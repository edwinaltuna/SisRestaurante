using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using C3_Dominio;
using C3_Dominio.Entidades;

namespace C4_Persistencia
{
    public class TipoTrabajadorDA
    {
        #region Singleton
        private static readonly TipoTrabajadorDA _instancia = new TipoTrabajadorDA();
        public static TipoTrabajadorDA Instancia
        {
            get { return TipoTrabajadorDA._instancia; }
        }
        #endregion Singleton

        #region metodos
        public List<TipoTrabajador> ListarTrabajadores()
        {
            SqlCommand cmd = null;
            List<TipoTrabajador> listarTipoTrabajador = new List<TipoTrabajador>();
            try
            {
                SqlConnection cn = GestorDAOSQL.Instancia.Conectar();
                cmd = new SqlCommand("listarTipoTrabajador", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TipoTrabajador t = new TipoTrabajador();
                    t.idTipoTrabajador = Convert.ToInt16(dr["id"]);
                    t.nombre = dr["nombre"].ToString();
                    t.descripcion = dr["dni"].ToString();
                    t.estado = Convert.ToBoolean(dr["id"]);
                    listarTipoTrabajador.Add(t);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return listarTipoTrabajador;
        }

        public TipoTrabajador ListarTrabajadorPorId(Int16 id)
        {
            SqlCommand cmd = null;
            TipoTrabajador t = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_trabajador_listarXId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("in_id", id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    t = new TipoTrabajador();
                    t.idTipoTrabajador = Convert.ToInt16(dr["id"]);
                    t.nombre = dr["nombre"].ToString();
                    t.descripcion = dr["descripcion"].ToString();
                    t.estado = Convert.ToBoolean(dr["estado"]);

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return t;
        }

        public Boolean RegistrarTipoTrabajador(TipoTrabajador t)
        {
            Boolean inserto = false;

            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand("sp_trabajador_Registrar", cn))
                {
                    try
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", t.nombre);
                        cmd.Parameters.AddWithValue("@dni", t.descripcion);
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
