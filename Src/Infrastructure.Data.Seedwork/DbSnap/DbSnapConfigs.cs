using System.Collections.Generic;
using System.Security.Policy;
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
            return getDbSnapAppConfig().DbSnapInfoList;
        }

        /// <summary>
        /// 获取DbSnapAppConfig配置信息
        /// </summary>
        /// <returns></returns>
        public static DbSnapAppConfig getDbSnapAppConfig()
        {
            string Url = @"E:\030.GitHub\020.DCI.2.0\Src\Infrastructure.Data.Seedwork\bin\Debug\DbSnap.xml";
            object objDbSnapapp = XmlSerializers.Deserialize(Url, typeof(DbSnapAppConfig));
            if (objDbSnapapp != null && objDbSnapapp != (DbSnapAppConfig)null)
            {
                return (DbSnapAppConfig)objDbSnapapp;
            }
            return null;
        }
    }
}
