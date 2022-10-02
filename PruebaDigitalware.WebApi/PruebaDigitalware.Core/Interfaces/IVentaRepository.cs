using PruebaDigitalware.Core.Dtos;
using PruebaDigitalware.Core.Responses;
using System.Collections.Generic;

namespace PruebaDigitalware.Core.Interfaces
{
    public interface IVentaRepository
    {
        public ResponseQuery<List<VentaDto>> Consultar(ResponseQuery<List<VentaDto>> response);
        public ResponseRegister Crear(VentaDto input, ResponseRegister response);
        public ResponseRegister Editar(VentaDto input, ResponseRegister response);
        ResponseRegister Eliminar(int id, ResponseRegister response);
    }
}
