using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Domain.MainBoundedContext.Entities;

namespace Application.MainBoundedContext
{
    public interface ILibraryService
    {
        /// <summary>
        /// 借书
        /// </summary>
        /// <returns></returns>
        bool BorrowBooks(LibraryAccount libraryAccount, List<Book> books);
    }
}
