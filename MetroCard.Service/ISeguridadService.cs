using MetroCard.Service.Dominio;
using MetroCard.Service.Errores;
using MetroCard.Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MetroCard.Service
{    
    [ServiceContract]
    public interface ISeguridadService
    {
        [FaultContract(typeof(RepetidorException))]
        [OperationContract]
        UsuarioResponse AutenticarUsuario(Usuario Usuario);
    }
}
