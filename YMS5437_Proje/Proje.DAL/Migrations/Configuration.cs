namespace Proje.DAL.Migrations
{
    using Proje.Model.Model.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Proje.DAL.DAL.Context.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Proje.DAL.DAL.Context.ProjectContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            List<AppUser> defaultUsers = new List<AppUser>();

            defaultUsers.Add(new AppUser {
                Name = "Keith D.",
                LastName = "Hough",
                Address = "Corpus Christi, Texas(TX), 78476",
                PhoneNumber = "682-201-6771",
                BirthDate = new DateTime(1973,1,22),
                Email= "keithd.2000@yahoo.com",
                CreatedComputerName= "DESKTOP/Keith-Desktop",
                CreatedDate=DateTime.Now,
                ImagePath= "/Uploads/Keith.jpg",
                CreatedIp="10.0.0.1",
                CreatedADUserName="Keith-Desktop",
                Role=Role.Admin,
                Status=Core.Core.Entity.Enum.Status.Active,
                UserName= "admin",
                Password= "123"
            });


            context.Users.AddRange(defaultUsers);
            base.Seed(context);
        }
    }
}
