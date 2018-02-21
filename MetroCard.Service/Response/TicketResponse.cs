using MetroCard.Service.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MetroCard.Service.Response
{
    [DataContract]
    public class TicketResponse
    {
        [DataMember]
        public bool EsValido { get; set; }

        [DataMember]
        public string Mensaje { get; set; }

        [DataMember]
        public Ticket Ticket { get; set; }
    }
}