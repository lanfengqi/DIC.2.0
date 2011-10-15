using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Seedwork.Entities;
using Domain.Seedwork.Specification;

namespace Domain.Seedwork.Repository
{
    public interface  IRepository<TAggregateRoot, TAggregateRootId>
        where TAggregateRoot : Entity<TAggregateRootId>, IAggregateRoot<TAggregateRootId>
    {
        /// <summary>
        /// Add item into repository
        /// </summary>
        /// <param name="item">Item to add to repository</param>
        void Add(TAggregateRoot item);

        /// <summary>
        /// Delete item 
        /// </summary>
        /// <param name="item">Item to delete</param>
        void Remove(TAggregateRoot item);

        /// <summary>
        ///Track entity into this repository, really in UnitOfWork. 
        ///In EF this can be done with Attach and with Update in NH
        /// </summary>
        /// <param name="item">Item to attach</param>
        void TrackItem(TAggregateRoot item);

        /// <summary>
        /// Sets modified entity into the repository. 
        /// When calling Commit() method in UnitOfWork 
        /// these changes will be saved into the storage
        /// </summary>
        /// <param name="persisted">The persisted item</param>
        /// <param name="current">The current item</param>
        void Merge(TAggregateRoot persisted, TAggregateRoot current);

        /// <summary>
        /// Get element by entity key
        /// </summary>
        /// <param name="entityKeyValues">entity key values, the order the are same of order in mapping.</param>
        /// <returns></returns>
        TAggregateRoot Get(TAggregateRootId id);

        /// <summary>
        /// Get all elements of type {T} in repository
        /// </summary>
        /// <returns>List of selected elements</returns>
        IEnumerable<TAggregateRoot> GetAll();

        /// <summary>
        /// Get all elements of type {T} that matching a
        /// Specification <paramref name="specification"/>
        /// </summary>
        /// <param name="specification">Specification that result meet</param>
        /// <returns></returns>
        IEnumerable<TAggregateRoot> AllMatching(ISpecification<TAggregateRoot> specification);

        /// <summary>
        /// Get all elements of type {T} in repository
        /// </summary>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageCount">Number of elements in each page</param>
        /// <param name="orderByExpression">Order by expression for this query</param>
        /// <param name="ascending">Specify if order is ascending</param>
        /// <returns>List of selected elements</returns>
        IEnumerable<TAggregateRoot> GetPaged<KProperty>(int pageIndex, int pageCount, Expression<Func<TAggregateRoot, KProperty>> orderByExpression, bool ascending);

        /// <summary>
        /// Get  elements of type {T} in repository
        /// </summary>
        /// <param name="filter">Filter that each element do match</param>
        /// <returns>List of selected elements</returns>
        IEnumerable<TAggregateRoot> GetFiltered(Expression<Func<TAggregateRoot, bool>> filter);
    }
}
