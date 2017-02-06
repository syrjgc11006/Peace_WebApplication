using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Modules;
namespace Peace.Core
{
    /// <summary>
    /// 全局管理工具，利用IOC容器实现系统类型的管理
    /// </summary>
    public class SiteManager : NinjectModule
    {
        /// <summary>
        /// 空构造函数
        /// </summary>
        public SiteManager()
        {

        }

        /// <summary>
        /// OutputCache的Key，修改这个属性控制缓存整体失效
        /// </summary>
        public static string CacheType { get; set; }

        private static IKernel kernel = new StandardKernel(new SiteManager());

        /// <summary>
        /// 单例模式，允许一个对象生成
        /// </summary>
        public new static IKernel Kernel
        {
            get { return kernel; }
        }

        public override void Load()
        {
            
        }

        /// <summary>
        /// 获取Ninject容器中的指定类型对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns>指定类型的对象</returns>
        public static T Get<T>()
        {
            return kernel.Get<T>();
        }

        /// <summary>
        /// 获取Ninject容器中的指定类型对象的非泛型版本。
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <returns>指定类型的对象</returns>
        public static object Get(Type type)
        {
            return kernel.Get(type);
        }
    }
}
