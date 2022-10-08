using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaUsuario
    {
        public static void Agregar(Usuario pUsuario)
        {
            PersistenciaUsuario.AltaUsuario((Usuario)pUsuario);
        }
        public static Usuario Buscar(string pUsuario)
        {
            Usuario usuario = null;
            usuario = (Usuario)PersistenciaUsuario.BuscarUsuario(pUsuario);
            return usuario;
        }
        public static void Modificar(Usuario pUsuario)
        {
            PersistenciaUsuario.ModificarUsuario((Usuario)pUsuario);
        }
        public static void Eliminar(Usuario pUsuario)
        {
            PersistenciaUsuario.EliminarUsuario((Usuario)pUsuario);
        }
    }
}
