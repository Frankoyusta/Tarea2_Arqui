using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea2_ArquiSistemas.Src.Dto
{
    public class CreateUserResponseDto
    {
        public string Token { get; set; } = null!;
        public string UUID { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string CorreoElectrónico { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
    }
}