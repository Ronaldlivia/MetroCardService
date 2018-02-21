using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MetroCard.Service.Dominio
{
    public class Movimiento
    {
        [DataMember]
        public int IdTarjeta { get; set; }

        [DataMember]
        public string NroTarjeta { get; set; }

        [DataMember]
        public decimal Saldo { get; set; }

        [DataMember]
        public DateTime FechaSaldo { get; set; }

        [DataMember]
        public decimal SaldoAnterior { get; set; }

        [DataMember]
        public DateTime FechaMovimiento { get; set; }
    }
}