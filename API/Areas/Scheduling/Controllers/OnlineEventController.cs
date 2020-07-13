using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using API.Areas.Application.Controllers;
using API.Areas.Scheduling.Models;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Enum;

namespace API.Areas.Scheduling.Controllers
{
    [AllowAnonymous]
    public class OnlineEventController : BaseController
    {
        private readonly ITempcartService _tempcartService;
        private readonly IOnlineEventService _onlineEventService;
        private readonly IEventSchedulerService _eventSchedulerService;
        private readonly ICityRepository _cityRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IGoogleAnalyticsReportingDataService _googleAnalyticsReportingDataService;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly bool _askPreQualifierQuestionSetting;

        private readonly int _cutOffhoursbeforeEventSelection;
        private readonly int _pageSize;
        private readonly int _maxNumberOfEventstoFetch;

        public OnlineEventController(IConfigurationSettingRepository configurationSettingRepository, ITempcartService tempcartService, IOnlineEventService onlineEventService, IEventSchedulerService eventSchedulerService, ICityRepository cityRepository, IEventRepository eventRepository, ICorporateAccountRepository corporateAccountRepository,
            IGoogleAnalyticsReportingDataService googleAnalyticsReportingDataService, IEventTestRepository eventTestRepository)
        {
            _cutOffhoursbeforeEventSelection = Convert.ToInt32(configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.CutOffHourNumberforOnlineEventSelection));
            _maxNumberOfEventstoFetch = Convert.ToInt32(configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.MaxNoOfEventToShowOnline));
            _maxNumberOfEventstoFetch = _maxNumberOfEventstoFetch > 0 ? _maxNumberOfEventstoFetch : 25;
            _pageSize = _pageSize > 0 ? _pageSize : 4;

            var value = configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.AskPreQualificationQuestion);
            _askPreQualifierQuestionSetting = value.ToLower() == bool.TrueString.ToLower();

            _tempcartService = tempcartService;
            _onlineEventService = onlineEventService;
            _eventSchedulerService = eventSchedulerService;
            _cityRepository = cityRepository;
            _eventRepository = eventRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _googleAnalyticsReportingDataService = googleAnalyticsReportingDataService;
            _eventTestRepository = eventTestRepository;
        }

        [HttpGet]
        public OnlineEventListModel GetEvents([FromUri]OnlineSchedulingEventListModelFilter filter)
        {
            filter.CutOffHourstoMarkEventforOnlineSelection = _cutOffhoursbeforeEventSelection;

            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(filter.Guid);

            var model = new OnlineEventListModel { RequestValidationModel = onlineRequestValidationModel };

            if (onlineRequestValidationModel.RequestStatus != OnlineRequestStatus.Valid)
                return model;

            int totalRecords = 0;

            if (!string.IsNullOrEmpty(filter.Guid))
            {
                filter = CompleteFilter(model.RequestValidationModel.TempCart, filter);
            }
            model.Events = _onlineEventService.GetEvents(filter, _maxNumberOfEventstoFetch, _pageSize, out totalRecords);

            model.TotalEvents = totalRecords;
            model.PagingModel = new PagingModel(filter.PageNumber, _pageSize, totalRecords, null);

            if (string.IsNullOrWhiteSpace(filter.InvitationCode)) return model; ;

            var theEvent = _eventRepository.GetEventByInvitationCode(filter.InvitationCode);
            if (theEvent != null)
            {
                var account = _corporateAccountRepository.GetbyEventId(theEvent.Id);
                if (account != null && account.CheckoutPhoneNumber != null && !string.IsNullOrWhiteSpace(account.CheckoutPhoneNumber.DomesticPhoneNumber))
                {
                    model.CheckoutPhoneNumber = account.CheckoutPhoneNumber.FormatPhoneNumber;
                }
            }
            return model;
        }

        [HttpPost]
        public OnlineSelectedEventEditModel SaveSelectedEvent(OnlineSelectedEventEditModel model)
        {
            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(model.Guid);
            model.RequestValidationModel = onlineRequestValidationModel;
            if (onlineRequestValidationModel.RequestStatus != OnlineRequestStatus.Valid)
                return model;

            onlineRequestValidationModel.TempCart = _onlineEventService.SaveSelectedEvent(onlineRequestValidationModel.TempCart, model);

            return model;
        }

        private static OnlineSchedulingEventListModelFilter CompleteFilter(TempCart tempCart, OnlineSchedulingEventListModelFilter filter)
        {
            if (tempCart == null) return filter;
            if (filter == null) filter = new OnlineSchedulingEventListModelFilter();


            filter.ZipCode = !string.IsNullOrEmpty(filter.ZipCode) ? filter.ZipCode : tempCart.ZipCode;
            filter.Radius = (int?)tempCart.Radius;
            filter.EventId = tempCart.EventId.HasValue ? tempCart.EventId.Value : 0;
            filter.InvitationCode = !string.IsNullOrEmpty(filter.InvitationCode) ? filter.InvitationCode : tempCart.InvitationCode;

            return filter;
        }

        [HttpGet]
        public OnlineRequestValidationModel GetTempcart(string guid)
        {
            return _tempcartService.ValidateOnlineRequest(guid);
        }

        [HttpPost]
        public PreQualificationViewModel SavePreQualificationAnswer(PreQualificationViewModel model)
        {
            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(model.Guid);
            model.RequestValidationModel = onlineRequestValidationModel;
            if (onlineRequestValidationModel.RequestStatus != OnlineRequestStatus.Valid)
                return model;

            var tempCart = onlineRequestValidationModel.TempCart;
            if (!string.IsNullOrEmpty(tempCart.Gender) && tempCart.Gender != model.Gender && !string.IsNullOrEmpty(tempCart.TestId) && tempCart.EventId.HasValue)
            {
                Gender gender;
                System.Enum.TryParse(model.Gender, out gender);

                var testIds = tempCart.TestId.Split(',').Select(long.Parse).ToList();

                var eventTests = _eventTestRepository.GetTestsForEventByRole(tempCart.EventId.Value, (long)Roles.Customer, (long)gender);
                if (!eventTests.IsNullOrEmpty())
                {
                    testIds = eventTests.Where(x => testIds.Contains(x.Id)).Select(x => x.Id).ToList();
                    tempCart.TestId = string.Join(",", testIds);
                }

            }
            tempCart.Gender = model.Gender;
            tempCart.Dob = model.Dob;

            _tempcartService.SaveTempCart(tempCart);

            onlineRequestValidationModel.TempCart = tempCart;
            if (model.AskPreQualificationQuestion)
            {
                _onlineEventService.SaveAnswer(model);
            }
            return model;
        }

        [HttpGet]
        public PreQualificationViewModel GetPreQualificationAnswer(string guid)
        {
            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(guid);
            if (onlineRequestValidationModel.RequestStatus != OnlineRequestStatus.Valid)
                return new PreQualificationViewModel() { RequestValidationModel = onlineRequestValidationModel };

            var returnObj = _onlineEventService.GetPreQualificationAnswer(onlineRequestValidationModel.TempCart) ??
                            new PreQualificationViewModel();

            var tempCart = onlineRequestValidationModel.TempCart;

            var theEvent = _eventRepository.GetById(tempCart.EventId.Value);

            returnObj.AskPreQualificationQuestion = _askPreQualifierQuestionSetting && theEvent.AskPreQualifierQuestion;
            returnObj.RequestValidationModel = onlineRequestValidationModel;
            return returnObj;
        }

        [HttpGet]
        public OnlineSummaryModel GetOnlineSummaryModel(string guid)
        {
            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(guid);
            var model = new OnlineSummaryModel { RequestValidationModel = onlineRequestValidationModel };
            if (onlineRequestValidationModel.RequestStatus == OnlineRequestStatus.InvalidOperation || onlineRequestValidationModel.RequestStatus == OnlineRequestStatus.InValid)
                return model;

            var appliedSouceCode = _eventSchedulerService.GetSourceCodeApplied(onlineRequestValidationModel.TempCart);
            model.EventCustomerOrderSummaryModel = _eventSchedulerService.GetEventCustomerOrderSummaryModel(onlineRequestValidationModel.TempCart, appliedSouceCode);

            return model;
        }

        [HttpGet]
        public OnlineThankyouModel GetOnlineThankyouModel(string guid)
        {
            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(guid);
            var model = new OnlineThankyouModel { RequestValidationModel = onlineRequestValidationModel };
            if (onlineRequestValidationModel.RequestStatus == OnlineRequestStatus.InvalidOperation || onlineRequestValidationModel.RequestStatus == OnlineRequestStatus.InValid)
                return model;

            var tempCart = onlineRequestValidationModel.TempCart;
            var appliedSouceCode = _eventSchedulerService.GetSourceCodeApplied(tempCart);
            model.EventCustomerOrderSummaryModel = _eventSchedulerService.GetEventCustomerOrderSummaryModel(tempCart, appliedSouceCode);
            model.GoogleAnalyticsReportingDataModel = _googleAnalyticsReportingDataService.GetGoogleAnalyticsViewModel(tempCart);

            return model;
        }

        [HttpGet]
        public List<string> GetCityByPrefixText(string text)
        {
            return _cityRepository.GetbyPrefixTest(text).Select(m => m.Name).Distinct().ToList();
        }

        [HttpPost]
        public bool UpdateExitUrl(ExitUrlEditModel model)
        {
            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(model.Guid);
            var tempCart = onlineRequestValidationModel.TempCart;
            tempCart.ExitPage = model.PageUrl;
            tempCart.IPAddress = HttpContext.Current.Request.UserHostAddress;
            tempCart.Browser = HttpContext.Current.Request.Browser.Browser +
                               HttpContext.Current.Request.Browser.MajorVersion;
            _tempcartService.SaveTempCart(tempCart);

            return true;
        }

        [HttpGet]
        public PreQualificationViewModel UpdateUserPrefrenceWithPrequalificationQuestion(string guid)
        {
            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(guid);
            var tempCart = onlineRequestValidationModel.TempCart;
            var model = new PreQualificationViewModel();
            if (onlineRequestValidationModel.RequestStatus != OnlineRequestStatus.Valid)
                model.RequestValidationModel = onlineRequestValidationModel;

            model = _onlineEventService.GetPreQualificationAnswer(tempCart);
            model.RequestValidationModel = onlineRequestValidationModel;
            model.AgreedWithPrequalificationQuestion = true;
            if (tempCart.EventId != null)
                _onlineEventService.SaveAnswer(model);

            return new PreQualificationViewModel();
        }

        [HttpGet]
        public PreQualificationViewModel UpdateUserPrefrenceSkip(string guid)
        {
            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(guid);
            var tempCart = onlineRequestValidationModel.TempCart;
            var model = new PreQualificationViewModel();
            if (onlineRequestValidationModel.RequestStatus != OnlineRequestStatus.Valid)
                model.RequestValidationModel = onlineRequestValidationModel;

            model = _onlineEventService.GetPreQualificationAnswer(tempCart) ?? new PreQualificationViewModel();
            model.RequestValidationModel = onlineRequestValidationModel;
            model.SkipPreQualificationQuestion = true;
            if (tempCart.EventId != null)
                _onlineEventService.SaveAnswer(model);

            return new PreQualificationViewModel();
        }
    }
}
