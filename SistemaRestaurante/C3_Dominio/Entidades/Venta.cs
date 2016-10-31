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
       private string serie {get;set;}
       private string numero { get; set; }
       public string serieNumero 
       {
           get
           {
               return serie + " - " + numero;
           }
       }

       #region metodos
       public void calcularSiguienteSerie()
       {
           //TODO: algoritmo para calcular serie 
       }

       public void calcularSiguienteNumero()
       {
            //TODO: algoritmo para calcular serie 
       }
       #endregion metodos
    }
}
