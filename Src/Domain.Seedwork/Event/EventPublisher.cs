﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Infrastructure.Crosscutting.SeedWork.Ioc;

namespace Domain.Seedwork.Event
{
    public sealed class EventPublisher
    {
        #region Public Methods

        public void Publish(IDomainEvent evnt)
        {
            foreach (var subscriberType in DomainInitializer.Current.GetSubscriberTypesList(evnt.GetType()))
            {
                foreach (var result in HandleEvent(evnt, subscriberType))
                {
                    if (result != null)
                    {
                        evnt.Results.Add(result);
                    }
                }
            }
        }
        public void Publish(IEnumerable<IDomainEvent> evnts)
        {
            evnts.ForEach(evnt => Publish(evnt));
        }
        public void Publish(params IDomainEvent[] evnts)
        {
            evnts.ForEach(evnt => Publish(evnt));
        }

        #endregion

        #region Private Methods

        private static IEnumerable<object> HandleEvent(IDomainEvent evnt, Type subscriberType)
        {
            IList<object> results = new List<object>();

            var eventHandlers = DomainInitializer.Current.GetEventHandlers(subscriberType).Where(eventHandler => IsEventHandler(eventHandler, evnt.GetType()));
            foreach (var eventHandler in eventHandlers)
            {
                ExecuteEventHandler(eventHandler, GetSubscriber(subscriberType), evnt, ref results);
            }

            return results;
        }
        private static void ExecuteEventHandler(MethodInfo eventHandler, object eventSource, object evnt, ref IList<object> results)
        {
            var result = eventHandler.Invoke(eventSource, new object[] { evnt });
            if (result != null)
            {
                results.Add(result);
            }
        }
        private static bool IsEventHandler(MethodInfo method, Type eventType)
        {
            var parameters = method.GetParameters();
            return parameters.Count() == 1 && parameters[0].ParameterType.IsAssignableFrom(eventType);
        }
        private static object GetSubscriber(Type subscriberType)
        {
            IInstanceLocator instanceLocator = IocFactory.CreateIoc();
            if (instanceLocator.IsTypeRegistered(subscriberType))
            {
                return instanceLocator.GetInstance(subscriberType);
            }
            else
            {
                return CreateSubscriber(subscriberType);
            }
        }
        private static object CreateSubscriber(Type subscriberType)
        {
            var constructor = subscriberType.GetConstructors()[0];
            var parameterValues = new List<object>();
            constructor.GetParameters().ForEach(parameterInfo => parameterValues.Add(GetValueForType(parameterInfo.ParameterType)));
            return constructor.Invoke(parameterValues.ToArray());
        }
        private static object GetValueForType(Type targetType)
        {
            IInstanceLocator instanceLocator = IocFactory.CreateIoc();
            if (targetType.IsInterface)
            {
                return instanceLocator.GetInstance(targetType);
            }
            else
            {
                return DefaultValueForType(targetType);
            }
        }
        private static object DefaultValueForType(Type targetType)
        {
            return targetType.IsValueType ? Activator.CreateInstance(targetType) : null;
        }

        #endregion
    }
}
