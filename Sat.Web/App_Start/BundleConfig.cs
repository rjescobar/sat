using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Sat.Web.App_Start
{
    public class BundleConfig
    {
        /// <summary>
        ///  Agregar a la tabla de Bundle nuestros paquetes.
        /// </summary>
        /// <param name="bundles">Tabla de bundles.</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
             
            bundles.Add(new ScriptBundle("~/bundles/scripts")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/toastr.js")
                .Include("~/Scripts/jquery.validate.js")
                .Include("~/Scripts/jquery.validate.unobtrusive.js"));

            bundles.Add(new StyleBundle("~/bundles/styles")
                .Include("~/Content/bootstrap-theme.css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/toastr.css")
                .Include("~/Content/font-awesome.css")
                .Include("~/Content/styles.css"));

            //Fuerza que se optimicen los bundles
            //BundleTable.EnableOptimizations = true;
        }
    }
}