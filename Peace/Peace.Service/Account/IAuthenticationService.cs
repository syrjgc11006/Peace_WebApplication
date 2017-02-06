using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peace.Model;
using Peace.Data;

namespace Peace.Services.Account
{
    public interface IAuthenticationService
    {
        void SignIn(User user, bool createPersistentCookie);

        void SignOut();

        User GetAuthenticatedCustomer();

        bool IsCurrentUser { get; }
    }
}
