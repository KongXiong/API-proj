using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace API_Proj.Models
{
    public class Client
    {

        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }

        [EmailAddress]
        public string Email { get; set; }

    }
}