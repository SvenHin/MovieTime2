﻿using System.Web;
using System.Web.Optimization;

namespace MovieTime2
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/mainmoviejquery").Include(
                        "~/Scripts/MainMovieLoader.js"));

            bundles.Add(new ScriptBundle("~/bundles/cartjquery").Include(
                        "~/Scripts/CartLoader.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryandajax").Include(
                        "~/Scripts/jquery-3.3.1.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryvalidation").Include(
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js"));
        }
    }
}
