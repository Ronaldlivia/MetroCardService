using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MetroCard.Service.Dominio.Metropolitano
{
    [DataContract]
    public class Tarjeta
    {
        [DataMember]
        public int IdTarjeta { get; set; }

        [DataMember]
        public string CodigoTarjeta { get; set; }

        [DataMember]
        public DateTime FechaVigencia { get; set; }

        [DataMember]
        public bool Estado { get; set; }
    }
}