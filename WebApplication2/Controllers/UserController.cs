using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AppContext = WebApplication2.Models.AppContext;
// User controler
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
            if (HttpContext.Session.GetInt32("userId") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        public IActionResult UserLogout()
        {
            if (HttpContext.Session.GetInt32("userId") != null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");
            }
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
                HttpContext.Session.SetInt32("userId", user.userID);
                HttpContext.Session.SetString("username", user.Login);

                return RedirectToAction("Success");
            }
            else
            {
                ViewBag.Error = true;
                return RedirectToAction("UserLogin");
            }


        }


        public ActionResult Success()
        {
            return View();

        }

        public ActionResult Disconnect()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(string login, string password, string passwordRepeat)
        {
            if (login != null && password != null && passwordRepeat != null)
            {
                if (password == passwordRepeat)
                {
                    _context.user.Add(new Models.User {
                       Login = login,
                       Password = password,
                       accountTypeID = 1
                    });

                    _context.SaveChanges();

                    return RedirectToAction("Success");

                }
                else
                {
                    return RedirectToAction("UserRegister");
                }
            }
            else
            {
                return RedirectToAction("UserRegister");
            }
        }

        //[Authorize]
        //[HttpPost]
        public ActionResult UserDetails()
        {
            var userId = HttpContext.Session.GetInt32("userId");
            var user = (from cust in _context.user where cust.userID == userId select cust);
            return View();
        }

    }
}