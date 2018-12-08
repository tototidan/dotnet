using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using Microsoft.AspNetCore.Http;
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
            string t = "";
            var test = _context.etablishment.Where(s => s.etablishmenttypeID == 2).OrderByDescending(x => x.average).Select(s => new { s.name, s.phonenumber, s.etablishmentType.type }).Take(5).ToList();
            foreach(var test2 in test)
            {
                t += test2.ToString();
            }
            return Content(t);
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
