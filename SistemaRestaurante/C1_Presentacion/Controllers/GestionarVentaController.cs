using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using C3_Dominio.Entidades;
using C2_Aplicacion;

namespace C1_Presentacion.Controllers
{
    public class GestionarVentaController : Controller
    {
        //
        // GET: /GestionarVenta/

        public ActionResult Listar()
        {
            List<Venta> listaVentas = gestionarVentaServices.Instancia.Listar();
            return View(listaVentas);
        }


        [HttpGet]
        public ActionResult Crear()
        {
            List<Pedido> listaPedidos = generarPedidosFalsos();
            List<Pedido> listaPedidosAgregados = new List<Pedido>();

            return View(listaPedidos);
        }

        public List<Pedido> generarPedidosFalsos()
        {
            List<Pedido> tempPedido = new List<Pedido>();
            for (int i = 0;i < 10; i++)
            {
                Pedido pedido = new Pedido();
                pedido.id = i;
                pedido.estado = 0;
                pedido.fecha = DateTime.Now;
                Mesa mesa = new Mesa();
                mesa.id = 1;
                mesa.numero = "10";
                pedido.mesa = mesa;
                Trabajador trabajador = new Trabajador();
                trabajador.id = 1;
                trabajador.nombres = "Paul";
                trabajador.apellidoPaterno = "Farfan";
                trabajador.apellidoMaterno = "Altuna";
                TipoTrabajador tipoTrabajador = new TipoTrabajador();
                tipoTrabajador.idTipoTrabajador = 1;
                tipoTrabajador.estado = true;
                tipoTrabajador.nombre = "Administrador";
                trabajador.tipoTrabajador = tipoTrabajador;
                pedido.trabajador = trabajador;
                tempPedido.Add(pedido);
            }
            return tempPedido;
        }

        [HttpPost]
        public ActionResult CambiarEstado(int[] data)
        {
            bool cambio = gestionarVentaServices.Instancia.CambiarEstadoVenta(data[0], data[1]== 0 ? 1 : 0);
            List<int> parametros = new List<int>();
            parametros.Add(data[0]);
            parametros.Add(data[1] == 0 ? 1 : 0);
            return PartialView("_CambiarEstado",parametros);
        }

        [HttpPost]
        public ActionResult MostrarPedidosVenta(int[] data)
        {
            Venta venta= gestionarVentaServices.Instancia.ListarDetallesDeVenta(data[0]);
            
            return PartialView("_DetalleVenta",venta);
        }

    }
}
