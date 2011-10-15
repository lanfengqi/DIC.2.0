using System.Collections.Generic;


namespace Domain.Seedwork.Event
{
    /// <summary>
    /// 领域事件接口
    /// </summary>
    public interface IDomainEvent
    {
        IList<object> Results { get; }
        T GetTypedResult<T>();
        IList<T> GetTypedResults<T>();
    }
}
