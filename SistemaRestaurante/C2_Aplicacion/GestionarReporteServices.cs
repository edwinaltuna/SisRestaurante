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
    public class gestionarReporteServices
    {
        #region Singleton
        public static readonly gestionarReporteServices _instancia = new gestionarReporteServices();
        public static gestionarReporteServices Instancia { get { return gestionarReporteServices._instancia; } }
        #endregion


        private GestorDAOSQL gestorDAOSQL;
        private ReporteSQL reporteDAO;

        public gestionarReporteServices()
        {
            gestorDAOSQL = new GestorDAOSQL();
            reporteDAO = new ReporteSQL(gestorDAOSQL);
        }


        #region Metodos
        public List<Venta> ListarVenta(DateTime FechaInicio, DateTime FechaFin)
        {
            try
            {
                gestorDAOSQL.abrirConexion();
                List<Venta> listarMesa = reporteDAO.ListarVenta(FechaInicio, FechaFin);
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
