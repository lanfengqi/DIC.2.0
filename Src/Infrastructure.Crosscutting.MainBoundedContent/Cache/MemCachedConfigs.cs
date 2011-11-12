using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Crosscutting.SeedWork.Tool;

namespace Infrastructure.Crosscutting.MainBoundedContent.Cache
{
    public static class MemCachedConfigs
    {
        public static MemCachedConfigInfo GetConfig(string Url)
        {
            object objDbSnapapp = XmlSerializers.Deserialize(Url, typeof(MemCachedConfigInfo));
            if (objDbSnapapp != (MemCachedConfigInfo)null)
            {
                return (MemCachedConfigInfo)objDbSnapapp;
            }
            return null;
        }
    }
}
