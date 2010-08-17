using MavenThought.Commons.Testing;
using MavenThought.MediaLibrary.Domain;

namespace MavenThought.MediaLibrary.Core.Tests
{
    /// <summary>
    /// Base specification for Movie
    /// </summary>
    public abstract class MovieSpecification
        : AutoMockSpecification<Movie, IMovie>
    {
        /// <summary>
        /// Returns default movie
        /// </summary>
        /// <returns></returns>
        protected override IMovie CreateSut()
        {
            return new Movie();
        }
    }
}