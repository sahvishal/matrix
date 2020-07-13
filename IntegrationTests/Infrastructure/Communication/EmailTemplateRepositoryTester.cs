using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.Data.EntityClasses;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Communication
{
    [TestFixture]
    [Ignore("Still being written")]
    public class EmailTemplateRepositoryTester
    {
        private IEmailTemplateRepository _emailTemplateRepository;

        [SetUp]
        public void SetUp()
        {
            DependencyRegistrar.RegisterDependencies();
            IPersistenceLayer persistenceLayer = IoC.Resolve<IPersistenceLayer>();
            IMapper<EmailTemplate, EmailTemplateEntity> resolve = IoC.Resolve<IMapper<EmailTemplate, EmailTemplateEntity>>();
            _emailTemplateRepository = IoC.Resolve<IEmailTemplateRepository>();
        }

        [Test]
        public void CanSaveNewTemplate()
        {
            EmailTemplate emailTemplate = GetTestEmailTemplate();

            EmailTemplate savedTemplate = _emailTemplateRepository.Save(emailTemplate);

            Assert.AreNotEqual(0, savedTemplate.Id);
        }

        [Test]
        public void CanGetTemplateByAlias()
        {
            EmailTemplate emailTemplate = _emailTemplateRepository.Save(GetTestEmailTemplate());

            EmailTemplate fetchedEmailTemplate = _emailTemplateRepository.GetByAlias(emailTemplate.Alias);

            Assert.AreEqual(emailTemplate.Id, fetchedEmailTemplate.Id);
        }

        [Test]
        [Ignore("This is not essential at the moment but it will probably eventually come up...")]
        public void UpdateDoesNotSaveNew()
        {
            EmailTemplate emailTemplate = _emailTemplateRepository.Save(GetTestEmailTemplate());
            EmailTemplate fetchedEmailTemplate = _emailTemplateRepository.GetByAlias(emailTemplate.Alias);
            EmailTemplate updatedEmailTemplate = _emailTemplateRepository.Save(fetchedEmailTemplate);

            Assert.AreEqual(emailTemplate.Id, fetchedEmailTemplate.Id);
            Assert.AreEqual(emailTemplate.Id, updatedEmailTemplate.Id);
        }

        private EmailTemplate GetTestEmailTemplate()
        {
            return new EmailTemplate
            {
                Alias = Guid.NewGuid().ToString(),
                Body = "created by integration test",
                DataRecorderMetaData = new DataRecorderMetaData(null, DateTime.Now, null),
                Subject = "created by integration test"
            };
        }
    }
}