using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEKTON.Domain.Aggregates.PageAgg
{
    public class Paginacion
    {
        public string? Search { get; set; }
        public int TotalRegistros { get; set; }
        public int PaginaActual { get; set; }
        public int TotalPaginas { get; set; }
        public int TamanioPagina { get; set; }
    }
}
