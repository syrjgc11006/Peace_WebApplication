using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peace.Model;
using Peace.Data;

namespace Peace.Web.Framework
{
    public interface IWorkContext
    {

        /// <summary>
        /// Gets or sets the current customer
        /// </summary>
        User CurrentUser { get; set; }
        /// <summary>
        /// Gets or sets the original customer (in case the current one is impersonated)
        /// </summary>

        /// <summary>
        /// Get or set value indicating whether we're in admin area
        /// </summary>
        bool IsAdmin { get; set; }
        bool IsCurrentUser { get; }

        bool SendMail(string toEmails, string emailText, string subject);

        /// <summary>
        /// 异步邮件发送
        /// </summary>
        /// <param name="toEmails"></param>
        /// <param name="emailText"></param>
        /// <param name="subject"></param>
        void AsyncSendMail(string toEmails, string emailText, string subject);
    }
}
