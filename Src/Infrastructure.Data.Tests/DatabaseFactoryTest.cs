
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Infrastructure.Data.Seedwork;
using Infrastructure.Data.Seedwork.Scheduling;

namespace Infrastructure.Data.Tests
{
    [TestClass]
    public class DatabaseFactoryTest
    {
        [TestMethod]
        public void Current()
        {
            WeightedRoundRobinScheduling weighted = new WeightedRoundRobinScheduling();
            DatabaseFactory databaseFactory = new DatabaseFactory(weighted);

            databaseFactory.Current();


        }
    }
}
