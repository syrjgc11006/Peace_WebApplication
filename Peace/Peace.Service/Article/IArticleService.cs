using Peace.Com;
using Peace.Core;
using Peace.Data;
using Peace.Model.ViewModels.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Peace.Service.Article
{
    public interface IArticleService
    {
        /// <summary>
        /// 获取当前频道下所有分类
        /// </summary>
        /// <param name="parentId">分类Id</param>
        /// <param name="channelId">频道</param>
        /// <returns></returns>
        List<pl_article_category> GetCategory(int parentId, int channelId);

        /// <summary>
        /// 获取分页文章内容
        /// </summary>
        /// <param name="key">查询关键字</param>
        /// <param name="page">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <returns>返回数据</returns>
        Pager<ArticleModel> GetPagerArticle(string key, string channel_id, int page, int pageSize, string sortExpression = null);

        /// <summary>
        /// 通过类别Id获取类别名称
        /// </summary>
        /// <param name="categoryId">类别Id</param>
        /// <returns></returns>
        pl_article_category GetCategoryById(int categoryId);

        /// <summary>
        /// 获取频道下对应的扩展信息
        /// </summary>
        /// <param name="channel_id"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        List<pl_article_attribute_field> GetModelList(Expression<Func<pl_article_attribute_field, bool>> whereExpression);
    }
}
