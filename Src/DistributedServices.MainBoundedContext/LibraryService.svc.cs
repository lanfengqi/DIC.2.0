using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Domain.MainBoundedContext.Entities;

namespace DistributedServices.MainBoundedContext
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LibraryService" in code, svc and config file together.
    public class LibraryService : ILibraryService
    {
        public bool BorrowBooks(LibraryAccount libraryAccount, List<Book> books)
        {
            Application.MainBoundedContext.ILibraryService libraryService = new Application.MainBoundedContext.LibraryService();
            return libraryService.BorrowBooks(libraryAccount, books);
        }
    }
}
