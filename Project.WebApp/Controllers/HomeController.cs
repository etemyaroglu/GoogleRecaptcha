using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.WebApp.Models;
using Project.WebApp.Tools;

namespace Project.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MultiForm()
        {            
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
        [ValidateAntiForgeryToken]
        public ActionResult FormPost(ContactModel model)
        {
            #region GoogleControl
            var response = Request["g-recaptcha-response"];
            ReCaptchaModel googleresult = ReCaptcha.Check(response);
            if (!googleresult.Result)
            {
                return Json(new
                {
                    data =googleresult.Message,
                    success = false,
                }, JsonRequestBehavior.AllowGet);

            }
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