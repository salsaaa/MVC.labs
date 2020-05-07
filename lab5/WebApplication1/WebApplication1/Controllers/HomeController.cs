using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
                Users user = new Users();
        // GET: Home
        [HttpGet]
        [HandleError]
        public ActionResult Index()
        {
            //try
            //{
            throw new Exception("custom ex");
            return View();

            //}
            //catch (Exception ex)
            //{
            //    return View("Error", ex);
            //}
        }
        public ActionResult Welcome()
        {
            return View();
        }

    }
}