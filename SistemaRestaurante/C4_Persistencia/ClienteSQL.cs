using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C3_Dominio.Entidades;
using System.Data.SqlClient;

namespace C4_Persistencia
{
    public class ClienteSQL
    {
        private GestorDAOSQL gestorDAOSQL;
        public ClienteSQL(GestorDAOSQL gestorDAOSQL)
        {
            this.gestorDAOSQL = gestorDAOSQL;
        }

        public Cliente construirObjetoCliente(SqlDataReader resultado)
        {
            Cliente tmpCliente = new Cliente();
            tmpCliente.id = Convert.ToInt32(resultado["idPersona"]);
            tmpCliente.dni = resultado["dni"].ToString();
            tmpCliente.nombres = resultado["nombre"].ToString();
            tmpCliente.apellidoPaterno = resultado["apellidoPaterno"].ToString();
            tmpCliente.apellidoMaterno = resultado["apellidoMaterno"].ToString();
            tmpCliente.ruc = resultado["ruc"].ToString();
            tmpCliente.fechaNacimiento = DateTime.Parse(resultado["fechaNacimiento"].ToString());
            //tmpCliente.telefono no hay XDXDXD
            return tmpCliente;
        }

        public List<Cliente> Listar()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            using (SqlConnection conexionActual = gestorDAOSQL.abrirConexion())
            {
                using (SqlCommand command = gestorDAOSQL.ObtenerComandoSP("SP_ListarClientes", conexionActual))
                {
                    try
                    {
                        conexionActual.Open();
                        SqlDataReader resultado = command.ExecuteReader();
                        while (resultado.Read())
                        {
                            listaClientes.Add(construirObjetoCliente(resultado));
                        }
                        return listaClientes;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
    }
}
