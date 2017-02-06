using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Peace.Model.ViewModels
{
    public class PageModel
    {
        public int CatalogId { get; set; }

        /// <summary>
        /// 页号
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 和PageIndex相同
        /// </summary>
        public int Page { get { return PageIndex; } set { PageIndex = value; } }

        /// <summary>
        /// 页的大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 排序方向， asc或desc
        /// </summary>
        public string SortOrder { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string SortField { get; set; }

        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 高级查询的条件表达式树Json字符串
        /// </summary>
        public string AdvQuery { get; set; }

        public string SortExpression
        {
            get { return SortField + " " + SortOrder; }
        }

        public PageModel()
        {
            //SortField = "Id";
            //SortOrder = "DESC";
            PageSize = 10;
            PageIndex = 1;
        }
    }
}
