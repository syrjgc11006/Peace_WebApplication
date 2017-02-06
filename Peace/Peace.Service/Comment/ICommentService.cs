using Peace.Com;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Peace.Data;
using Peace.Model.ViewModels.Article;

//评论服务
namespace Peace.Service.Comment
{
    public interface ICommentService
    {
        /// <summary>
        /// 获取分页文章评论，后台进行评论
        /// </summary>
        /// <param name="key"></param>
        /// <param name="channel_id"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortExpression"></param>
        /// <returns></returns>
        Pager<CommentModel> GetPagerCommont(string key, string channel_id, int page, int pageSize, string sortExpression = null);
    }
}
