using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio
{
    public class entPersona
    {
        public int idPersona { get; set; }
        public String nombres { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String dni { get; set; }
        public DateTime fechanac { get; set; }
        public String direccion { get; set; }
        public String telefono { get; set; }
        public Boolean estado { get; set; }

    }
}
