using System;
using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using MavenThought.Commons.Testing;
using MavenThought.MediaLibrary.Domain;
using MbUnit.Framework;
using SharpTestsEx;

namespace MavenThought.MediaLibrary.WebClient.Tests
{
    /// <summary>
    /// Specification when registering types into Windsor
    /// </summary>
    [Specification]
    public class When_windsor_resolves_with_parameters : WindsorContainerSpecification
    {
        /// <summary>
        /// Actual movie obtained
        /// </summary>
        private IMovie _actual;

        /// <summary>
        /// Checks the instance is resolved
        /// </summary>
        [Test]
        public void Should_have_expected_title()
        {
            this._actual.Title.Should().Be("Blazing Saddles");
        }

        /// <summary>
        /// Checks the same instance is resolved
        /// </summary>
        [Test]
        public void Should_have_expected_release_date()
        {
            this._actual.ReleaseDate.Should().Be(new DateTime(2010, 01, 01));
        }

        /// <summary>
        /// Register a movie
        /// </summary>
        protected override void AndGivenThatAfterCreated()
        {
            base.AndGivenThatAfterCreated();

            this.Sut.Register(Component.For<IMovie>().ImplementedBy<DummyMovie>());
        }

        /// <summary>
        /// Resolve the service
        /// </summary>
        protected override void WhenIRun()
        {
            var dictionary = new Dictionary<string, object>()
                                 {
                                     { "title", "Blazing Saddles" },
                                     { "date", new DateTime(2010, 01, 01) }
                                 };

            this._actual = this.Sut.Resolve<IMovie>(dictionary);
        }
    }
}