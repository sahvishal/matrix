using System;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.ACL.Domain;
using Falcon.App.Core.ACL.Enum;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.ViewModels;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Insurance.Domain;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Application.Extensions;
using Falcon.Data.EntityClasses;
using Call = Falcon.App.Core.CallCenter.Domain.Call;
using Product = Falcon.App.Core.Finance.Domain.Product;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Medicare.ViewModels;

namespace Falcon.App.Infrastructure.Application.Impl
{
    public class AutoMapperBootstrapper : IAutoMapperBootstrapper
    {
        public void Bootstrap()
        {

            Mapper.CreateMap<Address, AddressEditModel>()
                .ForMember(x => x.ZipCode, opt => opt.MapFrom(d => d.ZipCode.Zip));

            Mapper.CreateMap<AddressEditModel, Address>()
                .ForMember(x => x.CityId, opt => opt.Ignore())
                .ForMember(x => x.State, opt => opt.Ignore())
                .ForMember(x => x.StateCode, opt => opt.Ignore())
                .ForMember(x => x.Country, opt => opt.Ignore())
                .ForMember(x => x.ZipCode, opt => opt.MapFrom(d => new ZipCode(d.ZipCode)))
                .ForMember(x => x.VerificationOrgRoleUserId, opt => opt.Ignore())
                .ForMember(x => x.Latitude, opt => opt.Ignore())
                .ForMember(x => x.Longitude, opt => opt.Ignore())
                .ForMember(x => x.LatLogUseForAddressMaping, opt => opt.Ignore());


            Mapper.CreateMap<UserEditModel, User>()
                .ForMember(x => x.Name, opt => opt.MapFrom(d => d.FullName))
                .ForMember(x => x.UserLogin, opt => opt.MapFrom(d => new UserLogin(d.UserName, d.Password, d.IsLocked) { IsSecurityQuestionVerified = true, UserVerified = true }))
                .ForMember(x => x.HomePhoneNumber, opt => opt.MapFrom(d => d.HomeNumber))
                .ForMember(x => x.OfficePhoneNumber, opt => opt.MapFrom(d => d.OfficeNumber))
                .ForMember(x => x.MobilePhoneNumber, opt => opt.MapFrom(d => d.CellNumber))
                .ForMember(x => x.Email, opt => opt.MapFrom(d => string.IsNullOrEmpty(d.Email) ? null : new Email(d.Email)))
                .ForMember(x => x.DefaultRole, opt => opt.MapFrom(d => (Roles)d.UsersRoles.Where(r => r.IsDefault).FirstOrDefault().RoleId))
                .ForMember(x => x.AlternateEmail, opt => opt.Ignore())
                .ForMember(x => x.PhoneOfficeExtension, opt => opt.Ignore());

            Mapper.CreateMap<User, UserEditModel>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(d => d.Name))
                .ForMember(x => x.UserName, opt => opt.MapFrom(d => d.UserLogin.UserName))
                .ForMember(x => x.Password, opt => opt.Ignore())
                .ForMember(x => x.ConfirmPassword, opt => opt.Ignore())
                .ForMember(x => x.OfficeNumber, opt => opt.MapFrom(d => d.OfficePhoneNumber))
                .ForMember(x => x.HomeNumber, opt => opt.MapFrom(d => d.HomePhoneNumber))
                .ForMember(x => x.CellNumber, opt => opt.MapFrom(d => d.MobilePhoneNumber))
                .ForMember(x => x.IsLocked, opt => opt.MapFrom(d => d.UserLogin.Locked))
                .ForMember(x => x.UsersRoles, opt => opt.Ignore())
                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore())
                .ForMember(x => x.TechnicianProfile, opt => opt.Ignore())
                .ForMember(x => x.PhysicianProfile, opt => opt.Ignore())
                .ForMember(x => x.OverRideTwoFactorAuthrequired, opt => opt.Ignore())
                .ForMember(x => x.IsTwoFactorAuthrequired, opt => opt.Ignore())
                .ForMember(x => x.AccountCoordinatorProfile, opt => opt.Ignore())
                .ForMember(x => x.CustomerProfile, opt => opt.Ignore())
                .ForMember(x => x.LastLoggedInAt, opt => opt.MapFrom(d => d.UserLogin.LastLogged))
                .ForMember(x => x.Npi, opt => opt.Ignore())
                .ForMember(x => x.Credential, opt => opt.Ignore())
                .ForMember(x => x.EmployeeId, opt => opt.Ignore());

            Mapper.CreateMap<Customer, CustomerEditModel>();


            Mapper.CreateMap<CustomerEditModel, Customer>()
                .ForMember(x => x.DisplayCode, opt => opt.Ignore())
                .ForMember(x => x.BillingAddress, opt => opt.Ignore())
                .ForMember(x => x.PrimaryCarePhysician, opt => opt.Ignore())
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateModified, opt => opt.Ignore())
                .ForMember(x => x.UserLogin, opt => opt.Ignore())
                .ForMember(x => x.Name, opt => opt.Ignore())
                .ForMember(x => x.Address, opt => opt.Ignore())
                .ForMember(x => x.Email, opt => opt.Ignore())
                .ForMember(x => x.AlternateEmail, opt => opt.Ignore())
                .ForMember(x => x.HomePhoneNumber, opt => opt.Ignore())
                .ForMember(x => x.OfficePhoneNumber, opt => opt.Ignore())
                .ForMember(x => x.MobilePhoneNumber, opt => opt.Ignore())
                .ForMember(x => x.DateOfBirth, opt => opt.Ignore())
                .ForMember(x => x.DefaultRole, opt => opt.Ignore())
                .ForMember(x => x.DataRecorderMetaData, opt => opt.Ignore())
                .ForMember(x => x.RequestForNewsLetter, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.PhoneOfficeExtension, opt => opt.Ignore())
                .ForMember(x => x.DoNotContactTypeId, opt => opt.Ignore())
                .ForMember(x => x.DoNotContactReasonId, opt => opt.Ignore())
                .ForMember(x => x.DoNotContactReasonNotesId, opt => opt.Ignore())
                .ForMember(x => x.Ssn, opt => opt.Ignore())
                .ForMember(x => x.Tag, opt => opt.Ignore())
                .ForMember(x => x.Hicn, opt => opt.Ignore())
                .ForMember(x => x.MedicareAdvantageNumber, opt => opt.Ignore())
                .ForMember(x => x.MedicareAdvantagePlanName, opt => opt.Ignore())
                //.ForMember(x => x.IsEligible, opt => opt.Ignore())
                .ForMember(x => x.LabId, opt => opt.Ignore())
                .ForMember(x => x.Copay, opt => opt.Ignore())
                .ForMember(x => x.LanguageId, opt => opt.Ignore())
                .ForMember(x => x.Lpi, opt => opt.Ignore())
                .ForMember(x => x.Market, opt => opt.Ignore())
                .ForMember(x => x.Mrn, opt => opt.Ignore())
                .ForMember(x => x.GroupName, opt => opt.Ignore())
                .ForMember(x => x.IsIncorrectPhoneNumber, opt => opt.Ignore())
                .ForMember(x => x.AdditionalField1, opt => opt.Ignore())
                .ForMember(x => x.AdditionalField2, opt => opt.Ignore())
                .ForMember(x => x.AdditionalField3, opt => opt.Ignore())
                .ForMember(x => x.AdditionalField4, opt => opt.Ignore())
                .ForMember(x => x.IsLanguageBarrier, opt => opt.Ignore())
                .ForMember(x => x.ActivityId, opt => opt.Ignore())
                .ForMember(x => x.DoNotContactUpdateDate, opt => opt.Ignore())
                .ForMember(x => x.DoNotContactUpdateSource, opt => opt.Ignore())
                .ForMember(x => x.IsSubscribed, opt => opt.Ignore())
                .ForMember(x => x.LanguageBarrierMarkedDate, opt => opt.Ignore())
                .ForMember(x => x.IncorrectPhoneNumberMarkedDate, opt => opt.Ignore())
                .ForMember(x => x.PreferredContactType, opt => opt.Ignore())
                .ForMember(x => x.Mbi, opt => opt.Ignore())
                .ForMember(x => x.AcesId, opt => opt.Ignore())
                .ForMember(x => x.PhoneHomeConsentId, opt => opt.Ignore())
                .ForMember(x => x.PhoneCellConsentId, opt => opt.Ignore())
                .ForMember(x => x.PhoneOfficeConsentId, opt => opt.Ignore())
                .ForMember(x => x.PhoneHomeConsentUpdateDate, opt => opt.Ignore())
                .ForMember(x => x.PhoneCellConsentUpdateDate, opt => opt.Ignore())
                .ForMember(x => x.PhoneOfficeConsentUpdateDate, opt => opt.Ignore())
                .ForMember(x => x.BillingMemberId, opt => opt.Ignore())
                .ForMember(x => x.BillingMemberPlan, opt => opt.Ignore())
                .ForMember(x => x.BillingMemberPlanYear, opt => opt.Ignore())
                .ForMember(x => x.EnableEmail, opt => opt.Ignore())
                .ForMember(x => x.EnableEmailUpdateDate, opt => opt.Ignore())
                .ForMember(x => x.MemberUploadSourceId, opt => opt.Ignore())
                .ForMember(x => x.ActivityTypeIsManual, opt => opt.Ignore())
                .ForMember(x => x.ProductTypeId, opt => opt.Ignore())
                .ForMember(x => x.AcesClientId, opt => opt.Ignore());

            Mapper.CreateMap<OrganizationRoleUserModel, OrganizationRoleUser>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.OrganizationRoleUserId));



            Mapper.CreateMap<VanEditModel, Van>()
                .ForMember(x => x.IsActive, opt => opt.UseValue(true));

            Mapper.CreateMap<Van, VanEditModel>()
                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore());



            Mapper.CreateMap<RoleEntity, Role>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.RoleId))
                .ForMember(x => x.DisplayName, opt => opt.MapFrom(d => d.Name))
                .ForMember(x => x.Parent, opt => opt.MapFrom(d => d.Role))
                .ForMember(x => x.RoleScopeOptions, opt => opt.MapFrom(d => d.RoleScopeOption));

            Mapper.CreateMap<User, ProfileEditModel>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(d => d.Name))
                .ForMember(x => x.HomeNumber, opt => opt.MapFrom(d => d.HomePhoneNumber))
                .ForMember(x => x.CellNumber, opt => opt.MapFrom(d => d.MobilePhoneNumber))
                .ForMember(x => x.OfficeNumber, opt => opt.MapFrom(d => d.OfficePhoneNumber))
                .ForMember(x => x.Password, opt => opt.Ignore())
                .ForMember(x => x.ConfirmPassword, opt => opt.Ignore())
                .ForMember(x => x.DateOfBirth, opt => opt.MapFrom(d => d.DateOfBirth))
                .ForMember(x => x.UserName, opt => opt.MapFrom(d => d.UserLogin.UserName))
                .ForMember(x => x.DateCreated, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateCreated))
                .ForMember(x => x.CreatedByOrgRoleUserId, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderCreator == null ? (long?)null : d.DataRecorderMetaData.DataRecorderCreator.Id))
                .ForMember(x => x.HintQuestion, opt => opt.MapFrom(d => d.UserLogin.HintQuestion))
                .ForMember(x => x.HintAnswer, opt => opt.MapFrom(d => d.UserLogin.HintAnswer))
                .ForMember(x => x.UseSms, opt => opt.Ignore())
                .ForMember(x => x.UseEmail, opt => opt.Ignore())
                .ForMember(x => x.ChangePassword, opt => opt.Ignore())
                .ForMember(x => x.UseAuthenticator, opt => opt.Ignore())
                .ForMember(x => x.IsPinRequiredForRole, opt => opt.Ignore())
                .ForMember(x => x.IsOtpBySmsEnabled, opt => opt.Ignore())
                .ForMember(x => x.IsOtpByEmailEnabled, opt => opt.Ignore())
                .ForMember(x => x.IsOtpByAppEnabled, opt => opt.Ignore())
                .ForMember(x => x.DownloadFilePin, opt => opt.Ignore())
                .ForMember(x => x.EncodedSecret, opt => opt.Ignore())
                .ForMember(x => x.Secret, opt => opt.Ignore())
                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore())
                .ForMember(x => x.TechnicianPin, opt => opt.Ignore());

            Mapper.CreateMap<ProfileEditModel, User>()
                .ForMember(x => x.Name, opt => opt.MapFrom(d => d.FullName))
                .ForMember(x => x.HomePhoneNumber, opt => opt.MapFrom(d => d.HomeNumber))
                .ForMember(x => x.MobilePhoneNumber, opt => opt.MapFrom(d => d.CellNumber))
                .ForMember(x => x.OfficePhoneNumber, opt => opt.MapFrom(d => d.OfficeNumber))
                .ForMember(x => x.UserLogin, opt => opt.MapFrom(d => new UserLogin(d.UserName, d.Password, false) { HintQuestion = d.HintQuestion, HintAnswer = d.HintAnswer }))
                .ForMember(x => x.Email, opt => opt.MapFrom(d => new Email(d.Email)))
                .ForMember(x => x.DateOfBirth, opt => opt.MapFrom(d => d.DateOfBirth))
                .ForMember(x => x.DataRecorderMetaData,
                           opt =>
                           opt.MapFrom(
                               d =>
                               new DataRecorderMetaData(d.CreatedByOrgRoleUserId,
                                                        d.DateCreated, DateTime.Now)))
                .ForMember(x => x.AlternateEmail, opt => opt.Ignore())
                .ForMember(x => x.PhoneOfficeExtension, opt => opt.Ignore());



            Mapper.CreateMap<PodStaffEditModel, PodStaff>()
                .ForMember(x => x.DataRecorderMetaData, opt => opt.Ignore());


            Mapper.CreateMap<PodEditModel, Pod>()
                .ForMember(x => x.DataRecorderMetaData, opt => opt.Ignore());

            Mapper.CreateMap<StaffEventRoleEditModel, StaffEventRole>();

            Mapper.CreateMap<StaffEventRole, StaffEventRoleEditModel>().
                ForMember(x => x.Tests, opt => opt.Ignore()).
                ForMember(x => x.FeedbackMessage, opt => opt.Ignore());

            Mapper.CreateMap<Address, AddressViewModel>();


            Mapper.CreateMap<Event, EventBasicInfoViewModel>()
                .ForMember(x => x.AssignedtoFullName, opt => opt.Ignore())
                .ForMember(x => x.HostAddress, opt => opt.Ignore())
                .ForMember(x => x.HostName, opt => opt.Ignore())
                .ForMember(x => x.Pods, opt => opt.Ignore())
                .ForMember(x => x.TotalAppointmentSlots, opt => opt.Ignore())
                .ForMember(x => x.FilledAppintmentSlots, opt => opt.Ignore())
                .ForMember(x => x.IsCdContentGenerated, opt => opt.Ignore())
                .ForMember(x => x.IsResultPacketGenetated, opt => opt.Ignore())
                .ForMember(x => x.CaptureHealthAssessmentForm, opt => opt.Ignore())
                .ForMember(x => x.GenerateBatchLabel, opt => opt.Ignore())
                .ForMember(x => x.Sponsor, opt => opt.Ignore())
                .ForMember(x => x.MorningAvailableSlots, opt => opt.Ignore())
                .ForMember(x => x.AfternoonAvailableSlots, opt => opt.Ignore())
                .ForMember(x => x.EveningAvailableSlots, opt => opt.Ignore())
                .ForMember(x => x.BookedSlots, opt => opt.Ignore())
                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore())
                .ForMember(x => x.ScreenedCustomers, opt => opt.Ignore())
                .ForMember(x => x.IsSmsEnabled, opt => opt.Ignore());




            Mapper.CreateMap<EventStaffAssignmentViewModel, EventJsonModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.Event.Id))
                .ForMember(x => x.start, opt => opt.MapFrom(d => d.Event.EventDate.ToShortDateString()))
                .ForMember(x => x.title,
                           opt =>
                           opt.MapFrom(
                               d =>
                               string.Format("{0} in {1}, {2}", d.Event.PodNames(), d.Event.HostAddress.City,
                                             d.Event.HostAddress.State)))
                .ForMember(x => x.allDay, opt => opt.UseValue(true))
                .ForMember(x => x.end, opt => opt.Ignore())
                .ForMember(x => x.editable, opt => opt.UseValue(false))
                .ForMember(x => x.Pods, opt => opt.MapFrom(d => d.Event.Pods.Select(a => a.SecondValue).ToArray()))
                .ForMember(x => x.AssignedStaff,
                           opt =>
                           opt.MapFrom(
                               d =>
                               d.AssignedStaff.Select(
                                   staff => new OrderedPair<string, string>(staff.FullName, staff.EventRole)).ToArray()))
                .ForMember(x => x.TotalAppointmentSlots, opt => opt.MapFrom(d => d.Event.TotalAppointmentSlots))
                .ForMember(x => x.FilledAppintmentSlots, opt => opt.MapFrom(d => d.Event.FilledAppintmentSlots))
                .ForMember(x => x.url, opt => opt.Ignore());


            Mapper.CreateMap<ISettings, AddressViewModel>().ForMember(x => x.City, opt => opt.MapFrom(d => d.City)).
                ForMember(x => x.State, opt => opt.MapFrom(d => d.State))
                .ForMember(x => x.StateCode, opt => opt.Ignore())
                .ForMember(x => x.Country, opt => opt.UseValue("USA"))
                .ForMember(x => x.StreetAddressLine1, opt => opt.MapFrom(d => d.Address1))
                .ForMember(x => x.StreetAddressLine2, opt => opt.MapFrom(d => d.Address2))
                .ForMember(x => x.StateId, opt => opt.Ignore());

            Mapper.CreateMap<ISettings, EmailCommunicationViewModelBase>()
                .ForMember(x => x.NotificationId, opt => opt.Ignore())
                .ForMember(x => x.EmailNotificationLogoRelativePath, opt => opt.MapFrom(d => d.EmailNotificationLogoRelativePath))
                .ForMember(x => x.NotificationDateTime, opt => opt.UseValue(DateTime.Now))
                .ForMember(x => x.CompanyAddress, opt => opt.MapFrom(d => d));

            Mapper.CreateMap<MarketingSource, MarketingSourceEditModel>()
                .ForMember(x => x.SelectedTerritories, opt => opt.Ignore())
                .ForMember(x => x.Territories, opt => opt.Ignore())
                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore());

            Mapper.CreateMap<MarketingSourceEditModel, MarketingSource>()
                .ForMember(x => x.DataRecorderMetaData, opt => opt.Ignore());

            Mapper.CreateMap<MarketingSource, MarketingSourceBasicModel>()
                .ForMember(x => x.Territories, opt => opt.Ignore());

            Mapper.CreateMap<EventStaffAssignment, EventStaffAssignmentEntity>()
                .IgnoreEntityBaseFields()
                .ForMember(x => x.EventStaffAssignmentId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id == 0))
                .ForMember(x => x.StaffEventRoleId, opt => opt.MapFrom(d => d.StaffEventRoleId))
                .ForMember(x => x.ScheduledByOrgRoleUserId, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderCreator.Id))
                .ForMember(x => x.ScheduledOn, opt => opt.MapFrom(d => (d.DataRecorderMetaData.DateCreated == DateTime.MinValue ? DateTime.Now : d.DataRecorderMetaData.DateCreated)))
                .ForMember(x => x.IsActive, opt => opt.Ignore());

            Mapper.CreateMap<EventStaffAssignmentEntity, EventStaffAssignment>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.EventStaffAssignmentId))
                .ForMember(x => x.StaffEventRoleId, opt => opt.MapFrom(d => d.StaffEventRoleId))
                .ForMember(x => x.DataRecorderMetaData, opt => opt.MapFrom(d => new DataRecorderMetaData(d.ScheduledByOrgRoleUserId, d.ScheduledOn, null)));

            Mapper.CreateMap<EventStaffBasicInfoModel, EventStaffAssignment>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.EventId, opt => opt.Ignore())
                .ForMember(x => x.PodId, opt => opt.Ignore())
                .ForMember(x => x.StaffEventRoleId, opt => opt.MapFrom(d => d.EventRoleId))
                .ForMember(x => x.DataRecorderMetaData, opt => opt.Ignore());


            Mapper.CreateMap<EventStaffAssignment, EventStaffBasicInfoModel>()
                .ForMember(x => x.FullName, opt => opt.Ignore())
                .ForMember(x => x.EventRole, opt => opt.Ignore())
                .ForMember(x => x.EventRoleId, opt => opt.MapFrom(d => d.StaffEventRoleId))
                .ForMember(x => x.EmployeeId, opt => opt.Ignore());

            Mapper.CreateMap<ProspectCustomer, ProspectCustomerBasicInfoModel>()
                .ForMember(x => x.Status, opt => opt.MapFrom(d => (ProspectCustomerConversionStatus)d.Status))
                .ForMember(x => x.Notes, opt => opt.Ignore())
                .ForMember(x => x.SourceCode, opt => opt.Ignore())
                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore())
                .ForMember(x => x.DateOfBirth, opt => opt.MapFrom(m => m.BirthDate))
                .ForMember(x => x.CorporateTag, opt => opt.Ignore())
                .ForMember(x => x.CustomTags, opt => opt.Ignore())
                .ForMember(x => x.MemberId, opt => opt.Ignore())
                .ForMember(x => x.CorporateSponsor, opt => opt.Ignore())
                .ForMember(x => x.ContactedBy, opt => opt.Ignore());

            Mapper.CreateMap<RefundRequest, RefundRequestEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id == 0))
                .ForMember(x => x.RefundRequestId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.ReasonType, opt => opt.MapFrom(d => (long)d.RefundRequestType))
                .ForMember(x => x.ReasonComment, opt => opt.MapFrom(d => d.Reason))
                .ForMember(x => x.RequestStatus, opt => opt.MapFrom(d => d.RequestStatus))
                .ForMember(x => x.ProcessedOn, opt => opt.MapFrom(d => (d.RefundRequestResult != null ? (DateTime?)d.RefundRequestResult.ProcessedOn : null)))
                .ForMember(x => x.ProcessedByOrgRoleUserId,
                opt => opt.MapFrom(d => d.RefundRequestResult != null ? (long?)d.RefundRequestResult.ProcessedByOrgRoleUserId : null))
                .ForMember(x => x.FinalRefundAmount, opt => opt.MapFrom(d => d.RefundRequestResult != null ? (decimal?)d.RefundRequestResult.RefundAmount : null))
                .ForMember(x => x.ProcessorNotes, opt => opt.MapFrom(d => d.RefundRequestResult != null ? d.RefundRequestResult.Notes : string.Empty))
                .ForMember(x => x.RequestResult, opt => opt.MapFrom(d => d.RefundRequestResult != null ? (int?)d.RefundRequestResult.RequestResultType : null))
                .ForMember(x => x.IsActive, opt => opt.UseValue(true))
                .ForMember(x => x.RefundRequestGiftCertificate, opt => opt.Ignore())
                .ForMember(x => x.GiftCertificateCollectionViaRefundRequestGiftCertificate, opt => opt.Ignore());

            Mapper.CreateMap<RefundRequestEntity, RefundRequestResult>()
                .ForMember(x => x.RequestId, opt => opt.MapFrom(d => d.RefundRequestId))
                .ForMember(x => x.RefundAmount, opt => opt.MapFrom(d => d.FinalRefundAmount))
                .ForMember(x => x.Notes, opt => opt.MapFrom(d => d.ProcessorNotes))
                .ForMember(x => x.RequestResultType, opt => opt.MapFrom(d => d.RequestResult));


            Mapper.CreateMap<RefundRequestEntity, RefundRequest>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.RefundRequestId))
                .ForMember(x => x.RefundRequestType, opt => opt.MapFrom(d => (RefundRequestType)d.ReasonType))
                .ForMember(x => x.Reason, opt => opt.MapFrom(d => d.ReasonComment))
                .ForMember(x => x.EventId, opt => opt.Ignore())
                .ForMember(x => x.CustomerId, opt => opt.Ignore())
                .ForMember(x => x.RefundRequestResult, opt => opt.MapFrom(d => d.RequestResult == null ? null : d));

            Mapper.CreateMap<RefundRequestEditModel, RefundRequest>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.RequestId))
                .ForMember(x => x.RefundRequestResult, opt => opt.Ignore())
                .ForMember(x => x.RefundRequestType, opt => opt.MapFrom(d => (RefundRequestType)d.RefundType))
                .ForMember(x => x.EventId, opt => opt.Ignore())
                .ForMember(x => x.CustomerId, opt => opt.Ignore())
                .ForMember(x => x.RequestedByOrgRoleUserId, opt => opt.Ignore())
                .ForMember(x => x.RequestStatus, opt => opt.UseValue((long)RequestStatus.Pending))
                .ForMember(x => x.RequestedOn, opt => opt.Ignore());

            Mapper.CreateMap<RefundRequest, RefundRequestResultEditModel>()
                .ForMember(x => x.RequestId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.RequestedRefundAmount, opt => opt.MapFrom(d => d.RequestedRefundAmount))
                .ForMember(x => x.RefundType, opt => opt.MapFrom(d => d.RefundRequestType))
                .ForMember(x => x.OrderId, opt => opt.MapFrom(d => d.OrderId))
                .ForMember(x => x.RequestedOn, opt => opt.MapFrom(d => d.RequestedOn))
                .ForMember(x => x.RefundRequestNotes, opt => opt.MapFrom(d => d.Reason))
                .ForMember(x => x.PreviousProcessingNotes, opt => opt.MapFrom(d => d.RefundRequestResult == null ? string.Empty : d.RefundRequestResult.Notes))
                .ForMember(x => x.Notes, opt => opt.Ignore())
                .ForMember(x => x.RequestedBy, opt => opt.Ignore())
                .ForMember(x => x.CancellationFee, opt => opt.Ignore())
                .ForMember(x => x.ChargeCancellationFee, opt => opt.Ignore())
                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore())
                .ForMember(x => x.RefundAmount, opt => opt.Ignore())
                .ForMember(x => x.PaymentEditModel, opt => opt.Ignore())
                .ForMember(x => x.OfferFreeProduct, opt => opt.Ignore())
                .ForMember(x => x.OfferDiscount, opt => opt.Ignore())
                .ForMember(x => x.DiscountAmount, opt => opt.Ignore())
                .ForMember(x => x.RequestResultType, opt => opt.Ignore())
                .ForMember(x => x.CancellationReason, opt => opt.Ignore());

            Mapper.CreateMap<RefundRequestResultEditModel, RefundRequestResult>()
                .ForMember(m => m.RequestResultType, opt => opt.MapFrom(d => d.RequestResultType))
                .ForMember(m => m.Notes, opt => opt.MapFrom(d => d.Notes))
                .ForMember(m => m.RefundAmount, opt => opt.MapFrom(d => d.RefundAmount))
                .ForMember(m => m.ProcessedByOrgRoleUserId, opt => opt.Ignore())
                .ForMember(m => m.ProcessedOn, opt => opt.Ignore());

            Mapper.CreateMap<Product, ProductstoOfferModel>()
                .ForMember(x => x.ProductId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.ProductDescription, opt => opt.MapFrom(d => "Offer Free " + d.Name))
                .ForMember(x => x.ProductPrice, opt => opt.MapFrom(d => d.Price))
                .ForMember(x => x.OrderItemId, opt => opt.Ignore())
                .ForMember(x => x.ProductAvailed, opt => opt.Ignore())
                .ForMember(x => x.ProductPriceinOrder, opt => opt.Ignore());

            Mapper.CreateMap<ResultArchiveUploadEntity, ResultArchive>()
                .ForMember(m => m.Id, opt => opt.MapFrom(d => d.ResultArchiveUploadId));

            Mapper.CreateMap<ResultArchive, ResultArchiveUploadEntity>()
                .IgnoreEntityBaseFields()
                .ForMember(m => m.Status, opt => opt.MapFrom(d => (long)d.Status))
                .ForMember(m => m.ResultArchiveUploadId, opt => opt.MapFrom(d => d.Id))
                .ForMember(m => m.ResultArchiveUploadLog, opt => opt.Ignore())
                .ForMember(m => m.CustomerProfileCollectionViaResultArchiveUploadLog, opt => opt.Ignore())
                .ForMember(m => m.TestCollectionViaResultArchiveUploadLog, opt => opt.Ignore())
                .ForMember(m => m.IsNew, opt => opt.MapFrom(d => d.Id > 0 ? false : true));

            Mapper.CreateMap<ResultArchiveUploadLogEntity, ResultArchiveLog>()
                .ForMember(m => m.Id, opt => opt.MapFrom(d => d.ResultArchiveUploadLogId))
                .ForMember(m => m.ResultArchiveId, opt => opt.MapFrom(d => d.ResultArchiveUploadId))
                .ForMember(m => m.Notes, opt => opt.MapFrom(d => d.Note))
                .ForMember(m => m.TestId, opt => opt.MapFrom(d => (TestType)d.TestId));

            Mapper.CreateMap<ResultArchiveLog, ResultArchiveUploadLogEntity>()
                .IgnoreEntityBaseFields()
                .ForMember(m => m.ResultArchiveUploadLogId, opt => opt.MapFrom(d => d.Id))
                .ForMember(m => m.TestId, opt => opt.MapFrom(d => (long)d.TestId))
                .ForMember(m => m.ResultArchiveUploadId, opt => opt.MapFrom(d => d.ResultArchiveId))
                .ForMember(m => m.Note, opt => opt.MapFrom(d => d.Notes))
                .ForMember(m => m.IsNew, opt => opt.MapFrom(d => d.Id > 0 ? false : true));

            Mapper.CreateMap<ResultArchive, ResultArchiveUploadViewModel>()
                .ForMember(m => m.File, opt => opt.MapFrom(d => d.FileId.HasValue ? new File(d.FileId.Value) : null))
                .ForMember(m => m.EventName, opt => opt.Ignore())
                .ForMember(m => m.EventDate, opt => opt.Ignore())
                .ForMember(m => m.UploadedBy, opt => opt.Ignore())
                .ForMember(m => m.PodName, opt => opt.Ignore());

            Mapper.CreateMap<ResultArchiveLog, ResultArchiveUploadLogViewModel>()
                .ForMember(m => m.CustomerName, opt => opt.Ignore())
                .ForMember(m => m.TestName, opt => opt.Ignore());

            Mapper.CreateMap<MedicalVendorEditModel, MedicalVendor>()
                .ForMember(x => x.MedicalVendorType, opt => opt.MapFrom(mv => (MedicalVendorType)mv.MedicalVendorType))
                .ForMember(x => x.ContractId, opt => opt.MapFrom(mv => mv.ContractId))
                .ForMember(x => x.IsHospitalPartner, opt => opt.MapFrom(mv => mv.IsHospitalPartner))
                .ForMember(x => x.Id, opt => opt.MapFrom(mv => mv.OrganizationEditModel.Id))
                .ForMember(x => x.ResultLetterCoBrandingFileId, opt => opt.MapFrom(mv => mv.ResultLetterCoBrandingFile != null ? (long?)mv.ResultLetterCoBrandingFile.Id : null))
                .ForMember(x => x.DoctorLetterFileId, opt => opt.MapFrom(mv => mv.DoctorLetterFile != null ? (long?)mv.DoctorLetterFile.Id : null))
                .ForMember(x => x.OrganizationType, opt => opt.Ignore())
                .ForMember(x => x.Name, opt => opt.Ignore())
                .ForMember(x => x.Description, opt => opt.Ignore())
                .ForMember(x => x.BusinessAddressId, opt => opt.Ignore())
                .ForMember(x => x.BillingAddressId, opt => opt.Ignore())
                .ForMember(x => x.PhoneNumber, opt => opt.Ignore())
                .ForMember(x => x.FaxNumber, opt => opt.Ignore())
                .ForMember(x => x.Email, opt => opt.Ignore())
                .ForMember(x => x.LogoImageId, opt => opt.Ignore())
                .ForMember(x => x.TeamImageId, opt => opt.Ignore());

            Mapper.CreateMap<MedicalVendor, MedicalVendorEditModel>()
                .ForMember(x => x.MedicalVendorType, opt => opt.MapFrom(mv => (long)mv.MedicalVendorType))
                .ForMember(x => x.ContractId, opt => opt.MapFrom(mv => mv.ContractId))
                .ForMember(x => x.IsHospitalPartner, opt => opt.MapFrom(mv => mv.IsHospitalPartner))
                .ForMember(x => x.ResultLetterCoBrandingFile, opt => opt.Ignore())
                .ForMember(x => x.DoctorLetterFile, opt => opt.Ignore())
                .ForMember(x => x.OrganizationEditModel, opt => opt.Ignore())
                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore())
                .ForMember(x => x.HospitalPartnerEditModel, opt => opt.Ignore());

            Mapper.CreateMap<HospitalPartnerEditModel, HospitalPartner>()
                .ForMember(x => x.IsGlobal, opt => opt.MapFrom(hp => (hp.TerritoryIds != null && hp.TerritoryIds.Count() > 0) ? false : true))
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Name, opt => opt.Ignore())
                .ForMember(x => x.PackageIds, opt => opt.Ignore())
                .ForMember(x => x.AdvocateId, opt => opt.Ignore());

            Mapper.CreateMap<HospitalPartner, HospitalPartnerEditModel>()
                .ForMember(x => x.OrganizationPackageList, opt => opt.Ignore())
                .ForMember(x => x.DefaultPackages, opt => opt.Ignore())
                .ForMember(x => x.Territories, opt => opt.Ignore())
                .ForMember(x => x.DeactivedPackages, opt => opt.Ignore())
                .ForMember(x => x.ShowAskPreQualificationQuestionSetttings, opt => opt.Ignore())
                .ForMember(x => x.HospitalFacilities, opt => opt.Ignore())
                .ForMember(x => x.ShippingOptions, opt => opt.Ignore());

            Mapper.CreateMap<TechnicianModel, Technician>()
                .ForMember(x => x.IsTeamLead, opt => opt.MapFrom(t => t.IsTeamLead))
                .ForMember(x => x.CanDoPreAudit, opt => opt.MapFrom(t => t.CanCompletePreAudit))
                .ForMember(x => x.Pin, opt => opt.MapFrom(t => t.Pin))
                .ForMember(x => x.TechnicianId, opt => opt.Ignore())
                .ForMember(x => x.Address, opt => opt.Ignore())
                .ForMember(x => x.AlternateEmail, opt => opt.Ignore())
                .ForMember(x => x.DataRecorderMetaData, opt => opt.Ignore())
                .ForMember(x => x.DateOfBirth, opt => opt.Ignore())
                .ForMember(x => x.DefaultRole, opt => opt.Ignore())
                .ForMember(x => x.Email, opt => opt.Ignore())
                .ForMember(x => x.HomePhoneNumber, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.MobilePhoneNumber, opt => opt.Ignore())
                .ForMember(x => x.Name, opt => opt.Ignore())
                .ForMember(x => x.OfficePhoneNumber, opt => opt.Ignore())
                .ForMember(x => x.UserLogin, opt => opt.Ignore())
                .ForMember(x => x.PhoneOfficeExtension, opt => opt.Ignore())
                .ForMember(x => x.Ssn, opt => opt.Ignore())
                .ForMember(x => x.PinChangeDate, opt => opt.Ignore());

            Mapper.CreateMap<Technician, TechnicianModel>()
                .ForMember(x => x.CanCompletePreAudit, opt => opt.MapFrom(t => t.CanDoPreAudit))
                .ForMember(x => x.IsTeamLead, opt => opt.MapFrom(t => t.IsTeamLead))
                .ForMember(x => x.Pin, opt => opt.MapFrom(t => t.Pin))
                .ForMember(x => x.TechnicianId, opt => opt.MapFrom(t => t.TechnicianId));

            Mapper.CreateMap<PhysicianModel, Physician>()
                .ForMember(x => x.SpecializationId, opt => opt.MapFrom(p => p.SpecializationId))
                .ForMember(x => x.CanSeeEarnings, opt => opt.MapFrom(p => p.CanSeeEarnings))
                .ForMember(x => x.CanDoAuthorizations, opt => opt.MapFrom(p => p.CanDoAuthorizations))
                .ForMember(x => x.SkipAudit, opt => opt.MapFrom(p => p.SkipAudit))
                .ForMember(x => x.CutOffDate, opt => opt.MapFrom(p => p.CutOffDate))
                .ForMember(x => x.PermittedTests, opt => opt.MapFrom(p => p.PermittedTests))
                .ForMember(x => x.AssignedPodIds, opt => opt.MapFrom(p => p.AssignedPodIds))
                .ForMember(x => x.StandardRate, opt => opt.MapFrom(p => p.StandardRate))
                .ForMember(x => x.OverReadRate, opt => opt.MapFrom(p => p.OverReadRate))
                .ForMember(x => x.SignatureFile, opt => opt.MapFrom(p => p.SignatureFile))
                .ForMember(x => x.ResumeFile, opt => opt.MapFrom(p => p.ResumeFile))
                .ForMember(x => x.IsDefault, opt => opt.MapFrom(p => p.IsDefault))
                .ForMember(x => x.UpdateResultEntry, opt => opt.MapFrom(p => p.UpdateResultEntry))
                .ForMember(x => x.PhysicianId, opt => opt.MapFrom(p => p.PhysicianId))
                .ForMember(x => x.AuthorizedStateLicenses, opt => opt.Ignore())
                .ForMember(x => x.PhysicianId, opt => opt.Ignore())
                .ForMember(x => x.MedicalVendorId, opt => opt.Ignore())
                .ForMember(x => x.Address, opt => opt.Ignore())
                .ForMember(x => x.AlternateEmail, opt => opt.Ignore())
                .ForMember(x => x.DataRecorderMetaData, opt => opt.Ignore())
                .ForMember(x => x.DateOfBirth, opt => opt.Ignore())
                .ForMember(x => x.DefaultRole, opt => opt.Ignore())
                .ForMember(x => x.Email, opt => opt.Ignore())
                .ForMember(x => x.HomePhoneNumber, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.MobilePhoneNumber, opt => opt.Ignore())
                .ForMember(x => x.Name, opt => opt.Ignore())
                .ForMember(x => x.OfficePhoneNumber, opt => opt.Ignore())
                .ForMember(x => x.UserLogin, opt => opt.Ignore())
                .ForMember(x => x.PhoneOfficeExtension, opt => opt.Ignore())
                .ForMember(x => x.Ssn, opt => opt.Ignore())
                .ForMember(x => x.Npi, opt => opt.MapFrom(p => p.Npi));

            Mapper.CreateMap<Physician, PhysicianModel>()
                .ForMember(x => x.SpecializationId, opt => opt.MapFrom(p => p.SpecializationId))
                .ForMember(x => x.CanSeeEarnings, opt => opt.MapFrom(p => p.CanSeeEarnings))
                .ForMember(x => x.CanDoAuthorizations, opt => opt.MapFrom(p => p.CanDoAuthorizations))
                .ForMember(x => x.SkipAudit, opt => opt.MapFrom(p => p.SkipAudit))
                .ForMember(x => x.CutOffDate, opt => opt.MapFrom(p => p.CutOffDate))
                .ForMember(x => x.PermittedTests, opt => opt.MapFrom(p => p.PermittedTests))
                .ForMember(x => x.AssignedPodIds, opt => opt.MapFrom(p => p.AssignedPodIds))
                .ForMember(x => x.StandardRate, opt => opt.MapFrom(p => p.StandardRate))
                .ForMember(x => x.OverReadRate, opt => opt.MapFrom(p => p.OverReadRate))
                .ForMember(x => x.SignatureFile, opt => opt.MapFrom(p => p.SignatureFile))
                .ForMember(x => x.ResumeFile, opt => opt.MapFrom(p => p.ResumeFile))
                .ForMember(x => x.IsDefault, opt => opt.MapFrom(p => p.IsDefault))
                .ForMember(x => x.PhysicianId, opt => opt.MapFrom(p => p.PhysicianId))
                .ForMember(x => x.UpdateResultEntry, opt => opt.MapFrom(p => p.UpdateResultEntry))
                .ForMember(x => x.Tests, opt => opt.Ignore())
                .ForMember(x => x.Pods, opt => opt.Ignore())
                .ForMember(x => x.Licenses, opt => opt.Ignore())
                .ForMember(x => x.Npi, opt => opt.MapFrom(p => p.Npi));

            Mapper.CreateMap<CallsEntity, Call>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.CallId))
                .ForMember(x => x.CalledCustomerId, opt => opt.MapFrom(d => d.CalledCustomerId))
                .ForMember(x => x.CallDateTime, opt => opt.MapFrom(d => d.DateCreated))
                .ForMember(x => x.StartTime, opt => opt.MapFrom(d => d.TimeCreated))
                .ForMember(x => x.EndTime, opt => opt.MapFrom(d => d.TimeEnd))
                .ForMember(x => x.CallStatus, opt => opt.MapFrom(d => d.CallStatus))
                .ForMember(x => x.CalledInNumber, opt => opt.MapFrom(d => d.IncomingPhoneLine))
                .ForMember(x => x.CallerNumber, opt => opt.MapFrom(d => d.CallersPhoneNumber))
                .ForMember(x => x.CallBackNumber, opt => opt.MapFrom(d => d.CallBackNumber))
                .ForMember(x => x.IsIncoming, opt => opt.MapFrom(d => !d.OutBound))
                .ForMember(x => x.Status, opt => opt.MapFrom(d => d.Status))
                .ForMember(x => x.CreatedByOrgRoleUserId, opt => opt.MapFrom(d => d.CreatedByOrgRoleUserId))
                .ForMember(x => x.IsNewCustomer, opt => opt.MapFrom(d => d.IsNewCustomer))
                .ForMember(x => x.EventId, opt => opt.MapFrom(d => d.EventId))
                .ForMember(x => x.DateCreated, opt => opt.MapFrom(d => d.DateCreated))
                .ForMember(x => x.DateModified, opt => opt.MapFrom(d => d.DateModified))
                .ForMember(x => x.ReadAndUnderstood, opt => opt.MapFrom(d => d.ReadAndUnderstoodNotes))
                .ForMember(x => x.IsUploaded, opt => opt.MapFrom(d => d.IsUploaded))
                .ForMember(x => x.CampaignId, opt => opt.MapFrom(d => d.CampaignId))
                .ForMember(x => x.NotInterestedReasonId, opt => opt.MapFrom(d => d.NotInterestedReasonId))
                .ForMember(x => x.HealthPlanId, opt => opt.MapFrom(d => d.HealthPlanId))
                .ForMember(x => x.CallQueueId, opt => opt.MapFrom(d => d.CallQueueId))
                .ForMember(x => x.ProductTypeId, opt => opt.MapFrom(d => d.ProductTypeId))
                .ForMember(x => x.CustomTags, opt => opt.MapFrom(d => d.CustomTags));

            Mapper.CreateMap<Call, CallsEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.CallId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.CalledCustomerId, opt => opt.MapFrom(d => d.CalledCustomerId))
                .ForMember(x => x.DateCreated, opt => opt.MapFrom(d => d.CallDateTime))
                .ForMember(x => x.TimeCreated, opt => opt.MapFrom(d => d.StartTime))
                .ForMember(x => x.TimeEnd, opt => opt.MapFrom(d => d.EndTime))
                .ForMember(x => x.CallStatus, opt => opt.MapFrom(d => d.CallStatus))
                .ForMember(x => x.IncomingPhoneLine, opt => opt.MapFrom(d => d.CalledInNumber))
                .ForMember(x => x.CallersPhoneNumber, opt => opt.MapFrom(d => d.CallerNumber))
                .ForMember(x => x.CallBackNumber, opt => opt.MapFrom(d => d.CallBackNumber))
                .ForMember(x => x.OutBound, opt => opt.MapFrom(d => !d.IsIncoming))
                .ForMember(x => x.Status, opt => opt.MapFrom(d => d.Status > 0 ? d.Status : (long)CallStatus.Initiated))
                .ForMember(x => x.CreatedByOrgRoleUserId, opt => opt.MapFrom(d => d.CreatedByOrgRoleUserId))
                .ForMember(x => x.IsNewCustomer, opt => opt.MapFrom(d => d.IsNewCustomer))
                .ForMember(x => x.EventId, opt => opt.MapFrom(d => d.EventId))
                .ForMember(x => x.DateCreated, opt => opt.MapFrom(d => d.DateCreated))
                .ForMember(x => x.DateModified, opt => opt.MapFrom(d => d.DateModified))
                .ForMember(x => x.ReadAndUnderstoodNotes, opt => opt.MapFrom(d => d.ReadAndUnderstood))
                .ForMember(x => x.IsUploaded, opt => opt.MapFrom(d => d.IsUploaded))
                .ForMember(m => m.IsNew, opt => opt.MapFrom(d => d.Id <= 0))
                .ForMember(m => m.CallerName, opt => opt.Ignore())
                .ForMember(m => m.PromoCodeId, opt => opt.Ignore())
                .ForMember(m => m.AffiliateId, opt => opt.Ignore())
                .ForMember(x => x.CampaignId, opt => opt.MapFrom(d => d.CampaignId))
                .ForMember(x => x.NotInterestedReasonId, opt => opt.MapFrom(d => d.NotInterestedReasonId))
                .ForMember(x => x.HealthPlanId, opt => opt.MapFrom(d => d.HealthPlanId))
                .ForMember(x => x.CallQueueId, opt => opt.MapFrom(d => d.CallQueueId))
                .ForMember(x => x.CustomTags, opt => opt.MapFrom(d => d.CustomTags));


            Mapper.CreateMap<PhysicianEventAssignmentEditModel, PhysicianEventAssignment>()
                .ForMember(x => x.EventId, opt => opt.MapFrom(d => d.EventId))
                .ForMember(x => x.PhysicianId, opt => opt.MapFrom(d => d.PhysicianId))
                .ForMember(x => x.OverReadPhysicianId, opt => opt.MapFrom(d => d.OverReadPhysicianId))
                .ForMember(x => x.Notes, opt => opt.MapFrom(d => d.Notes))
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.DataRecorderMetaData, opt => opt.Ignore());

            Mapper.CreateMap<PhysicianCustomerAssignmentEditModel, PhysicianCustomerAssignment>()
                .ForMember(x => x.EventCustomerId, opt => opt.MapFrom(d => d.EventCustomerId))
                .ForMember(x => x.PhysicianId, opt => opt.MapFrom(d => d.PhysicianId))
                .ForMember(x => x.OverReadPhysicianId, opt => opt.MapFrom(d => d.OverReadPhysicianId))
                .ForMember(x => x.Notes, opt => opt.MapFrom(d => d.Notes))
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.DataRecorderMetaData, opt => opt.Ignore());

            Mapper.CreateMap<BasicBiometric, EventCustomerBasicBioMetricEntity>()
                .IgnoreEntityBaseFields()
                .ForMember(m => m.EventCustomerId, opt => opt.MapFrom(d => d.Id))
                .ForMember(m => m.IsActive, opt => opt.MapFrom(d => true))
                .ForMember(m => m.IsNew, opt => opt.MapFrom(d => d.Id > 0 ? false : true));

            Mapper.CreateMap<EventCustomerBasicBioMetricEntity, BasicBiometric>()
                .ForMember(m => m.Id, opt => opt.MapFrom(d => d.EventCustomerId));

            Mapper.CreateMap<HospitalPartnerCustomer, HospitalPartnerCustomerEditModel>()
                .ForMember(x => x.HospitalPartnerCustomerId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.DateCreated, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateCreated))
                .ForMember(x => x.CreatedByOrgRoleUserId,
                           opt =>
                           opt.MapFrom(
                               d =>
                               d.DataRecorderMetaData.DataRecorderCreator == null
                                   ? (long?)null
                                   : d.DataRecorderMetaData.DataRecorderCreator.Id))
                .ForMember(x => x.CustomerName, opt => opt.Ignore())
                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore())
                .ForMember(x => x.PrimaryCarePhysicianName, opt => opt.Ignore());


            Mapper.CreateMap<HospitalPartnerCustomerEditModel, HospitalPartnerCustomer>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.HospitalPartnerCustomerId))
                .ForMember(x => x.DataRecorderMetaData, opt => opt.MapFrom(d => new DataRecorderMetaData(d.CreatedByOrgRoleUserId, d.DateCreated, DateTime.Now)));

            Mapper.CreateMap<Notes, NotesDetailsEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.NoteId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.Notes, opt => opt.MapFrom(d => d.Text))
                .ForMember(x => x.Active, opt => opt.MapFrom(d => true))
                .ForMember(x => x.DateCreated, opt => opt.MapFrom(d => (d.DataRecorderMetaData != null ? (DateTime?)d.DataRecorderMetaData.DateCreated : null)))
                .ForMember(x => x.DateModified, opt => opt.MapFrom(d => (d.DataRecorderMetaData != null ? d.DataRecorderMetaData.DateModified : null)))
                .ForMember(x => x.CreatedByOrgRoleUserId, opt => opt.MapFrom(d => (d.DataRecorderMetaData != null && d.DataRecorderMetaData.DataRecorderCreator != null ? (long?)d.DataRecorderMetaData.DataRecorderCreator.Id : null)))
                .ForMember(x => x.ModifiedByOrgRoleUserId, opt => opt.MapFrom(d => (d.DataRecorderMetaData != null && d.DataRecorderMetaData.DataRecorderModifier != null ? (long?)d.DataRecorderMetaData.DataRecorderModifier.Id : null)))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id > 0 ? false : true))
                .ForMember(x => x.Events, opt => opt.Ignore())
                .ForMember(x => x.CustomerProfile, opt => opt.Ignore());


            Mapper.CreateMap<NotesDetailsEntity, Notes>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.NoteId))
                .ForMember(x => x.Text, opt => opt.MapFrom(d => d.Notes))
                .ForMember(x => x.DataRecorderMetaData, opt => opt.MapFrom(d => new DataRecorderMetaData((d.CreatedByOrgRoleUserId.HasValue ? d.CreatedByOrgRoleUserId.Value : 0), d.DateCreated.HasValue ? d.DateCreated.Value : DateTime.Now, d.DateModified)
                                                                                    {
                                                                                        DataRecorderModifier = d.ModifiedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(d.ModifiedByOrgRoleUserId.Value) : null
                                                                                    }));

            Mapper.CreateMap<Test, TestViewModel>()
                .ForMember(x => x.TestId, opt => opt.MapFrom(d => d.Id))

                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore());

            Mapper.CreateMap<Package, PackageEditModel>()
                .ForMember(x => x.AllRoles, opt => opt.Ignore())
                .ForMember(x => x.AllTests, opt => opt.Ignore())
                .ForMember(x => x.SelectedRoles, opt => opt.Ignore())
                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore())
                .ForMember(x => x.SelectedTests, opt => opt.Ignore())
                .ForMember(x => x.Gender, opt => opt.MapFrom(d => d.Gender))
                .ForMember(x => x.ForOrderDisplayFile, opt => opt.Ignore());


            Mapper.CreateMap<PackageEditModel, Package>()
                .ForMember(x => x.DataRecorderMetaData, opt => opt.Ignore())
                .ForMember(x => x.IsActive, opt => opt.Ignore())
                .ForMember(x => x.Tests, opt => opt.Ignore())
                .ForMember(x => x.Gender, opt => opt.MapFrom(d => d.Gender))
                .ForMember(x => x.ForOrderDisplayFileId, opt => opt.Ignore());

            Mapper.CreateMap<Test, TestEditModel>()
                .ForMember(x => x.TestId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore())
                .ForMember(x => x.Roles, opt => opt.Ignore())
                .ForMember(x => x.IsTestCoveredByInsurance, opt => opt.Ignore())
                .ForMember(x => x.Gender, opt => opt.MapFrom(d => d.Gender))
                .ForMember(x => x.ReimbursementRate, opt => opt.MapFrom(d => d.ReimbursementRate))
                .ForMember(x => x.MediaUrl, opt => opt.MapFrom(d => d.MediaUrl))
                .ForMember(x => x.BillingAccountId, opt => opt.Ignore())
                .ForMember(x => x.NotValidateChatStartDate, opt => opt.Ignore());

            Mapper.CreateMap<Package, PackageViewModel>()
                .ForMember(x => x.PackageType, opt => opt.MapFrom(d => d.PackageTypeId == (long)PackageType.Retail ? PackageType.Retail.ToString() : PackageType.Corporate.ToString()))
                .ForMember(x => x.SelectedRoles, opt => opt.Ignore())
                .ForMember(x => x.SelectedTests, opt => opt.Ignore());

            Mapper.CreateMap<TestEditModel, Test>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.TestId))
                .ForMember(x => x.ReimbursementRate, opt => opt.MapFrom(d => d.ReimbursementRate))
                .ForMember(x => x.MediaUrl, opt => opt.MapFrom(d => d.MediaUrl))
                .ForMember(x => x.Gender, opt => opt.MapFrom(d => d.Gender));


            Mapper.CreateMap<PackageTest, PackageTestEntity>()
                .IgnoreEntityBaseFields()
                .ForMember(x => x.IsActive, opt => opt.MapFrom(d => true))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id > 0 ? false : true));

            Mapper.CreateMap<PackageTest, PackageTestEditModel>()
                .ForMember(x => x.IsDefault, opt => opt.Ignore());

            Mapper.CreateMap<PackageTestEditModel, PackageTest>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateModified, opt => opt.Ignore())
                .ForMember(x => x.PackageId, opt => opt.Ignore());

            Mapper.CreateMap<PackageTestEntity, PackageTest>().ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<CustomerCriticalData, CustomerEventCriticalTestDataEntity>()
                .IgnoreEntityBaseFields()
                .ForMember(x => x.CustomerEventScreeningTestId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.ContactNumber, opt => opt.MapFrom(d => d.ContactNumber != null ? d.ContactNumber.AreaCode + d.ContactNumber.Number : string.Empty))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(d => true))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));

            Mapper.CreateMap<CustomerEventCriticalTestDataEntity, CustomerCriticalData>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.CustomerEventScreeningTestId))
                .ForMember(x => x.ContactNumber, opt => opt.MapFrom(d => PhoneNumber.Create(d.ContactNumber, PhoneNumberType.Unknown)))
                .ForMember(x => x.EventId, opt => opt.Ignore())
                .ForMember(x => x.CustomerId, opt => opt.Ignore())
                .ForMember(x => x.TestId, opt => opt.Ignore());

            Mapper.CreateMap<TempCartEntity, TempCart>()
                .ForMember(x => x.LoginAttempt, opt => opt.MapFrom(d => d.LoginAtempt));

            Mapper.CreateMap<TempCart, TempCartEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.LoginAtempt, opt => opt.MapFrom(d => d.LoginAttempt))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));

            Mapper.CreateMap<EventPackage, EventPackageOrderItemViewModel>()
                .ForMember(x => x.Description, opt => opt.MapFrom(d => d.Package.Description))
                .ForMember(x => x.DescriptiononUpsellSection, opt => opt.MapFrom(d => d.Package.DescriptiononUpsellSection))
                .ForMember(x => x.EventPackageId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(d => d.Package.Name))
                .ForMember(x => x.PackageId, opt => opt.MapFrom(d => d.Package.Id))
                .ForMember(x => x.PackageInfoUrl, opt => opt.MapFrom(d => d.Package.PackageInfoUrl))
                .ForMember(x => x.ImageUrlForOnlineDisplay, opt => opt.Ignore())
                .ForMember(x => x.NotAvailable, opt => opt.Ignore())
                .ForMember(x => x.NotAvailabilityMessage, opt => opt.Ignore())
                .ForMember(x => x.IsRecommended, opt => opt.Ignore())
                .ForMember(x => x.DisplaySequence, opt => opt.Ignore())
                .ForMember(x => x.IsLowestPrice, opt => opt.Ignore())
                .ForMember(x => x.IsHighestPrice, opt => opt.Ignore());

            Mapper.CreateMap<EventTest, EventTestOrderItemViewModel>()
                .ForMember(x => x.EventTestId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(d => d.Test.Name))
                .ForMember(x => x.Price, opt => opt.MapFrom(d => d.Price))
                .ForMember(x => x.Description, opt => opt.MapFrom(d => d.Test.Description))
                .ForMember(x => x.MinAge, opt => opt.MapFrom(d => d.Test.MinAge.HasValue ? d.Test.MinAge.Value : 0))
                .ForMember(x => x.MaxAge, opt => opt.MapFrom(d => d.Test.MaxAge.HasValue ? d.Test.MaxAge.Value : 0))
                .ForMember(x => x.Alias, opt => opt.MapFrom(d => d.Test.Alias))
                .ForMember(x => x.RelativeOrder, opt => opt.MapFrom(d => d.Test.RelativeOrder))
                .ForMember(x => x.AddDefaultToOrder, opt => opt.MapFrom(d => d.Test.IsDefaultSelectionForOrder))
                .ForMember(x => x.NotAvailable, opt => opt.Ignore())
                .ForMember(x => x.NotAvailabilityMessage, opt => opt.Ignore())
                .ForMember(x => x.MediaUrl, opt => opt.MapFrom(x => x.Test.MediaUrl))
                .ForMember(x => x.Tests, opt => opt.Ignore());


            Mapper.CreateMap<ElectronicProduct, ProductOrderItemViewModel>()
                .ForMember(x => x.ProductId, opt => opt.MapFrom(d => d.Id));

            Mapper.CreateMap<ShippingOption, ShippingOptionOrderItemViewModel>()
                .ForMember(x => x.ShippingOptionId, opt => opt.MapFrom(d => d.Id));

            Mapper.CreateMap<Customer, SchedulingCustomerEditModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.CustomerId))
                .ForMember(x => x.FullName, opt => opt.MapFrom(d => d.Name))
                .ForMember(x => x.HomeNumber, opt => opt.MapFrom(d => PhoneNumber.ToNumber(d.HomePhoneNumber.ToString())))
                .ForMember(x => x.Gender, opt => opt.MapFrom(d => (int)d.Gender))
                .ForMember(x => x.Password, opt => opt.Ignore())
                .ForMember(x => x.ConfirmPassword, opt => opt.Ignore())
                .ForMember(x => x.ShippingAddress, opt => opt.Ignore())
                .ForMember(x => x.InsuranceIdRequired, opt => opt.Ignore())
                 .ForMember(x => x.InsuranceIdLabel, opt => opt.Ignore())
                .ForMember(x => x.ConfirmationToEnablTexting, opt => opt.MapFrom(d => d.EnableTexting))
                .ForMember(x => x.EnableTexting, opt => opt.Ignore())
                 .ForMember(x => x.ConfirmationToEnableVoiceMail, opt => opt.MapFrom(d => d.EnableVoiceMail))
                .ForMember(x => x.EnableVoiceMail, opt => opt.Ignore())
                .ForMember(x => x.PhoneCell, opt => opt.MapFrom(d => PhoneNumber.ToNumber(d.MobilePhoneNumber.ToString())))
                .ForMember(x => x.CaptureSsn, opt => opt.Ignore())
                .ForMember(x => x.RequestValidationModel, opt => opt.Ignore())
                .ForMember(x => x.UserName, opt => opt.Ignore())
                .ForMember(x => x.IsRegisteringForCorporateEvent, opt => opt.Ignore());


            Mapper.CreateMap<ProspectCustomer, ProspectCustomerEditModel>()
                .ForMember(x => x.RequestValidationModel, opt => opt.Ignore())
                .ForMember(x => x.IsCallBackPhoneNumberRequired, opt => opt.Ignore());
            // .ForMember(x => x.CallBackRequestedOn, opt => opt.Ignore()) 
            //.ForMember(x => x.CallBackRequestedDate, opt => opt.Ignore());

            Mapper.CreateMap<ProspectCustomerEditModel, ProspectCustomer>()
                .ForMember(x => x.PhoneNumber, opt => opt.Ignore())
                .ForMember(x => x.SourceCodeId, opt => opt.Ignore())
                .ForMember(x => x.CustomerId, opt => opt.Ignore())
                .ForMember(x => x.IsConverted, opt => opt.Ignore())
                .ForMember(x => x.ConvertedOnDate, opt => opt.Ignore())
                .ForMember(x => x.CreatedOn, opt => opt.Ignore())
                .ForMember(x => x.IsContacted, opt => opt.Ignore())
                .ForMember(x => x.ContactedDate, opt => opt.Ignore())
                .ForMember(x => x.ContactedBy, opt => opt.Ignore())
                .ForMember(x => x.Status, opt => opt.Ignore())
                .ForMember(x => x.CallBackRequestedOn, opt => opt.Ignore())
                .ForMember(x => x.IsQueuedForCallBack, opt => opt.Ignore())
                .ForMember(x => x.CallBackRequestedDate, opt => opt.Ignore())
                .ForMember(x => x.TagUpdateDate, opt => opt.Ignore());


            Mapper.CreateMap<PackageSourceCodeDiscountEntity, SourceCodeItemWiseDiscount>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.PackageId))
                .ForMember(x => x.DiscountAmount, opt => opt.MapFrom(d => d.Discount))
                .ForMember(x => x.DiscountValueType,
                           opt => opt.MapFrom(d => d.IsPercentage ? DiscountValueType.Percent : DiscountValueType.Money));

            Mapper.CreateMap<TestSourceCodeDiscountEntity, SourceCodeItemWiseDiscount>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.TestId))
                .ForMember(x => x.DiscountAmount, opt => opt.MapFrom(d => d.Discount))
                .ForMember(x => x.DiscountValueType,
                           opt => opt.MapFrom(d => d.IsPercentage ? DiscountValueType.Percent : DiscountValueType.Money));

            Mapper.CreateMap<ProductSourceCodeDiscountEntity, SourceCodeItemWiseDiscount>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.ProductId))
                .ForMember(x => x.DiscountAmount, opt => opt.MapFrom(d => d.Discount))
                .ForMember(x => x.DiscountValueType,
                           opt => opt.MapFrom(d => d.IsPercentage ? DiscountValueType.Percent : DiscountValueType.Money));

            Mapper.CreateMap<ShippingOptionSourceCodeDiscountEntity, SourceCodeItemWiseDiscount>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.ShippingOptionId))
                .ForMember(x => x.DiscountAmount, opt => opt.MapFrom(d => d.Discount))
                .ForMember(x => x.DiscountValueType,
                           opt => opt.MapFrom(d => d.IsPercentage ? DiscountValueType.Percent : DiscountValueType.Money));

            Mapper.CreateMap<SourceCode, SourceCodeEditModel>()
                .ForMember(x => x.SourceCodeTypeId, opt => opt.MapFrom(d => (long)d.DiscountType))
                .ForMember(x => x.CouponValueType, opt => opt.MapFrom(d => (int)d.DiscountValueType))
                .ForMember(x => x.CustomerType, opt => opt.MapFrom(d => (int)d.CustomerType))
                .ForMember(x => x.SelectedSignUpModes, opt => opt.MapFrom(d => d.SelectedSignUpModes == null ? null : d.SelectedSignUpModes.Cast<int>()))
                .ForMember(x => x.AllPackages, opt => opt.Ignore())
                .ForMember(x => x.AllTests, opt => opt.Ignore())
                .ForMember(x => x.AllShippingOptions, opt => opt.Ignore())
                .ForMember(x => x.AllProducts, opt => opt.Ignore())
                .ForMember(x => x.AllSignUpModes, opt => opt.Ignore())
                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore())
                .ForMember(x => x.Events, opt => opt.Ignore());


            Mapper.CreateMap<SourceCode, SourceCodeViewModel>()
                .ForMember(x => x.PackageDiscounts, opt => opt.Ignore())
                .ForMember(x => x.TestDiscounts, opt => opt.Ignore())
                .ForMember(x => x.ProductDiscounts, opt => opt.Ignore())
                .ForMember(x => x.ShippingDiscounts, opt => opt.Ignore());

            Mapper.CreateMap<SourceCodeEditModel, SourceCode>()
                .ForMember(x => x.DiscountType, opt => opt.MapFrom(d => (DiscountType)d.SourceCodeTypeId))
                .ForMember(x => x.DiscountValueType,
                           opt => opt.MapFrom(d => (DiscountValueType)d.CouponValueType))
                .ForMember(x => x.CustomerType, opt => opt.MapFrom(d => (CustomerType)d.CustomerType))
                .ForMember(x => x.SelectedSignUpModes, opt => opt.MapFrom(d => (d.SelectedSignUpModes == null || d.SelectedSignUpModes.Count() == Enum.GetNames(typeof(SignUpMode)).Length) ? null : d.SelectedSignUpModes.Cast<SignUpMode>()))
                .ForMember(x => x.IsActive, opt => opt.Ignore())
                .ForMember(x => x.DataRecorderMetaData, opt => opt.Ignore())
                .ForMember(x => x.EventIds, opt => opt.MapFrom(d => d.Events != null ? d.Events.Select(e => e.EventId).ToArray() : null));

            Mapper.CreateMap<SourceCodeItemWiseDiscount, SourceCodeItemWiseDiscountEditModel>()
                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore())
                .ForMember(x => x.Name, opt => opt.Ignore());

            Mapper.CreateMap<SourceCodeItemWiseDiscountEditModel, SourceCodeItemWiseDiscount>();

            Mapper.CreateMap<HealthAssessmentQuestion, HealthAssessmentQuestionEditModel>()
                .ForMember(x => x.QuestionId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.DefaultAnswer, opt => opt.MapFrom(d => d.DefaultValue))
                .ForMember(x => x.Answer, opt => opt.Ignore());

            Mapper.CreateMap<CustomerEventTestStateEntity, CustomerEventTestState>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.CustomerEventTestStateId))
                .ForMember(x => x.DataRecorderMetaData, opt => opt.MapFrom(d => new DataRecorderMetaData(d.CreatedByOrgRoleUserId, d.CreatedOn, d.UpdatedOn)));

            Mapper.CreateMap<CustomerEventScreeningTestsEntity, CustomerEventScreeningTests>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.CustomerEventScreeningTestId));

            Mapper.CreateMap<ShippingDetail, ShippingDetailEditModel>()
                .ForMember(x => x.ShippingDetailId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.Status, opt => opt.MapFrom(d => (int)d.Status))
                .ForMember(x => x.ShippingOptionName, opt => opt.MapFrom(d => d.ShippingOption != null ? d.ShippingOption.Name : string.Empty))
                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore());

            Mapper.CreateMap<TemplateMacroEntity, TemplateMacro>()
                .ForMember(x => x.Sequence, opt => opt.MapFrom(d => d.EmailTemplateMacro.Single().Sequence))
                .ForMember(x => x.ParameterValue, opt => opt.MapFrom(d => d.EmailTemplateMacro.Single().ParameterValue));

            Mapper.CreateMap<ContentEntity, Content>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.ContentId))
                .ForMember(x => x.ContentHtml, opt => opt.MapFrom(d => d.Content))
                .ForMember(x => x.DataRecorderMetaData,
                           opt => opt.MapFrom(d => new DataRecorderMetaData(d.CreatedBy, d.DateCreated, d.DateModified) { DataRecorderModifier = d.ModifiedBy.HasValue ? new OrganizationRoleUser(d.ModifiedBy.Value) : null }));

            Mapper.CreateMap<Content, ContentEntity>()
                .IgnoreEntityBaseFields()
                .ForMember(x => x.Content, opt => opt.MapFrom(d => d.ContentHtml))
                .ForMember(x => x.ContentId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderCreator.Id))
                .ForMember(x => x.DateCreated, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateCreated))
                .ForMember(x => x.ModifiedBy, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderModifier != null ? (long?)d.DataRecorderMetaData.DataRecorderModifier.Id : null))
                .ForMember(x => x.DateModified, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateModified))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));

            Mapper.CreateMap<Content, ContentEditModel>()
                .ForMember(x => x.Content, opt => opt.MapFrom(d => d.ContentHtml))
                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore());

            Mapper.CreateMap<Content, ContentViewModel>();

            Mapper.CreateMap<ContentEditModel, Content>()
                .ForMember(x => x.ContentHtml, opt => opt.MapFrom(d => d.Content))
                .ForMember(x => x.IsActive, opt => opt.Ignore())
                .ForMember(x => x.DataRecorderMetaData, opt => opt.Ignore());

            Mapper.CreateMap<EventSchedulingSlot, EventSchedulingSlotEntity>()
                .IgnoreEntityBaseFields()
                .ForMember(x => x.SlotId, opt => opt.MapFrom(m => m.Id))
                .ForMember(x => x.Status, opt => opt.MapFrom(m => (long)m.Status))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(m => m.Id < 1));

            Mapper.CreateMap<EventSchedulingSlotEntity, EventSchedulingSlot>()
                .ForMember(x => x.Id, opt => opt.MapFrom(m => m.SlotId))
                .ForMember(x => x.Status, opt => opt.MapFrom(m => (AppointmentStatus)m.Status));

            Mapper.CreateMap<EventAppointmentEditModel, EventSchedulingSlot>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.AppointmentId))
                .ForMember(x => x.Status, opt => opt.UseValue(AppointmentStatus.Free))
                .ForMember(x => x.Reason, opt => opt.UseValue(string.Empty))
                .ForMember(x => x.DateCreated, opt => opt.UseValue(DateTime.Now))
                .ForMember(x => x.DateModified, opt => opt.UseValue(DateTime.Now));

            Mapper.CreateMap<HafTemplateEntity, HealthAssessmentTemplate>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.HaftemplateId))
                .ForMember(x => x.TemplateType, opt => opt.MapFrom(d => d.Type.HasValue ? (long?)d.Type.Value : null))
                .ForMember(x => x.DataRecorderMetaData,
                           opt => opt.MapFrom(d => new DataRecorderMetaData(d.CreatedBy, d.DateCreated, d.DateModified) { DataRecorderModifier = d.ModifiedBy.HasValue ? new OrganizationRoleUser(d.ModifiedBy.Value) : null }))
                .ForMember(x => x.QuestionIds, opt => opt.MapFrom(d => d.HafTemplateQuestion != null ? d.HafTemplateQuestion.Select(tq => tq.QuestionId).ToArray() : null));

            Mapper.CreateMap<HealthAssessmentTemplate, HafTemplateEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.HaftemplateId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.Type, opt => opt.MapFrom(d => d.TemplateType.HasValue ? (long?)d.TemplateType.Value : null))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderCreator.Id))
                .ForMember(x => x.DateCreated, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateCreated))
                .ForMember(x => x.ModifiedBy, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderModifier != null ? (long?)d.DataRecorderMetaData.DataRecorderModifier.Id : null))
                .ForMember(x => x.DateModified, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateModified))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));

            Mapper.CreateMap<HealthAssessmentTemplate, HealthAssessmentTemplateViewModel>()
                .ForMember(m => m.Criterias, opt => opt.Ignore())
                .ForMember(m => m.TemplateType, opt => opt.MapFrom(d => d.TemplateType.HasValue ? ((HealthAssessmentTemplateType)d.TemplateType.Value).GetDescription() : string.Empty));

            Mapper.CreateMap<HealthAssessmentTemplate, HealthAssessmentTemplateEditModel>()
                .ForMember(x => x.SelectedQuestionIds, opt => opt.MapFrom(d => d.QuestionIds))
                .ForMember(x => x.TemplateType, opt => opt.MapFrom(d => d.TemplateType.HasValue ? d.TemplateType : null))
                .ForMember(x => x.Category, opt => opt.MapFrom(d => d.Category))
                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore())
                .ForMember(x => x.IsNewTemplate, opt => opt.Ignore());

            Mapper.CreateMap<HealthAssessmentTemplateEditModel, HealthAssessmentTemplate>()
                .ForMember(x => x.QuestionIds, opt => opt.MapFrom(d => d.SelectedQuestionIds))
                .ForMember(x => x.TemplateType, opt => opt.MapFrom(d => d.TemplateType))
                .ForMember(x => x.Category, opt => opt.MapFrom(d => d.Category))
                .ForMember(x => x.PublicationDate, opt => opt.Ignore())
                .ForMember(x => x.DataRecorderMetaData, opt => opt.Ignore());

            Mapper.CreateMap<EventNotificationEntity, EventNotification>();

            Mapper.CreateMap<EventNotification, EventNotificationEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<VwHospitalPartnerCustomersEntity, HospitalPartnerCustomer>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.HospitalPartnerCustomerId))
                .ForMember(x => x.DataRecorderMetaData,
                           opt => opt.MapFrom(d => new DataRecorderMetaData(d.CreatedByOrgRoleUserId, d.DateCreated, d.DateModified) { DataRecorderModifier = new OrganizationRoleUser(d.ModifiedByOrgRoleUserId) }));

            Mapper.CreateMap<EventCustomerNotification, EventCustomerNotificationEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<EventCustomerNotificationEntity, EventCustomerNotification>();

            Mapper.CreateMap<EventAppointmentChangeLog, EventAppointmentChangeLogEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<EventAppointmentChangeLogEntity, EventAppointmentChangeLog>();

            Mapper.CreateMap<EventHospitalPartnerEntity, EventHospitalPartner>();

            Mapper.CreateMap<PodRoomTestEntity, PodRoomTest>();

            Mapper.CreateMap<PodRoomTest, PodRoomTestEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<PodRoomEntity, PodRoom>()
                  .ForMember(x => x.Id, opt => opt.MapFrom(d => d.PodRoomId));

            Mapper.CreateMap<PodRoom, PodRoomEntity>()
                  .IgnoreEntityBaseFields()
                  .IgnoreEntityCollection()
                  .ForMember(x => x.PodRoomId, opt => opt.MapFrom(d => d.Id))
                  .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));

            Mapper.CreateMap<EventPodRoomTestEntity, EventPodRoomTest>();

            Mapper.CreateMap<EventPodRoomTest, EventPodRoomTestEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<EventPodRoomEntity, EventPodRoom>()
                  .ForMember(x => x.Id, opt => opt.MapFrom(d => d.EventPodRoomId));

            Mapper.CreateMap<EventPodRoom, EventPodRoomEntity>()
                  .IgnoreEntityBaseFields()
                  .IgnoreEntityCollection()
                  .ForMember(x => x.EventPodRoomId, opt => opt.MapFrom(d => d.Id))
                  .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));

            Mapper.CreateMap<EventPodEntity, EventPod>()
                  .ForMember(x => x.Id, opt => opt.MapFrom(d => d.EventPodId));

            Mapper.CreateMap<EventPod, EventPodEntity>()
                  .IgnoreEntityBaseFields()
                  .IgnoreEntityCollection()
                  .ForMember(x => x.EventPodId, opt => opt.MapFrom(d => d.Id))
                  .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));


            Mapper.CreateMap<PrimaryCarePhysician, PrimaryCarePhysicianEditModel>()
                  .ForMember(x => x.CustomerId, opt => opt.MapFrom(d => d.CustomerId))
                  .ForMember(x => x.FullName, opt => opt.MapFrom(d => d.Name))
                  .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(d => d.Primary))
                  .ForMember(x => x.PcpAddressVerifiedOn, opt => opt.MapFrom(d => d.PcpAddressVerifiedOn))
                  .ForMember(x => x.IsPcpAddressVerified, opt => opt.MapFrom(d => d.IsPcpAddressVerified))
                  .ForMember(x => x.PcpAddressVerifiedBy, opt => opt.MapFrom(d => d.PcpAddressVerifiedBy))
                  .ForMember(x => x.PcpAddresVarifiedByRole, opt => opt.Ignore())
                  .ForMember(x => x.PcpAddresVarifiedByUserName, opt => opt.Ignore())

                  .ForMember(x => x.HasSameAddress, opt => opt.Ignore())
                  .ForMember(x => x.FeedbackMessage, opt => opt.Ignore())
                  .ForMember(x => x.Phone, opt => opt.Ignore());

            Mapper.CreateMap<InsuranceServiceTypeEntity, InsuranceServiceType>()
               .ForMember(x => x.Id, opt => opt.MapFrom(d => d.InsuranceServiceTypeId));

            Mapper.CreateMap<InsuranceCompanyEntity, InsuranceCompany>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.InsuranceCompanyId));

            Mapper.CreateMap<InsuranceCompany, InsuranceCompanyEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.InsuranceCompanyId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));

            Mapper.CreateMap<EligibilityEntity, Eligibility>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.EligibilityId));

            Mapper.CreateMap<Eligibility, EligibilityEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.EligibilityId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));

            Mapper.CreateMap<EventCustomerEligibilityEntity, EventCustomerEligibility>();

            Mapper.CreateMap<EventCustomerEligibility, EventCustomerEligibilityEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));


            Mapper.CreateMap<ZipDataEntity, ZipData>()
                .ForMember(x => x.StateCode, opt => opt.MapFrom(d => d.State))
                .ForMember(x => x.City, opt => opt.MapFrom(d => d.CityAliasMixedCase));

            Mapper.CreateMap<BillingAccountEntity, BillingAccount>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.BillingAccountId))
                .ForMember(x => x.Password, opt => opt.MapFrom(d => new PasswordCryptographyService().Decrypt(d.Password)))
                .ForMember(x => x.CustomerKey, opt => opt.MapFrom(d => new PasswordCryptographyService().Decrypt(d.CustomerKey)));

            Mapper.CreateMap<BillingAccountTestEntity, BillingAccountTest>();

            Mapper.CreateMap<CustomerBillingAccountEntity, CustomerBillingAccount>();

            Mapper.CreateMap<CustomerBillingAccount, CustomerBillingAccountEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<EncounterEntity, Encounter>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.EncounterId));

            Mapper.CreateMap<Encounter, EncounterEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.EncounterId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<EventCustomerEncounterEntity, EventCustomerEncounter>();

            Mapper.CreateMap<EventCustomerEncounter, EventCustomerEncounterEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<ClaimEntity, Claim>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.ClaimId));

            Mapper.CreateMap<Claim, ClaimEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.ClaimId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<HospitalFacilityEditModel, HospitalFacility>()
                .ForMember(x => x.ContractId, opt => opt.MapFrom(mv => mv.ContractId))
                .ForMember(x => x.Id, opt => opt.MapFrom(mv => mv.OrganizationEditModel.Id))
                .ForMember(x => x.ResultLetterFileId, opt => opt.MapFrom(mv => mv.ResultLetterFile != null ? (long?)mv.ResultLetterFile.Id : null))
                .ForMember(x => x.OrganizationType, opt => opt.Ignore())
                .ForMember(x => x.Name, opt => opt.Ignore())
                .ForMember(x => x.Description, opt => opt.Ignore())
                .ForMember(x => x.BusinessAddressId, opt => opt.Ignore())
                .ForMember(x => x.BillingAddressId, opt => opt.Ignore())
                .ForMember(x => x.PhoneNumber, opt => opt.Ignore())
                .ForMember(x => x.FaxNumber, opt => opt.Ignore())
                .ForMember(x => x.Email, opt => opt.Ignore())
                .ForMember(x => x.LogoImageId, opt => opt.Ignore())
                .ForMember(x => x.TeamImageId, opt => opt.Ignore());

            Mapper.CreateMap<HospitalFacility, HospitalFacilityEditModel>()
                .ForMember(x => x.ContractId, opt => opt.MapFrom(mv => mv.ContractId))
                .ForMember(x => x.ResultLetterFile, opt => opt.Ignore())
                .ForMember(x => x.OrganizationEditModel, opt => opt.Ignore())
                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore());

            Mapper.CreateMap<CriteriaEntity, Criteria>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.CriteriaId));

            Mapper.CreateMap<Criteria, CriteriaEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.CriteriaId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));

            Mapper.CreateMap<CallQueueEntity, CallQueue>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.CallQueueId))
                .ForMember(x => x.DataRecorderMetaData,
                    opt => opt.MapFrom(d => new DataRecorderMetaData(d.CreatedByOrgRoleUserId, d.DateCreated, d.DateModified)
                                {
                                    DataRecorderModifier = d.ModifiedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(d.ModifiedByOrgRoleUserId.Value) : null
                                }));

            Mapper.CreateMap<CallQueue, CallQueueEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.CallQueueId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.CreatedByOrgRoleUserId, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderCreator.Id))
                .ForMember(x => x.DateCreated, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateCreated))
                .ForMember(x => x.ModifiedByOrgRoleUserId, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderModifier != null ? (long?)d.DataRecorderMetaData.DataRecorderModifier.Id : null))
                .ForMember(x => x.DateModified, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateModified))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));

            Mapper.CreateMap<CallQueue, CallQueueEditModel>()
                .ForMember(x => x.Criterias, opt => opt.Ignore())
                .ForMember(x => x.Assignments, opt => opt.Ignore())
                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore())
                .ForMember(x => x.ScriptId, opt => opt.MapFrom(d => d.ScriptId.HasValue ? d.ScriptId.Value : 0))
                .ForMember(x => x.ScriptText, opt => opt.Ignore());

            Mapper.CreateMap<CallQueueEditModel, CallQueue>()
                .ForMember(x => x.IsActive, opt => opt.UseValue(true))
                .ForMember(x => x.IsQueueGenerated, opt => opt.UseValue(false))
                .ForMember(x => x.IsManual, opt => opt.UseValue(true))
                .ForMember(x => x.Category, opt => opt.Ignore())
                .ForMember(x => x.LastQueueGeneratedDate, opt => opt.Ignore())
                .ForMember(x => x.DataRecorderMetaData, opt => opt.Ignore())
                .ForMember(x => x.IsHealthPlan, opt => opt.UseValue(false));

            Mapper.CreateMap<CallQueueCriteriaEntity, CallQueueCriteria>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.CallQueueCriteriaId));

            Mapper.CreateMap<CallQueueCriteria, CallQueueCriteriaEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.CallQueueCriteriaId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));

            Mapper.CreateMap<CallQueueCriteria, CallQueueCriteriaEditModel>()
                .ForMember(x => x.Name, opt => opt.Ignore());

            Mapper.CreateMap<CallQueueCriteriaEditModel, CallQueueCriteria>()
                .ForMember(x => x.IsActive, opt => opt.UseValue(true))
                .ForMember(x => x.Sequence, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<CallQueueAssignmentEntity, CallQueueAssignment>();

            Mapper.CreateMap<CallQueueAssignment, CallQueueAssignmentEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<CallQueueAssignment, CallQueueAssignmentEditModel>()
                .ForMember(x => x.Name, opt => opt.Ignore())
                .ForMember(x => x.IsExistInOtherCriteria, opt => opt.Ignore())
                .ForMember(x => x.StartDate, opt => opt.Ignore())
                .ForMember(x => x.EndDate, opt => opt.Ignore())
                .ForMember(x => x.IsEdited, opt => opt.Ignore())
                .ForMember(x => x.HealthPlanCriteriaId, opt => opt.Ignore());

            Mapper.CreateMap<CallQueueAssignmentEditModel, CallQueueAssignment>();

            Mapper.CreateMap<CallQueueCustomerEntity, CallQueueCustomer>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.CallQueueCustomerId))
                .ForMember(x => x.Status, opt => opt.MapFrom(d => (CallQueueStatus)d.Status))
                .ForMember(x => x.PhoneHome, opt => opt.MapFrom(d => string.IsNullOrEmpty(d.PhoneHome) ? null : PhoneNumber.Create(d.PhoneHome, PhoneNumberType.Home)))
                .ForMember(x => x.PhoneOffice, opt => opt.MapFrom(d => string.IsNullOrEmpty(d.PhoneOffice) ? null : PhoneNumber.Create(d.PhoneOffice, PhoneNumberType.Office)))
                .ForMember(x => x.PhoneCell, opt => opt.MapFrom(d => string.IsNullOrEmpty(d.PhoneCell) ? null : PhoneNumber.Create(d.PhoneCell, PhoneNumberType.Mobile)));


            Mapper.CreateMap<CallQueueCustomer, CallQueueCustomerEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.CallQueueCustomerId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.Status, opt => opt.MapFrom(d => (long)d.Status))
                .ForMember(x => x.PhoneHome, opt => opt.MapFrom(d => d.PhoneHome != null ? d.PhoneHome.AreaCode + d.PhoneHome.Number : ""))
                .ForMember(x => x.PhoneCell, opt => opt.MapFrom(d => d.PhoneCell != null ? d.PhoneCell.AreaCode + d.PhoneCell.Number : ""))
                .ForMember(x => x.PhoneOffice, opt => opt.MapFrom(d => d.PhoneOffice != null ? d.PhoneOffice.AreaCode + d.PhoneOffice.Number : ""))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));

            Mapper.CreateMap<CallCenterNotesEntity, CallCenterNotes>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.CallCenterNotesId));

            Mapper.CreateMap<CallCenterNotes, CallCenterNotesEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.CallCenterNotesId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));

            Mapper.CreateMap<CallQueueCustomerCallEntity, CallQueueCustomerCall>();

            Mapper.CreateMap<CallQueueCustomerCall, CallQueueCustomerCallEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<ScriptsEntity, Script>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.ScriptId));

            Mapper.CreateMap<Script, ScriptsEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.ScriptId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.IsActive, opt => opt.UseValue(true))
                .ForMember(x => x.IsDefault, opt => opt.UseValue(true))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));

            Mapper.CreateMap<KynLabValues, KynLabValuesEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.CreatedByOrgRoleUserId, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderCreator.Id))
                .ForMember(x => x.DateCreated, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateCreated))
                .ForMember(x => x.ModifiedByOrgRoleUserId, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderModifier != null ? (long?)d.DataRecorderMetaData.DataRecorderModifier.Id : null))
                .ForMember(x => x.DateModified, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateModified))
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<KynLabValuesEntity, KynLabValues>()
                .ForMember(x => x.DataRecorderMetaData,
                    opt => opt.MapFrom(d => new DataRecorderMetaData(d.CreatedByOrgRoleUserId, d.DateCreated, d.DateModified)
                    {
                        DataRecorderModifier = d.ModifiedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(d.ModifiedByOrgRoleUserId.Value) : null
                    }));

            Mapper.CreateMap<PreApprovedTestEntity, PreApprovedTest>();
            //.ForMember(x => x.DataRecorderMetaData,
            //    opt => opt.MapFrom(d => new DataRecorderMetaData(d.CreatedByOrgRoleUserId, d.DateCreated, d.DateModified)
            //    {
            //        DataRecorderModifier = d.ModifiedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(d.ModifiedByOrgRoleUserId.Value) : null
            //    }));

            Mapper.CreateMap<PreApprovedTest, PreApprovedTestEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsActive, opt => opt.UseValue(true))
                //.ForMember(x => x.CreatedByOrgRoleUserId, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderCreator.Id))
                //.ForMember(x => x.DateCreated, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateCreated))
                //.ForMember(x => x.ModifiedByOrgRoleUserId, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderModifier != null ? (long?)d.DataRecorderMetaData.DataRecorderModifier.Id : null))
                //.ForMember(x => x.DateModified, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateModified))
                .ForMember(x => x.IsNew, opt => opt.UseValue(true))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));

            Mapper.CreateMap<HealthQuestionDependencyRuleEntity, HealthAssessmentQuestionDependencyRule>();

            Mapper.CreateMap<PhysicianMaster, PhysicianMasterEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.PhysicianMasterId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.PracticePhone, opt => opt.MapFrom(d => d.PracticePhone != null ? d.PracticePhone.AreaCode + d.PracticePhone.Number : ""))
                .ForMember(x => x.PracticeFax, opt => opt.MapFrom(d => d.PracticeFax != null ? d.PracticeFax.AreaCode + d.PracticeFax.Number : ""))
                .ForMember(x => x.IsActive, opt => opt.UseValue(true))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));

            Mapper.CreateMap<PhysicianMasterEntity, PhysicianMaster>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.PhysicianMasterId))
                .ForMember(x => x.PracticePhone, opt => opt.MapFrom(d => PhoneNumber.Create(d.PracticePhone, PhoneNumberType.Unknown)))
                .ForMember(x => x.PracticeFax, opt => opt.MapFrom(d => PhoneNumber.Create(d.PracticeFax, PhoneNumberType.Unknown)));

            Mapper.CreateMap<PhysicianMaster, PhysicianMasterViewModel>();

            Mapper.CreateMap<MedicareGroupDependencyRuleEntity, MedicareGroupDependencyRule>();

            Mapper.CreateMap<MedicareQuestionEntity, MedicareQuestion>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.QuestionId))
                .ForMember(x => x.ControlValues,
                    opt => opt.MapFrom(d => string.IsNullOrWhiteSpace(d.ControlValue) && string.IsNullOrWhiteSpace(d.Delimiter)
                                ? null : d.ControlValue.Split(new[] { d.Delimiter.Trim() }, StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray()))
                .ForMember(x => x.ControlType, opt => opt.MapFrom(d => (DisplayControlType)d.ControlType))

                .ForMember(x => x.MedicareQuestionsRemarks,
                    opt => opt.MapFrom(d => d.MedicareQuestionsRemarks != null ? d.MedicareQuestionsRemarks.ToArray() : null))
                .ForMember(x => x.MedicareGroupDependencyRules,
                    opt => opt.MapFrom(d => d.MedicareGroupDependencyRule != null ? d.MedicareGroupDependencyRule.ToArray() : null))
                .ForMember(x => x.DependencyRules,
                    opt => opt.MapFrom(d => d.MedicareQuestionDependencyRule != null ? d.MedicareQuestionDependencyRule.ToArray() : null));


            Mapper.CreateMap<MedicareQuestionsRemarksEntity, MedicareQuestionsRemark>();
            Mapper.CreateMap<MedicareQuestionGroupEntity, MedicareQuestionGroup>().ForMember(x => x.Id, opt => opt.MapFrom(m => m.GroupId));

            Mapper.CreateMap<MedicareQuestionDependencyRuleEntity, MedicareQuestionDependencyRule>();

            Mapper.CreateMap<CustomerMedicareQuestionAnswerEntity, MedicareQuestionAnswer>()
                .ForMember(x => x.Id, opt => opt.Ignore());


            Mapper.CreateMap<LookupEntity, Lookup>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.LookupId));

            Mapper.CreateMap<AccountPackageEntity, AccountPackage>();


            Mapper.CreateMap<AccountPackage, AccountPackageEntity>()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true))
                .IgnoreEntityBaseFields();

            Mapper.CreateMap<HospitalPartnerPackageEntity, HospitalPartnerPackage>();

            Mapper.CreateMap<HospitalPartnerPackage, HospitalPartnerPackageEntity>()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true))
                .IgnoreEntityBaseFields();

            Mapper.CreateMap<Package, EventPackageEditModel>()
                .ForMember(x => x.PackageId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.IsRecommended, opt => opt.Ignore())
                .ForMember(x => x.MostPopular, opt => opt.Ignore())
                .ForMember(x => x.BestValue, opt => opt.Ignore());

            Mapper.CreateMap<PreQualificationResultEntity, PreQualificationResult>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.PreQualificationResultId));

            Mapper.CreateMap<PreQualificationResult, PreQualificationResultEntity>()
                .IgnoreEntityBaseFields()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1))
                .ForMember(x => x.PreQualificationResultId, opt => opt.MapFrom(d => d.Id));


            Mapper.CreateMap<EventPhysicianTestEntity, EventPhysicianTest>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<EventPhysicianTest, EventPhysicianTestEntity>()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true))
                .IgnoreEntityBaseFields();

            Mapper.CreateMap<PriorityInQueueEntity, PriorityInQueue>();

            Mapper.CreateMap<PriorityInQueue, PriorityInQueueEntity>()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0))
                .IgnoreEntityBaseFields();

            Mapper.CreateMap<CustomerEventPriorityInQueueDataEntity, CustomerEventPriorityInQueueData>();

            Mapper.CreateMap<CustomerEventPriorityInQueueData, CustomerEventPriorityInQueueDataEntity>()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.CustomerEventScreeningTestID <= 0))
                .IgnoreEntityBaseFields();

            Mapper.CreateMap<CallQueueCustomerLockEntity, CallQueueCustomerLock>()
               .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<CallQueueCustomerLock, CallQueueCustomerLockEntity>()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true))
                .IgnoreEntityBaseFields();




            Mapper.CreateMap<CustomerTagEntity, CorporateCustomerCustomTag>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.CustomerTagId))
                .ForMember(x => x.DataRecorderMetaData,
                    opt => opt.MapFrom(d => new DataRecorderMetaData(d.CreatedByOrgRoleUserId, d.DateCreated, d.DateModified)
                    {
                        DataRecorderModifier = d.ModifiedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(d.ModifiedByOrgRoleUserId.Value) : null
                    }));

            Mapper.CreateMap<CorporateCustomerCustomTag, CustomerTagEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.CustomerTagId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.CreatedByOrgRoleUserId, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderCreator.Id))
                .ForMember(x => x.DateCreated, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateCreated))
                .ForMember(x => x.ModifiedByOrgRoleUserId, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderModifier != null ? (long?)d.DataRecorderMetaData.DataRecorderModifier.Id : null))
                .ForMember(x => x.DateModified, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateModified))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));

            Mapper.CreateMap<CorporateTagEntity, CorporateTag>().ForMember(x => x.Id, opt => opt.MapFrom(d => d.CorporateTagId));

            Mapper.CreateMap<CorporateTag, CorporateTagEntity>()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0))
                .ForMember(x => x.CorporateTagId, opt => opt.MapFrom(d => d.Id))
                .IgnoreEntityBaseFields();

            Mapper.CreateMap<SystemGeneratedCallQueueCriteriaEntity, SystemGeneratedCallQueueCriteria>()
                .ForMember(x => x.DataRecorderMetaData,
                    opt => opt.MapFrom(d => new DataRecorderMetaData(d.CreatedByOrgRoleUserId, d.DateCreated, d.DateModified)
                    {
                        DataRecorderModifier = d.ModifiedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(d.ModifiedByOrgRoleUserId.Value) : null
                    }));

            Mapper.CreateMap<SystemGeneratedCallQueueCriteria, SystemGeneratedCallQueueCriteriaEntity>()
                .ForMember(x => x.CreatedByOrgRoleUserId, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderCreator.Id))
                .ForMember(x => x.DateCreated, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateCreated))
                .ForMember(x => x.ModifiedByOrgRoleUserId, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderModifier != null ? (long?)d.DataRecorderMetaData.DataRecorderModifier.Id : null))
                .ForMember(x => x.DateModified, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateModified))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0))
                .ForMember(x => x.CallQueueCollectionViaSystemGeneratedCallQueueAssignment, opt => opt.Ignore())
                .IgnoreEntityCollection()
                .IgnoreEntityBaseFields();

            Mapper.CreateMap<EventCustomerResultBloodLab, EventCustomerResultBloodLabEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore())
                .ForMember(x => x.IsActive, opt => opt.UseValue(true));

            Mapper.CreateMap<EventCustomerResultBloodLabEntity, EventCustomerResultBloodLab>();
            Mapper.CreateMap<SystemGeneratedCallQueueAssignmentEntity, SystemGeneratedCallQueueAssignment>();
            Mapper.CreateMap<SystemGeneratedCallQueueAssignment, SystemGeneratedCallQueueAssignmentEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<Lab, LabEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0))
                .ForMember(x => x.IsActive, opt => opt.UseValue(true));

            Mapper.CreateMap<LabEntity, Lab>();

            Mapper.CreateMap<Language, LanguageEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0))
                .ForMember(x => x.IsActive, opt => opt.UseValue(true));

            Mapper.CreateMap<LanguageEntity, Language>();

            Mapper.CreateMap<EmailTemplateMacro, EmailTemplateMacroEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<ClinicalTestQualificationCriteria, ClinicalTestQualificationCriteriaEditModel>()
                .ForMember(m => m.AgeCriteriaSelected, opt => opt.MapFrom(x => x.AgeCondition.HasValue))
                .ForMember(m => m.GenderCriteriaSelected, opt => opt.MapFrom(x => x.Gender != Gender.Unspecified))
                .ForMember(m => m.NumberOfQuestionCriteriaSelected, opt => opt.MapFrom(x => x.NumberOfQuestion.HasValue))
                .ForMember(m => m.DisqualifierQuestionSelected, opt => opt.MapFrom(x => x.DisqualifierQuestionId.HasValue))
                .ForMember(m => m.Gender, opt => opt.MapFrom(x => x.Gender))
                .ForMember(m => m.GroupName, opt => opt.Ignore())
                .ForMember(m => m.TotalQuestionCount, opt => opt.Ignore());

            Mapper.CreateMap<CustomerClinicalQuestionAnswer, CustomerClinicalQuestionAnswerEntity>()
                .ForMember(m => m.IsNew, opt => opt.UseValue(true))
                .ForMember(m => m.CreatedBy, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderCreator.Id))
                .ForMember(m => m.CreatedOn, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateCreated))
                .ForMember(m => m.ModifiedBy, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderModifier != null ? (long?)d.DataRecorderMetaData.DataRecorderModifier.Id : null))
                .ForMember(m => m.ModifiedOn, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateModified))
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection();

            Mapper.CreateMap<CustomerClinicalQuestionAnswerEntity, CustomerClinicalQuestionAnswer>()
                .ForMember(m => m.DataRecorderMetaData, opt => opt.MapFrom(d => new DataRecorderMetaData(d.CreatedBy, d.CreatedOn, d.ModifiedOn)
                {
                    DataRecorderModifier = d.ModifiedBy.HasValue ? new OrganizationRoleUser(d.ModifiedBy.Value) : null
                }));

            Mapper.CreateMap<ClinicalTestQualificationCriteriaEditModel, ClinicalTestQualificationCriteria>()
                .ForMember(m => m.IsPublished, opt => opt.Ignore())
                .ForMember(m => m.DataRecorderMetaData, opt => opt.Ignore())
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.Gender, opt => opt.MapFrom(x => (x.Gender == Gender.Male || x.Gender == Gender.Female) ? x.Gender : Gender.Unspecified))
                .ForMember(m => m.MedicationQuestionId, opt => opt.MapFrom(x => x.MedicationQuestionId > 0 ? x.MedicationQuestionId : (long?)null))
                .ForMember(m => m.NumberOfQuestion, opt => opt.MapFrom(x => x.NumberOfQuestion > 0 ? x.NumberOfQuestion : (int?)null))
                .ForMember(m => m.AgeCondition, opt => opt.MapFrom(x => x.AgeCondition > 0 ? x.AgeCondition : (long?)null))
                .ForMember(m => m.OnMedication, opt => opt.MapFrom(x => x.OnMedication ? x.OnMedication : (bool?)null))
                .ForMember(m => m.DisqualifierQuestionId, opt => opt.MapFrom(x => x.DisqualifierQuestionId > 0 ? x.DisqualifierQuestionId : (long?)null));

            Mapper.CreateMap<ClinicalTestQualificationCriteria, ClinicalTestQualificationCriteriaViewModel>()
                               .ForMember(m => m.GroupName, opt => opt.Ignore())
                               .ForMember(m => m.Gender, opt => opt.MapFrom(x => (x.Gender == Gender.Male || x.Gender == Gender.Female) ? x.Gender : Gender.Unspecified))
                               .ForMember(m => m.NumberOfQuestion, opt => opt.MapFrom(x => x.NumberOfQuestion.HasValue ? x.NumberOfQuestion.Value : 0))
                               .ForMember(m => m.OnMedication, opt => opt.MapFrom(x => x.OnMedication.HasValue && x.OnMedication.Value))
                               .ForMember(m => m.AgeCondition, opt => opt.MapFrom(x => x.AgeCondition.HasValue ? x.AgeCondition.Value : 0))
                               .ForMember(m => m.AgeCondition, opt => opt.MapFrom(x => x.AgeCondition.HasValue ? x.AgeCondition.Value : 0))
                               .ForMember(m => m.AgeCondition, opt => opt.MapFrom(x => x.AgeCondition.HasValue ? x.AgeCondition.Value : 0))
                               .ForMember(m => m.MedicationQuestionId, opt => opt.MapFrom(x => x.MedicationQuestionId.HasValue ? x.MedicationQuestionId.Value : 0))
                               .ForMember(m => m.DisqualifierQuestionId, opt => opt.MapFrom(x => x.DisqualifierQuestionId.HasValue ? x.DisqualifierQuestionId.Value : 0))
                               .ForMember(m => m.TotalQuestionCount, opt => opt.Ignore())
                               .ForMember(m => m.DisqualifierQuestionText, opt => opt.Ignore())
                               .ForMember(m => m.HasSectionsInQuestion, opt => opt.Ignore());

            Mapper.CreateMap<EventAppointmentCancellationLog, EventAppointmentCancellationLogEntity>()
               .IgnoreEntityBaseFields()
               .IgnoreEntityCollection()
               .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<EventAppointmentCancellationLogEntity, EventAppointmentCancellationLog>();

            Mapper.CreateMap<RoleAccessControlObject, RoleAccessControlObjectEntity>()
                .IgnoreEntityBaseFields()
               .IgnoreEntityCollection()
                .ForMember(m => m.ScopeId, opt => opt.MapFrom(x => (long)x.DataScope))
                .ForMember(m => m.PermissionTypeId, opt => opt.MapFrom(x => (long)x.PermissionType))
                .ForMember(m => m.AccessControlObjectId, opt => opt.MapFrom(x => x.AccessControlObject.Id))
                .ForMember(m => m.RoleId, opt => opt.MapFrom(x => x.Role.Id))
                .ForMember(m => m.IsNew, opt => opt.Ignore());

            Mapper.CreateMap<RoleAccessControlObjectEntity, RoleAccessControlObject>()
                .ForMember(m => m.DataScope, opt => opt.MapFrom(x => x.ScopeId != null ? (DataScope)x.ScopeId : (DataScope)0))
                .ForMember(m => m.PermissionType, opt => opt.MapFrom(x => (PermissionType)x.PermissionTypeId));

            Mapper.CreateMap<AccessControlObjectEntity, AccessControlObject>()
                .ForMember(x => x.Urls, opt => opt.MapFrom(y => y.AccessControlObjectUrl))
                .ForMember(x => x.Parent, opt => opt.MapFrom(y => y.AccessControlObject))
                .ForMember(x => x.RoleAccessControlObjects, opt => opt.MapFrom(y => y.RoleAccessControlObject))
                .ForMember(x => x.Children, opt => opt.Ignore())
                .ForMember(x => x.IsRequired, opt => opt.MapFrom(y => y.IsRequired))
                .ForMember(x => x.AccessObjectScopeOptions, opt => opt.MapFrom(y => y.AccessObjectScopeOption));

            Mapper.CreateMap<AccessControlObjectUrlEntity, AccessControlObjectUrl>();

            Mapper.CreateMap<AccessObjectScopeOptionEntity, AccessObjectScopeOption>()
                .ForMember(m => m.Scope, opt => opt.MapFrom(x => (DataScope)x.ScopeId));

            Mapper.CreateMap<RoleScopeOptionEntity, RoleScopeOption>()
                .ForMember(m => m.Scope, opt => opt.MapFrom(x => (DataScope)x.ScopeId));

            Mapper.CreateMap<RoleScopeOption, RoleScopeOptionEntity>()
                .IgnoreEntityBaseFields()
               .IgnoreEntityCollection()
                .ForMember(m => m.ScopeId, opt => opt.MapFrom(x => (long)x.Scope))
                .ForMember(m => m.IsNew, opt => opt.Ignore());

            Mapper.CreateMap<Role, RoleEntity>()
                .IgnoreEntityBaseFields()
               .IgnoreEntityCollection()
                .ForMember(x => x.RoleId, opt => opt.MapFrom(d => d.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(d => d.DisplayName))
                .ForMember(x => x.RoleAccessControlObject, opt => opt.Ignore())
                .ForMember(x => x.RoleScopeOption, opt => opt.Ignore())
                .ForMember(m => m.IsNew, opt => opt.Ignore());

            Mapper.CreateMap<PasswordChangelogEntity, PasswordChangelog>();
            Mapper.CreateMap<PasswordChangelog, PasswordChangelogEntity>()
                .IgnoreEntityBaseFields()
               .IgnoreEntityCollection()
               .ForMember(m => m.IsNew, opt => opt.MapFrom(x => x.Id <= 0));
            Mapper.CreateMap<LoginOtpEntity, LoginOtp>();
            Mapper.CreateMap<LoginOtp, LoginOtpEntity>()
                .IgnoreEntityBaseFields()
               .IgnoreEntityCollection()
               .ForMember(m => m.IsNew, opt => opt.Ignore());

            Mapper.CreateMap<SafeComputerHistoryEntity, SafeComputerHistory>();
            Mapper.CreateMap<SafeComputerHistory, SafeComputerHistoryEntity>()
                .IgnoreEntityBaseFields()
               .IgnoreEntityCollection().ForMember(m => m.IsNew, opt => opt.Ignore()).ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<LoginSettingsEntity, LoginSettings>();
            Mapper.CreateMap<LoginSettings, LoginSettingsEntity>()
                .IgnoreEntityBaseFields()
               .IgnoreEntityCollection().ForMember(m => m.IsNew, opt => opt.Ignore());

            Mapper.CreateMap<IcdCodesEntity, IcdCode>()
                .ForMember(m => m.CodeName, opt => opt.MapFrom(x => x.IcdCode))
                .ForMember(m => m.DataRecorderMetaData, opt => opt.MapFrom(d => new DataRecorderMetaData(d.CreatedBy, d.DateCreated, d.DateModified)
                                                        {
                                                            DataRecorderModifier = d.ModifiedBy.HasValue ? new OrganizationRoleUser(d.ModifiedBy.Value) : null
                                                        }));

            Mapper.CreateMap<IcdCode, IcdCodesEntity>()
                .ForMember(m => m.IcdCode, opt => opt.MapFrom(x => x.CodeName))
                .ForMember(m => m.CreatedBy, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderCreator.Id))
                .ForMember(m => m.DateCreated, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateCreated))
                .ForMember(m => m.ModifiedBy, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateModified.HasValue ? (long?)null : d.DataRecorderMetaData.DataRecorderModifier.Id))
                .ForMember(m => m.DateModified, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateModified))
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                 .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<CustomerIcdCodeEntity, CustomerIcdCode>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<CustomerIcdCode, CustomerIcdCodeEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                 .ForMember(x => x.IsNew, opt => opt.UseValue(true));


            Mapper.CreateMap<AccountTestEntity, AccountTest>();


            Mapper.CreateMap<AccountTest, AccountTestEntity>()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true))
                .IgnoreEntityBaseFields();


            Mapper.CreateMap<HealthPlanCallQueueCriteriaEntity, HealthPlanCallQueueCriteria>()
                .ForMember(x => x.DataRecorderMetaData, opt => opt.MapFrom(d => new DataRecorderMetaData(d.CreatedByOrgRoleUserId, d.DateCreated, d.DateModified)
                    {
                        DataRecorderModifier = d.ModifiedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(d.ModifiedByOrgRoleUserId.Value) : null
                    }));


            Mapper.CreateMap<HealthPlanCallQueueCriteria, HealthPlanCallQueueCriteriaEntity>()
                .ForMember(x => x.CreatedByOrgRoleUserId, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderCreator.Id))
                .ForMember(x => x.DateCreated, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateCreated))
                .ForMember(x => x.ModifiedByOrgRoleUserId, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderModifier != null ? (long?)d.DataRecorderMetaData.DataRecorderModifier.Id : null))
                .ForMember(x => x.DateModified, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateModified))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0))
                .ForMember(x => x.CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment, opt => opt.Ignore())
                .IgnoreEntityCollection()
                .IgnoreEntityBaseFields();

            Mapper.CreateMap<HealthPlanCallQueueCriteriaAssignmentEntity, HealthPlanCallQueueCriteriaAssignment>();
            Mapper.CreateMap<HealthPlanCallQueueCriteriaAssignment, HealthPlanCallQueueCriteriaAssignmentEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));


            Mapper.CreateMap<WellMedAttestationEntity, WellMedAttestation>();
            Mapper.CreateMap<WellMedAttestation, WellMedAttestationEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<WellMedAttestationViewModel, WellMedAttestation>()
                .ForMember(x => x.ReferenceDate, opt => opt.MapFrom(d => (d.ReferenceDate == DateTime.MinValue ? (DateTime?)null : d.ReferenceDate)))
                .ForMember(x => x.DiagnosisDate, opt => opt.MapFrom(d => (d.DiagnosisDate == DateTime.MinValue ? (DateTime?)null : d.DiagnosisDate)));
            Mapper.CreateMap<WellMedAttestation, WellMedAttestationViewModel>()
                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore())
                .ForMember(x => x.ProviderSignatureImage, opt => opt.Ignore())
                .ForMember(x => x.ProviderSignaturePath, opt => opt.Ignore());

            Mapper.CreateMap<MolinaAttestationEntity, MolinaAttestation>();
            Mapper.CreateMap<MolinaAttestation, MolinaAttestationEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<MolinaAttestationViewModel, MolinaAttestation>()
                .ForMember(x => x.StatusId, opt => opt.MapFrom(x => x.StatusId == 0 ? (long?)null : x.StatusId));
            Mapper.CreateMap<MolinaAttestation, MolinaAttestationViewModel>()
                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore());

            Mapper.CreateMap<PrimaryCarePhysician, PrimaryCarePhysicianViewModel>()
                  .ForMember(x => x.CustomerId, opt => opt.MapFrom(d => d.CustomerId))
                  .ForMember(x => x.FullName, opt => opt.MapFrom(d => d.Name))
                  .ForMember(x => x.HasSameAddress, opt => opt.Ignore())
                  .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(d => d.Primary))
                  .ForMember(x => x.Phone, opt => opt.Ignore());

            Mapper.CreateMap<PcpAppointment, PcpAppointmentEntity>()
               .ForMember(m => m.IsNew, opt => opt.UseValue(true))
               .ForMember(m => m.EventCustomerId, opt => opt.MapFrom(d => d.EventCustomerId))
               .ForMember(m => m.AppointmentOn, opt => opt.MapFrom(d => d.AppointmentOn))
               .ForMember(m => m.CreatedBy, opt => opt.MapFrom(d => d.CreatedBy))
               .ForMember(m => m.CreatedOn, opt => opt.MapFrom(d => d.CreatedOn))
               .ForMember(m => m.ModifiedBy, opt => opt.MapFrom(d => d.ModifiedBy))
               .ForMember(m => m.ModifiedOn, opt => opt.MapFrom(d => d.ModifiedOn))
               .ForMember(m => m.PreferredContactMethod, opt => opt.MapFrom(d => d.PreferredContactMethod))
               .IgnoreEntityBaseFields()
               .IgnoreEntityCollection();

            Mapper.CreateMap<PcpAppointmentEntity, PcpAppointment>()
                .ForMember(m => m.EventCustomerId, opt => opt.MapFrom(d => d.EventCustomerId))
                .ForMember(m => m.AppointmentOn, opt => opt.MapFrom(d => d.AppointmentOn))
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.CreatedBy, opt => opt.MapFrom(d => d.CreatedBy))
               .ForMember(m => m.CreatedOn, opt => opt.MapFrom(d => d.CreatedOn))
               .ForMember(m => m.ModifiedBy, opt => opt.MapFrom(d => d.ModifiedBy))
               .ForMember(m => m.PreferredContactMethod, opt => opt.MapFrom(d => d.PreferredContactMethod))
               .ForMember(m => m.ModifiedOn, opt => opt.MapFrom(d => d.ModifiedOn));

            Mapper.CreateMap<PcpDisposition, PcpDispositionEntity>()
              .ForMember(m => m.IsNew, opt => opt.MapFrom(d => d.PcpDispositionId <= 0))
              .ForMember(m => m.EventCustomerId, opt => opt.MapFrom(d => d.EventCustomerId))
              .ForMember(m => m.DispositionId, opt => opt.MapFrom(d => (long)d.Disposition))
              .ForMember(m => m.CreatedBy, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderCreator.Id))
              .ForMember(m => m.CreatedOn, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateCreated))
              .ForMember(m => m.ModifiedBy, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderModifier != null ? (long?)d.DataRecorderMetaData.DataRecorderModifier.Id : null))
              .ForMember(m => m.ModifiedOn, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateModified))
              .IgnoreEntityBaseFields()
              .IgnoreEntityCollection();

            Mapper.CreateMap<PcpDispositionEntity, PcpDisposition>()
                .ForMember(m => m.EventCustomerId, opt => opt.MapFrom(d => d.EventCustomerId))
                .ForMember(m => m.Disposition, opt => opt.MapFrom(d => (PcpAppointmentDisposition)d.DispositionId))
                .ForMember(m => m.PcpDispositionId, opt => opt.MapFrom(x => x.PcpDispositionId))
                 .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.DataRecorderMetaData, opt => opt.MapFrom(d => new DataRecorderMetaData(d.CreatedBy, d.CreatedOn, d.ModifiedOn)
                {
                    DataRecorderModifier = d.ModifiedBy.HasValue ? new OrganizationRoleUser(d.ModifiedBy.Value) : null
                }));

            Mapper.CreateMap<CallUpload, CallUploadEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));
            Mapper.CreateMap<CallUploadEntity, CallUpload>();


            Mapper.CreateMap<CallUploadLog, CallUploadLogEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<CallUploadLogEntity, CallUploadLog>()
                .ForMember(x => x.OutreachDate, opt => opt.Ignore())
                .ForMember(x => x.CustomerIdForCsv, opt => opt.Ignore())
                .ForMember(x => x.EventIdForCsv, opt => opt.Ignore())
                .ForMember(x => x.OutreachTime, opt => opt.Ignore())
                .ForMember(x => x.OutcomeEnum, opt => opt.Ignore())
                .ForMember(x => x.DispositionEnum, opt => opt.Ignore())
                .ForMember(x => x.ReasonEnum, opt => opt.Ignore())
                .ForMember(x => x.IsDirectMail, opt => opt.Ignore());

            Mapper.CreateMap<CallUploadLog, CallUploadLogViewModel>()
                .ForMember(m => m.CustomerId, opt => opt.MapFrom(x => x.CustomerIdForCsv))
                .ForMember(m => m.EventId, opt => opt.MapFrom(x => x.EventIdForCsv))
                .ForMember(m => m.OutreachTime, opt => opt.MapFrom(x => x.OutreachTime))
                .ForMember(m => m.FeedbackMessage, opt => opt.Ignore())
                .ForMember(m => m.IsInvalidAddress, opt => opt.MapFrom(x => x.IsInvalidAddress))
                .ForMember(m => m.OutreachDate, opt => opt.MapFrom(x => x.OutreachDate));


            Mapper.CreateMap<CorporateUpload, CorporateUploadEntity>()
               .IgnoreEntityBaseFields()
               .IgnoreEntityCollection()
               .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<CorporateUploadEntity, CorporateUpload>();

            Mapper.CreateMap<HealthPlanCriteriaAssignmentEntity, HealthPlanCriteriaAssignment>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<HealthPlanCriteriaAssignment, HealthPlanCriteriaAssignmentEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<DirectMail, DirectMailEntity>()
               .IgnoreEntityBaseFields()
               .IgnoreEntityCollection()
               .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<DirectMailEntity, DirectMail>();

            Mapper.CreateMap<Campaign, CampaignEntity>()
              .ForMember(m => m.Createdby, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderCreator.Id))
              .ForMember(m => m.CreatedOn, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateCreated))
              .ForMember(m => m.Modifiedby, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderModifier != null ? d.DataRecorderMetaData.DataRecorderModifier.Id : d.DataRecorderMetaData.DataRecorderCreator.Id))
              .ForMember(m => m.ModifiedOn, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateModified))
              .IgnoreEntityBaseFields()
              .IgnoreEntityCollection()
              .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<CampaignEntity, Campaign>()
                 .ForMember(m => m.DataRecorderMetaData, opt => opt.MapFrom(d => new DataRecorderMetaData(d.Createdby, d.CreatedOn, d.ModifiedOn)
                 {
                     DataRecorderModifier = new OrganizationRoleUser(d.Modifiedby)
                 }));

            Mapper.CreateMap<CampaignAssignmentEntity, CampaignAssignment>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<CampaignAssignment, CampaignAssignmentEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<CampaignActivity, CampaignActivityEntity>()
              .ForMember(m => m.Createdby, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderCreator.Id))
              .ForMember(m => m.CreatedOn, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateCreated))
              .ForMember(m => m.Modifiedby, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderModifier != null ? d.DataRecorderMetaData.DataRecorderModifier.Id : d.DataRecorderMetaData.DataRecorderCreator.Id))
              .ForMember(m => m.ModifiedOn, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateModified))
              .IgnoreEntityBaseFields()
              .IgnoreEntityCollection()
              .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<CampaignActivityEntity, CampaignActivity>()
                 .ForMember(m => m.DataRecorderMetaData, opt => opt.MapFrom(d => new DataRecorderMetaData(d.Createdby, d.CreatedOn, d.ModifiedOn)
                 {
                     DataRecorderModifier = new OrganizationRoleUser(d.Modifiedby)
                 }));

            Mapper.CreateMap<CampaignActivityAssignmentEntity, CampaignActivityAssignment>()
               .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<CampaignActivityAssignment, CampaignActivityAssignmentEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<ExportableReportsEntity, ExportableReports>();

            Mapper.CreateMap<ExportableReports, ExportableReportsEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<ExportableReportsQueueEntity, ExportableReportsQueue>();

            Mapper.CreateMap<ExportableReportsQueue, ExportableReportsQueueEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<DirectMailTypeEntity, DirectMailType>();

            Mapper.CreateMap<DirectMailType, DirectMailTypeEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<CustomerSkipReviewEntity, CustomerSkipReview>()
              .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<TestNotPerformedEntity, TestNotPerformed>()
                .ForMember(m => m.RecorderMetaData, opt => opt.MapFrom(d => new DataRecorderMetaData(d.CreatedBy, d.CreatedOn, d.UpdatedOn)
                {
                    DataRecorderModifier = d.UpdatedBy.HasValue ? new OrganizationRoleUser(d.UpdatedBy.Value) : null
                }));

            Mapper.CreateMap<TestNotPerformedReasonEntity, TestNotPerformedReason>();

            Mapper.CreateMap<TestNotPerformedReason, TestNotPerformedReasonEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<AccountNotReviewableTestEntity, AccountNotReviewableTest>();


            Mapper.CreateMap<AccountNotReviewableTest, AccountNotReviewableTestEntity>()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true))
                .IgnoreEntityBaseFields();


            Mapper.CreateMap<RapsUpload, RapsUploadEntity>()
             .IgnoreEntityBaseFields()
             .IgnoreEntityCollection()
             .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));
            Mapper.CreateMap<RapsUploadEntity, RapsUpload>();


            Mapper.CreateMap<RapsUploadLog, RapsUploadLogEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<RapsUploadLogEntity, RapsUploadLog>();

            Mapper.CreateMap<RapsUploadLog, RapsUploadLogViewModel>()
                .ForMember(m => m.FeedbackMessage, opt => opt.Ignore());

            Mapper.CreateMap<AccountHraChatQuestionnaireEntity, AccountHraChatQuestionnaire>()
              .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<AccountHraChatQuestionnaire, AccountHraChatQuestionnaireEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());

            Mapper.CreateMap<Raps, RapsEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<RapsEntity, Raps>();

            Mapper.CreateMap<PreApprovedPackageEntity, PreApprovedPackage>();


            Mapper.CreateMap<PreApprovedPackage, PreApprovedPackageEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsActive, opt => opt.UseValue(true))

                .ForMember(x => x.IsNew, opt => opt.UseValue(true));


            Mapper.CreateMap<NdcEntity, Ndc>();

            Mapper.CreateMap<CurrentMedicationEntity, CurrentMedication>();


            Mapper.CreateMap<CurrentMedication, CurrentMedicationEntity>()
                .IgnoreEntityCollection()
                .IgnoreEntityBaseFields()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<DiabeticRetinopathyParserlogEntity, DiabeticRetinopathyParserlog>();

            Mapper.CreateMap<DiabeticRetinopathyParserlog, DiabeticRetinopathyParserlogEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<HealthPlanFillEventCallQueueEntity, HealthPlanFillEventCallQueue>()
                 .ForMember(x => x.Id, opt => opt.Ignore());


            Mapper.CreateMap<HealthPlanFillEventCallQueue, HealthPlanFillEventCallQueueEntity>()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true))
                .IgnoreEntityBaseFields();


            Mapper.CreateMap<AdditionalFieldsEntity, AdditionalFields>();


            Mapper.CreateMap<AccountAdditionalFieldsEntity, AccountAdditionalFields>();

            Mapper.CreateMap<AccountAdditionalFields, AccountAdditionalFieldsEntity>()
                .IgnoreEntityBaseFields()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<AccountAdditionalFieldsEditModel, AccountAdditionalFields>()
            .ForMember(x => x.AdditionalFieldId, opt => opt.MapFrom(m => m.AdditionalFieldId))
            .ForMember(x => x.AccountId, opt => opt.Ignore())
            .ForMember(x => x.DisplayName, opt => opt.MapFrom(m => m.DisplayName));

            Mapper.CreateMap<AccountAdditionalFields, AccountAdditionalFieldsEditModel>()
            .ForMember(x => x.AdditionalFieldId, opt => opt.MapFrom(m => m.AdditionalFieldId))
            .ForMember(x => x.DisplayName, opt => opt.MapFrom(m => m.DisplayName))
            .ForMember(x => x.FieldName, opt => opt.Ignore())
            .ForMember(x => x.FeedbackMessage, opt => opt.Ignore());

            Mapper.CreateMap<HealthPlanRevenue, HealthPlanRevenueEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.AccountId, opt => opt.MapFrom(m => m.AccountId))
                .ForMember(x => x.RevenueItemTypeId, opt => opt.MapFrom(m => m.RevenueItemTypeId))
                .ForMember(x => x.DateFrom, opt => opt.MapFrom(m => m.DateFrom))
                .ForMember(x => x.DateTo, opt => opt.MapFrom(m => m.DateTo))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderCreator.Id))
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateCreated))
                .ForMember(x => x.ModifiedBy, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderModifier != null ? (long?)d.DataRecorderMetaData.DataRecorderModifier.Id : null))
                .ForMember(x => x.ModifiedDate, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateModified))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0));

            Mapper.CreateMap<HealthPlanRevenueEntity, HealthPlanRevenue>()
                .ForMember(x => x.DataRecorderMetaData,
                   opt => opt.MapFrom(d => new DataRecorderMetaData(d.CreatedBy, d.CreatedDate, d.ModifiedDate)
                   {
                       DataRecorderModifier = d.ModifiedBy.HasValue ? new OrganizationRoleUser(d.ModifiedBy.Value) : null
                   }));

            Mapper.CreateMap<HealthPlanRevenueItem, HealthPlanRevenueItemEntity>()
              .IgnoreEntityBaseFields()
              .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<HealthPlanRevenueItemEntity, HealthPlanRevenueItem>();

            Mapper.CreateMap<EventCustomerPreApprovedTestEntity, EventCustomerPreApprovedTest>();


            Mapper.CreateMap<HcpcsCodeEntity, HcpcsCode>();
            Mapper.CreateMap<TestHcpcsCodeEntity, TestHcpcsCode>();
            Mapper.CreateMap<Raps, MedicareRapsViewModel>();

            Mapper.CreateMap<VwEventCustomerPreApprovedTestListEntity, EventCustomerPreApprovedTest>();

            Mapper.CreateMap<AccountCoordinatorProfileModel, AccountCoordinatorProfile>()
                .ForMember(x => x.AccountCoordinatorId, opt => opt.MapFrom(t => t.OrganizationRoleUserId))
                .ForMember(x => x.IsClinicalCoordinator, opt => opt.MapFrom(t => t.IsClinicalCoordinator))
                .ForMember(x => x.Address, opt => opt.Ignore())
                .ForMember(x => x.AlternateEmail, opt => opt.Ignore())
                .ForMember(x => x.DataRecorderMetaData, opt => opt.Ignore())
                .ForMember(x => x.DateOfBirth, opt => opt.Ignore())
                .ForMember(x => x.DefaultRole, opt => opt.Ignore())
                .ForMember(x => x.Email, opt => opt.Ignore())
                .ForMember(x => x.HomePhoneNumber, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.MobilePhoneNumber, opt => opt.Ignore())
                .ForMember(x => x.Name, opt => opt.Ignore())
                .ForMember(x => x.OfficePhoneNumber, opt => opt.Ignore())
                .ForMember(x => x.UserLogin, opt => opt.Ignore())
                .ForMember(x => x.PhoneOfficeExtension, opt => opt.Ignore())
                .ForMember(x => x.Ssn, opt => opt.Ignore());

            Mapper.CreateMap<AccountCoordinatorProfile, AccountCoordinatorProfileModel>()
                .ForMember(x => x.OrganizationRoleUserId, opt => opt.MapFrom(t => t.AccountCoordinatorId))
                .ForMember(x => x.IsClinicalCoordinator, opt => opt.MapFrom(t => t.IsClinicalCoordinator));

            Mapper.CreateMap<ChaseCampaign, ChaseCampaignEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.ChaseCampaignId, opt => opt.MapFrom(m => m.Id))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(m => m.Id <= 0));
            Mapper.CreateMap<ChaseCampaignEntity, ChaseCampaign>()
                .ForMember(x => x.Id, opt => opt.MapFrom(m => m.ChaseCampaignId));

            Mapper.CreateMap<ChaseCampaignType, ChaseCampaignTypeEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.ChaseCampaignTypeId, opt => opt.MapFrom(m => m.Id))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(m => m.Id <= 0));
            Mapper.CreateMap<ChaseCampaignTypeEntity, ChaseCampaignType>()
                .ForMember(x => x.Id, opt => opt.MapFrom(m => m.ChaseCampaignTypeId));

            Mapper.CreateMap<ChaseChannelLevel, ChaseChannelLevelEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.ChaseChannelLevelId, opt => opt.MapFrom(m => m.Id))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(m => m.Id <= 0));
            Mapper.CreateMap<ChaseChannelLevelEntity, ChaseChannelLevel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(m => m.ChaseChannelLevelId));

            Mapper.CreateMap<ChaseGroup, ChaseGroupEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.ChaseGroupId, opt => opt.MapFrom(m => m.Id))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(m => m.Id <= 0));
            Mapper.CreateMap<ChaseGroupEntity, ChaseGroup>()
                .ForMember(x => x.Id, opt => opt.MapFrom(m => m.ChaseGroupId));

            Mapper.CreateMap<ChaseOutbound, ChaseOutboundEntity>()
                .IgnoreEntityCollection()
                .IgnoreEntityBaseFields()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));
            Mapper.CreateMap<ChaseOutboundEntity, ChaseOutbound>();


            Mapper.CreateMap<ChaseProduct, ChaseProductEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.ChaseProductId, opt => opt.MapFrom(m => m.Id))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(m => m.Id <= 0));
            Mapper.CreateMap<ChaseProductEntity, ChaseProduct>()
                .ForMember(x => x.Id, opt => opt.MapFrom(m => m.ChaseProductId));

            Mapper.CreateMap<CustomerChaseCampaign, CustomerChaseCampaignEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());
            Mapper.CreateMap<CustomerChaseCampaignEntity, CustomerChaseCampaign>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<CustomerChaseChannel, CustomerChaseChannelEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());
            Mapper.CreateMap<CustomerChaseChannelEntity, CustomerChaseChannel>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<CustomerChaseProduct, CustomerChaseProductEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());
            Mapper.CreateMap<CustomerChaseProductEntity, CustomerChaseProduct>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<OutboundUpload, OutboundUploadEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(m => m.Id <= 0));
            Mapper.CreateMap<OutboundUploadEntity, OutboundUpload>();

            Mapper.CreateMap<RelationshipEntity, Core.Users.Domain.Relationship>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.RelationshipId));

            Mapper.CreateMap<Core.Users.Domain.Relationship, RelationshipEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.RelationshipId, opt => opt.Ignore())
                .ForMember(x => x.IsNew, opt => opt.MapFrom(m => m.Id <= 0));

            Mapper.CreateMap<CareCodingOutbound, CareCodingOutboundEntity>()
                .IgnoreEntityBaseFields()
                .ForMember(x => x.IsNew, opt => opt.Ignore());
            Mapper.CreateMap<CareCodingOutboundEntity, CareCodingOutbound>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<BarrierEntity, Barrier>();

            Mapper.CreateMap<Barrier, BarrierEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(m => m.Id <= 0));

            Mapper.CreateMap<EventCustomerBarrierEntity, EventCustomerBarrier>();

            Mapper.CreateMap<EventCustomerBarrier, EventCustomerBarrierEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());

            Mapper.CreateMap<EventCustomerPrimaryCarePhysicianEntity, EventCustomerPrimaryCarePhysician>();

            Mapper.CreateMap<EventCustomerPrimaryCarePhysician, EventCustomerPrimaryCarePhysicianEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());

            Mapper.CreateMap<CheckListGroup, CheckListGroupEntity>()
                .ForMember(x => x.TypeId, opt => opt.MapFrom(d => (long)d.Type))
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<CheckListGroupEntity, CheckListGroup>()

                .ForMember(x => x.Type, opt => opt.MapFrom(d => (CheckListGroupType)d.TypeId));

            Mapper.CreateMap<CheckListQuestion, CheckListQuestionEntity>()
                .ForMember(x => x.TypeId, opt => opt.MapFrom(d => (long)d.Type))
                .ForMember(x => x.Gender, opt => opt.MapFrom(d => (long)d.Gender))
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<CheckListQuestionEntity, CheckListQuestion>()
                .ForMember(x => x.Gender, opt => opt.MapFrom(d => (Gender)d.Gender))
                .ForMember(x => x.Type, opt => opt.MapFrom(d => (CheckListQuestionType)d.TypeId));

            Mapper.CreateMap<CheckListAnswer, CheckListAnswerEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.EventCustomerId, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.CreatedOn, opt => opt.MapFrom(d => (d.DataRecorderMetaData != null ? (DateTime?)d.DataRecorderMetaData.DateCreated : null)))
                .ForMember(x => x.ModifiedOn, opt => opt.MapFrom(d => (d.DataRecorderMetaData != null ? d.DataRecorderMetaData.DateModified : null)))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(d => (d.DataRecorderMetaData != null && d.DataRecorderMetaData.DataRecorderCreator != null ? d.DataRecorderMetaData.DataRecorderCreator.Id : 0)))
                .ForMember(x => x.ModifiedBy, opt => opt.MapFrom(d => (d.DataRecorderMetaData != null && d.DataRecorderMetaData.DataRecorderModifier != null ? (long?)d.DataRecorderMetaData.DataRecorderModifier.Id : null)))


                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<CheckListAnswerEntity, CheckListAnswer>()
                .ForMember(x => x.DataRecorderMetaData, opt => opt.MapFrom(d => new DataRecorderMetaData((d.CreatedBy), d.CreatedOn, d.ModifiedOn)
                {
                    DataRecorderModifier = d.ModifiedBy.HasValue ? new OrganizationRoleUser(d.ModifiedBy.Value) : null
                }))
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.EventCustomerId));

            Mapper.CreateMap<EventCustomerDiagnosisEntity, EventCustomerDiagnosis>();

            Mapper.CreateMap<EventCustomerDiagnosis, EventCustomerDiagnosisEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0));

            Mapper.CreateMap<VwOutreachCallReportEntity, Call>()
               .ForMember(x => x.Id, opt => opt.MapFrom(d => d.CallId))
               .ForMember(x => x.CalledCustomerId, opt => opt.MapFrom(d => d.CalledCustomerId))
               .ForMember(x => x.CallDateTime, opt => opt.MapFrom(d => d.DateCreated))
               .ForMember(x => x.StartTime, opt => opt.MapFrom(d => d.TimeCreated))
               .ForMember(x => x.EndTime, opt => opt.MapFrom(d => d.TimeEnd))
               .ForMember(x => x.CallStatus, opt => opt.MapFrom(d => d.CallStatus))
               .ForMember(x => x.CalledInNumber, opt => opt.MapFrom(d => d.IncomingPhoneLine))
               .ForMember(x => x.CallerNumber, opt => opt.MapFrom(d => d.CallersPhoneNumber))
               .ForMember(x => x.CallBackNumber, opt => opt.MapFrom(d => d.CallBackNumber))
               .ForMember(x => x.IsIncoming, opt => opt.MapFrom(d => !d.OutBound))
               .ForMember(x => x.Status, opt => opt.MapFrom(d => d.Status))
               .ForMember(x => x.CreatedByOrgRoleUserId, opt => opt.MapFrom(d => d.CreatedByOrgRoleUserId))
               .ForMember(x => x.IsNewCustomer, opt => opt.MapFrom(d => d.IsNewCustomer))
               .ForMember(x => x.EventId, opt => opt.MapFrom(d => d.EventId))
               .ForMember(x => x.DateCreated, opt => opt.MapFrom(d => d.DateCreated))
               .ForMember(x => x.DateModified, opt => opt.MapFrom(d => d.DateModified))
               .ForMember(x => x.ReadAndUnderstood, opt => opt.MapFrom(d => d.ReadAndUnderstoodNotes))
               .ForMember(x => x.IsUploaded, opt => opt.MapFrom(d => d.IsUploaded))
               .ForMember(x => x.CampaignId, opt => opt.MapFrom(d => d.CampaignId))
               .ForMember(x => x.NotInterestedReasonId, opt => opt.MapFrom(d => d.NotInterestedReasonId))
               .ForMember(x => x.HealthPlanId, opt => opt.Ignore())
               .ForMember(x => x.CallQueueId, opt => opt.MapFrom(d => d.CallQueueId))
               .ForMember(x => x.CustomTags, opt => opt.MapFrom(d => d.CustomTags))
               .ForMember(x => x.DialerType, opt => opt.Ignore())
               .ForMember(x => x.ProductTypeId, opt => opt.MapFrom(d => d.ProductTypeId))
               .ForMember(x => x.InvalidNumberCount, opt => opt.Ignore());

            Mapper.CreateMap<EventNoteEntity, EventNote>();

            Mapper.CreateMap<EventNote, EventNoteEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0));

            Mapper.CreateMap<EventNotesLogEntity, EventNotesLog>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<EventNotesLog, EventNotesLogEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0));


            Mapper.CreateMap<CheckListTemplateEntity, CheckListTemplate>();

            Mapper.CreateMap<CheckListTemplate, CheckListTemplateEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.HealthPlanId, opt => opt.Ignore())
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0));

            Mapper.CreateMap<CheckListTemplateQuestionEntity, CheckListTemplateQuestion>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<CheckListTemplateQuestion, CheckListTemplateQuestionEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<CheckListTemplateEditModel, CheckListTemplate>()
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateModified, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.IsActive, opt => opt.UseValue(true));

            Mapper.CreateMap<VwCallQueueCustomerCallDetailsEntity, CallQueueCustomerCallDetails>()
              .ForMember(x => x.CallId, opt => opt.MapFrom(d => d.CallId))
              .ForMember(x => x.CalledCustomerId, opt => opt.MapFrom(d => d.CalledCustomerId))
              .ForMember(x => x.CallDateTime, opt => opt.MapFrom(d => d.DateCreated))
              .ForMember(x => x.StartTime, opt => opt.MapFrom(d => d.TimeCreated))
              .ForMember(x => x.EndTime, opt => opt.MapFrom(d => d.TimeEnd))
              .ForMember(x => x.CallStatus, opt => opt.MapFrom(d => d.CallStatus))
              .ForMember(x => x.CalledInNumber, opt => opt.MapFrom(d => d.IncomingPhoneLine))
              .ForMember(x => x.CallerNumber, opt => opt.MapFrom(d => d.CallersPhoneNumber))
              .ForMember(x => x.CallBackNumber, opt => opt.MapFrom(d => d.CallBackNumber))
              .ForMember(x => x.IsIncoming, opt => opt.MapFrom(d => !d.OutBound))
              .ForMember(x => x.Status, opt => opt.MapFrom(d => d.Status))
              .ForMember(x => x.CreatedByOrgRoleUserId, opt => opt.MapFrom(d => d.CreatedByOrgRoleUserId))
              .ForMember(x => x.EventId, opt => opt.MapFrom(d => d.EventId))
              .ForMember(x => x.DateCreated, opt => opt.MapFrom(d => d.DateCreated))
              .ForMember(x => x.DateModified, opt => opt.MapFrom(d => d.DateModified))
              .ForMember(x => x.ReadAndUnderstood, opt => opt.MapFrom(d => d.ReadAndUnderstoodNotes))
              .ForMember(x => x.IsUploaded, opt => opt.MapFrom(d => d.IsUploaded))
              .ForMember(x => x.CampaignId, opt => opt.MapFrom(d => d.CampaignId))
              .ForMember(x => x.NotInterestedReasonId, opt => opt.MapFrom(d => d.NotInterestedReasonId))
              .ForMember(x => x.CallQueueCustomerId, opt => opt.MapFrom(d => d.CallQueueCustomerId))
              .ForMember(x => x.CallQueueId, opt => opt.MapFrom(d => d.CallQueueId))
              .ForMember(x => x.HealthPlanId, opt => opt.MapFrom(d => d.HealthPlanId));

            Mapper.CreateMap<ChecklistGroupQuestionEntity, ChecklistGroupQuestion>();

            Mapper.CreateMap<ChecklistGroupQuestion, ChecklistGroupQuestionEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(m => m.Id > 0));

            Mapper.CreateMap<EventChecklistTemplateEntity, EventChecklistTemplate>();

            Mapper.CreateMap<EventChecklistTemplate, EventChecklistTemplateEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<CallRoundCallQueueEntity, CallRoundCallQueue>()
                .ForMember(x => x.Status, opt => opt.MapFrom(d => (CallQueueStatus)d.Status));

            Mapper.CreateMap<CallRoundCallQueue, CallRoundCallQueueEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.Status, opt => opt.MapFrom(d => (long)d.Status))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));

            Mapper.CreateMap<CallRoundCallQueueCriteriaAssignmentEntity, CallRoundCallQueueCriteriaAssignment>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<CallRoundCallQueueCriteriaAssignment, CallRoundCallQueueCriteriaAssignmentEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());


            Mapper.CreateMap<FillEventCallQueueEntity, FillEventCallQueue>()
                .ForMember(x => x.Status, opt => opt.MapFrom(d => (CallQueueStatus)d.Status));

            Mapper.CreateMap<FillEventCallQueue, FillEventCallQueueEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.Status, opt => opt.MapFrom(d => (long)d.Status))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));

            Mapper.CreateMap<FillEventCallQueueCriteriaAssignmentEntity, FillEventCallQueueCriteriaAssignment>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<FillEventCallQueueCriteriaAssignment, FillEventCallQueueCriteriaAssignmentEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());


            Mapper.CreateMap<NoShowCallQueueEntity, NoShowCallQueue>()
                .ForMember(x => x.Status, opt => opt.MapFrom(d => (CallQueueStatus)d.Status));

            Mapper.CreateMap<NoShowCallQueue, NoShowCallQueueEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.Status, opt => opt.MapFrom(d => (long)d.Status))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));

            Mapper.CreateMap<NoShowCallQueueCriteriaAssignmentEntity, NoShowCallQueueCriteriaAssignment>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<NoShowCallQueueCriteriaAssignment, NoShowCallQueueCriteriaAssignmentEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());


            Mapper.CreateMap<UncontactedCustomerCallQueueEntity, UncontactedCustomerCallQueue>()
                .ForMember(x => x.Status, opt => opt.MapFrom(d => (CallQueueStatus)d.Status));

            Mapper.CreateMap<UncontactedCustomerCallQueue, UncontactedCustomerCallQueueEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.Status, opt => opt.MapFrom(d => (long)d.Status))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));

            Mapper.CreateMap<UncontactedCustomerCallQueueCriteriaAssignmentEntity, UncontactedCustomerCallQueueCriteriaAssignment>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<UncontactedCustomerCallQueueCriteriaAssignment, UncontactedCustomerCallQueueCriteriaAssignmentEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());


            Mapper.CreateMap<MailRoundCallQueueEntity, MailRoundCallQueue>()
                .ForMember(x => x.Status, opt => opt.MapFrom(d => (CallQueueStatus)d.Status));

            Mapper.CreateMap<MailRoundCallQueue, MailRoundCallQueueEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.Status, opt => opt.MapFrom(d => (long)d.Status))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));

            Mapper.CreateMap<MailRoundCallQueueCriteriaAssignmentEntity, MailRoundCallQueueCriteriaAssignment>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<MailRoundCallQueueCriteriaAssignment, MailRoundCallQueueCriteriaAssignmentEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());


            Mapper.CreateMap<LanguageBarrierCallQueueEntity, LanguageBarrierCallQueue>()
                .ForMember(x => x.Status, opt => opt.MapFrom(d => (CallQueueStatus)d.Status));

            Mapper.CreateMap<LanguageBarrierCallQueue, LanguageBarrierCallQueueEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.Status, opt => opt.MapFrom(d => (long)d.Status))
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));

            Mapper.CreateMap<LanguageBarrierCallQueueCriteriaAssignmentEntity, LanguageBarrierCallQueueCriteriaAssignment>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<LanguageBarrierCallQueueCriteriaAssignment, LanguageBarrierCallQueueCriteriaAssignmentEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());


            Mapper.CreateMap<CustomerLockForCallEntity, CustomerLockForCall>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<CustomerLockForCall, CustomerLockForCallEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));


            Mapper.CreateMap<CustomerCallAttemptsEntity, CustomerCallAttempts>();

            Mapper.CreateMap<CustomerCallAttempts, CustomerCallAttemptsEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());

            Mapper.CreateMap<VwGetTestPerformedReportEntity, VwGetTestPerformedReport>();

            Mapper.CreateMap<VwGetOutboundCallsEntity, OutboundCall>();

            Mapper.CreateMap<PayPeriodEntity, PayPeriod>()
                .ForMember(x => x.EndDate, opt => opt.Ignore());

            Mapper.CreateMap<PayPeriod, PayPeriodEntity>()

                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));

            Mapper.CreateMap<PayPeriodCriteriaEntity, PayPeriodCriteria>();

            Mapper.CreateMap<PayPeriodCriteria, PayPeriodCriteriaEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id < 1));

            //Mapper.CreateMap<PayPeriod, PayPeriodEditModel>()
            //    .ForMember(x => x.PayPeriodId, opt => opt.MapFrom(d => d.Id))
            //    .ForMember(x => x.Name, opt => opt.MapFrom(d => d.Name))
            //    .ForMember(x => x.FromDate, opt => opt.MapFrom(d => d.StartDate))
            //    .ForMember(x => x.ToDate, opt => opt.MapFrom(d => d.EndDate))
            //    .ForMember(x => x.IsActive, opt => opt.MapFrom(d => d.IsActive))
            //    .ForMember(x => x.IsPublished, opt => opt.MapFrom(d => d.IsPublished))
            //    .ForMember(x => x.Criteria, opt => opt.Ignore());

            //Mapper.CreateMap<PayPeriodEditModel, PayPeriod>()
            //    .ForMember(x => x.Id, opt => opt.MapFrom(d => d.PayPeriodId))
            //    .ForMember(x => x.Name, opt => opt.MapFrom(d => d.Name))
            //    .ForMember(x => x.StartDate, opt => opt.MapFrom(d => d.FromDate))
            //    .ForMember(x => x.EndDate, opt => opt.MapFrom(d => d.ToDate))
            //    .ForMember(x => x.IsActive, opt => opt.MapFrom(d => d.IsActive))
            //    .ForMember(x => x.IsPublished, opt => opt.MapFrom(d => d.IsPublished))
            //    .ForMember(x => x.ModifiedOn, opt => opt.Ignore())
            //    .ForMember(x => x.ModifiedBy, opt => opt.Ignore())
            //    .ForMember(x => x.CreatedBy, opt => opt.Ignore())
            //    .ForMember(x => x.CreatedOn, opt => opt.Ignore());

            //Mapper.CreateMap<PayPeriodCriteria, PayPeriodCriteriaEditModel>()
            //.ForMember(x => x.PayPeriodCriteriaId, opt => opt.MapFrom(d => d.Id))
            //   .ForMember(x => x.PayPeriodId, opt => opt.MapFrom(d => d.PayPeriodId))
            //   .ForMember(x => x.NumberOfCustomer, opt => opt.MapFrom(d => d.NumberOfCustomer))
            //   .ForMember(x => x.Ammount, opt => opt.MapFrom(d => d.Ammount));

            //Mapper.CreateMap<PayPeriodCriteriaEditModel, PayPeriodCriteria>()
            //    .ForMember(x => x.Id, opt => opt.MapFrom(d => d.PayPeriodCriteriaId))
            //    .ForMember(x => x.PayPeriodId, opt => opt.MapFrom(d => d.PayPeriodId))
            //   .ForMember(x => x.NumberOfCustomer, opt => opt.MapFrom(d => d.NumberOfCustomer))
            //   .ForMember(x => x.Ammount, opt => opt.MapFrom(d => d.Ammount));

            Mapper.CreateMap<VwEventCustomersViewServiceReportEntity, EventCustomersViewServiceReport>();

            Mapper.CreateMap<CustomEventNotificationEntity, CustomEventNotification>();

            Mapper.CreateMap<CustomEventNotification, CustomEventNotificationEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0));

            Mapper.CreateMap<EventCustomerCustomNotificationEntity, EventCustomerCustomNotification>();

            Mapper.CreateMap<EventCustomerCustomNotification, EventCustomerCustomNotificationEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());

            Mapper.CreateMap<LoincCrosswalkEntity, LoincCrosswalk>();

            Mapper.CreateMap<LoincCrosswalk, LoincCrosswalkEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0));

            Mapper.CreateMap<VwCallCenterCallReportEntity, Call>()
               .ForMember(x => x.Id, opt => opt.MapFrom(d => d.CallId))
               .ForMember(x => x.CalledCustomerId, opt => opt.MapFrom(d => d.CalledCustomerId))
               .ForMember(x => x.CallDateTime, opt => opt.MapFrom(d => d.DateCreated))
               .ForMember(x => x.StartTime, opt => opt.MapFrom(d => d.TimeCreated))
               .ForMember(x => x.EndTime, opt => opt.MapFrom(d => d.TimeEnd))
               .ForMember(x => x.CallStatus, opt => opt.MapFrom(d => d.CallStatus))
               .ForMember(x => x.CalledInNumber, opt => opt.MapFrom(d => d.IncomingPhoneLine))
               .ForMember(x => x.CallerNumber, opt => opt.MapFrom(d => d.CallersPhoneNumber))
               .ForMember(x => x.CallBackNumber, opt => opt.MapFrom(d => d.CallBackNumber))
               .ForMember(x => x.IsIncoming, opt => opt.MapFrom(d => !d.OutBound))
               .ForMember(x => x.Status, opt => opt.MapFrom(d => d.Status))
               .ForMember(x => x.CreatedByOrgRoleUserId, opt => opt.MapFrom(d => d.CreatedByOrgRoleUserId))
               .ForMember(x => x.IsNewCustomer, opt => opt.MapFrom(d => d.IsNewCustomer))
               .ForMember(x => x.EventId, opt => opt.MapFrom(d => d.EventId))
               .ForMember(x => x.DateCreated, opt => opt.MapFrom(d => d.DateCreated))
               .ForMember(x => x.DateModified, opt => opt.MapFrom(d => d.DateModified))
               .ForMember(x => x.ReadAndUnderstood, opt => opt.MapFrom(d => d.ReadAndUnderstoodNotes))
               .ForMember(x => x.IsUploaded, opt => opt.MapFrom(d => d.IsUploaded))
               .ForMember(x => x.CampaignId, opt => opt.MapFrom(d => d.CampaignId))
               .ForMember(x => x.NotInterestedReasonId, opt => opt.MapFrom(d => d.NotInterestedReasonId))
               .ForMember(x => x.HealthPlanId, opt => opt.Ignore())
               .ForMember(x => x.CallQueueId, opt => opt.MapFrom(d => d.CallQueueId))
               .ForMember(x => x.CustomTags, opt => opt.MapFrom(d => d.CustomTags))
               .ForMember(x => x.IsContacted, opt => opt.Ignore())
               .ForMember(x => x.DialerType, opt => opt.Ignore())
                 .ForMember(x => x.ProductTypeId, opt => opt.Ignore())
               .ForMember(x => x.InvalidNumberCount, opt => opt.Ignore());

            Mapper.CreateMap<LoincLabDataEntity, LoincLabData>();

            Mapper.CreateMap<LoincLabData, LoincLabDataEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0));

            Mapper.CreateMap<CustomerPredictedZipEntity, CustomerPredictedZip>();

            Mapper.CreateMap<CustomerPredictedZip, CustomerPredictedZipEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0));

            Mapper.CreateMap<AccountCheckoutPhoneNumberEntity, AccountCheckoutPhoneNumber>();

            Mapper.CreateMap<AccountCheckoutPhoneNumber, AccountCheckoutPhoneNumberEntity>()
            .IgnoreEntityBaseFields()
            .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<HealthPlanEventZip, HealthPlanEventZipEntity>()
            .IgnoreEntityBaseFields()
            .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<HealthPlanEventZipEntity, HealthPlanEventZip>();

            Mapper.CreateMap<EventCustomerCriticalQuestion, EventCustomerCriticalQuestionEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());

            Mapper.CreateMap<EventCustomerCriticalQuestionEntity, EventCustomerCriticalQuestion>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Note, opt => opt.Ignore());

            Mapper.CreateMap<AccountCallQueueSetting, AccountCallQueueSettingEntity>()
            .IgnoreEntityBaseFields()
            .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<AccountCallQueueSettingEntity, AccountCallQueueSetting>();

            Mapper.CreateMap<CustomerCallQueueCallAttempt, CustomerCallQueueCallAttemptEntity>()
                .IgnoreEntityBaseFields()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.CallAttemptId <= 0));

            Mapper.CreateMap<CustomerCallQueueCallAttemptEntity, CustomerCallQueueCallAttempt>();

            Mapper.CreateMap<EventCustomerIcdCodes, EventCustomerIcdCodesEntity>()
                .IgnoreEntityBaseFields()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true))
                .IgnoreEntityCollection();

            Mapper.CreateMap<EventCustomerIcdCodesEntity, EventCustomerIcdCodes>();

            Mapper.CreateMap<CustomerAccountGlocomNumberEntity, CustomerAccountGlocomNumber>();
            Mapper.CreateMap<CustomerAccountGlocomNumber, CustomerAccountGlocomNumberEntity>()
                .IgnoreEntityBaseFields()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true))
                .IgnoreEntityCollection();

            Mapper.CreateMap<EventCustomerCurrentMedication, EventCustomerCurrentMedicationEntity>()
                 .IgnoreEntityBaseFields()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true))
                .IgnoreEntityCollection();

            Mapper.CreateMap<AccountEventZip, AccountEventZipEntity>()
                .IgnoreEntityBaseFields()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true))
                .IgnoreEntityCollection();


            Mapper.CreateMap<VwGetCallsEntity, Call>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => d.CallId))
                .ForMember(x => x.CalledCustomerId, opt => opt.MapFrom(d => d.CalledCustomerId))
                .ForMember(x => x.CallDateTime, opt => opt.MapFrom(d => d.DateCreated))
                .ForMember(x => x.StartTime, opt => opt.MapFrom(d => d.TimeCreated))
                .ForMember(x => x.EndTime, opt => opt.MapFrom(d => d.TimeEnd))
                .ForMember(x => x.CallStatus, opt => opt.MapFrom(d => d.CallStatus))
                .ForMember(x => x.CalledInNumber, opt => opt.MapFrom(d => d.IncomingPhoneLine))
                .ForMember(x => x.CallerNumber, opt => opt.MapFrom(d => d.CallersPhoneNumber))
                .ForMember(x => x.CallBackNumber, opt => opt.MapFrom(d => d.CallBackNumber))
                .ForMember(x => x.IsIncoming, opt => opt.MapFrom(d => !d.OutBound))
                .ForMember(x => x.Status, opt => opt.MapFrom(d => d.Status))
                .ForMember(x => x.CreatedByOrgRoleUserId, opt => opt.MapFrom(d => d.CreatedByOrgRoleUserId))
                .ForMember(x => x.IsNewCustomer, opt => opt.MapFrom(d => d.IsNewCustomer))
                .ForMember(x => x.EventId, opt => opt.MapFrom(d => d.EventId))
                .ForMember(x => x.DateCreated, opt => opt.MapFrom(d => d.DateCreated))
                .ForMember(x => x.DateModified, opt => opt.MapFrom(d => d.DateModified))
                .ForMember(x => x.ReadAndUnderstood, opt => opt.MapFrom(d => d.ReadAndUnderstoodNotes))
                .ForMember(x => x.IsUploaded, opt => opt.MapFrom(d => d.IsUploaded))
                .ForMember(x => x.CampaignId, opt => opt.MapFrom(d => d.CampaignId))
                .ForMember(x => x.NotInterestedReasonId, opt => opt.MapFrom(d => d.NotInterestedReasonId))
                .ForMember(x => x.HealthPlanId, opt => opt.MapFrom(d => d.HealthPlanId))
                .ForMember(x => x.CallQueueId, opt => opt.MapFrom(d => d.CallQueueId))
                .ForMember(x => x.CustomTags, opt => opt.MapFrom(d => d.CustomTags))
                .ForMember(x => x.DialerType, opt => opt.Ignore())
                 .ForMember(x => x.ProductTypeId, opt => opt.Ignore())
                .ForMember(x => x.InvalidNumberCount, opt => opt.Ignore());


            Mapper.CreateMap<RapsUploadEntity, RapsUploadModel>()
                .ForMember(x => x.Filename, opt => opt.MapFrom(d => d.File.Path))
                .ForMember(x => x.Date, opt => opt.MapFrom(d => d.UploadTime.ToString("MM/dd/yyyy hh:mm tt")))
                .ForMember(x => x.Status, opt => opt.MapFrom(d => ((RapsUploadStatus)d.StatusId).GetDescription()))
                .ForMember(x => x.FailName, opt => opt.Ignore())
                .ForMember(x => x.UploadedName, opt => opt.Ignore())
                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore());

            Mapper.CreateMap<RapsEntity, MedicareRapsViewModel>();

            Mapper.CreateMap<CustomerPhoneNumberUpdateUpload, CustomerPhoneNumberUpdateUploadEntity>()
            .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0))
            .IgnoreEntityBaseFields()
            .IgnoreEntityCollection();

            Mapper.CreateMap<CustomerPhoneNumberUpdateUploadEntity, CustomerPhoneNumberUpdateUpload>();

            Mapper.CreateMap<MergeCustomerUpload, MergeCustomerUploadEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<MergeCustomerUploadEntity, MergeCustomerUpload>();

            Mapper.CreateMap<MergeCustomerUploadLog, MergeCustomerUploadLogEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<MergeCustomerUploadLogEntity, MergeCustomerUploadLog>();

            Mapper.CreateMap<MergeCustomerUploadLog, MergeCustomerUploadLogViewModel>()
                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore());

            Mapper.CreateMap<CustomerPhoneNumberUpdateUploadLog, CustomerPhoneNumberUpdateUploadLogEntity>()
            .ForMember(x => x.IsNew, opt => opt.UseValue(true))
            .IgnoreEntityBaseFields()
            .IgnoreEntityCollection();

            Mapper.CreateMap<CustomerPhoneNumberUpdateUploadLogEntity, CustomerPhoneNumberUpdateUploadLog>();

            Mapper.CreateMap<HealthPlanCriteriaAssignmentUpload, HealthPlanCriteriaAssignmentUploadEntity>()
            .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0))
            .IgnoreEntityBaseFields()
            .IgnoreEntityCollection();

            Mapper.CreateMap<HealthPlanCriteriaAssignmentUploadEntity, HealthPlanCriteriaAssignmentUpload>();


            Mapper.CreateMap<SmsReceived, SmsReceivedEntity>()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0))
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection();

            Mapper.CreateMap<SmsReceivedEntity, SmsReceived>();


            Mapper.CreateMap<CustomerUnsubscribedSmsNotification, CustomerUnsubscribedSmsNotificationEntity>()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0))
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection();

            Mapper.CreateMap<CustomerUnsubscribedSmsNotificationEntity, CustomerUnsubscribedSmsNotification>();

            Mapper.CreateMap<CallCenterTeam, CallCenterTeamEntity>()
              .ForMember(m => m.CreatedBy, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderCreator.Id))
              .ForMember(m => m.DateCreated, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateCreated))
              .ForMember(m => m.ModifiedBy, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderModifier != null ? d.DataRecorderMetaData.DataRecorderModifier.Id : d.DataRecorderMetaData.DataRecorderCreator.Id))
              .ForMember(m => m.DateModified, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateModified))
              .IgnoreEntityBaseFields()
              .IgnoreEntityCollection()
              .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<CallCenterTeamEntity, CallCenterTeam>()
            .ForMember(m => m.DataRecorderMetaData, opt => opt.MapFrom(d => new DataRecorderMetaData(d.CreatedBy, d.DateCreated, d.DateModified)
                 {
                     DataRecorderModifier = new OrganizationRoleUser(d.ModifiedBy)
                 }));

            Mapper.CreateMap<CallCenterAgentTeamLog, CallCenterAgentTeamLogEntity>()
             .IgnoreEntityBaseFields()
             .IgnoreEntityCollection()
             .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<CallCenterAgentTeamLogEntity, CallCenterAgentTeamLog>();

            Mapper.CreateMap<HealthPlanCriteriaTeamAssignment, HealthPlanCriteriaTeamAssignmentEntity>()
            .IgnoreEntityBaseFields()
            .IgnoreEntityCollection()
            .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<HealthPlanCriteriaTeamAssignmentEntity, HealthPlanCriteriaTeamAssignment>();

            Mapper.CreateMap<VwCallQueueCustomerCriteraAssignmentForStatsEntity, CallQueueCustomerCriteraAssignmentForStats>();

            Mapper.CreateMap<AccountCallCenterOrganization, AccountCallCenterOrganizationEntity>()
              .ForMember(m => m.CreatedBy, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderCreator.Id))
              .ForMember(m => m.DateCreated, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateCreated))
              .ForMember(m => m.ModifiedBy, opt => opt.MapFrom(d => d.DataRecorderMetaData.DataRecorderModifier != null ? d.DataRecorderMetaData.DataRecorderModifier.Id : d.DataRecorderMetaData.DataRecorderCreator.Id))
              .ForMember(m => m.DateModified, opt => opt.MapFrom(d => d.DataRecorderMetaData.DateModified))
              .IgnoreEntityBaseFields()
              .IgnoreEntityCollection()
              .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<AccountCallCenterOrganizationEntity, AccountCallCenterOrganization>()
            .ForMember(m => m.DataRecorderMetaData, opt => opt.MapFrom(d => new DataRecorderMetaData(d.CreatedBy, d.DateCreated, d.DateModified)
            {
                DataRecorderModifier = d.ModifiedBy.HasValue ? new OrganizationRoleUser(d.ModifiedBy.Value) : null
            }));

            Mapper.CreateMap<EventCustomerTestNotPerformedNotification, EventCustomerTestNotPerformedNotificationEntity>()
            .IgnoreEntityBaseFields()
            .IgnoreEntityCollection()
            .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<EventCustomerTestNotPerformedNotificationEntity, EventCustomerTestNotPerformedNotification>();

            Mapper.CreateMap<EligibilityUpload, EligibilityUploadEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<EligibilityUploadEntity, EligibilityUpload>();

            Mapper.CreateMap<CustomerEligibilityEntity, CustomerEligibility>();
            Mapper.CreateMap<CustomerEligibility, CustomerEligibilityEntity>()
                .IgnoreEntityBaseFields()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0))
                .IgnoreEntityCollection();

            Mapper.CreateMap<CallCenterRepProfile, CallCenterRepProfileEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
            .ForMember(x => x.IsNew, opt => opt.Ignore());

            Mapper.CreateMap<CallCenterRepProfileEntity, CallCenterRepProfile>()
                .ForMember(x => x.Address, opt => opt.Ignore())
                .ForMember(x => x.AlternateEmail, opt => opt.Ignore())
                .ForMember(x => x.DataRecorderMetaData, opt => opt.Ignore())
                .ForMember(x => x.DateOfBirth, opt => opt.Ignore())
                .ForMember(x => x.DefaultRole, opt => opt.Ignore())
                .ForMember(x => x.Email, opt => opt.Ignore())
                .ForMember(x => x.HomePhoneNumber, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.MobilePhoneNumber, opt => opt.Ignore())
                .ForMember(x => x.Name, opt => opt.Ignore())
                .ForMember(x => x.OfficePhoneNumber, opt => opt.Ignore())
                .ForMember(x => x.UserLogin, opt => opt.Ignore())
                .ForMember(x => x.PhoneOfficeExtension, opt => opt.Ignore())
                .ForMember(x => x.Ssn, opt => opt.Ignore());


            Mapper.CreateMap<CustomerTargetedEntity, CustomerTargeted>();
            Mapper.CreateMap<CustomerTargeted, CustomerTargetedEntity>()
                .IgnoreEntityBaseFields()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0))
                .IgnoreEntityCollection();


            Mapper.CreateMap<CustomerResultPostedEntity, CustomerResultPosted>();
            Mapper.CreateMap<CustomerResultPosted, CustomerResultPostedEntity>()
                .IgnoreEntityBaseFields()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.ResultPostId <= 0))
                .IgnoreEntityCollection();

            Mapper.CreateMap<StaffEventScheduleUpload, StaffEventScheduleUploadEntity>()
            .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0))
            .IgnoreEntityBaseFields()
            .IgnoreEntityCollection();

            Mapper.CreateMap<StaffEventScheduleUploadEntity, StaffEventScheduleUpload>();

            Mapper.CreateMap<StaffEventScheduleUploadLog, StaffEventScheduleUploadLogEntity>()
            .ForMember(x => x.IsNew, opt => opt.UseValue(true))
            .IgnoreEntityBaseFields()
            .IgnoreEntityCollection();

            Mapper.CreateMap<StaffEventScheduleUploadLogEntity, StaffEventScheduleUploadLog>();

            Mapper.CreateMap<UserNpiInfo, UserNpiInfoEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
            .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<UserNpiInfoEntity, UserNpiInfo>();

            Mapper.CreateMap<VwGetDataForSkippedCallReportEntity, CallSkippedReportEditModel>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection();

            Mapper.CreateMap<RescheduleCancelDisposition, RescheduleCancelDispositionEntity>()
               .IgnoreEntityBaseFields()
               .IgnoreEntityCollection()
               .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<RescheduleCancelDispositionEntity, RescheduleCancelDisposition>();

            Mapper.CreateMap<EventCustomerRetest, EventCustomerRetestEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
            .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<EventCustomerRetestEntity, EventCustomerRetest>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<Medication, MedicationEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0));

            Mapper.CreateMap<MedicationEntity, Medication>();

            Mapper.CreateMap<MedicationUploadLog, MedicationUploadLogEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<MedicationUploadLogEntity, MedicationUploadLog>();

            Mapper.CreateMap<MedicationUpload, MedicationUploadEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0));

            Mapper.CreateMap<MedicationUploadEntity, MedicationUpload>();

            Mapper.CreateMap<MedicationUploadEntity, MedicationUploadViewModel>()
                .ForMember(x => x.Filename, opt => opt.MapFrom(d => d.File.Path))
                .ForMember(x => x.Date, opt => opt.MapFrom(d => d.UploadTime.ToString("MM/dd/yyyy")))
                .ForMember(x => x.Status, opt => opt.MapFrom(d => ((MedicationUploadStatus)d.StatusId).GetDescription()))
                .ForMember(x => x.FailName, opt => opt.Ignore())
                .ForMember(x => x.UploadedName, opt => opt.Ignore())
                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore());

            Mapper.CreateMap<MedicationUploadLog, MedicationUploadLogViewModel>()
                .ForMember(x => x.Hicn, opt => opt.MapFrom(d => d.CmsHicn))
                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore());

            Mapper.CreateMap<Medication, MedicareMedicationViewModel>();
            Mapper.CreateMap<MedicationEntity, MedicareMedicationViewModel>();

            Mapper.CreateMap<CustomerTraleEntity, CustomerTrale>();

            Mapper.CreateMap<CustomerTrale, CustomerTraleEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<EventCustomerResultTraleEntity, EventCustomerResultTrale>();

            Mapper.CreateMap<EventCustomerResultTrale, EventCustomerResultTraleEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<UnitEntity, Unit>();

            Mapper.CreateMap<Unit, UnitEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<HealthPlanCriteriaDirectMailEntity, HealthPlanCriteriaDirectMail>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<HealthPlanCriteriaDirectMail, HealthPlanCriteriaDirectMailEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<SystemUserInfo, SystemUserInfoEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
            .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<SystemUserInfoEntity, SystemUserInfo>();

            Mapper.CreateMap<SuspectCondition, SuspectConditionEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<SuspectConditionEntity, SuspectCondition>();

            Mapper.CreateMap<SuspectConditionUpload, SuspectConditionUploadEntity>()
             .IgnoreEntityBaseFields()
             .IgnoreEntityCollection()
             .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));
            Mapper.CreateMap<SuspectConditionUploadEntity, SuspectConditionUpload>();


            Mapper.CreateMap<SuspectConditionUploadLog, SuspectConditionUploadLogEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<SuspectConditionUploadLogEntity, SuspectConditionUploadLog>();

            Mapper.CreateMap<SuspectConditionUploadLog, SuspectConditionUploadLogViewModel>()
                .ForMember(m => m.FeedbackMessage, opt => opt.Ignore());

            Mapper.CreateMap<SuspectCondition, MedicareSuspectConditionViewModel>();

            Mapper.CreateMap<SuspectConditionEntity, MedicareSuspectConditionViewModel>();

            Mapper.CreateMap<SuspectConditionUploadEntity, SuspectConditionUploadModel>()
                .ForMember(x => x.Filename, opt => opt.MapFrom(d => d.File.Path))
                .ForMember(x => x.Date, opt => opt.MapFrom(d => d.UploadTime.ToString("MM/dd/yyyy")))
                .ForMember(x => x.Status, opt => opt.MapFrom(d => ((SuspectConditionUploadStatus)d.StatusId).GetDescription()))
                .ForMember(x => x.FailName, opt => opt.Ignore())
                .ForMember(x => x.UploadedName, opt => opt.Ignore())
                .ForMember(x => x.FeedbackMessage, opt => opt.Ignore());

            Mapper.CreateMap<ZipRadiusDistance, ZipRadiusDistanceEntity>()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true))
                .IgnoreEntityBaseFields();

            Mapper.CreateMap<ZipRadiusDistanceEntity, ZipRadiusDistance>()
                .ForMember(x => x.Id, opt => opt.Ignore());


            Mapper.CreateMap<EventCustomerResultEntity, EventCustomerResultHistoryEntity>()
               .IgnoreEntityBaseFields()
               .IgnoreEntityCollection()
               .ForMember(x => x.Id, opt => opt.Ignore())
               .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<PreQualificationQuestion, PreQualificationQuestionEntity>()
               .IgnoreEntityBaseFields()
               .IgnoreEntityCollection()
               .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0));

            Mapper.CreateMap<PreQualificationQuestionEntity, PreQualificationQuestion>();

            Mapper.CreateMap<PreQualificationTestTemplate, PreQualificationTestTemplateEntity>()
               .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0))
               .IgnoreEntityBaseFields()
               .IgnoreEntityCollection();

            Mapper.CreateMap<PreQualificationTestTemplateEntity, PreQualificationTestTemplate>();

            Mapper.CreateMap<PreQualificationTemplateQuestion, PreQualificationTemplateQuestionEntity>()
               .IgnoreEntityBaseFields()
               .IgnoreEntityCollection()
               .ForMember(x => x.IsNew, opt => opt.Ignore());

            Mapper.CreateMap<PreQualificationTemplateQuestionEntity, PreQualificationTemplateQuestion>()
               .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<EventCustomerQuestionAnswer, EventCustomerQuestionAnswerEntity>()
               .IgnoreEntityBaseFields()
               .IgnoreEntityCollection()
               .ForMember(x => x.IsNew, opt => opt.Ignore());

            Mapper.CreateMap<EventCustomerQuestionAnswerEntity, EventCustomerQuestionAnswer>()
               .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<DisqualifiedTest, DisqualifiedTestEntity>()
               .IgnoreEntityBaseFields()
               .IgnoreEntityCollection()
               .ForMember(x => x.IsNew, opt => opt.Ignore());

            Mapper.CreateMap<DisqualifiedTestEntity, DisqualifiedTest>()
               .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<RequiredTest, RequiredTestEntity>()
               .IgnoreEntityBaseFields()
               .IgnoreEntityCollection()
               .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0));

            Mapper.CreateMap<RequiredTestEntity, RequiredTest>()
               .ForMember(x => x.IsActive, opt => opt.Ignore());

            Mapper.CreateMap<CustomerWarmTransferEntity, CustomerWarmTransfer>();
            Mapper.CreateMap<CustomerWarmTransfer, CustomerWarmTransferEntity>()
                .IgnoreEntityBaseFields()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0))
                .IgnoreEntityCollection();

            Mapper.CreateMap<PreQualificationTemplateDependentTestEntity, PreQualificationTemplateDependentTest>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<PreQualificationTemplateDependentTest, PreQualificationTemplateDependentTestEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());

            Mapper.CreateMap<DependentDisqualifiedTestEntity, DependentDisqualifiedTest>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<DependentDisqualifiedTest, DependentDisqualifiedTestEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());

            Mapper.CreateMap<Core.Medical.Domain.ActivityType, ActivityTypeEntity>()
               .IgnoreEntityBaseFields()
               .IgnoreEntityCollection()
               .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0));

            Mapper.CreateMap<ActivityTypeEntity, Core.Medical.Domain.ActivityType>()
               .ForMember(x => x.IsActive, opt => opt.Ignore());

            Mapper.CreateMap<FluConsentTemplateEntity, FluConsentTemplate>();

            Mapper.CreateMap<FluConsentTemplate, FluConsentTemplateEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0));

            Mapper.CreateMap<FluConsentQuestionEntity, FluConsentQuestion>();

            Mapper.CreateMap<FluConsentQuestion, FluConsentQuestionEntity>()
                .ForMember(x => x.FluConsentQuestionType, opt => opt.Ignore())
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0));

            Mapper.CreateMap<FluConsentTemplateQuestionEntity, FluConsentTemplateQuestion>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<FluConsentTemplateQuestion, FluConsentTemplateQuestionEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());

            Mapper.CreateMap<FluConsentAnswerEntity, FluConsentAnswer>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<FluConsentAnswer, FluConsentAnswerEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());


            Mapper.CreateMap<Event, ShortEventInfoViewModel>()
                .ForMember(x => x.HostAddress, opt => opt.Ignore())
                .ForMember(x => x.HostName, opt => opt.Ignore())
                .ForMember(x => x.Pods, opt => opt.Ignore())
                .ForMember(x => x.TotalAppointmentSlots, opt => opt.Ignore())
                .ForMember(x => x.FilledAppintmentSlots, opt => opt.Ignore())
                .ForMember(x => x.CaptureHealthAssessmentForm, opt => opt.Ignore())
                .ForMember(x => x.Sponsor, opt => opt.Ignore())
                .ForMember(x => x.BookedSlots, opt => opt.Ignore())
                .ForMember(x => x.HipaaSignedCount, opt => opt.Ignore())
                .ForMember(x => x.HipaaUnSignedCount, opt => opt.Ignore())
                .ForMember(x => x.ShowGiftCard, opt => opt.Ignore())
                .ForMember(x => x.GiftCardAmount, opt => opt.Ignore())
                .ForMember(x => x.ShowMatrixConsent, opt => opt.Ignore())
                .ForMember(x => x.ShowFluVaccineConsent, opt => opt.Ignore())
                .ForMember(x => x.ShowChaperoneConsent, opt => opt.Ignore())
                .ForMember(x => x.ShowSurvey, opt => opt.Ignore())
                .ForMember(x => x.ShowPcpConsent, opt => opt.Ignore());


            Mapper.CreateMap<FluConsentSignatureEntity, FluConsentSignature>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<FluConsentSignature, FluConsentSignatureEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());


            Mapper.CreateMap<ParticipationConsentSignatureEntity, ParticipationConsentSignature>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<ParticipationConsentSignature, ParticipationConsentSignatureEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());


            Mapper.CreateMap<PhysicianRecordRequestSignatureEntity, PhysicianRecordRequestSignature>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<PhysicianRecordRequestSignature, PhysicianRecordRequestSignatureEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());


            Mapper.CreateMap<ExitInterviewSignatureEntity, ExitInterviewSignature>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<ExitInterviewSignature, ExitInterviewSignatureEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());





            Mapper.CreateMap<SurveyQuestion, SurveyQuestionEntity>()
                .ForMember(x => x.TypeId, opt => opt.MapFrom(d => (long)d.Type))
                .ForMember(x => x.Gender, opt => opt.MapFrom(d => (long)d.Gender))
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<SurveyQuestionEntity, SurveyQuestion>()
                .ForMember(x => x.Gender, opt => opt.MapFrom(d => (Gender)d.Gender))
                .ForMember(x => x.Type, opt => opt.MapFrom(d => (DisplayControlType)d.TypeId));

            Mapper.CreateMap<SurveyAnswer, SurveyAnswerEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.EventCustomerId, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.CreatedOn, opt => opt.MapFrom(d => (d.DataRecorderMetaData != null ? (DateTime?)d.DataRecorderMetaData.DateCreated : null)))
                .ForMember(x => x.ModifiedOn, opt => opt.MapFrom(d => (d.DataRecorderMetaData != null ? d.DataRecorderMetaData.DateModified : null)))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(d => (d.DataRecorderMetaData != null && d.DataRecorderMetaData.DataRecorderCreator != null ? d.DataRecorderMetaData.DataRecorderCreator.Id : 0)))
                .ForMember(x => x.ModifiedBy, opt => opt.MapFrom(d => (d.DataRecorderMetaData != null && d.DataRecorderMetaData.DataRecorderModifier != null ? (long?)d.DataRecorderMetaData.DataRecorderModifier.Id : null)))


                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<SurveyAnswerEntity, SurveyAnswer>()
                .ForMember(x => x.DataRecorderMetaData, opt => opt.MapFrom(d => new DataRecorderMetaData((d.CreatedBy), d.CreatedOn, d.ModifiedOn)
                {
                    DataRecorderModifier = d.ModifiedBy.HasValue ? new OrganizationRoleUser(d.ModifiedBy.Value) : null
                }))
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.EventCustomerId));

            Mapper.CreateMap<SurveyTemplateEntity, SurveyTemplate>();

            Mapper.CreateMap<SurveyTemplate, SurveyTemplateEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0));

            Mapper.CreateMap<SurveyTemplateQuestionEntity, SurveyTemplateQuestion>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<SurveyTemplateQuestion, SurveyTemplateQuestionEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<SurveyTemplateEditModel, SurveyTemplate>()
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateModified, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.IsActive, opt => opt.UseValue(true));

            Mapper.CreateMap<EventSurveyTemplateEntity, EventSurveyTemplate>();

            Mapper.CreateMap<EventSurveyTemplate, EventSurveyTemplateEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true));

            Mapper.CreateMap<EventCustomerGiftCardEntity, EventCustomerGiftCard>();

            Mapper.CreateMap<EventCustomerGiftCard, EventCustomerGiftCardEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0));

            Mapper.CreateMap<TestPerformedExternallyEntity, TestPerformedExternally>();

            Mapper.CreateMap<TestPerformedExternally, TestPerformedExternallyEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<ApplicationAuthenticationEntity, ApplicationAuthentication>();

            Mapper.CreateMap<ExitInterviewQuestionEntity, ExitInterviewQuestion>();

            Mapper.CreateMap<ExitInterviewQuestion, ExitInterviewQuestionEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0));

            Mapper.CreateMap<ExitInterviewAnswerEntity, ExitInterviewAnswer>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<ExitInterviewAnswer, ExitInterviewAnswerEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());

            Mapper.CreateMap<MemberUploadLog, MemberUploadLogEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<PinChangelogEntity, PinChangelog>();
            Mapper.CreateMap<PinChangelog, PinChangelogEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(m => m.IsNew, opt => opt.MapFrom(x => x.Id <= 0));


            Mapper.CreateMap<ChaperoneQuestionEntity, ChaperoneQuestion>();

            Mapper.CreateMap<ChaperoneQuestion, ChaperoneQuestionEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(d => d.Id <= 0));


            Mapper.CreateMap<ChaperoneAnswerEntity, ChaperoneAnswer>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<ChaperoneAnswer, ChaperoneAnswerEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());

            Mapper.CreateMap<ChaperoneSignatureEntity, ChaperoneSignature>()
                    .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<ChaperoneSignature, ChaperoneSignatureEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());

            Mapper.CreateMap<PreQualificationQuestionRuleEntity, PreQualificationQuestionRule>()
                   .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<PreQualificationQuestionRule, PreQualificationQuestionRuleEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());

            Mapper.CreateMap<CustomerActivityTypeUpload, CustomerActivityTypeUploadEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<CustomerActivityTypeUploadEntity, CustomerActivityTypeUpload>();

            Mapper.CreateMap<CustomerOrderHistory, CustomerOrderHistoryEntity>()
               .IgnoreEntityBaseFields()
               .IgnoreEntityCollection()
               .ForMember(x => x.IsNew, opt => opt.Ignore());

            Mapper.CreateMap<CustomerOrderHistoryEntity, CustomerOrderHistory>()
                .ForMember(x => x.Id, opt => opt.Ignore());


            Mapper.CreateMap<EventCustomerResultBloodLabParser, EventCustomerResultBloodLabParserEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.Ignore());

            Mapper.CreateMap<EventCustomerResultBloodLabParserEntity, EventCustomerResultBloodLabParser>()
                .ForMember(x => x.EventCustomerResultId, opt => opt.Ignore());

            Mapper.CreateMap<MemberUploadParseDetail, MemberUploadParseDetailEntity>()
                .IgnoreEntityBaseFields()
                .IgnoreEntityCollection()
                .ForMember(x => x.IsNew, opt => opt.MapFrom(x => x.Id <= 0));

            Mapper.CreateMap<MemberUploadParseDetailEntity, MemberUploadParseDetail>();


            Mapper.CreateMap<PreAssessmentCallQueueCustomerLockEntity, PreAssessmentCallQueueCustomerLock>()
              .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<PreAssessmentCallQueueCustomerLock, PreAssessmentCallQueueCustomerLockEntity>()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true))
                .IgnoreEntityBaseFields();


            Mapper.CreateMap<PreAssessmentCustomerCallQueueCallAttemptEntity, PreAssessmentCustomerCallQueueCallAttempt>();
            // .ForMember(x => x.PreAssessmentCallAttemptID, opt => opt.Ignore());

            Mapper.CreateMap<PreAssessmentCustomerCallQueueCallAttempt, PreAssessmentCustomerCallQueueCallAttemptEntity>()
                .ForMember(x => x.IsNew, opt => opt.UseValue(true))
                .IgnoreEntityBaseFields();

            Mapper.CreateMap<EventProductTypeEntity, EventProductType>()
                .ForMember(x => x.Id, opt => opt.Ignore()); ;

            Mapper.CreateMap<EventProductType, EventProductTypeEntity>()
                      .ForMember(x => x.IsNew, opt => opt.UseValue(true))
                .IgnoreEntityBaseFields();

            Mapper.CreateMap<EventZipProductTypeEntity, EventZipProductType>()
                .ForMember(x => x.Id, opt => opt.Ignore()); 

            Mapper.CreateMap<EventZipProductType, EventZipProductTypeEntity>()
                      .ForMember(x => x.IsNew, opt => opt.UseValue(true))
                .IgnoreEntityBaseFields();

            Mapper.CreateMap<EventZipProductTypeSubstituteEntity, EventZipProductType>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.CreateMap<EventZipProductType, EventZipProductTypeSubstituteEntity>()
                      .ForMember(x => x.IsNew, opt => opt.UseValue(true))
                .IgnoreEntityBaseFields();
                




            //should be last statement in file.
            Mapper.AssertConfigurationIsValid();

        }
    }
}