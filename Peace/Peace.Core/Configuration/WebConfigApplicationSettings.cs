using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace.Core.Configuration
{
    public class WebConfigApplicationSettings : IApplicationSettings
    {
        public string LoggerName
        {
            get { return ConfigurationManager.AppSettings["LoggerName"]; }
        }

        public string NumberOfResultsPerPage
        {
            get { return ConfigurationManager.AppSettings["NumberOfResultsPerPage"]; }
        }
    }
}
