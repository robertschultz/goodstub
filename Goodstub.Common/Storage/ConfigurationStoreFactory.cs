using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Goodstub.Common.Storage
{
    /// <summary>
    /// The <see cref="ConfigurationStoreFactory"/>
    /// class is used to create <see cref="IConfigurationStore"/> instances.
    /// </summary>
    /// <remarks>
    /// The application configuration is used to determine the type of 
    /// <see cref="IConfigurationStore"/> to create. The configuration key used is <c>StoreType</c> which is defined
    /// in <see cref="ConfigurationStoreTypeConfigurationKey"/>.
    /// If the application configuration does not contain a value, a <see cref="ConfigurationManagerStore"/> instance will be returned.
    /// </remarks>
    public static class ConfigurationStoreFactory
    {
        /// <summary>
        /// Defines the configuration key used to obtain the configuration store type
        /// from application configuration.
        /// </summary>
        public const String ConfigurationStoreTypeConfigurationKey = "ConfigurationStoreType";

        /// <summary>
        /// Stores the object used for locking the class when resolving the store type.
        /// </summary>
        private static readonly Object SyncLock = new Object();

        /// <summary>
        /// Stores the configuration store type.
        /// </summary>
        private static Type _storeType;

        /// <summary>
        /// Creates a <see cref="IConfigurationStore"/> instance.
        /// </summary>
        /// <returns>
        /// A <see cref="IConfigurationStore"/> instance.
        /// </returns>
        /// <remarks>
        /// The application configuration is used to determine the type of 
        /// <see cref="IConfigurationStore"/> to create. The configuration key used is <c>StoreType</c> which is defined
        /// in <see cref="ConfigurationStoreTypeConfigurationKey"/>.
        /// If the application configuration does not contain a value, a <see cref="ConfigurationManagerStore"/> instance will be returned.
        /// </remarks>
        public static IConfigurationStore Create()
        {
            return (IConfigurationStore)Activator.CreateInstance(StoreType);
        }

        /// <summary>
        /// Determines the type of the configuration store.
        /// </summary>
        private static void DetermineStoreType()
        {
            lock (SyncLock)
            {
                if (_storeType == null)
                {
                    _storeType = ConfigurationTypeLoader.DetermineStoreType(
                        new ConfigurationManagerStore(),
                        ConfigurationStoreTypeConfigurationKey,
                        typeof(IConfigurationStore),
                        typeof(ConfigurationManagerStore));
                }
            }
        }

        /// <summary>
        /// Gets or sets the type of the configuration store.
        /// </summary>
        /// <value>
        /// The type of the configuration store.
        /// </value>
        /// <remarks>
        /// The application configuration is used to determine the type of 
        /// <see cref="IConfigurationStore"/> created by this class. The configuration key used is <c>StoreType</c> which is defined
        /// in <see cref="ConfigurationStoreTypeConfigurationKey"/>.
        /// If the application configuration does not contain a value, <see cref="ConfigurationManagerStore"/> will be the type created.
        /// </remarks>
        public static Type StoreType
        {
            get
            {
                if (_storeType == null)
                {
                    DetermineStoreType();
                }

                return _storeType;
            }

            set
            {
                if (value != null)
                {
                    if (typeof(IConfigurationStore).IsAssignableFrom(value) == false)
                    {
                        throw new InvalidCastException(
                            String.Format(
                                CultureInfo.InvariantCulture, "InvalidCastExceptionMessage", value.GetType(), typeof(IConfigurationStore)));
                    }
                }

                _storeType = value;
            }
        }
    }
}
