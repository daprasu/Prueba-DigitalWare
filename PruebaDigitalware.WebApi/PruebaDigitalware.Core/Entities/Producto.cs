using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaDigitalware.Core.Entities
{
    public partial class Producto
    {
        public Producto()
        {
            VentaDetalles = new HashSet<VentaDetalle>();
        }

        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public int Existencia { get; set; }
        public int Precio { get; set; }

        public virtual ICollection<VentaDetalle> VentaDetalles { get; set; }
    }
}
