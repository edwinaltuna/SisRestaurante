using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using C3_Dominio;
using C3_Dominio.Entidades;

namespace C4_Persistencia
{//TYRTYRTY
   public  class ReporteSQL
    {
       private GestorDAOSQL gestorDAOSQL;

       public ReporteSQL(GestorDAOSQL gestorDAOSQL)
        {
            this.gestorDAOSQL = gestorDAOSQL;
        }



       #region Objeto
       private Venta CrearReporte(SqlDataReader result)
       {
           Venta ventaReporte = new Venta();
           ventaReporte.cantidad = result.GetInt16(0);
           ventaReporte.fecha = result.GetDateTime(1);
           

           return ventaReporte;
       }
       #endregion


       #region Metodos
       public List<Venta> ListarVenta(DateTime fechaInicio, DateTime fechaFin)
       {
           Venta ventaList;
           List<Venta> list = new List<Venta>();
           // List<Reporte> report;
           SqlDataReader dr = null;

           try
           {
               using (SqlConnection conexion = GestorDAOSQL.Instancia.abrirConexion())
               {
                   conexion.Open();
                   SqlCommand comand = GestorDAOSQL.Instancia.ObtenerComandoSP("ReporteMensual", conexion);
                   comand.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                   comand.Parameters.AddWithValue("@FechaFin", fechaFin);
                   dr = comand.ExecuteReader();
                
                       while (dr.Read())
                       {

                        ventaList=CrearReporte(dr);

                          list.Add(ventaList);
                       }
                   return list;
                   }
             
           }
           catch (Exception e )
           {
               throw e;
           }

           finally
           {

               dr.Close();
           }

       }
#endregion 

       /*reporte*/
         }
}
