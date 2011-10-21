using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.MainBoundedContext.Entities;
using Domain.MainBoundedContext.Repositories;
using Domain.Seedwork.Repository;
using Infrastructure.Data.Seedwork;

namespace Infrastructure.Data.MainBoundedContext.Repositories
{
    public class BorrowInfoRepository : Repository<BorrowInfo, Guid>, IBorrowInfoRepository
    {

        public BorrowInfoRepository(IUnitOfWork iUnitOfWork, IDatabaseFactory databaseFactory)
            : base(iUnitOfWork, databaseFactory)
        {
        }

        public IList<BorrowInfo> FindNotReturnedBorrowInfos(Guid borrowerId)
        {
            return GetAll().Where(borrowInfo => borrowInfo.LibraryAccount.Id == borrowerId && borrowInfo.ReturnTime == null).ToList();
        }
        public BorrowInfo FindNotReturnedBorrowInfo(Guid borrowerId, Guid bookId)
        {
            return GetAll().FirstOrDefault(borrowInfo => borrowInfo.LibraryAccount.Id == borrowerId && borrowInfo.Book.Id == bookId && borrowInfo.ReturnTime == null);
        }

    }
}
