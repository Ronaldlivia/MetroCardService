using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MetroCard.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                ConultarTicket();
            }
            catch (Exception ex)
            {
                
            }
            
        }

        static void AutenticarUsuario()
        {
            WSSeguridad.SeguridadServiceClient cli = new WSSeguridad.SeguridadServiceClient();
            WSSeguridad.Usuario objUsuario = new WSSeguridad.Usuario();
            objUsuario.Correo = "gp.paraguay@gmail.com";
            objUsuario.Clave = "";

            WSSeguridad.UsuarioResponse objUsuarioResponse = cli.AutenticarUsuario(objUsuario);
        }

        static void RegistrarUsuario()
        {
            WSUsuario.UsuarioServiceClient cli = new WSUsuario.UsuarioServiceClient();

            WSUsuario.Usuario objUsuario = new WSUsuario.Usuario();
            objUsuario.Nombres = "CARLOS JAVIER";
            objUsuario.ApellidoPaterno = "PEREZ";
            objUsuario.ApellidoMaterno = "PANDO";
            objUsuario.IdTipoDocumento = 1;
            objUsuario.NroDocumento = "44567898";


            WSUsuario.UsuarioResponse objUsuarioResponse = cli.RegistrarUsuario(objUsuario);

        }

        static void ConultarTicket()
        {
            WSTicket.TicketServiceClient cli = new WSTicket.TicketServiceClient();

            WSTicket.Ticket objTicket = new WSTicket.Ticket();
            objTicket.Codigo = "T20201802";

            WSTicket.TicketResponse objTicketResponse = cli.ConsultarTicket(objTicket);
        }
    }    
}
