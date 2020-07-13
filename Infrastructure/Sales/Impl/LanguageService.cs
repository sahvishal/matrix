using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;

namespace Falcon.App.Infrastructure.Sales.Impl
{
    [DefaultImplementation]
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;

        }

        public Language AddLanguage(string name, long orgRoleId)
        {
            var language = new Language
             {
                 Name = name,
                 Alias = name,
                 IsActive = true,
                 CreatedByOrgRoleUserId = orgRoleId,
                 DateCreated = DateTime.Now
             };

            language = _languageRepository.Save(language);
            return language;
        }
    }
}
