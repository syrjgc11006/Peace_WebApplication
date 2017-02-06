using System;
using System.Collections.Generic;

namespace Peace.Data
{
    public partial class PermissionRecord:BaseEntity<int>
    {
        public PermissionRecord()
        {
            this.UserRoles = new List<UserRole>();
        }

        public string Name { get; set; }
        public string SystemName { get; set; }
        public string Category { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
