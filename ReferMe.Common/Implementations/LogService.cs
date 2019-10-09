using log4net;
using ReferMe.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferMe.Common.Implementations
{
    public class LogService : ILogService
    {
        private ILog logger;
        private bool isConfigured = false;

        public LogService()
        {
            if (!isConfigured)
            {
                logger = LogManager.GetLogger(typeof(LogService));
                log4net.Config.XmlConfigurator.Configure();
            }
        }

        public ILog Logger()
        {
            return logger;
        }

    }
}
