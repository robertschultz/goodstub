using Goodstub.Domain;
using Goodstub.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Goodstub.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUserService userService = null;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index()
        {
            IUser s = userService.Get("robertschultz");

            //IUser Insert(User user)

            IUser u = new User
            {
                Firstname = "JOhn",
                Lastname = "Doe",
                Username = "jondoe"
            };

            var r = userService.Insert(u);

            return View();
        }
    }
}
