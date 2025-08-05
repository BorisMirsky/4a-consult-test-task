using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace _4aconsultWebForms
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
            //
            routes.MapPageRoute(null, "list/{category}/{page}", "~/Pages/Default.aspx");
            routes.MapPageRoute(null, "list/{page}", "~/Pages/Default.aspx");
            routes.MapPageRoute(null, "", "~/Pages/Default.aspx");
            routes.MapPageRoute(null, "list", "~/Pages/Default.aspx");

        }
    }
}
