using PruebaDigitalware.Core.Dtos;
using PruebaDigitalware.Core.Responses;
using System.Collections.Generic;

namespace PruebaDigitalware.Core.Interfaces
{
    public interface IVentaDetalleRepository
    {
        public ResponseQuery<List<VentaDetalleDto>> Consultar(ResponseQuery<List<VentaDetalleDto>> response);
        public ResponseRegister Crear(VentaDetalleDto input, ResponseRegister response);
        public ResponseRegister Editar(VentaDetalleDto input, ResponseRegister response);
        ResponseRegister Eliminar(int id, ResponseRegister response);
    }
}
