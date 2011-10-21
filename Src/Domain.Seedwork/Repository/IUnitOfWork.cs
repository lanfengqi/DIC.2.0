using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Seedwork.Repository
{
    public interface IUnitOfWork 
        : IDisposable
    {
        /// <summary>
        /// Register Repository
        /// </summary>
        /// <param name="repository"></param>
        void RegisterRepository(IPersistableRepository repository);

        /// <summary>
        /// Rollback changes are not stored in the database at 
        /// this moment. See references of UnitOfWork pattern
        /// </summary>
        void SubmitChanges();
    }
}
