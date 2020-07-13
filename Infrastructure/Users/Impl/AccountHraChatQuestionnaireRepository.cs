using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Users.Impl
{
    [DefaultImplementation]
    public class AccountHraChatQuestionnaireRepository : PersistenceRepository, IAccountHraChatQuestionnaireRepository
    {
        public IEnumerable<AccountHraChatQuestionnaire> GetByAccountId(long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var enetities = (from aqh in linqMetaData.AccountHraChatQuestionnaire where aqh.AccountId == accountId select aqh).ToArray();
                return Mapper.Map<IEnumerable<AccountHraChatQuestionnaireEntity>, IEnumerable<AccountHraChatQuestionnaire>>(enetities);
            }
        }

        public AccountHraChatQuestionnaire GetCurrentQuestionnaireTypeByAccountId(long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from aqh in linqMetaData.AccountHraChatQuestionnaire
                              where aqh.AccountId == accountId && aqh.EndDate == null
                              orderby aqh.CreatedOn descending
                              select aqh).FirstOrDefault();
                return Mapper.Map<AccountHraChatQuestionnaireEntity, AccountHraChatQuestionnaire>(entity);
            }
        }

        public void Save(long accountId, long questionnaireType, DateTime? startDate, long orgUserId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var accountHraChatQuestionnaireHistoryId = (from aqh in linqMetaData.AccountHraChatQuestionnaire
                                                            where aqh.AccountId == accountId
                                                            orderby aqh.CreatedOn descending
                                                            select aqh.Id).FirstOrDefault();
                if (accountHraChatQuestionnaireHistoryId > 0)
                {
                    var entity = new AccountHraChatQuestionnaireEntity()
                    {
                        EndDate = (questionnaireType == (long)QuestionnaireType.ChatQuestionnaire && startDate.HasValue) ? startDate.Value : DateTime.Today,
                        ModifiedBy = orgUserId,
                        ModifiedOn = DateTime.Now,
                    };
                    adapter.UpdateEntitiesDirectly(entity, new RelationPredicateBucket(AccountHraChatQuestionnaireFields.Id == accountHraChatQuestionnaireHistoryId));
                }
                var entityInsert = new AccountHraChatQuestionnaireEntity()
                {
                    AccountId = accountId,
                    QuestionnaireType = questionnaireType,
                    StartDate = (questionnaireType == (long)QuestionnaireType.ChatQuestionnaire && startDate.HasValue) ? startDate.Value : DateTime.Today,
                    CreatedBy = orgUserId,
                    CreatedOn = DateTime.Now,
                };
                adapter.SaveEntity(entityInsert);
            }
        }

        public void Save(AccountHraChatQuestionnaire domain)
        {
            DeactivateLast(domain.AccountId, domain.StartDate, domain.CreatedBy);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<AccountHraChatQuestionnaire, AccountHraChatQuestionnaireEntity>(domain);

                entity.IsNew = true;

                adapter.SaveEntity(entity);
            }
        }

        public void DeactivateLast(long accountId, DateTime endDate, long orgUserId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var accountHraChatQuestionnaireHistoryId = (from aqh in linqMetaData.AccountHraChatQuestionnaire
                                                            where aqh.AccountId == accountId && aqh.EndDate == null
                                                            orderby aqh.CreatedOn descending
                                                            select aqh.Id).FirstOrDefault();
                if (accountHraChatQuestionnaireHistoryId > 0)
                {
                    var entity = new AccountHraChatQuestionnaireEntity()
                    {
                        EndDate = endDate,
                        ModifiedBy = orgUserId,
                        ModifiedOn = DateTime.Now,
                    };
                    adapter.UpdateEntitiesDirectly(entity, new RelationPredicateBucket(AccountHraChatQuestionnaireFields.Id == accountHraChatQuestionnaireHistoryId));
                }
            }
        }
    }
}
