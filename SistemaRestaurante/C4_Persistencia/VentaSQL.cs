using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C3_Dominio.Entidades;

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
            return new List<Venta>();
        }
    }
}
