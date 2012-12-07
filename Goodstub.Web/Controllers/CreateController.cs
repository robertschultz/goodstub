using Goodstub.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Goodstub.Web.Controllers
{
    /// <summary>
    /// Controller to create events.
    /// </summary>
    [Authorize]
    public class CreateController : BaseController
    {
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
        public ActionResult Index(CreateModel model)
        {
            return View();
        }
    }
}
