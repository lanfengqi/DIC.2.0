using System.Collections.Generic;

using Infrastructure.Crosscutting.SeedWork.Tool;

namespace Infrastructure.Data.Seedwork.DbSnap
{
    public class DbSnapConfigs
    {

        public static List<DbSnapInfo> GetEnableSnapList()
        {
            string Url = @"E:\030.GitHub\020.DCI.2.0\Src\Infrastructure.Data.Seedwork\bin\Debug\DbSnap.xml";
            object objDbSnapapp = XmlSerializers.Deserialize(Url, typeof(DbSnapAppConfig));
            if (objDbSnapapp != null && objDbSnapapp != (DbSnapAppConfig)null)
            {
                return ((DbSnapAppConfig)objDbSnapapp).DbSnapInfoList;
            }
            return null;
        }

    }
}
