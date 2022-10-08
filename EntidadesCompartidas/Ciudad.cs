using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Ciudad
    {
        #region Attributes
        private Pais pais;
        private string coCiudad;
        private string nombre;
        #endregion

        #region Properties
        public Pais Pais
        {
            get { return pais; }
            set
            {
                if (value == null)
                    throw new Exception("Debe elegir un país.");
                else
                    pais = value;
            }
        }
        public string CoCiudad
        {
            get { return coCiudad; }
            set
            {
                if (value.Length != 2)
                throw new Exception("El codigo de la ciudad debe contener 3 caracteres");
                else
                coCiudad = value;
            }
        }
        public string Nombre
        {
            get { return nombre; }
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
        public Ciudad(Pais pPais,string pCoCiudad, string pNombre)
        {
            pais = pPais;
            CoCiudad = pCoCiudad;
            Nombre = pNombre;
        }
        #endregion

        #region Method
        public override string ToString()
        {
            return ("País: " + this.pais.ToString() + "-" +
                    "\nCódigo Ciudad: " + this.coCiudad + "-" +
                    "\nNombre: " + this.nombre);
        }
        #endregion
    }
}
