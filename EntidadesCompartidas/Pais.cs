using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Pais
    {
        #region Attributes
        private string coPais;
        private string nombre;
        #endregion

        #region Properties
        public string CoPais
        {
            get{ return coPais;}
            set
            {
                if (value.Length != 3)
                    throw new Exception("El codigo del pais debe contener 3 caracteres");
                else
                    coPais = value;
            }
        }
        public string Nombre
        {
            get{ return nombre;}
            set
            {
                if (value == "")
                    throw new Exception("No puede ser vacio");
                else if (value.Trim().Length > 49)
                    throw new Exception("El nombre es demasiado largo");
                else
                    nombre = value.Trim();
            }
        }
        #endregion

        #region Construct
        public Pais(string pCoPais, string pNombre)
        {
            CoPais = pCoPais;
            Nombre = pNombre;
        }
        #endregion

        #region Method
        public override string ToString()
        {
            return ("País: " + this.coPais + "-" +
                    "\nNombre: " + this.nombre);
        }
        #endregion
    }
}
