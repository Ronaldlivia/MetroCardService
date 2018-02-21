using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MetroCard.Service.Dominio;
using MetroCard.Service.Utilitario;
using System.Data.SqlClient;
using System.Data;

namespace MetroCard.Service.Persistencia
{
    public class TicketDAO
    {
        public Ticket Consultar(Ticket Ticket)
        {
            Ticket objTicket = new Ticket();

            using (SqlConnection sqlCn = new SqlConnection(Conexion.cnMetroCard))
            {
                sqlCn.Open();

                using (SqlCommand sqlCmd = new SqlCommand("Ticket_Consultar", sqlCn))
                {
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add("@Codigo", SqlDbType.VarChar, 50).Value = Ticket.Codigo;

                    SqlDataReader sqlDr = sqlCmd.ExecuteReader(CommandBehavior.SingleResult);

                    if (sqlDr.HasRows)
                    {
                        if (sqlDr.Read())
                        {
                            objTicket.IdTicket = sqlDr.GetInt32(sqlDr.GetOrdinal("IdTicket"));
                            objTicket.Codigo = sqlDr.GetString(sqlDr.GetOrdinal("Codigo"));
                            objTicket.Estado = sqlDr.GetBoolean(sqlDr.GetOrdinal("Estado"));
                        }
                    }
                }
            }

            return objTicket;
        }
    }
}