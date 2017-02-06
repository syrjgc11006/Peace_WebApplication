using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Peace.Admin.Controllers
{
    /// <summary>
    /// 后台管理主页面
    /// </summary>
    public class HomeController : BaseAdminController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Center()
        {
            return View();
        }
    }
}
