using System.Collections.Generic;
using Infrastructure.Crosscutting.SeedWork.Tool;
using Infrastructure.Crosscutting.SeedWork.Tool;

namespace Infrastructure.Data.Seedwork.DbSnap
{
    public class DbSnapConfigs
    {
        /// <summary>
        /// 获取数据库列表DbSnapInfo
        /// </summary>
        /// <returns></returns>
        public static List<DbSnapInfo> GetEnableSnapList()
        {
            return GetDbSnapAppConfig().DbSnapInfoList;
        }

        /// <summary>
        /// 获取DbSnapAppConfig配置信息
        /// </summary>
        /// <returns></returns>
        public static DbSnapAppConfig GetDbSnapAppConfig()
        {
            string Url = PathServer.GetRootPath() + @"Content\\xml\\DbSnap.xml";
            object objDbSnapapp = XmlSerializers.Deserialize(Url, typeof(DbSnapAppConfig));
            if (objDbSnapapp != (DbSnapAppConfig)null)
            {
                return (DbSnapAppConfig)objDbSnapapp;
            }
            return null;
        }
    }
}
