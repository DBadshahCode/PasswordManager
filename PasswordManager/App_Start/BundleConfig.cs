using System.Web.Optimization;

namespace PasswordManager
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/bootstrap/js").Include(
                "~/Scripts/modernizr-{version}.js",
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.bundle.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/jquery.dataTables.min.js",
                "~/Scripts/dataTables.bootstrap5.min.js",
                "~/Scripts/dataTables.buttons.min.js",
                "~/Scripts/buttons.html5.min.js",
                "~/Scripts/buttons.print.min.js",
                "~/Scripts/jszip.min.js",
                "~/Scripts/pdfmake.min.js",
                "~/Scripts/vfs_fonts.js"
                ));

            bundles.Add(new StyleBundle("~/Content/bootstrap/css").Include(
                "~/Content/bootstrap-grid.min.css",
                "~/Content/bootstrap-reboot.min.css",
                "~/Content/bootstrap-utilities.min.css",
                "~/Content/bootstrap.min.css",
                "~/Content/jquery.dataTables.min.css",
                "~/Content/buttons.dataTables.min.css",
                "~/Content/dataTables.bootstrap5.min.css",
                "~/Content/Site.css"
                ));
        }
    }
}
