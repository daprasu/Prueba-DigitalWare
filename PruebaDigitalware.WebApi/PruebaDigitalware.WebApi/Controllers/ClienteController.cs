using Microsoft.AspNetCore.Mvc;
using PruebaDigitalware.Core.Dtos;
using PruebaDigitalware.Core.Interfaces;
using PruebaDigitalware.Core.Responses;
using System.Collections.Generic;

namespace PruebaDigitalware.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        #region Inyeccion Dependencias 
        readonly IClienteRepository clienteRepository;
        public ClienteController(IClienteRepository _clienteRepository)
        {
            clienteRepository = _clienteRepository;
        }
        #endregion

        #region Consultar
        [HttpGet]
        [Route("consultar")]
        public IActionResult Consultar()
        {
            ResponseQuery<List<ClienteDto>> response = new ResponseQuery<List<ClienteDto>>();
            clienteRepository.Consultar(response);
            return Ok(response);
        }
        #endregion

        #region Crear
        [HttpPost]
        [Route("crear")]
        public IActionResult Crear(ClienteDto input)
        {
            ResponseRegister response = new ResponseRegister();
            clienteRepository.Crear(input, response);
            return Ok(response);
        }
        #endregion

        #region Editar
        [HttpPut]
        [Route("editar")]
        public IActionResult Editar(ClienteDto input)
        {
            ResponseRegister response = new ResponseRegister();
            clienteRepository.Editar(input, response);
            return Ok(response);
        }
        #endregion

        #region Eliminar
        [HttpPost]
        [Route("eliminar")]
        public IActionResult Eliminar(int id)
        {
            ResponseRegister response = new ResponseRegister();
            clienteRepository.Eliminar(id, response);
            return Ok(response);
        }
        #endregion
    }
}
