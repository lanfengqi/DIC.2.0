using Domain.Seedwork.Entities;

namespace Domain.Seedwork.Role
{
    /// <summary>
    /// 角色
    /// </summary>
    /// <typeparam name="TActor"></typeparam>
    /// <typeparam name="TRoleId"></typeparam>
    public class Role<TActor, TRoleId> : Entity<TRoleId>, IAggregateRoot<TRoleId>, IRole<TRoleId>
           where TActor : Entity<TRoleId>, IAggregateRoot<TRoleId>
    {
        #region Constructor
        public Role(TActor actor)
            : base(actor.Id)
        {
            this.Actor = actor;
        }
        #endregion

        #region Members
        public TActor Actor { get; set; }
        #endregion
    }
}
