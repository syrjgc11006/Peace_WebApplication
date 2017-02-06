using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Peace.Data;
using System.Web.Mvc;
using Peace.Core;

namespace Peace.Model.ViewModels.Article
{
    public class ArticleExtentionModel
    {
        public ArticleExtentionModel()
        {
            this.MoveCategories = new List<SelectListItem>();
            this.AllCategories = new List<SelectListItem>();
            this.ArtcleProperties = new List<SelectListItem>();
        }
      
        /// <summary>
        /// 文章所有类别
        /// </summary>
        public List<SelectListItem> MoveCategories { get; set; }

        /// <summary>
        /// 文章所有类别
        /// </summary>
        public List<SelectListItem> AllCategories { get; set; }

        /// <summary>
        /// 文章所有属性
        /// </summary>
        public List<SelectListItem> ArtcleProperties { get; set; }

    }
}
