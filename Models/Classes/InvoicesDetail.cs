using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class InvoicesDetail
    {
        [Key]
        public int InvoiceDetailID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string InvoicesDetails { get; set; }  
        public int Piece { get; set; }   
        public decimal Price { get; set; }   
        public decimal TotalPrice { get; set; }
        public int InvoiceID { get; set; }
        public virtual Invoices Invoices { get; set; }  

    }
}