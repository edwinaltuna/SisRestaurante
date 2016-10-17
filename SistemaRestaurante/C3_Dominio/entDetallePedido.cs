using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio
{
    public class entDetallePedido
    {
        public int idDetallePedido { get; set; }
        public Decimal subtotal { get; set; }
        public String descripcion { get; set; }
        public Boolean estado { get; set; }
        public entProducto producto { get; set; }
        public entPedido pedido { get; set; }

    }
}
