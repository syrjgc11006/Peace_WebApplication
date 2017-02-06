using System;
using System.Collections.Generic;

namespace Peace.Data
{
    /// <summary>
    /// 内容分类
    /// </summary>
    public partial class pl_article_category : BaseEntity<int>
    {
        /// 频道ID
        /// </summary>
        public int channel_id { get; set; }

        /// <summary>
        /// 类别标题
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 调用别名
        /// </summary>
        public string call_index { get; set; }

        /// <summary>
        /// 父类别ID
        /// </summary>
        public Nullable<int> parent_id { get; set; }
        /// <summary>
        /// 类别ID列表(逗号分隔开)
        /// </summary>
        public string class_list { get; set; }
        /// <summary>
        /// 类别深度
        /// </summary>
        public Nullable<int> class_layer { get; set; }
        /// <summary>
        /// 排序数字
        /// </summary>
        public Nullable<int> sort_id { get; set; }
       
        /// <summary>
        /// URL跳转地址
        /// </summary>
        public string link_url { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string img_url { get; set; }

        /// <summary>
        /// 备注说明
        /// </summary>
        public string content { get; set; }

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
    }
}
