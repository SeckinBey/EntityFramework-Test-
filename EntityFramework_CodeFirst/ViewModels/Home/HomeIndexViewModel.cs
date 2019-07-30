using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityFramework_CodeFirst.Models;

namespace EntityFramework_CodeFirst.ViewModels.Home
{
    public class HomeIndexViewModel
    {
        public IList<Person> Persons { get; set; }
        public IList<Address> Addresses { get; set; }
    }
}