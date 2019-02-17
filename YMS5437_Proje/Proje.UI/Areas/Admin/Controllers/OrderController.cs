using PagedList;
using Proje.Model.Model.Entities;
using Proje.Service.Service.Concrete;
using Proje.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje.UI.Areas.Admin.Controllers
{
    [Roles("Admin")]
    public class OrderController : Controller
    {
        OrderService _orderService;
        OrderDetailService _orderDetailService;
        ProductService _productService;
        public OrderController()
        {
            _orderService = new OrderService();
            _orderDetailService = new OrderDetailService();
            _productService = new ProductService();
        }

        //Daha onaylanmamış tüm siparişleri listele
        [HttpGet]
        public ViewResult List(int page = 1)=>View(_orderService.ListPendingOrders().ToPagedList(page,10));
        
        public ViewResult Detail(Guid id)=>View(_orderDetailService.GetDefault(x=>x.OrderID==id));
        

        public RedirectToRouteResult RejectOrder(Guid id)
        {
            _orderService.Remove(id);
            return RedirectToAction("List","Order");
        }

        public RedirectToRouteResult ConfirmOrder(Guid id)
        {
            Order order = _orderService.GetById(id);

            //Stoktan düşme işlemi
            foreach (var item in order.OrderDetails)
            {
                Product p = _productService.GetById(item.ProductID);
                //if (p.UnitsInStock<item.Quantity)
                //{
                //    return RedirectToAction("List", "Order");
                //}
                p.UnitsInStock -= (short)item.Quantity;
                _productService.Update(p);
            }

            //Sipariş onaylama işlemleri
          
            order.IsConfirmed = true;
            _orderService.Update(order);


            return RedirectToAction("List", "Order");

        }
    }
}