using System.Web;
using System.Web.Optimization;

namespace ProjectTask
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",

                        "~/Script/bootstrap.js",

                         "~/Script/bootbox.js",

                         "~/Script/respond.js",

                         "~/Script/DataTables/jquery.dataTables.js",

                         "~/Script/DataTables/jquery.dataTables.min.js",

                         "~/Script/DataTables/dataTables.bootstrap.js"



                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                       "~/Scripts/bootstrap.js"
                      
                       ));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/DataTables/dataTables.bootstrap.css",
                     "~/Content/DataTables/dataTables.bootstrap.min.css",
                      "~/Content/site.css"));
        }
    }
}
