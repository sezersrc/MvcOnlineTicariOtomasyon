using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    
    public class DepartmentController : Controller
    {
        // GET: Department
        private Context c = new Context();
       
        public ActionResult Index()
        {
            var degerler = c.Departments.Where(x => x.Status == true).ToList();
            return View(degerler);
        }
        [Authorize(Roles = "A")]
        [HttpGet]
        public ActionResult AddDepartment()
        {

            return View();
        }
       
        [HttpPost]
        public ActionResult AddDepartment(Department d)
        {
            d.Status = true;
            c.Departments.Add(d);
            c.SaveChanges(); 
            return RedirectToAction("Index");
        }

        public ActionResult DeleteDepartment(int id)
        {
            var dep = c.Departments.Find(id);
            dep.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetDepartment(int id)
        {
            var dpt = c.Departments.Find(id);
            return View("GetDepartment", dpt);
        }

        public ActionResult UpdateDepartment(Department p)
        {
            var dept = c.Departments.Find(p.DepartmentID);
            dept.DepartmentName = p.DepartmentName;
            dept.Status = p.Status;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DetailDepartment(int id)
        {
            var degerler = c.Employees.Where(x => x.DepartmentID == id).ToList();
            var dpt = c.Departments.Where(x => x.DepartmentID == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.de = dpt;
            return View(degerler);
        }

        public ActionResult DepartmentPersonelSale(int id)
        {
            var degerler = c.Sales_Transactions.Where(x => x.EmployeeID == id).ToList();
            var pers = c.Employees.Where(x => x.EmployeeID == id).Select(y => y.EmployeeName + " " + y.EmployeeSurname).FirstOrDefault();
            ViewBag.pe = pers;
            return View(degerler);

        }
        
    }
}