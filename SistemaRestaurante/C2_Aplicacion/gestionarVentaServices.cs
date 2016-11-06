using C4_Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C3_Dominio.Entidades;

namespace C2_Aplicacion
{
    public class gestionarVentaServices
    {
        #region Singleton
        public static readonly gestionarVentaServices _instancia = new gestionarVentaServices();
        public static gestionarVentaServices Instancia { get { return _instancia; } }
        #endregion

        private GestorDAOSQL gestorDAOSQL;
        private VentaSQL ventaSQL;

        public gestionarVentaServices()
        {
            gestorDAOSQL = new GestorDAOSQL();

        }

        public List<Venta> Listar(int? idVenta = null)
        {
            try
            {
                return ventaSQL.Listar(idVenta != null ? (int)idVenta : -1);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
