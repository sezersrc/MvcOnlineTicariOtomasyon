using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Accounts.Where(x => x.Status == true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult AddAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAccount(Account p)
        {
            p.Status = true;
            c.Accounts.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAccount(int id)
        {
            var acc = c.Accounts.Find(id);
            acc.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetAccount(int id)
        {
            var acct = c.Accounts.Find(id);
            return View("GetAccount", acct);
        }

        public ActionResult UpdateAccount(Account p)
        {
            if (!ModelState.IsValid)
            {
                return View("GetAccount");

            }
            var act = c.Accounts.Find(p.AccountID);
            act.AccountName = p.AccountName;
            act.AccountSurname = p.AccountSurname;
            act.AccountCity = p.AccountCity;
            act.AccountDistrict = p.AccountDistrict;
            act.AccountAdress = p.AccountAdress;
            act.APostCode = p.APostCode;
            act.AccountMail = p.AccountMail;
            
            

            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AccountSale(int id)
        {
         var degerler = c.Sales_Transactions.Where(x => x.AccountID == id).ToList();
         var ac = c.Accounts.Where(x => x.AccountID == id).Select(y => y.AccountName + " " + y.AccountSurname)
             .FirstOrDefault();
         @ViewBag.ac = ac;
         return View(degerler);
        }
    }
}