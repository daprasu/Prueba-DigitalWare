using System.Text.Json.Serialization;

namespace PruebaDigitalware.Core.Dtos
{
    public class VentaDetalleDto
    {
        public int Id { get; set; }
        public int? ProductoId { get; set; }
        public int? CantidadProducto { get; set; }
        public int? VentaId { get; set; }

        public virtual ProductoDto Producto { get; set; }
        [JsonIgnore]
        public virtual VentaDto Venta { get; set; }
    }
}
