using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea2_ArquiSistemas.Src.Dto
{
    public class CreateUserDto
    {   [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Nombre { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string CorreoElectrónico { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Apellidos { get; set; } = null!;

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Contrasenia { get; set; } = null!;
        
    }
}