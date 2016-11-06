using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C3_Dominio.Entidades;
using C4_Persistencia;

namespace C2_Aplicacion
{
    public class gestionarTipoProductoServices
    {
        #region Singleton
        private static readonly gestionarTipoProductoServices _instancia = new gestionarTipoProductoServices();
        public static gestionarTipoProductoServices Instancia
        {
            get { return gestionarTipoProductoServices._instancia; }
        }
        #endregion Singleton
        #region methods

        public List<TipoProducto> ListarTipoProductos()
        {
            try
            {
                return TipoProductoSQL.Instancia.ListarProductos();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public Boolean RegistrarTipoTrabajador(TipoProducto t)
        {
            try
            {
                return TipoProductoSQL.Instancia.RegistrarTipoProducto(t);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        public TipoProducto ListarTipoProductoPorId(short id)
        {
            try
            {
                return TipoProductoSQL.Instancia.ListarTipoProductoPorId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }



}




