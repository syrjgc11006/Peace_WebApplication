using System;
using System.Collections.Generic;

namespace Peace.Data
{
    /// <summary>
    /// 扩展属性值表
    /// </summary>
    public partial class pl_article_attribute_value
    {
        public int article_id { get; set; }
        public string sub_title { get; set; }
        public string source { get; set; }
        public string author { get; set; }
        public string goods_no { get; set; }
        public Nullable<int> stock_quantity { get; set; }
        public Nullable<decimal> market_price { get; set; }
        public Nullable<decimal> sell_price { get; set; }
        public Nullable<int> point { get; set; }
        public string video_src { get; set; }
        public virtual pl_article pl_article { get; set; }
    }
}
