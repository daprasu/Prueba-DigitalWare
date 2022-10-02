using System.Collections.Generic;

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
