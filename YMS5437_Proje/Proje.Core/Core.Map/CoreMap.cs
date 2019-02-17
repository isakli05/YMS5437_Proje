using Proje.Core.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proje.Core.Core.Map
{
    //Core Entity tüm entity sınıflarına miras verecek sınıftır. Şu an yaptığımız ise tüm map sınıflarına yani tüm db kurallarına sahip entity sınıflarının ortak map sınıfını yaratmaktır. Aynı zamanda da Core Entity özelliklerinin burada db kurallarını da oluşturuyoruz.

    //Nasıl core entity tüm entity sınflarına miras veriyorsa, coremapte tüm map sınıflarına miras verecektir.
    public class CoreMap<T> : EntityTypeConfiguration<T> where T : CoreEntity
    {
        //Constructor
        public CoreMap()
        {
            Property(core => core.ID).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnOrder(1);
            Property(core => core.Status).IsOptional();

            //Ekleme özelliklerinin mapleri
            Property(core => core.CreatedDate).HasColumnType("datetime2").IsOptional();
            Property(core => core.CreatedADUserName).IsOptional();
            Property(core => core.CreatedBy).IsOptional();
            Property(core => core.CreatedComputerName).IsOptional();
            Property(core => core.CreatedIp).IsOptional();


            //Güncelleme özelliklerinin mapleri
            Property(core => core.ModifiedDate).HasColumnType("datetime2").IsOptional();
            Property(core => core.ModifiedADUserName).IsOptional();
            Property(core => core.ModifiedBy).IsOptional();
            Property(core => core.ModifiedComputerName).IsOptional();
            Property(core => core.ModifiedIp).IsOptional();

        }
    }
}
