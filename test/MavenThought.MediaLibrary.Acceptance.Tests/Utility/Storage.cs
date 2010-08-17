using System.IO;
using MavenThought.MediaLibrary.Core;
using MavenThought.MediaLibrary.Domain;
using MavenThought.MediaLibrary.Storage.NHibernate;

namespace MavenThought.MediaLibrary.Acceptance.Tests.Utility
{
    /// <summary>
    /// Base class for movie library steps
    /// </summary>
    public class Storage
    {
        /// <summary>
        /// Setup the library
        /// </summary>
        static Storage()
        {
            // DatabaseFile = Path.GetTempFileName();
            DatabaseFile = "c:/temp/movies.db";

            Instance = new SimpleMediaLibrary(new NHMediaLibraryStorage(DatabaseFile));
        }

        /// <summary>
        /// Gets the database file used
        /// </summary>
        public static string DatabaseFile { get; private set; }

        /// <summary>
        /// Gets the instance of the library
        /// </summary>
        public static IMediaLibrary Instance { get; private set; }
    }
}