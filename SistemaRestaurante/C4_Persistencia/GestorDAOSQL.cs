using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace C4_Persistencia
{
    public class GestorDAOSQL
    {
        #region Singleton
        private static readonly GestorDAOSQL _instancia = new GestorDAOSQL();
        public static GestorDAOSQL Instancia
        {
            get { return GestorDAOSQL._instancia; }
        }
        #endregion Singleton

        private SqlConnection conexion;
        private SqlTransaction transaction;

        public SqlConnection abrirConexion()
        {
            try
            {
                conexion = new SqlConnection();
                conexion.ConnectionString = "Data Source=uwjaf6p6fj.database.windows.net,1433;Initial Catalog=SistemaRestaurantBD;User ID=Administrador;Password=Admin123456";
                return conexion;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void cerrarConexion()
        {
            try
            {
                conexion.Close();
            }
            catch (Exception e) { throw e; }
        }

        public void IniciarTransacion()
        {
            try
            {
                abrirConexion();
                transaction = conexion.BeginTransaction();
            }
            catch (Exception e) { throw e; }
        }

        public void TerminarTransacion()
        {
            try
            {
                transaction.Commit();
                conexion.Close();
            }
            catch (Exception e) { throw e; }
        }

        public void CancelarTransaccion()
        {
            try
            {
                transaction.Rollback();
                conexion.Close();
            }
            catch (Exception e) { throw e; }
        }

        public SqlDataReader EjecutarConsulta(String SentenciaSQL)
        {
            try
            {
                SqlCommand comando = conexion.CreateCommand();
                if (transaction != null)
                    comando.Transaction = transaction;
                comando.CommandText = SentenciaSQL;
                comando.CommandType = CommandType.Text;
                SqlDataReader resultado = comando.ExecuteReader();
                return resultado;
            }
            catch (Exception e) { throw e; }
        }

        public SqlCommand obtenerComandoSQL(String sentenciaSQL, SqlConnection conexion, SqlTransaction transaccion = null)
        {
            try
            {
                SqlCommand comando = conexion.CreateCommand();
                if (transaccion != null)
                    comando.Transaction = transaccion;
                comando.CommandText = sentenciaSQL;
                comando.CommandType = CommandType.Text;
                return comando;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SqlCommand ObtenerComandoSP(String procedimiento_almacenado, SqlConnection conexion, SqlTransaction transaccion = null)
        {
            try
            {
                SqlCommand comando = conexion.CreateCommand();
                if (transaccion != null)
                    comando.Transaction = transaccion;
                comando.CommandText = procedimiento_almacenado;
                comando.CommandType = CommandType.StoredProcedure;
                return comando;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
