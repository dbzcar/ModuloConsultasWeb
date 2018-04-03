using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.IO;
using System.Web;


namespace MiLibreria
{
    public class Conexion
    {
     
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        SqlConnection conexion = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter dt = new SqlDataAdapter();
        DataSet ds;
        ClsErrorHandler error = new ClsErrorHandler();

        public Conexion()
        {
            builder.DataSource = @"DESKTOP-HH45HA0\LOCAL";
            builder.UserID = "sa";
            builder.Password = "patito";
            builder.InitialCatalog = "Gastos";

        }

        public void AbrirConexion()
        {
            try
            {
                conexion = new SqlConnection(builder.ToString());
                conexion.Open();


            }
            catch (Exception ex)
            {
                error.LogError(ex.ToString(), ex.StackTrace);

            }

        }

        public void CerrarConexion()
        {

            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }

            }
            catch (Exception ex)
            {
                error.LogError(ex.ToString(), ex.StackTrace);

            }
        }

        public DataSet EjectuaSQL(string strSql, string tabla)
        {
            try
            {
                AbrirConexion();
                dt = new SqlDataAdapter(strSql, conexion);
                ds = new DataSet(tabla);
                dt.Fill(ds, tabla);


            }
            catch (Exception ex)
            {

                error.LogError(ex.ToString(), ex.StackTrace);
            }

            CerrarConexion();

            return ds;
        }

        public void EjectuaSQLT(SqlConnection con, SqlTransaction trans, String strSql)
        {


            new SqlCommand(strSql, con, trans).ExecuteNonQuery();


        }

        public SqlConnection OpenConexion()
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = new SqlConnection(builder.ToString());
                con.Open();


            }
            catch (Exception ex)
            {
                error.LogError(ex.ToString(), ex.StackTrace);

            }

            return con;
        }

        public SqlConnection CloseConexion()
        {
            SqlConnection con = new SqlConnection();
            try
            {

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                error.LogError(ex.ToString(), ex.StackTrace);
            }

            return con;
        }

        //MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();

        //MySqlConnection conexion = new MySqlConnection();
        //MySqlCommand cmd = new MySqlCommand();
        //MySqlDataAdapter dt = new MySqlDataAdapter();
        //DataSet ds;
        //ClsErrorHandler error = new ClsErrorHandler();

        //public Conexion()
        //{

        //    builder.Server = "localhost";
        //    builder.UserID = "root";
        //    builder.Password = "patito";
        //    builder.Database = "recepcion";
        //}

        //public void AbrirConexion()
        //{

        //    try
        //    {
        //        conexion = new MySqlConnection(builder.ToString());
        //        conexion.Open();


        //    }
        //    catch (Exception ex)
        //    {
        //        error.LogError(ex.ToString(), ex.StackTrace);

        //    }
        //}


        //public void CerrarConexion()
        //{
        //    try
        //    {
        //        if (conexion.State == ConnectionState.Open)
        //        {
        //            conexion.Close();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        error.LogError(ex.ToString(), ex.StackTrace);
        //    }
        //}

        //public DataSet EjectuaSQL(string strSql, string tabla)
        //{
        //    try
        //    {
        //        AbrirConexion();
        //        dt = new MySqlDataAdapter(strSql, conexion);
        //        ds = new DataSet(tabla);
        //        dt.Fill(ds, tabla);

        //    }
        //    catch (Exception ex)
        //    {

        //        error.LogError(ex.ToString(), ex.StackTrace);
        //    }

        //    CerrarConexion();

        //    return ds;
        //}

        //public void EjectuaSQLT(MySqlConnection con, MySqlTransaction trans, String strSql)
        //{
        //    new MySqlCommand(strSql, con, trans).ExecuteNonQuery();

        //}

        //public MySqlConnection OpenConexion()
        //{
        //    MySqlConnection con = new MySqlConnection();
        //    try
        //    {
        //        con = new MySqlConnection(builder.ToString());
        //        con.Open();


        //    }
        //    catch (Exception ex)
        //    {
        //        error.LogError(ex.ToString(), ex.StackTrace);

        //    }

        //    return con;
        //}

        //public MySqlConnection CloseConexion()
        //{
        //    MySqlConnection con = new MySqlConnection();
        //    try
        //    {

        //        if (con.State == ConnectionState.Open)
        //        {
        //            con.Close();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        error.LogError(ex.ToString(), ex.StackTrace);
        //    }

        //    return con;
        //}


    }

    public class ClsController
    {
        DataSet dsReturn;

        public DataSet DsReturn
        {
            get
            {
                return dsReturn;
            }

            set
            {
                dsReturn = value;
            }
        }
    }

    public class ClsDataLayer
    {
        string strMsjTecnico;
        string strMsjUsuario;
        string strMsj;
        DataSet dsReturn;

        public string StrMsjTecnico
        {
            get
            {
                return strMsjTecnico;
            }

            set
            {
                strMsjTecnico = value;
            }
        }

        public string StrMsjUsuario
        {
            get
            {
                return strMsjUsuario;
            }

            set
            {
                strMsjUsuario = value;
            }
        }

        public string StrMsj
        {
            get
            {
                return strMsj;
            }

            set
            {
                strMsj = value;
            }
        }

        public DataSet DsReturn
        {
            get
            {
                return dsReturn;
            }

            set
            {
                dsReturn = value;
            }
        }
    }

    public class ClsErrorHandler
    {
        public void LogError(string strMensaje, string stack)
        {
            try
            {

                string Path = string.Format("../../Eventos/Log/{0}.txt", DateTime.Now.ToString("dd-MM-yyyy"));

                if (!File.Exists(HttpContext.Current.Server.MapPath(Path)))
                {
                    File.Create(HttpContext.Current.Server.MapPath(Path)).Close();
                }

                using (StreamWriter w = File.AppendText(HttpContext.Current.Server.MapPath(Path)))
                {
                    w.WriteLine("\r\nLog del Error: ");
                    w.WriteLine("{0}", DateTime.Now.ToString());
                    string err = string.Format("Error en: {0} | Mensaje de Error: {1} | Stack: {2}", HttpContext.Current.Request.Url.ToString(), strMensaje, stack);
                    w.WriteLine(err);
                    w.WriteLine("__________________________");
                    w.Flush();
                    w.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }



}
