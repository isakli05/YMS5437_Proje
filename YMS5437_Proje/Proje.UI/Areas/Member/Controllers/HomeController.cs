using Proje.Service.Service.Concrete;
using Proje.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje.UI.Areas.Member.Controllers
{
    [RolesAttribute("Member", "Admin")]
    public class HomeController : Controller
    {
        CategoryService _categoryService;

        public HomeController()
        {
            _categoryService = new CategoryService();
        }




        public ActionResult Index()
        {
            return View(_categoryService.GetActive());
        }
    }
}