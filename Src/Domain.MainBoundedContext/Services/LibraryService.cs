using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.MainBoundedContext.Entities;
using Domain.MainBoundedContext.Repositories;

namespace Domain.MainBoundedContext.Services
{
    public class LibraryService
        : ILibraryService
    {
        private IBorrowInfoRepository borrowInfoRepository;
        public LibraryService(IBorrowInfoRepository borrowInfoRepository)
        {
            this.borrowInfoRepository = borrowInfoRepository;
        }

        public void LendBook(Book book, LibraryAccount libraryAccount)
        {
            borrowInfoRepository.Add(new BorrowInfo(book, libraryAccount, DateTime.Now));
        }

        public void ReceiveReturnedBook(Book book, LibraryAccount libraryAccount)
        {

        }

        public void StoreBook(Book book, int count, string location)
        {
            //图书入库时生成图书的库存信息

        }

        public void OutBook(Book book, int count)
        {

        }

        public BookStoreInfo GetBookStoreInfo(Guid bookId)
        {
            return null;
        }
    }
}
