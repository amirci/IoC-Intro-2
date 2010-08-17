using MavenThought.Commons.Testing;
using MavenThought.MediaLibrary.WebClient.Models;

namespace MavenThought.MediaLibrary.WebClient.Tests.Model
{
    /// <summary>
    /// Base specification for MovieFactory
    /// </summary>
    public abstract class MovieFactorySpecification
        : AutoMockSpecification<MovieFactory, IMovieFactory>
    {
    }
}