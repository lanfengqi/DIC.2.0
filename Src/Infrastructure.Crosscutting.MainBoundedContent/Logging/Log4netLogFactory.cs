using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Infrastructure.Crosscutting.SeedWork.Logging;

namespace Infrastructure.Crosscutting.MainBoundedContent.Logging
{
    /// <summary>
    /// log4net 工厂
    /// </summary>
    public class Log4netLogFactory : ILoggerFactory
    {
        /// <summary>
        /// Create the trace source log
        /// </summary>
        /// <returns>New ILog based on Trace Source infrastructure</returns>
        public ILogger Create()
        {
            return new Log4netLog();
            ;
        }
    }
}
