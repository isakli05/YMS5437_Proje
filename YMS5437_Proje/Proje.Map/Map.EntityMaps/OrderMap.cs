using Proje.Core.Core.Map;
using Proje.Model.Model.Entities;


namespace Proje.Map.Map.EntityMaps
{
    public class OrderMap : CoreMap <Order>
    {
        public OrderMap()
        {
            ToTable("dbo.Orders");

            HasRequired(order => order.AppUser)
                .WithMany(user => user.Orders)
                .HasForeignKey(order => order.AppUserID)
                .WillCascadeOnDelete(false);

            HasMany(order => order.OrderDetails)
                .WithRequired(od => od.Order)
                .HasForeignKey(od => od.OrderID)
                .WillCascadeOnDelete(false);
        }
    }
}