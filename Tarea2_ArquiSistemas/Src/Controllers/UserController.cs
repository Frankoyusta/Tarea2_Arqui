using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tarea2_ArquiSistemas.Src.Dto;
using Tarea2_ArquiSistemas.Src.Services.Interfaces;

namespace Tarea2_ArquiSistemas.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpPost]
        public async Task<ActionResult<CreateUserResponseDto>> CreateUser(CreateUserDto createUserDto, string token)
        {
           try
           {
             Console.WriteLine("Creating user");
             var response = await _userService.CreateUser(createUserDto,token);
             return response;
           }
           catch (System.Exception)
           {
            
            throw;
           }
        }
        
    }
}