using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class TodoListController : Controller
    {
        private Context c = new Context();
        // GET: TodoList
        public ActionResult Index()
        {
            var value1 = c.Accounts.Count().ToString();
            ViewBag.acc = value1;
            var value2 = c.Products.Count().ToString();
            ViewBag.prod = value2;
            var value3 = c.Categorys.Count().ToString();
            ViewBag.cat = value3;
            var value4 = (from x in c.Accounts select x.AccountCity).Distinct().Count().ToString();
            ViewBag.cit = value4;

            var todo = c.ToDolists.ToList();

            return View(todo);
        }
    }
}