using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;
using Falcon.App.UI.Filters;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.UI.Areas.Marketing.Controllers
{
    [RoleBasedAuthorize]
    public class PackageController : Controller
    {
        private readonly IPackageRepository _packageRepository;
        private readonly IPackageTestRepository _packageTestRepository;
        private readonly ITestRepository _testRepository;
        private readonly IUserService _userService;
        private readonly ISessionContext _sessionContext;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly int _pageSize;

        public PackageController(IPackageRepository packageRepository, ITestRepository testRepository, IUserService userService, IPackageTestRepository packageTestRepository, ISessionContext sessionContext,
            ISettings setting, IUniqueItemRepository<File> fileRepository, IMediaRepository mediaRepository)
        {
            _packageRepository = packageRepository;
            _testRepository = testRepository;
            _userService = userService;
            _packageTestRepository = packageTestRepository;
            _sessionContext = sessionContext;
            _pageSize = setting.DefaultPageSizeForReports;
            _fileRepository = fileRepository;
            _mediaRepository = mediaRepository;
        }
        //
        // GET: /Marketing/Package/

        public ActionResult GetAllPackages()
        {
            return Json(_packageRepository.GetAll().OrderBy(p => p.Name).Select(p => new OrderedPair<string, long>(p.Name, p.Id)).ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCorporatePackages()
        {
            return Json(_packageRepository.GetCorporatePackages().OrderBy(p => p.Name).Select(p => new OrderedPair<string, long>(p.Name, p.Id)).ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            var tests = _testRepository.GetAll();

            var model = new PackageEditModel
            {
                AllTests = Mapper.Map<IEnumerable<Test>, IEnumerable<TestViewModel>>(tests),
                AllRoles = _userService.GetRoleswithRegistrationEnabled(),
                Gender = (long)Gender.Unspecified,
                SelectedTests = GetDefaultSelectedTests(tests.Where(x => x.IsDefaultSelectionForPackage), null)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(PackageEditModel model)
        {
            try
            {
                var tests = _testRepository.GetAll();
                model.AllTests = Mapper.Map<IEnumerable<Test>, IEnumerable<TestViewModel>>(tests);
                model.AllRoles = _userService.GetRoleswithRegistrationEnabled();
                model.SelectedTests = GetDefaultSelectedTests(tests.Where(x => x.IsDefaultSelectionForPackage), model.SelectedTests);
                if (ModelState.IsValid)
                {
                    model.ForOrderDisplayFile = FileObject(model.Name.Replace(" ", "_").Replace("+", "_"), "package_image", _mediaRepository.GetPackageImageFolderLocation());
                    SavePackage(model);
                    model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Package is created successfully. You can create more packages or close this page.");

                    return View(model);
                }

                return View(model);

            }
            catch (Exception ex)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error:" + ex);
                return View(model);
            }
        }

        public ActionResult Edit(long id)
        {
            var tests = _testRepository.GetAll();
            var package = _packageRepository.GetById(id);
            var model = Mapper.Map<Package, PackageEditModel>(package);
            if (package.ForOrderDisplayFileId.HasValue && package.ForOrderDisplayFileId > 0)
            {
                model.ForOrderDisplayFile = _fileRepository.GetById(package.ForOrderDisplayFileId.Value);
            }

            model.AllTests = Mapper.Map<IEnumerable<Test>, IEnumerable<TestViewModel>>(tests);
            model.AllRoles = _userService.GetRoleswithRegistrationEnabled();

            model.SelectedRoles = _packageRepository.GetRoleswithGivenPackageAvailability(id);
            var packageTests = _packageTestRepository.GetbyPackageId(id);
            var pacakgeTestModel = Mapper.Map<IEnumerable<PackageTest>, IEnumerable<PackageTestEditModel>>(packageTests);
            model.SelectedTests = GetDefaultSelectedTests(tests.Where(x => x.IsDefaultSelectionForPackage), pacakgeTestModel);

            return View(model);
        }

        public ActionResult GetPackageTestAccessedByName(string prefixText, long gender)
        {
            var tests = _testRepository.GetAll();
            var allTests = Mapper.Map<IEnumerable<Test>, IEnumerable<TestViewModel>>(tests);

            return Json(allTests.Where(x => (gender == (long)Gender.Unspecified ||(x.Gender==(long)Gender.Unspecified || x.Gender == gender)) && x.Name.ToLower().Contains(prefixText.ToLower())).Select(x => new { TestId = x.TestId, Name = x.Name }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(PackageEditModel model)
        {
            try
            {
                var tests = _testRepository.GetAll();
                model.AllTests = Mapper.Map<IEnumerable<Test>, IEnumerable<TestViewModel>>(tests);
                model.AllRoles = _userService.GetRoleswithRegistrationEnabled();
                model.SelectedTests = GetDefaultSelectedTests(tests.Where(x => x.IsDefaultSelectionForPackage), model.SelectedTests);

                if (ModelState.IsValid)
                {
                    model.ForOrderDisplayFile = FileObject(model.Name.Replace(" ", "_").Replace("+", "_"), "package_image", _mediaRepository.GetPackageImageFolderLocation(), model.ForOrderDisplayFile != null ? model.ForOrderDisplayFile.Id : 0);
                    SavePackage(model);

                    var packageTests = _packageTestRepository.GetbyPackageId(model.Id);
                    var pacakgeTestModel = Mapper.Map<IEnumerable<PackageTest>, IEnumerable<PackageTestEditModel>>(packageTests);
                    model.SelectedTests = GetDefaultSelectedTests(tests.Where(x => x.IsDefaultSelectionForPackage), pacakgeTestModel);

                    model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Package is edited successfully. You can edit more packages or close this page.");
                    return View(model);
                }
                return View(model);
            }
            catch (Exception ex)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error:" + ex);
                return View(model);
            }
        }

        private void SavePackage(PackageEditModel model)
        {
            Package packageinDb = null;
            IEnumerable<PackageTest> packageTestsinDb = null;

            var package = Mapper.Map<PackageEditModel, Package>(model);
            if (model.ForOrderDisplayFile != null)
            {
                model.ForOrderDisplayFile = _fileRepository.Save(model.ForOrderDisplayFile);
                package.ForOrderDisplayFileId = model.ForOrderDisplayFile.Id;
            }
            if (package.Id > 0)
            {
                packageinDb = _packageRepository.GetById(package.Id);
                packageTestsinDb = _packageTestRepository.GetbyPackageId(package.Id);
                package.DataRecorderMetaData = packageinDb.DataRecorderMetaData;
                package.DataRecorderMetaData.DateModified = DateTime.Now;
                package.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
            }
            else
            {
                package.DataRecorderMetaData = new DataRecorderMetaData(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, DateTime.Now, null);
            }

            using (var scope = new TransactionScope())
            {
                package = ((IUniqueItemRepository<Package>)_packageRepository).Save(package);
                _packageRepository.SaveRolesforGivenPackageAvailability(package.Id, model.SelectedRoles);

                if (model.SelectedTests != null && model.SelectedTests.Count() > 0)
                {
                    var packageTests =
                        Mapper.Map<IEnumerable<PackageTestEditModel>, IEnumerable<PackageTest>>(model.SelectedTests);

                    foreach (var test in packageTests)
                    {
                        PackageTest packageTestInDb = null;
                        if (packageTestsinDb != null && packageTestsinDb.Count() > 0)
                        {
                            packageTestInDb = packageTestsinDb.Where(pt => pt.TestId == test.TestId).SingleOrDefault();
                        }

                        test.PackageId = package.Id;
                        if (packageTestInDb != null)
                        {
                            test.DateModified = DateTime.Now;
                            test.DateCreated = packageTestInDb.DateCreated;
                        }
                        else
                        {
                            test.DateCreated = DateTime.Now;
                        }
                    }
                    packageTests = _packageTestRepository.Save(packageTests);
                }

                scope.Complete();
            }
        }

        public ActionResult Index(PackageListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords;
            var packages = _packageRepository.Get(filter, pageNumber, _pageSize, out totalRecords);
            var model = new PackageListModel
                            {
                                Packages = Mapper.Map<IEnumerable<Package>, IEnumerable<PackageViewModel>>(packages)
                            };

            if (filter == null) filter = new PackageListModelFilter();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc = pn => Url.Action(currentAction, new { pageNumber = pn, filter.Name, filter.Active, filter.Inactive, filter.PackageType });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult SetPackageIsActiveState(long packageId, bool isActive)
        {
            _packageRepository.SetPackageIsActiveState(packageId, isActive);
            return Content("");
        }

        private File FileObject(string fileNamePrefix, string fileUploadElementName, MediaLocation fileLocation, long fileId = 0)
        {
            if (Request.Files != null && Request.Files.Count > 0 && Request.Files[fileUploadElementName] != null)
            {
                var fileUploaded = Request.Files[fileUploadElementName];
                if (string.IsNullOrEmpty(fileUploaded.FileName))
                {
                    return fileId > 0 ? _fileRepository.GetById(fileId) : null;
                }

                var newFileName = fileNamePrefix.Replace(" ", "") + "_" + DateTime.Now.ToFileTimeUtc() + Path.GetExtension(fileUploaded.FileName);

                fileUploaded.SaveAs(fileLocation.PhysicalPath + newFileName);

                return new File
                {
                    Id = fileId,
                    FileSize = fileUploaded.ContentLength,
                    Path = newFileName,
                    Type = FileType.Image,
                    UploadedOn = DateTime.Now,
                    UploadedBy = new OrganizationRoleUser(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId)
                };
            }

            return fileId > 0 ? _fileRepository.GetById(fileId) : null;
        }


        private IEnumerable<PackageTestEditModel> GetDefaultSelectedTests(IEnumerable<Test> tests, IEnumerable<PackageTestEditModel> packageTest)
        {
            if (tests.IsNullOrEmpty()) return packageTest;

            if (packageTest.IsNullOrEmpty())
            {
                return tests.Select(test => new PackageTestEditModel { TestId = test.Id, Price = test.PackagePrice, RefundPrice = test.PackageRefundPrice, IsDefault = true }).ToList();
            }

            foreach (var package in from package in packageTest let defaultTest = tests.SingleOrDefault(x => x.Id == package.TestId) where defaultTest != null select package)
            {
                package.IsDefault = true;
            }

            return packageTest;
        }
    }
}
