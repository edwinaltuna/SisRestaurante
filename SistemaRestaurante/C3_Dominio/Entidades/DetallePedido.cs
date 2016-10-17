using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio
{
    public class DetallePedido
    {
        public int idDetallePedido { get; set; }
        public Decimal subtotal { get; set; }
        public String descripcion { get; set; }
        public Boolean estado { get; set; }
        public Producto producto { get; set; }
        public entPedido pedido { get; set; }

    }
}
