using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Infrastructure.Crosscutting.SeedWork.Ioc;
using Microsoft.Practices.Unity;

namespace Infrastructure.Crosscutting.MainBoundedContent.Unity
{
    public class InstanceLocatorFactory : IIocFactory
    {
        #region Members
        private IInstanceLocator _instanceLocator;
        #endregion

        #region Constructor
        public InstanceLocatorFactory(IUnityContainer unityContainer)
        {
            this._instanceLocator = new InstanceLocator(unityContainer);
        }

        public InstanceLocatorFactory()
        {
            this._instanceLocator = new InstanceLocator();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Create the trace source log
        /// </summary>
        /// <returns>New ILog based on Trace Source infrastructure</returns>
        public IInstanceLocator Create()
        {
            return _instanceLocator;
        }
        #endregion
    }
}
