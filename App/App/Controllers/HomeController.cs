using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using System.Threading;
using StackExchange.Profiling;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            var profiler = MiniProfiler.StartNew("Profiler on the About Controller");
            using (profiler.Step("Some Work")) {
                Thread.Sleep(100);
                ViewData["Message"] = "Your application description page.";
            }
            return View();
        }

        [ResponseCache(CacheProfileName = "Default")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [ResponseCache(CacheProfileName = "Never")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
