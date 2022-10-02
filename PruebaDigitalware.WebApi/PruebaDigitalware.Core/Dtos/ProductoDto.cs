using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDigitalware.Core.Dtos
{
    public class ProductoDto
    {
        public ProductoDto()
        {
            VentaDetalles = new HashSet<VentaDetalleDto>();
        }

        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public int Existencia { get; set; }
        public int Precio { get; set; }

        public virtual ICollection<VentaDetalleDto> VentaDetalles { get; set; }
    }
}
