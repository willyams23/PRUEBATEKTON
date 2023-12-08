using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEKTON.Domain.Aggregates.ProductoAgg
{
    public class ProductoListarRequestReadOnly
    {
        public string? Search { get; set; }
        public int? PageIndex { get; set;}

    }
}
