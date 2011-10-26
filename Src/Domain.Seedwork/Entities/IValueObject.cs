using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Seedwork.Entities
{
    /// <summary>
    /// 值对象接口
    /// </summary>
    public interface IValueObject
    {
        /// <summary>
        /// 获取原值
        /// </summary>
        /// <returns></returns>
        IEnumerable<object> GetAtomicValues();
    }
}
