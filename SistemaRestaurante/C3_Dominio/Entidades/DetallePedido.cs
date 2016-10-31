using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio.Entidades
{
   public class DetallePedido
    {
       public int id {get; set;}
       public int cantidad {get;set;}
       public string descripcion {get;set;}
       public bool estado {get;set;}
       public Producto producto {get;set;}

       public double calcularSubTotal()
       {
           return cantidad*producto.precio;
       }
    }
}