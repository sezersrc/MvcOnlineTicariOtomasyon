using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Sales_Transaction
    {
        [Key] 
        public int TransactionID  { get; set; }
        public DateTime Date { get; set; }
        public int Piece { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

        public int ProductID { get; set; }
        public int AccountID { get; set; }
        public int EmployeeID { get; set; }
        public virtual Product Product { get; set; }
        public virtual Account Account { get; set; }
        public virtual Employee Employee { get; set; }
        


    }
}