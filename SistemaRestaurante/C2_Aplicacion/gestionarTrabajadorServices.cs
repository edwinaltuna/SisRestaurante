using C3_Dominio.Entidades;
using C4_Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace C2_Aplicacion
{
    public class gestionarTrabajadorServices
    {
        private GestorDAOSQL gestorDAOSQL;
        private TrabajadorSQL trabajadorSQL;

        public gestionarTrabajadorServices()
        {
            gestorDAOSQL = new GestorDAOSQL();
            trabajadorSQL = new TrabajadorSQL(gestorDAOSQL);
        }

        public Trabajador IniciarSession(String usuario, String clave)
        {
            try
            {
                gestorDAOSQL.abrirConexion();
                Trabajador trabajador = trabajadorSQL.Login(usuario, clave);
                gestorDAOSQL.cerrarConexion();
                
                if (string.IsNullOrEmpty(usuario))
                    throw new ApplicationException("Ingrese un usuario.");
                else if (string.IsNullOrEmpty(clave))
                    throw new ApplicationException("Ingrese una clave.");
                else if (trabajador == null)
                    throw new ApplicationException("Usuario o password erróneos.");
                return trabajador;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

}
