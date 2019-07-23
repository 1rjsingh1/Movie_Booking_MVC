using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class paymentController : Controller
    {
        // GET: payment
        [HttpGet]
        public ActionResult pay()
        {
            ViewBag.image = Session["image"];
            ViewBag.select = Session["select"];
            return View();
        }
    }
}