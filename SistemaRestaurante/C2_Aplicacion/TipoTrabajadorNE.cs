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
    public class tipoTrabajadorNE
    {
        #region Singleton
        private static readonly tipoTrabajadorNE _instancia = new tipoTrabajadorNE();
        public static tipoTrabajadorNE Instancia
        {
            get { return tipoTrabajadorNE._instancia; }
        }
        #endregion Singleton
        #region methods

        public List<TipoTrabajador> ListarTipoTrabajadores()
        {
            try
            {
                return TipoTrabajadorDA.Instancia.ListarTrabajadores();
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
                return TipoTrabajadorDA.Instancia.RegistrarTipoTrabajador(t);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        public TipoTrabajador ListarTipoTrabajadores(short id)
        {
            try
            {
                return TipoTrabajadorDA.Instancia.ListarTrabajadorPorId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }



}




