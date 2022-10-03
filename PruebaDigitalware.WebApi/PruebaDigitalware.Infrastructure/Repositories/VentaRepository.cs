using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class VentaRepository : IVentaRepository
    {
        #region inyenccion dependencias
        protected IsaBDContext context;
        private readonly IMapper mapper;
        public VentaRepository(IsaBDContext _context, IMapper _mapper)
        {
            mapper = _mapper;
            context = _context;
        }
        #endregion

        #region Consultar
        public ResponseQuery<List<VentaDto>> Consultar(ResponseQuery<List<VentaDto>> response)
        {
            try
            {
                var lista = context.Venta
                .OrderBy(x => x.FechaVenta)
                .ToList();

                response.ObjetoResultado = mapper.Map<List<VentaDto>>(lista);
                response.Exitoso = true;
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;
                response.Exitoso = false;
                response.ObjetoResultado = new List<VentaDto>();
            }

            return response;
        }
        #endregion

        #region crear
        public ResponseRegister Crear(VentaDto input, ResponseRegister response)
        {
            try
            {
                var entidad = mapper.Map<Venta>(input);
                context.Venta.Add(entidad);
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
        public ResponseRegister Editar(VentaDto input, ResponseRegister response)
        {
            try
            {
                var entidadConsultada = context.Venta.Find(input.Id);
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
                var entidadConsultada = context.Venta.Find(id);
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
