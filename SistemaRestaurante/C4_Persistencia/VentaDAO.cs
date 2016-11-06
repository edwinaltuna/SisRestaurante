using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using C3_Dominio.Entidades;


namespace C4_Persistencia
{
    public class VentaDAO
    {

        private GestorDAOSQL gestorDAOSQL;

        public VentaDAO(GestorDAOSQL gestorDAOSQL)
        {
            this.gestorDAOSQL = gestorDAOSQL;
        }



       
    }
}
