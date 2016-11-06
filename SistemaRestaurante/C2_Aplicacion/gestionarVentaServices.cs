using C4_Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
