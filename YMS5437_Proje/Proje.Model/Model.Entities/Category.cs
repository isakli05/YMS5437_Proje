using Proje.Core.Core.Entity;
using System.Collections.Generic;


namespace Proje.Model.Model.Entities
{
    public class Category:CoreEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public string Name { get; set; }
        public string Description { get; set; }

        //Bir kategori birden çok ürüne aittir.

        public virtual ICollection<Product> Products { get; set; }
    }
}
