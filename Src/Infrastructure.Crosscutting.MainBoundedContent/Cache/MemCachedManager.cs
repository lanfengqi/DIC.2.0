using System;
using System.Net;
using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;

namespace Infrastructure.Crosscutting.MainBoundedContent.Cache
{
    /// <summary>
    /// MemCached管理操作类
    /// </summary>
    public class MemCachedManager
    {
        #region 静态方法和属性
        private MemcachedClient mc = null;

        private MemCachedConfigInfo memCachedConfigInfo = null;

        private string[] serverList = null;
        #endregion

        public MemCachedManager()
        {
            memCachedConfigInfo = MemCachedConfigs.GetConfig();
            CreateManager();
        }

        private void CreateManager()
        {
            serverList = memCachedConfigInfo.ServerList.Split(',');
            MemcachedClientConfiguration config = new MemcachedClientConfiguration();
            foreach (string server in ServerList)
            {
                config.Servers.Add(new IPEndPoint(
                    IPAddress.Parse(server.Substring(0, server.LastIndexOf(':'))), Int32.Parse(server.Substring(server.LastIndexOf(':') + 1))));
            }
            config.Protocol = MemcachedProtocol.Text;
            config.Authentication.Type = typeof(PlainTextAuthenticator);
            config.SocketPool.MaxPoolSize = memCachedConfigInfo.MaxPoolSize;
            config.SocketPool.MinPoolSize = memCachedConfigInfo.MinPoolSize;
            config.SocketPool.ConnectionTimeout = new TimeSpan(0, 0, memCachedConfigInfo.ConnectionTimeout);
            config.SocketPool.ReceiveTimeout = new TimeSpan(0, 0, memCachedConfigInfo.ReceiveTimeout);
            config.SocketPool.DeadTimeout = new TimeSpan(0, 0, memCachedConfigInfo.DeadTimeout);
            config.SocketPool.QueueTimeout = new TimeSpan(0, 0, memCachedConfigInfo.QueueTimeout);

            mc = new MemcachedClient(config);
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
        public MemcachedClient CacheClient
        {
            get
            {
                if (mc == null)
                    CreateManager();

                return mc;
            }
        }

        public void Dispose()
        {


        }

    }
}