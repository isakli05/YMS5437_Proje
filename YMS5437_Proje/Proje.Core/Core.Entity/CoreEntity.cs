using Proje.Core.Core.Entity.Enum;
using System;
namespace Proje.Core.Core.Entity
{
    public class CoreEntity:IEntity<Guid>
    {
        //Burası tüm entitylerin ortak özelliklerinin belirtileceği yerdir.

        public Guid ID { get; set; }
        public Status Status{ get; set; }


        //Alttakiler loglama amaçlı propertyler'dir.

        //EKLEME ANI ÖZELLİKLERİ
        public string CreatedComputerName { get; set; }
        public string CreatedIp { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedADUserName { get; set; }


        //GÜNCELLEME ANI ÖZELLİKLERİ
        public string ModifiedComputerName { get; set; }
        public string ModifiedIp { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedADUserName { get; set; }

    }
}
