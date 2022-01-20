using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }
        [StringLength(30)]
        public string Brand { get; set; }
        public short Stock { get; set; } 
        public decimal PurchasePrice { get; set; } // Alış Fiyat
        public decimal SalePrice { get; set; } // Satış Fiyat
        public bool  Status { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string ProductImage { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<Sales_Transaction> Sales_Transactions { get; set; }
    }
}