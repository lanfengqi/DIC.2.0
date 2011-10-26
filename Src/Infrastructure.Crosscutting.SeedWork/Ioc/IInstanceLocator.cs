using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Crosscutting.SeedWork.Ioc
{
    /// <summary>
    /// IOC接口
    /// </summary>
    public interface IInstanceLocator
    {
        /// <summary>
        /// 获取实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetInstance<T>();

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        object GetInstance(Type type);

        /// <summary>
        /// 类型是否注册
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        bool IsTypeRegistered<T>();

        /// <summary>
        /// 类型是否注册
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool IsTypeRegistered(Type type);
    }
}
