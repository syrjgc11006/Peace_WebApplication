using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Peace.Web.Controllers
{
    public partial class CommonController : BasePublicController
    {
        #region 字段

        #endregion

        #region 构造函数

        #endregion

        #region 工具方法

        #endregion

        #region 方法

        public ActionResult PageNotFound()
        {
            this.Response.StatusCode = 404;
            this.Response.TrySkipIisCustomErrors = true;
            return View();
        }

        #endregion

    }
}
