using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Usuario
    {
        #region Attributes
        private string logId;
        private string contrasena;
        private string nombre;
        private string apellido;
        #endregion

        #region Properties
        public string Logid
        {
            get { return logId; }
            set
            {
                if (value == "")
                    throw new Exception("No puede ser vacio");
                else
                    logId = value.Trim();
            }
        }
        public string Contrasena
        {
            get { return contrasena; }
            set
            {
                if (value != "" && value.Length > 7)
                {
                    if(value.Contains(""))//Hay realizar validación de caracteres especiales
                        contrasena = value.Trim();
                    else
                        throw new Exception("");
                }
                else
                    throw new Exception("No puede ser vacio ó mayor a 7");

            }
        }
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value == "")
                    throw new Exception("No puede ser vacio");
                else
                    nombre = value.Trim();
            }
        }
        public string Apellido
        {
            get { return apellido; }
            set
            {
                if (value == "")
                    throw new Exception("No puede ser vacio");
                else
                    apellido = value.Trim();
            }
        }
        #endregion

        #region Construct
        public Usuario(string pLogId, string pContrasena, string pNombre, string pApellido)
        {
            Logid = pLogId;
            Contrasena = pContrasena;
            Nombre = pNombre;
            Apellido = pApellido;
        }
        #endregion

        #region Method
        public override string ToString()
        {
            return ("Código: " + this.logId + "-" +
                    "\nContraseña: " + this.contrasena + "-" +
                    "\nNombre: " + this.nombre + "-" +
                    "\nApellido: " + this.apellido);
        }
        #endregion
    }
}
