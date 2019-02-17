using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Service.Service.DTO
{
    public class ProductUpdateVM
    {
        //Bu sınıfta hem güncellenme izni verilen product özelliklerini , hem de güncelleme yapılacağı için tüm kategori listesini gönderebileceğim bir model sınıfı oluşturuyorum. View içerisine gönderilecek custom bir model olduğundan sınıf isminde hem adını, hem de view model olduğunu gösteren vm bölümünü eklıyoruz.


        public ProductUpdateVM()
        {
            Categories = new List<CategoryDTO>();
            Product = new ProductDTO();
        }

        public ProductDTO Product { get; set; }
        public List<CategoryDTO> Categories { get; set; }

    }
}