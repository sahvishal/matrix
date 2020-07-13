using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using AutoMapper;

namespace Falcon.App.Infrastructure.Communication.Repositories
{
    [DefaultImplementation]
    public class EmailTemplateMacroRepository : PersistenceRepository, IEmailTemplateMacroRepository
    {
        public void SaveEmailTemplateMacros(IEnumerable<EmailTemplateMacro> emailTemplateMacroses)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                foreach (var macrose in emailTemplateMacroses)
                {
                    var entity = Mapper.Map<EmailTemplateMacro, EmailTemplateMacroEntity>(macrose);
                    if (!adapter.SaveEntity(entity, true))
                    {
                        throw new PersistenceFailureException();
                    }

                }
            }
        }
    }
}