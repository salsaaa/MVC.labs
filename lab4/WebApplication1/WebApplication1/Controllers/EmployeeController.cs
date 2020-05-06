using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        Users user = new Users();
        // GET: Employee
        [HttpGet]
        public ActionResult Index()
        {
            EmployeeViewModel vm = new EmployeeViewModel
            {
                Employees = user.Employees.ToList(),
                Employee = new Employee()
            };
            return View(vm);
        }
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("EmployeeForm");
        }
        [HttpPost]
        public ActionResult Add(Employee employee)
        {
           
            if (ModelState.IsValid)
            {
                user.Employees.Add(employee);
                user.SaveChanges();
                TempData["Message"] = "Employee added successfuly";
                return RedirectToAction(nameof(Index));
            }
            return View("EmployeeForm");
        }
        [HttpPost]
        public ActionResult AddAjax(Employee employee)
        {

            if (ModelState.IsValid)
            {
                user.Employees.Add(employee);
                user.SaveChanges();
                TempData["Message"] = "Employee added successfuly";
                return PartialView("_EmployeePartial", employee);//34an yrg3ha nfs shakl el employee
            }
            return Json(ModelState);
        }
        //public PartialViewResult EmployeePartial(int id) //etbdltha b el partial 3ltol
        //{
        //    Employee emp = user.Employees.ToList().Find(e => e.Id == id);
        //    return PartialView("_EmployeePartial", emp);
        //}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Employee employee = user.Employees.Find(id);
            if(employee!=null)
            {

            user.Employees.Remove(employee);
            user.SaveChanges();
                return Json(true);
            }
            return HttpNotFound("Employee not found");

        }
        public ActionResult Details(int id)
        {
            Employee emp = user.Employees.Find(id);
            return View("Details", emp);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee employee = user.Employees.Find(id);
            if(employee!=null)
            {
            ViewBag.Action = "Edit";
                return View("EmployeeForm",employee);
            }
            return HttpNotFound("Employee not found");
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                user.Employees.Attach(employee);
                user.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                user.SaveChanges();
                TempData["Message"] = "Employee edited successfuly";

                return RedirectToAction(nameof(Index));

            }
            ViewBag.Action = "Edit";

            return View("EmployeeForm", employee);


        }

    }
}