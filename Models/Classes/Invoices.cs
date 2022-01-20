using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Invoices
    {
        [Key]
        public int InvoiceID { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string InvoiceSeriNo { get; set; }  // Fatura Seri NO:
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string InvoiceOrderNumber { get; set; }  // FAtura Sıra No 
        public DateTime InvoiceDate { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string VergiDairesi { get; set; }
        public string VergiNO { get; set; }
        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Saat { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimEden { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }

        public decimal InvoiceTotal { get; set; }

        public ICollection<InvoicesDetail> InvoicesDetails { get; set; }
    }
}