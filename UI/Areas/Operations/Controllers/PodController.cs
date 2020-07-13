using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Operations.Controllers
{
    [RoleBasedAuthorize]
    public class PodController : Controller
    {
        private readonly IUniqueItemRepository<Pod> _podRepository;
        private readonly IPodStaffAssignmentRepository _podStaffAssignmentRepository;
        private readonly ISessionContext _sessionContext;
        private readonly ITerritoryRepository _territoryRepository;
        private readonly IPodService _podService;
        private readonly ITestRepository _testRepository;


        public PodController(IUniqueItemRepository<Pod> podRepository, IPodStaffAssignmentRepository podStaffAssignmentRepository, ITerritoryRepository territoryRepository,
            ISessionContext sessionContext, IPodService podService, ITestRepository testRepository)
        {
            _podRepository = podRepository;
            _podStaffAssignmentRepository = podStaffAssignmentRepository;
            _sessionContext = sessionContext;
            _territoryRepository = territoryRepository;
            _podService = podService;
            _testRepository = testRepository;
        }

        public ActionResult Create()
        {
            return View(new PodEditModel(_territoryRepository, _testRepository));
        }

        [HttpPost]
        public ActionResult Create(PodEditModel podEditModel)
        {
            try
            {
                podEditModel.Territories = _territoryRepository.GetAllTerritoriesIdNamePair(TerritoryType.Pod);
                podEditModel.Tests = _testRepository.GetAll();
                if (ModelState.IsValid)
                {

                    var pod = Mapper.Map<PodEditModel, Pod>(podEditModel);
                    pod.DataRecorderMetaData = new DataRecorderMetaData()
                                                   {
                                                       DataRecorderCreator = Mapper.Map<OrganizationRoleUserModel, OrganizationRoleUser>(_sessionContext.UserSession.CurrentOrganizationRole),
                                                       DateCreated = DateTime.Now
                                                   };

                    using (var scope = new TransactionScope())
                    {
                        pod = _podRepository.Save(pod);

                        var podTeam = new List<PodStaff>();
                        podEditModel.DefaultStaffAssigned.ToList().ForEach(dsa =>
                                                                               {
                                                                                   var teamMember = Mapper.Map<PodStaffEditModel, PodStaff>(dsa);
                                                                                   teamMember.PodId = pod.Id;
                                                                                   teamMember.DataRecorderMetaData = new DataRecorderMetaData
                                                                                   {
                                                                                       DataRecorderCreator = Mapper.Map<OrganizationRoleUserModel, OrganizationRoleUser>(_sessionContext.UserSession.CurrentOrganizationRole),
                                                                                       DateCreated = DateTime.Now
                                                                                   };
                                                                                   podTeam.Add(teamMember);
                                                                               });

                        if (!podEditModel.AssignedTerritories.IsNullOrEmpty())
                            ((IPodRepository)_podRepository).SavePodTerritories(podEditModel.AssignedTerritories,
                                                                                 pod.Id);

                        // Need to check the DefaultPodTeam Issue.
                        podTeam = _podStaffAssignmentRepository.SaveMultiple(podTeam, pod.Id).ToList();

                        _podService.SavePodRooms(podEditModel.Rooms, pod.Id);

                        scope.Complete();
                    }

                    var newModel = new PodEditModel(_territoryRepository, _testRepository);

                    newModel.FeedbackMessage =
                        FeedbackMessageModel.CreateSuccessMessage(
                            "The POD information was saved successfully. You can add more PODs or close this page.");

                    return View(newModel);
                }
                return View(podEditModel);
            }
            catch (Exception exception)
            {
                podEditModel.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error:" + exception);
                return View(podEditModel);
            }
        }

        public ActionResult Index()
        {
            //TODO: Spotted hardcoding, Need to fix the paging : Sandeep
            return View(_podService.GetPodListModel(1, 30));
        }

        public ActionResult Edit(long id)
        {
            return View(_podService.GetPodEditModel(id));
        }

        [HttpPost]
        public ActionResult Edit(PodEditModel podEditModel)
        {
            try
            {
                podEditModel.Territories = _territoryRepository.GetAllTerritoriesIdNamePair(TerritoryType.Pod);
                podEditModel.Tests = _testRepository.GetAll();
                if (ModelState.IsValid)
                {

                    var pod = Mapper.Map<PodEditModel, Pod>(podEditModel);
                    var podInDb = _podRepository.GetById(pod.Id);
                    pod.DataRecorderMetaData = podInDb.DataRecorderMetaData;

                    pod.DataRecorderMetaData.DataRecorderModifier =
                        Mapper.Map<OrganizationRoleUserModel, OrganizationRoleUser>(_sessionContext.UserSession.CurrentOrganizationRole);
                    pod.DataRecorderMetaData.DateModified = DateTime.Now;

                    using (var scope = new TransactionScope())
                    {
                        pod = _podRepository.Save(pod);

                        var podTeam = new List<PodStaff>();
                        podEditModel.DefaultStaffAssigned.ToList().ForEach(dsa =>
                        {
                            var teamMember = Mapper.Map<PodStaffEditModel, PodStaff>(dsa);
                            teamMember.PodId = pod.Id;
                            teamMember.DataRecorderMetaData = new DataRecorderMetaData()
                            {
                                DataRecorderCreator = Mapper.Map<OrganizationRoleUserModel, OrganizationRoleUser>(_sessionContext.UserSession.CurrentOrganizationRole),
                                DateCreated = DateTime.Now
                            };
                            podTeam.Add(teamMember);
                        });

                        ((IPodRepository)_podRepository).SavePodTerritories(podEditModel.AssignedTerritories,
                                                                             pod.Id);

                        // Need to check the DefaultPodTeam Issue.
                        podTeam = _podStaffAssignmentRepository.SaveMultiple(podTeam, pod.Id).ToList();

                        _podService.SavePodRooms(podEditModel.Rooms,pod.Id);
                        scope.Complete();
                    }

                    var newModel = _podService.GetPodEditModel(podEditModel.Id);

                    newModel.FeedbackMessage =
                        FeedbackMessageModel.CreateSuccessMessage(
                            "The POD was edited successfully. You can edit it for more changes or close this page.");

                    return View(newModel);
                }
                return View(podEditModel);
            }
            catch (Exception exception)
            {
                podEditModel.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error:" + exception);
                return View(podEditModel);
            }
        }

    }
}
