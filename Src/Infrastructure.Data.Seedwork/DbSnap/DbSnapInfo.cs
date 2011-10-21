using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data.Seedwork.DbSnap
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class DbSnapInfo
    {
        /// <summary>
        /// 源ID,用于唯一标识快照在数据库负载均衡中的信息
        /// </summary>
        private int _souceID;
        /// <summary>
        /// 源ID,用于唯一标识快照在数据库负载均衡中的信息
        /// </summary>
        public int SouceID
        {
            get { return _souceID; }
            set { _souceID = value; }
        }

        /// <summary>
        /// 快照是否有效
        /// </summary>
        private bool _enable;
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Enable
        {
            get { return _enable; }
            set { _enable = value; }
        }

        /// <summary>
        /// 快照链接
        /// </summary>
        private string _dbConnectString;
        /// <summary>
        /// 快照链接
        /// </summary>
        public string DbconnectString
        {
            get { return _dbConnectString; }
            set { _dbConnectString = value; }
        }

        /// <summary>
        /// 权重信息，该值越高则意味着被轮循到的次数越多
        /// </summary>
        private int _weight;
        /// <summary>
        /// 权重信息，该值越高则意味着被轮循到的次数越多
        /// </summary>
        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

    }
}
