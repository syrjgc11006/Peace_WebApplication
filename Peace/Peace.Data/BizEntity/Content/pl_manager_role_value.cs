using System;
using System.Collections.Generic;

namespace Peace.Data
{
    /// <summary>
    /// 管理角色权限表（多表，不会针对此单独进行增删改查）
    /// </summary>
    public partial class pl_manager_role_value
    {
        public int id { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public Nullable<int> role_id { get; set; }

        /// <summary>
        /// 导航名称
        /// </summary>
        public string nav_name { get; set; }

        /// <summary>
        /// 权限类型
        /// </summary>
        public string action_type { get; set; }
        public virtual pl_manager_role pl_manager_role { get; set; }
    }
}
