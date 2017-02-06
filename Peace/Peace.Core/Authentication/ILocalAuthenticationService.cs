using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace.Core.Authentication
{
    /// <summary>
    /// 登录本地数据库接口
    /// </summary>
    public interface ILocalAuthenticationService
    {
        AuthenUser Login(string name, string password);
        AuthenUser RegisterUser(string name, string password, string email = "");
    }
}
