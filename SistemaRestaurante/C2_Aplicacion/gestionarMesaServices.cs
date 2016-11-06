using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using C3_Dominio.Entidades;
using C4_Persistencia;

namespace C2_Aplicacion
{
    public class gestionarMesaServices
    {
        #region Singleton
        public static readonly gestionarMesaServices _instancia = new gestionarMesaServices();
        public static gestionarMesaServices Instancia { get { return gestionarMesaServices._instancia; } }
        #endregion

        private GestorDAOSQL gestorDAOSQL;
        private MesaSQL mesaDAO;

        public gestionarMesaServices()
        {
            gestorDAOSQL = new GestorDAOSQL();
            mesaDAO = new MesaSQL(gestorDAOSQL);
        }

        #region Metodos
        public List<Mesa> ListarMesa(Int32 idTrabajador)
        {
            try
            {
                gestorDAOSQL.abrirConexion();
                List<Mesa> listarMesa = mesaDAO.ListarMesa(idTrabajador);
                gestorDAOSQL.cerrarConexion();
                return listarMesa;
            }
            catch (Exception e)
            {
                if (e.GetType().IsAssignableFrom(typeof(SqlConnection)))
                {
                    throw new ApplicationException("Error de conexion a la Bd");
                }
                throw e;
            }
        }
        #endregion
    }
}
