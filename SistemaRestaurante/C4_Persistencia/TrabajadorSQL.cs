﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using C3_Dominio;
using C3_Dominio.Entidades;

namespace C4_Persistencia
{
    public class TrabajadorSQL
    {
        private GestorDAOSQL gestorDAOSQL;

        public TrabajadorSQL(GestorDAOSQL gestorDAOSQL)
        {
            this.gestorDAOSQL = gestorDAOSQL;
        }

        public Trabajador CrearObjetoTrabajador(SqlDataReader resultado)
        {
            Trabajador trabajador;
            TipoTrabajador tipo;
            trabajador = new Trabajador();
            tipo = new TipoTrabajador();
            trabajador.idPersona = resultado.GetInt32(0);
            trabajador.nombres = resultado.GetString(1);
            trabajador.apellidoPaterno = resultado.GetString(2);
            trabajador.apellidoMaterno = resultado.GetString(3);
            trabajador.dni = resultado.GetString(4);
            trabajador.fechaNacimiento = resultado.GetDateTime(5);
            trabajador.direccion = resultado.GetString(6);
            trabajador.telefono = resultado.GetString(7);
            trabajador.idTrabajador = resultado.GetInt32(8);
            trabajador.usuario = resultado.GetString(9);
            trabajador.usuario = resultado.GetString(10);
            tipo.idTipoTrabajador = resultado.GetInt32(11);
            tipo.nombre = resultado.GetString(12);
            tipo.descripcion = resultado.GetString(13);
            trabajador.TipoTrabajador = tipo;
            return trabajador;
        }
    }
}
