using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C3_Dominio.Entidades;
using C4_Persistencia;


namespace C2_Aplicacion
{
    public class gestionarClienteServices
    {
        #region Singleton
        public static readonly gestionarClienteServices _instancia = new gestionarClienteServices();
        public static gestionarClienteServices Instancia { get { return _instancia; } }
        #endregion
        private GestorDAOSQL gestorDAOSQL;
        private ClienteSQL clienteSQL;

        public gestionarClienteServices()
        {
            gestorDAOSQL = new GestorDAOSQL();
            clienteSQL = new ClienteSQL(gestorDAOSQL);
        }

        public List<Cliente> Listar()
        {
            try
            {
                return clienteSQL.Listar();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
