using Proje.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje.UI.Areas.Admin.Controllers
{
    [RolesAttribute("Admin")]
    public class BaseController : Controller
    {
       
    }
}