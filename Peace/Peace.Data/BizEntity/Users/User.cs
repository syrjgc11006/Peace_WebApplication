using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Peace.Data
{
    [Serializable]
    public sealed partial class User : BaseEntity<int>
    {
        public User()
        {
            this.Addresses = new List<Address>();
            this.UserRoles = new List<UserRole>();
        }

        public System.Guid UserGuid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public int PasswordFormatId { get; set; }
        public string PasswordSalt { get; set; }
        public string RealName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public bool IsSystemAccount { get; set; }
        public string SystemName { get; set; }
        public string LastIpAddress { get; set; }

        public Nullable<DateTime> LastLoginDateUtc { get; set; }
        public DateTime LastActivityDateUtc { get; set; }

        public DateTime? ModifyTime { get; set; }
        public Nullable<int> UserRole_Id { get; set; }
        public string ImgUrl { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public UserRole UserRole { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
