using Castle.MicroKernel.Registration;
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
    public class When_windsor_resolves_with_naming : WindsorContainerSpecification
    {
        /// <summary>
        /// Actual movie obtained
        /// </summary>
        private IMovie _actual;

        private IMovie _actual2;

        private IMovie _expected;

        /// <summary>
        /// Checks the named "Blazing" returns the mock
        /// </summary>
        [Test]
        public void Should_return_expected_mock_named_blazing()
        {
            this._actual.Should().Be(this._expected);
        }

        /// <summary>
        /// Checks the name "YoungF" returns a DummyMovie instance
        /// </summary>
        [Test]
        public void Should_return_dummy_class_named_young_f()
        {
            this._actual2.Should().Be.InstanceOf<DummyMovie>();
        }

        /// <summary>
        /// Checks that both instances are different
        /// </summary>
        [It]
        public void Should_return_different_instances()
        {
            this._actual.Should().Not.Be.SameInstanceAs(this._actual2);
        }

        /// <summary>
        /// Register a movie
        /// </summary>
        protected override void AndGivenThatAfterCreated()
        {
            base.AndGivenThatAfterCreated();

            this.Sut.Register(Component.For<IMovie>()
                                  .Instance(this._expected = Mock<IMovie>())
                                  .Named("Blazing"),
                              Component.For<IMovie>()
                                  .ImplementedBy<DummyMovie>()
                                  .Named("YoungF"));
        }

        /// <summary>
        /// Resolve the service
        /// </summary>
        protected override void WhenIRun()
        {
            this._actual = this.Sut.Resolve<IMovie>("Blazing");
            this._actual2 = this.Sut.Resolve<IMovie>("YoungF");
        }
    }
}