using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class moviedetails
    {
        public string displayn { get; set; }

        public HttpPostedFileBase image { get; set; }
        public string rating { get; set; }
        public string review { get; set; }
        public string status { get; set; }
        public HttpPostedFileBase land { get; set; }
        public DateTime release { get; set; }
        public string duration { get; set; }
        public string trail { get; set; }
        public string genre { get; set; }
        public string age { get; set; }
        public string actors { get; set; }




    }
}