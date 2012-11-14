using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Goodstub.Web.Common.Security
{
    public static class FormsAuthenticationHelper
    {
        public static void SetCustomTicketAndPrincipal(this Controller controller, string name, object data)
        {
            //JavaScriptSerializer serializer = new JavaScriptSerializer();

            //string userData = serializer.Serialize(data);

            //FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
            //            1,
            //            name,
            //            DateTime.Now,
            //            DateTime.Now.AddMinutes(15),
            //            false,
            //            userData);

            //string encTicket = FormsAuthentication.Encrypt(authTicket);
            //HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            //Response.Cookies.Add(faCookie);
        }
    }
}
