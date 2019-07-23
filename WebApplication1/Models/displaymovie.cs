using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class displaymovie
    {
        public int movieid { get; set; }

        public string name { get; set; }

        public string image { get; set; }
        public float rating { get; set; }
        public string review { get; set; }
        public char status { get; set; }
        public string land { get; set; }
        public  string displayn { get; set; }
        public DateTime release { get; set; }
        public string duration { get; set; }
        public string trail { get; set; }
        public string genre { get; set; }
        public string age { get; set; }
        public string actors { get; set; }
    }
}