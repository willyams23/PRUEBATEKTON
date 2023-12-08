using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEKTON.Domain.Aggregates.ProductoAgg
{
    public class ProductoResponseReadOnly : ProductoBaseReadOnly
    {
        public string StatusName { get; set; } = string.Empty;
        public double Discount => (Price * PorcentajeDescuento) / 100;
        public double FinalPrice => (Price * (100 - PorcentajeDescuento)) / 100;
    }
}
