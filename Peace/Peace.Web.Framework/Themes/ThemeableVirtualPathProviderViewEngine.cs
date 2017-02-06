using Peace.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Peace.Web.Framework.Themes
{
    public abstract class ThemeableVirtualPathProviderViewEngine : VirtualPathProviderViewEngine
    {
        //the original implementation can be found at http://aspnetwebstack.codeplex.com/SourceControl/latest#src/System.Web.Mvc/VirtualPathProviderViewEngine.cs
        //we make some methods protected virtual because they are overridden by some plugin vendors
        #region Fields

        private const string CacheKeyFormat = ":ViewCacheEntry:{0}:{1}:{2}:{3}:{4}:{5}";
        private const string CacheKeyPrefixMaster = "Master";
        private const string CacheKeyPrefixPartial = "Partial";
        private const string CacheKeyPrefixView = "View";
        private static readonly string[] _emptyLocations = new string[0];

        internal Func<string, string> GetExtensionThunk = VirtualPathUtility.GetExtension;

        #endregion

        #region Utilities & Methods


        protected virtual string GetAreaName(RouteData routeData)
        {
            object result;
            if (routeData.DataTokens.TryGetValue("area", out result))
            {
                return (result as string);
            }
            return GetAreaName(routeData.Route);
        }

        protected virtual string GetAreaName(RouteBase route)
        {
            var area = route as IRouteWithArea;
            if (area != null)
            {
                return area.Area;
            }
            var route2 = route as Route;
            if ((route2 != null) && (route2.DataTokens != null))
            {
                return (route2.DataTokens["area"] as string);
            }
            return null;
        }

        protected virtual string GetCurrentTheme()
        {
            var themeContext = SiteManager.Get<IThemeContext>();
            return themeContext.WorkingThemeName;
        }

        protected virtual string CreateCacheKey(string prefix, string name, string controllerName, string areaName, string theme)
        {
            return String.Format(CultureInfo.InvariantCulture, CacheKeyFormat,
                                 GetType().AssemblyQualifiedName, prefix, name, controllerName, areaName, theme);
        }

        protected virtual string AppendDisplayModeToCacheKey(string cacheKey, string displayMode)
        {
            return cacheKey + displayMode + ":";
        }

        public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }
            if (String.IsNullOrEmpty(partialViewName))
            {
                throw new ArgumentException("Partial view name cannot be null or empty.", "partialViewName");
            }

            string[] searched;
            var theme = GetCurrentTheme();
            string controllerName = controllerContext.RouteData.GetRequiredString("controller");
            string partialPath = GetPath(controllerContext, PartialViewLocationFormats, AreaPartialViewLocationFormats, "PartialViewLocationFormats", partialViewName, controllerName, theme, CacheKeyPrefixPartial, useCache, out searched);

            if (String.IsNullOrEmpty(partialPath))
            {
                return new ViewEngineResult(searched);
            }

            return new ViewEngineResult(CreatePartialView(controllerContext, partialPath), this);
        }

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }
            if (String.IsNullOrEmpty(viewName))
            {
                throw new ArgumentException("View name cannot be null or empty.", "viewName");
            }

            string[] viewLocationsSearched;
            string[] masterLocationsSearched;

            var theme = GetCurrentTheme();
            string controllerName = controllerContext.RouteData.GetRequiredString("controller");
            string viewPath = GetPath(controllerContext, ViewLocationFormats, AreaViewLocationFormats, "ViewLocationFormats", viewName, controllerName, theme, CacheKeyPrefixView, useCache, out viewLocationsSearched);
            string masterPath = GetPath(controllerContext, MasterLocationFormats, AreaMasterLocationFormats, "MasterLocationFormats", masterName, controllerName, theme, CacheKeyPrefixMaster, useCache, out masterLocationsSearched);

            if (String.IsNullOrEmpty(viewPath) || (String.IsNullOrEmpty(masterPath) && !String.IsNullOrEmpty(masterName)))
            {
                return new ViewEngineResult(viewLocationsSearched.Union(masterLocationsSearched));
            }

            return new ViewEngineResult(CreateView(controllerContext, viewPath, masterPath), this);
        }

        protected virtual string GetPath(ControllerContext controllerContext, string[] locations, string[] areaLocations, string locationsPropertyName, string name, string controllerName, string theme, string cacheKeyPrefix, bool useCache, out string[] searchedLocations)
        {
            searchedLocations = _emptyLocations;
            if (string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }
            string areaName = GetAreaName(controllerContext.RouteData);

            //little hack to get nop's admin area to be in /Administration/ instead of /Nop/Admin/ or Areas/Admin/
            if (!string.IsNullOrEmpty(areaName) && areaName.Equals("admin", StringComparison.InvariantCultureIgnoreCase))
            {
                var newLocations = areaLocations.ToList();
                newLocations.Insert(0, "~/Administration/Views/{1}/{0}.cshtml");
                newLocations.Insert(0, "~/Administration/Views/Shared/{0}.cshtml");
                areaLocations = newLocations.ToArray();
            }

            bool flag = !string.IsNullOrEmpty(areaName);
            List<ViewLocation> viewLocations = GetViewLocations(locations, flag ? areaLocations : null);
            if (viewLocations.Count == 0)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Properties cannot be null or empty.", new object[] { locationsPropertyName }));
            }
            bool flag2 = IsSpecificPath(name);
            string key = this.CreateCacheKey(cacheKeyPrefix, name, flag2 ? string.Empty : controllerName, areaName, theme);
            if (useCache)
            {
                var cached = this.ViewLocationCache.GetViewLocation(controllerContext.HttpContext, key);
                if (cached != null)
                {
                    return cached;
                }
            }
            if (!flag2)
            {
                return this.GetPathFromGeneralName(controllerContext, viewLocations, name, controllerName, areaName, theme, key, ref searchedLocations);
            }
            return this.GetPathFromSpecificName(controllerContext, name, key, ref searchedLocations);
        }

        protected virtual string GetPathFromGeneralName(ControllerContext controllerContext, List<ViewLocation> locations, string name, string controllerName, string areaName, string theme, string cacheKey, ref string[] searchedLocations)
        {
            string virtualPath = string.Empty;
            searchedLocations = new string[locations.Count];
            for (int i = 0; i < locations.Count; i++)
            {
                string str2 = locations[i].Format(name, controllerName, areaName, theme);
                if (this.FileExists(controllerContext, str2))
                {
                    searchedLocations = _emptyLocations;
                    virtualPath = str2;
                    this.ViewLocationCache.InsertViewLocation(controllerContext.HttpContext, cacheKey, virtualPath);
                    return virtualPath;
                }
                searchedLocations[i] = str2;
            }
            return virtualPath;
        }

        protected virtual string GetPathFromSpecificName(ControllerContext controllerContext, string name, string cacheKey, ref string[] searchedLocations)
        {
            string result = name;

            if (!(FilePathIsSupported(name) && FileExists(controllerContext, name)))
            {
                result = String.Empty;
                searchedLocations = new[] { name };
            }

            ViewLocationCache.InsertViewLocation(controllerContext.HttpContext, cacheKey, result);
            return result;
        }

        protected virtual bool FilePathIsSupported(string virtualPath)
        {
            if (FileExtensions == null)
            {
                // legacy behavior for custom ViewEngine that might not set the FileExtensions property
                return true;
            }
            else
            {
                // get rid of the '.' because the FileExtensions property expects extensions withouth a dot.
                string extension = GetExtensionThunk(virtualPath).TrimStart('.');
                return FileExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
            }
        }

        protected virtual List<ViewLocation> GetViewLocations(string[] viewLocationFormats, string[] areaViewLocationFormats)
        {
            List<ViewLocation> allLocations = new List<ViewLocation>();

            if (areaViewLocationFormats != null)
            {
                foreach (string areaViewLocationFormat in areaViewLocationFormats)
                {
                    allLocations.Add(new AreaAwareViewLocation(areaViewLocationFormat));
                }
            }

            if (viewLocationFormats != null)
            {
                foreach (string viewLocationFormat in viewLocationFormats)
                {
                    allLocations.Add(new ViewLocation(viewLocationFormat));
                }
            }

            return allLocations;
        }

        protected virtual bool IsSpecificPath(string name)
        {
            char c = name[0];
            return (c == '~' || c == '/');
        }


        #endregion

        #region Nested classes

        public class AreaAwareViewLocation : ViewLocation
        {
            public AreaAwareViewLocation(string virtualPathFormatString)
                : base(virtualPathFormatString)
            {
            }

            public override string Format(string viewName, string controllerName, string areaName, string theme)
            {
                return string.Format(CultureInfo.InvariantCulture, _virtualPathFormatString, viewName, controllerName, areaName, theme);
            }
        }

        public class ViewLocation
        {
            protected readonly string _virtualPathFormatString;

            public ViewLocation(string virtualPathFormatString)
            {
                _virtualPathFormatString = virtualPathFormatString;
            }

            public virtual string Format(string viewName, string controllerName, string areaName, string theme)
            {
                return string.Format(CultureInfo.InvariantCulture, _virtualPathFormatString, viewName, controllerName, theme);
            }
        }
        #endregion

    }
}
