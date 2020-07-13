using System;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.ValueTypes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Impl
{
    [TestFixture]
    public class EmailFactoryTester
    {
        private readonly IEmailFactory _emailFactory = new EmailFactory();

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateEmailThrowsExceptionWhenGivenNullString()
        {
            _emailFactory.CreateEmail(null);
        }

        [Test]
        public void CreateEmailSetsAddressToValueOfStringBeforeAtSymbol()
        {
            const string address = "theAddress";
            const string emailAddress = address + "@domain.net";

            Email email = _emailFactory.CreateEmail(emailAddress);

            Assert.AreEqual(address, email.Address);
        }

        [Test]
        public void CreateEmailSetsDomainNameToValueOfStringAfterAtSymbol()
        {
            const string domainName = "blah.blh";
            const string emailAddress = "address@" + domainName;

            Email email = _emailFactory.CreateEmail(emailAddress);

            Assert.AreEqual(domainName, email.DomainName);
        }

        [Test]
        public void CreateEmailReturnsEmptyEmailWhenGivenStringDoesNotContainAtSymbol()
        {
            Email email = _emailFactory.CreateEmail("blah");

            Assert.IsEmpty(email.ToString());
        }

        [Test]
        public void CreateEmailReturnsEmptyEmailWhenGivenStringContainsMoreThanOneAtSymbol()
        {
            Email email = _emailFactory.CreateEmail("blah@blah@blah.com");

            Assert.IsEmpty(email.ToString());
        }

    }
}