using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Tarea2_ArquiSistemas.Src.Models;

namespace Tarea2_ArquiSistemas.Src.Data
{
    public class DataSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataContext>();
            
                 if (!context.Users.Any() || context.Users.All(u => u.EstaEliminado))
                    {
                        var faker = new Faker<User>()
                            .RuleFor(u => u.UUID, f => Guid.NewGuid().ToString())
                            .RuleFor(u => u.Nombre, f => f.Person.FirstName)
                            .RuleFor(u => u.Apellidos, f => f.Person.LastName)
                            .RuleFor(u => u.CorreoElectrónico, f => f.Person.Email)
                            .RuleFor(u => u.Contrasenia, f => BCrypt.Net.BCrypt.HashPassword("password"))
                            .RuleFor(u => u.EstaEliminado, f => false);

                        var users = faker.Generate(100); 

                        context.Users.AddRange(users);
                        context.SaveChanges();
                    }
                }
            
            }
        }
 }
