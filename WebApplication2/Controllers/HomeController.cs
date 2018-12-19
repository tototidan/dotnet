using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using Microsoft.AspNetCore.Http;
using AppContext = WebApplication2.Models.AppContext;
using System.Collections.Generic;

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
            IList<Etablishment> hotellist = new List<Etablishment>();
            hotellist.Add(new Etablishment() { name = "toto", postalcode = "75000", street = "34 avenue paris", description = "hotel 5 etoiles" });
            hotellist.Add(new Etablishment() { name = "tota", postalcode = "75000", street = "34 avenue paris", description = "hotel 5 etoiles" });
            hotellist.Add(new Etablishment() { name = "toti", postalcode = "75000", street = "34 avenue paris", description = "hotel 5 etoiles" });
            hotellist.Add(new Etablishment() { name = "toti", postalcode = "75000", street = "34 avenue paris", description = "hotel 5 etoiles" });

            ViewData["hotels"] = hotellist;
            return View();
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
            return View("home");
        }
    }
}
