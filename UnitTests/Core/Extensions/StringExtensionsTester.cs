using System;
using System.Text;
using Falcon.App.Core.Extensions;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Extensions
{
    [TestFixture]
    public class StringExtensionsTester
    {
        [Test]
        public void LineCountReturnsZeroForEmptyString()
        {
            Assert.AreEqual(0, string.Empty.LineCount());
        }

        [Test]
        public void LineCountReturnsZeroForNullString()
        {
            Assert.AreEqual(0, ((string)null).LineCount());
        }

        [Test]
        public void LineCountRetunrsOneForStringWithOneLine()
        {
            string stringWithOneLine = "stringWithOneLine";

            int numberOfLines = stringWithOneLine.LineCount();

            Assert.AreEqual(1, numberOfLines);
        }

        [Test]
        public void LineCountReturnsNumberOfLinesInMultiLineString()
        {
            var stringBuilder = new StringBuilder();
            for (int i = 2; i < 10; i++)
			{
			    stringBuilder.Append(Environment.NewLine);
                Assert.AreEqual(i, stringBuilder.ToString().LineCount());
			}
        }

        [Test]
        public void ToUpperCaseTester_forInitialString()
        {
            string allLower = "hello world, we are here!";
            const string normalCaseInitalWord = "Hello world, we are here!";
            const string normalCaseWholeWord = "Hello World, We Are Here!";

            var result = allLower.ToUppercaseInitalLetter(false);
            Assert.AreNotEqual(normalCaseWholeWord, result);
            Assert.AreEqual(normalCaseInitalWord, result);
        }

        [Test]
        public void ToUpperCaseTester_forWholeString()
        {
            string allLower = "hello world, we are here!";
            const string normalCaseWholeWord = "Hello World, We Are Here!";

            var result = allLower.ToUppercaseInitalLetter();
            Assert.AreEqual(normalCaseWholeWord, result);
        }


        [Test]
        public void ToUpperCaseTester_forSingleWordString()
        {
            string allLower = "hello!";
            const string normalCaseInitalWord = "Hello!";

            var result = allLower.ToUppercaseInitalLetter(false);
            Assert.AreEqual(normalCaseInitalWord, result);
        }

    }
}