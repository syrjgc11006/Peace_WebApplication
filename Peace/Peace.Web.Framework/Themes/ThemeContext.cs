using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace.Web.Framework.Themes
{
    public class ThemeContext:IThemeContext
    {

        public string WorkingThemeName
        {
            get
            {
                return "Peace";
            }
            set
            {
                return;
            }
        }
    }
}
