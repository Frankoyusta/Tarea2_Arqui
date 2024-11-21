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
        Task<ActionResult<CreateUserResponseDto>> CreateUser(CreateUserDto createUserDto,string token);
    }
}