using System;
using System.Configuration;
using System.Globalization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Microsoft.Practices.Unity;

namespace Goodstub.Common.Unity
{
    /// <summary>
    /// The <see cref="UnityInstanceContainer"/> class is used to provide a <see cref="IInstanceProvider"/>.
    /// </summary>
    internal class UnityInstanceProvider : IInstanceProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnityInstanceProvider"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="serviceType">Type of the service.</param>
        public UnityInstanceProvider(IUnityContainer container, Type serviceType)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException("serviceType");
            }

            Container = container;
            ServiceType = serviceType;
        }

        /// <summary>
        /// Returns a service object given the specified <see cref="T:System.ServiceModel.InstanceContext"/> object.
        /// </summary>
        /// <param name="instanceContext">The current <see cref="T:System.ServiceModel.InstanceContext"/> object.</param>
        /// <returns>
        /// A user-defined service object.
        /// </returns>
        public Object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        /// <summary>
        /// Returns a service object given the specified <see cref="T:System.ServiceModel.InstanceContext"/> object.
        /// </summary>
        /// <param name="instanceContext">The current <see cref="T:System.ServiceModel.InstanceContext"/> object.</param>
        /// <param name="message">The message that triggered the creation of a service object.</param>
        /// <returns>
        /// The service object.
        /// </returns>
        public Object GetInstance(InstanceContext instanceContext, Message message)
        {
            Object instance = Container.Resolve(ServiceType);

            if (instance == null)
            {
                const String MessageFormat = "No unity configuration was found for service type '{0}'";
                String failureMessage = String.Format(CultureInfo.InvariantCulture, MessageFormat, ServiceType.FullName);

                throw new ConfigurationErrorsException(failureMessage);
            }

            return instance;
        }

        /// <summary>
        /// Called when an <see cref="T:System.ServiceModel.InstanceContext"/> object recycles a service object.
        /// </summary>
        /// <param name="instanceContext">The service's instance context.</param>
        /// <param name="instance">The service object to be recycled.</param>
        public void ReleaseInstance(InstanceContext instanceContext, Object instance)
        {
            Container.Teardown(instance);
        }

        /// <summary>
        /// Gets or sets the type of the service.
        /// </summary>
        /// <value>
        /// The type of the service.
        /// </value>
        protected Type ServiceType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        private IUnityContainer Container
        {
            get;
            set;
        }
    }

}