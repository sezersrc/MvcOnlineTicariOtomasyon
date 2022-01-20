using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class CargoTracking
    {
        [Key]
        public int CargoTrackingID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        public string TrackingNumber { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string CTDetail { get; set; }
        public DateTime Date { get; set; }
    }
}