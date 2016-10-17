using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio
{
    public class entTrabajador : Persona
    {
        public int idTrabajador { get; set; }
        public String usuario { get; set; }
        public String contrasena { get; set; }
        public Boolean estado { get; set; }
        public TipoTrabajador tipotrabajador { get; set; }

    }
}
