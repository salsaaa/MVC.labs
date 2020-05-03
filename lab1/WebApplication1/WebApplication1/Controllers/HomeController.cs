using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
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
        public ViewResult RegisterForm(User e)
        {
            if(e.Name!=null && e.Email!=null)
            {
                ViewBag.Name = e.Name;
                return View("Welcome");
            }
            return View();
        }

    }
}