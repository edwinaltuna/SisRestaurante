using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C3_Dominio.Entidades;
using System.Data.SqlClient;

namespace C4_Persistencia
{
    public class VentaSQL
    {
        private GestorDAOSQL gestorDAOSQL;
        public VentaSQL(GestorDAOSQL gestorDAOSQL)
        {
            this.gestorDAOSQL = gestorDAOSQL;
        }



        #region metodos
        public List<Venta> Listar(int idVenta)
        {
            SqlCommand command = new SqlCommand();
            List<Venta> listaVentas = new List<Venta>();
            using (SqlConnection conexionActual = gestorDAOSQL.abrirConexion())
            {
                conexionActual.Open();
                try
                {
                    command = gestorDAOSQL.ObtenerComandoSP("SP_ListarVenta", conexionActual);
                    command.Parameters.AddWithValue("@param_idVenta", idVenta);
                    SqlDataReader resultado = command.ExecuteReader();
                    while (resultado.Read())
                    {
                        listaVentas.Add(construirObjetoVenta(resultado));
                    }
                    return listaVentas;
                }
                catch (Exception)
                {
                    throw;
                }
               
            }
        }

        private Venta construirObjetoVenta(SqlDataReader resultado)
        {
            Venta tempVenta = new Venta();
            tempVenta.serieNumero = resultado["numeroSerie"].ToString();
            tempVenta.estado = int.Parse(resultado["estado"].ToString());
            tempVenta.fecha = DateTime.Parse(resultado["fecha"].ToString());
            TipoTrabajador tipoTrabajador = new TipoTrabajador();
            tipoTrabajador.nombre = resultado["tipoTrabajadorNombre"].ToString();
            tempVenta.total = float.Parse(resultado["totalPedido"].ToString());
           
            return tempVenta;
        }

        #endregion metodos
    }
}
