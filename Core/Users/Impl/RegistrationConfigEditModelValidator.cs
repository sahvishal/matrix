using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.Impl;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Falcon.App.Core.Users.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<RegistrationConfigEditModel>))]
    public class RegistrationConfigEditModelValidator : AbstractValidator<RegistrationConfigEditModel>
    {
        private readonly ICorporateAccountRepository _corporateAccountRepository;

        public RegistrationConfigEditModelValidator(ICorporateAccountRepository corporateAccountRepository)
        {
            _corporateAccountRepository = corporateAccountRepository;
            RuleFor(x => x.DefaultPackages).NotNull().WithMessage("Please select atleast one package").NotEmpty().WithMessage("Please select atleast one package");

            RuleFor(x => x.Tag).Length(2, 20).WithMessage("Required, 2-20 chars").Must((x, accountCode) => CustomerTagIsUnique(accountCode, x.AccountId)).WithMessage("Already in use");

            RuleFor(x => x.AppointmentConfirmationMailTemplateId).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").GreaterThan(0).WithMessage("Required").When(x => x.SendAppointmentMail);

            RuleFor(x => x.AppointmentReminderMailTemplateId).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").GreaterThan(0).WithMessage("Required").When(x => x.SendAppointmentMail);

            RuleFor(x => x.CheckoutPhoneNumber).Must((x, y) => PhoneNumber.ToNumber(y.DomesticPhoneNumber.ToString()).Length == 10).WithMessage("length must be 10").When(x => x.CheckoutPhoneNumber != null && string.IsNullOrWhiteSpace(PhoneNumber.ToNumber(x.CheckoutPhoneNumber.ToString())));

            RuleFor(x => x.MemberId).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").Must((x, y) => y).WithMessage("Required").When(x => x.AllowVerifiedMemebersOnly);
            RuleFor(x => x.DateOfBirth).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").Must((x, y) => y).WithMessage("Required").When(x => x.AllowVerifiedMemebersOnly);
            RuleFor(x => x.ClinicalQuestionTemplateId).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").GreaterThan(0).WithMessage("Required").When(x => x.AskClinicalQuestions);
            RuleFor(x => x.NumberOfDays).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").GreaterThan(0).WithMessage("Required").When(x => x.BookPcpAppointment);
            RuleFor(x => x.SurveyPdf).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").Must((x, y) => y != null && !string.IsNullOrEmpty(y.Caption)).WithMessage("Required").When(x => x.CaptureSurvey);

            RuleFor(x => x.GiftCardAmount).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").GreaterThan(0).WithMessage("must Greater Than 0").Must(x => x.HasValue && ValidDecimalPoints(x.Value)).WithMessage("only two decimal points allowed").When(x => x.AttachGiftCard);

            RuleFor(x => x.DefaultTests).NotNull().WithMessage("Please select atleast one test").NotEmpty().WithMessage("Please select atleast one test");
            RuleFor(x => x.LockEventDaysCount).NotNull().WithMessage("Please select days before event is locked").NotEmpty().WithMessage("Please select days before event is locked").GreaterThan(0).WithMessage("Please select days before event is locked").When(x => x.LockEvent);
            RuleFor(x => x.AccountAdditionalFields).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").Must(AccountAdditionalFieldsUnique).WithMessage("All field should be unique.").When(x => x.IsAdditionalField);

            RuleFor(x => x.MaxSmsCount).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").GreaterThan(0).WithMessage("Greater than 0").When(x => x.EnableSms);
            RuleFor(x => x.ConfirmationSmsTemplateId).GreaterThan(0).WithMessage("Required").When(x => x.EnableSms);
            RuleFor(x => x.ReminderSmsTemplateId).GreaterThan(0).WithMessage("Required").When(x => x.EnableSms);
            RuleFor(x => x.AccountCheckoutPhoneNumbers).Must(AccountCheckoutPhoneNumberValidation).WithMessage("Required");
            RuleFor(x => x.MaxAttempt).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").GreaterThan(0).WithMessage("Greater than 0").When(x => x.IsMaxAttemptPerHealthPlan && x.IsHealthPlan);

            RuleFor(x => x.AccountCallQueueSettings).Must(ValidateAccountCallQueueSettings).WithMessage("No.Of Days and Max Attempts must be greater than 0 and less than 100.").When(x => x.IsHealthPlan);

            RuleFor(x => x.CallCenterScriptPdf).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").Must((x, y) => y != null && !string.IsNullOrEmpty(y.Caption)).WithMessage("Required").When(x => x.ShowCallCenterScript);
            RuleFor(x => x.ConfirmationScriptPdf).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").Must((x, y) => y != null && !string.IsNullOrEmpty(y.Caption)).WithMessage("Required").When(x => x.ShowCallCenterScript);

            RuleFor(x => x.EventConfirmationBeforeDays).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").When(x => x.IsHealthPlan);
            RuleFor(x => x.ConfirmationBeforeAppointmentMinutes).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").When(x => x.IsHealthPlan);
            RuleFor(x => x.AccountCallCenterOrganization).NotNull().WithMessage("Please select at least one organization.").NotEmpty().WithMessage("Please select at least one organization.").When(x => x.RestrictHealthPlanData);

            RuleFor(x => x.ClientId).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").When(x => x.SendPatientDataToAces);
            RuleFor(x => x.ClientId).Length(1, 4).WithMessage("Max Length can be 4").Matches(@"^[a-zA-Z0-9\x20]+$").WithMessage("Only alphanumerics with spaces are allowed").When(x => !string.IsNullOrEmpty(x.ClientId) && x.SendPatientDataToAces);

            //RuleFor(x => x.CheckListPdf).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").Must((x, y) => y != null && !string.IsNullOrEmpty(y.Caption)).WithMessage("Required").When(x => x.PrintCheckList);

            //RuleFor(x => x.InboundCallScriptPdf).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").Must((x, y) => y != null && !string.IsNullOrEmpty(y.Caption)).WithMessage("Required").When(x => x.ShowCallCenterScript);

            RuleFor(x => x.AcesClientShortName).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").When(x => x.SendPatientDataToAces);

            RuleFor(x => x.AcesToHipIntakeShortName).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").When(x => x.AcesToHipIntake);

            RuleFor(x => x.AcesToHipIntakeShortName).Length(2, 50).WithMessage("Required, 2-50 chars").Must((x, shortName) => AcesToHipIntakeShortNameIsUnique(x.AccountId, shortName)).When(x => x.AcesToHipIntake).WithMessage("Already in use");

            RuleFor(x => x.ChatStartDate).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").Must((x, chatStartDate) => chatStartDate.HasValue && chatStartDate >= DateTime.Today.AddDays(1)).WithMessage("Only future Date accepted.").When(x => x.QuestionnaireType == QuestionnaireType.ChatQuestionnaire && !x.HasChatStartDate);
        }

        private bool ValidateAccountCallQueueSettings(RegistrationConfigEditModel registrationConfigEditModel, IEnumerable<AccountCallQueueSettingEditModel> accountCallQueueSettings)
        {
            var isValid = true;
            foreach (var accountCallQueueSetting in accountCallQueueSettings)
            {
                if (!accountCallQueueSetting.NoOfDays.HasValue || accountCallQueueSetting.NoOfDays <= 0)
                {
                    if (registrationConfigEditModel.IsMaxAttemptPerHealthPlan && accountCallQueueSetting.SuppressionTypeId == (long)CallQueueSuppressionType.MaxAttempts)
                        continue;

                    isValid = false;
                }

                if (!accountCallQueueSetting.NoOfDays.HasValue || accountCallQueueSetting.NoOfDays >= 100)
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        private bool ValidDecimalPoints(decimal giftAmmount)
        {
            return (decimal.Truncate(giftAmmount * 100) / 100) > 0;
        }

        private bool CustomerTagIsUnique(string customerTag, long excludedAccountId)
        {
            return !_corporateAccountRepository.CustomerTagExists(excludedAccountId, customerTag);
        }
        private bool AccountAdditionalFieldsUnique(IEnumerable<AccountAdditionalFieldsEditModel> accountAdditionalEditModel)
        {
            if (accountAdditionalEditModel != null)
            {
                List<string> DisplayNameList = new List<string>();
                foreach (var item in accountAdditionalEditModel)
                {
                    if (!DisplayNameList.Contains(item.DisplayName))
                        DisplayNameList.Add(item.DisplayName);
                    else
                        return false;

                }
            }
            return true;
        }

        private bool AccountCheckoutPhoneNumberValidation(IEnumerable<AccountCheckoutPhoneNumberEditModel> accountCheckoutPhoneNumbers)
        {
            if (accountCheckoutPhoneNumbers != null)
            {
                foreach (var item in accountCheckoutPhoneNumbers)
                {
                    if (string.IsNullOrEmpty(item.CheckoutPhoneNumber))
                        return false;
                }
            }
            return true;
        }

        private bool AcesToHipIntakeShortNameIsUnique(long excludedAccountId, string acesToHipIntakeShortName)
        {
            return !_corporateAccountRepository.AcesToHipIntakeShortNameExists(excludedAccountId, acesToHipIntakeShortName);
        }
    }
}