using Proje.Model.Model.Entities;
using Proje.Service.Service.Abstract;


namespace Proje.Service.Service.Concrete
{
    public class CategoryService:BaseService<Category>
    {
        public int CategoryCount() => GetDefault(x => (x.Status == Core.Core.Entity.Enum.Status.Active || x.Status == Core.Core.Entity.Enum.Status.Updated)).Count;


     

    }
}