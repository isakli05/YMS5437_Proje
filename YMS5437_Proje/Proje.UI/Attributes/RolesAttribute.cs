using Proje.Model.Model.Entities;
using Proje.Service.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje.UI.Attributes
{
    public class RolesAttribute:AuthorizeAttribute
    {
        AppUserService _appUserService;
        private string[] _roles;
        public RolesAttribute(params string[] roles)
        {
            _roles = new string[roles.Length];
            _appUserService = new AppUserService();
            Array.Copy(roles,_roles,roles.Length);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //FormsAuth cookie içerisine atılan mail adresini yakalama yöntemi.
            string email = HttpContext.Current.User.Identity.Name;
            if (!string.IsNullOrWhiteSpace(email))
            {
                AppUser currentUser = _appUserService.FindByEmail(email);
                foreach (string role in _roles)
                {
                    if (currentUser.Role.ToString().Trim().ToLower() == role.Trim().ToLower())
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                //İstersek Error Controller açar ve unauthorized sayfasını hazırlarız.
                HttpContext.Current.Response.Redirect("~/Error/Unauthorized");
                return false;
            }

            

            
        }


        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Error/unauthorized");
        }
    }
}