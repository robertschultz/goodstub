using Goodstub.Web.Common.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Goodstub.Web.Common.Mvc
{
    /// <summary>
    /// Custom base view page, specifically used to override the user principal.
    /// </summary>
    public abstract class BaseViewPage : WebViewPage
    {
        /// <summary>
        /// When overridden in a derived class, gets a user value based on the HTTP context.
        /// </summary>
        /// <returns>A user value based on the HTTP context.</returns>
        public virtual new CustomPrincipal User
        {
            get { return base.User as CustomPrincipal; }
        }
    }

    /// <summary>
    /// Custom generic base view page, specifically used to override the user principal.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        /// <summary>
        /// When overridden in a derived class, gets a user value based on the HTTP context.
        /// </summary>
        /// <returns>A user value based on the HTTP context.</returns>
        public virtual new CustomPrincipal User
        {
            get { return base.User as CustomPrincipal; }
        }
    }
}
