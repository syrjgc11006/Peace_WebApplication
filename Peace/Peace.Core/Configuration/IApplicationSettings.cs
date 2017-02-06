using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace.Core.Configuration
{
    public interface IApplicationSettings
    {
        string LoggerName { get; }
        string NumberOfResultsPerPage { get; }
    }
}
