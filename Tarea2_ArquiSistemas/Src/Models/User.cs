using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea2_ArquiSistemas.Src.Models
{
    public class User
    {
        public string uuid { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string CorreoElectrónico { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        bool EstaEliminado { get; set; }
    }
}