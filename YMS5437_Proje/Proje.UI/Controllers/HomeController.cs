using Proje.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje.UI.Controllers
{
    [RolesAttribute("Member","Admin")]
    public class HomeController : Controller
    {
      
        public ActionResult Index()
        {
            return View();
        }
    }
}