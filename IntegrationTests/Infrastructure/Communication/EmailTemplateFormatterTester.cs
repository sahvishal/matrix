using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.DependencyResolution;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Communication
{
    [TestFixture]
    public class EmailTemplateFormatterTester
    {
        private IEmailTemplateFormatter _emailTemplateFormatter;
        [SetUp]
        public void SetUp()
        {
            DependencyRegistrar.RegisterDependencies();
            _emailTemplateFormatter = IoC.Resolve<IEmailTemplateFormatter>();
        }

        [Test]
        public void ReplacesRazorInBothSubjectAndBody()
        {
            
            var emailTemplate = new EmailTemplate
            {
                Subject = "@Model.Subject Hello",
                Body = "@if (Model.IsTrue) { <p>@Model.TrueMessage</p> } else { <p>@Model.FalseMessage</p> }"
            };

            var model = new
            {
                Subject = "Integration Test",
                TrueMessage = "It is true",
                FalseMessage = "A lie was told",
                IsTrue = true
            };

            EmailMessage formatMessage = _emailTemplateFormatter.FormatMessage(emailTemplate, model, "testman@example.com", "fromman@example.com", "From Me", emailTemplate.Id);

            Assert.AreEqual(model.Subject + " Hello", formatMessage.Subject);
            Assert.IsTrue(formatMessage.Body.Contains(model.TrueMessage));
            Assert.IsFalse(formatMessage.Body.Contains(model.FalseMessage));
        }
    }
}