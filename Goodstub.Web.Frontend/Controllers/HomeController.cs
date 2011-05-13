using System.Web.Mvc;
using Goodstub.Service.Client;
using Goodstub.Data.Entity;
using Goodstub.Web.Frontend.Models;

namespace Goodstub.Web.Frontend.Controllers
{
    public class HomeController : Controller
    {
        //[Dependency]
        //public Goodstub.Web.Frontend.UserService.IUserService UserService { get; set; }

        public ActionResult Index()
        {
            //var us = System.Web.Security.Membership.GetAllUsers();
            Goodstub.Web.Frontend.Models.IMembershipService MembershipService = new AccountMembershipService();
            MembershipService.CreateUser("test", "test123", "r@test.com");

            using (UserServiceClient u = new UserServiceClient())
            {
                u.CreateUser(new User { Firstname = "Robb" });
            }

            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
