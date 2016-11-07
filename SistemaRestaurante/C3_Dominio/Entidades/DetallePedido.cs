using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio.Entidades
{
    public class DetallePedido
    {
        public int id { get; set; }
        public int cantidad { get; set; }
        public string descripcion { get; set; }
        public bool estado { get; set; }
        public Producto producto { get; set; }
        public float IGV { get; set; }
        public float subtotal { get; set; }

        #region metodos
        public double calcularSubTotal()
        {
            subtotal =  cantidad * producto.precio;
            return subtotal;
        }

        public void calcularIGV(float actual)
        {
            calcularSubTotal();
            IGV = subtotal * actual ;
        }
        public double calcularSubTotalConIgv()
        {
            return cantidad * producto.precio * 1.18;
        }
        #endregion metodos
    }
}