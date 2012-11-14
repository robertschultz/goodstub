using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Goodstub.Web.Controllers
{
    /// <summary>
    /// Sign out controller.
    /// </summary>
    public class SignOutController : BaseController
    {
        /// <summary>
        /// Default action.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

    }
}
