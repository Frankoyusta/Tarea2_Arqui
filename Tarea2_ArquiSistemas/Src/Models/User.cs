using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tarea2_ArquiSistemas.Src.Models
{
    public class User
    {   
        [Key]
        public string UUID { get; set; } = null!;
        
        public string Nombre { get; set; } = null!;
        public string CorreoElectrónico { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public bool EstaEliminado { get; set; }
    }
}