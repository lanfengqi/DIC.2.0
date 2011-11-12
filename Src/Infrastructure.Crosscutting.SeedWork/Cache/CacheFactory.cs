using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Crosscutting.SeedWork.Cache
{
    public static class CacheFactory
    {
        #region Members
        static ICacheStrategy _currentCacheStrategy = null;
        #endregion

        #region Public Methods

        /// <summary>
        /// Set the  Ioc factory to use
        /// </summary>
        /// <param name="logFactory">Log factory to use</param>
        public static void SetCurrent(ICacheStrategy cacheStrategy)
        {
            _currentCacheStrategy = cacheStrategy;
        }

        /// <summary>
        /// Createt a new <paramref name="Infrastructure.Crosscutting.SeedWork.Ioc"/>
        /// </summary>
        /// <returns>Created ILog</returns>
        public static ICacheStrategy Create()
        {
            return _currentCacheStrategy;
        }

        #endregion
    }
}
