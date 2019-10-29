using Proyecto1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto1.Controllers
{
    public class VentaController : Controller
    {
        private Proyecto1Entities ce = new Proyecto1Entities();

        public ActionResult Index()
        {
            return View(ce.Venta.ToList().OrderBy(x => x.DiaVenta));
        }

        public ActionResult Detalles(int Id)
        {
            return View(ce.Venta.Find(Id));
        }

    }
}