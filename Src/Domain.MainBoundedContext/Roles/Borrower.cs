using System;
using Domain.MainBoundedContext.Entities;
using Domain.MainBoundedContext.Services;
using Domain.Seedwork.Role;
using Infrastructure.Crosscutting.SeedWork.Ioc;

namespace Domain.MainBoundedContext.Roles
{
    public interface IBorrower : IRole<Guid>
    {
        void BorrowBook(Book book);
        void ReturnBook(Book book);
    }

    public class Borrower :
        Role<LibraryAccount, Guid>, IBorrower
    {
        private ILibraryService libraryService;

        public Borrower(LibraryAccount account)
            : base(account)
        {
            this.libraryService = IocFactory.CreateIoc().GetInstance<ILibraryService>();
            if (account.IsLocked)
            {
                throw new NotSupportedException("Locked account is not allowed to act as borrower.");
            }
        }

        public void BorrowBook(Book book)
        {
            //通知图书馆把书借给我
            libraryService.LendBook(book, this.Actor);
        }
        public void ReturnBook(Book book)
        {
            //通知图书馆接收归还的书
            libraryService.ReceiveReturnedBook(book, this.Actor);
        }
    }
}
