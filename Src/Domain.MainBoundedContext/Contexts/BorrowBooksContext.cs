using System.Collections.Generic;
using Domain.MainBoundedContext.Entities;
using Domain.MainBoundedContext.Roles;

namespace Domain.MainBoundedContext.Contexts
{
    public class BorrowBooksContext
    {
        public void Interaction(LibraryAccount account, IEnumerable<Book> books)
        {
            var borrower = account.ActAs<IBorrower>();
            foreach (var book in books)
            {
                borrower.BorrowBook(book);
            }
        }
    }
}
