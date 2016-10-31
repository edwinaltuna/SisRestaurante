using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio.Entidades
{
    public class Trabajador : Persona
    {
        public String usuario { get; set; }
        public String contrasena { get; set; }
        public String direccion { get; set; }
        public string telefono { get; set; }
        public TipoTrabajador tipoTrabajador { get; set; }
    }
}
