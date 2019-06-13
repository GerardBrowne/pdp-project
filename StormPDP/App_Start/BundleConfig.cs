using System.Web;
using System.Web.Optimization;

namespace StormPDP
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-ui-{version}.js",
                "~/Scripts/popper.min.js",
                "~/Scripts/materialize.js",
                "~/Scripts/bootstrap-multiselect.js",
                "~/Scripts/jquery.scrollme.min.js",
                "~/Content/DataTables/datatables.js",
                "~/Content/DataTables/dataTables.bootstrap4.js",
                "~/Scripts/bootbox.js",
                "~/Scripts/respond.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/materialize.css",
                      "~/Content/DataTables/datatables.css",
                      "~/Content/DataTables/dataTables.bootstrap4.css",
                      "~/Content/site.css"
                ));
        }
    }
}
