using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Outgoing
    {
        [Key] 
        public int OutgoingID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string OutgoingDetails { get; set; }
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }

    }
}