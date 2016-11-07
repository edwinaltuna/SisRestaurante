using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C3_Dominio.Entidades;

namespace PruebasUnitarias
{
    [TestClass]
    public class VentasPruebaUnitaria
    {
        [TestMethod]
        public void calcularTotalTest()
        {
            Pedido pedido = new Pedido();
            List<DetallePedido> detalles = new List<DetallePedido>();
            popularListaDetalles(detalles);
            pedido.detallesPedido = detalles;

            double expected=150; 
            double actual = pedido.calcularTotal();
            Assert.AreEqual(expected,actual,"El total calculado es incorrecto.");
            
        }

        public DetallePedido generarDetallePlacebo(float precio, int cantidad)
        {
            DetallePedido detallePedido = new DetallePedido();
            Producto producto = new Producto();
            producto.precio = precio;
            detallePedido.producto = producto;
            detallePedido.cantidad = cantidad;
            return detallePedido;
        }

        public void popularListaDetalles(List<DetallePedido> detalles)
        {
            detalles.Add(generarDetallePlacebo(1, 10));
            detalles.Add(generarDetallePlacebo(2, 10));
            detalles.Add(generarDetallePlacebo(3, 10));
            detalles.Add(generarDetallePlacebo(4, 10));
            detalles.Add(generarDetallePlacebo(5, 10));
        }
    }
}
