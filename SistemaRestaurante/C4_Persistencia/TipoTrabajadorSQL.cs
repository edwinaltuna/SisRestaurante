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
    public class TipoTrabajadorSQL
    {
        #region Singleton
        private static readonly TipoTrabajadorSQL _instancia = new TipoTrabajadorSQL();
        public static TipoTrabajadorSQL Instancia
        {
            get { return TipoTrabajadorSQL._instancia; }
        }
        #endregion Singleton

        #region metodos
        public List<TipoTrabajador> ListarTrabajadores()
        {
            SqlCommand cmd = null;
            List<TipoTrabajador> listarTipoTrabajador = new List<TipoTrabajador>();
            try
            {
                using (SqlConnection cn = GestorDAOSQL.Instancia.abrirConexion())
                {
                    cmd = new SqlCommand("listarTipoTrabajador", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        TipoTrabajador t = new TipoTrabajador();
                        t.idTipoTrabajador = Convert.ToInt16(dr["id"]);
                        t.nombre = dr["nombre"].ToString();
                        //t.descripcion = dr["dni"].ToString();
                        t.estado = Convert.ToBoolean(dr["estado"]);
                        listarTipoTrabajador.Add(t);
                    }
                }
                return listarTipoTrabajador;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public TipoTrabajador ListarTrabajadorPorId(Int16 id)
        {
            SqlCommand cmd = null;
            TipoTrabajador t = null;
            try
            {
                using (SqlConnection cn = GestorDAOSQL.Instancia.abrirConexion())
                {
                    cmd = new SqlCommand("detallesTipoTrabajador", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("in_id", id);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        t = new TipoTrabajador();
                        t.idTipoTrabajador = Convert.ToInt16(dr["id"]);
                        t.nombre = dr["nombre"].ToString();
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

        public Boolean RegistrarTipoTrabajador(TipoTrabajador t)
        {
            Boolean inserto = false;

            using (SqlConnection cn = GestorDAOSQL.Instancia.abrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand("insertarTipoTrabajador", cn))
                {
                    try
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", t.nombre);
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
