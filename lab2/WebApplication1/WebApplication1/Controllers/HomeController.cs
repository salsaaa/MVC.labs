using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult RegisterForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult RegisterForm(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Users user = new Users();
                user.Employees.Add(employee);
                user.SaveChanges();
                TempData["Name"] = employee.Name;
                return View("Welcome", employee);
            }
            return View();
        }

    }
}