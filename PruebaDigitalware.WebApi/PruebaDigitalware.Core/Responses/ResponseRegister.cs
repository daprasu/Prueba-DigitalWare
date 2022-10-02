using System.Collections.Generic;

namespace PruebaDigitalware.Core.Responses
{
    public class ResponseRegister
    {
        /// <summary>
        /// Estado de la solicitud
        /// </summary>
        public bool Exitoso { get; set; }
        /// <summary>
        /// Codigo del resultado de la solicitud
        /// </summary>
        public string CodigoResultado { get; set; }
        /// <summary>
        /// Mensaje de advertencia o error de la solicitud
        /// </summary>
        public string Mensaje { get; set; }
        /// <summary>
        /// Lista de mensajes que pueden contener errores o advertencias
        /// </summary>
        public List<string> ListaMensajes { get; set; }
    }
}
