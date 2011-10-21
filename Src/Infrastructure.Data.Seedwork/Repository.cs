using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Domain.Seedwork.Entities;
using Domain.Seedwork.Repository;
using Domain.Seedwork.Specification;
using Infrastructure.Crosscutting.SeedWork.Logging;
using Infrastructure.Data.Seedwork.Resources;
using NHibernate;
using NHibernate.Linq;

namespace Infrastructure.Data.Seedwork
{
    public abstract class Repository<TAggregateRoot, TAggregateRootId> :
      IRepository<TAggregateRoot, TAggregateRootId>,
      IPersistableRepository
        where TAggregateRoot : Entity<TAggregateRootId>, IAggregateRoot<TAggregateRootId>
    {
        #region Private Variables
        private ISession session;
        #endregion

        #region Constructors

        public Repository(IUnitOfWork iUnitOfWork, IDatabaseFactory databaseFactory)
        {
            session = databaseFactory.Current();
            iUnitOfWork.RegisterRepository(this);
        }

        #endregion

        #region IRepository<TAggregateRoot, TAggregateRootId> Members

        /// <summary>
        /// Add item into repository
        /// </summary>
        /// <param name="item">Item to add to repository</param>
        public void Add(TAggregateRoot item)
        {
            if (item != (TAggregateRoot)null)
            {
                session.Save(item);
                LoggerFactory.CreateLog()
                          .LogInfo(Messages.trace_AddedItemRepository, typeof(TAggregateRoot).ToString());
            }
            else
            {
                LoggerFactory.CreateLog()
                          .LogInfo(Messages.info_CannotAddNullEntity, typeof(TAggregateRoot).ToString());
            }
        }

        /// <summary>
        /// Delete item 
        /// </summary>
        /// <param name="item">Item to delete</param>
        public void Remove(TAggregateRoot item)
        {
            if (item != (TAggregateRoot)null)
            {
                session.Delete(item);
                LoggerFactory.CreateLog()
                          .LogInfo(Messages.trace_DeletedItemRepository, typeof(TAggregateRoot).ToString());
            }
            else
            {
                LoggerFactory.CreateLog()
                          .LogInfo(Messages.info_CannotRemoveNullEntity, typeof(TAggregateRoot).ToString());
            }
        }

        /// <summary>
        /// Modify item
        /// </summary>
        /// <param name="item"><see cref="IRepository{TAggregateRoot,TAggregateRootId}"/></param>
        public virtual void Modify(TAggregateRoot item)
        {
            if (item != (TAggregateRoot)null)
            {
                session.Update(item);
                LoggerFactory.CreateLog()
                         .LogInfo(Messages.trace_AttachedItemToRepository, typeof(TAggregateRoot).ToString());
            }
            else
            {
                LoggerFactory.CreateLog()
                          .LogInfo(Messages.info_CannotModifyNullEntity, typeof(TAggregateRoot).ToString());
            }
        }

        /// <summary>
        /// Get element by entity key
        /// </summary>
        /// <param name="TAggregateRootId">entity key values, the order the are same of order in mapping.</param>
        /// <returns></returns>
        public TAggregateRoot Get(TAggregateRootId id)
        {
            if (id != null)
            {
                return session.Get<TAggregateRoot>(id);
            }
            else
                return null;
        }

        /// <summary>
        /// Get all elements of type {T} in repository
        /// </summary>
        /// <returns>List of selected elements</returns>
        public IEnumerable<TAggregateRoot> GetAll()
        {
            LoggerFactory.CreateLog()
                        .LogInfo(Messages.trace_GetAllRepository, typeof(TAggregateRoot).ToString());
            ICriteria crit = session.CreateCriteria(typeof(TAggregateRoot));
            return crit.List<TAggregateRoot>();

        }

        /// <summary>
        /// Get all elements of type {T} that matching a
        /// Specification <paramref name="specification"/>
        /// </summary>
        /// <param name="specification">Specification that result meet</param>
        /// <returns></returns>
        public IEnumerable<TAggregateRoot> AllMatching(ISpecification<TAggregateRoot> specification)
        {
            LoggerFactory.CreateLog()
                        .LogInfo(Messages.trace_GetBySpec, typeof(TAggregateRoot).ToString());
            return session.Query<TAggregateRoot>().Where(specification.SatisfiedBy());
        }

        /// <summary>
        /// Get all elements of type {T} in repository
        /// </summary>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageCount">Number of elements in each page</param>
        /// <param name="orderByExpression">Order by expression for this query</param>
        /// <param name="ascending">Specify if order is ascending</param>
        /// <returns>List of selected elements</returns>
        public IEnumerable<TAggregateRoot> GetPaged<KProperty>(int pageIndex, int pageCount, Expression<Func<TAggregateRoot, KProperty>> orderByExpression, bool ascending)
        {
            LoggerFactory.CreateLog()
                        .LogInfo(Messages.trace_GetPagedElementsRepository, typeof(TAggregateRoot).ToString());
            if (ascending)
            {
                return session.Query<TAggregateRoot>().OrderBy(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount)
                          .AsEnumerable();
            }
            else
            {
                return session.Query<TAggregateRoot>().OrderByDescending(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount)
                          .AsEnumerable();
            }
        }

        /// <summary>
        /// Get  elements of type {T} in repository
        /// </summary>
        /// <param name="filter">Filter that each element do match</param>
        /// <returns>List of selected elements</returns>
        public IEnumerable<TAggregateRoot> GetFiltered(Expression<Func<TAggregateRoot, bool>> filter)
        {
            LoggerFactory.CreateLog()
                        .LogInfo(Messages.trace_GetFilteredElementsRepository, typeof(TAggregateRoot).ToString());
            return session.Query<TAggregateRoot>().Where(filter)
                          .AsEnumerable();
        }
        #endregion

        #region IPersistableRepository Members

        public virtual void PersistChanges()
        {

        }

        #endregion
    }
}
