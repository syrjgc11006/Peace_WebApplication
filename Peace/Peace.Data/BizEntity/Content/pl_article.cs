using System;
using System.Collections.Generic;

namespace Peace.Data
{
    /// <summary>
    /// 内容管理表
    /// </summary>
    public partial class pl_article:BaseEntity<int>
    {
        /// <summary>
        /// 频道ID
        /// </summary>
        public int channel_id { get; set; }
        /// <summary>
        /// 类别ID
        /// </summary>
        public int category_id { get; set; }

        /// <summary>
        /// 调用别名
        /// </summary>
        public string call_index { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 外部链接
        /// </summary>
        public string link_url { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string img_url { get; set; }
        /// <summary>
        /// SEO标题
        /// </summary>
        public string seo_title { get; set; }
        /// <summary>
        /// SEO关健字
        /// </summary>
        public string seo_keywords { get; set; }
        /// <summary>
        /// SEO描述
        /// </summary>
        public string seo_description { get; set; }
        /// <summary>
        /// TAG标签逗号分隔
        /// </summary>
        public string tags { get; set; }

        /// <summary>
        /// 内容摘要
        /// </summary>
        public string zhaiyao { get; set; }

        /// <summary>
        /// 详细内容
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public Nullable<int> sort_id { get; set; }
        /// <summary>
        /// 浏览次数
        /// </summary>
        public Nullable<int> click { get; set; }
        /// <summary>
        /// 状态0正常1未审核2锁定
        /// </summary>
        public Nullable<byte> status { get; set; }
        /// <summary>
        /// 是否允许评论
        /// </summary>
        public Nullable<byte> is_msg { get; set; }
        /// <summary>
        /// 是否置顶
        /// </summary>
        public Nullable<byte> is_top { get; set; }
        /// <summary>
        /// 是否推荐
        /// </summary>
        public Nullable<byte> is_red { get; set; }
        /// <summary>
        /// 是否热门
        /// </summary>
        public Nullable<byte> is_hot { get; set; }
        /// <summary>
        /// 是否幻灯片
        /// </summary>
        public Nullable<byte> is_slide { get; set; }
        /// <summary>
        /// 是否管理员发布0不是1是
        /// </summary>
        public Nullable<byte> is_sys { get; set; }

        public virtual pl_article_attribute_value pl_article_attribute_value { get; set; }
    }
}
