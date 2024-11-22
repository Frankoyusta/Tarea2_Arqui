using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tarea2_ArquiSistemas.Src.Dto;

namespace Tarea2_ArquiSistemas.Src.Services.Interfaces
{
    public interface IUserService
    {
        Task<ActionResult<CreateUserResponseDto>> CreateUser(CreateUserDto createUserDto);
        Task<ActionResult<GetUserDto>> GetUserById(string uuid);
        Task<ActionResult<List<GetUserDto>>> GetUsers(int page,int cantUser);
        Task<bool> UpdateUser(string uuid, UpdateUserDto updateUserDto);

        
    }
}