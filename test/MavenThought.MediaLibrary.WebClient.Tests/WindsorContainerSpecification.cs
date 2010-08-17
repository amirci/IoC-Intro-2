using Castle.Windsor;
using MavenThought.Commons.Testing;

namespace MavenThought.MediaLibrary.WebClient.Tests
{
    /// <summary>
    /// Base specification for WindsorContainer
    /// </summary>
    public abstract class WindsorContainerSpecification
        : AutoMockSpecification<WindsorContainer, IWindsorContainer>
    {
        /// <summary>
        /// Creates the container
        /// </summary>
        /// <returns></returns>
        protected override IWindsorContainer CreateSut()
        {
            return new WindsorContainer();
        }
    }
}