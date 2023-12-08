using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEKTON.Domain.Aggregates.DescuentoAgg;

namespace TEKTON.Domain.Aggregates.DescuentoAgg
{
    public interface IDescuentoRepository
    {
        Task<DescuentoListarResponseReadOnly> ListarDescuentos();
        Task<DescuentoResponseReadOnly> BuscarRegistro(int IdDescuento);
    }
}
