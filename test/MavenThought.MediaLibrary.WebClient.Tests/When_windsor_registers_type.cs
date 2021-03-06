﻿using Castle.MicroKernel.Registration;
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
    public class When_windsor_registers_type : WindsorContainerSpecification
    {
        /// <summary>
        /// Actual movie obtained
        /// </summary>
        private IMovie _actual;

        /// <summary>
        /// Checks the instance is resolved
        /// </summary>
        [Test]
        public void Should_return_an_instance_of_mock_movie()
        {
            this._actual.Should().Be.InstanceOf<DummyMovie>();
        }

        /// <summary>
        /// Checks the same instance is resolved
        /// </summary>
        [Test]
        public void Should_return_always_the_same_instance()
        {
            var instance2 = this.Sut.Resolve<IMovie>();

            this._actual.Should().Be.SameInstanceAs(instance2);
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
            this._actual = this.Sut.Resolve<IMovie>();
        }
    }
}