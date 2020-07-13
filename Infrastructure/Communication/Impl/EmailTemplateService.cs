using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Communication.ViewModels;
using HtmlAgilityPack;
namespace Falcon.App.Infrastructure.Communication.Impl
{
    [DefaultImplementation]
    public class EmailTemplateService : IEmailTemplateService
    {

        private readonly IEmailTemplateRepository _emailTemplateRepository;
        private readonly IEmailTemplateEditModelFactory _emailTemplateEditModelFactory;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly IEmailTemplateMacroRepository _emailTemplateMacroRepository;
        private readonly ITemplateMacroRepository _templateMacroRepository;
        private readonly INotificationTypeRepository _notificationTypeRepository;
        private readonly IEmailTemplateFormatter _emailTemplateFormatter;
        private readonly IPhoneNotificationModelsFactory _phoneNotificationModelsFactory;

        public EmailTemplateService(IEmailTemplateRepository emailTemplateRepository, IEmailTemplateEditModelFactory emailTemplateEditModelFactory,
            IEmailNotificationModelsFactory emailNotificationModelsFactory, IEmailTemplateMacroRepository emailTemplateMacroRepository,
            ITemplateMacroRepository templateMacroRepository, INotificationTypeRepository notificationTypeRepository, IEmailTemplateFormatter emailTemplateFormatter,
            IPhoneNotificationModelsFactory phoneNotificationModelsFactory)
        {
            _emailTemplateEditModelFactory = emailTemplateEditModelFactory;
            _emailTemplateRepository = emailTemplateRepository;

            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _emailTemplateMacroRepository = emailTemplateMacroRepository;
            _templateMacroRepository = templateMacroRepository;
            _notificationTypeRepository = notificationTypeRepository;
            _emailTemplateFormatter = emailTemplateFormatter;
            _phoneNotificationModelsFactory = phoneNotificationModelsFactory;
        }

        public EmailTemplateEditModel GetModel(long id)
        {
            var emailTemplate = _emailTemplateRepository.GetById(id);
            return _emailTemplateEditModelFactory.Edit(emailTemplate);
        }

        public EmailTemplateEditModel CompleteModel(EmailTemplateEditModel model)
        {
            return _emailTemplateEditModelFactory.Complete(model);
        }

        public string ReplaceMacroswithCodeString(string body, long emailTemplateId)
        {
            return _emailTemplateEditModelFactory.ReplaceMacroswithCodeString(body, emailTemplateId);
        }

        public EmailTemplateEditModel Save(EmailTemplateEditModel model, long orgRoleUserId)
        {

            var inDb = _emailTemplateRepository.GetById(model.Id);

            if (model.TemplateType == (long)TemplateType.Sms)
                model.Body = ConvertToPlainText(model.Body).Trim();

            var emailTemplate = _emailTemplateEditModelFactory.Edit(model, inDb, orgRoleUserId);

            if (model.IsEditable)
            {
                _emailTemplateRepository.Save(emailTemplate);
            }
            return GetModel(emailTemplate.Id);
        }

        private string ConvertToPlainText(string body)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(body);
            return doc.DocumentNode.FirstChild.InnerText;
        }

        public bool IsEmailTemplateValid(long emailTemplateId, string body, long notificationTypeId)
        {

            var emailTemplateAlias = string.Empty;
            if (emailTemplateId > 0)
            {
                var emailTemplate = _emailTemplateRepository.GetById(emailTemplateId);
                emailTemplateAlias = emailTemplate.Alias;
            }

            try
            {
                var content = LoadTemplate(emailTemplateAlias, notificationTypeId, body);
                return !string.IsNullOrEmpty(content);
            }
            catch (Exception) // Need to see type of exception
            {
                return false;
            }
        }

        public EmailTemplateEditModel CreateNewTemplate(long notificationTypeId)
        {
            var templateMacros = GetMacrosForNotificationTypeId(notificationTypeId);

            var model = new EmailTemplateEditModel
            {

                TemplateMacros = templateMacros.Select(tm => tm.IdentifierName).OrderBy(t => t),
                TemplateType = (long)TemplateType.Email,
                NotificationTypeId = notificationTypeId,
            };

            return model;
        }

        public EmailTemplateEditModel SaveNewTemplate(EmailTemplateEditModel model, long orgRoleUserId)
        {
            if (model.TemplateType == (long)TemplateType.Sms)
                model.Body = ConvertToPlainText(model.Body).Trim();

            var templateMacros = GetMacrosForNotificationTypeId(model.NotificationTypeId);
            var list = new List<EmailTemplateMacro>();

            var emailTemplate = _emailTemplateEditModelFactory.Create(model, orgRoleUserId, templateMacros);

            emailTemplate = _emailTemplateRepository.Save(emailTemplate);
            var sequence = 1;
            templateMacros = templateMacros.OrderBy(x => x.Sequence);

            foreach (var templateMacro in templateMacros)
            {
                list.Add(new EmailTemplateMacro
                {
                    EmailTemplateId = (int)emailTemplate.Id,
                    TemplateMacroId = templateMacro.Id,
                    Sequence = sequence++,
                    ParameterValue = templateMacro.ParameterValue
                });
            }

            _emailTemplateMacroRepository.SaveEmailTemplateMacros(list);

            return GetModel(emailTemplate.Id);
        }

        public IEnumerable<TemplateMacro> GetMacrosForNotificationTypeId(long notificationTypeId)
        {
            return _templateMacroRepository.GetbyEmailTemplateNotificationTypeId(notificationTypeId);
        }

        public string ReplaceCodeStringwithMacroParameterValueForNotificationTypeId(string body, long notificationTypeId)
        {
            var templateMacros = _templateMacroRepository.GetbyEmailTemplateNotificationTypeId(notificationTypeId);

            return templateMacros.Aggregate(body, (current, templateMacro) => current.Replace(templateMacro.IdentifierUiString, templateMacro.CodeString));

        }

        public string LoadTemplate(string emailTemplateAlias, long notificationTypeId, string body = null)
        {
            var content = string.Empty;

            var notificationtype = _notificationTypeRepository.GetById(notificationTypeId);
            // No binding exisits between Template and Notification Type. As discussed, using emailTemplateAlias as notification Type
            switch (notificationtype.NotificationTypeAlias)
            {
                case NotificationTypeAlias.ScreeningReminderMail:
                case NotificationTypeAlias.AppointmentConfirmationWithEventDetails:
                    var appointmentConfModel = _emailNotificationModelsFactory.GetDummyDataAppointmentConfirmationModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, appointmentConfModel);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;

                case NotificationTypeAlias.AppointmentBookedInTwentyFourHours:
                    var appointmentbookedModel = _emailNotificationModelsFactory.GetDummyAppointmentBookedInTwentyFourHoursModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, appointmentbookedModel);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;

                case NotificationTypeAlias.LoginIssuesSendUsername:
                case NotificationTypeAlias.EmployeeWelcomeEmailWithUsername:
                case NotificationTypeAlias.CustomerWelcomeEmailWithUsername:
                    var welcomWithUNameModel = _emailNotificationModelsFactory.GetDummyDataWelcomeWithUserNameNotificationModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, welcomWithUNameModel);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;

                case NotificationTypeAlias.LoginIssuesSendResetMail:
                case NotificationTypeAlias.EmployeeWelcomeEmailWithResetMail:
                case NotificationTypeAlias.CustomerWelcomeEmailWithResetMail:
                    var welcomeWithPasswordModel = _emailNotificationModelsFactory.GetDummyDataWelcomeWithPasswordNotificationModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, welcomeWithPasswordModel);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;

                case NotificationTypeAlias.ResetMail:
                    var resetPasswordModel = _emailNotificationModelsFactory.GetDummyDataResetModificationModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, resetPasswordModel);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;

                case NotificationTypeAlias.GiftCertificateAcknowledgmentEmail:
                case NotificationTypeAlias.GiftCertificateClaimCodeEmail:
                    var giftCertificateModel = _emailNotificationModelsFactory.GetDummyDataGiftCertificateNotificationModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, giftCertificateModel);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;

                case NotificationTypeAlias.CriticalCustomer:
                    var criticalCustomer = _emailNotificationModelsFactory.GetDummyCriticalCustomerNotificationModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, criticalCustomer);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.PriorityInQueueCustomer:
                    var priorityInQueueCustomer = _emailNotificationModelsFactory.GetDummyPriorityInQueueNotificationModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, priorityInQueueCustomer);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;

                case NotificationTypeAlias.AmountRefundNotification:
                    var amountRefund = _emailNotificationModelsFactory.GetDummyAmountRefundNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, amountRefund);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;

                case NotificationTypeAlias.EvaluationReminder:
                    var evalReminder = _emailNotificationModelsFactory.GetDummyEvaluationReminderNotificationModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, evalReminder);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;

                case NotificationTypeAlias.ResultsReady:
                    var resultReady = _emailNotificationModelsFactory.GetDummyResultReadyModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, resultReady);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;

                case NotificationTypeAlias.ThirtyDaysFromAnnualAnniversaryEmailer:
                case NotificationTypeAlias.OneWeekAfter30DayReminder:
                case NotificationTypeAlias.TwoWeekAfter30DayReminder:
                case NotificationTypeAlias.OnOneYearAnniversaryDate:
                    var annualReminder = _emailNotificationModelsFactory.GetDummyAnnualReminderNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, annualReminder);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;

                case NotificationTypeAlias.SurveyEmailNotification:
                    var surveyNotification = _emailNotificationModelsFactory.GetDummySurveyNotificationModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, surveyNotification);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.OneDayAfterProspectCreationFollowup:
                case NotificationTypeAlias.OneWeekAfterProspectCreationFollowup:
                case NotificationTypeAlias.TwoWeekAfterProspectCreationFollowup:
                case NotificationTypeAlias.ThreeWeekAfterProspectCreationFollowup:
                case NotificationTypeAlias.FourWeekAfterProspectCreationFollowup:
                case NotificationTypeAlias.FiveWeekAfterProspectCreationFollowup:
                case NotificationTypeAlias.SixWeekAfterProspectCreationFollowup:
                case NotificationTypeAlias.SevenWeekAfterProspectCreationFollowup:
                    var prospectNotification = _emailNotificationModelsFactory.GetDummyProspectCustomerFollowupNotificationViewModel();
                    content = this.GetEmailMessagewithdummyData(emailTemplateAlias, body, prospectNotification);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.EventFillingNotification:
                    var emailFilling = _emailNotificationModelsFactory.GetDummyEventFillingNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, emailFilling);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.PurchaseShippingNotification:
                    var purchaseShipping = _emailNotificationModelsFactory.GetDummyPurchaseShippingNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, purchaseShipping);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.UrgentCustomer:
                    var urgentCustomer = _emailNotificationModelsFactory.GetDummyUrgentCustomerNotificationModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, urgentCustomer);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.TestUpsellNotification:
                    var testUpsellNotification = _emailNotificationModelsFactory.GetDummyTestUpsellNotificationModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, testUpsellNotification);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.EventResultReadyNotification:
                    var eventResultReadyNotification = _emailNotificationModelsFactory.GetDummyEventResultReadyNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, eventResultReadyNotification);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.KynFirstNotification:
                case NotificationTypeAlias.KynSecondNotification:
                    var kynNotification = _emailNotificationModelsFactory.GetDummyKynNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, kynNotification);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case EmailTemplateAlias.AppointmentReminder:
                    var appointmentReminder = _phoneNotificationModelsFactory.GetDummyScreeningReminderSmsNotificationModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, appointmentReminder);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.AppointmentConfirmation:
                    var appointmentConfirmation = _phoneNotificationModelsFactory.GetDummyScreeningReminderSmsNotificationModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, appointmentConfirmation);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.PhysicianPartnerSurveyEmailNotification:
                    var ppSurveyNotification = _emailNotificationModelsFactory.GetDummySurveyNotificationModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, ppSurveyNotification);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.PhysicianPartnersCustomerResultReady:
                    var ppCustomerResultReady = _emailNotificationModelsFactory.GetDummyPpCustomerResultNotificationModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, ppCustomerResultReady);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;

                case NotificationTypeAlias.EventFullNotification:
                    var emailEventFull = _emailNotificationModelsFactory.GetDummyEventFillingNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, emailEventFull);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;

                case NotificationTypeAlias.LoginOtpEmailNotification:
                    var emailNotif = _emailNotificationModelsFactory.GetDummyLoginOtpEmailNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, emailNotif);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.LoginOtpSmsNotification:
                    var smsNotif = _phoneNotificationModelsFactory.GetDummyUserLoginOtpModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, smsNotif);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.CustomerTagUpdated:
                    var customerTagChangeNotif = _emailNotificationModelsFactory.GetDummyCustomerTagChangeNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, customerTagChangeNotif);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;

                case NotificationTypeAlias.EventLocked:
                    var eventLockedNotification = _emailNotificationModelsFactory.GetDummyEventLockedNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, eventLockedNotification);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;

                case NotificationTypeAlias.NoShowCustomer:
                    var noshowCustomerNotification = _emailNotificationModelsFactory.GetDummyNoShowCustomerNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, noshowCustomerNotification);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;

                case NotificationTypeAlias.CorporateUploadNotification:
                    var corporateUploadNotification = _emailNotificationModelsFactory.GetDummyCorporateUploadNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, corporateUploadNotification);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.DirectMailActivityNotification:
                    var directEmailNotificationViewModel = _emailNotificationModelsFactory.GetDummyDirectMailActivityNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, directEmailNotificationViewModel);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.IneligibleCustomerAppointmentNotification:
                    var directIneligibleCustomerAppointmentNotificationViewModel = _emailNotificationModelsFactory.GetDummyIneligibleCustomerAppointmentNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, directIneligibleCustomerAppointmentNotificationViewModel);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.ExportToCsvNotification:
                    var directcustomerExportNotificationtNotificationViewModel = _emailNotificationModelsFactory.GetDummyCustomerExportableReportsNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, directcustomerExportNotificationtNotificationViewModel);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.CancelRescheduleAppointmentNotification:
                    var cancellationRescheduleNotificationViewModel = _emailNotificationModelsFactory.GetDummyCancelRescheduleAppointmentNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, cancellationRescheduleNotificationViewModel);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;

                case NotificationTypeAlias.PatientLeftNotification:
                    var patientLeftNotificationViewModel = _emailNotificationModelsFactory.GetDummyPatientLeftNotificationModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, patientLeftNotificationViewModel);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;

                case NotificationTypeAlias.CustomEventSmsNotification:
                    var customEventSmsNotificationModel = _phoneNotificationModelsFactory.GetDummyCustomEventSmsNotificatonModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, customEventSmsNotificationModel);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;

                case NotificationTypeAlias.RecordSendBackForCorrection:
                    var recordSendBackForCorrectionNotificationModel = _emailNotificationModelsFactory.GetDummyRecordSendBackForCorrectionNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, recordSendBackForCorrectionNotificationModel);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;

                case NotificationTypeAlias.HourlyNotificationAppointmentBookedReport:
                    var hourlyNoitificationAppointment = _emailNotificationModelsFactory.GetDummyHourlyAppointmentBookedReportNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, hourlyNoitificationAppointment);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;

                case NotificationTypeAlias.HourlyNotificationOutreachCallReport:
                    var hourlyOutreachReport = _emailNotificationModelsFactory.GetDummyHourlyOutreachNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, hourlyOutreachReport);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;

                case NotificationTypeAlias.MergeCustomer:
                    var mergeCustomerModel = _emailNotificationModelsFactory.GetDummyMergeCustomerViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, mergeCustomerModel);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.WrongSmsReponse:
                    var wrongSmsReponse = _phoneNotificationModelsFactory.GetDummyWrongSmsResponseNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, wrongSmsReponse);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.WellcomeSmsMessage:
                    var wellcomeSmsNotification = _phoneNotificationModelsFactory.GetDummyWellcomeSmsNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, wellcomeSmsNotification);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.FileNotPosted:
                    var fileNotPostedModel = _emailNotificationModelsFactory.GetDummyFileNotPostedViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, fileNotPostedModel);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.TestNotPerformedSupplyIssue:
                    var testNotPerformedSupplyIssue = _emailNotificationModelsFactory.GetDummyTestNotPerformedEmailNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, testNotPerformedSupplyIssue);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.TestNotPerformedEquipmentMalfunction:
                    var testNotPerformedEquipmentMalfunction = _emailNotificationModelsFactory.GetDummyTestNotPerformedEmailNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, testNotPerformedEquipmentMalfunction);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.ReTestNotification:
                    var reTestNotification = _emailNotificationModelsFactory.GetDummyReTestNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, reTestNotification);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.NonTargetedMemberRegistrationNotification:
                    var nonTargetedMemberRegistrationNotification = _emailNotificationModelsFactory.GetDummyNonTargetedMemberRegistrationNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, nonTargetedMemberRegistrationNotification);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;

                case NotificationTypeAlias.MammoPatientRegistrationOnNonMammoEventNotification:
                    var mammoPatientRegistrationOnNonMammoEventNotification = _emailNotificationModelsFactory.GetDummyMammoPatientRegestrationOnNonMammoEventViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, mammoPatientRegistrationOnNonMammoEventNotification);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.SingleTestOverrideNotification:
                    var singleTestOverrideNotification = _emailNotificationModelsFactory.GetDummySingleTestOverrideNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, singleTestOverrideNotification);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.NPfordiagnosingwithlinkNotification:
                    var NPfordiagnosingwithlinkNotification = _emailNotificationModelsFactory.GetDummyNPfordiagnosingwithlinkNotificationViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, NPfordiagnosingwithlinkNotification);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.CoverLetterTemplate:
                    var coverLetterTemplate = _emailNotificationModelsFactory.GetDummyCoverLetterTemplateViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, coverLetterTemplate);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.ListWithoutCustomTags:
                    var listWithoutCustomTags = _emailNotificationModelsFactory.GetDummyListWithoutCustomTagsViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, listWithoutCustomTags);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;
                case NotificationTypeAlias.AbsenceByMember:
                    var AbsenceByMemberModel = _emailNotificationModelsFactory.GetDummyAbsenceByMemberPostedViewModel();
                    content = GetEmailMessagewithdummyData(emailTemplateAlias, body, AbsenceByMemberModel);
                    if (!string.IsNullOrEmpty(content)) return content;
                    break;

            }

            return content;
        }

        private string GetEmailMessagewithdummyData<T>(string emailTemplateAlias, string content, T model)
        {
            var emailBody = string.Empty;
            if (!string.IsNullOrEmpty(emailTemplateAlias))
            {
                EmailTemplate emailTemplate = _emailTemplateRepository.GetByAlias(emailTemplateAlias);

                emailBody = _emailTemplateFormatter.FormatContent(string.IsNullOrEmpty(content) ? emailTemplate.Body : content, model, emailTemplate.Id);
            }
            else if (!string.IsNullOrEmpty(content))
            {
                emailBody = _emailTemplateFormatter.FormatContent(content, model);
            }

            return emailBody;
        }
    }
}