using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        private Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Products.ToList();
            return View(values);
        }
    }
}