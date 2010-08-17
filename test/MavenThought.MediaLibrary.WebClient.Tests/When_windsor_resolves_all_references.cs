using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using MavenThought.Commons.Extensions;
using MavenThought.Commons.Testing;
using MavenThought.MediaLibrary.Domain;
using MbUnit.Framework;
using SharpTestsEx;

namespace MavenThought.MediaLibrary.WebClient.Tests
{
    /// <summary>
    /// Specification when resolving types with a name
    /// </summary>
    [Specification]
    public class When_windsor_resolves_all_references : WindsorContainerSpecification
    {
        /// <summary>
        /// Actual movie obtained
        /// </summary>
        private IMovie[] _actual;

        private IEnumerable<IMovie> _expected;

        /// <summary>
        /// Checks the named "Blazing" returns the mock
        /// </summary>
        [Test]
        public void Should_return_all_expected_mocks()
        {
            this._actual.Should().Have.SameSequenceAs(this._expected);
        }

        /// <summary>
        /// Register a movie
        /// </summary>
        protected override void AndGivenThatAfterCreated()
        {
            base.AndGivenThatAfterCreated();

            this._expected = 10.Times(() => Mock<IMovie>());

            this._expected
                .ForEach((i, mock) =>
                         this.Sut.Register(Component.For<IMovie>()
                                               .Instance(mock)
                                               .Named("Movie" + i)));
        }

        /// <summary>
        /// Resolve the service
        /// </summary>
        protected override void WhenIRun()
        {
            this._actual = this.Sut.ResolveAll<IMovie>();
        }
    }
}