using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Domain.MainBoundedContext.Entities;
using Domain.MainBoundedContext.Repositories;
using Domain.Seedwork;
using Domain.Seedwork.Repository;
using Infrastructure.Crosscutting.MainBoundedContent.Cache;
using Infrastructure.Crosscutting.MainBoundedContent.Logging;
using Infrastructure.Crosscutting.MainBoundedContent.Unity;
using Infrastructure.Crosscutting.SeedWork.Cache;
using Infrastructure.Crosscutting.SeedWork.Ioc;
using Infrastructure.Crosscutting.SeedWork.Logging;
using Infrastructure.Data.MainBoundedContext.Repositories;
using Infrastructure.Data.Seedwork;
using Infrastructure.Data.Seedwork.Scheduling;
using Microsoft.Practices.Unity;
using Domain.MainBoundedContext.Services;

namespace Presentantion.Web.MVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<ILibraryService, LibraryService>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IBookRepository, BookRepository>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<ILibraryAccountRepository, LibraryAccountRepository>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IBorrowInfoRepository, BorrowInfoRepository>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IDatabaseFactory, DatabaseFactory>();
            unityContainer.RegisterType<ILoadBalanceScheduling, WeightedRoundRobinScheduling>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IUnitOfWork, UnitOfWork>(new ContainerControlledLifetimeManager());

            //设置IOC
            IocFactory.SetCurrent(new UnityFactory(unityContainer));
            //设置Logger
            LoggerFactory.SetCurrent(new Log4netLogFactory());

            //初始化Domain
            DomainInitializer.Current.InitializeDomain(typeof(Book).Assembly);
            DomainInitializer.Current.ResolveDomainEvents(typeof(Book).Assembly);

            //初始化缓存
            ICacheStrategy cacheStrategy = new MemCachedStrategy(
                new MemCachedManager(Server.MapPath("/Content/xml/memCachedConfig.xml"))
                );
            CacheFactory.SetCurrent(cacheStrategy);

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}