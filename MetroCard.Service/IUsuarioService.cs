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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsuarioService" in both code and config file together.
    [ServiceContract]
    public interface IUsuarioService
    {
        [FaultContract(typeof(RepetidorException))]
        [OperationContract]
        UsuarioResponse RegistrarUsuario(Usuario usuario);        

        [FaultContract(typeof(RepetidorException))]
        [OperationContract]
        UsuarioResponse ObtenerUsuario(Usuario Usuario);


        [FaultContract(typeof(RepetidorException))]
        [OperationContract]
        UsuarioResponse RegistrarTarjetaUsuario(Tarjeta Tarjeta);

        [FaultContract(typeof(RepetidorException))]
        [OperationContract]
        List<Tarjeta> ListarTarjetaUsuario(Usuario Usuario);

        [FaultContract(typeof(RepetidorException))]
        [OperationContract]
        List<Movimiento> ListarTarjetaMovimientoUsuario(Tarjeta Tarjeta);
    }
}