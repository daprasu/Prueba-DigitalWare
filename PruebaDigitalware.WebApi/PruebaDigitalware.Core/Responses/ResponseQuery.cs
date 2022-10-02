using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDigitalware.Core.Responses
{
    [Serializable]
    [DataContract]
    public class ResponseQuery<T>
    {
        /// <summary>
        /// True: indica que la operación se ejecutó exitósamene.
        /// </summary>
        [DataMember]
        public bool Exitoso { get; set; }

        /// <summary>
        /// Código de fallo en caso de presentarse un error.
        /// </summary>
        [DataMember]
        public string CodigoResultado { get; set; }

        /// <summary>
        /// Detalle del error que pueda presentarse.
        /// </summary>
        [DataMember]
        public string Mensaje { get; set; }

        /// <summary>
        /// Entidad compuesta con información 
        /// </summary>
        [DataMember]
        public T ObjetoResultado { get; set; }
    }
}
