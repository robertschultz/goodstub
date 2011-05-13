using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Microsoft.Practices.Unity;
using Goodstub.Common.Storage;

namespace Goodstub.Common.Unity
{
    public class UnityServiceHostFactory : ServiceHostFactory
    {
        public UnityServiceHostFactory()
            : this(null, String.Empty, String.Empty)
        {
        }

        public UnityServiceHostFactory(IConfigurationStore configuration, String unitySectionName, String containerName)
        {
            Container = UnityContainerResolver.Resolve(configuration, unitySectionName, containerName);
        }

        public UnityServiceHostFactory(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            Container = container;
        }

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new UnityServiceHost(serviceType, Container, baseAddresses);
        }

        public IUnityContainer Container
        {
            get;
            set;
        }
    }

}