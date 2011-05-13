using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using System.Configuration;
using System.Globalization;
using Microsoft.Practices.Unity.Configuration;
using System.Diagnostics;
using Goodstub.Common.Storage;

namespace Goodstub.Common.Unity
{
    /// <summary>
    /// The <see cref="UnityContainerResolver"/>
    /// class is used to resolve a <see cref="IUnityContainer"/> instance from configuration.
    /// </summary>
    public static class UnityContainerResolver
    {
        /// <summary>
        /// Defines the default unity section name.
        /// </summary>
        public const String DefaultUnitySectionName = "unity";

        /// <summary>
        /// Resolves the container from configuration using the default configuration options.
        /// </summary>
        /// <returns>
        /// A <see cref="IUnityContainer"/> instance.
        /// </returns>
        public static IUnityContainer Resolve()
        {
            return Resolve(null, String.Empty, String.Empty);
        }

        /// <summary>
        /// Resolves the container from configuration using the specified configuration values.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        /// <param name="unitySectionName">
        /// Name of the unity section.
        /// </param>
        /// <param name="containerName">
        /// Name of the container.
        /// </param>
        /// <returns>
        /// A <see cref="IUnityContainer"/> instance.
        /// </returns>
        public static IUnityContainer Resolve(IConfigurationStore configuration, String unitySectionName, String containerName)
        {
            if (configuration == null)
            {
                configuration = ConfigurationStoreFactory.Create();
            }

            if (String.IsNullOrEmpty(unitySectionName))
            {
                unitySectionName = DefaultUnitySectionName;
            }

            UnityConfigurationSection config = configuration.GetSection<UnityConfigurationSection>(unitySectionName);

            if (config == null)
            {
                throw new ConfigurationErrorsException("No Unity configuration was found.");
            }

            Debug.Assert(config.Containers != null, "No containers found");

            if (config.Containers.Count == 0)
            {
                throw new ConfigurationErrorsException("No Unity containers have been configured.");
            }

            ContainerElement containerConfig;

            if (String.IsNullOrEmpty(containerName))
            {
                containerConfig = config.Containers.Default;

                if (containerConfig == null)
                {
                    throw new ConfigurationErrorsException("The default Unity container was not found in configuration.");
                }
            }
            else
            {
                containerConfig = config.Containers[containerName];

                if (containerConfig == null)
                {
                    const String MessageFormat = "No Unity container with the name '{0}' was not found in configuration.";
                    String message = String.Format(CultureInfo.InvariantCulture, MessageFormat, containerName);

                    throw new ConfigurationErrorsException(message);
                }
            }

            IUnityContainer container = new UnityContainer();

            config.Configure(container, containerName);

            return container;
        }
    }
}
