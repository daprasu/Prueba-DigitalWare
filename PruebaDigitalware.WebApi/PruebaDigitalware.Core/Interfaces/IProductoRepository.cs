using PruebaDigitalware.Core.Dtos;
using PruebaDigitalware.Core.Responses;
using System.Collections.Generic;

namespace PruebaDigitalware.Core.Interfaces
{
    public interface IProductoRepository
    {
        public ResponseQuery<List<ProductoDto>> Consultar(ResponseQuery<List<ProductoDto>> response);
        public ResponseRegister Crear(ProductoDto input, ResponseRegister response);
        public ResponseRegister Editar(ProductoDto input, ResponseRegister response);
        ResponseRegister Eliminar(int id, ResponseRegister response);
    }
}
