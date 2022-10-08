using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PersistenciaPais
    {
        public static void AltaPais(Pais Pais)
        {
            SqlConnection oConnection = new SqlConnection(Conexion.STR);
            SqlCommand oCommand = new SqlCommand("AltaPais", oConnection);
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.AddWithValue("@idpais", Pais.CoPais);
            oCommand.Parameters.AddWithValue("@nombre", Pais.Nombre);

            SqlParameter response = new SqlParameter();
            response.Direction = ParameterDirection.ReturnValue;
            oCommand.Parameters.Add(response);

            try
            {
                oConnection.Open();
                oCommand.ExecuteNonQuery();

                if (Convert.ToInt32(response.Value) == -1)
                    throw new Exception("Error: Ya existe un pais con el mismo codigo.");
                if (Convert.ToInt32(response.Value) == -2)
                    throw new Exception("Error al ingresarse el pais");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { oConnection.Close(); }
        }

        public static void ModificarPais(Pais Pais)
        {
            SqlConnection oConnection = new SqlConnection(Conexion.STR);
            SqlCommand oCommand = new SqlCommand("ModificarPais", oConnection);
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.AddWithValue("@idpais", Pais.CoPais);
            oCommand.Parameters.AddWithValue("@nombre", Pais.Nombre);

            SqlParameter response = new SqlParameter("@Retorno", SqlDbType.Int);
            response.Direction = ParameterDirection.ReturnValue;
            oCommand.Parameters.Add(response);

            try
            {
                oConnection.Open();
                oCommand.ExecuteNonQuery();

                if (Convert.ToInt32(response.Value) == -1)
                    throw new Exception("Error: No existe el pais.");
                if (Convert.ToInt32(response.Value) == -2)
                    throw new Exception("Error al modificarse el pais");
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { oConnection.Close(); }

        }

        public static void EliminarPais(Pais Pais)
        {
            SqlConnection oConnection = new SqlConnection(Conexion.STR);
            SqlCommand oCommand = new SqlCommand("EliminarPais", oConnection);
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.Parameters.AddWithValue("@idpais", Pais.CoPais);

            SqlParameter response = new SqlParameter();
            response.Direction = ParameterDirection.ReturnValue;
            oCommand.Parameters.Add(response);

            try
            {
                oConnection.Open();
                oCommand.ExecuteNonQuery();
                if (Convert.ToInt32(response.Value) == -1)
                    throw new Exception("Error: No se puede eliminar - No existe el pais.");
                if (Convert.ToInt32(response.Value) == -2)
                    throw new Exception("Error: El pais tiene noticias asociadas, se deben eliminar las noticias primero");
                if (Convert.ToInt32(response.Value) == -3)
                    throw new Exception("Error: No se pudo eliminar el pais");
                if (Convert.ToInt32(response.Value) == -4)
                    throw new Exception("Error: No se pudo eliminar una ciudad asociada al pais");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { oConnection.Close(); }
        }
        public static Pais BuscarPais(string pPais)
        {
            Pais pais = null;
            string codigo = pPais;
            string nombre;

            SqlDataReader reader;
            SqlConnection oConnection = new SqlConnection(Conexion.STR);
            SqlCommand oCommand = new SqlCommand("Exec BuscarPais " + codigo, oConnection);

            try
            {
                oConnection.Open();
                reader = oCommand.ExecuteReader();

                if (reader.Read())
                {
                    nombre = (string)reader["nombre"];

                    pais = new Pais(codigo, nombre);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { oConnection.Close(); }
            return pais;
        }
    }
}
