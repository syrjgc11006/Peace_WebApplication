using Peace.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace.Services.Navigation
{
    public interface INavigationService
    {
        /// <summary>
        /// 获取菜单模型数据
        /// </summary>
        /// <param name="parent_id">上级菜单</param>
        /// <param name="nav_type">菜单类别</param>
        /// <returns></returns>
        IQueryable<NavigationModel> GetNavigationQuery(int parent_id, string nav_type);
    }
}
