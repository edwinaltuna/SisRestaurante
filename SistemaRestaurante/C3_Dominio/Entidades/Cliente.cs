using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio
{
    public class Cliente : Persona
    {
        public int idCliente { get; set; }
        public Persona persona { get; set; }
        public String ruc { get; set; }
        public String direccion { get; set; }
        public String telefono { get; set; }
        public Boolean estado { get; set; }
        public TipoCliente tipocliente { get; set; }
    }
}
