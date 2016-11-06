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
   public  class ReporteDAO
    {
       private GestorDAOSQL gestorDAOSQL;

       public ReporteDAO(GestorDAOSQL gestorDAOSQL)
        {
            this.gestorDAOSQL = gestorDAOSQL;
        }


       public List<Reporte> ListarVenta(DateTime fechaInicio, DateTime fechaFin)
       {

           List<Reporte> list = null;
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
                    if(dr.HasRows)
                    {
                        list = new List<Reporte>();
                      
                        while(dr.Read()){

                            Reporte re = new Reporte();
                        //re.FechaVenta = dr["fecha"].ToString();
                        re.cantidad = Convert.ToInt16((dr["cantidad"]));
                        re.FechaVenta = dr["fecha"].ToString();

                        list.Add(re); 
                        } 
                    }                   
                }  
               return(list);
           }
           catch (Exception e)
           {
               throw;
           }

           finally
           {

               dr.Close();
           }
         
       }
      



       






    }
}
