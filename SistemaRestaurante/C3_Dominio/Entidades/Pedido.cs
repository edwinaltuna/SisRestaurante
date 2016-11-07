using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio.Entidades
{
    public class Pedido
    {
        public int id {get; set;}
        public DateTime fecha {get; set;}
        public double total {get; set;}
        public int estado {get; set;}
        public Cliente idCliente {get; set;}
        public Mesa mesa {get; set;}
        public List<DetallePedido> detallesPedido {get;set;}
        public Trabajador trabajador { get; set;}

        #region metodos
        public double calcularTotal(){
            double totalCalculado = 0;
            foreach (var detalle in detallesPedido)
            {
                totalCalculado += detalle.calcularSubTotal();
            }
            return totalCalculado;
        }    

        public float calcularIgv()
        {
            float igv = 0f;
            foreach(DetallePedido detalle in detallesPedido)
            {
                igv += detalle.IGV;
            }
            return igv;
        }

        public void agregarDetallePedido(DetallePedido detalleNuevo)
        {
            detallesPedido.Add(detalleNuevo);
        }
        #endregion metodos
    }
}
