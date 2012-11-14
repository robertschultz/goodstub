using Goodstub.Domain;
using Goodstub.Service;
using System;
using System.Web.Mvc;

namespace Goodstub.Web.Controllers
{
    /// <summary>
    /// Default controller.
    /// </summary>
    public class HomeController : BaseController
    {
        /// <summary>
        /// The user service.
        /// </summary>
        private IUserService userService = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController" /> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        public HomeController(IUserService userService)
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
        public ActionResult Index()
        {
            return View();
        }
    }
}
