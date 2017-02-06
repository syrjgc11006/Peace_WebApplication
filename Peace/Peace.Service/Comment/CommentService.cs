using Peace.Com;
using Peace.Core;
using Peace.Data;
using Peace.Model.ViewModels.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Peace.Service.Comment
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<pl_article_comment> _articleCommontRepostory;
        public CommentService(IRepository<pl_article_comment> articleCommontRepostory)
        {
            _articleCommontRepostory = articleCommontRepostory;
        }
        /// <summary>
        ///  获取分页文章评论，后台进行评论
        /// </summary>
        /// <param name="key"></param>
        /// <param name="channel_id"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortExpression"></param>
        /// <returns></returns>
        public Pager<CommentModel> GetPagerCommont(string key, string channel_id, int page, int pageSize, string sortExpression = null)
        {
            int chanelId = int.Parse(channel_id);
            using (var context = SiteManager.Get<PeaceObjectContext>())
            {
                var data = from pac in context.pl_article_comment
                           join pa in context.pl_article on new { id = (Int32)pac.article_id } equals new { id = pa.id }
                           where pa.channel_id == chanelId
                           select new CommentModel()
                           {
                               id = pac.id,
                               channel_id = pac.channel_id,
                               article_id = pac.article_id,
                               articleTitle = pa.title,
                               parent_id = pac.parent_id,
                               user_id = pac.user_id,
                               user_name = pac.user_name,
                               user_ip = pac.user_ip,
                               content = pac.content,
                               is_lock = pac.is_lock,
                               add_time = pac.add_time,
                               is_reply = pac.is_reply,
                               reply_content = pac.reply_content,
                               reply_time = pac.reply_time,
                               CreaterId = pac.CreaterId,
                               CreaterName = pac.CreaterName,
                               UpdaterId = pac.UpdaterId,
                               UpdaterName = pac.UpdaterName,
                               CreateTime = pac.CreateTime,
                               UpdateTime = pac.UpdateTime
                           };
                Pager<CommentModel> commentPager = new Pager<CommentModel>(data, sortExpression, page, pageSize);
                return commentPager;
            }
        }
    }
}
