using System;
using System.Collections;
using Memcached.ClientLibrary;

namespace Infrastructure.Crosscutting.MainBoundedContent.Cache
{
    /// <summary>
    /// MemCached管理操作类
    /// </summary>
    public class MemCachedManager
    {
        #region 静态方法和属性
        private  MemcachedClient mc = null;

        private SockIOPool pool = null;

        private MemCachedConfigInfo memCachedConfigInfo = null;

        private string[] serverList = null;
        #endregion

        public MemCachedManager(string xmlUrl)
        {
            memCachedConfigInfo = MemCachedConfigs.GetConfig(xmlUrl);
            CreateManager();
        }

        private void CreateManager()
        {
            serverList = memCachedConfigInfo.ServerList.Split(',');
            pool = SockIOPool.GetInstance(memCachedConfigInfo.PoolName);
            pool.SetServers(serverList);
            pool.InitConnections = memCachedConfigInfo.IntConnections;//初始化链接数
            pool.MinConnections = memCachedConfigInfo.MinConnections;//最少链接数
            pool.MaxConnections = memCachedConfigInfo.MaxConnections;//最大连接数
            pool.SocketConnectTimeout = memCachedConfigInfo.SocketConnectTimeout;//Socket链接超时时间
            pool.SocketTimeout = memCachedConfigInfo.SocketTimeout;// Socket超时时间
            pool.MaintenanceSleep = memCachedConfigInfo.MaintenanceSleep;//维护线程休息时间
            pool.Failover = memCachedConfigInfo.FailOver; //失效转移(一种备份操作模式)
            pool.Nagle = memCachedConfigInfo.Nagle;//是否用nagle算法启动socket
            pool.HashingAlgorithm = HashingAlgorithm.NewCompatibleHash;
            pool.Initialize();
            mc = new MemcachedClient();
            mc.PoolName = memCachedConfigInfo.PoolName;
            mc.EnableCompression = false;
        }

        /// <summary>
        /// 缓存服务器地址列表
        /// </summary>
        public string[] ServerList
        {
            set
            {
                if (value != null)
                    serverList = value;
            }
            get { return serverList; }
        }

        /// <summary>
        /// 客户端缓存操作对象
        /// </summary>
        public  MemcachedClient CacheClient
        {
            get
            {
                if (mc == null)
                    CreateManager();

                return mc;
            }
        }

        public  void Dispose()
        {
            if (pool != null)
                pool.Shutdown();
        }

    }
}