using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEKTON.Domain.Aggregates.PageAgg;

namespace TEKTON.Domain.Aggregates.ProductoAgg
{
    public class ProductoListarResponseReadOnly : Paginacion
    {
        public List<ProductoResponseReadOnly> Productos { get; set; } = new List<ProductoResponseReadOnly>();
    }
}
