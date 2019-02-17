using Proje.Service.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje.UI.Areas.Admin.Controllers
{
    public class ReportController : Controller
    {
        
        public PartialViewResult OrderCount()
        {
            OrderService _orderService = new OrderService();
            ViewBag.PendingOrderCount = _orderService.PendingOrderCount();
            return PartialView("_OrderCount");
        }

        public PartialViewResult MemberCount()
        {
            AppUserService _appUserService = new AppUserService();
            ViewBag.MemberCount = _appUserService.MemberCount();
            return PartialView("_MemberCount");

        }


        public PartialViewResult ProductCount()
        {
            ProductService _productService = new ProductService();
            ViewBag.ProductCount = _productService.ProductCount();
            return PartialView("_ProductCount");

        }


        public PartialViewResult CategoryCount()
        {
            CategoryService _categoryService = new CategoryService();
            ViewBag.CategoryCount = _categoryService.CategoryCount();
            return PartialView("_CategoryCount");
        }
    }
}