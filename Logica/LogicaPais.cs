using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaPais
    {
        public static void Agregar(Pais pPais)
        {
            PersistenciaPais.AltaPais((Pais)pPais);
        }
        public static Pais Buscar(string pPais)
        {
            Pais pais = null;
            pais = (Pais)PersistenciaPais.BuscarPais(pPais);
            return pais;
        }
        public static void Eliminar(Pais pPais)
        {
            PersistenciaPais.EliminarPais((Pais)pPais);
        }
        public static void Modificar(Pais pPais)
        {
            PersistenciaPais.ModificarPais((Pais)pPais);
        }
    }
}
