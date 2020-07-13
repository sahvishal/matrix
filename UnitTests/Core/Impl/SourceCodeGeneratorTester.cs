using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Impl;
using Falcon.App.Core.Marketing.Interfaces;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Impl
{
    [TestFixture]
    public class SourceCodeGeneratorTester
    {
        [Test]
        public void GeneratedSourceCodeBeginsWithPrefix()
        {
            const string prefix = "testPrefix";            

            ISourceCodeGenerator sourceCodeGenerator = new SourceCodeGenerator(prefix);
            string sourceCode = sourceCodeGenerator.GenerateSourceCode();

            Assert.That(sourceCode.StartsWith(prefix));            
        }

        [Test]
        public void GeneratedSourceCodeLengthIsLengthOfPrefixPlusSourceCodeLength()
        {
            const string prefix = "testPrefix";
            int length = prefix.Length + SourceCodeGenerator.DEFAULT_SOURCE_CODE_LENGTH;

            ISourceCodeGenerator sourceCodeGenerator = new SourceCodeGenerator(prefix);
            string sourceCode = sourceCodeGenerator.GenerateSourceCode();

            Assert.AreEqual(length, sourceCode.Length);
        }
    }
}