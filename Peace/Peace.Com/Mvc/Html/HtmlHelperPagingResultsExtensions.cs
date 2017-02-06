using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Peace.Com.Mvc
{
    public static class HtmlHelperPagingResultsExtensions
    {
        /// <summary>
        /// 生成分页统计结果
        /// </summary>
        /// <param name="htmlHelper">被扩展的HtmlHelper实例</param>
        /// <param name="pagingDataSet">分页集合</param>
        /// <returns></returns>
        public static MvcHtmlString PagingResults(this HtmlHelper htmlHelper, Pager pagingDataSet)
        {
            string pagerResult = "<div class=\"l-btns\">";

            TagBuilder builder = new TagBuilder("span");
            builder.AddCssClass("tn-page-results tn-text-note");
            long startCount = (pagingDataSet.PageIndex - 1) * pagingDataSet.PageSize + 1;
            long endCount = pagingDataSet.PageIndex * pagingDataSet.PageSize;
            if (endCount > pagingDataSet.RecordCount)
                endCount = pagingDataSet.RecordCount;
            builder.SetInnerText(string.Format("{0}-{1} 共{2}", startCount, endCount, pagingDataSet.RecordCount));
            pagerResult += builder.ToString() + "</div>";

            return MvcHtmlString.Create(pagerResult);
        }
    }
}
