using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class paytmController : Controller
    {
        // GET: paytm
        public ActionResult pay()
        {
            return View();
        }
        [HttpPost]
        public ActionResult send()
        {
            return RedirectToAction("print", "ticket");
        }
    }
}