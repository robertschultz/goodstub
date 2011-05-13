using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Microsoft.Practices.Unity;

namespace Goodstub.Common.Unity
{
    internal class UnityServiceBehavior : IServiceBehavior
    {
        public UnityServiceBehavior(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            Container = container;
        }

        public void AddBindingParameters(
            ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase,
            Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            if (serviceDescription == null)
            {
                throw new ArgumentNullException("serviceDescription");
            }

            if (serviceHostBase == null)
            {
                throw new ArgumentNullException("serviceHostBase");
            }

            for (Int32 dispatcherIndex = 0; dispatcherIndex < serviceHostBase.ChannelDispatchers.Count; dispatcherIndex++)
            {
                ChannelDispatcherBase dispatcher = serviceHostBase.ChannelDispatchers[dispatcherIndex];
                ChannelDispatcher channelDispatcher = (ChannelDispatcher)dispatcher;

                for (Int32 endpointIndex = 0; endpointIndex < channelDispatcher.Endpoints.Count; endpointIndex++)
                {
                    EndpointDispatcher endpointDispatcher = channelDispatcher.Endpoints[endpointIndex];

                    endpointDispatcher.DispatchRuntime.InstanceProvider = new UnityInstanceProvider(Container, serviceDescription.ServiceType);
                }
            }
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        protected IUnityContainer Container
        {
            get;
            set;
        }
    }

}