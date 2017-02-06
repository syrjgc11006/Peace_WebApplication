using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace.Core.Authentication
{
    public class AuthenUser
    {
        public string AuthenticationToken { get; set; }
        public string UserName { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
