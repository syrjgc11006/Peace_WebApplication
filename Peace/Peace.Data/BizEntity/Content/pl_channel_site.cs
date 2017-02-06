using System;
using System.Collections.Generic;

namespace Peace.Data
{
    /// <summary>
    /// 频道分类
    /// </summary>
    public partial class pl_channel_site : BaseEntity<int>
    {
        public pl_channel_site()
        {
            this.pl_channel = new List<pl_channel>();
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 生成目录名
        /// </summary>
        public string build_path { get; set; }

        /// <summary>
        /// 模板目录名
        /// </summary>
        public string templet_path { get; set; }

        /// <summary>
        /// 绑定域名
        /// </summary>
        public string domain { get; set; }
        /// <summary>
        /// 网站名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 网站LOGO
        /// </summary>
        public string logo { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string company { get; set; }

        /// <summary>
        /// 通讯地址
        /// </summary>
        public string address { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string tel { get; set; }

        /// <summary>
        /// 传真号码
        /// </summary>
        public string fax { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// 备案号
        /// </summary>
        public string crod { get; set; }

        /// <summary>
        /// 版权信息
        /// </summary>
        public string copyright { get; set; }
        /// <summary>
        /// SEO标题
        /// </summary>
        public string seo_title { get; set; }

        /// <summary>
        /// SEO关健字
        /// </summary>
        public string seo_keyword { get; set; }

        /// <summary>
        /// SEO描述
        /// </summary>
        public string seo_description { get; set; }

        /// <summary>
        /// 是否移动站
        /// </summary>
        public Nullable<byte> is_mobile { get; set; }

        /// <summary>
        /// 是否默认
        /// </summary>
        public Nullable<byte> is_default { get; set; }

        /// <summary>
        /// 排序数字
        /// </summary>
        public Nullable<int> sort_id { get; set; }
        public virtual ICollection<pl_channel> pl_channel { get; set; }
    }
}
