using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio.Entidades
{
    public class TipoCliente
    {
        int  idTipoCliente {get; set;}
        String nombre {get; set;}
        String descripcion {get; set;}
        Boolean estado { get; set; }
    }
}
