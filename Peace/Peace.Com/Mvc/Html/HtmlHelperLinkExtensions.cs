using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace Peace.Com.Mvc
{
    /// <summary>
    /// 扩展对Link的HtmlHelper使用方法
    /// </summary>
    public static class HtmlHelperLinkExtensions
    {
        /// <summary>
        /// 生成链接标签
        /// </summary>
        /// <param name="htmlHelper">被扩展的HtmlHelper实例</param>
        /// <param name="text">链接文本</param>
        /// <param name="url">链接地址</param>
        /// <param name="title">链接提示文字（必填）</param>
        /// <param name="htmlAttributes">链接的其他属性集合</param>
        /// <param name="navigateTarget">头衔图片链接的Target</param>
        /// <returns></returns>
        public static MvcHtmlString Link(this HtmlHelper htmlHelper, string text, string url, string title, object htmlAttributes = null, HyperLinkTarget navigateTarget = HyperLinkTarget._self)
        {
            if (string.IsNullOrEmpty(text))
                return MvcHtmlString.Empty;

            //if (string.IsNullOrEmpty(title))
            //{
            //    throw new ExceptionFacade("参数名称title不能为空");
            //}

            if (string.IsNullOrEmpty(url))
            {
                url = "javascript:void(0)";
            }

            TagBuilder builder = new TagBuilder("a");
            builder.MergeAttribute("href", url);
            builder.SetInnerText(text);
            builder.MergeAttribute("title", title);
            if (navigateTarget != HyperLinkTarget._self)
                builder.MergeAttribute("target", navigateTarget.ToString());
            if (htmlAttributes != null)
                builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return MvcHtmlString.Create(builder.ToString());
        }

        /// <summary>
        /// 超级链接Target
        /// </summary>
        public enum HyperLinkTarget
        {
            /// <summary>
            /// 将内容呈现在一个没有框架的新窗口中
            /// </summary>
            _blank,

            /// <summary>
            /// 将内容呈现在含焦点的框架中
            /// </summary>
            _self,

            /// <summary>
            /// 将内容呈现在上一个框架集父级中
            /// </summary>
            _parent,

            /// <summary>
            /// 将内容呈现在没有框架的全窗口中
            /// </summary>
            _top

        }
    }
}
