using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class SocioRepository

    {

        private ConnectToDB conexion = new ConnectToDB();

        SqlDataReader dataReader;
        DataTable table = new DataTable();
        SqlCommand comando = new SqlCommand();

        /// <summary>
        /// Método para Insertar "Create" los datos
        /// </summary>
        public void CreateSocio(Guid id, string nombre, string apellido, string direccion, string tipoDocId, int documento, string tipoSocioId)
        {
            var socioId = id.ToString();
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_INSERTAR_SOCIO";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", socioId);
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Apellido", apellido);
            comando.Parameters.AddWithValue("@Direccion", direccion);
            comando.Parameters.AddWithValue("@TipoDocumento", tipoDocId);
            comando.Parameters.AddWithValue("@NumeroDocumento", documento);
            comando.Parameters.AddWithValue("@TipoSocio", tipoSocioId);
            comando.Parameters.AddWithValue("@FechaAlta", DateTime.Now);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
      

        /// <summary>
        /// Método para Seleccionar "Read" los datos
        /// </summary>
        public DataTable ReadAllSocios()
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_SELECCIONAR_ALL_SOCIOS";
            comando.CommandType = CommandType.StoredProcedure;
            dataReader = comando.ExecuteReader();
            table.Load(dataReader);
            conexion.CloseConnection();
            return table;
        }

        /// <summary>
        /// Método para Actualizar "Update" los datos
        /// </summary>
        /// <param name="id">parámetro para filtra y actualizar el registro de acurdo al id</param>
        public void UpdateSocio(string id,string nombre, string apellido, string direccion, string tipoDocumentoId, int numeroDocumento, string tipoSocioId)
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_ACTUALIZAR_SOCIO";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Apellido", apellido);
            comando.Parameters.AddWithValue("@Direccion", direccion);
            comando.Parameters.AddWithValue("@TipoDocumento", tipoDocumentoId);
            comando.Parameters.AddWithValue("@NumeroDocumento", numeroDocumento);
            comando.Parameters.AddWithValue("@TipoSocio", tipoSocioId);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        /// <summary>
        /// Método para Eliminar "Delete" los datos
        /// </summary>
        /// <param name="id">parámetro de entrada para eliminar el registro de acuerdo al filtro id</param>
        public void DeleteSocio(string id)

        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_ELIMINAR_SOCIO";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
                       

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

    


    }
}

