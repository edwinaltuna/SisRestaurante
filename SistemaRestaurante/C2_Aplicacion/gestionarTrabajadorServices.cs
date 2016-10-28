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
                Trabajador trabajador = null;
                using (SqlConnection conexionActual = gestorDAOSQL.abrirConexion())
                {
                    conexionActual.Open();
                    trabajador = trabajadorSQL.Buscar(usuario, clave);

                }

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
                if(e.GetType().IsAssignableFrom(typeof(SqlException)))
                {
                    throw new ApplicationException("Error de conexión a la BD.");
                }
                throw e;
            }
        }
    }

}
