using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaDatos
{
    public class SocioContactoRepository
    {
        private ConnectToDB conexion = new ConnectToDB();

        SqlDataReader dataReader;
        DataTable table = new DataTable();
        SqlCommand comando = new SqlCommand();
        public void CreateSocioContacto(string mail, int telefonos, Guid idSocio)
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_INSERTAR_SOCIOCONTACTO";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", Guid.NewGuid());
            comando.Parameters.AddWithValue("@mail", mail);
            comando.Parameters.AddWithValue("@telefonos", telefonos);
            comando.Parameters.AddWithValue("@idSocio", idSocio);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void UpdateSocioContacto(string mail, int telefonos, string idSocio)
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_ACTUALIZAR_SOCIOCONTACTO";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@mail", mail);
            comando.Parameters.AddWithValue("@telefonos", telefonos);
            comando.Parameters.AddWithValue("@idSocio", idSocio);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void DeleteSocioContacto(string id)
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_ELIMINAR_SOCIO_CONTACTO";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
