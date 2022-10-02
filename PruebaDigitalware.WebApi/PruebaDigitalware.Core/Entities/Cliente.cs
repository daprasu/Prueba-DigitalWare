using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaDigitalware.Core.Entities
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Venta>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
