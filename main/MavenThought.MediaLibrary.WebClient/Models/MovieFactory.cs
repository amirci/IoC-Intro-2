using System.Collections.Generic;
using Castle.Windsor;
using MavenThought.MediaLibrary.Domain;

namespace MavenThought.MediaLibrary.WebClient.Models
{
    /// <summary>
    /// Implementation of movie factory
    /// </summary>
    public class MovieFactory : IMovieFactory
    {
        private readonly IWindsorContainer _container;

        /// <summary>
        /// Constructor injecting the container
        /// </summary>
        /// <param name="container"></param>
        public MovieFactory(IWindsorContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Creates a new movie
        /// </summary>
        /// <param name="title"></param>
        /// <returns>The new movie instance</returns>
        public IMovie Create(string title)
        {
            return this._container.Resolve<IMovie>(new Dictionary<string, object>()
                                                       {
                                                           { "title", title }
                                                       });
        }
    }
}