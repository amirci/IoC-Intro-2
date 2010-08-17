using System;
using MavenThought.MediaLibrary.Domain;

namespace MavenThought.MediaLibrary.WebClient.Tests
{
    /// <summary>
    /// Mock movie to use
    /// </summary>
    public class DummyMovie : IMovie
    {
        public IUser User { get; set; }

        public IMediaReview Review { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public DummyMovie() {}

        /// <summary>
        /// Constructor using title and release date
        /// </summary>
        /// <param name="title"></param>
        /// <param name="date"></param>
        public DummyMovie(string title, DateTime date)
        {
            this.Title = title;
            this.ReleaseDate = date;
        }

        /// <summary>
        /// Constructor with review
        /// </summary>
        /// <param name="review"></param>
        public DummyMovie(IMediaReview review)
        {
            Review = review;
        }

        /// <summary>
        /// Constructor with a user
        /// </summary>
        /// <param name="review"></param>
        /// <param name="user"></param>
        public DummyMovie(IMediaReview review, IUser user)
            : this(review)
        {
            User = user;
        }

        /// <summary>
        /// Title for the media element
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// The release date of the media
        /// </summary>
        public DateTime? ReleaseDate { get; set; }
    }

    public interface IMovieCritic
    {
    }
}