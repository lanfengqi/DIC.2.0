
namespace Domain.Seedwork.Entities
{
    /// <summary>
    /// 实体接口
    /// </summary>
    /// <typeparam name="TEntityId"></typeparam>
    public interface IEntity<TEntityId>
    {
        TEntityId Id { get; }
    }
}
