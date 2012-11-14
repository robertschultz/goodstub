using Goodstub.Service;
using Goodstub.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Goodstub.Web.Controllers
{
    /// <summary>
    /// Login controller for the user.
    /// </summary>
    public class LoginController : BaseController
    {
        /// <summary>
        /// The user service.
        /// </summary>
        private readonly IUserService userService = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController" /> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        /// <exception cref="System.ArgumentNullException">userService;IUserService should not be null.</exception>
        public LoginController(IUserService userService)
        {
            if (userService == null)
            {
                throw new ArgumentNullException("userService", "IUserService should not be null.");
            }

            this.userService = userService;
        }

        /// <summary>
        /// Default action for GET.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Default action for POST.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (userService.Validate(model.Email, model.Password))
                {
                    var user = userService.Get(model.Email);

                    JavaScriptSerializer serializer = new JavaScriptSerializer();

                    string userData = serializer.Serialize(user);

                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                             1,
                             model.Email,
                             DateTime.Now,
                             DateTime.Now.AddMinutes(15),
                             false,
                             userData);

                    string encTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(faCookie);
                }
            }

            return View();
        }
    }
}
