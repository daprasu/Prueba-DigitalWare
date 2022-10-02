using Microsoft.AspNetCore.Mvc;
using PruebaDigitalware.Core.Dtos;
using PruebaDigitalware.Core.Interfaces;
using PruebaDigitalware.Core.Responses;
using System.Collections.Generic;

namespace PruebaDigitalware.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaDetalleController : ControllerBase
    {
        #region Inyeccion Dependencias 
        readonly IVentaDetalleRepository ventaDetalleRepository;
        public VentaDetalleController(IVentaDetalleRepository _ventaDetalleRepository)
        {
            ventaDetalleRepository = _ventaDetalleRepository;
        }
        #endregion

        #region Consultar
        [HttpGet]
        [Route("consultar")]
        public IActionResult Consultar()
        {
            ResponseQuery<List<VentaDetalleDto>> response = new ResponseQuery<List<VentaDetalleDto>>();
            ventaDetalleRepository.Consultar(response);
            return Ok(response);
        }
        #endregion

        #region Crear
        [HttpPost]
        [Route("crear")]
        public IActionResult Crear(VentaDetalleDto input)
        {
            ResponseRegister response = new ResponseRegister();
            ventaDetalleRepository.Crear(input, response);
            return Ok(response);
        }
        #endregion

        #region Editar
        [HttpPut]
        [Route("editar")]
        public IActionResult Editar(VentaDetalleDto input)
        {
            ResponseRegister response = new ResponseRegister();
            ventaDetalleRepository.Editar(input, response);
            return Ok(response);
        }
        #endregion

        #region Eliminar
        [HttpPost]
        [Route("eliminar")]
        public IActionResult Eliminar(int id)
        {
            ResponseRegister response = new ResponseRegister();
            ventaDetalleRepository.Eliminar(id, response);
            return Ok(response);
        }
        #endregion
    }
}
