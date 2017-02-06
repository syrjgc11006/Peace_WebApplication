using Peace.Com;
using Peace.Core;
using Peace.Data;
using Peace.Model.ViewModels.Article;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Peace.Service.Article
{
    public class ArticleService : IArticleService
    {
        private readonly IRepository<pl_article_category> _articleCategoryRepository;           //文章类别
        private readonly IRepository<pl_article> _articleRepository;                            //文章实体
        private readonly IRepository<pl_article_attribute_field> _articleAttributeFieldRepository;   //文章扩展属性
        private readonly IRepository<pl_channel_field> _channelFieldRespostory;                 //频道字段
        public ArticleService(IRepository<pl_article_category> articleCategoryRepository,
            IRepository<pl_article> articleRepository,
            IRepository<pl_article_attribute_field> articleAttributeFieldRepository
            )
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleRepository = articleRepository;
            _articleAttributeFieldRepository = articleAttributeFieldRepository;
        }
        /// <summary>
        /// 获取当前频道下所有分类
        /// </summary>
        /// <param name="parentId">分类Id</param>
        /// <param name="channelId">频道</param>
        /// <returns></returns>
        public List<pl_article_category> GetCategory(int parentId, int channelId)
        {
            var categoryTable = _articleCategoryRepository.Table.Where(m => m.channel_id == channelId).ToList();
            if (categoryTable == null)
            {
                return null;
            }
            List<pl_article_category> newData = new List<pl_article_category>();
            //调用迭代组合成DAGATABLE
            GetChilds(categoryTable, newData, parentId, channelId);
            return newData;
        }

        /// <summary>
        /// 从内存中取得所有下级类别列表（自身迭代）
        /// </summary>
        private void GetChilds(List<pl_article_category> oldData, List<pl_article_category> newData, int parent_id, int channel_id)
        {
            List<pl_article_category> temps = oldData.Where(m => m.parent_id == parent_id).ToList();
            foreach (var item in temps)
            {
                pl_article_category category = new pl_article_category
                {
                    id = item.id,
                    channel_id = item.channel_id,
                    title = item.title,
                    call_index = item.call_index,
                    parent_id = item.parent_id,
                    class_list = item.class_list,
                    class_layer = item.class_layer,
                    sort_id = item.sort_id,
                    link_url = item.link_url,
                    img_url = item.img_url,
                    content = item.content,
                    seo_title = item.seo_title,
                    seo_keywords = item.seo_keywords,
                    seo_description = item.seo_description
                };
                newData.Add(category);
                //调用自身迭代
                this.GetChilds(oldData, newData, item.id, channel_id);
            }
        }

        /// <summary>
        /// 获取分页文章内容
        /// </summary>
        /// <param name="key">查询关键字</param>
        /// <param name="page">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <returns>返回数据</returns>
        public Pager<ArticleModel> GetPagerArticle(string key, string channel_id, int page, int pageSize, string sortExpression = null)
        {
            int chanelId = int.Parse(channel_id);
            IQueryable<ArticleModel> IQAriticle;        //可查询对象
            using (var context = SiteManager.Get<PeaceObjectContext>())
            {
                var data = from pa in context.pl_article
                           join pac in context.pl_article_category on new { category_id = pa.category_id } equals new { category_id = pac.id }
                           where pa.channel_id == chanelId
                           && (string.IsNullOrEmpty(key) || pa.title.Contains(key))
                           select new ArticleModel
                           {
                               id = pa.id,
                               channel_id = pa.channel_id,
                               category_id = pa.category_id,
                               category_title = pac.title,
                               call_index = pa.call_index,
                               title = pa.title,
                               link_url = pa.link_url,
                               img_url = pa.img_url,
                               seo_title = pa.seo_title,
                               seo_keywords = pa.seo_keywords,
                               seo_description = pa.seo_description,
                               tags = pa.tags,
                               zhaiyao = pa.zhaiyao,
                               content = pa.content,
                               sort_id = pa.sort_id,
                               click = pa.click,
                               status = pa.status,
                               is_msg = pa.is_msg,
                               is_top = pa.is_top,
                               is_red = pa.is_red,
                               is_hot = pa.is_hot,
                               is_slide = pa.is_slide,
                               is_sys = pa.is_sys,
                               CreaterId = pa.CreaterId,
                               CreaterName = pa.CreaterName,
                               UpdaterId = pa.UpdaterId,
                               UpdaterName = pa.UpdaterName,
                               CreateTime = pa.CreateTime,
                               UpdateTime = pa.UpdateTime
                           };
                Pager<ArticleModel> articlePager = new Pager<ArticleModel>(data, sortExpression, page, pageSize);
                return articlePager;
            }

        }


        /// <summary>
        /// 通过类别Id获取类别名称
        /// </summary>
        /// <param name="categoryId">类别Id</param>
        /// <returns></returns>
        public pl_article_category GetCategoryById(int categoryId)
        {
            return _articleCategoryRepository.GetById(categoryId);
        }

        /// <summary>
        /// 获取频道下对应的扩展信息
        /// </summary>
        /// <param name="channel_id"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<pl_article_attribute_field> GetModelList(Expression<Func<pl_article_attribute_field, bool>> whereExpression)
        {
            var articleAttributeField = _articleAttributeFieldRepository.Table.Where(whereExpression)
                .OrderBy(m => m.sort_id).ThenByDescending(n => n.id);
            return articleAttributeField.ToList();
        }
    }
}
