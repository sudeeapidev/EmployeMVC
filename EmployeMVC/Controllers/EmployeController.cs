using EmployeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeMVC.Controllers
{
    public class EmployeController : Controller
    {
        // GET: Employe
        EmployeContext ec = new EmployeContext();
        public ActionResult Index()
        {
           
            List<Employe> li = ec.getEmploye();
            return View(li);
        }
        [HttpGet]
        public ActionResult Index1()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Index1(Employe e)
        {
            //ec.InsertEmploye(e);
            ec.InsertEmployeConnectionless(e);
            return RedirectToAction("Index");
        }

        public ActionResult Index2(int id) 
        
        {
            Employe e = new Employe();

            e =ec.getEmployeById(id);
           // ViewData["id"] = e.Empid;
            return View(e);
        }
       
        
        public ActionResult Index3()

        {
            return View();
        }
        [HttpGet]
        public ActionResult Index3(int id)

        {
            Employe e = new Employe();

            e = ec.getEmployeById(id);

            return View(e);
        }
        [HttpPost]
        public ActionResult Index3(Employe e)

        {
            ec.UpdateEmployeeConnectionless(e);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Index4(int id)

        {
            Employe e = new Employe();

            e = ec.getEmployeById(id);

            return View(e);
        }
        [HttpPost]
        public ActionResult Index4(String id)

        {
            int id1 = Convert.ToInt32(id);
            //ec.DeleteEmployeeConnectionless(e);
            ec.DeleteEmployee(id1);
            return RedirectToAction("Index");
        }
    }
}