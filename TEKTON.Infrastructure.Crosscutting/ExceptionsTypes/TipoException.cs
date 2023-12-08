using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEKTON.Infrastructure.Crosscutting.ExceptionsTypes
{
    public enum TipoException
    {
        ReglaNegocio = 1,
        Validacion = 2,
        NoAutorizado = 3,
        Otro = 4,
        Interna = 5
    }
}
