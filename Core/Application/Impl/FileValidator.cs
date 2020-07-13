using Falcon.App.Core.Application.Domain;
using FluentValidation;

namespace Falcon.App.Core.Application.Impl
{
    public class FileValidator : AbstractValidator<File>
    {
        public FileValidator()
        {
            //RuleFor(x => x.Path).NotNull().WithMessage("(required)").Length(2, 256);
        }
    }


    public class FileValidator_ForRequired : AbstractValidator<File>
    {
        public FileValidator_ForRequired()
        {
            RuleFor(x => x.Path).NotNull().WithMessage("(required)").Length(2, 256);
        }
    }
}