using Proje.Core.Core.Map;
using Proje.Model.Model.Entities;


namespace Proje.Map.Map.EntityMaps
{
    public class AppUserMap:CoreMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("dbo.Users");
            Property(user => user.Role).IsOptional();
            Property(user => user.BirthDate).HasColumnType("datetime2").IsOptional();

            Property(user => user.UserName).IsRequired();
            Property(user => user.Password).IsRequired();

        }
    }
}
