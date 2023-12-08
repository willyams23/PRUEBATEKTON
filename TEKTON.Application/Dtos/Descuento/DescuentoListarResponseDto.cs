using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEKTON.Application.Dtos.Page;
using TEKTON.Domain.Aggregates.DescuentoAgg;

namespace TEKTON.Application.Dtos.Descuento
{
    public class DescuentoListarResponseDto : PaginacionDto
    {
        public List<DescuentoResponseReadOnly> Descuentos { get; set; } = new List<DescuentoResponseReadOnly>();

    }
}
