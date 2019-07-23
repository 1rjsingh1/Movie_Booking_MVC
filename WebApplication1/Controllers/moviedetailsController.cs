using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.SqlClient;
using System.IO;
using System.Text;
namespace WebApplication1.Controllers
{
    public class moviedetailsController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        // GET: moviedetails
        [HttpGet]
        public ActionResult insert()
        {
            return View("moviedetail");
        }
        [HttpPost]
        public ActionResult Insert1(Models.moviedetails movie)
        {
            con.ConnectionString = "Data Source=LAPTOP-3OSSUTQ9;Initial Catalog=AppDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";

            con.Open();
            com.Connection = con;
            if (movie.image != null)
            {
                HttpPostedFileBase postedFile = movie.image;
                string filename = postedFile.FileName;
                movie.image.SaveAs(Server.MapPath("~/Images/") + filename);
                string path = "images/" + filename;
                HttpPostedFileBase postedFile1 = movie.land;
                string filename1 = postedFile1.FileName;
                movie.land.SaveAs(Server.MapPath("~/Images/") + filename1);
                string path1 = "images/" + filename1;

                movie.release = movie.release.Date;
                string rel = movie.release.ToString("yyyy - MM - dd");

                if (movie.rating == null)
                    movie.rating ="0.0";
                    float rat = float.Parse(movie.rating);
                

                com.CommandText = "insert into moviedetails (name,image,rating,review,land,displayn,release,duration,trail,genre,age,actors) values('" + filename + "','" + path + "',"+rat+",'"+movie.review+"','"+path1+"','"+movie.displayn+ "','" + rel + "','" + movie.duration + "','" + movie.trail + "','" + movie.genre + "','" + movie.age + "','" + movie.actors + "')";



                Console.WriteLine(com.CommandText);
              com.ExecuteNonQuery();
                    con.Close();
                    ViewBag.DuplicateMessage = "Movie Added Success";

                    return View("moviedetail", movie);
                }
                else
                {
                    ViewBag.DuplicateMessage ="Failed";

                    return View("moviedetail", movie);
                }
            }
            
        }
    }
