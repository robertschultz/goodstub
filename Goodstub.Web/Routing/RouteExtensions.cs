using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Goodstub.Web.Routing
{
    public static class RouteExtensions
    {
        public static Route MapRouteLowercase(this RouteCollection routes, string name, string url)
        {
            return routes.MapRouteLowercase(name, url, null /* defaults */, (object)null /* constraints */);
        }

        public static Route MapRouteLowercase(this RouteCollection routes, string name, string url, object defaults)
        {
            return routes.MapRouteLowercase(name, url, defaults, (object)null /* constraints */);
        }

        public static Route MapRouteLowercase(this RouteCollection routes, string name, string url, object defaults, object constraints)
        {
            return routes.MapRouteLowercase(name, url, defaults, constraints, null /* namespaces */);
        }

        public static Route MapRouteLowercase(this RouteCollection routes, string name, string url, string[] namespaces)
        {
            return routes.MapRouteLowercase(name, url, null /* defaults */, null /* constraints */, namespaces);
        }

        public static Route MapRouteLowercase(this RouteCollection routes, string name, string url, object defaults, string[] namespaces)
        {
            return routes.MapRouteLowercase(name, url, defaults, null /* constraints */, namespaces);
        }

        public static Route MapRouteLowercase(this RouteCollection routes, string name, string url, object defaults, object constraints, string[] namespaces)
        {
            if (routes == null)
            {
                throw new ArgumentNullException("routes");
            }
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            Route route = new LowercaseRoute(url, new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(defaults),
                Constraints = new RouteValueDictionary(constraints),
                DataTokens = new RouteValueDictionary()
            };

            if ((namespaces != null) && (namespaces.Length > 0))
            {
                route.DataTokens["Namespaces"] = namespaces;
            }

            routes.Add(name, route);

            return route;
        }

        public static Route MapRouteLowercase(this AreaRegistrationContext context, string name, string url)
        {
            return context.MapRouteLowercase(name, url, (object)null /* defaults */);
        }

        public static Route MapRouteLowercase(this AreaRegistrationContext context, string name, string url, object defaults)
        {
            return context.MapRouteLowercase(name, url, defaults, (object)null /* constraints */);
        }

        public static Route MapRouteLowercase(this AreaRegistrationContext context, string name, string url, object defaults, object constraints)
        {
            return context.MapRouteLowercase(name, url, defaults, constraints, null /* namespaces */);
        }

        public static Route MapRouteLowercase(this AreaRegistrationContext context, string name, string url, string[] namespaces)
        {
            return context.MapRouteLowercase(name, url, (object)null /* defaults */, namespaces);
        }

        public static Route MapRouteLowercase(this AreaRegistrationContext context, string name, string url, object defaults, string[] namespaces)
        {
            return context.MapRouteLowercase(name, url, defaults, null /* constraints */, namespaces);
        }

        public static Route MapRouteLowercase(this AreaRegistrationContext context, string name, string url, object defaults, object constraints, string[] namespaces)
        {
            if (namespaces == null && context.Namespaces != null)
            {
                namespaces = new string[context.Namespaces.Count];
                context.Namespaces.CopyTo(namespaces, 0);
            }

            Route route = context.Routes.MapRouteLowercase(name, url, defaults, constraints, namespaces);
            route.DataTokens["area"] = context.AreaName;

            // disabling the namespace lookup fallback mechanism keeps this areas from accidentally picking up
            // controllers belonging to other areas
            bool useNamespaceFallback = (namespaces == null || namespaces.Length == 0);
            route.DataTokens["UseNamespaceFallback"] = useNamespaceFallback;

            return route;
        }
    }
}
