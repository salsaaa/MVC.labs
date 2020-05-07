using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebApplication1.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Bundles/scripts").Include(
                   "~/scripts/jquery-3.0.0.min.js" ,
                   "~/Scripts/bootstrap.min.js" ,
                   "~/scripts/jquery.unobtrusive-ajax.js" ,
                   "~/scripts/jquery.validate.min.js" ,
                   "~/scripts/jquery.validate.unobtrusive.min.js",
                   "~/scripts/SiteScripts/site.js"
                  
                ));
        }
    }
}