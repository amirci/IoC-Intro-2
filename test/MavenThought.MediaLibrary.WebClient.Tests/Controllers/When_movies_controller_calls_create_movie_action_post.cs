using MavenThought.MediaLibrary.Domain;
using MbUnit.Framework;
using MvcContrib.TestHelper;
using Rhino.Mocks;
using MavenThought.Commons.Testing;

namespace MavenThought.MediaLibrary.WebClient.Tests.Controllers
{
    /// <summary>
    /// Specification when calling Movies/Create with a form POST
    /// </summary>
    [Specification]
    public class When_movies_controller_calls_create_movie_action_post : MoviesControllerSpecification
    {
        /// <summary>
        /// Actual title to add
        /// </summary>
        private readonly string _title;

        /// <summary>
        /// Initializes a new instance of <see cref="When_movies_controller_calls_create_movie_action_post"/> class.
        /// </summary>
        /// <param name="title">Title to use</param>
        public When_movies_controller_calls_create_movie_action_post([RandomStrings(Count = 10, Pattern = "The Great [a-z]{8}")]string title)
        {
            this._title = title;
        }

        /// <summary>
        /// Checks the view returned is to add a movie
        /// </summary>
        [It]
        public void Should_return_the_form_to_create()
        {
            this.ActualResult.AssertHttpRedirect().ToUrl("Index");
        }

        /// <summary>
        /// Checks the movie has been added to the library
        /// </summary>
        [It]
        public void Should_add_the_movie_to_the_library()
        {
            var movieWithSameTitle = Arg<IMovie>.Matches(m => m.Title == this._title);

            Dep<IMediaLibrary>().AssertWasCalled(lib => lib.Add(movieWithSameTitle));
        }

        /// <summary>
        /// Call create to show the form
        /// </summary>
        protected override void WhenIRun()
        {
            this.ActualResult = this.Sut.Create(this._title);
        }
    }
}