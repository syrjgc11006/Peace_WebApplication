using System;
using System.Collections.Generic;

namespace Peace.Data
{
    /// <summary>
    /// 扩展属性表
    /// </summary>
    public partial class pl_article_attribute_field : BaseEntity<int>
    {
        /// <summary>
        /// 列名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 控件类型
        /// </summary>
        public string control_type { get; set; }

        /// <summary>
        /// 字段类型
        /// </summary>
        public string data_type { get; set; }

        /// <summary>
        /// 字段长度
        /// </summary>
        public Nullable<int> data_length { get; set; }


        /// <summary>
        /// 小数点位数
        /// </summary>
        public Nullable<byte> data_place { get; set; }

        /// <summary>
        /// 选项列表
        /// </summary>
        public string item_option { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string default_value { get; set; }

        /// <summary>
        /// 是否必填0非必填1必填
        /// </summary>
        public Nullable<byte> is_required { get; set; }

        /// <summary>
        /// 是否密码框
        /// </summary>
        public Nullable<byte> is_password { get; set; }

        /// <summary>
        /// 是否允许HTML
        /// </summary>
        public Nullable<byte> is_html { get; set; }

        /// <summary>
        /// 编辑器类型;0:标准型  1:简洁型
        /// </summary>
        public Nullable<byte> editor_type { get; set; }

        /// <summary>
        /// 验证提示信息
        /// </summary>
        public string valid_tip_msg { get; set; }

        /// <summary>
        /// 验证失败提示信息
        /// </summary>
        public string valid_error_msg { get; set; }

        /// <summary>
        /// 验证正则表达式
        /// </summary>
        public string valid_pattern { get; set; }

        /// <summary>
        /// 排序数字
        /// </summary>
        public Nullable<int> sort_id { get; set; }

        /// <summary>
        /// 系统默认
        /// </summary>
        public Nullable<byte> is_sys { get; set; }
    }
}
