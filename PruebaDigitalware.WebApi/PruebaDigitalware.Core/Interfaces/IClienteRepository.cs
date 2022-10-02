using PruebaDigitalware.Core.Dtos;
using PruebaDigitalware.Core.Responses;
using System.Collections.Generic;

namespace PruebaDigitalware.Core.Interfaces
{
    public interface IClienteRepository
    {
        public ResponseQuery<List<ClienteDto>> Consultar(ResponseQuery<List<ClienteDto>> response);
        public ResponseRegister Crear(ClienteDto input, ResponseRegister response);
        public ResponseRegister Editar(ClienteDto input, ResponseRegister response);
        ResponseRegister Eliminar(int id, ResponseRegister response);
    }
}
