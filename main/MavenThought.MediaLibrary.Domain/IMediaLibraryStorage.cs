using System.Collections.Generic;

namespace MavenThought.MediaLibrary.Domain
{
    /// <summary>
    /// Model for media storage
    /// </summary>
    public interface IMediaLibraryStorage
    {
        /// <summary>
        /// Saves a movie to the library
        /// </summary>
        /// <param name="media">Movie to save</param>
        void Save(IMovie media);

        /// <summary>
        /// Retrieves all the movies in the storage
        /// </summary>
        /// <returns></returns>
        IEnumerable<IMovie> Retrieve();

        /// <summary>
        /// Clears all the contents in the storage
        /// </summary>
        void Clear();
    }
}