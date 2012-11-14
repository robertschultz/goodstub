using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Goodstub.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/content/scripts/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.unobtrusive*",
            //            "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/content/scripts/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/content/scripts/bootstrap").Include(
                        "~/Scripts/bootstrap*"));


            bundles.Add(new StyleBundle("~/content/css").Include("~/Content/css/main.css"));
            bundles.Add(new StyleBundle("~/content/css/bootstrap").Include(
                "~/content/css/bootstrap.css",
                "~/content/css/bootstrap-responsive.css",
                "~/content/css/font-awesome.css"));

        }
    }
}