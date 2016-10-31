using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio.Entidades
{
    public class Pedido
    {
        int id {get; set;}
        DateTime fecha {get; set;}
        double total {get; set;}
        int estado {get; set;}
        Cliente idCliente {get; set;}
        Mesa mesa {get; set;}
        List<DetallePedido> detallesPedido {get;set;}

        #region metodos
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
            detallesPedido.Add(detalleNuevo);
        }
        #endregion metodos
    }
}
