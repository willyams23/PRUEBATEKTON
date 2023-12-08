using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEKTON.Application.QueryFilters.Producto
{
    public class PostProductoGuardar
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int StatusId { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }

        public double Peso { get; set; }
        public int Anio { get; set; }
        public string Color { get; set; } = string.Empty;
        public string UsuarioRegistro { get; set; } = string.Empty;
    }
}
