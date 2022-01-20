using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class InvoicesDynamic
    {
        public IEnumerable<Invoices> value1 { get; set; }
        public IEnumerable<InvoicesDetail> value2 { get; set; }
    }
}