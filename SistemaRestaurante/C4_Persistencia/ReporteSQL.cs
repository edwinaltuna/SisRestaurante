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
       public Producto crearReporteProducto(SqlDataReader resultado)
       {
           try
           {
               Producto p = new Producto();
               p.id = resultado.GetInt32(0);
               p.descripcion = resultado.GetString(1);
               p.precio = Convert.ToDouble(resultado.GetOrdinal("precio"));
               p.imagen = resultado.GetString(3);
               p.fecha = resultado.GetDateTime(4);
               p.estado = Convert.ToBoolean(resultado.GetOrdinal("estado"));
               return p;
           }
           catch (Exception e)
           {
               throw e;
           }
       }
       public IList<Producto> listarProductosMasVendidos()
       {
           List<Producto> lista = new List<Producto>();
           Producto p = null;
           using (SqlConnection conexionActual = GestorDAOSQL.Instancia.abrirConexion())
           {

               conexionActual.Open();
               String sp = "SP_ProductoMasVendidosPorFecha";
               SqlCommand comando = GestorDAOSQL.Instancia.ObtenerComandoSP(sp, conexionActual);
               //String fecha = Convert.ToString(DateTime.Now.Year) +"-"+Convert.ToString(DateTime.Now.Month)+"-" + Convert.ToString(DateTime.Now.Day);
               String fecha = "2016-10-02";
               comando.Parameters.AddWithValue("@fecha", fecha);
               SqlDataReader resultado = comando.ExecuteReader();
               while (resultado.Read())
               {
                   p = crearReporteProducto(resultado);
                   lista.Add(p);

               }
               resultado.Close();

               return lista;

           }

       }
#endregion 

       /*reporte*/
         }
}
