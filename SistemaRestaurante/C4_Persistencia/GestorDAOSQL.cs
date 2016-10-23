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
        private SqlConnection conexion;
        private SqlTransaction transaction;

        public void abrirConexion()
        {
            try
            {
                conexion = new SqlConnection();
                conexion.ConnectionString = "Data source=uwjaf6p6fj.database.windows.net,1433;Initial Catalog=SistemaRestaurantBD;" +
                 "User ID=Administrador;Password=Admi123456";
                conexion.Open();
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

        public SqlCommand ObtenerComandoSQL(String sentenciaSQL)
        {
            try
            {
                SqlCommand comando = conexion.CreateCommand();
                if (transaction != null)
                    comando.Transaction = transaction;
                comando.CommandText = sentenciaSQL;
                comando.CommandType = CommandType.Text;
                return comando;
            }
            catch (Exception e) { throw e; }
        }

        public SqlCommand ObtenerComandoSP(String procedure)
        {
            try
            {
                SqlCommand comando = conexion.CreateCommand();
                if (transaction != null)
                    comando.Transaction = transaction;
                comando.CommandText = procedure;
                comando.CommandType = CommandType.StoredProcedure;
                return comando;
            }
            catch (Exception e) { throw e; }
        }
    }
}
