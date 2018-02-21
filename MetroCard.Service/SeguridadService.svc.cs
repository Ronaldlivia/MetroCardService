using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MetroCard.Service.Dominio;
using MetroCard.Service.Errores;
using MetroCard.Service.Persistencia;
using MetroCard.Service.Response;

namespace MetroCard.Service
{        
    public class SeguridadService : ISeguridadService
    {
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();

        public UsuarioResponse AutenticarUsuario(Usuario Usuario)
        {
            UsuarioResponse objUsuarioResponse = new UsuarioResponse();
            objUsuarioResponse.EsValido = false;

            try
            {
                if (Usuario.Correo == string.Empty || Usuario.Clave == string.Empty)
                {
                    objUsuarioResponse.Mensaje = "Ingrese sus credenciales";
                    return objUsuarioResponse;
                }

                int idUsuario = objUsuarioDAO.Autenticar(Usuario);

                if (idUsuario == 0)
                {
                    objUsuarioResponse.Mensaje = "El usuario no existe.";
                    return objUsuarioResponse;
                }
                else
                {
                    objUsuarioResponse.EsValido = true;
                    objUsuarioResponse.Mensaje = "El usuario si existe.";
              
                    objUsuarioResponse.Usuario = new Usuario { IdUsuario = idUsuario  , Estado = true};
                }
            }
            catch (Exception ex)
            {
                objUsuarioResponse.Mensaje = "Se presentró un error al autenticar el usuario. " + ex.Message;
            }            
           
            return objUsuarioResponse;
        }
    }
}
