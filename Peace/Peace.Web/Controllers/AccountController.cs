using Ninject;
using Peace.Core;
using Peace.Services.Account;
using Peace.Services.Users;
using Peace.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peace.Model;
using Peace.Web.Framework;
using Peace.Web.Framework.Controllers;
using Peace.Core.Authentication;
using Peace.Data;

namespace Peace.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _service;
        private readonly IWorkContext _workContext;
        private readonly ILocalAuthenticationService _localAuthenService;
        private readonly IFormsAuthentication _formAuthenService;

        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }


        public AccountController(IUserService userService, IAccountService accountService, IWorkContext workContext
            , ILocalAuthenticationService localAuthenService
            , IFormsAuthentication formAuthenService)
        {
            _service = userService;
            _workContext = workContext;
            _accountService = accountService;
            _localAuthenService = localAuthenService;
            _formAuthenService=formAuthenService;
        }

        #region 登陆登出
        [HttpGet]
        public ActionResult Login(string returnUrl = "")
        {
            var model = new LoginModel();
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }


        /// <summary>
        /// 用于处理客户端的一些请求
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (model.UserName != null)
                {
                    model.UserName = model.UserName.Trim();
                }
                UserLoginResults loginResult = _accountService.ValidateUser(model.UserName, model.Password);

                switch (loginResult)
                {
                    case UserLoginResults.Successful:
                        {
                            User user = _service.GetUserByUsername(model.UserName);
                            //sign in new customer
                            AuthenticationService.SignIn(user, model.RememberMe);

                            if (String.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
                                return Redirect(@"~/Home/Index");
                            return Redirect(returnUrl);
                        }
                    case UserLoginResults.UserNotExist:
                        ModelState.AddModelError("", "用户不存在");
                        break;
                    case UserLoginResults.Deleted:
                        ModelState.AddModelError("", "用户已删除");
                        break;
                    case UserLoginResults.NotActive:
                        ModelState.AddModelError("", "用户没有激活");
                        break;
                    case UserLoginResults.NotRegistered:
                        ModelState.AddModelError("", "用户未注册");
                        break;
                    case UserLoginResults.WrongPassword:
                    default:
                        ModelState.AddModelError("", "密码错误");
                        break;
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            var model = new RegisterModel();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model, string returnUrl)
        {
            //如果当前用户再注册别的用户，就让他先退出，加入一个Guest角色用户进来准备。
            var user = _service.InsertGuestUser();

            if (ModelState.IsValid)
            {
                if (model.UserName != null)
                {
                    model.UserName = model.UserName.Trim();
                }

                var isApprove = true;
                var registerRequest = new UserRegistrationRequest(user, model.Email, model.Mobile, model.UserName, model.Password, isApprove);
                var registrationResult = _accountService.RegisterUser(registerRequest);
                if (registrationResult.Success)
                {
                    if (isApprove)
                    {
                        AuthenticationService.SignIn(user, true);
                    }
                    if (String.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
                        return RedirectToAction("Index", "Home");
                    return Redirect(returnUrl);
                }
                foreach (var error in registrationResult.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }
            return View(model);
        }


        /// <summary>
        /// 退出函数还需要处理，退出时统计退出时间,然后关闭网页。
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOff()
        {
            AuthenticationService.SignOut();
            return Redirect(@"~/Account/Login");
        }


        #endregion

    }


}