using System.Web.Optimization;

namespace PasswordManager
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/bootstrap/js").Include(
                "~/Scripts/bootstrap.bundle.min.js",
                "~/Scripts/bootstrap.esm.min.js",
                "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap/css").Include(
                "~/Content/bootstrap-grid.min.css",
                "~/Content/bootstrap-reboot.min.css",
                "~/Content/bootstrap-utilities.min.css",
                "~/Content/bootstrap.min.css",
                "~/Content/Site.css"
                ));
        }
    }
}
