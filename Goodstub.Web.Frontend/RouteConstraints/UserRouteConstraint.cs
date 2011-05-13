using System.Web;
using System.Web.Routing;
using Goodstub.Service.Contract;
using Microsoft.Practices.Unity;

namespace Goodstub.Web.Frontend.RouteConstraints
{
    public class UserRouteConstraint : IRouteConstraint
    {
        [Dependency]
        public IUserService UserService { get; set; }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var username = values["username"] as string;
            return IsCurrentUser(username);
        }

        private bool IsCurrentUser(string username)
        {
            var user = UserService.GetByUsername(username);
            return user != null;
        }
    }
}