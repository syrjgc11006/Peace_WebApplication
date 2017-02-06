using Peace.Core;
using Peace.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peace.Web.Framework;
using Peace.Web.Framework.Controllers;

namespace Peace.Web.Controllers
{
    public class UserController : BaseController
    {

        private readonly IUserService _userService;
        private readonly IWorkContext _peaceContext;
        //
        // GET: /User/

        public UserController(IWorkContext peaceContext, IUserService userService)
        {
            _peaceContext = peaceContext;
            _userService = userService;
        }


        #region 个人中心

        public ActionResult Index()
        {
            return View();
        }



        #endregion

       

    }
}
