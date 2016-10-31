using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio.Entidades
{
    public class Trabajador : Persona
    {
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public TipoTrabajador tipoTrabajador { get; set; }

        #region metodos
        public bool telefonoValido()
        {
            string[] elementos = telefono.Split('-');
            return elementos[1].Length == 6;
        }
        #endregion metodos
    }
}
