using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Pronostico
    {
        #region Attributes
        private int prCodigo;
        private Ciudad ciudad;
        private Usuario usuario;
        private DateTime fecha;
        private int tempMax;
        private int tempMin;
        private int velViento;
        private string tipoCielo;
        private int probLluvia;
        #endregion

        #region Properties
        public Ciudad Ciudad
        {
            get { return ciudad; }
            set
            {
                if (value == null)
                    throw new Exception("Se necesita una ciudad para generar un pronostico.");
                else
                    ciudad = value;
            }
        }
        public Usuario Usuario
        {
            get { return usuario; }
            set
            {
                if (value == null)
                    throw new Exception("Se necesita un usuario para generar un pronostico.");
                else
                    usuario = value;
            }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set
            {
                if (value.Date > DateTime.Now.Date)
                    throw new Exception("Error: Fecha de ingreso no válida");
                fecha = value;
            }
        }
        public int TempMax
        {
            get { return tempMax;}
            set
            {
                if (value >= 60 || value <= -40)
                    throw new Exception("La tempetura es invalida");
                else
                    tempMax = value;
            }
        }
        public int TempMin
        {
            get { return tempMin; }
            set
            {
                if (value >= 60 || value <= -40)
                    throw new Exception("La tempetura es invalida");
                else
                    tempMin = value;
            }
        }
        public int VelViento
        {
            get { return velViento; }
            set
            {
                if (value < 0)
                    throw new Exception("El valor de la velocidad del vient odebe ser numero positivo");
                else
                    velViento = value;
            }
        }
        public string TipoCielo
        {
            get { return tipoCielo; }
            set
            {
                if (value != "despejado" || value != "parcialmente nuboso" || value != "nuboso")
                throw new Exception("Tipo de cielo invalido");
                else
                tipoCielo = value;
            }
        }
        public int ProbLluvia
        {
            get { return probLluvia; }
            set
            {    
                if (value >= 0 && value <= 100)
                    probLluvia = value;
                else
                    throw new Exception("Probabilidad invalida");
            }
        }
        #endregion

        #region Construct
        public Pronostico(Ciudad pCiudad, Usuario pUsuario, DateTime pFecha, int pTempMax,int pTempMin,int pVelViento,string pTipoCielo,int pProbLluvia)
        {
            Ciudad = pCiudad;
            Usuario = pUsuario;
            Fecha = pFecha;
            TempMax = pTempMax;
            TempMin = pTempMin;
            VelViento = pVelViento;
            TipoCielo = pTipoCielo;
            ProbLluvia = pProbLluvia;
        }
        #endregion

        #region Method
        public override string ToString()
        {
            return ("Usuario: " + this.usuario.ToString() + "-" +
                    "\nCiudad: " + this.Ciudad.ToString() + "-" +
                    "\nFecha: " + this.fecha + "-" +
                    "\nTemperatura Maxima: " + this.tempMax + "-" +
                    "\nTemperatura Minima: " + this.tempMin + "-" +
                    "\nVelocidad del Viento: " + this.velViento + "-" +
                    "\nTipo de Cielo: " + this.tipoCielo + "-" +
                    "\nProbabilidad de Lluvia: " + this.probLluvia);
        }
        #endregion
    }
}
