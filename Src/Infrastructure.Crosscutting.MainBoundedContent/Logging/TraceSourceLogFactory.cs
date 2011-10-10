﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Infrastructure.Crosscutting.SeedWork.Logging;

namespace Infrastructure.Crosscutting.MainBoundedContent.Logging
{
    /// <summary>
    /// A Trace Source base, log factory
    /// </summary>
    public  class TraceSourceLogFactory
        :ILoggerFactory
    {
        /// <summary>
        /// Create the trace source log
        /// </summary>
        /// <returns>New ILog based on Trace Source infrastructure</returns>
        public ILogger Create()
        {
            return new TraceSourceLog();
        }
    }
}
