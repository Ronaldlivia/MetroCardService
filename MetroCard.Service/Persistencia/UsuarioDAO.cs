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
    public class UsuarioDAO
    {
        public int Autenticar(Usuario Usuario)
        {
            int idUsuario = 0;

            using (SqlConnection sqlCn = new SqlConnection(Conexion.cnMetroCard))
            {
                sqlCn.Open();

                using (SqlCommand sqlCmd = new SqlCommand("Usuario_Autenticar", sqlCn))
                {                    
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = Usuario.Correo;
                    sqlCmd.Parameters.Add("@Clave", SqlDbType.VarChar, 50).Value = Usuario.Clave;

                    SqlDataReader sqlDr = sqlCmd.ExecuteReader(CommandBehavior.SingleResult);

                    if (sqlDr.HasRows)
                    {
                        if (sqlDr.Read())
                        {
                            idUsuario = sqlDr.GetInt32(sqlDr.GetOrdinal("IdUsuario"));                                            
                        }
                    }
                }
            }

            return idUsuario;     
        }

        public Usuario Obtener(Usuario Usuario)
        {
            Usuario objUsuario = new Usuario();

            using (SqlConnection sqlCn = new SqlConnection(Conexion.cnMetroCard))
            {
                sqlCn.Open();

                using (SqlCommand sqlCmd = new SqlCommand("Usuario_Obtener", sqlCn))
                {
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.VarChar, 50).Value = Usuario.IdUsuario;
                    sqlCmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Usuario.Estado;

                    SqlDataReader sqlDr = sqlCmd.ExecuteReader(CommandBehavior.SingleResult);

                    if (sqlDr.HasRows)
                    {
                        if (sqlDr.Read())
                        {
                            objUsuario.IdUsuario = sqlDr.GetInt32(sqlDr.GetOrdinal("IdUsuario"));
                            objUsuario.Nombres = sqlDr.GetString(sqlDr.GetOrdinal("Nombres"));
                            objUsuario.ApellidoPaterno = sqlDr.GetString(sqlDr.GetOrdinal("ApellidoPaterno"));
                            objUsuario.ApellidoMaterno = sqlDr.GetString(sqlDr.GetOrdinal("ApellidoMaterno"));
                            objUsuario.IdTipoDocumento = sqlDr.GetInt32(sqlDr.GetOrdinal("IdTipoDocumento"));
                            objUsuario.NroDocumento = sqlDr.GetString(sqlDr.GetOrdinal("NroDocumento"));
                            objUsuario.FechaNacimiento = sqlDr.GetDateTime(sqlDr.GetOrdinal("FehaNacimiento"));
                            objUsuario.NroTelefono = sqlDr.GetString(sqlDr.GetOrdinal("NroTelefono"));
                            objUsuario.Correo = sqlDr.GetString(sqlDr.GetOrdinal("Correo"));
                        }
                    }
                }
            }

            return objUsuario;
        }

        public int Registrar(Usuario Usuario)
        {
            int idUsuario = 0;

            using (SqlConnection sqlCn = new SqlConnection(Conexion.cnMetroCard))
            {
                sqlCn.Open();

                using (SqlCommand sqlCmd = new SqlCommand("Usuario_Registrar", sqlCn))
                {
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add("@Nombres", SqlDbType.VarChar, 50).Value = Usuario.Nombres;
                    sqlCmd.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar, 50).Value = Usuario.ApellidoPaterno;
                    sqlCmd.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar, 50).Value = Usuario.ApellidoMaterno;
                    sqlCmd.Parameters.Add("@IdTipoDocumento", SqlDbType.Int).Value = Usuario.IdTipoDocumento;
                    sqlCmd.Parameters.Add("@NroDocumento", SqlDbType.VarChar, 15).Value = Usuario.NroDocumento;
                    sqlCmd.Parameters.Add("@FehaNacimiento", SqlDbType.DateTime).Value = Usuario.FechaNacimiento;
                    sqlCmd.Parameters.Add("@NroTelefono", SqlDbType.VarChar,15).Value = Usuario.NroTelefono;
                    sqlCmd.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = Usuario.Correo;
                    sqlCmd.Parameters.Add("@Clave", SqlDbType.VarChar, 50).Value = Usuario.Clave;

                    SqlParameter sqlPar_IdUsuario = new SqlParameter();
                    sqlPar_IdUsuario.ParameterName = "@IdUsuario";
                    sqlPar_IdUsuario.SqlDbType = SqlDbType.Int;
                    sqlPar_IdUsuario.Direction = ParameterDirection.Output;

                    sqlCmd.Parameters.Add(sqlPar_IdUsuario);

                    if (sqlCmd.ExecuteNonQuery() > 0)
                    {
                        idUsuario = (int)sqlPar_IdUsuario.Value;
                    }                 
                }                
            }

            return idUsuario;
        }
    }
}