using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Goodstub.Common.Storage
{
    /// <summary>
    /// The <see cref="IConfigurationStore"/> interface defines the methods used to read and write to a configuration store.
    /// </summary>
    public interface IConfigurationStore
    {
        /// <overloads>
        /// <summary>
        /// Gets the application setting for the provided key.
        /// </summary>
        /// </overloads>
        /// <summary>
        /// Gets the application setting for the provided key.
        /// </summary>
        /// <typeparam name="T">
        /// The type of setting value.
        /// </typeparam>
        /// <param name="key">
        /// The configuration key.
        /// </param>
        /// <returns>
        /// A <typeparamref name="T"/> value, or <c>default(T)</c> if no configuration is found.
        /// </returns>
        T GetApplicationSetting<T>(String key);

        /// <summary>
        /// Gets the application setting for the provided key and default value.
        /// </summary>
        /// <typeparam name="T">
        /// The type of setting value.
        /// </typeparam>
        /// <param name="key">
        /// The configuration key.
        /// </param>
        /// <param name="defaultValue">
        /// The default value.
        /// </param>
        /// <returns>
        /// A <typeparamref name="T"/> value, or <paramref name="defaultValue"/> if no configuration is found.
        /// </returns>
        T GetApplicationSetting<T>(String key, T defaultValue);

        /// <summary>
        /// Gets the connection setting for the provided key.
        /// </summary>
        /// <param name="key">
        /// The configuration key.
        /// </param>
        /// <returns>
        /// A <see cref="ConnectionStringSettings"/> instance or <c>null</c> if no configuration is found.
        /// </returns>
        ConnectionStringSettings GetConnectionSetting(String key);

        /// <summary>
        /// Gets the configuration section for the provided section name.
        /// </summary>
        /// <typeparam name="T">
        /// The type of configuration section.
        /// </typeparam>
        /// <param name="sectionName">
        /// Name of the section.
        /// </param>
        /// <returns>
        /// A <typeparamref name="T"/> instance or <c>null</c> if the section is not defined in configuration.
        /// </returns>
        T GetSection<T>(String sectionName) where T : ConfigurationSection;
    }
}
