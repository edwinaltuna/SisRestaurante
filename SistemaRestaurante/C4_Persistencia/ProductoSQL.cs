using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using C3_Dominio;
using C3_Dominio.Entidades;
using System.Data;

namespace C4_Persistencia
{
    public class ProductoSQL
    {
        #region Singleton
        private static readonly ProductoSQL _instancia = new ProductoSQL();
        public static ProductoSQL Instancia
        {
            get { return ProductoSQL._instancia; }
        }
        #endregion Singleton

        #region metodos
        #endregion
    }
}
