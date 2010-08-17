using System.Collections.Generic;
using MavenThought.MediaLibrary.Domain;

namespace MavenThought.MediaLibrary.Core
{
    /// <summary>
    /// Implementation of media library
    /// </summary>
    public class SimpleMediaLibrary : IMediaLibrary
    {
        /// <summary>
        /// Storage backing field
        /// </summary>
        private readonly IMediaLibraryStorage _storage;

        /// <summary>
        /// Constructor using the storage
        /// </summary>
        /// <param name="storage"></param>
        public SimpleMediaLibrary(IMediaLibraryStorage storage)
        {
            _storage = storage;
        }

        /// <summary>
        /// Adds a new element to the library
        /// </summary>
        /// <param name="element">New media element to add to the library</param>
        public void Add(IMovie element)
        {
            this._storage.Save(element);
        }

        /// <summary>
        /// Gets the collection of media
        /// </summary>
        public IEnumerable<IMovie> Contents
        {
            get
            {
                return this._storage.Retrieve();
            }
        }

        /// <summary>
        /// Clears the contents of the library
        /// </summary>
        public void Clear()
        {
            this._storage.Clear();
        }
    }
}