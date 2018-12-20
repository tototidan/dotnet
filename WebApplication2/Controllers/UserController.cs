﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AppContext = WebApplication2.Models.AppContext;
using System.Data;
using System.Text;

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
                        && string.Compare(Hash(password), us.Password, StringComparison.OrdinalIgnoreCase) == 0
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
                       Password = Hash(password),
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

        
        public ActionResult UserDetails()
        {
            var userId = HttpContext.Session.GetInt32("userId");
            var user = _context.user.Where(s => s.userID ==  HttpContext.Session.GetInt32("userId")).First();
            ViewData["details"] = user;
            return View();
        }

        [HttpPost]
        public ActionResult EditUser(string login, string password, string passwordRepeat)
        {
            
            if (password !=null){
                if (password == passwordRepeat)
                    {
                        var userId = HttpContext.Session.GetInt32("userId");
                        var pass = _context.user.First(a => a.userID == userId);
                        pass.Password = Hash(password);
                        _context.SaveChanges();
                        TempData["SuccessMessage"] = "Your success message here";
                        

                    }
            }
            return View("Success");
            


        }

        public string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

    }
}