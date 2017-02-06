using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace.Core.Authentication
{
    public interface IFormsAuthentication
    {
        void SetAuthenticationToken(string token, bool isRemenber);

        string GetAuthenticationToken();

        void SignOut();
    }
}
