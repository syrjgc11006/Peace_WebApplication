using Peace.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peace.Data;
using Peace.Core;
using Peace.Model;

namespace Peace.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        /// <summary>
        /// 获取菜单数据
        /// </summary>
        /// <param name="parent_id">上级菜单</param>
        /// <param name="nav_type">菜单类别</param>
        /// <returns></returns>
        public IQueryable<NavigationModel> GetNavigationQuery(int parent_id, string nav_type)
        {
            List<NavigationModel> newData = new List<NavigationModel>();
            using (var context = SiteManager.Get<PeaceObjectContext>())
            {
                //获取菜单数据
                var oldData = context.pl_navigation.ToList();
                if (oldData==null||oldData.Count<=0)
                {
                    return null;
                }
              
                //调用迭代组合成DAGATABLE
                GetChilds(oldData, newData, parent_id, 0);
            }
            return newData.AsQueryable();
        }

        /// <summary>
        /// 从内存中取得所有下级类别列表（自身迭代）
        /// </summary>
        private void GetChilds(List<pl_navigation> oldData, List<NavigationModel> newData, int parent_id, int class_layer)
        {
            class_layer++;
            List<pl_navigation> dr = oldData.Where(m => m.parent_id == parent_id).ToList();
            foreach (var item in dr)
            {
                NavigationModel model = new NavigationModel()
                {
                    id = item.id,
                    parent_id = item.parent_id,
                    channel_id = item.channel_id,
                    class_layer = class_layer,
                    nav_type = item.nav_type,
                    name = item.name,
                    title = item.title,
                    sub_title = item.sub_title,
                    icon_url = item.icon_url,
                    link_url = item.link_url,
                    sort_id = item.sort_id,
                    is_lock = item.is_lock,
                    remark = item.remark,
                    action_type = item.action_type,
                    is_sys = item.is_sys
                };
                newData.Add(model);
                //自身迭代
                this.GetChilds(oldData, newData, item.id, class_layer);
            }
        }
    }
}
