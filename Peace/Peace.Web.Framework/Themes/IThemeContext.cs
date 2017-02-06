using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace.Web.Framework.Themes
{
    public interface IThemeContext
    {
        /// <summary>
        /// 获取当前系统的名称
        /// </summary>
        string WorkingThemeName { get; set; }
    }
}
