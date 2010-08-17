using System.Web.Mvc;
using System.Web.Routing;
using NHaml.Web.Mvc;

namespace MavenThought.MediaLibrary.WebClient
{
    /// <summary>
    /// Main application
    /// </summary>
    public class MediaLibraryApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Registers the routes
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                                // Route name
                "{controller}/{action}/{id}",                             // URL with parameters
                new { controller = "Movies", action = "Index", id = "" }  // Parameter defaults
            );

        }

        /// <summary>
        /// Called when the application starts
        /// </summary>
        protected void Application_Start()
        {
            // Add nhaml engine
            ViewEngines.Engines.Add(new NHamlMvcViewEngine());

            // Register the routes
            RegisterRoutes(RouteTable.Routes);
        }
    }
}