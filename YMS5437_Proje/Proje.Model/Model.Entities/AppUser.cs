using Proje.Core.Core.Entity;
using System;
using System.Collections.Generic;


namespace Proje.Model.Model.Entities
{
    public enum Role
    {
        None = 0,
        Member = 1,
        Admin = 3
    }
    public class AppUser : CoreEntity
    {
        public AppUser()
        {
            Orders = new HashSet<Order>();
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}