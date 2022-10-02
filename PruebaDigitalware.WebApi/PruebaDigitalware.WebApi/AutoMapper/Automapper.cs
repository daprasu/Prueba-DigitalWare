using AutoMapper;
using PruebaDigitalware.Core.Dtos;
using PruebaDigitalware.Core.Entities;

namespace PruebaDigitalware.WebApi.AutoMapper
{
    public class Automapper: Profile
    {
        public Automapper()
        {
            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Venta, VentaDto>().ReverseMap();
            CreateMap<VentaDetalle, VentaDetalleDto>().ReverseMap();
        }
    }
}
