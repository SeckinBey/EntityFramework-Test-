using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EntityFramework_CodeFirst.Models;

namespace EntityFramework_CodeFirst.Entity
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new DataInitializer());
        }
    }

    public class DataInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                Person person = new Person();
                person.Name = FakeData.NameData.GetFirstName();
                person.Surname = FakeData.NameData.GetSurname();
                person.Age = FakeData.NumberData.GetNumber(10, 90);

                context.Persons.Add(person);
            }   //Inserting Persons

            context.SaveChanges();

            List<Person> allPersons = context.Persons.ToList();

            foreach (var person in allPersons)
            {
                for (int i = 0; i < FakeData.NumberData.GetNumber(1,5); i++)
                {
                    Address address = new Address();
                    address.AddressName = FakeData.PlaceData.GetAddress();
                    address.Person = person;

                    context.Addresses.Add(address);
                }
            }   //Inserting addresses

            context.SaveChanges();
        }
    }
}