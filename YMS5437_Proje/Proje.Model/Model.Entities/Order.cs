using Proje.Core.Core.Entity;
using System;
using System.Collections.Generic;

namespace Proje.Model.Model.Entities
{
    public class Order:CoreEntity
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public Guid AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }
        public bool IsConfirmed { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
