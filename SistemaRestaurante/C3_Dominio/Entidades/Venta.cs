using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio.Entidades
{
   public class Venta
    {


       public TipoVenta idTipoVenta {get; set;}
       public int idVenta    {get; set;}
       public Boolean estado {get; set;}

       public TipoVenta idTipoventa {get; set;}

       public Pedidocs idPedidos {get; set;}

              


    }
}
