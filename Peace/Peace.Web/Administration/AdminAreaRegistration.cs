using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peace.Com.Mvc.Routes;
using Peace.Admin.Handler;

namespace Peace.Admin
{
    /// <summary>
    /// 路由区域注册，管理员访问采用不同的区域控制
    /// </summary>
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Admin"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            //管理员首页
            context.MapRoute(
                name: "Admin_default",           //路由名称
                url: "Admin/{Controller}/{action}/{id}",     //路由的URL模式
                defaults: new { controller = "Home", action = "Index", area = "Admin", id = "" }, //默认路由
                namespaces: new[] { "Peace.Admin.Controllers" }    //路由的命名空间
                );

            //添加使用HttpHandler的路由
            #region Handler
            context.Routes.MapHttpHandler<uploadHandler>("uploadHandler", "Handler/uploadHandler.ashx");
            //context.Routes.MapHttpHandler<uploadHandler>("uploadHandler", "");
            #endregion
        }
    }
}