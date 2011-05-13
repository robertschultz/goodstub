using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace Goodstub.Web.Frontend.Unity
{
    /// <summary>
    /// Static class providing access to an instanse of the Unity IoC container.
    /// </summary>
    public sealed class UnityManager
    {
        /// <summary>
        /// Lock object used to lock the configuration when loading.
        /// </summary>
        private static object unitylock = new object();

        /// <summary>
        /// Unity container used to map the dependencies.
        /// </summary>
        private static IUnityContainer container;

        /// <summary>
        /// Gets an instance of the Unity IoC container.
        /// </summary>
        public static IUnityContainer Instance
        {
            get
            {
                if (container == null)
                {
                    lock (unitylock)
                    {
                        try
                        {
                            if (container == null)
                            {
                                container = new UnityContainer();
                            }

                            UnityConfigurationSection section = (UnityConfigurationSection) ConfigurationManager.GetSection("unity");
                            section.Configure(container);


                            //container.LoadConfiguration("default");
                        }
                        catch (Exception ex)
                        {
                            //Shared.ExceptionManagement.MFNExceptionManager.PublishCriticalException("UnityManager", ex);
                        }
                    }
                }

                return container;
            }
        }
    }
}