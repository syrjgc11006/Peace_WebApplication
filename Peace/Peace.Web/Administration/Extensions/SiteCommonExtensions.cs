using Peace.Web.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Tunynet.Utilities;

namespace Peace.Admin.Extensions
{
    public static class SiteCommonExtensions
    {
        private static readonly string AdminAreaName = "Admin";
        private static readonly string ControllerKey = "controller";
        private static readonly string ActionKey = "action";
        private static readonly string AreaKey = "area";

        /// <summary>
        /// 获取上传资讯附件Url
        /// </summary>
        public static string UploadAttachment(this SiteCommon siteUrls)
        {
            return WebUtility.ResolveUrl(string.Format("~/Handler/uploadHandler.ashx"));
        }

        /// <summary>
        /// 获取RequestContext
        /// </summary>
        /// <returns></returns>
        private static RequestContext GetRequestContext()
        {
            HttpContext httpContext = HttpContext.Current;
            if (httpContext == null)
            {
                var httpRequest = new HttpRequest("", "http://a.com/", "");
                var httpResponse = new HttpResponse(new System.IO.StringWriter(new StringBuilder()));
                httpContext = new HttpContext(httpRequest, httpResponse);
            }
            RequestContext requestContext = new RequestContext(new HttpContextWrapper(httpContext), new RouteData());
            return requestContext;
        }

        /// <summary>
        /// 通过Action/Controller获取url
        /// </summary>
        /// <param name="actionName">actionName</param>
        /// <param name="controllerName">controllerName</param>
        /// <param name="areaName">路由分区名称</param>
        /// <param name="routeValueDictionary">路由数据</param>
        /// <returns>返回对应的url</returns>
        public static string Action(string actionName, string controllerName, string areaName, RouteValueDictionary routeValueDictionary)
        {

            RouteValueDictionary routeParameters = new RouteValueDictionary();
            string[] values = null;
            if (routeValueDictionary != null)
            {
                values = new string[routeValueDictionary.Count];
                int index = 0;
                foreach (KeyValuePair<string, object> pair in routeValueDictionary)
                {
                    if (pair.Value == null)
                        values[index] = string.Empty;
                    else
                        values[index] = pair.Value.ToString();
                    routeParameters[pair.Key] = "{" + index + "}";

                    index++;
                }
            }
            string url = string.Empty;
            if (url == null)
            {
                if (areaName != null)
                    routeParameters.Add(AreaKey, areaName);

                RequestContext requestContext = GetRequestContext();
                try
                {
                    url = UrlHelper.GenerateUrl(null, actionName, controllerName, routeParameters, RouteTable.Routes, requestContext, true);
                }
                catch (Exception e)
                {
                    url = string.Empty;
                }

                if (string.IsNullOrEmpty(url))
                    return string.Empty;
                //替换UrlEncode编码
                url = url.Replace("%7b", "{").Replace("%7d", "}").Replace("%7B", "{").Replace("%7D", "}").ToLower();
            }

            if (values != null)
                return string.Format(url, values);
            else
                return url;
        }
    }
}