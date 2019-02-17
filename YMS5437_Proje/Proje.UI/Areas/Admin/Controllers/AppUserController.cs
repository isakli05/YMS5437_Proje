using Proje.Model.Model.Entities;
using Proje.Service.Service.Concrete;
using Proje.Service.Service.DTO;
using Proje.UI.Attributes;
using Proje.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje.UI.Areas.Admin.Controllers
{

    public class AppUserController : BaseController
    {
        AppUserService _appUserService;
        public AppUserController()
        {
            _appUserService = new AppUserService();
        }

        public ActionResult List()
        {
            return View(_appUserService.GetActive());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AppUser data,HttpPostedFileBase Image)
        {
            data.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", Image);

            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
            {
                //Varsayılan foto.
                data.ImagePath = "/Uploads/Anon.png";
            }
            _appUserService.Add(data);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Update(Guid? id)
        {
            if (id == null) return RedirectToAction("List");
            AppUser guncellenecek = _appUserService.GetById((Guid)id);
            AppUserDTO model = new AppUserDTO();
            model.ID = guncellenecek.ID;
            model.Name = guncellenecek.Name;
            model.LastName = guncellenecek.LastName;
            model.Password = guncellenecek.Password;
            model.UserName = guncellenecek.UserName;
            model.Role = guncellenecek.Role;
            model.ImagePath = guncellenecek.ImagePath;
            model.Address = guncellenecek.Address;
            model.PhoneNumber = guncellenecek.PhoneNumber;
            model.Email = guncellenecek.Email;
            return View(model);
            
        }
        [HttpPost]
        public ActionResult Update(AppUserDTO data,HttpPostedFileBase Image)
        {

            data.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", Image);

            AppUser guncellenecek = _appUserService.GetById(data.ID);

            if (data.ImagePath != "0" && data.ImagePath != "1" && data.ImagePath != "2")
            {
                guncellenecek.ImagePath = data.ImagePath;
            }

            guncellenecek.Name = data.Name;
            guncellenecek.LastName = data.LastName;
            guncellenecek.Password = data.Password;
            guncellenecek.UserName = data.UserName;
            guncellenecek.Role = data.Role;
            guncellenecek.Address = data.Address;
            guncellenecek.PhoneNumber = data.PhoneNumber;
            guncellenecek.Email = data.Email;
            _appUserService.Update(guncellenecek);

            return RedirectToAction("List");
        }

        public RedirectToRouteResult Delete(Guid? id)
        {
            if (id == null) return RedirectToAction("List");

            _appUserService.Remove((Guid)id);

            return RedirectToAction("List");
        }
    }
}