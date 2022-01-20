using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
         Context c = new Context();
        public ActionResult Index()
        {
            // Arama Gelecek => KArgo TAkip index'Ten AL
            var products = c.Products.Where(x=>x.Status==true).ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {    // Categorileri listeledik . Text Görünen değer Value  Tablodan çekilecek ID 
            List<SelectListItem> deger1 = (from x in c.Categorys.ToList()
                select new SelectListItem()
                {
                    Text = x.CategoryName,
                    Value = x.CategoryID.ToString()
                }).ToList();
            ViewBag.dgr1 = deger1;

           
            return View();

        }
        [HttpPost]
        public ActionResult AddProduct(Product P)
        {
            P.Status = true;
            c.Products.Add(P);
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DeleteProduct(int id)
        {
            var dege = c.Products.Find(id);
            dege.Status = false; //Ürün silme işlemi pasif yaparak olacak .
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetProduct(int id)
        {
            // Categorileri listeledik . Text Görünen değer Value  Tablodan çekilecek ID 
            List<SelectListItem> deger1 = (from x in c.Categorys.ToList()
                select new SelectListItem()
                {
                    Text = x.CategoryName,
                    Value = x.CategoryID.ToString()
                }).ToList();
            ViewBag.dgr1 = deger1;
            ///
            var prodeger = c.Products.Find(id);
            return View("GetProduct", prodeger);
        }

        public ActionResult UpdateProduct(Product p)
        {
            var prod = c.Products.Find(p.ProductID);
            prod.PurchasePrice = p.PurchasePrice;
            prod.SalePrice = p.SalePrice;
            prod.Status = p.Status;
            prod.CategoryID = p.CategoryID;
            prod.Brand = p.Brand;
            prod.Stock = p.Stock;
            prod.ProductName = p.ProductName;
            prod.ProductImage = p.ProductImage;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult ListProduct()
        {
            var values = c.Products.ToList();
            return View(values);
        }
       [HttpGet]
        public ActionResult SaleProduct(int id)
        {
            // Personel Tablosu 
            List<SelectListItem> value3 = (from x in c.Employees.ToList()
                select new SelectListItem
                {
                    Text = x.EmployeeName + " " + x.EmployeeSurname,
                    Value = x.EmployeeID.ToString()
                }).ToList();

            ViewBag.emp3 = value3;
            var proid = c.Products.Find(id);
            ViewBag.proid = proid.ProductID;
            ViewBag.name = proid.ProductName;
            ViewBag.brand = proid.Brand;
            ViewBag.price = proid.SalePrice;

            return View();
        }
        [HttpPost]
        public ActionResult SaleProduct(Sales_Transaction p)
        {
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.Sales_Transactions.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index","Sales");
        }
    }
}