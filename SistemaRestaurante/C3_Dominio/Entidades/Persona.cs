using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio.Entidades
{
    public class Persona
    {
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string dni { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public bool estado { get; set; }

        #region metodos
        public bool esMayorDeEdad()
        {
            return DateTime.Now.Year - fechaNacimiento.Year == 18;
        }
        
        public string generarNombreCompleto()
        {
            return string.Format("{0} {1} {2}",nombres, apellidoPaterno, apellidoMaterno);
        }
        #endregion metodos
    }
}
