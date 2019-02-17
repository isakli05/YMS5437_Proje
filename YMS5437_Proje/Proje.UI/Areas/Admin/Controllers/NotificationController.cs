using Proje.Service.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje.UI.Areas.Admin.Controllers
{
    public class NotificationController : Controller
    {
        
        public PartialViewResult AppUserNotification()
        {
            AppUserService _appUserService = new AppUserService();
            return PartialView("_AppUserNotification",_appUserService.GetLastEntries(3));
        }


        public PartialViewResult OrderNotification()
        {
            OrderService _orderService = new OrderService();
            return PartialView("_OrderNotification", _orderService.GetLastEntries(1));
        }
    }
}