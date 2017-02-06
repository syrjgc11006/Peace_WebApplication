using Peace.Core;
using Peace.Web.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Peace.Web.Controllers
{
    public abstract partial class BasePublicController : BaseController
    {
        /// <summary>
        /// 请求找不到页面
        /// </summary>
        /// <returns></returns>
        protected virtual ActionResult InvokeHttp404()
        {
            //获取公共帮助控制器来传递路由参数
            IController errorController = SiteManager.Get<CommonController>();

            var routeData = new RouteData();
            routeData.Values.Add("controller","Common");
            routeData.Values.Add("action","PageNotFound");

            errorController.Execute(new RequestContext(this.HttpContext, routeData));
            return new EmptyResult();
        }
    }
}
