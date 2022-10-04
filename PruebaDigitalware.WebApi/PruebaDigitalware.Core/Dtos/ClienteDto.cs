using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public virtual ICollection<VentaDto> Venta { get; set; }
    }
}
