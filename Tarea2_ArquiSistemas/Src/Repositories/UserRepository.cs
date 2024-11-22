using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tarea2_ArquiSistemas.Src.Data;
using Tarea2_ArquiSistemas.Src.Models;
using Tarea2_ArquiSistemas.Src.Repositories.Interfaces;
using Tarea2_ArquiSistemas.Src.Dto;

namespace Tarea2_ArquiSistemas.Src.Repositories
{
    public class UserRepository : IUserRepository
    {   
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> InsertUserInDb(User user)
        {
            try
            {
                Console.WriteLine("Creating user in service");
                await _dataContext.Users.AddAsync(user);
                await _dataContext.SaveChangesAsync();
                return true;
                
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public async Task<bool> verifyEmail(string email)
        {
            var response = await _dataContext.Users.AnyAsync(user => user.CorreoElectrónico == email);
            Console.WriteLine("Verificando correo" + response.ToString());
            return response;
        }

        public async Task<User> getUserByUUID(string UUID)
        {
            var response = await _dataContext.Users.FirstOrDefaultAsync(user => user.UUID == UUID);
            return response;
        }

        public Task<List<User>> GetUsers(int page, int cantUser)
        {
            var response = _dataContext.Users.Skip(page * cantUser).Take(cantUser).ToListAsync();
            return response;
        }

        public async Task<bool> UpdateUser(string uuid, UpdateUserDto updateUserDto)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.UUID == uuid);
            if (user == null)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(updateUserDto.Nombre))
            {
                user.Nombre = updateUserDto.Nombre;
            }
            if (!string.IsNullOrEmpty(updateUserDto.Apellidos))
            {
                user.Apellidos = updateUserDto.Apellidos;
            }
            if (!string.IsNullOrEmpty(updateUserDto.CorreoElectronico))
            {
                user.CorreoElectrónico = updateUserDto.CorreoElectronico;
            }
            if (!string.IsNullOrEmpty(updateUserDto.Contrasenia))
            {
                user.Contrasenia = updateUserDto.Contrasenia;
            }
            _dataContext.Users.Update(user);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}