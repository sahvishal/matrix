using System.Collections.Generic;
using Falcon.App.Core.Marketing.Domain;
using NUnit.Framework;

namespace Falcon.UnitTests.Core.Domain.Marketing
{
    [TestFixture]
    public class PhoneNumberResolverTester
    {
        private List<PhoneNumberResolutionRule> _listOfRules;
        
        [SetUp]
        public void CreateResolverRules()
        {
            _listOfRules = new List<PhoneNumberResolutionRule>();                                      
        }

        //TODO: Write Tests
        [Test]
        public void GetPhoneNumberAlwaysReturnsANumber()
        {
            

        }
        
    }
}