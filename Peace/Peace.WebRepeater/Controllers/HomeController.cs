using Peace.Com;
using Peace.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Peace.WebRepeater.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Repeater/
        static IQueryable<HelloWorldModel> allData;
        public HomeController()
        {
            Random rand = new Random(0);
            allData = Enumerable.Range(1, 1000).Select(i => new HelloWorldModel
            {
                Id = i,
                CreateTime = DateTime.Now.AddSeconds(rand.Next(i * 1000)),
                Name = "Product_" + rand.Next(),
                Price = rand.Next() / 10.2m,
                SalerName = "Saler_" + rand.Next()
            }).ToArray().AsQueryable(); //如果先不ToArray()一下，每次结果都会不一样
        }
        //
        // GET: /Home/

        public ActionResult Index(PageModel pageModel)
        {
            return View(new Pager<HelloWorldModel>(allData, pageModel.SortExpression, pageModel.Page, pageModel.PageSize));
            //return View();
        }

    }
    public class HelloWorldModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateTime { get; set; }

        public decimal Price { get; set; }

        public string SalerName { get; set; }
    }
    public class PageModel
    {
        public int CatalogId { get; set; }

        /// <summary>
        /// 页号
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 和PageIndex相同
        /// </summary>
        public int Page { get { return PageIndex; } set { PageIndex = value; } }

        /// <summary>
        /// 页的大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 排序方向， asc或desc
        /// </summary>
        public string SortOrder { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string SortField { get; set; }

        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 高级查询的条件表达式树Json字符串
        /// </summary>
        public string AdvQuery { get; set; }

        public string SortExpression
        {
            get { return SortField + " " + SortOrder; }
        }

        public PageModel()
        {
            //SortField = "Id";
            //SortOrder = "DESC";
            PageSize = 5;
            PageIndex = 1;
        }
    }
}
