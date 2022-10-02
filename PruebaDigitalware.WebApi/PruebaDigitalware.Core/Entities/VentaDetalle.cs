using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaDigitalware.Core.Entities
{
    public partial class VentaDetalle
    {
        public int Id { get; set; }
        public int? ProductoId { get; set; }
        public int? CantidadProducto { get; set; }
        public int? VentaId { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Venta Venta { get; set; }
    }
}
