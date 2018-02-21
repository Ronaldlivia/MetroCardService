using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MetroCard.Service.Dominio
{
    public class Tarjeta
    {
        [DataMember]
        public int IdTarjeta { get; set; }

        [DataMember]
        public int IdUsuario { get; set; }

        [DataMember]
        public string NroTarjeta { get; set; }

        [DataMember]
        public decimal Saldo { get; set; }

        [DataMember]
        public DateTime FechaSaldo { get; set; }

        [DataMember]
        public DateTime FechaCreacion { get; set; }

        [DataMember]
        public bool Estado { get; set; }
    }
}