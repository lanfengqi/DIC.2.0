namespace Infrastructure.Crosscutting.MainBoundedContent.Cache
{
    /// <summary>
    /// MemCached配置信息类文件
    /// </summary>
    public class MemCachedConfigInfo
    {

        private string _serverList;
        /// <summary>
        /// 链接地址
        /// </summary>
        public string ServerList
        {
            get
            {
                return _serverList;
            }
            set
            {
                _serverList = value;
            }
        }

        private string _poolName;
        /// <summary>
        /// 链接池名称
        /// </summary>
        public string PoolName
        {
            get
            {
                return string.IsNullOrEmpty(_poolName) ? "DiscuzNT_MemCache" : _poolName;
            }
            set
            {
                _poolName = value;
            }
        }

        private int _minPoolSize;
        /// <summary>
        /// 最小链接数
        /// </summary>
        public int MinPoolSize
        {
            get
            {
                return _minPoolSize > 0 ? _minPoolSize : 10;
            }
            set
            {
                _minPoolSize = value;
            }
        }

        private int _maxPoolSize;
        /// <summary>
        /// 最大链接数
        /// </summary>
        public int MaxPoolSize
        {
            get
            {
                return _maxPoolSize > 0 ? _maxPoolSize : 20;
            }
            set
            {
                _maxPoolSize = value;
            }
        }

        private int _connectionTimeout;
        /// <summary>
        /// 连接超时时间
        /// </summary>
        public int ConnectionTimeout
        {
            get
            {
                return _connectionTimeout > 0 ? _connectionTimeout : 10;
            }
            set
            {
                _connectionTimeout = value;
            }
        }

        private int _receiveTimeout;
        /// <summary>
        /// 接受超时时间
        /// </summary>
        public int ReceiveTimeout
        {
            get
            {
                return _receiveTimeout > 0 ? _receiveTimeout : 10;
            }
            set
            {
                _receiveTimeout = value;
            }
        }

        private int _deadTimeout;
        /// <summary>
        /// 死链接超时时间
        /// </summary>
        public int DeadTimeout
        {
            get
            {
                return _deadTimeout > 0 ? _deadTimeout : 10;
            }
            set
            {
                _deadTimeout = value;
            }
        }

        private int _queueTimeout;
        /// <summary>
        /// 队列超时
        /// </summary>
        public int QueueTimeout
        {
            get
            {
                return _queueTimeout > 0 ? _queueTimeout : 100;
            }
            set
            {
                _queueTimeout = value;
            }
        }
    }
}