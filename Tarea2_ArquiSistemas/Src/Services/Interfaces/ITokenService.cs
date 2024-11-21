using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea2_ArquiSistemas.Src.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(string email);
    }
}