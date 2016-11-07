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

        #region metodos

        public List<Producto> ListarProductos()
        {
            SqlCommand cmd = null;
            List<Producto> listarProducto = new List<Producto>();
            try
            {
                using (SqlConnection cn = GestorDAOSQL.Instancia.abrirConexion())
                {
                    cmd = new SqlCommand("listarProducto", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Producto p = new Producto();
                        p.id = Convert.ToInt16(dr["idProducto"]);
                        p.precio = Convert.ToDouble(dr["precio"]);

                        p.descripcion = dr["descripcion"].ToString();
                        //t.descripcion = dr["dni"].ToString();
                        p.fecha = Convert.ToDateTime(dr["fecha"]);

                        p.imagen = dr["imagen"].ToString();
                        p.estado = Convert.ToBoolean(dr["estado"]);

                        listarProducto.Add(p);
                    }
                }
                return listarProducto;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        #endregion
    }
}
