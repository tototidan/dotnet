using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AppContext = WebApplication2.Models.AppContext;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        private readonly AppContext _context;
        public UserController(AppContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckUser(string username, string password)
        {
            var user = (from us in _context.user
                        where string.Compare(username, us.Login, StringComparison.OrdinalIgnoreCase) == 0
                        && string.Compare(password, us.Password, StringComparison.OrdinalIgnoreCase) == 0
                        select us).FirstOrDefault();

            if (user != null)
            {
                return RedirectToAction("Success");
            }
            else
            {
                return RedirectToAction("UserLogin", new { error = true });
            }

            //Content(_context.user.Where(s => s.accountTypeID == 1).Count().ToString())


        }


        public ActionResult Success()
        {
            return View();

        }
    }
}
