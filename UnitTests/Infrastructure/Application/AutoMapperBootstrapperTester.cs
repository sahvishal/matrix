using AutoMapper;
using Falcon.App.Infrastructure.Application.Impl;
using NUnit.Framework;

namespace Falcon.UnitTests.Infrastructure.Application
{
    [TestFixture]
    public class AutoMapperBootstrapperTester
    {
        [Test]
        public void AssertConfigurationIsValid()
        {
            var autoMapperBootstrapper = new AutoMapperBootstrapper();
            autoMapperBootstrapper.Bootstrap();
            Mapper.AssertConfigurationIsValid();
        }
        
    }
}

