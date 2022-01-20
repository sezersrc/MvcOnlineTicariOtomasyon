using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class ToDolist
    {
        [Key]
        public int TodoID { get; set; }
        
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string TodoTitle { get; set; }
        
        [Column(TypeName = "bit")]
        
        public bool Status { get; set; }
        
    }
}