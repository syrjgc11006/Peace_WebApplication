using Peace.Com.Tools;
using Peace.Core;
using Peace.Core.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tunynet.Utilities;

namespace Peace.Web.Framework.Common
{
    public class SiteCommon
    {
        private readonly SiteOperation dal = new SiteOperation();
        private readonly ICacheManager _cacheManager = SiteManager.Get<ICacheManager>();

        #region Instance

        private static volatile SiteCommon _instance = null;
        private static readonly object lockObject = new object();

        /// <summary>
        /// 创建主页实体
        /// </summary>
        /// <returns></returns>
        public static SiteCommon Instance()
        {
            if (_instance == null)
            {
                lock (lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new SiteCommon();
                    }
                }
            }
            return _instance;
        }

        private SiteCommon()
        { }

        #endregion Instance
        /// <summary>
        ///  读取配置文件
        /// </summary>
        public siteconfig loadConfig()
        {
            siteconfig model = _cacheManager.Get<siteconfig>(PeaceKeys.CACHE_SITE_CONFIG);
            if (model == null)
            {
                _cacheManager.Set(PeaceKeys.CACHE_SITE_CONFIG, dal.loadConfig(Utils.GetXmlMapPath(PeaceKeys.FILE_SITE_XML_CONFING)), 100000
                    );
                model = _cacheManager.Get<siteconfig>(PeaceKeys.CACHE_SITE_CONFIG);
            }
            return model;
        }

        /// <summary>
        ///  保存配置文件
        /// </summary>
        public siteconfig saveConifg(siteconfig model)
        {
            return dal.saveConifg(model, Utils.GetXmlMapPath(PeaceKeys.FILE_SITE_XML_CONFING));
        }

        public string UploadAttachment()
        {
            return WebUtility.ResolveUrl(string.Format("~/Handler/uploadHandler.ashx"));
        }

    }
}
