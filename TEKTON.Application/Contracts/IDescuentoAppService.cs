using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEKTON.Application.Dtos.Descuento;

namespace TEKTON.Application.Contracts
{
    public interface IDescuentoAppService
    {
        Task<DescuentoListarResponseDto> ListarDescuentos();
        Task<DescuentoResponseDto> BuscarRegistro(int IdDescuento);
    }
}
