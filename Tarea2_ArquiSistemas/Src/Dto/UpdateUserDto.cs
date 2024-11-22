using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea2_ArquiSistemas.Src.Dto
{
    public class UpdateUserDto
    {
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;

    }
}