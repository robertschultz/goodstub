using System;
using System.ServiceModel;
using Microsoft.Practices.Unity;


namespace Goodstub.Common.Unity
{
    internal class UnityServiceHost : ServiceHost
    {
        public UnityServiceHost(Type serviceType, IUnityContainer container, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            Container = container;
        }

        protected override void OnOpening()
        {
            if (Description.Behaviors.Find<UnityServiceBehavior>() == null)
            {
                Description.Behaviors.Add(new UnityServiceBehavior(Container));
            }

            base.OnOpening();
        }

        protected IUnityContainer Container
        {
            get;
            set;
        }
    }
}