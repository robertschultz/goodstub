using AutoMapper;
using Goodstub.Domain;
using Goodstub.Service;
using Goodstub.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Goodstub.Web.Controllers
{
    /// <summary>
    /// SignUp controller for the user.
    /// </summary>
    public class SignUpController : BaseController
    {
        /// <summary>
        /// The user service.
        /// </summary>
        private readonly IUserService userService = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignUpController" /> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        /// <exception cref="System.ArgumentNullException">userService;IUserService should not be null.</exception>
        public SignUpController(IUserService userService)
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
        public ActionResult Index(SignUpModel model)
        {
            if (ModelState.IsValid)
            {
                var user = userService.Get(model.Email);

                if (user != null)
                {
                    ModelState.AddModelError("exists", "User with this email already exists.");
                }
                else
                {
                    userService.Insert(Mapper.Map<IUser>(model));
                }
            }

            return View();
        }
    }
}
