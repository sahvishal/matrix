using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Interfaces;

namespace Falcon.App.Core.Marketing.Impl
{
    public class SourceCodeGenerator
        : ISourceCodeGenerator
    {
        public const int DEFAULT_SOURCE_CODE_LENGTH = 7;

        private readonly IRandomStringGenerator _randomStringGenerator;        
        private readonly string _prefix;
        private readonly int _length;

        public SourceCodeGenerator()
            : this("")
        { }

        public SourceCodeGenerator(string prefix)
            : this(prefix, DEFAULT_SOURCE_CODE_LENGTH)
        { }

        public SourceCodeGenerator(string prefix, int length)
            : this(prefix, length, new RandomStringGenerator())
        { }

        public SourceCodeGenerator(string prefix, int length, IRandomStringGenerator randomStringGenerator)
        {            
            _prefix = prefix;
            _length = length;
            _randomStringGenerator = randomStringGenerator;
        }                        

        public string GenerateSourceCode()
        {
            return _prefix + _randomStringGenerator.GetRandomString(_length);
        }

        public bool ValidateSourceCode(string sourceCode)
        {
            return false;
        }
    }
}