using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio
{
    public class entCliente : entPersona
    {
        public int idCliente { get; set; }
        public entPersona persona { get; set; }
        public String ruc { get; set; }
        public String direccion { get; set; }
        public String telefono { get; set; }
        public Boolean estado { get; set; }
        public entTipoCliente tipocliente { get; set; }
    }
}
