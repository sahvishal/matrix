///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:36
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;

namespace Falcon.Data
{

	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AccessControlObject.
	/// </summary>
	public enum AccessControlObjectFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Title. </summary>
		Title,
		///<summary>Description. </summary>
		Description,
		///<summary>ParentId. </summary>
		ParentId,
		///<summary>DisplayOrder. </summary>
		DisplayOrder,
		///<summary>IsRequired. </summary>
		IsRequired,
		///<summary>Alias. </summary>
		Alias,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AccessControlObjectUrl.
	/// </summary>
	public enum AccessControlObjectUrlFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>AccessControlObjectId. </summary>
		AccessControlObjectId,
		///<summary>Url. </summary>
		Url,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AccessObjectScopeOption.
	/// </summary>
	public enum AccessObjectScopeOptionFieldIndex:int
	{
		///<summary>AccessControlObjectId. </summary>
		AccessControlObjectId,
		///<summary>ScopeId. </summary>
		ScopeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Account.
	/// </summary>
	public enum AccountFieldIndex:int
	{
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>ContractNotes. </summary>
		ContractNotes,
		///<summary>ShowSponsoredByUrl. </summary>
		ShowSponsoredByUrl,
		///<summary>Content. </summary>
		Content,
		///<summary>ConvertedHostId. </summary>
		ConvertedHostId,
		///<summary>CorpCode. </summary>
		CorpCode,
		///<summary>CorporateWhiteLabeling. </summary>
		CorporateWhiteLabeling,
		///<summary>AllowCobranding. </summary>
		AllowCobranding,
		///<summary>FluffLetterFileId. </summary>
		FluffLetterFileId,
		///<summary>CaptureInsuranceId. </summary>
		CaptureInsuranceId,
		///<summary>InsuranceIdRequired. </summary>
		InsuranceIdRequired,
		///<summary>SendAppointmentMail. </summary>
		SendAppointmentMail,
		///<summary>Tag. </summary>
		Tag,
		///<summary>MemberIdLabel. </summary>
		MemberIdLabel,
		///<summary>AllowOnlineRegistration. </summary>
		AllowOnlineRegistration,
		///<summary>AllowPreQualifiedTestOnly. </summary>
		AllowPreQualifiedTestOnly,
		///<summary>AllowCustomerPortalLogin. </summary>
		AllowCustomerPortalLogin,
		///<summary>SendResultReadyMail. </summary>
		SendResultReadyMail,
		///<summary>ShowBasicBiometricPage. </summary>
		ShowBasicBiometricPage,
		///<summary>SendSurveyMail. </summary>
		SendSurveyMail,
		///<summary>AppointmentConfirmationMailTemplateId. </summary>
		AppointmentConfirmationMailTemplateId,
		///<summary>AppointmentReminderMailTemplateId. </summary>
		AppointmentReminderMailTemplateId,
		///<summary>ResultReadyMailTemplateId. </summary>
		ResultReadyMailTemplateId,
		///<summary>SurveyMailTemplateId. </summary>
		SurveyMailTemplateId,
		///<summary>AllowVerifiedMembersOnly. </summary>
		AllowVerifiedMembersOnly,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>MemberId. </summary>
		MemberId,
		///<summary>Zipcode. </summary>
		Zipcode,
		///<summary>LastName. </summary>
		LastName,
		///<summary>DateOfBirth. </summary>
		DateOfBirth,
		///<summary>Email. </summary>
		Email,
		///<summary>SendResultReadyMailWithFax. </summary>
		SendResultReadyMailWithFax,
		///<summary>CapturePcpconsent. </summary>
		CapturePcpconsent,
		///<summary>CaptureAbnstatus. </summary>
		CaptureAbnstatus,
		///<summary>AllowPrePayment. </summary>
		AllowPrePayment,
		///<summary>HicnumberRequired. </summary>
		HicnumberRequired,
		///<summary>GeneratePcpLetterWithDiagnosisCode. </summary>
		GeneratePcpLetterWithDiagnosisCode,
		///<summary>GenerateCustomerResult. </summary>
		GenerateCustomerResult,
		///<summary>IsCustomerResultsTestDependent. </summary>
		IsCustomerResultsTestDependent,
		///<summary>GeneratePcpResult. </summary>
		GeneratePcpResult,
		///<summary>CheckoutPhoneNumber. </summary>
		CheckoutPhoneNumber,
		///<summary>RecommendPackage. </summary>
		RecommendPackage,
		///<summary>AskPreQualificationQuestion. </summary>
		AskPreQualificationQuestion,
		///<summary>SendWelcomeEmail. </summary>
		SendWelcomeEmail,
		///<summary>CaptureHaf. </summary>
		CaptureHaf,
		///<summary>CaptureHafonline. </summary>
		CaptureHafonline,
		///<summary>EnableImageUpsell. </summary>
		EnableImageUpsell,
		///<summary>AllowTechUpdateQualifiedTests. </summary>
		AllowTechUpdateQualifiedTests,
		///<summary>AttachQualityAssuranceForm. </summary>
		AttachQualityAssuranceForm,
		///<summary>RemoveLongDescription. </summary>
		RemoveLongDescription,
		///<summary>GenerateBatchLabel. </summary>
		GenerateBatchLabel,
		///<summary>AttachCongitiveClockForm. </summary>
		AttachCongitiveClockForm,
		///<summary>AttachChronicEvaluationForm. </summary>
		AttachChronicEvaluationForm,
		///<summary>AttachParicipantConsentForm. </summary>
		AttachParicipantConsentForm,
		///<summary>UpsellTest. </summary>
		UpsellTest,
		///<summary>AskClinicalQuestions. </summary>
		AskClinicalQuestions,
		///<summary>ClinicalQuestionTemplateId. </summary>
		ClinicalQuestionTemplateId,
		///<summary>DefaultSelectionBasePackage. </summary>
		DefaultSelectionBasePackage,
		///<summary>SlotBooking. </summary>
		SlotBooking,
		///<summary>AddImagesForAbnormal. </summary>
		AddImagesForAbnormal,
		///<summary>BookPcpAppointment. </summary>
		BookPcpAppointment,
		///<summary>NumberOfDays. </summary>
		NumberOfDays,
		///<summary>ScreeningInfo. </summary>
		ScreeningInfo,
		///<summary>PatientWorkSheet. </summary>
		PatientWorkSheet,
		///<summary>UseHeaderImage. </summary>
		UseHeaderImage,
		///<summary>ShowHafFooter. </summary>
		ShowHafFooter,
		///<summary>CaptureSurvey. </summary>
		CaptureSurvey,
		///<summary>SurveyPdfFileId. </summary>
		SurveyPdfFileId,
		///<summary>PcpLetterPdfFileId. </summary>
		PcpLetterPdfFileId,
		///<summary>AttachScannedDoc. </summary>
		AttachScannedDoc,
		///<summary>ResultFormatTypeId. </summary>
		ResultFormatTypeId,
		///<summary>AttachUnreadableTest. </summary>
		AttachUnreadableTest,
		///<summary>AttachGiftCard. </summary>
		AttachGiftCard,
		///<summary>GiftCardAmount. </summary>
		GiftCardAmount,
		///<summary>AttachEawvPreventionPlan. </summary>
		AttachEawvPreventionPlan,
		///<summary>GenerateEawvPreventionPlanReport. </summary>
		GenerateEawvPreventionPlanReport,
		///<summary>GenerateFluPneuConsentForm. </summary>
		GenerateFluPneuConsentForm,
		///<summary>GenerateBmiReport. </summary>
		GenerateBmiReport,
		///<summary>EnablePgpEncryption. </summary>
		EnablePgpEncryption,
		///<summary>PublicKeyFileId. </summary>
		PublicKeyFileId,
		///<summary>LockEvent. </summary>
		LockEvent,
		///<summary>GenerateHealthPlanReport. </summary>
		GenerateHealthPlanReport,
		///<summary>IsHealthPlan. </summary>
		IsHealthPlan,
		///<summary>AttachAttestationForm. </summary>
		AttachAttestationForm,
		///<summary>EventLockDaysCount. </summary>
		EventLockDaysCount,
		///<summary>AttachOrderRequisitionForm. </summary>
		AttachOrderRequisitionForm,
		///<summary>ParticipantLetterId. </summary>
		ParticipantLetterId,
		///<summary>FolderName. </summary>
		FolderName,
		///<summary>CheckListFileId. </summary>
		CheckListFileId,
		///<summary>PrintCheckList. </summary>
		PrintCheckList,
		///<summary>SendEventResultReadyNotification. </summary>
		SendEventResultReadyNotification,
		///<summary>ShowBarrier. </summary>
		ShowBarrier,
		///<summary>PrintPcpAppointmentForBulkHaf. </summary>
		PrintPcpAppointmentForBulkHaf,
		///<summary>PrintPcpAppointmentForResult. </summary>
		PrintPcpAppointmentForResult,
		///<summary>PrintAceForm. </summary>
		PrintAceForm,
		///<summary>PrintMipForm. </summary>
		PrintMipForm,
		///<summary>AllowRegistrationWithImproperTags. </summary>
		AllowRegistrationWithImproperTags,
		///<summary>PrintMicroalbuminForm. </summary>
		PrintMicroalbuminForm,
		///<summary>PrintIfobtform. </summary>
		PrintIfobtform,
		///<summary>EnableSms. </summary>
		EnableSms,
		///<summary>MaximumSms. </summary>
		MaximumSms,
		///<summary>ConfirmationSmsTemplateId. </summary>
		ConfirmationSmsTemplateId,
		///<summary>ReminderSmsTemplateId. </summary>
		ReminderSmsTemplateId,
		///<summary>PrintLoincLabData. </summary>
		PrintLoincLabData,
		///<summary>CheckListTemplateId. </summary>
		CheckListTemplateId,
		///<summary>IsMaxAttemptPerHealthPlan. </summary>
		IsMaxAttemptPerHealthPlan,
		///<summary>MaxAttempt. </summary>
		MaxAttempt,
		///<summary>MarkPennedBack. </summary>
		MarkPennedBack,
		///<summary>PennedBackText. </summary>
		PennedBackText,
		///<summary>ShowCallCenterScript. </summary>
		ShowCallCenterScript,
		///<summary>CallCenterScriptFileId. </summary>
		CallCenterScriptFileId,
		///<summary>EventConfirmationBeforeDays. </summary>
		EventConfirmationBeforeDays,
		///<summary>ConfirmationBeforeAppointmentMinutes. </summary>
		ConfirmationBeforeAppointmentMinutes,
		///<summary>ConfirmationScriptFileId. </summary>
		ConfirmationScriptFileId,
		///<summary>RestrictHealthPlanData. </summary>
		RestrictHealthPlanData,
		///<summary>SendPatientDataToAces. </summary>
		SendPatientDataToAces,
		///<summary>ClientId. </summary>
		ClientId,
		///<summary>SendConsentData. </summary>
		SendConsentData,
		///<summary>ShowGiftCertificateOnEod. </summary>
		ShowGiftCertificateOnEod,
		///<summary>WarmTransfer. </summary>
		WarmTransfer,
		///<summary>InboundCallScriptFileId. </summary>
		InboundCallScriptFileId,
		///<summary>AcesClientShortName. </summary>
		AcesClientShortName,
		///<summary>IncludeMemberLetter. </summary>
		IncludeMemberLetter,
		///<summary>MemberLetterFileId. </summary>
		MemberLetterFileId,
		///<summary>PcpCoverLetterTemplateId. </summary>
		PcpCoverLetterTemplateId,
		///<summary>MemberCoverLetterTemplateId. </summary>
		MemberCoverLetterTemplateId,
		///<summary>AcesToHipIntake. </summary>
		AcesToHipIntake,
		///<summary>AcesToHipIntakeShortName. </summary>
		AcesToHipIntakeShortName,
		///<summary>FluConsentTemplateId. </summary>
		FluConsentTemplateId,
		///<summary>ExitInterviewTemplateId. </summary>
		ExitInterviewTemplateId,
		///<summary>SurveyTemplateId. </summary>
		SurveyTemplateId,
		///<summary>ShowChaperonForm. </summary>
		ShowChaperonForm,
		///<summary>GeneratePcpLetter. </summary>
		GeneratePcpLetter,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AccountAdditionalFields.
	/// </summary>
	public enum AccountAdditionalFieldsFieldIndex:int
	{
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>AdditionalFieldId. </summary>
		AdditionalFieldId,
		///<summary>DisplayName. </summary>
		DisplayName,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AccountCallCenterOrganization.
	/// </summary>
	public enum AccountCallCenterOrganizationFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>OrganizationId. </summary>
		OrganizationId,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsDeleted. </summary>
		IsDeleted,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AccountCallQueueSetting.
	/// </summary>
	public enum AccountCallQueueSettingFieldIndex:int
	{
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>CallQueueId. </summary>
		CallQueueId,
		///<summary>SuppressionTypeId. </summary>
		SuppressionTypeId,
		///<summary>NoOfDays. </summary>
		NoOfDays,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AccountCheckoutPhoneNumber.
	/// </summary>
	public enum AccountCheckoutPhoneNumberFieldIndex:int
	{
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>StateId. </summary>
		StateId,
		///<summary>CheckoutPhoneNumber. </summary>
		CheckoutPhoneNumber,
		///<summary>Id. </summary>
		Id,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AccountCoordinatorProfile.
	/// </summary>
	public enum AccountCoordinatorProfileFieldIndex:int
	{
		///<summary>OrganizationRoleUserId. </summary>
		OrganizationRoleUserId,
		///<summary>IsClinicalCoordinator. </summary>
		IsClinicalCoordinator,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AccountCustomerResultTestDependency.
	/// </summary>
	public enum AccountCustomerResultTestDependencyFieldIndex:int
	{
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>TestId. </summary>
		TestId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AccountEventZip.
	/// </summary>
	public enum AccountEventZipFieldIndex:int
	{
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>ZipId. </summary>
		ZipId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AccountEventZipSubstitute.
	/// </summary>
	public enum AccountEventZipSubstituteFieldIndex:int
	{
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>ZipId. </summary>
		ZipId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AccountHealthPlanResultTestDependency.
	/// </summary>
	public enum AccountHealthPlanResultTestDependencyFieldIndex:int
	{
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>TestId. </summary>
		TestId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AccountHraChatQuestionnaire.
	/// </summary>
	public enum AccountHraChatQuestionnaireFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>QuestionnaireType. </summary>
		QuestionnaireType,
		///<summary>StartDate. </summary>
		StartDate,
		///<summary>EndDate. </summary>
		EndDate,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>ModifiedOn. </summary>
		ModifiedOn,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AccountNotReviewableTest.
	/// </summary>
	public enum AccountNotReviewableTestFieldIndex:int
	{
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>TestId. </summary>
		TestId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AccountPackage.
	/// </summary>
	public enum AccountPackageFieldIndex:int
	{
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>PackageId. </summary>
		PackageId,
		///<summary>IsRecommended. </summary>
		IsRecommended,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AccountPcpResultTestDependency.
	/// </summary>
	public enum AccountPcpResultTestDependencyFieldIndex:int
	{
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>TestId. </summary>
		TestId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AccountTest.
	/// </summary>
	public enum AccountTestFieldIndex:int
	{
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>TestId. </summary>
		TestId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AccountTestHcpcsCode.
	/// </summary>
	public enum AccountTestHcpcsCodeFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>TestHcpcsCodeId. </summary>
		TestHcpcsCodeId,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>ModifiedDate. </summary>
		ModifiedDate,
		///<summary>IsDeleted. </summary>
		IsDeleted,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Activity.
	/// </summary>
	public enum ActivityFieldIndex:int
	{
		///<summary>ActivityId. </summary>
		ActivityId,
		///<summary>Type. </summary>
		Type,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>ModifiedByOrgRoleUserId. </summary>
		ModifiedByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ActivityType.
	/// </summary>
	public enum ActivityTypeFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Name. </summary>
		Name,
		///<summary>Alias. </summary>
		Alias,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AdditionalFields.
	/// </summary>
	public enum AdditionalFieldsFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Name. </summary>
		Name,
		///<summary>Alias. </summary>
		Alias,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>ModifiedDate. </summary>
		ModifiedDate,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Address.
	/// </summary>
	public enum AddressFieldIndex:int
	{
		///<summary>AddressId. </summary>
		AddressId,
		///<summary>Address1. </summary>
		Address1,
		///<summary>Address2. </summary>
		Address2,
		///<summary>CityId. </summary>
		CityId,
		///<summary>StateId. </summary>
		StateId,
		///<summary>CountryId. </summary>
		CountryId,
		///<summary>ZipId. </summary>
		ZipId,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>Latitude. </summary>
		Latitude,
		///<summary>Longitude. </summary>
		Longitude,
		///<summary>VerificationOrgRoleUserId. </summary>
		VerificationOrgRoleUserId,
		///<summary>IsManuallyVerified. </summary>
		IsManuallyVerified,
		///<summary>UseLatLogForMapping. </summary>
		UseLatLogForMapping,
		///<summary>NeedVerification. </summary>
		NeedVerification,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AdvocateManagerTeam.
	/// </summary>
	public enum AdvocateManagerTeamFieldIndex:int
	{
		///<summary>ManagerTeamId. </summary>
		ManagerTeamId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>ManagerOrgRoleUserId. </summary>
		ManagerOrgRoleUserId,
		///<summary>SalesRepOrgRoleUserId. </summary>
		SalesRepOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Afadvertiser.
	/// </summary>
	public enum AfadvertiserFieldIndex:int
	{
		///<summary>AdvertiserId. </summary>
		AdvertiserId,
		///<summary>AdvertiserName. </summary>
		AdvertiserName,
		///<summary>ChannelId. </summary>
		ChannelId,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>LastModifiedDate. </summary>
		LastModifiedDate,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AfAdvertisingCommission.
	/// </summary>
	public enum AfAdvertisingCommissionFieldIndex:int
	{
		///<summary>MmcommissionId. </summary>
		MmcommissionId,
		///<summary>MarketingMaterialId. </summary>
		MarketingMaterialId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>AffiliateId. </summary>
		AffiliateId,
		///<summary>Commission. </summary>
		Commission,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>LastModifiedDate. </summary>
		LastModifiedDate,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsPaid. </summary>
		IsPaid,
		///<summary>PaymentId. </summary>
		PaymentId,
		///<summary>IsApproved. </summary>
		IsApproved,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AfaffiliateCampaign.
	/// </summary>
	public enum AfaffiliateCampaignFieldIndex:int
	{
		///<summary>AffiliateCampaignId. </summary>
		AffiliateCampaignId,
		///<summary>AffiliateId. </summary>
		AffiliateId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>AssignedDate. </summary>
		AssignedDate,
		///<summary>IsAssignmentActive. </summary>
		IsAssignmentActive,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>LastModifiedDate. </summary>
		LastModifiedDate,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AfaffiliateCampaignMarketingMaterial.
	/// </summary>
	public enum AfaffiliateCampaignMarketingMaterialFieldIndex:int
	{
		///<summary>AffiliateCampaignMarketingMaterialId. </summary>
		AffiliateCampaignMarketingMaterialId,
		///<summary>MarketingMaterialId. </summary>
		MarketingMaterialId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>ImpressionCount. </summary>
		ImpressionCount,
		///<summary>ClickCount. </summary>
		ClickCount,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>LastModifiedDate. </summary>
		LastModifiedDate,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsInbound. </summary>
		IsInbound,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Afcampaign.
	/// </summary>
	public enum AfcampaignFieldIndex:int
	{
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>CampaignName. </summary>
		CampaignName,
		///<summary>PromoCodeId. </summary>
		PromoCodeId,
		///<summary>AdvertiserId. </summary>
		AdvertiserId,
		///<summary>IncomingPhone. </summary>
		IncomingPhone,
		///<summary>StartDate. </summary>
		StartDate,
		///<summary>EndDate. </summary>
		EndDate,
		///<summary>Cost. </summary>
		Cost,
		///<summary>Commision. </summary>
		Commision,
		///<summary>ParentAffiliateCommision. </summary>
		ParentAffiliateCommision,
		///<summary>IsCommisionPercentage. </summary>
		IsCommisionPercentage,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>LastModifiedDate. </summary>
		LastModifiedDate,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsGlobal. </summary>
		IsGlobal,
		///<summary>CompensationType. </summary>
		CompensationType,
		///<summary>CampaignType. </summary>
		CampaignType,
		///<summary>OwnerAffiliate. </summary>
		OwnerAffiliate,
		///<summary>IsuniquePhonenumber. </summary>
		IsuniquePhonenumber,
		///<summary>IsAutoGenerated. </summary>
		IsAutoGenerated,
		///<summary>Notes. </summary>
		Notes,
		///<summary>CategoryId. </summary>
		CategoryId,
		///<summary>RoleId. </summary>
		RoleId,
		///<summary>ShellId. </summary>
		ShellId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AfcampaignCreative.
	/// </summary>
	public enum AfcampaignCreativeFieldIndex:int
	{
		///<summary>CampaignCreativeId. </summary>
		CampaignCreativeId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>CreativeId. </summary>
		CreativeId,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>LastModifiedDate. </summary>
		LastModifiedDate,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AfcampaignSubAdvocate.
	/// </summary>
	public enum AfcampaignSubAdvocateFieldIndex:int
	{
		///<summary>CampaignSubAffiliateId. </summary>
		CampaignSubAffiliateId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>AffiliateId. </summary>
		AffiliateId,
		///<summary>SubAffiliateId. </summary>
		SubAffiliateId,
		///<summary>SubAffiliateCommission. </summary>
		SubAffiliateCommission,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>ModifiedOn. </summary>
		ModifiedOn,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AfcampaignTemplate.
	/// </summary>
	public enum AfcampaignTemplateFieldIndex:int
	{
		///<summary>CampaignTemplateId. </summary>
		CampaignTemplateId,
		///<summary>TemplateType. </summary>
		TemplateType,
		///<summary>TemplateCampaignName. </summary>
		TemplateCampaignName,
		///<summary>PromoCodeId. </summary>
		PromoCodeId,
		///<summary>AdvertiserId. </summary>
		AdvertiserId,
		///<summary>IncomingPhone. </summary>
		IncomingPhone,
		///<summary>StartDate. </summary>
		StartDate,
		///<summary>EndDate. </summary>
		EndDate,
		///<summary>Cost. </summary>
		Cost,
		///<summary>Commision. </summary>
		Commision,
		///<summary>ParentAffiliateCommision. </summary>
		ParentAffiliateCommision,
		///<summary>IsCommisionPercentage. </summary>
		IsCommisionPercentage,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>LastModifiedDate. </summary>
		LastModifiedDate,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsGlobal. </summary>
		IsGlobal,
		///<summary>OwnerFranchiseeId. </summary>
		OwnerFranchiseeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Afchannel.
	/// </summary>
	public enum AfchannelFieldIndex:int
	{
		///<summary>ChannelId. </summary>
		ChannelId,
		///<summary>ChannelName. </summary>
		ChannelName,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>LastModifiedDate. </summary>
		LastModifiedDate,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Afcommision.
	/// </summary>
	public enum AfcommisionFieldIndex:int
	{
		///<summary>CommisionId. </summary>
		CommisionId,
		///<summary>AffiliateId. </summary>
		AffiliateId,
		///<summary>AffiliateCampaignId. </summary>
		AffiliateCampaignId,
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>Commision. </summary>
		Commision,
		///<summary>IsParentAffilateCommision. </summary>
		IsParentAffilateCommision,
		///<summary>Notes. </summary>
		Notes,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>LastModifiedDate. </summary>
		LastModifiedDate,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsPaid. </summary>
		IsPaid,
		///<summary>SaleAmount. </summary>
		SaleAmount,
		///<summary>PaymentId. </summary>
		PaymentId,
		///<summary>IsPaymentConfirm. </summary>
		IsPaymentConfirm,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AfDailyLogImpressionClick.
	/// </summary>
	public enum AfDailyLogImpressionClickFieldIndex:int
	{
		///<summary>DailyLogImpressionClickId. </summary>
		DailyLogImpressionClickId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>MarketingMaterialId. </summary>
		MarketingMaterialId,
		///<summary>ImpressionCount. </summary>
		ImpressionCount,
		///<summary>ClickCount. </summary>
		ClickCount,
		///<summary>Date. </summary>
		Date,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AffiliateProfile.
	/// </summary>
	public enum AffiliateProfileFieldIndex:int
	{
		///<summary>AffiliateId. </summary>
		AffiliateId,
		///<summary>ParentAffilateId. </summary>
		ParentAffilateId,
		///<summary>AffiliateCode. </summary>
		AffiliateCode,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>LastModifiedDate. </summary>
		LastModifiedDate,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsGlobal. </summary>
		IsGlobal,
		///<summary>DefaultIncomingPhoneLine. </summary>
		DefaultIncomingPhoneLine,
		///<summary>MaxCommisionDollar. </summary>
		MaxCommisionDollar,
		///<summary>MaxParentCommisionDollar. </summary>
		MaxParentCommisionDollar,
		///<summary>PayCycle. </summary>
		PayCycle,
		///<summary>PaymentThreshold. </summary>
		PaymentThreshold,
		///<summary>PaymentAddressId. </summary>
		PaymentAddressId,
		///<summary>IsPaymentByCheck. </summary>
		IsPaymentByCheck,
		///<summary>IsDonation. </summary>
		IsDonation,
		///<summary>CheckPaypalEmail. </summary>
		CheckPaypalEmail,
		///<summary>MarketingInfo. </summary>
		MarketingInfo,
		///<summary>MaxCommisionPercentage. </summary>
		MaxCommisionPercentage,
		///<summary>MaxParentCommisionPercentage. </summary>
		MaxParentCommisionPercentage,
		///<summary>IsApproved. </summary>
		IsApproved,
		///<summary>LastPaidOn. </summary>
		LastPaidOn,
		///<summary>NextDueOn. </summary>
		NextDueOn,
		///<summary>IsExpressAffiliate. </summary>
		IsExpressAffiliate,
		///<summary>IsMonetize. </summary>
		IsMonetize,
		///<summary>CompanyName. </summary>
		CompanyName,
		///<summary>CampaignTypeAssignment. </summary>
		CampaignTypeAssignment,
		///<summary>CategoryId. </summary>
		CategoryId,
		///<summary>WebAddress. </summary>
		WebAddress,
		///<summary>OwnerOrganizationId. </summary>
		OwnerOrganizationId,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Afimpression.
	/// </summary>
	public enum AfimpressionFieldIndex:int
	{
		///<summary>ImpressionId. </summary>
		ImpressionId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>TotalImpressionMarkedForCommission. </summary>
		TotalImpressionMarkedForCommission,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AfimpressionLog.
	/// </summary>
	public enum AfimpressionLogFieldIndex:int
	{
		///<summary>ImpressionLogId. </summary>
		ImpressionLogId,
		///<summary>AffiliateCampaignMarketingMaterialId. </summary>
		AffiliateCampaignMarketingMaterialId,
		///<summary>DayStamp. </summary>
		DayStamp,
		///<summary>ImpressionCount. </summary>
		ImpressionCount,
		///<summary>ClickCount. </summary>
		ClickCount,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AfincomingPhone.
	/// </summary>
	public enum AfincomingPhoneFieldIndex:int
	{
		///<summary>IncomingPhoneId. </summary>
		IncomingPhoneId,
		///<summary>IncomingPhoneLine. </summary>
		IncomingPhoneLine,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AflAffiliatePaymentMethod.
	/// </summary>
	public enum AflAffiliatePaymentMethodFieldIndex:int
	{
		///<summary>AffiliatePaymentMethod. </summary>
		AffiliatePaymentMethod,
		///<summary>AffiliateId. </summary>
		AffiliateId,
		///<summary>StartDate. </summary>
		StartDate,
		///<summary>EndDate. </summary>
		EndDate,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>LastModifiedDate. </summary>
		LastModifiedDate,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AfmanualCheck.
	/// </summary>
	public enum AfmanualCheckFieldIndex:int
	{
		///<summary>ManualCheckId. </summary>
		ManualCheckId,
		///<summary>AffiliatePaymentMethodId. </summary>
		AffiliatePaymentMethodId,
		///<summary>PayeeName. </summary>
		PayeeName,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>LastModifiedDate. </summary>
		LastModifiedDate,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>PayeeAddressId. </summary>
		PayeeAddressId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AfmarketingMaterial.
	/// </summary>
	public enum AfmarketingMaterialFieldIndex:int
	{
		///<summary>MarketingMaterialId. </summary>
		MarketingMaterialId,
		///<summary>Title. </summary>
		Title,
		///<summary>Description. </summary>
		Description,
		///<summary>IsEventSpecific. </summary>
		IsEventSpecific,
		///<summary>MarketingMaterialTypeId. </summary>
		MarketingMaterialTypeId,
		///<summary>ImagePath. </summary>
		ImagePath,
		///<summary>Text. </summary>
		Text,
		///<summary>Htmltext. </summary>
		Htmltext,
		///<summary>CommonSizeName. </summary>
		CommonSizeName,
		///<summary>Height. </summary>
		Height,
		///<summary>Width. </summary>
		Width,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>LastModifiedDate. </summary>
		LastModifiedDate,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsInternal. </summary>
		IsInternal,
		///<summary>EventId. </summary>
		EventId,
		///<summary>HeadingText. </summary>
		HeadingText,
		///<summary>LeadingInUrl. </summary>
		LeadingInUrl,
		///<summary>DisplayUrl. </summary>
		DisplayUrl,
		///<summary>IsInbound. </summary>
		IsInbound,
		///<summary>Isdefault. </summary>
		Isdefault,
		///<summary>MarketingOfferId. </summary>
		MarketingOfferId,
		///<summary>ThumbnailImagePath. </summary>
		ThumbnailImagePath,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AfMarketingMaterialBannerSize.
	/// </summary>
	public enum AfMarketingMaterialBannerSizeFieldIndex:int
	{
		///<summary>MarketingMaterialBannerSizeId. </summary>
		MarketingMaterialBannerSizeId,
		///<summary>BannerSize. </summary>
		BannerSize,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AfmarketingMaterialGroup.
	/// </summary>
	public enum AfmarketingMaterialGroupFieldIndex:int
	{
		///<summary>MarketingMaterialGroupId. </summary>
		MarketingMaterialGroupId,
		///<summary>Title. </summary>
		Title,
		///<summary>Description. </summary>
		Description,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AfmarketingMaterialType.
	/// </summary>
	public enum AfmarketingMaterialTypeFieldIndex:int
	{
		///<summary>MarketingMaterialTypeId. </summary>
		MarketingMaterialTypeId,
		///<summary>Title. </summary>
		Title,
		///<summary>Description. </summary>
		Description,
		///<summary>Tag. </summary>
		Tag,
		///<summary>GroupId. </summary>
		GroupId,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>LastModifiedDate. </summary>
		LastModifiedDate,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Afpayment.
	/// </summary>
	public enum AfpaymentFieldIndex:int
	{
		///<summary>PaymentId. </summary>
		PaymentId,
		///<summary>AffiliateId. </summary>
		AffiliateId,
		///<summary>Amount. </summary>
		Amount,
		///<summary>PaymentDate. </summary>
		PaymentDate,
		///<summary>CommisionStartDate. </summary>
		CommisionStartDate,
		///<summary>CommisionEndDate. </summary>
		CommisionEndDate,
		///<summary>AffiliatePaymentMethod. </summary>
		AffiliatePaymentMethod,
		///<summary>PaymentMode. </summary>
		PaymentMode,
		///<summary>Notes. </summary>
		Notes,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>LastModifiedDate. </summary>
		LastModifiedDate,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>InvoiceNumber. </summary>
		InvoiceNumber,
		///<summary>CheckNumber. </summary>
		CheckNumber,
		///<summary>NameOnCheck. </summary>
		NameOnCheck,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Afpaypal.
	/// </summary>
	public enum AfpaypalFieldIndex:int
	{
		///<summary>PaypalId. </summary>
		PaypalId,
		///<summary>AffiliatePaymentMethod. </summary>
		AffiliatePaymentMethod,
		///<summary>PayPalUserName. </summary>
		PayPalUserName,
		///<summary>PaypalVerfiedAddressId. </summary>
		PaypalVerfiedAddressId,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>LastModifiedDate. </summary>
		LastModifiedDate,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AfppcclickLog.
	/// </summary>
	public enum AfppcclickLogFieldIndex:int
	{
		///<summary>PpcclickLogId. </summary>
		PpcclickLogId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>Mmid. </summary>
		Mmid,
		///<summary>TimeStamp. </summary>
		TimeStamp,
		///<summary>IpAddress. </summary>
		IpAddress,
		///<summary>Referer. </summary>
		Referer,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AfredirectUrl.
	/// </summary>
	public enum AfredirectUrlFieldIndex:int
	{
		///<summary>RedirectUrlId. </summary>
		RedirectUrlId,
		///<summary>CampaignMmid. </summary>
		CampaignMmid,
		///<summary>RedirectUrl. </summary>
		RedirectUrl,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>LastModifiedDate. </summary>
		LastModifiedDate,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ApplicationAuthentication.
	/// </summary>
	public enum ApplicationAuthenticationFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>ApplicationName. </summary>
		ApplicationName,
		///<summary>ApplicationId. </summary>
		ApplicationId,
		///<summary>Token. </summary>
		Token,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Barrier.
	/// </summary>
	public enum BarrierFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Name. </summary>
		Name,
		///<summary>Alias. </summary>
		Alias,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: BillingAccount.
	/// </summary>
	public enum BillingAccountFieldIndex:int
	{
		///<summary>BillingAccountId. </summary>
		BillingAccountId,
		///<summary>Name. </summary>
		Name,
		///<summary>CustomerKey. </summary>
		CustomerKey,
		///<summary>UserName. </summary>
		UserName,
		///<summary>Password. </summary>
		Password,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: BillingAccountTest.
	/// </summary>
	public enum BillingAccountTestFieldIndex:int
	{
		///<summary>BillingAccountId. </summary>
		BillingAccountId,
		///<summary>TestId. </summary>
		TestId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: BlockedDays.
	/// </summary>
	public enum BlockedDaysFieldIndex:int
	{
		///<summary>BlockedDayId. </summary>
		BlockedDayId,
		///<summary>BlockedDay. </summary>
		BlockedDay,
		///<summary>BlockedReason. </summary>
		BlockedReason,
		///<summary>IsGlobal. </summary>
		IsGlobal,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: BlockedDaysFranchisee.
	/// </summary>
	public enum BlockedDaysFranchiseeFieldIndex:int
	{
		///<summary>BlockedDayFranchiseeId. </summary>
		BlockedDayFranchiseeId,
		///<summary>BlockedDaysId. </summary>
		BlockedDaysId,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>OrganizationId. </summary>
		OrganizationId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CallCenterAgentTeam.
	/// </summary>
	public enum CallCenterAgentTeamFieldIndex:int
	{
		///<summary>TeamId. </summary>
		TeamId,
		///<summary>AgentId. </summary>
		AgentId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CallCenterAgentTeamLog.
	/// </summary>
	public enum CallCenterAgentTeamLogFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>TeamId. </summary>
		TeamId,
		///<summary>AgentId. </summary>
		AgentId,
		///<summary>DateAssigned. </summary>
		DateAssigned,
		///<summary>DateRemoved. </summary>
		DateRemoved,
		///<summary>AssignedByOrgRoleUserId. </summary>
		AssignedByOrgRoleUserId,
		///<summary>RemovedByOrgRoleUserId. </summary>
		RemovedByOrgRoleUserId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CallCenterNotes.
	/// </summary>
	public enum CallCenterNotesFieldIndex:int
	{
		///<summary>CallCenterNotesId. </summary>
		CallCenterNotesId,
		///<summary>CallId. </summary>
		CallId,
		///<summary>Notes. </summary>
		Notes,
		///<summary>NotesSequence. </summary>
		NotesSequence,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CallCenterRepProfile.
	/// </summary>
	public enum CallCenterRepProfileFieldIndex:int
	{
		///<summary>CallCenterRepId. </summary>
		CallCenterRepId,
		///<summary>CanRefund. </summary>
		CanRefund,
		///<summary>CanChangeNotes. </summary>
		CanChangeNotes,
		///<summary>DialerUrl. </summary>
		DialerUrl,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CallCenterTeam.
	/// </summary>
	public enum CallCenterTeamFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>TypeId. </summary>
		TypeId,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CallDetails.
	/// </summary>
	public enum CallDetailsFieldIndex:int
	{
		///<summary>CallDetailsId. </summary>
		CallDetailsId,
		///<summary>CalledUserId. </summary>
		CalledUserId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DareModified. </summary>
		DareModified,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CallQueue.
	/// </summary>
	public enum CallQueueFieldIndex:int
	{
		///<summary>CallQueueId. </summary>
		CallQueueId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>Attempts. </summary>
		Attempts,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>ModifiedByOrgRoleUserId. </summary>
		ModifiedByOrgRoleUserId,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsQueueGenerated. </summary>
		IsQueueGenerated,
		///<summary>QueueGenerationInterval. </summary>
		QueueGenerationInterval,
		///<summary>LastQueueGeneratedDate. </summary>
		LastQueueGeneratedDate,
		///<summary>ScriptId. </summary>
		ScriptId,
		///<summary>IsManual. </summary>
		IsManual,
		///<summary>Category. </summary>
		Category,
		///<summary>IsHealthPlan. </summary>
		IsHealthPlan,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CallQueueAssignment.
	/// </summary>
	public enum CallQueueAssignmentFieldIndex:int
	{
		///<summary>CallQueueId. </summary>
		CallQueueId,
		///<summary>AssignedOrgRoleUserId. </summary>
		AssignedOrgRoleUserId,
		///<summary>Percentage. </summary>
		Percentage,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CallQueueCriteria.
	/// </summary>
	public enum CallQueueCriteriaFieldIndex:int
	{
		///<summary>CallQueueCriteriaId. </summary>
		CallQueueCriteriaId,
		///<summary>CallQueueId. </summary>
		CallQueueId,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		///<summary>Zipcode. </summary>
		Zipcode,
		///<summary>Radius. </summary>
		Radius,
		///<summary>Condition. </summary>
		Condition,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>Sequence. </summary>
		Sequence,
		///<summary>CallReason. </summary>
		CallReason,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CallQueueCustomer.
	/// </summary>
	public enum CallQueueCustomerFieldIndex:int
	{
		///<summary>CallQueueCustomerId. </summary>
		CallQueueCustomerId,
		///<summary>CallQueueId. </summary>
		CallQueueId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>ProspectCustomerId. </summary>
		ProspectCustomerId,
		///<summary>Status. </summary>
		Status,
		///<summary>Attempts. </summary>
		Attempts,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>NotesId. </summary>
		NotesId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>ModifiedByOrgRoleUserId. </summary>
		ModifiedByOrgRoleUserId,
		///<summary>AssignedToOrgRoleUserId. </summary>
		AssignedToOrgRoleUserId,
		///<summary>CallQueueCriteriaId. </summary>
		CallQueueCriteriaId,
		///<summary>CallDate. </summary>
		CallDate,
		///<summary>EventId. </summary>
		EventId,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>LastUpdatedOn. </summary>
		LastUpdatedOn,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>MiddleName. </summary>
		MiddleName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>PhoneOffice. </summary>
		PhoneOffice,
		///<summary>PhoneCell. </summary>
		PhoneCell,
		///<summary>PhoneHome. </summary>
		PhoneHome,
		///<summary>ZipId. </summary>
		ZipId,
		///<summary>ZipCode. </summary>
		ZipCode,
		///<summary>Tag. </summary>
		Tag,
		///<summary>IsEligble. </summary>
		IsEligble,
		///<summary>IsIncorrectPhoneNumber. </summary>
		IsIncorrectPhoneNumber,
		///<summary>IsLanguageBarrier. </summary>
		IsLanguageBarrier,
		///<summary>ActivityId. </summary>
		ActivityId,
		///<summary>DoNotContactTypeId. </summary>
		DoNotContactTypeId,
		///<summary>DoNotContactReasonId. </summary>
		DoNotContactReasonId,
		///<summary>DoNotContactUpdateDate. </summary>
		DoNotContactUpdateDate,
		///<summary>CallCount. </summary>
		CallCount,
		///<summary>AppointmentDate. </summary>
		AppointmentDate,
		///<summary>CallStatus. </summary>
		CallStatus,
		///<summary>ContactedDate. </summary>
		ContactedDate,
		///<summary>Disposition. </summary>
		Disposition,
		///<summary>CallBackRequestedDate. </summary>
		CallBackRequestedDate,
		///<summary>AppointmentCancellationDate. </summary>
		AppointmentCancellationDate,
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>AppointmentDateTimeWithTimeZone. </summary>
		AppointmentDateTimeWithTimeZone,
		///<summary>DoNotContactUpdateSource. </summary>
		DoNotContactUpdateSource,
		///<summary>IncorrectPhoneNumberMarkedDate. </summary>
		IncorrectPhoneNumberMarkedDate,
		///<summary>LanguageBarrierMarkedDate. </summary>
		LanguageBarrierMarkedDate,
		///<summary>LanguageId. </summary>
		LanguageId,
		///<summary>NoShowDate. </summary>
		NoShowDate,
		///<summary>TargetedYear. </summary>
		TargetedYear,
		///<summary>IsTargeted. </summary>
		IsTargeted,
		///<summary>ProductTypeId. </summary>
		ProductTypeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CallQueueCustomerCall.
	/// </summary>
	public enum CallQueueCustomerCallFieldIndex:int
	{
		///<summary>CallQueueCustomerId. </summary>
		CallQueueCustomerId,
		///<summary>CallId. </summary>
		CallId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CallQueueCustomerLock.
	/// </summary>
	public enum CallQueueCustomerLockFieldIndex:int
	{
		///<summary>CallQueueCustomerId. </summary>
		CallQueueCustomerId,
		///<summary>ProspectCustomerId. </summary>
		ProspectCustomerId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CallQueueCustomTag.
	/// </summary>
	public enum CallQueueCustomTagFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CustomTag. </summary>
		CustomTag,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CallRoundCallQueue.
	/// </summary>
	public enum CallRoundCallQueueFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Status. </summary>
		Status,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CallDate. </summary>
		CallDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CallRoundCallQueueCriteriaAssignment.
	/// </summary>
	public enum CallRoundCallQueueCriteriaAssignmentFieldIndex:int
	{
		///<summary>CallRoundCallQueueId. </summary>
		CallRoundCallQueueId,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Calls.
	/// </summary>
	public enum CallsFieldIndex:int
	{
		///<summary>CallId. </summary>
		CallId,
		///<summary>IsNewCustomer. </summary>
		IsNewCustomer,
		///<summary>CalledCustomerId. </summary>
		CalledCustomerId,
		///<summary>TimeCreated. </summary>
		TimeCreated,
		///<summary>TimeEnd. </summary>
		TimeEnd,
		///<summary>CallStatus. </summary>
		CallStatus,
		///<summary>EventId. </summary>
		EventId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CallBackNumber. </summary>
		CallBackNumber,
		///<summary>IncomingPhoneLine. </summary>
		IncomingPhoneLine,
		///<summary>CallersPhoneNumber. </summary>
		CallersPhoneNumber,
		///<summary>CallerName. </summary>
		CallerName,
		///<summary>PromoCodeId. </summary>
		PromoCodeId,
		///<summary>AffiliateId. </summary>
		AffiliateId,
		///<summary>OutBound. </summary>
		OutBound,
		///<summary>Status. </summary>
		Status,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>Disposition. </summary>
		Disposition,
		///<summary>ReadAndUnderstoodNotes. </summary>
		ReadAndUnderstoodNotes,
		///<summary>IsUploaded. </summary>
		IsUploaded,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>NotInterestedReasonId. </summary>
		NotInterestedReasonId,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CallQueueId. </summary>
		CallQueueId,
		///<summary>CustomTags. </summary>
		CustomTags,
		///<summary>IsContacted. </summary>
		IsContacted,
		///<summary>DialerType. </summary>
		DialerType,
		///<summary>InvalidNumberCount. </summary>
		InvalidNumberCount,
		///<summary>ProductTypeId. </summary>
		ProductTypeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CallUpload.
	/// </summary>
	public enum CallUploadFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>FileId. </summary>
		FileId,
		///<summary>StatusId. </summary>
		StatusId,
		///<summary>SuccessfullUploadCount. </summary>
		SuccessfullUploadCount,
		///<summary>FailedUploadCount. </summary>
		FailedUploadCount,
		///<summary>UploadTime. </summary>
		UploadTime,
		///<summary>UploadedBy. </summary>
		UploadedBy,
		///<summary>ParseStartTime. </summary>
		ParseStartTime,
		///<summary>ParseEndTime. </summary>
		ParseEndTime,
		///<summary>LogFileId. </summary>
		LogFileId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CallUploadLog.
	/// </summary>
	public enum CallUploadLogFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CallUploadId. </summary>
		CallUploadId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>OutreachType. </summary>
		OutreachType,
		///<summary>OutreachDateTime. </summary>
		OutreachDateTime,
		///<summary>Outcome. </summary>
		Outcome,
		///<summary>Disposition. </summary>
		Disposition,
		///<summary>EventId. </summary>
		EventId,
		///<summary>Email. </summary>
		Email,
		///<summary>UserName. </summary>
		UserName,
		///<summary>Notes. </summary>
		Notes,
		///<summary>IsSuccessFull. </summary>
		IsSuccessFull,
		///<summary>ErrorMessage. </summary>
		ErrorMessage,
		///<summary>IsRuleApplied. </summary>
		IsRuleApplied,
		///<summary>Reason. </summary>
		Reason,
		///<summary>CampaignName. </summary>
		CampaignName,
		///<summary>DirectMailType. </summary>
		DirectMailType,
		///<summary>IsInvalidAddress. </summary>
		IsInvalidAddress,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Campaign.
	/// </summary>
	public enum CampaignFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Name. </summary>
		Name,
		///<summary>CampaignCode. </summary>
		CampaignCode,
		///<summary>StartDate. </summary>
		StartDate,
		///<summary>EndDate. </summary>
		EndDate,
		///<summary>TypeId. </summary>
		TypeId,
		///<summary>ModeId. </summary>
		ModeId,
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>CustomTags. </summary>
		CustomTags,
		///<summary>Description. </summary>
		Description,
		///<summary>IsPublished. </summary>
		IsPublished,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>Createdby. </summary>
		Createdby,
		///<summary>ModifiedOn. </summary>
		ModifiedOn,
		///<summary>Modifiedby. </summary>
		Modifiedby,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CampaignActivity.
	/// </summary>
	public enum CampaignActivityFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>ActivityDate. </summary>
		ActivityDate,
		///<summary>TypeId. </summary>
		TypeId,
		///<summary>Sequence. </summary>
		Sequence,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>Createdby. </summary>
		Createdby,
		///<summary>ModifiedOn. </summary>
		ModifiedOn,
		///<summary>Modifiedby. </summary>
		Modifiedby,
		///<summary>DirectMailTypeId. </summary>
		DirectMailTypeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CampaignActivityAssignment.
	/// </summary>
	public enum CampaignActivityAssignmentFieldIndex:int
	{
		///<summary>CampaignActivityId. </summary>
		CampaignActivityId,
		///<summary>AssignedToOrgRoleUserId. </summary>
		AssignedToOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CampaignAssignment.
	/// </summary>
	public enum CampaignAssignmentFieldIndex:int
	{
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>AssignedToOrgRoleUserId. </summary>
		AssignedToOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CampaignTag.
	/// </summary>
	public enum CampaignTagFieldIndex:int
	{
		///<summary>CampaignTagId. </summary>
		CampaignTagId,
		///<summary>Namespace. </summary>
		Namespace,
		///<summary>Tag. </summary>
		Tag,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>ModifiedDate. </summary>
		ModifiedDate,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CampaignTagMapping.
	/// </summary>
	public enum CampaignTagMappingFieldIndex:int
	{
		///<summary>CampaignTagId. </summary>
		CampaignTagId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>CampaignTagMappingId. </summary>
		CampaignTagMappingId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CareCodingOutbound.
	/// </summary>
	public enum CareCodingOutboundFieldIndex:int
	{
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>TenantId. </summary>
		TenantId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>IndividualId. </summary>
		IndividualId,
		///<summary>ClientId. </summary>
		ClientId,
		///<summary>ContractNumber. </summary>
		ContractNumber,
		///<summary>ContractPersonNumber. </summary>
		ContractPersonNumber,
		///<summary>ConsumerId. </summary>
		ConsumerId,
		///<summary>CampaignCode. </summary>
		CampaignCode,
		///<summary>CampaignMemberId. </summary>
		CampaignMemberId,
		///<summary>CareCodeLabType. </summary>
		CareCodeLabType,
		///<summary>CareCodeLabDescription. </summary>
		CareCodeLabDescription,
		///<summary>StatusOfCoding. </summary>
		StatusOfCoding,
		///<summary>MedicalCode. </summary>
		MedicalCode,
		///<summary>MedicalCodeType. </summary>
		MedicalCodeType,
		///<summary>MedicalCodeServiceDate. </summary>
		MedicalCodeServiceDate,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateUpdated. </summary>
		DateUpdated,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Carrier.
	/// </summary>
	public enum CarrierFieldIndex:int
	{
		///<summary>CarrierId. </summary>
		CarrierId,
		///<summary>Carrier. </summary>
		Carrier,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CashPayment.
	/// </summary>
	public enum CashPaymentFieldIndex:int
	{
		///<summary>CashPaymentId. </summary>
		CashPaymentId,
		///<summary>PaymentId. </summary>
		PaymentId,
		///<summary>Amount. </summary>
		Amount,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Categories.
	/// </summary>
	public enum CategoriesFieldIndex:int
	{
		///<summary>CategoryId. </summary>
		CategoryId,
		///<summary>CategoryName. </summary>
		CategoryName,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CdcontentGeneratorTracking.
	/// </summary>
	public enum CdcontentGeneratorTrackingFieldIndex:int
	{
		///<summary>CdcontentGeneratorTrackingId. </summary>
		CdcontentGeneratorTrackingId,
		///<summary>EventCustomerResultId. </summary>
		EventCustomerResultId,
		///<summary>IsContentGenerated. </summary>
		IsContentGenerated,
		///<summary>IsContentDownloaded. </summary>
		IsContentDownloaded,
		///<summary>DownloadedByOrgRoleUserId. </summary>
		DownloadedByOrgRoleUserId,
		///<summary>DownloadedDate. </summary>
		DownloadedDate,
		///<summary>ContentGeneratedDate. </summary>
		ContentGeneratedDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ChaperoneAnswer.
	/// </summary>
	public enum ChaperoneAnswerFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>QuestionId. </summary>
		QuestionId,
		///<summary>Answer. </summary>
		Answer,
		///<summary>Version. </summary>
		Version,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ChaperoneQuestion.
	/// </summary>
	public enum ChaperoneQuestionFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Question. </summary>
		Question,
		///<summary>TypeId. </summary>
		TypeId,
		///<summary>Gender. </summary>
		Gender,
		///<summary>ParentId. </summary>
		ParentId,
		///<summary>ControlValues. </summary>
		ControlValues,
		///<summary>ControlValueDelimiter. </summary>
		ControlValueDelimiter,
		///<summary>Index. </summary>
		Index,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ChaperoneSignature.
	/// </summary>
	public enum ChaperoneSignatureFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>SignatureFileId. </summary>
		SignatureFileId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>Version. </summary>
		Version,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>StaffSignatureFileId. </summary>
		StaffSignatureFileId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ChargeCard.
	/// </summary>
	public enum ChargeCardFieldIndex:int
	{
		///<summary>ChargeCardId. </summary>
		ChargeCardId,
		///<summary>NameOnCard. </summary>
		NameOnCard,
		///<summary>Number. </summary>
		Number,
		///<summary>TypeId. </summary>
		TypeId,
		///<summary>ExpirationDate. </summary>
		ExpirationDate,
		///<summary>Cvv. </summary>
		Cvv,
		///<summary>CardIssuer. </summary>
		CardIssuer,
		///<summary>IsDebitCard. </summary>
		IsDebitCard,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>OrganizationRoleUserCreatorId. </summary>
		OrganizationRoleUserCreatorId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ChargeCardPayment.
	/// </summary>
	public enum ChargeCardPaymentFieldIndex:int
	{
		///<summary>ChargeCardPaymentId. </summary>
		ChargeCardPaymentId,
		///<summary>PaymentId. </summary>
		PaymentId,
		///<summary>ChargeCardId. </summary>
		ChargeCardId,
		///<summary>Amount. </summary>
		Amount,
		///<summary>ProcessorResponse. </summary>
		ProcessorResponse,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>OrganizationRoleUserCreatorId. </summary>
		OrganizationRoleUserCreatorId,
		///<summary>Status. </summary>
		Status,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ChaseCampaign.
	/// </summary>
	public enum ChaseCampaignFieldIndex:int
	{
		///<summary>ChaseCampaignId. </summary>
		ChaseCampaignId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>CampaignFileId. </summary>
		CampaignFileId,
		///<summary>CampaignName. </summary>
		CampaignName,
		///<summary>CampaignCode. </summary>
		CampaignCode,
		///<summary>CampaignHouseholdId. </summary>
		CampaignHouseholdId,
		///<summary>ChaseCampaignTypeId. </summary>
		ChaseCampaignTypeId,
		///<summary>KeyCode. </summary>
		KeyCode,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ChaseCampaignType.
	/// </summary>
	public enum ChaseCampaignTypeFieldIndex:int
	{
		///<summary>ChaseCampaignTypeId. </summary>
		ChaseCampaignTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>Alias. </summary>
		Alias,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ChaseChannelLevel.
	/// </summary>
	public enum ChaseChannelLevelFieldIndex:int
	{
		///<summary>ChaseChannelLevelId. </summary>
		ChaseChannelLevelId,
		///<summary>ChannelName. </summary>
		ChannelName,
		///<summary>ChannelLevel. </summary>
		ChannelLevel,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ChaseGroup.
	/// </summary>
	public enum ChaseGroupFieldIndex:int
	{
		///<summary>ChaseGroupId. </summary>
		ChaseGroupId,
		///<summary>Name. </summary>
		Name,
		///<summary>Number. </summary>
		Number,
		///<summary>Division. </summary>
		Division,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ChaseOutbound.
	/// </summary>
	public enum ChaseOutboundFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>TenantId. </summary>
		TenantId,
		///<summary>IndividualId. </summary>
		IndividualId,
		///<summary>ClientId. </summary>
		ClientId,
		///<summary>VendorCd. </summary>
		VendorCd,
		///<summary>ContractNumber. </summary>
		ContractNumber,
		///<summary>ContractPersonNumber. </summary>
		ContractPersonNumber,
		///<summary>ConsumerId. </summary>
		ConsumerId,
		///<summary>CampaignMemberId. </summary>
		CampaignMemberId,
		///<summary>DistributionId. </summary>
		DistributionId,
		///<summary>SubscriberIndicator. </summary>
		SubscriberIndicator,
		///<summary>RelationshipId. </summary>
		RelationshipId,
		///<summary>IdentifiedIndicator. </summary>
		IdentifiedIndicator,
		///<summary>OutboundCallIndicator. </summary>
		OutboundCallIndicator,
		///<summary>WirelessIndicator. </summary>
		WirelessIndicator,
		///<summary>PriorityCode. </summary>
		PriorityCode,
		///<summary>BusinessCaseId. </summary>
		BusinessCaseId,
		///<summary>MedicareIndicator. </summary>
		MedicareIndicator,
		///<summary>ChaseGroupId. </summary>
		ChaseGroupId,
		///<summary>HmoLobIndicator. </summary>
		HmoLobIndicator,
		///<summary>ReferMemberTo. </summary>
		ReferMemberTo,
		///<summary>ClosestRetailCenter. </summary>
		ClosestRetailCenter,
		///<summary>ConfidenceScoreId. </summary>
		ConfidenceScoreId,
		///<summary>LocationCode. </summary>
		LocationCode,
		///<summary>ForecastedOutreachDate. </summary>
		ForecastedOutreachDate,
		///<summary>RecordProcessDate. </summary>
		RecordProcessDate,
		///<summary>AgentContextNameValueSet. </summary>
		AgentContextNameValueSet,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>EndDate. </summary>
		EndDate,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ChaseProduct.
	/// </summary>
	public enum ChaseProductFieldIndex:int
	{
		///<summary>ChaseProductId. </summary>
		ChaseProductId,
		///<summary>Name. </summary>
		Name,
		///<summary>ProductLevel. </summary>
		ProductLevel,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Check.
	/// </summary>
	public enum CheckFieldIndex:int
	{
		///<summary>CheckId. </summary>
		CheckId,
		///<summary>PayableTo. </summary>
		PayableTo,
		///<summary>Amount. </summary>
		Amount,
		///<summary>CheckNumber. </summary>
		CheckNumber,
		///<summary>RoutingNumber. </summary>
		RoutingNumber,
		///<summary>BankName. </summary>
		BankName,
		///<summary>Memo. </summary>
		Memo,
		///<summary>AccountNumber. </summary>
		AccountNumber,
		///<summary>CheckDate. </summary>
		CheckDate,
		///<summary>DataRecoderCreatorId. </summary>
		DataRecoderCreatorId,
		///<summary>DataRecoderModifierId. </summary>
		DataRecoderModifierId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsElectronic. </summary>
		IsElectronic,
		///<summary>AccountHolderName. </summary>
		AccountHolderName,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CheckListAnswer.
	/// </summary>
	public enum CheckListAnswerFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>QuestionId. </summary>
		QuestionId,
		///<summary>Answer. </summary>
		Answer,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>Version. </summary>
		Version,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>ModifiedOn. </summary>
		ModifiedOn,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>Type. </summary>
		Type,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CheckListGroup.
	/// </summary>
	public enum CheckListGroupFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>TypeId. </summary>
		TypeId,
		///<summary>ParentId. </summary>
		ParentId,
		///<summary>Alias. </summary>
		Alias,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ChecklistGroupQuestion.
	/// </summary>
	public enum ChecklistGroupQuestionFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>GroupId. </summary>
		GroupId,
		///<summary>QuestionId. </summary>
		QuestionId,
		///<summary>ParentId. </summary>
		ParentId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CheckListQuestion.
	/// </summary>
	public enum CheckListQuestionFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Question. </summary>
		Question,
		///<summary>TypeId. </summary>
		TypeId,
		///<summary>Gender. </summary>
		Gender,
		///<summary>ControlValues. </summary>
		ControlValues,
		///<summary>ControlValueDelimiter. </summary>
		ControlValueDelimiter,
		///<summary>Index. </summary>
		Index,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CheckListTemplate.
	/// </summary>
	public enum CheckListTemplateFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Name. </summary>
		Name,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsPublished. </summary>
		IsPublished,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>IsDefault. </summary>
		IsDefault,
		///<summary>Type. </summary>
		Type,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CheckListTemplateQuestion.
	/// </summary>
	public enum CheckListTemplateQuestionFieldIndex:int
	{
		///<summary>TemplateId. </summary>
		TemplateId,
		///<summary>QuestionId. </summary>
		QuestionId,
		///<summary>GroupQuestionId. </summary>
		GroupQuestionId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CheckPayment.
	/// </summary>
	public enum CheckPaymentFieldIndex:int
	{
		///<summary>PaymentId. </summary>
		PaymentId,
		///<summary>CheckId. </summary>
		CheckId,
		///<summary>Status. </summary>
		Status,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: City.
	/// </summary>
	public enum CityFieldIndex:int
	{
		///<summary>CityId. </summary>
		CityId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>StateId. </summary>
		StateId,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CityCode. </summary>
		CityCode,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Claim.
	/// </summary>
	public enum ClaimFieldIndex:int
	{
		///<summary>ClaimId. </summary>
		ClaimId,
		///<summary>EncounterId. </summary>
		EncounterId,
		///<summary>InsurancePaymentId. </summary>
		InsurancePaymentId,
		///<summary>BillingPatientId. </summary>
		BillingPatientId,
		///<summary>ProcedureCode. </summary>
		ProcedureCode,
		///<summary>ProcedureName. </summary>
		ProcedureName,
		///<summary>Units. </summary>
		Units,
		///<summary>UnitCharge. </summary>
		UnitCharge,
		///<summary>TotalCharges. </summary>
		TotalCharges,
		///<summary>AdjustedCharges. </summary>
		AdjustedCharges,
		///<summary>Receipts. </summary>
		Receipts,
		///<summary>PatientBalance. </summary>
		PatientBalance,
		///<summary>InsuranceBalance. </summary>
		InsuranceBalance,
		///<summary>TotalBalance. </summary>
		TotalBalance,
		///<summary>Status. </summary>
		Status,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>FirstBillDate. </summary>
		FirstBillDate,
		///<summary>LastBillDate. </summary>
		LastBillDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ClickConversion.
	/// </summary>
	public enum ClickConversionFieldIndex:int
	{
		///<summary>ClickConversionId. </summary>
		ClickConversionId,
		///<summary>ClickId. </summary>
		ClickId,
		///<summary>ProspectCustomerId. </summary>
		ProspectCustomerId,
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>CustomerId. </summary>
		CustomerId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ClickKeyword.
	/// </summary>
	public enum ClickKeywordFieldIndex:int
	{
		///<summary>KeywordClickId. </summary>
		KeywordClickId,
		///<summary>ClickId. </summary>
		ClickId,
		///<summary>Keyword. </summary>
		Keyword,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ClickLog.
	/// </summary>
	public enum ClickLogFieldIndex:int
	{
		///<summary>ClickId. </summary>
		ClickId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>MarketingMaterialId. </summary>
		MarketingMaterialId,
		///<summary>Timestamp. </summary>
		Timestamp,
		///<summary>IpAddress. </summary>
		IpAddress,
		///<summary>PriorReferrer. </summary>
		PriorReferrer,
		///<summary>Referrer. </summary>
		Referrer,
		///<summary>BrowserClient. </summary>
		BrowserClient,
		///<summary>ResolutionWidth. </summary>
		ResolutionWidth,
		///<summary>ResolutionHeight. </summary>
		ResolutionHeight,
		///<summary>Cookie. </summary>
		Cookie,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Client.
	/// </summary>
	public enum ClientFieldIndex:int
	{
		///<summary>ClientId. </summary>
		ClientId,
		///<summary>ClientIp. </summary>
		ClientIp,
		///<summary>ClientAction. </summary>
		ClientAction,
		///<summary>Attempts. </summary>
		Attempts,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>UpdatedOn. </summary>
		UpdatedOn,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ClinicalTestQualificationCriteria.
	/// </summary>
	public enum ClinicalTestQualificationCriteriaFieldIndex:int
	{
		///<summary>TemplateId. </summary>
		TemplateId,
		///<summary>TestId. </summary>
		TestId,
		///<summary>Gender. </summary>
		Gender,
		///<summary>NumberOfQuestion. </summary>
		NumberOfQuestion,
		///<summary>Answer. </summary>
		Answer,
		///<summary>OnMedication. </summary>
		OnMedication,
		///<summary>MedicationQuestionId. </summary>
		MedicationQuestionId,
		///<summary>AgeMin. </summary>
		AgeMin,
		///<summary>AgeMax. </summary>
		AgeMax,
		///<summary>AgeCondition. </summary>
		AgeCondition,
		///<summary>IsPublished. </summary>
		IsPublished,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>ModifiedOn. </summary>
		ModifiedOn,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>DisqualifierQuestionId. </summary>
		DisqualifierQuestionId,
		///<summary>DisqualifierQuestionAnswer. </summary>
		DisqualifierQuestionAnswer,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CommunicationMode.
	/// </summary>
	public enum CommunicationModeFieldIndex:int
	{
		///<summary>CommunicationModeId. </summary>
		CommunicationModeId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ContactCall.
	/// </summary>
	public enum ContactCallFieldIndex:int
	{
		///<summary>ContactCallId. </summary>
		ContactCallId,
		///<summary>Subject. </summary>
		Subject,
		///<summary>Notes. </summary>
		Notes,
		///<summary>ContactCallStatusId. </summary>
		ContactCallStatusId,
		///<summary>IsInbound. </summary>
		IsInbound,
		///<summary>StartDate. </summary>
		StartDate,
		///<summary>Starttime. </summary>
		Starttime,
		///<summary>Duration. </summary>
		Duration,
		///<summary>Reminder. </summary>
		Reminder,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>CallResult. </summary>
		CallResult,
		///<summary>FutureAction. </summary>
		FutureAction,
		///<summary>CreatedByRoleId. </summary>
		CreatedByRoleId,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ContactCallStatus.
	/// </summary>
	public enum ContactCallStatusFieldIndex:int
	{
		///<summary>ContactCallStatusId. </summary>
		ContactCallStatusId,
		///<summary>Status. </summary>
		Status,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ContactFranchiseeAccess.
	/// </summary>
	public enum ContactFranchiseeAccessFieldIndex:int
	{
		///<summary>ContactAccessId. </summary>
		ContactAccessId,
		///<summary>AccessId. </summary>
		AccessId,
		///<summary>ContactId. </summary>
		ContactId,
		///<summary>IsSecured. </summary>
		IsSecured,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>OrganizationId. </summary>
		OrganizationId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ContactMeeting.
	/// </summary>
	public enum ContactMeetingFieldIndex:int
	{
		///<summary>ContactMeetingId. </summary>
		ContactMeetingId,
		///<summary>Subject. </summary>
		Subject,
		///<summary>Description. </summary>
		Description,
		///<summary>ContactMeetingStatusId. </summary>
		ContactMeetingStatusId,
		///<summary>MeetingVenue. </summary>
		MeetingVenue,
		///<summary>StartDate. </summary>
		StartDate,
		///<summary>Starttime. </summary>
		Starttime,
		///<summary>Duration. </summary>
		Duration,
		///<summary>Reminder. </summary>
		Reminder,
		///<summary>ReminderHoursBefore. </summary>
		ReminderHoursBefore,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>FollowUpDate. </summary>
		FollowUpDate,
		///<summary>MeetingType. </summary>
		MeetingType,
		///<summary>CreatedByRoleId. </summary>
		CreatedByRoleId,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ContactNotes.
	/// </summary>
	public enum ContactNotesFieldIndex:int
	{
		///<summary>ContactNotesId. </summary>
		ContactNotesId,
		///<summary>ContactId. </summary>
		ContactId,
		///<summary>Notes. </summary>
		Notes,
		///<summary>NotesSequence. </summary>
		NotesSequence,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Contacts.
	/// </summary>
	public enum ContactsFieldIndex:int
	{
		///<summary>ContactId. </summary>
		ContactId,
		///<summary>Salutation. </summary>
		Salutation,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>MiddleName. </summary>
		MiddleName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>PhoneHome. </summary>
		PhoneHome,
		///<summary>PhoneCell. </summary>
		PhoneCell,
		///<summary>PhoneOffice. </summary>
		PhoneOffice,
		///<summary>PhoneOfficeExtension. </summary>
		PhoneOfficeExtension,
		///<summary>Fax. </summary>
		Fax,
		///<summary>Email. </summary>
		Email,
		///<summary>Addedby. </summary>
		Addedby,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsPrimary. </summary>
		IsPrimary,
		///<summary>Title. </summary>
		Title,
		///<summary>Gender. </summary>
		Gender,
		///<summary>Website. </summary>
		Website,
		///<summary>Organisation. </summary>
		Organisation,
		///<summary>Status. </summary>
		Status,
		///<summary>AddedRoleId. </summary>
		AddedRoleId,
		///<summary>ModifiedRoleId. </summary>
		ModifiedRoleId,
		///<summary>ContactTypeId. </summary>
		ContactTypeId,
		///<summary>Address1. </summary>
		Address1,
		///<summary>Address2. </summary>
		Address2,
		///<summary>City. </summary>
		City,
		///<summary>State. </summary>
		State,
		///<summary>Country. </summary>
		Country,
		///<summary>ZipCode. </summary>
		ZipCode,
		///<summary>EmailOffice. </summary>
		EmailOffice,
		///<summary>DateOfBirth. </summary>
		DateOfBirth,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>EmployeeId. </summary>
		EmployeeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ContactType.
	/// </summary>
	public enum ContactTypeFieldIndex:int
	{
		///<summary>ContactTypeId. </summary>
		ContactTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Content.
	/// </summary>
	public enum ContentFieldIndex:int
	{
		///<summary>ContentId. </summary>
		ContentId,
		///<summary>Title. </summary>
		Title,
		///<summary>Summary. </summary>
		Summary,
		///<summary>Content. </summary>
		Content,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Contract.
	/// </summary>
	public enum ContractFieldIndex:int
	{
		///<summary>ContractId. </summary>
		ContractId,
		///<summary>ContractName. </summary>
		ContractName,
		///<summary>StateId. </summary>
		StateId,
		///<summary>Description. </summary>
		Description,
		///<summary>Contract. </summary>
		Contract,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>StartDate. </summary>
		StartDate,
		///<summary>EndDate. </summary>
		EndDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CorporateShippingOption.
	/// </summary>
	public enum CorporateShippingOptionFieldIndex:int
	{
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>ShippingOptionId. </summary>
		ShippingOptionId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CorporateTag.
	/// </summary>
	public enum CorporateTagFieldIndex:int
	{
		///<summary>CorporateTagId. </summary>
		CorporateTagId,
		///<summary>CorporateId. </summary>
		CorporateId,
		///<summary>Tag. </summary>
		Tag,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>ModifiedOn. </summary>
		ModifiedOn,
		///<summary>IsDisabled. </summary>
		IsDisabled,
		///<summary>StartDate. </summary>
		StartDate,
		///<summary>EndDate. </summary>
		EndDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CorporateUpload.
	/// </summary>
	public enum CorporateUploadFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>FileId. </summary>
		FileId,
		///<summary>SuccessfullUploadCount. </summary>
		SuccessfullUploadCount,
		///<summary>FailedUploadCount. </summary>
		FailedUploadCount,
		///<summary>UploadTime. </summary>
		UploadTime,
		///<summary>UploadedBy. </summary>
		UploadedBy,
		///<summary>LogFileId. </summary>
		LogFileId,
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>AdjustOrderLogFileId. </summary>
		AdjustOrderLogFileId,
		///<summary>SourceId. </summary>
		SourceId,
		///<summary>ParseStatus. </summary>
		ParseStatus,
		///<summary>IsTermByAbsence. </summary>
		IsTermByAbsence,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Country.
	/// </summary>
	public enum CountryFieldIndex:int
	{
		///<summary>CountryId. </summary>
		CountryId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CountryCode. </summary>
		CountryCode,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Coupons.
	/// </summary>
	public enum CouponsFieldIndex:int
	{
		///<summary>CouponId. </summary>
		CouponId,
		///<summary>CouponTypeId. </summary>
		CouponTypeId,
		///<summary>IsPercentage. </summary>
		IsPercentage,
		///<summary>CouponValue. </summary>
		CouponValue,
		///<summary>CouponDescription. </summary>
		CouponDescription,
		///<summary>MinimumPurchaseAmount. </summary>
		MinimumPurchaseAmount,
		///<summary>ValidityStartDate. </summary>
		ValidityStartDate,
		///<summary>ValidityEndDate. </summary>
		ValidityEndDate,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>MaximumNumberTimesUsed. </summary>
		MaximumNumberTimesUsed,
		///<summary>CouponCode. </summary>
		CouponCode,
		///<summary>CustomerRange. </summary>
		CustomerRange,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>ModifiedByOrgRoleUserId. </summary>
		ModifiedByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CouponSignUpMode.
	/// </summary>
	public enum CouponSignUpModeFieldIndex:int
	{
		///<summary>CouponId. </summary>
		CouponId,
		///<summary>SignUpMode. </summary>
		SignUpMode,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CouponType.
	/// </summary>
	public enum CouponTypeFieldIndex:int
	{
		///<summary>CouponTypeId. </summary>
		CouponTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>IsEventCoupon. </summary>
		IsEventCoupon,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CreditCardType.
	/// </summary>
	public enum CreditCardTypeFieldIndex:int
	{
		///<summary>CreditCardTypeId. </summary>
		CreditCardTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Criteria.
	/// </summary>
	public enum CriteriaFieldIndex:int
	{
		///<summary>CriteriaId. </summary>
		CriteriaId,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CriticalCustomerCommunicationRecord.
	/// </summary>
	public enum CriticalCustomerCommunicationRecordFieldIndex:int
	{
		///<summary>NoteId. </summary>
		NoteId,
		///<summary>EventCustomerResultId. </summary>
		EventCustomerResultId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CriticalQuestion.
	/// </summary>
	public enum CriticalQuestionFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Question. </summary>
		Question,
		///<summary>ControlType. </summary>
		ControlType,
		///<summary>ControlValues. </summary>
		ControlValues,
		///<summary>ControlValueDelimiter. </summary>
		ControlValueDelimiter,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CurrentMedication.
	/// </summary>
	public enum CurrentMedicationFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>NdcId. </summary>
		NdcId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateEnd. </summary>
		DateEnd,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsPrescribed. </summary>
		IsPrescribed,
		///<summary>IsOtc. </summary>
		IsOtc,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomCampaignContent.
	/// </summary>
	public enum CustomCampaignContentFieldIndex:int
	{
		///<summary>CustomCampaignContentId. </summary>
		CustomCampaignContentId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>MarketingMaterialId. </summary>
		MarketingMaterialId,
		///<summary>Position. </summary>
		Position,
		///<summary>Step. </summary>
		Step,
		///<summary>Tag. </summary>
		Tag,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerAccountGlocomNumber.
	/// </summary>
	public enum CustomerAccountGlocomNumberFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>CallId. </summary>
		CallId,
		///<summary>GlocomNumber. </summary>
		GlocomNumber,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerActivityTypeUpload.
	/// </summary>
	public enum CustomerActivityTypeUploadFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>FileId. </summary>
		FileId,
		///<summary>SuccessfullUploadCount. </summary>
		SuccessfullUploadCount,
		///<summary>FailedUploadCount. </summary>
		FailedUploadCount,
		///<summary>UploadTime. </summary>
		UploadTime,
		///<summary>UploadedBy. </summary>
		UploadedBy,
		///<summary>LogFileId. </summary>
		LogFileId,
		///<summary>StatusId. </summary>
		StatusId,
		///<summary>ParseStartTime. </summary>
		ParseStartTime,
		///<summary>ParseEndTime. </summary>
		ParseEndTime,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerBillingAccount.
	/// </summary>
	public enum CustomerBillingAccountFieldIndex:int
	{
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>BillingAccountId. </summary>
		BillingAccountId,
		///<summary>BillingPatientId. </summary>
		BillingPatientId,
		///<summary>DateCreated. </summary>
		DateCreated,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerCallAttempts.
	/// </summary>
	public enum CustomerCallAttemptsFieldIndex:int
	{
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Attempt. </summary>
		Attempt,
		///<summary>UpdatedOn. </summary>
		UpdatedOn,
		///<summary>UpdatedBy. </summary>
		UpdatedBy,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerCallQueueCallAttempt.
	/// </summary>
	public enum CustomerCallQueueCallAttemptFieldIndex:int
	{
		///<summary>CallAttemptId. </summary>
		CallAttemptId,
		///<summary>CallId. </summary>
		CallId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>CallQueueCustomerId. </summary>
		CallQueueCustomerId,
		///<summary>IsCallSkipped. </summary>
		IsCallSkipped,
		///<summary>IsNotesReadAndUnderstood. </summary>
		IsNotesReadAndUnderstood,
		///<summary>NotInterestedReasonId. </summary>
		NotInterestedReasonId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>SkipCallNote. </summary>
		SkipCallNote,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerChaseCampaign.
	/// </summary>
	public enum CustomerChaseCampaignFieldIndex:int
	{
		///<summary>ChaseOutboundId. </summary>
		ChaseOutboundId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>ChaseCampaignId. </summary>
		ChaseCampaignId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerChaseChannel.
	/// </summary>
	public enum CustomerChaseChannelFieldIndex:int
	{
		///<summary>ChaseOutboundId. </summary>
		ChaseOutboundId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>ChaseChannelLevelId. </summary>
		ChaseChannelLevelId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerChaseProduct.
	/// </summary>
	public enum CustomerChaseProductFieldIndex:int
	{
		///<summary>ChaseOutboundId. </summary>
		ChaseOutboundId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>ChaseProductId. </summary>
		ChaseProductId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerClinicalQuestionAnswer.
	/// </summary>
	public enum CustomerClinicalQuestionAnswerFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Guid. </summary>
		Guid,
		///<summary>ClinicalQuestionTemplateId. </summary>
		ClinicalQuestionTemplateId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>ClinicalHealthQuestionId. </summary>
		ClinicalHealthQuestionId,
		///<summary>HealthQuestionAnswer. </summary>
		HealthQuestionAnswer,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>ModifiedOn. </summary>
		ModifiedOn,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerEligibility.
	/// </summary>
	public enum CustomerEligibilityFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>ForYear. </summary>
		ForYear,
		///<summary>IsEligible. </summary>
		IsEligible,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>DateModified. </summary>
		DateModified,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerEventCriticalTestData.
	/// </summary>
	public enum CustomerEventCriticalTestDataFieldIndex:int
	{
		///<summary>CustomerEventScreeningTestId. </summary>
		CustomerEventScreeningTestId,
		///<summary>ContactNumber. </summary>
		ContactNumber,
		///<summary>TechnicianNotes. </summary>
		TechnicianNotes,
		///<summary>TechnicianNotesForPhysician. </summary>
		TechnicianNotesForPhysician,
		///<summary>IsCustomerSigned. </summary>
		IsCustomerSigned,
		///<summary>IsTechnicianSigned. </summary>
		IsTechnicianSigned,
		///<summary>DateOfSubmission. </summary>
		DateOfSubmission,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>TechnicianId. </summary>
		TechnicianId,
		///<summary>ValidatingTechnicianId. </summary>
		ValidatingTechnicianId,
		///<summary>HasPcp. </summary>
		HasPcp,
		///<summary>IsDefaultFollowup. </summary>
		IsDefaultFollowup,
		///<summary>IsPatientReceivedImages. </summary>
		IsPatientReceivedImages,
		///<summary>Symptoms. </summary>
		Symptoms,
		///<summary>Physician. </summary>
		Physician,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerEventPriorityInQueueData.
	/// </summary>
	public enum CustomerEventPriorityInQueueDataFieldIndex:int
	{
		///<summary>CustomerEventScreeningTestId. </summary>
		CustomerEventScreeningTestId,
		///<summary>Note. </summary>
		Note,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>ModifiedByOrgRoleUserId. </summary>
		ModifiedByOrgRoleUserId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerEventReading.
	/// </summary>
	public enum CustomerEventReadingFieldIndex:int
	{
		///<summary>CustomerEventReadingId. </summary>
		CustomerEventReadingId,
		///<summary>CustomerEventScreeningTestId. </summary>
		CustomerEventScreeningTestId,
		///<summary>TestReadingId. </summary>
		TestReadingId,
		///<summary>Value. </summary>
		Value,
		///<summary>StandardFindingTestReadingId. </summary>
		StandardFindingTestReadingId,
		///<summary>IsManual. </summary>
		IsManual,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>UpdatedByOrgRoleUserId. </summary>
		UpdatedByOrgRoleUserId,
		///<summary>UpdatedOn. </summary>
		UpdatedOn,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerEventScreeningTests.
	/// </summary>
	public enum CustomerEventScreeningTestsFieldIndex:int
	{
		///<summary>CustomerEventScreeningTestId. </summary>
		CustomerEventScreeningTestId,
		///<summary>TestId. </summary>
		TestId,
		///<summary>EventCustomerResultId. </summary>
		EventCustomerResultId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerEventTestFinding.
	/// </summary>
	public enum CustomerEventTestFindingFieldIndex:int
	{
		///<summary>EventId. </summary>
		EventId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>TestId. </summary>
		TestId,
		///<summary>Finding. </summary>
		Finding,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerEventTestIncidentalFinding.
	/// </summary>
	public enum CustomerEventTestIncidentalFindingFieldIndex:int
	{
		///<summary>CustomerEventTestIncidentalFindingId. </summary>
		CustomerEventTestIncidentalFindingId,
		///<summary>CustomerEventScreeningTestId. </summary>
		CustomerEventScreeningTestId,
		///<summary>IncidentalFindingId. </summary>
		IncidentalFindingId,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerEventTestIncidentalFindingDetail.
	/// </summary>
	public enum CustomerEventTestIncidentalFindingDetailFieldIndex:int
	{
		///<summary>CustomerEventTestIncidentalFindingDetailId. </summary>
		CustomerEventTestIncidentalFindingDetailId,
		///<summary>CustomerEventTestIncidentalFindingId. </summary>
		CustomerEventTestIncidentalFindingId,
		///<summary>GroupItemId. </summary>
		GroupItemId,
		///<summary>Value. </summary>
		Value,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>UpdatedByOrgRoleUserId. </summary>
		UpdatedByOrgRoleUserId,
		///<summary>UpdatedOn. </summary>
		UpdatedOn,
		///<summary>Location. </summary>
		Location,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerEventTestPhysicianEvaluation.
	/// </summary>
	public enum CustomerEventTestPhysicianEvaluationFieldIndex:int
	{
		///<summary>CustomerEventTestPhysicianEvaluationId. </summary>
		CustomerEventTestPhysicianEvaluationId,
		///<summary>CustomerEventScreeningTestId. </summary>
		CustomerEventScreeningTestId,
		///<summary>PhysicianRemarks. </summary>
		PhysicianRemarks,
		///<summary>IsCritical. </summary>
		IsCritical,
		///<summary>IsFollowUpWithPhysician. </summary>
		IsFollowUpWithPhysician,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>UpdatedByOrgRoleUserId. </summary>
		UpdatedByOrgRoleUserId,
		///<summary>UpdatedOn. </summary>
		UpdatedOn,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerEventTestPhysicianNote.
	/// </summary>
	public enum CustomerEventTestPhysicianNoteFieldIndex:int
	{
		///<summary>EventId. </summary>
		EventId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>PhysicianNotes. </summary>
		PhysicianNotes,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerEventTestStandardFinding.
	/// </summary>
	public enum CustomerEventTestStandardFindingFieldIndex:int
	{
		///<summary>CustomerEventTestStandardFindingId. </summary>
		CustomerEventTestStandardFindingId,
		///<summary>CustomerEventScreeningTestId. </summary>
		CustomerEventScreeningTestId,
		///<summary>StandardFindingTestReadingId. </summary>
		StandardFindingTestReadingId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerEventTestState.
	/// </summary>
	public enum CustomerEventTestStateFieldIndex:int
	{
		///<summary>CustomerEventTestStateId. </summary>
		CustomerEventTestStateId,
		///<summary>CustomerEventScreeningTestId. </summary>
		CustomerEventScreeningTestId,
		///<summary>EvaluationState. </summary>
		EvaluationState,
		///<summary>IsPartial. </summary>
		IsPartial,
		///<summary>IsCritical. </summary>
		IsCritical,
		///<summary>SelfPresent. </summary>
		SelfPresent,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>IsTestNotPerformed. </summary>
		IsTestNotPerformed,
		///<summary>ConductedByOrgRoleUserId. </summary>
		ConductedByOrgRoleUserId,
		///<summary>EvaluatedByOrgRoleUserId. </summary>
		EvaluatedByOrgRoleUserId,
		///<summary>TechnicianNotes. </summary>
		TechnicianNotes,
		///<summary>UpdatedByOrgRoleUserId. </summary>
		UpdatedByOrgRoleUserId,
		///<summary>UpdatedOn. </summary>
		UpdatedOn,
		///<summary>IsNoteManualEntered. </summary>
		IsNoteManualEntered,
		///<summary>TestSummary. </summary>
		TestSummary,
		///<summary>PathwayRecommendation. </summary>
		PathwayRecommendation,
		///<summary>IsPriorityInQueue. </summary>
		IsPriorityInQueue,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerEventUnableScreenReason.
	/// </summary>
	public enum CustomerEventUnableScreenReasonFieldIndex:int
	{
		///<summary>CustomerEventUnableScreenReasonId. </summary>
		CustomerEventUnableScreenReasonId,
		///<summary>CustomerEventScreeningTestId. </summary>
		CustomerEventScreeningTestId,
		///<summary>TestUnableScreenReasonId. </summary>
		TestUnableScreenReasonId,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>UpdatedByOrgRoleUserId. </summary>
		UpdatedByOrgRoleUserId,
		///<summary>UpdatedOn. </summary>
		UpdatedOn,
		///<summary>IsManual. </summary>
		IsManual,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerHealthInfo.
	/// </summary>
	public enum CustomerHealthInfoFieldIndex:int
	{
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>CustomerHealthQuestionId. </summary>
		CustomerHealthQuestionId,
		///<summary>HealthQuestionAnswer. </summary>
		HealthQuestionAnswer,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerHealthInfoArchive.
	/// </summary>
	public enum CustomerHealthInfoArchiveFieldIndex:int
	{
		///<summary>CustomerHealthInfoArchiveId. </summary>
		CustomerHealthInfoArchiveId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>CustomerHealthQuestionId. </summary>
		CustomerHealthQuestionId,
		///<summary>HealthQuestionAnswer. </summary>
		HealthQuestionAnswer,
		///<summary>ArchiveDate. </summary>
		ArchiveDate,
		///<summary>Version. </summary>
		Version,
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>DateCreated. </summary>
		DateCreated,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerHealthQuestionGroup.
	/// </summary>
	public enum CustomerHealthQuestionGroupFieldIndex:int
	{
		///<summary>CustomerHealthQuestionGroupId. </summary>
		CustomerHealthQuestionGroupId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsClinicalQuestions. </summary>
		IsClinicalQuestions,
		///<summary>TestId. </summary>
		TestId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerHealthQuestions.
	/// </summary>
	public enum CustomerHealthQuestionsFieldIndex:int
	{
		///<summary>CustomerHealthQuestionId. </summary>
		CustomerHealthQuestionId,
		///<summary>CustomerHealthQuestionGroupId. </summary>
		CustomerHealthQuestionGroupId,
		///<summary>Question. </summary>
		Question,
		///<summary>Label. </summary>
		Label,
		///<summary>ControlType. </summary>
		ControlType,
		///<summary>ControlValues. </summary>
		ControlValues,
		///<summary>ControlValueDelimiter. </summary>
		ControlValueDelimiter,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsRequired. </summary>
		IsRequired,
		///<summary>DisplaySequence. </summary>
		DisplaySequence,
		///<summary>DefaultValue. </summary>
		DefaultValue,
		///<summary>ParentQuestionId. </summary>
		ParentQuestionId,
		///<summary>IsForFemale. </summary>
		IsForFemale,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerIcdCode.
	/// </summary>
	public enum CustomerIcdCodeFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>IcdCodeId. </summary>
		IcdCodeId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateEnd. </summary>
		DateEnd,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerLockForCall.
	/// </summary>
	public enum CustomerLockForCallFieldIndex:int
	{
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerMedicareQuestionAnswer.
	/// </summary>
	public enum CustomerMedicareQuestionAnswerFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>QuestionId. </summary>
		QuestionId,
		///<summary>Answer. </summary>
		Answer,
		///<summary>CreateOn. </summary>
		CreateOn,
		///<summary>CreateBy. </summary>
		CreateBy,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerOrderHistory.
	/// </summary>
	public enum CustomerOrderHistoryFieldIndex:int
	{
		///<summary>UploadId. </summary>
		UploadId,
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>EventPackageId. </summary>
		EventPackageId,
		///<summary>EventTestId. </summary>
		EventTestId,
		///<summary>OrderItemStatusId. </summary>
		OrderItemStatusId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerPhoneNumberUpdateUpload.
	/// </summary>
	public enum CustomerPhoneNumberUpdateUploadFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>FileId. </summary>
		FileId,
		///<summary>StatusId. </summary>
		StatusId,
		///<summary>SuccessUploadCount. </summary>
		SuccessUploadCount,
		///<summary>FailedUploadCount. </summary>
		FailedUploadCount,
		///<summary>UploadTime. </summary>
		UploadTime,
		///<summary>ParseStartTime. </summary>
		ParseStartTime,
		///<summary>ParseEndTime. </summary>
		ParseEndTime,
		///<summary>UploadedByOrgRoleUserId. </summary>
		UploadedByOrgRoleUserId,
		///<summary>LogFileId. </summary>
		LogFileId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerPhoneNumberUpdateUploadLog.
	/// </summary>
	public enum CustomerPhoneNumberUpdateUploadLogFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>UploadId. </summary>
		UploadId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>Dob. </summary>
		Dob,
		///<summary>MemberId. </summary>
		MemberId,
		///<summary>PhoneNumber. </summary>
		PhoneNumber,
		///<summary>PhoneType. </summary>
		PhoneType,
		///<summary>IsSuccessful. </summary>
		IsSuccessful,
		///<summary>ErrorMessage. </summary>
		ErrorMessage,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerPredictedZip.
	/// </summary>
	public enum CustomerPredictedZipFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>PredictedZip. </summary>
		PredictedZip,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerPrimaryCarePhysician.
	/// </summary>
	public enum CustomerPrimaryCarePhysicianFieldIndex:int
	{
		///<summary>PrimaryCarePhysicianId. </summary>
		PrimaryCarePhysicianId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>MiddleName. </summary>
		MiddleName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>Pcpaddress. </summary>
		Pcpaddress,
		///<summary>PhoneNumber. </summary>
		PhoneNumber,
		///<summary>Email. </summary>
		Email,
		///<summary>SendEmail. </summary>
		SendEmail,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>PhoneOther. </summary>
		PhoneOther,
		///<summary>EmailOther. </summary>
		EmailOther,
		///<summary>Website. </summary>
		Website,
		///<summary>UpdatedByOrganizationRoleUserId. </summary>
		UpdatedByOrganizationRoleUserId,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>Npi. </summary>
		Npi,
		///<summary>Fax. </summary>
		Fax,
		///<summary>PrefixText. </summary>
		PrefixText,
		///<summary>SuffixText. </summary>
		SuffixText,
		///<summary>CredentialText. </summary>
		CredentialText,
		///<summary>PhysicianMasterId. </summary>
		PhysicianMasterId,
		///<summary>MailingAddressId. </summary>
		MailingAddressId,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsPcpAddressVerified. </summary>
		IsPcpAddressVerified,
		///<summary>PcpAddressVerifiedBy. </summary>
		PcpAddressVerifiedBy,
		///<summary>PcpAddressVerifiedOn. </summary>
		PcpAddressVerifiedOn,
		///<summary>Source. </summary>
		Source,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerProfile.
	/// </summary>
	public enum CustomerProfileFieldIndex:int
	{
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>DisplayId. </summary>
		DisplayId,
		///<summary>BillingAddressId. </summary>
		BillingAddressId,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>Height. </summary>
		Height,
		///<summary>Weight. </summary>
		Weight,
		///<summary>Gender. </summary>
		Gender,
		///<summary>Race. </summary>
		Race,
		///<summary>Age. </summary>
		Age,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>TrackingMarketingId. </summary>
		TrackingMarketingId,
		///<summary>AddedByRoleId. </summary>
		AddedByRoleId,
		///<summary>Employer. </summary>
		Employer,
		///<summary>EmergencyContactName. </summary>
		EmergencyContactName,
		///<summary>EmergencyContactRelationship. </summary>
		EmergencyContactRelationship,
		///<summary>EmergencyContactPhoneNumber. </summary>
		EmergencyContactPhoneNumber,
		///<summary>DoNotContactReasonId. </summary>
		DoNotContactReasonId,
		///<summary>DoNotContactReasonNotesId. </summary>
		DoNotContactReasonNotesId,
		///<summary>RequestNewsLetter. </summary>
		RequestNewsLetter,
		///<summary>EmployeeId. </summary>
		EmployeeId,
		///<summary>InsuranceId. </summary>
		InsuranceId,
		///<summary>PreferredLanguage. </summary>
		PreferredLanguage,
		///<summary>BestTimeToCall. </summary>
		BestTimeToCall,
		///<summary>Waist. </summary>
		Waist,
		///<summary>Hicn. </summary>
		Hicn,
		///<summary>EnableTexting. </summary>
		EnableTexting,
		///<summary>MedicareAdvantageNumber. </summary>
		MedicareAdvantageNumber,
		///<summary>Tag. </summary>
		Tag,
		///<summary>MedicareAdvantagePlanName. </summary>
		MedicareAdvantagePlanName,
		///<summary>LanguageId. </summary>
		LanguageId,
		///<summary>LabId. </summary>
		LabId,
		///<summary>Copay. </summary>
		Copay,
		///<summary>Lpi. </summary>
		Lpi,
		///<summary>Market. </summary>
		Market,
		///<summary>Mrn. </summary>
		Mrn,
		///<summary>GroupName. </summary>
		GroupName,
		///<summary>IsIncorrectPhoneNumber. </summary>
		IsIncorrectPhoneNumber,
		///<summary>IsLanguageBarrier. </summary>
		IsLanguageBarrier,
		///<summary>DoNotContactTypeId. </summary>
		DoNotContactTypeId,
		///<summary>EnableVoiceMail. </summary>
		EnableVoiceMail,
		///<summary>AdditionalField1. </summary>
		AdditionalField1,
		///<summary>AdditionalField2. </summary>
		AdditionalField2,
		///<summary>AdditionalField3. </summary>
		AdditionalField3,
		///<summary>AdditionalField4. </summary>
		AdditionalField4,
		///<summary>ActivityId. </summary>
		ActivityId,
		///<summary>DoNotContactUpdateDate. </summary>
		DoNotContactUpdateDate,
		///<summary>DoNotContactUpdateSource. </summary>
		DoNotContactUpdateSource,
		///<summary>IsSubscribed. </summary>
		IsSubscribed,
		///<summary>IncorrectPhoneNumberMarkedDate. </summary>
		IncorrectPhoneNumberMarkedDate,
		///<summary>LanguageBarrierMarkedDate. </summary>
		LanguageBarrierMarkedDate,
		///<summary>PreferredContactType. </summary>
		PreferredContactType,
		///<summary>Mbi. </summary>
		Mbi,
		///<summary>AcesId. </summary>
		AcesId,
		///<summary>PhoneHomeConsentId. </summary>
		PhoneHomeConsentId,
		///<summary>PhoneHomeConsentUpdateDate. </summary>
		PhoneHomeConsentUpdateDate,
		///<summary>PhoneCellConsentId. </summary>
		PhoneCellConsentId,
		///<summary>PhoneCellConsentUpdateDate. </summary>
		PhoneCellConsentUpdateDate,
		///<summary>PhoneOfficeConsentId. </summary>
		PhoneOfficeConsentId,
		///<summary>PhoneOfficeConsentUpdateDate. </summary>
		PhoneOfficeConsentUpdateDate,
		///<summary>BillingMemberId. </summary>
		BillingMemberId,
		///<summary>BillingMemberPlan. </summary>
		BillingMemberPlan,
		///<summary>BillingMemberPlanYear. </summary>
		BillingMemberPlanYear,
		///<summary>EnableEmail. </summary>
		EnableEmail,
		///<summary>EnableEmailUpdateDate. </summary>
		EnableEmailUpdateDate,
		///<summary>MemberUploadSourceId. </summary>
		MemberUploadSourceId,
		///<summary>ActivityTypeIsManual. </summary>
		ActivityTypeIsManual,
		///<summary>ProductTypeId. </summary>
		ProductTypeId,
		///<summary>AcesClientId. </summary>
		AcesClientId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerProfileHistory.
	/// </summary>
	public enum CustomerProfileHistoryFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>MiddleName. </summary>
		MiddleName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>HomeAddress1. </summary>
		HomeAddress1,
		///<summary>HomeAddress2. </summary>
		HomeAddress2,
		///<summary>HomeCity. </summary>
		HomeCity,
		///<summary>HomeState. </summary>
		HomeState,
		///<summary>HomeZipCode. </summary>
		HomeZipCode,
		///<summary>HomeCountry. </summary>
		HomeCountry,
		///<summary>PhoneOffice. </summary>
		PhoneOffice,
		///<summary>PhoneCell. </summary>
		PhoneCell,
		///<summary>PhoneHome. </summary>
		PhoneHome,
		///<summary>Email1. </summary>
		Email1,
		///<summary>Email2. </summary>
		Email2,
		///<summary>Picture. </summary>
		Picture,
		///<summary>Dob. </summary>
		Dob,
		///<summary>DefaultRoleId. </summary>
		DefaultRoleId,
		///<summary>PhoneOfficeExtension. </summary>
		PhoneOfficeExtension,
		///<summary>Ssn. </summary>
		Ssn,
		///<summary>DisplayId. </summary>
		DisplayId,
		///<summary>BillingAddress1. </summary>
		BillingAddress1,
		///<summary>BillingAddress2. </summary>
		BillingAddress2,
		///<summary>BillingCity. </summary>
		BillingCity,
		///<summary>BillingState. </summary>
		BillingState,
		///<summary>BillingZipCode. </summary>
		BillingZipCode,
		///<summary>BillingCountry. </summary>
		BillingCountry,
		///<summary>Height. </summary>
		Height,
		///<summary>Weight. </summary>
		Weight,
		///<summary>Gender. </summary>
		Gender,
		///<summary>Race. </summary>
		Race,
		///<summary>TrackingMarketingId. </summary>
		TrackingMarketingId,
		///<summary>AddedByRoleId. </summary>
		AddedByRoleId,
		///<summary>Employer. </summary>
		Employer,
		///<summary>EmergencyContactName. </summary>
		EmergencyContactName,
		///<summary>EmergencyContactRelationship. </summary>
		EmergencyContactRelationship,
		///<summary>EmergencyContactPhoneNumber. </summary>
		EmergencyContactPhoneNumber,
		///<summary>DoNotContactReasonId. </summary>
		DoNotContactReasonId,
		///<summary>DoNotContactReasonNotesId. </summary>
		DoNotContactReasonNotesId,
		///<summary>RequestNewsLetter. </summary>
		RequestNewsLetter,
		///<summary>EmployeeId. </summary>
		EmployeeId,
		///<summary>InsuranceId. </summary>
		InsuranceId,
		///<summary>PreferredLanguage. </summary>
		PreferredLanguage,
		///<summary>BestTimeToCall. </summary>
		BestTimeToCall,
		///<summary>Waist. </summary>
		Waist,
		///<summary>Hicn. </summary>
		Hicn,
		///<summary>EnableTexting. </summary>
		EnableTexting,
		///<summary>MedicareAdvantageNumber. </summary>
		MedicareAdvantageNumber,
		///<summary>Tag. </summary>
		Tag,
		///<summary>MedicareAdvantagePlanName. </summary>
		MedicareAdvantagePlanName,
		///<summary>IsEligble. </summary>
		IsEligble,
		///<summary>LanguageId. </summary>
		LanguageId,
		///<summary>LabId. </summary>
		LabId,
		///<summary>Copay. </summary>
		Copay,
		///<summary>Lpi. </summary>
		Lpi,
		///<summary>Market. </summary>
		Market,
		///<summary>Mrn. </summary>
		Mrn,
		///<summary>GroupName. </summary>
		GroupName,
		///<summary>IsIncorrectPhoneNumber. </summary>
		IsIncorrectPhoneNumber,
		///<summary>IsLanguageBarrier. </summary>
		IsLanguageBarrier,
		///<summary>DoNotContactTypeId. </summary>
		DoNotContactTypeId,
		///<summary>EnableVoiceMail. </summary>
		EnableVoiceMail,
		///<summary>AdditionalField1. </summary>
		AdditionalField1,
		///<summary>AdditionalField2. </summary>
		AdditionalField2,
		///<summary>AdditionalField3. </summary>
		AdditionalField3,
		///<summary>AdditionalField4. </summary>
		AdditionalField4,
		///<summary>ActivityId. </summary>
		ActivityId,
		///<summary>DoNotContactUpdateDate. </summary>
		DoNotContactUpdateDate,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>DoNotContactUpdateSource. </summary>
		DoNotContactUpdateSource,
		///<summary>IsSubscribed. </summary>
		IsSubscribed,
		///<summary>IncorrectPhoneNumberMarkedDate. </summary>
		IncorrectPhoneNumberMarkedDate,
		///<summary>LanguageBarrierMarkedDate. </summary>
		LanguageBarrierMarkedDate,
		///<summary>PreferredContactType. </summary>
		PreferredContactType,
		///<summary>Mbi. </summary>
		Mbi,
		///<summary>AcesId. </summary>
		AcesId,
		///<summary>PhoneHomeConsentId. </summary>
		PhoneHomeConsentId,
		///<summary>PhoneHomeConsentUpdateDate. </summary>
		PhoneHomeConsentUpdateDate,
		///<summary>PhoneCellConsentId. </summary>
		PhoneCellConsentId,
		///<summary>PhoneCellConsentUpdateDate. </summary>
		PhoneCellConsentUpdateDate,
		///<summary>PhoneOfficeConsentId. </summary>
		PhoneOfficeConsentId,
		///<summary>PhoneOfficeConsentUpdateDate. </summary>
		PhoneOfficeConsentUpdateDate,
		///<summary>BillingMemberId. </summary>
		BillingMemberId,
		///<summary>BillingMemberPlan. </summary>
		BillingMemberPlan,
		///<summary>BillingMemberPlanYear. </summary>
		BillingMemberPlanYear,
		///<summary>EnableEmail. </summary>
		EnableEmail,
		///<summary>EnableEmailUpdateDate. </summary>
		EnableEmailUpdateDate,
		///<summary>MergedCustomerId. </summary>
		MergedCustomerId,
		///<summary>EligibilityForYear. </summary>
		EligibilityForYear,
		///<summary>IsWarmTransfer. </summary>
		IsWarmTransfer,
		///<summary>WarmTransferYear. </summary>
		WarmTransferYear,
		///<summary>MemberUploadSourceId. </summary>
		MemberUploadSourceId,
		///<summary>ActivityTypeIsManual. </summary>
		ActivityTypeIsManual,
		///<summary>TargetedYear. </summary>
		TargetedYear,
		///<summary>IsTargeted. </summary>
		IsTargeted,
		///<summary>ProductTypeId. </summary>
		ProductTypeId,
		///<summary>AcesClientId. </summary>
		AcesClientId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerRegistrationNotes.
	/// </summary>
	public enum CustomerRegistrationNotesFieldIndex:int
	{
		///<summary>CustomerRegistrationNotesId. </summary>
		CustomerRegistrationNotesId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Notes. </summary>
		Notes,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>NoteType. </summary>
		NoteType,
		///<summary>ReasonId. </summary>
		ReasonId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerResultPosted.
	/// </summary>
	public enum CustomerResultPostedFieldIndex:int
	{
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>ResultPostId. </summary>
		ResultPostId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerResultScreeningCommunication.
	/// </summary>
	public enum CustomerResultScreeningCommunicationFieldIndex:int
	{
		///<summary>CommunicationId. </summary>
		CommunicationId,
		///<summary>PhysicianComment. </summary>
		PhysicianComment,
		///<summary>FranchiseeComment. </summary>
		FranchiseeComment,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateResponded. </summary>
		DateResponded,
		///<summary>CommunicationInitiatedByOrgRoleUserId. </summary>
		CommunicationInitiatedByOrgRoleUserId,
		///<summary>PhysicianOrgRoleUserId. </summary>
		PhysicianOrgRoleUserId,
		///<summary>FranchiseeAdminOrgRoleUserId. </summary>
		FranchiseeAdminOrgRoleUserId,
		///<summary>EventCustomerResultId. </summary>
		EventCustomerResultId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerSkipReview.
	/// </summary>
	public enum CustomerSkipReviewFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>DefaultPhysicianId. </summary>
		DefaultPhysicianId,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsSkipEvaluation. </summary>
		IsSkipEvaluation,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerSurvey.
	/// </summary>
	public enum CustomerSurveyFieldIndex:int
	{
		///<summary>CustomerSurveyId. </summary>
		CustomerSurveyId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>CustomerSurveyQuestionAnswerId. </summary>
		CustomerSurveyQuestionAnswerId,
		///<summary>TextBoxValue. </summary>
		TextBoxValue,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerSurveyQuestion.
	/// </summary>
	public enum CustomerSurveyQuestionFieldIndex:int
	{
		///<summary>CustomerSurveyQuestionId. </summary>
		CustomerSurveyQuestionId,
		///<summary>Question. </summary>
		Question,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerSurveyQuestionAnswer.
	/// </summary>
	public enum CustomerSurveyQuestionAnswerFieldIndex:int
	{
		///<summary>CustomerSurveyQuestionAnswerId. </summary>
		CustomerSurveyQuestionAnswerId,
		///<summary>CustomerSurveyQuestionId. </summary>
		CustomerSurveyQuestionId,
		///<summary>Answer. </summary>
		Answer,
		///<summary>IsShowTextBox. </summary>
		IsShowTextBox,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerTag.
	/// </summary>
	public enum CustomerTagFieldIndex:int
	{
		///<summary>CustomerTagId. </summary>
		CustomerTagId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Tag. </summary>
		Tag,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>ModifiedByOrgRoleUserId. </summary>
		ModifiedByOrgRoleUserId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerTargeted.
	/// </summary>
	public enum CustomerTargetedFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>ForYear. </summary>
		ForYear,
		///<summary>IsTargated. </summary>
		IsTargated,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>DateModified. </summary>
		DateModified,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerTrale.
	/// </summary>
	public enum CustomerTraleFieldIndex:int
	{
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>UserId. </summary>
		UserId,
		///<summary>DateCreated. </summary>
		DateCreated,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerUnsubscribedSmsNotification.
	/// </summary>
	public enum CustomerUnsubscribedSmsNotificationFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>SmsReceivedId. </summary>
		SmsReceivedId,
		///<summary>StatusId. </summary>
		StatusId,
		///<summary>DateCreated. </summary>
		DateCreated,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerWarmTransfer.
	/// </summary>
	public enum CustomerWarmTransferFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>WarmTransferYear. </summary>
		WarmTransferYear,
		///<summary>IsWarmTransfer. </summary>
		IsWarmTransfer,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>DateModified. </summary>
		DateModified,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomEventNotification.
	/// </summary>
	public enum CustomEventNotificationFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>EventId. </summary>
		EventId,
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>Body. </summary>
		Body,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>ServiceStatus. </summary>
		ServiceStatus,
		///<summary>ServiceDate. </summary>
		ServiceDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: DemandDraftPaymentDetails.
	/// </summary>
	public enum DemandDraftPaymentDetailsFieldIndex:int
	{
		///<summary>DemandDraftId. </summary>
		DemandDraftId,
		///<summary>Ddnumber. </summary>
		Ddnumber,
		///<summary>Description. </summary>
		Description,
		///<summary>PaymentId. </summary>
		PaymentId,
		///<summary>PaymentStatus. </summary>
		PaymentStatus,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: DependentDisqualifiedTest.
	/// </summary>
	public enum DependentDisqualifiedTestFieldIndex:int
	{
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>TestId. </summary>
		TestId,
		///<summary>Version. </summary>
		Version,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: DiabeticRetinopathyParserlog.
	/// </summary>
	public enum DiabeticRetinopathyParserlogFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>FileName. </summary>
		FileName,
		///<summary>ErrorMessage. </summary>
		ErrorMessage,
		///<summary>DateCreated. </summary>
		DateCreated,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: DigitalAssetAccessLog.
	/// </summary>
	public enum DigitalAssetAccessLogFieldIndex:int
	{
		///<summary>DigitalAssetAccessLogId. </summary>
		DigitalAssetAccessLogId,
		///<summary>OrganisationRoleUserId. </summary>
		OrganisationRoleUserId,
		///<summary>UserLoginLogId. </summary>
		UserLoginLogId,
		///<summary>AccessedOn. </summary>
		AccessedOn,
		///<summary>DigitalAssetType. </summary>
		DigitalAssetType,
		///<summary>DigitalAsset. </summary>
		DigitalAsset,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: DirectMail.
	/// </summary>
	public enum DirectMailFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>MailDate. </summary>
		MailDate,
		///<summary>MailedBy. </summary>
		MailedBy,
		///<summary>CallUploadId. </summary>
		CallUploadId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>DirectMailTypeId. </summary>
		DirectMailTypeId,
		///<summary>IsInvalidAddress. </summary>
		IsInvalidAddress,
		///<summary>Notes. </summary>
		Notes,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: DirectMailType.
	/// </summary>
	public enum DirectMailTypeFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Name. </summary>
		Name,
		///<summary>Alias. </summary>
		Alias,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: DisqualifiedTest.
	/// </summary>
	public enum DisqualifiedTestFieldIndex:int
	{
		///<summary>TestId. </summary>
		TestId,
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>QuestionId. </summary>
		QuestionId,
		///<summary>Answer. </summary>
		Answer,
		///<summary>Version. </summary>
		Version,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>UpdatedBy. </summary>
		UpdatedBy,
		///<summary>UpdatedDate. </summary>
		UpdatedDate,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>EventId. </summary>
		EventId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EcheckPayment.
	/// </summary>
	public enum EcheckPaymentFieldIndex:int
	{
		///<summary>PaymentId. </summary>
		PaymentId,
		///<summary>EcheckId. </summary>
		EcheckId,
		///<summary>ProcessorResponse. </summary>
		ProcessorResponse,
		///<summary>Status. </summary>
		Status,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Eligibility.
	/// </summary>
	public enum EligibilityFieldIndex:int
	{
		///<summary>EligibilityId. </summary>
		EligibilityId,
		///<summary>Guid. </summary>
		Guid,
		///<summary>InsuranceCompanyId. </summary>
		InsuranceCompanyId,
		///<summary>PlanName. </summary>
		PlanName,
		///<summary>GroupName. </summary>
		GroupName,
		///<summary>CoPayment. </summary>
		CoPayment,
		///<summary>CoInsurance. </summary>
		CoInsurance,
		///<summary>Request. </summary>
		Request,
		///<summary>Response. </summary>
		Response,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EligibilityUpload.
	/// </summary>
	public enum EligibilityUploadFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>FileId. </summary>
		FileId,
		///<summary>SuccessfullUploadCount. </summary>
		SuccessfullUploadCount,
		///<summary>FailedUploadCount. </summary>
		FailedUploadCount,
		///<summary>UploadTime. </summary>
		UploadTime,
		///<summary>UploadedBy. </summary>
		UploadedBy,
		///<summary>LogFileId. </summary>
		LogFileId,
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>StatusId. </summary>
		StatusId,
		///<summary>ParseStartTime. </summary>
		ParseStartTime,
		///<summary>ParseEndTime. </summary>
		ParseEndTime,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EmailTemplate.
	/// </summary>
	public enum EmailTemplateFieldIndex:int
	{
		///<summary>EmailTemplateId. </summary>
		EmailTemplateId,
		///<summary>EmailTitle. </summary>
		EmailTitle,
		///<summary>EmailSubject. </summary>
		EmailSubject,
		///<summary>EmailBody. </summary>
		EmailBody,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>ModifiedByOrgRoleUserId. </summary>
		ModifiedByOrgRoleUserId,
		///<summary>TemplateType. </summary>
		TemplateType,
		///<summary>NotificationTypeId. </summary>
		NotificationTypeId,
		///<summary>IsEditable. </summary>
		IsEditable,
		///<summary>CoverLetterTypeLookupId. </summary>
		CoverLetterTypeLookupId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EmailTemplateMacro.
	/// </summary>
	public enum EmailTemplateMacroFieldIndex:int
	{
		///<summary>EmailTemplateId. </summary>
		EmailTemplateId,
		///<summary>TemplateMacroId. </summary>
		TemplateMacroId,
		///<summary>Sequence. </summary>
		Sequence,
		///<summary>ParameterValue. </summary>
		ParameterValue,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Encounter.
	/// </summary>
	public enum EncounterFieldIndex:int
	{
		///<summary>EncounterId. </summary>
		EncounterId,
		///<summary>BillingAccountId. </summary>
		BillingAccountId,
		///<summary>DateCreated. </summary>
		DateCreated,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventAccount.
	/// </summary>
	public enum EventAccountFieldIndex:int
	{
		///<summary>EventId. </summary>
		EventId,
		///<summary>AccountId. </summary>
		AccountId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventAccountTestHcpcsCode.
	/// </summary>
	public enum EventAccountTestHcpcsCodeFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>EventId. </summary>
		EventId,
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>TestHcpcsCodeId. </summary>
		TestHcpcsCodeId,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>ModifiedDate. </summary>
		ModifiedDate,
		///<summary>IsDeleted. </summary>
		IsDeleted,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventActivityTemplate.
	/// </summary>
	public enum EventActivityTemplateFieldIndex:int
	{
		///<summary>EventActivityTemplateId. </summary>
		EventActivityTemplateId,
		///<summary>TemplateName. </summary>
		TemplateName,
		///<summary>IsGlobal. </summary>
		IsGlobal,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>OrganizationRoleUserId. </summary>
		OrganizationRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventActivityTemplateCall.
	/// </summary>
	public enum EventActivityTemplateCallFieldIndex:int
	{
		///<summary>EventActivityTemplateCallId. </summary>
		EventActivityTemplateCallId,
		///<summary>EventActivityTemplateId. </summary>
		EventActivityTemplateId,
		///<summary>Subject. </summary>
		Subject,
		///<summary>Notes. </summary>
		Notes,
		///<summary>CallingDay. </summary>
		CallingDay,
		///<summary>ForAfterEvent. </summary>
		ForAfterEvent,
		///<summary>ResponsibleRoleId. </summary>
		ResponsibleRoleId,
		///<summary>ResponsibleEmailSpecified. </summary>
		ResponsibleEmailSpecified,
		///<summary>ResponsibleOrgRoleUserId. </summary>
		ResponsibleOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventActivityTemplateEmail.
	/// </summary>
	public enum EventActivityTemplateEmailFieldIndex:int
	{
		///<summary>EventActivityTemplateEmailId. </summary>
		EventActivityTemplateEmailId,
		///<summary>EventActivityTemplateId. </summary>
		EventActivityTemplateId,
		///<summary>Subject. </summary>
		Subject,
		///<summary>EmailContent. </summary>
		EmailContent,
		///<summary>EmailSentDay. </summary>
		EmailSentDay,
		///<summary>ForAfterEvent. </summary>
		ForAfterEvent,
		///<summary>ResponsibleRoleId. </summary>
		ResponsibleRoleId,
		///<summary>ResponsibleEmailSpecified. </summary>
		ResponsibleEmailSpecified,
		///<summary>ResponsibleOrgRoleUserId. </summary>
		ResponsibleOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventActivityTemplateHost.
	/// </summary>
	public enum EventActivityTemplateHostFieldIndex:int
	{
		///<summary>EventActivityTemplateHostId. </summary>
		EventActivityTemplateHostId,
		///<summary>EventActivityTemplateId. </summary>
		EventActivityTemplateId,
		///<summary>HostId. </summary>
		HostId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventActivityTemplateMeeting.
	/// </summary>
	public enum EventActivityTemplateMeetingFieldIndex:int
	{
		///<summary>EventActivityTemplateMeetingId. </summary>
		EventActivityTemplateMeetingId,
		///<summary>EventActivityTemplateId. </summary>
		EventActivityTemplateId,
		///<summary>Subject. </summary>
		Subject,
		///<summary>Notes. </summary>
		Notes,
		///<summary>MeetingDay. </summary>
		MeetingDay,
		///<summary>ForAfterEvent. </summary>
		ForAfterEvent,
		///<summary>ResponsibleRoleId. </summary>
		ResponsibleRoleId,
		///<summary>ResponsibleEmailSpecified. </summary>
		ResponsibleEmailSpecified,
		///<summary>ResponsibleOrgRoleUserId. </summary>
		ResponsibleOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventActivityTemplateTask.
	/// </summary>
	public enum EventActivityTemplateTaskFieldIndex:int
	{
		///<summary>EventActivityTemplateTaskId. </summary>
		EventActivityTemplateTaskId,
		///<summary>EventActivityTemplateId. </summary>
		EventActivityTemplateId,
		///<summary>Subject. </summary>
		Subject,
		///<summary>Notes. </summary>
		Notes,
		///<summary>TaskDuration. </summary>
		TaskDuration,
		///<summary>ForAfterEvent. </summary>
		ForAfterEvent,
		///<summary>ResponsibleRoleId. </summary>
		ResponsibleRoleId,
		///<summary>ResponsibleEmailSpecified. </summary>
		ResponsibleEmailSpecified,
		///<summary>ResponsibleOrgRoleUserId. </summary>
		ResponsibleOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventAffiliateDetails.
	/// </summary>
	public enum EventAffiliateDetailsFieldIndex:int
	{
		///<summary>EventAffiliateId. </summary>
		EventAffiliateId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>AffiliateId. </summary>
		AffiliateId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsAdvocate. </summary>
		IsAdvocate,
		///<summary>IsHost. </summary>
		IsHost,
		///<summary>IsSalesRep. </summary>
		IsSalesRep,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventAppointment.
	/// </summary>
	public enum EventAppointmentFieldIndex:int
	{
		///<summary>AppointmentId. </summary>
		AppointmentId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>StartTime. </summary>
		StartTime,
		///<summary>EndTime. </summary>
		EndTime,
		///<summary>CheckinTime. </summary>
		CheckinTime,
		///<summary>CheckoutTime. </summary>
		CheckoutTime,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>ScheduledByOrgRoleUserId. </summary>
		ScheduledByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventAppointmentCancellationLog.
	/// </summary>
	public enum EventAppointmentCancellationLogFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>ReasonId. </summary>
		ReasonId,
		///<summary>NoteId. </summary>
		NoteId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>RefundRequestId. </summary>
		RefundRequestId,
		///<summary>SubReasonId. </summary>
		SubReasonId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventAppointmentChangeLog.
	/// </summary>
	public enum EventAppointmentChangeLogFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>OldEventId. </summary>
		OldEventId,
		///<summary>OldAppointmentTime. </summary>
		OldAppointmentTime,
		///<summary>NewEventId. </summary>
		NewEventId,
		///<summary>NewAppointmentTime. </summary>
		NewAppointmentTime,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>ReasonId. </summary>
		ReasonId,
		///<summary>Notes. </summary>
		Notes,
		///<summary>SubReasonId. </summary>
		SubReasonId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCallDetails.
	/// </summary>
	public enum EventCallDetailsFieldIndex:int
	{
		///<summary>EventId. </summary>
		EventId,
		///<summary>CallId. </summary>
		CallId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCampaignDetails.
	/// </summary>
	public enum EventCampaignDetailsFieldIndex:int
	{
		///<summary>EventCampaignId. </summary>
		EventCampaignId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>AffiliateId. </summary>
		AffiliateId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>MarketingPrintOrderItemId. </summary>
		MarketingPrintOrderItemId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventChecklistTemplate.
	/// </summary>
	public enum EventChecklistTemplateFieldIndex:int
	{
		///<summary>EventId. </summary>
		EventId,
		///<summary>ChecklistTemplateId. </summary>
		ChecklistTemplateId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCoupons.
	/// </summary>
	public enum EventCouponsFieldIndex:int
	{
		///<summary>EventId. </summary>
		EventId,
		///<summary>CouponId. </summary>
		CouponId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerBarrier.
	/// </summary>
	public enum EventCustomerBarrierFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>BarrierId. </summary>
		BarrierId,
		///<summary>Reason. </summary>
		Reason,
		///<summary>Resolution. </summary>
		Resolution,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerBasicBioMetric.
	/// </summary>
	public enum EventCustomerBasicBioMetricFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>SystolicPressure. </summary>
		SystolicPressure,
		///<summary>DiastolicPressure. </summary>
		DiastolicPressure,
		///<summary>IsRightArmBpMeasurement. </summary>
		IsRightArmBpMeasurement,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsBloodPressureElevated. </summary>
		IsBloodPressureElevated,
		///<summary>PulseRate. </summary>
		PulseRate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerCriticalQuestion.
	/// </summary>
	public enum EventCustomerCriticalQuestionFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>QuestionId. </summary>
		QuestionId,
		///<summary>Answer. </summary>
		Answer,
		///<summary>Note. </summary>
		Note,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerCurrentMedication.
	/// </summary>
	public enum EventCustomerCurrentMedicationFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>NdcId. </summary>
		NdcId,
		///<summary>IsPrescribed. </summary>
		IsPrescribed,
		///<summary>IsOtc. </summary>
		IsOtc,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerCustomNotification.
	/// </summary>
	public enum EventCustomerCustomNotificationFieldIndex:int
	{
		///<summary>CustomEventNotificationId. </summary>
		CustomEventNotificationId,
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>Message. </summary>
		Message,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerDiagnosis.
	/// </summary>
	public enum EventCustomerDiagnosisFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>Diagnosis. </summary>
		Diagnosis,
		///<summary>Accepted. </summary>
		Accepted,
		///<summary>ClinicalMonitor. </summary>
		ClinicalMonitor,
		///<summary>ClinicalEvaluation. </summary>
		ClinicalEvaluation,
		///<summary>ClinicalAssessment. </summary>
		ClinicalAssessment,
		///<summary>ClinicalTreatment. </summary>
		ClinicalTreatment,
		///<summary>ClinicalComment. </summary>
		ClinicalComment,
		///<summary>Icd. </summary>
		Icd,
		///<summary>IsIcd10. </summary>
		IsIcd10,
		///<summary>DateCreated. </summary>
		DateCreated,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerEligibility.
	/// </summary>
	public enum EventCustomerEligibilityFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>EligibilityId. </summary>
		EligibilityId,
		///<summary>ChargeCardId. </summary>
		ChargeCardId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerEncounter.
	/// </summary>
	public enum EventCustomerEncounterFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>EncounterId. </summary>
		EncounterId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerEvaluationLock.
	/// </summary>
	public enum EventCustomerEvaluationLockFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>PhysicianId. </summary>
		PhysicianId,
		///<summary>DateCreated. </summary>
		DateCreated,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerGiftCard.
	/// </summary>
	public enum EventCustomerGiftCardFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>GiftCardReceived. </summary>
		GiftCardReceived,
		///<summary>PatientSignatureFileId. </summary>
		PatientSignatureFileId,
		///<summary>TechnicianSignatureFileId. </summary>
		TechnicianSignatureFileId,
		///<summary>Version. </summary>
		Version,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerIcdCodes.
	/// </summary>
	public enum EventCustomerIcdCodesFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>IcdCodeId. </summary>
		IcdCodeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerNotification.
	/// </summary>
	public enum EventCustomerNotificationFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>NotificationId. </summary>
		NotificationId,
		///<summary>NotificationTypeId. </summary>
		NotificationTypeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerOrderDetail.
	/// </summary>
	public enum EventCustomerOrderDetailFieldIndex:int
	{
		///<summary>OrderDetailId. </summary>
		OrderDetailId,
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerPayment.
	/// </summary>
	public enum EventCustomerPaymentFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>OrderId. </summary>
		OrderId,
		///<summary>OrderCost. </summary>
		OrderCost,
		///<summary>OrderTotal. </summary>
		OrderTotal,
		///<summary>NetPayment. </summary>
		NetPayment,
		///<summary>DiscountAmount. </summary>
		DiscountAmount,
		///<summary>IsShipping. </summary>
		IsShipping,
		///<summary>IsPaid. </summary>
		IsPaid,
		///<summary>CouponCode. </summary>
		CouponCode,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerPdfgenerationErrorLog.
	/// </summary>
	public enum EventCustomerPdfgenerationErrorLogFieldIndex:int
	{
		///<summary>ErrorLogId. </summary>
		ErrorLogId,
		///<summary>ErrorMessage. </summary>
		ErrorMessage,
		///<summary>IsRectified. </summary>
		IsRectified,
		///<summary>EventCustomerResultId. </summary>
		EventCustomerResultId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerPreApprovedPackageTest.
	/// </summary>
	public enum EventCustomerPreApprovedPackageTestFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>TestId. </summary>
		TestId,
		///<summary>PackageId. </summary>
		PackageId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerPreApprovedTest.
	/// </summary>
	public enum EventCustomerPreApprovedTestFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>TestId. </summary>
		TestId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerPrimaryCarePhysician.
	/// </summary>
	public enum EventCustomerPrimaryCarePhysicianFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>PrimaryCarePhysicianId. </summary>
		PrimaryCarePhysicianId,
		///<summary>IsPcpAddressVerified. </summary>
		IsPcpAddressVerified,
		///<summary>PcpAddressVerifiedBy. </summary>
		PcpAddressVerifiedBy,
		///<summary>PcpAddressVerifiedOn. </summary>
		PcpAddressVerifiedOn,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerQuestionAnswer.
	/// </summary>
	public enum EventCustomerQuestionAnswerFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>QuestionId. </summary>
		QuestionId,
		///<summary>Answer. </summary>
		Answer,
		///<summary>Version. </summary>
		Version,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>UpdatedBy. </summary>
		UpdatedBy,
		///<summary>UpdatedDate. </summary>
		UpdatedDate,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>EventId. </summary>
		EventId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerRequiredTest.
	/// </summary>
	public enum EventCustomerRequiredTestFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>TestId. </summary>
		TestId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerResult.
	/// </summary>
	public enum EventCustomerResultFieldIndex:int
	{
		///<summary>EventCustomerResultId. </summary>
		EventCustomerResultId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>IsClinicalFormGenerated. </summary>
		IsClinicalFormGenerated,
		///<summary>IsResultPdfgenerated. </summary>
		IsResultPdfgenerated,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>ModifiedByOrgRoleUserId. </summary>
		ModifiedByOrgRoleUserId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>ResultState. </summary>
		ResultState,
		///<summary>IsPartial. </summary>
		IsPartial,
		///<summary>ResultSummary. </summary>
		ResultSummary,
		///<summary>PathwayRecommendation. </summary>
		PathwayRecommendation,
		///<summary>RegenerationDate. </summary>
		RegenerationDate,
		///<summary>RegeneratedBy. </summary>
		RegeneratedBy,
		///<summary>IsFasting. </summary>
		IsFasting,
		///<summary>IsRevertedToEvaluation. </summary>
		IsRevertedToEvaluation,
		///<summary>IsPennedBack. </summary>
		IsPennedBack,
		///<summary>SignedOffBy. </summary>
		SignedOffBy,
		///<summary>SignedOffOn. </summary>
		SignedOffOn,
		///<summary>VerifiedBy. </summary>
		VerifiedBy,
		///<summary>VerifiedOn. </summary>
		VerifiedOn,
		///<summary>CodedBy. </summary>
		CodedBy,
		///<summary>CodedOn. </summary>
		CodedOn,
		///<summary>AcesApprovedOn. </summary>
		AcesApprovedOn,
		///<summary>InvoiceDateUpdatedBy. </summary>
		InvoiceDateUpdatedBy,
		///<summary>IsIpResultGenerated. </summary>
		IsIpResultGenerated,
		///<summary>ChatPdfReviewedByPhysicianId. </summary>
		ChatPdfReviewedByPhysicianId,
		///<summary>ChatPdfReviewedByPhysicianDate. </summary>
		ChatPdfReviewedByPhysicianDate,
		///<summary>ChatPdfReviewedByOverreadPhysicianId. </summary>
		ChatPdfReviewedByOverreadPhysicianId,
		///<summary>ChatPdfReviewedByOverreadPhysicianDate. </summary>
		ChatPdfReviewedByOverreadPhysicianDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerResultBloodLab.
	/// </summary>
	public enum EventCustomerResultBloodLabFieldIndex:int
	{
		///<summary>EventCustomerResultId. </summary>
		EventCustomerResultId,
		///<summary>IsFromNewLab. </summary>
		IsFromNewLab,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedByOrgRoleUserid. </summary>
		CreatedByOrgRoleUserid,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerResultBloodLabParser.
	/// </summary>
	public enum EventCustomerResultBloodLabParserFieldIndex:int
	{
		///<summary>EventCustomerResultId. </summary>
		EventCustomerResultId,
		///<summary>BloodLabId. </summary>
		BloodLabId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerResultHistory.
	/// </summary>
	public enum EventCustomerResultHistoryFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>EventCustomerResultId. </summary>
		EventCustomerResultId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>IsClinicalFormGenerated. </summary>
		IsClinicalFormGenerated,
		///<summary>IsResultPdfgenerated. </summary>
		IsResultPdfgenerated,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>ModifiedByOrgRoleUserId. </summary>
		ModifiedByOrgRoleUserId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>ResultState. </summary>
		ResultState,
		///<summary>IsPartial. </summary>
		IsPartial,
		///<summary>ResultSummary. </summary>
		ResultSummary,
		///<summary>PathwayRecommendation. </summary>
		PathwayRecommendation,
		///<summary>RegenerationDate. </summary>
		RegenerationDate,
		///<summary>RegeneratedBy. </summary>
		RegeneratedBy,
		///<summary>IsFasting. </summary>
		IsFasting,
		///<summary>IsRevertedToEvaluation. </summary>
		IsRevertedToEvaluation,
		///<summary>IsPennedBack. </summary>
		IsPennedBack,
		///<summary>SignedOffBy. </summary>
		SignedOffBy,
		///<summary>SignedOffOn. </summary>
		SignedOffOn,
		///<summary>VerifiedBy. </summary>
		VerifiedBy,
		///<summary>VerifiedOn. </summary>
		VerifiedOn,
		///<summary>CodedBy. </summary>
		CodedBy,
		///<summary>CodedOn. </summary>
		CodedOn,
		///<summary>AcesApprovedOn. </summary>
		AcesApprovedOn,
		///<summary>InvoiceDateUpdatedBy. </summary>
		InvoiceDateUpdatedBy,
		///<summary>IsIpResultGenerated. </summary>
		IsIpResultGenerated,
		///<summary>ChatPdfReviewedByPhysicianId. </summary>
		ChatPdfReviewedByPhysicianId,
		///<summary>ChatPdfReviewedByPhysicianDate. </summary>
		ChatPdfReviewedByPhysicianDate,
		///<summary>ChatPdfReviewedByOverreadPhysicianId. </summary>
		ChatPdfReviewedByOverreadPhysicianId,
		///<summary>ChatPdfReviewedByOverreadPhysicianDate. </summary>
		ChatPdfReviewedByOverreadPhysicianDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerResultTrale.
	/// </summary>
	public enum EventCustomerResultTraleFieldIndex:int
	{
		///<summary>EventCustomerResultId. </summary>
		EventCustomerResultId,
		///<summary>ResponseId. </summary>
		ResponseId,
		///<summary>DateCreated. </summary>
		DateCreated,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerRetest.
	/// </summary>
	public enum EventCustomerRetestFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>TestId. </summary>
		TestId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>MailSentDate. </summary>
		MailSentDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomers.
	/// </summary>
	public enum EventCustomersFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>IsPaymentOnline. </summary>
		IsPaymentOnline,
		///<summary>AppointmentId. </summary>
		AppointmentId,
		///<summary>IsTestConducted. </summary>
		IsTestConducted,
		///<summary>BMailReports. </summary>
		BMailReports,
		///<summary>Notes. </summary>
		Notes,
		///<summary>NoShow. </summary>
		NoShow,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>OfflineCustomerId. </summary>
		OfflineCustomerId,
		///<summary>AffiliateCampaignId. </summary>
		AffiliateCampaignId,
		///<summary>SignInSource. </summary>
		SignInSource,
		///<summary>AdvocateId. </summary>
		AdvocateId,
		///<summary>Hipaastatus. </summary>
		Hipaastatus,
		///<summary>MarketingSource. </summary>
		MarketingSource,
		///<summary>ClickId. </summary>
		ClickId,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>PartnerRelease. </summary>
		PartnerRelease,
		///<summary>HospitalFacilityId. </summary>
		HospitalFacilityId,
		///<summary>AbnStatus. </summary>
		AbnStatus,
		///<summary>PcpConsentStatus. </summary>
		PcpConsentStatus,
		///<summary>InsuranceReleaseStatus. </summary>
		InsuranceReleaseStatus,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>AwvVisitId. </summary>
		AwvVisitId,
		///<summary>LeftWithoutScreeningReasonId. </summary>
		LeftWithoutScreeningReasonId,
		///<summary>EnableTexting. </summary>
		EnableTexting,
		///<summary>IsGiftCertificateDelivered. </summary>
		IsGiftCertificateDelivered,
		///<summary>GiftCode. </summary>
		GiftCode,
		///<summary>PatientDetailId. </summary>
		PatientDetailId,
		///<summary>LeftWithoutScreeningNotesId. </summary>
		LeftWithoutScreeningNotesId,
		///<summary>CustomerProfileHistoryId. </summary>
		CustomerProfileHistoryId,
		///<summary>IsAppointmentConfirmed. </summary>
		IsAppointmentConfirmed,
		///<summary>ConfirmedBy. </summary>
		ConfirmedBy,
		///<summary>IsForRetest. </summary>
		IsForRetest,
		///<summary>PreferredContactType. </summary>
		PreferredContactType,
		///<summary>GcNotGivenReasonId. </summary>
		GcNotGivenReasonId,
		///<summary>NoShowDate. </summary>
		NoShowDate,
		///<summary>SingleTestOverride. </summary>
		SingleTestOverride,
		///<summary>IsParticipationConsentSigned. </summary>
		IsParticipationConsentSigned,
		///<summary>IsPhysicianRecordRequestSigned. </summary>
		IsPhysicianRecordRequestSigned,
		///<summary>IsFluVaccineConsentSigned. </summary>
		IsFluVaccineConsentSigned,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventCustomerTestNotPerformedNotification.
	/// </summary>
	public enum EventCustomerTestNotPerformedNotificationFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>NotificationTypeId. </summary>
		NotificationTypeId,
		///<summary>TestId. </summary>
		TestId,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>DateCreated. </summary>
		DateCreated,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventFluConsentTemplate.
	/// </summary>
	public enum EventFluConsentTemplateFieldIndex:int
	{
		///<summary>EventId. </summary>
		EventId,
		///<summary>TemplateId. </summary>
		TemplateId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventHospitalFacility.
	/// </summary>
	public enum EventHospitalFacilityFieldIndex:int
	{
		///<summary>EventId. </summary>
		EventId,
		///<summary>HospitalFacilityId. </summary>
		HospitalFacilityId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventHospitalPartner.
	/// </summary>
	public enum EventHospitalPartnerFieldIndex:int
	{
		///<summary>EventId. </summary>
		EventId,
		///<summary>HospitalPartnerId. </summary>
		HospitalPartnerId,
		///<summary>AttachHospitalMaterial. </summary>
		AttachHospitalMaterial,
		///<summary>CaptureSsn. </summary>
		CaptureSsn,
		///<summary>RestrictEvaluation. </summary>
		RestrictEvaluation,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventHostPromotions.
	/// </summary>
	public enum EventHostPromotionsFieldIndex:int
	{
		///<summary>EventPromotionId. </summary>
		EventPromotionId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>BHostAllowPostersAndFlyers. </summary>
		BHostAllowPostersAndFlyers,
		///<summary>TotalPosters. </summary>
		TotalPosters,
		///<summary>TotalHostPosters. </summary>
		TotalHostPosters,
		///<summary>TotalRepPosters. </summary>
		TotalRepPosters,
		///<summary>BPosterPlacementDiscussedWithHost. </summary>
		BPosterPlacementDiscussedWithHost,
		///<summary>BHostWillPostAnnouncement. </summary>
		BHostWillPostAnnouncement,
		///<summary>BAnnouncementStartDate. </summary>
		BAnnouncementStartDate,
		///<summary>BAnnouncemcentEndDate. </summary>
		BAnnouncemcentEndDate,
		///<summary>BHostAllowBulletinInserts. </summary>
		BHostAllowBulletinInserts,
		///<summary>BInsertDate1. </summary>
		BInsertDate1,
		///<summary>BInsertDate2. </summary>
		BInsertDate2,
		///<summary>NumberofInserts. </summary>
		NumberofInserts,
		///<summary>BHostAllowVerbalAnnnouncements. </summary>
		BHostAllowVerbalAnnnouncements,
		///<summary>BVerbalAnnouncementByRepresentative. </summary>
		BVerbalAnnouncementByRepresentative,
		///<summary>BVerbalAnnouncementBySalesRep. </summary>
		BVerbalAnnouncementBySalesRep,
		///<summary>VerbalAnnouncementBySalesRepDate. </summary>
		VerbalAnnouncementBySalesRepDate,
		///<summary>BHostAllowsDirectMailsToMembers. </summary>
		BHostAllowsDirectMailsToMembers,
		///<summary>BProvidedWithMailingInformation. </summary>
		BProvidedWithMailingInformation,
		///<summary>DirectMailingListArrivalDate. </summary>
		DirectMailingListArrivalDate,
		///<summary>BHostAllowEmailingtheMembersOfTheOrganisation. </summary>
		BHostAllowEmailingtheMembersOfTheOrganisation,
		///<summary>DateEmailsProvided. </summary>
		DateEmailsProvided,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventMarketingOffers.
	/// </summary>
	public enum EventMarketingOffersFieldIndex:int
	{
		///<summary>EventMarketingOfferId. </summary>
		EventMarketingOfferId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>MarketingOfferId. </summary>
		MarketingOfferId,
		///<summary>NumberOfTimesUsed. </summary>
		NumberOfTimesUsed,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventMeetingDetails.
	/// </summary>
	public enum EventMeetingDetailsFieldIndex:int
	{
		///<summary>EventId. </summary>
		EventId,
		///<summary>MeetingId. </summary>
		MeetingId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventNote.
	/// </summary>
	public enum EventNoteFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Note. </summary>
		Note,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>EventDateFrom. </summary>
		EventDateFrom,
		///<summary>EventDateTo. </summary>
		EventDateTo,
		///<summary>IsPublished. </summary>
		IsPublished,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>PodId. </summary>
		PodId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventNotesLog.
	/// </summary>
	public enum EventNotesLogFieldIndex:int
	{
		///<summary>EventNoteId. </summary>
		EventNoteId,
		///<summary>EventId. </summary>
		EventId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventNotification.
	/// </summary>
	public enum EventNotificationFieldIndex:int
	{
		///<summary>EventId. </summary>
		EventId,
		///<summary>NotificationId. </summary>
		NotificationId,
		///<summary>IsForCorporateAccount. </summary>
		IsForCorporateAccount,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventPackageDetails.
	/// </summary>
	public enum EventPackageDetailsFieldIndex:int
	{
		///<summary>EventPackageId. </summary>
		EventPackageId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>PackageId. </summary>
		PackageId,
		///<summary>PackagePrice. </summary>
		PackagePrice,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>AvailableThroughOnline. </summary>
		AvailableThroughOnline,
		///<summary>AvailableThroughCallCenter. </summary>
		AvailableThroughCallCenter,
		///<summary>AvailableThroughTechnician. </summary>
		AvailableThroughTechnician,
		///<summary>AvailableThroughAdmin. </summary>
		AvailableThroughAdmin,
		///<summary>ScreeningTime. </summary>
		ScreeningTime,
		///<summary>HafTemplateId. </summary>
		HafTemplateId,
		///<summary>IsRecommended. </summary>
		IsRecommended,
		///<summary>Gender. </summary>
		Gender,
		///<summary>MostPopular. </summary>
		MostPopular,
		///<summary>BestValue. </summary>
		BestValue,
		///<summary>PodRoomId. </summary>
		PodRoomId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventPackageOrderItem.
	/// </summary>
	public enum EventPackageOrderItemFieldIndex:int
	{
		///<summary>OrderItemId. </summary>
		OrderItemId,
		///<summary>EventPackageId. </summary>
		EventPackageId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventPackageTest.
	/// </summary>
	public enum EventPackageTestFieldIndex:int
	{
		///<summary>EventPackageId. </summary>
		EventPackageId,
		///<summary>EventTestId. </summary>
		EventTestId,
		///<summary>Price. </summary>
		Price,
		///<summary>RefundPrice. </summary>
		RefundPrice,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventPaymentDetails.
	/// </summary>
	public enum EventPaymentDetailsFieldIndex:int
	{
		///<summary>EventPaymentId. </summary>
		EventPaymentId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>PaymentId. </summary>
		PaymentId,
		///<summary>PayReceivedUserId. </summary>
		PayReceivedUserId,
		///<summary>IsOnsite. </summary>
		IsOnsite,
		///<summary>EventPackageId. </summary>
		EventPackageId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventPerformanceMailStatus.
	/// </summary>
	public enum EventPerformanceMailStatusFieldIndex:int
	{
		///<summary>SalesRepEventId. </summary>
		SalesRepEventId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>MailCount. </summary>
		MailCount,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsEventSlot. </summary>
		IsEventSlot,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventPhysicianTest.
	/// </summary>
	public enum EventPhysicianTestFieldIndex:int
	{
		///<summary>EventId. </summary>
		EventId,
		///<summary>PhysicianId. </summary>
		PhysicianId,
		///<summary>TestId. </summary>
		TestId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>AssignedByOrgRoleUserId. </summary>
		AssignedByOrgRoleUserId,
		///<summary>ModifiedByOrgRoleUserId. </summary>
		ModifiedByOrgRoleUserId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventPod.
	/// </summary>
	public enum EventPodFieldIndex:int
	{
		///<summary>EventPodId. </summary>
		EventPodId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>PodId. </summary>
		PodId,
		///<summary>TerritoryId. </summary>
		TerritoryId,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>EnableKynIntegration. </summary>
		EnableKynIntegration,
		///<summary>IsBloodworkFormAttached. </summary>
		IsBloodworkFormAttached,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventPodRoom.
	/// </summary>
	public enum EventPodRoomFieldIndex:int
	{
		///<summary>EventPodRoomId. </summary>
		EventPodRoomId,
		///<summary>EventPodId. </summary>
		EventPodId,
		///<summary>RoomNo. </summary>
		RoomNo,
		///<summary>Duration. </summary>
		Duration,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventPodRoomTest.
	/// </summary>
	public enum EventPodRoomTestFieldIndex:int
	{
		///<summary>EventPodRoomId. </summary>
		EventPodRoomId,
		///<summary>TestId. </summary>
		TestId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventProductExclusion.
	/// </summary>
	public enum EventProductExclusionFieldIndex:int
	{
		///<summary>EventId. </summary>
		EventId,
		///<summary>ProductId. </summary>
		ProductId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventProductType.
	/// </summary>
	public enum EventProductTypeFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>EventId. </summary>
		EventId,
		///<summary>ProductTypeId. </summary>
		ProductTypeId,
		///<summary>StartDate. </summary>
		StartDate,
		///<summary>EndDate. </summary>
		EndDate,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventPublication.
	/// </summary>
	public enum EventPublicationFieldIndex:int
	{
		///<summary>EventPublicationId. </summary>
		EventPublicationId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>PublicationName. </summary>
		PublicationName,
		///<summary>ContactName. </summary>
		ContactName,
		///<summary>Description. </summary>
		Description,
		///<summary>ContactInfo. </summary>
		ContactInfo,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Events.
	/// </summary>
	public enum EventsFieldIndex:int
	{
		///<summary>EventId. </summary>
		EventId,
		///<summary>EventName. </summary>
		EventName,
		///<summary>EventDate. </summary>
		EventDate,
		///<summary>EventStartTime. </summary>
		EventStartTime,
		///<summary>EventEndTime. </summary>
		EventEndTime,
		///<summary>TimeZone. </summary>
		TimeZone,
		///<summary>EventTypeId. </summary>
		EventTypeId,
		///<summary>ScheduleMethodId. </summary>
		ScheduleMethodId,
		///<summary>IsRescheduled. </summary>
		IsRescheduled,
		///<summary>CosttoUseHostSite. </summary>
		CosttoUseHostSite,
		///<summary>CommunicationModeId. </summary>
		CommunicationModeId,
		///<summary>EventNotes. </summary>
		EventNotes,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>Googleuri. </summary>
		Googleuri,
		///<summary>EventActivityTemplateId. </summary>
		EventActivityTemplateId,
		///<summary>InvitationCode. </summary>
		InvitationCode,
		///<summary>TeamArrivalTime. </summary>
		TeamArrivalTime,
		///<summary>TeamDepartureTime. </summary>
		TeamDepartureTime,
		///<summary>EventStatus. </summary>
		EventStatus,
		///<summary>IsSignoff. </summary>
		IsSignoff,
		///<summary>SignoffDatetime. </summary>
		SignoffDatetime,
		///<summary>UpdatedByOrganizationRoleUser. </summary>
		UpdatedByOrganizationRoleUser,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>AssignedToOrgRoleUserId. </summary>
		AssignedToOrgRoleUserId,
		///<summary>EventActivityOrgRoleUserId. </summary>
		EventActivityOrgRoleUserId,
		///<summary>SignOffOrgRoleUserId. </summary>
		SignOffOrgRoleUserId,
		///<summary>GenerateHealthAssesmentForm. </summary>
		GenerateHealthAssesmentForm,
		///<summary>EmrNotesId. </summary>
		EmrNotesId,
		///<summary>EnableAlaCarteOnline. </summary>
		EnableAlaCarteOnline,
		///<summary>EnableAlaCarteCallCenter. </summary>
		EnableAlaCarteCallCenter,
		///<summary>EnableAlaCarteTechnician. </summary>
		EnableAlaCarteTechnician,
		///<summary>IsDynamicScheduling. </summary>
		IsDynamicScheduling,
		///<summary>SlotInterval. </summary>
		SlotInterval,
		///<summary>ServerRooms. </summary>
		ServerRooms,
		///<summary>LunchStartTime. </summary>
		LunchStartTime,
		///<summary>LunchDuration. </summary>
		LunchDuration,
		///<summary>HafTemplateId. </summary>
		HafTemplateId,
		///<summary>NotifyResultReady. </summary>
		NotifyResultReady,
		///<summary>CaptureInsuranceId. </summary>
		CaptureInsuranceId,
		///<summary>InsuranceIdRequired. </summary>
		InsuranceIdRequired,
		///<summary>IsFemaleOnly. </summary>
		IsFemaleOnly,
		///<summary>GenerateKynXml. </summary>
		GenerateKynXml,
		///<summary>RecommendPackage. </summary>
		RecommendPackage,
		///<summary>AskPreQualifierQuestion. </summary>
		AskPreQualifierQuestion,
		///<summary>FixedGroupScreeningTime. </summary>
		FixedGroupScreeningTime,
		///<summary>BloodPackageTracking. </summary>
		BloodPackageTracking,
		///<summary>RecordsPackageTracking. </summary>
		RecordsPackageTracking,
		///<summary>EventCancellationReasonId. </summary>
		EventCancellationReasonId,
		///<summary>EnableForCallCenter. </summary>
		EnableForCallCenter,
		///<summary>EnableForTechnician. </summary>
		EnableForTechnician,
		///<summary>IsLocked. </summary>
		IsLocked,
		///<summary>IsPackageTimeOnly. </summary>
		IsPackageTimeOnly,
		///<summary>GenerateHkynXml. </summary>
		GenerateHkynXml,
		///<summary>GenerateMyBioCheckAssessment. </summary>
		GenerateMyBioCheckAssessment,
		///<summary>UpdatedByAdmin. </summary>
		UpdatedByAdmin,
		///<summary>IsManual. </summary>
		IsManual,
		///<summary>GenerateHealthAssesmentFormStatus. </summary>
		GenerateHealthAssesmentFormStatus,
		///<summary>AllowNonMammoPatients. </summary>
		AllowNonMammoPatients,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventScheduleTemplate.
	/// </summary>
	public enum EventScheduleTemplateFieldIndex:int
	{
		///<summary>EventScheduleTemplateId. </summary>
		EventScheduleTemplateId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>ScheduleTemplateId. </summary>
		ScheduleTemplateId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventSchedulingSlot.
	/// </summary>
	public enum EventSchedulingSlotFieldIndex:int
	{
		///<summary>SlotId. </summary>
		SlotId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>StartTime. </summary>
		StartTime,
		///<summary>EndTime. </summary>
		EndTime,
		///<summary>Reason. </summary>
		Reason,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>Status. </summary>
		Status,
		///<summary>EventPodRoomId. </summary>
		EventPodRoomId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventSlotAppointment.
	/// </summary>
	public enum EventSlotAppointmentFieldIndex:int
	{
		///<summary>SlotId. </summary>
		SlotId,
		///<summary>AppointmentId. </summary>
		AppointmentId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventStaffAssignment.
	/// </summary>
	public enum EventStaffAssignmentFieldIndex:int
	{
		///<summary>EventStaffAssignmentId. </summary>
		EventStaffAssignmentId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>PodId. </summary>
		PodId,
		///<summary>ScheduledStaffOrgRoleUserId. </summary>
		ScheduledStaffOrgRoleUserId,
		///<summary>ActualStaffOrgRoleUserId. </summary>
		ActualStaffOrgRoleUserId,
		///<summary>Notes. </summary>
		Notes,
		///<summary>StaffEventRoleId. </summary>
		StaffEventRoleId,
		///<summary>ScheduledOn. </summary>
		ScheduledOn,
		///<summary>ScheduledByOrgRoleUserId. </summary>
		ScheduledByOrgRoleUserId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventSurveyTemplate.
	/// </summary>
	public enum EventSurveyTemplateFieldIndex:int
	{
		///<summary>EventId. </summary>
		EventId,
		///<summary>SurveyTemplateId. </summary>
		SurveyTemplateId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventTaskDetails.
	/// </summary>
	public enum EventTaskDetailsFieldIndex:int
	{
		///<summary>EventId. </summary>
		EventId,
		///<summary>TaskId. </summary>
		TaskId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventTest.
	/// </summary>
	public enum EventTestFieldIndex:int
	{
		///<summary>EventTestId. </summary>
		EventTestId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>TestId. </summary>
		TestId,
		///<summary>Price. </summary>
		Price,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>RefundPrice. </summary>
		RefundPrice,
		///<summary>ShowInAlaCarte. </summary>
		ShowInAlaCarte,
		///<summary>ScreeningTime. </summary>
		ScreeningTime,
		///<summary>HafTemplateId. </summary>
		HafTemplateId,
		///<summary>WithPackagePrice. </summary>
		WithPackagePrice,
		///<summary>Gender. </summary>
		Gender,
		///<summary>GroupId. </summary>
		GroupId,
		///<summary>ReimbursementRate. </summary>
		ReimbursementRate,
		///<summary>IsTestReviewableByPhysician. </summary>
		IsTestReviewableByPhysician,
		///<summary>PreQualificationQuestionTemplateId. </summary>
		PreQualificationQuestionTemplateId,
		///<summary>ResultEntryTypeId. </summary>
		ResultEntryTypeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventTestOrderItem.
	/// </summary>
	public enum EventTestOrderItemFieldIndex:int
	{
		///<summary>OrderItemId. </summary>
		OrderItemId,
		///<summary>EventTestId. </summary>
		EventTestId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventType.
	/// </summary>
	public enum EventTypeFieldIndex:int
	{
		///<summary>EventTypeId. </summary>
		EventTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventZip.
	/// </summary>
	public enum EventZipFieldIndex:int
	{
		///<summary>EventId. </summary>
		EventId,
		///<summary>ZipId. </summary>
		ZipId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventZipProductType.
	/// </summary>
	public enum EventZipProductTypeFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>ZipId. </summary>
		ZipId,
		///<summary>ProductTypeId. </summary>
		ProductTypeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EventZipProductTypeSubstitute.
	/// </summary>
	public enum EventZipProductTypeSubstituteFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>ZipId. </summary>
		ZipId,
		///<summary>ProductTypeId. </summary>
		ProductTypeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ExitInterviewAnswer.
	/// </summary>
	public enum ExitInterviewAnswerFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>QuestionId. </summary>
		QuestionId,
		///<summary>Answer. </summary>
		Answer,
		///<summary>Version. </summary>
		Version,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ExitInterviewQuestion.
	/// </summary>
	public enum ExitInterviewQuestionFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Question. </summary>
		Question,
		///<summary>TypeId. </summary>
		TypeId,
		///<summary>Gender. </summary>
		Gender,
		///<summary>ParentId. </summary>
		ParentId,
		///<summary>ControlValues. </summary>
		ControlValues,
		///<summary>ControlValueDelimiter. </summary>
		ControlValueDelimiter,
		///<summary>Index. </summary>
		Index,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ExitInterviewSignature.
	/// </summary>
	public enum ExitInterviewSignatureFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>QuestionId. </summary>
		QuestionId,
		///<summary>SignatureFileId. </summary>
		SignatureFileId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>Version. </summary>
		Version,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ExportableReports.
	/// </summary>
	public enum ExportableReportsFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Name. </summary>
		Name,
		///<summary>Alias. </summary>
		Alias,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ExportableReportsQueue.
	/// </summary>
	public enum ExportableReportsQueueFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>ReportId. </summary>
		ReportId,
		///<summary>FilterData. </summary>
		FilterData,
		///<summary>RequestedBy. </summary>
		RequestedBy,
		///<summary>RequestedOn. </summary>
		RequestedOn,
		///<summary>FileId. </summary>
		FileId,
		///<summary>StartedOn. </summary>
		StartedOn,
		///<summary>EndedOn. </summary>
		EndedOn,
		///<summary>StatusId. </summary>
		StatusId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: File.
	/// </summary>
	public enum FileFieldIndex:int
	{
		///<summary>FileId. </summary>
		FileId,
		///<summary>Path. </summary>
		Path,
		///<summary>Type. </summary>
		Type,
		///<summary>Size. </summary>
		Size,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>IsArchived. </summary>
		IsArchived,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: FillEventCallQueue.
	/// </summary>
	public enum FillEventCallQueueFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Status. </summary>
		Status,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CallDate. </summary>
		CallDate,
		///<summary>EventIds. </summary>
		EventIds,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: FillEventCallQueueCriteriaAssignment.
	/// </summary>
	public enum FillEventCallQueueCriteriaAssignmentFieldIndex:int
	{
		///<summary>FillEventCallQueueId. </summary>
		FillEventCallQueueId,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: FluConsentAnswer.
	/// </summary>
	public enum FluConsentAnswerFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>QuestionId. </summary>
		QuestionId,
		///<summary>Answer. </summary>
		Answer,
		///<summary>Version. </summary>
		Version,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: FluConsentQuestion.
	/// </summary>
	public enum FluConsentQuestionFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Question. </summary>
		Question,
		///<summary>TypeId. </summary>
		TypeId,
		///<summary>Gender. </summary>
		Gender,
		///<summary>ParentId. </summary>
		ParentId,
		///<summary>ControlValues. </summary>
		ControlValues,
		///<summary>ControlValueDelimiter. </summary>
		ControlValueDelimiter,
		///<summary>Index. </summary>
		Index,
		///<summary>FluConsentQuestionType. </summary>
		FluConsentQuestionType,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: FluConsentSignature.
	/// </summary>
	public enum FluConsentSignatureFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>SignatureFileId. </summary>
		SignatureFileId,
		///<summary>ConsentSignedDate. </summary>
		ConsentSignedDate,
		///<summary>ClinicalProviderSignatureFileId. </summary>
		ClinicalProviderSignatureFileId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>Version. </summary>
		Version,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: FluConsentTemplate.
	/// </summary>
	public enum FluConsentTemplateFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Name. </summary>
		Name,
		///<summary>IsPublished. </summary>
		IsPublished,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: FluConsentTemplateQuestion.
	/// </summary>
	public enum FluConsentTemplateQuestionFieldIndex:int
	{
		///<summary>TemplateId. </summary>
		TemplateId,
		///<summary>QuestionId. </summary>
		QuestionId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: FraminghamCalculationSource.
	/// </summary>
	public enum FraminghamCalculationSourceFieldIndex:int
	{
		///<summary>CalculationSourceId. </summary>
		CalculationSourceId,
		///<summary>ReadingId. </summary>
		ReadingId,
		///<summary>MinValue. </summary>
		MinValue,
		///<summary>MaxValue. </summary>
		MaxValue,
		///<summary>MaleScore. </summary>
		MaleScore,
		///<summary>FemaleScore. </summary>
		FemaleScore,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: FraminghamScoreRange.
	/// </summary>
	public enum FraminghamScoreRangeFieldIndex:int
	{
		///<summary>ScoreRangeId. </summary>
		ScoreRangeId,
		///<summary>MinValue. </summary>
		MinValue,
		///<summary>MaxValue. </summary>
		MaxValue,
		///<summary>MaleRiskScore. </summary>
		MaleRiskScore,
		///<summary>FemaleRiskScore. </summary>
		FemaleRiskScore,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: FranchiseeApplication.
	/// </summary>
	public enum FranchiseeApplicationFieldIndex:int
	{
		///<summary>ApplicationId. </summary>
		ApplicationId,
		///<summary>BusinessName. </summary>
		BusinessName,
		///<summary>BusinessAddressId. </summary>
		BusinessAddressId,
		///<summary>ContactAddressId. </summary>
		ContactAddressId,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>MiddleName. </summary>
		MiddleName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>PhoneCell. </summary>
		PhoneCell,
		///<summary>PhoneHome. </summary>
		PhoneHome,
		///<summary>PhoneOffice. </summary>
		PhoneOffice,
		///<summary>Email1. </summary>
		Email1,
		///<summary>Email2. </summary>
		Email2,
		///<summary>Reference1Name. </summary>
		Reference1Name,
		///<summary>Reference1Email. </summary>
		Reference1Email,
		///<summary>Reference2Name. </summary>
		Reference2Name,
		///<summary>Reference2Email. </summary>
		Reference2Email,
		///<summary>Reference3Name. </summary>
		Reference3Name,
		///<summary>Reference3Email. </summary>
		Reference3Email,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>WorkFlowStageId. </summary>
		WorkFlowStageId,
		///<summary>WorkFlowStageTriggerId. </summary>
		WorkFlowStageTriggerId,
		///<summary>WorkFlowStageActivityTriggerId. </summary>
		WorkFlowStageActivityTriggerId,
		///<summary>BusinessPhone. </summary>
		BusinessPhone,
		///<summary>BusinessFax. </summary>
		BusinessFax,
		///<summary>BillingAddressId. </summary>
		BillingAddressId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: FranchiseeTerritory.
	/// </summary>
	public enum FranchiseeTerritoryFieldIndex:int
	{
		///<summary>OrganizationId. </summary>
		OrganizationId,
		///<summary>TerritoryId. </summary>
		TerritoryId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: FranchiseeWiringInstructions.
	/// </summary>
	public enum FranchiseeWiringInstructionsFieldIndex:int
	{
		///<summary>FranchisingWiringId. </summary>
		FranchisingWiringId,
		///<summary>Description. </summary>
		Description,
		///<summary>PaymentFrequencyId. </summary>
		PaymentFrequencyId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: GcNotGivenReason.
	/// </summary>
	public enum GcNotGivenReasonFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Name. </summary>
		Name,
		///<summary>Alias. </summary>
		Alias,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: GiftCertificate.
	/// </summary>
	public enum GiftCertificateFieldIndex:int
	{
		///<summary>GiftCertificateId. </summary>
		GiftCertificateId,
		///<summary>TypeId. </summary>
		TypeId,
		///<summary>ClaimCode. </summary>
		ClaimCode,
		///<summary>Amount. </summary>
		Amount,
		///<summary>FromName. </summary>
		FromName,
		///<summary>ToName. </summary>
		ToName,
		///<summary>Message. </summary>
		Message,
		///<summary>ExpirationDate. </summary>
		ExpirationDate,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>OrgazizationRoleUserCreatorId. </summary>
		OrgazizationRoleUserCreatorId,
		///<summary>ApplicablePackageId. </summary>
		ApplicablePackageId,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>ToEmail. </summary>
		ToEmail,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: GiftCertificateOrderItem.
	/// </summary>
	public enum GiftCertificateOrderItemFieldIndex:int
	{
		///<summary>OrderItemId. </summary>
		OrderItemId,
		///<summary>GiftCertificateId. </summary>
		GiftCertificateId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: GiftCertificatePayment.
	/// </summary>
	public enum GiftCertificatePaymentFieldIndex:int
	{
		///<summary>PaymentId. </summary>
		PaymentId,
		///<summary>GiftCertificateId. </summary>
		GiftCertificateId,
		///<summary>Amount. </summary>
		Amount,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: GiftCertificateType.
	/// </summary>
	public enum GiftCertificateTypeFieldIndex:int
	{
		///<summary>GiftCertificateTypeId. </summary>
		GiftCertificateTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>ImageId. </summary>
		ImageId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>OrganizationRoleUserCreatorId. </summary>
		OrganizationRoleUserCreatorId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: GlobalConfiguration.
	/// </summary>
	public enum GlobalConfigurationFieldIndex:int
	{
		///<summary>GlobalConfigurationId. </summary>
		GlobalConfigurationId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>Value. </summary>
		Value,
		///<summary>RoleTypeId. </summary>
		RoleTypeId,
		///<summary>UserId. </summary>
		UserId,
		///<summary>SettingGroupName. </summary>
		SettingGroupName,
		///<summary>DataType. </summary>
		DataType,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>Delimiter. </summary>
		Delimiter,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: GuardianDetails.
	/// </summary>
	public enum GuardianDetailsFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>RelationshipId. </summary>
		RelationshipId,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>MiddleName. </summary>
		MiddleName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>AddressId. </summary>
		AddressId,
		///<summary>PhoneCell. </summary>
		PhoneCell,
		///<summary>PhoneOffice. </summary>
		PhoneOffice,
		///<summary>PhoneHome. </summary>
		PhoneHome,
		///<summary>EmailId. </summary>
		EmailId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HafTemplate.
	/// </summary>
	public enum HafTemplateFieldIndex:int
	{
		///<summary>HaftemplateId. </summary>
		HaftemplateId,
		///<summary>Name. </summary>
		Name,
		///<summary>Type. </summary>
		Type,
		///<summary>IsDefault. </summary>
		IsDefault,
		///<summary>IsPublished. </summary>
		IsPublished,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>PublicationDate. </summary>
		PublicationDate,
		///<summary>Notes. </summary>
		Notes,
		///<summary>Category. </summary>
		Category,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HafTemplateQuestion.
	/// </summary>
	public enum HafTemplateQuestionFieldIndex:int
	{
		///<summary>HaftemplateId. </summary>
		HaftemplateId,
		///<summary>QuestionId. </summary>
		QuestionId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HcpcsCode.
	/// </summary>
	public enum HcpcsCodeFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Code. </summary>
		Code,
		///<summary>Description. </summary>
		Description,
		///<summary>Cost. </summary>
		Cost,
		///<summary>CopayCost. </summary>
		CopayCost,
		///<summary>IsRetired. </summary>
		IsRetired,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>ModifiedDate. </summary>
		ModifiedDate,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HealthPlanCallQueueCriteria.
	/// </summary>
	public enum HealthPlanCallQueueCriteriaFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CallQueueId. </summary>
		CallQueueId,
		///<summary>Percentage. </summary>
		Percentage,
		///<summary>NoOfDays. </summary>
		NoOfDays,
		///<summary>RoundOfCalls. </summary>
		RoundOfCalls,
		///<summary>StartDate. </summary>
		StartDate,
		///<summary>EndDate. </summary>
		EndDate,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CustomTags. </summary>
		CustomTags,
		///<summary>IsDefault. </summary>
		IsDefault,
		///<summary>IsQueueGenerated. </summary>
		IsQueueGenerated,
		///<summary>LastQueueGeneratedDate. </summary>
		LastQueueGeneratedDate,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>ModifiedByOrgRoleUserId. </summary>
		ModifiedByOrgRoleUserId,
		///<summary>ZipCode. </summary>
		ZipCode,
		///<summary>Radius. </summary>
		Radius,
		///<summary>IsDeleted. </summary>
		IsDeleted,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>CriteriaName. </summary>
		CriteriaName,
		///<summary>LanguageId. </summary>
		LanguageId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HealthPlanCallQueueCriteriaAssignment.
	/// </summary>
	public enum HealthPlanCallQueueCriteriaAssignmentFieldIndex:int
	{
		///<summary>CallQueueCustomerId. </summary>
		CallQueueCustomerId,
		///<summary>CallQueueId. </summary>
		CallQueueId,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HealthPlanCriteriaAssignment.
	/// </summary>
	public enum HealthPlanCriteriaAssignmentFieldIndex:int
	{
		///<summary>HealthPlanCriteriaId. </summary>
		HealthPlanCriteriaId,
		///<summary>AssignedToOrgRoleUserId. </summary>
		AssignedToOrgRoleUserId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>CustomTagId. </summary>
		CustomTagId,
		///<summary>StartDate. </summary>
		StartDate,
		///<summary>EndDate. </summary>
		EndDate,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HealthPlanCriteriaAssignmentUpload.
	/// </summary>
	public enum HealthPlanCriteriaAssignmentUploadFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>FileId. </summary>
		FileId,
		///<summary>UploadTime. </summary>
		UploadTime,
		///<summary>UploadedByOrgRoleUserId. </summary>
		UploadedByOrgRoleUserId,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HealthPlanCriteriaDirectMail.
	/// </summary>
	public enum HealthPlanCriteriaDirectMailFieldIndex:int
	{
		///<summary>CriteriaId. </summary>
		CriteriaId,
		///<summary>CampaignActivityId. </summary>
		CampaignActivityId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HealthPlanCriteriaTeamAssignment.
	/// </summary>
	public enum HealthPlanCriteriaTeamAssignmentFieldIndex:int
	{
		///<summary>HealthPlanCriteriaId. </summary>
		HealthPlanCriteriaId,
		///<summary>TeamId. </summary>
		TeamId,
		///<summary>StartDate. </summary>
		StartDate,
		///<summary>EndDate. </summary>
		EndDate,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HealthPlanEventZip.
	/// </summary>
	public enum HealthPlanEventZipFieldIndex:int
	{
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>AccountTag. </summary>
		AccountTag,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>IsQueueGenerated. </summary>
		IsQueueGenerated,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HealthPlanFillEventCallQueue.
	/// </summary>
	public enum HealthPlanFillEventCallQueueFieldIndex:int
	{
		///<summary>EventId. </summary>
		EventId,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HealthPlanRevenue.
	/// </summary>
	public enum HealthPlanRevenueFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>RevenueItemTypeId. </summary>
		RevenueItemTypeId,
		///<summary>DateFrom. </summary>
		DateFrom,
		///<summary>DateTo. </summary>
		DateTo,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>ModifiedDate. </summary>
		ModifiedDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HealthPlanRevenueItem.
	/// </summary>
	public enum HealthPlanRevenueItemFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>HealthPlanRevenueId. </summary>
		HealthPlanRevenueId,
		///<summary>PackageId. </summary>
		PackageId,
		///<summary>TestId. </summary>
		TestId,
		///<summary>Price. </summary>
		Price,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HealthQuestionDependencyRule.
	/// </summary>
	public enum HealthQuestionDependencyRuleFieldIndex:int
	{
		///<summary>QuestionId. </summary>
		QuestionId,
		///<summary>DependantQuestionId. </summary>
		DependantQuestionId,
		///<summary>DependencyRule. </summary>
		DependencyRule,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HospitalFacility.
	/// </summary>
	public enum HospitalFacilityFieldIndex:int
	{
		///<summary>HospitalFacilityId. </summary>
		HospitalFacilityId,
		///<summary>ContractId. </summary>
		ContractId,
		///<summary>ResultLetterFileId. </summary>
		ResultLetterFileId,
		///<summary>CannedMessage. </summary>
		CannedMessage,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HospitalFacilityCampaign.
	/// </summary>
	public enum HospitalFacilityCampaignFieldIndex:int
	{
		///<summary>FacilityCampaignId. </summary>
		FacilityCampaignId,
		///<summary>FacilityId. </summary>
		FacilityId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HospitalPartner.
	/// </summary>
	public enum HospitalPartnerFieldIndex:int
	{
		///<summary>HospitalPartnerId. </summary>
		HospitalPartnerId,
		///<summary>AssociatedPhoneNumber. </summary>
		AssociatedPhoneNumber,
		///<summary>AdvocateId. </summary>
		AdvocateId,
		///<summary>IsGlobal. </summary>
		IsGlobal,
		///<summary>NormalResultValidityPeriod. </summary>
		NormalResultValidityPeriod,
		///<summary>AbnormalResultValidityPeriod. </summary>
		AbnormalResultValidityPeriod,
		///<summary>CriticalResultValidityPeriod. </summary>
		CriticalResultValidityPeriod,
		///<summary>MailTransitDays. </summary>
		MailTransitDays,
		///<summary>HafTemplateId. </summary>
		HafTemplateId,
		///<summary>CannedMessage. </summary>
		CannedMessage,
		///<summary>CaptureSsn. </summary>
		CaptureSsn,
		///<summary>RecommendPackage. </summary>
		RecommendPackage,
		///<summary>AskPreQualificationQuestion. </summary>
		AskPreQualificationQuestion,
		///<summary>AttachDoctorLetter. </summary>
		AttachDoctorLetter,
		///<summary>RestrictEvaluation. </summary>
		RestrictEvaluation,
		///<summary>ShowOnlineShipping. </summary>
		ShowOnlineShipping,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HospitalPartnerCustomer.
	/// </summary>
	public enum HospitalPartnerCustomerFieldIndex:int
	{
		///<summary>HospitalPartnerCustomerId. </summary>
		HospitalPartnerCustomerId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Status. </summary>
		Status,
		///<summary>Outcome. </summary>
		Outcome,
		///<summary>CareCoordinatorOrgRoleUserId. </summary>
		CareCoordinatorOrgRoleUserId,
		///<summary>Notes. </summary>
		Notes,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>ModifiedByOrgRoleUserId. </summary>
		ModifiedByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HospitalPartnerEventNotes.
	/// </summary>
	public enum HospitalPartnerEventNotesFieldIndex:int
	{
		///<summary>NotesId. </summary>
		NotesId,
		///<summary>EventId. </summary>
		EventId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HospitalPartnerHospitalFacility.
	/// </summary>
	public enum HospitalPartnerHospitalFacilityFieldIndex:int
	{
		///<summary>HospitalPartnerId. </summary>
		HospitalPartnerId,
		///<summary>HospitalFacilityId. </summary>
		HospitalFacilityId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HospitalPartnerPackage.
	/// </summary>
	public enum HospitalPartnerPackageFieldIndex:int
	{
		///<summary>HospitalpartnerId. </summary>
		HospitalpartnerId,
		///<summary>PackageId. </summary>
		PackageId,
		///<summary>IsRecommended. </summary>
		IsRecommended,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HospitalPartnerShippingOption.
	/// </summary>
	public enum HospitalPartnerShippingOptionFieldIndex:int
	{
		///<summary>HospitalPartnerId. </summary>
		HospitalPartnerId,
		///<summary>ShippingOptionId. </summary>
		ShippingOptionId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HospitalPartnerTerritory.
	/// </summary>
	public enum HospitalPartnerTerritoryFieldIndex:int
	{
		///<summary>HospitalPartnerId. </summary>
		HospitalPartnerId,
		///<summary>TerritoryId. </summary>
		TerritoryId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HostAdvocateDetail.
	/// </summary>
	public enum HostAdvocateDetailFieldIndex:int
	{
		///<summary>HostId. </summary>
		HostId,
		///<summary>AffiliateId. </summary>
		AffiliateId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HostEventDetails.
	/// </summary>
	public enum HostEventDetailsFieldIndex:int
	{
		///<summary>HostEventId. </summary>
		HostEventId,
		///<summary>HostId. </summary>
		HostId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>BConfirmMinRequirements. </summary>
		BConfirmMinRequirements,
		///<summary>BConfirmedVisually. </summary>
		BConfirmedVisually,
		///<summary>ConfirmedVisuallyComments. </summary>
		ConfirmedVisuallyComments,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>DepositAmount. </summary>
		DepositAmount,
		///<summary>PayByCheck. </summary>
		PayByCheck,
		///<summary>PayByCreditCard. </summary>
		PayByCreditCard,
		///<summary>PaymentDueDate. </summary>
		PaymentDueDate,
		///<summary>DepositDueDate. </summary>
		DepositDueDate,
		///<summary>InstructionForCallCenter. </summary>
		InstructionForCallCenter,
		///<summary>IsHostRatedbyTechnician. </summary>
		IsHostRatedbyTechnician,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HostFacilityRanking.
	/// </summary>
	public enum HostFacilityRankingFieldIndex:int
	{
		///<summary>HostFacilityRankingId. </summary>
		HostFacilityRankingId,
		///<summary>HostId. </summary>
		HostId,
		///<summary>Ranking. </summary>
		Ranking,
		///<summary>RankedByRole. </summary>
		RankedByRole,
		///<summary>InternetAccess. </summary>
		InternetAccess,
		///<summary>NumberOfPlugPoint. </summary>
		NumberOfPlugPoint,
		///<summary>RoomSize. </summary>
		RoomSize,
		///<summary>RoomNeedsCleared. </summary>
		RoomNeedsCleared,
		///<summary>Notes. </summary>
		Notes,
		///<summary>RankedByOrganizationRoleUserId. </summary>
		RankedByOrganizationRoleUserId,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>IsCurrentForRole. </summary>
		IsCurrentForRole,
		///<summary>IsConfirmedVisually. </summary>
		IsConfirmedVisually,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HostImage.
	/// </summary>
	public enum HostImageFieldIndex:int
	{
		///<summary>HostId. </summary>
		HostId,
		///<summary>ImageId. </summary>
		ImageId,
		///<summary>HostImageType. </summary>
		HostImageType,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HostNotes.
	/// </summary>
	public enum HostNotesFieldIndex:int
	{
		///<summary>HostId. </summary>
		HostId,
		///<summary>CallCenterInstructions. </summary>
		CallCenterInstructions,
		///<summary>TechnicianInstructions. </summary>
		TechnicianInstructions,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HostPayment.
	/// </summary>
	public enum HostPaymentFieldIndex:int
	{
		///<summary>HostPaymentId. </summary>
		HostPaymentId,
		///<summary>IsDeposit. </summary>
		IsDeposit,
		///<summary>HostId. </summary>
		HostId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>Amount. </summary>
		Amount,
		///<summary>PaymentMode. </summary>
		PaymentMode,
		///<summary>PayableTo. </summary>
		PayableTo,
		///<summary>MailingOrganizationName. </summary>
		MailingOrganizationName,
		///<summary>MailingAttentionOf. </summary>
		MailingAttentionOf,
		///<summary>MailingAddressId. </summary>
		MailingAddressId,
		///<summary>DueDate. </summary>
		DueDate,
		///<summary>CreatorOrganizationRoleUserId. </summary>
		CreatorOrganizationRoleUserId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DepositType. </summary>
		DepositType,
		///<summary>DepositFullRefundDays. </summary>
		DepositFullRefundDays,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>Status. </summary>
		Status,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: HostPaymentTransaction.
	/// </summary>
	public enum HostPaymentTransactionFieldIndex:int
	{
		///<summary>HostPaymentId. </summary>
		HostPaymentId,
		///<summary>TransactionType. </summary>
		TransactionType,
		///<summary>PaymentMethod. </summary>
		PaymentMethod,
		///<summary>Amount. </summary>
		Amount,
		///<summary>Notes. </summary>
		Notes,
		///<summary>TransactionDate. </summary>
		TransactionDate,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: IcdCodes.
	/// </summary>
	public enum IcdCodesFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>IcdCode. </summary>
		IcdCode,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: IflocationMaster.
	/// </summary>
	public enum IflocationMasterFieldIndex:int
	{
		///<summary>LocationId. </summary>
		LocationId,
		///<summary>Label. </summary>
		Label,
		///<summary>IncidentalFindingsId. </summary>
		IncidentalFindingsId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: IncidentalFindingIncidentalFindingReadingGroup.
	/// </summary>
	public enum IncidentalFindingIncidentalFindingReadingGroupFieldIndex:int
	{
		///<summary>IncidentalFindingId. </summary>
		IncidentalFindingId,
		///<summary>GroupId. </summary>
		GroupId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: IncidentalFindingReadingGroup.
	/// </summary>
	public enum IncidentalFindingReadingGroupFieldIndex:int
	{
		///<summary>GroupId. </summary>
		GroupId,
		///<summary>GroupName. </summary>
		GroupName,
		///<summary>DisplayControlType. </summary>
		DisplayControlType,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: IncidentalFindingReadingGroupItem.
	/// </summary>
	public enum IncidentalFindingReadingGroupItemFieldIndex:int
	{
		///<summary>GroupItemId. </summary>
		GroupItemId,
		///<summary>GroupId. </summary>
		GroupId,
		///<summary>Label. </summary>
		Label,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: IncidentalFindings.
	/// </summary>
	public enum IncidentalFindingsFieldIndex:int
	{
		///<summary>IncidentalFindingsId. </summary>
		IncidentalFindingsId,
		///<summary>Label. </summary>
		Label,
		///<summary>Description. </summary>
		Description,
		///<summary>LocationCount. </summary>
		LocationCount,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>DateCreated. </summary>
		DateCreated,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: IncomingPhoneNumberResolverRule.
	/// </summary>
	public enum IncomingPhoneNumberResolverRuleFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>MarketingMaterialTypeId. </summary>
		MarketingMaterialTypeId,
		///<summary>AdvocateTypeId. </summary>
		AdvocateTypeId,
		///<summary>AdvocateId. </summary>
		AdvocateId,
		///<summary>Tag. </summary>
		Tag,
		///<summary>PhoneNumber. </summary>
		PhoneNumber,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: InsuranceCompany.
	/// </summary>
	public enum InsuranceCompanyFieldIndex:int
	{
		///<summary>InsuranceCompanyId. </summary>
		InsuranceCompanyId,
		///<summary>Code. </summary>
		Code,
		///<summary>Name. </summary>
		Name,
		///<summary>EdiPayerNumber. </summary>
		EdiPayerNumber,
		///<summary>Address. </summary>
		Address,
		///<summary>InNetwork. </summary>
		InNetwork,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: InsurancePayment.
	/// </summary>
	public enum InsurancePaymentFieldIndex:int
	{
		///<summary>InsurancePaymentId. </summary>
		InsurancePaymentId,
		///<summary>PaymentId. </summary>
		PaymentId,
		///<summary>AmountToBePaid. </summary>
		AmountToBePaid,
		///<summary>Amount. </summary>
		Amount,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: InsuranceServiceType.
	/// </summary>
	public enum InsuranceServiceTypeFieldIndex:int
	{
		///<summary>InsuranceServiceTypeId. </summary>
		InsuranceServiceTypeId,
		///<summary>Code. </summary>
		Code,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: InventoryItem.
	/// </summary>
	public enum InventoryItemFieldIndex:int
	{
		///<summary>InventoryItemId. </summary>
		InventoryItemId,
		///<summary>Name. </summary>
		Name,
		///<summary>ItemType. </summary>
		ItemType,
		///<summary>Description. </summary>
		Description,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>Count. </summary>
		Count,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: InventoryItemTest.
	/// </summary>
	public enum InventoryItemTestFieldIndex:int
	{
		///<summary>InventoryItemTestId. </summary>
		InventoryItemTestId,
		///<summary>InventoryItemId. </summary>
		InventoryItemId,
		///<summary>TestId. </summary>
		TestId,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Item.
	/// </summary>
	public enum ItemFieldIndex:int
	{
		///<summary>ItemId. </summary>
		ItemId,
		///<summary>InventoryItemId. </summary>
		InventoryItemId,
		///<summary>ItemCode. </summary>
		ItemCode,
		///<summary>Skucode. </summary>
		Skucode,
		///<summary>ManufacturerName. </summary>
		ManufacturerName,
		///<summary>ManufacturerId. </summary>
		ManufacturerId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsAllocated. </summary>
		IsAllocated,
		///<summary>Notes. </summary>
		Notes,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ItemType.
	/// </summary>
	public enum ItemTypeFieldIndex:int
	{
		///<summary>ItemTypeId. </summary>
		ItemTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsTestAssociated. </summary>
		IsTestAssociated,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: KynLabValues.
	/// </summary>
	public enum KynLabValuesFieldIndex:int
	{
		///<summary>EventCustomerResultId. </summary>
		EventCustomerResultId,
		///<summary>Glucose. </summary>
		Glucose,
		///<summary>TotalCholesterol. </summary>
		TotalCholesterol,
		///<summary>Triglycerides. </summary>
		Triglycerides,
		///<summary>Hdl. </summary>
		Hdl,
		///<summary>FastingStatus. </summary>
		FastingStatus,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>ModifiedByOrgRoleUserId. </summary>
		ModifiedByOrgRoleUserId,
		///<summary>ManualSystolic. </summary>
		ManualSystolic,
		///<summary>ManualDiastolic. </summary>
		ManualDiastolic,
		///<summary>TestId. </summary>
		TestId,
		///<summary>A1c. </summary>
		A1c,
		///<summary>BodyFat. </summary>
		BodyFat,
		///<summary>BoneDensity. </summary>
		BoneDensity,
		///<summary>Psa. </summary>
		Psa,
		///<summary>NonHdlCholestrol. </summary>
		NonHdlCholestrol,
		///<summary>Nicotine. </summary>
		Nicotine,
		///<summary>Cotinine. </summary>
		Cotinine,
		///<summary>Smoker. </summary>
		Smoker,
		///<summary>LdlCholestrol. </summary>
		LdlCholestrol,
		///<summary>Notes. </summary>
		Notes,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Lab.
	/// </summary>
	public enum LabFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Name. </summary>
		Name,
		///<summary>Alias. </summary>
		Alias,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Language.
	/// </summary>
	public enum LanguageFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Name. </summary>
		Name,
		///<summary>Alias. </summary>
		Alias,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: LanguageBarrierCallQueue.
	/// </summary>
	public enum LanguageBarrierCallQueueFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Status. </summary>
		Status,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CallDate. </summary>
		CallDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: LanguageBarrierCallQueueCriteriaAssignment.
	/// </summary>
	public enum LanguageBarrierCallQueueCriteriaAssignmentFieldIndex:int
	{
		///<summary>LanguageBarrierCallQueueId. </summary>
		LanguageBarrierCallQueueId,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: LoginOtp.
	/// </summary>
	public enum LoginOtpFieldIndex:int
	{
		///<summary>UserLoginId. </summary>
		UserLoginId,
		///<summary>Otp. </summary>
		Otp,
		///<summary>AttemptCount. </summary>
		AttemptCount,
		///<summary>DateCreated. </summary>
		DateCreated,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: LoginSettings.
	/// </summary>
	public enum LoginSettingsFieldIndex:int
	{
		///<summary>UserLoginId. </summary>
		UserLoginId,
		///<summary>GoogleAuthenticatorSecretKey. </summary>
		GoogleAuthenticatorSecretKey,
		///<summary>DownloadFilePin. </summary>
		DownloadFilePin,
		///<summary>AuthenticationModeId. </summary>
		AuthenticationModeId,
		///<summary>IsFirstLogin. </summary>
		IsFirstLogin,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: LoincCrosswalk.
	/// </summary>
	public enum LoincCrosswalkFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>LoincNumber. </summary>
		LoincNumber,
		///<summary>Component. </summary>
		Component,
		///<summary>System. </summary>
		System,
		///<summary>MethodType. </summary>
		MethodType,
		///<summary>VersionLastChanged. </summary>
		VersionLastChanged,
		///<summary>DefinitionDescription. </summary>
		DefinitionDescription,
		///<summary>Formula. </summary>
		Formula,
		///<summary>Species. </summary>
		Species,
		///<summary>ExampleAnswers. </summary>
		ExampleAnswers,
		///<summary>SurveyQuestionText. </summary>
		SurveyQuestionText,
		///<summary>SurveyQuestionSource. </summary>
		SurveyQuestionSource,
		///<summary>UnitsRequired. </summary>
		UnitsRequired,
		///<summary>SubmittedUnits. </summary>
		SubmittedUnits,
		///<summary>CdiscCommonTests. </summary>
		CdiscCommonTests,
		///<summary>Hl7FieldSubfieldId. </summary>
		Hl7FieldSubfieldId,
		///<summary>ExternalCopyrightNotice. </summary>
		ExternalCopyrightNotice,
		///<summary>ExampleUnits. </summary>
		ExampleUnits,
		///<summary>LongCommonName. </summary>
		LongCommonName,
		///<summary>UploadId. </summary>
		UploadId,
		///<summary>Year. </summary>
		Year,
		///<summary>DateCreated. </summary>
		DateCreated,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: LoincLabData.
	/// </summary>
	public enum LoincLabDataFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>MemberId. </summary>
		MemberId,
		///<summary>Gmpi. </summary>
		Gmpi,
		///<summary>Loinc. </summary>
		Loinc,
		///<summary>LoincDescription. </summary>
		LoincDescription,
		///<summary>ResultValue. </summary>
		ResultValue,
		///<summary>ResultUnits. </summary>
		ResultUnits,
		///<summary>RefRange. </summary>
		RefRange,
		///<summary>UploadId. </summary>
		UploadId,
		///<summary>Year. </summary>
		Year,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateOfService. </summary>
		DateOfService,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Lookup.
	/// </summary>
	public enum LookupFieldIndex:int
	{
		///<summary>LookupId. </summary>
		LookupId,
		///<summary>LookupTypeId. </summary>
		LookupTypeId,
		///<summary>Alias. </summary>
		Alias,
		///<summary>DisplayName. </summary>
		DisplayName,
		///<summary>Description. </summary>
		Description,
		///<summary>RelativeOrder. </summary>
		RelativeOrder,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>DataRecorderCreatorId. </summary>
		DataRecorderCreatorId,
		///<summary>DataRecorderModifierId. </summary>
		DataRecorderModifierId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: LookupType.
	/// </summary>
	public enum LookupTypeFieldIndex:int
	{
		///<summary>LookupTypeId. </summary>
		LookupTypeId,
		///<summary>Alias. </summary>
		Alias,
		///<summary>DisplayName. </summary>
		DisplayName,
		///<summary>Description. </summary>
		Description,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MailRoundCallQueue.
	/// </summary>
	public enum MailRoundCallQueueFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Status. </summary>
		Status,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CallDate. </summary>
		CallDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MailRoundCallQueueCriteriaAssignment.
	/// </summary>
	public enum MailRoundCallQueueCriteriaAssignmentFieldIndex:int
	{
		///<summary>MailRoundCallQueueId. </summary>
		MailRoundCallQueueId,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MarketingOfferRoleMapping.
	/// </summary>
	public enum MarketingOfferRoleMappingFieldIndex:int
	{
		///<summary>MarketingOfferRoleMappingId. </summary>
		MarketingOfferRoleMappingId,
		///<summary>MarketingOfferId. </summary>
		MarketingOfferId,
		///<summary>RoleId. </summary>
		RoleId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MarketingOffers.
	/// </summary>
	public enum MarketingOffersFieldIndex:int
	{
		///<summary>MarketingOfferId. </summary>
		MarketingOfferId,
		///<summary>MarketingOfferTypeId. </summary>
		MarketingOfferTypeId,
		///<summary>IsGlobal. </summary>
		IsGlobal,
		///<summary>IsPercentage. </summary>
		IsPercentage,
		///<summary>DiscountType. </summary>
		DiscountType,
		///<summary>MarketingOfferValue. </summary>
		MarketingOfferValue,
		///<summary>MarketingOfferDescription. </summary>
		MarketingOfferDescription,
		///<summary>IsFree. </summary>
		IsFree,
		///<summary>IsEventbased. </summary>
		IsEventbased,
		///<summary>MinimumPurchaseAmount. </summary>
		MinimumPurchaseAmount,
		///<summary>CreatedUserId. </summary>
		CreatedUserId,
		///<summary>ValidityStartDate. </summary>
		ValidityStartDate,
		///<summary>ValidityEndDate. </summary>
		ValidityEndDate,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>MaximumNumberTimesUsed. </summary>
		MaximumNumberTimesUsed,
		///<summary>MarketingOfferCode. </summary>
		MarketingOfferCode,
		///<summary>CustomerRange. </summary>
		CustomerRange,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MarketingOfferSignUpMode.
	/// </summary>
	public enum MarketingOfferSignUpModeFieldIndex:int
	{
		///<summary>MarketingOfferSignUpModeId. </summary>
		MarketingOfferSignUpModeId,
		///<summary>MarketingOfferId. </summary>
		MarketingOfferId,
		///<summary>SignUpMode. </summary>
		SignUpMode,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MarketingOfferType.
	/// </summary>
	public enum MarketingOfferTypeFieldIndex:int
	{
		///<summary>MarketingOfferTypeId. </summary>
		MarketingOfferTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>IsEventCoupon. </summary>
		IsEventCoupon,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MarketingOrderShippingInfo.
	/// </summary>
	public enum MarketingOrderShippingInfoFieldIndex:int
	{
		///<summary>MarketingOrderShippingInfoId. </summary>
		MarketingOrderShippingInfoId,
		///<summary>OrganizationName. </summary>
		OrganizationName,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>MiddleName. </summary>
		MiddleName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>Address1. </summary>
		Address1,
		///<summary>Address2. </summary>
		Address2,
		///<summary>City. </summary>
		City,
		///<summary>State. </summary>
		State,
		///<summary>ZipCode. </summary>
		ZipCode,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>PhoneNumber. </summary>
		PhoneNumber,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MarketingPrintOrder.
	/// </summary>
	public enum MarketingPrintOrderFieldIndex:int
	{
		///<summary>MarketingPrintOrderId. </summary>
		MarketingPrintOrderId,
		///<summary>OrderDate. </summary>
		OrderDate,
		///<summary>Status. </summary>
		Status,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>DatePlaced. </summary>
		DatePlaced,
		///<summary>DateAssigned. </summary>
		DateAssigned,
		///<summary>FranchiseeOrganizationId. </summary>
		FranchiseeOrganizationId,
		///<summary>PrintVendorOrganizationId. </summary>
		PrintVendorOrganizationId,
		///<summary>OrgRoleUserId. </summary>
		OrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MarketingPrintOrderEventMapping.
	/// </summary>
	public enum MarketingPrintOrderEventMappingFieldIndex:int
	{
		///<summary>MarketingPrintOrderEventId. </summary>
		MarketingPrintOrderEventId,
		///<summary>MarketingPrintOrderId. </summary>
		MarketingPrintOrderId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MarketingPrintOrderItem.
	/// </summary>
	public enum MarketingPrintOrderItemFieldIndex:int
	{
		///<summary>MarketingPrintOrderItemId. </summary>
		MarketingPrintOrderItemId,
		///<summary>MarketingPrintOrderId. </summary>
		MarketingPrintOrderId,
		///<summary>MarketingMaterialId. </summary>
		MarketingMaterialId,
		///<summary>PhoneNumber. </summary>
		PhoneNumber,
		///<summary>Sourcecode. </summary>
		Sourcecode,
		///<summary>Quantity. </summary>
		Quantity,
		///<summary>ShippingMethod. </summary>
		ShippingMethod,
		///<summary>Logo. </summary>
		Logo,
		///<summary>MarketingOrderShippingInfoId. </summary>
		MarketingOrderShippingInfoId,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>AffiliateId. </summary>
		AffiliateId,
		///<summary>SourceCodeId. </summary>
		SourceCodeId,
		///<summary>Status. </summary>
		Status,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MarketingPrintOrderProspectListMapping.
	/// </summary>
	public enum MarketingPrintOrderProspectListMappingFieldIndex:int
	{
		///<summary>MarketingPrintOrderProspectLlistMappingId. </summary>
		MarketingPrintOrderProspectLlistMappingId,
		///<summary>MarketingPrintOrderItemId. </summary>
		MarketingPrintOrderItemId,
		///<summary>ProspectFileId. </summary>
		ProspectFileId,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MarketingSource.
	/// </summary>
	public enum MarketingSourceFieldIndex:int
	{
		///<summary>MarketingSourceId. </summary>
		MarketingSourceId,
		///<summary>Label. </summary>
		Label,
		///<summary>Notes. </summary>
		Notes,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>ShowOnline. </summary>
		ShowOnline,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MarketingSourceTerritory.
	/// </summary>
	public enum MarketingSourceTerritoryFieldIndex:int
	{
		///<summary>MarketingSourceId. </summary>
		MarketingSourceId,
		///<summary>TerritoryId. </summary>
		TerritoryId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MedicalHistoryReadingAssosciation.
	/// </summary>
	public enum MedicalHistoryReadingAssosciationFieldIndex:int
	{
		///<summary>ReadingId. </summary>
		ReadingId,
		///<summary>MedicalHistoryQuestionId. </summary>
		MedicalHistoryQuestionId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MedicalVendorProfile.
	/// </summary>
	public enum MedicalVendorProfileFieldIndex:int
	{
		///<summary>OrganizationId. </summary>
		OrganizationId,
		///<summary>TypeId. </summary>
		TypeId,
		///<summary>ContractId. </summary>
		ContractId,
		///<summary>IsHospitalPartner. </summary>
		IsHospitalPartner,
		///<summary>ResultLetterCoBrandingFileId. </summary>
		ResultLetterCoBrandingFileId,
		///<summary>DoctorLetterFileId. </summary>
		DoctorLetterFileId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MedicalVendorType.
	/// </summary>
	public enum MedicalVendorTypeFieldIndex:int
	{
		///<summary>MedicalVendorTypeId. </summary>
		MedicalVendorTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MedicareGroupDependencyRule.
	/// </summary>
	public enum MedicareGroupDependencyRuleFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>QuestionId. </summary>
		QuestionId,
		///<summary>DependentGroupId. </summary>
		DependentGroupId,
		///<summary>DependencyValue. </summary>
		DependencyValue,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MedicareQuestion.
	/// </summary>
	public enum MedicareQuestionFieldIndex:int
	{
		///<summary>QuestionId. </summary>
		QuestionId,
		///<summary>GroupId. </summary>
		GroupId,
		///<summary>Question. </summary>
		Question,
		///<summary>ControlValue. </summary>
		ControlValue,
		///<summary>ControlType. </summary>
		ControlType,
		///<summary>Delimiter. </summary>
		Delimiter,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsRequired. </summary>
		IsRequired,
		///<summary>DisplaySequence. </summary>
		DisplaySequence,
		///<summary>ParentQuestionId. </summary>
		ParentQuestionId,
		///<summary>IsDefault. </summary>
		IsDefault,
		///<summary>DefaultValue. </summary>
		DefaultValue,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MedicareQuestionDependencyRule.
	/// </summary>
	public enum MedicareQuestionDependencyRuleFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>QuestionId. </summary>
		QuestionId,
		///<summary>DependentQuestionId. </summary>
		DependentQuestionId,
		///<summary>DependencyValue. </summary>
		DependencyValue,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MedicareQuestionGroup.
	/// </summary>
	public enum MedicareQuestionGroupFieldIndex:int
	{
		///<summary>GroupId. </summary>
		GroupId,
		///<summary>GroupName. </summary>
		GroupName,
		///<summary>GroupAlias. </summary>
		GroupAlias,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsDefault. </summary>
		IsDefault,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MedicareQuestionsRemarks.
	/// </summary>
	public enum MedicareQuestionsRemarksFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>QuestionId. </summary>
		QuestionId,
		///<summary>QuestionValue. </summary>
		QuestionValue,
		///<summary>DependentQuestionId. </summary>
		DependentQuestionId,
		///<summary>DependentQuestionValue. </summary>
		DependentQuestionValue,
		///<summary>CombinedQuestionId. </summary>
		CombinedQuestionId,
		///<summary>CombinedQuestionValue. </summary>
		CombinedQuestionValue,
		///<summary>IsDefault. </summary>
		IsDefault,
		///<summary>Remarks. </summary>
		Remarks,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Medication.
	/// </summary>
	public enum MedicationFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>ServiceDate. </summary>
		ServiceDate,
		///<summary>Hicn. </summary>
		Hicn,
		///<summary>MemberId. </summary>
		MemberId,
		///<summary>MemberDob. </summary>
		MemberDob,
		///<summary>NdcProductCode. </summary>
		NdcProductCode,
		///<summary>ProprietaryName. </summary>
		ProprietaryName,
		///<summary>Dose. </summary>
		Dose,
		///<summary>Unit. </summary>
		Unit,
		///<summary>Frequency. </summary>
		Frequency,
		///<summary>IsPrescribed. </summary>
		IsPrescribed,
		///<summary>IsOtc. </summary>
		IsOtc,
		///<summary>Indication. </summary>
		Indication,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsManual. </summary>
		IsManual,
		///<summary>IsSynced. </summary>
		IsSynced,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MedicationUpload.
	/// </summary>
	public enum MedicationUploadFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>FileId. </summary>
		FileId,
		///<summary>StatusId. </summary>
		StatusId,
		///<summary>SuccessfullUploadCount. </summary>
		SuccessfullUploadCount,
		///<summary>FailedUploadCount. </summary>
		FailedUploadCount,
		///<summary>UploadTime. </summary>
		UploadTime,
		///<summary>UploadedBy. </summary>
		UploadedBy,
		///<summary>ParseStartTime. </summary>
		ParseStartTime,
		///<summary>ParseEndTime. </summary>
		ParseEndTime,
		///<summary>LogFileId. </summary>
		LogFileId,
		///<summary>TotalCount. </summary>
		TotalCount,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MedicationUploadLog.
	/// </summary>
	public enum MedicationUploadLogFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>MedicationUploadId. </summary>
		MedicationUploadId,
		///<summary>ServiceDate. </summary>
		ServiceDate,
		///<summary>CmsHicn. </summary>
		CmsHicn,
		///<summary>MemberId. </summary>
		MemberId,
		///<summary>MemberDob. </summary>
		MemberDob,
		///<summary>NdcProductCode. </summary>
		NdcProductCode,
		///<summary>IsSuccessFull. </summary>
		IsSuccessFull,
		///<summary>ErrorMessage. </summary>
		ErrorMessage,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MemberUploadLog.
	/// </summary>
	public enum MemberUploadLogFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>CorporateUploadId. </summary>
		CorporateUploadId,
		///<summary>IsCustomerZipInvalid. </summary>
		IsCustomerZipInvalid,
		///<summary>IsPcpzipInvalid. </summary>
		IsPcpzipInvalid,
		///<summary>IsPcpmailingZipInvalid. </summary>
		IsPcpmailingZipInvalid,
		///<summary>NewInsertedZipIds. </summary>
		NewInsertedZipIds,
		///<summary>NewInsertedCityIds. </summary>
		NewInsertedCityIds,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MemberUploadParseDetail.
	/// </summary>
	public enum MemberUploadParseDetailFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CorporateUploadId. </summary>
		CorporateUploadId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>MemberId. </summary>
		MemberId,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>MiddleName. </summary>
		MiddleName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>Gender. </summary>
		Gender,
		///<summary>Dob. </summary>
		Dob,
		///<summary>Email. </summary>
		Email,
		///<summary>AlternateEmail. </summary>
		AlternateEmail,
		///<summary>PhoneCell. </summary>
		PhoneCell,
		///<summary>PhoneHome. </summary>
		PhoneHome,
		///<summary>Address1. </summary>
		Address1,
		///<summary>Address2. </summary>
		Address2,
		///<summary>City. </summary>
		City,
		///<summary>State. </summary>
		State,
		///<summary>Zip. </summary>
		Zip,
		///<summary>Hicn. </summary>
		Hicn,
		///<summary>PcpFirstName. </summary>
		PcpFirstName,
		///<summary>PcpLastName. </summary>
		PcpLastName,
		///<summary>PcpPhone. </summary>
		PcpPhone,
		///<summary>PcpFax. </summary>
		PcpFax,
		///<summary>PcpEmail. </summary>
		PcpEmail,
		///<summary>PcpAddress1. </summary>
		PcpAddress1,
		///<summary>PcpAddress2. </summary>
		PcpAddress2,
		///<summary>PcpCity. </summary>
		PcpCity,
		///<summary>PcpState. </summary>
		PcpState,
		///<summary>PcpZip. </summary>
		PcpZip,
		///<summary>PcpNpi. </summary>
		PcpNpi,
		///<summary>PreApprovedTest. </summary>
		PreApprovedTest,
		///<summary>IsEligible. </summary>
		IsEligible,
		///<summary>TargetYear. </summary>
		TargetYear,
		///<summary>Language. </summary>
		Language,
		///<summary>Lab. </summary>
		Lab,
		///<summary>Copay. </summary>
		Copay,
		///<summary>MedicareAdvantagePlanName. </summary>
		MedicareAdvantagePlanName,
		///<summary>Lpi. </summary>
		Lpi,
		///<summary>Market. </summary>
		Market,
		///<summary>Mrn. </summary>
		Mrn,
		///<summary>GroupName. </summary>
		GroupName,
		///<summary>IcdCodes. </summary>
		IcdCodes,
		///<summary>PreApprovedPackage. </summary>
		PreApprovedPackage,
		///<summary>PreApprovedPackageId. </summary>
		PreApprovedPackageId,
		///<summary>PcpmailingAddress1. </summary>
		PcpmailingAddress1,
		///<summary>PcpmailingAddress2. </summary>
		PcpmailingAddress2,
		///<summary>PcpmailingCity. </summary>
		PcpmailingCity,
		///<summary>PcpmailingState. </summary>
		PcpmailingState,
		///<summary>PcpmailingZip. </summary>
		PcpmailingZip,
		///<summary>CurrentMedication. </summary>
		CurrentMedication,
		///<summary>CurrentMedicationSource. </summary>
		CurrentMedicationSource,
		///<summary>AdditionalField1. </summary>
		AdditionalField1,
		///<summary>AdditionalField2. </summary>
		AdditionalField2,
		///<summary>AdditionalField3. </summary>
		AdditionalField3,
		///<summary>AdditionalField4. </summary>
		AdditionalField4,
		///<summary>Activity. </summary>
		Activity,
		///<summary>PredictedZip. </summary>
		PredictedZip,
		///<summary>Mbi. </summary>
		Mbi,
		///<summary>BillingMemberId. </summary>
		BillingMemberId,
		///<summary>BillingMemberPlan. </summary>
		BillingMemberPlan,
		///<summary>BillingMemberPlanYear. </summary>
		BillingMemberPlanYear,
		///<summary>WarmTransferAllowed. </summary>
		WarmTransferAllowed,
		///<summary>WarmTransferYear. </summary>
		WarmTransferYear,
		///<summary>AcesId. </summary>
		AcesId,
		///<summary>EligibilityYear. </summary>
		EligibilityYear,
		///<summary>ErrorMessage. </summary>
		ErrorMessage,
		///<summary>IsSuccessful. </summary>
		IsSuccessful,
		///<summary>Dnc. </summary>
		Dnc,
		///<summary>ProductType. </summary>
		ProductType,
		///<summary>AcesClientId. </summary>
		AcesClientId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MergeCustomerUpload.
	/// </summary>
	public enum MergeCustomerUploadFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>FileId. </summary>
		FileId,
		///<summary>StatusId. </summary>
		StatusId,
		///<summary>UploadedBy. </summary>
		UploadedBy,
		///<summary>UploadTime. </summary>
		UploadTime,
		///<summary>SuccessUploadCount. </summary>
		SuccessUploadCount,
		///<summary>FailedUploadCount. </summary>
		FailedUploadCount,
		///<summary>ParseStartTime. </summary>
		ParseStartTime,
		///<summary>ParseEndTime. </summary>
		ParseEndTime,
		///<summary>LogFileId. </summary>
		LogFileId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MergeCustomerUploadLog.
	/// </summary>
	public enum MergeCustomerUploadLogFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>UploadId. </summary>
		UploadId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>DuplicateCustomerId. </summary>
		DuplicateCustomerId,
		///<summary>StatusId. </summary>
		StatusId,
		///<summary>IsSuccessful. </summary>
		IsSuccessful,
		///<summary>ErrorMessage. </summary>
		ErrorMessage,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MolinaAttestation.
	/// </summary>
	public enum MolinaAttestationFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>EventCustomerResultId. </summary>
		EventCustomerResultId,
		///<summary>Icd9Code. </summary>
		Icd9Code,
		///<summary>Icd9CodeDescription. </summary>
		Icd9CodeDescription,
		///<summary>Icd10Code. </summary>
		Icd10Code,
		///<summary>Icd10CodeDescription. </summary>
		Icd10CodeDescription,
		///<summary>Condition. </summary>
		Condition,
		///<summary>StatusId. </summary>
		StatusId,
		///<summary>WhyNoDiagnosis. </summary>
		WhyNoDiagnosis,
		///<summary>DateResolved. </summary>
		DateResolved,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MVPaymentCheckDetails.
	/// </summary>
	public enum MVPaymentCheckDetailsFieldIndex:int
	{
		///<summary>CheckId. </summary>
		CheckId,
		///<summary>MvpaymentId. </summary>
		MvpaymentId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: MvuserClassification.
	/// </summary>
	public enum MvuserClassificationFieldIndex:int
	{
		///<summary>MvuserClassificationId. </summary>
		MvuserClassificationId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Ndc.
	/// </summary>
	public enum NdcFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>ProductName. </summary>
		ProductName,
		///<summary>NdcCode. </summary>
		NdcCode,
		///<summary>Route. </summary>
		Route,
		///<summary>Dose. </summary>
		Dose,
		///<summary>ActiveNumeratorStrength. </summary>
		ActiveNumeratorStrength,
		///<summary>ActiveIngredUnit. </summary>
		ActiveIngredUnit,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: NoShowCallQueue.
	/// </summary>
	public enum NoShowCallQueueFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Status. </summary>
		Status,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CallDate. </summary>
		CallDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: NoShowCallQueueCriteriaAssignment.
	/// </summary>
	public enum NoShowCallQueueCriteriaAssignmentFieldIndex:int
	{
		///<summary>NoShowCallQueueId. </summary>
		NoShowCallQueueId,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Note.
	/// </summary>
	public enum NoteFieldIndex:int
	{
		///<summary>NoteId. </summary>
		NoteId,
		///<summary>Note. </summary>
		Note,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: NotesDetails.
	/// </summary>
	public enum NotesDetailsFieldIndex:int
	{
		///<summary>NoteId. </summary>
		NoteId,
		///<summary>Notes. </summary>
		Notes,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>Active. </summary>
		Active,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>ModifiedByOrgRoleUserId. </summary>
		ModifiedByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Notification.
	/// </summary>
	public enum NotificationFieldIndex:int
	{
		///<summary>NotificationId. </summary>
		NotificationId,
		///<summary>UserId. </summary>
		UserId,
		///<summary>NotificationDate. </summary>
		NotificationDate,
		///<summary>NotificationMediumId. </summary>
		NotificationMediumId,
		///<summary>NotificationTypeId. </summary>
		NotificationTypeId,
		///<summary>ClientLabel. </summary>
		ClientLabel,
		///<summary>Priority. </summary>
		Priority,
		///<summary>AttemptCount. </summary>
		AttemptCount,
		///<summary>ServiceStatus. </summary>
		ServiceStatus,
		///<summary>ServicedDate. </summary>
		ServicedDate,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>Notes. </summary>
		Notes,
		///<summary>RequestedByOrgRoleUserId. </summary>
		RequestedByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: NotificationEmail.
	/// </summary>
	public enum NotificationEmailFieldIndex:int
	{
		///<summary>NotificationEmailId. </summary>
		NotificationEmailId,
		///<summary>ToEmail. </summary>
		ToEmail,
		///<summary>Subject. </summary>
		Subject,
		///<summary>Body. </summary>
		Body,
		///<summary>FromEmail. </summary>
		FromEmail,
		///<summary>FromName. </summary>
		FromName,
		///<summary>OpenedDate. </summary>
		OpenedDate,
		///<summary>OpenCount. </summary>
		OpenCount,
		///<summary>AttachmentPath. </summary>
		AttachmentPath,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: NotificationMedium.
	/// </summary>
	public enum NotificationMediumFieldIndex:int
	{
		///<summary>NotificationMediumId. </summary>
		NotificationMediumId,
		///<summary>NotificationMedium. </summary>
		NotificationMedium,
		///<summary>Description. </summary>
		Description,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: NotificationPhone.
	/// </summary>
	public enum NotificationPhoneFieldIndex:int
	{
		///<summary>NotificationPhoneId. </summary>
		NotificationPhoneId,
		///<summary>PhoneCell. </summary>
		PhoneCell,
		///<summary>Message. </summary>
		Message,
		///<summary>ServicedBy. </summary>
		ServicedBy,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: NotificationSubscribers.
	/// </summary>
	public enum NotificationSubscribersFieldIndex:int
	{
		///<summary>NotificationSubscriberId. </summary>
		NotificationSubscriberId,
		///<summary>NotificationTypeId. </summary>
		NotificationTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>Email. </summary>
		Email,
		///<summary>Phone. </summary>
		Phone,
		///<summary>UserId. </summary>
		UserId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: NotificationType.
	/// </summary>
	public enum NotificationTypeFieldIndex:int
	{
		///<summary>NotificationTypeId. </summary>
		NotificationTypeId,
		///<summary>NotificationTypeName. </summary>
		NotificationTypeName,
		///<summary>NotificationTypeNameAlias. </summary>
		NotificationTypeNameAlias,
		///<summary>Description. </summary>
		Description,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>NoOfAttempts. </summary>
		NoOfAttempts,
		///<summary>NotificationMediumId. </summary>
		NotificationMediumId,
		///<summary>AllowTemplateCreation. </summary>
		AllowTemplateCreation,
		///<summary>IsServiceEnabled. </summary>
		IsServiceEnabled,
		///<summary>IsQueuingEnabled. </summary>
		IsQueuingEnabled,
		///<summary>ModifiedByOrgRoleUserId. </summary>
		ModifiedByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Order.
	/// </summary>
	public enum OrderFieldIndex:int
	{
		///<summary>OrderId. </summary>
		OrderId,
		///<summary>Type. </summary>
		Type,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>OrganizationRoleUserCreatorId. </summary>
		OrganizationRoleUserCreatorId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: OrderDetail.
	/// </summary>
	public enum OrderDetailFieldIndex:int
	{
		///<summary>OrderDetailId. </summary>
		OrderDetailId,
		///<summary>OrderId. </summary>
		OrderId,
		///<summary>ForOrganizationRoleUserId. </summary>
		ForOrganizationRoleUserId,
		///<summary>OrderItemId. </summary>
		OrderItemId,
		///<summary>Description. </summary>
		Description,
		///<summary>Quantity. </summary>
		Quantity,
		///<summary>Price. </summary>
		Price,
		///<summary>Status. </summary>
		Status,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>OrganizationRoleUserCreatorId. </summary>
		OrganizationRoleUserCreatorId,
		///<summary>SourceId. </summary>
		SourceId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: OrderItem.
	/// </summary>
	public enum OrderItemFieldIndex:int
	{
		///<summary>OrderItemId. </summary>
		OrderItemId,
		///<summary>Type. </summary>
		Type,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Organization.
	/// </summary>
	public enum OrganizationFieldIndex:int
	{
		///<summary>OrganizationId. </summary>
		OrganizationId,
		///<summary>OrganizationTypeId. </summary>
		OrganizationTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>BusinessAddressId. </summary>
		BusinessAddressId,
		///<summary>BillingAddressId. </summary>
		BillingAddressId,
		///<summary>PhoneNumber. </summary>
		PhoneNumber,
		///<summary>FaxNumber. </summary>
		FaxNumber,
		///<summary>Email. </summary>
		Email,
		///<summary>LogoImageId. </summary>
		LogoImageId,
		///<summary>TeamImageId. </summary>
		TeamImageId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>ModifiedByOrgRoleUserId. </summary>
		ModifiedByOrgRoleUserId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: OrganizationRoleUser.
	/// </summary>
	public enum OrganizationRoleUserFieldIndex:int
	{
		///<summary>OrganizationRoleUserId. </summary>
		OrganizationRoleUserId,
		///<summary>UserId. </summary>
		UserId,
		///<summary>RoleId. </summary>
		RoleId,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>OrganizationId. </summary>
		OrganizationId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: OrganizationRoleUserTerritory.
	/// </summary>
	public enum OrganizationRoleUserTerritoryFieldIndex:int
	{
		///<summary>TerritoryId. </summary>
		TerritoryId,
		///<summary>OrganizationRoleUserId. </summary>
		OrganizationRoleUserId,
		///<summary>EventTypeSetupPermission. </summary>
		EventTypeSetupPermission,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: OrganizationType.
	/// </summary>
	public enum OrganizationTypeFieldIndex:int
	{
		///<summary>OrganizationTypeId. </summary>
		OrganizationTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>Alias. </summary>
		Alias,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: OrgRoleUserActivity.
	/// </summary>
	public enum OrgRoleUserActivityFieldIndex:int
	{
		///<summary>ActivityId. </summary>
		ActivityId,
		///<summary>OrgRoleUserId. </summary>
		OrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: OutboundUpload.
	/// </summary>
	public enum OutboundUploadFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>FileId. </summary>
		FileId,
		///<summary>TypeId. </summary>
		TypeId,
		///<summary>StatusId. </summary>
		StatusId,
		///<summary>SuccessUploadCount. </summary>
		SuccessUploadCount,
		///<summary>FailedUploadCount. </summary>
		FailedUploadCount,
		///<summary>UploadTime. </summary>
		UploadTime,
		///<summary>ParseStartTime. </summary>
		ParseStartTime,
		///<summary>ParseEndTime. </summary>
		ParseEndTime,
		///<summary>LogFileId. </summary>
		LogFileId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Package.
	/// </summary>
	public enum PackageFieldIndex:int
	{
		///<summary>PackageId. </summary>
		PackageId,
		///<summary>PackageName. </summary>
		PackageName,
		///<summary>Description. </summary>
		Description,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>Price. </summary>
		Price,
		///<summary>PackageTypeId. </summary>
		PackageTypeId,
		///<summary>RelativeOrder. </summary>
		RelativeOrder,
		///<summary>DescriptiononPublicWebsite. </summary>
		DescriptiononPublicWebsite,
		///<summary>IsSelectedByDefaultForEvent. </summary>
		IsSelectedByDefaultForEvent,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>UpdatedByOrgRoleUserId. </summary>
		UpdatedByOrgRoleUserId,
		///<summary>ForOrderDisplayFileId. </summary>
		ForOrderDisplayFileId,
		///<summary>PackageInfoUrl. </summary>
		PackageInfoUrl,
		///<summary>DescriptiononUpsellSection. </summary>
		DescriptiononUpsellSection,
		///<summary>ScreeningTime. </summary>
		ScreeningTime,
		///<summary>HafTemplateId. </summary>
		HafTemplateId,
		///<summary>Gender. </summary>
		Gender,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PackageAvailabilityToRoles.
	/// </summary>
	public enum PackageAvailabilityToRolesFieldIndex:int
	{
		///<summary>PackageId. </summary>
		PackageId,
		///<summary>RoleId. </summary>
		RoleId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PackageMarketingOfferDiscount.
	/// </summary>
	public enum PackageMarketingOfferDiscountFieldIndex:int
	{
		///<summary>PackageMarketingOfferDiscountId. </summary>
		PackageMarketingOfferDiscountId,
		///<summary>PackageId. </summary>
		PackageId,
		///<summary>MarketingOfferId. </summary>
		MarketingOfferId,
		///<summary>Discount. </summary>
		Discount,
		///<summary>IsPercentage. </summary>
		IsPercentage,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PackageSourceCodeDiscount.
	/// </summary>
	public enum PackageSourceCodeDiscountFieldIndex:int
	{
		///<summary>PackageId. </summary>
		PackageId,
		///<summary>SourceCodeId. </summary>
		SourceCodeId,
		///<summary>Discount. </summary>
		Discount,
		///<summary>IsPercentage. </summary>
		IsPercentage,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PackageTest.
	/// </summary>
	public enum PackageTestFieldIndex:int
	{
		///<summary>PackageId. </summary>
		PackageId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>TestId. </summary>
		TestId,
		///<summary>Price. </summary>
		Price,
		///<summary>RefundPrice. </summary>
		RefundPrice,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ParticipationConsentSignature.
	/// </summary>
	public enum ParticipationConsentSignatureFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>SignatureFileId. </summary>
		SignatureFileId,
		///<summary>ConsentSignedDate. </summary>
		ConsentSignedDate,
		///<summary>InsuranceSignatureFileId. </summary>
		InsuranceSignatureFileId,
		///<summary>InsuranceConsentSignedDate. </summary>
		InsuranceConsentSignedDate,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>Version. </summary>
		Version,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PasswordChangelog.
	/// </summary>
	public enum PasswordChangelogFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>UserLoginId. </summary>
		UserLoginId,
		///<summary>Password. </summary>
		Password,
		///<summary>Salt. </summary>
		Salt,
		///<summary>Sequence. </summary>
		Sequence,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Payment.
	/// </summary>
	public enum PaymentFieldIndex:int
	{
		///<summary>PaymentId. </summary>
		PaymentId,
		///<summary>Notes. </summary>
		Notes,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>OrganizationRoleUserCreatorId. </summary>
		OrganizationRoleUserCreatorId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PaymentFrequency.
	/// </summary>
	public enum PaymentFrequencyFieldIndex:int
	{
		///<summary>PaymentFrequencyId. </summary>
		PaymentFrequencyId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>FrequencyName. </summary>
		FrequencyName,
		///<summary>Interval. </summary>
		Interval,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PaymentInstructions.
	/// </summary>
	public enum PaymentInstructionsFieldIndex:int
	{
		///<summary>PaymentInstructionId. </summary>
		PaymentInstructionId,
		///<summary>Description. </summary>
		Description,
		///<summary>PaymentFrequencyId. </summary>
		PaymentFrequencyId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>BankName. </summary>
		BankName,
		///<summary>RoutingNumber. </summary>
		RoutingNumber,
		///<summary>AccountType. </summary>
		AccountType,
		///<summary>AccountHolderName. </summary>
		AccountHolderName,
		///<summary>PaymentMode. </summary>
		PaymentMode,
		///<summary>AccountNumber. </summary>
		AccountNumber,
		///<summary>Memo. </summary>
		Memo,
		///<summary>SpecialInstructions. </summary>
		SpecialInstructions,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PaymentOrder.
	/// </summary>
	public enum PaymentOrderFieldIndex:int
	{
		///<summary>OrderId. </summary>
		OrderId,
		///<summary>PaymentId. </summary>
		PaymentId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PaymentType.
	/// </summary>
	public enum PaymentTypeFieldIndex:int
	{
		///<summary>PaymentTypeId. </summary>
		PaymentTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>Alias. </summary>
		Alias,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PayPeriod.
	/// </summary>
	public enum PayPeriodFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Name. </summary>
		Name,
		///<summary>StartDate. </summary>
		StartDate,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>ModifiedOn. </summary>
		ModifiedOn,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsPublished. </summary>
		IsPublished,
		///<summary>NumberOfWeeks. </summary>
		NumberOfWeeks,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PayPeriodCriteria.
	/// </summary>
	public enum PayPeriodCriteriaFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>PayPeriodId. </summary>
		PayPeriodId,
		///<summary>MinCustomer. </summary>
		MinCustomer,
		///<summary>MaxCustomer. </summary>
		MaxCustomer,
		///<summary>TypeId. </summary>
		TypeId,
		///<summary>Ammount. </summary>
		Ammount,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PcpAppointment.
	/// </summary>
	public enum PcpAppointmentFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>AppointmentOn. </summary>
		AppointmentOn,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>ModifiedOn. </summary>
		ModifiedOn,
		///<summary>PreferredContactMethod. </summary>
		PreferredContactMethod,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PcpDisposition.
	/// </summary>
	public enum PcpDispositionFieldIndex:int
	{
		///<summary>PcpDispositionId. </summary>
		PcpDispositionId,
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>DispositionId. </summary>
		DispositionId,
		///<summary>Notes. </summary>
		Notes,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>ModifiedOn. </summary>
		ModifiedOn,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PhysicianCustomerAssignment.
	/// </summary>
	public enum PhysicianCustomerAssignmentFieldIndex:int
	{
		///<summary>PhysicianId. </summary>
		PhysicianId,
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>OverReadPhysicianId. </summary>
		OverReadPhysicianId,
		///<summary>AssignedByOrgRoleUserId. </summary>
		AssignedByOrgRoleUserId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>Notes. </summary>
		Notes,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PhysicianCustomerPayRate.
	/// </summary>
	public enum PhysicianCustomerPayRateFieldIndex:int
	{
		///<summary>PhysicianId. </summary>
		PhysicianId,
		///<summary>StandardRate. </summary>
		StandardRate,
		///<summary>OverReadRate. </summary>
		OverReadRate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PhysicianEarnings.
	/// </summary>
	public enum PhysicianEarningsFieldIndex:int
	{
		///<summary>PhysicianEarningId. </summary>
		PhysicianEarningId,
		///<summary>PhysicianEvaluationId. </summary>
		PhysicianEvaluationId,
		///<summary>PhysicianId. </summary>
		PhysicianId,
		///<summary>AmountEarned. </summary>
		AmountEarned,
		///<summary>DataRecoderCreatorId. </summary>
		DataRecoderCreatorId,
		///<summary>DataRecoderModifierId. </summary>
		DataRecoderModifierId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModifed. </summary>
		DateModifed,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PhysicianEvaluation.
	/// </summary>
	public enum PhysicianEvaluationFieldIndex:int
	{
		///<summary>PhysicianEvaluationId. </summary>
		PhysicianEvaluationId,
		///<summary>PhysicianId. </summary>
		PhysicianId,
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>EvaluationStartTime. </summary>
		EvaluationStartTime,
		///<summary>EvaluationEndTime. </summary>
		EvaluationEndTime,
		///<summary>Ipaddress. </summary>
		Ipaddress,
		///<summary>IsPrimaryEvaluator. </summary>
		IsPrimaryEvaluator,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PhysicianEventAssignment.
	/// </summary>
	public enum PhysicianEventAssignmentFieldIndex:int
	{
		///<summary>PhysicianId. </summary>
		PhysicianId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>OverReadPhysicianId. </summary>
		OverReadPhysicianId,
		///<summary>AssignedByOrgRoleUserId. </summary>
		AssignedByOrgRoleUserId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>Notes. </summary>
		Notes,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PhysicianInvoice.
	/// </summary>
	public enum PhysicianInvoiceFieldIndex:int
	{
		///<summary>PhysicianInvoiceId. </summary>
		PhysicianInvoiceId,
		///<summary>PhysicianId. </summary>
		PhysicianId,
		///<summary>PhysicianName. </summary>
		PhysicianName,
		///<summary>ApprovalGuid. </summary>
		ApprovalGuid,
		///<summary>ApprovalStatus. </summary>
		ApprovalStatus,
		///<summary>PaymentStatus. </summary>
		PaymentStatus,
		///<summary>MedicalVendorName. </summary>
		MedicalVendorName,
		///<summary>MedicalVendorAddress. </summary>
		MedicalVendorAddress,
		///<summary>PayPeriodStartDate. </summary>
		PayPeriodStartDate,
		///<summary>PayPeriodEndDate. </summary>
		PayPeriodEndDate,
		///<summary>DateGenerated. </summary>
		DateGenerated,
		///<summary>DateApproved. </summary>
		DateApproved,
		///<summary>DatePaid. </summary>
		DatePaid,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PhysicianInvoiceItem.
	/// </summary>
	public enum PhysicianInvoiceItemFieldIndex:int
	{
		///<summary>PhysicianInvoiceItemId. </summary>
		PhysicianInvoiceItemId,
		///<summary>PhysicianInvoiceId. </summary>
		PhysicianInvoiceId,
		///<summary>PhysicianEvaluationId. </summary>
		PhysicianEvaluationId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>ReviewDate. </summary>
		ReviewDate,
		///<summary>EventDate. </summary>
		EventDate,
		///<summary>PodName. </summary>
		PodName,
		///<summary>EventName. </summary>
		EventName,
		///<summary>CustomerName. </summary>
		CustomerName,
		///<summary>PackageName. </summary>
		PackageName,
		///<summary>AmountEarned. </summary>
		AmountEarned,
		///<summary>PodId. </summary>
		PodId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PhysicianLabTest.
	/// </summary>
	public enum PhysicianLabTestFieldIndex:int
	{
		///<summary>LabTestLicenseId. </summary>
		LabTestLicenseId,
		///<summary>PhysicianId. </summary>
		PhysicianId,
		///<summary>StateId. </summary>
		StateId,
		///<summary>IfobtLicenseNo. </summary>
		IfobtLicenseNo,
		///<summary>MicroalbumineLicenseNo. </summary>
		MicroalbumineLicenseNo,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsDefault. </summary>
		IsDefault,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PhysicianLicense.
	/// </summary>
	public enum PhysicianLicenseFieldIndex:int
	{
		///<summary>LicenseId. </summary>
		LicenseId,
		///<summary>PhysicianId. </summary>
		PhysicianId,
		///<summary>StateId. </summary>
		StateId,
		///<summary>LicenseNo. </summary>
		LicenseNo,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>ExpiryDate. </summary>
		ExpiryDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PhysicianMaster.
	/// </summary>
	public enum PhysicianMasterFieldIndex:int
	{
		///<summary>PhysicianMasterId. </summary>
		PhysicianMasterId,
		///<summary>Npi. </summary>
		Npi,
		///<summary>LastName. </summary>
		LastName,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>MiddleName. </summary>
		MiddleName,
		///<summary>PrefixText. </summary>
		PrefixText,
		///<summary>SuffixText. </summary>
		SuffixText,
		///<summary>CredentialText. </summary>
		CredentialText,
		///<summary>PracticeAddress1. </summary>
		PracticeAddress1,
		///<summary>PracticeAddress2. </summary>
		PracticeAddress2,
		///<summary>PracticeCity. </summary>
		PracticeCity,
		///<summary>PracticeState. </summary>
		PracticeState,
		///<summary>PracticeZip. </summary>
		PracticeZip,
		///<summary>PracticePhone. </summary>
		PracticePhone,
		///<summary>PracticeFax. </summary>
		PracticeFax,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsImported. </summary>
		IsImported,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>MailingAddress1. </summary>
		MailingAddress1,
		///<summary>MailingAddress2. </summary>
		MailingAddress2,
		///<summary>MailingCity. </summary>
		MailingCity,
		///<summary>MailingState. </summary>
		MailingState,
		///<summary>MailingZip. </summary>
		MailingZip,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PhysicianPayment.
	/// </summary>
	public enum PhysicianPaymentFieldIndex:int
	{
		///<summary>PhysicianPaymentId. </summary>
		PhysicianPaymentId,
		///<summary>ReferenceNumber. </summary>
		ReferenceNumber,
		///<summary>PaymentStatus. </summary>
		PaymentStatus,
		///<summary>Notes. </summary>
		Notes,
		///<summary>DataRecoderCreatorId. </summary>
		DataRecoderCreatorId,
		///<summary>DataRecoderModifierId. </summary>
		DataRecoderModifierId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModifed. </summary>
		DateModifed,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PhysicianPaymentInvoice.
	/// </summary>
	public enum PhysicianPaymentInvoiceFieldIndex:int
	{
		///<summary>PhysicianPaymentId. </summary>
		PhysicianPaymentId,
		///<summary>PhysicianInvoiceId. </summary>
		PhysicianInvoiceId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PhysicianPermittedTest.
	/// </summary>
	public enum PhysicianPermittedTestFieldIndex:int
	{
		///<summary>OrganizationRoleUserId. </summary>
		OrganizationRoleUserId,
		///<summary>TestId. </summary>
		TestId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PhysicianPod.
	/// </summary>
	public enum PhysicianPodFieldIndex:int
	{
		///<summary>PhysicianId. </summary>
		PhysicianId,
		///<summary>PodId. </summary>
		PodId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PhysicianProfile.
	/// </summary>
	public enum PhysicianProfileFieldIndex:int
	{
		///<summary>PhysicianId. </summary>
		PhysicianId,
		///<summary>ResumeFileId. </summary>
		ResumeFileId,
		///<summary>DigitalSignatureFileId. </summary>
		DigitalSignatureFileId,
		///<summary>SpecializationId. </summary>
		SpecializationId,
		///<summary>ClassificationId. </summary>
		ClassificationId,
		///<summary>ShowEarningAmount. </summary>
		ShowEarningAmount,
		///<summary>IsAuthorizationAllowed. </summary>
		IsAuthorizationAllowed,
		///<summary>SkipAudit. </summary>
		SkipAudit,
		///<summary>CutOffDate. </summary>
		CutOffDate,
		///<summary>IsDefaultPhysician. </summary>
		IsDefaultPhysician,
		///<summary>DisplayName. </summary>
		DisplayName,
		///<summary>UpdateResultEntry. </summary>
		UpdateResultEntry,
		///<summary>Npi. </summary>
		Npi,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PhysicianRecordRequestSignature.
	/// </summary>
	public enum PhysicianRecordRequestSignatureFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>SignatureFileId. </summary>
		SignatureFileId,
		///<summary>ConsentSignedDate. </summary>
		ConsentSignedDate,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>Version. </summary>
		Version,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PhysicianSpecialization.
	/// </summary>
	public enum PhysicianSpecializationFieldIndex:int
	{
		///<summary>PhysicianSpecializationId. </summary>
		PhysicianSpecializationId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PinChangelog.
	/// </summary>
	public enum PinChangelogFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>TechnicianId. </summary>
		TechnicianId,
		///<summary>Pin. </summary>
		Pin,
		///<summary>Sequence. </summary>
		Sequence,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PodDefaultTeam.
	/// </summary>
	public enum PodDefaultTeamFieldIndex:int
	{
		///<summary>PodTeamId. </summary>
		PodTeamId,
		///<summary>PodId. </summary>
		PodId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>EventRoleId. </summary>
		EventRoleId,
		///<summary>OrgnizationRoleUserId. </summary>
		OrgnizationRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PodDetails.
	/// </summary>
	public enum PodDetailsFieldIndex:int
	{
		///<summary>PodId. </summary>
		PodId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>VanId. </summary>
		VanId,
		///<summary>PodProcessingCapacity. </summary>
		PodProcessingCapacity,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsDefault. </summary>
		IsDefault,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>UpdatedByOrgRoleUserId. </summary>
		UpdatedByOrgRoleUserId,
		///<summary>UpdatedOn. </summary>
		UpdatedOn,
		///<summary>OrganizationId. </summary>
		OrganizationId,
		///<summary>EnableKynIntegration. </summary>
		EnableKynIntegration,
		///<summary>IsBloodworkFormAttached. </summary>
		IsBloodworkFormAttached,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PodInventoryItem.
	/// </summary>
	public enum PodInventoryItemFieldIndex:int
	{
		///<summary>PodInventoryId. </summary>
		PodInventoryId,
		///<summary>ItemId. </summary>
		ItemId,
		///<summary>PodId. </summary>
		PodId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>FromDate. </summary>
		FromDate,
		///<summary>ToDate. </summary>
		ToDate,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PodPackage.
	/// </summary>
	public enum PodPackageFieldIndex:int
	{
		///<summary>PodId. </summary>
		PodId,
		///<summary>PackageId. </summary>
		PackageId,
		///<summary>IsDefaultSelected. </summary>
		IsDefaultSelected,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PodRoom.
	/// </summary>
	public enum PodRoomFieldIndex:int
	{
		///<summary>PodRoomId. </summary>
		PodRoomId,
		///<summary>PodId. </summary>
		PodId,
		///<summary>RoomNo. </summary>
		RoomNo,
		///<summary>Duration. </summary>
		Duration,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PodRoomTest.
	/// </summary>
	public enum PodRoomTestFieldIndex:int
	{
		///<summary>PodRoomId. </summary>
		PodRoomId,
		///<summary>TestId. </summary>
		TestId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PodTerritory.
	/// </summary>
	public enum PodTerritoryFieldIndex:int
	{
		///<summary>PodId. </summary>
		PodId,
		///<summary>TerritoryId. </summary>
		TerritoryId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PodTest.
	/// </summary>
	public enum PodTestFieldIndex:int
	{
		///<summary>PodId. </summary>
		PodId,
		///<summary>TestId. </summary>
		TestId,
		///<summary>IsDefaultSelected. </summary>
		IsDefaultSelected,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PreApprovedPackage.
	/// </summary>
	public enum PreApprovedPackageFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>PackageId. </summary>
		PackageId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateEnd. </summary>
		DateEnd,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PreApprovedTest.
	/// </summary>
	public enum PreApprovedTestFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>TestId. </summary>
		TestId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateEnd. </summary>
		DateEnd,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PreAssessmentCallQueueCustomerLock.
	/// </summary>
	public enum PreAssessmentCallQueueCustomerLockFieldIndex:int
	{
		///<summary>PreAssessmentCustomerId. </summary>
		PreAssessmentCustomerId,
		///<summary>ProspectCustomerId. </summary>
		ProspectCustomerId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PreAssessmentCustomerCallQueueCallAttempt.
	/// </summary>
	public enum PreAssessmentCustomerCallQueueCallAttemptFieldIndex:int
	{
		///<summary>PreAssessmentCallAttemptId. </summary>
		PreAssessmentCallAttemptId,
		///<summary>CallId. </summary>
		CallId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>IsCallSkipped. </summary>
		IsCallSkipped,
		///<summary>IsNotesReadAndUnderstood. </summary>
		IsNotesReadAndUnderstood,
		///<summary>NotInterestedReasonId. </summary>
		NotInterestedReasonId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>SkipCallNote. </summary>
		SkipCallNote,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PreQualificationQuestion.
	/// </summary>
	public enum PreQualificationQuestionFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Question. </summary>
		Question,
		///<summary>TestId. </summary>
		TestId,
		///<summary>ControlValues. </summary>
		ControlValues,
		///<summary>ControlValueDelimiter. </summary>
		ControlValueDelimiter,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>Index. </summary>
		Index,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>DisqualifiedReason. </summary>
		DisqualifiedReason,
		///<summary>ParentId. </summary>
		ParentId,
		///<summary>TypeId. </summary>
		TypeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PreQualificationQuestionRule.
	/// </summary>
	public enum PreQualificationQuestionRuleFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>QuestionId. </summary>
		QuestionId,
		///<summary>DependentQuestionId. </summary>
		DependentQuestionId,
		///<summary>DependencyValue. </summary>
		DependencyValue,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PreQualificationResult.
	/// </summary>
	public enum PreQualificationResultFieldIndex:int
	{
		///<summary>PreQualificationResultId. </summary>
		PreQualificationResultId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>TempCartId. </summary>
		TempCartId,
		///<summary>SignUpModeId. </summary>
		SignUpModeId,
		///<summary>CallId. </summary>
		CallId,
		///<summary>HighBloodPressure. </summary>
		HighBloodPressure,
		///<summary>Smoker. </summary>
		Smoker,
		///<summary>HeartDisease. </summary>
		HeartDisease,
		///<summary>Diabetic. </summary>
		Diabetic,
		///<summary>ChestPain. </summary>
		ChestPain,
		///<summary>DiagnosedHeartProblem. </summary>
		DiagnosedHeartProblem,
		///<summary>HighCholestrol. </summary>
		HighCholestrol,
		///<summary>OverWeight. </summary>
		OverWeight,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>AgreedWithPrequalificationQuestion. </summary>
		AgreedWithPrequalificationQuestion,
		///<summary>SkipPreQualificationQuestion. </summary>
		SkipPreQualificationQuestion,
		///<summary>AgeOverPreQualificationQuestion. </summary>
		AgeOverPreQualificationQuestion,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PreQualificationTemplateDependentTest.
	/// </summary>
	public enum PreQualificationTemplateDependentTestFieldIndex:int
	{
		///<summary>TemplateId. </summary>
		TemplateId,
		///<summary>TestId. </summary>
		TestId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PreQualificationTemplateQuestion.
	/// </summary>
	public enum PreQualificationTemplateQuestionFieldIndex:int
	{
		///<summary>QuestionId. </summary>
		QuestionId,
		///<summary>TemplateId. </summary>
		TemplateId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PreQualificationTestTemplate.
	/// </summary>
	public enum PreQualificationTestTemplateFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>TemplateName. </summary>
		TemplateName,
		///<summary>TestId. </summary>
		TestId,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsPublished. </summary>
		IsPublished,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>UpdatedBy. </summary>
		UpdatedBy,
		///<summary>UpdatedDate. </summary>
		UpdatedDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PrintOrderItemTracking.
	/// </summary>
	public enum PrintOrderItemTrackingFieldIndex:int
	{
		///<summary>PrintOrderItemShippingId. </summary>
		PrintOrderItemShippingId,
		///<summary>PrintOrderItemId. </summary>
		PrintOrderItemId,
		///<summary>TrackingNumber. </summary>
		TrackingNumber,
		///<summary>ShippingService. </summary>
		ShippingService,
		///<summary>ScheduledDeliveryDate. </summary>
		ScheduledDeliveryDate,
		///<summary>ShipToName. </summary>
		ShipToName,
		///<summary>ShipToAttentionOf. </summary>
		ShipToAttentionOf,
		///<summary>Address1. </summary>
		Address1,
		///<summary>Address2. </summary>
		Address2,
		///<summary>City. </summary>
		City,
		///<summary>State. </summary>
		State,
		///<summary>Zip. </summary>
		Zip,
		///<summary>ConfirmationMode. </summary>
		ConfirmationMode,
		///<summary>ConfirmedBy. </summary>
		ConfirmedBy,
		///<summary>ActualDeliveryDate. </summary>
		ActualDeliveryDate,
		///<summary>PackageReference1. </summary>
		PackageReference1,
		///<summary>PackageReference2. </summary>
		PackageReference2,
		///<summary>PackageReference3. </summary>
		PackageReference3,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>DateUpdated. </summary>
		DateUpdated,
		///<summary>UpdatedByOrgRoleUserId. </summary>
		UpdatedByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: PriorityInQueue.
	/// </summary>
	public enum PriorityInQueueFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>EventCustomerResultId. </summary>
		EventCustomerResultId,
		///<summary>NoteId. </summary>
		NoteId,
		///<summary>InQueuePriority. </summary>
		InQueuePriority,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>ModifiedByOrgRoleUserId. </summary>
		ModifiedByOrgRoleUserId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Product.
	/// </summary>
	public enum ProductFieldIndex:int
	{
		///<summary>ProductId. </summary>
		ProductId,
		///<summary>Name. </summary>
		Name,
		///<summary>ShortDescription. </summary>
		ShortDescription,
		///<summary>Description. </summary>
		Description,
		///<summary>Price. </summary>
		Price,
		///<summary>Weight. </summary>
		Weight,
		///<summary>Height. </summary>
		Height,
		///<summary>Width. </summary>
		Width,
		///<summary>Depth. </summary>
		Depth,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>ForOrderDisplayHtmlString. </summary>
		ForOrderDisplayHtmlString,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProductOrderItem.
	/// </summary>
	public enum ProductOrderItemFieldIndex:int
	{
		///<summary>OrderItemId. </summary>
		OrderItemId,
		///<summary>ProductId. </summary>
		ProductId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProductShippingOption.
	/// </summary>
	public enum ProductShippingOptionFieldIndex:int
	{
		///<summary>ProductId. </summary>
		ProductId,
		///<summary>ShippingOptionId. </summary>
		ShippingOptionId,
		///<summary>IsShowVisible. </summary>
		IsShowVisible,
		///<summary>IsForPcp. </summary>
		IsForPcp,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProductSourceCodeDiscount.
	/// </summary>
	public enum ProductSourceCodeDiscountFieldIndex:int
	{
		///<summary>ProductId. </summary>
		ProductId,
		///<summary>SourceCodeId. </summary>
		SourceCodeId,
		///<summary>Discount. </summary>
		Discount,
		///<summary>IsPercentage. </summary>
		IsPercentage,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProspectActivity.
	/// </summary>
	public enum ProspectActivityFieldIndex:int
	{
		///<summary>ProspectId. </summary>
		ProspectId,
		///<summary>ActivityId. </summary>
		ActivityId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProspectActivityDetails.
	/// </summary>
	public enum ProspectActivityDetailsFieldIndex:int
	{
		///<summary>ProspectActivityDetailsId. </summary>
		ProspectActivityDetailsId,
		///<summary>ProspectId. </summary>
		ProspectId,
		///<summary>WfsequenceId. </summary>
		WfsequenceId,
		///<summary>ActivityDetails. </summary>
		ActivityDetails,
		///<summary>ActvityResultId. </summary>
		ActvityResultId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProspectAddress.
	/// </summary>
	public enum ProspectAddressFieldIndex:int
	{
		///<summary>ProspectAddressId. </summary>
		ProspectAddressId,
		///<summary>ProspectId. </summary>
		ProspectId,
		///<summary>Address1. </summary>
		Address1,
		///<summary>Address2. </summary>
		Address2,
		///<summary>City. </summary>
		City,
		///<summary>State. </summary>
		State,
		///<summary>Country. </summary>
		Country,
		///<summary>Zip. </summary>
		Zip,
		///<summary>Fax. </summary>
		Fax,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsMailing. </summary>
		IsMailing,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProspectCallDetails.
	/// </summary>
	public enum ProspectCallDetailsFieldIndex:int
	{
		///<summary>CallId. </summary>
		CallId,
		///<summary>CallerId. </summary>
		CallerId,
		///<summary>ProspectsId. </summary>
		ProspectsId,
		///<summary>ProspectStage. </summary>
		ProspectStage,
		///<summary>CallResponse. </summary>
		CallResponse,
		///<summary>NextCallDate. </summary>
		NextCallDate,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProspectCalls.
	/// </summary>
	public enum ProspectCallsFieldIndex:int
	{
		///<summary>ProspectCallId. </summary>
		ProspectCallId,
		///<summary>ProspectId. </summary>
		ProspectId,
		///<summary>CallId. </summary>
		CallId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProspectContact.
	/// </summary>
	public enum ProspectContactFieldIndex:int
	{
		///<summary>ProspectContactId. </summary>
		ProspectContactId,
		///<summary>ProspectId. </summary>
		ProspectId,
		///<summary>ContactId. </summary>
		ContactId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProspectContactCalls.
	/// </summary>
	public enum ProspectContactCallsFieldIndex:int
	{
		///<summary>ProspectContactCallId. </summary>
		ProspectContactCallId,
		///<summary>ProspectContactId. </summary>
		ProspectContactId,
		///<summary>CallId. </summary>
		CallId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProspectContactMeetings.
	/// </summary>
	public enum ProspectContactMeetingsFieldIndex:int
	{
		///<summary>ProspectContactMeetingId. </summary>
		ProspectContactMeetingId,
		///<summary>ProspectContactId. </summary>
		ProspectContactId,
		///<summary>MeetingId. </summary>
		MeetingId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProspectContactRole.
	/// </summary>
	public enum ProspectContactRoleFieldIndex:int
	{
		///<summary>ProspectContactRoleId. </summary>
		ProspectContactRoleId,
		///<summary>ProspectContactRoleName. </summary>
		ProspectContactRoleName,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProspectContactRoleMapping.
	/// </summary>
	public enum ProspectContactRoleMappingFieldIndex:int
	{
		///<summary>ProspectContactRoleMappingId. </summary>
		ProspectContactRoleMappingId,
		///<summary>ProspectContactId. </summary>
		ProspectContactId,
		///<summary>ProspectContactRoleId. </summary>
		ProspectContactRoleId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProspectContactTasks.
	/// </summary>
	public enum ProspectContactTasksFieldIndex:int
	{
		///<summary>ProspectContactTaskId. </summary>
		ProspectContactTaskId,
		///<summary>ProspectContactId. </summary>
		ProspectContactId,
		///<summary>TaskId. </summary>
		TaskId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProspectCustomer.
	/// </summary>
	public enum ProspectCustomerFieldIndex:int
	{
		///<summary>ProspectCustomerId. </summary>
		ProspectCustomerId,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>ZipCode. </summary>
		ZipCode,
		///<summary>CallbackNo. </summary>
		CallbackNo,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>Address1. </summary>
		Address1,
		///<summary>Address2. </summary>
		Address2,
		///<summary>City. </summary>
		City,
		///<summary>State. </summary>
		State,
		///<summary>Dob. </summary>
		Dob,
		///<summary>Email. </summary>
		Email,
		///<summary>Phone2. </summary>
		Phone2,
		///<summary>IsConverted. </summary>
		IsConverted,
		///<summary>DateConverted. </summary>
		DateConverted,
		///<summary>Source. </summary>
		Source,
		///<summary>Tag. </summary>
		Tag,
		///<summary>AffiliateCampaignMarketingMaterialId. </summary>
		AffiliateCampaignMarketingMaterialId,
		///<summary>MarketingSource. </summary>
		MarketingSource,
		///<summary>IsQueuedForCallBack. </summary>
		IsQueuedForCallBack,
		///<summary>SourceCodeId. </summary>
		SourceCodeId,
		///<summary>IncomingPhoneLine. </summary>
		IncomingPhoneLine,
		///<summary>ProspectListId. </summary>
		ProspectListId,
		///<summary>Gender. </summary>
		Gender,
		///<summary>Status. </summary>
		Status,
		///<summary>IsContacted. </summary>
		IsContacted,
		///<summary>ContactedDate. </summary>
		ContactedDate,
		///<summary>ContactedBy. </summary>
		ContactedBy,
		///<summary>CallBackRequestedOn. </summary>
		CallBackRequestedOn,
		///<summary>CallBackRequestedDate. </summary>
		CallBackRequestedDate,
		///<summary>TagUpdateDate. </summary>
		TagUpdateDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProspectCustomerCall.
	/// </summary>
	public enum ProspectCustomerCallFieldIndex:int
	{
		///<summary>ProspectCustomerId. </summary>
		ProspectCustomerId,
		///<summary>CallId. </summary>
		CallId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProspectCustomerDeleted.
	/// </summary>
	public enum ProspectCustomerDeletedFieldIndex:int
	{
		///<summary>ProspectCustomerId. </summary>
		ProspectCustomerId,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>ZipCode. </summary>
		ZipCode,
		///<summary>CallbackNo. </summary>
		CallbackNo,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>Address1. </summary>
		Address1,
		///<summary>Address2. </summary>
		Address2,
		///<summary>City. </summary>
		City,
		///<summary>State. </summary>
		State,
		///<summary>Dob. </summary>
		Dob,
		///<summary>Email. </summary>
		Email,
		///<summary>Phone2. </summary>
		Phone2,
		///<summary>IsConverted. </summary>
		IsConverted,
		///<summary>DateConverted. </summary>
		DateConverted,
		///<summary>Source. </summary>
		Source,
		///<summary>Tag. </summary>
		Tag,
		///<summary>AffiliateCampaignMarketingMaterialId. </summary>
		AffiliateCampaignMarketingMaterialId,
		///<summary>MarketingSource. </summary>
		MarketingSource,
		///<summary>IsQueuedForCallBack. </summary>
		IsQueuedForCallBack,
		///<summary>SourceCodeId. </summary>
		SourceCodeId,
		///<summary>IncomingPhoneLine. </summary>
		IncomingPhoneLine,
		///<summary>ProspectListId. </summary>
		ProspectListId,
		///<summary>Gender. </summary>
		Gender,
		///<summary>Status. </summary>
		Status,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProspectCustomerNotification.
	/// </summary>
	public enum ProspectCustomerNotificationFieldIndex:int
	{
		///<summary>ProspectCustomerId. </summary>
		ProspectCustomerId,
		///<summary>NotificationId. </summary>
		NotificationId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProspectDetails.
	/// </summary>
	public enum ProspectDetailsFieldIndex:int
	{
		///<summary>ProspectDetailsId. </summary>
		ProspectDetailsId,
		///<summary>ProspectId. </summary>
		ProspectId,
		///<summary>FacilitiesFee. </summary>
		FacilitiesFee,
		///<summary>PaymentMethod. </summary>
		PaymentMethod,
		///<summary>DepositsRequire. </summary>
		DepositsRequire,
		///<summary>DepositsAmount. </summary>
		DepositsAmount,
		///<summary>ViableHostSite. </summary>
		ViableHostSite,
		///<summary>HostedInPast. </summary>
		HostedInPast,
		///<summary>HostedInPastWith. </summary>
		HostedInPastWith,
		///<summary>WillHost. </summary>
		WillHost,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>ReasonViableHostSite. </summary>
		ReasonViableHostSite,
		///<summary>ReasonHostedInPast. </summary>
		ReasonHostedInPast,
		///<summary>ReasonHostedInPastWith. </summary>
		ReasonHostedInPastWith,
		///<summary>ReasonWillHost. </summary>
		ReasonWillHost,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProspectFaliureReport.
	/// </summary>
	public enum ProspectFaliureReportFieldIndex:int
	{
		///<summary>ProspectFaliureId. </summary>
		ProspectFaliureId,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>Organisation. </summary>
		Organisation,
		///<summary>Email. </summary>
		Email,
		///<summary>PhoneOffice. </summary>
		PhoneOffice,
		///<summary>PhoneCell. </summary>
		PhoneCell,
		///<summary>Website. </summary>
		Website,
		///<summary>Notes. </summary>
		Notes,
		///<summary>ProspectListId. </summary>
		ProspectListId,
		///<summary>Address1. </summary>
		Address1,
		///<summary>CountryId. </summary>
		CountryId,
		///<summary>StateId. </summary>
		StateId,
		///<summary>City. </summary>
		City,
		///<summary>ZipId. </summary>
		ZipId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProspectListDetails.
	/// </summary>
	public enum ProspectListDetailsFieldIndex:int
	{
		///<summary>ProspectFileId. </summary>
		ProspectFileId,
		///<summary>FileName. </summary>
		FileName,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>ListName. </summary>
		ListName,
		///<summary>ListSource. </summary>
		ListSource,
		///<summary>ListType. </summary>
		ListType,
		///<summary>AddedBy. </summary>
		AddedBy,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>LogList. </summary>
		LogList,
		///<summary>RoleId. </summary>
		RoleId,
		///<summary>FileSize. </summary>
		FileSize,
		///<summary>UploadTime. </summary>
		UploadTime,
		///<summary>Assigned. </summary>
		Assigned,
		///<summary>OrganizationId. </summary>
		OrganizationId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProspectListType.
	/// </summary>
	public enum ProspectListTypeFieldIndex:int
	{
		///<summary>ProspectListTypeId. </summary>
		ProspectListTypeId,
		///<summary>ProspectListType. </summary>
		ProspectListType,
		///<summary>DateCreated. </summary>
		DateCreated,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProspectMeetings.
	/// </summary>
	public enum ProspectMeetingsFieldIndex:int
	{
		///<summary>ProspectMeetingId. </summary>
		ProspectMeetingId,
		///<summary>ProspectId. </summary>
		ProspectId,
		///<summary>MeetingId. </summary>
		MeetingId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProspectNotesDetails.
	/// </summary>
	public enum ProspectNotesDetailsFieldIndex:int
	{
		///<summary>ProspectNoteId. </summary>
		ProspectNoteId,
		///<summary>ProspectId. </summary>
		ProspectId,
		///<summary>NoteId. </summary>
		NoteId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Prospects.
	/// </summary>
	public enum ProspectsFieldIndex:int
	{
		///<summary>ProspectId. </summary>
		ProspectId,
		///<summary>ProspectListId. </summary>
		ProspectListId,
		///<summary>ProspectStage. </summary>
		ProspectStage,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>PropectsState. </summary>
		PropectsState,
		///<summary>IsHost. </summary>
		IsHost,
		///<summary>Status. </summary>
		Status,
		///<summary>ProspectTypeId. </summary>
		ProspectTypeId,
		///<summary>EmailId. </summary>
		EmailId,
		///<summary>PhoneOffice. </summary>
		PhoneOffice,
		///<summary>PhoneCell. </summary>
		PhoneCell,
		///<summary>PhoneOther. </summary>
		PhoneOther,
		///<summary>WebSite. </summary>
		WebSite,
		///<summary>OrganizationName. </summary>
		OrganizationName,
		///<summary>Notes. </summary>
		Notes,
		///<summary>AddressId. </summary>
		AddressId,
		///<summary>AddressIdmailling. </summary>
		AddressIdmailling,
		///<summary>ActualMembersHip. </summary>
		ActualMembersHip,
		///<summary>ActualAttendance. </summary>
		ActualAttendance,
		///<summary>WillPromote. </summary>
		WillPromote,
		///<summary>Mapurl. </summary>
		Mapurl,
		///<summary>OtherEmail. </summary>
		OtherEmail,
		///<summary>MethodObtainedId. </summary>
		MethodObtainedId,
		///<summary>County. </summary>
		County,
		///<summary>DateHostConverted. </summary>
		DateHostConverted,
		///<summary>Fudate. </summary>
		Fudate,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>ReasonWillPromote. </summary>
		ReasonWillPromote,
		///<summary>TaxIdNumber. </summary>
		TaxIdNumber,
		///<summary>CompanyId. </summary>
		CompanyId,
		///<summary>Department. </summary>
		Department,
		///<summary>Ext. </summary>
		Ext,
		///<summary>Small. </summary>
		Small,
		///<summary>Industry. </summary>
		Industry,
		///<summary>WebsiteJobOpenings. </summary>
		WebsiteJobOpenings,
		///<summary>YearlyRevRange. </summary>
		YearlyRevRange,
		///<summary>EmployeeRange. </summary>
		EmployeeRange,
		///<summary>GroupDescription. </summary>
		GroupDescription,
		///<summary>OrgRoleUserId. </summary>
		OrgRoleUserId,
		///<summary>Fax. </summary>
		Fax,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProspectTasks.
	/// </summary>
	public enum ProspectTasksFieldIndex:int
	{
		///<summary>ProspectTaskId. </summary>
		ProspectTaskId,
		///<summary>ProspectId. </summary>
		ProspectId,
		///<summary>TaskId. </summary>
		TaskId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ProspectType.
	/// </summary>
	public enum ProspectTypeFieldIndex:int
	{
		///<summary>ProspectTypeId. </summary>
		ProspectTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Raps.
	/// </summary>
	public enum RapsFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>RapsUploadId. </summary>
		RapsUploadId,
		///<summary>CmsHicn. </summary>
		CmsHicn,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>MemberDob. </summary>
		MemberDob,
		///<summary>MemberId. </summary>
		MemberId,
		///<summary>IcdVersion. </summary>
		IcdVersion,
		///<summary>ServiceDate. </summary>
		ServiceDate,
		///<summary>IcdCode. </summary>
		IcdCode,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>SecondName. </summary>
		SecondName,
		///<summary>IsSynced. </summary>
		IsSynced,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: RapsUpload.
	/// </summary>
	public enum RapsUploadFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>FileId. </summary>
		FileId,
		///<summary>StatusId. </summary>
		StatusId,
		///<summary>SuccessfullUploadCount. </summary>
		SuccessfullUploadCount,
		///<summary>FailedUploadCount. </summary>
		FailedUploadCount,
		///<summary>UploadTime. </summary>
		UploadTime,
		///<summary>UploadedBy. </summary>
		UploadedBy,
		///<summary>ParseStartTime. </summary>
		ParseStartTime,
		///<summary>ParseEndTime. </summary>
		ParseEndTime,
		///<summary>LogFileId. </summary>
		LogFileId,
		///<summary>TotalCount. </summary>
		TotalCount,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: RapsUploadLog.
	/// </summary>
	public enum RapsUploadLogFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>RapsUploadId. </summary>
		RapsUploadId,
		///<summary>CmsHicn. </summary>
		CmsHicn,
		///<summary>MemberDob. </summary>
		MemberDob,
		///<summary>IsSuccessFull. </summary>
		IsSuccessFull,
		///<summary>ErrorMessage. </summary>
		ErrorMessage,
		///<summary>MemberId. </summary>
		MemberId,
		///<summary>IcdVersion. </summary>
		IcdVersion,
		///<summary>ServiceDate. </summary>
		ServiceDate,
		///<summary>IcdCode. </summary>
		IcdCode,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>SecondName. </summary>
		SecondName,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Reading.
	/// </summary>
	public enum ReadingFieldIndex:int
	{
		///<summary>ReadingId. </summary>
		ReadingId,
		///<summary>Label. </summary>
		Label,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>MeasurementUnit. </summary>
		MeasurementUnit,
		///<summary>DefaultInputSource. </summary>
		DefaultInputSource,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Referral.
	/// </summary>
	public enum ReferralFieldIndex:int
	{
		///<summary>ReferralId. </summary>
		ReferralId,
		///<summary>Name. </summary>
		Name,
		///<summary>Email. </summary>
		Email,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>ReferedCustomerId. </summary>
		ReferedCustomerId,
		///<summary>ReferrelPage. </summary>
		ReferrelPage,
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>ReferedByOrgRoleUserId. </summary>
		ReferedByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Refund.
	/// </summary>
	public enum RefundFieldIndex:int
	{
		///<summary>RefundId. </summary>
		RefundId,
		///<summary>ReasonId. </summary>
		ReasonId,
		///<summary>Amount. </summary>
		Amount,
		///<summary>Notes. </summary>
		Notes,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>OrganizationRoleUserCreatorId. </summary>
		OrganizationRoleUserCreatorId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: RefundOrderItem.
	/// </summary>
	public enum RefundOrderItemFieldIndex:int
	{
		///<summary>OrderItemId. </summary>
		OrderItemId,
		///<summary>RefundId. </summary>
		RefundId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: RefundRequest.
	/// </summary>
	public enum RefundRequestFieldIndex:int
	{
		///<summary>RefundRequestId. </summary>
		RefundRequestId,
		///<summary>ReasonType. </summary>
		ReasonType,
		///<summary>ReasonComment. </summary>
		ReasonComment,
		///<summary>OrderId. </summary>
		OrderId,
		///<summary>RequestedRefundAmount. </summary>
		RequestedRefundAmount,
		///<summary>FinalRefundAmount. </summary>
		FinalRefundAmount,
		///<summary>RequestedByOrgRoleUserId. </summary>
		RequestedByOrgRoleUserId,
		///<summary>ProcessedByOrgRoleUserId. </summary>
		ProcessedByOrgRoleUserId,
		///<summary>ProcessorNotes. </summary>
		ProcessorNotes,
		///<summary>RequestedOn. </summary>
		RequestedOn,
		///<summary>ProcessedOn. </summary>
		ProcessedOn,
		///<summary>RequestResult. </summary>
		RequestResult,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>RequestStatus. </summary>
		RequestStatus,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: RefundRequestGiftCertificate.
	/// </summary>
	public enum RefundRequestGiftCertificateFieldIndex:int
	{
		///<summary>GiftCertificateId. </summary>
		GiftCertificateId,
		///<summary>RefundRequestId. </summary>
		RefundRequestId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Relationship.
	/// </summary>
	public enum RelationshipFieldIndex:int
	{
		///<summary>RelationshipId. </summary>
		RelationshipId,
		///<summary>Code. </summary>
		Code,
		///<summary>Description. </summary>
		Description,
		///<summary>Alias. </summary>
		Alias,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: RequiredTest.
	/// </summary>
	public enum RequiredTestFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>TestId. </summary>
		TestId,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>ForYear. </summary>
		ForYear,
		///<summary>EndDate. </summary>
		EndDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: RescheduleCancelDisposition.
	/// </summary>
	public enum RescheduleCancelDispositionFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>LookupId. </summary>
		LookupId,
		///<summary>Alias. </summary>
		Alias,
		///<summary>DisplayName. </summary>
		DisplayName,
		///<summary>Description. </summary>
		Description,
		///<summary>RelativeOrder. </summary>
		RelativeOrder,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DataRecorderCreatorId. </summary>
		DataRecorderCreatorId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ResultArchiveUpload.
	/// </summary>
	public enum ResultArchiveUploadFieldIndex:int
	{
		///<summary>EventId. </summary>
		EventId,
		///<summary>UploadStartTime. </summary>
		UploadStartTime,
		///<summary>UploadEndTime. </summary>
		UploadEndTime,
		///<summary>ParseStartTime. </summary>
		ParseStartTime,
		///<summary>ParseEndTime. </summary>
		ParseEndTime,
		///<summary>CustomerRecordsFound. </summary>
		CustomerRecordsFound,
		///<summary>Status. </summary>
		Status,
		///<summary>ResultArchiveUploadId. </summary>
		ResultArchiveUploadId,
		///<summary>FileId. </summary>
		FileId,
		///<summary>UploadPercentage. </summary>
		UploadPercentage,
		///<summary>ParsePercentage. </summary>
		ParsePercentage,
		///<summary>UploadedByOrgRoleUserId. </summary>
		UploadedByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ResultArchiveUploadLog.
	/// </summary>
	public enum ResultArchiveUploadLogFieldIndex:int
	{
		///<summary>ResultArchiveUploadLogId. </summary>
		ResultArchiveUploadLogId,
		///<summary>ResultArchiveUploadId. </summary>
		ResultArchiveUploadId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>TestId. </summary>
		TestId,
		///<summary>MedicalEquipmentTag. </summary>
		MedicalEquipmentTag,
		///<summary>IsSuccessful. </summary>
		IsSuccessful,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>Note. </summary>
		Note,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Role.
	/// </summary>
	public enum RoleFieldIndex:int
	{
		///<summary>RoleId. </summary>
		RoleId,
		///<summary>OrganizationTypeId. </summary>
		OrganizationTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>Alias. </summary>
		Alias,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>Description. </summary>
		Description,
		///<summary>DefaultPage. </summary>
		DefaultPage,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>ShellType. </summary>
		ShellType,
		///<summary>ParentId. </summary>
		ParentId,
		///<summary>IsSystemRole. </summary>
		IsSystemRole,
		///<summary>IsTwoFactorAuthrequired. </summary>
		IsTwoFactorAuthrequired,
		///<summary>IsPinRequired. </summary>
		IsPinRequired,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: RoleAccessControlObject.
	/// </summary>
	public enum RoleAccessControlObjectFieldIndex:int
	{
		///<summary>RoleId. </summary>
		RoleId,
		///<summary>AccessControlObjectId. </summary>
		AccessControlObjectId,
		///<summary>PermissionTypeId. </summary>
		PermissionTypeId,
		///<summary>ScopeId. </summary>
		ScopeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: RolePermisibleAccessControlObject.
	/// </summary>
	public enum RolePermisibleAccessControlObjectFieldIndex:int
	{
		///<summary>RoleId. </summary>
		RoleId,
		///<summary>AccessControlObjectId. </summary>
		AccessControlObjectId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: RoleScopeOption.
	/// </summary>
	public enum RoleScopeOptionFieldIndex:int
	{
		///<summary>RoleId. </summary>
		RoleId,
		///<summary>ScopeId. </summary>
		ScopeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: SafeComputerHistory.
	/// </summary>
	public enum SafeComputerHistoryFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>UserLoginId. </summary>
		UserLoginId,
		///<summary>BrowserType. </summary>
		BrowserType,
		///<summary>ComputerIp. </summary>
		ComputerIp,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: SalesRepPodAssigments.
	/// </summary>
	public enum SalesRepPodAssigmentsFieldIndex:int
	{
		///<summary>OrganizationRoleUserId. </summary>
		OrganizationRoleUserId,
		///<summary>PodId. </summary>
		PodId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ScheduleMethod.
	/// </summary>
	public enum ScheduleMethodFieldIndex:int
	{
		///<summary>ScheduleMethodId. </summary>
		ScheduleMethodId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ScheduleTemplate.
	/// </summary>
	public enum ScheduleTemplateFieldIndex:int
	{
		///<summary>ScheduleTemplateId. </summary>
		ScheduleTemplateId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>IsGlobal. </summary>
		IsGlobal,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>ModifiedByOrgRoleUserId. </summary>
		ModifiedByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ScheduleTemplateFranchiseeAccess.
	/// </summary>
	public enum ScheduleTemplateFranchiseeAccessFieldIndex:int
	{
		///<summary>ScheduleTemplateFranchiseeAccessId. </summary>
		ScheduleTemplateFranchiseeAccessId,
		///<summary>ScheduleTemplateId. </summary>
		ScheduleTemplateId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>OrganizationId. </summary>
		OrganizationId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ScheduleTemplateTime.
	/// </summary>
	public enum ScheduleTemplateTimeFieldIndex:int
	{
		///<summary>ScheduleTemplateTimeId. </summary>
		ScheduleTemplateTimeId,
		///<summary>ScheduleTemplateId. </summary>
		ScheduleTemplateId,
		///<summary>StartTime. </summary>
		StartTime,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ScreeningAuthorization.
	/// </summary>
	public enum ScreeningAuthorizationFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>Initials. </summary>
		Initials,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>Signature. </summary>
		Signature,
		///<summary>PhysicianOrgRoleUserId. </summary>
		PhysicianOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Scripts.
	/// </summary>
	public enum ScriptsFieldIndex:int
	{
		///<summary>ScriptId. </summary>
		ScriptId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>ScriptText. </summary>
		ScriptText,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsDefault. </summary>
		IsDefault,
		///<summary>ScriptTypeId. </summary>
		ScriptTypeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ScriptType.
	/// </summary>
	public enum ScriptTypeFieldIndex:int
	{
		///<summary>ScriptTypeId. </summary>
		ScriptTypeId,
		///<summary>ScriptName. </summary>
		ScriptName,
		///<summary>Description. </summary>
		Description,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: SecurityQuestion.
	/// </summary>
	public enum SecurityQuestionFieldIndex:int
	{
		///<summary>SecurityQuestionId. </summary>
		SecurityQuestionId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: SeminarCampaignDetails.
	/// </summary>
	public enum SeminarCampaignDetailsFieldIndex:int
	{
		///<summary>SeminarId. </summary>
		SeminarId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Seminars.
	/// </summary>
	public enum SeminarsFieldIndex:int
	{
		///<summary>SeminarId. </summary>
		SeminarId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>HostId. </summary>
		HostId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>SeminarDate. </summary>
		SeminarDate,
		///<summary>SeminarTimeFrom. </summary>
		SeminarTimeFrom,
		///<summary>SeminarTimeTo. </summary>
		SeminarTimeTo,
		///<summary>AddressId. </summary>
		AddressId,
		///<summary>AttendeesCount. </summary>
		AttendeesCount,
		///<summary>Type. </summary>
		Type,
		///<summary>Organizationname. </summary>
		Organizationname,
		///<summary>HscprospectNotificationSend. </summary>
		HscprospectNotificationSend,
		///<summary>OrgRoleUserId. </summary>
		OrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ShippingDetail.
	/// </summary>
	public enum ShippingDetailFieldIndex:int
	{
		///<summary>ShippingDetailId. </summary>
		ShippingDetailId,
		///<summary>ShippingOptionId. </summary>
		ShippingOptionId,
		///<summary>ShippingAddressId. </summary>
		ShippingAddressId,
		///<summary>ShipmentDate. </summary>
		ShipmentDate,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>OrganizationRoleUserCreatorId. </summary>
		OrganizationRoleUserCreatorId,
		///<summary>Status. </summary>
		Status,
		///<summary>ActualPrice. </summary>
		ActualPrice,
		///<summary>IsExclusivelyRequested. </summary>
		IsExclusivelyRequested,
		///<summary>ShippedByOrgRoleUserId. </summary>
		ShippedByOrgRoleUserId,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>DateModified. </summary>
		DateModified,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ShippingDetailOrderDetail.
	/// </summary>
	public enum ShippingDetailOrderDetailFieldIndex:int
	{
		///<summary>OrderDetailId. </summary>
		OrderDetailId,
		///<summary>ShippingDetailId. </summary>
		ShippingDetailId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ShippingOption.
	/// </summary>
	public enum ShippingOptionFieldIndex:int
	{
		///<summary>ShippingOptionId. </summary>
		ShippingOptionId,
		///<summary>Type. </summary>
		Type,
		///<summary>CarrierId. </summary>
		CarrierId,
		///<summary>Description. </summary>
		Description,
		///<summary>Price. </summary>
		Price,
		///<summary>CostToCompany. </summary>
		CostToCompany,
		///<summary>Disclaimer. </summary>
		Disclaimer,
		///<summary>ShippableToPobox. </summary>
		ShippableToPobox,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>Name. </summary>
		Name,
		///<summary>ForOrderDisplayHtmlString. </summary>
		ForOrderDisplayHtmlString,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ShippingOptionOrderItem.
	/// </summary>
	public enum ShippingOptionOrderItemFieldIndex:int
	{
		///<summary>OrderItemId. </summary>
		OrderItemId,
		///<summary>ShippingOptionId. </summary>
		ShippingOptionId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ShippingOptionSourceCodeDiscount.
	/// </summary>
	public enum ShippingOptionSourceCodeDiscountFieldIndex:int
	{
		///<summary>ShippingOptionId. </summary>
		ShippingOptionId,
		///<summary>SourceCodeId. </summary>
		SourceCodeId,
		///<summary>Discount. </summary>
		Discount,
		///<summary>IsPercentage. </summary>
		IsPercentage,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: SmsReceived.
	/// </summary>
	public enum SmsReceivedFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>PhoneNumber. </summary>
		PhoneNumber,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>Message. </summary>
		Message,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: SourceCodeChangeLog.
	/// </summary>
	public enum SourceCodeChangeLogFieldIndex:int
	{
		///<summary>SourceCodeChangeId. </summary>
		SourceCodeChangeId,
		///<summary>OldSourceCodeId. </summary>
		OldSourceCodeId,
		///<summary>NewSourceCodeId. </summary>
		NewSourceCodeId,
		///<summary>IsPriceChange. </summary>
		IsPriceChange,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>Shellid. </summary>
		Shellid,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: SourceCodeOrderDetail.
	/// </summary>
	public enum SourceCodeOrderDetailFieldIndex:int
	{
		///<summary>OrderDetailId. </summary>
		OrderDetailId,
		///<summary>SourceCodeId. </summary>
		SourceCodeId,
		///<summary>Amount. </summary>
		Amount,
		///<summary>OrganizationRoleUserCreatorId. </summary>
		OrganizationRoleUserCreatorId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: StaffEventRole.
	/// </summary>
	public enum StaffEventRoleFieldIndex:int
	{
		///<summary>StaffEventRoleId. </summary>
		StaffEventRoleId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>UpdatedByOrgRoleUserId. </summary>
		UpdatedByOrgRoleUserId,
		///<summary>UpdatedOn. </summary>
		UpdatedOn,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: StaffEventRoleTest.
	/// </summary>
	public enum StaffEventRoleTestFieldIndex:int
	{
		///<summary>StaffEventRoleId. </summary>
		StaffEventRoleId,
		///<summary>TestId. </summary>
		TestId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: StaffEventScheduleUpload.
	/// </summary>
	public enum StaffEventScheduleUploadFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>FileId. </summary>
		FileId,
		///<summary>StatusId. </summary>
		StatusId,
		///<summary>SuccessUploadCount. </summary>
		SuccessUploadCount,
		///<summary>FailedUploadCount. </summary>
		FailedUploadCount,
		///<summary>UploadTime. </summary>
		UploadTime,
		///<summary>ParseStartTime. </summary>
		ParseStartTime,
		///<summary>ParseEndTime. </summary>
		ParseEndTime,
		///<summary>UploadedByOrgRoleUserId. </summary>
		UploadedByOrgRoleUserId,
		///<summary>LogFileId. </summary>
		LogFileId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: StaffEventScheduleUploadLog.
	/// </summary>
	public enum StaffEventScheduleUploadLogFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>UploadId. </summary>
		UploadId,
		///<summary>StaffName. </summary>
		StaffName,
		///<summary>Pod. </summary>
		Pod,
		///<summary>Role. </summary>
		Role,
		///<summary>EventDate. </summary>
		EventDate,
		///<summary>IsSuccessful. </summary>
		IsSuccessful,
		///<summary>ErrorMessage. </summary>
		ErrorMessage,
		///<summary>EmployeeId. </summary>
		EmployeeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: StandardFinding.
	/// </summary>
	public enum StandardFindingFieldIndex:int
	{
		///<summary>StandardFindingId. </summary>
		StandardFindingId,
		///<summary>Label. </summary>
		Label,
		///<summary>Description. </summary>
		Description,
		///<summary>MinValue. </summary>
		MinValue,
		///<summary>MaxValue. </summary>
		MaxValue,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>UpdatedByOrgRoleUserId. </summary>
		UpdatedByOrgRoleUserId,
		///<summary>UpdatedOn. </summary>
		UpdatedOn,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>ResultInterpretation. </summary>
		ResultInterpretation,
		///<summary>LongDescription. </summary>
		LongDescription,
		///<summary>WorstCaseOrder. </summary>
		WorstCaseOrder,
		///<summary>PathwayRecommendation. </summary>
		PathwayRecommendation,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: StandardFindingTestReading.
	/// </summary>
	public enum StandardFindingTestReadingFieldIndex:int
	{
		///<summary>StandardFindingTestReadingId. </summary>
		StandardFindingTestReadingId,
		///<summary>StandardFindingId. </summary>
		StandardFindingId,
		///<summary>TestId. </summary>
		TestId,
		///<summary>ReadingId. </summary>
		ReadingId,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: State.
	/// </summary>
	public enum StateFieldIndex:int
	{
		///<summary>StateId. </summary>
		StateId,
		///<summary>Name. </summary>
		Name,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>Description. </summary>
		Description,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>CountryId. </summary>
		CountryId,
		///<summary>StateCode. </summary>
		StateCode,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: SurveyAnswer.
	/// </summary>
	public enum SurveyAnswerFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>QuestionId. </summary>
		QuestionId,
		///<summary>Answer. </summary>
		Answer,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>Version. </summary>
		Version,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>ModifiedOn. </summary>
		ModifiedOn,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: SurveyQuestion.
	/// </summary>
	public enum SurveyQuestionFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Question. </summary>
		Question,
		///<summary>TypeId. </summary>
		TypeId,
		///<summary>ParentId. </summary>
		ParentId,
		///<summary>Gender. </summary>
		Gender,
		///<summary>ControlValues. </summary>
		ControlValues,
		///<summary>ControlValueDelimiter. </summary>
		ControlValueDelimiter,
		///<summary>Index. </summary>
		Index,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: SurveyTemplate.
	/// </summary>
	public enum SurveyTemplateFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsPublished. </summary>
		IsPublished,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>IsDefault. </summary>
		IsDefault,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: SurveyTemplateQuestion.
	/// </summary>
	public enum SurveyTemplateQuestionFieldIndex:int
	{
		///<summary>TemplateId. </summary>
		TemplateId,
		///<summary>QuestionId. </summary>
		QuestionId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: SuspectCondition.
	/// </summary>
	public enum SuspectConditionFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>SuspectConditionUploadId. </summary>
		SuspectConditionUploadId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Gmpi. </summary>
		Gmpi,
		///<summary>SubscriberId. </summary>
		SubscriberId,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>MiddleName. </summary>
		MiddleName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>Dob. </summary>
		Dob,
		///<summary>Icdcode. </summary>
		Icdcode,
		///<summary>Icddesc. </summary>
		Icddesc,
		///<summary>IcdcodeVersion. </summary>
		IcdcodeVersion,
		///<summary>Hcc. </summary>
		Hcc,
		///<summary>Hccdesc. </summary>
		Hccdesc,
		///<summary>CaptureAction. </summary>
		CaptureAction,
		///<summary>CaptureLocation. </summary>
		CaptureLocation,
		///<summary>CaptureReasonDescription. </summary>
		CaptureReasonDescription,
		///<summary>CaptureReferenceDate. </summary>
		CaptureReferenceDate,
		///<summary>SectionName. </summary>
		SectionName,
		///<summary>IsSynced. </summary>
		IsSynced,
		///<summary>MemberId. </summary>
		MemberId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: SuspectConditionUpload.
	/// </summary>
	public enum SuspectConditionUploadFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>FileId. </summary>
		FileId,
		///<summary>StatusId. </summary>
		StatusId,
		///<summary>SuccessfullUploadCount. </summary>
		SuccessfullUploadCount,
		///<summary>FailedUploadCount. </summary>
		FailedUploadCount,
		///<summary>UploadTime. </summary>
		UploadTime,
		///<summary>UploadedBy. </summary>
		UploadedBy,
		///<summary>ParseStartTime. </summary>
		ParseStartTime,
		///<summary>ParseEndTime. </summary>
		ParseEndTime,
		///<summary>LogFileId. </summary>
		LogFileId,
		///<summary>TotalCount. </summary>
		TotalCount,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: SuspectConditionUploadLog.
	/// </summary>
	public enum SuspectConditionUploadLogFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>SuspectConditionUploadId. </summary>
		SuspectConditionUploadId,
		///<summary>Gmpi. </summary>
		Gmpi,
		///<summary>SubscriberId. </summary>
		SubscriberId,
		///<summary>MemberName. </summary>
		MemberName,
		///<summary>Dob. </summary>
		Dob,
		///<summary>Icdcode. </summary>
		Icdcode,
		///<summary>Icddesc. </summary>
		Icddesc,
		///<summary>IcdcodeVersion. </summary>
		IcdcodeVersion,
		///<summary>Hcc. </summary>
		Hcc,
		///<summary>Hccdesc. </summary>
		Hccdesc,
		///<summary>CaptureAction. </summary>
		CaptureAction,
		///<summary>CaptureLocation. </summary>
		CaptureLocation,
		///<summary>CaptureReasonDescription. </summary>
		CaptureReasonDescription,
		///<summary>CaptureReferenceDate. </summary>
		CaptureReferenceDate,
		///<summary>SectionName. </summary>
		SectionName,
		///<summary>IsSuccessFull. </summary>
		IsSuccessFull,
		///<summary>ErrorMessage. </summary>
		ErrorMessage,
		///<summary>MemberId. </summary>
		MemberId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: SystemGeneratedCallQueueAssignment.
	/// </summary>
	public enum SystemGeneratedCallQueueAssignmentFieldIndex:int
	{
		///<summary>CallQueueCustomerId. </summary>
		CallQueueCustomerId,
		///<summary>CallQueueId. </summary>
		CallQueueId,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: SystemGeneratedCallQueueCriteria.
	/// </summary>
	public enum SystemGeneratedCallQueueCriteriaFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CallQueueId. </summary>
		CallQueueId,
		///<summary>Amount. </summary>
		Amount,
		///<summary>Percentage. </summary>
		Percentage,
		///<summary>NoOfDays. </summary>
		NoOfDays,
		///<summary>IsDefault. </summary>
		IsDefault,
		///<summary>IsQueueGenerated. </summary>
		IsQueueGenerated,
		///<summary>LastQueueGeneratedDate. </summary>
		LastQueueGeneratedDate,
		///<summary>AssignedToOrgRoleUserId. </summary>
		AssignedToOrgRoleUserId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>ModifiedByOrgRoleUserId. </summary>
		ModifiedByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: SystemUserInfo.
	/// </summary>
	public enum SystemUserInfoFieldIndex:int
	{
		///<summary>UserId. </summary>
		UserId,
		///<summary>EmployeeId. </summary>
		EmployeeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Tag.
	/// </summary>
	public enum TagFieldIndex:int
	{
		///<summary>TagId. </summary>
		TagId,
		///<summary>Source. </summary>
		Source,
		///<summary>Name. </summary>
		Name,
		///<summary>Alias. </summary>
		Alias,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>IsSystemDefined. </summary>
		IsSystemDefined,
		///<summary>IsHealthPlanTag. </summary>
		IsHealthPlanTag,
		///<summary>ForAppointmentConfirmation. </summary>
		ForAppointmentConfirmation,
		///<summary>CallStatus. </summary>
		CallStatus,
		///<summary>ForWarmTransfer. </summary>
		ForWarmTransfer,
		///<summary>ForPreAssessment. </summary>
		ForPreAssessment,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Task.
	/// </summary>
	public enum TaskFieldIndex:int
	{
		///<summary>TaskId. </summary>
		TaskId,
		///<summary>Task. </summary>
		Task,
		///<summary>Details. </summary>
		Details,
		///<summary>StartDate. </summary>
		StartDate,
		///<summary>StartTime. </summary>
		StartTime,
		///<summary>DueDate. </summary>
		DueDate,
		///<summary>DueTime. </summary>
		DueTime,
		///<summary>TaskPriorityId. </summary>
		TaskPriorityId,
		///<summary>TaskStatusId. </summary>
		TaskStatusId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TaskDetails.
	/// </summary>
	public enum TaskDetailsFieldIndex:int
	{
		///<summary>TaskId. </summary>
		TaskId,
		///<summary>Subject. </summary>
		Subject,
		///<summary>Notes. </summary>
		Notes,
		///<summary>StartDate. </summary>
		StartDate,
		///<summary>StartTime. </summary>
		StartTime,
		///<summary>DueDate. </summary>
		DueDate,
		///<summary>DueTime. </summary>
		DueTime,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>TaskPriorityId. </summary>
		TaskPriorityId,
		///<summary>TaskStatusId. </summary>
		TaskStatusId,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>AssignedToOrgRoleUserId. </summary>
		AssignedToOrgRoleUserId,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>ModifiedByOrgRoleUserId. </summary>
		ModifiedByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TaskPriorityTypes.
	/// </summary>
	public enum TaskPriorityTypesFieldIndex:int
	{
		///<summary>TaskPriorityId. </summary>
		TaskPriorityId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TaskStatusTypes.
	/// </summary>
	public enum TaskStatusTypesFieldIndex:int
	{
		///<summary>TaskStatusId. </summary>
		TaskStatusId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TechnicianProfile.
	/// </summary>
	public enum TechnicianProfileFieldIndex:int
	{
		///<summary>OrganizationRoleUserId. </summary>
		OrganizationRoleUserId,
		///<summary>CanCompletePreAudit. </summary>
		CanCompletePreAudit,
		///<summary>IsTeamLead. </summary>
		IsTeamLead,
		///<summary>Pin. </summary>
		Pin,
		///<summary>PinChangeDate. </summary>
		PinChangeDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TempCart.
	/// </summary>
	public enum TempCartFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Guid. </summary>
		Guid,
		///<summary>ZipCode. </summary>
		ZipCode,
		///<summary>EventId. </summary>
		EventId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>ProspectCustomerId. </summary>
		ProspectCustomerId,
		///<summary>AppointmentId. </summary>
		AppointmentId,
		///<summary>EventPackageId. </summary>
		EventPackageId,
		///<summary>SourceCodeId. </summary>
		SourceCodeId,
		///<summary>TestId. </summary>
		TestId,
		///<summary>ProductId. </summary>
		ProductId,
		///<summary>Shippingid. </summary>
		Shippingid,
		///<summary>PaymentMode. </summary>
		PaymentMode,
		///<summary>PaymentAmount. </summary>
		PaymentAmount,
		///<summary>IsPaymentSuccessful. </summary>
		IsPaymentSuccessful,
		///<summary>IsHafFilled. </summary>
		IsHafFilled,
		///<summary>EntryPage. </summary>
		EntryPage,
		///<summary>ExitPage. </summary>
		ExitPage,
		///<summary>Ipaddress. </summary>
		Ipaddress,
		///<summary>ScreenResolution. </summary>
		ScreenResolution,
		///<summary>Browser. </summary>
		Browser,
		///<summary>IsCompleted. </summary>
		IsCompleted,
		///<summary>IsExistingCustomer. </summary>
		IsExistingCustomer,
		///<summary>LoginAtempt. </summary>
		LoginAtempt,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>ShippingAddressId. </summary>
		ShippingAddressId,
		///<summary>InvitationCode. </summary>
		InvitationCode,
		///<summary>CorpCode. </summary>
		CorpCode,
		///<summary>Radius. </summary>
		Radius,
		///<summary>IsUsedAppointmentSlotExpiryExtension. </summary>
		IsUsedAppointmentSlotExpiryExtension,
		///<summary>MarketingSource. </summary>
		MarketingSource,
		///<summary>InChainAppointmentSlots. </summary>
		InChainAppointmentSlots,
		///<summary>PreliminarySelectedTime. </summary>
		PreliminarySelectedTime,
		///<summary>Gender. </summary>
		Gender,
		///<summary>Dob. </summary>
		Dob,
		///<summary>Version. </summary>
		Version,
		///<summary>EligibilityId. </summary>
		EligibilityId,
		///<summary>ChargeCardId. </summary>
		ChargeCardId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Template.
	/// </summary>
	public enum TemplateFieldIndex:int
	{
		///<summary>TemplateId. </summary>
		TemplateId,
		///<summary>TemplateText. </summary>
		TemplateText,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TemplateMacro.
	/// </summary>
	public enum TemplateMacroFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>IdentifierName. </summary>
		IdentifierName,
		///<summary>CodeString. </summary>
		CodeString,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TemplateTag.
	/// </summary>
	public enum TemplateTagFieldIndex:int
	{
		///<summary>TemplateTagId. </summary>
		TemplateTagId,
		///<summary>TemplateTagName. </summary>
		TemplateTagName,
		///<summary>TemplateTagFormula. </summary>
		TemplateTagFormula,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Territory.
	/// </summary>
	public enum TerritoryFieldIndex:int
	{
		///<summary>TerritoryId. </summary>
		TerritoryId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>Type. </summary>
		Type,
		///<summary>ParentTerritoryId. </summary>
		ParentTerritoryId,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TerritoryPackage.
	/// </summary>
	public enum TerritoryPackageFieldIndex:int
	{
		///<summary>TerritoryId. </summary>
		TerritoryId,
		///<summary>PackageId. </summary>
		PackageId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TerritoryZip.
	/// </summary>
	public enum TerritoryZipFieldIndex:int
	{
		///<summary>TerritoryId. </summary>
		TerritoryId,
		///<summary>ZipId. </summary>
		ZipId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Test.
	/// </summary>
	public enum TestFieldIndex:int
	{
		///<summary>TestId. </summary>
		TestId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>Alias. </summary>
		Alias,
		///<summary>Version. </summary>
		Version,
		///<summary>RelativeOrder. </summary>
		RelativeOrder,
		///<summary>Cptcode. </summary>
		Cptcode,
		///<summary>IsRecordable. </summary>
		IsRecordable,
		///<summary>IsTestReviewableByPhysician. </summary>
		IsTestReviewableByPhysician,
		///<summary>ShowInCustomerPdf. </summary>
		ShowInCustomerPdf,
		///<summary>Price. </summary>
		Price,
		///<summary>DefaultPackagePrice. </summary>
		DefaultPackagePrice,
		///<summary>RefundPrice. </summary>
		RefundPrice,
		///<summary>DefaultPackageRefundPrice. </summary>
		DefaultPackageRefundPrice,
		///<summary>MinAge. </summary>
		MinAge,
		///<summary>MaxAge. </summary>
		MaxAge,
		///<summary>ShowInAlaCarte. </summary>
		ShowInAlaCarte,
		///<summary>DiagnosisCode. </summary>
		DiagnosisCode,
		///<summary>ScreeningTime. </summary>
		ScreeningTime,
		///<summary>HafTemplateId. </summary>
		HafTemplateId,
		///<summary>IsSelectedByDefaultForEvent. </summary>
		IsSelectedByDefaultForEvent,
		///<summary>Gender. </summary>
		Gender,
		///<summary>GroupId. </summary>
		GroupId,
		///<summary>ReimbursementRate. </summary>
		ReimbursementRate,
		///<summary>WithPackagePrice. </summary>
		WithPackagePrice,
		///<summary>IsDefaultSelectionForPackage. </summary>
		IsDefaultSelectionForPackage,
		///<summary>IsDefaultSelectionForOrder. </summary>
		IsDefaultSelectionForOrder,
		///<summary>MediaUrl. </summary>
		MediaUrl,
		///<summary>IsBillableToHealthPlan. </summary>
		IsBillableToHealthPlan,
		///<summary>PreQualificationQuestionTemplateId. </summary>
		PreQualificationQuestionTemplateId,
		///<summary>ResultEntryTypeId. </summary>
		ResultEntryTypeId,
		///<summary>ChatStartDate. </summary>
		ChatStartDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TestAvailabilityToRoles.
	/// </summary>
	public enum TestAvailabilityToRolesFieldIndex:int
	{
		///<summary>TestId. </summary>
		TestId,
		///<summary>RoleId. </summary>
		RoleId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TestDependencyRule.
	/// </summary>
	public enum TestDependencyRuleFieldIndex:int
	{
		///<summary>DependantTestId. </summary>
		DependantTestId,
		///<summary>TestId. </summary>
		TestId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TestHcpcsCode.
	/// </summary>
	public enum TestHcpcsCodeFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>TestId. </summary>
		TestId,
		///<summary>HcpcsCodeId. </summary>
		HcpcsCodeId,
		///<summary>IsRetired. </summary>
		IsRetired,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>ModifiedDate. </summary>
		ModifiedDate,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Testimonial.
	/// </summary>
	public enum TestimonialFieldIndex:int
	{
		///<summary>TestimonialId. </summary>
		TestimonialId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>TestimonialText. </summary>
		TestimonialText,
		///<summary>FileId. </summary>
		FileId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsAccepted. </summary>
		IsAccepted,
		///<summary>Rank. </summary>
		Rank,
		///<summary>ReviewedBy. </summary>
		ReviewedBy,
		///<summary>ReviewedOn. </summary>
		ReviewedOn,
		///<summary>Comment. </summary>
		Comment,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TestIncidentalFinding.
	/// </summary>
	public enum TestIncidentalFindingFieldIndex:int
	{
		///<summary>TestId. </summary>
		TestId,
		///<summary>IncidentalFindingId. </summary>
		IncidentalFindingId,
		///<summary>Sequence. </summary>
		Sequence,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TestMedia.
	/// </summary>
	public enum TestMediaFieldIndex:int
	{
		///<summary>MediaId. </summary>
		MediaId,
		///<summary>CustomerEventScreeningTestId. </summary>
		CustomerEventScreeningTestId,
		///<summary>FileId. </summary>
		FileId,
		///<summary>ThumbnailFileId. </summary>
		ThumbnailFileId,
		///<summary>IsManual. </summary>
		IsManual,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TestNotPerformed.
	/// </summary>
	public enum TestNotPerformedFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CustomerEventScreeningTestId. </summary>
		CustomerEventScreeningTestId,
		///<summary>TestNotPerformedReasonId. </summary>
		TestNotPerformedReasonId,
		///<summary>Notes. </summary>
		Notes,
		///<summary>IsManual. </summary>
		IsManual,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>UpdatedBy. </summary>
		UpdatedBy,
		///<summary>UpdatedOn. </summary>
		UpdatedOn,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TestNotPerformedReason.
	/// </summary>
	public enum TestNotPerformedReasonFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Name. </summary>
		Name,
		///<summary>Alias. </summary>
		Alias,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TestOrderItem.
	/// </summary>
	public enum TestOrderItemFieldIndex:int
	{
		///<summary>OrderItemId. </summary>
		OrderItemId,
		///<summary>TestId. </summary>
		TestId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TestPerformedExternally.
	/// </summary>
	public enum TestPerformedExternallyFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CustomerEventScreeningTestId. </summary>
		CustomerEventScreeningTestId,
		///<summary>EntryCompleted. </summary>
		EntryCompleted,
		///<summary>ResultEntryTypeId. </summary>
		ResultEntryTypeId,
		///<summary>CreatedBy. </summary>
		CreatedBy,
		///<summary>CreatedDate. </summary>
		CreatedDate,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>ModifiedDate. </summary>
		ModifiedDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TestReading.
	/// </summary>
	public enum TestReadingFieldIndex:int
	{
		///<summary>TestReadingId. </summary>
		TestReadingId,
		///<summary>TestId. </summary>
		TestId,
		///<summary>ReadingId. </summary>
		ReadingId,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TestSourceCodeDiscount.
	/// </summary>
	public enum TestSourceCodeDiscountFieldIndex:int
	{
		///<summary>TestId. </summary>
		TestId,
		///<summary>SourceCodeId. </summary>
		SourceCodeId,
		///<summary>Discount. </summary>
		Discount,
		///<summary>IsPercentage. </summary>
		IsPercentage,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TestUnableScreenReason.
	/// </summary>
	public enum TestUnableScreenReasonFieldIndex:int
	{
		///<summary>TestUnableScreenReasonId. </summary>
		TestUnableScreenReasonId,
		///<summary>TestId. </summary>
		TestId,
		///<summary>UnableScreenReasonId. </summary>
		UnableScreenReasonId,
		///<summary>Description. </summary>
		Description,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ToolTip.
	/// </summary>
	public enum ToolTipFieldIndex:int
	{
		///<summary>TagId. </summary>
		TagId,
		///<summary>Tag. </summary>
		Tag,
		///<summary>Content. </summary>
		Content,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TrackingMarketing.
	/// </summary>
	public enum TrackingMarketingFieldIndex:int
	{
		///<summary>TrackingMarketingId. </summary>
		TrackingMarketingId,
		///<summary>SourceName. </summary>
		SourceName,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: UncontactedCustomerCallQueue.
	/// </summary>
	public enum UncontactedCustomerCallQueueFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Status. </summary>
		Status,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CallDate. </summary>
		CallDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: UncontactedCustomerCallQueueCriteriaAssignment.
	/// </summary>
	public enum UncontactedCustomerCallQueueCriteriaAssignmentFieldIndex:int
	{
		///<summary>UncontactedCustomerId. </summary>
		UncontactedCustomerId,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Unit.
	/// </summary>
	public enum UnitFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>Name. </summary>
		Name,
		///<summary>Alias. </summary>
		Alias,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: UploadTestInfo.
	/// </summary>
	public enum UploadTestInfoFieldIndex:int
	{
		///<summary>UploadTestInfoId. </summary>
		UploadTestInfoId,
		///<summary>UploadZipInfoId. </summary>
		UploadZipInfoId,
		///<summary>PatientId. </summary>
		PatientId,
		///<summary>GeneralReason. </summary>
		GeneralReason,
		///<summary>ActualReason. </summary>
		ActualReason,
		///<summary>FailedRecord. </summary>
		FailedRecord,
		///<summary>TestId. </summary>
		TestId,
		///<summary>IsSuccessful. </summary>
		IsSuccessful,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: UploadZipInfo.
	/// </summary>
	public enum UploadZipInfoFieldIndex:int
	{
		///<summary>UploadZipInfoId. </summary>
		UploadZipInfoId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>FileName. </summary>
		FileName,
		///<summary>FileSize. </summary>
		FileSize,
		///<summary>IsUploadSuccessful. </summary>
		IsUploadSuccessful,
		///<summary>IsParseSuccessful. </summary>
		IsParseSuccessful,
		///<summary>FailureCount. </summary>
		FailureCount,
		///<summary>RecordsNotInZip. </summary>
		RecordsNotInZip,
		///<summary>UploadStartTime. </summary>
		UploadStartTime,
		///<summary>UploadEndTime. </summary>
		UploadEndTime,
		///<summary>ParseStartTime. </summary>
		ParseStartTime,
		///<summary>ParseEndTime. </summary>
		ParseEndTime,
		///<summary>LogFilePath. </summary>
		LogFilePath,
		///<summary>PreviousFileDiscarded. </summary>
		PreviousFileDiscarded,
		///<summary>UploadedByOrgRoleUserId. </summary>
		UploadedByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: User.
	/// </summary>
	public enum UserFieldIndex:int
	{
		///<summary>UserId. </summary>
		UserId,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>MiddleName. </summary>
		MiddleName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>HomeAddressId. </summary>
		HomeAddressId,
		///<summary>PhoneOffice. </summary>
		PhoneOffice,
		///<summary>PhoneCell. </summary>
		PhoneCell,
		///<summary>PhoneHome. </summary>
		PhoneHome,
		///<summary>Email1. </summary>
		Email1,
		///<summary>Email2. </summary>
		Email2,
		///<summary>Picture. </summary>
		Picture,
		///<summary>Dob. </summary>
		Dob,
		///<summary>Ssn. </summary>
		Ssn,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>TempUserName. </summary>
		TempUserName,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DefaultRoleId. </summary>
		DefaultRoleId,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>ModifiedByOrgRoleUserId. </summary>
		ModifiedByOrgRoleUserId,
		///<summary>PhoneOfficeExtension. </summary>
		PhoneOfficeExtension,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: UserLogin.
	/// </summary>
	public enum UserLoginFieldIndex:int
	{
		///<summary>UserLoginId. </summary>
		UserLoginId,
		///<summary>UserName. </summary>
		UserName,
		///<summary>Password. </summary>
		Password,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsLocked. </summary>
		IsLocked,
		///<summary>LoginAttempts. </summary>
		LoginAttempts,
		///<summary>LastLogged. </summary>
		LastLogged,
		///<summary>UserSecurityQuestionId. </summary>
		UserSecurityQuestionId,
		///<summary>BrowserSessionId. </summary>
		BrowserSessionId,
		///<summary>UserVerified. </summary>
		UserVerified,
		///<summary>HintQuestion. </summary>
		HintQuestion,
		///<summary>HintAnswer. </summary>
		HintAnswer,
		///<summary>IsSecurityQuestionVerified. </summary>
		IsSecurityQuestionVerified,
		///<summary>ResetPwdQueryString. </summary>
		ResetPwdQueryString,
		///<summary>LastLoginAttemptAt. </summary>
		LastLoginAttemptAt,
		///<summary>Salt. </summary>
		Salt,
		///<summary>LastPasswordChangeDate. </summary>
		LastPasswordChangeDate,
		///<summary>IsTwoFactorAuthrequired. </summary>
		IsTwoFactorAuthrequired,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: UserLoginLog.
	/// </summary>
	public enum UserLoginLogFieldIndex:int
	{
		///<summary>UserLoginLogId. </summary>
		UserLoginLogId,
		///<summary>UserId. </summary>
		UserId,
		///<summary>LoginDatetime. </summary>
		LoginDatetime,
		///<summary>LogoutDatetime. </summary>
		LogoutDatetime,
		///<summary>BrowserSessionId. </summary>
		BrowserSessionId,
		///<summary>BrowserType. </summary>
		BrowserType,
		///<summary>SessionIp. </summary>
		SessionIp,
		///<summary>ReferredlUrl. </summary>
		ReferredlUrl,
		///<summary>DeviceKey. </summary>
		DeviceKey,
		///<summary>MedicareToken. </summary>
		MedicareToken,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: UserNpiInfo.
	/// </summary>
	public enum UserNpiInfoFieldIndex:int
	{
		///<summary>UserId. </summary>
		UserId,
		///<summary>Npi. </summary>
		Npi,
		///<summary>Credential. </summary>
		Credential,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: UserSecurityQuestion.
	/// </summary>
	public enum UserSecurityQuestionFieldIndex:int
	{
		///<summary>UserQuestionId. </summary>
		UserQuestionId,
		///<summary>Question1. </summary>
		Question1,
		///<summary>Answer1. </summary>
		Answer1,
		///<summary>Question2. </summary>
		Question2,
		///<summary>Answer2. </summary>
		Answer2,
		///<summary>Question3. </summary>
		Question3,
		///<summary>Answer3. </summary>
		Answer3,
		///<summary>DateCreation. </summary>
		DateCreation,
		///<summary>DateModification. </summary>
		DateModification,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VanDetails.
	/// </summary>
	public enum VanDetailsFieldIndex:int
	{
		///<summary>VanId. </summary>
		VanId,
		///<summary>RegistrationNumber. </summary>
		RegistrationNumber,
		///<summary>StateId. </summary>
		StateId,
		///<summary>Vin. </summary>
		Vin,
		///<summary>Name. </summary>
		Name,
		///<summary>Make. </summary>
		Make,
		///<summary>Description. </summary>
		Description,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwCallCenterCallReport.
	/// </summary>
	public enum VwCallCenterCallReportFieldIndex:int
	{
		///<summary>CallId. </summary>
		CallId,
		///<summary>IsNewCustomer. </summary>
		IsNewCustomer,
		///<summary>CalledCustomerId. </summary>
		CalledCustomerId,
		///<summary>TimeCreated. </summary>
		TimeCreated,
		///<summary>TimeEnd. </summary>
		TimeEnd,
		///<summary>CallStatus. </summary>
		CallStatus,
		///<summary>EventId. </summary>
		EventId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CallBackNumber. </summary>
		CallBackNumber,
		///<summary>IncomingPhoneLine. </summary>
		IncomingPhoneLine,
		///<summary>CallersPhoneNumber. </summary>
		CallersPhoneNumber,
		///<summary>OutBound. </summary>
		OutBound,
		///<summary>Status. </summary>
		Status,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>Disposition. </summary>
		Disposition,
		///<summary>ReadAndUnderstoodNotes. </summary>
		ReadAndUnderstoodNotes,
		///<summary>IsUploaded. </summary>
		IsUploaded,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>NotInterestedReasonId. </summary>
		NotInterestedReasonId,
		///<summary>CustomTags. </summary>
		CustomTags,
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>Tag. </summary>
		Tag,
		///<summary>CallQueueId. </summary>
		CallQueueId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwCallQueueCustomerCallDetails.
	/// </summary>
	public enum VwCallQueueCustomerCallDetailsFieldIndex:int
	{
		///<summary>CallId. </summary>
		CallId,
		///<summary>CalledCustomerId. </summary>
		CalledCustomerId,
		///<summary>TimeCreated. </summary>
		TimeCreated,
		///<summary>TimeEnd. </summary>
		TimeEnd,
		///<summary>CallStatus. </summary>
		CallStatus,
		///<summary>EventId. </summary>
		EventId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CallBackNumber. </summary>
		CallBackNumber,
		///<summary>IncomingPhoneLine. </summary>
		IncomingPhoneLine,
		///<summary>CallersPhoneNumber. </summary>
		CallersPhoneNumber,
		///<summary>CallerName. </summary>
		CallerName,
		///<summary>PromoCodeId. </summary>
		PromoCodeId,
		///<summary>AffiliateId. </summary>
		AffiliateId,
		///<summary>OutBound. </summary>
		OutBound,
		///<summary>Status. </summary>
		Status,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>Disposition. </summary>
		Disposition,
		///<summary>ReadAndUnderstoodNotes. </summary>
		ReadAndUnderstoodNotes,
		///<summary>IsUploaded. </summary>
		IsUploaded,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>NotInterestedReasonId. </summary>
		NotInterestedReasonId,
		///<summary>CallQueueCustomerId. </summary>
		CallQueueCustomerId,
		///<summary>CallQueueId. </summary>
		CallQueueId,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwCallQueueCustomerCriteraAssignment.
	/// </summary>
	public enum VwCallQueueCustomerCriteraAssignmentFieldIndex:int
	{
		///<summary>CallQueueCustomerId. </summary>
		CallQueueCustomerId,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		///<summary>CallQueueId. </summary>
		CallQueueId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Status. </summary>
		Status,
		///<summary>Attempts. </summary>
		Attempts,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>ModifiedByOrgRoleUserId. </summary>
		ModifiedByOrgRoleUserId,
		///<summary>AssignedToOrgRoleUserId. </summary>
		AssignedToOrgRoleUserId,
		///<summary>CallQueueCriteriaId. </summary>
		CallQueueCriteriaId,
		///<summary>CallDate. </summary>
		CallDate,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>EventIds. </summary>
		EventIds,
		///<summary>CallCount. </summary>
		CallCount,
		///<summary>Tag. </summary>
		Tag,
		///<summary>CallBackRequestedDate. </summary>
		CallBackRequestedDate,
		///<summary>LastContactedDate. </summary>
		LastContactedDate,
		///<summary>CallStatus. </summary>
		CallStatus,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwCallQueueCustomerCriteraAssignmentForGms.
	/// </summary>
	public enum VwCallQueueCustomerCriteraAssignmentForGmsFieldIndex:int
	{
		///<summary>CallQueueCustomerId. </summary>
		CallQueueCustomerId,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		///<summary>CallQueueId. </summary>
		CallQueueId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Status. </summary>
		Status,
		///<summary>Attempts. </summary>
		Attempts,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CallDate. </summary>
		CallDate,
		///<summary>CallCount. </summary>
		CallCount,
		///<summary>ZipId. </summary>
		ZipId,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>EventIds. </summary>
		EventIds,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>MiddleName. </summary>
		MiddleName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>ZipCode. </summary>
		ZipCode,
		///<summary>IsLanguageBarrier. </summary>
		IsLanguageBarrier,
		///<summary>CallStatus. </summary>
		CallStatus,
		///<summary>ContactedDate. </summary>
		ContactedDate,
		///<summary>Disposition. </summary>
		Disposition,
		///<summary>AppointmentDate. </summary>
		AppointmentDate,
		///<summary>AppointmentCancellationDate. </summary>
		AppointmentCancellationDate,
		///<summary>LanguageBarrierMarkedDate. </summary>
		LanguageBarrierMarkedDate,
		///<summary>IncorrectPhoneNumberMarkedDate. </summary>
		IncorrectPhoneNumberMarkedDate,
		///<summary>NoShowDate. </summary>
		NoShowDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwCallQueueCustomerCriteraAssignmentForGmsStats.
	/// </summary>
	public enum VwCallQueueCustomerCriteraAssignmentForGmsStatsFieldIndex:int
	{
		///<summary>CallQueueCustomerId. </summary>
		CallQueueCustomerId,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		///<summary>CallQueueId. </summary>
		CallQueueId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Status. </summary>
		Status,
		///<summary>Attempts. </summary>
		Attempts,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CallDate. </summary>
		CallDate,
		///<summary>CallCount. </summary>
		CallCount,
		///<summary>ZipId. </summary>
		ZipId,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>EventIds. </summary>
		EventIds,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>MiddleName. </summary>
		MiddleName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>ZipCode. </summary>
		ZipCode,
		///<summary>IsLanguageBarrier. </summary>
		IsLanguageBarrier,
		///<summary>CallStatus. </summary>
		CallStatus,
		///<summary>ContactedDate. </summary>
		ContactedDate,
		///<summary>Disposition. </summary>
		Disposition,
		///<summary>AppointmentDate. </summary>
		AppointmentDate,
		///<summary>AppointmentCancellationDate. </summary>
		AppointmentCancellationDate,
		///<summary>IsEligble. </summary>
		IsEligble,
		///<summary>ActivityId. </summary>
		ActivityId,
		///<summary>PhoneCell. </summary>
		PhoneCell,
		///<summary>PhoneHome. </summary>
		PhoneHome,
		///<summary>PhoneOffice. </summary>
		PhoneOffice,
		///<summary>IsIncorrectPhoneNumber. </summary>
		IsIncorrectPhoneNumber,
		///<summary>DoNotContactTypeId. </summary>
		DoNotContactTypeId,
		///<summary>CallBackRequestedDate. </summary>
		CallBackRequestedDate,
		///<summary>DoNotContactUpdateDate. </summary>
		DoNotContactUpdateDate,
		///<summary>DoNotContactUpdateSource. </summary>
		DoNotContactUpdateSource,
		///<summary>LanguageBarrierMarkedDate. </summary>
		LanguageBarrierMarkedDate,
		///<summary>IncorrectPhoneNumberMarkedDate. </summary>
		IncorrectPhoneNumberMarkedDate,
		///<summary>NoShowDate. </summary>
		NoShowDate,
		///<summary>TargetedYear. </summary>
		TargetedYear,
		///<summary>IsTargeted. </summary>
		IsTargeted,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwCallQueueCustomerCriteraAssignmentForStats.
	/// </summary>
	public enum VwCallQueueCustomerCriteraAssignmentForStatsFieldIndex:int
	{
		///<summary>CallQueueCustomerId. </summary>
		CallQueueCustomerId,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		///<summary>CallQueueId. </summary>
		CallQueueId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Status. </summary>
		Status,
		///<summary>Attempts. </summary>
		Attempts,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CallDate. </summary>
		CallDate,
		///<summary>CallCount. </summary>
		CallCount,
		///<summary>ZipId. </summary>
		ZipId,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>EventIds. </summary>
		EventIds,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>MiddleName. </summary>
		MiddleName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>ZipCode. </summary>
		ZipCode,
		///<summary>IsLanguageBarrier. </summary>
		IsLanguageBarrier,
		///<summary>CallStatus. </summary>
		CallStatus,
		///<summary>ContactedDate. </summary>
		ContactedDate,
		///<summary>Disposition. </summary>
		Disposition,
		///<summary>AppointmentDate. </summary>
		AppointmentDate,
		///<summary>AppointmentCancellationDate. </summary>
		AppointmentCancellationDate,
		///<summary>IsEligble. </summary>
		IsEligble,
		///<summary>ActivityId. </summary>
		ActivityId,
		///<summary>PhoneCell. </summary>
		PhoneCell,
		///<summary>PhoneHome. </summary>
		PhoneHome,
		///<summary>PhoneOffice. </summary>
		PhoneOffice,
		///<summary>IsIncorrectPhoneNumber. </summary>
		IsIncorrectPhoneNumber,
		///<summary>DoNotContactTypeId. </summary>
		DoNotContactTypeId,
		///<summary>CallBackRequestedDate. </summary>
		CallBackRequestedDate,
		///<summary>DoNotContactUpdateDate. </summary>
		DoNotContactUpdateDate,
		///<summary>DoNotContactUpdateSource. </summary>
		DoNotContactUpdateSource,
		///<summary>LanguageBarrierMarkedDate. </summary>
		LanguageBarrierMarkedDate,
		///<summary>IncorrectPhoneNumberMarkedDate. </summary>
		IncorrectPhoneNumberMarkedDate,
		///<summary>NoShowDate. </summary>
		NoShowDate,
		///<summary>TargetedYear. </summary>
		TargetedYear,
		///<summary>IsTargeted. </summary>
		IsTargeted,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwCallQueueCustomerCriteraAssignmentWithCustomer.
	/// </summary>
	public enum VwCallQueueCustomerCriteraAssignmentWithCustomerFieldIndex:int
	{
		///<summary>CallQueueCustomerId. </summary>
		CallQueueCustomerId,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		///<summary>CallQueueId. </summary>
		CallQueueId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Status. </summary>
		Status,
		///<summary>Attempts. </summary>
		Attempts,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>ModifiedByOrgRoleUserId. </summary>
		ModifiedByOrgRoleUserId,
		///<summary>AssignedToOrgRoleUserId. </summary>
		AssignedToOrgRoleUserId,
		///<summary>CallQueueCriteriaId. </summary>
		CallQueueCriteriaId,
		///<summary>CallDate. </summary>
		CallDate,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>EventIds. </summary>
		EventIds,
		///<summary>CallCount. </summary>
		CallCount,
		///<summary>ZipId. </summary>
		ZipId,
		///<summary>IsLanguageBarrier. </summary>
		IsLanguageBarrier,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwCallRoundCallQueueCriteraAssignment.
	/// </summary>
	public enum VwCallRoundCallQueueCriteraAssignmentFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Status. </summary>
		Status,
		///<summary>Attempt. </summary>
		Attempt,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>CallDate. </summary>
		CallDate,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CallCount. </summary>
		CallCount,
		///<summary>TagCount. </summary>
		TagCount,
		///<summary>Tags. </summary>
		Tags,
		///<summary>ZipId. </summary>
		ZipId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwCampaignClickConversion.
	/// </summary>
	public enum VwCampaignClickConversionFieldIndex:int
	{
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>CampaignName. </summary>
		CampaignName,
		///<summary>ClickId. </summary>
		ClickId,
		///<summary>Keyword. </summary>
		Keyword,
		///<summary>ProspectCustomerId. </summary>
		ProspectCustomerId,
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>ClickConversionId. </summary>
		ClickConversionId,
		///<summary>MarketingMaterialId. </summary>
		MarketingMaterialId,
		///<summary>Timestamp. </summary>
		Timestamp,
		///<summary>IpAddress. </summary>
		IpAddress,
		///<summary>PriorReferrer. </summary>
		PriorReferrer,
		///<summary>Referrer. </summary>
		Referrer,
		///<summary>BrowserClient. </summary>
		BrowserClient,
		///<summary>ResolutionHeight. </summary>
		ResolutionHeight,
		///<summary>ResolutionWidth. </summary>
		ResolutionWidth,
		///<summary>KeywordClickId. </summary>
		KeywordClickId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwCustomerAggregateResultSummary.
	/// </summary>
	public enum VwCustomerAggregateResultSummaryFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>NoShow. </summary>
		NoShow,
		///<summary>HiPaastatus. </summary>
		HiPaastatus,
		///<summary>PartnerRelease. </summary>
		PartnerRelease,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>AppointmentId. </summary>
		AppointmentId,
		///<summary>ResultState. </summary>
		ResultState,
		///<summary>ResultSummary. </summary>
		ResultSummary,
		///<summary>ResultStatusUpdatedDate. </summary>
		ResultStatusUpdatedDate,
		///<summary>ResultSummaryOrder. </summary>
		ResultSummaryOrder,
		///<summary>EventId. </summary>
		EventId,
		///<summary>EventDate. </summary>
		EventDate,
		///<summary>EventTypeId. </summary>
		EventTypeId,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>MiddleName. </summary>
		MiddleName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>Dob. </summary>
		Dob,
		///<summary>PhoneHome. </summary>
		PhoneHome,
		///<summary>PhoneCell. </summary>
		PhoneCell,
		///<summary>PhoneOffice. </summary>
		PhoneOffice,
		///<summary>CorporateAccountId. </summary>
		CorporateAccountId,
		///<summary>HospitalPartnerId. </summary>
		HospitalPartnerId,
		///<summary>HospitalPartnerStatus. </summary>
		HospitalPartnerStatus,
		///<summary>HospitalPartnerStatusOrder. </summary>
		HospitalPartnerStatusOrder,
		///<summary>HospitalPartnerLastModifiedDate. </summary>
		HospitalPartnerLastModifiedDate,
		///<summary>ShippingStatus. </summary>
		ShippingStatus,
		///<summary>ShipmentDate. </summary>
		ShipmentDate,
		///<summary>InitialCallDate. </summary>
		InitialCallDate,
		///<summary>HospitalFacilityId. </summary>
		HospitalFacilityId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwEventAppointment.
	/// </summary>
	public enum VwEventAppointmentFieldIndex:int
	{
		///<summary>AppointmentId. </summary>
		AppointmentId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>StartTime. </summary>
		StartTime,
		///<summary>EndTime. </summary>
		EndTime,
		///<summary>CheckinTime. </summary>
		CheckinTime,
		///<summary>CheckoutTime. </summary>
		CheckoutTime,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>ScheduledByOrgRoleUserId. </summary>
		ScheduledByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwEventCustomerPreApprovedTestList.
	/// </summary>
	public enum VwEventCustomerPreApprovedTestListFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>TestId. </summary>
		TestId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwEventCustomersAccount.
	/// </summary>
	public enum VwEventCustomersAccountFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>IsPaymentOnline. </summary>
		IsPaymentOnline,
		///<summary>AppointmentId. </summary>
		AppointmentId,
		///<summary>IsTestConducted. </summary>
		IsTestConducted,
		///<summary>BMailReports. </summary>
		BMailReports,
		///<summary>Notes. </summary>
		Notes,
		///<summary>NoShow. </summary>
		NoShow,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>OfflineCustomerId. </summary>
		OfflineCustomerId,
		///<summary>AffiliateCampaignId. </summary>
		AffiliateCampaignId,
		///<summary>SignInSource. </summary>
		SignInSource,
		///<summary>AdvocateId. </summary>
		AdvocateId,
		///<summary>Hipaastatus. </summary>
		Hipaastatus,
		///<summary>MarketingSource. </summary>
		MarketingSource,
		///<summary>ClickId. </summary>
		ClickId,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>PartnerRelease. </summary>
		PartnerRelease,
		///<summary>HospitalFacilityId. </summary>
		HospitalFacilityId,
		///<summary>Abnstatus. </summary>
		Abnstatus,
		///<summary>PcpconsentStatus. </summary>
		PcpconsentStatus,
		///<summary>InsuranceReleaseStatus. </summary>
		InsuranceReleaseStatus,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>LeftWithoutScreeningReasonId. </summary>
		LeftWithoutScreeningReasonId,
		///<summary>AwvVisitId. </summary>
		AwvVisitId,
		///<summary>EnableTexting. </summary>
		EnableTexting,
		///<summary>IsGiftCertificateDelivered. </summary>
		IsGiftCertificateDelivered,
		///<summary>GiftCode. </summary>
		GiftCode,
		///<summary>PatientDetailId. </summary>
		PatientDetailId,
		///<summary>EventDate. </summary>
		EventDate,
		///<summary>EventStatus. </summary>
		EventStatus,
		///<summary>EventTypeId. </summary>
		EventTypeId,
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>IsAppointmentConfirmed. </summary>
		IsAppointmentConfirmed,
		///<summary>ConfirmedBy. </summary>
		ConfirmedBy,
		///<summary>PreferredContactType. </summary>
		PreferredContactType,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwEventCustomersViewServiceReport.
	/// </summary>
	public enum VwEventCustomersViewServiceReportFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>EventDate. </summary>
		EventDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwFillEventCallQueueCriteraAssignment.
	/// </summary>
	public enum VwFillEventCallQueueCriteraAssignmentFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Status. </summary>
		Status,
		///<summary>Attempt. </summary>
		Attempt,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>CallDate. </summary>
		CallDate,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>EventIds. </summary>
		EventIds,
		///<summary>CallCount. </summary>
		CallCount,
		///<summary>TagCount. </summary>
		TagCount,
		///<summary>Tags. </summary>
		Tags,
		///<summary>ZipId. </summary>
		ZipId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetAllTestForCustomers.
	/// </summary>
	public enum VwGetAllTestForCustomersFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>TestId. </summary>
		TestId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetBookedAppointmentForCalculatingBonus.
	/// </summary>
	public enum VwGetBookedAppointmentForCalculatingBonusFieldIndex:int
	{
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetCallCenterAgentsForConversionReport.
	/// </summary>
	public enum VwGetCallCenterAgentsForConversionReportFieldIndex:int
	{
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CallQueueId. </summary>
		CallQueueId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetCallQueueCustomers.
	/// </summary>
	public enum VwGetCallQueueCustomersFieldIndex:int
	{
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Gender. </summary>
		Gender,
		///<summary>Race. </summary>
		Race,
		///<summary>DoNotContactReasonId. </summary>
		DoNotContactReasonId,
		///<summary>DoNotContactReasonNotesId. </summary>
		DoNotContactReasonNotesId,
		///<summary>RequestNewsLetter. </summary>
		RequestNewsLetter,
		///<summary>IsEligble. </summary>
		IsEligble,
		///<summary>IsIncorrectPhoneNumber. </summary>
		IsIncorrectPhoneNumber,
		///<summary>IsLanguageBarrier. </summary>
		IsLanguageBarrier,
		///<summary>ActivityId. </summary>
		ActivityId,
		///<summary>DoNotContactTypeId. </summary>
		DoNotContactTypeId,
		///<summary>BillingAddressId. </summary>
		BillingAddressId,
		///<summary>InsuranceId. </summary>
		InsuranceId,
		///<summary>Tag. </summary>
		Tag,
		///<summary>ZipId. </summary>
		ZipId,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CallQueueId. </summary>
		CallQueueId,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		///<summary>CampaignId. </summary>
		CampaignId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetCallQueueExcludedCustomers.
	/// </summary>
	public enum VwGetCallQueueExcludedCustomersFieldIndex:int
	{
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Tag. </summary>
		Tag,
		///<summary>ActivityId. </summary>
		ActivityId,
		///<summary>IsEligble. </summary>
		IsEligble,
		///<summary>IsIncorrectPhoneNumber. </summary>
		IsIncorrectPhoneNumber,
		///<summary>InsuranceId. </summary>
		InsuranceId,
		///<summary>DoNotContactTypeId. </summary>
		DoNotContactTypeId,
		///<summary>DoNotContactUpdateDate. </summary>
		DoNotContactUpdateDate,
		///<summary>ZipCode. </summary>
		ZipCode,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetCalls.
	/// </summary>
	public enum VwGetCallsFieldIndex:int
	{
		///<summary>CallId. </summary>
		CallId,
		///<summary>IsNewCustomer. </summary>
		IsNewCustomer,
		///<summary>CalledCustomerId. </summary>
		CalledCustomerId,
		///<summary>TimeCreated. </summary>
		TimeCreated,
		///<summary>TimeEnd. </summary>
		TimeEnd,
		///<summary>CallStatus. </summary>
		CallStatus,
		///<summary>EventId. </summary>
		EventId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CallBackNumber. </summary>
		CallBackNumber,
		///<summary>IncomingPhoneLine. </summary>
		IncomingPhoneLine,
		///<summary>CallersPhoneNumber. </summary>
		CallersPhoneNumber,
		///<summary>CallerName. </summary>
		CallerName,
		///<summary>PromoCodeId. </summary>
		PromoCodeId,
		///<summary>AffiliateId. </summary>
		AffiliateId,
		///<summary>OutBound. </summary>
		OutBound,
		///<summary>Status. </summary>
		Status,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>Disposition. </summary>
		Disposition,
		///<summary>ReadAndUnderstoodNotes. </summary>
		ReadAndUnderstoodNotes,
		///<summary>IsUploaded. </summary>
		IsUploaded,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>NotInterestedReasonId. </summary>
		NotInterestedReasonId,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CallQueueId. </summary>
		CallQueueId,
		///<summary>CustomTags. </summary>
		CustomTags,
		///<summary>IsContacted. </summary>
		IsContacted,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetCallsForCalculatingBonus.
	/// </summary>
	public enum VwGetCallsForCalculatingBonusFieldIndex:int
	{
		///<summary>CallId. </summary>
		CallId,
		///<summary>CalledCustomerId. </summary>
		CalledCustomerId,
		///<summary>TimeCreated. </summary>
		TimeCreated,
		///<summary>TimeEnd. </summary>
		TimeEnd,
		///<summary>CallStatus. </summary>
		CallStatus,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>Status. </summary>
		Status,
		///<summary>OutBound. </summary>
		OutBound,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetCallsForCallQueue.
	/// </summary>
	public enum VwGetCallsForCallQueueFieldIndex:int
	{
		///<summary>CallId. </summary>
		CallId,
		///<summary>CalledCustomerId. </summary>
		CalledCustomerId,
		///<summary>TimeCreated. </summary>
		TimeCreated,
		///<summary>TimeEnd. </summary>
		TimeEnd,
		///<summary>CallStatus. </summary>
		CallStatus,
		///<summary>EventId. </summary>
		EventId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>OutBound. </summary>
		OutBound,
		///<summary>Status. </summary>
		Status,
		///<summary>Disposition. </summary>
		Disposition,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>Tag. </summary>
		Tag,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetCallsForSuppression.
	/// </summary>
	public enum VwGetCallsForSuppressionFieldIndex:int
	{
		///<summary>CallId. </summary>
		CallId,
		///<summary>CalledCustomerId. </summary>
		CalledCustomerId,
		///<summary>TimeCreated. </summary>
		TimeCreated,
		///<summary>TimeEnd. </summary>
		TimeEnd,
		///<summary>CallStatus. </summary>
		CallStatus,
		///<summary>EventId. </summary>
		EventId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>OutBound. </summary>
		OutBound,
		///<summary>Status. </summary>
		Status,
		///<summary>Disposition. </summary>
		Disposition,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>MaxDays. </summary>
		MaxDays,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetConfirmationCallQueueCustomersWithoutSuppression.
	/// </summary>
	public enum VwGetConfirmationCallQueueCustomersWithoutSuppressionFieldIndex:int
	{
		///<summary>CallQueueCustomerId. </summary>
		CallQueueCustomerId,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		///<summary>CallQueueId. </summary>
		CallQueueId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>MiddleName. </summary>
		MiddleName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>Status. </summary>
		Status,
		///<summary>Attempts. </summary>
		Attempts,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CallDate. </summary>
		CallDate,
		///<summary>CallCount. </summary>
		CallCount,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>AppointmentDate. </summary>
		AppointmentDate,
		///<summary>AppointmentDateTimeWithTimeZone. </summary>
		AppointmentDateTimeWithTimeZone,
		///<summary>LanguageId. </summary>
		LanguageId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetCustomerForMailRoundInsertion.
	/// </summary>
	public enum VwGetCustomerForMailRoundInsertionFieldIndex:int
	{
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>DoNotContactReasonId. </summary>
		DoNotContactReasonId,
		///<summary>DoNotContactReasonNotesId. </summary>
		DoNotContactReasonNotesId,
		///<summary>IsEligble. </summary>
		IsEligble,
		///<summary>IsIncorrectPhoneNumber. </summary>
		IsIncorrectPhoneNumber,
		///<summary>IsLanguageBarrier. </summary>
		IsLanguageBarrier,
		///<summary>ActivityId. </summary>
		ActivityId,
		///<summary>DoNotContactTypeId. </summary>
		DoNotContactTypeId,
		///<summary>Tag. </summary>
		Tag,
		///<summary>ZipId. </summary>
		ZipId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetCustomerIdsHavingSingleTagForCallQueue.
	/// </summary>
	public enum VwGetCustomerIdsHavingSingleTagForCallQueueFieldIndex:int
	{
		///<summary>CustomerId. </summary>
		CustomerId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetCustomersForCallQueueWithCustomer.
	/// </summary>
	public enum VwGetCustomersForCallQueueWithCustomerFieldIndex:int
	{
		///<summary>CallQueueCustomerId. </summary>
		CallQueueCustomerId,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		///<summary>CallQueueId. </summary>
		CallQueueId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Status. </summary>
		Status,
		///<summary>Attempts. </summary>
		Attempts,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CallDate. </summary>
		CallDate,
		///<summary>CallCount. </summary>
		CallCount,
		///<summary>ZipId. </summary>
		ZipId,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>EventIds. </summary>
		EventIds,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>MiddleName. </summary>
		MiddleName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>ZipCode. </summary>
		ZipCode,
		///<summary>IsLanguageBarrier. </summary>
		IsLanguageBarrier,
		///<summary>CallStatus. </summary>
		CallStatus,
		///<summary>ContactedDate. </summary>
		ContactedDate,
		///<summary>Disposition. </summary>
		Disposition,
		///<summary>AppointmentDate. </summary>
		AppointmentDate,
		///<summary>AppointmentCancellationDate. </summary>
		AppointmentCancellationDate,
		///<summary>LanguageBarrierMarkedDate. </summary>
		LanguageBarrierMarkedDate,
		///<summary>IncorrectPhoneNumberMarkedDate. </summary>
		IncorrectPhoneNumberMarkedDate,
		///<summary>NoShowDate. </summary>
		NoShowDate,
		///<summary>ProductTypeId. </summary>
		ProductTypeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetCustomersForCallQueueWithCustomerVici.
	/// </summary>
	public enum VwGetCustomersForCallQueueWithCustomerViciFieldIndex:int
	{
		///<summary>CallQueueCustomerId. </summary>
		CallQueueCustomerId,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		///<summary>CallQueueId. </summary>
		CallQueueId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Status. </summary>
		Status,
		///<summary>Attempts. </summary>
		Attempts,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CallDate. </summary>
		CallDate,
		///<summary>CallCount. </summary>
		CallCount,
		///<summary>ZipId. </summary>
		ZipId,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>EventIds. </summary>
		EventIds,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>MiddleName. </summary>
		MiddleName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>ZipCode. </summary>
		ZipCode,
		///<summary>IsLanguageBarrier. </summary>
		IsLanguageBarrier,
		///<summary>CallStatus. </summary>
		CallStatus,
		///<summary>ContactedDate. </summary>
		ContactedDate,
		///<summary>Disposition. </summary>
		Disposition,
		///<summary>AppointmentDate. </summary>
		AppointmentDate,
		///<summary>AppointmentCancellationDate. </summary>
		AppointmentCancellationDate,
		///<summary>LanguageBarrierMarkedDate. </summary>
		LanguageBarrierMarkedDate,
		///<summary>IncorrectPhoneNumberMarkedDate. </summary>
		IncorrectPhoneNumberMarkedDate,
		///<summary>NoShowDate. </summary>
		NoShowDate,
		///<summary>ProductTypeId. </summary>
		ProductTypeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetCustomersForConfirmationCallQueue.
	/// </summary>
	public enum VwGetCustomersForConfirmationCallQueueFieldIndex:int
	{
		///<summary>CallQueueCustomerId. </summary>
		CallQueueCustomerId,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		///<summary>CallQueueId. </summary>
		CallQueueId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>MiddleName. </summary>
		MiddleName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>Status. </summary>
		Status,
		///<summary>Attempts. </summary>
		Attempts,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CallDate. </summary>
		CallDate,
		///<summary>CallCount. </summary>
		CallCount,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>AppointmentDate. </summary>
		AppointmentDate,
		///<summary>AppointmentDateTimeWithTimeZone. </summary>
		AppointmentDateTimeWithTimeZone,
		///<summary>LanguageId. </summary>
		LanguageId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetCustomersForNotInCallQueue.
	/// </summary>
	public enum VwGetCustomersForNotInCallQueueFieldIndex:int
	{
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Gender. </summary>
		Gender,
		///<summary>Race. </summary>
		Race,
		///<summary>DoNotContactReasonId. </summary>
		DoNotContactReasonId,
		///<summary>DoNotContactReasonNotesId. </summary>
		DoNotContactReasonNotesId,
		///<summary>RequestNewsLetter. </summary>
		RequestNewsLetter,
		///<summary>IsEligble. </summary>
		IsEligble,
		///<summary>IsIncorrectPhoneNumber. </summary>
		IsIncorrectPhoneNumber,
		///<summary>IsLanguageBarrier. </summary>
		IsLanguageBarrier,
		///<summary>ActivityId. </summary>
		ActivityId,
		///<summary>DoNotContactTypeId. </summary>
		DoNotContactTypeId,
		///<summary>BillingAddressId. </summary>
		BillingAddressId,
		///<summary>InsuranceId. </summary>
		InsuranceId,
		///<summary>Tag. </summary>
		Tag,
		///<summary>ZipId. </summary>
		ZipId,
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>ZipCode. </summary>
		ZipCode,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetCustomersToGenerateCallQueue.
	/// </summary>
	public enum VwGetCustomersToGenerateCallQueueFieldIndex:int
	{
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Gender. </summary>
		Gender,
		///<summary>Race. </summary>
		Race,
		///<summary>DoNotContactReasonId. </summary>
		DoNotContactReasonId,
		///<summary>DoNotContactReasonNotesId. </summary>
		DoNotContactReasonNotesId,
		///<summary>RequestNewsLetter. </summary>
		RequestNewsLetter,
		///<summary>IsEligble. </summary>
		IsEligble,
		///<summary>IsIncorrectPhoneNumber. </summary>
		IsIncorrectPhoneNumber,
		///<summary>IsLanguageBarrier. </summary>
		IsLanguageBarrier,
		///<summary>ActivityId. </summary>
		ActivityId,
		///<summary>DoNotContactTypeId. </summary>
		DoNotContactTypeId,
		///<summary>BillingAddressId. </summary>
		BillingAddressId,
		///<summary>InsuranceId. </summary>
		InsuranceId,
		///<summary>Tag. </summary>
		Tag,
		///<summary>ZipId. </summary>
		ZipId,
		///<summary>LanguageBarrierMarkedDate. </summary>
		LanguageBarrierMarkedDate,
		///<summary>IncorrectPhoneNumberMarkedDate. </summary>
		IncorrectPhoneNumberMarkedDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetCustomersToGenerateConfirmationCallQueue.
	/// </summary>
	public enum VwGetCustomersToGenerateConfirmationCallQueueFieldIndex:int
	{
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Tag. </summary>
		Tag,
		///<summary>EventId. </summary>
		EventId,
		///<summary>EventDate. </summary>
		EventDate,
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>AppointmentTime. </summary>
		AppointmentTime,
		///<summary>TimeZone. </summary>
		TimeZone,
		///<summary>StateId. </summary>
		StateId,
		///<summary>StateCode. </summary>
		StateCode,
		///<summary>LanguageId. </summary>
		LanguageId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetCustomersToGenerateFillEventCallQueue.
	/// </summary>
	public enum VwGetCustomersToGenerateFillEventCallQueueFieldIndex:int
	{
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>IsLanguageBarrier. </summary>
		IsLanguageBarrier,
		///<summary>Tag. </summary>
		Tag,
		///<summary>LanguageBarrierMarkedDate. </summary>
		LanguageBarrierMarkedDate,
		///<summary>IsMammoPatient. </summary>
		IsMammoPatient,
		///<summary>ZipId. </summary>
		ZipId,
		///<summary>ProductTypeId. </summary>
		ProductTypeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetCustomersToGenerateFillEventCallQueue_.
	/// </summary>
	public enum VwGetCustomersToGenerateFillEventCallQueue_FieldIndex:int
	{
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>IsLanguageBarrier. </summary>
		IsLanguageBarrier,
		///<summary>Tag. </summary>
		Tag,
		///<summary>LanguageBarrierMarkedDate. </summary>
		LanguageBarrierMarkedDate,
		///<summary>IsMammoPatient. </summary>
		IsMammoPatient,
		///<summary>ZipId. </summary>
		ZipId,
		///<summary>ProductTypeId. </summary>
		ProductTypeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetCustomerTagForCallQueue.
	/// </summary>
	public enum VwGetCustomerTagForCallQueueFieldIndex:int
	{
		///<summary>CustomerTagId. </summary>
		CustomerTagId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Tag. </summary>
		Tag,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>ModifiedByOrgRoleUserId. </summary>
		ModifiedByOrgRoleUserId,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetDataForSkippedCallReport.
	/// </summary>
	public enum VwGetDataForSkippedCallReportFieldIndex:int
	{
		///<summary>CallId. </summary>
		CallId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>AgentId. </summary>
		AgentId,
		///<summary>CallQueueCustomerId. </summary>
		CallQueueCustomerId,
		///<summary>CallAttemptId. </summary>
		CallAttemptId,
		///<summary>SkipCallNote. </summary>
		SkipCallNote,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CallQueueId. </summary>
		CallQueueId,
		///<summary>SkipCallDate. </summary>
		SkipCallDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetDirectMailForCallQueue.
	/// </summary>
	public enum VwGetDirectMailForCallQueueFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>MailDate. </summary>
		MailDate,
		///<summary>MailedBy. </summary>
		MailedBy,
		///<summary>CallUploadId. </summary>
		CallUploadId,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>DirectMailTypeId. </summary>
		DirectMailTypeId,
		///<summary>IsInvalidAddress. </summary>
		IsInvalidAddress,
		///<summary>Notes. </summary>
		Notes,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetEventCustomerEawvTestInOrder.
	/// </summary>
	public enum VwGetEventCustomerEawvTestInOrderFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>OrderId. </summary>
		OrderId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetHkynTestCustomers.
	/// </summary>
	public enum VwGetHkynTestCustomersFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>OrderId. </summary>
		OrderId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetKynTestCustomers.
	/// </summary>
	public enum VwGetKynTestCustomersFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>OrderId. </summary>
		OrderId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetMyBioCheckTestCustomers.
	/// </summary>
	public enum VwGetMyBioCheckTestCustomersFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>OrderId. </summary>
		OrderId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetOutboundCalls.
	/// </summary>
	public enum VwGetOutboundCallsFieldIndex:int
	{
		///<summary>CallId. </summary>
		CallId,
		///<summary>IsNewCustomer. </summary>
		IsNewCustomer,
		///<summary>CalledCustomerId. </summary>
		CalledCustomerId,
		///<summary>TimeCreated. </summary>
		TimeCreated,
		///<summary>TimeEnd. </summary>
		TimeEnd,
		///<summary>CallStatus. </summary>
		CallStatus,
		///<summary>EventId. </summary>
		EventId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CallBackNumber. </summary>
		CallBackNumber,
		///<summary>IncomingPhoneLine. </summary>
		IncomingPhoneLine,
		///<summary>CallersPhoneNumber. </summary>
		CallersPhoneNumber,
		///<summary>CallerName. </summary>
		CallerName,
		///<summary>PromoCodeId. </summary>
		PromoCodeId,
		///<summary>AffiliateId. </summary>
		AffiliateId,
		///<summary>OutBound. </summary>
		OutBound,
		///<summary>Status. </summary>
		Status,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>Disposition. </summary>
		Disposition,
		///<summary>ReadAndUnderstoodNotes. </summary>
		ReadAndUnderstoodNotes,
		///<summary>IsUploaded. </summary>
		IsUploaded,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>NotInterestedReasonId. </summary>
		NotInterestedReasonId,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CallQueueId. </summary>
		CallQueueId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwGetTestPerformedReport.
	/// </summary>
	public enum VwGetTestPerformedReportFieldIndex:int
	{
		///<summary>EventId. </summary>
		EventId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>EventDate. </summary>
		EventDate,
		///<summary>Pod. </summary>
		Pod,
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>IsHealthPlan. </summary>
		IsHealthPlan,
		///<summary>CustomerEventTestStateId. </summary>
		CustomerEventTestStateId,
		///<summary>CustomerEventScreeningTestId. </summary>
		CustomerEventScreeningTestId,
		///<summary>EvaluationState. </summary>
		EvaluationState,
		///<summary>IsPartial. </summary>
		IsPartial,
		///<summary>IsCritical. </summary>
		IsCritical,
		///<summary>SelfPresent. </summary>
		SelfPresent,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>CreatedOn. </summary>
		CreatedOn,
		///<summary>IsTestNotPerformed. </summary>
		IsTestNotPerformed,
		///<summary>ConductedByOrgRoleUserId. </summary>
		ConductedByOrgRoleUserId,
		///<summary>EvaluatedByOrgRoleUserId. </summary>
		EvaluatedByOrgRoleUserId,
		///<summary>TechnicianNotes. </summary>
		TechnicianNotes,
		///<summary>UpdatedByOrgRoleUserId. </summary>
		UpdatedByOrgRoleUserId,
		///<summary>UpdatedOn. </summary>
		UpdatedOn,
		///<summary>IsNoteManualEntered. </summary>
		IsNoteManualEntered,
		///<summary>TestSummary. </summary>
		TestSummary,
		///<summary>PathwayRecommendation. </summary>
		PathwayRecommendation,
		///<summary>IsPriorityInQueue. </summary>
		IsPriorityInQueue,
		///<summary>TestId. </summary>
		TestId,
		///<summary>IsPdfGenerated. </summary>
		IsPdfGenerated,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwHospitalPartnerCustomers.
	/// </summary>
	public enum VwHospitalPartnerCustomersFieldIndex:int
	{
		///<summary>HospitalPartnerCustomerId. </summary>
		HospitalPartnerCustomerId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Status. </summary>
		Status,
		///<summary>Outcome. </summary>
		Outcome,
		///<summary>CareCoordinatorOrgRoleUserId. </summary>
		CareCoordinatorOrgRoleUserId,
		///<summary>Notes. </summary>
		Notes,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>ModifiedByOrgRoleUserId. </summary>
		ModifiedByOrgRoleUserId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwHostEventDetails.
	/// </summary>
	public enum VwHostEventDetailsFieldIndex:int
	{
		///<summary>HostEventId. </summary>
		HostEventId,
		///<summary>HostId. </summary>
		HostId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>BConfirmMinRequirements. </summary>
		BConfirmMinRequirements,
		///<summary>BConfirmedVisually. </summary>
		BConfirmedVisually,
		///<summary>ConfirmedVisuallyComments. </summary>
		ConfirmedVisuallyComments,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>DepositAmount. </summary>
		DepositAmount,
		///<summary>PayByCheck. </summary>
		PayByCheck,
		///<summary>PayByCreditCard. </summary>
		PayByCreditCard,
		///<summary>PaymentDueDate. </summary>
		PaymentDueDate,
		///<summary>DepositDueDate. </summary>
		DepositDueDate,
		///<summary>InstructionForCallCenter. </summary>
		InstructionForCallCenter,
		///<summary>IsHostRatedbyTechnician. </summary>
		IsHostRatedbyTechnician,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwLanguageBarrierCallQueueCriteraAssignment.
	/// </summary>
	public enum VwLanguageBarrierCallQueueCriteraAssignmentFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Status. </summary>
		Status,
		///<summary>Attempt. </summary>
		Attempt,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>CallDate. </summary>
		CallDate,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CallCount. </summary>
		CallCount,
		///<summary>TagCount. </summary>
		TagCount,
		///<summary>Tags. </summary>
		Tags,
		///<summary>ZipId. </summary>
		ZipId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwMailRoundCallQueueCriteraAssignment.
	/// </summary>
	public enum VwMailRoundCallQueueCriteraAssignmentFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Status. </summary>
		Status,
		///<summary>Attempt. </summary>
		Attempt,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>CallDate. </summary>
		CallDate,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CallCount. </summary>
		CallCount,
		///<summary>TagCount. </summary>
		TagCount,
		///<summary>Tags. </summary>
		Tags,
		///<summary>ZipId. </summary>
		ZipId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwOutreachCallReport.
	/// </summary>
	public enum VwOutreachCallReportFieldIndex:int
	{
		///<summary>CallId. </summary>
		CallId,
		///<summary>IsNewCustomer. </summary>
		IsNewCustomer,
		///<summary>CalledCustomerId. </summary>
		CalledCustomerId,
		///<summary>TimeCreated. </summary>
		TimeCreated,
		///<summary>TimeEnd. </summary>
		TimeEnd,
		///<summary>CallStatus. </summary>
		CallStatus,
		///<summary>EventId. </summary>
		EventId,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>CallBackNumber. </summary>
		CallBackNumber,
		///<summary>IncomingPhoneLine. </summary>
		IncomingPhoneLine,
		///<summary>CallersPhoneNumber. </summary>
		CallersPhoneNumber,
		///<summary>OutBound. </summary>
		OutBound,
		///<summary>Status. </summary>
		Status,
		///<summary>CreatedByOrgRoleUserId. </summary>
		CreatedByOrgRoleUserId,
		///<summary>Disposition. </summary>
		Disposition,
		///<summary>ReadAndUnderstoodNotes. </summary>
		ReadAndUnderstoodNotes,
		///<summary>IsUploaded. </summary>
		IsUploaded,
		///<summary>CampaignId. </summary>
		CampaignId,
		///<summary>NotInterestedReasonId. </summary>
		NotInterestedReasonId,
		///<summary>CustomTags. </summary>
		CustomTags,
		///<summary>AccountId. </summary>
		AccountId,
		///<summary>Tag. </summary>
		Tag,
		///<summary>CallQueueId. </summary>
		CallQueueId,
		///<summary>IsContacted. </summary>
		IsContacted,
		///<summary>ProductTypeId. </summary>
		ProductTypeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwPcpAppointmetnDisposition.
	/// </summary>
	public enum VwPcpAppointmetnDispositionFieldIndex:int
	{
		///<summary>EventCustomerId. </summary>
		EventCustomerId,
		///<summary>PcpAppointment. </summary>
		PcpAppointment,
		///<summary>PcpAppointmentLastModified. </summary>
		PcpAppointmentLastModified,
		///<summary>PcpDispositionId. </summary>
		PcpDispositionId,
		///<summary>PcpDispositionLastModified. </summary>
		PcpDispositionLastModified,
		///<summary>LastModified. </summary>
		LastModified,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwPhysicianQueueRecord.
	/// </summary>
	public enum VwPhysicianQueueRecordFieldIndex:int
	{
		///<summary>EventCustomerResultId. </summary>
		EventCustomerResultId,
		///<summary>EventId. </summary>
		EventId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>PhysicianId. </summary>
		PhysicianId,
		///<summary>OverreadPhysicianId. </summary>
		OverreadPhysicianId,
		///<summary>IsAtOverreadState. </summary>
		IsAtOverreadState,
		///<summary>EvaluatedByOrgRoleUserId. </summary>
		EvaluatedByOrgRoleUserId,
		///<summary>CriticalMarkedByTechnician. </summary>
		CriticalMarkedByTechnician,
		///<summary>ResultSummary. </summary>
		ResultSummary,
		///<summary>SentBackatPrimaryEval. </summary>
		SentBackatPrimaryEval,
		///<summary>SentBackatOverread. </summary>
		SentBackatOverread,
		///<summary>InQueuePriority. </summary>
		InQueuePriority,
		///<summary>UpdatedOn. </summary>
		UpdatedOn,
		///<summary>CriticalChatTest. </summary>
		CriticalChatTest,
		///<summary>CriticalChatDate. </summary>
		CriticalChatDate,
		///<summary>CriticalHiptest. </summary>
		CriticalHiptest,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: VwUncontactedCustomerCallQueueCriteraAssignment.
	/// </summary>
	public enum VwUncontactedCustomerCallQueueCriteraAssignmentFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>CriteriaId. </summary>
		CriteriaId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>Status. </summary>
		Status,
		///<summary>Attempt. </summary>
		Attempt,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>ModifiedBy. </summary>
		ModifiedBy,
		///<summary>CallDate. </summary>
		CallDate,
		///<summary>HealthPlanId. </summary>
		HealthPlanId,
		///<summary>CallCount. </summary>
		CallCount,
		///<summary>TagCount. </summary>
		TagCount,
		///<summary>Tags. </summary>
		Tags,
		///<summary>ZipId. </summary>
		ZipId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: WellMedAttestation.
	/// </summary>
	public enum WellMedAttestationFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>EventCustomerResultId. </summary>
		EventCustomerResultId,
		///<summary>DiagnosisCode. </summary>
		DiagnosisCode,
		///<summary>ReferenceDate. </summary>
		ReferenceDate,
		///<summary>StatusId. </summary>
		StatusId,
		///<summary>ProviderSignatureFileId. </summary>
		ProviderSignatureFileId,
		///<summary>FullPrintedName. </summary>
		FullPrintedName,
		///<summary>DiagnosisDate. </summary>
		DiagnosisDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Wf.
	/// </summary>
	public enum WfFieldIndex:int
	{
		///<summary>Wfid. </summary>
		Wfid,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Widget.
	/// </summary>
	public enum WidgetFieldIndex:int
	{
		///<summary>WidgetId. </summary>
		WidgetId,
		///<summary>MarketingMaterialId. </summary>
		MarketingMaterialId,
		///<summary>WidgetAbbreviation. </summary>
		WidgetAbbreviation,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Zip.
	/// </summary>
	public enum ZipFieldIndex:int
	{
		///<summary>ZipId. </summary>
		ZipId,
		///<summary>ZipCode. </summary>
		ZipCode,
		///<summary>CityId. </summary>
		CityId,
		///<summary>Latitude. </summary>
		Latitude,
		///<summary>Longitude. </summary>
		Longitude,
		///<summary>TimeZone. </summary>
		TimeZone,
		///<summary>DayLightSaving. </summary>
		DayLightSaving,
		///<summary>Description. </summary>
		Description,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>DateModified. </summary>
		DateModified,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ZipData.
	/// </summary>
	public enum ZipDataFieldIndex:int
	{
		///<summary>Id. </summary>
		Id,
		///<summary>ZipCode. </summary>
		ZipCode,
		///<summary>CityAliasName. </summary>
		CityAliasName,
		///<summary>State. </summary>
		State,
		///<summary>County. </summary>
		County,
		///<summary>CityType. </summary>
		CityType,
		///<summary>Latitude. </summary>
		Latitude,
		///<summary>Longitude. </summary>
		Longitude,
		///<summary>TimeZone. </summary>
		TimeZone,
		///<summary>DayLightSaving. </summary>
		DayLightSaving,
		///<summary>PreferredLastLineKey. </summary>
		PreferredLastLineKey,
		///<summary>CityMixedCase. </summary>
		CityMixedCase,
		///<summary>CityAliasMixedCase. </summary>
		CityAliasMixedCase,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ZipRadiusDistance.
	/// </summary>
	public enum ZipRadiusDistanceFieldIndex:int
	{
		///<summary>SourceZipId. </summary>
		SourceZipId,
		///<summary>DestinationZipId. </summary>
		DestinationZipId,
		///<summary>Radius. </summary>
		Radius,
		///<summary>Distance. </summary>
		Distance,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : AddressView.
	/// </summary>
	public enum AddressViewFieldIndex:int
	{
		///<summary>AddressId</summary>
		AddressId,
		///<summary>Address1</summary>
		Address1,
		///<summary>Address2</summary>
		Address2,
		///<summary>CityId</summary>
		CityId,
		///<summary>City</summary>
		City,
		///<summary>StateId</summary>
		StateId,
		///<summary>State</summary>
		State,
		///<summary>StateCode</summary>
		StateCode,
		///<summary>CountryId</summary>
		CountryId,
		///<summary>Country</summary>
		Country,
		///<summary>ZipId</summary>
		ZipId,
		///<summary>ZipCode</summary>
		ZipCode,
		///<summary>PhoneNumber</summary>
		PhoneNumber,
		///<summary>Fax</summary>
		Fax,
		///<summary>IsActive</summary>
		IsActive,
		///<summary>DateCreated</summary>
		DateCreated,
		///<summary>DateModified</summary>
		DateModified,
		///<summary>Latitude</summary>
		Latitude,
		///<summary>Longitude</summary>
		Longitude,
		///<summary>VerificationOrgRoleUserId</summary>
		VerificationOrgRoleUserId,
		///<summary>IsManuallyVerified</summary>
		IsManuallyVerified,
		///<summary>UseLatLogForMapping</summary>
		UseLatLogForMapping,
		///<summary>ZipLatitiude</summary>
		ZipLatitiude,
		///<summary>ZipLongitude</summary>
		ZipLongitude,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : CcrepMetrices.
	/// </summary>
	public enum CcrepMetricesFieldIndex:int
	{
		///<summary>EventCustomerId</summary>
		EventCustomerId,
		///<summary>EventId</summary>
		EventId,
		///<summary>CustomerId</summary>
		CustomerId,
		///<summary>RegisteredDate</summary>
		RegisteredDate,
		///<summary>OrganizationRoleUserId</summary>
		OrganizationRoleUserId,
		///<summary>CcrepUserId</summary>
		CcrepUserId,
		///<summary>OrderId</summary>
		OrderId,
		///<summary>PaymentDate</summary>
		PaymentDate,
		///<summary>PaymentRecievedBy</summary>
		PaymentRecievedBy,
		///<summary>PaymentRecievedByUserId</summary>
		PaymentRecievedByUserId,
		///<summary>RoleId</summary>
		RoleId,
		///<summary>PaidAmount</summary>
		PaidAmount,
		///<summary>DiscountAmount</summary>
		DiscountAmount,
		///<summary>ShippingAmount</summary>
		ShippingAmount,
		///<summary>OrderAmount</summary>
		OrderAmount,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : CustomerEventBasicInfo.
	/// </summary>
	public enum CustomerEventBasicInfoFieldIndex:int
	{
		///<summary>CustomerId</summary>
		CustomerId,
		///<summary>EventCustomerId</summary>
		EventCustomerId,
		///<summary>FirstName</summary>
		FirstName,
		///<summary>LastName</summary>
		LastName,
		///<summary>SignUpMarketingSource</summary>
		SignUpMarketingSource,
		///<summary>CustomerSignupMode</summary>
		CustomerSignupMode,
		///<summary>EventSignupMode</summary>
		EventSignupMode,
		///<summary>EventSignupDate</summary>
		EventSignupDate,
		///<summary>EventId</summary>
		EventId,
		///<summary>EventName</summary>
		EventName,
		///<summary>EventDate</summary>
		EventDate,
		///<summary>CustomerSignupDate</summary>
		CustomerSignupDate,
		///<summary>PackageName</summary>
		PackageName,
		///<summary>PodName</summary>
		PodName,
		///<summary>AssignedToOrgRoleUserId</summary>
		AssignedToOrgRoleUserId,
		///<summary>PaymentTotalAmount</summary>
		PaymentTotalAmount,
		///<summary>IsPaid</summary>
		IsPaid,
		///<summary>DrOrCr</summary>
		DrOrCr,
		///<summary>CouponCode</summary>
		CouponCode,
		///<summary>IncomingPhoneLine</summary>
		IncomingPhoneLine,
		///<summary>CallersPhoneNumber</summary>
		CallersPhoneNumber,
		///<summary>CallStatus</summary>
		CallStatus,
		///<summary>IsPodActive</summary>
		IsPodActive,
		///<summary>SalesRepFirstName</summary>
		SalesRepFirstName,
		///<summary>SalesRepMiddleName</summary>
		SalesRepMiddleName,
		///<summary>SalesRepLastName</summary>
		SalesRepLastName,
		///<summary>MarketingSource</summary>
		MarketingSource,
		///<summary>HomeAddressId</summary>
		HomeAddressId,
		///<summary>Address1</summary>
		Address1,
		///<summary>Address2</summary>
		Address2,
		///<summary>CityId</summary>
		CityId,
		///<summary>City</summary>
		City,
		///<summary>StateId</summary>
		StateId,
		///<summary>State</summary>
		State,
		///<summary>ZipId</summary>
		ZipId,
		///<summary>ZipCode</summary>
		ZipCode,
		///<summary>PaidAmount</summary>
		PaidAmount,
		///<summary>UnpaidAmount</summary>
		UnpaidAmount,
		///<summary>PaymentNet</summary>
		PaymentNet,
		///<summary>EventStatus</summary>
		EventStatus,
		///<summary>PackagePrice</summary>
		PackagePrice,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : CustomerOrderBasicInfo.
	/// </summary>
	public enum CustomerOrderBasicInfoFieldIndex:int
	{
		///<summary>EventCustomerId</summary>
		EventCustomerId,
		///<summary>OrderId</summary>
		OrderId,
		///<summary>OrderDetailId</summary>
		OrderDetailId,
		///<summary>CustomerId</summary>
		CustomerId,
		///<summary>FirstName</summary>
		FirstName,
		///<summary>MiddleName</summary>
		MiddleName,
		///<summary>LastName</summary>
		LastName,
		///<summary>Email1</summary>
		Email1,
		///<summary>Phone</summary>
		Phone,
		///<summary>EventSignupDate</summary>
		EventSignupDate,
		///<summary>EventSignupRoleId</summary>
		EventSignupRoleId,
		///<summary>AppointmentId</summary>
		AppointmentId,
		///<summary>AppointmentStartTime</summary>
		AppointmentStartTime,
		///<summary>AppointmentEndTime</summary>
		AppointmentEndTime,
		///<summary>Noshow</summary>
		Noshow,
		///<summary>Hipaastatus</summary>
		Hipaastatus,
		///<summary>EventPackageId</summary>
		EventPackageId,
		///<summary>EventName</summary>
		EventName,
		///<summary>EventDate</summary>
		EventDate,
		///<summary>EventId</summary>
		EventId,
		///<summary>FranchiseeName</summary>
		FranchiseeName,
		///<summary>OrganizationName</summary>
		OrganizationName,
		///<summary>HostAddress</summary>
		HostAddress,
		///<summary>HostState</summary>
		HostState,
		///<summary>HostCity</summary>
		HostCity,
		///<summary>HostZip</summary>
		HostZip,
		///<summary>Latitude</summary>
		Latitude,
		///<summary>Longitude</summary>
		Longitude,
		///<summary>IsManuallyVerified</summary>
		IsManuallyVerified,
		///<summary>UseLatLogForMapping</summary>
		UseLatLogForMapping,
		///<summary>CheckinTime</summary>
		CheckinTime,
		///<summary>CheckoutTime</summary>
		CheckoutTime,
		///<summary>LeftWithoutScreeningReasonId</summary>
		LeftWithoutScreeningReasonId,
		///<summary>PackagePrice</summary>
		PackagePrice,
		///<summary>EffectiveCost</summary>
		EffectiveCost,
		///<summary>PackageName</summary>
		PackageName,
		///<summary>PackageId</summary>
		PackageId,
		///<summary>AdditionalTest</summary>
		AdditionalTest,
		///<summary>EventSignupMarketingSource</summary>
		EventSignupMarketingSource,
		///<summary>EventStatus</summary>
		EventStatus,
		///<summary>SourceCodeId</summary>
		SourceCodeId,
		///<summary>SourceCode</summary>
		SourceCode,
		///<summary>SourceCodeAmount</summary>
		SourceCodeAmount,
		///<summary>ShippingCost</summary>
		ShippingCost,
		///<summary>CreditCard</summary>
		CreditCard,
		///<summary>Check</summary>
		Check,
		///<summary>Echeck</summary>
		Echeck,
		///<summary>Cash</summary>
		Cash,
		///<summary>Gc</summary>
		Gc,
		///<summary>IsAuthorized</summary>
		IsAuthorized,
		///<summary>CustomerEventTestId</summary>
		CustomerEventTestId,
		///<summary>IsResultPdfgenerated</summary>
		IsResultPdfgenerated,
		///<summary>IsPdfgenerated</summary>
		IsPdfgenerated,
		///<summary>IsResultReady</summary>
		IsResultReady,
		///<summary>IsColoractelResultReady</summary>
		IsColoractelResultReady,
		///<summary>TestStatus</summary>
		TestStatus,
		///<summary>AaatestEvaluation</summary>
		AaatestEvaluation,
		///<summary>AsitestEvaluation</summary>
		AsitestEvaluation,
		///<summary>CarotidTestEvaluation</summary>
		CarotidTestEvaluation,
		///<summary>OsteoTestEvaluation</summary>
		OsteoTestEvaluation,
		///<summary>PadtestEvaluation</summary>
		PadtestEvaluation,
		///<summary>EkgtestEvaluation</summary>
		EkgtestEvaluation,
		///<summary>LipidTestEvaluation</summary>
		LipidTestEvaluation,
		///<summary>LiverTestEvaluation</summary>
		LiverTestEvaluation,
		///<summary>FraminghamTestEvaluation</summary>
		FraminghamTestEvaluation,
		///<summary>AaapartialState</summary>
		AaapartialState,
		///<summary>AsipartialState</summary>
		AsipartialState,
		///<summary>CarotidPartialState</summary>
		CarotidPartialState,
		///<summary>OsteoPartialState</summary>
		OsteoPartialState,
		///<summary>PadpartialState</summary>
		PadpartialState,
		///<summary>EkgpartialState</summary>
		EkgpartialState,
		///<summary>LipidPartialState</summary>
		LipidPartialState,
		///<summary>LiverPartialState</summary>
		LiverPartialState,
		///<summary>FraminghamPartialState</summary>
		FraminghamPartialState,
		///<summary>EventCount</summary>
		EventCount,
		///<summary>ScheduledByOrgRoleUserId</summary>
		ScheduledByOrgRoleUserId,
		///<summary>AppointBlockReason</summary>
		AppointBlockReason,
		///<summary>UserCreatedOn</summary>
		UserCreatedOn,
		///<summary>CustomerHealthInfo</summary>
		CustomerHealthInfo,
		///<summary>IsRegistered</summary>
		IsRegistered,
		///<summary>IsTestAttended</summary>
		IsTestAttended,
		///<summary>IsPaid</summary>
		IsPaid,
		///<summary>IsShippingApplied</summary>
		IsShippingApplied,
		///<summary>PartnerRelease</summary>
		PartnerRelease,
		///<summary>InsurancePayment</summary>
		InsurancePayment,
		///<summary>AwvVisitId</summary>
		AwvVisitId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : FranchiseeFranchiseeUser.
	/// </summary>
	public enum FranchiseeFranchiseeUserFieldIndex:int
	{
		///<summary>OrganizationRoleUserId</summary>
		OrganizationRoleUserId,
		///<summary>UserId</summary>
		UserId,
		///<summary>OrganizationId</summary>
		OrganizationId,
		///<summary>RoleId</summary>
		RoleId,
		///<summary>IsActive</summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : GetRecordsReadyforCustomerView.
	/// </summary>
	public enum GetRecordsReadyforCustomerViewFieldIndex:int
	{
		///<summary>EventCustomerId</summary>
		EventCustomerId,
		///<summary>CustomerEventTestId</summary>
		CustomerEventTestId,
		///<summary>CustomerId</summary>
		CustomerId,
		///<summary>EventId</summary>
		EventId,
		///<summary>AaatestEvaluation</summary>
		AaatestEvaluation,
		///<summary>AsitestEvaluation</summary>
		AsitestEvaluation,
		///<summary>CarotidTestEvaluation</summary>
		CarotidTestEvaluation,
		///<summary>OsteoTestEvaluation</summary>
		OsteoTestEvaluation,
		///<summary>PadtestEvaluation</summary>
		PadtestEvaluation,
		///<summary>EkgtestEvaluation</summary>
		EkgtestEvaluation,
		///<summary>LipidTestEvaluation</summary>
		LipidTestEvaluation,
		///<summary>LiverTestEvaluation</summary>
		LiverTestEvaluation,
		///<summary>FraminghamTestEvaluation</summary>
		FraminghamTestEvaluation,
		///<summary>IsPdfgenerated</summary>
		IsPdfgenerated,
		///<summary>IsResultPdfgenerated</summary>
		IsResultPdfgenerated,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : MedicalVendorEarningCustomer.
	/// </summary>
	public enum MedicalVendorEarningCustomerFieldIndex:int
	{
		///<summary>CustomerId</summary>
		CustomerId,
		///<summary>EventId</summary>
		EventId,
		///<summary>OrganizationId</summary>
		OrganizationId,
		///<summary>OrganizationRoleUserId</summary>
		OrganizationRoleUserId,
		///<summary>MvamountEarned</summary>
		MvamountEarned,
		///<summary>EvaluationDate</summary>
		EvaluationDate,
		///<summary>CustomerFirstName</summary>
		CustomerFirstName,
		///<summary>CustomerMiddleName</summary>
		CustomerMiddleName,
		///<summary>CustomerLastName</summary>
		CustomerLastName,
		///<summary>PhysicianFirstName</summary>
		PhysicianFirstName,
		///<summary>PhysicianMiddleName</summary>
		PhysicianMiddleName,
		///<summary>PhysicianLastName</summary>
		PhysicianLastName,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : MedicalVendorEarningInfo.
	/// </summary>
	public enum MedicalVendorEarningInfoFieldIndex:int
	{
		///<summary>OrganizationRoleUserId</summary>
		OrganizationRoleUserId,
		///<summary>OrganizationId</summary>
		OrganizationId,
		///<summary>PhysicianAmountEarned</summary>
		PhysicianAmountEarned,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : MedicalVendorInvoiceItem.
	/// </summary>
	public enum MedicalVendorInvoiceItemFieldIndex:int
	{
		///<summary>OrganizationRoleUserId</summary>
		OrganizationRoleUserId,
		///<summary>CustomerId</summary>
		CustomerId,
		///<summary>FirstName</summary>
		FirstName,
		///<summary>MiddleName</summary>
		MiddleName,
		///<summary>LastName</summary>
		LastName,
		///<summary>ReviewDate</summary>
		ReviewDate,
		///<summary>EventId</summary>
		EventId,
		///<summary>EventName</summary>
		EventName,
		///<summary>EventDate</summary>
		EventDate,
		///<summary>PodId</summary>
		PodId,
		///<summary>PodName</summary>
		PodName,
		///<summary>MedicalVendorAmountEarned</summary>
		MedicalVendorAmountEarned,
		///<summary>OrganizationRoleUserAmountEarned</summary>
		OrganizationRoleUserAmountEarned,
		///<summary>EvaluationStartTime</summary>
		EvaluationStartTime,
		///<summary>EvaluationEndTime</summary>
		EvaluationEndTime,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : MedicalVendorMedicalVendorUser.
	/// </summary>
	public enum MedicalVendorMedicalVendorUserFieldIndex:int
	{
		///<summary>OrganizationRoleUserId</summary>
		OrganizationRoleUserId,
		///<summary>OrganizationId</summary>
		OrganizationId,
		///<summary>MedicalVendorName</summary>
		MedicalVendorName,
		///<summary>RoleName</summary>
		RoleName,
		///<summary>FirstName</summary>
		FirstName,
		///<summary>MiddleName</summary>
		MiddleName,
		///<summary>LastName</summary>
		LastName,
		///<summary>IsActive</summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : MedicalVendorMvuserEarningAndPayRate.
	/// </summary>
	public enum MedicalVendorMvuserEarningAndPayRateFieldIndex:int
	{
		///<summary>OrganizationRoleUserId</summary>
		OrganizationRoleUserId,
		///<summary>OrganizationId</summary>
		OrganizationId,
		///<summary>OfferRate</summary>
		OfferRate,
		///<summary>NumberOfEvaluations</summary>
		NumberOfEvaluations,
		///<summary>AmountEarned</summary>
		AmountEarned,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : MedicalVendorMvuserPayment.
	/// </summary>
	public enum MedicalVendorMvuserPaymentFieldIndex:int
	{
		///<summary>OrganizationRoleUserId</summary>
		OrganizationRoleUserId,
		///<summary>OrganizationId</summary>
		OrganizationId,
		///<summary>AmountPaid</summary>
		AmountPaid,
		/// <summary></summary>
		AmountOfFields
	}




	/// <summary>
	/// Enum definition for all the entity types defined in this namespace. Used by the entityfields factory.
	/// </summary>
	public enum EntityType:int
	{
		///<summary>AccessControlObject</summary>
		AccessControlObjectEntity,
		///<summary>AccessControlObjectUrl</summary>
		AccessControlObjectUrlEntity,
		///<summary>AccessObjectScopeOption</summary>
		AccessObjectScopeOptionEntity,
		///<summary>Account</summary>
		AccountEntity,
		///<summary>AccountAdditionalFields</summary>
		AccountAdditionalFieldsEntity,
		///<summary>AccountCallCenterOrganization</summary>
		AccountCallCenterOrganizationEntity,
		///<summary>AccountCallQueueSetting</summary>
		AccountCallQueueSettingEntity,
		///<summary>AccountCheckoutPhoneNumber</summary>
		AccountCheckoutPhoneNumberEntity,
		///<summary>AccountCoordinatorProfile</summary>
		AccountCoordinatorProfileEntity,
		///<summary>AccountCustomerResultTestDependency</summary>
		AccountCustomerResultTestDependencyEntity,
		///<summary>AccountEventZip</summary>
		AccountEventZipEntity,
		///<summary>AccountEventZipSubstitute</summary>
		AccountEventZipSubstituteEntity,
		///<summary>AccountHealthPlanResultTestDependency</summary>
		AccountHealthPlanResultTestDependencyEntity,
		///<summary>AccountHraChatQuestionnaire</summary>
		AccountHraChatQuestionnaireEntity,
		///<summary>AccountNotReviewableTest</summary>
		AccountNotReviewableTestEntity,
		///<summary>AccountPackage</summary>
		AccountPackageEntity,
		///<summary>AccountPcpResultTestDependency</summary>
		AccountPcpResultTestDependencyEntity,
		///<summary>AccountTest</summary>
		AccountTestEntity,
		///<summary>AccountTestHcpcsCode</summary>
		AccountTestHcpcsCodeEntity,
		///<summary>Activity</summary>
		ActivityEntity,
		///<summary>ActivityType</summary>
		ActivityTypeEntity,
		///<summary>AdditionalFields</summary>
		AdditionalFieldsEntity,
		///<summary>Address</summary>
		AddressEntity,
		///<summary>AdvocateManagerTeam</summary>
		AdvocateManagerTeamEntity,
		///<summary>Afadvertiser</summary>
		AfadvertiserEntity,
		///<summary>AfAdvertisingCommission</summary>
		AfAdvertisingCommissionEntity,
		///<summary>AfaffiliateCampaign</summary>
		AfaffiliateCampaignEntity,
		///<summary>AfaffiliateCampaignMarketingMaterial</summary>
		AfaffiliateCampaignMarketingMaterialEntity,
		///<summary>Afcampaign</summary>
		AfcampaignEntity,
		///<summary>AfcampaignCreative</summary>
		AfcampaignCreativeEntity,
		///<summary>AfcampaignSubAdvocate</summary>
		AfcampaignSubAdvocateEntity,
		///<summary>AfcampaignTemplate</summary>
		AfcampaignTemplateEntity,
		///<summary>Afchannel</summary>
		AfchannelEntity,
		///<summary>Afcommision</summary>
		AfcommisionEntity,
		///<summary>AfDailyLogImpressionClick</summary>
		AfDailyLogImpressionClickEntity,
		///<summary>AffiliateProfile</summary>
		AffiliateProfileEntity,
		///<summary>Afimpression</summary>
		AfimpressionEntity,
		///<summary>AfimpressionLog</summary>
		AfimpressionLogEntity,
		///<summary>AfincomingPhone</summary>
		AfincomingPhoneEntity,
		///<summary>AflAffiliatePaymentMethod</summary>
		AflAffiliatePaymentMethodEntity,
		///<summary>AfmanualCheck</summary>
		AfmanualCheckEntity,
		///<summary>AfmarketingMaterial</summary>
		AfmarketingMaterialEntity,
		///<summary>AfMarketingMaterialBannerSize</summary>
		AfMarketingMaterialBannerSizeEntity,
		///<summary>AfmarketingMaterialGroup</summary>
		AfmarketingMaterialGroupEntity,
		///<summary>AfmarketingMaterialType</summary>
		AfmarketingMaterialTypeEntity,
		///<summary>Afpayment</summary>
		AfpaymentEntity,
		///<summary>Afpaypal</summary>
		AfpaypalEntity,
		///<summary>AfppcclickLog</summary>
		AfppcclickLogEntity,
		///<summary>AfredirectUrl</summary>
		AfredirectUrlEntity,
		///<summary>ApplicationAuthentication</summary>
		ApplicationAuthenticationEntity,
		///<summary>Barrier</summary>
		BarrierEntity,
		///<summary>BillingAccount</summary>
		BillingAccountEntity,
		///<summary>BillingAccountTest</summary>
		BillingAccountTestEntity,
		///<summary>BlockedDays</summary>
		BlockedDaysEntity,
		///<summary>BlockedDaysFranchisee</summary>
		BlockedDaysFranchiseeEntity,
		///<summary>CallCenterAgentTeam</summary>
		CallCenterAgentTeamEntity,
		///<summary>CallCenterAgentTeamLog</summary>
		CallCenterAgentTeamLogEntity,
		///<summary>CallCenterNotes</summary>
		CallCenterNotesEntity,
		///<summary>CallCenterRepProfile</summary>
		CallCenterRepProfileEntity,
		///<summary>CallCenterTeam</summary>
		CallCenterTeamEntity,
		///<summary>CallDetails</summary>
		CallDetailsEntity,
		///<summary>CallQueue</summary>
		CallQueueEntity,
		///<summary>CallQueueAssignment</summary>
		CallQueueAssignmentEntity,
		///<summary>CallQueueCriteria</summary>
		CallQueueCriteriaEntity,
		///<summary>CallQueueCustomer</summary>
		CallQueueCustomerEntity,
		///<summary>CallQueueCustomerCall</summary>
		CallQueueCustomerCallEntity,
		///<summary>CallQueueCustomerLock</summary>
		CallQueueCustomerLockEntity,
		///<summary>CallQueueCustomTag</summary>
		CallQueueCustomTagEntity,
		///<summary>CallRoundCallQueue</summary>
		CallRoundCallQueueEntity,
		///<summary>CallRoundCallQueueCriteriaAssignment</summary>
		CallRoundCallQueueCriteriaAssignmentEntity,
		///<summary>Calls</summary>
		CallsEntity,
		///<summary>CallUpload</summary>
		CallUploadEntity,
		///<summary>CallUploadLog</summary>
		CallUploadLogEntity,
		///<summary>Campaign</summary>
		CampaignEntity,
		///<summary>CampaignActivity</summary>
		CampaignActivityEntity,
		///<summary>CampaignActivityAssignment</summary>
		CampaignActivityAssignmentEntity,
		///<summary>CampaignAssignment</summary>
		CampaignAssignmentEntity,
		///<summary>CampaignTag</summary>
		CampaignTagEntity,
		///<summary>CampaignTagMapping</summary>
		CampaignTagMappingEntity,
		///<summary>CareCodingOutbound</summary>
		CareCodingOutboundEntity,
		///<summary>Carrier</summary>
		CarrierEntity,
		///<summary>CashPayment</summary>
		CashPaymentEntity,
		///<summary>Categories</summary>
		CategoriesEntity,
		///<summary>CdcontentGeneratorTracking</summary>
		CdcontentGeneratorTrackingEntity,
		///<summary>ChaperoneAnswer</summary>
		ChaperoneAnswerEntity,
		///<summary>ChaperoneQuestion</summary>
		ChaperoneQuestionEntity,
		///<summary>ChaperoneSignature</summary>
		ChaperoneSignatureEntity,
		///<summary>ChargeCard</summary>
		ChargeCardEntity,
		///<summary>ChargeCardPayment</summary>
		ChargeCardPaymentEntity,
		///<summary>ChaseCampaign</summary>
		ChaseCampaignEntity,
		///<summary>ChaseCampaignType</summary>
		ChaseCampaignTypeEntity,
		///<summary>ChaseChannelLevel</summary>
		ChaseChannelLevelEntity,
		///<summary>ChaseGroup</summary>
		ChaseGroupEntity,
		///<summary>ChaseOutbound</summary>
		ChaseOutboundEntity,
		///<summary>ChaseProduct</summary>
		ChaseProductEntity,
		///<summary>Check</summary>
		CheckEntity,
		///<summary>CheckListAnswer</summary>
		CheckListAnswerEntity,
		///<summary>CheckListGroup</summary>
		CheckListGroupEntity,
		///<summary>ChecklistGroupQuestion</summary>
		ChecklistGroupQuestionEntity,
		///<summary>CheckListQuestion</summary>
		CheckListQuestionEntity,
		///<summary>CheckListTemplate</summary>
		CheckListTemplateEntity,
		///<summary>CheckListTemplateQuestion</summary>
		CheckListTemplateQuestionEntity,
		///<summary>CheckPayment</summary>
		CheckPaymentEntity,
		///<summary>City</summary>
		CityEntity,
		///<summary>Claim</summary>
		ClaimEntity,
		///<summary>ClickConversion</summary>
		ClickConversionEntity,
		///<summary>ClickKeyword</summary>
		ClickKeywordEntity,
		///<summary>ClickLog</summary>
		ClickLogEntity,
		///<summary>Client</summary>
		ClientEntity,
		///<summary>ClinicalTestQualificationCriteria</summary>
		ClinicalTestQualificationCriteriaEntity,
		///<summary>CommunicationMode</summary>
		CommunicationModeEntity,
		///<summary>ContactCall</summary>
		ContactCallEntity,
		///<summary>ContactCallStatus</summary>
		ContactCallStatusEntity,
		///<summary>ContactFranchiseeAccess</summary>
		ContactFranchiseeAccessEntity,
		///<summary>ContactMeeting</summary>
		ContactMeetingEntity,
		///<summary>ContactNotes</summary>
		ContactNotesEntity,
		///<summary>Contacts</summary>
		ContactsEntity,
		///<summary>ContactType</summary>
		ContactTypeEntity,
		///<summary>Content</summary>
		ContentEntity,
		///<summary>Contract</summary>
		ContractEntity,
		///<summary>CorporateShippingOption</summary>
		CorporateShippingOptionEntity,
		///<summary>CorporateTag</summary>
		CorporateTagEntity,
		///<summary>CorporateUpload</summary>
		CorporateUploadEntity,
		///<summary>Country</summary>
		CountryEntity,
		///<summary>Coupons</summary>
		CouponsEntity,
		///<summary>CouponSignUpMode</summary>
		CouponSignUpModeEntity,
		///<summary>CouponType</summary>
		CouponTypeEntity,
		///<summary>CreditCardType</summary>
		CreditCardTypeEntity,
		///<summary>Criteria</summary>
		CriteriaEntity,
		///<summary>CriticalCustomerCommunicationRecord</summary>
		CriticalCustomerCommunicationRecordEntity,
		///<summary>CriticalQuestion</summary>
		CriticalQuestionEntity,
		///<summary>CurrentMedication</summary>
		CurrentMedicationEntity,
		///<summary>CustomCampaignContent</summary>
		CustomCampaignContentEntity,
		///<summary>CustomerAccountGlocomNumber</summary>
		CustomerAccountGlocomNumberEntity,
		///<summary>CustomerActivityTypeUpload</summary>
		CustomerActivityTypeUploadEntity,
		///<summary>CustomerBillingAccount</summary>
		CustomerBillingAccountEntity,
		///<summary>CustomerCallAttempts</summary>
		CustomerCallAttemptsEntity,
		///<summary>CustomerCallQueueCallAttempt</summary>
		CustomerCallQueueCallAttemptEntity,
		///<summary>CustomerChaseCampaign</summary>
		CustomerChaseCampaignEntity,
		///<summary>CustomerChaseChannel</summary>
		CustomerChaseChannelEntity,
		///<summary>CustomerChaseProduct</summary>
		CustomerChaseProductEntity,
		///<summary>CustomerClinicalQuestionAnswer</summary>
		CustomerClinicalQuestionAnswerEntity,
		///<summary>CustomerEligibility</summary>
		CustomerEligibilityEntity,
		///<summary>CustomerEventCriticalTestData</summary>
		CustomerEventCriticalTestDataEntity,
		///<summary>CustomerEventPriorityInQueueData</summary>
		CustomerEventPriorityInQueueDataEntity,
		///<summary>CustomerEventReading</summary>
		CustomerEventReadingEntity,
		///<summary>CustomerEventScreeningTests</summary>
		CustomerEventScreeningTestsEntity,
		///<summary>CustomerEventTestFinding</summary>
		CustomerEventTestFindingEntity,
		///<summary>CustomerEventTestIncidentalFinding</summary>
		CustomerEventTestIncidentalFindingEntity,
		///<summary>CustomerEventTestIncidentalFindingDetail</summary>
		CustomerEventTestIncidentalFindingDetailEntity,
		///<summary>CustomerEventTestPhysicianEvaluation</summary>
		CustomerEventTestPhysicianEvaluationEntity,
		///<summary>CustomerEventTestPhysicianNote</summary>
		CustomerEventTestPhysicianNoteEntity,
		///<summary>CustomerEventTestStandardFinding</summary>
		CustomerEventTestStandardFindingEntity,
		///<summary>CustomerEventTestState</summary>
		CustomerEventTestStateEntity,
		///<summary>CustomerEventUnableScreenReason</summary>
		CustomerEventUnableScreenReasonEntity,
		///<summary>CustomerHealthInfo</summary>
		CustomerHealthInfoEntity,
		///<summary>CustomerHealthInfoArchive</summary>
		CustomerHealthInfoArchiveEntity,
		///<summary>CustomerHealthQuestionGroup</summary>
		CustomerHealthQuestionGroupEntity,
		///<summary>CustomerHealthQuestions</summary>
		CustomerHealthQuestionsEntity,
		///<summary>CustomerIcdCode</summary>
		CustomerIcdCodeEntity,
		///<summary>CustomerLockForCall</summary>
		CustomerLockForCallEntity,
		///<summary>CustomerMedicareQuestionAnswer</summary>
		CustomerMedicareQuestionAnswerEntity,
		///<summary>CustomerOrderHistory</summary>
		CustomerOrderHistoryEntity,
		///<summary>CustomerPhoneNumberUpdateUpload</summary>
		CustomerPhoneNumberUpdateUploadEntity,
		///<summary>CustomerPhoneNumberUpdateUploadLog</summary>
		CustomerPhoneNumberUpdateUploadLogEntity,
		///<summary>CustomerPredictedZip</summary>
		CustomerPredictedZipEntity,
		///<summary>CustomerPrimaryCarePhysician</summary>
		CustomerPrimaryCarePhysicianEntity,
		///<summary>CustomerProfile</summary>
		CustomerProfileEntity,
		///<summary>CustomerProfileHistory</summary>
		CustomerProfileHistoryEntity,
		///<summary>CustomerRegistrationNotes</summary>
		CustomerRegistrationNotesEntity,
		///<summary>CustomerResultPosted</summary>
		CustomerResultPostedEntity,
		///<summary>CustomerResultScreeningCommunication</summary>
		CustomerResultScreeningCommunicationEntity,
		///<summary>CustomerSkipReview</summary>
		CustomerSkipReviewEntity,
		///<summary>CustomerSurvey</summary>
		CustomerSurveyEntity,
		///<summary>CustomerSurveyQuestion</summary>
		CustomerSurveyQuestionEntity,
		///<summary>CustomerSurveyQuestionAnswer</summary>
		CustomerSurveyQuestionAnswerEntity,
		///<summary>CustomerTag</summary>
		CustomerTagEntity,
		///<summary>CustomerTargeted</summary>
		CustomerTargetedEntity,
		///<summary>CustomerTrale</summary>
		CustomerTraleEntity,
		///<summary>CustomerUnsubscribedSmsNotification</summary>
		CustomerUnsubscribedSmsNotificationEntity,
		///<summary>CustomerWarmTransfer</summary>
		CustomerWarmTransferEntity,
		///<summary>CustomEventNotification</summary>
		CustomEventNotificationEntity,
		///<summary>DemandDraftPaymentDetails</summary>
		DemandDraftPaymentDetailsEntity,
		///<summary>DependentDisqualifiedTest</summary>
		DependentDisqualifiedTestEntity,
		///<summary>DiabeticRetinopathyParserlog</summary>
		DiabeticRetinopathyParserlogEntity,
		///<summary>DigitalAssetAccessLog</summary>
		DigitalAssetAccessLogEntity,
		///<summary>DirectMail</summary>
		DirectMailEntity,
		///<summary>DirectMailType</summary>
		DirectMailTypeEntity,
		///<summary>DisqualifiedTest</summary>
		DisqualifiedTestEntity,
		///<summary>EcheckPayment</summary>
		EcheckPaymentEntity,
		///<summary>Eligibility</summary>
		EligibilityEntity,
		///<summary>EligibilityUpload</summary>
		EligibilityUploadEntity,
		///<summary>EmailTemplate</summary>
		EmailTemplateEntity,
		///<summary>EmailTemplateMacro</summary>
		EmailTemplateMacroEntity,
		///<summary>Encounter</summary>
		EncounterEntity,
		///<summary>EventAccount</summary>
		EventAccountEntity,
		///<summary>EventAccountTestHcpcsCode</summary>
		EventAccountTestHcpcsCodeEntity,
		///<summary>EventActivityTemplate</summary>
		EventActivityTemplateEntity,
		///<summary>EventActivityTemplateCall</summary>
		EventActivityTemplateCallEntity,
		///<summary>EventActivityTemplateEmail</summary>
		EventActivityTemplateEmailEntity,
		///<summary>EventActivityTemplateHost</summary>
		EventActivityTemplateHostEntity,
		///<summary>EventActivityTemplateMeeting</summary>
		EventActivityTemplateMeetingEntity,
		///<summary>EventActivityTemplateTask</summary>
		EventActivityTemplateTaskEntity,
		///<summary>EventAffiliateDetails</summary>
		EventAffiliateDetailsEntity,
		///<summary>EventAppointment</summary>
		EventAppointmentEntity,
		///<summary>EventAppointmentCancellationLog</summary>
		EventAppointmentCancellationLogEntity,
		///<summary>EventAppointmentChangeLog</summary>
		EventAppointmentChangeLogEntity,
		///<summary>EventCallDetails</summary>
		EventCallDetailsEntity,
		///<summary>EventCampaignDetails</summary>
		EventCampaignDetailsEntity,
		///<summary>EventChecklistTemplate</summary>
		EventChecklistTemplateEntity,
		///<summary>EventCoupons</summary>
		EventCouponsEntity,
		///<summary>EventCustomerBarrier</summary>
		EventCustomerBarrierEntity,
		///<summary>EventCustomerBasicBioMetric</summary>
		EventCustomerBasicBioMetricEntity,
		///<summary>EventCustomerCriticalQuestion</summary>
		EventCustomerCriticalQuestionEntity,
		///<summary>EventCustomerCurrentMedication</summary>
		EventCustomerCurrentMedicationEntity,
		///<summary>EventCustomerCustomNotification</summary>
		EventCustomerCustomNotificationEntity,
		///<summary>EventCustomerDiagnosis</summary>
		EventCustomerDiagnosisEntity,
		///<summary>EventCustomerEligibility</summary>
		EventCustomerEligibilityEntity,
		///<summary>EventCustomerEncounter</summary>
		EventCustomerEncounterEntity,
		///<summary>EventCustomerEvaluationLock</summary>
		EventCustomerEvaluationLockEntity,
		///<summary>EventCustomerGiftCard</summary>
		EventCustomerGiftCardEntity,
		///<summary>EventCustomerIcdCodes</summary>
		EventCustomerIcdCodesEntity,
		///<summary>EventCustomerNotification</summary>
		EventCustomerNotificationEntity,
		///<summary>EventCustomerOrderDetail</summary>
		EventCustomerOrderDetailEntity,
		///<summary>EventCustomerPayment</summary>
		EventCustomerPaymentEntity,
		///<summary>EventCustomerPdfgenerationErrorLog</summary>
		EventCustomerPdfgenerationErrorLogEntity,
		///<summary>EventCustomerPreApprovedPackageTest</summary>
		EventCustomerPreApprovedPackageTestEntity,
		///<summary>EventCustomerPreApprovedTest</summary>
		EventCustomerPreApprovedTestEntity,
		///<summary>EventCustomerPrimaryCarePhysician</summary>
		EventCustomerPrimaryCarePhysicianEntity,
		///<summary>EventCustomerQuestionAnswer</summary>
		EventCustomerQuestionAnswerEntity,
		///<summary>EventCustomerRequiredTest</summary>
		EventCustomerRequiredTestEntity,
		///<summary>EventCustomerResult</summary>
		EventCustomerResultEntity,
		///<summary>EventCustomerResultBloodLab</summary>
		EventCustomerResultBloodLabEntity,
		///<summary>EventCustomerResultBloodLabParser</summary>
		EventCustomerResultBloodLabParserEntity,
		///<summary>EventCustomerResultHistory</summary>
		EventCustomerResultHistoryEntity,
		///<summary>EventCustomerResultTrale</summary>
		EventCustomerResultTraleEntity,
		///<summary>EventCustomerRetest</summary>
		EventCustomerRetestEntity,
		///<summary>EventCustomers</summary>
		EventCustomersEntity,
		///<summary>EventCustomerTestNotPerformedNotification</summary>
		EventCustomerTestNotPerformedNotificationEntity,
		///<summary>EventFluConsentTemplate</summary>
		EventFluConsentTemplateEntity,
		///<summary>EventHospitalFacility</summary>
		EventHospitalFacilityEntity,
		///<summary>EventHospitalPartner</summary>
		EventHospitalPartnerEntity,
		///<summary>EventHostPromotions</summary>
		EventHostPromotionsEntity,
		///<summary>EventMarketingOffers</summary>
		EventMarketingOffersEntity,
		///<summary>EventMeetingDetails</summary>
		EventMeetingDetailsEntity,
		///<summary>EventNote</summary>
		EventNoteEntity,
		///<summary>EventNotesLog</summary>
		EventNotesLogEntity,
		///<summary>EventNotification</summary>
		EventNotificationEntity,
		///<summary>EventPackageDetails</summary>
		EventPackageDetailsEntity,
		///<summary>EventPackageOrderItem</summary>
		EventPackageOrderItemEntity,
		///<summary>EventPackageTest</summary>
		EventPackageTestEntity,
		///<summary>EventPaymentDetails</summary>
		EventPaymentDetailsEntity,
		///<summary>EventPerformanceMailStatus</summary>
		EventPerformanceMailStatusEntity,
		///<summary>EventPhysicianTest</summary>
		EventPhysicianTestEntity,
		///<summary>EventPod</summary>
		EventPodEntity,
		///<summary>EventPodRoom</summary>
		EventPodRoomEntity,
		///<summary>EventPodRoomTest</summary>
		EventPodRoomTestEntity,
		///<summary>EventProductExclusion</summary>
		EventProductExclusionEntity,
		///<summary>EventProductType</summary>
		EventProductTypeEntity,
		///<summary>EventPublication</summary>
		EventPublicationEntity,
		///<summary>Events</summary>
		EventsEntity,
		///<summary>EventScheduleTemplate</summary>
		EventScheduleTemplateEntity,
		///<summary>EventSchedulingSlot</summary>
		EventSchedulingSlotEntity,
		///<summary>EventSlotAppointment</summary>
		EventSlotAppointmentEntity,
		///<summary>EventStaffAssignment</summary>
		EventStaffAssignmentEntity,
		///<summary>EventSurveyTemplate</summary>
		EventSurveyTemplateEntity,
		///<summary>EventTaskDetails</summary>
		EventTaskDetailsEntity,
		///<summary>EventTest</summary>
		EventTestEntity,
		///<summary>EventTestOrderItem</summary>
		EventTestOrderItemEntity,
		///<summary>EventType</summary>
		EventTypeEntity,
		///<summary>EventZip</summary>
		EventZipEntity,
		///<summary>EventZipProductType</summary>
		EventZipProductTypeEntity,
		///<summary>EventZipProductTypeSubstitute</summary>
		EventZipProductTypeSubstituteEntity,
		///<summary>ExitInterviewAnswer</summary>
		ExitInterviewAnswerEntity,
		///<summary>ExitInterviewQuestion</summary>
		ExitInterviewQuestionEntity,
		///<summary>ExitInterviewSignature</summary>
		ExitInterviewSignatureEntity,
		///<summary>ExportableReports</summary>
		ExportableReportsEntity,
		///<summary>ExportableReportsQueue</summary>
		ExportableReportsQueueEntity,
		///<summary>File</summary>
		FileEntity,
		///<summary>FillEventCallQueue</summary>
		FillEventCallQueueEntity,
		///<summary>FillEventCallQueueCriteriaAssignment</summary>
		FillEventCallQueueCriteriaAssignmentEntity,
		///<summary>FluConsentAnswer</summary>
		FluConsentAnswerEntity,
		///<summary>FluConsentQuestion</summary>
		FluConsentQuestionEntity,
		///<summary>FluConsentSignature</summary>
		FluConsentSignatureEntity,
		///<summary>FluConsentTemplate</summary>
		FluConsentTemplateEntity,
		///<summary>FluConsentTemplateQuestion</summary>
		FluConsentTemplateQuestionEntity,
		///<summary>FraminghamCalculationSource</summary>
		FraminghamCalculationSourceEntity,
		///<summary>FraminghamScoreRange</summary>
		FraminghamScoreRangeEntity,
		///<summary>FranchiseeApplication</summary>
		FranchiseeApplicationEntity,
		///<summary>FranchiseeTerritory</summary>
		FranchiseeTerritoryEntity,
		///<summary>FranchiseeWiringInstructions</summary>
		FranchiseeWiringInstructionsEntity,
		///<summary>GcNotGivenReason</summary>
		GcNotGivenReasonEntity,
		///<summary>GiftCertificate</summary>
		GiftCertificateEntity,
		///<summary>GiftCertificateOrderItem</summary>
		GiftCertificateOrderItemEntity,
		///<summary>GiftCertificatePayment</summary>
		GiftCertificatePaymentEntity,
		///<summary>GiftCertificateType</summary>
		GiftCertificateTypeEntity,
		///<summary>GlobalConfiguration</summary>
		GlobalConfigurationEntity,
		///<summary>GuardianDetails</summary>
		GuardianDetailsEntity,
		///<summary>HafTemplate</summary>
		HafTemplateEntity,
		///<summary>HafTemplateQuestion</summary>
		HafTemplateQuestionEntity,
		///<summary>HcpcsCode</summary>
		HcpcsCodeEntity,
		///<summary>HealthPlanCallQueueCriteria</summary>
		HealthPlanCallQueueCriteriaEntity,
		///<summary>HealthPlanCallQueueCriteriaAssignment</summary>
		HealthPlanCallQueueCriteriaAssignmentEntity,
		///<summary>HealthPlanCriteriaAssignment</summary>
		HealthPlanCriteriaAssignmentEntity,
		///<summary>HealthPlanCriteriaAssignmentUpload</summary>
		HealthPlanCriteriaAssignmentUploadEntity,
		///<summary>HealthPlanCriteriaDirectMail</summary>
		HealthPlanCriteriaDirectMailEntity,
		///<summary>HealthPlanCriteriaTeamAssignment</summary>
		HealthPlanCriteriaTeamAssignmentEntity,
		///<summary>HealthPlanEventZip</summary>
		HealthPlanEventZipEntity,
		///<summary>HealthPlanFillEventCallQueue</summary>
		HealthPlanFillEventCallQueueEntity,
		///<summary>HealthPlanRevenue</summary>
		HealthPlanRevenueEntity,
		///<summary>HealthPlanRevenueItem</summary>
		HealthPlanRevenueItemEntity,
		///<summary>HealthQuestionDependencyRule</summary>
		HealthQuestionDependencyRuleEntity,
		///<summary>HospitalFacility</summary>
		HospitalFacilityEntity,
		///<summary>HospitalFacilityCampaign</summary>
		HospitalFacilityCampaignEntity,
		///<summary>HospitalPartner</summary>
		HospitalPartnerEntity,
		///<summary>HospitalPartnerCustomer</summary>
		HospitalPartnerCustomerEntity,
		///<summary>HospitalPartnerEventNotes</summary>
		HospitalPartnerEventNotesEntity,
		///<summary>HospitalPartnerHospitalFacility</summary>
		HospitalPartnerHospitalFacilityEntity,
		///<summary>HospitalPartnerPackage</summary>
		HospitalPartnerPackageEntity,
		///<summary>HospitalPartnerShippingOption</summary>
		HospitalPartnerShippingOptionEntity,
		///<summary>HospitalPartnerTerritory</summary>
		HospitalPartnerTerritoryEntity,
		///<summary>HostAdvocateDetail</summary>
		HostAdvocateDetailEntity,
		///<summary>HostEventDetails</summary>
		HostEventDetailsEntity,
		///<summary>HostFacilityRanking</summary>
		HostFacilityRankingEntity,
		///<summary>HostImage</summary>
		HostImageEntity,
		///<summary>HostNotes</summary>
		HostNotesEntity,
		///<summary>HostPayment</summary>
		HostPaymentEntity,
		///<summary>HostPaymentTransaction</summary>
		HostPaymentTransactionEntity,
		///<summary>IcdCodes</summary>
		IcdCodesEntity,
		///<summary>IflocationMaster</summary>
		IflocationMasterEntity,
		///<summary>IncidentalFindingIncidentalFindingReadingGroup</summary>
		IncidentalFindingIncidentalFindingReadingGroupEntity,
		///<summary>IncidentalFindingReadingGroup</summary>
		IncidentalFindingReadingGroupEntity,
		///<summary>IncidentalFindingReadingGroupItem</summary>
		IncidentalFindingReadingGroupItemEntity,
		///<summary>IncidentalFindings</summary>
		IncidentalFindingsEntity,
		///<summary>IncomingPhoneNumberResolverRule</summary>
		IncomingPhoneNumberResolverRuleEntity,
		///<summary>InsuranceCompany</summary>
		InsuranceCompanyEntity,
		///<summary>InsurancePayment</summary>
		InsurancePaymentEntity,
		///<summary>InsuranceServiceType</summary>
		InsuranceServiceTypeEntity,
		///<summary>InventoryItem</summary>
		InventoryItemEntity,
		///<summary>InventoryItemTest</summary>
		InventoryItemTestEntity,
		///<summary>Item</summary>
		ItemEntity,
		///<summary>ItemType</summary>
		ItemTypeEntity,
		///<summary>KynLabValues</summary>
		KynLabValuesEntity,
		///<summary>Lab</summary>
		LabEntity,
		///<summary>Language</summary>
		LanguageEntity,
		///<summary>LanguageBarrierCallQueue</summary>
		LanguageBarrierCallQueueEntity,
		///<summary>LanguageBarrierCallQueueCriteriaAssignment</summary>
		LanguageBarrierCallQueueCriteriaAssignmentEntity,
		///<summary>LoginOtp</summary>
		LoginOtpEntity,
		///<summary>LoginSettings</summary>
		LoginSettingsEntity,
		///<summary>LoincCrosswalk</summary>
		LoincCrosswalkEntity,
		///<summary>LoincLabData</summary>
		LoincLabDataEntity,
		///<summary>Lookup</summary>
		LookupEntity,
		///<summary>LookupType</summary>
		LookupTypeEntity,
		///<summary>MailRoundCallQueue</summary>
		MailRoundCallQueueEntity,
		///<summary>MailRoundCallQueueCriteriaAssignment</summary>
		MailRoundCallQueueCriteriaAssignmentEntity,
		///<summary>MarketingOfferRoleMapping</summary>
		MarketingOfferRoleMappingEntity,
		///<summary>MarketingOffers</summary>
		MarketingOffersEntity,
		///<summary>MarketingOfferSignUpMode</summary>
		MarketingOfferSignUpModeEntity,
		///<summary>MarketingOfferType</summary>
		MarketingOfferTypeEntity,
		///<summary>MarketingOrderShippingInfo</summary>
		MarketingOrderShippingInfoEntity,
		///<summary>MarketingPrintOrder</summary>
		MarketingPrintOrderEntity,
		///<summary>MarketingPrintOrderEventMapping</summary>
		MarketingPrintOrderEventMappingEntity,
		///<summary>MarketingPrintOrderItem</summary>
		MarketingPrintOrderItemEntity,
		///<summary>MarketingPrintOrderProspectListMapping</summary>
		MarketingPrintOrderProspectListMappingEntity,
		///<summary>MarketingSource</summary>
		MarketingSourceEntity,
		///<summary>MarketingSourceTerritory</summary>
		MarketingSourceTerritoryEntity,
		///<summary>MedicalHistoryReadingAssosciation</summary>
		MedicalHistoryReadingAssosciationEntity,
		///<summary>MedicalVendorProfile</summary>
		MedicalVendorProfileEntity,
		///<summary>MedicalVendorType</summary>
		MedicalVendorTypeEntity,
		///<summary>MedicareGroupDependencyRule</summary>
		MedicareGroupDependencyRuleEntity,
		///<summary>MedicareQuestion</summary>
		MedicareQuestionEntity,
		///<summary>MedicareQuestionDependencyRule</summary>
		MedicareQuestionDependencyRuleEntity,
		///<summary>MedicareQuestionGroup</summary>
		MedicareQuestionGroupEntity,
		///<summary>MedicareQuestionsRemarks</summary>
		MedicareQuestionsRemarksEntity,
		///<summary>Medication</summary>
		MedicationEntity,
		///<summary>MedicationUpload</summary>
		MedicationUploadEntity,
		///<summary>MedicationUploadLog</summary>
		MedicationUploadLogEntity,
		///<summary>MemberUploadLog</summary>
		MemberUploadLogEntity,
		///<summary>MemberUploadParseDetail</summary>
		MemberUploadParseDetailEntity,
		///<summary>MergeCustomerUpload</summary>
		MergeCustomerUploadEntity,
		///<summary>MergeCustomerUploadLog</summary>
		MergeCustomerUploadLogEntity,
		///<summary>MolinaAttestation</summary>
		MolinaAttestationEntity,
		///<summary>MVPaymentCheckDetails</summary>
		MVPaymentCheckDetailsEntity,
		///<summary>MvuserClassification</summary>
		MvuserClassificationEntity,
		///<summary>Ndc</summary>
		NdcEntity,
		///<summary>NoShowCallQueue</summary>
		NoShowCallQueueEntity,
		///<summary>NoShowCallQueueCriteriaAssignment</summary>
		NoShowCallQueueCriteriaAssignmentEntity,
		///<summary>Note</summary>
		NoteEntity,
		///<summary>NotesDetails</summary>
		NotesDetailsEntity,
		///<summary>Notification</summary>
		NotificationEntity,
		///<summary>NotificationEmail</summary>
		NotificationEmailEntity,
		///<summary>NotificationMedium</summary>
		NotificationMediumEntity,
		///<summary>NotificationPhone</summary>
		NotificationPhoneEntity,
		///<summary>NotificationSubscribers</summary>
		NotificationSubscribersEntity,
		///<summary>NotificationType</summary>
		NotificationTypeEntity,
		///<summary>Order</summary>
		OrderEntity,
		///<summary>OrderDetail</summary>
		OrderDetailEntity,
		///<summary>OrderItem</summary>
		OrderItemEntity,
		///<summary>Organization</summary>
		OrganizationEntity,
		///<summary>OrganizationRoleUser</summary>
		OrganizationRoleUserEntity,
		///<summary>OrganizationRoleUserTerritory</summary>
		OrganizationRoleUserTerritoryEntity,
		///<summary>OrganizationType</summary>
		OrganizationTypeEntity,
		///<summary>OrgRoleUserActivity</summary>
		OrgRoleUserActivityEntity,
		///<summary>OutboundUpload</summary>
		OutboundUploadEntity,
		///<summary>Package</summary>
		PackageEntity,
		///<summary>PackageAvailabilityToRoles</summary>
		PackageAvailabilityToRolesEntity,
		///<summary>PackageMarketingOfferDiscount</summary>
		PackageMarketingOfferDiscountEntity,
		///<summary>PackageSourceCodeDiscount</summary>
		PackageSourceCodeDiscountEntity,
		///<summary>PackageTest</summary>
		PackageTestEntity,
		///<summary>ParticipationConsentSignature</summary>
		ParticipationConsentSignatureEntity,
		///<summary>PasswordChangelog</summary>
		PasswordChangelogEntity,
		///<summary>Payment</summary>
		PaymentEntity,
		///<summary>PaymentFrequency</summary>
		PaymentFrequencyEntity,
		///<summary>PaymentInstructions</summary>
		PaymentInstructionsEntity,
		///<summary>PaymentOrder</summary>
		PaymentOrderEntity,
		///<summary>PaymentType</summary>
		PaymentTypeEntity,
		///<summary>PayPeriod</summary>
		PayPeriodEntity,
		///<summary>PayPeriodCriteria</summary>
		PayPeriodCriteriaEntity,
		///<summary>PcpAppointment</summary>
		PcpAppointmentEntity,
		///<summary>PcpDisposition</summary>
		PcpDispositionEntity,
		///<summary>PhysicianCustomerAssignment</summary>
		PhysicianCustomerAssignmentEntity,
		///<summary>PhysicianCustomerPayRate</summary>
		PhysicianCustomerPayRateEntity,
		///<summary>PhysicianEarnings</summary>
		PhysicianEarningsEntity,
		///<summary>PhysicianEvaluation</summary>
		PhysicianEvaluationEntity,
		///<summary>PhysicianEventAssignment</summary>
		PhysicianEventAssignmentEntity,
		///<summary>PhysicianInvoice</summary>
		PhysicianInvoiceEntity,
		///<summary>PhysicianInvoiceItem</summary>
		PhysicianInvoiceItemEntity,
		///<summary>PhysicianLabTest</summary>
		PhysicianLabTestEntity,
		///<summary>PhysicianLicense</summary>
		PhysicianLicenseEntity,
		///<summary>PhysicianMaster</summary>
		PhysicianMasterEntity,
		///<summary>PhysicianPayment</summary>
		PhysicianPaymentEntity,
		///<summary>PhysicianPaymentInvoice</summary>
		PhysicianPaymentInvoiceEntity,
		///<summary>PhysicianPermittedTest</summary>
		PhysicianPermittedTestEntity,
		///<summary>PhysicianPod</summary>
		PhysicianPodEntity,
		///<summary>PhysicianProfile</summary>
		PhysicianProfileEntity,
		///<summary>PhysicianRecordRequestSignature</summary>
		PhysicianRecordRequestSignatureEntity,
		///<summary>PhysicianSpecialization</summary>
		PhysicianSpecializationEntity,
		///<summary>PinChangelog</summary>
		PinChangelogEntity,
		///<summary>PodDefaultTeam</summary>
		PodDefaultTeamEntity,
		///<summary>PodDetails</summary>
		PodDetailsEntity,
		///<summary>PodInventoryItem</summary>
		PodInventoryItemEntity,
		///<summary>PodPackage</summary>
		PodPackageEntity,
		///<summary>PodRoom</summary>
		PodRoomEntity,
		///<summary>PodRoomTest</summary>
		PodRoomTestEntity,
		///<summary>PodTerritory</summary>
		PodTerritoryEntity,
		///<summary>PodTest</summary>
		PodTestEntity,
		///<summary>PreApprovedPackage</summary>
		PreApprovedPackageEntity,
		///<summary>PreApprovedTest</summary>
		PreApprovedTestEntity,
		///<summary>PreAssessmentCallQueueCustomerLock</summary>
		PreAssessmentCallQueueCustomerLockEntity,
		///<summary>PreAssessmentCustomerCallQueueCallAttempt</summary>
		PreAssessmentCustomerCallQueueCallAttemptEntity,
		///<summary>PreQualificationQuestion</summary>
		PreQualificationQuestionEntity,
		///<summary>PreQualificationQuestionRule</summary>
		PreQualificationQuestionRuleEntity,
		///<summary>PreQualificationResult</summary>
		PreQualificationResultEntity,
		///<summary>PreQualificationTemplateDependentTest</summary>
		PreQualificationTemplateDependentTestEntity,
		///<summary>PreQualificationTemplateQuestion</summary>
		PreQualificationTemplateQuestionEntity,
		///<summary>PreQualificationTestTemplate</summary>
		PreQualificationTestTemplateEntity,
		///<summary>PrintOrderItemTracking</summary>
		PrintOrderItemTrackingEntity,
		///<summary>PriorityInQueue</summary>
		PriorityInQueueEntity,
		///<summary>Product</summary>
		ProductEntity,
		///<summary>ProductOrderItem</summary>
		ProductOrderItemEntity,
		///<summary>ProductShippingOption</summary>
		ProductShippingOptionEntity,
		///<summary>ProductSourceCodeDiscount</summary>
		ProductSourceCodeDiscountEntity,
		///<summary>ProspectActivity</summary>
		ProspectActivityEntity,
		///<summary>ProspectActivityDetails</summary>
		ProspectActivityDetailsEntity,
		///<summary>ProspectAddress</summary>
		ProspectAddressEntity,
		///<summary>ProspectCallDetails</summary>
		ProspectCallDetailsEntity,
		///<summary>ProspectCalls</summary>
		ProspectCallsEntity,
		///<summary>ProspectContact</summary>
		ProspectContactEntity,
		///<summary>ProspectContactCalls</summary>
		ProspectContactCallsEntity,
		///<summary>ProspectContactMeetings</summary>
		ProspectContactMeetingsEntity,
		///<summary>ProspectContactRole</summary>
		ProspectContactRoleEntity,
		///<summary>ProspectContactRoleMapping</summary>
		ProspectContactRoleMappingEntity,
		///<summary>ProspectContactTasks</summary>
		ProspectContactTasksEntity,
		///<summary>ProspectCustomer</summary>
		ProspectCustomerEntity,
		///<summary>ProspectCustomerCall</summary>
		ProspectCustomerCallEntity,
		///<summary>ProspectCustomerDeleted</summary>
		ProspectCustomerDeletedEntity,
		///<summary>ProspectCustomerNotification</summary>
		ProspectCustomerNotificationEntity,
		///<summary>ProspectDetails</summary>
		ProspectDetailsEntity,
		///<summary>ProspectFaliureReport</summary>
		ProspectFaliureReportEntity,
		///<summary>ProspectListDetails</summary>
		ProspectListDetailsEntity,
		///<summary>ProspectListType</summary>
		ProspectListTypeEntity,
		///<summary>ProspectMeetings</summary>
		ProspectMeetingsEntity,
		///<summary>ProspectNotesDetails</summary>
		ProspectNotesDetailsEntity,
		///<summary>Prospects</summary>
		ProspectsEntity,
		///<summary>ProspectTasks</summary>
		ProspectTasksEntity,
		///<summary>ProspectType</summary>
		ProspectTypeEntity,
		///<summary>Raps</summary>
		RapsEntity,
		///<summary>RapsUpload</summary>
		RapsUploadEntity,
		///<summary>RapsUploadLog</summary>
		RapsUploadLogEntity,
		///<summary>Reading</summary>
		ReadingEntity,
		///<summary>Referral</summary>
		ReferralEntity,
		///<summary>Refund</summary>
		RefundEntity,
		///<summary>RefundOrderItem</summary>
		RefundOrderItemEntity,
		///<summary>RefundRequest</summary>
		RefundRequestEntity,
		///<summary>RefundRequestGiftCertificate</summary>
		RefundRequestGiftCertificateEntity,
		///<summary>Relationship</summary>
		RelationshipEntity,
		///<summary>RequiredTest</summary>
		RequiredTestEntity,
		///<summary>RescheduleCancelDisposition</summary>
		RescheduleCancelDispositionEntity,
		///<summary>ResultArchiveUpload</summary>
		ResultArchiveUploadEntity,
		///<summary>ResultArchiveUploadLog</summary>
		ResultArchiveUploadLogEntity,
		///<summary>Role</summary>
		RoleEntity,
		///<summary>RoleAccessControlObject</summary>
		RoleAccessControlObjectEntity,
		///<summary>RolePermisibleAccessControlObject</summary>
		RolePermisibleAccessControlObjectEntity,
		///<summary>RoleScopeOption</summary>
		RoleScopeOptionEntity,
		///<summary>SafeComputerHistory</summary>
		SafeComputerHistoryEntity,
		///<summary>SalesRepPodAssigments</summary>
		SalesRepPodAssigmentsEntity,
		///<summary>ScheduleMethod</summary>
		ScheduleMethodEntity,
		///<summary>ScheduleTemplate</summary>
		ScheduleTemplateEntity,
		///<summary>ScheduleTemplateFranchiseeAccess</summary>
		ScheduleTemplateFranchiseeAccessEntity,
		///<summary>ScheduleTemplateTime</summary>
		ScheduleTemplateTimeEntity,
		///<summary>ScreeningAuthorization</summary>
		ScreeningAuthorizationEntity,
		///<summary>Scripts</summary>
		ScriptsEntity,
		///<summary>ScriptType</summary>
		ScriptTypeEntity,
		///<summary>SecurityQuestion</summary>
		SecurityQuestionEntity,
		///<summary>SeminarCampaignDetails</summary>
		SeminarCampaignDetailsEntity,
		///<summary>Seminars</summary>
		SeminarsEntity,
		///<summary>ShippingDetail</summary>
		ShippingDetailEntity,
		///<summary>ShippingDetailOrderDetail</summary>
		ShippingDetailOrderDetailEntity,
		///<summary>ShippingOption</summary>
		ShippingOptionEntity,
		///<summary>ShippingOptionOrderItem</summary>
		ShippingOptionOrderItemEntity,
		///<summary>ShippingOptionSourceCodeDiscount</summary>
		ShippingOptionSourceCodeDiscountEntity,
		///<summary>SmsReceived</summary>
		SmsReceivedEntity,
		///<summary>SourceCodeChangeLog</summary>
		SourceCodeChangeLogEntity,
		///<summary>SourceCodeOrderDetail</summary>
		SourceCodeOrderDetailEntity,
		///<summary>StaffEventRole</summary>
		StaffEventRoleEntity,
		///<summary>StaffEventRoleTest</summary>
		StaffEventRoleTestEntity,
		///<summary>StaffEventScheduleUpload</summary>
		StaffEventScheduleUploadEntity,
		///<summary>StaffEventScheduleUploadLog</summary>
		StaffEventScheduleUploadLogEntity,
		///<summary>StandardFinding</summary>
		StandardFindingEntity,
		///<summary>StandardFindingTestReading</summary>
		StandardFindingTestReadingEntity,
		///<summary>State</summary>
		StateEntity,
		///<summary>SurveyAnswer</summary>
		SurveyAnswerEntity,
		///<summary>SurveyQuestion</summary>
		SurveyQuestionEntity,
		///<summary>SurveyTemplate</summary>
		SurveyTemplateEntity,
		///<summary>SurveyTemplateQuestion</summary>
		SurveyTemplateQuestionEntity,
		///<summary>SuspectCondition</summary>
		SuspectConditionEntity,
		///<summary>SuspectConditionUpload</summary>
		SuspectConditionUploadEntity,
		///<summary>SuspectConditionUploadLog</summary>
		SuspectConditionUploadLogEntity,
		///<summary>SystemGeneratedCallQueueAssignment</summary>
		SystemGeneratedCallQueueAssignmentEntity,
		///<summary>SystemGeneratedCallQueueCriteria</summary>
		SystemGeneratedCallQueueCriteriaEntity,
		///<summary>SystemUserInfo</summary>
		SystemUserInfoEntity,
		///<summary>Tag</summary>
		TagEntity,
		///<summary>Task</summary>
		TaskEntity,
		///<summary>TaskDetails</summary>
		TaskDetailsEntity,
		///<summary>TaskPriorityTypes</summary>
		TaskPriorityTypesEntity,
		///<summary>TaskStatusTypes</summary>
		TaskStatusTypesEntity,
		///<summary>TechnicianProfile</summary>
		TechnicianProfileEntity,
		///<summary>TempCart</summary>
		TempCartEntity,
		///<summary>Template</summary>
		TemplateEntity,
		///<summary>TemplateMacro</summary>
		TemplateMacroEntity,
		///<summary>TemplateTag</summary>
		TemplateTagEntity,
		///<summary>Territory</summary>
		TerritoryEntity,
		///<summary>TerritoryPackage</summary>
		TerritoryPackageEntity,
		///<summary>TerritoryZip</summary>
		TerritoryZipEntity,
		///<summary>Test</summary>
		TestEntity,
		///<summary>TestAvailabilityToRoles</summary>
		TestAvailabilityToRolesEntity,
		///<summary>TestDependencyRule</summary>
		TestDependencyRuleEntity,
		///<summary>TestHcpcsCode</summary>
		TestHcpcsCodeEntity,
		///<summary>Testimonial</summary>
		TestimonialEntity,
		///<summary>TestIncidentalFinding</summary>
		TestIncidentalFindingEntity,
		///<summary>TestMedia</summary>
		TestMediaEntity,
		///<summary>TestNotPerformed</summary>
		TestNotPerformedEntity,
		///<summary>TestNotPerformedReason</summary>
		TestNotPerformedReasonEntity,
		///<summary>TestOrderItem</summary>
		TestOrderItemEntity,
		///<summary>TestPerformedExternally</summary>
		TestPerformedExternallyEntity,
		///<summary>TestReading</summary>
		TestReadingEntity,
		///<summary>TestSourceCodeDiscount</summary>
		TestSourceCodeDiscountEntity,
		///<summary>TestUnableScreenReason</summary>
		TestUnableScreenReasonEntity,
		///<summary>ToolTip</summary>
		ToolTipEntity,
		///<summary>TrackingMarketing</summary>
		TrackingMarketingEntity,
		///<summary>UncontactedCustomerCallQueue</summary>
		UncontactedCustomerCallQueueEntity,
		///<summary>UncontactedCustomerCallQueueCriteriaAssignment</summary>
		UncontactedCustomerCallQueueCriteriaAssignmentEntity,
		///<summary>Unit</summary>
		UnitEntity,
		///<summary>UploadTestInfo</summary>
		UploadTestInfoEntity,
		///<summary>UploadZipInfo</summary>
		UploadZipInfoEntity,
		///<summary>User</summary>
		UserEntity,
		///<summary>UserLogin</summary>
		UserLoginEntity,
		///<summary>UserLoginLog</summary>
		UserLoginLogEntity,
		///<summary>UserNpiInfo</summary>
		UserNpiInfoEntity,
		///<summary>UserSecurityQuestion</summary>
		UserSecurityQuestionEntity,
		///<summary>VanDetails</summary>
		VanDetailsEntity,
		///<summary>VwCallCenterCallReport</summary>
		VwCallCenterCallReportEntity,
		///<summary>VwCallQueueCustomerCallDetails</summary>
		VwCallQueueCustomerCallDetailsEntity,
		///<summary>VwCallQueueCustomerCriteraAssignment</summary>
		VwCallQueueCustomerCriteraAssignmentEntity,
		///<summary>VwCallQueueCustomerCriteraAssignmentForGms</summary>
		VwCallQueueCustomerCriteraAssignmentForGmsEntity,
		///<summary>VwCallQueueCustomerCriteraAssignmentForGmsStats</summary>
		VwCallQueueCustomerCriteraAssignmentForGmsStatsEntity,
		///<summary>VwCallQueueCustomerCriteraAssignmentForStats</summary>
		VwCallQueueCustomerCriteraAssignmentForStatsEntity,
		///<summary>VwCallQueueCustomerCriteraAssignmentWithCustomer</summary>
		VwCallQueueCustomerCriteraAssignmentWithCustomerEntity,
		///<summary>VwCallRoundCallQueueCriteraAssignment</summary>
		VwCallRoundCallQueueCriteraAssignmentEntity,
		///<summary>VwCampaignClickConversion</summary>
		VwCampaignClickConversionEntity,
		///<summary>VwCustomerAggregateResultSummary</summary>
		VwCustomerAggregateResultSummaryEntity,
		///<summary>VwEventAppointment</summary>
		VwEventAppointmentEntity,
		///<summary>VwEventCustomerPreApprovedTestList</summary>
		VwEventCustomerPreApprovedTestListEntity,
		///<summary>VwEventCustomersAccount</summary>
		VwEventCustomersAccountEntity,
		///<summary>VwEventCustomersViewServiceReport</summary>
		VwEventCustomersViewServiceReportEntity,
		///<summary>VwFillEventCallQueueCriteraAssignment</summary>
		VwFillEventCallQueueCriteraAssignmentEntity,
		///<summary>VwGetAllTestForCustomers</summary>
		VwGetAllTestForCustomersEntity,
		///<summary>VwGetBookedAppointmentForCalculatingBonus</summary>
		VwGetBookedAppointmentForCalculatingBonusEntity,
		///<summary>VwGetCallCenterAgentsForConversionReport</summary>
		VwGetCallCenterAgentsForConversionReportEntity,
		///<summary>VwGetCallQueueCustomers</summary>
		VwGetCallQueueCustomersEntity,
		///<summary>VwGetCallQueueExcludedCustomers</summary>
		VwGetCallQueueExcludedCustomersEntity,
		///<summary>VwGetCalls</summary>
		VwGetCallsEntity,
		///<summary>VwGetCallsForCalculatingBonus</summary>
		VwGetCallsForCalculatingBonusEntity,
		///<summary>VwGetCallsForCallQueue</summary>
		VwGetCallsForCallQueueEntity,
		///<summary>VwGetCallsForSuppression</summary>
		VwGetCallsForSuppressionEntity,
		///<summary>VwGetConfirmationCallQueueCustomersWithoutSuppression</summary>
		VwGetConfirmationCallQueueCustomersWithoutSuppressionEntity,
		///<summary>VwGetCustomerForMailRoundInsertion</summary>
		VwGetCustomerForMailRoundInsertionEntity,
		///<summary>VwGetCustomerIdsHavingSingleTagForCallQueue</summary>
		VwGetCustomerIdsHavingSingleTagForCallQueueEntity,
		///<summary>VwGetCustomersForCallQueueWithCustomer</summary>
		VwGetCustomersForCallQueueWithCustomerEntity,
		///<summary>VwGetCustomersForCallQueueWithCustomerVici</summary>
		VwGetCustomersForCallQueueWithCustomerViciEntity,
		///<summary>VwGetCustomersForConfirmationCallQueue</summary>
		VwGetCustomersForConfirmationCallQueueEntity,
		///<summary>VwGetCustomersForNotInCallQueue</summary>
		VwGetCustomersForNotInCallQueueEntity,
		///<summary>VwGetCustomersToGenerateCallQueue</summary>
		VwGetCustomersToGenerateCallQueueEntity,
		///<summary>VwGetCustomersToGenerateConfirmationCallQueue</summary>
		VwGetCustomersToGenerateConfirmationCallQueueEntity,
		///<summary>VwGetCustomersToGenerateFillEventCallQueue</summary>
		VwGetCustomersToGenerateFillEventCallQueueEntity,
		///<summary>VwGetCustomersToGenerateFillEventCallQueue_</summary>
		VwGetCustomersToGenerateFillEventCallQueue_Entity,
		///<summary>VwGetCustomerTagForCallQueue</summary>
		VwGetCustomerTagForCallQueueEntity,
		///<summary>VwGetDataForSkippedCallReport</summary>
		VwGetDataForSkippedCallReportEntity,
		///<summary>VwGetDirectMailForCallQueue</summary>
		VwGetDirectMailForCallQueueEntity,
		///<summary>VwGetEventCustomerEawvTestInOrder</summary>
		VwGetEventCustomerEawvTestInOrderEntity,
		///<summary>VwGetHkynTestCustomers</summary>
		VwGetHkynTestCustomersEntity,
		///<summary>VwGetKynTestCustomers</summary>
		VwGetKynTestCustomersEntity,
		///<summary>VwGetMyBioCheckTestCustomers</summary>
		VwGetMyBioCheckTestCustomersEntity,
		///<summary>VwGetOutboundCalls</summary>
		VwGetOutboundCallsEntity,
		///<summary>VwGetTestPerformedReport</summary>
		VwGetTestPerformedReportEntity,
		///<summary>VwHospitalPartnerCustomers</summary>
		VwHospitalPartnerCustomersEntity,
		///<summary>VwHostEventDetails</summary>
		VwHostEventDetailsEntity,
		///<summary>VwLanguageBarrierCallQueueCriteraAssignment</summary>
		VwLanguageBarrierCallQueueCriteraAssignmentEntity,
		///<summary>VwMailRoundCallQueueCriteraAssignment</summary>
		VwMailRoundCallQueueCriteraAssignmentEntity,
		///<summary>VwOutreachCallReport</summary>
		VwOutreachCallReportEntity,
		///<summary>VwPcpAppointmetnDisposition</summary>
		VwPcpAppointmetnDispositionEntity,
		///<summary>VwPhysicianQueueRecord</summary>
		VwPhysicianQueueRecordEntity,
		///<summary>VwUncontactedCustomerCallQueueCriteraAssignment</summary>
		VwUncontactedCustomerCallQueueCriteraAssignmentEntity,
		///<summary>WellMedAttestation</summary>
		WellMedAttestationEntity,
		///<summary>Wf</summary>
		WfEntity,
		///<summary>Widget</summary>
		WidgetEntity,
		///<summary>Zip</summary>
		ZipEntity,
		///<summary>ZipData</summary>
		ZipDataEntity,
		///<summary>ZipRadiusDistance</summary>
		ZipRadiusDistanceEntity
	}



	/// <summary>
	/// Enum definition for all the typed view types defined in this namespace. Used by the entityfields factory.
	/// </summary>
	public enum TypedViewType:int
	{
		///<summary>AddressView</summary>
		AddressViewTypedView,
		///<summary>CcrepMetrices</summary>
		CcrepMetricesTypedView,
		///<summary>CustomerEventBasicInfo</summary>
		CustomerEventBasicInfoTypedView,
		///<summary>CustomerOrderBasicInfo</summary>
		CustomerOrderBasicInfoTypedView,
		///<summary>FranchiseeFranchiseeUser</summary>
		FranchiseeFranchiseeUserTypedView,
		///<summary>GetRecordsReadyforCustomerView</summary>
		GetRecordsReadyforCustomerViewTypedView,
		///<summary>MedicalVendorEarningCustomer</summary>
		MedicalVendorEarningCustomerTypedView,
		///<summary>MedicalVendorEarningInfo</summary>
		MedicalVendorEarningInfoTypedView,
		///<summary>MedicalVendorInvoiceItem</summary>
		MedicalVendorInvoiceItemTypedView,
		///<summary>MedicalVendorMedicalVendorUser</summary>
		MedicalVendorMedicalVendorUserTypedView,
		///<summary>MedicalVendorMvuserEarningAndPayRate</summary>
		MedicalVendorMvuserEarningAndPayRateTypedView,
		///<summary>MedicalVendorMvuserPayment</summary>
		MedicalVendorMvuserPaymentTypedView
	}


	#region Custom ConstantsEnums Code
	
	// __LLBLGENPRO_USER_CODE_REGION_START CustomUserConstants
	// __LLBLGENPRO_USER_CODE_REGION_END
	#endregion

	#region Included code

	#endregion
}


