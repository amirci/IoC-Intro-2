using MavenThought.MediaLibrary.Domain;
using Rhino.Mocks;
using MavenThought.Commons.Testing;

namespace MavenThought.MediaLibrary.Core.Tests
{
    /// <summary>
    /// Specification when the library is cleared
    /// </summary>
    [Specification]
    public class WhenSimpleMediaLibraryClearsTheStorage : SimpleMediaLibrarySpecification
    {
        /// <summary>
        /// Checks the storage is cleared as well
        /// </summary>
        [It]
        public void Should_clear_the_storage()
        {
            Dep<IMediaLibraryStorage>().AssertWasCalled(storage => storage.Clear());
        }

        /// <summary>
        /// Clear the library
        /// </summary>
        protected override void WhenIRun()
        {
            this.Sut.Clear();
        }
    }
}