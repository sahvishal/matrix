using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using System;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Operations.Controllers
{
    [RoleBasedAuthorize]
    public class StaffEventRoleController : Controller
    {
        private ISessionContext _sessionContext;
        private ITestRepository _testRepository;
        private IEventRoleRepository _staffEventRoleRepository;
        private readonly IStaffEventRoleListModelFactory _staffEventRoleListModelFactory;

        public StaffEventRoleController(ISessionContext sessionContext, ITestRepository testRepository, IEventRoleRepository staffEventRoleRepository,
            IStaffEventRoleListModelFactory staffEventRoleListModelFactory)
        {
            _sessionContext = sessionContext;
            _testRepository = testRepository;
            _staffEventRoleRepository = staffEventRoleRepository;
            _staffEventRoleListModelFactory = staffEventRoleListModelFactory;
        }

        public ActionResult Index()
        {
            var staffEventRoles = _staffEventRoleRepository.GetAllActiveRoles();
            var tests = ((IUniqueItemRepository<Test>)_testRepository).GetByIds(staffEventRoles.SelectMany(ser => ser.AllowedTestIds).Distinct());

            return View(_staffEventRoleListModelFactory.Create(staffEventRoles, tests));
        }

        public ActionResult Create()
        {
            return View(new StaffEventRoleEditModel(_testRepository));
        }

        [HttpPost]
        public ActionResult Create(StaffEventRoleEditModel staffEventRoleEditModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var staffEventRole = Mapper.Map<StaffEventRoleEditModel, StaffEventRole>(staffEventRoleEditModel);

                    if (staffEventRole.Id == 0)
                    {
                        staffEventRole.DataRecorderMetaData = new DataRecorderMetaData()
                                                                  {
                                                                      DataRecorderCreator = Mapper.Map<OrganizationRoleUserModel, OrganizationRoleUser>(
                                                                              _sessionContext.UserSession.CurrentOrganizationRole),
                                                                      DateCreated = DateTime.Now
                                                                  };
                    }
                    _staffEventRoleRepository.Save(staffEventRole);

                    var newModel = new StaffEventRoleEditModel(_testRepository);
                    newModel.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Staff Event Role created succesfully.");
                    return View(newModel);
                }
                staffEventRoleEditModel.Tests = _testRepository.GetAll();
                return View(staffEventRoleEditModel);
            }
            catch (Exception exception)
            {
                staffEventRoleEditModel.Tests = _testRepository.GetAll();
                staffEventRoleEditModel.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error:" + exception);
                return View(staffEventRoleEditModel);
            }
        }

        public ActionResult Edit(long id)
        {
            var staffEventRole = _staffEventRoleRepository.GetById(id);
            var staffEventRoleEditModel = Mapper.Map<StaffEventRole, StaffEventRoleEditModel>(staffEventRole);
            staffEventRoleEditModel.Tests = _testRepository.GetAll();
            return View(staffEventRoleEditModel);
        }

        [HttpPost]
        public ActionResult Edit(StaffEventRoleEditModel staffEventRoleEditModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var staffEventRole = Mapper.Map<StaffEventRoleEditModel, StaffEventRole>(staffEventRoleEditModel);

                    var inDbStaffEventRole = _staffEventRoleRepository.GetById(staffEventRole.Id);
                    staffEventRole.DataRecorderMetaData = inDbStaffEventRole.DataRecorderMetaData;

                    staffEventRole.DataRecorderMetaData.DataRecorderModifier = Mapper.Map<OrganizationRoleUserModel, OrganizationRoleUser>(
                                                                              _sessionContext.UserSession.CurrentOrganizationRole);
                    staffEventRole.DataRecorderMetaData.DateModified = DateTime.Now;

                    staffEventRole = _staffEventRoleRepository.Save(staffEventRole);
                    staffEventRoleEditModel = Mapper.Map<StaffEventRole, StaffEventRoleEditModel>(staffEventRole);
                    staffEventRoleEditModel.Tests = _testRepository.GetAll();
                    staffEventRoleEditModel.FeedbackMessage =
                        FeedbackMessageModel.CreateSuccessMessage("Staff Event Role edited succesfully.");
                }
                staffEventRoleEditModel.Tests = _testRepository.GetAll();
                return View(staffEventRoleEditModel);
            }
            catch (Exception exception)
            {
                staffEventRoleEditModel.Tests = _testRepository.GetAll();
                staffEventRoleEditModel.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error:" + exception);
                return View(staffEventRoleEditModel);
            }
        }

    }
}