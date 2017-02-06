using System;
using System.Collections.Generic;

namespace Peace.Data
{
    /// <summary>
    /// 管理员信息表
    /// </summary>
    public partial class pl_manager : BaseEntity<int>
    {
        /// <summary>
        ///角色ID
        /// </summary>
        public Nullable<int> role_id { get; set; }

        /// <summary>
        /// 管理员类型1超管2系管（默认：2）
        /// </summary>
        public Nullable<int> role_type { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string user_name { get; set; }

        /// <summary>
        ///登录密码 
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// 6位随机字符串,加密用到
        /// </summary>
        public string salt { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string real_name { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string telephone { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// 是否锁定
        /// </summary>
        public Nullable<int> is_lock { get; set; }
        public Nullable<System.DateTime> add_time { get; set; }
        public virtual pl_manager_role pl_manager_role { get; set; }
    }
}
