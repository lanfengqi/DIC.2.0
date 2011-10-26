using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Domain.MainBoundedContext.Entities;
using Domain.MainBoundedContext.Repositories;
using Domain.Seedwork;
using Domain.Seedwork.Repository;
using Infrastructure.Crosscutting.MainBoundedContent.Logging;
using Infrastructure.Crosscutting.MainBoundedContent.Unity;
using Infrastructure.Crosscutting.SeedWork.Ioc;
using Infrastructure.Crosscutting.SeedWork.Logging;
using Infrastructure.Data.MainBoundedContext.Repositories;
using Infrastructure.Data.Seedwork;
using Infrastructure.Data.Seedwork.Scheduling;
using Microsoft.Practices.Unity;

namespace DistributedServices.MainBoundedContext
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            IUnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<ILibraryService, LibraryService>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IBookRepository, BookRepository>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<ILibraryAccountRepository, LibraryAccountRepository>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IBorrowInfoRepository, BorrowInfoRepository>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IDatabaseFactory, DatabaseFactory>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<ILoadBalanceScheduling, WeightedRoundRobinScheduling>(
                new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IUnitOfWork, UnitOfWork>(new ContainerControlledLifetimeManager());

            LoggerFactory.SetCurrent(new Log4netLogFactory());
            IocFactory.SetCurrent(new UnityFactory(unityContainer));

            DomainInitializer.Current.InitializeDomain(typeof(Book).Assembly);
            DomainInitializer.Current.ResolveDomainEvents(typeof(Book).Assembly);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}