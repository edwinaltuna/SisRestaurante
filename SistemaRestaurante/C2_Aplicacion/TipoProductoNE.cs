using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C2_Aplicacion;
using C3_Dominio.Entidades;
using C4_Persistencia;

namespace C2_Aplicacion
{
    public class tipoProductoNE
    {
        #region Singleton
        private static readonly tipoProductoNE _instancia = new tipoProductoNE();
        public static tipoProductoNE Instancia
        {
            get { return tipoProductoNE._instancia; }
        }
        #endregion Singleton
        #region methods

        public List<TipoProducto> ListarTipoTrabajadores()
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


        public Boolean RegistrarTipoTrabajador(TipoTrabajador t)
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




