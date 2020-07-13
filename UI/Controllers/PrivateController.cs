using System;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.UI.Controllers
{
    public class PrivateController : Controller
    {
        //
        // GET: /PrivateEvents/

        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ITempCartRepository _tempCartRepository;
        private readonly ISettings _settings;
        private readonly IEventRepository _eventRepository;
        private readonly ILogger _logger;
        public PrivateController(ICorporateAccountRepository corporateAccountRepository, ICustomerRepository customerRepository, ITempCartRepository tempCartRepository, ISettings settings, ILogManager logManager, IEventRepository eventRepository)
        {
            _corporateAccountRepository = corporateAccountRepository;
            _customerRepository = customerRepository;
            _tempCartRepository = tempCartRepository;
            _settings = settings;
            _eventRepository = eventRepository;
            _logger = logManager.GetLogger<PrivateController>();
        }

        public ActionResult Index(AccountVerificationEditModel model)
        {
            model = model ?? new AccountVerificationEditModel();
            model.CheckoutPhoneNumber = _settings.PhoneTollFree;
            try
            {
                CorporateAccount corporateAccount = null;
                if (!string.IsNullOrWhiteSpace(model.UrlSuffix))
                {
                    corporateAccount = _corporateAccountRepository.GetByUrlSiffix(model.UrlSuffix);
                }
                else if (!string.IsNullOrWhiteSpace(model.InvitationCode))
                {
                    var theEvent = _eventRepository.GetEventByInvitationCode(model.InvitationCode);
                    if (theEvent != null)
                    {
                        corporateAccount = _corporateAccountRepository.GetbyEventId(theEvent.Id);
                    }
                }

                if (corporateAccount != null)
                {
                    model.Content = corporateAccount.Content;
                    model.AllowVerifiedMembersOnly = corporateAccount.AllowVerifiedMembersOnly;
                    model.CheckoutPhoneNumber = (corporateAccount.CheckoutPhoneNumber != null && !string.IsNullOrWhiteSpace(corporateAccount.CheckoutPhoneNumber.DomesticPhoneNumber)) ? corporateAccount.CheckoutPhoneNumber.FormatPhoneNumber : _settings.PhoneTollFree;
                }
            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("While accessing private\\Index Message: {0} \n Stack Trace: {1} ", exception.Message, exception.StackTrace));
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult PrivateSearch(string invitationCode, string zipcode, long? customerId = null, string corpCode = "")
        {
            //string url;

            if (customerId.HasValue && customerId.Value > 0)
            {
                var guid = Guid.NewGuid().ToString();

                var tempCart = new TempCart
                {
                    CustomerId = customerId,
                    ZipCode = zipcode,
                    IsExistingCustomer = true,
                    InvitationCode = invitationCode,
                    EntryPage = Request.UrlReferrer.PathAndQuery,
                    ExitPage = Request.UrlReferrer.PathAndQuery,
                    Guid = guid,
                    DateCreated = DateTime.Now,
                    CorpCode = corpCode,
                    Version = 1
                };

                SaveTempCart(tempCart);

                //url = "/Scheduling/Online/LocationAndAppointmentSlot?guid=" + guid;
                return RedirectToAction("LocationAndAppointmentSlot", "Online", new { Area = "Scheduling", guid = guid });
            }
            else
            {
                //url = "/Scheduling/Online/LocationAndAppointmentSlot?InvitationCode=" + invitationCode + "&ZipCode=" + zipcode;
                return RedirectToAction("LocationAndAppointmentSlot", "Online", new { Area = "Scheduling", InvitationCode = invitationCode, ZipCode = zipcode });

            }

            //return Redirect(url);
        }

        public ActionResult AccountMemberVerificationForm(string urlSuffix, string invitationCode = "")
        {
            var corporateAccount = _corporateAccountRepository.GetByUrlSiffix(urlSuffix);
            var model = GetFormModel(corporateAccount);

            model.UrlSuffix = urlSuffix;
            model.InvitationCode = invitationCode;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AccountMemberVerificationForm(AccountVerificationEditModel model)
        {
            if (!ModelState.IsValid) return PartialView(model);
            var isCustomerVerified = _customerRepository.IsCustomerVerified(model);

            if (isCustomerVerified)
            {
                var customer = _customerRepository.GetCustomer(model.CustomerId);
                model.FirstName = customer.Name.FirstName;
                model.LastName = customer.Name.LastName;
                model.DateOfBirth = customer.DateOfBirth.HasValue ? customer.DateOfBirth.Value : (DateTime?)null;
                model.CustomerEmail = customer.Email.ToString();
                model.MemberId = customer.InsuranceId;
                model.ZipCode = customer.Address.ZipCode.Zip;
            }


            model.FeedbackMessage = isCustomerVerified
                ? FeedbackMessageModel.CreateSuccessMessage("Verification Success")
                : FeedbackMessageModel.CreateFailureMessage(string.Format("Unable to verify your information. Please call us as {0} for any queries.", _settings.PhoneTollFree));

            return PartialView(model);
        }

        private AccountVerificationEditModel GetFormModel(CorporateAccount corporateAccount)
        {
            return new AccountVerificationEditModel
            {
                CustomerEmailVerification = corporateAccount.CustomerEmail,
                FirstNameVerification = corporateAccount.FirstName,
                LastNameVerification = corporateAccount.LastName,
                MemberIdVerification = corporateAccount.MemberId,
                ZipCodeVerification = corporateAccount.ZipCode,
                DateOfBirthVerification = corporateAccount.DateOfBirth,
                MemberIdLabel = corporateAccount.MemberIdLabel,
                Tag = corporateAccount.Tag
            };
        }

        private void SaveTempCart(TempCart tempCart)
        {
            tempCart.IPAddress = Request.UserHostAddress;
            tempCart.Browser = Request.Browser.Type;

            if (tempCart.Id > 0)
                tempCart.DateModified = DateTime.Now;
            else
            {
                tempCart.DateCreated = DateTime.Now;
            }

            _tempCartRepository.Save(tempCart);

        }
    }
}
