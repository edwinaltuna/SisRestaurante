using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio.Entidades
{
   public class Venta
    {
       public int id    {get; set;}
       public TipoVenta tipoVenta {get; set;}
       public Pedido pedido {get; set;}
       private int serie = 0;
       private int numero = 0;
       public DateTime fecha {get; set;}

       public int cantidad { get; set; } //reportes
       public string serieNumero 
       {
           get
           {
               calcularSiguienteSerie(serie);
               calcularSiguienteNumero(numero);
               return serie.ToString("3D") + " - " + numero.ToString("10D");
           }
       }

       #region metodos
       public void calcularSiguienteSerie(int serie)
       {
           this.serie = serie+1;
           //TODO: algoritmo para calcular serie 
       }

       public void calcularSiguienteNumero(int numero)
       {
           this.numero =  numero + 1;
            //TODO: algoritmo para calcular serie 
       }
       #endregion metodos
    }
}
