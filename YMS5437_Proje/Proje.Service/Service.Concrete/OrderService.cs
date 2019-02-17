using Proje.Model.Model.Entities;
using Proje.Service.Service.Abstract;
using System.Collections.Generic;
using Proje.Core.Core.Entity.Enum;
namespace Proje.Service.Service.Concrete
{
    public class OrderService : BaseService<Order>
    {
        /// <summary>
        /// Admin onayı bekleyen siparişleri List olarak döndürür.
        /// </summary>
        /// <returns></returns>
        public List<Order> ListPendingOrders() => GetDefault(x => (x.Status == Status.Active || x.Status == Status.Updated) && x.IsConfirmed == false);

        public int PendingOrderCount() => GetDefault(x => (x.Status == Status.Active || x.Status == Status.Updated) && x.IsConfirmed == false).Count;

        public List<Order> GetLastEntries(int entryCount)
        {
            return GetLastEntries(((x => x.Status == Status.Active || x.Status == Status.Updated)), entryCount);
        }

    }
}