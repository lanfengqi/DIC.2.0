using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data.Seedwork.DbSnap
{

    [Serializable]
    public class DbSnapAppConfig 
    {
        private bool _appDbSnap;
        /// <summary>
        /// 是否启用快照，如不使用，则即使DbSnapInfoList已设置有效快照信息也不会使用。
        /// </summary>
        public bool AppDbSnap
        {
            get { return _appDbSnap; }
            set { _appDbSnap = value; }
        }

        private int _writeWaitTime = 6;
        /// <summary>
        /// 写操作等待时间(单位:秒), 说明:在执行完写操作之后，在该时间内的sql请求依旧会被发往master数据库
        /// </summary>
        public int WriteWaitTime
        {
            get { return _writeWaitTime; }
            set { _writeWaitTime = value; }
        }

        private string _loadBalanceScheduling = "WeightedRoundRobinScheduling";
        /// <summary>
        /// 负载均衡调度算法，默认为权重轮询调度算法 http://www.pcjx.com/Cisco/zhong/209068.html
        /// </summary>
        public string LoadBalanceScheduling
        {
            get { return _loadBalanceScheduling; }
            set { _loadBalanceScheduling = value; }
        }

        private bool _recordeLog = false;
        /// <summary>
        /// 是否记录日志
        /// </summary>
        public bool RecordeLog
        {
            get { return _recordeLog; }
            set { _recordeLog = value; }
        }


        private List<DbSnapInfo> _dbSnapInfoList;
        /// <summary>
        /// 快照轮循列表
        /// </summary>
        public List<DbSnapInfo> DbSnapInfoList
        {
            get { return _dbSnapInfoList; }
            set { _dbSnapInfoList = value; }
        }

    }
}
