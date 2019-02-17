using Proje.Model.Model.Entities;
using Proje.Service.Service.Abstract;
using System.Collections.Generic;

namespace Proje.Service.Service.Concrete
{
    public class AppUserService : BaseService<AppUser>
    {
        public bool CheckCredentials(string email, string password) => Any(x => x.Email == email && x.Password == password);


        public AppUser FindByEmail(string email) => GetByDefault(x => x.Email == email);

        public int MemberCount() => GetDefault(x => (x.Status==Core.Core.Entity.Enum.Status.Active || x.Status==Core.Core.Entity.Enum.Status.Updated)&&x.Role==Role.Member).Count;

        public List<AppUser> GetLastEntries(int entryCount)
        {
            return GetLastEntries((x => x.Status == Core.Core.Entity.Enum.Status.Active || x.Status == Core.Core.Entity.Enum.Status.Updated), entryCount);
        }
        

    }
}
