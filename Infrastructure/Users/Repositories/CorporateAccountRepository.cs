using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Users.Repositories
{
    public class CorporateAccountRepository : UniqueItemRepository<CorporateAccount, AccountEntity>, ICorporateAccountRepository
    {
        public CorporateAccountRepository(IMapper<CorporateAccount, AccountEntity> mapper)
            : base(mapper)
        {
        }

        public CorporateAccountRepository(IPersistenceLayer persistenceLayer, IMapper<CorporateAccount, AccountEntity> mapper, RepositoryStrategySet<CorporateAccount> strategySet)
            : base(persistenceLayer, mapper, strategySet)
        {
        }

        protected override EntityField2 EntityIdField
        {
            get { return AccountFields.AccountId; }
        }

        public new IEnumerable<CorporateAccount> GetByIds(IEnumerable<long> ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = linqMetaData.Account.Where(a => ids.Contains(a.AccountId)).WithPath(
                    path => path.Prefetch(a => a.Organization)).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }

        public new CorporateAccount Save(CorporateAccount domainObject)
        {
            using (var transactionScope = new TransactionScope())
            {
                if (domainObject == null)
                {
                    throw new ArgumentNullException("domainObject",
                        "The given object to persist cannot be null.");
                }

                AccountEntity entity = Mapper.Map(domainObject);

                try
                {
                    GetById(domainObject.Id);
                }
                catch (ObjectNotFoundInPersistenceException<CorporateAccount>)
                {
                    entity.IsNew = true;
                }

                using (var adapter = PersistenceLayer.GetDataAccessAdapter())
                {
                    if (!adapter.SaveEntity(entity, true))
                    {
                        throw new PersistenceFailureException();
                    }
                }

                var newDomainObject = Mapper.Map(entity);

                transactionScope.Complete();
                return newDomainObject;
            }
        }

        public CorporateAccount SaveAccount(CorporateAccount corporateAccount, IEnumerable<long> shippingOptionIds, IEnumerable<long> accountCustomerResultTestDependency, IEnumerable<long> accountPcpResultTestDependency,
            IEnumerable<long> healthPlanResultTestDependency)
        {
            var corporateaccount = Save(corporateAccount);
            SaveShippingOption(corporateaccount.Id, shippingOptionIds);
            SaveCustomerResultTestDependency(corporateAccount.Id, accountCustomerResultTestDependency);
            SavePcpResultTestDependency(corporateAccount.Id, accountPcpResultTestDependency);
            SaveHealthPlanResultTestDependency(corporateAccount.Id, healthPlanResultTestDependency);
            // SaveAccountAddtionalFieldDependency(corporateaccount.Id, corporateAccount.AccountAdditionalFields);
            return corporateaccount;
        }

        private void SaveCustomerResultTestDependency(long accountId, IEnumerable<long> customeResultTestDependency)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                //Delete all Dependency First
                adapter.DeleteEntitiesDirectly(typeof(AccountCustomerResultTestDependencyEntity),
                                               new RelationPredicateBucket(AccountCustomerResultTestDependencyFields.AccountId == accountId));
                if (customeResultTestDependency.IsNullOrEmpty()) return;

                var entities = new EntityCollection<AccountCustomerResultTestDependencyEntity>();

                //Insert new Test dependecy 
                foreach (long testId in customeResultTestDependency)
                {
                    entities.Add(new AccountCustomerResultTestDependencyEntity(accountId, testId));
                }

                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }

        private void SavePcpResultTestDependency(long accountId, IEnumerable<long> pcpResultTestDependency)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                //Delete all Dependency First
                adapter.DeleteEntitiesDirectly(typeof(AccountPcpResultTestDependencyEntity),
                                               new RelationPredicateBucket(AccountPcpResultTestDependencyFields.AccountId == accountId));
                if (pcpResultTestDependency.IsNullOrEmpty()) return;

                var entities = new EntityCollection<AccountPcpResultTestDependencyEntity>();

                //Insert new Test dependecy 
                foreach (long testId in pcpResultTestDependency)
                {
                    entities.Add(new AccountPcpResultTestDependencyEntity(accountId, testId));
                }

                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }

        public void SaveAccountAddtionalFieldDependency(long accountId, IEnumerable<AccountAdditionalFields> accountAdditionalFields)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                //Delete all additional field of this account
                adapter.DeleteEntitiesDirectly(typeof(AccountAdditionalFieldsEntity), new RelationPredicateBucket(AccountAdditionalFieldsFields.AccountId == accountId));

                if (accountAdditionalFields.IsNullOrEmpty()) return;

                var entities = new EntityCollection<AccountAdditionalFieldsEntity>();

                //Insert new Test dependecy 
                foreach (var additionFilds in accountAdditionalFields)
                {
                    additionFilds.AccountId = accountId;
                    var entity = AutoMapper.Mapper.Map<AccountAdditionalFields, AccountAdditionalFieldsEntity>(additionFilds);

                    entities.Add(entity);
                }

                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }

        private void SaveHealthPlanResultTestDependency(long accountId, IEnumerable<long> healthPlanResultTestDependency)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                //Delete all Dependency First
                adapter.DeleteEntitiesDirectly(typeof(AccountHealthPlanResultTestDependencyEntity),
                                               new RelationPredicateBucket(AccountHealthPlanResultTestDependencyFields.AccountId == accountId));
                if (healthPlanResultTestDependency.IsNullOrEmpty()) return;

                var entities = new EntityCollection<AccountHealthPlanResultTestDependencyEntity>();

                //Insert new Test dependecy 
                foreach (long testId in healthPlanResultTestDependency)
                {
                    entities.Add(new AccountHealthPlanResultTestDependencyEntity(accountId, testId));
                }

                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }

        public IEnumerable<CorporateAccount> GetbyFilter(int pageNumber, int pageSize, CorporateAccountListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = from a in linqMetaData.Account
                            join o in linqMetaData.Organization on a.AccountId equals o.OrganizationId
                            where o.IsActive
                            select new { a, o };

                if (filter == null)
                {
                    var accounts = from q in query
                                   orderby q.o.Name
                                   select q.a;
                    totalRecords = accounts.Count();

                    return Mapper.MapMultiple(accounts.TakePage(pageNumber, pageSize).ToArray());
                }

                if (!string.IsNullOrEmpty(filter.Name))
                    query = query.Where(q => q.o.Name.Contains(filter.Name));

                if (filter.ShowHealthPlanOnly)
                    query = query.Where(q => q.a.IsHealthPlan);

                if (filter.ShowCorporateAccountOnly)
                    query = query.Where(q => q.a.IsHealthPlan == false);

                var accountQuery = from q in query
                                   orderby q.o.Name
                                   select q.a;

                totalRecords = accountQuery.Count();
                return Mapper.MapMultiple(accountQuery.TakePage(pageNumber, pageSize).ToArray());
            }
        }

        public CorporateAccount GetByUrlSiffix(string urlSuffix)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = linqMetaData.Account.Where(ac => ac.CorpCode == urlSuffix).SingleOrDefault();
                if (entity == null)
                    return null;
                return Mapper.Map(entity);
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetAccountPackagesNameIdPair(long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from a in linqMetaData.AccountPackage
                        join p in linqMetaData.Package on a.PackageId equals p.PackageId
                        where a.AccountId == accountId
                        select new OrderedPair<long, string>(p.PackageId, p.PackageName)).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetAccountIdPackagesNamePair(long[] accountIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from a in linqMetaData.AccountPackage
                        join p in linqMetaData.Package on a.PackageId equals p.PackageId
                        where accountIds.Contains(a.AccountId)
                        select new OrderedPair<long, string>(a.AccountId, p.PackageName)).ToArray();
            }
        }

        public bool UpdateConvertedHost(long accountId, long? hostId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new AccountEntity(accountId)
                                 {
                                     ConvertedHostId = hostId
                                 };
                var bucket = new RelationPredicateBucket(AccountFields.AccountId == accountId);
                return adapter.UpdateEntitiesDirectly(entity, bucket) > 0 ? true : false;
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetEventIdCorporateAccountNamePair(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ea in linqMetaData.EventAccount
                        join o in linqMetaData.Organization on ea.AccountId equals o.OrganizationId
                        where eventIds.Contains(ea.EventId)
                        select new OrderedPair<long, string>(ea.EventId, o.Name)
                       ).ToArray();
            }
        }

        public IEnumerable<CorporateAccount> GetAll()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from a in linqMetaData.Account select a).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }

        public bool AccountCodeExists(long excludedAccountId, string accountCode)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return linqMetaData.Account.Any(a => a.CorpCode == accountCode && a.AccountId != excludedAccountId);
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetEventIdCorporateAccountPairForSponsoredBy(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ea in linqMetaData.EventAccount
                        join a in linqMetaData.Account on ea.AccountId equals a.AccountId
                        where eventIds.Contains(ea.EventId) && a.ShowSponsoredByUrl
                        select new OrderedPair<long, long>(ea.EventId, ea.AccountId)).ToArray();
            }
        }

        public CorporateAccount GetbyEventId(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var accountId = (from ea in linqMetaData.EventAccount where ea.EventId == eventId select ea.AccountId).SingleOrDefault();

                if (accountId > 0)
                    return GetById(accountId);

                return null;
            }
        }

        private void SaveShippingOption(long accountId, IEnumerable<long> shippingOptionIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly(typeof(CorporateShippingOptionEntity),
                                               new RelationPredicateBucket(CorporateShippingOptionFields.AccountId == accountId));
                if (shippingOptionIds.IsNullOrEmpty()) return;

                var entities = new EntityCollection<CorporateShippingOptionEntity>();
                foreach (long shippingOptionId in shippingOptionIds)
                {
                    entities.Add(new CorporateShippingOptionEntity(accountId, shippingOptionId));
                }

                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }

        public IEnumerable<long> GetAccountShippingOptionIds(long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from a in linqMetaData.CorporateShippingOption
                        where a.AccountId == accountId
                        select a.ShippingOptionId).ToArray();
            }
        }

        public CorporateAccount GetForEventIdWithOrganizationDetail(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var accountId = (from ea in linqMetaData.EventAccount where ea.EventId == eventId select ea.AccountId).SingleOrDefault();

                if (accountId > 0)
                {
                    var entity = linqMetaData.Account.Where(a => a.AccountId == accountId).WithPath(path => path.Prefetch(a => a.Organization)).Single();

                    return Mapper.Map(entity);
                }

                return null;
            }
        }

        public bool CustomerTagExists(long excludedAccountId, string customerTag)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return linqMetaData.Account.Any(a => a.Tag == customerTag && a.AccountId != excludedAccountId);
            }
        }

        public CorporateAccount GetByTag(string tag)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from a in linqMetaData.Account where a.Tag == tag select a).SingleOrDefault();
                if (entity == null)
                    return null;
                return Mapper.Map(entity);
            }
        }

        public IEnumerable<long> GetAccountCustomerResultTestDependency(long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var testDependencies =
                    (from a in linqMetaData.AccountCustomerResultTestDependency
                     where a.AccountId == accountId
                     select a.TestId).ToList();

                return testDependencies;
            }
        }

        public IEnumerable<long> GetAccountPcpResultTestDependency(long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var testDependencies =
                    (from a in linqMetaData.AccountPcpResultTestDependency
                     where a.AccountId == accountId
                     select a.TestId).ToList();

                return testDependencies;
            }
        }

        public bool CheckCanChangeClinicalTemplate(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var futureEventIds = from e in linqMetaData.Events
                                     join ea in linqMetaData.EventAccount
                                     on e.EventId equals ea.EventId
                                     where e.EventDate >= DateTime.Today && ea.AccountId == id
                                     select e.EventId;
                var eventCustomers = from c in linqMetaData.EventCustomers
                                     where futureEventIds.Contains(c.EventId)
                                     select c;

                var answersCount = (from e in linqMetaData.CustomerClinicalQuestionAnswer
                                    join ea in eventCustomers
                                    on new { e.EventId, e.CustomerId } equals new { ea.EventId, ea.CustomerId }
                                    select 1).Count();

                return answersCount == 0;
            }
        }

        public IEnumerable<CorporateAccount> GetByTags(string[] tags)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from a in linqMetaData.Account where tags.Contains(a.Tag) select a).WithPath(
                    path => path.Prefetch(a => a.Organization));

                return Mapper.MapMultiple(entity);
            }
        }

        public IEnumerable<CorporateAccount> GetCorporateAccountForLockEvent()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from a in linqMetaData.Account where a.LockEvent select a).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<long> GetAccountHealthPlanResultTestDependency(long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var testDependencies =
                    (from a in linqMetaData.AccountHealthPlanResultTestDependency
                     where a.AccountId == accountId
                     select a.TestId).ToArray();

                return testDependencies;
            }
        }

        public IEnumerable<CorporateAccount> GetAllHealthPlan()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = linqMetaData.Account.Where(a => a.IsHealthPlan).WithPath(
                    path => path.Prefetch(a => a.Organization)).Where(x=>x.Organization.IsActive).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<CorporateAccount> GetHealthPlanbyFilter(int pageNumber, int pageSize, HealthPlanRevenueListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = linqMetaData.Account.Where(a => a.IsHealthPlan);

                if (filter.HealthPlanId > 0)
                {
                    entities = linqMetaData.Account.Where(a => a.IsHealthPlan && a.AccountId == filter.HealthPlanId);
                }

                totalRecords = entities.Count();

                var finalEntities = entities.TakePage(pageNumber, pageSize).WithPath(path => path.Prefetch(a => a.Organization)).OrderBy(a => a.Organization.Name).ToArray();

                return Mapper.MapMultiple(finalEntities);
            }
        }

        public IEnumerable<CorporateAccount> GetAllOnlyCorporateAccount()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = linqMetaData.Account.Where(a => !a.IsHealthPlan).WithPath(path => path.Prefetch(a => a.Organization)).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }
        public bool IsCorporateAccount(long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var accountid = (from a in linqMetaData.Account
                                 where a.AccountId == accountId && !a.IsHealthPlan
                                 select a.AccountId
                                   ).FirstOrDefault();
                return (accountid > 0 ? true : false);

            }
        }

        public IEnumerable<CorporateAccount> GetAllHealthPlansForPrintAceAndMip()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = linqMetaData.Account.Where(a => a.IsHealthPlan && (a.PrintAceForm || a.PrintMipForm)).WithPath(path => path.Prefetch(a => a.Organization)).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<string> GetHealthPlanTags()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var tags = (from a in linqMetaData.Account
                            where a.IsHealthPlan
                            select a.Tag
                                   ).ToArray();
                return tags;
            }
        }

        public IEnumerable<CorporateAccount> GetByChecklistTemplateIds(IEnumerable<long> checklistTemplateIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = linqMetaData.Account.Where(a => a.CheckListTemplateId.HasValue && checklistTemplateIds.Contains(a.CheckListTemplateId.Value)).WithPath(path => path.Prefetch(a => a.Organization)).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<OrderedPair<long, string>> HealthPlanNamesCorrepondingToHealthPlanIds(IEnumerable<long?> healthPlanIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var collection = (from o in linqMetaData.Organization
                                  join a in linqMetaData.Account
                                  on o.OrganizationId equals a.AccountId
                                  where healthPlanIds.Contains(a.AccountId)
                                  select new OrderedPair<long, string>(a.AccountId, o.Name)
                    ).ToArray();
                return collection;
            }
        }

        public long GetHealthPlanIdByAccountName(string accountName)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from a in linqMetaData.Account
                        join o in linqMetaData.Organization on a.AccountId equals o.OrganizationId
                        where o.Name == accountName && a.IsHealthPlan
                        select a.AccountId).First();
            }
        }

        public IEnumerable<CorporateAccount> GetHealthPlanAssingedToAgent(long agentOrganizationId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var accountAssignedIds = (from acco in linqMetaData.AccountCallCenterOrganization
                                          where acco.OrganizationId == agentOrganizationId && acco.IsDeleted == false
                                          select acco.AccountId);

                var entities = (from a in linqMetaData.Account
                                where a.IsHealthPlan && (a.RestrictHealthPlanData == false || accountAssignedIds.Contains(a.AccountId))
                                select a).WithPath(
                     path => path.Prefetch(a => a.Organization)).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetRestrictionIdNamePairs(long[] healthPlanIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from acco in linqMetaData.AccountCallCenterOrganization
                        join o in linqMetaData.Organization on acco.OrganizationId equals o.OrganizationId
                        where healthPlanIds.Contains(acco.AccountId) && acco.IsDeleted == false
                        select new OrderedPair<long, string>(acco.AccountId, o.Name)).ToArray();
            }
        }

        public IEnumerable<CorporateAccount> GetAllCorporateAccountToSendPatientDataToAces()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from a in linqMetaData.Account where a.SendPatientDataToAces select a).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<CorporateAccount> GetAllCorporateAccountToSendConsentData()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from a in linqMetaData.Account where a.IsHealthPlan && a.SendConsentData select a).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<OrderedPair<string, string>> HealthPlanNamesCorrepondingToTag(string[] tags)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var collection = (from o in linqMetaData.Organization
                                  join a in linqMetaData.Account
                                  on o.OrganizationId equals a.AccountId
                                  where tags.Contains(a.Tag)
                                  select new OrderedPair<string, string>(a.Tag, o.Name)
                    ).ToArray();
                return collection;
            }
        }

        public IEnumerable<CorporateAccount> GetCorporateAccountbyClientIds(string[] clientIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ac in linqMetaData.Account
                                where clientIds.Contains(ac.ClientId)
                                select ac).ToArray();
                return Mapper.MapMultiple(entities);
            }

        }

        public bool AcesToHipIntakeShortNameExists(long excludedAccountId, string acesToHipIntakeShortName)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return linqMetaData.Account.Any(a => a.AcesToHipIntakeShortName == acesToHipIntakeShortName && a.AccountId != excludedAccountId);
            }
        }

        public IEnumerable<CorporateAccount> GetAllCorporateAccountAcestoHipInTake()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ac in linqMetaData.Account
                                where ac.AcesToHipIntake == true
                                select ac).ToArray();
                return Mapper.MapMultiple(entities);
            }

        }

        public IEnumerable<CorporateAccount> GetByFluConsentTemplateIds(IEnumerable<long> templateIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = linqMetaData.Account.Where(a => a.FluConsentTemplateId.HasValue && templateIds.Contains(a.FluConsentTemplateId.Value)).WithPath(path => path.Prefetch(a => a.Organization)).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }

        public CorporateAccount GetByTagWithOrganization(string tag)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from a in linqMetaData.Account where a.Tag == tag select a).WithPath(path => path.Prefetch(a => a.Organization)).SingleOrDefault();
                if (entity == null)
                    return null;
                return Mapper.Map(entity);
            }
        }

        public IEnumerable<CorporateAccount> GetBySurveyTemplateIds(IEnumerable<long> surveyTenplateIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = linqMetaData.Account.Where(a => a.SurveyTemplateId.HasValue && surveyTenplateIds
                    .Contains(a.SurveyTemplateId.Value)).WithPath(path => path.Prefetch(a => a.Organization)).ToArray();

                return Mapper.MapMultiple(entities);
            }
        }
    }
}