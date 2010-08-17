using System.Linq;
using System.Web.Mvc;
using MavenThought.MediaLibrary.Domain;
using MavenThought.MediaLibrary.WebClient.Models;

namespace MavenThought.MediaLibrary.WebClient.Controllers
{
    /// <summary>
    /// Controller for movies
    /// </summary>
    public class MoviesController : Controller
    {
        /// <summary>
        /// Library instance
        /// </summary>
        private readonly IMediaLibrary _library;

        /// <summary>
        /// Factory backing field
        /// </summary>
        private readonly IMovieFactory _factory;

        /// <summary>
        /// Initializes the controller
        /// </summary>
        /// <param name="library">Library to use</param>
        /// <param name="factory">Factory to create movies</param>
        public MoviesController(IMediaLibrary library, IMovieFactory factory)
        {
            _library = library;
            _factory = factory;
        }

        /// <summary>
        /// Gets the list of movies GET : /Movies/
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(this._library.Contents.ToList());
        }

        /// <summary>
        /// Gets the form to add a movie
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates a movie using the title passed by parameter
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(string title)
        {
            this._library.Add(this._factory.Create(title));

            return Redirect("Index");
        }
    }
}
