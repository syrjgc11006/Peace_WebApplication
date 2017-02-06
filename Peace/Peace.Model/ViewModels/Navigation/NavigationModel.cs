using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Peace.Model.ViewModels
{
    public class NavigationModel
    {
        /// <summary>
        /// 菜单Id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 所属父导航ID
        /// </summary>
        public Nullable<int> parent_id { get; set; }

        /// <summary>
        /// 所属频道ID
        /// </summary>
        public Nullable<int> channel_id { get; set; }

        /// <summary>
        /// 层级，深度字段
        /// </summary>
        public int class_layer { get; set; }

        /// <summary>
        /// 导航类别
        /// </summary>
        public string nav_type { get; set; }

        /// <summary>
        /// 导航名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 副标题
        /// </summary>
        public string sub_title { get; set; }

        /// <summary>
        ///    图标地址 
        /// </summary>
        public string icon_url { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        public string link_url { get; set; }

        /// <summary>
        /// 排序数字
        /// </summary>
        public Nullable<int> sort_id { get; set; }

        /// <summary>
        /// 是否隐藏0显示1隐藏
        /// </summary>
        public Nullable<byte> is_lock { get; set; }

        /// <summary>
        /// 备注说明
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 权限资源
        /// </summary>
        public string action_type { get; set; }

        /// <summary>
        /// 系统默认
        /// </summary>
        public Nullable<byte> is_sys { get; set; }
    }
}
