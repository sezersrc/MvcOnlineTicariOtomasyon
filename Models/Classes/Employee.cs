using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Display(Name = "Personel Adı")] // Laberfor ile kullandığında burası görünür .
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeeName { get; set; }
        [Display(Name = "Personel Soyadı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeeSurname { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeeEmail { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeePhone { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string EmployeePicture { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeeAbout { get; set; }

        public ICollection<Sales_Transaction> Sales_Transactions { get; set; }
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }

    }
}