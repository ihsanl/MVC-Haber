using System;
using System.Web.Mvc;
using System.Web.WebPages;

[assembly: WebActivatorEx.PreApplicationStartMethod(
    typeof(HaberPortalı.App_Start.SecureDefaultsMvc), "PreStart")]

namespace HaberPortalı.App_Start {
    public static class SecureDefaultsMvc {
        public static void PreStart() {
            MvcHandler.DisableMvcResponseHeader = true;
            WebPageHttpHandler.DisableWebPagesResponseHeader = true;
        }
    }
}