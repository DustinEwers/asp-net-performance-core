﻿using App.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace App.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context) {
            _context = context;
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.Take(100).ToList();

            return View(customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}