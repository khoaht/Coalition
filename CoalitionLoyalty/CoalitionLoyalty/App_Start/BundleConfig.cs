﻿using System.Web;
using System.Web.Optimization;

namespace CoalitionLoyalty
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-route.js",
                        "~/Scripts/angular-scenario.js",
                        "~/Scripts/angular-animate.js",
                        "~/Scripts/angular-resource.js",
                         "~/Scripts/ui-bootstrap-tpls-0.10.0.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/ngApp").Include(
                "~/app/ng-app.js"
                , "~/app/servies/globalService.js"
                , "~/app/controllers/homeController.js"
                , "~/app/controllers/transactionController.js"
                , "~/app/controllers/addTransactionController.js"
                           ));
            //End Directives

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
