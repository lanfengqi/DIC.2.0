using System;
using System.Globalization;

using log4net.Appender;
using log4net.Config;
using log4net.Layout;
using Infrastructure.Crosscutting.SeedWork.Logging;

namespace Infrastructure.Crosscutting.MainBoundedContent.Logging
{
    public class Log4netLog : ILogger
    {
        private log4net.ILog log = null;
        public Log4netLog()
        {
            BasicConfigurator.Configure(new FileAppender(new PatternLayout("%d [%t]%-5p %c [%x] - %m%n"), "logfile.log", true));
            log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        /// <summary>
        /// Log message information 
        /// </summary>
        /// <param name="message">The information message to write</param>
        /// <param name="args">The arguments values</param>
        public void LogInfo(string message, params object[] args)
        {
            if (!String.IsNullOrEmpty(message))
            {
                var traceData = string.Format(CultureInfo.InvariantCulture, message, args);
                log.Info(traceData);
            }
        }

        /// <summary>
        /// Log warning message
        /// </summary>
        /// <param name="message">The warning message to write</param>
        /// <param name="args">The argument values</param>
        public void LogWarning(string message, params object[] args)
        {
            if (!String.IsNullOrEmpty(message))
            {
                var traceData = string.Format(CultureInfo.InvariantCulture, message, args);
                log.Warn(traceData);
            }

        }

        /// <summary>
        /// Log error message
        /// </summary>
        /// <param name="message">The error message to write</param>
        /// <param name="args">The arguments values</param>
        public void LogError(string message, params object[] args)
        {
            if (!String.IsNullOrEmpty(message))
            {
                var traceData = string.Format(CultureInfo.InvariantCulture, message, args);
                log.Error(traceData);
            }
        }

        /// <summary>
        /// Log error message
        /// </summary>
        /// <param name="message">The error message to write</param>
        /// <param name="exception">The exception associated with this error</param>
        /// <param name="args">The arguments values</param>
        public void LogError(string message, Exception exception, params object[] args)
        {
            if (!String.IsNullOrEmpty(message))
            {
                var traceData = string.Format(CultureInfo.InvariantCulture, message, args);
                var exceptionData = exception.ToString();
                log.Error(string.Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", traceData, exceptionData));
            }
        }
    }
}
