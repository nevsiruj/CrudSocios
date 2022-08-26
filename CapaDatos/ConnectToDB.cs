using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;


namespace CapaDatos
{
    public class ConnectToDB
    {
        //SqlConnection cn;
        //SqlCommand cmd;
        //SqlDataAdapter da;
        //SqlDataReader dr;
        //public void ConnectionDb()
        //{
        //    cn = new SqlConnection(@"Data Source = delli5\sqlexpress; Initial Catalog = tbl; TrustServerCertificate=True;Integrated Security = True"); ;
        //    cn.Open();

        //}

        private SqlConnection Conexion = new
           SqlConnection("Data Source = delli5\\sqlexpress; Initial Catalog = tbl; TrustServerCertificate=True;Integrated Security = True");

        /// <summary>
        /// Abrir la conexión hacia la base de datos
        /// </summary>
        /// <returns></returns>
        public SqlConnection OpenConnection()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }

        /// <summary>
        /// Cerrar la conexión hacia la base de datos
        /// </summary>
        /// <returns></returns>
        public SqlConnection CloseConnection()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }
}
