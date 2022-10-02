﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDigitalware.Core.Dtos
{
    internal class VentaDetalleDto
    {
        public int Id { get; set; }
        public int? ProductoId { get; set; }
        public int? CantidadProducto { get; set; }
        public int? VentaId { get; set; }

        public virtual ProductoDto Producto { get; set; }
        public virtual VentaDto Venta { get; set; }
    }
}
