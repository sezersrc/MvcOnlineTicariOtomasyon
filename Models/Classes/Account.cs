using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Account // Cariler
    {
        [Key]
        public int AccountID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage = "En Fazla 30 Karakter Yazabilirsiniz")]
        public string AccountName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string AcountCompany { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string AcountLogo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz")]
        public string AccountSurname { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string AccountDistrict { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string AccountCity { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(400)]
        public string AccountAdress { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(5)]
        public string APostCode { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string AccountMail { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string AccountPassword { get; set; }
        public bool Status { get; set; }

        public ICollection<Sales_Transaction> Sales_Transactions { get; set; }

    }
}