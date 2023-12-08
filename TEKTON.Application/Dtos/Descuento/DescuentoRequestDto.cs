using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEKTON.Application.Dtos.Descuento
{
    public class DescuentoRequestDto
    {
        public string id { get; set; } = string.Empty;
        public int valor { get; set; }
    }
}
