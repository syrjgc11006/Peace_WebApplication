using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.WebPages;

namespace Peace.WebRepeater
{
    public static class RepeaterExtensions
    {
        public static MvcHtmlString Repeater(this HtmlHelper htmlHelper)
        {
            return htmlHelper.Partial("_Repeater", new RepeaterFormData());
        }

        /// <summary>
        /// 根据指定的分页数据源创建一个分页的Repeater控件
        /// </summary>
        /// <param name="htmlHelper">HTML帮助类</param>
        /// <param name="formData">Repeater的配置对象</param>
        /// <returns>分页的Html结果以相关前台脚本</returns>
        public static MvcHtmlString Repeater(this HtmlHelper htmlHelper,
            RepeaterFormData formData)
        {
            return htmlHelper.Partial("_Repeater", formData);
        }

        /// <summary>
        /// 生成Base_Article的扩展属性Exts集合的表单录入区域
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="renderEvent">包含回调委托的包装对象</param>
        /// <returns>Html的录入表单区域</returns>
        //public static MvcHtmlString ExtsEditor(this HtmlHelper<Base_Article> htmlHelper, ExtRenderEvent renderEvent = null)
        //{
        //    htmlHelper.ViewDataContainer.ViewData["ExtRenderEvent"] = renderEvent;
        //    return htmlHelper.EditorFor(a => a.Exts);
        //}

        /// <summary>
        /// 生成Base_Article的关联文章属性TargetArticles集合的表单录入区域
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="article">Base_Article 文章对象</param>
        /// <param name="itemCatalogId">Base_Article 文章所在栏目ID</param>
        /// <returns></returns>
        //public static MvcHtmlString TargetsEditor(this HtmlHelper<Base_Article> htmlHelper, int itemCatalogId)
        //{
        //    htmlHelper.ViewDataContainer.ViewData["ItemCatalogId"] = itemCatalogId;
        //    return htmlHelper.Partial("_TargetsEditer");
        //}

        /// <summary>
        /// 生成Base_Article的扩展属性Exts集合的数据显示区域
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="renderEvent">包含回调委托的包装对象</param>
        /// <returns>Html结果显示区域</returns>
        //public static MvcHtmlString ExtDisplay(this HtmlHelper<Base_Article> htmlHelper, ExtRenderEvent renderEvent = null)
        //{
        //    htmlHelper.ViewDataContainer.ViewData["ExtRenderEvent"] = renderEvent;
        //    return htmlHelper.DisplayFor(a => a.Exts);
        //}

        /// <summary>
        /// 生成Base_Article的扩展属性Exts集合的表单录入区域
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="onExtRendered">扩展展性录入区生成后的回调</param>
        /// <returns>Html结果</returns>
        //public static MvcHtmlString ExtsEditor(this HtmlHelper<Base_Article> htmlHelper, Func<HtmlHelper<Base_ArticleExt>, HelperResult> onExtRendered)
        //{
        //    htmlHelper.ViewDataContainer.ViewData["ExtRenderEvent"] = new ExtRenderEvent
        //    {
        //        OnExtRendered = onExtRendered
        //    };
        //    return htmlHelper.EditorFor(a => a.Exts);
        //}
    }
}