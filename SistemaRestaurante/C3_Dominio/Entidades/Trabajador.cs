using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio.Entidades
{
    public class Trabajador : Persona
    {
        public int idTrabajador { get; set; }
        public String usuario { get; set; }
        public String contrasena { get; set; }
        public TipoTrabajador TipoTrabajador { get; set; }
    }
}
