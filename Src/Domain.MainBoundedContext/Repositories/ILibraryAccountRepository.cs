using System;
using Domain.MainBoundedContext.Entities;
using Domain.Seedwork.Repository;


namespace Domain.MainBoundedContext.Repositories
{
    public interface ILibraryAccountRepository : IRepository<LibraryAccount, Guid>
    {
    }
}
