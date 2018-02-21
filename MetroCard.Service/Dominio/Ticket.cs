using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MetroCard.Service.Dominio
{
    public class Ticket
    {
        [DataMember]
        public int IdTicket { get; set; }

        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public DateTime FechaVigencia { get; set; }

        [DataMember]
        public bool Estado { get; set; }
    }
}