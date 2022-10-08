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


        }

        public static void EliminarUsuario(Usuario Usuario)
        {

        }
    }
}
