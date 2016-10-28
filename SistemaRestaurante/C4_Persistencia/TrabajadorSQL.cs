using System;
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
            trabajador.contrasena = resultado.GetString(10);
            tipo.idTipoTrabajador = resultado.GetInt32(11);
            tipo.nombre = resultado.GetString(12);
            tipo.descripcion = resultado.GetString(13);
            trabajador.TipoTrabajador = tipo;
            return trabajador;
        }

        public Trabajador Login(String Usuario, String Clave)
        {
            Trabajador trabajador = null;
            String sentenciaSQL = "select p.idPersona,p.nombres,p.apellidoPaterno,p.ApellidoMaterno,p.dni,p.fechaNacimiento,"+
                                  "p.direccion,p.telefono,t.idTrabajador,t.usuario,t.contrasena,tt.idTipoTrabajador,tt.nombre,tt.descripcion " +
                                  "from TB_Trabajador t inner join TB_Persona p on(t.idPersona = p.idPersona) "+
                                  "inner join TB_TipoTrabajador tt on(t.idTipoTrabajador = tt.idTipoTrabajador) "+
                                  "where t.estado = 1 and t.usuario = '"+ Usuario + "' and t.contrasena = '" + Clave + "'";
            try
            {
                SqlDataReader resultado = gestorDAOSQL.EjecutarConsulta(sentenciaSQL);
                if (resultado.Read()) {
                    trabajador = CrearObjetoTrabajador(resultado);
                }
                resultado.Close();
                return trabajador;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
