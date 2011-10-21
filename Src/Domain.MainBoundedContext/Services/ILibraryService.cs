using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.MainBoundedContext.Entities;

namespace Domain.MainBoundedContext.Services
{
    /// <summary>
    /// 图书馆服务
    /// </summary>
    public interface ILibraryService
    {
        /// <summary>
        /// 将某本书借给某人
        /// </summary>
        void LendBook(Book book, LibraryAccount libraryAccount);
        /// <summary>
        /// 接收已归还的书
        /// </summary>
        void ReceiveReturnedBook(Book book, LibraryAccount libraryAccount);

        /// <summary>
        /// 图书入库
        /// </summary>
        void StoreBook(Book book, int count, string location);

        /// <summary>
        /// 图书出库
        /// </summary>
        void OutBook(Book book, int count);

        /// <summary>
        /// 提供某本书的库存信息
        /// </summary>
        BookStoreInfo GetBookStoreInfo(Guid bookId);
    }
}
