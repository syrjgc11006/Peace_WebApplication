using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace Peace.Core.Authentication
{
    public class AspFormsAuthentication : IFormsAuthentication
    {
        public void SetAuthenticationToken(string token,bool isRemenber)
        {
            FormsAuthentication.SetAuthCookie(token, isRemenber);
        }

        public string GetAuthenticationToken()
        {
            return HttpContext.Current.User.Identity.Name;
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}
