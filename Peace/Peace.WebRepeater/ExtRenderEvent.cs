using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Peace.WebRepeater
{
    /// <summary>
    /// 在扩展属性集生成表单录入区时，单个属性生成控件后调用的委托
    /// 这有助于在属性控件后添加自定义内容
    /// </summary>
    public class ExtRenderEvent
    {
        /// <summary>
        /// 用户自定义单个属性生成控件的委托
        /// </summary>
        //public Func<HtmlHelper<Base_ArticleExt>, HelperResult> UserRenderer { get; set; }
        
        /// <summary>
        /// 单个属性生成控件后调用的委托
        /// </summary>
        //public Func<HtmlHelper<Base_ArticleExt>, HelperResult> OnExtRendered { get; set; }

        /// <summary>
        /// 是否以紧凑格式生成（所有录入项在一行内）默认为false
        /// </summary>
        public bool Inline { get; set; }
    }
}