using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace MetroCard.Service.Utilitario
{
    public class Conexion
    {
        public static string cnMetroCard = ConfigurationManager.ConnectionStrings["cnMetroCard"].ConnectionString;
        //public static string cnMetropolitano = ConfigurationManager.ConnectionStrings["cnMetropolitano"].ConnectionString;

    }
}