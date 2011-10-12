﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Infrastructure.Crosscutting.SeedWork.Ioc;
using Microsoft.Practices.Unity;

namespace Infrastructure.Crosscutting.MainBoundedContent.Unity
{
    public class InstanceLocator : IInstanceLocator
    {
        #region Members
        /// <summary>
        /// IUnityContainer
        /// </summary>
        private IUnityContainer _unityContainer;
        #endregion

        #region Constructor
        public InstanceLocator(IUnityContainer unityContainer)
        {
            this._unityContainer = unityContainer;
        }

        public InstanceLocator()
            :this(new UnityContainer())
        {}

        #endregion

        #region IInstanceLocator Methods
        public T GetInstance<T>()
        {
            return _unityContainer.Resolve<T>();
        }

        public object GetInstance(Type instanceType)
        {
            return _unityContainer.Resolve(instanceType);
        }

        public bool IsTypeRegistered<T>()
        {
            return _unityContainer.IsRegistered<T>();
        }

        public bool IsTypeRegistered(Type type)
        {
            return _unityContainer.IsRegistered(type);
        }

        public void RegisterType<T>()
        {
            _unityContainer.RegisterType<T>();
        }

        public void RegisterType(Type type)
        {
            _unityContainer.RegisterType(type);
        }
        #endregion
    }
}
