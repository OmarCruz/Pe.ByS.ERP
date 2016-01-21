using System.IO;
using System.Web;
using System.Web.Optimization;
using System.Linq;

namespace Pe.ByS.Caja.Presentacion
{
    public class BundleConfig
    {
        // Para obtener más información acerca de Bundling, consulte http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Components/JQuery").Include(
                         "~/Components/JQuery/jquery-1.11.2.js",
                         "~/Components/JQuery/jquery-ui-1.10.4.custom.js",
                         "~/Components/JQuery/jquery.validate.js",
                         "~/Components/JQuery/jquery.validate.additional-methods.js",
                         "~/Components/JQuery/jquery.mask.js",
                         "~/Components/JQuery/jquery.autocomplete.min.js",
                         "~/Components/JQuery/jquery.formatCurrency-1.4.0.min.js",
                         "~/Components/JQuery/jquery.formatCurrency-1.4.0.js",
                         "~/Components/JQuery/jquery.tokeninput.js",
                         "~/Components/JQuery/jshashset-3.0.js",
                         "~/Components/JQuery/jshashtable-3.0.js",
                         "~/Components/JQuery/jquery.numberformatter-1.2.4.js"
             ));

            bundles.Add(new ScriptBundle("~/Components/DataTables").Include(
                        "~/Components/DataTables/js/jquery.dataTables.js",
                        "~/Components/DataTables/js/dataTables.responsive.js"
                        , "~/Components/DataTables/js/dataTables.bootstrap.js"
            ));

            bundles.Add(new ScriptBundle("~/Components/Codemaleon").Include(
                        "~/Components/Codemaleon/ns.js"
            ));

            bundles.Add(new StyleBundle("~/Components/TinyMCE").Include(
            "~/Components/TinyMCE/tiny_mce.js",
            "~/Components/TinyMCE/tiny_mce_popup.js",
            "~/Components/TinyMCE/tiny_mce_src.js"
            ));

            bundles.Add(new StyleBundle("~/Components/ckeditor").Include(
            "~/Components/ckeditor/ckeditor.js",
            "~/Components/ckeditor/adapters/jquery.js"
            ));

            bundles.Add(new ScriptBundle("~/Components/Gmd").Include(
                      "~/Scripts/Base/Layout/Util.js",
                      "~/Components/Gmd/Dialog/Dialog.js",
                      "~/Components/Gmd/FragmentView/FragmentView.js",
                        "~/Components/Gmd/Message/Message.js",
                        "~/Components/Gmd/Ajax/Ajax.js",
                        "~/Components/Gmd/ProgressBar/ProgressBar.js",
                        "~/Components/Gmd/Validator/Validator.js",
                        "~/Components/Gmd/Storage/Storage.js",
                        "~/Components/Gmd/TextBox/TextBox.js",
                        "~/Components/Gmd/Calendar/Calendar.js",
                        "~/Components/Gmd/Grid/Grid.js",
                        "~/Components/Gmd/TokenInput/TokenField.js",
                        "~/Components/Gmd/TinyMCE/TinyMCE.js",
                        "~/Components/Gmd/TabControl/TabControl.js",
                        "~/Components/Gmd/Calendar/Calendar.js"
            ));

            bundles.Add(new ScriptBundle("~/FrameworkStyle/js").Include(
                        "~/Components/Bootstrap/js/bootstrap.js"
            ));

            bundles.Add(new StyleBundle("~/Components/GmdCss").Include(
                        "~/Components/Gmd/ProgressBar/ProgressBar.css",
                        "~/Components/Gmd/Dialog/Dialog.css",
                        "~/Components/Gmd/Message/Message.css"
            ));

            bundles.Add(new StyleBundle("~/Components/JQueryCss").Include(
            "~/Components/JQuery/jquery-ui-1.10.0.custom.css",
            "~/Components/JQuery/TokenInput-facebook.css",
            "~/Components/JQuery/TokenInput.css"
            ));

            bundles.Add(new ScriptBundle("~/Components/DataTablesCss").Include(
                        "~/Components/DataTables/css/jquery.dataTables.css"
                        , "~/Components/DataTables/css/dataTables.bootstrap.css"
                        , "~/Components/DataTables/css/dataTables.responsive.css"
            ));

            bundles.Add(new StyleBundle("~/Template/css").Include(
                        "~/Theme/app/animate.css",
                        "~/Theme/app/main.css",
                        "~/Theme/app/dev.css"
            ));


            bundles.Add(new StyleBundle("~/FrameworkStyle/css").Include(
                        "~/Components/Bootstrap/css/bootstrap.css",
                        "~/Components/font-awesome/css/font-awesome.css"
            ));

            var directoryScripts = HttpContext.Current.Server.MapPath("~/Scripts");
            GenerateDynamicScriptBundle(bundles, new DirectoryInfo(directoryScripts));

            /*Custom page css*/

            //bundles.Add(new StyleBundle("~/Login/css").Include(
            //            "~/Theme/Login.css"));

        }

        private static void GenerateDynamicScriptBundle(BundleCollection bundles, DirectoryInfo directory, string pathDirectories = "")
        {
            var files = directory.EnumerateFiles();
            if (files != null && files.Any())
            {
                bundles.Add(new ScriptBundle("~/Scripts/" + pathDirectories.Replace("/", "").ToLower()).Include(
                                        "~/Scripts/" + pathDirectories + "*.js"));
            }
            var directories = directory.EnumerateDirectories().ToList();
            if (directories != null && directories.Any())
            {
                directories.ForEach(d =>
                {
                    GenerateDynamicScriptBundle(bundles, d, (pathDirectories + d.Name + "/"));
                });
            }
        }
    }
}