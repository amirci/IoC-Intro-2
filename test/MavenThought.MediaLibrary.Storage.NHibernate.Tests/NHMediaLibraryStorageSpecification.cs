using MavenThought.Commons.Testing;
using MavenThought.MediaLibrary.Domain;
using NHibernate;

namespace MavenThought.MediaLibrary.Storage.NHibernate.Tests
{
    /// <summary>
    /// StorageMediaLibrary specification
    /// </summary>
    public abstract class NHMediaLibraryStorageSpecification
        : AutoMockSpecification<NHMediaLibraryStorage, IMediaLibraryStorage>
    {
        /// <summary>
        /// Creates the media library using the session factory dependency
        /// </summary>
        /// <returns>An instance to storage media library</returns>
        protected override IMediaLibraryStorage CreateSut()
        {
            return new NHMediaLibraryStorage(Dep<ISessionFactory>());
        }
    }
}