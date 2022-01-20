using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        private Context c = new Context();
        public ActionResult Index()
        {   //Toplam Cari SAyısı
            var value1 = c.Accounts.Count().ToString();
            ViewBag.acc1 = value1;
            //Toplam Ürün Sayısı
            var value2 = c.Products.Count().ToString();
            ViewBag.pro2 = value2;
            //Personel Sayısı 
            var value3 = c.Employees.Count().ToString();
            ViewBag.emp3 = value3;
            //Toplam Katagori Sayısı
            var value4= c.Categorys.Count().ToString();
            ViewBag.cat4 = value4;
            //Toplam Stok 
            var value5 = c.Products.Sum(x=>x.Stock).ToString();
            ViewBag.sto5 = value5;
            // Toplam Marka Sayısı =>Ürünler içindeki Markayı Seç - Distinct =>Tekrarsız olarak Say 
            var value6 = (from x in c.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.br6 = value6;
            //Kritik Stok => Stoğu 20'nin altına düşenler .
            var value7 = c.Products.Count(x => x.Stock <= 20).ToString();
            ViewBag.sto7 = value7;
            //En Pahalı Fiyatlı ÜrünÜrünler içindeki Orderby ile Fiyatları Sırala ( A-Z )descending (Z-A'ya çevirdi) => First -- İlk sıradakini getir.  
            var value8 = (from x in c.Products orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.mpp8 = value8;
            // En Ucuz Ürün 
            var value9 = (from x in c.Products orderby x.SalePrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.minpp9 = value9;
            //Buzdolabı sayısı
            var value10 = c.Products.Count(x=>x.ProductName=="Buzdolabı").ToString();
            ViewBag.prod10 = value10;
            //Laptop Sayısı
            var value11 = c.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.prod11 = value11;
            //Max Marka 
            var value12 = c.Products.GroupBy(x => x.Brand).OrderByDescending(z => z.Count()).Select(y => y.Key)
               .FirstOrDefault();
            ViewBag.br12 = value12;
            // En Çok Satan => iç içe geçmiş iki sorgu 
            // iç sorgu SAtış Hareket tablosu içinde en fazla geçen ürün ID'ye getir =>.
            // Dş Sorgu  Bu ID'Yi Select ile Seç ve Ürün Adını Ekrana yaz. 
            var value13 = c.Products.Where(p => p.ProductID == (c.Sales_Transactions.GroupBy(x => x.ProductID)
               .OrderByDescending(z => z.Count())
               .Select(y => y.Key).FirstOrDefault())).Select(k => k.ProductName).FirstOrDefault();
            ViewBag.tsa13 = value13;
            //Kasadaki Toplam Tutar
            var value14 = c.Sales_Transactions.Sum(x => x.TotalPrice).ToString();
            ViewBag.st14 = value14;
            //Kasadaki Bugünkü  Satış  sayısı
            DateTime today = DateTime.Today;
            var value15 = c.Sales_Transactions.Count(x => x.Date== today).ToString();
            ViewBag.st15 = value15;
            // Bugünkü Kasa => Satış hareketlerinin içinde Şartlı Bugün Sum ile topla getir .
            var value16 = c.Sales_Transactions.Where(x => x.Date == today).Sum(y=>(decimal?)y.TotalPrice).ToString();
            ViewBag.st16 = value16;
            return View();
        }

        public ActionResult Tables()
        {   //Cariler (Accounts ) içindeki şehirlerin sayısını say count ce city değişkenine at . GroupClass içindeki 
            var query = from x in c.Accounts
                group x by x.AccountCity
                into g
                select new GroupClass()
                {
                    city = g.Key, count = g.Count()
                };
            return View(query);
        }

        public PartialViewResult PartialTable()
        {    //"109.Ders Partial ile Gruplandırma
            var query2 = from x in c.Employees
                group x by x.Department.DepartmentName
                into g
                select new GroupClass2 {departman = g.Key, count = g.Count()};
            return PartialView(query2.ToList());
        }

        public PartialViewResult ParTableAccounts()
        {
            var query3 = c.Accounts.ToList();
            return PartialView(query3);
        }
        public PartialViewResult ParTableProducts()
        {
            var query4 = c.Products.ToList();
            return PartialView(query4);
        }

        public PartialViewResult PartialBrand()
        {
            var query5 = from x in c.Products
                         group x by x.Brand
                into g
                         select new GroupClass3 { brand = g.Key, count = g.Count() };
            return PartialView(query5.ToList());

        }
    }
}