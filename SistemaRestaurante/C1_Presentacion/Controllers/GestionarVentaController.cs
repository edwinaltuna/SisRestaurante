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
            List<Cliente> listaClientes = gestionarClienteServices.Instancia.Listar();
            int idPedido = -1;
            Session["listaClientes"] = listaClientes;
            Session["idPedido"] = idPedido;
            return View(listaPedidos);
        }

        public List<Pedido> generarPedidosFalsos()
        {
            List<Pedido> tempPedido = new List<Pedido>();
            for (int i = 0; i < 10; i++)
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
            bool cambio = gestionarVentaServices.Instancia.CambiarEstadoVenta(data[0], data[1] == 0 ? 1 : 0);
            List<int> parametros = new List<int>();
            parametros.Add(data[0]);
            parametros.Add(data[1] == 0 ? 1 : 0);
            return PartialView("_CambiarEstado", parametros);
        }

        [HttpPost]
        public ActionResult CargarDetalleCliente(int[] data)
        {
            TempData["idCliente"] = data[0];
            return PartialView("_DetalleCliente");
        }

        [HttpPost]
        public ActionResult VerificarAccedeDescuento(int[] data)
        {
            List<Cliente> listaClientes = (List<Cliente>)Session["listaClientes"];
            Cliente cliente = listaClientes.Find(item => item.id == data[0]);
            //cliente.fechaNacimiento = DateTime.Today; //para verificar que funciona owo
            if (cliente.cumpleAniosHoy())
            {
                return Json(Enumerable.Range(0, 1).Select(i => new { title = "En hora buena", mensaje = "Es el cumpleaños de " + cliente.nombres + " y tiene acceso a un descuento", estado = "success" }), JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(Enumerable.Range(0, 1).Select(i => new { title = "Mala suerte", mensaje = "No es el cumpleaños de " + cliente.nombres, estado = "error" }), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SeleccionarPedido(int[] data)
        {
            Session["idPedido"] = data[0];


            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult ValidarCodigoPromocional(string codigo)
        {


            Dictionary<string, float> codigosValidos = new Dictionary<string, float>();
            codigosValidos.Add("ABC123XYZ", 55.5f);
            codigosValidos.Add("KLR345KLR", 45.5f);
            codigosValidos.Add("JRO567JRO", 22.5f);
            codigosValidos.Add("PTS000PTS", 34.5f);

            float montoDescuento = 0.0f;


            return
                codigosValidos.TryGetValue(codigo, out montoDescuento) ?
                Json(Enumerable.Range(0, 1).Select(i => new { title = "Felicidades!", mensaje = String.Format("El código ingresado hace acreedor al cliente de {0} nuevos soles.",montoDescuento), estado = "success" }), JsonRequestBehavior.AllowGet) :
                Json(Enumerable.Range(0, 1).Select(i => new { title = "Error!", mensaje = "El código ingresado no es válido.", estado = "error" }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult MostrarPedidosVenta(int[] data)
        {
            Venta venta = gestionarVentaServices.Instancia.ListarDetallesDeVenta(data[0]);

            return PartialView("_DetalleVenta", venta);
        }

    }
}
