using System.Web;
using System.Web.Optimization;

namespace Barbeda
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Assets/css").Include(
                                          "~/Assets/css/bootstrap.min.css",
                                          "~/Assets/css/font-awesome.min.css",                
                                          "~/Assets/css/owl.carousel.min.css",
                                          "~/Assets/css/owl.transitions.css",                        
                                          "~/Assets/css/magnific-popup.css",       
                                          "~/Assets/css/jquery-ui.css" ,
                                          "~/Assets/css/style.css",  
                                          "~/Assets/css/responsive.css"
                ));
            bundles.Add(new ScriptBundle("~/Assets/js").Include(
                                         "~/Assets/js/jquery.min.js",
                                         //"~/Assets/js/jquery-ui.js",
                                         "~/Assets/js/bootstrap.min.js",
                                         "~/Assets/js/owl.carousel.min.js",
                                         "~/Assets/js/jquery.mixitup.js",
                                         "~/Assets/js/jquery.magnific-popup.min.js",
                                         "~/Assets/js/jquery.waypoints.min.js",
                                         "~/Assets/js/jquery.ajaxchimp.min.js",
                                         "~/Assets/js/main_script.js"
                ));

            bundles.Add(new ScriptBundle("~/Assets/validate").Include(
                        "~/Assets/validate/jquery.validate*"));

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}
