using MavenThought.MediaLibrary.Domain;

namespace MavenThought.MediaLibrary.WebClient.Models
{
    /// <summary>
    /// Factory to provide movies
    /// </summary>
    public interface IMovieFactory
    {
        /// <summary>
        /// Creates a new movie
        /// </summary>
        /// <param name="title"></param>
        /// <returns>The new movie instance</returns>
        IMovie Create(string title);
    }
}