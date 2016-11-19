using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio.Entidades
{
   public class Venta
    {
        public int id { get; set; }
        public TipoVenta tipoVenta { get; set; }
        public Pedido pedido { get; set; }
        public int estado { get; set; }
        public DateTime fecha { get; set; }
        public Trabajador trabajador { get; set; }
        public float descuento { get; set; }

        public float total { get; set; }

        public int serie = 0;

        public int numero = 0;
        public int cantidad { get; set; } //reportes
        public string serieNumero;
        public string SerieNumero
        {

            set
            {
                serieNumero = value;
            }
           get
           {
               //calcularSiguienteSerie(serie);
               //calcularSiguienteNumero(numero);
                return string.Format("{0:D3} - {1:D10}", serie, numero); 
           }
       }

       #region metodos
       public void calcularSiguienteSerie(int serie)
       {
            this.serie = serie + 1;
           //TODO: algoritmo para calcular serie 
       }

       public void calcularSiguienteNumero(int numero)
       {
            this.numero = numero + 1;
            //TODO: algoritmo para calcular serie 
       }
       #endregion metodos
    }
}
