using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tarea2_ArquiSistemas.Src.Models;

namespace Tarea2_ArquiSistemas.Src.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
        public required DbSet<User> Users { get; set; }
}
}