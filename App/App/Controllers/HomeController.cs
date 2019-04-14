using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using System.Threading;
using StackExchange.Profiling;
using App.Services;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        public ICustomerService service;

        public HomeController(ICustomerService _service) {
            service = _service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            var profiler = MiniProfiler.StartNew("Profiler on the Home Controller");
            using (profiler.Step("Some Work")) {
                Thread.Sleep(100);
                ViewData["Message"] = "Your application description page.";
            }
            return View();
        }

        [ResponseCache(CacheProfileName = "Default")]
        public IActionResult Contact()
        {
            using (MiniProfiler.Current.Step("Some Work"))
            {
                Thread.Sleep(100);
                ViewData["Message"] = "Your contact page.";
            }

            return View();
        }

        [ResponseCache(CacheProfileName = "Never")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private async Task<List<Customer>> GetCustomerDataAsync() {
            var customers = await service.GetCustomersAsync();
            var details = await service.GetExtraCustomerDataFromService();
            var moreDetails = await service.GetMoreExternalCustomerDataFromService();

            return AssembleCustomerDetails(details, moreDetails, customers);
        }

        private List<Customer> GetCustomerDataParallel()
        {
            // Kick off all of these in parallel
            var customerTask = service.GetCustomersAsync();
            var detailsTask = service.GetExtraCustomerDataFromService();
            var moreDetailsTask = service.GetMoreExternalCustomerDataFromService();

            // Wait until all of the results come back
            Task.WaitAll(customerTask, detailsTask, moreDetailsTask);

            return AssembleCustomerDetails(detailsTask.Result, 
                moreDetailsTask.Result, 
                customerTask.Result);
        }




        private List<Customer> AssembleCustomerDetails(List<string> thing1, List<string> thing2, List<Customer> customers) {
            return customers;
        }
    }
}
