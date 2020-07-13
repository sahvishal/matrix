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
    public class AccountHraChatQuestionnaireHistoryRepository : PersistenceRepository, IAccountHraChatQuestionnaireHistoryRepository
    {
        public IEnumerable<AccountHraChatQuestionnaireHistory> GetByAccountId(long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var enetities = (from aqh in linqMetaData.AccountHraChatQuestionnaireHistory where aqh.AccountId == accountId select aqh).ToArray();
                return Mapper.Map<IEnumerable<AccountHraChatQuestionnaireHistoryEntity>, IEnumerable<AccountHraChatQuestionnaireHistory>>(enetities);
            }
        }

        public AccountHraChatQuestionnaireHistory GetCurrentQuestionnaireTypeByAccountId(long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from aqh in linqMetaData.AccountHraChatQuestionnaireHistory
                              where aqh.AccountId == accountId && aqh.EndDate == null
                              orderby aqh.CreatedOn descending
                              select aqh).FirstOrDefault();
                return Mapper.Map<AccountHraChatQuestionnaireHistoryEntity, AccountHraChatQuestionnaireHistory>(entity);
            }
        }

        public void Save(long accountId, long questionnaireType, DateTime? startDate, long orgUserId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var accountHraChatQuestionnaireHistoryId = (from aqh in linqMetaData.AccountHraChatQuestionnaireHistory
                                                            where aqh.AccountId == accountId
                                                            orderby aqh.CreatedOn descending
                                                            select aqh.Id).FirstOrDefault();
                if (accountHraChatQuestionnaireHistoryId > 0)
                {
                    var entity = new AccountHraChatQuestionnaireHistoryEntity()
                    {
                        EndDate = (questionnaireType == (long)QuestionnaireType.ChatQuestionnaire && startDate.HasValue) ? startDate.Value : DateTime.Today,
                        ModifiedBy = orgUserId,
                        ModifiedOn = DateTime.Now,
                    };
                    adapter.UpdateEntitiesDirectly(entity, new RelationPredicateBucket(AccountHraChatQuestionnaireHistoryFields.Id == accountHraChatQuestionnaireHistoryId));
                }
                var entityInsert = new AccountHraChatQuestionnaireHistoryEntity()
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
        public void UpdateIfnotHealthPlan(long accountId, long orgUserId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var accountHraChatQuestionnaireHistoryId = (from aqh in linqMetaData.AccountHraChatQuestionnaireHistory
                                                            where aqh.AccountId == accountId && aqh.EndDate == null
                                                            orderby aqh.CreatedOn descending
                                                            select aqh.Id).FirstOrDefault();
                if (accountHraChatQuestionnaireHistoryId > 0)
                {
                    var entity = new AccountHraChatQuestionnaireHistoryEntity()
                    {
                        EndDate = DateTime.Today,
                        ModifiedBy = orgUserId,
                        ModifiedOn = DateTime.Now,
                    };
                    adapter.UpdateEntitiesDirectly(entity, new RelationPredicateBucket(AccountHraChatQuestionnaireHistoryFields.Id == accountHraChatQuestionnaireHistoryId));
                }

            }
        }
    }
}
