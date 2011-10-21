
using Infrastructure.Data.Seedwork.DbSnap;

namespace Infrastructure.Data.Seedwork.Scheduling
{
    /// <summary>
    /// 负载均衡调度接口
    /// </summary>
    public interface ILoadBalanceScheduling
    {
        /// <summary>
        /// 获取应用当前负载均衡调度算法下的快照链接信息
        /// </summary>
        /// <returns></returns>
        DbSnapInfo GetConnectDbSnap();
    }
}
