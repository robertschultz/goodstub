using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Globalization;
using System.ComponentModel;

namespace Goodstub.Common.Storage
{
    /// <summary>
    /// The <see cref="ConfigurationManagerStore"/>
    /// class is used to provide a 
    /// <see cref="IConfigurationStore"/> implementation based on the 
    /// <see cref="ConfigurationManager"/> class.
    /// </summary>
    public class ConfigurationManagerStore : IConfigurationStore
    {
        /// <summary>
        /// Defines the set of types supported by the <see cref="Convert"/> class.
        /// </summary>
        private static readonly List<Type> SupportedConvertTypes = new List<Type>
                                                                   {
                                                                       typeof(Object), 
                                                                       typeof(DBNull), 
                                                                       typeof(Boolean), 
                                                                       typeof(Char), 
                                                                       typeof(SByte), 
                                                                       typeof(Byte), 
                                                                       typeof(Int16), 
                                                                       typeof(UInt16), 
                                                                       typeof(Int32), 
                                                                       typeof(UInt32), 
                                                                       typeof(Int64), 
                                                                       typeof(UInt64), 
                                                                       typeof(Single), 
                                                                       typeof(Double), 
                                                                       typeof(Decimal), 
                                                                       typeof(DateTime), 
                                                                       typeof(String)
                                                                   };

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
        public T GetApplicationSetting<T>(String key)
        {
            return GetApplicationSetting(key, default(T));
        }

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
        public T GetApplicationSetting<T>(String key, T defaultValue)
        {
            // Checks whether the key parameter has been supplied
            if (String.IsNullOrEmpty(key))
            {
                const String KeyParameterName = "key";

                throw new ArgumentNullException(KeyParameterName);
            }

            String configurationValue = ConfigurationManager.AppSettings[key];

            if (String.IsNullOrEmpty(configurationValue))
            {
                return defaultValue;
            }

            Type returnType = typeof(T);

            if (returnType.Equals(typeof(String)))
            {
                return (T)(Object)configurationValue;
            }

            if (SupportedConvertTypes.Contains(returnType))
            {
                return (T)Convert.ChangeType(configurationValue, returnType, CultureInfo.CurrentCulture);
            }

            // Get the type converter for the type to return
            TypeConverter converter = TypeDescriptor.GetConverter(returnType);

            // Convert from a string to the type required
            return (T)converter.ConvertFromString(configurationValue);
        }

        /// <summary>
        /// Gets the connection setting for the provided key.
        /// </summary>
        /// <param name="key">
        /// The configuration key.
        /// </param>
        /// <returns>
        /// A <see cref="ConnectionStringSettings"/> instance or <c>null</c> if no configuration is found.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The <paramref name="key"/> is <c>null</c> or equals <see cref="String.Empty"/>.
        /// </exception>
        public ConnectionStringSettings GetConnectionSetting(String key)
        {
            // Checks whether the key parameter has been supplied
            if (String.IsNullOrEmpty(key))
            {
                const String KeyParameterName = "key";

                throw new ArgumentNullException(KeyParameterName);
            }

            return ConfigurationManager.ConnectionStrings[key];
        }

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
        /// <exception cref="ArgumentNullException">
        /// The <paramref name="sectionName"/> is <c>null</c> or equals <see cref="String.Empty"/>.
        /// </exception>
        /// <exception cref="ConfigurationErrorsException">
        /// The section defined in configuration is not the same type as <typeparamref name="T"/>.
        /// </exception>
        public T GetSection<T>(String sectionName) where T : ConfigurationSection
        {
            // Checks whether the sectionName parameter has been supplied
            if (String.IsNullOrEmpty(sectionName))
            {
                const String SectionNameParameterName = "sectionName";

                throw new ArgumentNullException(SectionNameParameterName);
            }

            ConfigurationSection section = ConfigurationManager.GetSection(sectionName) as ConfigurationSection;

            if (section == null)
            {
                return null;
            }

            T typedSection = section as T;

            if (typedSection == null)
            {
                throw new ConfigurationErrorsException(
                    String.Format(
                        CultureInfo.InvariantCulture,
                        "InvalidConfigurationSectionTypeExceptionMessage",
                        sectionName,
                        typeof(T).FullName,
                        section.GetType().FullName));
            }

            return typedSection;
        }
    }
}
