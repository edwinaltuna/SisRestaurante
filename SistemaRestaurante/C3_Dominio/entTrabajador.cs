using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio
{
    public class entTrabajador : entPersona
    {
        public int idTrabajador { get; set; }
        public String usuario { get; set; }
        public String contrasena { get; set; }
        public Boolean estado { get; set; }
        public entTipoTrabajador tipotrabajador { get; set; }

    }
}
