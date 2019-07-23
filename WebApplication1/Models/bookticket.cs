using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class bookticket
    {
        public int theatreid { get; set; }
        public int timeid { get; set; }
        public string name { get; set; }
        public DateTime showtime { get; set; }


    }
}