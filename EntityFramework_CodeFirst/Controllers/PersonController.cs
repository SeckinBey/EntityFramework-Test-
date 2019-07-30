using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;
using EntityFramework_CodeFirst.Entity;
using EntityFramework_CodeFirst.Models;

namespace EntityFramework_CodeFirst.Controllers
{
    public class PersonController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person model)
        {

            db.Persons.Add(model);

            db.SaveChanges();



            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int? personid)
        {
            Person person = null;

            if (personid != null)
            {
                person = db.Persons.FirstOrDefault(i => i.ID == personid);
            }

            return View(person);
        }

        [HttpPost]
        public ActionResult Edit(Person model, int? personid)
        {
            Person person = db.Persons.FirstOrDefault(x => x.ID == personid);

            if (person != null)
            {
                person.Name = model.Name;
                person.Surname = model.Surname;
                person.Age = model.Age;

                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int? personid)
        {
            Person person = null;

            if (personid!=null)
            {
                person = db.Persons.FirstOrDefault(i => i.ID == personid);
            }

            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? personid)
        {

            if (personid != null)
            {
                Person person = db.Persons.FirstOrDefault(i => i.ID == personid);

                db.Persons.Remove(person);
                db.SaveChanges();

            }

            return RedirectToAction("Index", "Home");
        }
    }
}