using Proje.Core.Core.Map;
using Proje.Model.Model.Entities;


namespace Proje.Map.Map.EntityMaps
{
    public class CategoryMap:CoreMap<Category>
    {
        public CategoryMap()
        {
            ToTable("dbo.Categories");

            HasMany(category => category.Products)
                .WithRequired(product => product.Category)
                .HasForeignKey(product => product.CategoryID)
                .WillCascadeOnDelete(false);
        }
    }
}
