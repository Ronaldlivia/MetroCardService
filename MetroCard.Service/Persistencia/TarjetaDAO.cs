using MetroCard.Service.Dominio;
using MetroCard.Service.Utilitario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MetroCard.Service.Persistencia
{
    public class TarjetaDAO
    {
        public bool Descontar(Tarjeta Tarjeta)
        {
            bool exito = false;

            using (SqlConnection sqlCn = new SqlConnection(Conexion.cnMetroCard))
            {
                sqlCn.Open();

                using (SqlCommand sqlCmd = new SqlCommand("Tarjeta_Descontar", sqlCn))
                {
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add("@IdTarjeta", SqlDbType.Int).Value = Tarjeta.IdTarjeta;
                    sqlCmd.Parameters.Add("@Saldo", SqlDbType.Decimal).Value = Tarjeta.Saldo;

                    SqlParameter sqlPar_Exito = new SqlParameter();
                    sqlPar_Exito.ParameterName = "@Exito";
                    sqlPar_Exito.SqlDbType = SqlDbType.Bit;
                    sqlPar_Exito.Direction = ParameterDirection.Output;

                    sqlCmd.Parameters.Add(sqlPar_Exito);

                    if (sqlCmd.ExecuteNonQuery() > 0)
                    {
                        exito = (bool)sqlPar_Exito.Value;
                    }
                }
            }

            return exito;
        }

        public bool Recargar(Tarjeta Tarjeta)
        {
            bool exito = false;

            using (SqlConnection sqlCn = new SqlConnection(Conexion.cnMetroCard))
            {
                sqlCn.Open();

                using (SqlCommand sqlCmd = new SqlCommand("Tarjeta_Recargar", sqlCn))
                {
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add("@IdTarjeta", SqlDbType.Int).Value = Tarjeta.IdTarjeta;
                    sqlCmd.Parameters.Add("@Saldo", SqlDbType.Decimal).Value = Tarjeta.Saldo;

                    SqlParameter sqlPar_Exito = new SqlParameter();
                    sqlPar_Exito.ParameterName = "@Exito";
                    sqlPar_Exito.SqlDbType = SqlDbType.Bit;
                    sqlPar_Exito.Direction = ParameterDirection.Output;

                    sqlCmd.Parameters.Add(sqlPar_Exito);

                    if (sqlCmd.ExecuteNonQuery() > 0)
                    {
                        exito = (bool)sqlPar_Exito.Value;
                    }
                }
            }

            return exito;
        }

        public bool Registrar(Tarjeta Tarjeta)
        {
            bool exito = false;

            using (SqlConnection sqlCn = new SqlConnection(Conexion.cnMetroCard))
            {
                sqlCn.Open();

                using (SqlCommand sqlCmd = new SqlCommand("Tarjeta_Registar", sqlCn))
                {
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = Tarjeta.IdUsuario;
                    sqlCmd.Parameters.Add("@NroTarjeta", SqlDbType.VarChar, 25).Value = Tarjeta.NroTarjeta;

                    if (sqlCmd.ExecuteNonQuery() > 0)
                    {
                        exito = true;
                    }
                }
            }

            return exito;
        }


        public List<Tarjeta> ListarTarjeta(int IdUsuario)
        {
            List<Tarjeta> lstTarjeta = new List<Tarjeta>();

            using (SqlConnection sqlCn = new SqlConnection(Conexion.cnMetroCard))
            {
                sqlCn.Open();

                using (SqlCommand sqlCmd = new SqlCommand("Tarjeta_Listar", sqlCn))
                {
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;

                    SqlDataReader sqlDr = sqlCmd.ExecuteReader(CommandBehavior.SingleResult);

                    if (sqlDr != null)
                    {
                        if (sqlDr.HasRows)
                        {
                            Tarjeta objTarjeta;

                            while (sqlDr.Read())
                            {
                                objTarjeta = new Tarjeta();

                                objTarjeta.IdTarjeta = sqlDr.GetInt32(sqlDr.GetOrdinal("IdTarjeta"));
                                objTarjeta.NroTarjeta = sqlDr.GetString(sqlDr.GetOrdinal("NroTarjeta"));
                                objTarjeta.Saldo = sqlDr.GetDecimal(sqlDr.GetOrdinal("Saldo"));
                                objTarjeta.FechaSaldo = sqlDr.GetDateTime(sqlDr.GetOrdinal("FechaSaldo"));
                                objTarjeta.Estado = sqlDr.GetBoolean(sqlDr.GetOrdinal("Estado"));

                                lstTarjeta.Add(objTarjeta);
                            }

                            sqlDr.Close();
                        }
                    }
                }
            }

            return lstTarjeta;
        }

        public List<Movimiento> ListarMovimientoTarjeta(int IdTarjeta)
        {
            List<Movimiento> lstMovimiento = new List<Movimiento>();

            using (SqlConnection sqlCn = new SqlConnection(Conexion.cnMetroCard))
            {
                sqlCn.Open();

                using (SqlCommand sqlCmd = new SqlCommand("Movimiento_Listar", sqlCn))
                {
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add("@IdTarjeta", SqlDbType.Int).Value = IdTarjeta;

                    SqlDataReader sqlDr = sqlCmd.ExecuteReader(CommandBehavior.SingleResult);

                    if (sqlDr != null)
                    {
                        if (sqlDr.HasRows)
                        {
                            Movimiento objMovimiento;

                            while (sqlDr.Read())
                            {
                                objMovimiento = new Movimiento();

                                objMovimiento.IdTarjeta = sqlDr.GetInt32(sqlDr.GetOrdinal("IdTarjeta"));
                                objMovimiento.NroTarjeta = sqlDr.GetString(sqlDr.GetOrdinal("NroTarjeta"));
                                objMovimiento.Saldo = sqlDr.GetDecimal(sqlDr.GetOrdinal("Saldo"));
                                objMovimiento.FechaSaldo = sqlDr.GetDateTime(sqlDr.GetOrdinal("FechaSaldo"));
                                objMovimiento.SaldoAnterior = sqlDr.GetDecimal(sqlDr.GetOrdinal("SaldoAnterior"));
                                objMovimiento.FechaMovimiento = sqlDr.GetDateTime(sqlDr.GetOrdinal("FechaSaldoAnterior"));

                                lstMovimiento.Add(objMovimiento);
                            }

                            sqlDr.Close();
                        }
                    }
                }
            }

            return lstMovimiento;
        }
    }
}