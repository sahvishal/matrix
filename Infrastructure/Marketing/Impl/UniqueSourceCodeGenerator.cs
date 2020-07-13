using Falcon.App.Core.Marketing.Interfaces;

namespace Falcon.App.Infrastructure.Marketing.Impl
{
    public class UniqueSourceCodeGenerator
        : ISourceCodeGenerator
    {
        private readonly ISourceCodeRepository _repository;
        private readonly ISourceCodeGenerator _generator;

        public UniqueSourceCodeGenerator(ISourceCodeRepository repository, ISourceCodeGenerator generator)
        {
            _repository = repository;
            _generator = generator;
        }

        public string GenerateSourceCode()
        {
            string sourceCode;
            
            do
            {
                sourceCode = _generator.GenerateSourceCode();
            } while (!_repository.ValidateSourceCode(sourceCode));

            return sourceCode;
        }
    }
}