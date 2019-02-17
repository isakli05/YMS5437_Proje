using System;

namespace Proje.Service.Service.DTO
{
    public class ProductDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public short UnitsInStock { get; set; }
        public string Quantity { get; set; }
        public string ImagePath { get; set; }
        public Guid CategoryID { get; set; }
    }
}