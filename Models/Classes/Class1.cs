using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Class1
    {
        // iki tabloyu bu tabloda Kolleksiyon olarak tutuyoruz . 
        public IEnumerable<Product> Value1 { get; set; }
        public IEnumerable<ProDetail> Value2 { get; set; }

    }
}