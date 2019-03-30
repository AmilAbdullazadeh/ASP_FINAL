using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using ASPFinal.Models;
using ASPFinal.ViewModels;
using ASPFinal.DAL;
using ASPFinal.Models.ViewModels;
using System.Threading.Tasks;

namespace ASPFinal.Controllers
{
    public class AccountController : Controller
    {
        private readonly CarContext _context;

        public AccountController()
        {
            _context = new CarContext();
        }

        public ActionResult Register() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(User user)
        {
            if (!ModelState.IsValid) return View(user);

            if (_context.Users.Any(m => m.Email == user.Email))
            {
                ModelState.AddModelError("Email", "This email is duplicate");
                return View(user);
            }

            if (_context.Users.Any(m => m.Name == user.Name))
            {
                ModelState.AddModelError("Name", "This Name is duplicate");
                return View(user);
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Login", "Account");
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            User user = _context.Users.FirstOrDefault(u => u.Email == vm.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Email or password is not valid");
                return View(vm);
            }

            //if (!Crypto.VerifyHashedPassword(user.Password, vm.Password))
            //{
            //    ModelState.AddModelError("", "Email or password is not valid");
            //    return View(vm);
            //}

            Session["user"] = user;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}