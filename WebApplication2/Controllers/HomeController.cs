using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using AppContext = WebApplication2.Models.AppContext;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppContext _context;
        public HomeController(AppContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            Debug.WriteLine("ok");
            return Content(_context.Admins.Count().ToString());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
