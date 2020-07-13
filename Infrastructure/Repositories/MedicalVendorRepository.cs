using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Factories;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.HelperClasses;
using Falcon.Data.EntityClasses;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.Data.Linq;
using Falcon.Data;

namespace Falcon.App.Infrastructure.Repositories
{

    public class MedicalVendorRepository : PersistenceRepository, IMedicalVendorRepository
    {
        private readonly IMedicalVendorFactory _medicalVendorFactory;

        public MedicalVendorRepository()
            : this(new SqlPersistenceLayer(), new MedicalVendorFactory())
        { }

        public MedicalVendorRepository(IPersistenceLayer persistenceLayer, IMedicalVendorFactory medicalVendorFactory)
            : base(persistenceLayer)
        {
            _medicalVendorFactory = medicalVendorFactory;
        }

        public MedicalVendor GetMedicalVendor(long medicalVendorId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var medicalVendorProfileEntity = new MedicalVendorProfileEntity(medicalVendorId);
                IPrefetchPath2 path = new PrefetchPath2(EntityType.MedicalVendorProfileEntity);
                path.Add(MedicalVendorProfileEntity.PrefetchPathOrganization);

                if (!myAdapter.FetchEntity(medicalVendorProfileEntity, path))
                {
                    throw new ObjectNotFoundInPersistenceException<MedicalVendor>(medicalVendorId);
                }
                var medicalVendor = _medicalVendorFactory.CreateMedicalVendor(medicalVendorProfileEntity);
                return medicalVendor;
            }
        }

        // TODO: TEST (integration)
        public List<MedicalVendor> GetMedicalVendors()
        {
            // Removed old implementation, and invoked Org Repository for the time being.
            // This method is not being used anywhere currently, but foreseeing the need, when Organizations may have distinctive properties, 
            // then it becomes needed.
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var medicalVendorProfileEntities = new EntityCollection<MedicalVendorProfileEntity>();
                IPrefetchPath2 path = new PrefetchPath2(EntityType.OrganizationEntity);

                myAdapter.FetchEntityCollection(medicalVendorProfileEntities, null, path);
                if (medicalVendorProfileEntities == null)
                {
                    throw new ObjectNotFoundInPersistenceException<MedicalVendor>();
                }

                var medicalVendors = _medicalVendorFactory.CreateMedicalVendors(medicalVendorProfileEntities);
                return medicalVendors;
            }
        }

        public MedicalVendor Save(MedicalVendor medicalVendor)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var medicalVendorProfileEntity = _medicalVendorFactory.CreateMedicalVendorEntity(medicalVendor);
                try
                {
                    var entity = new MedicalVendorProfileEntity(medicalVendor.Id);
                    if (myAdapter.FetchEntity(entity))
                        medicalVendorProfileEntity.IsNew = false;
                }
                catch (ObjectNotFoundInPersistenceException<MedicalVendor>)
                {
                    medicalVendorProfileEntity.IsNew = true;
                }  
                if (!myAdapter.SaveEntity(medicalVendorProfileEntity, true))
                {
                    throw new PersistenceFailureException();
                }

                medicalVendor.Id = medicalVendorProfileEntity.OrganizationId;
                return medicalVendor;
            }
        }
        
        //Bidhan - Dropped this table.
        //public bool SaveMedicalVendorPermittesTests(TestType[] tests, long medicalVendorId)
        //{
        //    using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
        //    {
        //        var bucket =
        //            new RelationPredicateBucket(MedicalVendorPermittedTestFields.OrganizationId == medicalVendorId);

        //        myAdapter.DeleteEntitiesDirectly("MedicalVendorPermittedTestEntity", bucket);

        //        var entities = new EntityCollection<MedicalVendorPermittedTestEntity>();
        //        foreach (var test in tests)
        //        {
        //            entities.Add(new MedicalVendorPermittedTestEntity(medicalVendorId, (long)test));
        //        }

        //        if (myAdapter.SaveEntityCollection(entities) == 0)
        //        {
        //            throw new PersistenceFailureException();
        //        }
        //        return true;
        //    }
        //}
        
        public List<OrderedPair<long, string>> GetAllContracts()
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                return (from c in linqMetaData.Contract
                                 where c.IsActive
                                 select new OrderedPair<long,string>(c.ContractId,c.ContractName)).ToList();

            }
        }

        public List<MedicalVendor> GetByFilter(int pageNumber, int pageSize, MedicalVendorListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null)
                {
                    totalRecords = linqMetaData.MedicalVendorProfile.Count();
                    return _medicalVendorFactory.CreateMedicalVendors(linqMetaData.MedicalVendorProfile.TakePage(pageNumber, pageSize));
                }

                var query = from mv in linqMetaData.MedicalVendorProfile
                            join o in linqMetaData.Organization on mv.OrganizationId equals o.OrganizationId
                            orderby o.Name
                            select new { mv, o };

                if (!string.IsNullOrEmpty(filter.Name))
                    query = query.Where(q => q.o.Name.Contains(filter.Name));

                totalRecords = query.Count();
                return _medicalVendorFactory.CreateMedicalVendors(query.OrderBy(q => q.o.Name).TakePage(pageNumber, pageSize).Select(q => q.mv).ToArray());
            }
        }
    }
}