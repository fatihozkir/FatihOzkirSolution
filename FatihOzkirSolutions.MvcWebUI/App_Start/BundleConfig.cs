using System.Web.Optimization;
namespace FatihOzkirSolutions.MvcWebUI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css/mainStyles").Include(
                "~/Content/Site.css",
                "~/Content/bootstrap.min.css"
                ));
            bundles.Add(new ScriptBundle("~/js/mainScripts").Include(
                "~/Scripts/modernizr-2.6.2.js",
                "~/Scripts/jquery-1.10.2.min.js",
                "~/Scripts/bootstrap.min.js"
                ));
            bundles.Add(new ScriptBundle("~/js/validationScripts").Include(
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js"
                ));
            bundles.Add(new ScriptBundle("~/js/pagerScripts").Include(
                "~/Scripts/paginathing.js",
                "~/Scripts/pagerScript.js"
            ));
            BundleTable.EnableOptimizations = true;
        }
    }
}