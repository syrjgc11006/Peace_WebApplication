using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace.Model
{
    public class UserRegistrationResult
    {
        public IList<string> Errors { get; set; }

        public bool Success { get; set; }
        public UserRegistrationResult()
        {
            this.Errors = new List<string>();
        }

        public void AddError(string error)
        {
            this.Errors.Add(error);
        }
    }
}
