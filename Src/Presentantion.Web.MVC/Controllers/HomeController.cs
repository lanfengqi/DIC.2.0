using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.MainBoundedContext.Entities;
using Infrastructure.Crosscutting.MainBoundedContent.Cache;

using Infrastructure.Crosscutting.SeedWork.Cache;


namespace Presentantion.Web.MVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ICacheStrategy cacheStrategy = CacheFactory.Create();
            cacheStrategy.AddObject("key", "keyValue");


            object objCache = cacheStrategy.RetrieveObject("key");


            //var book1 = new Book { BookName = "C#高级编程", Author = "Jhon Smith", ISBN = "56-YAQ-23452", Publisher = "清华大学出版社", Description = "A very good book." };
            //var book2 = new Book { BookName = "JQuery In Action", Author = "Jhon Smith", ISBN = "09-BEH-23452", Publisher = "人民邮电出版社", Description = "A very good book." };

            ////创建一个图书馆用户帐号，用户凭帐号借书
            //var libraryAccount = new LibraryAccount("12345678876543") { OwnerName = "赖小天", IsLocked = false };
            //Application.MainBoundedContext.ILibraryService libraryService = new Application.MainBoundedContext.LibraryService();
            //libraryService.BorrowBooks(libraryAccount, new List<Book> { book1, book2 });
            return View();
        }

    }
}
