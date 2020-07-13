using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Impl;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Filters;
using FluentValidation;


namespace Falcon.App.UI.Areas.Medical.Controllers
{
    public class AttestationController : Controller
    {
        private readonly IMolinaAttestationRepository _molinaAttestationRepository;
        private readonly IWellmedAttestationService _wellmedAttestationService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ISettings _settings;

        public AttestationController(ISettings settings, IMolinaAttestationRepository molinaAttestationRepository, IWellmedAttestationService wellmedAttestationService, ICustomerRepository customerRepository,
            IEventRepository eventRepository)
        {
            _molinaAttestationRepository = molinaAttestationRepository;
            _wellmedAttestationService = wellmedAttestationService;
            _customerRepository = customerRepository;
            _eventRepository = eventRepository;
            _settings = settings;
        }
        [RoleBasedAuthorize]
        public ActionResult Edit(long eventCustomerResultId, long accountId, long customerId, long eventId)
        {
            if (accountId == _settings.WellmedAccountId)
            {
                return RedirectToAction("WellMed", new { eventCustomerResultId, accountId, customerId, eventId });
            }

            if (accountId == _settings.MolinaAccountId)
            {
                return RedirectToAction("Molina", new { eventCustomerResultId, accountId, customerId, eventId });
            }

            return View();
        }
        [RoleBasedAuthorize]
        public ActionResult View(long eventCustomerResultId, long accountId, long customerId, long eventId)
        {
            if (accountId == _settings.WellmedAccountId)
            {
                return RedirectToAction("WellMedView", new { eventCustomerResultId, accountId, customerId, eventId });
            }
            if (accountId == _settings.MolinaAccountId)
            {
                return RedirectToAction("MolinaView", new { eventCustomerResultId, accountId, customerId, eventId });
            }

            return View();
        }
        [RoleBasedAuthorize]
        public ActionResult WellMed(long eventCustomerResultId, long accountId, long customerId, long eventId)
        {
            var model = new WellMedAttestationListModel();
            var attestations = _wellmedAttestationService.GetbyEventCustumerResultId(eventCustomerResultId);
            if (attestations != null && attestations.Any())
            {
                model.Attestations = attestations;
        }
            model.EventCustomerResultId = eventCustomerResultId;
            model.CustomerId = customerId;
            model.EventId = eventId;
            GetDetails(model);
            return View(model);
        }

        public ActionResult WellMedView(long eventCustomerResultId, long accountId, long customerId, long eventId, bool print = false)
        {
            var model = new WellMedAttestationListModel();
            model.EventCustomerResultId = eventCustomerResultId;
            model.CustomerId = customerId;
            model.EventId = eventId;
            var attestations = _wellmedAttestationService.GetbyEventCustumerResultId(eventCustomerResultId);

            if (attestations != null && attestations.Any())
            {
                model.Attestations = attestations;
            }
            GetDetails(model);
            model.LayoutForPrint = print;

            return View(model);
        }

        private void GetDetails(dynamic model)
        {
            var customer = _customerRepository.GetCustomer(model.CustomerId);
            if (customer != null)
            {
                model.CustomerName = customer.NameAsString;
                model.CustomerDob = customer.DateOfBirth;
            }
            var theEvent = _eventRepository.GetById(model.EventId);
            if (theEvent != null)
            {
                model.EventDate = theEvent.EventDate;
            }
        }

        [HttpPost]
        public ActionResult WellMed(WellMedAttestationListModel model, bool saveAndContinue)
        {
            var attestationValidator = IoC.Resolve<WellMedAttestationViewModelValidator>();
            var invalidattestationList = new List<WellMedAttestationViewModel>();
            foreach (var attestation in model.Attestations)
            {
                var result = ValidateModel(attestationValidator, attestation);
                if (!string.IsNullOrEmpty(result))
                {
                    attestation.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(result);
                    invalidattestationList.Add(attestation);
                }
            }
            if (!invalidattestationList.Any())
            {
                _wellmedAttestationService.Delete(model.EventCustomerResultId);
                foreach (var attestation in model.Attestations)
                {
                    try
                    {
                        using (var scope = new TransactionScope())
                        {
                            _wellmedAttestationService.Save(attestation);
                            scope.Complete();
                        }
                    }
                    catch (Exception ex)
                    {
                        attestation.FeedbackMessage =
                            FeedbackMessageModel.CreateFailureMessage("System Error:" + ex.Message);
                        invalidattestationList.Add(attestation);
                    }
                }
            }
            else
            {
                GetDetails(model);
                return View(model);
            }
            return !saveAndContinue ? Redirect("/Medical/Results/ResultStatusList?EventId=" + model.EventId) : null;
        }

        private static string ValidateModel<T>(IValidator<T> validator, T objectToValidate)
        {
            var result = validator.Validate(objectToValidate);
            if (result.IsValid) return string.Empty;

            var propertyNames = result.Errors.Select(e => e.PropertyName).Distinct();
            var htmlString = propertyNames.Aggregate("", (current, property) => current + (result.Errors.Where(e => e.PropertyName == property).FirstOrDefault().ErrorMessage + ",&nbsp;&nbsp;"));

            if (htmlString.Length > 0)
            {
                htmlString = htmlString.Substring(0, htmlString.Length - 13);
                return htmlString;
            }
            return string.Empty;
        }
        [RoleBasedAuthorize]
        public ActionResult Molina(long eventCustomerResultId, long accountId, long customerId, long eventId)
        {
            var lstMolinaAttestation = _molinaAttestationRepository.GetbyEventCustumerResultId(eventCustomerResultId);

            var molinaAttestationListViewModel = new MolinaAttestationListModel { EventCustomerResultId = eventCustomerResultId, EventId = eventId, CustomerId = customerId };
            GetDetails(molinaAttestationListViewModel);

            if (!lstMolinaAttestation.Any()) return View(molinaAttestationListViewModel);

            molinaAttestationListViewModel.Attestations = new List<MolinaAttestationViewModel>();

            foreach (var item in (List<MolinaAttestation>)lstMolinaAttestation)
            {

                if (item.StatusId != (long)MolinaAttestationStatus.Resolved)
                {
                    item.DateResolved = null;
                }
                if (item.StatusId != (long)MolinaAttestationStatus.UnabletodetermineDiagnosis)
                {
                    item.WhyNoDiagnosis = "";
                }
                var molinaAttestationViewModel = Mapper.Map<MolinaAttestation, MolinaAttestationViewModel>(item);
                molinaAttestationListViewModel.Attestations.Add(molinaAttestationViewModel);
            }
            return View(molinaAttestationListViewModel);
        }

        [HttpPost]
        public ActionResult Molina(MolinaAttestationListModel model, bool saveAndContinue)
        {
            var attestationValidator = IoC.Resolve<MolinaAttestationViewModelValidator>();
            var invalidattestationList = new List<MolinaAttestationViewModel>();

            _molinaAttestationRepository.Delete(model.EventCustomerResultId);
            foreach (var item in model.Attestations)
            {
                var result = ValidateModel(attestationValidator, item);
                if (string.IsNullOrEmpty(result))
                {
                    try
                    {
                        using (var scope = new TransactionScope())
                        {
                            if (item.StatusId != (long)MolinaAttestationStatus.Resolved)
                            {
                                item.DateResolved = null;
                            }
                            if (item.StatusId != (long)MolinaAttestationStatus.UnabletodetermineDiagnosis)
                            {
                                item.WhyNoDiagnosis = "";
                            }
                            var molinaAttestation = Mapper.Map<MolinaAttestationViewModel, MolinaAttestation>(item);
                            if (!_molinaAttestationRepository.Save(molinaAttestation))
                            {
                                invalidattestationList.Add(item);
                            }
                            scope.Complete();
                        }
                    }
                    catch (Exception ex)
                    {
                        item.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error:" + ex.Message);
                        invalidattestationList.Add(item);
                    }
                }
                else
                {
                    item.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(result);
                    invalidattestationList.Add(item);
                }
            }


            if (invalidattestationList.Count > 0)
            {
                //  model.Attestations = invalidattestationList;
                GetDetails(model);
                return View(model);
            }
            if (!saveAndContinue)
            {
                return Redirect("/Medical/Results/ResultStatusList?EventId=" + model.EventId);
            }
            return View(model);
        }

        public ActionResult MolinaView(long eventCustomerResultId, long accountId, long customerId, long eventId, bool print = false)
        {
            var lstMolinaAttestation = _molinaAttestationRepository.GetbyEventCustumerResultId(eventCustomerResultId);
            var molinaAttestationListViewModel = new MolinaAttestationListModel
            {
                EventCustomerResultId = eventCustomerResultId,
                EventId = eventId,
                CustomerId = customerId
            };
            if (lstMolinaAttestation != null && lstMolinaAttestation.Any())
            {
                var lstMolinaAttestationViewModel = new List<MolinaAttestationViewModel>();
                foreach (var item in (List<MolinaAttestation>)lstMolinaAttestation)
                {
                    if (item.StatusId != (long)MolinaAttestationStatus.Resolved)
                    {
                        item.DateResolved = null;
                    }
                    if (item.StatusId != (long)MolinaAttestationStatus.UnabletodetermineDiagnosis)
                    {
                        item.WhyNoDiagnosis = "";
                    }
                    var molinaAttestationViewModel = Mapper.Map<MolinaAttestation, MolinaAttestationViewModel>(item);


                    lstMolinaAttestationViewModel.Add(molinaAttestationViewModel);
                }
                molinaAttestationListViewModel.Attestations = lstMolinaAttestationViewModel;
            }
            GetDetails(molinaAttestationListViewModel);
            molinaAttestationListViewModel.ModelForPrint = print;
            return View(molinaAttestationListViewModel);
        }
    }
}
