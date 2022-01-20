using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class AccountPanelController : Controller
    {
        private Context c = new Context();
        // GET: AccountPanel
        
        public ActionResult Index()
        {
            var mail = (string) Session["AccountMail"]; // Mail adresini seasion atıyoruz . 
            var values = c.Messages.Where(x => x.Recipient == mail).ToList();
            ViewBag.m = mail;
            var mailid = c.Accounts.Where(x => x.AccountMail == mail.ToString()).Select(y => y.AccountID).FirstOrDefault();
            ViewBag.maid = mailid;
            var totalsale = c.Sales_Transactions.Where(x => x.AccountID == mailid).Count();
            ViewBag.totalsale = totalsale;
            var totalprice = c.Sales_Transactions.Where(x => x.AccountID == mailid).Sum(y => y.TotalPrice);
            ViewBag.totalprice = totalprice;
            var totalproduct = c.Sales_Transactions.Where(x => x.AccountID == mailid).Sum(y=>y.Piece);
            ViewBag.totalproduct = totalproduct;
            var namesurname = c.Accounts.Where(x => x.AccountMail == mail)
                .Select(y => y.AccountName + " " + y.AccountSurname).FirstOrDefault();
            ViewBag.namesurname = namesurname;

            return View(values);
        }

        public ActionResult MyOrders()
        {
            var mail = (string)Session["AccountMail"];
            // id isminde değişken oluşturduk . seasion'Daki mail ile eşleşen Account ID değerini bu id ile ilişkilendirdik . 
            var id = c.Accounts.Where(x => x.AccountMail == mail.ToString()).Select(y => y.AccountID).FirstOrDefault();
            var values = c.Sales_Transactions.Where(x => x.AccountID == id).ToList();

            return View(values);
        }
        //public ActionResult Support()
        //{
        //    return View();
        //}
        public ActionResult MessageInbox()
        {
            var mail = (string)Session["AccountMail"];
            var messages = c.Messages.Where(x=>x.Recipient==mail).OrderByDescending(x=>x.MessageID).ToList();
            var recivencount = c.Messages.Count(x => x.Recipient == mail).ToString();
            ViewBag.inbox = recivencount;
            var sendingcount = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.sendbox = sendingcount;
            return View(messages);
        }
        public ActionResult MessageSendbox()
        {
            var mail = (string)Session["AccountMail"];
            var messages = c.Messages.Where(x => x.Sender == mail).OrderByDescending(x => x.MessageID).ToList();
            var sendingcount = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.sendbox = sendingcount;
            var recivencount = c.Messages.Count(x => x.Recipient == mail).ToString();
            ViewBag.inbox = recivencount;
            return View(messages);
        }
        public ActionResult MessageDetail(int id)
        {
            var mail = (string)Session["AccountMail"];
            var messages = c.Messages.Where(x => x.MessageID == id).ToList();
            var sendingcount = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.sendbox = sendingcount;
            var recivencount = c.Messages.Count(x => x.Recipient == mail).ToString();
            ViewBag.inbox = recivencount;
            return View(messages);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            var mail = (string)Session["AccountMail"];
            //var messages = c.Messages.Where(x => x.MessageID == id).ToList();
            var sendingcount = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.sendbox = sendingcount;
            var recivencount = c.Messages.Count(x => x.Recipient == mail).ToString();
            ViewBag.inbox = recivencount;
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message m)
        {
            var mail = (string)Session["AccountMail"];
            m.MessageDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Sender=mail;
            c.Messages.Add(m);
            c.SaveChanges();
            return View();
        }

        public ActionResult CargoTracking(string p)
        {
            var k = from x in c.CargoDetails select x;
           
                k = k.Where(y => y.TrackingNumber.Contains(p));
            
            // var cargo = c.CargoDetails.ToList();
            return View(k.ToList());
        }
        public ActionResult AccCargoTracking(string id)
        {
            var values = c.CargoTrackings.Where(x => x.TrackingNumber == id).ToList();

            return View(values);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public PartialViewResult GetAccount()
        {
            var mail = (string)Session["AccountMail"];
            var id = c.Accounts.Where(x => x.AccountMail == mail).Select(y => y.AccountID).FirstOrDefault();
            var accountfind = c.Accounts.Find(id);
            return PartialView("GetAccount", accountfind);
        }

        public PartialViewResult Timeline()
        {
            var data = c.Messages.Where(x => x.Sender == "admin").ToList();
            return PartialView(data);
        }
        public ActionResult UpdateAccount(Account ac)
        {
            var account = c.Accounts.Find(ac.AccountID);
            account.AccountName = ac.AccountName;
            account.AccountSurname = ac.AccountSurname;
            account.AccountPassword = ac.AccountPassword;
            c.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}