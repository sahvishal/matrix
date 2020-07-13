using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Medical;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class PhysicianMasterRepository : PersistenceRepository, IPhysicianMasterRepository
    {
        private readonly IZipCodeRepository _zipcodeRepository;
        public PhysicianMasterRepository()
            : this(new ZipCodeRepository())
        { }

        public PhysicianMasterRepository(IZipCodeRepository zipcodeRepository)
        {
            _zipcodeRepository = zipcodeRepository;
        }

        public PhysicianMaster Save(PhysicianMaster domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<PhysicianMaster, PhysicianMasterEntity>(domain);
                if (adapter.SaveEntity(entity, true))
                    return Mapper.Map<PhysicianMasterEntity, PhysicianMaster>(entity);
                throw new PersistenceFailureException();
            }
        }

        public PhysicianMaster GetByNpi(string npi)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from pm in linqMetaData.PhysicianMaster where pm.Npi == npi select pm).SingleOrDefault();
                if (entity == null)
                    return null;
                return Mapper.Map<PhysicianMasterEntity, PhysicianMaster>(entity);
            }
        }

        public PhysicianMaster GetById(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from pm in linqMetaData.PhysicianMaster where pm.PhysicianMasterId == id select pm).SingleOrDefault();
                if (entity == null)
                    return null;
                return Mapper.Map<PhysicianMasterEntity, PhysicianMaster>(entity);
            }
        }

        public IEnumerable<PhysicianMaster> Search(string firstName, string lastName, string zipcode, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var query = (from pm in linqMetaData.PhysicianMaster where pm.IsActive select pm);

                if (!string.IsNullOrEmpty(zipcode))
                {
                    //query = (from q in query where q.PracticeZip == zipcode select q);

                    var zipInRange = _zipcodeRepository.GetZipCodesInRadius(zipcode, 10);

                    var zipCodesInRange = zipInRange != null ? zipInRange.Select(zcir => zcir.Zip).ToList() : null;

                    if (!(zipCodesInRange == null || zipCodesInRange.IsEmpty()))
                    {
                        var mapping = new FunctionMapping(this.GetType(), "IndexOf", 2, " charindex({0}, {1})");
                        if (linqMetaData.CustomFunctionMappings == null) linqMetaData.CustomFunctionMappings = new FunctionMappingStore();
                        linqMetaData.CustomFunctionMappings.Add(mapping);
                        mapping = new FunctionMapping(typeof(Convert), "ToString", 1, "',' + Convert(varchar, {0}) + ','");
                        linqMetaData.CustomFunctionMappings.Add(mapping);

                        string zipIdstring = "," + string.Join(",", zipCodesInRange) + ",";
                        query = from pm in linqMetaData.PhysicianMaster
                                where pm.IsActive && IndexOf(Convert.ToString(pm.PracticeZip), zipIdstring) > 0
                                select pm;

                    }
                }


                if (!string.IsNullOrEmpty(firstName))
                    query = (from q in query where q.FirstName.Contains(firstName) select q);

                if (!string.IsNullOrEmpty(lastName))
                    query = (from q in query where q.LastName.Contains(lastName) select q);

                query = (from q in query orderby q.FirstName, q.LastName, q.PhysicianMasterId select q);

                totalRecords = query.Count();
                var entities = query.TakePage(pageNumber, pageSize).ToList();
                return Mapper.Map<IEnumerable<PhysicianMasterEntity>, IEnumerable<PhysicianMaster>>(entities);
            }
        }

        private static int IndexOf(string searchText, string searchFrom)
        {
            return searchFrom.IndexOf(searchText);
        }
    }
}
