using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Infrastructure.Crosscutting.SeedWork.Ioc;
using Infrastructure.Crosscutting.MainBoundedContent.Unity;
using Microsoft.Practices.Unity;

namespace Infrastructure.Crosscutting.Tests
{
    [TestClass]
    public class InstanceLocatorTest
    {
        [ClassInitialize()]
        public static void ClassInitialze(TestContext context)
        {
            IUnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IDisposable, ShortLivedObject>(new ContainerControlledLifetimeManager());
            IocFactory.SetCurrent(new UnityFactory(unityContainer));
        }

        [TestMethod]
        public void GetInstance()
        {
            IInstanceLocator instance = IocFactory.CreateIoc();
            IDisposable disposable = instance.GetInstance<IDisposable>();
            Assert.IsNotNull(disposable);

            object obj = instance.GetInstance(typeof(IDisposable));
            Assert.IsNotNull(obj);

        }

        [TestMethod()]
        public void IsTypeRegistered()
        {
            IInstanceLocator instance = IocFactory.CreateIoc();
            bool disposable = instance.IsTypeRegistered<IDisposable>();
            Assert.IsTrue(disposable);

            bool obj = instance.IsTypeRegistered(typeof(IDisposable));
            Assert.IsTrue(obj);
        }
    }
}
