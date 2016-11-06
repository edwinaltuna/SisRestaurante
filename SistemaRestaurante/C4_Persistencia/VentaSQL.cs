using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C3_Dominio.Entidades;
using System.Data.SqlClient;

namespace C4_Persistencia
{
    public class VentaSQL
    {
        private GestorDAOSQL gestorDAOSQL;
        public VentaSQL(GestorDAOSQL gestorDAOSQL)
        {
            this.gestorDAOSQL = gestorDAOSQL;
        }

        public List<Venta> Listar()
        {
            using (SqlConnection conexionActual = gestorDAOSQL.abrirConexion())
            {
                
            }
            return new List<Venta>();
        }
    }
}
