using System.Collections.Generic;
using Falcon.App.Core.Communication.Domain;

namespace Falcon.App.Core.Communication
{
    public interface IEmailTemplateMacroRepository
    {
        void SaveEmailTemplateMacros(IEnumerable<EmailTemplateMacro> emailTemplateMacroses);
    }
}