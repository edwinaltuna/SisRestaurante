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
        public Boolean RegistrarProducto(Producto p)
        {

            using (SqlConnection cn = GestorDAOSQL.Instancia.abrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand("insertarProducto", cn))
                {
                    try
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@precio", p.precio);
                        cmd.Parameters.AddWithValue("@descripcion", p.descripcion);
                        cmd.Parameters.AddWithValue("@fecha", p.fecha);
                        cmd.Parameters.AddWithValue("@imagen", p.imagen);
                        cmd.Parameters.AddWithValue("@idTipoProducto", p.tipoProducto.id);
                        cmd.Parameters.AddWithValue("@estado", p.estado);

                        cn.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                        return false;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            
        }

        public Producto ListarProductoPorId(Int16 id)
        {
            SqlCommand cmd = null;
            Producto p = null;
            try
            {
                using (SqlConnection cn = GestorDAOSQL.Instancia.abrirConexion())
                {
                    cmd = new SqlCommand("detalleProducto", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", id);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        p = new Producto();
                        p.id = Convert.ToInt16(dr["id"]);
                        p.precio = Convert.ToDouble(dr["descripcion"]);
                        p.descripcion = dr["descripcion"].ToString();
                        p.fecha = Convert.ToDateTime(dr["fecha"]);
                        p.imagen = dr["imagen"].ToString();
                        //t.descripcion = dr["descripcion"].ToString();
                        p.estado = Convert.ToBoolean(dr["estado"]);
                        TipoProducto tipo = new TipoProducto();
                        tipo.id = Convert.ToInt16(dr["idTipoProducto"]);
                        p.tipoProducto = tipo;

                    }
                }
                
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return p;

        }

        public Boolean EditarProducto(Producto p)
        {
            Boolean inserto = false;

            using (SqlConnection cn = GestorDAOSQL.Instancia.abrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand("editarProducto", cn))
                {
                    try
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", p.id);
                        cmd.Parameters.AddWithValue("@precio", p.precio);
                        cmd.Parameters.AddWithValue("@descripcion", p.descripcion);
                        cmd.Parameters.AddWithValue("@fecha", p.fecha);
                        cmd.Parameters.AddWithValue("@imagen", p.imagen);
                        cmd.Parameters.AddWithValue("@idTipoProducto", p.tipoProducto.id);
                        cmd.Parameters.AddWithValue("@estado", p.estado);

                        cn.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            inserto = true;
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return inserto;
        }

        public bool Delete(int id)
        {
            using (SqlConnection cn = GestorDAOSQL.Instancia.abrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand("borrarProducto", cn))
                {

                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);

                        cn.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            throw new Exception("Error al borrar Plato.");
                        }
                        else
                        {
                            return true;
                        }
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

