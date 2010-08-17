using MavenThought.MediaLibrary.Domain;
using Rhino.Mocks;
using MavenThought.Commons.Testing;

namespace MavenThought.MediaLibrary.Core.Tests
{
    /// <summary>
    /// Specification when adding media to the library
    /// </summary>
    [Specification]
    public class WhenSimpleMediaLibraryAddsSimpleMedia : SimpleMediaLibrarySpecification
    {
        /// <summary>
        /// Checks the movie is saved in the storage
        /// </summary>
        [It]
        public void Should_save_the_movie_in_the_storage()
        {
            Dep<IMediaLibraryStorage>().AssertWasCalled(storage => storage.Save(Dep<IMovie>()));
        }

        /// <summary>
        /// Add the movie to the library
        /// </summary>
        protected override void WhenIRun()
        {
            this.Sut.Add(Dep<IMovie>());
        }
    }
}