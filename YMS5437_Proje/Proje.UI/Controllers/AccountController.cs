using Proje.Model.Model.Entities;
using Proje.Service.Service.Concrete;
using Proje.Service.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Proje.UI.Controllers
{
    public class AccountController : Controller
    {
        AppUserService _appUserService;
        public AccountController()
        {
            _appUserService = new AppUserService();
        }
        
        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser currentUser = _appUserService.FindByEmail(HttpContext.User.Identity.Name);

                if (currentUser.Role == Role.Admin)
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else if (currentUser.Role == Role.Member)
                {
                    return RedirectToAction("Index", "Home", new { area = "Member" });
                }
                else
                {
                    return RedirectToAction("SignUp");
                }
            }


            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM data)
        {
            if (ModelState.IsValid)
            {

                if (_appUserService.CheckCredentials(data.Email,data.Password))
                {
                    AppUser currentUser = _appUserService.FindByEmail(data.Email);

                    //cookie oluşturuyoruz.
                    string cookie = currentUser.Email;

                    FormsAuthentication.SetAuthCookie(cookie, true);

                    if (currentUser.Role==Role.Admin)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else if (currentUser.Role==Role.Member)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Member" });
                    }
                    else
                    {
                        return RedirectToAction("SignUp");
                    }

                }
                else
                {
                    ViewBag.Message = "Kullanıcı Adı veya Parola Yanlış!";
                    return RedirectToAction("Login");
                }


            }
            return RedirectToAction("Login");
        }
    }
}