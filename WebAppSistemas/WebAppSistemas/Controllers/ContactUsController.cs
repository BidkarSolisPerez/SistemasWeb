using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppSistemas.Controllers
{
    public class ContactUsController : Controller
    {
        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public void FormContact(Models.FormContactUsModel formData)
        {

        }
    }
}