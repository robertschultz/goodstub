using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using Moq;
using System.Web.Routing;
using System.IO;

namespace Goodstub.Web.Frontend.UnitTests.Mocks
{
    public class Mock_ControllerContext
    {
        public static Controller Mock(Controller controller, HttpVerbs verb = HttpVerbs.Get, string url = null)
        {
            var routes = new RouteCollection();
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });

            var request = new Mock<HttpRequestBase>();
            request.Setup(x => x.HttpMethod).Returns(Enum.GetName(typeof(HttpVerbs), verb));
            request.SetupGet(x => x.ApplicationPath).Returns("/");

            // Create mock response
            var response = new Mock<HttpResponseBase>();
            response.Setup(x => x.Output).Returns(new StringWriter(new StringBuilder(string.Empty)));
            response.Setup(x => x.ApplyAppPathModifier(It.IsAny<string>())).Returns((string s) => s);

            var context = new Mock<HttpContextBase>();
            context.SetupGet(x => x.Request).Returns(request.Object);
            context.SetupGet(x => x.Response).Returns(response.Object);

            if (!String.IsNullOrEmpty(url))
            {
                context.SetupGet(x => x.Request.Url).Returns(new Uri(url));
            }

            controller.ControllerContext = new ControllerContext(context.Object, new RouteData(), controller);
            controller.Url = new UrlHelper(new RequestContext(context.Object, new RouteData()), routes);

            return controller;
        }
    }
}
