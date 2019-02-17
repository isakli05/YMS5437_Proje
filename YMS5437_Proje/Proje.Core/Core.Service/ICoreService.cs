using Proje.Core.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Core.Core.Service
{
    public interface ICoreService<T> where T : CoreEntity
    {
        //Genel olarak tüm entitiylerin sahip olacağı davranışları tanımlıyoruz.

        void Add(T item);
        void Add(List<T> items);
        void Update(T item);
        void Remove(T item);
        List<T> GetActive();
        void Remove(Guid id);
        /// <summary>
        /// İçerisine herhangi bir ifade gönderebiliriz ve o ifadeye uyan tüm kayıtları siler.
        /// </summary>
        /// <param name="exp"></param>
        void RemoveAll(Expression<Func<T, bool>> exp);
        T GetById(Guid id);
        T GetByDefault(Expression<Func<T, bool>> exp);
        List<T> GetDefault(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        int Save();
    }
}
