using Proyecto1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto1.Controllers
{
    public class CarritoController : Controller
    {
        // GET: Carrito
        public Proyecto1Entities ce = new Proyecto1Entities();
        public ActionResult AgregaCarrito(int id)
        {
            if(Session["carrito"] == null)
            {
                List<CarritoItem> compras = new List<CarritoItem>();
                compras.Add(new CarritoItem(ce.Products.Find(id), 1));
                Session["carrito"] = compras;
            }
            else
            {
                List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
                int IndexExistente = GetIndex(id);
                if (IndexExistente == -1)
                {
                    compras.Add(new CarritoItem(ce.Products.Find(id), 1));
                }
                else
                {
                    compras[IndexExistente].Cantidad++;
                }
                Session["carrito"] = compras;
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            compras.RemoveAt(GetIndex(id));
            return View("AgregaCarrito");
        }

        public ActionResult FinalizaCompra()
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            if (compras != null && compras.Count > 0)
            {
                Venta nuevaVenta = new Venta();
                nuevaVenta.DiaVenta = DateTime.Now;
                nuevaVenta.Subtotal = compras.Sum(x => x.Producto.Price * x.Cantidad);
                nuevaVenta.Iva = nuevaVenta.Subtotal * 0.16;
                nuevaVenta.Total = nuevaVenta.Subtotal + nuevaVenta.Iva;

                nuevaVenta.ListaVenta = (from producto in compras
                                         select new ListaVenta
                                         {
                                             Product_ID = producto.Producto.Product_ID,
                                             Cantidad = producto.Cantidad,
                                             Total = producto.Cantidad * producto.Producto.Price
                                         }).ToList();
                ce.Venta.Add(nuevaVenta);
                ce.SaveChanges();
                Session["carrito"] = new List<CarritoItem>();
            }
            return View();
        }


        private int GetIndex(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            for(int i=0; i < compras.Count; i++)
            {
                if (compras[i].Producto.Product_ID == id)
                    return i;
            }
            return -1;
        }
    }
}