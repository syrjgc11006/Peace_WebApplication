using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peace.Data;

namespace Peace.Model
{
    public class UserRegistrationRequest
    {
        public User User { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsApproved { get; set; }
        public string Mobile { get; set; }


        public UserRegistrationRequest(User user, string email, string mobile, string username,
            string password,
            bool isApproved = true)
        {
            this.User = user;
            this.Email = email;
            this.Username = username;
            this.Password = password;
            this.IsApproved = isApproved;
            Mobile = mobile;
        }
    }
}
