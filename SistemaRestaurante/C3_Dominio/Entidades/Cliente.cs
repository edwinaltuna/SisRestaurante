﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Dominio.Entidades
{
    public class Cliente : Persona
    {        
        string ruc {get; set; }
        TipoCliente tipoCliente {get; set; } 
    }
}
