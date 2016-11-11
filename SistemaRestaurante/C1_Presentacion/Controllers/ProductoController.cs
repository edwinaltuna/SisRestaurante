using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using C2_Aplicacion;
using C3_Dominio.Entidades;

namespace C1_Presentacion.Controllers
{
    public class ProductoController : Controller
    {
        //
        // GET: /Producto/

        gestionarProductoServices obj = new gestionarProductoServices();
        Producto producto = new Producto();
        // GET: /Trabajador/
        public ActionResult Index()
        {
            List<Producto> listProducto = null;
            listProducto = obj.ListarProductos().ToList();
            return View(listProducto);
        }

        public ActionResult Registrar()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Registrar(FormCollection form)
        {
            TipoProducto tipo = new TipoProducto();
            producto.precio = float.Parse(form["precio"].ToString());
            producto.descripcion = form["descripcion"];
            producto.fecha = DateTime.Parse(form["fecha"].ToString());
            producto.imagen = form["imagen"];
            producto.estado = form["estado"].Contains("true");
            tipo.id = int.Parse(form["tipoProducto.id"].ToString());
            producto.tipoProducto = tipo;
            obj.RegistrarProducto(producto);
            return RedirectToAction("Index", "Producto");
        }

        public ActionResult Details(int id)
        {
            return View(obj.DetallesPlato(id));
        }

        public ActionResult Edit(int id)
        {
            return View(obj.DetallesPlato(id));
        }

        // POST: Estudiante/Edit/5
        [HttpPost]
        public ActionResult Edit(Producto collection)
        {
            try
            {
                // TODO: Add update logic here
                Producto objPlato = new Producto();
                obj.Update(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Estudiante/Delete/5
        public ActionResult Delete(int id)
        {
            return View(obj.DetallesPlato(id));
        }

        // POST: Estudiante/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                obj.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
//aa