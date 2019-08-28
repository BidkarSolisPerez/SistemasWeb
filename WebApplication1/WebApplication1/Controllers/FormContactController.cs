using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.ContactFormViewModels;

namespace WebApplication1.Controllers
{
    public class FormContactController : Controller
    {
        // GET: FormContact
        public ActionResult Index()
        {
            var contactForm = from e in contactList
                             orderby e.customerName
                             select e;

            return View(contactForm);
        }

        // GET: FormContact/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: FormContact/Create
        public ActionResult Create()
        {
                return View();
            
        }

        // POST: FormContact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                ContactFormViewModel form = new ContactFormViewModel();
                form.customerName = collection["CustomerName"];
                form.emailCustomer = collection["EmailCustomer"];
                form.feedback = collection["Feedback"];
                contactList.Add(form);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FormContact/Edit/5
        public ActionResult Edit(string email)
        {
            List<ContactFormViewModel> empList = contactList;
            var customerEmail = empList.Single(m => m.emailCustomer == email);
            return View(customerEmail);
        }

        // POST: FormContact/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FormContact/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FormContact/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public static List<ContactFormViewModel> contactList = new List<ContactFormViewModel>{
      new ContactFormViewModel{
         customerName = "Jose",
         emailCustomer = "jose@email.com",
         feedback = "Feedback Jose"
      },
      new ContactFormViewModel{
         customerName = "Jose",
         emailCustomer = "jose@email.com",
         feedback = "Feedback Jose",
      },new ContactFormViewModel{
         customerName = "Jose",
         emailCustomer = "jose@email.com",
         feedback = "Feedback Jose"
      }

};
    }
}