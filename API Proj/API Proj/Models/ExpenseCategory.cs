﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API_Proj.Models
{
    public class ExpenseCategory
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public float Total { get; set; }
        public int ExpenseID { get; set; }
        public virtual Expense Expense { get; set; }
    }
}