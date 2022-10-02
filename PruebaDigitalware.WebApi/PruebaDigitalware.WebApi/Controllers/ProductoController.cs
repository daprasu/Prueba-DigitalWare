using Microsoft.AspNetCore.Mvc;
using PruebaDigitalware.Core.Dtos;
using PruebaDigitalware.Core.Interfaces;
using PruebaDigitalware.Core.Responses;
using System.Collections.Generic;

namespace PruebaDigitalware.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        #region Inyeccion Dependencias 
        readonly IProductoRepository productoRepository;
        public ProductoController(IProductoRepository _productoRepository)
        {
            productoRepository = _productoRepository;
        }
        #endregion

        #region Consultar
        [HttpGet]
        [Route("consultar")]
        public IActionResult Consultar()
        {
            ResponseQuery<List<ProductoDto>> response = new ResponseQuery<List<ProductoDto>>();
            productoRepository.Consultar(response);
            return Ok(response);
        }
        #endregion

        #region Crear
        [HttpPost]
        [Route("crear")]
        public IActionResult Crear(ProductoDto input)
        {
            ResponseRegister response = new ResponseRegister();
            productoRepository.Crear(input, response);
            return Ok(response);
        }
        #endregion

        #region Editar
        [HttpPut]
        [Route("editar")]
        public IActionResult Editar(ProductoDto input)
        {
            ResponseRegister response = new ResponseRegister();
            productoRepository.Editar(input, response);
            return Ok(response);
        }
        #endregion

        #region Eliminar
        [HttpPost]
        [Route("eliminar")]
        public IActionResult Eliminar(int id)
        {
            ResponseRegister response = new ResponseRegister();
            productoRepository.Eliminar(id, response);
            return Ok(response);
        }
        #endregion
    }
}
