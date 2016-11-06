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
    public class MesaSQL
    {
        private GestorDAOSQL gestorDAOSQL;
        public MesaSQL(GestorDAOSQL gestorDAOSQL)
        {
            this.gestorDAOSQL = gestorDAOSQL;
        }
        #region Objeto
        private Mesa crearObjetoMesa(SqlDataReader resultado){
            Mesa mesa;
            mesa = new Mesa();
            mesa.id = resultado.GetInt32(0);
            mesa.numero = resultado.GetString(1);
            mesa.descripcion = resultado.GetString(2);
            mesa.estado = resultado.GetBoolean(3);
            return mesa;
        }
        #endregion

        #region Metodos
        public List<Mesa> ListarMesa(Int32 idTrabajador)
        {
            Mesa mesa;
            List<Mesa> listmesa = new List<Mesa>();
            try
            {
                using (SqlConnection conexion = GestorDAOSQL.Instancia.abrirConexion())
                {
                    conexion.Open();
                    SqlCommand cmd = GestorDAOSQL.Instancia.ObtenerComandoSP("sp_ListarMesa", conexion);
                    cmd.Parameters.AddWithValue("@idTrabajador", idTrabajador);
                    SqlDataReader resultado = cmd.ExecuteReader();
                    while(resultado.Read()){
                        mesa = crearObjetoMesa(resultado);
                        listmesa.Add(mesa);
                    }
                    resultado.Close();
                }
                return listmesa;
        
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
