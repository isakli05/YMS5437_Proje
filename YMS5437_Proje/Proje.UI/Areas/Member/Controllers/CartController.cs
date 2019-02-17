using Proje.Model.Model.Entities;
using Proje.Service.Service.Concrete;
using Proje.Service.Service.DTO;
using Proje.UI.Areas.Member.Models;
using Proje.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje.UI.Areas.Member.Controllers
{
    [RolesAttribute("Member", "Admin")]
    public class CartController : Controller
    {
        ProductService _productService;
        public CartController()
        {
            _productService = new ProductService();
        }


        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Add(Guid id)
        {
            Product eklenecekUrun = _productService.GetById(id);

            CartProductVM sepetUrunu = new CartProductVM
            {
                ID = eklenecekUrun.ID,
                ProductName = eklenecekUrun.Name,
                UnitPrice = eklenecekUrun.Price,
                Quantity = 1
            };

            if (Session["sepet"] != null)
            {
                //Eğer sepet zaten varsa, sepeti yakala, gerçek tipine cast et, içine ürünü ekle, tekrar session içerisinde aynı yere son halini ekle.
                ProductCart cart = Session["sepet"] as ProductCart;
                cart.AddToCart(sepetUrunu);
                Session["sepet"] = cart;
            }
            else
            {
                //Eğer session içerisinde bir sepet yoksa, ilk kez sepet oluşuyordur. Sepeti oluştur ve ilk ürünü ekle.
                ProductCart cart = new ProductCart();
                cart.AddToCart(sepetUrunu);
                //İlk session oluşturmamda aşağıdaki kod kullanılır.
                //ilk parametre string tipte bu sessiondan tekrar yakalamakta kullancağımız isim(şu an sepet ismi verdik), ikinci parametre ise gerçek sepept nesnemizdir.
                Session.Add("sepet", cart);


            }
            //Ekleme işlemi sonucunda geriye json tipinde boş bile olsa değer dönmeliyiz. Eğer "return View()" bırakırsak , o zaman bize metodun kendi isminde bir view arayacak ve sayfamızı değiştirmeye çalışacaktır. Ajax sayesinde sayfanın yenilenmesini bile istemiyoruz. Bu nedenle bu metotlara bir view oluşturmuyoruz. Return View() yerine Return Json() yazıyoruz.
            ProductCart cart2 = Session["sepet"] as ProductCart;

            return Json(cart2.CartProductList);
        }


        public ActionResult List()
        {
            //Sepet varsa. Session içerisinde sepet isminde bir değer varsa, o zaman sepetteki tüm ürünleri bir liste halinde istemciye gönderiyoruz.
            if (Session["sepet"] != null)
            {

                ProductCart cart = Session["sepet"] as ProductCart;

                List<CartProductVM> productList = cart.CartProductList.Select(x => new CartProductVM
                {
                    ID = x.ID,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    Quantity = x.Quantity
                }).ToList();

                return Json(productList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Empty", JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult DecreaseCart(Guid id)
        {
            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                cart.DecreaseCart(id);
                Session["sepet"] = cart;
            }
            return Json("");
        }

        public ActionResult IncreaseCart(Guid id)
        {
            ProductCart cart = Session["sepet"] as ProductCart;
            cart.IncreaseCart(id);
            Session["sepet"] = cart;

            return Json("");
        }

        public ActionResult Remove(Guid id)
        {
            ProductCart cart = Session["sepet"] as ProductCart;
            cart.RemoveCart(id);
            Session["sepet"] = cart;

            return Json("");
        }
    }
}