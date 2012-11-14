using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Goodstub.Web.Common.Serialization
{
    /// <summary>
    /// Extension methods related to json serialization.
    /// </summary>
    public static class JsonSerializationExtensions
    {
        /// <summary>
        /// Converts any object to a json representation using the JavaScriptSerializer class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string ToJson(this object value)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(value);
        }
    }
}
