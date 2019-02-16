using System.Web;
using System.Web.Optimization;

namespace EC_Ecom2
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.js"));
                //.Include("~/Scripts/circle-progress.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/circle-progress").Include(
            //          "~/Scripts/circle-progress.min.js"));
            //var bundle = new ScriptBundle("~/bundles/photogallery")
            //    .Include("~/Scripts/circle-progress.min.js")
            //    .Include("~/Scripts/imagesloaded.pkgd.min.js")
            //    .Include("~/Scripts/isotope.pkgd.min.js")
            //    .Include("~/Scripts/jquery.nicescroll.min.js")
            //    .Include("~/Scripts/main.js")
            //    .Include("~/Scripts/owl.carousel.min.js");
            //bundles.Add(bundle);
    

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"
                      //"~/Content/css/animate.css",
                      //"~/Content/css/font-awesome.min.css",
                      //"~/Content/css/owl.carousel.min.css",
                      //"~/Content/css/style.css"
                      ));
        }
    }
}
