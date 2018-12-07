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
            UserEtablishment u = new UserEtablishment();
            u.etablishmentID = 8;
            u.userID = 1;
            _context.Add(u);
            _context.SaveChanges();
            
            return Content(_context.user.Where(s => s.accountTypeID == 1).Count().ToString());
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
