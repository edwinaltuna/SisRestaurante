using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using C3_Dominio.Entidades;

namespace C4_Persistencia
{
    public class PedidoSQL
    {
        private GestorDAOSQL gestorDAOSQL;

        public PedidoSQL(GestorDAOSQL gestorDAOSQL)
        {
            this.gestorDAOSQL = gestorDAOSQL;
        }
        private Producto CrearObjetoProducto(SqlDataReader resultado)
        {
            Producto producto;
            producto = new Producto();
            producto.id = resultado.GetInt32(0);
            producto.descripcion = resultado.GetString(1);
            producto.fecha = resultado.GetDateTime(2);
            producto.imagen = resultado.GetString(3);
            TipoProducto tipo = new TipoProducto();
            tipo.id = resultado.GetInt32(4);
            producto.tipoProducto = tipo;
            return producto;
        }

        #region Metodos
        public List<Producto> ListarProducto()
        {
            Producto producto;
            List<Producto> listProducto = new List<Producto>();
            try
            {
                using (SqlConnection conexion = GestorDAOSQL.Instancia.abrirConexion())
                {
                    conexion.Open();
                    SqlCommand cmd = GestorDAOSQL.Instancia.ObtenerComandoSP("sp_ListarProducto", conexion);
                    SqlDataReader resultado = cmd.ExecuteReader();
                    while(resultado.Read()){
                        producto = CrearObjetoProducto(resultado);
                        listProducto.Add(producto);
                    }
                    resultado.Close();
                }
                return listProducto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion


    }
}
