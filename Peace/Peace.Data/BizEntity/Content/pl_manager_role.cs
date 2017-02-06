using System;
using System.Collections.Generic;

namespace Peace.Data
{
    /// <summary>
    /// 管理角色表
    /// </summary>
    public partial class pl_manager_role : BaseEntity<int>
    {
        public pl_manager_role()
        {
            this.pl_manager = new List<pl_manager>();
            this.pl_manager_role_value = new List<pl_manager_role_value>();
        }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string role_name { get; set; }

        /// <summary>
        /// 角色类型
        /// </summary>
        public Nullable<byte> role_type { get; set; }

        /// <summary>
        /// 是否系统默认0否1是
        /// </summary>
        public Nullable<byte> is_sys { get; set; }
        public virtual ICollection<pl_manager> pl_manager { get; set; }
        public virtual ICollection<pl_manager_role_value> pl_manager_role_value { get; set; }
    }
}
