using App.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace App.DataAccess
{
    public class DataGenerators
    {

        public static List<Customer> GenerateCustomers(int numberOfCustomers = 10000)
        {
            Randomizer.Seed = new Random(8675309);
            var idx = 1;
            var customerFaker = new Faker<Customer>()
                .RuleFor(x => x.Id, f => idx++)
                .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName())
                .RuleFor(u => u.LastName, (f, u) => f.Name.LastName())
                .RuleFor(u => u.Address1, f => f.Address.FullAddress())
                .RuleFor(u => u.Address2, f => f.Address.SecondaryAddress())
                .RuleFor(u => u.City, f => f.Address.City())
                .RuleFor(u => u.State, f => f.Address.State())
                .RuleFor(u => u.PostalCode, f => f.Address.ZipCode());

            var fakeCustomers = customerFaker.Generate(numberOfCustomers);

            return fakeCustomers;
        }

        public static List<Product> GenerateProducts()
        {
            return new List<Product>()
            {
                new Product {Id = 1, Name = "Plush Cheetah", Description = "This is a fine microfiber plush cheetah.", Price = 10.0m},
                new Product {Id = 2, Name = "Plush Sloth", Description = "This is an adorable plush sloth.", Price = 5.0m},
                new Product {Id = 3, Name = "Stuffed Bear", Description = "This is a non-descript stuffed bear.", Price = 15.0m},
                new Product {Id = 4, Name = "Gold plated Sloth Bust", Description = "This fine bust would be lovely over your fireplace.", Price = 50.0m},
            };
        }
    }
}
