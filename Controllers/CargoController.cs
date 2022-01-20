using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CargoController : Controller
    {
        // GET: Cargo
        private Context c = new Context();
        public ActionResult Index(string p)
        {
            var k = from x in c.CargoDetails select x;
            if (!string.IsNullOrEmpty(p))
            {
                k = k.Where(y => y.TrackingNumber.Contains(p));
            }

           // var cargo = c.CargoDetails.ToList();
            return View(k.ToList());
        }
        [HttpGet]
        public ActionResult NewCargo()
        {
            // Personele Liste'den seç . //Alıcıyı Listeden Seç 
            Random rnd = new Random();
            string[] characters = {"A", "B", "C", "D","E","F","G","H","K"};
            int k1, k2, k3;
            k1 = rnd.Next(0, 4);
            k2 = rnd.Next(0, 4);
            k3 = rnd.Next(0, 4);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);//10 =>3 1 2 1 2 1 
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string code = s1.ToString() + characters[k1] + s2 + characters[k2] + s3 + characters[k3];
            ViewBag.trackingcode = code;
            return View();
        }
        [HttpPost]
        public ActionResult NewCargo(CargoDetail d)
        {
            c.CargoDetails.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CargoTracking(string id)
        {
            var values = c.CargoTrackings.Where(x => x.TrackingNumber == id).ToList();
            
            return View(values);
        }
    }
}