using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
namespace Peace.Core.Authentication
{
    /// <summary>
    /// Asp.net登录验证，用于记住密码
    /// </summary>
    public class AspMembershipAuthentication : ILocalAuthenticationService
    {
        public AuthenUser Login(string name, string password)
        {
            AuthenUser user = new AuthenUser();
            user.IsAuthenticated = false;
            if (Membership.ValidateUser(name, password))
            {
                MembershipUser validatedUser = Membership.GetUser(name);
                user.AuthenticationToken = validatedUser.ProviderUserKey.ToString();
                user.UserName = name;
                user.IsAuthenticated = true;
            }
            return user;
        }

        public AuthenUser RegisterUser(string name, string password, string email = "")
        {
            MembershipCreateStatus status;
            AuthenUser user = new AuthenUser();
            user.IsAuthenticated = false;
            if (string.IsNullOrEmpty(email))
            {
                Membership.CreateUser(name, password, name, Guid.NewGuid().ToString()
                , Guid.NewGuid().ToString(), true, out status);
            }
            else
            {
                Membership.CreateUser(name, password, email, Guid.NewGuid().ToString()
                   , Guid.NewGuid().ToString(), true, out status);
            }

            if (status == MembershipCreateStatus.Success)
            {
                MembershipUser newlyCreatedUser = Membership.GetUser(name);
                user.AuthenticationToken = newlyCreatedUser.ProviderUserKey.ToString();
                user.UserName = name;
                user.IsAuthenticated = true;
            }
            else
            {
                switch (status)
                {
                    case MembershipCreateStatus.DuplicateEmail:
                        throw new InvalidOperationException(
                               "There is already a user with this email address.");
                    case MembershipCreateStatus.DuplicateUserName:
                        throw new InvalidOperationException(
                               "There is already a user with this email address.");
                    case MembershipCreateStatus.InvalidEmail:
                        throw new InvalidOperationException(
                               "Your email address is invalid");
                    default:
                        throw new InvalidOperationException(
                        "There was a problem creating your account. Please try again.");
                }
            }
            return user;
        }
    }
}
