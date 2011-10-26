using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Domain.MainBoundedContext.Contexts;
using Domain.MainBoundedContext.Entities;
using Domain.MainBoundedContext.Services;
using Domain.Seedwork;
using Infrastructure.Crosscutting.MainBoundedContent.Logging;
using Infrastructure.Crosscutting.MainBoundedContent.Unity;
using Infrastructure.Crosscutting.SeedWork.Ioc;
using Infrastructure.Crosscutting.SeedWork.Logging;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.MainBoundedContext.Repositories;
using Infrastructure.Data.MainBoundedContext.Repositories;
using Infrastructure.Data.Seedwork;
using Infrastructure.Data.Seedwork.Scheduling;
using Domain.Seedwork.Repository;

namespace Domain.Tests
{
    [TestClass]
    public class BorrowBooksContextTest
    {
        [ClassInitialize()]
        public static void ClassInitialze(TestContext context)
        {
            IUnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<ILibraryService, LibraryService>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IBookRepository, BookRepository>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<ILibraryAccountRepository, LibraryAccountRepository>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IBorrowInfoRepository, BorrowInfoRepository>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IDatabaseFactory, DatabaseFactory>();
            unityContainer.RegisterType<ILoadBalanceScheduling, RoundRobinScheduling>(
                new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IUnitOfWork, UnitOfWork>(new ContainerControlledLifetimeManager());

            LoggerFactory.SetCurrent(new Log4netLogFactory());
            IocFactory.SetCurrent(new UnityFactory(unityContainer));

            DomainInitializer.Current.InitializeDomain(typeof(Book).Assembly);
            DomainInitializer.Current.ResolveDomainEvents(typeof(Book).Assembly);
        }

        [TestMethod]
        public void BorrowBooks()
        {
            IInstanceLocator ioc = IocFactory.CreateIoc();

            var book1 = new Book { BookName = "C#高级编程", Author = "Jhon Smith", ISBN = "56-YAQ-23452", Publisher = "清华大学出版社", Description = "A very good book." };
            var book2 = new Book { BookName = "JQuery In Action", Author = "Jhon Smith", ISBN = "09-BEH-23452", Publisher = "人民邮电出版社", Description = "A very good book." };

            IBookRepository bookRepository = ioc.GetInstance<IBookRepository>();
            bookRepository.Add(book1);
            bookRepository.Add(book2);

            //创建一个图书馆用户帐号，用户凭帐号借书
            var libraryAccount = new LibraryAccount("12345678876543") { OwnerName = "赖小天", IsLocked = false };
            ILibraryAccountRepository libraryAccountRepository = ioc.GetInstance<ILibraryAccountRepository>();
            libraryAccountRepository.Add(libraryAccount);

            //创建并启动借书场景
            new BorrowBooksContext().Interaction(libraryAccount, new List<Book> { book1, book2 });
        }
    }
}
