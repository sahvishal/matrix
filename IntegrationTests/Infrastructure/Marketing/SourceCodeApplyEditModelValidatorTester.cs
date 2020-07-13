using Falcon.App.Core.Marketing.Impl;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.DependencyResolution;
using FluentValidation;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Marketing
{
    [TestFixture]
    public class SourceCodeApplyEditModelValidatorTester
    {
        private IValidator<SourceCodeApplyEditModel> _validator;
        [SetUp]
        public void SetUp()
        {
            DependencyRegistrar.RegisterDependencies();
            _validator = IoC.Resolve<IValidator<SourceCodeApplyEditModel>>();
        }

        [Test]
        public void Validate_Test()
        {
            var result = _validator.Validate(new SourceCodeApplyEditModel(){ SourceCode = "Sand_01" });
        }
    }
}