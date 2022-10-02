using System;
using System.Collections.Generic;

namespace PruebaDigitalware.Core.Dtos
{
    public class VentaDto
    {
        public VentaDto()
        {
            VentaDetalles = new HashSet<VentaDetalleDto>();
        }

        public int Id { get; set; }
        public DateTime FechaVenta { get; set; }
        public int TotalVenta { get; set; }
        public int? ClienteId { get; set; }

        public virtual ClienteDto Cliente { get; set; }
        public virtual ICollection<VentaDetalleDto> VentaDetalles { get; set; }
    }
}
