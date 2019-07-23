using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            User usermodel = new Models.User();
            return View("AddOrEdit1");
        }
        [HttpPost]
        public ActionResult AddOrEdit(User userModel)
        {
            using( DbModels dbModel=new DbModels())
            {
                if(dbModel.Users.Any( x=> x.Username == userModel.Username))
                {
                    ViewBag.DuplicateMessage = "UserName Already Exists.";
                    return View("AddOrEdit1", userModel);
                }
                dbModel.Users.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful.";
            Session["newreg"] = 1;
            return RedirectToAction("login1","Account1");
                    
                    
                    
                    }   
    }
}