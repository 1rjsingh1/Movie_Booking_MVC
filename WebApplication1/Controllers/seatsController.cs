using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using WebApplication1.Models;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    
    public class seatsController : Controller
    {
        // GET: seats
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        [HttpGet]
        public ActionResult check()
        {
            if (Session["userid"] == null)
            {
                return RedirectToAction("login1", "account1");
            }
            else
            {
                
                con.ConnectionString = "Data Source=LAPTOP-3OSSUTQ9;Initial Catalog=AppDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
                seats s = new seats();
                con.Open();
                com.Connection = con;
                com.CommandText = "Select pseats,eseats from theatre where theatreid=" + Session["theatre"];
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    s.exec = Int32.Parse(dr["eseats"].ToString());
                    s.reg = Int32.Parse(dr["pseats"].ToString());
                }
                con.Close();
                con.Open();
                com.Connection = con;
                com.CommandText = "Select seat from bookings where theatreid=" + Session["theatre"] + " and timeid="+ Session["time"] + " and movieid="+Session["movieid"];
                dr = com.ExecuteReader();
                List<int> arr = new List<int>();
                while (dr.Read())
                {
                    arr.Add(Int32.Parse(dr["seat"].ToString()));
                }
                ViewBag.booked = arr;
                ViewBag.exec = s.exec;
                ViewBag.reg = s.reg;
                ViewBag.time = Session["time"];
                ViewBag.theatre = Session["theatre"];

                return View();
            }
        }
        [HttpGet]

        public ActionResult book(string sel,int total)
        {
            Session["total"] = total;
            Session["select"] = sel;
            string[] arr = sel.Split(',');
            List<int> seats = new List<int>();
            
            con.ConnectionString = "Data Source=LAPTOP-3OSSUTQ9;Initial Catalog=AppDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            Session["bookid"] = finalString;
            foreach (string n in arr)
            {
                Console.WriteLine(n);
                if (n != "")
                {
                    con.Open();
                    com.Connection = con;
                    com.CommandText = "Insert into bookings values(" + Session["id"] + "," + Session["movieid"] + "," + Session["time"] + "," + Session["theatre"] + "," + n + ",'"+finalString+"')";

                    dr = com.ExecuteReader();
                    con.Close();
                }
            }
            return RedirectToAction("pay","payment");
        }
    }
}