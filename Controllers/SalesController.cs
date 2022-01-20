using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        private Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Sales_Transactions.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewSale()
        {
            // Ürün Tablosu 
            List<SelectListItem> value1 = (from x in c.Products.ToList()
                select new SelectListItem
                {
                    Text = x.ProductName,
                    Value = x.ProductID.ToString()
                }).ToList();

            ViewBag.pro1 = value1;

            // Cariler Tablosu 
            List<SelectListItem> value2 = (from x in c.Accounts.ToList()
                select new SelectListItem
                {
                    Text = x.AccountName + " " + x.AccountSurname,
                    Value = x.AccountID.ToString()
                }).ToList();

            ViewBag.acc2 = value2;

            // Personel Tablosu 
            List<SelectListItem> value3 = (from x in c.Employees.ToList()
                select new SelectListItem
                {
                    Text = x.EmployeeName + " " + x.EmployeeSurname,
                    Value = x.EmployeeID.ToString()
                }).ToList();

            ViewBag.emp3 = value3;

            return View();

        }
        [HttpPost]
        public ActionResult NewSale(Sales_Transaction s)
        {
            s.Date =DateTime.Parse(DateTime.Now.ToShortDateString());
            c.Sales_Transactions.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
            
        }

        public ActionResult GetSales(int id)
        {
            var value = c.Sales_Transactions.Find(id);
                // Ürün Tablosu
            List<SelectListItem> value1 = (from x in c.Products.ToList()
                select new SelectListItem
                {
                    Text = x.ProductName,
                    Value = x.ProductID.ToString()
                }).ToList();

            ViewBag.pro1 = value1;

            // Cariler Tablosu 
            List<SelectListItem> value2 = (from x in c.Accounts.ToList()
                select new SelectListItem
                {
                    Text = x.AccountName + " " + x.AccountSurname,
                    Value = x.AccountID.ToString()
                }).ToList();

            ViewBag.acc2 = value2;

            // Personel Tablosu 
            List<SelectListItem> value3 = (from x in c.Employees.ToList()
                select new SelectListItem
                {
                    Text = x.EmployeeName + " " + x.EmployeeSurname,
                    Value = x.EmployeeID.ToString()
                }).ToList();

            ViewBag.emp3 = value3;
            

            return View("GetSales", value);
        }

        public ActionResult UpdateSales(Sales_Transaction p)
        {
            var value = c.Sales_Transactions.Find(p.TransactionID);
            value.AccountID = p.AccountID;
            value.Piece = p.Piece;
            value.Price = p.Price;
            value.EmployeeID = p.EmployeeID;
            value.Date = p.Date;
            value.TotalPrice = p.TotalPrice;
            value.ProductID = p.ProductID;
            c.SaveChanges();
            return RedirectToAction("Index");


        }

        public ActionResult DetailSales(int id)
        {
            var values = c.Sales_Transactions.Where(x => x.TransactionID == id).ToList();
            return View(values);
        }

    }
}