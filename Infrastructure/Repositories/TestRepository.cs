using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Repositories
{
    public class TestRepository : UniqueItemRepository<Test, TestEntity>, ITestRepository
    {
        public TestRepository()
            : this(new TestMapper())
        { }

        public TestRepository(IMapper<Test, TestEntity> mapper)
            : base(mapper)
        { }


        protected override EntityField2 EntityIdField
        {
            get { return TestFields.TestId; }
        }

        public List<Test> GetAll()
        {
            var testEntities = new EntityCollection<TestEntity>();
            IRelationPredicateBucket bucket = new RelationPredicateBucket(TestFields.IsActive == true);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchEntityCollection(testEntities, bucket);
            }
            return Mapper.MapMultiple(testEntities).ToList();
        }

        public List<OrderedPair<long, long>> GetTestDependencyData()
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var dependencyData = (from dtr in linqMetaData.TestDependencyRule
                                      select new OrderedPair<long, long>(dtr.DependantTestId, dtr.TestId)).ToList();
                return dependencyData;
            }
        }

        public string GetTestNamesByPackageId(long packageId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var testNames = (from pt in linqMetaData.PackageTest
                                 join t in linqMetaData.Test on pt.TestId equals t.TestId
                                 where pt.PackageId == packageId
                                 select t.Name).ToArray();

                return string.Join(",", testNames);
            }
        }

        public List<Test> GetPermittedTestsForaPhysician(long orgRoleUserId)
        {
            var testEntities = new EntityCollection<TestEntity>();
            IRelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.Relations.Add(TestEntity.Relations.PhysicianPermittedTestEntityUsingTestId);
            bucket.PredicateExpression.Add(PhysicianPermittedTestFields.OrganizationRoleUserId == orgRoleUserId);

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchEntityCollection(testEntities, bucket);
            }
            return Mapper.MapMultiple(testEntities).ToList();
        }

        public List<Test> GetTestsByPackageIds(List<long> packageIds)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var testIds = (from t in linqMetaData.Test
                               join p in linqMetaData.PackageTest on t.TestId equals p.TestId
                               where packageIds.Contains(p.PackageId)
                               select t.TestId).Distinct().ToList();

                var tests = linqMetaData.Test.Where(t => testIds.Contains(t.TestId)).ToList();

                return Mapper.MapMultiple(tests).ToList();
            }
        }

        public IEnumerable<Test> GetReviewableTests()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from t in linqMetaData.Test
                                where t.IsActive && t.IsTestReviewableByPhysician
                                select t);
                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<Test> GetAllTest(int pageNumber, int pageSize, TestListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = new List<TestEntity>();

                if (filter == null)
                {
                    var queryable = (from t in linqMetaData.Test
                                     orderby t.Name
                                     select t);

                    totalRecords = queryable.Count();
                    entities = queryable.TakePage(pageNumber, pageSize).ToList();
                }
                else
                {
                    var queryable = (from t in linqMetaData.Test
                                     select t);

                    if (!string.IsNullOrEmpty(filter.Name))
                        queryable = queryable.Where(q => q.Name.Contains(filter.Name));

                    queryable = queryable.OrderBy(q => q.Name);

                    totalRecords = queryable.Count();
                    entities = queryable.TakePage(pageNumber, pageSize).ToList();
                }
                return Mapper.MapMultiple(entities).ToList();

            }
        }

        public Test SaveTest(Test test)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map(test);
                entity.IsNew = !adapter.FetchEntity(new TestEntity(test.Id));

                if (!adapter.SaveEntity(entity))
                    throw new PersistenceFailureException();

                SaveTestAvailabilityToRoles(test.Id, test.AvailableToRoleIds);

                return test;
            }
        }

        public void SaveTestAvailabilityToRoles(long testId, IEnumerable<long> roleIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket =
                   new RelationPredicateBucket(TestAvailabilityToRolesFields.TestId == testId);

                adapter.DeleteEntitiesDirectly("TestAvailabilityToRolesEntity", bucket);

                var entities = new EntityCollection<TestAvailabilityToRolesEntity>();
                foreach (var roleId in roleIds)
                {
                    entities.Add(new TestAvailabilityToRolesEntity { TestId = testId, RoleId = roleId });
                }

                if (adapter.SaveEntityCollection(entities) == 0)
                {
                    throw new PersistenceFailureException();
                }
            }
        }

        public Test GetTest(long testId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from t in linqMetaData.Test where t.TestId == testId select t).SingleOrDefault();
                var test = Mapper.Map(entity);
                test.AvailableToRoleIds = GetRoleIdsAvailableForTest(testId);
                return test;
            }
        }

        public IEnumerable<long> GetRoleIdsAvailableForTest(long testId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return
                    (from tar in linqMetaData.TestAvailabilityToRoles where tar.TestId == testId select tar.RoleId).
                        ToList();
            }
        }

        public IEnumerable<Test> GetRecordableTests()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from t in linqMetaData.Test
                                where t.IsActive && t.IsRecordable
                                select t);
                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetTestNameValuePair(List<long> testIds)
        {
            if (!testIds.Any())
                return null;
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from t in linqMetaData.Test
                                where testIds.Contains(t.TestId)
                                select new { t.TestId, t.Name });
                var tests = entities.ToList();
                var result = new List<OrderedPair<long, string>>();
                tests.ForEach(
                    x => result.Add(new OrderedPair<long, string>() { FirstValue = x.TestId, SecondValue = x.Name }));
                return result;
            }
        }

        public List<OrderedPair<long, string>> GetTestIdListByAliasList(IEnumerable<string> list)
        {
            if (!list.Any())
                return null;
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from t in linqMetaData.Test
                    where list.Contains(t.Alias)
                    select new {t.TestId, t.Alias});
                var testIds = entities.ToList().Select(x => new OrderedPair<long, string>(x.TestId,x.Alias)).ToList();

                return testIds;
            }
        }

        public IEnumerable<Test> GetTestsByHealthPlanId(long healthPlanId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from t in linqMetaData.Test
                                join at in linqMetaData.AccountTest on t.TestId equals at.TestId
                                where t.IsActive && at.AccountId == healthPlanId
                                select t);
                return Mapper.MapMultiple(entities);
            }
        }

        public IEnumerable<Test> GetTestByIds(IEnumerable<long> testIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from t in linqMetaData.Test where testIds.Contains(t.TestId) select t).ToArray();
                var tests = Mapper.MapMultiple(entity);
                return tests;
            }
        }

        public List<string> GetAliasListByTestIdList(IEnumerable<long> testIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from t in linqMetaData.Test
                                where testIds.Contains(t.TestId) && t.IsActive
                                select  t.Alias );
                var aliases = entities.ToList();

                return aliases;
            }
        }

        public IEnumerable<Test> GetTestByPreQualificationQuestionTemplateIds(IEnumerable<long> templateIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from t in linqMetaData.Test where templateIds.Contains(t.PreQualificationQuestionTemplateId.Value) select t).ToArray();
                var tests = Mapper.MapMultiple(entity);
                return tests;
            }
        }

        public IEnumerable<Test> GetDependentTests(long testId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from t in linqMetaData.Test where t.TestId != testId && t.IsActive select t).ToArray();
                var tests = Mapper.MapMultiple(entities);
                return tests;
            }
        }
       
    }
}