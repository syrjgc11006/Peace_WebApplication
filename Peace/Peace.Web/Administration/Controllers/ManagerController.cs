using Peace.Data;
using Peace.Model;
using Peace.Model.ViewModels;
using Peace.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Peace.Admin.Controllers
{
    public class ManagerController : BaseAdminController
    {

        INavigationService _inavigationService;   //菜单服务
        public ManagerController(NavigationService inavigationService)
        {
            _inavigationService = inavigationService;
        }

        #region 页面跳转

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UpdatePwd()
        {
            return View();
        }

        public ActionResult LogOff()
        {
            return RedirectToAction("Index", "Home");
        }

        #endregion


        #region 返回菜单信息

        /// <summary>
        /// 通过当前登录用户获取该用户的菜单数据，菜单数据带样式
        /// </summary>
        /// <returns></returns>
        public string get_navigation_list()
        {
            //管理员身份认证
            //DataTable dt = new BLL.navigation().GetList(0, DTEnums.NavigationEnum.System.ToString());
            IQueryable<NavigationModel> navigationList = _inavigationService.GetNavigationQuery(0, "System");
            StringBuilder strBuilder = new StringBuilder();
            this.get_navigation_childs(navigationList.ToList(), 0, ref strBuilder);
            return strBuilder.ToString();
        }


        private void get_navigation_childs(List<NavigationModel> oldData, int parent_id, ref StringBuilder strHtml, int role_type = 0, List<pl_manager_role> ls = null)
        {
            List<NavigationModel> dr = oldData.Where(m => m.parent_id == parent_id).ToList();
            //StringBuilder strHtml = new StringBuilder();
            bool isWrite = false; //是否输出开始标签
            int i = 0;
            foreach (var item in dr)
            {
                //检查是否显示在界面上====================
                bool isActionPass = true;
                if (item.is_lock == 1)
                {
                    isActionPass = false;
                }
                //检查管理员权限==========================
                if (isActionPass && role_type > 1)
                {
                    string[] actionTypeArr = item.action_type.Split(',');
                    foreach (string action_type_str in actionTypeArr)
                    {
                        //如果存在显示权限资源，则检查是否拥有该权限
                        //if (action_type_str == "Show")
                        //{
                        //    List<pl_manager_role_value> modelt = ls.Find(p => p.nav_name == item.name && p.action_type == "Show");
                        //    if (modelt == null)
                        //    {
                        //        isActionPass = false;
                        //    }
                        //}
                    }
                }
                //如果没有该权限则不显示
                if (!isActionPass)
                {
                    if (isWrite && i == (dr.Count - 1) && parent_id > 0)
                    {
                        strHtml.Append("</ul>\n");
                    }
                    continue;
                }
                //如果是顶级导航
                if (parent_id == 0)
                {
                    strHtml.Append("<div class=\"list-group\">\n");
                    strHtml.Append("<h1 title=\"" + item.sub_title + "\">");
                    if (!string.IsNullOrEmpty(item.icon_url.Trim()))
                    {
                        strHtml.Append("<img src=\"" + item.icon_url + "\" />");
                    }
                    strHtml.Append("</h1>\n");
                    strHtml.Append("<div class=\"list-wrap\">\n");
                    strHtml.Append("<h2>" + item.title + "<i></i></h2>\n");
                    //调用自身迭代
                    this.get_navigation_childs(oldData, item.id, ref strHtml, role_type, ls);
                    strHtml.Append("</div>\n");
                    strHtml.Append("</div>\n");
                }
                else //下级导航
                {
                    if (!isWrite)
                    {
                        isWrite = true;
                        strHtml.Append("<ul>\n");
                    }
                    strHtml.Append("<li>\n");
                    strHtml.Append("<a navid=\"" + item.name + "\"");
                    if (!string.IsNullOrEmpty(item.link_url))
                    {
                        if (item.channel_id > 0)
                        {
                            strHtml.Append(" href=\"" + item.link_url + "?channel_id=" + item.channel_id.ToString() + "\" target=\"mainframe\"");
                        }
                        else
                        {
                            strHtml.Append(" href=\"" + item.link_url + "\" target=\"mainframe\"");
                        }
                    }
                    if (!string.IsNullOrEmpty(item.icon_url))
                    {
                        strHtml.Append(" icon=\"" + item.icon_url + "\"");
                    }
                    strHtml.Append(" target=\"mainframe\">\n");
                    strHtml.Append("<span>" + item.title + "</span>\n");
                    strHtml.Append("</a>\n");
                    //调用自身迭代
                    this.get_navigation_childs(oldData, item.id, ref strHtml, role_type, ls);
                    strHtml.Append("</li>\n");

                    if (i == (dr.Count - 1))
                    {
                        strHtml.Append("</ul>\n");
                    }
                }
                i++;
            }
            //return strHtml.ToString();
        }


        #endregion

    }
}
