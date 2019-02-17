using Proje.Service.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proje.UI.Areas.Member.Models
{
    public class ProductCart
    {
        private Dictionary<Guid, CartProductVM> _cart = null;

        public List<CartProductVM> CartProductList
        {
            get
            {
                return _cart.Values.ToList();
            }
        }

        //ctor
        public ProductCart()
        {
            _cart = new Dictionary<Guid, CartProductVM>();
        }

        //Sepete eklenecek ürünün daha önce bu sözlüğe eklenip eklenmediğine bakıyoruz. Eklendiyse miktarı arttırıyoruz, yoksa yeni bir ürün olarak ekliyoruz.
        public void AddToCart(CartProductVM item)
        {
            if (_cart.ContainsKey(item.ID))
            {
                _cart[item.ID].Quantity++;
            }
            else
            {
                _cart.Add(item.ID, item);
            }
        }

        public void RemoveCart(Guid id)
        {
            _cart.Remove(id);
        }

        /// <summary>
        /// Sepetteki ürünün miktarını arttırır.
        /// </summary>
        /// <param name="id">ProductID</param>
        public void IncreaseCart(Guid id)
        {
            _cart[id].Quantity++;
        }


        /// <summary>
        /// Sepetteki Miktarı Azaltır
        /// </summary>
        /// <param name="id">ProductID</param>
        public void DecreaseCart(Guid id)
        {
            _cart[id].Quantity--;
            //Sepetteki miktarı azaltma işlemi sonunda eğer sepette hiç kalmazsa, sepetten sil.
            if (_cart[id].Quantity <= 0)
            {
                _cart.Remove(id);
            }
        }

    }
}