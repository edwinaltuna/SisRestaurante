using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_Persistencia
{
    public class Conexion
    {
        #region singleton
        private static readonly Conexion _instancia = new Conexion();
        public static Conexion Instancia
        {
            get { return Conexion._instancia; }
        }
        #endregion singleton

        #region metodos
        public SqlConnection conectar()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "whateverthefuckitis :^)";
            //"Integrated Security=SSPI";
            return cn;
        }
        #endregion metodos
    }
}
