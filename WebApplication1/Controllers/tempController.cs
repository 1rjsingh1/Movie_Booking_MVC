using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class tempController : Controller
    {
        // GET: temp
        public ActionResult fun(int obj, int obj2, string obj3, string obj4)
        {
            Session["showtime"] = obj4;
            Session["theatrename"] = obj3;
            Session["time"] = obj;
            Session["theatre"] = obj2;
            return RedirectToAction("check","seats");
        }
    }
}