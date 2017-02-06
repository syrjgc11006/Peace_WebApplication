using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Peace.Core;
using Peace.Core.Caching;
using Peace.Data;
using Peace.Model;
using Peace.Services.Account;
using Peace.Services.Users;
using Peace.Web.App_Start;
using Peace.Web.Framework;
using Peace.Web.Framework.Themes;
using Peace.Core.Logging;
using Peace.Core.Configuration;
using Peace.Core.Authentication;
using Peace.Services.Navigation;
using Peace.Service.Article;
using Peace.Service.Comment;
using Peace.Core.Common;

namespace Peace.Web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //请求Controller，注册服务对象
            ControllerBuilder.Current.SetControllerFactory(new NinjectConfig(AddBindings));

            //视图引擎的注册（用于切换主题，使用特性路由）
            //remove all view engines
            ViewEngines.Engines.Clear();
            //except the themeable razor view engine we use
            ViewEngines.Engines.Add(new ThemeableRazorViewEngine());


            //注册区域
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            BundleConfig.RegisterBundles(BundleTable.Bundles);
           

            //系统公用设置工厂注册对象
            ApplicationSettingsFactory.InitializeApplicationSettingsFactory(SiteManager.Get<IApplicationSettings>());

            //日志工厂注册对象
            LoggingFactory.InitializeLogFactory(SiteManager.Get<ILogger>());

            //项目启动时计入日志（测试日志）
            LoggingFactory.GetLogger().Debugger("Application Started");
        }

        /// <summary>
        /// 依赖注入对象
        /// </summary>
        /// <param name="kernel"></param>
        private void AddBindings(IKernel kernel)
        {
            SiteManager.Kernel.Bind<IDbContext>().To<PeaceObjectContext>().InSingletonScope();
            SiteManager.Kernel.Bind<IWebHelper>().To<WebHelper>().InTransientScope();
            SiteManager.Kernel.Bind<IWorkContext>().To<WebWorkContext>().InTransientScope();
            SiteManager.Kernel.Bind(typeof(IRepository<>)).To(typeof(EfRepository<>));//带泛型约束注入

            SiteManager.Kernel.Bind<IThemeContext>().To<ThemeContext>().InTransientScope();
            kernel.Bind<ICacheManager>().To<MemoryCacheManager>().InSingletonScope().Named(PeaceConstConfig.PeaceCacheStatic);                                 //计算机内存缓存注入
            //kernel.Bind<ICacheManager>().To<PerRequestCacheManager>().WhenInjectedInto<UserService>().InRequestScope().Named(PeaceConstConfig.PortalCacheRequest);  //http请求缓存注入

            //Application Settings
            SiteManager.Kernel.Bind<IApplicationSettings>().To<WebConfigApplicationSettings>();

            //Logger注册
            SiteManager.Kernel.Bind<ILogger>().To<Log4NetAdapter>();

            //SiteManager.Kernel.Bind<ICacheManager>().To<PerRequestCacheManager>();
            SiteManager.Kernel.Bind<IUserService>().To<UserService>();
            //用户身份认证注册
            SiteManager.Kernel.Bind<IAuthenticationService>().To<FormsAuthenticationService>().InSingletonScope();

            //kernel.Bind<IPermissionService>().To<PermissionService>();
            SiteManager.Kernel.Bind<IAccountService>().To<AccoutService>();

            //Form表单认证
            SiteManager.Kernel.Bind<IFormsAuthentication>().To<AspFormsAuthentication>();

            SiteManager.Kernel.Bind<ILocalAuthenticationService>().To<AspMembershipAuthentication>();

            //菜单
            SiteManager.Kernel.Bind<INavigationService>().To<NavigationService>();
            //文章服务
            SiteManager.Kernel.Bind<IArticleService>().To<ArticleService>();
            //评论服务
            SiteManager.Kernel.Bind<ICommentService>().To<CommentService>();
        }
    }
}