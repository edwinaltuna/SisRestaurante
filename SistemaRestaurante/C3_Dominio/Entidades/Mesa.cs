﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio.Entidades
{
    public class Mesa
    {
        public int id {get; set; }
        public string numero {get; set; }
        public string descripcion { get; set; }
        public bool estado { get; set; }

        #region metodos
        public bool estaOcupada()
        {
            return estado;
        }
        #endregion metodos
    }
}
