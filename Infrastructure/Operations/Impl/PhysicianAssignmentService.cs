using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Infrastructure.Operations.Impl
{
    public class PhysicianAssignmentService : IPhysicianAssignmentService
    {
        private readonly IPhysicianEventAssignmentRepository _physicianEventAssignmentRepository;
        private readonly IPhysicianCustomerAssignmentRepository _physicianCustomerAssignmentRepository;
        private readonly IPhysicianRepository _physicianRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IEventPhysicianTestRepository _eventPhysicianTestRepository;
        private readonly IEventPhysicianTestFactory _eventPhysicianTestFactory;

        public PhysicianAssignmentService(IPhysicianEventAssignmentRepository physicianEventAssignmentRepository, IPhysicianCustomerAssignmentRepository physicianCustomerAssignmentRepository,
            IPhysicianRepository physicianRepository, IEventCustomerRepository eventCustomerRepository, IEventPhysicianTestRepository eventPhysicianTestRepository, IEventPhysicianTestFactory eventPhysicianTestFactory)
        {
            _physicianEventAssignmentRepository = physicianEventAssignmentRepository;
            _physicianCustomerAssignmentRepository = physicianCustomerAssignmentRepository;
            _physicianRepository = physicianRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _eventPhysicianTestRepository = eventPhysicianTestRepository;
            _eventPhysicianTestFactory = eventPhysicianTestFactory;
        }

        public IEnumerable<AssignedPhysicianBasicInfoModel> GetPhysiciansAssignedToEvent(long eventId)
        {
            var physicianEventAssignment = _physicianEventAssignmentRepository.GetAssignedPhysicians(eventId);
            if (physicianEventAssignment == null)
                return null;

            return GetAssignedPhysicians(physicianEventAssignment.PhysicianId, physicianEventAssignment.OverReadPhysicianId);
        }

        public IEnumerable<AssignedPhysicianBasicInfoModel> GetPhysiciansAssignedToCustomer(long eventCustomerId)
        {
            var physicianCustomerAssignment = _physicianCustomerAssignmentRepository.GetAssignedPhysicians(eventCustomerId);
            if (physicianCustomerAssignment == null)
                return null;

            return GetAssignedPhysicians(physicianCustomerAssignment.PhysicianId, physicianCustomerAssignment.OverReadPhysicianId);
        }

        public IEnumerable<AssignedPhysicianViewModel> GetPhysicianAssignments(long eventId, IEnumerable<long> eventCustomerIds)
        {
            var physicanCustomerAssignments = _physicianCustomerAssignmentRepository.GetCustomerAssignmentbyEventCustomerIds(eventCustomerIds);
            var physicianEventAssignment = _physicianEventAssignmentRepository.GetAssignedPhysicians(eventId);

            if (physicianEventAssignment == null && physicanCustomerAssignments == null)
                return null;

            var eventCustomers = _eventCustomerRepository.GetByIds(eventCustomerIds);
            var models = new List<AssignedPhysicianViewModel>();
            var specializations = _physicianRepository.GetPhysicianSpecilizationIdNamePairs();
            var physicians = new List<Physician>();

            foreach (long eventCustomerId in eventCustomerIds)
            {
                var eventCustomer = eventCustomers.Where(ec => ec.Id == eventCustomerId).SingleOrDefault();
                var physicianCustomerAssignment = physicanCustomerAssignments != null ? physicanCustomerAssignments.Where(pc => pc.EventCustomerId == eventCustomerId).SingleOrDefault() : null;
                if (physicianCustomerAssignment != null)
                {
                    var assignedPhysicians = GetAssignedPhysicians(physicianCustomerAssignment.PhysicianId, physicianCustomerAssignment.OverReadPhysicianId, physicians, specializations);

                    var model = new AssignedPhysicianViewModel
                    {
                        CustomerId = eventCustomer.CustomerId,
                        IsDefaultAssignment = false,
                        Primary = assignedPhysicians.FirstOrDefault(),
                        Overread = assignedPhysicians.ElementAtOrDefault(1),
                    };
                    models.Add(model);
                }
                else if (physicianEventAssignment != null)
                {
                    var assignedPhysicians = GetAssignedPhysicians(physicianEventAssignment.PhysicianId, physicianEventAssignment.OverReadPhysicianId, physicians, specializations);

                    var model = new AssignedPhysicianViewModel
                    {
                        CustomerId = eventCustomer.CustomerId,
                        IsDefaultAssignment = true,
                        Primary = assignedPhysicians.FirstOrDefault(),
                        Overread = assignedPhysicians.ElementAtOrDefault(1),
                    };
                    models.Add(model);
                }
            }
            return models;
        }

        private IEnumerable<AssignedPhysicianBasicInfoModel> GetAssignedPhysicians(long physicianId, long? overReadPhysicianId)
        {
            var specializations = _physicianRepository.GetPhysicianSpecilizationIdNamePairs();
            var assignedPhysicians = new List<AssignedPhysicianBasicInfoModel>();
            var physician = _physicianRepository.GetPhysician(physicianId);
            var assignedPhysicianBasicinfo = new AssignedPhysicianBasicInfoModel
                                                 {
                                                     PhysicianId = physician.PhysicianId,
                                                     Name = physician.Name.FullName,
                                                     Specialization = specializations.Where(s => s.FirstValue == physician.SpecializationId).Select(s => s.SecondValue).First(),
                                                     IsOverReadPhysician = false
                                                 };
            assignedPhysicians.Add(assignedPhysicianBasicinfo);

            if (overReadPhysicianId.HasValue)
            {
                var overReadPhysician = _physicianRepository.GetPhysician(overReadPhysicianId.Value);
                var assignedOverReadPhysicianBasicinfo = new AssignedPhysicianBasicInfoModel
                                                             {
                                                                 PhysicianId = overReadPhysician.PhysicianId,
                                                                 Name = overReadPhysician.Name.FullName,
                                                                 Specialization = specializations.Where(s => s.FirstValue == overReadPhysician.SpecializationId).Select(s => s.SecondValue).First(),
                                                                 IsOverReadPhysician = true
                                                             };
                assignedPhysicians.Add(assignedOverReadPhysicianBasicinfo);
            }
            return assignedPhysicians;
        }

        private IEnumerable<AssignedPhysicianBasicInfoModel> GetAssignedPhysicians(long physicianId, long? overReadPhysicianId, List<Physician> physicians, IEnumerable<OrderedPair<long, string>> specializations)
        {
            var assignedPhysicians = new List<AssignedPhysicianBasicInfoModel>();

            var physician = physicians.Where(p => p.PhysicianId == physicianId).SingleOrDefault();
            if (physician == null)
            {
                physician = _physicianRepository.GetPhysician(physicianId);
                physicians.Add(physician);
            }

            var assignedPhysicianBasicinfo = new AssignedPhysicianBasicInfoModel
            {
                PhysicianId = physician.PhysicianId,
                Name = physician.Name.FullName,
                Specialization = specializations.Where(s => s.FirstValue == physician.SpecializationId).Select(s => s.SecondValue).First(),
                IsOverReadPhysician = false
            };
            assignedPhysicians.Add(assignedPhysicianBasicinfo);

            if (overReadPhysicianId.HasValue)
            {
                var overReadPhysician = physicians.Where(p => p.PhysicianId == overReadPhysicianId.Value).SingleOrDefault();
                if (overReadPhysician == null)
                {
                    overReadPhysician = _physicianRepository.GetPhysician(overReadPhysicianId.Value);
                    physicians.Add(overReadPhysician);
                }
                var assignedOverReadPhysicianBasicinfo = new AssignedPhysicianBasicInfoModel
                {
                    PhysicianId = overReadPhysician.PhysicianId,
                    Name = overReadPhysician.Name.FullName,
                    Specialization = specializations.Where(s => s.FirstValue == overReadPhysician.SpecializationId).Select(s => s.SecondValue).First(),
                    IsOverReadPhysician = true
                };
                assignedPhysicians.Add(assignedOverReadPhysicianBasicinfo);
            }
            return assignedPhysicians;
        }

        public IEnumerable<long> GetPhysicianIdsAssignedtoaCustomer(long eventId, long customerId)
        {
            IEnumerable<long> physicianIds = null;
            // NOTE: Maintain the order of enumeration with, first elementas primary physician and second as overread
            var customerWiseAssignment = _physicianCustomerAssignmentRepository.GetAssignedPhysicians(eventId, customerId);
            if (customerWiseAssignment == null)
            {
                var eventAssignement = _physicianEventAssignmentRepository.GetAssignedPhysicians(eventId);
                if (eventAssignement != null)
                {
                    physicianIds = new[] { eventAssignement.PhysicianId };
                    if (eventAssignement.OverReadPhysicianId.HasValue && eventAssignement.OverReadPhysicianId.Value > 0)
                    {
                        physicianIds = new[] { eventAssignement.PhysicianId, eventAssignement.OverReadPhysicianId.Value };
                    }
                }
            }
            else
            {
                physicianIds = new[] { customerWiseAssignment.PhysicianId };
                if (customerWiseAssignment.OverReadPhysicianId.HasValue && customerWiseAssignment.OverReadPhysicianId.Value > 0)
                {
                    physicianIds = new[] { customerWiseAssignment.PhysicianId, customerWiseAssignment.OverReadPhysicianId.Value };
                }
            }

            return physicianIds;
        }

        public IEnumerable<AssignedPhysicianViewModel> GetPhysicianAssignmentsByEventcustomerIds(IEnumerable<long> eventCustomerIds)
        {
            var eventCustomers = _eventCustomerRepository.GetByIds(eventCustomerIds);
            var physicanCustomerAssignments = _physicianCustomerAssignmentRepository.GetCustomerAssignmentbyEventCustomerIds(eventCustomerIds);
            var physicianEventAssignments = _physicianEventAssignmentRepository.GetAssignedPhysiciansByEventIds(eventCustomers.Select(ec => ec.EventId).ToArray());

            if (physicianEventAssignments == null && physicanCustomerAssignments == null)
                return null;


            var models = new List<AssignedPhysicianViewModel>();
            var specializations = _physicianRepository.GetPhysicianSpecilizationIdNamePairs();
            var physicians = new List<Physician>();

            foreach (long eventCustomerId in eventCustomerIds)
            {
                var eventCustomer = eventCustomers.Where(ec => ec.Id == eventCustomerId).SingleOrDefault();

                var physicianCustomerAssignment = physicanCustomerAssignments != null ? physicanCustomerAssignments.Where(pc => pc.EventCustomerId == eventCustomerId).SingleOrDefault() : null;
                var physicianEventAssignment = physicianEventAssignments != null ? physicianEventAssignments.Where(pe => pe.EventId == eventCustomer.EventId).SingleOrDefault() : null;

                if (physicianCustomerAssignment != null)
                {
                    var assignedPhysicians = GetAssignedPhysicians(physicianCustomerAssignment.PhysicianId, physicianCustomerAssignment.OverReadPhysicianId, physicians, specializations);

                    var model = new AssignedPhysicianViewModel
                    {
                        CustomerId = eventCustomer.CustomerId,
                        EventCustomerId = eventCustomer.Id,
                        IsDefaultAssignment = false,
                        Primary = assignedPhysicians.FirstOrDefault(),
                        Overread = assignedPhysicians.ElementAtOrDefault(1),
                    };
                    models.Add(model);
                }
                else if (physicianEventAssignment != null)
                {
                    var assignedPhysicians = GetAssignedPhysicians(physicianEventAssignment.PhysicianId, physicianEventAssignment.OverReadPhysicianId, physicians, specializations);

                    var model = new AssignedPhysicianViewModel
                    {
                        CustomerId = eventCustomer.CustomerId,
                        EventCustomerId = eventCustomer.Id,
                        IsDefaultAssignment = true,
                        Primary = assignedPhysicians.FirstOrDefault(),
                        Overread = assignedPhysicians.ElementAtOrDefault(1),
                    };
                    models.Add(model);
                }
            }
            return models;
        }

        public IEnumerable<PhsicianEventTestViewModel> GetPhsiscianAssignedTests(long eventId, long physicianId)
        {
            var permittedTests = _physicianRepository.GetPermittedTestIdsForPhysician(physicianId);
            var testAssignedToPhysician = _eventPhysicianTestRepository.GetByEventIdPhysicianId(eventId, physicianId);

            var list = new List<PhsicianEventTestViewModel>();
            if (!permittedTests.IsNullOrEmpty())
            {
                var testList = testAssignedToPhysician != null ? testAssignedToPhysician.Select(x => x.TestId).ToList() : null;
                list.AddRange(permittedTests.Select(permittedTest => new PhsicianEventTestViewModel
                {
                    TestId = permittedTest,
                    IsSelected = testList != null && testList.Contains(permittedTest)
                }));
            }
            return list;
        }

        public void Save(PhysicianEventAssignmentEditModel model, OrganizationRoleUserModel currentOrganizationRole)
        {
            var physicianEventAssignment = Mapper.Map<PhysicianEventAssignmentEditModel, PhysicianEventAssignment>(model);
            physicianEventAssignment.DataRecorderMetaData = new DataRecorderMetaData
            {
                DataRecorderCreator = Mapper.Map<OrganizationRoleUserModel, OrganizationRoleUser>(currentOrganizationRole),
                DateCreated = DateTime.Now
            };

            _physicianEventAssignmentRepository.Save(physicianEventAssignment);

            if(model.IsEvaluationRestricted)
            {
                var eventPhysicianTest = model.EventPhysicianTests;
                var domainList=    _eventPhysicianTestFactory.GetDomain(eventPhysicianTest,currentOrganizationRole.OrganizationRoleUserId, model.EventId);

                _eventPhysicianTestRepository.SaveEventPhysicianTests(domainList);
            }
        }
    }
}
