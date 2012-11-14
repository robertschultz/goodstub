using Goodstub.Web.Controllers;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Goodstub.Service;
using System.Web.Security;
using System.Web.Script.Serialization;
using Goodstub.Domain;
using Goodstub.Web.Common.Security;

namespace Goodstub.Web
{
    /// <summary>
    /// HTTP web application class.
    /// </summary>
    public class MvcApplication : HttpApplication
    {
        /// <summary>
        /// Handles the start event of the Application.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.Configure();
        }

        /// <summary>
        /// Handles the PostAuthenticateRequest event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            // Get the forms authentication cookie.
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                // Create a serializer to serialize back to an object.
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                // Deserialize the user data.
                IUser user = serializer.Deserialize<User>(authTicket.UserData);

                // Create a new CustomPrincipal user object.
                CustomPrincipal principal = new CustomPrincipal(authTicket.Name);

                // Map the user back to the principal.
                principal.Email = user.Email;
                principal.Firstname = user.Firstname;
                principal.Lastname = user.Lastname;

                HttpContext.Current.User = principal;
            }
        }
    }
}