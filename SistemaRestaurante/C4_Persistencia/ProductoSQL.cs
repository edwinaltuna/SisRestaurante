using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using C3_Dominio;
using C3_Dominio.Entidades;
using System.Data;

namespace C4_Persistencia
{
    public class ProductoSQL
    {
        #region Singleton
        private static readonly ProductoSQL _instancia = new ProductoSQL();
        public static ProductoSQL Instancia
        {
            get { return ProductoSQL._instancia; }
        }
        #endregion Singleton

 

        private Producto CrearObjetoProducto(SqlDataReader resultado)
        {
            Producto producto;
            producto = new Producto();
            producto.id = resultado.GetInt32(0);
            producto.precio = Convert.ToDouble(resultado.GetDecimal(1));
            producto.descripcion = resultado.GetString(2);
            producto.fecha = resultado.GetDateTime(3);
            producto.imagen = resultado.GetString(4);
            TipoProducto tipo = new TipoProducto();
            tipo.id = resultado.GetInt32(5);
            producto.tipoProducto = tipo;
            return producto;
        }

       
        public List<Producto> ListarProductos()
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
                    while (resultado.Read())
                    {
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
       }

}

