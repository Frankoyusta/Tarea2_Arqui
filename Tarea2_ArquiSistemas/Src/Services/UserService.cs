using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tarea2_ArquiSistemas.Src.Dto;
using Tarea2_ArquiSistemas.Src.Repositories.Interfaces;
using Tarea2_ArquiSistemas.Src.Services.Interfaces;

namespace Tarea2_ArquiSistemas.Src.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        

        public UserService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        public async Task<ActionResult<CreateUserResponseDto>> CreateUser(CreateUserDto createUserDto,string token)
        {
            try
            {
                //Agregar validaciones de token para saber si el usuario esta autenticado
                if (await _userRepository.verifyEmail(createUserDto.CorreoElectrónico))
                {
                    return new BadRequestObjectResult(new { Message = "Hubo un error con sus credenciales, por favor intente nuevamente" });
                }

                var uuidUser = Guid.NewGuid();
                var salt = BCrypt.Net.BCrypt.GenerateSalt(12);
                var ContraseniaHash = BCrypt.Net.BCrypt.HashPassword(createUserDto.Contrasenia, salt);

                var user = new Models.User
                {
                    UUID = uuidUser.ToString(),
                    Nombre = createUserDto.Nombre,
                    CorreoElectrónico = createUserDto.CorreoElectrónico,
                    Apellidos = createUserDto.Apellidos,
                    Contrasenia = ContraseniaHash,
                    EstaEliminado = false
                };

                var tokenResponse = _tokenService.CreateToken(user.CorreoElectrónico);

                await _userRepository.InsertUserInDb(user);

                var response = new CreateUserResponseDto
                {
                    Token = tokenResponse,
                    Nombre = user.Nombre,
                    Apellidos = user.Apellidos,
                    CorreoElectrónico = user.CorreoElectrónico
                };

                return new CreatedAtActionResult(nameof(CreateUser), "User", new { id = user.UUID }, response);
            }
            catch (Exception ex)
            {
                return new ObjectResult(new { Message = "Hubo un error con el servidor, intente nuevamente en otro momento" }) { StatusCode = 500 };
            }
        }


    }
}