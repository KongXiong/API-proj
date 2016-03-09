using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Proj.Models
{
    public class Expense
    {
        public int ID { get; set; }
        public String Payee { get; set; }
        public double Total { get; set; }
        public int CategoryID { get; set; }
        public DateTime Date { get; set; }


    }
}