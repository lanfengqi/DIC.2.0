using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Domain.MainBoundedContext.Entities;

namespace DistributedServices.MainBoundedContext
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILibraryService" in both code and config file together.
    [ServiceContract]
    public interface ILibraryService
    {
        
        /// <summary>
        /// 借书
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        bool BorrowBooks(LibraryAccount libraryAccount, List<Book> books);
    }
}
