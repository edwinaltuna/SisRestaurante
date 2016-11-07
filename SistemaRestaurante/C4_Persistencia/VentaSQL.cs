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

        public bool CambiarEstadoVenta(int idVenta,int estadoVenta)
        {
            bool cambio = false;
            using (SqlConnection conexionActual = gestorDAOSQL.abrirConexion())
            {
                using (SqlCommand cmd = gestorDAOSQL.ObtenerComandoSP("SP_CambiarEstadoVenta", conexionActual))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@param_idVenta", idVenta);
                        cmd.Parameters.AddWithValue("@param_estadoVenta", estadoVenta);
                        conexionActual.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            cambio = true;
                        }
                        return cambio;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        public Venta ListarDetallesDeVenta(int idVenta)
        {
            SqlCommand command = new SqlCommand();
            Venta venta = new Venta();
            Pedido pedido = new Pedido();
            List<DetallePedido> listaDetalles = new List<DetallePedido>();
            using (SqlConnection conexionActual = gestorDAOSQL.abrirConexion())
            {
                conexionActual.Open();
                try
                {
                    command = gestorDAOSQL.ObtenerComandoSP("SP_ListarDetallesDeVenta", conexionActual);
                    command.Parameters.AddWithValue("@param_idVenta", idVenta);
                    SqlDataReader resultado = command.ExecuteReader();
                    while (resultado.Read())
                    {
                        DetallePedido detalle = new DetallePedido();
                        detalle.cantidad = Convert.ToInt32(resultado["cantidad"]);                            
                            Producto producto = new Producto();
                            producto.precio = float.Parse(resultado["precio"].ToString());
                            producto.descripcion = resultado["descripcion"].ToString();
                        detalle.producto = producto;
                            Mesa mesa = new Mesa();
                            mesa.numero = resultado["numeroMesa"].ToString();
                            Trabajador trabajador = new Trabajador();
                            trabajador.nombres = resultado["nombre"].ToString();
                            trabajador.apellidoPaterno = resultado["apellidoPaterno"].ToString();
                            trabajador.apellidoMaterno = resultado["apellidoMaterno"].ToString();
                        pedido.trabajador = trabajador;
                        pedido.mesa = mesa;
                        venta.numero = Convert.ToInt32(resultado["numeroSerie"]);

                        listaDetalles.Add(detalle);
                    }
                    pedido.detallesPedido = listaDetalles;
                    venta.pedido = pedido;
                    return venta;
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
            tempVenta.id = Convert.ToInt32(resultado["idVenta"]);
            tempVenta.numero = Convert.ToInt32(resultado["numeroSerie"]);
            tempVenta.SerieNumero = resultado["numeroSerie"].ToString();
            tempVenta.estado = Convert.ToInt32(resultado["estado"]);
            tempVenta.fecha = DateTime.Parse(resultado["fecha"].ToString());
            tempVenta.total = float.Parse(resultado["totalPedido"].ToString());
            TipoTrabajador tipoTrabajador = new TipoTrabajador();
            tipoTrabajador.nombre = resultado["tipoTrabajadorNombre"].ToString();
            Trabajador trabajador = new Trabajador();
            trabajador.tipoTrabajador = tipoTrabajador;
            trabajador.nombres = resultado["nombre"].ToString();
            trabajador.apellidoPaterno = resultado["apellidoPaterno"].ToString();
            trabajador.apellidoMaterno = resultado["apellidoMaterno"].ToString();
            tempVenta.trabajador = trabajador;
            
            return tempVenta;
        }

        #endregion metodos
    }
}
