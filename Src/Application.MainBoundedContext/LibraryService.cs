using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.MainBoundedContext.Contexts;
using Domain.MainBoundedContext.Entities;
using Domain.MainBoundedContext.Repositories;
using Infrastructure.Crosscutting.SeedWork.Ioc;

namespace Application.MainBoundedContext
{
    public class LibraryService : ILibraryService
    {
        /// <summary>
        /// 借书
        /// </summary>
        /// <returns></returns>
        public bool BorrowBooks(LibraryAccount libraryAccount, List<Book> books)
        {
            if (libraryAccount == null || books == null)
                return false;

            new BorrowBooksContext().Interaction(libraryAccount, books);
            return true;
        }

        /// <summary>
        /// 添加书籍
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Book book)
        {
            IInstanceLocator ioc = IocFactory.CreateIoc();
            IBookRepository bookRepository = ioc.GetInstance<IBookRepository>();
            bookRepository.Add(book);
        }
    }
}
