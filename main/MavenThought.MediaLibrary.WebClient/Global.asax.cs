using System;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MavenThought.MediaLibrary.Core;
using MavenThought.MediaLibrary.Domain;
using MavenThought.MediaLibrary.Storage.NHibernate;
using MavenThought.MediaLibrary.WebClient.Controllers;
using MvcContrib.Castle;
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

            // Setup IoC container
            this.SetupContainer();

            // Register the factory for the controllers
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(this.Container));
   
            // Register the routes
            RegisterRoutes(RouteTable.Routes);
        }

        /// <summary>
        /// Container property
        /// </summary>
        protected IWindsorContainer Container { get; set; }

        /// <summary>
        /// Register controllers and other types
        /// </summary>
        private void SetupContainer()
        {
            this.Container = new WindsorContainer();

            this.Container.Register(
                Component.For<Controller>().ImplementedBy<MoviesController>().Named("Movies"),
                Component.For<Controller>().ImplementedBy<HomeController>().Named("Home"),
                Component.For<IMediaLibrary>().ImplementedBy<SimpleMediaLibrary>(),
                Component.For<IMediaLibraryStorage>().Instance(new NHMediaLibraryStorage("c:/temp/movies.db"))
                );
        }
    }
}