using PagedList;
using Proje.Model.Model.Entities;
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
    public class ProductController : Controller
    {
        ProductService _productService;
        CategoryService _categoryService;
        public ProductController()
        {
            _productService = new ProductService();
            _categoryService = new CategoryService();
        }

        public ActionResult Detail(Guid? id)
        {
            if (id == null) return RedirectToAction("Index", "Home");

            return View(_productService.GetById((Guid)id));

        }

        public ActionResult Index(Guid? id, int page = 1)
        {
            if (id == null) return RedirectToAction("Index", "Home");
            List<Product> productList = _productService.GetProductsByCategoryID((Guid)id);

            return View(productList.ToPagedList(page, 5));
        }
    }
}