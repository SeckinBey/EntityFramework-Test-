using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFramework_CodeFirst.Entity;
using EntityFramework_CodeFirst.Models;

namespace EntityFramework_CodeFirst.Controllers
{
    public class AddressController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        // GET: Address
        public ActionResult Create()
        {



            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Address address)
        {
            Person person = db.Persons.FirstOrDefault(i => i.ID == address.Person.ID);

            address.Person = person;
            db.Addresses.Add(address);

            db.SaveChanges();

            ViewBag.item = TempData["persons"];

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int? addressid)
        {
            Address address = null;

            if (addressid != null)
            {
                List<SelectListItem> personList =
                               (from person in db.Persons.ToList()
                                select new SelectListItem()
                                {
                                    Text = person.Name + " " + person.Surname,
                                    Value = person.ID.ToString()
                                }).ToList();

                TempData["persons"] = personList;
                ViewBag.item = personList;

                address = db.Addresses.FirstOrDefault(i => i.ID == addressid);

            }
            return View(address);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Address model, int? addressid)
        {
            Person person = db.Persons.FirstOrDefault(i => i.ID == model.Person.ID);
            Address address = db.Addresses.FirstOrDefault(i => i.ID == addressid);
            

            if (person != null)
            {
                address.Person = person;
                address.AddressName = model.AddressName;

                db.SaveChanges();
            }


            ViewBag.item = TempData["persons"];

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int? addressid)
        {
            Address address = null;

            if (addressid != null)
            {
                address = db.Addresses.FirstOrDefault(i => i.ID == addressid);
            }

            return View(address);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? addressid)
        {

            if (addressid != null)
            {
                Address address = db.Addresses.FirstOrDefault(i => i.ID == addressid);

                db.Addresses.Remove(address);
                db.SaveChanges();

            }

            return RedirectToAction("Index", "Home");
        }
    }
}