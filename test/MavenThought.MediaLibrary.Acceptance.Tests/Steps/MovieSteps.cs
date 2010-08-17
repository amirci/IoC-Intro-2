using MavenThought.MediaLibrary.Acceptance.Tests.PageObjects;
using TechTalk.SpecFlow;

namespace MavenThought.MediaLibrary.Acceptance.Tests.Steps
{
    /// <summary>
    /// Steps related to movie
    /// </summary>
    [Binding]
    public class MovieSteps
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MovieSteps()
        {
            this.Page = new AddMoviePage();
        }

        /// <summary>
        /// Gets the add movies page
        /// </summary>
        protected AddMoviePage Page { get; private set; }

        /// <summary>
        /// Enters the movie title
        /// </summary>
        /// <param name="title"></param>
        [When(@"I enter (.*) in the title")]
        public void EnterMovieTitle(string title)
        {
            this.Page.Title = title;
        }

        /// <summary>
        /// Submit the new movie to the library
        /// </summary>
        [When(@"I click Submit")]
        public void SubmitNewMovie()
        {
            this.Page.Submit();
        }
    }
}