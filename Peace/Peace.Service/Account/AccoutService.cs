using Peace.Core;
using Peace.Core.Helpers;
using Peace.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peace.Model;
using Peace.Data;

namespace Peace.Services.Account
{
    public class AccoutService : IAccountService
    {
        private readonly IUserService _userService;

        public AccoutService(IUserService userService)
        {
            _userService = userService;
        }
        public UserLoginResults ValidateUser(string usernameOrEmail, string password)
        {
            User user = null;
            user = _userService.GetUserByUsername(usernameOrEmail);
            if (user == null && usernameOrEmail.Contains("@"))
            {
                user = _userService.GetUserByEmail(usernameOrEmail);
            }
            if (user == null)
                return UserLoginResults.UserNotExist;
            if (user.Deleted)
                return UserLoginResults.Deleted;
            if (!user.Active)
                return UserLoginResults.NotActive;
            string pwd = "";
            bool isValid = Encrypt.GetMd5Code(password) == user.Password;
            if (!isValid)
                return UserLoginResults.WrongPassword;

            //save last login date
            user.LastLoginDateUtc = DateTime.UtcNow;
            _userService.UpdateUser(user);
            return UserLoginResults.Successful;
        }

        public void SetEmail(User user, string newEmail)
        {
            throw new NotImplementedException();
        }

        public void SetUsername(User user, string newUsername)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            newUsername = newUsername.Trim();

            if (newUsername.Length > 100)
                throw new PeaceException("用户名太长");

            var user2 = _userService.GetUserByUsername(newUsername);
            if (user2 != null && user.id != user2.id)
                throw new PeaceException("用户名已经存在");

            user.Username = newUsername;
            _userService.UpdateUser(user);
        }

        public UserRegistrationResult RegisterUser(UserRegistrationRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            if (request.User == null)
                throw new ArgumentException("当前用户为空");

            var result = new UserRegistrationResult();

            if (request.User.IsRegistered())
            {
                result.AddError("当前用户已经注册");
                return result;
            }
            if (String.IsNullOrEmpty(request.Email))
            {
                result.AddError("邮箱不能为空");
                return result;
            }
            if (!CommonHelper.IsValidEmail(request.Email))
            {
                result.AddError("邮件格式错误");
                return result;
            }
            if (String.IsNullOrWhiteSpace(request.Password))
            {
                result.AddError("密码不能为空");
                return result;
            }
            if (String.IsNullOrWhiteSpace(request.Mobile))
            {
                result.AddError("手机号码不能为空");
                return result;
            }
            if (_userService.GetUserByUsername(request.Username) != null)
            {
                result.AddError("用户名已经存在");
                return result;
            }

            request.User.Username = request.Username;
            request.User.Email = request.Email;
            request.User.Mobile = request.Mobile;

            request.User.Password = Encrypt.GetMd5Code(request.Password);
            request.User.ImgUrl = "/Content/user_img.jpg";
            request.User.Active = request.IsApproved;

            // 添加基本角色。
            //var registeredRole = _userService.GetUserRoleBySystemName(SystemUserRoleNames.Registered);
            //if (registeredRole == null)
            //    throw new PortalException("'Registered' 角色加载失败");
            if (request.User.id == 0)
            {

                _userService.InsertUser(request.User);
                request.User = _userService.GetUserByUsername(request.Username);
            }
            //request.User.UserRoles.Add(registeredRole);
            //_userService.UpdateUser(request.User);
            result.Success = true;
            return result;
        }

        public PasswordChangeResult ChangePassword(ChangePasswordRequest request)
        {
            throw new NotImplementedException();
        }

        public bool ChangePassword(int userid, string password)
        {
            throw new NotImplementedException();
        }
    }
}
