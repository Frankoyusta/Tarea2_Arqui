using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tarea2_ArquiSistemas.Src.Dto;
using Tarea2_ArquiSistemas.Src.Services.Interfaces;

namespace Tarea2_ArquiSistemas.Src.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpPost]
        public async Task<ActionResult<CreateUserResponseDto>> CreateUser(CreateUserDto createUserDto)
        {
           try
           {
             Console.WriteLine("Creating user");
             var response = await _userService.CreateUser(createUserDto);
             return response;
           }
           catch (System.Exception)
           {
            
            throw;
           }
        }

        [HttpGet("{uuid}")]
        public async Task<ActionResult<GetUserDto>> GetUserById(string uuid)
        {
            try
            {
                Console.WriteLine("Getting user by id");
                var response = await _userService.GetUserById(uuid);
                return response;
            }
            catch (Exception ex)
            {
                
                 return new ObjectResult(new { Message = "Hubo un error con el servidor, intente nuevamente en otro momento" + ex.ToString() }) { StatusCode = 500 };
            }
        }

        [HttpGet("{page}/{cantUser}")]
        public async Task<ActionResult<List<GetUserDto>>> GetUsers(int page,int cantUser)
        {
            try
            {
                Console.WriteLine("Getting user by id");
                var response = await _userService.GetUsers(page,cantUser);
                return response;
            }
            catch (Exception ex)
            {
                
                 return new ObjectResult(new { Message = "Hubo un error con el servidor, intente nuevamente en otro momento" + ex.ToString() }) { StatusCode = 500 };
            }
        }

        [HttpPatch("{uuid}")]
        public async Task<IActionResult> UpdateUser(string uuid, [FromBody] UpdateUserDto updateUserDto)
        {
            try
            {
                var result = await _userService.UpdateUser(uuid, updateUserDto);
                if (result == null)
                {
                    return NotFound(new { Message = "User not found" });
                }
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return new ObjectResult(new { Message = "Hubo un error con el servidor, intente nuevamente en otro momento" + ex.ToString() }) { StatusCode = 500 };
            }
        }

       [HttpDelete("{uuid}")]
        public async Task<IActionResult> DeleteUser(string uuid)
        {
            try
            {
                var result = await _userService.DeleteUser(uuid);
                if (!result)
                {
                    return NotFound(new { Message = "User not found" });
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return new ObjectResult(new { Message = "Hubo un error con el servidor, intente nuevamente en otro momento" + ex.ToString() }) { StatusCode = 500 };
            }
        }
        
    }
}