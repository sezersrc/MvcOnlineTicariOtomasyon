using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        private Context c = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            //var values = c.Products.Where(x => x.ProductID == 2).ToList();
            cs.Value1 = c.Products.Where(x => x.ProductID == 2).ToList();
            cs.Value2 = c.ProDetails.Where(y => y.DetailID == 2).ToList();
            return View(cs);
        }
    }
}