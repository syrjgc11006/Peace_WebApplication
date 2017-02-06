using System;
using System.Collections.Generic;

namespace Peace.Data
{
    /// <summary>
    /// 附件表
    /// </summary>
    public partial class pl_article_attach : BaseEntity<int>
    {
        /// <summary>
        /// 文章ID
        /// </summary>
        public Nullable<int> article_id { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        public string file_name { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string file_path { get; set; }

        /// <summary>
        /// 文件大小(字节)
        /// </summary>
        public Nullable<int> file_size { get; set; }

        /// <summary>
        /// 文件扩展名
        /// </summary>
        public string file_ext { get; set; }
        /// <summary>
        /// 下载次数
        /// </summary>
        public Nullable<int> down_num { get; set; }

        /// <summary>
        /// 积分(正:赠送;负:消费)
        /// </summary>
        public Nullable<int> point { get; set; }
    }
}
