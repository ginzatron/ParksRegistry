using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Web.Models;
using WebApplication.Web.Providers.Auth;

namespace WebApplication.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthProvider authProvider;
        public UserController(IAuthProvider authProvider)
        {
            this.authProvider = authProvider;
        }

        [AuthorizationFilter] // This restricts the "Index" action to users who have been authenticated
        //[AuthorizationFilter("Admin", "Manager")] // This restricts the "Index" action to users who have Admin or Manager role only
        public IActionResult Index()
        {
            var user = authProvider.GetCurrentUser();
            return View(user);
        }

        public IActionResult Logoff()
        {
            authProvider.LogOff();

            return RedirectToAction("Index", "Home");
        }

        // Build Registration
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            // Check to see if the data is valid
            if (ModelState.IsValid)
            {
                // Register the user as a new user in the system.
                // Give the user "User" role by default.
                authProvider.Register(model.Email, model.Password, "User");

                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Not valid, so send the user back to the register view
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool validCredentials = authProvider.SignIn(model.Email, model.Password);

                if (!validCredentials)
                {
                    // Take the user to the login page and show an error message
                    // We need to add a customer error, since our model doesn't validate credentials
                    ModelState.AddModelError("AuthenticationFailed", "");
                    return View(model);
                }

                // Happy Path
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(model);
            }
        }
    }
}