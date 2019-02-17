using Proje.Core.Core.Map;
using Proje.Model.Model.Entities;


namespace Proje.Map.Map.EntityMaps
{
    public class OrderDetailMap:CoreMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            ToTable("dbo.OrderDetails");
            Property(od => od.UnitPrice).IsOptional();
            Property(od => od.Quantity).IsOptional();

            HasRequired(od => od.Product)
                .WithMany(product => product.OrderDetails)
                .HasForeignKey(od => od.ProductID)
                .WillCascadeOnDelete(false);
        }
    }
}
