using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEKTON.Domain.Aggregates.PageAgg;
using TEKTON.Domain.Aggregates.DescuentoAgg;

namespace TEKTON.Domain.Aggregates.DescuentoAgg
{
    public class DescuentoListarResponseReadOnly : Paginacion
    {
        public List<DescuentoResponseReadOnly> Descuentos { get; set; } = new List<DescuentoResponseReadOnly>();
    }
}
