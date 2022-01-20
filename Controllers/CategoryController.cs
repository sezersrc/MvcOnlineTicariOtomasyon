using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        private Context c = new Context();
        public ActionResult Index(int page=1)
        {
            var category = c.Categorys.ToList().ToPagedList(page,10);
            return View(category);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory( Category k)
        {
            k.Status = true;
            c.Categorys.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var ctg = c.Categorys.Find(id);
            c.Categorys.Remove(ctg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCategory(int id)
        {
            var category = c.Categorys.Find(id);
            return View("GetCategory", category);
        }

        public ActionResult UpdateCategory(Category ca)
        {
            var categ = c.Categorys.Find(ca.CategoryID);
            categ.CategoryName = ca.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");


        }

        public ActionResult Test()
        {
            CascadeClass cs = new CascadeClass();
            cs.Categories = new SelectList(c.Categorys, "CategoryID", "CategoryName");
            cs.Products = new SelectList(c.Products, "ProductID", "ProductName");
            return View(cs);

        }

        public JsonResult ProductGet(int p)
        {
            var productlist = (from x in c.Products
                join y in c.Categorys on x.Category.CategoryID equals y.CategoryID
                where x.Category.CategoryID == p
                select new
                {
                    Text = x.ProductName,
                    Value = x.ProductID.ToString()
                }).ToList();

            return Json(productlist, JsonRequestBehavior.AllowGet);
        }

    }
}