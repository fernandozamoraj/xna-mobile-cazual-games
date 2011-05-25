using System;
using CazualGames.Core;
using CazualGames.Services;
using XnaMobileUnit.FrameWork;

namespace CazualGames.UnitTests.Services
{
    public class ServiceLocatorContext : TestFixture
    {
        protected ServiceLocator _serviceLocator;

        public override void Context()
        {
            _serviceLocator = ServiceLocator.GetTestLocator();
        }
    }

    public class WhenRetrievingServiceThatExists : ServiceLocatorContext
    {
        private IDummyService _service;
        public override void Context()
        {
            base.Context();

            _serviceLocator.RegisterService<IDummyService>(new DummyService());
            _service = _serviceLocator.GetService<IDummyService>();
        }

        [TestMethod]
        public void should_return_the_service()
        {
            Assert.IsTrue(_service != null, "Should have returned the service");
        }

        [TestMethod]
        public void service_should_be_of_IDummyService_type()
        {
            Assert.AreEqual(typeof(IDummyService), _service.GetType().GetInterface("IDummyService", false), "Service should be of type IDummyService");
        }
    }

    public class WhenRegisteringAServiceThatDoesNotImplementTheInterface : ServiceLocatorContext
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void should_throw_an_argument_exception()
        {
            _serviceLocator.RegisterService<IDummyService>(new FooService());
        }
    }

    public class WhenFetchingAServiceThatDoesNotExist : ServiceLocatorContext
    {
        [TestMethod]
        [ExpectedException(typeof(CazualGamesException))]
        public void Should_throw_a_cazual_games_exception()
        {
            _serviceLocator.GetService<IDummyService>();
        }
    }

    public class WhenRegisteringANullService : ServiceLocatorContext
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_throw_a_null_argument_exception()
        {
            _serviceLocator.RegisterService<IDummyService>(null);
        }
    }

    public interface IDummyService{}
    public class DummyService : IDummyService{}
    public interface IFooService{}
    public class FooService{}
}
