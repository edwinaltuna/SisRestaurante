using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C3_Dominio.Entidades;
using C4_Persistencia;

namespace C2_Aplicacion
{
    public class gestionarProductoServices
    {
        #region Singleton
        private static readonly gestionarProductoServices _instancia = new gestionarProductoServices();
        public static gestionarProductoServices Instancia
        {
            get { return gestionarProductoServices._instancia; }
        }
        #endregion Singleton
        #region methods

        public List<Producto> ListarProductos()
        {
            try
            {
                return ProductoSQL.Instancia.ListarProductos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Boolean RegistrarProducto(Producto t)
        {
            try
            {
                return ProductoSQL.Instancia.RegistrarProducto(t);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                return ProductoSQL.Instancia.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Producto producto)
        {
            try
            {
                return ProductoSQL.Instancia.EditarProducto(producto);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Producto DetallesPlato(int id)
        {
            try
            {
                return ProductoSQL.Instancia.ListarProductoPorId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}