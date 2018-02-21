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
    public class UsuarioService : IUsuarioService
    {
        UsuarioDAO objUsuarioDAO = new UsuarioDAO();

        public UsuarioResponse RegistrarUsuario(Usuario Usuario)
        {
            UsuarioResponse objUsuarioResponse = new UsuarioResponse();
            objUsuarioResponse.EsValido = false;

            try
            {
                if (string.IsNullOrEmpty(Usuario.Nombres))
                {
                    objUsuarioResponse.Mensaje = "Ingrese el nombre del usuario.";
                    return objUsuarioResponse;
                }
                if (string.IsNullOrEmpty(Usuario.ApellidoPaterno))
                {
                    objUsuarioResponse.Mensaje = "Ingrese el apellido paterno del usuario.";
                    return objUsuarioResponse;
                }

                if (string.IsNullOrEmpty(Usuario.ApellidoMaterno))
                {
                    objUsuarioResponse.Mensaje = "Ingrese el apellido materno del usuario.";
                    return objUsuarioResponse;
                }

                if (Usuario.IdTipoDocumento == 0)
                {
                    objUsuarioResponse.Mensaje = "Ingrese el tipo de documento del usuario.";
                    return objUsuarioResponse;
                }

                if (string.IsNullOrEmpty(Usuario.NroDocumento))
                {
                    objUsuarioResponse.Mensaje = "Ingrese el nro. de documento del usuario.";
                    return objUsuarioResponse;
                }

                if (Usuario.FechaNacimiento == null || Usuario.FechaNacimiento.ToString("dd/MM/yyyy") == "01/01/1900" || Usuario.FechaNacimiento.ToString("dd/MM/yyyy") == "01/01/0001")
                {
                    objUsuarioResponse.Mensaje = "Ingrese la fecha de nacimiento del usuario.";
                    return objUsuarioResponse;
                }

                if (string.IsNullOrEmpty(Usuario.NroTelefono))
                {
                    objUsuarioResponse.Mensaje = "Error al registar telfono.";
                    return objUsuarioResponse;
                }

                if (string.IsNullOrEmpty(Usuario.Correo))
                {
                    objUsuarioResponse.Mensaje = "Error al registar correo del usuario.";
                    return objUsuarioResponse;
                }

                if (string.IsNullOrEmpty(Usuario.Clave))
                {
                    objUsuarioResponse.Mensaje = "Ingrese la clave del usuario.";
                    return objUsuarioResponse;
                }

                int idUsuario = objUsuarioDAO.Registrar(Usuario);

                if (idUsuario > 0)
                {
                    objUsuarioResponse.Mensaje = "Se registró los datos del usuario.";
                    objUsuarioResponse.EsValido = true;
                    objUsuarioResponse.Usuario = new Usuario { IdUsuario = idUsuario };
                }
                else
                {
                    objUsuarioResponse.Mensaje = "Se presentró un error al registrar los datos del usuario.";
                }
            }
            catch (Exception ex)
            {
                objUsuarioResponse.Mensaje = "Se presentró un error al registrar los datos del usuario. " + ex.Message;
           
            
            }

            return objUsuarioResponse;
        }

        public UsuarioResponse ObtenerUsuario(Usuario Usuario)
        {
            UsuarioResponse objUsuarioResponse = new UsuarioResponse();
            objUsuarioResponse.EsValido = false;

            try
            {
                Usuario objUsuario = objUsuarioDAO.Obtener(Usuario);

                if (objUsuario.IdUsuario == 0)
                {
                    objUsuarioResponse.Mensaje = "El usuario no existe.";
                    return objUsuarioResponse;
                }
                else
                {
                    objUsuarioResponse.Mensaje = "El usuario si existe.";
                    objUsuarioResponse.EsValido = true;
                    objUsuarioResponse.Usuario = objUsuario;
                }
            }
            catch (Exception ex)
            {
                objUsuarioResponse.Mensaje = "Se presentró un error al obtener los datos del usuario. " + ex.Message;
            }

            return objUsuarioResponse;
        }

        public UsuarioResponse RegistrarTarjetaUsuario(Tarjeta Tarjeta)
        {
            UsuarioResponse objUsuarioResponse = new UsuarioResponse();
            objUsuarioResponse.EsValido = false;

            try
            {
                if (Tarjeta.IdUsuario == 0)
                {
                    objUsuarioResponse.Mensaje = "El Id usuario no existe.";
                    return objUsuarioResponse;
                }

                if (string.IsNullOrEmpty(Tarjeta.NroTarjeta))
                {
                    objUsuarioResponse.Mensaje = "El nro. de tarjeta no existe.";
                    return objUsuarioResponse;
                }

                TarjetaDAO objTarjetaDAO = new TarjetaDAO();

                if (objTarjetaDAO.Registrar(Tarjeta))
                {
                    objUsuarioResponse.EsValido = true;
                }

            }
            catch (Exception ex)
            {
                objUsuarioResponse.Mensaje = "Se presentró un error al registar los datos de la tarjeta. " + ex.Message;
            }

            return objUsuarioResponse;
        }

        public List<Tarjeta> ListarTarjetaUsuario(Usuario Usuario)
        {
            List<Tarjeta> lstTarjeta = new List<Tarjeta>();

            try
            {
                TarjetaDAO objTarjetaDAO = new TarjetaDAO();

                lstTarjeta = objTarjetaDAO.ListarTarjeta(Usuario.IdUsuario);
            }
            catch (Exception ex)
            {

            }

            return lstTarjeta;
        }

        public List<Movimiento> ListarTarjetaMovimientoUsuario(Tarjeta Tarjeta)
        {
            List<Movimiento> lstMovimiento = new List<Movimiento>();

            try
            {
                TarjetaDAO objTarjetaDAO = new TarjetaDAO();

                lstMovimiento = objTarjetaDAO.ListarMovimientoTarjeta(Tarjeta.IdTarjeta);
            }
            catch (Exception ex)
            {

            }

            return lstMovimiento;
    }
}
}
