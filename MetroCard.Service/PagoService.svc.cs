using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MetroCard.Service.Dominio;
using MetroCard.Service.Persistencia;
using MetroCard.Service.Errores;
using MetroCard.Service.Response;

namespace MetroCard.Service
{    
    public class PagoService : IPagoService
    {
        TarjetaDAO objTarjetaDAO = new TarjetaDAO();

        public TarjetaResponse DescontarTarjeta(Tarjeta Tarjeta)
        {
            TarjetaResponse objTarjetaResponse = new TarjetaResponse();
            objTarjetaResponse.EsValido = false;

            try
            {
                if (Tarjeta.IdTarjeta == 0)
                {
                    objTarjetaResponse.Mensaje = "El Id tarjeta no es válido.";
                    return objTarjetaResponse;
                }

                if (Tarjeta.Saldo == 0)
                {
                    objTarjetaResponse.Mensaje = "El saldo es incorrecto.";
                    return objTarjetaResponse;                    
                }

                bool respuesta = objTarjetaDAO.Descontar(Tarjeta);

                if (!respuesta)
                {
                    objTarjetaResponse.Mensaje = "No se pudo realizar el descuento.";
                    return objTarjetaResponse;
                }
                else
                {
                    objTarjetaResponse.Mensaje = "Se realizó el descuento.";
                    objTarjetaResponse.EsValido = true;
                    return objTarjetaResponse;
                }
            }
            catch (Exception ex)
            {
                objTarjetaResponse.Mensaje = "Se presentró un error al realizar el descuento. " + ex.Message;
            }
                      
            return objTarjetaResponse;
        }

        public TarjetaResponse RecargarTarjeta(Tarjeta Tarjeta)
        {
            TarjetaResponse objTarjetaResponse = new TarjetaResponse();
            objTarjetaResponse.EsValido = false;

            try
            {
                if (Tarjeta.IdTarjeta == 0)
                {
                    objTarjetaResponse.Mensaje = "El Id tarjeta no es válido.";
                    return objTarjetaResponse;
                }

                if (Tarjeta.Saldo == 0)
                {
                    objTarjetaResponse.Mensaje = "El saldo es incorrecto.";
                    return objTarjetaResponse;
                }

                bool respuesta = objTarjetaDAO.Recargar(Tarjeta);

                if (!respuesta)
                {
                    objTarjetaResponse.Mensaje = "No se pudo realizar la recarga.";
                    return objTarjetaResponse;
                }
                else
                {
                    objTarjetaResponse.Mensaje = "Se realizó la recarga de la Tarjeta.";
                    objTarjetaResponse.EsValido = true;
                    return objTarjetaResponse;
                }
            }
            catch(Exception ex)
            {
                objTarjetaResponse.Mensaje = "Se presentró un error al realizar la recarga. " + ex.Message;
            }

            return objTarjetaResponse;
        }
    }
}
