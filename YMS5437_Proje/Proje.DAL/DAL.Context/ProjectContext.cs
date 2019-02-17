using Proje.Core.Core.Entity;
using Proje.Map.Map.EntityMaps;
using Proje.Model.Model.Entities;
using Proje.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DAL.DAL.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = @"server=.;database=YMS5437_Proje;uid=sa;pwd=123;";
        }

        //Map sınıflarımızı da context'e dahil edebilmek için modellerin(entitiylerin) oluşma anında çalışacak olan OnModelCreating metodunu yani modelleri tabloya dönüştüren metodu override ederek çağırıyoruz, db kurallarımızı da dahil etmesini sağlıyoruz.

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Model oluşturucunun ayarlarına ekle :)
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new ProductMap());

            base.OnModelCreating(modelBuilder);
        }

        //DbSetleri oluşturmazsak tablolar oluşmaz.

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        //Değişiklikleri har kaydetme metodunu çağırdığımda otomatik loglama işlemleri gerçekleşsin
        //https://www.tutorialsteacher.com/ioc
        public override int SaveChanges()
        {
            //Yeni eklenen veya yeni güncellenen kayıtları yakalıyoruz. IEntityChangeTracker isimli interface sayesinde kendisi yapılan değişimleri izler. Bu özellik sayesinde kendi tuttuğu EntityState(Status Enum Gibi) üzerinden yakalama şansına sahip oluruz.

            var modifiedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            string identity = WindowsIdentity.GetCurrent().Name;
            string computerName = Environment.MachineName;
            DateTime date = DateTime.UtcNow;
            //IP Yakalama Utility içerisine atılacak.
            string ip = RemoteIP.IpAddress;

            foreach (var item in modifiedEntries)
            {
                //Tüm yeni eklenen/güncellenen kayıtları sırayla alıyorum. Hepsinin ortak tipi CoreEntity'dir.
                CoreEntity entity = item.Entity as CoreEntity;
                if (item != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        entity.Status = Core.Core.Entity.Enum.Status.Active;
                        entity.CreatedADUserName = identity;
                        entity.CreatedComputerName = computerName;
                        entity.CreatedDate = date;
                        entity.CreatedIp = ip;
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        entity.ModifiedADUserName = identity;
                        entity.ModifiedComputerName = computerName;
                        entity.ModifiedDate = date;
                        entity.ModifiedIp = ip;
                    }
                }
            }

            return base.SaveChanges();
        }


    }
}
