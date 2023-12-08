using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEKTON.Domain.Aggregates.DescuentoAgg
{
    public class DescuentoResponseReadOnly
    {
        public string id { get; set; } = string.Empty;
        public int valor { get; set; } 
    }
}
