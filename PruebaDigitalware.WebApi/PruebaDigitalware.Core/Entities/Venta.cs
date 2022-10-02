using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaDigitalware.Core.Entities
{
    public partial class Venta
    {
        public Venta()
        {
            VentaDetalles = new HashSet<VentaDetalle>();
        }

        public int Id { get; set; }
        public DateTime FechaVenta { get; set; }
        public int TotalVenta { get; set; }
        public int? ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<VentaDetalle> VentaDetalles { get; set; }
    }
}
