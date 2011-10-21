using System.Collections.Generic;
using Infrastructure.Data.Seedwork.DbSnap;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Infrastructure.Data.Tests
{
    [TestClass]
    public class DbSnapConfigsTest
    {
        [TestMethod]
        public void GetEnableSnapList()
        {
            IList<DbSnapInfo> dbSnapInfo = DbSnapConfigs.GetEnableSnapList();
            Assert.IsNotNull(dbSnapInfo);
        }
    }
}
