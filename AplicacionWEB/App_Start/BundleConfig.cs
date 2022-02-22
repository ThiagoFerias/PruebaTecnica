using System.Web;
using System.Web.Optimization;

namespace AplicacionWEB
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/pages/dashboard.js",
                      "~/Scripts/mazer.js",
                      "~/Scripts/bootstrap.bundle.min.js",
                      "~/Content/vendors/perfect-scrollbar/perfect-scrollbar.min.js",
                      "~/Content/vendors/apexcharts/apexcharts.js",
                      "~/Content/vendors/simple-datatables/simple-datatables.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/vendors/iconly/bold.css",
                      "~/Content/vendors/perfect-scrollbar/perfect-scrollbar.css",
                      "~/Content/vendors/bootstrap-icons/bootstrap-icons.css",
                      "~/Content/css/app.css",
                      "~/Content/vendors/simple-datatables/style.css"));
            
            //login
            bundles.Add(new StyleBundle("~/Auth/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/vendors/perfect-scrollbar/perfect-scrollbar.css",
                      "~/Content/vendors/bootstrap-icons/bootstrap-icons.css",
                      "~/Content/css/app.css",
                      "~/Content/css/pages/auth.css"));
        }
    }
}
