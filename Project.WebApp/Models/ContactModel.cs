using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebApp.Models
{
    public class ContactModel
    {
        public int ContactID { get; set; }
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
    }
}