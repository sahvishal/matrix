using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Mappers.Screening;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Repositories.Screening
{
    [DefaultImplementation(Interface = typeof(IUnableToScreenStatusRepository))]
    public class UnableToScreenStatusRepository : PersistenceRepository, IUnableToScreenStatusRepository
    {
        private readonly IMapper<UnableScreenReason, LookupEntity> _mapper;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;

        public UnableToScreenStatusRepository()
            : this(new SqlPersistenceLayer(), new UnableToScreenReasonMapper(), null)
        {
            _mapper = new UnableToScreenReasonMapper();
        }

        public UnableToScreenStatusRepository(IPersistenceLayer persistenceLayer,
            IMapper<UnableScreenReason, LookupEntity> mapper, IOrganizationRoleUserRepository organizationRoleUserRepository)
            : base(persistenceLayer)
        {
            _mapper = mapper;
            _organizationRoleUserRepository = organizationRoleUserRepository;
        }

        public List<UnableScreenReason> GetAllUnableToScreenReasons(long testId)
        {
            List<LookupEntity> unableScreenReasonEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var listTestUnableScreenReason = linqMetaData.TestUnableScreenReason.Where(testUnableScreenReason =>
                    testUnableScreenReason.TestId == testId).ToList();

                var lookUpIds = listTestUnableScreenReason.Select(unableScreenReason => unableScreenReason.UnableScreenReasonId).ToList();

                unableScreenReasonEntities = linqMetaData.Lookup.Where(lookUp => lookUpIds.Contains(lookUp.LookupId)).ToList();
            }
            var unableToScreenReasons =  _mapper.MapMultiple(unableScreenReasonEntities).ToList();

            if (unableToScreenReasons != null && unableToScreenReasons.Count == 1 && unableToScreenReasons[0].Reason == UnableToScreenReason.Other)
                unableToScreenReasons[0].DisplayName = "Unable to Screen";

            return unableToScreenReasons;
        }
        
        public byte GetTestUnableScreenReasonId(int testId, int unableScreenReasonId)
        {
            TestUnableScreenReasonEntity unableScreenReason = null;

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                unableScreenReason = linqMetaData.TestUnableScreenReason.Where(testUnableScreenReason =>
                                        testUnableScreenReason.TestId == testId && testUnableScreenReason.UnableScreenReasonId == unableScreenReasonId)
                                        .FirstOrDefault();
            }
            if (unableScreenReason != null)
                return unableScreenReason.TestUnableScreenReasonId;
            else return 0;
        }

        public IEnumerable<TestUnabletoScreenViewModel> GetUnabletoScreenView(IEnumerable<long> eventCustomerResultIds)
        {
            using(var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from cest in linqMetaData.CustomerEventScreeningTests
                            join ceus in linqMetaData.CustomerEventUnableScreenReason on cest.CustomerEventScreeningTestId equals ceus.CustomerEventScreeningTestId
                            join cets in linqMetaData.CustomerEventTestState on cest.CustomerEventScreeningTestId equals cets.CustomerEventScreeningTestId
                        where eventCustomerResultIds.Contains(cest.EventCustomerResultId)
                        select new { cest.EventCustomerResultId, cest.TestId, cets.TechnicianNotes, cets.ConductedByOrgRoleUserId, ceus.TestUnableScreenReasonId }).ToArray();

                var orgRoleUserIds = entities.Where(e => e.ConductedByOrgRoleUserId.HasValue).Select(e => e.ConductedByOrgRoleUserId.Value).ToArray();

                var userNameIdpairs = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds);
                var unableToScreenReasons = (from tus in linqMetaData.TestUnableScreenReason
                                                join l in linqMetaData.Lookup on tus.UnableScreenReasonId equals l.LookupId
                                             select new {tus.TestUnableScreenReasonId, l.DisplayName}).ToArray();

                return entities.Select(e => new TestUnabletoScreenViewModel
                                                {
                                                    EventCustomerResultId = e.EventCustomerResultId,
                                                    TechnicianNotes = e.TechnicianNotes,
                                                    TestId = e.TestId,
                                                    ConductedBy = e.ConductedByOrgRoleUserId.HasValue ? userNameIdpairs.Where(p => p.FirstValue == e.ConductedByOrgRoleUserId.Value).Select(p => p.SecondValue).Single() : "",
                                                    Reason = e.TestUnableScreenReasonId.HasValue ? unableToScreenReasons.Where(usr => usr.TestUnableScreenReasonId == e.TestUnableScreenReasonId).Select(usr => usr.DisplayName).Single() : ""
                                                });
            }
        }

    }
}
