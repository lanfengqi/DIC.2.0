using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure.Crosscutting.SeedWork.Logging;
using Infrastructure.Crosscutting.MainBoundedContent.Logging;

namespace Infrastructure.Crosscutting.Tests
{
    [TestClass]
    public partial class TraceSourceLogTest
    {
        [ClassInitialize()]
        public static void ClassInitialze(TestContext context)
        {
            LoggerFactory.SetCurrent(new TraceSourceLogFactory());
        }

        [TestMethod()]
        public void LogInfo()
        {
            ILogger logger = LoggerFactory.CreateLog();
            logger.LogInfo("{0}", "the info message");
        }

        [TestMethod()]
        public void LogWarning()
        {
            ILogger logger = LoggerFactory.CreateLog();
            logger.LogWarning("{0}","the warning message");
        }

        [TestMethod()]
        public void LogError()
        {
            ILogger logger = LoggerFactory.CreateLog();
            logger.LogError("{0}","the Error message");
        }

        [TestMethod()]
        public void LogErrorWithException()
        {
            //Arrange
            ILogger log = LoggerFactory.CreateLog();

            //Act
            log.LogError("{0}", new ArgumentNullException("param"), "the error message");
        }
    }
}
