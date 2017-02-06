using System;
using System.Collections.Generic;

namespace Peace.Data
{
    /// <summary>
    /// 系统频道表
    /// </summary>
    public partial class pl_channel : BaseEntity<int>
    {
        /// <summary>
        ///    //站点Id
        /// </summary>
        public Nullable<int> site_id { get; set; }
        /// <summary>
        ///  //频道名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 频道标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 是否开启相册功能（首页幻灯片展示，是否将该篇文档作为幻灯片展示）
        /// </summary>
        public Nullable<byte> is_albums { get; set; }
        /// <summary>
        /// 是否开启附件功能
        /// </summary>
        public Nullable<byte> is_attach { get; set; }
        /// <summary>
        /// 是否开启规格
        /// </summary>
        public Nullable<byte> is_spec { get; set; }

        /// <summary>
        /// 排序数字
        /// </summary>
        public Nullable<int> sort_id { get; set; }
        public virtual pl_channel_site pl_channel_site { get; set; }
    }
}
