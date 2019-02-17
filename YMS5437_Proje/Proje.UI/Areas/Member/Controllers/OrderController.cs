using Proje.Model.Model.Entities;
using Proje.Service.Service.Concrete;
using Proje.UI.Areas.Member.Models;
using Proje.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje.UI.Areas.Member.Controllers
{
    [RolesAttribute("Member","Admin")]
    public class OrderController : Controller
    {
        AppUserService _appUserService;
        ProductService _productService;
        OrderService _orderService;

        public OrderController()
        {
            _appUserService = new AppUserService();
            _productService = new ProductService();
            _orderService = new OrderService();
        }



        public ActionResult Add()
        {
            if (Session["sepet"]==null)
            {
                return RedirectToAction("Index","Home");
            }

            ProductCart cart = Session["sepet"] as ProductCart;

            Order newOrder = new Order();

            AppUser currentUser = _appUserService.FindByEmail(HttpContext.User.Identity.Name);

            newOrder.AppUserID = currentUser.ID;

            foreach (var item in cart.CartProductList)
            {
                Product nextCartProduct = _productService.GetById(item.ID);
                newOrder.OrderDetails.Add(new OrderDetail
                {
                    ProductID = nextCartProduct.ID,
                    Quantity=item.Quantity,
                    UnitPrice=item.UnitPrice
                });
            }

            _orderService.Add(newOrder);


            return RedirectToAction("Index","Home");
        }
    }
}