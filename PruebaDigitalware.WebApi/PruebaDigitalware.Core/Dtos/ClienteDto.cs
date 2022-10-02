using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDigitalware.Core.Dtos
{
    public class ClienteDto
    {
        public ClienteDto()
        {
            Venta = new HashSet<VentaDto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public virtual ICollection<VentaDto> Venta { get; set; }
    }
}
