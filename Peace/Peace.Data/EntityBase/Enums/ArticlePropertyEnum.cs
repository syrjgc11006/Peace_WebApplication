using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Peace.Data.EntityBase.Enums
{
    public enum ArticlePropertyEnum
    {
        [Description("待审核")]
        IsLock,
        [Description("已审核")]
        UnIsLock,
        [Description("可评论")]
        IsMsg,
        [Description("置顶")]
        IsTop,
        [Description("推荐")]
        IsRed,
        [Description("热门")]
        IsHot,
        [Description("幻灯片")]
        IsSlide
    }
}
