using Ninject;
using Peace.Core;
using Peace.Core.Common;
using Peace.Core.Helpers;

using Peace.Services.Account;
using Peace.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Peace.Model;
using Peace.Data;

namespace Peace.Web.Framework
{
    public class WebWorkContext : IWorkContext
    {
        #region 字段

        private readonly IUserService _userService;
        private User _cachedUser;

        #endregion

        #region 属性

        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        public HttpContextBase HttpContext
        {
            get { return new HttpContextWrapper(System.Web.HttpContext.Current); }
        }

        public SendMail Mail { get; set; }

        #endregion

        #region 接口实现

        public User CurrentUser
        {
            get
            {
                User customer = AuthenticationService.GetAuthenticatedCustomer();
                if (customer == null || customer.Deleted || !customer.Active)
                {
                    var customerCookie = GetUserCookie();
                    if (customerCookie != null && !string.IsNullOrEmpty(customerCookie.Value))
                    {
                        Guid customerGuid;
                        if (Guid.TryParse(customerCookie.Value, out customerGuid))
                        {
                            var customerByCookie = _userService.GetUserByGuid(customerGuid);
                            if (customerByCookie != null && IsCurrentUser)
                                //this customer (from cookie) should not be registered
                                //!customerByCookie.IsRegistered())
                                customer = customerByCookie;
                        }
                    }
                }
                //validation
                if (customer != null && !customer.Deleted && customer.Active)
                {
                    SetUserCookie(customer.UserGuid);
                }

                return customer;
            }
            set
            {
                SetUserCookie(value.UserGuid);
                _cachedUser = value;
            }
        }

        public bool IsAdmin
        {
            get;
            set;
        }

        public bool IsCurrentUser
        {
            get { return AuthenticationService.IsCurrentUser; }
        }

        public bool SendMail(string toEmails, string emailText, string subject)
        {
            throw new NotImplementedException();
        }

        public void AsyncSendMail(string toEmails, string emailText, string subject)
        {
            throw new NotImplementedException();
        }

        #endregion
      
        #region 工具方法

        protected virtual HttpCookie GetUserCookie()
        {
            if (HttpContext == null || HttpContext.Request == null)
            {
                return null;
            }
            return HttpContext.Request.Cookies[PeaceConstConfig.UserCookieName];
        }

        protected virtual void SetUserCookie(Guid customerGuid)
        {
            if (HttpContext != null && HttpContext.Response != null)
            {
                var cookie = new HttpCookie(PeaceConstConfig.UserCookieName);
                cookie.HttpOnly = true;
                cookie.Value = customerGuid.ToString();
                if (customerGuid == Guid.Empty)
                {
                    cookie.Expires = DateTime.Now.AddMonths(-1);
                }
                else
                {
                    int cookieExpires = 24 * 30; //TODO make configurable
                    cookie.Expires = DateTime.Now.AddHours(cookieExpires);  //过期时间一个月
                }

                HttpContext.Response.Cookies.Remove(PeaceConstConfig.UserCookieName);
                HttpContext.Response.Cookies.Add(cookie);
            }
        }


        #endregion
    }
}
