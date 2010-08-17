using MavenThought.Commons.Testing;
using MavenThought.MediaLibrary.Domain;

namespace MavenThought.MediaLibrary.Core.Tests
{
    /// <summary>
    /// Base specification for MediaLibrary
    /// </summary>
    public abstract class SimpleMediaLibrarySpecification
        : AutoMockSpecification<SimpleMediaLibrary, IMediaLibrary>
    {        
    }
}