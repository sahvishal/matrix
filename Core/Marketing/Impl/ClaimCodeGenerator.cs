using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.Core.Marketing.Impl
{
    public class ClaimCodeGenerator : IClaimCodeGenerator
    {
        private const int DEFAULT_CLAIM_CODE_LENGTH = 12;
        private const string DEFAULT_CLAIM_CODE_SEPERATOR = "-";
        private const int DEFAULT_SEPERATOR_INTERVAL = 4;


        private readonly IRandomStringGenerator _randomStringGenerator;
        private readonly int _length;
        private readonly int _interval;
        private readonly string _seperator;

        public ClaimCodeGenerator()
            : this(DEFAULT_CLAIM_CODE_LENGTH, DEFAULT_SEPERATOR_INTERVAL)
        { }

        public ClaimCodeGenerator(int length)
            : this(length, DEFAULT_SEPERATOR_INTERVAL)
        { }

        public ClaimCodeGenerator(int length, int interval)
            : this(length, interval, DEFAULT_CLAIM_CODE_SEPERATOR, new RandomStringGenerator())
        { }

        public ClaimCodeGenerator(int length, int interval, string seperator)
            : this(length, interval, seperator, new RandomStringGenerator())
        { }

        public ClaimCodeGenerator(int length, int interval, string seperator, IRandomStringGenerator randomStringGenerator)
        {
            _length = length;
            _interval = interval;
            _seperator = seperator;
            _randomStringGenerator = randomStringGenerator;
        }

        public string GenerateClaimCode()
        {
            return _randomStringGenerator.GetRandomUpperCaseNumericString(_length).AddSpecialCharacter(_interval,
                                                                                                       _seperator);
        }
    }
}
