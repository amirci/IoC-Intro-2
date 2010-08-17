using Castle.MicroKernel.Registration;
using MavenThought.Commons.Testing;
using MavenThought.MediaLibrary.Domain;
using MbUnit.Framework;
using SharpTestsEx;

namespace MavenThought.MediaLibrary.WebClient.Tests
{
    /// <summary>
    /// Specification when registering transient types into Windsor
    /// </summary>
    [Specification]
    public class When_windsor_resolves_greediest_constructor_possible : WindsorContainerSpecification
    {
        /// <summary>
        /// Actual movie obtained
        /// </summary>
        private DummyMovie _actual;

        /// <summary>
        /// Checks the instance is resolved
        /// </summary>
        [Test]
        public void Should_have_review()
        {
            this._actual.Review.Should().Not.Be.Null();
        }

        /// <summary>
        /// Checks the same instance is resolved
        /// </summary>
        [Test]
        public void Should_not_have_user()
        {
            this._actual.User.Should().Be.Null();
        }

        /// <summary>
        /// Register a movie
        /// </summary>
        protected override void AndGivenThatAfterCreated()
        {
            base.AndGivenThatAfterCreated();

            this.Sut.Register(Component.For<IMovie>()
                                  .ImplementedBy<DummyMovie>(),
                              Component.For<IMediaReview>()
                                  .Instance(Dep<IMediaReview>()));


        }

        /// <summary>
        /// Resolve the service
        /// </summary>
        protected override void WhenIRun()
        {
            this._actual = (DummyMovie)this.Sut.Resolve<IMovie>();
        }
    }
}