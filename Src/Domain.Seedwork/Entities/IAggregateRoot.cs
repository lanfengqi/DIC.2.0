namespace Domain.Seedwork.Entities
{
    /// <summary>
    /// 根接口定义
    /// </summary>
    public interface IAggregateRoot<TAggregateRootId> : IEntity<TAggregateRootId>
    {
    }
}
