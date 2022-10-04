using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public virtual ICollection<VentaDetalleDto> VentaDetalles { get; set; }
    }
}
