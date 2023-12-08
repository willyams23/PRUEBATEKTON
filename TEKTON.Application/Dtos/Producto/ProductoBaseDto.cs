using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEKTON.Application.Dtos.Producto
{
    public class ProductoBaseDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int StatusId { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }

        public int PorcentajeDescuento { get; set; }

        //Otros
        public double Peso { get; set; }
        public int Anio { get; set; }
        public string Color { get; set; } = string.Empty;

        public string UsuarioRegistro { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; }
        public string UsuarioActualizacion { get; set; } = string.Empty;
        public DateTime? FechaActualizacion { get; set; }
    }
}
