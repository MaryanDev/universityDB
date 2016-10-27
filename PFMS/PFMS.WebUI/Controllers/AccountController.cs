using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PFMS.WebUI.Infrastructure.Authentification;
using PFMS.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace PFMS.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET: Account
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public  ActionResult Login(LoginModel loginModel, string returnUrl)
        {
            PrintingFactoryUser user = UserManager.Find(loginModel.Login, loginModel.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid name or password.");
            }
            else
            {
                ClaimsIdentity ident = UserManager.CreateIdentity(user,
                    DefaultAuthenticationTypes.ApplicationCookie);

                AuthManager.SignOut();
                AuthManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = false
                }, ident);

                if (string.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return Redirect(returnUrl);
                }
            }

            return View(loginModel);
        }

        public ActionResult Logout()
        {
            AuthManager.SignOut();
            return RedirectToAction("Login");
        }

        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private PrintingFactoryUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<PrintingFactoryUserManager>();
            }
        }
    }
}