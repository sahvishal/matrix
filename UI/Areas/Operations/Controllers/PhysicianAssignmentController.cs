using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Operations.Controllers
{
    [RoleBasedAuthorize]
    public class PhysicianAssignmentController : Controller
    {
        private readonly ISessionContext _sessionContext;
        private readonly IPhysicianCustomerAssignmentRepository _physicianCustomerAssignmentRepository;
        private readonly IPhysicianAssignmentService _physicianAssignmentService;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;
        private readonly IEventTestRepository _eventTestRepository;


        public PhysicianAssignmentController(ISessionContext sessionContext, IPhysicianCustomerAssignmentRepository physicianCustomerAssignmentRepository,
            IPhysicianAssignmentService physicianAssignmentService, IHospitalPartnerRepository hospitalPartnerRepository, IEventTestRepository eventTestRepository)
        {
            _sessionContext = sessionContext;
            _physicianCustomerAssignmentRepository = physicianCustomerAssignmentRepository;
            _physicianAssignmentService = physicianAssignmentService;
            _hospitalPartnerRepository = hospitalPartnerRepository;
            _eventTestRepository = eventTestRepository;
        }

        public ActionResult AssignPhysicianToEvent(long eventId)
        {
            var model = new PhysicianEventAssignmentEditModel
            {
                EventId = eventId,
                AssignedPhysicians = _physicianAssignmentService.GetPhysiciansAssignedToEvent(eventId),
                IsEvaluationRestricted = GetEventTestEvaluationRestricted(eventId)
            };


            if (model.AssignedPhysicians != null)
            {
                foreach (var assignedPhysician in model.AssignedPhysicians)
                {
                    if (assignedPhysician.IsOverReadPhysician)
                        model.OverReadPhysicianId = assignedPhysician.PhysicianId;
                    else
                        model.PhysicianId = assignedPhysician.PhysicianId;
                }
            }
            return View(Get(model));
        }

        private PhysicianEventAssignmentEditModel Get(PhysicianEventAssignmentEditModel model)
        {
            if (model != null && model.IsEvaluationRestricted)
            {
                var eventTests = _eventTestRepository.GetTestsForEvent(model.EventId);

                var tests = eventTests.Where(et => et.Test.IsReviewable).Select(et => et.Test).ToArray();
                //model.EventTests = _testRepository.GetReviewableTests();
                model.EventTests = tests;
            }
            return model;
        }

        private bool GetEventTestEvaluationRestricted(long eventId)
        {
            var hospitalPartner = _hospitalPartnerRepository.GetEventHospitalPartnersByEventId(eventId);

            return hospitalPartner != null && hospitalPartner.RestrictEvaluation;
        }

        [HttpPost]
        public ActionResult AssignPhysicianToEvent(PhysicianEventAssignmentEditModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _physicianAssignmentService.Save(model, _sessionContext.UserSession.CurrentOrganizationRole);
                    model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Physicians assigned successfully");
                    model.AssignedPhysicians = _physicianAssignmentService.GetPhysiciansAssignedToEvent(model.EventId);

                    return View(Get(model));
                }
                catch (Exception exception)
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error:" + exception.Message);
                    return View(Get(model));
                }
            }
            return View(Get(model));
        }

        public ActionResult AssignPhysicianToCustomer(long eventCustomerId)
        {
            var model = new PhysicianCustomerAssignmentEditModel { EventCustomerId = eventCustomerId };
            model.AssignedPhysicians = _physicianAssignmentService.GetPhysiciansAssignedToCustomer(eventCustomerId);
            if (model.AssignedPhysicians != null)
            {
                foreach (var assignedPhysician in model.AssignedPhysicians)
                {
                    if (assignedPhysician.IsOverReadPhysician)
                        model.OverReadPhysicianId = assignedPhysician.PhysicianId;
                    else
                        model.PhysicianId = assignedPhysician.PhysicianId;
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AssignPhysicianToCustomer(PhysicianCustomerAssignmentEditModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {


                    var physicianCustomerAssignment =
                        Mapper.Map<PhysicianCustomerAssignmentEditModel, PhysicianCustomerAssignment>(model);
                    physicianCustomerAssignment.DataRecorderMetaData = new DataRecorderMetaData
                                                                           {
                                                                               DataRecorderCreator = Mapper.Map<OrganizationRoleUserModel, OrganizationRoleUser>(
                                                                                       _sessionContext.UserSession.CurrentOrganizationRole),
                                                                               DateCreated = DateTime.Now
                                                                           };
                    _physicianCustomerAssignmentRepository.Save(physicianCustomerAssignment);
                    model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Physicians assigned successfully");
                    model.AssignedPhysicians = _physicianAssignmentService.GetPhysiciansAssignedToCustomer(model.EventCustomerId);
                }
                catch (Exception exception)
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error:" + exception.Message);
                    return View(model);
                }
            }
            return View(model);
        }

        public ActionResult GetAssignedPhysiciansForEvent(long id)
        {
            var model = _physicianAssignmentService.GetPhysiciansAssignedToEvent(id);
            return View(model);
        }

        public ActionResult GetTestAssignedToPhysician(long eventId, long physicianId)
        {
            return Json(_physicianAssignmentService.GetPhsiscianAssignedTests(eventId, physicianId), JsonRequestBehavior.AllowGet);
        }
    }
}
