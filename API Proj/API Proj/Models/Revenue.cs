using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Proj.Models
{
    public class Revenue
    {
        public int ID { get; set; }
        public int PayerID { get; set; }
        public double Total { get; set; }
        public int CategoryID { get; set; }
        public DateTime Date { get; set; }
    }
}