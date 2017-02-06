using Peace.Service.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peace.Com;
using Peace.Com.Tools;
using Peace.Data;
using Peace.Model.ViewModels.Article;
using System.Reflection;
using System.ComponentModel;
using Peace.Data.EntityBase.Enums;
using Peace.Core;
using Peace.Service.Comment;

namespace Peace.Admin.Controllers
{
    public class ArticleController : BaseAdminController
    {
        //
        // GET: /Article/

        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;

        #region Constructor
        public ArticleController(IArticleService articleService, ICommentService commentService)
        {
            _articleService = articleService;
            _commentService = commentService;
        }

        #endregion

        #region Utils

        /// <summary>
        /// 获取移动类别
        /// </summary>
        /// <returns></returns>
        public List<pl_article_category> GetMoveCategory(string channel_id)
        {
            var chanelId = Request.Params["channel_id"];
            if (!string.IsNullOrEmpty(chanelId))
            {
                var data = _articleService.GetCategory(0, CommOp.ToInt(chanelId));
                return data;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取文章的所有属性
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public List<SelectListItem> GetArticleProperties(Type enumType)
        {
            List<SelectListItem> articleProperties = new List<SelectListItem> { new SelectListItem
            {
                Text="所有属性",Value="",Selected=true
            }};
            if (enumType.IsEnum == false)
            {
                return null;
            }
            FieldInfo[] fields = enumType.GetFields();
            foreach (FieldInfo field in fields)
            {
                if (field.IsSpecialName) continue;  //一定要加这一句，调试发现，枚举会多出一个 _int32的值
                if (field != null)
                {
                    // 获取描述的属性。
                    DescriptionAttribute attr = Attribute.GetCustomAttribute(field,
                        typeof(DescriptionAttribute), false) as DescriptionAttribute;
                    articleProperties.Add(new SelectListItem
                    {
                        Text = attr.Description,
                        Value = field.Name
                    });
                }
            }
            return articleProperties;
        }


        /// <summary>
        /// 通过类别Id获取类别对象
        /// </summary>
        /// <param name="catoryId"></param>
        /// <returns></returns>
        public pl_article_category GetCategoryById(int categoryId)
        {
            return _articleService.GetCategoryById(categoryId);
        }

        /// <summary>
        /// 获取文章扩展属性
        /// </summary>
        /// <returns></returns>
        private ArticleExtentionModel GetArticleExtionModel(string channel_id)
        {
            ArticleExtentionModel artclemodel = new ArticleExtentionModel();
            var articleCategorys = this.GetMoveCategory(channel_id);

            //1.文章类别
            if (articleCategorys.Count > 0)
            {
                artclemodel.MoveCategories.Add(new SelectListItem
                {
                    Text = "批量移动...",
                    Value = ""
                });

                artclemodel.AllCategories.Add(new SelectListItem
                {
                    Text = "所有类别",
                    Value = ""
                });
                foreach (var item in articleCategorys)
                {
                    int classLayer = item.class_layer.ToInt();
                    string Title = item.title.ToString().Trim();
                    if (classLayer == 1)
                    {
                        artclemodel.MoveCategories.Add(new SelectListItem
                        {
                            Text = item.title,
                            Value = item.id.ToString()
                        });
                        artclemodel.AllCategories.Add(new SelectListItem
                        {
                            Text = item.title,
                            Value = item.id.ToString()
                        });
                    }
                    else
                    {
                        Title = "├ " + Title;
                        Title = Utils.StringOfChar(classLayer - 1, "　") + Title;
                        artclemodel.MoveCategories.Add(new SelectListItem
                        {
                            Text = Title,
                            Value = item.id.ToString()
                        });
                        artclemodel.AllCategories.Add(new SelectListItem
                        {
                            Text = Title,
                            Value = item.id.ToString()
                        });
                    }
                }
            }
            //2.文章属性
            artclemodel.ArtcleProperties = this.GetArticleProperties(typeof(ArticlePropertyEnum));
            return artclemodel;
        }

        #endregion

        #region Method

        /// <summary>
        /// 文章列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var pageIndex = Request.Params["pageIndex"];
            var channelid = Request.Params["channel_id"];
            var keyword = Request.Params["txtKeywords"];
            var viewTypeStr = Utils.GetCookie("article_list_view"); //显示方式
            var chanelId = Request.Params["channel_id"];
            int page = 0;
            ArticleExtentionModel artclemodel = GetArticleExtionModel(chanelId);
            ViewBag.MoveCategories = artclemodel.MoveCategories;
            ViewBag.AllCategories = artclemodel.AllCategories;
            ViewBag.ArtcleProperties = artclemodel.ArtcleProperties;
            if (string.IsNullOrEmpty(viewTypeStr) || viewTypeStr == "Txt")
            {
                ViewBag.isLisView = true;
            }
            else
            {
                ViewBag.isLisView = false;
            }

            if (string.IsNullOrEmpty(pageIndex))
            {
                page = 1;
            }
            else
            {
                page = int.Parse(pageIndex);
            }
            var data = _articleService.GetPagerArticle(keyword, channelid, page, 10, " id asc, title desc ");
            return View(data);
        }

        /// <summary>
        /// 文章类别
        /// </summary>
        /// <returns></returns>
        public ActionResult ArticleCategory()
        {
            var chanelId = Request.Params["channel_id"];
            var articleCategorys = this.GetMoveCategory(chanelId);
            return View(articleCategorys);
        }

        /// <summary>
        /// 文章评论
        /// </summary>
        /// <returns></returns>
        public ActionResult Comment()
        {
            var pageIndex = Request.Params["pageIndex"];
            var channelid = Request.Params["channel_id"];
            var keyword = Request.Params["txtKeywords"];
            int page = 0;
            if (string.IsNullOrEmpty(pageIndex))
            {
                page = 1;
            }
            else
            {
                page = int.Parse(pageIndex);
            }
            var data = _commentService.GetPagerCommont(keyword, channelid, page, 10, " id asc, add_time desc ");
            return View(data);
        }

        /// <summary>
        /// 添加文章
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id = 0)
        {
            var chanelId = Request.Params["channel_id"];
            ArticleExtentionModel artclemodel = GetArticleExtionModel(chanelId);
            ViewBag.AllCategories = artclemodel.AllCategories;
            //新增界面
            if (id == 0)
            {
                return View();
            }
            else
            {
                //编辑界面
                return View();
            }
        }


        /// <summary>
        /// 获取其他字段信息
        /// </summary>
        /// <returns></returns>
        public JsonResult CreateOtherField()
        {
            string chanel_id = Request.Params["channel_id"];
            if (!string.IsNullOrEmpty(chanel_id))
            {
                int id = int.Parse(chanel_id);
                List<pl_article_attribute_field> ls = _articleService.GetModelList(m => m.id == id && m.is_sys == 0);
                return Json(ls, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
