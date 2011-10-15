using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Seedwork.Event
{
    /// <summary>
    /// 事件发布接口定义
    /// </summary>
    public interface IEventPublisher
    {
        void Publish(IDomainEvent evnt);
        void Publish(IEnumerable<IDomainEvent> evnts);
        void Publish(params IDomainEvent[] evnts);
    }
}
