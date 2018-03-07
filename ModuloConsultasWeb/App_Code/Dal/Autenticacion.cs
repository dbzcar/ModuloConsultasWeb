using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ModuloConsultasWeb.App_Code.Dal
{
    public class Autenticacion
    {
        public static bool Autenticar(string user, string pass)
        {
            string sql;
            sql = string.Format("EXEC Loguear '{0}', '{1}'", user, pass);

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionNueva"].ToString()))
            {
                conn.Open();//abrimos conexion

                SqlCommand cmd = new SqlCommand(sql, conn); //ejecutamos la instruccion

                int count = Convert.ToInt32(cmd.ExecuteScalar()); //devuelve la fila afectada

                if (count == 0)
                    return false;
                else
                    return true;

            }
        }
    }
}