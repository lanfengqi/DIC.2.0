using System;


namespace Infrastructure.Crosscutting.SeedWork.Logging
{

    /// <summary>
    /// Common contract for trace instrumentation. You 
    /// can implement this contrat with several frameworks.
    /// .NET Diagnostics API, EntLib, Log4Net,NLog etc.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log message information 
        /// </summary>
        /// <param name="message">The information message to write</param>
        /// <param name="args">The arguments values</param>
        void LogInfo(string message, params object[] args);

        /// <summary>
        /// Log warning message
        /// </summary>
        /// <param name="message">The warning message to write</param>
        /// <param name="args">The argument values</param>
        void LogWarning(string message, params object[] args);

        /// <summary>
        /// Log error message
        /// </summary>
        /// <param name="message">The error message to write</param>
        /// <param name="args">The arguments values</param>
        void LogError(string message, params object[] args);

        /// <summary>
        /// Log error message
        /// </summary>
        /// <param name="message">The error message to write</param>
        /// <param name="exception">The exception associated with this error</param>
        /// <param name="args">The arguments values</param>
        void LogError(string message, Exception exception, params object[] args);
    }
}
