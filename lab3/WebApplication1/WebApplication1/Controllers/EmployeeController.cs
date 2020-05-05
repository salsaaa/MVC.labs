using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        Users user = new Users();
        // GET: Employee
        [HttpGet]
        public ActionResult Index()
        {
            return View(user.Employees.ToList());
        }
        [HttpGet]
        public ActionResult RegisterForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterForm(Employee employee)
        {
            if (ModelState.IsValid)
            {
                user.Employees.Add(employee);
                user.SaveChanges();
                TempData["Name"] = employee.Name;
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        //public PartialViewResult EmployeePartial(int id) //etbdltha b el partial 3ltol
        //{
        //    Employee emp = user.Employees.ToList().Find(e => e.Id == id);
        //    return PartialView("_EmployeePartial", emp);
        //}
        public ActionResult Delete(int id)
        {
            Employee emp = user.Employees.Find(id);
            user.Employees.Remove(emp);
            user.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public ActionResult Details(int id)
        {
            Employee emp = user.Employees.Find(id);
            return View("Details", emp);
        }
        public ActionResult Edit(int id,Employee emp)
        {
            if (ModelState.IsValid)
            {
                user.Employees.Attach(emp);
                user.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                user.SaveChanges();
                return RedirectToAction(nameof(Index));
             
            }
            return View();

        }

    }
}