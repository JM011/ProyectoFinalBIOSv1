using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PersistenciaUsuario
    {
        public static void AltaUsuario(Usuario Usuario)
        {
            SqlConnection oConnection = new SqlConnection(Conexion.STR);
            SqlCommand oCommand = new SqlCommand("AltaUsuario", oConnection);
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.AddWithValue("@logid", Usuario.Logid);
            oCommand.Parameters.AddWithValue("@contrasena", Usuario.Contrasena);
            oCommand.Parameters.AddWithValue("@nombre", Usuario.Nombre);
            oCommand.Parameters.AddWithValue("@apellido", Usuario.Apellido);

            SqlParameter response = new SqlParameter();
            response.Direction = ParameterDirection.ReturnValue;
            oCommand.Parameters.Add(response);

            try
            {
                oConnection.Open();
                oCommand.ExecuteNonQuery();

                if (Convert.ToInt32(response.Value) == -1)
                    throw new Exception("Error: No se puede agregar - Ya existe el usuario.");
                if (Convert.ToInt32(response.Value) == -2)
                    throw new Exception("Error: No se puede agregar");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { oConnection.Close(); }
        }

        public static void ModificarUsuario(Usuario Usuario)
        {
            SqlConnection oConnection = new SqlConnection(Conexion.STR);
            SqlCommand oCommand = new SqlCommand("ModificarUsuario", oConnection);
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.AddWithValue("@logid", Usuario.Logid);
            oCommand.Parameters.AddWithValue("@contrasena", Usuario.Contrasena);
            oCommand.Parameters.AddWithValue("@nombre", Usuario.Nombre);
            oCommand.Parameters.AddWithValue("@apellido", Usuario.Apellido);

            SqlParameter response = new SqlParameter("@Retorno", SqlDbType.Int);
            response.Direction = ParameterDirection.ReturnValue;
            oCommand.Parameters.Add(response);

            try
            {
                oConnection.Open();
                oCommand.ExecuteNonQuery();

                throw new Exception((int)response.Value == -1 ? "No existe el usuario" : "Modificación Éxitosa");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { oConnection.Close(); }

        }

        public static void EliminarUsuario(Usuario Usuario)
        {
            SqlConnection oConnection = new SqlConnection(Conexion.STR);
            SqlCommand oCommand = new SqlCommand("EliminarUsuario", oConnection);
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.AddWithValue("@logid", Usuario.Logid);

            SqlParameter response = new SqlParameter();
            response.Direction = ParameterDirection.ReturnValue;
            oCommand.Parameters.Add(response);

            try
            {
                oConnection.Open();
                oCommand.ExecuteNonQuery();
                if (Convert.ToInt32(response.Value) == -1)
                    throw new Exception("Error: No se puede eliminar - No existe el usuario.");
                if (Convert.ToInt32(response.Value) == -2)
                    throw new Exception("Error: No se pudo eliminar - Error general");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { oConnection.Close(); }
        }

        public static Usuario BuscarUsuario(string pUsuario)
        {
            Usuario usuario = null;
            string logid = pUsuario;
            string nombre, apellido, contrasena;

            SqlDataReader reader;
            SqlConnection oConnection = new SqlConnection(Conexion.STR);
            SqlCommand oCommand = new SqlCommand("Exec BuscarUsuario " + logid, oConnection);

            try
            {
                oConnection.Open();
                reader = oCommand.ExecuteReader();

                if (reader.Read())
                {
                    contrasena = (string)reader["contrasena"];
                    nombre = (string)reader["nombre"];
                    apellido = (string)reader["apellido"];

                    usuario = new Usuario(logid, contrasena, nombre, apellido);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { oConnection.Close(); }
            return usuario;
        }
    }
}
