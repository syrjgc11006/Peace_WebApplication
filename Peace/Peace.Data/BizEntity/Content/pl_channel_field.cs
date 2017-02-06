using System;
using System.Collections.Generic;

namespace Peace.Data
{
    /// <summary>
    /// 频道属性表
    /// </summary>
    public partial class pl_channel_field : BaseEntity<int>
    {
        /// <summary>
        /// 频道ID
        /// </summary>
        public Nullable<int> channel_id { get; set; }

        /// <summary>
        /// 字段ID
        /// </summary>
        public Nullable<int> field_id { get; set; }
    }
}
