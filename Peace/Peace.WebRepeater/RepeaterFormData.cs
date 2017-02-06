
using Peace.Com;
using Peace.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace Peace.WebRepeater
{
    public class RepeaterFormData
    {
        public string Id { get; set; }

        public bool ShowCheckBox { get; set; }

        public bool ShowNumberPager { get; set; }

        public bool ShowMore { get; set; }

        public Pager Pager { get; set; }

        public ICollection<TableField> Fields { get; set; }

        public string KeyField { get; set; }

        public Func<object, HelperResult> ItemTemplate { get; set; }

        public Func<HelperResult> HeaderTemplate { get; set; }

        public Func<HelperResult> FooterTemplate { get; set; }

        public Func<HelperResult> PagerTemplate { get; set; }

        public bool ShowFocusRowStyle { get; set; }
        
        public RepeaterFormData()
        {
            KeyField = "Id";
            ShowNumberPager = true;
            ShowMore = true;
            ShowFocusRowStyle = true;
        }
    }

    public class TableField
    {
        public TableField()
        {
            Sortable = true;
        }
        
        public string FieldName { get; set; }

        public string Caption { get; set; }

        public int Width { get; set; }

        public bool Sortable { get; set; }
    }
}