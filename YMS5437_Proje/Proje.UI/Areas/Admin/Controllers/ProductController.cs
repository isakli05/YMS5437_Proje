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

    public class ProductController : BaseController
    {
        ProductService _productService;
        CategoryService _categoryService;
        public ProductController()
        {
            _categoryService = new CategoryService();
            _productService = new ProductService();
        }

        public ActionResult List()
        {
            return View(_productService.GetActive());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(_categoryService.GetActive());
        }


        [HttpPost]
        public ActionResult Add(Product data, HttpPostedFileBase Image)
        {
            //Görsel için static metodu inceleyiniz. Utility katmanına bakınız.

            data.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", Image);

            //Eğer 0 veya 1 veya 2 geldiyse bir hata almışızdır, o durumda gidip default bir image tanımlayalım.

            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
            {
                //Varsayılan foto.
                data.ImagePath = "~/Uploads/TestPhoto.jpg";
            }
            _productService.Add(data);


            return RedirectToAction("List");
        }

        public ActionResult Delete(Guid id)
        {
            _productService.Remove(id);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Update(Guid id)
        {
            ProductUpdateVM model = new ProductUpdateVM();
            Product guncellenecek = _productService.GetById(id);

            model.Product.ID = guncellenecek.ID;
            model.Product.Price = guncellenecek.Price;
            model.Product.Name = guncellenecek.Name;
            model.Product.Quantity = guncellenecek.Quantity;
            model.Product.UnitsInStock = guncellenecek.UnitsInStock;
            model.Product.ImagePath = guncellenecek.ImagePath;
            model.Product.CategoryID = guncellenecek.CategoryID;

            //View'e gidecek bu modelin ürün bölümünü tamamladık, sıra tüm kategorileri göndermede.
            //Kategoriler de direk entity tipinde değil CategoryDTO tipinde olduğu için select ile atamaları gerçekleştirdik.

            model.Categories = _categoryService.GetActive().Select(c => new CategoryDTO
            {
                ID = c.ID,
                Name = c.Name,
                Description = c.Description
            }).ToList();

            return View(model);
        }


        [HttpPost]
        public ActionResult Update(ProductDTO data, HttpPostedFileBase Image)
            {
            data.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", Image);

            Product guncellenecek = _productService.GetById(data.ID);

            if (data.ImagePath != "0" && data.ImagePath != "1" && data.ImagePath != "2")
            {
                guncellenecek.ImagePath = data.ImagePath;
            }

            guncellenecek.Name = data.Name;
            guncellenecek.Price = data.Price;
            guncellenecek.UnitsInStock = data.UnitsInStock;
            guncellenecek.Quantity = data.Quantity;
            guncellenecek.CategoryID = data.CategoryID;

            _productService.Update(guncellenecek);

            return RedirectToAction("List");

        }
    }
}