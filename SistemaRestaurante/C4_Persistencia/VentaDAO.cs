using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using C3_Dominio.Entidades;


namespace C4_Persistencia
{
    public class VentaDAO
    {

        private GestorDAOSQL gestorDAOSQL;

        public VentaDAO(GestorDAOSQL gestorDAOSQL)
        {
            this.gestorDAOSQL = gestorDAOSQL;
        }


       /* public List<VentaDAO> ListInstitutionType()
        {
            //SqlCommand cmd = null;
            //SqlDataReader dr = null;
            //List<VentaDAO> lstobjVenta = null;

            //try
            //{
            //    cmd = new SqlCommand("ReporteMensual",gestorDAOSQL.ObtenerComandoSQL());
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    dr = cmd.ExecuteReader();
            //    if (dr.HasRows)
            //    {
            //        lstobj = new List<clsInstitutionType>();
            //        while (dr.Read())
            //        {
            //            clsInstitutionType obj = new clsInstitutionType();
            //            obj.Description = dr.GetColumnValue<String>("DESCRIPTION");
            //            obj.ID = dr.GetColumnValue<Int32>("ID_INSTITUTION_TYPE");
            //            lstobj.Add(obj);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    lstobj = null;
            //    Entity.Errors.Add(new BaseEntity.ListError(ex, "No found."));
            //}
            //finally
            //{
            //    clsConnection.DisposeCommand(cmd);
            //}
            //return lstobj;
        }   
        */

       
    }
}
