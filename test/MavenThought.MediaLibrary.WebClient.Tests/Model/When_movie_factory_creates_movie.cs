using System.Collections.Generic;
using Castle.Windsor;
using MavenThought.MediaLibrary.Domain;
using MavenThought.Commons.Testing;
using SharpTestsEx;

namespace MavenThought.MediaLibrary.WebClient.Tests.Model
{
    /// <summary>
    /// Specification when ...
    /// </summary>
    [Specification]
    public class When_movie_factory_creates_movie : MovieFactorySpecification
    {
        /// <summary>
        /// Actual movie created
        /// </summary>
        private IMovie _actual;

        /// <summary>
        /// Checks the movie is the one returned
        /// </summary>
        [It]
        public void Should_return_the_configured_movie()
        {
            this._actual.Should().Be(Dep<IMovie>());
        }

        /// <summary>
        /// Setup the Windsor container
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            var dictionary = new Dictionary<string, object>
                                 {
                                     { "title", "Blazing Saddles"}                                     
                                 };

            Stub<IWindsorContainer, IMovie>(ctr => ctr.Resolve<IMovie>(dictionary));
        }

        /// <summary>
        /// Create the movie
        /// </summary>
        protected override void WhenIRun()
        {
            this._actual = this.Sut.Create("Blazing Saddles");
        }
    }
}