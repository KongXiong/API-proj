﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API_Proj.Models
{
    public class Expense
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Payee { get; set; }
        public double Total { get; set; }
        public DateTime Date { get; set; }
        public string RegisteredUserID { get; set; }
        public virtual RegisteredUser RegisteredUser { get; set; }
        public int ExpenseCategoryID { get; set; }
        public virtual RevenueCategory ExpenseCategory { get; set; }



    }
}