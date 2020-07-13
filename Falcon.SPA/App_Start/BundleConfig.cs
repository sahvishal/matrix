using System.Web.Optimization;

namespace Falcon.SPA.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/onlineCheckout")
                .Include("~/Content/custom.css")
                .Include("~/Content/toastr.css")
                .Include("~/Content/typography.css")
                .Include("~/Content/alertify/alertify.core.css")
                .Include("~/Content/alertify/alertify.default.css")
                .Include("~/Content/auto-complete.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap")
                .Include("~/Content/typography.css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/slider.css"));

            bundles.Add(new StyleBundle("~/Content/thridparty")
               .Include("~/Content/toastr.css")
                .Include("~/Content/typography.css")
                .Include("~/Content/alertify/alertify.core.css")
                .Include("~/Content/alertify/alertify.default.css")
                .Include("~/Content/auto-complete.css")
                .Include("~/Content/jquery.qtip.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.inputmask.bundle.js",
                        "~/Scripts/jquery.maskedinput.js",
                        "~/Scripts/jquery.easing.1.3.js",
                        "~/Scripts/jquery.mousewheel.js",
                        "~/Scripts/jquery.contentcarousel.js",
                        "~/Scripts/jquery-ui-1.10.4.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.js",
                //"~/Scripts/angular-animate.js",
                "~/Scripts/angular-resource.js",
                "~/Scripts/angular-route.js",
                "~/Scripts/angular-spinner.js",
                "~/Scripts/angular-cookies.js",
                "~/Scripts/angular-sanitize.js",
                "~/Scripts/angular-slider.js",
                "~/Scripts/angular-ui-router.js",
                "~/Scripts/ngPercentDisplay.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/thirdparty").Include(
                "~/Scripts/spinner/spin.js",
               "~/Scripts/spinner/angular-spinner.js",
               "~/Scripts/angular-busy.js",
               "~/Scripts/thirdparty/*.js",
               "~/Content/colorbox/jquery.colorbox.js"
               ));

            bundles.Add(new ScriptBundle("~/bundles/qtip").Include(
               "~/Scripts/thirdparty/imagesloaded.pkg.min.js",
              "~/Scripts/thirdparty/jquery.qtip.min.js"
              ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.min.js"
                        , "~/Scripts/ui-bootstrap.min.js"
                        , "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/public").Include(
                "~/public/config.js", "~/public/application.js"));


            bundles.Add(new ScriptBundle("~/bundles/public/core").IncludeDirectory("~/public/modules/core", "*.js", true));
            bundles.Add(new ScriptBundle("~/bundles/public/online").IncludeDirectory("~/public/modules/online", "*.js", true));
            bundles.Add(new ScriptBundle("~/bundles/public/callcenter").IncludeDirectory("~/public/modules/callcenter", "*.js", true));
            bundles.Add(new ScriptBundle("~/bundles/lib").IncludeDirectory("~/public/lib", "*.js", true));
            bundles.Add(new ScriptBundle("~/bundles/lib/angular").IncludeDirectory("~/public/lib/angular", "*.js", true));
            bundles.Add(new ScriptBundle("~/bundles/public/shared").IncludeDirectory("~/public/modules/shared", "*.js", true));

            BundleTable.EnableOptimizations = true;
        }

    }
}