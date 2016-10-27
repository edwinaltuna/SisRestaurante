using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio.Entidades
{
    public class TipoVenta
    {
        public int idTipoVenta { get; set; }
        public String nombre { get; set; }

        public String descripcion { get; set; }

        public Boolean estado { get; set; }

    }
}
