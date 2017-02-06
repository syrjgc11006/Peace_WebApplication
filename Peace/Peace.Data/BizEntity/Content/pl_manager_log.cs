using System;
using System.Collections.Generic;

namespace Peace.Data
{
    /// <summary>
    /// 管理日志表
    /// </summary>
    public partial class pl_manager_log : BaseEntity<int>
    {
        /// <summary>
        ///操作类型
        /// </summary>
        public string action_type { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 用户IP
        /// </summary>
        public string user_ip { get; set; }
    }
}
