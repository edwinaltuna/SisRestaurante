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
    public class TipoProductoSQL
    {
        #region Singleton
        private static readonly TipoProductoSQL _instancia = new TipoProductoSQL();
        public static TipoProductoSQL Instancia
        {
            get { return TipoProductoSQL._instancia; }
        }
        #endregion Singleton

        #region metodos

        public List<TipoProducto> ListarProductos()
        {
            SqlCommand cmd = null;
            List<TipoProducto> listarTipoProducto = new List<TipoProducto>();
            try
            {
                using (SqlConnection cn = GestorDAOSQL.Instancia.abrirConexion())
                {
                    cmd = new SqlCommand("listarTipoProducto", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        TipoProducto t = new TipoProducto();
                        t.id = Convert.ToInt16(dr["id"]);
                        t.descripcion = dr["nombre"].ToString();
                        //t.descripcion = dr["dni"].ToString();
                        t.estado = Convert.ToBoolean(dr["estado"]);
                        listarTipoProducto.Add(t);
                    }
                }
                return listarTipoProducto;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public TipoProducto ListarTipoProductoPorId(Int16 id)
        {
            SqlCommand cmd = null;
            TipoProducto t = null;
            try
            {
                using (SqlConnection cn = GestorDAOSQL.Instancia.abrirConexion())
                {
                    cmd = new SqlCommand("detallesTipoProducto", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("in_id", id);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        t = new TipoProducto();
                        t.id = Convert.ToInt16(dr["id"]);
                        t.descripcion = dr["descripcion"].ToString();
                        //t.descripcion = dr["descripcion"].ToString();
                        t.estado = Convert.ToBoolean(dr["estado"]);

                    }
                }
                return t;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public Boolean RegistrarTipoTrabajador(TipoProducto t)
        {
            Boolean inserto = false;

            using (SqlConnection cn = GestorDAOSQL.Instancia.abrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand("insertarTipoProducto", cn))
                {
                    try
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@descripcion", t.descripcion);
                        //cmd.Parameters.AddWithValue("@descripcion", t.descripcion);
                        cmd.Parameters.AddWithValue("@estado", t.estado);

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

        #endregion
    }
}
