using System;
using System.Collections.Generic;
using Domain.MainBoundedContext.Entities;
using Domain.Seedwork.Repository;


namespace Domain.MainBoundedContext.Repositories
{
    public interface IBorrowInfoRepository : IRepository<BorrowInfo, Guid>
    {
        IList<BorrowInfo> FindNotReturnedBorrowInfos(Guid borrowerId);
        BorrowInfo FindNotReturnedBorrowInfo(Guid borrowerId, Guid bookId);
    }
}
