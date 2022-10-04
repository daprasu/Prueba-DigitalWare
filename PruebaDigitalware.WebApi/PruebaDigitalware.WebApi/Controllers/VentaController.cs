using Microsoft.AspNetCore.Mvc;
using PruebaDigitalware.Core.Dtos;
using PruebaDigitalware.Core.Interfaces;
using PruebaDigitalware.Core.Responses;
using System.Collections.Generic;

namespace PruebaDigitalware.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        #region Constructor
        readonly IVentaRepository ventaRepository;
        public VentaController(IVentaRepository _ventaRepository)
        {
            ventaRepository = _ventaRepository;
        }
        #endregion

        #region Consultar
        [HttpGet]
        [Route("consultar")]
        public IActionResult Consultar()
        {
            ResponseQuery<List<VentaDto>> response = new ResponseQuery<List<VentaDto>>();
            ventaRepository.Consultar(response);
            return Ok(response);
        }
        #endregion

        #region Crear
        [HttpPost]
        [Route("crear")]
        public IActionResult Crear(VentaDto input)
        {
            ResponseRegister response = new ResponseRegister();
            ventaRepository.Crear(input, response);
            return Ok(response);
        }
        #endregion

        #region Editar
        [HttpPut]
        [Route("editar")]
        public IActionResult Editar(VentaDto input)
        {
            ResponseRegister response = new ResponseRegister();
            ventaRepository.Editar(input, response);
            return Ok(response);
        }
        #endregion

        #region Eliminar
        [HttpPost]
        [Route("eliminar")]
        public IActionResult Eliminar(int id)
        {
            ResponseRegister response = new ResponseRegister();
            ventaRepository.Eliminar(id, response);
            return Ok(response);
        }
        #endregion
    }
}
