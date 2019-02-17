using Proje.Core.Core.Map;
using Proje.Model.Model.Entities;


namespace Proje.Map.Map.EntityMaps
{
    public class ProductMap : CoreMap<Product>
    {
        public ProductMap()
        {
            ToTable("dbo.Products");
            Property(product => product.Price).IsOptional();
            Property(product => product.UnitsInStock).IsOptional();

            HasRequired(product => product.Category)
                .WithMany(category => category.Products)
                .HasForeignKey(product => product.CategoryID)
                .WillCascadeOnDelete(false);

            HasMany(product => product.OrderDetails)
                .WithRequired(od => od.Product)
                .HasForeignKey(od => od.ProductID)
                .WillCascadeOnDelete(false);

        }
    }
}
