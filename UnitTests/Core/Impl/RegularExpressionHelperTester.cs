
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Impl
{
    [TestFixture]
    public class RegularExpressionHelperTester
    {
        private const string COMPLETE_STRING = @"I have received the packet with sourcecode P1883A on 04-26-2009 my name is | BB";

        [Test]
        public void GetSourceCodeTester()
        {
            IRegularExpressionParser regularExpressionParser = new RegularExpressionParser();

            string sourceCode = regularExpressionParser.GetSourceCode(COMPLETE_STRING);

            Assert.AreEqual("P1883A", sourceCode);
        }

        [Test]
        public void GetDateTester()
        {
            IRegularExpressionParser regularExpressionParser = new RegularExpressionParser();

            string date = regularExpressionParser.GetDate(COMPLETE_STRING);

            Assert.AreEqual("04-26-2009", date);
        }

        [Test]
        public void GetNameTester()
        {
            IRegularExpressionParser regularExpressionParser = new RegularExpressionParser();

            string name = regularExpressionParser.GetName(COMPLETE_STRING);

            Assert.AreEqual("| BB", name);
        }
    }
}