using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.ContactFormViewModels
{
    public class ContactFormViewModel
    {
        public String customerName { get; set; }
        public String emailCustomer { get; set; }
        public String feedback { get; set; }

    }
}
