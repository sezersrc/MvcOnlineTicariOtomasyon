using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        private Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Employees.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            List<SelectListItem> deger1 = (from x in c.Departments.Where(x=>x.Status==true).ToList()
                select new SelectListItem()
                {
                    Text = x.DepartmentName,
                    Value = x.DepartmentID.ToString()
                }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee( Employee p)
        {   
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs (Server.MapPath(yol));
                p.EmployeePicture = "/Images/" + dosyaadi + uzanti;
            }
           
            c.Employees.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetEmployee(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departments.Where(x=>x.Status==true).ToList()
                select new SelectListItem()
                {
                    Text = x.DepartmentName,
                    Value = x.DepartmentID.ToString()
                }).ToList();
            ViewBag.dgr1 = deger1;
            var emp = c.Employees.Find(id);
            return View("GetEmployee",emp);
        }

        public ActionResult UpdateEmployee(Employee em)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                em.EmployeePicture = "/Images/" + dosyaadi + uzanti;
            }
            var empl = c.Employees.Find(em.EmployeeID);
            empl.EmployeeName = em.EmployeeName;
            empl.EmployeeSurname = em.EmployeeSurname;
            empl.EmployeePicture = em.EmployeePicture;
            empl.DepartmentID = em.DepartmentID;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult EmployeeList()
        {
            var query = c.Employees.ToList();
            return View(query);
        }
    }
}