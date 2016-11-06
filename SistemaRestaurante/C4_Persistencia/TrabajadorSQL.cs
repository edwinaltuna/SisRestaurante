using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using C3_Dominio;
using C3_Dominio.Entidades;

//a
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
            trabajador.id = resultado.GetInt32(0);
            trabajador.nombres = resultado.GetString(1);
            trabajador.apellidoPaterno = resultado.GetString(2);
            trabajador.apellidoMaterno = resultado.GetString(3);
            trabajador.dni = resultado.GetString(4);
            trabajador.fechaNacimiento = resultado.GetDateTime(5);
            trabajador.direccion = resultado.GetString(6);
            trabajador.telefono = resultado.GetString(7);
            trabajador.usuario = resultado.GetString(9);
            trabajador.contrasena = resultado.GetString(10);
            tipo.idTipoTrabajador = resultado.GetInt32(11);
            tipo.nombre = resultado.GetString(12);
            trabajador.tipoTrabajador = tipo;
            return trabajador;
        }

        public Trabajador Buscar(string Usuario, string Clave)
        {
            Trabajador trabajador = null;            
            try
            {
                using (SqlConnection conexionActual = GestorDAOSQL.Instancia.abrirConexion())
                {
                    conexionActual.Open();
                    SqlCommand comando = GestorDAOSQL.Instancia.ObtenerComandoSP("SP_BuscarUsuario", conexionActual);
                    comando.Parameters.AddWithValue("@param_username", Usuario);
                    comando.Parameters.AddWithValue("@param_password", Clave);
                    SqlDataReader resultado = comando.ExecuteReader();
                    if (resultado.Read())
                    {
                        trabajador = CrearObjetoTrabajador(resultado);
                    }
                    resultado.Close();
                    
                }
                return trabajador;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
