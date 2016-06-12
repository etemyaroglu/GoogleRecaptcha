using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.WebApp.Models;

namespace Project.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public PartialViewResult ContactForm1()
        {
            return PartialView();
        }
        public PartialViewResult ContactForm2()
        {
            return PartialView();
        }

        #region HttpPost Methods
        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            #region CheckGoogleRecaptcha
            #endregion

            if (!ModelState.IsValid)
            {
                //return error
            }
            //return success
            return View();
        }
        #endregion



    }
}