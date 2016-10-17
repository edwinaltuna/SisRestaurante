using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio
{
    public class entPedido
    {
        public int idPedido { get; set; }
        public DateTime fecha { get; set; }
        public Decimal total { get; set; }
        public String atendido { get; set; }
        public Boolean estado { get; set; }
        public entCliente cliente { get; set; }
        public entMesa mesa { get; set; }

    }
}
