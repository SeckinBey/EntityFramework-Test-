using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFramework_CodeFirst.Entity;
using EntityFramework_CodeFirst.Models;
using EntityFramework_CodeFirst.ViewModels.Home;

namespace EntityFramework_CodeFirst.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DatabaseContext db = new DatabaseContext();
            //var persons = db.Persons.ToList(); //Select * from Person

            HomeIndexViewModel model = new HomeIndexViewModel();
            model.Persons = db.Persons.ToList();
            model.Addresses = db.Addresses.ToList();

            return View(model);
        }
    }
}