using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio.Entidades
{
    public class AsignacionMesa
    {
        public int idAsignacionMesa { get; set; }
        public Mesa mesa { get; set; }
        public Trabajador Trabajador { get; set; }
    }
}
