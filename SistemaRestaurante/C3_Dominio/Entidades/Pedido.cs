using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio.Entidades
{
    public class Pedido
    {
        int idPedido {get; set;}
        DateTime fecha {get; set;}
        Double total {get; set;}
        int estado {get; set;}
        Cliente idCliente {get; set;}
        Mesa mesa {get; set;}
        List<DetallePedido> detallesPedido {get;set;}    

        public double calcularTotal(){
            double totalCalculado = 0;
            foreach (var detalle in detallesPedido)
            {
                totalCalculado += detalle.calcularSubTotal();
            }
            return totalCalculado;
        }    

        public void agregarDetallePedido(DetallePedido detalleNuevo)
        {
            detallesPedido.add(detalleNuevo);
        }
    }
}
