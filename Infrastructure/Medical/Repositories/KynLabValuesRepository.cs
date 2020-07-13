using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class KynLabValuesRepository : PersistenceRepository, IKynLabValuesRepository
    {
        public KynLabValuesRepository()
            : this(new SqlPersistenceLayer())
        { }

        public KynLabValuesRepository(IPersistenceLayer persistenceLayer)
            : base(persistenceLayer)
        { }

        public KynLabValues Get(long eventCustomerResultId, long testId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from klv in linqMetaData.KynLabValues
                              where klv.EventCustomerResultId == eventCustomerResultId
                              && klv.TestId == testId
                              select klv).SingleOrDefault();
                if (entity == null)
                    return null;
                return Mapper.Map<KynLabValuesEntity, KynLabValues>(entity);
            }
        }

        public KynLabValues Save(KynLabValues domain, long orgRoleUserId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from klv in linqMetaData.KynLabValues
                              where klv.EventCustomerResultId == domain.EventCustomerResultId
                              && klv.TestId == domain.TestId
                              select klv).SingleOrDefault();
                var isNew = true;

                if (entity != null)
                {
                    domain.DataRecorderMetaData = new DataRecorderMetaData
                    {
                        DataRecorderCreator = new OrganizationRoleUser(entity.CreatedByOrgRoleUserId),
                        DateCreated = entity.DateCreated,
                        DataRecorderModifier = new OrganizationRoleUser(orgRoleUserId),
                        DateModified = DateTime.Now
                    };
                    isNew = false;
                }
                else
                {
                    domain.DataRecorderMetaData = new DataRecorderMetaData
                    {
                        DataRecorderCreator = new OrganizationRoleUser(orgRoleUserId),
                        DateCreated = DateTime.Now
                    };
                }

                entity = Mapper.Map<KynLabValues, KynLabValuesEntity>(domain);
                entity.IsNew = isNew;

                adapter.SaveEntity(entity, true, false);
                return Mapper.Map<KynLabValuesEntity, KynLabValues>(entity);
            }
        }

        public IEnumerable<MedicareKynResultEditModel> GetRecentKynLabValuesForMedicareSync(DateTime fromDate, string tagAlias)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                // has tag , Is Eligible
                // has appointment , on a corporate Account

                var linqMetaData = new LinqMetaData(adapter);

                var eligibleCustomerIds = (from ce in linqMetaData.CustomerEligibility where ce.IsEligible.HasValue && ce.IsEligible.Value && ce.ForYear==DateTime.Today.Year select ce.CustomerId);

                var query = (from cp in linqMetaData.CustomerProfile
                             join ec in linqMetaData.EventCustomers
                             on cp.CustomerId equals ec.CustomerId
                             //join ea in linqMetaData.EventAccount on ec.EventId equals ea.EventId
                             join ecr in linqMetaData.EventCustomerResult on new { cp.CustomerId, ec.EventId } equals new { ecr.CustomerId, ecr.EventId }
                             join klv in linqMetaData.KynLabValues on ecr.EventCustomerResultId equals klv.EventCustomerResultId
                             where ec.AppointmentId.HasValue && cp.Tag == tagAlias && eligibleCustomerIds.Contains(cp.CustomerId) /*(cp.IsEligble.HasValue && cp.IsEligble.Value)*/
                             && (ecr.DateCreated >= fromDate || ecr.DateModified >= fromDate || klv.DateCreated >= fromDate || klv.DateModified >= fromDate)
                             && (klv.TestId == (long)TestType.Kyn || klv.TestId == (long)TestType.HKYN)
                             && (klv.TotalCholesterol.HasValue || klv.Triglycerides.HasValue || klv.Hdl.HasValue)
                             select new MedicareKynResultEditModel { CustomerId = ecr.CustomerId, 
                                 EventId = ecr.EventId, 
                                 ResultState = ecr.ResultState, 
                                 KynTotalCholestrol = klv.TotalCholesterol,
                                                                     TryGlycerides = klv.Triglycerides,
                                                                     Hdl=klv.Hdl
                             }).Distinct().ToArray();

                return query;
            }
        }
    }
}
