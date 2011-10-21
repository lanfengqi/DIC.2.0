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
    public class BookRepository : Repository<Book, Guid>, IBookRepository
    {
        public BookRepository(IUnitOfWork iUnitOfWork, IDatabaseFactory databaseFactory)
            : base(iUnitOfWork, databaseFactory)
        {

        }
    }
}
