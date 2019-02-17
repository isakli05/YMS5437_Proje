using Proje.Core.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Model.Model.Entities
{
    public class Product:CoreEntity
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public decimal Price { get; set; }
        public short UnitsInStock { get; set; }
        public string Quantity { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }


    }
}
