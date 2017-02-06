using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace.Core.Logging
{
    public interface ILogger
    {
        void Log(string message);

        void Error(string message);

        void Debugger(string message);

        void Warn(string message);
    }
}
