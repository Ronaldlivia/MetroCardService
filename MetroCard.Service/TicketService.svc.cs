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
    public class TicketService : ITicketService
    {
        TicketDAO objTicketDAO = new TicketDAO();

        public TicketResponse ConsultarTicket(Ticket Ticket)
        {
            TicketResponse objTicketResponse = new TicketResponse();
            objTicketResponse.EsValido = false;

            try
            {
                if (string.IsNullOrEmpty(Ticket.Codigo))
                {
                    objTicketResponse.Mensaje = "El código de ticket no es válido.";
                    return objTicketResponse;
                }

                Ticket objTicket = objTicketDAO.Consultar(Ticket);

                if (string.IsNullOrEmpty(objTicket.Codigo))
                {
                    objTicketResponse.Mensaje = "El ticket no existe.";
                    return objTicketResponse;
                }
                else
                {
                    objTicketResponse.Mensaje = "El ticket si existe.";                    
                    objTicketResponse.EsValido = true;
                    objTicketResponse.Ticket = objTicket;
                }
            }
            catch (Exception ex)
            {
                objTicketResponse.Mensaje = "Se presentró un error al obtener los datos del ticket. " + ex.Message;
            }
                        
            return objTicketResponse;
        }
    }
}
