using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class showmovieController : Controller
    {
        // GET: showmovie
        public ActionResult show()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            SqlDataReader dr;
            if (Session["userid"] == null)
            {
                return RedirectToAction("login1", "account1");
            }
            else
            {

                con.ConnectionString = "Data Source=LAPTOP-3OSSUTQ9;Initial Catalog=AppDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";

                con.Open();
                com.Connection = con;
                com.CommandText = "Select * from moviedetails where movieid=" + @Session["movieid"];
                dr = com.ExecuteReader();
                displaymovie obj = new displaymovie();
                while (dr.Read())
                {

                    obj.movieid = Int32.Parse(dr["movieid"].ToString());
                    obj.name = dr["name"].ToString();
                    obj.image = dr["image"].ToString();
                    obj.rating = float.Parse(dr["rating"].ToString());
                    obj.review = dr["review"].ToString();
                    //obj.status = char.Parse(dr["status"].ToString());
                    obj.land = dr["land"].ToString();
                    obj.displayn = dr["displayn"].ToString();
                    obj.trail = dr["trail"].ToString();
                    obj.duration = dr["duration"].ToString();
                    obj.release = DateTime.Parse(dr["release"].ToString());
                    obj.release = obj.release.Date;
                    obj.age = dr["age"].ToString();
                    obj.actors = dr["actors"].ToString();


                }
                con.Close();
                con.Open();
                com.Connection = con;

                ViewBag.data = obj;
                List<bookticket> movie = new List<bookticket>();
                Session["image"] = obj.image;
                Session["moviename"] = obj.displayn;

                com.CommandText = "Select theatre.name as name,theatre.theatreid,show.timeid,showtime from showtime,theatre,show where show.movieid=" + @Session["movieid"] + " and theatre.theatreid=show.theatreid and showtime.timeid=show.timeid order by show.timeid";
                dr = com.ExecuteReader();
                
                while (dr.Read())
                {
                    bookticket obj1 = new bookticket();
                    obj1.name = dr["name"].ToString();
                    obj1.timeid = Int32.Parse(dr["timeid"].ToString());
                    obj1.theatreid = Int32.Parse(dr["theatreid"].ToString());
                    obj1.showtime = DateTime.Parse(dr["showtime"].ToString());
                    movie.Add(obj1);
                }

                con.Close();
                ViewBag.book = movie;
                ViewBag.t1 = DateTime.Now;
                ViewBag.username = Session["userid"];
                return View();
            }
        }

           
        }
    }
