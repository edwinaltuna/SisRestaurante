using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio
{
    public class Venta
    {
        public int idVenta { get; set; }
        public Boolean estado { get; set; }
        public TipoVenta tipoventa { get; set; }
        public entPedido pedido { get; set; }

    }
}
