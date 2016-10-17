using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio
{
    public class Producto
    {
        public int idProducto { get; set; }
        public String nombre { get; set; }
        public float precio { get; set; }
        public String descripcion { get; set; }
        public DateTime fecha { get; set; }
        public String imagen { get; set; }
        public Boolean estado { get; set; }
        public TipoProducto tipoproducto { get; set; }

    }
}
