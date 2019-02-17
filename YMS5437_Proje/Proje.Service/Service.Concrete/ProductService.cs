using Proje.Model.Model.Entities;
using Proje.Service.Service.Abstract;
using System;
using System.Collections.Generic;

namespace Proje.Service.Service.Concrete
{
    public class ProductService : BaseService<Product>
    {
        public List<Product> GetProductsByCategoryID(Guid id) => GetDefault(x => x.CategoryID == id && x.UnitsInStock > 0 && (x.Status == Core.Core.Entity.Enum.Status.Active || x.Status == Core.Core.Entity.Enum.Status.Updated));


        public int ProductCount() => GetDefault(x => (x.Status == Core.Core.Entity.Enum.Status.Active || x.Status == Core.Core.Entity.Enum.Status.Updated)).Count;
    }
}
