using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Text.RegularExpressions;
using System.Web;
using System.Collections.Specialized;
using System.Data;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace Peace.Com.Tools
{
    public static class JMvcExtensions
    {
        /// <summary>
        /// 根据现有请求信息重新构造一个请求字典
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static RouteValueDictionary ReBuildRouteDict(this ViewContext context)
        {
            var routeValues = new RouteValueDictionary(); // ViewContext.RouteData.Values;
            var request = context.RequestContext.HttpContext.Request;
            foreach (string key in request.QueryString.Keys)
            {
                if (!key.IsEmpty())
                {
                    routeValues[key] = request.QueryString[key];
                }
            }

            foreach (KeyValuePair<string, object> so in context.RouteData.Values)
            {
                if (so.Value.GetType() == typeof(String) || so.Value.GetType().IsValueType)
                {
                    routeValues[so.Key] = so.Value;
                }
            }
            return routeValues;
        }


    }
}
