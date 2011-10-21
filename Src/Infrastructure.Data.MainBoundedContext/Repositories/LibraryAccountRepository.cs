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
    public class LibraryAccountRepository : Repository<LibraryAccount, Guid>, ILibraryAccountRepository
    {
        public LibraryAccountRepository(IUnitOfWork iUnitOfWork, IDatabaseFactory databaseFactory)
            : base(iUnitOfWork, databaseFactory)
        {
        }

    }
}
