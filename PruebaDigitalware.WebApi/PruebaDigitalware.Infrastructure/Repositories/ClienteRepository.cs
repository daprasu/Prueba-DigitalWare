using AutoMapper;
using PruebaDigitalware.Core.Dtos;
using PruebaDigitalware.Core.Entities;
using PruebaDigitalware.Core.Interfaces;
using PruebaDigitalware.Core.Responses;
using PruebaDigitalware.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebaDigitalware.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        #region inyenccion dependencias
        protected IsaBDContext context;
        private readonly IMapper mapper;
        public ClienteRepository(IsaBDContext _context, IMapper _mapper)
        {
            mapper = _mapper;
            context = _context;
        }
        #endregion

        #region Consultar
        public ResponseQuery<List<ClienteDto>> Consultar(ResponseQuery<List<ClienteDto>> response)
        {
            try
            {
                var lista = context.Clientes
                .OrderBy(x => x.Nombre)
                .ToList();

                response.ObjetoResultado = mapper.Map<List<ClienteDto>>(lista);
                response.Exitoso = true;
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;
                response.Exitoso = false;
                response.ObjetoResultado = new List<ClienteDto>();
            }

            return response;
        }
        #endregion

        #region crear
        public ResponseRegister Crear(ClienteDto input, ResponseRegister response)
        {
            try
            {
                var entidad = mapper.Map<Cliente>(input);
                context.Clientes.Add(entidad);
                context.SaveChanges();
                response.CodigoResultado = entidad.Id.ToString();
                response.Exitoso = true;
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;
                response.Exitoso = false;
                response.CodigoResultado = null;
            }

            return response;
        }
        #endregion

        #region Editar
        public ResponseRegister Editar(ClienteDto input, ResponseRegister response)
        {
            try
            {
                var entidadConsultada = context.Clientes.Find(input.Id);
                mapper.Map(input, entidadConsultada);
                context.SaveChanges();

                response.CodigoResultado = input.Id.ToString();
                response.Exitoso = true;
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;
                response.Exitoso = false;
                response.CodigoResultado = null;
            }

            return response;
        }
        #endregion

        #region Eliminar
        public ResponseRegister Eliminar(int id, ResponseRegister response)
        {
            try
            {
                var entidadConsultada = context.Clientes.Find(id);
                context.Remove(entidadConsultada);
                context.SaveChanges();
                response.CodigoResultado = id.ToString();
                response.Exitoso = true;
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;
                response.Exitoso = false;
                response.CodigoResultado = null;
            }

            return response;
        }
        #endregion

      
    }
}
