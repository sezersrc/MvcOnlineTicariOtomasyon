using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class CargoDetail
    {
         [Key]
         public int CargoDetailID { get; set; }
         [Column(TypeName = "VarChar")]
         [StringLength(300)]
         public string CargDetail { get; set; }
         [Column(TypeName = "VarChar")]
         [StringLength(10)]
         public string TrackingNumber { get; set; } //1234123AB stili 
         [Column(TypeName = "VarChar")]
         [StringLength(30)]
         public string Employee { get; set; }
         [StringLength(25)]
         public string Recipient { get; set; }
         public DateTime CargoDate { get; set; }

    }
}