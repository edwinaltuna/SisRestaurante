using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using C3_Dominio.Entidades;
using C4_Persistencia;

namespace C2_Aplicacion
{
    public class gestionarPedidoServices
    {
        #region Singleton
        public static readonly gestionarPedidoServices _instancia = new gestionarPedidoServices();
        public static gestionarPedidoServices Instancia { get { return gestionarPedidoServices._instancia; } }
        #endregion

        private GestorDAOSQL gestorDAOSQL;
        private PedidoSQL pedidoSQL;

        public gestionarPedidoServices()
        {
            gestorDAOSQL = new GestorDAOSQL();
            pedidoSQL = new PedidoSQL(gestorDAOSQL);
        }

        public List<Producto> ListarPedido()
        {
            try
            {
                List<Producto> listarProducto = pedidoSQL.ListarProducto();
                return listarProducto;
            }
            catch (Exception e)
            {
                if (e.GetType().IsAssignableFrom(typeof(SqlConnection)))
                {
                    throw new ApplicationException("Error de Conexion a la Bd");
                }
                throw e;
            }
        }
    }
}
