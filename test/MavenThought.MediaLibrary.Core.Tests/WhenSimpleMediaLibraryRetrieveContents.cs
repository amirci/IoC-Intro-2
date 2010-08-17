using System.Collections.Generic;
using MavenThought.Commons.Extensions;
using MavenThought.MediaLibrary.Domain;
using Rhino.Mocks;
using MavenThought.Commons.Testing;
using SharpTestsEx;

namespace MavenThought.MediaLibrary.Core.Tests
{
    /// <summary>
    /// Specification when retrieving contents from the library
    /// </summary>
    [Specification]
    public class WhenSimpleMediaLibraryRetrieveContents : SimpleMediaLibrarySpecification
    {
        /// <summary>
        /// Actual values obtained
        /// </summary>
        private IEnumerable<IMovie> _actual;

        /// <summary>
        /// Expected values
        /// </summary>
        private IEnumerable<IMovie> _expected;

        /// <summary>
        /// Checks the media is returned from the storage
        /// </summary>
        [It]
        public void Should_return_the_expected_media_from_the_storage()
        {
            this._actual.Should().Have.SameSequenceAs(this._expected);
        }

        /// <summary>
        /// Setup the storage
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this._expected = 10.Times(() => Mock<IMovie>());

            Dep<IMediaLibraryStorage>()
                .Stub(storage => storage.Retrieve())
                .Return(this._expected);
        }

        /// <summary>
        /// Get the contents from the library
        /// </summary>
        protected override void WhenIRun()
        {
            this._actual = this.Sut.Contents;
        }
    }
}