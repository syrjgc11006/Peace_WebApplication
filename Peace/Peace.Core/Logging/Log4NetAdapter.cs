using log4net;
using log4net.Config;
using Peace.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace.Core.Logging
{
    public class Log4NetAdapter : ILogger
    {
        private readonly ILog _log;

        public Log4NetAdapter()
        {
            XmlConfigurator.Configure();
            _log = LogManager.GetLogger(ApplicationSettingsFactory.GetApplicationSettings().LoggerName);
        }
        public void Log(string message)
        {
            _log.Info(message);
        }

        public void Error(string message)
        {
            _log.Error(message);
        }


        public void Debugger(string message)
        {
            _log.Debug(message);
        }


        public void Warn(string message)
        {
            _log.Warn(message);
        }
    }
}
