using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEKTON.Application.Dtos.Page;
using TEKTON.Domain.Aggregates.ProductoAgg;

namespace TEKTON.Application.Dtos.Producto
{
    public class ProductoListarResponseDto : PaginacionDto
    {
        public List<ProductoResponseDto> Productos { get; set; } = new List<ProductoResponseDto>();
        //public List<ProductoResponseReadOnly> Productos { get; set; } = new List<ProductoResponseReadOnly>();

    }
}
