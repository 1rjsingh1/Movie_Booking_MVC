using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class Account1Controller : Controller
    {

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Account1
        [HttpGet]
        public ActionResult Login1()
        {
            if(Session["newreg"]!=null)
            {
                ViewData["checkCondition"] = true;
                Session["newreg"] = null;
            }
            return View();
        }
        
        
        [HttpPost]
        public ActionResult Verify(Account1 acc)
        {
            con.ConnectionString = "Data Source=LAPTOP-3OSSUTQ9;Initial Catalog=AppDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";

            con.Open();
            com.Connection = con;
            com.CommandText = "select * from [User] where Username ='"+acc.Username+"' and Password ='"+acc.Password+"'";
            dr = com.ExecuteReader();
            if(dr.Read())
            {
                
                Session["id"] =Int32.Parse(dr["UserID"].ToString());
                Session["userid"] = acc.Username;
                con.Close();
                if(acc.Username.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    return RedirectToAction("admin", "admin");
                }
                else
                return RedirectToAction("Index","Home");
            }
            else
            {
                con.Close();
                ViewBag.DuplicateMessage = "Invalid Credentials";
                return View("Login1", acc);
                
            }
            
            
        }
    }
}