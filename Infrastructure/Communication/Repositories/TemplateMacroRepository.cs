using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Falcon.App.Infrastructure.Communication.Repositories
{
    [DefaultImplementation]
    public class TemplateMacroRepository : PersistenceRepository, ITemplateMacroRepository
    {
        public IEnumerable<TemplateMacro> GetbyEmailTemplateId(long emailTemplateId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                //var entities =
                //    linqMetaData.TemplateMacro.WithPath(path => path.Prefetch(tm => tm.EmailTemplateMacro)).Where(
                //        tm => tm.EmailTemplateMacro.Any(etm => etm.EmailTemplateId == emailTemplateId)).ToArray();

                var query = from tm in linqMetaData.TemplateMacro
                            join etm in linqMetaData.EmailTemplateMacro on tm.Id equals etm.TemplateMacroId
                            where etm.EmailTemplateId == emailTemplateId
                            select tm;

                var entities = query.WithPath(path => path.Prefetch(tm => tm.EmailTemplateMacro)).ToArray();

                foreach (var templateMacroEntity in entities)
                {
                    var items = templateMacroEntity.EmailTemplateMacro.Where(etm => etm.EmailTemplateId == emailTemplateId).ToArray();

                    templateMacroEntity.EmailTemplateMacro.Clear();
                    templateMacroEntity.EmailTemplateMacro.AddRange(items);
                }

                return AutoMapper.Mapper.Map<IEnumerable<TemplateMacroEntity>, IEnumerable<TemplateMacro>>(entities).OrderBy(t => t.Sequence).ToArray();
            }
        }

        public IEnumerable<TemplateMacro> GetbyEmailTemplateNotificationTypeId(long notificationTypeId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var templateMacroEntity = (from tm in linqMetaData.TemplateMacro
                    join etm in linqMetaData.EmailTemplateMacro on tm.Id equals etm.TemplateMacroId
                    join et in linqMetaData.EmailTemplate on etm.EmailTemplateId equals et.EmailTemplateId
                    where et.NotificationTypeId == notificationTypeId
                    select new TemplateMacro
                        {
                            Id = tm.Id,
                            IdentifierName = tm.IdentifierName,
                            CodeString = tm.CodeString,
                            Sequence = etm.Sequence,
                            ParameterValue = etm.ParameterValue
                        }).ToList();
                

                var templateMacros = new List<TemplateMacro>();

                foreach (var item in templateMacroEntity)
                {
                    if (templateMacros.All(x => x.IdentifierName != item.IdentifierName))
                    {
                        templateMacros.Add(item);
                    }
                }

                return templateMacros;
            }
        }
    }
}