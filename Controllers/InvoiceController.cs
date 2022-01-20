using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice

        private Context c = new Context();

        public ActionResult Index()
        {
            var list = c.Invoicess.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult AddInvoice()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddInvoice(Invoices f)
        {
            c.Invoicess.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetInvoice(int id)
        {
            var invoice = c.Invoicess.Find(id);
            return View("GetInvoice", invoice);
        }

        public ActionResult UpdateInvoice(Invoices f)
        {
            var invo = c.Invoicess.Find(f.InvoiceID);
            invo.InvoiceSeriNo = f.InvoiceSeriNo;
            invo.InvoiceOrderNumber = f.InvoiceOrderNumber;
            invo.Saat = f.Saat;
            invo.InvoiceDate = f.InvoiceDate;
            invo.VergiDairesi = f.VergiDairesi;
            invo.VergiNO = f.VergiNO;
            invo.TeslimAlan = f.TeslimAlan;
            invo.TeslimEden = f.TeslimEden;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DetailInvoice(int id)
        {
            var values = c.InvoicesDetails.Where(x => x.InvoiceID == id).ToList();
            
            return View(values);
        }

        [HttpGet]
        public ActionResult NewDetailInvoice()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewDetailInvoice(InvoicesDetail p)
        {
            c.InvoicesDetails.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Dynamic()
        {
            InvoicesDynamic cs = new InvoicesDynamic();
            cs.value1 = c.Invoicess.ToList();
            cs.value2 = c.InvoicesDetails.ToList();
            
            return View(cs);
        }

    }
}