using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarea2_ArquiSistemas.Src.Models;
using Tarea2_ArquiSistemas.Src.Dto;

namespace Tarea2_ArquiSistemas.Src.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> InsertUserInDb(User user);
        Task<bool> verifyEmail(string email);
        Task<User> getUserByUUID(string UUID);
        Task<List<User>> GetUsers(int page, int cantUser);
        Task<bool> UpdateUser(string UUID, UpdateUserDto updateUserDto);

    }
}