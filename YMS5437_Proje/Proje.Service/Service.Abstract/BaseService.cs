using Proje.Core.Core.Entity;
using Proje.Core.Core.Service;
using Proje.DAL.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Service.Service.Abstract
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {


        //Bu sınıfın amacı, ortak tüm metodlarımızı tanımlamak, yani tüm entitylerimizin yani tablolarımızın işine yarayacak metodları bir kere yazmak ve daha sonrasında bu sınıfı ve içerisindeki metodları miras vermek.
        //Eğer kendilerine özel bir metoda sahip olacaklarsa, onları kendi sınıflarında tannımlıyor olacağız.

        //Context Sınıfı tanımlanır.


        private ProjectContext _context;

        //protected DbSet<T> table;

        public BaseService()
        {
            //table = _context.Set<T>();
            _context = new ProjectContext();
        }


        public void Add(T item)
        {
            //table.Add(item);
            _context.Set<T>().Add(item);
            Save();

        }

        public void Add(List<T> items)
        {
            _context.Set<T>().AddRange(items);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp) => _context.Set<T>().Any(exp);

        public List<T> GetActive()
        {
            return _context.Set<T>().Where(x => x.Status == Core.Core.Entity.Enum.Status.Active || x.Status == Core.Core.Entity.Enum.Status.Updated).ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp).FirstOrDefault();


        public List<T> GetLastEntries(Expression<Func<T, bool>> exp,int count) => _context.Set<T>().Where(exp).OrderByDescending(y=>y.CreatedDate).Take(count).ToList();

        public T GetById(Guid id) => _context.Set<T>().Find(id); //Bodied Member.


        public List<T> GetDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp).ToList();


        public void Remove(T item)
        {
            item.Status = Core.Core.Entity.Enum.Status.Deleted;
            Update(item);
        }

        public void Remove(Guid id)
        {
            T item = GetById(id);
            item.Status = Core.Core.Entity.Enum.Status.Deleted;
            Update(item);
        }

        public void RemoveAll(Expression<Func<T, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Status = Core.Core.Entity.Enum.Status.Deleted;
                Update(item);
            }
        }


        public int Save() => _context.SaveChanges();


        public void Update(T item)
        {
            T updatedItem = GetById(item.ID);
            DbEntityEntry entry = _context.Entry(updatedItem);
            entry.CurrentValues.SetValues(item);
            Save();
        }
    }
}
