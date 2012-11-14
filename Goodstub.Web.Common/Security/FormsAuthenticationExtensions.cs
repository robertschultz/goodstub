using Goodstub.Web.Common.Serialization;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Goodstub.Web.Common.Security
{
    /// <summary>
    /// Extension methods related to the FormsAuthentication class.
    /// </summary>
    public static class FormsAuthenticationExtensions
    {
        /// <summary>
        /// Sets the custom ticket and redirects back to the requested page.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="name">The name.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static ActionResult SetCustomTicketAndRedirect(this Controller controller, string name, object data)
        {
            // Create ticket with json encoded data.
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, name, DateTime.Now, DateTime.Now.AddMinutes(15), false, data.ToJson());

            // Encrypt the ticket.
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);

            // Create the forms authentication cookie with encrypted ticket.
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

            // Set the cookie to the response.
            controller.Response.Cookies.Add(cookie);

            // Redirect back to the requested page.
            return new RedirectResult(FormsAuthentication.GetRedirectUrl(name, false));

        }
    }
}
