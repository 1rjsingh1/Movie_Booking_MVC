using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        public ActionResult Index()
        {
            if (Session["userid"] == null)
            {
                return RedirectToAction("login1", "account1");
            }
            else if(Session["userid"].ToString() == "admin")
            {
                return RedirectToAction("admin", "admin");
            }
            else
            {
                List<displaymovie> movie = new List<displaymovie>();
                con.ConnectionString = "Data Source=LAPTOP-3OSSUTQ9;Initial Catalog=AppDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";

                con.Open();
                com.Connection = con;
                com.CommandText = "Select * from moviedetails";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    displaymovie obj = new displaymovie();
                    obj.movieid = Int32.Parse(dr["movieid"].ToString());
                    obj.name = dr["name"].ToString();
                    obj.image = dr["image"].ToString();
                    obj.rating = float.Parse(dr["rating"].ToString());
                    obj.review = dr["review"].ToString();
                    //obj.status = char.Parse(dr["status"].ToString());
                    obj.land = dr["land"].ToString();
                    obj.displayn = dr["displayn"].ToString();
                    obj.actors = dr["actors"].ToString();
                    obj.release = DateTime.Parse( dr["release"].ToString());
                   
                    movie.Add(obj);
                }
                con.Close();

                    ViewBag.data = movie;




                }

                ViewBag.username = Session["userid"];
                return View();
            }
        
            
        public  ActionResult change(int obj)
        {
            Session["movieid"] = obj;
            return RedirectToAction("show", "showmovie");


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
        public ActionResult logout()
        {
            Session.Abandon();
            return RedirectToAction("Login1", "Account1");
        }
    }
}