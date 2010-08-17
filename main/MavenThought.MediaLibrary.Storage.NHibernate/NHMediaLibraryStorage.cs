using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.Cfg.Db;
using MavenThought.MediaLibrary.Core;
using MavenThought.MediaLibrary.Domain;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace MavenThought.MediaLibrary.Storage.NHibernate
{
    /// <summary>
    /// Implementation that uses NH to store the media
    /// </summary>
    public class NHMediaLibraryStorage : IMediaLibraryStorage
    {
        /// <summary>
        /// Factory to obtain the session
        /// </summary>
        private readonly ISessionFactory _factory;

        /// <summary>
        /// Initializes the repository using a persistence configurer
        /// </summary>
        public NHMediaLibraryStorage(string databaseFile)
        {
            var configurer = SQLiteConfiguration.Standard.UsingFile(databaseFile);

#if DEBUG
            configurer.ShowSql();
#endif
            
            this._factory = SessionFactoryGateway.CreateSessionFactory(configurer, BuildSchema);
        }

        /// <summary>
        /// Constructor that injects the session factory
        /// </summary>
        /// <param name="factory">Session factory to use</param>
        public NHMediaLibraryStorage(ISessionFactory factory)
        {
            this._factory = factory;
        }

        /// <summary>
        /// Adds a new element to the library
        /// </summary>
        /// <param name="element">New media element to add to the library</param>
        public void Save(IMovie element)
        {
            this._factory.SaveOrUpdate(element);
        }

        /// <summary>
        /// Gets the collection of media
        /// </summary>
        public IEnumerable<IMovie> Retrieve()
        {
            return this._factory.List<Movie>().Cast<IMovie>();
        }

        /// <summary>
        /// Clears the contents of the library
        /// </summary>
        public void Clear()
        {
            this._factory.AutoCommit(s => s.Delete("from Movie"));
        }

        /// <summary>
        /// Deletes the database if exists and creates the schema
        /// </summary>
        /// <param name="config">
        /// Configuration to use 
        /// </param>
        private static void BuildSchema(Configuration config)
        {
            // export schema
            new SchemaExport(config).Create(true, true);
        }
    }
}