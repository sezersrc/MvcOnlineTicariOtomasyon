using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GraphicController : Controller
    {
        // GET: Graphic
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grapcihdraw = new Chart(600, 600);
            grapcihdraw.AddTitle("Kategori - Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler",
                xValue: new[] {"Beyaz Eşya", "Bilgisayar", "Telefon"}, yValues: new[] {95, 35, 70}).Write();
            return File(grapcihdraw.ToWebImage().GetBytes(),"image/jpg");
        }
        Context c = new Context();
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var results = c.Products.ToList();
            results.ToList().ForEach(x=>xvalue.Add(x.ProductName));
            results.ToList().ForEach(x=>yvalue.Add(x.Stock));
            var graphic = new Chart(width: 800, height: 800)
                .AddTitle("Stoklar")
                .AddSeries(chartType: "Doughnut", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(graphic.ToWebImage().GetBytes(), "image/jpg");
        }

        public ActionResult Index4()
        {
            return View();
        }
        // Google Chart'lar ile yapılan demo sayfalar
        public ActionResult VisualizeProductResult()
        {
            
            return Json(Productlist(),JsonRequestBehavior.AllowGet);
        }

        public List<GoogleChart> Productlist()
        {
            List<GoogleChart> cls = new List<GoogleChart>();
            cls.Add(new GoogleChart()
            {
                productname = "Bilgisayar",
                stock = 120
            });
            cls.Add(new GoogleChart()
            {
                productname = "Beyaz Eşya",
                stock = 150
            });
            cls.Add(new GoogleChart()
            {
                productname = "Telefon",
                stock = 250
            });
            cls.Add(new GoogleChart()
            {
                productname = "Mobilya",
                stock = 70
            });
            cls.Add(new GoogleChart()
            {
                productname = "Küçük Ev Aletleri",
                stock = 90
            });
            return cls;
        }
        
        public ActionResult Index5()
        {

            return View();
        }
        public ActionResult VisualizeProductResult2()
        {

            return Json(Productlist2(), JsonRequestBehavior.AllowGet);
        }

        public List<GoogleChart2> Productlist2()
        {
            List<GoogleChart2> cls = new List<GoogleChart2>();

            using (var context = new Context())
            {
                cls = c.Products.Select(x => new GoogleChart2
                {
                    pro = x.ProductName,
                    stk = x.Stock
                }).ToList();
            }

            return cls;

        }

        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }
    }

}