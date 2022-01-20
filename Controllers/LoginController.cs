using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{   
    [AllowAnonymous] // Autorize dışı bırakmak için 
    public class LoginController : Controller
    {
        // GET: Login
        private Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult PartialRegister()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialRegister(Account p)
        {
            c.Accounts.Add(p);
            c.SaveChanges();

            return PartialView();
        }
        [HttpGet]
        public ActionResult AccountLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AccountLogin(Account p )
        {
            var info = c.Accounts.FirstOrDefault(x =>
                x.AccountMail == p.AccountMail && x.AccountPassword == p.AccountPassword);
            if (info!=null)
            {
                FormsAuthentication.SetAuthCookie(info.AccountMail,false);
                Session["AccountMail"] = info.AccountMail.ToString();
                return RedirectToAction("Index","AccountPanel");
            }
            else
            {
                return View();
            }
            
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var info = c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.UserPassword == p.UserPassword);
            if (info!=null)
            {
                FormsAuthentication.SetAuthCookie(info.UserName,false);
                Session["UserName"] = info.UserName.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}