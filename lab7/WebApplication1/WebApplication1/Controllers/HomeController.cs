using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //Any User
        [AllowAnonymous]
        public ActionResult Index()
        {
            ApplicationUserManager userManager =
                new ApplicationUserManager(
                    new UserStore<ApplicationUser>(
                        new ApplicationDbContext()));
            ApplicationUser admin = userManager.FindByEmail("Admin@gmail.com");
            ApplicationUser manager = userManager.FindByEmail("Manager@gmail.com");
            ApplicationUser client = userManager.FindByEmail("Client@gmail.com");

            userManager.AddToRole(admin.Id, "Admin");
            userManager.AddToRole(manager.Id, "Manager");
            userManager.AddToRole(client.Id, "Client");


            return View();
        }
        // Authenticated

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        // Authenticated

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        // Admin
        [Authorize(Roles ="Admin")]
        public ActionResult ForAdmin()
        {
            return View();

        }
        // Admin Manager
        [Authorize(Roles = "Admin,Manager")]

        public ActionResult ForManager()
        {
            return View();

        }
        //Admin Client
        [Authorize(Roles = "Client,Admin")]

        public ActionResult ForClient()
        {
            return View();

        }
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public ActionResult AddRole(IdentityRole role)
        {
            if(ModelState.IsValid)
            {
                RoleManager<IdentityRole> roleManager =
                    new RoleManager<IdentityRole>(
                        new RoleStore<IdentityRole>(
                            new ApplicationDbContext()));
                roleManager.Create(role);
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}