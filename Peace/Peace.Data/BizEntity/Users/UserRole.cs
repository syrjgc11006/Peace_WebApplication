using System;
using System.Collections.Generic;

namespace Peace.Data
{
    public sealed partial class UserRole:BaseEntity<int>
    {
        public UserRole()
        {
            this.Users = new List<User>();
            this.PermissionRecords = new List<PermissionRecord>();
            this.Users1 = new List<User>();
        }

        public string Name { get; set; }
        public bool FreeShipping { get; set; }
        public bool TaxExempt { get; set; }
        public bool Active { get; set; }
        public bool IsSystemRole { get; set; }
        public string SystemName { get; set; }
        public int PurchasedWithProductId { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<PermissionRecord> PermissionRecords { get; set; }
        public ICollection<User> Users1 { get; set; }
    }
}
