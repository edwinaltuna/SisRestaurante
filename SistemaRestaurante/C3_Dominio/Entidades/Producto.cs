using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio.Entidades
{
    public class Producto
    {
        public int id {get;set;}
        public float precio { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }
        public string imagen { get; set; }
        public bool estado { get; set; }
        public TipoProducto tipoProducto { get; set; }
        #region metodos
        public bool estaDisponible()
        {
            return estado;
        }
        #endregion metodos
    }
}
