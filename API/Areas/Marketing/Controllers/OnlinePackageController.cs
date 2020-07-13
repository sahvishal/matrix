using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using API.Areas.Application.Controllers;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users.Enum;

namespace API.Areas.Marketing.Controllers
{
    [AllowAnonymous]
    public class OnlinePackageController : BaseController
    {
        private readonly ITempcartService _tempcartService;
        private readonly IOnlinePackageService _onlinePackageService;

        public OnlinePackageController(ITempcartService tempcartService, IOnlinePackageService onlinePackageService)
        {
            _tempcartService = tempcartService;
            _onlinePackageService = onlinePackageService;

        }

        [HttpGet]
        public OrderPlaceEditModel GetEventPackageList(string guid)
        {
            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(guid);

            if (onlineRequestValidationModel.RequestStatus != OnlineRequestStatus.Valid)
                return new OrderPlaceEditModel() { RequestValidationModel = onlineRequestValidationModel };

            var tempCart = onlineRequestValidationModel.TempCart;

            var returnObj = _onlinePackageService.GetEventPackageList(tempCart);
            returnObj.RequestValidationModel = onlineRequestValidationModel;

            if (tempCart.EventId.HasValue && tempCart.EventId > 0 && !string.IsNullOrEmpty(tempCart.Gender) && tempCart.EventPackageId.HasValue)
            {
                returnObj.UpsellTestAvailable = _onlinePackageService.IsUpsellTestAvailable(tempCart);
                var allAdditionalTests = _onlinePackageService.GetAdditionalTest(tempCart);
                returnObj.IsAdditionalTestAvailable = allAdditionalTests != null && allAdditionalTests.Any();
            }

            return returnObj;
        }

        [HttpGet]
        public OnlineProductShippingEditModel GetShippingOption(string guid)
        {
            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(guid);

            if (onlineRequestValidationModel.RequestStatus != OnlineRequestStatus.Valid)
                return new OnlineProductShippingEditModel() { RequestValidationModel = onlineRequestValidationModel };

            var returnObj = _onlinePackageService.GetShippingOption(onlineRequestValidationModel.TempCart);
            returnObj.RequestValidationModel = onlineRequestValidationModel;

            return returnObj;
        }



        [HttpGet]
        public OrderPlaceEditModel GetAdditionalTest(string guid)
        {
            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(guid);
            var model = new OrderPlaceEditModel() { RequestValidationModel = onlineRequestValidationModel };

            if (onlineRequestValidationModel.RequestStatus != OnlineRequestStatus.Valid)
                return model;

            var tempCart = onlineRequestValidationModel.TempCart;

            model.AllEventTests = _onlinePackageService.GetAdditionalTest(onlineRequestValidationModel.TempCart);

            if (tempCart.EventId.HasValue && tempCart.EventId > 0 && !string.IsNullOrEmpty(tempCart.Gender) && tempCart.EventPackageId.HasValue)
            {
                Gender gender;
                System.Enum.TryParse(tempCart.Gender, out gender);
                var upsellTests = _onlinePackageService.UpsaleTest(tempCart.EventId.Value, tempCart.EventPackageId.Value, gender);
                model.UpsellTestAvailable = _onlinePackageService.IsUpsellTestAvailable(tempCart);
                if (model.UpsellTestAvailable)
                {
                    var panelTestId = gender == Gender.Male ? TestType.MenBloodPanel : TestType.WomenBloodPanel;
                    var test = upsellTests.Where(x => x.TestId == (long)panelTestId);
                    if (test != null && test.Any())
                    {
                        var panelEventTestId = test.First().EventTestId;
                        model.BloodPanelTestName = test.First().Name;
                        model.BloodPanelTestId = test.First().TestId;
                        if (!String.IsNullOrEmpty(tempCart.TestId))
                        {
                            var testIds = new List<long>();
                            testIds = tempCart.TestId.Split(',').Select(long.Parse).ToList();
                            if (testIds.Contains(panelEventTestId))
                            {
                                model.IsBloodPanelTestTaken = true;
                            }
                        }
                    }
                }
            }

            return model;
        }

        [HttpPost]
        public OrderPlaceEditModel SaveSelectedPackage(string guid, long selectedEventPackageId)
        {
            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(guid);
            var model = new OrderPlaceEditModel { RequestValidationModel = onlineRequestValidationModel };

            if (onlineRequestValidationModel.RequestStatus != OnlineRequestStatus.Valid)
                return model;

            var tempCart = onlineRequestValidationModel.TempCart;

            if (tempCart.AppointmentId > 0)
                _onlinePackageService.ReleaseSlotsOnScreeningtimeChanged(tempCart, selectedEventPackageId, tempCart.TestId);

            tempCart.EventPackageId = selectedEventPackageId;

            _onlinePackageService.UpdateTestPurchased(tempCart);

            _tempcartService.SaveTempCart(tempCart);

            if (tempCart.EventId.HasValue && tempCart.EventId > 0 && !string.IsNullOrEmpty(tempCart.Gender))
            {
                model.UpsellTestAvailable = _onlinePackageService.IsUpsellTestAvailable(tempCart);
                var allAdditionalTests = _onlinePackageService.GetAdditionalTest(tempCart);
                model.IsAdditionalTestAvailable = allAdditionalTests != null && allAdditionalTests.Any();
            }

            return model;
        }

        [HttpPost]
        public OnlineProductShippingEditModel SaveSelectedShippingOption(OnlineProductShippingEditModel model)
        {
            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(model.Guid);
            model.RequestValidationModel = onlineRequestValidationModel;

            if (onlineRequestValidationModel.RequestStatus != OnlineRequestStatus.Valid)
                return model;

            var tempCart = onlineRequestValidationModel.TempCart;

            tempCart.ProductId = model.SelectedProductIds != null ? string.Join(",", model.SelectedProductIds) : string.Empty;
            tempCart.ShippingId = model.SelectedShippingOptionId < 0 ? null : (long?)model.SelectedShippingOptionId;

            _tempcartService.SaveTempCart(tempCart);
            return model;
        }

        [HttpPost]
        public OrderPlaceEditModel SaveSelectedTest(UpsellTestEditModel upsellTest)
        {
            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(upsellTest.Guid);
            var model = new OrderPlaceEditModel { RequestValidationModel = onlineRequestValidationModel };

            if (onlineRequestValidationModel.RequestStatus != OnlineRequestStatus.Valid)
                return model;
            var tempCart = onlineRequestValidationModel.TempCart;

            var selectedEventTestIds = (upsellTest.SelectedEventTestIds != null && upsellTest.SelectedEventTestIds.Any()) ? string.Join(",", upsellTest.SelectedEventTestIds.ToList()) : string.Empty;

            _onlinePackageService.SaveaAlacarteTestIds(tempCart, selectedEventTestIds, upsellTest.SaveBloodPanelTest);

            if (tempCart.AppointmentId > 0)
            {
                _onlinePackageService.ReleaseSlotsOnScreeningtimeChanged(tempCart, tempCart.EventPackageId.Value, tempCart.TestId);
            }
            return model;
        }

        [HttpGet]
        public UpsellTestEditModel GetUpsellTest(string guid)
        {
            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(guid);
            var upsellTestEditModel = new UpsellTestEditModel
            {
                RequestValidationModel = onlineRequestValidationModel
            };
            if (onlineRequestValidationModel.RequestStatus != OnlineRequestStatus.Valid)
                return upsellTestEditModel;
            var tempCart = onlineRequestValidationModel.TempCart;

            if (tempCart.EventId.HasValue && tempCart.EventId > 0 && !string.IsNullOrEmpty(tempCart.Gender) && tempCart.EventPackageId.HasValue)
            {
                Gender gender;
                System.Enum.TryParse(tempCart.Gender, out gender);
                var upsellTests = _onlinePackageService.UpsaleTest(tempCart.EventId.Value, tempCart.EventPackageId.Value, gender);
                upsellTestEditModel.EventTestOrderItemList = upsellTests;
            }

            if (tempCart.EventId.HasValue && tempCart.EventId > 0 && tempCart.EventPackageId.HasValue)
            {
                var allAdditionalTests = _onlinePackageService.GetAdditionalTest(tempCart);
                upsellTestEditModel.IsAdditionalTestAvailable = allAdditionalTests != null && allAdditionalTests.Any();
            }

            return upsellTestEditModel;
        }

        [HttpPost]
        public UpsellTestEditModel PostUpsellTest(UpsellTestEditModel model)
        {
            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(model.Guid);

            model.RequestValidationModel = onlineRequestValidationModel;

            if (onlineRequestValidationModel.RequestStatus != OnlineRequestStatus.Valid)
                return model;

            _onlinePackageService.SaveUpsellTestIds(model);

            var tempCart = model.RequestValidationModel.TempCart;
            if (tempCart.AppointmentId > 0)
            {
                _onlinePackageService.ReleaseSlotsOnScreeningtimeChanged(tempCart, tempCart.EventPackageId.Value, tempCart.TestId);
            }

            return model;
        }

    }
}