using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MetroCard.Service.Dominio
{
    [DataContract]
    public class Usuario
    {
        [DataMember]
        public int IdUsuario { get; set; }

        [DataMember]
        public string Nombres { get; set; }

        [DataMember]
        public string ApellidoPaterno { get; set; }
            
        [DataMember]
        public string ApellidoMaterno { get; set; }

        [DataMember]
        public int IdTipoDocumento { get; set; }

        [DataMember]
        public string NroDocumento { get; set; }

        [DataMember]
        public DateTime FechaNacimiento { get; set; }

        [DataMember]
        public string NroTelefono { get; set; }

        [DataMember]
        public string Correo { get; set; }

        [DataMember]
        public string Clave { get; set; }

        [DataMember]
        public DateTime FechaCreacion { get; set; }

        [DataMember]
        public bool Estado { get; set; }
    }
}