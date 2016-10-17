using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio
{
    public class entVenta
    {
        public int idVenta { get; set; }
        public Boolean estado { get; set; }
        public entTipoVenta tipoventa { get; set; }
        public entPedido pedido { get; set; }

    }
}
