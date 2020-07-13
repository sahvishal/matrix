///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:44
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
#if !CF
using System.Runtime.Serialization;
#endif
using System.Xml.Serialization;
using Falcon.Data;
using Falcon.Data.HelperClasses;
using Falcon.Data.FactoryClasses;
using Falcon.Data.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.Data.EntityClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>
	/// Entity class which represents the entity 'EventCustomers'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class EventCustomersEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CallQueueCustomerEntity> _callQueueCustomer;
		private EntityCollection<ChaperoneAnswerEntity> _chaperoneAnswer;
		private EntityCollection<ChaperoneSignatureEntity> _chaperoneSignature;
		private EntityCollection<CheckListAnswerEntity> _checkListAnswer;
		private EntityCollection<ClickConversionEntity> _clickConversion;
		private EntityCollection<CustomerHealthInfoEntity> _customerHealthInfo;
		private EntityCollection<CustomerHealthInfoArchiveEntity> _customerHealthInfoArchive;
		private EntityCollection<CustomerMedicareQuestionAnswerEntity> _customerMedicareQuestionAnswer;
		private EntityCollection<CustomerOrderHistoryEntity> _customerOrderHistory;
		private EntityCollection<DependentDisqualifiedTestEntity> _dependentDisqualifiedTest;
		private EntityCollection<DisqualifiedTestEntity> _disqualifiedTest;
		private EntityCollection<EventAppointmentCancellationLogEntity> _eventAppointmentCancellationLog;
		private EntityCollection<EventAppointmentChangeLogEntity> _eventAppointmentChangeLog;
		private EntityCollection<EventCustomerCriticalQuestionEntity> _eventCustomerCriticalQuestion;
		private EntityCollection<EventCustomerCurrentMedicationEntity> _eventCustomerCurrentMedication;
		private EntityCollection<EventCustomerCustomNotificationEntity> _eventCustomerCustomNotification;
		private EntityCollection<EventCustomerDiagnosisEntity> _eventCustomerDiagnosis;
		private EntityCollection<EventCustomerEligibilityEntity> _eventCustomerEligibility;
		private EntityCollection<EventCustomerEncounterEntity> _eventCustomerEncounter;
		private EntityCollection<EventCustomerGiftCardEntity> _eventCustomerGiftCard;
		private EntityCollection<EventCustomerIcdCodesEntity> _eventCustomerIcdCodes;
		private EntityCollection<EventCustomerNotificationEntity> _eventCustomerNotification;
		private EntityCollection<EventCustomerOrderDetailEntity> _eventCustomerOrderDetail;
		private EntityCollection<EventCustomerPreApprovedPackageTestEntity> _eventCustomerPreApprovedPackageTest;
		private EntityCollection<EventCustomerPreApprovedTestEntity> _eventCustomerPreApprovedTest;
		private EntityCollection<EventCustomerPrimaryCarePhysicianEntity> _eventCustomerPrimaryCarePhysician;
		private EntityCollection<EventCustomerQuestionAnswerEntity> _eventCustomerQuestionAnswer;
		private EntityCollection<EventCustomerRequiredTestEntity> _eventCustomerRequiredTest;
		private EntityCollection<EventCustomerRetestEntity> _eventCustomerRetest;
		private EntityCollection<EventCustomerTestNotPerformedNotificationEntity> _eventCustomerTestNotPerformedNotification;
		private EntityCollection<ExitInterviewAnswerEntity> _exitInterviewAnswer;
		private EntityCollection<ExitInterviewSignatureEntity> _exitInterviewSignature;
		private EntityCollection<FluConsentAnswerEntity> _fluConsentAnswer;
		private EntityCollection<FluConsentSignatureEntity> _fluConsentSignature;
		private EntityCollection<ParticipationConsentSignatureEntity> _participationConsentSignature;
		private EntityCollection<PcpDispositionEntity> _pcpDisposition;
		private EntityCollection<PhysicianCustomerAssignmentEntity> _physicianCustomerAssignment;
		private EntityCollection<PhysicianEvaluationEntity> _physicianEvaluation;
		private EntityCollection<PhysicianRecordRequestSignatureEntity> _physicianRecordRequestSignature;
		private EntityCollection<SurveyAnswerEntity> _surveyAnswer;
		private EntityCollection<AccountEntity> _accountCollectionViaCallQueueCustomer;
		private EntityCollection<ActivityTypeEntity> _activityTypeCollectionViaCallQueueCustomer;
		private EntityCollection<CallQueueEntity> _callQueueCollectionViaCallQueueCustomer;
		private EntityCollection<CallQueueCriteriaEntity> _callQueueCriteriaCollectionViaCallQueueCustomer;
		private EntityCollection<CampaignEntity> _campaignCollectionViaCallQueueCustomer;
		private EntityCollection<ChaperoneQuestionEntity> _chaperoneQuestionCollectionViaChaperoneAnswer;
		private EntityCollection<ChargeCardEntity> _chargeCardCollectionViaEventCustomerEligibility;
		private EntityCollection<CheckListQuestionEntity> _checkListQuestionCollectionViaExitInterviewSignature;
		private EntityCollection<CheckListQuestionEntity> _checkListQuestionCollectionViaCheckListAnswer;
		private EntityCollection<ClickLogEntity> _clickLogCollectionViaClickConversion;
		private EntityCollection<CorporateUploadEntity> _corporateUploadCollectionViaCustomerOrderHistory;
		private EntityCollection<CriticalQuestionEntity> _criticalQuestionCollectionViaEventCustomerCriticalQuestion;
		private EntityCollection<CustomerHealthQuestionsEntity> _customerHealthQuestionsCollectionViaCustomerHealthInfoArchive;
		private EntityCollection<CustomerHealthQuestionsEntity> _customerHealthQuestionsCollectionViaCustomerHealthInfo;
		private EntityCollection<CustomerPrimaryCarePhysicianEntity> _customerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerHealthInfo;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCallQueueCustomer;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaDependentDisqualifiedTest;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaClickConversion;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaDisqualifiedTest;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerOrderHistory;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerHealthInfoArchive;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaEventCustomerQuestionAnswer;
		private EntityCollection<CustomerRegistrationNotesEntity> _customerRegistrationNotesCollectionViaEventAppointmentCancellationLog;
		private EntityCollection<CustomEventNotificationEntity> _customEventNotificationCollectionViaEventCustomerCustomNotification;
		private EntityCollection<EligibilityEntity> _eligibilityCollectionViaEventCustomerEligibility;
		private EntityCollection<EncounterEntity> _encounterCollectionViaEventCustomerEncounter;
		private EntityCollection<EventPackageDetailsEntity> _eventPackageDetailsCollectionViaCustomerOrderHistory;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventAppointmentChangeLog_;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventAppointmentChangeLog;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventAppointmentCancellationLog;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventCustomerQuestionAnswer;
		private EntityCollection<EventsEntity> _eventsCollectionViaDependentDisqualifiedTest;
		private EntityCollection<EventsEntity> _eventsCollectionViaCustomerOrderHistory;
		private EntityCollection<EventsEntity> _eventsCollectionViaDisqualifiedTest;
		private EntityCollection<EventsEntity> _eventsCollectionViaCallQueueCustomer;
		private EntityCollection<EventTestEntity> _eventTestCollectionViaCustomerOrderHistory;
		private EntityCollection<ExitInterviewQuestionEntity> _exitInterviewQuestionCollectionViaExitInterviewAnswer;
		private EntityCollection<FileEntity> _fileCollectionViaParticipationConsentSignature_;
		private EntityCollection<FileEntity> _fileCollectionViaParticipationConsentSignature;
		private EntityCollection<FileEntity> _fileCollectionViaEventCustomerGiftCard;
		private EntityCollection<FileEntity> _fileCollectionViaEventCustomerGiftCard_;
		private EntityCollection<FileEntity> _fileCollectionViaFluConsentSignature_;
		private EntityCollection<FileEntity> _fileCollectionViaPhysicianRecordRequestSignature;
		private EntityCollection<FileEntity> _fileCollectionViaChaperoneSignature;
		private EntityCollection<FileEntity> _fileCollectionViaExitInterviewSignature;
		private EntityCollection<FileEntity> _fileCollectionViaChaperoneSignature_;
		private EntityCollection<FileEntity> _fileCollectionViaFluConsentSignature;
		private EntityCollection<FluConsentQuestionEntity> _fluConsentQuestionCollectionViaFluConsentAnswer;
		private EntityCollection<IcdCodesEntity> _icdCodesCollectionViaEventCustomerIcdCodes;
		private EntityCollection<LanguageEntity> _languageCollectionViaCallQueueCustomer;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerOrderHistory;
		private EntityCollection<LookupEntity> _lookupCollectionViaCallQueueCustomer;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventAppointmentChangeLog;
		private EntityCollection<LookupEntity> _lookupCollectionViaCheckListAnswer;
		private EntityCollection<LookupEntity> _lookupCollectionViaPcpDisposition;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventAppointmentCancellationLog;
		private EntityCollection<MedicareQuestionEntity> _medicareQuestionCollectionViaCustomerMedicareQuestionAnswer;
		private EntityCollection<NdcEntity> _ndcCollectionViaEventCustomerCurrentMedication;
		private EntityCollection<NotesDetailsEntity> _notesDetailsCollectionViaCallQueueCustomer;
		private EntityCollection<NotificationEntity> _notificationCollectionViaEventCustomerNotification;
		private EntityCollection<NotificationTypeEntity> _notificationTypeCollectionViaEventCustomerTestNotPerformedNotification;
		private EntityCollection<NotificationTypeEntity> _notificationTypeCollectionViaEventCustomerNotification;
		private EntityCollection<OrderDetailEntity> _orderDetailCollectionViaEventCustomerOrderDetail;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaExitInterviewAnswer_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaParticipationConsentSignature;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaFluConsentSignature;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaPcpDisposition_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaPcpDisposition;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventCustomerRetest;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaExitInterviewAnswer;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaExitInterviewSignature;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaFluConsentAnswer_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventCustomerQuestionAnswer;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventCustomerQuestionAnswer_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaFluConsentAnswer;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaChaperoneSignature;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaSurveyAnswer;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaDisqualifiedTest_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventAppointmentChangeLog;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaChaperoneAnswer_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventAppointmentCancellationLog;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCheckListAnswer_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerHealthInfo;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerHealthInfoArchive;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaDisqualifiedTest;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCheckListAnswer;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaSurveyAnswer_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaChaperoneAnswer;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueCustomer__;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventCustomerGiftCard;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueCustomer;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueCustomer_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaPhysicianRecordRequestSignature;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer;
		private EntityCollection<PackageEntity> _packageCollectionViaEventCustomerPreApprovedPackageTest;
		private EntityCollection<PhysicianProfileEntity> _physicianProfileCollectionViaPhysicianEvaluation;
		private EntityCollection<PhysicianProfileEntity> _physicianProfileCollectionViaPhysicianCustomerAssignment_;
		private EntityCollection<PhysicianProfileEntity> _physicianProfileCollectionViaPhysicianCustomerAssignment;
		private EntityCollection<PreQualificationQuestionEntity> _preQualificationQuestionCollectionViaEventCustomerQuestionAnswer;
		private EntityCollection<PreQualificationQuestionEntity> _preQualificationQuestionCollectionViaDisqualifiedTest;
		private EntityCollection<ProspectCustomerEntity> _prospectCustomerCollectionViaClickConversion;
		private EntityCollection<ProspectCustomerEntity> _prospectCustomerCollectionViaCallQueueCustomer;
		private EntityCollection<RefundRequestEntity> _refundRequestCollectionViaEventAppointmentCancellationLog;
		private EntityCollection<RescheduleCancelDispositionEntity> _rescheduleCancelDispositionCollectionViaEventAppointmentChangeLog;
		private EntityCollection<RescheduleCancelDispositionEntity> _rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog;
		private EntityCollection<SurveyQuestionEntity> _surveyQuestionCollectionViaSurveyAnswer;
		private EntityCollection<TestEntity> _testCollectionViaEventCustomerPreApprovedPackageTest;
		private EntityCollection<TestEntity> _testCollectionViaDisqualifiedTest;
		private EntityCollection<TestEntity> _testCollectionViaDependentDisqualifiedTest;
		private EntityCollection<TestEntity> _testCollectionViaEventCustomerRetest;
		private EntityCollection<TestEntity> _testCollectionViaEventCustomerTestNotPerformedNotification;
		private EntityCollection<TestEntity> _testCollectionViaEventCustomerPreApprovedTest;
		private EntityCollection<TestEntity> _testCollectionViaEventCustomerRequiredTest;
		private AfaffiliateCampaignEntity _afaffiliateCampaign;
		private CampaignEntity _campaign;
		private CustomerProfileEntity _customerProfile;
		private CustomerProfileHistoryEntity _customerProfileHistory;
		private CustomerRegistrationNotesEntity _customerRegistrationNotes;
		private EventAppointmentEntity _eventAppointment;
		private EventsEntity _events;
		private GcNotGivenReasonEntity _gcNotGivenReason;
		private HospitalFacilityEntity _hospitalFacility;
		private LookupEntity _lookup_;
		private LookupEntity _lookup;
		private OrganizationRoleUserEntity _organizationRoleUser_;
		private OrganizationRoleUserEntity _organizationRoleUser;
		private CustomerSkipReviewEntity _customerSkipReview;
		private EventCustomerBarrierEntity _eventCustomerBarrier;
		private EventCustomerBasicBioMetricEntity _eventCustomerBasicBioMetric;
		private EventCustomerEvaluationLockEntity _eventCustomerEvaluationLock;
		private EventCustomerResultEntity _eventCustomerResult;
		private PcpAppointmentEntity _pcpAppointment_;
		private ScreeningAuthorizationEntity _screeningAuthorization;
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name AfaffiliateCampaign</summary>
			public static readonly string AfaffiliateCampaign = "AfaffiliateCampaign";
			/// <summary>Member name Campaign</summary>
			public static readonly string Campaign = "Campaign";
			/// <summary>Member name CustomerProfile</summary>
			public static readonly string CustomerProfile = "CustomerProfile";
			/// <summary>Member name CustomerProfileHistory</summary>
			public static readonly string CustomerProfileHistory = "CustomerProfileHistory";
			/// <summary>Member name CustomerRegistrationNotes</summary>
			public static readonly string CustomerRegistrationNotes = "CustomerRegistrationNotes";
			/// <summary>Member name EventAppointment</summary>
			public static readonly string EventAppointment = "EventAppointment";
			/// <summary>Member name Events</summary>
			public static readonly string Events = "Events";
			/// <summary>Member name GcNotGivenReason</summary>
			public static readonly string GcNotGivenReason = "GcNotGivenReason";
			/// <summary>Member name HospitalFacility</summary>
			public static readonly string HospitalFacility = "HospitalFacility";
			/// <summary>Member name Lookup_</summary>
			public static readonly string Lookup_ = "Lookup_";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name OrganizationRoleUser_</summary>
			public static readonly string OrganizationRoleUser_ = "OrganizationRoleUser_";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name CallQueueCustomer</summary>
			public static readonly string CallQueueCustomer = "CallQueueCustomer";
			/// <summary>Member name ChaperoneAnswer</summary>
			public static readonly string ChaperoneAnswer = "ChaperoneAnswer";
			/// <summary>Member name ChaperoneSignature</summary>
			public static readonly string ChaperoneSignature = "ChaperoneSignature";
			/// <summary>Member name CheckListAnswer</summary>
			public static readonly string CheckListAnswer = "CheckListAnswer";
			/// <summary>Member name ClickConversion</summary>
			public static readonly string ClickConversion = "ClickConversion";
			/// <summary>Member name CustomerHealthInfo</summary>
			public static readonly string CustomerHealthInfo = "CustomerHealthInfo";
			/// <summary>Member name CustomerHealthInfoArchive</summary>
			public static readonly string CustomerHealthInfoArchive = "CustomerHealthInfoArchive";
			/// <summary>Member name CustomerMedicareQuestionAnswer</summary>
			public static readonly string CustomerMedicareQuestionAnswer = "CustomerMedicareQuestionAnswer";
			/// <summary>Member name CustomerOrderHistory</summary>
			public static readonly string CustomerOrderHistory = "CustomerOrderHistory";
			/// <summary>Member name DependentDisqualifiedTest</summary>
			public static readonly string DependentDisqualifiedTest = "DependentDisqualifiedTest";
			/// <summary>Member name DisqualifiedTest</summary>
			public static readonly string DisqualifiedTest = "DisqualifiedTest";
			/// <summary>Member name EventAppointmentCancellationLog</summary>
			public static readonly string EventAppointmentCancellationLog = "EventAppointmentCancellationLog";
			/// <summary>Member name EventAppointmentChangeLog</summary>
			public static readonly string EventAppointmentChangeLog = "EventAppointmentChangeLog";
			/// <summary>Member name EventCustomerCriticalQuestion</summary>
			public static readonly string EventCustomerCriticalQuestion = "EventCustomerCriticalQuestion";
			/// <summary>Member name EventCustomerCurrentMedication</summary>
			public static readonly string EventCustomerCurrentMedication = "EventCustomerCurrentMedication";
			/// <summary>Member name EventCustomerCustomNotification</summary>
			public static readonly string EventCustomerCustomNotification = "EventCustomerCustomNotification";
			/// <summary>Member name EventCustomerDiagnosis</summary>
			public static readonly string EventCustomerDiagnosis = "EventCustomerDiagnosis";
			/// <summary>Member name EventCustomerEligibility</summary>
			public static readonly string EventCustomerEligibility = "EventCustomerEligibility";
			/// <summary>Member name EventCustomerEncounter</summary>
			public static readonly string EventCustomerEncounter = "EventCustomerEncounter";
			/// <summary>Member name EventCustomerGiftCard</summary>
			public static readonly string EventCustomerGiftCard = "EventCustomerGiftCard";
			/// <summary>Member name EventCustomerIcdCodes</summary>
			public static readonly string EventCustomerIcdCodes = "EventCustomerIcdCodes";
			/// <summary>Member name EventCustomerNotification</summary>
			public static readonly string EventCustomerNotification = "EventCustomerNotification";
			/// <summary>Member name EventCustomerOrderDetail</summary>
			public static readonly string EventCustomerOrderDetail = "EventCustomerOrderDetail";
			/// <summary>Member name EventCustomerPreApprovedPackageTest</summary>
			public static readonly string EventCustomerPreApprovedPackageTest = "EventCustomerPreApprovedPackageTest";
			/// <summary>Member name EventCustomerPreApprovedTest</summary>
			public static readonly string EventCustomerPreApprovedTest = "EventCustomerPreApprovedTest";
			/// <summary>Member name EventCustomerPrimaryCarePhysician</summary>
			public static readonly string EventCustomerPrimaryCarePhysician = "EventCustomerPrimaryCarePhysician";
			/// <summary>Member name EventCustomerQuestionAnswer</summary>
			public static readonly string EventCustomerQuestionAnswer = "EventCustomerQuestionAnswer";
			/// <summary>Member name EventCustomerRequiredTest</summary>
			public static readonly string EventCustomerRequiredTest = "EventCustomerRequiredTest";
			/// <summary>Member name EventCustomerRetest</summary>
			public static readonly string EventCustomerRetest = "EventCustomerRetest";
			/// <summary>Member name EventCustomerTestNotPerformedNotification</summary>
			public static readonly string EventCustomerTestNotPerformedNotification = "EventCustomerTestNotPerformedNotification";
			/// <summary>Member name ExitInterviewAnswer</summary>
			public static readonly string ExitInterviewAnswer = "ExitInterviewAnswer";
			/// <summary>Member name ExitInterviewSignature</summary>
			public static readonly string ExitInterviewSignature = "ExitInterviewSignature";
			/// <summary>Member name FluConsentAnswer</summary>
			public static readonly string FluConsentAnswer = "FluConsentAnswer";
			/// <summary>Member name FluConsentSignature</summary>
			public static readonly string FluConsentSignature = "FluConsentSignature";
			/// <summary>Member name ParticipationConsentSignature</summary>
			public static readonly string ParticipationConsentSignature = "ParticipationConsentSignature";
			/// <summary>Member name PcpDisposition</summary>
			public static readonly string PcpDisposition = "PcpDisposition";
			/// <summary>Member name PhysicianCustomerAssignment</summary>
			public static readonly string PhysicianCustomerAssignment = "PhysicianCustomerAssignment";
			/// <summary>Member name PhysicianEvaluation</summary>
			public static readonly string PhysicianEvaluation = "PhysicianEvaluation";
			/// <summary>Member name PhysicianRecordRequestSignature</summary>
			public static readonly string PhysicianRecordRequestSignature = "PhysicianRecordRequestSignature";
			/// <summary>Member name SurveyAnswer</summary>
			public static readonly string SurveyAnswer = "SurveyAnswer";
			/// <summary>Member name AccountCollectionViaCallQueueCustomer</summary>
			public static readonly string AccountCollectionViaCallQueueCustomer = "AccountCollectionViaCallQueueCustomer";
			/// <summary>Member name ActivityTypeCollectionViaCallQueueCustomer</summary>
			public static readonly string ActivityTypeCollectionViaCallQueueCustomer = "ActivityTypeCollectionViaCallQueueCustomer";
			/// <summary>Member name CallQueueCollectionViaCallQueueCustomer</summary>
			public static readonly string CallQueueCollectionViaCallQueueCustomer = "CallQueueCollectionViaCallQueueCustomer";
			/// <summary>Member name CallQueueCriteriaCollectionViaCallQueueCustomer</summary>
			public static readonly string CallQueueCriteriaCollectionViaCallQueueCustomer = "CallQueueCriteriaCollectionViaCallQueueCustomer";
			/// <summary>Member name CampaignCollectionViaCallQueueCustomer</summary>
			public static readonly string CampaignCollectionViaCallQueueCustomer = "CampaignCollectionViaCallQueueCustomer";
			/// <summary>Member name ChaperoneQuestionCollectionViaChaperoneAnswer</summary>
			public static readonly string ChaperoneQuestionCollectionViaChaperoneAnswer = "ChaperoneQuestionCollectionViaChaperoneAnswer";
			/// <summary>Member name ChargeCardCollectionViaEventCustomerEligibility</summary>
			public static readonly string ChargeCardCollectionViaEventCustomerEligibility = "ChargeCardCollectionViaEventCustomerEligibility";
			/// <summary>Member name CheckListQuestionCollectionViaExitInterviewSignature</summary>
			public static readonly string CheckListQuestionCollectionViaExitInterviewSignature = "CheckListQuestionCollectionViaExitInterviewSignature";
			/// <summary>Member name CheckListQuestionCollectionViaCheckListAnswer</summary>
			public static readonly string CheckListQuestionCollectionViaCheckListAnswer = "CheckListQuestionCollectionViaCheckListAnswer";
			/// <summary>Member name ClickLogCollectionViaClickConversion</summary>
			public static readonly string ClickLogCollectionViaClickConversion = "ClickLogCollectionViaClickConversion";
			/// <summary>Member name CorporateUploadCollectionViaCustomerOrderHistory</summary>
			public static readonly string CorporateUploadCollectionViaCustomerOrderHistory = "CorporateUploadCollectionViaCustomerOrderHistory";
			/// <summary>Member name CriticalQuestionCollectionViaEventCustomerCriticalQuestion</summary>
			public static readonly string CriticalQuestionCollectionViaEventCustomerCriticalQuestion = "CriticalQuestionCollectionViaEventCustomerCriticalQuestion";
			/// <summary>Member name CustomerHealthQuestionsCollectionViaCustomerHealthInfoArchive</summary>
			public static readonly string CustomerHealthQuestionsCollectionViaCustomerHealthInfoArchive = "CustomerHealthQuestionsCollectionViaCustomerHealthInfoArchive";
			/// <summary>Member name CustomerHealthQuestionsCollectionViaCustomerHealthInfo</summary>
			public static readonly string CustomerHealthQuestionsCollectionViaCustomerHealthInfo = "CustomerHealthQuestionsCollectionViaCustomerHealthInfo";
			/// <summary>Member name CustomerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician</summary>
			public static readonly string CustomerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician = "CustomerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician";
			/// <summary>Member name CustomerProfileCollectionViaCustomerHealthInfo</summary>
			public static readonly string CustomerProfileCollectionViaCustomerHealthInfo = "CustomerProfileCollectionViaCustomerHealthInfo";
			/// <summary>Member name CustomerProfileCollectionViaCallQueueCustomer</summary>
			public static readonly string CustomerProfileCollectionViaCallQueueCustomer = "CustomerProfileCollectionViaCallQueueCustomer";
			/// <summary>Member name CustomerProfileCollectionViaDependentDisqualifiedTest</summary>
			public static readonly string CustomerProfileCollectionViaDependentDisqualifiedTest = "CustomerProfileCollectionViaDependentDisqualifiedTest";
			/// <summary>Member name CustomerProfileCollectionViaClickConversion</summary>
			public static readonly string CustomerProfileCollectionViaClickConversion = "CustomerProfileCollectionViaClickConversion";
			/// <summary>Member name CustomerProfileCollectionViaDisqualifiedTest</summary>
			public static readonly string CustomerProfileCollectionViaDisqualifiedTest = "CustomerProfileCollectionViaDisqualifiedTest";
			/// <summary>Member name CustomerProfileCollectionViaCustomerOrderHistory</summary>
			public static readonly string CustomerProfileCollectionViaCustomerOrderHistory = "CustomerProfileCollectionViaCustomerOrderHistory";
			/// <summary>Member name CustomerProfileCollectionViaCustomerHealthInfoArchive</summary>
			public static readonly string CustomerProfileCollectionViaCustomerHealthInfoArchive = "CustomerProfileCollectionViaCustomerHealthInfoArchive";
			/// <summary>Member name CustomerProfileCollectionViaEventCustomerQuestionAnswer</summary>
			public static readonly string CustomerProfileCollectionViaEventCustomerQuestionAnswer = "CustomerProfileCollectionViaEventCustomerQuestionAnswer";
			/// <summary>Member name CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog</summary>
			public static readonly string CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog = "CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog";
			/// <summary>Member name CustomEventNotificationCollectionViaEventCustomerCustomNotification</summary>
			public static readonly string CustomEventNotificationCollectionViaEventCustomerCustomNotification = "CustomEventNotificationCollectionViaEventCustomerCustomNotification";
			/// <summary>Member name EligibilityCollectionViaEventCustomerEligibility</summary>
			public static readonly string EligibilityCollectionViaEventCustomerEligibility = "EligibilityCollectionViaEventCustomerEligibility";
			/// <summary>Member name EncounterCollectionViaEventCustomerEncounter</summary>
			public static readonly string EncounterCollectionViaEventCustomerEncounter = "EncounterCollectionViaEventCustomerEncounter";
			/// <summary>Member name EventPackageDetailsCollectionViaCustomerOrderHistory</summary>
			public static readonly string EventPackageDetailsCollectionViaCustomerOrderHistory = "EventPackageDetailsCollectionViaCustomerOrderHistory";
			/// <summary>Member name EventsCollectionViaEventAppointmentChangeLog_</summary>
			public static readonly string EventsCollectionViaEventAppointmentChangeLog_ = "EventsCollectionViaEventAppointmentChangeLog_";
			/// <summary>Member name EventsCollectionViaEventAppointmentChangeLog</summary>
			public static readonly string EventsCollectionViaEventAppointmentChangeLog = "EventsCollectionViaEventAppointmentChangeLog";
			/// <summary>Member name EventsCollectionViaEventAppointmentCancellationLog</summary>
			public static readonly string EventsCollectionViaEventAppointmentCancellationLog = "EventsCollectionViaEventAppointmentCancellationLog";
			/// <summary>Member name EventsCollectionViaEventCustomerQuestionAnswer</summary>
			public static readonly string EventsCollectionViaEventCustomerQuestionAnswer = "EventsCollectionViaEventCustomerQuestionAnswer";
			/// <summary>Member name EventsCollectionViaDependentDisqualifiedTest</summary>
			public static readonly string EventsCollectionViaDependentDisqualifiedTest = "EventsCollectionViaDependentDisqualifiedTest";
			/// <summary>Member name EventsCollectionViaCustomerOrderHistory</summary>
			public static readonly string EventsCollectionViaCustomerOrderHistory = "EventsCollectionViaCustomerOrderHistory";
			/// <summary>Member name EventsCollectionViaDisqualifiedTest</summary>
			public static readonly string EventsCollectionViaDisqualifiedTest = "EventsCollectionViaDisqualifiedTest";
			/// <summary>Member name EventsCollectionViaCallQueueCustomer</summary>
			public static readonly string EventsCollectionViaCallQueueCustomer = "EventsCollectionViaCallQueueCustomer";
			/// <summary>Member name EventTestCollectionViaCustomerOrderHistory</summary>
			public static readonly string EventTestCollectionViaCustomerOrderHistory = "EventTestCollectionViaCustomerOrderHistory";
			/// <summary>Member name ExitInterviewQuestionCollectionViaExitInterviewAnswer</summary>
			public static readonly string ExitInterviewQuestionCollectionViaExitInterviewAnswer = "ExitInterviewQuestionCollectionViaExitInterviewAnswer";
			/// <summary>Member name FileCollectionViaParticipationConsentSignature_</summary>
			public static readonly string FileCollectionViaParticipationConsentSignature_ = "FileCollectionViaParticipationConsentSignature_";
			/// <summary>Member name FileCollectionViaParticipationConsentSignature</summary>
			public static readonly string FileCollectionViaParticipationConsentSignature = "FileCollectionViaParticipationConsentSignature";
			/// <summary>Member name FileCollectionViaEventCustomerGiftCard</summary>
			public static readonly string FileCollectionViaEventCustomerGiftCard = "FileCollectionViaEventCustomerGiftCard";
			/// <summary>Member name FileCollectionViaEventCustomerGiftCard_</summary>
			public static readonly string FileCollectionViaEventCustomerGiftCard_ = "FileCollectionViaEventCustomerGiftCard_";
			/// <summary>Member name FileCollectionViaFluConsentSignature_</summary>
			public static readonly string FileCollectionViaFluConsentSignature_ = "FileCollectionViaFluConsentSignature_";
			/// <summary>Member name FileCollectionViaPhysicianRecordRequestSignature</summary>
			public static readonly string FileCollectionViaPhysicianRecordRequestSignature = "FileCollectionViaPhysicianRecordRequestSignature";
			/// <summary>Member name FileCollectionViaChaperoneSignature</summary>
			public static readonly string FileCollectionViaChaperoneSignature = "FileCollectionViaChaperoneSignature";
			/// <summary>Member name FileCollectionViaExitInterviewSignature</summary>
			public static readonly string FileCollectionViaExitInterviewSignature = "FileCollectionViaExitInterviewSignature";
			/// <summary>Member name FileCollectionViaChaperoneSignature_</summary>
			public static readonly string FileCollectionViaChaperoneSignature_ = "FileCollectionViaChaperoneSignature_";
			/// <summary>Member name FileCollectionViaFluConsentSignature</summary>
			public static readonly string FileCollectionViaFluConsentSignature = "FileCollectionViaFluConsentSignature";
			/// <summary>Member name FluConsentQuestionCollectionViaFluConsentAnswer</summary>
			public static readonly string FluConsentQuestionCollectionViaFluConsentAnswer = "FluConsentQuestionCollectionViaFluConsentAnswer";
			/// <summary>Member name IcdCodesCollectionViaEventCustomerIcdCodes</summary>
			public static readonly string IcdCodesCollectionViaEventCustomerIcdCodes = "IcdCodesCollectionViaEventCustomerIcdCodes";
			/// <summary>Member name LanguageCollectionViaCallQueueCustomer</summary>
			public static readonly string LanguageCollectionViaCallQueueCustomer = "LanguageCollectionViaCallQueueCustomer";
			/// <summary>Member name LookupCollectionViaCustomerOrderHistory</summary>
			public static readonly string LookupCollectionViaCustomerOrderHistory = "LookupCollectionViaCustomerOrderHistory";
			/// <summary>Member name LookupCollectionViaCallQueueCustomer</summary>
			public static readonly string LookupCollectionViaCallQueueCustomer = "LookupCollectionViaCallQueueCustomer";
			/// <summary>Member name LookupCollectionViaEventAppointmentChangeLog</summary>
			public static readonly string LookupCollectionViaEventAppointmentChangeLog = "LookupCollectionViaEventAppointmentChangeLog";
			/// <summary>Member name LookupCollectionViaCheckListAnswer</summary>
			public static readonly string LookupCollectionViaCheckListAnswer = "LookupCollectionViaCheckListAnswer";
			/// <summary>Member name LookupCollectionViaPcpDisposition</summary>
			public static readonly string LookupCollectionViaPcpDisposition = "LookupCollectionViaPcpDisposition";
			/// <summary>Member name LookupCollectionViaEventAppointmentCancellationLog</summary>
			public static readonly string LookupCollectionViaEventAppointmentCancellationLog = "LookupCollectionViaEventAppointmentCancellationLog";
			/// <summary>Member name MedicareQuestionCollectionViaCustomerMedicareQuestionAnswer</summary>
			public static readonly string MedicareQuestionCollectionViaCustomerMedicareQuestionAnswer = "MedicareQuestionCollectionViaCustomerMedicareQuestionAnswer";
			/// <summary>Member name NdcCollectionViaEventCustomerCurrentMedication</summary>
			public static readonly string NdcCollectionViaEventCustomerCurrentMedication = "NdcCollectionViaEventCustomerCurrentMedication";
			/// <summary>Member name NotesDetailsCollectionViaCallQueueCustomer</summary>
			public static readonly string NotesDetailsCollectionViaCallQueueCustomer = "NotesDetailsCollectionViaCallQueueCustomer";
			/// <summary>Member name NotificationCollectionViaEventCustomerNotification</summary>
			public static readonly string NotificationCollectionViaEventCustomerNotification = "NotificationCollectionViaEventCustomerNotification";
			/// <summary>Member name NotificationTypeCollectionViaEventCustomerTestNotPerformedNotification</summary>
			public static readonly string NotificationTypeCollectionViaEventCustomerTestNotPerformedNotification = "NotificationTypeCollectionViaEventCustomerTestNotPerformedNotification";
			/// <summary>Member name NotificationTypeCollectionViaEventCustomerNotification</summary>
			public static readonly string NotificationTypeCollectionViaEventCustomerNotification = "NotificationTypeCollectionViaEventCustomerNotification";
			/// <summary>Member name OrderDetailCollectionViaEventCustomerOrderDetail</summary>
			public static readonly string OrderDetailCollectionViaEventCustomerOrderDetail = "OrderDetailCollectionViaEventCustomerOrderDetail";
			/// <summary>Member name OrganizationRoleUserCollectionViaExitInterviewAnswer_</summary>
			public static readonly string OrganizationRoleUserCollectionViaExitInterviewAnswer_ = "OrganizationRoleUserCollectionViaExitInterviewAnswer_";
			/// <summary>Member name OrganizationRoleUserCollectionViaParticipationConsentSignature</summary>
			public static readonly string OrganizationRoleUserCollectionViaParticipationConsentSignature = "OrganizationRoleUserCollectionViaParticipationConsentSignature";
			/// <summary>Member name OrganizationRoleUserCollectionViaFluConsentSignature</summary>
			public static readonly string OrganizationRoleUserCollectionViaFluConsentSignature = "OrganizationRoleUserCollectionViaFluConsentSignature";
			/// <summary>Member name OrganizationRoleUserCollectionViaPcpDisposition_</summary>
			public static readonly string OrganizationRoleUserCollectionViaPcpDisposition_ = "OrganizationRoleUserCollectionViaPcpDisposition_";
			/// <summary>Member name OrganizationRoleUserCollectionViaPcpDisposition</summary>
			public static readonly string OrganizationRoleUserCollectionViaPcpDisposition = "OrganizationRoleUserCollectionViaPcpDisposition";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician = "OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification = "OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventCustomerRetest</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventCustomerRetest = "OrganizationRoleUserCollectionViaEventCustomerRetest";
			/// <summary>Member name OrganizationRoleUserCollectionViaExitInterviewAnswer</summary>
			public static readonly string OrganizationRoleUserCollectionViaExitInterviewAnswer = "OrganizationRoleUserCollectionViaExitInterviewAnswer";
			/// <summary>Member name OrganizationRoleUserCollectionViaExitInterviewSignature</summary>
			public static readonly string OrganizationRoleUserCollectionViaExitInterviewSignature = "OrganizationRoleUserCollectionViaExitInterviewSignature";
			/// <summary>Member name OrganizationRoleUserCollectionViaFluConsentAnswer_</summary>
			public static readonly string OrganizationRoleUserCollectionViaFluConsentAnswer_ = "OrganizationRoleUserCollectionViaFluConsentAnswer_";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer = "OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_ = "OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_";
			/// <summary>Member name OrganizationRoleUserCollectionViaFluConsentAnswer</summary>
			public static readonly string OrganizationRoleUserCollectionViaFluConsentAnswer = "OrganizationRoleUserCollectionViaFluConsentAnswer";
			/// <summary>Member name OrganizationRoleUserCollectionViaChaperoneSignature</summary>
			public static readonly string OrganizationRoleUserCollectionViaChaperoneSignature = "OrganizationRoleUserCollectionViaChaperoneSignature";
			/// <summary>Member name OrganizationRoleUserCollectionViaSurveyAnswer</summary>
			public static readonly string OrganizationRoleUserCollectionViaSurveyAnswer = "OrganizationRoleUserCollectionViaSurveyAnswer";
			/// <summary>Member name OrganizationRoleUserCollectionViaDisqualifiedTest_</summary>
			public static readonly string OrganizationRoleUserCollectionViaDisqualifiedTest_ = "OrganizationRoleUserCollectionViaDisqualifiedTest_";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventAppointmentChangeLog</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventAppointmentChangeLog = "OrganizationRoleUserCollectionViaEventAppointmentChangeLog";
			/// <summary>Member name OrganizationRoleUserCollectionViaChaperoneAnswer_</summary>
			public static readonly string OrganizationRoleUserCollectionViaChaperoneAnswer_ = "OrganizationRoleUserCollectionViaChaperoneAnswer_";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventAppointmentCancellationLog</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventAppointmentCancellationLog = "OrganizationRoleUserCollectionViaEventAppointmentCancellationLog";
			/// <summary>Member name OrganizationRoleUserCollectionViaCheckListAnswer_</summary>
			public static readonly string OrganizationRoleUserCollectionViaCheckListAnswer_ = "OrganizationRoleUserCollectionViaCheckListAnswer_";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerHealthInfo</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerHealthInfo = "OrganizationRoleUserCollectionViaCustomerHealthInfo";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerHealthInfoArchive</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerHealthInfoArchive = "OrganizationRoleUserCollectionViaCustomerHealthInfoArchive";
			/// <summary>Member name OrganizationRoleUserCollectionViaDisqualifiedTest</summary>
			public static readonly string OrganizationRoleUserCollectionViaDisqualifiedTest = "OrganizationRoleUserCollectionViaDisqualifiedTest";
			/// <summary>Member name OrganizationRoleUserCollectionViaCheckListAnswer</summary>
			public static readonly string OrganizationRoleUserCollectionViaCheckListAnswer = "OrganizationRoleUserCollectionViaCheckListAnswer";
			/// <summary>Member name OrganizationRoleUserCollectionViaSurveyAnswer_</summary>
			public static readonly string OrganizationRoleUserCollectionViaSurveyAnswer_ = "OrganizationRoleUserCollectionViaSurveyAnswer_";
			/// <summary>Member name OrganizationRoleUserCollectionViaChaperoneAnswer</summary>
			public static readonly string OrganizationRoleUserCollectionViaChaperoneAnswer = "OrganizationRoleUserCollectionViaChaperoneAnswer";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueCustomer__</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueCustomer__ = "OrganizationRoleUserCollectionViaCallQueueCustomer__";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventCustomerGiftCard</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventCustomerGiftCard = "OrganizationRoleUserCollectionViaEventCustomerGiftCard";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueCustomer</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueCustomer = "OrganizationRoleUserCollectionViaCallQueueCustomer";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueCustomer_</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueCustomer_ = "OrganizationRoleUserCollectionViaCallQueueCustomer_";
			/// <summary>Member name OrganizationRoleUserCollectionViaPhysicianRecordRequestSignature</summary>
			public static readonly string OrganizationRoleUserCollectionViaPhysicianRecordRequestSignature = "OrganizationRoleUserCollectionViaPhysicianRecordRequestSignature";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer = "OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer";
			/// <summary>Member name PackageCollectionViaEventCustomerPreApprovedPackageTest</summary>
			public static readonly string PackageCollectionViaEventCustomerPreApprovedPackageTest = "PackageCollectionViaEventCustomerPreApprovedPackageTest";
			/// <summary>Member name PhysicianProfileCollectionViaPhysicianEvaluation</summary>
			public static readonly string PhysicianProfileCollectionViaPhysicianEvaluation = "PhysicianProfileCollectionViaPhysicianEvaluation";
			/// <summary>Member name PhysicianProfileCollectionViaPhysicianCustomerAssignment_</summary>
			public static readonly string PhysicianProfileCollectionViaPhysicianCustomerAssignment_ = "PhysicianProfileCollectionViaPhysicianCustomerAssignment_";
			/// <summary>Member name PhysicianProfileCollectionViaPhysicianCustomerAssignment</summary>
			public static readonly string PhysicianProfileCollectionViaPhysicianCustomerAssignment = "PhysicianProfileCollectionViaPhysicianCustomerAssignment";
			/// <summary>Member name PreQualificationQuestionCollectionViaEventCustomerQuestionAnswer</summary>
			public static readonly string PreQualificationQuestionCollectionViaEventCustomerQuestionAnswer = "PreQualificationQuestionCollectionViaEventCustomerQuestionAnswer";
			/// <summary>Member name PreQualificationQuestionCollectionViaDisqualifiedTest</summary>
			public static readonly string PreQualificationQuestionCollectionViaDisqualifiedTest = "PreQualificationQuestionCollectionViaDisqualifiedTest";
			/// <summary>Member name ProspectCustomerCollectionViaClickConversion</summary>
			public static readonly string ProspectCustomerCollectionViaClickConversion = "ProspectCustomerCollectionViaClickConversion";
			/// <summary>Member name ProspectCustomerCollectionViaCallQueueCustomer</summary>
			public static readonly string ProspectCustomerCollectionViaCallQueueCustomer = "ProspectCustomerCollectionViaCallQueueCustomer";
			/// <summary>Member name RefundRequestCollectionViaEventAppointmentCancellationLog</summary>
			public static readonly string RefundRequestCollectionViaEventAppointmentCancellationLog = "RefundRequestCollectionViaEventAppointmentCancellationLog";
			/// <summary>Member name RescheduleCancelDispositionCollectionViaEventAppointmentChangeLog</summary>
			public static readonly string RescheduleCancelDispositionCollectionViaEventAppointmentChangeLog = "RescheduleCancelDispositionCollectionViaEventAppointmentChangeLog";
			/// <summary>Member name RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog</summary>
			public static readonly string RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog = "RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog";
			/// <summary>Member name SurveyQuestionCollectionViaSurveyAnswer</summary>
			public static readonly string SurveyQuestionCollectionViaSurveyAnswer = "SurveyQuestionCollectionViaSurveyAnswer";
			/// <summary>Member name TestCollectionViaEventCustomerPreApprovedPackageTest</summary>
			public static readonly string TestCollectionViaEventCustomerPreApprovedPackageTest = "TestCollectionViaEventCustomerPreApprovedPackageTest";
			/// <summary>Member name TestCollectionViaDisqualifiedTest</summary>
			public static readonly string TestCollectionViaDisqualifiedTest = "TestCollectionViaDisqualifiedTest";
			/// <summary>Member name TestCollectionViaDependentDisqualifiedTest</summary>
			public static readonly string TestCollectionViaDependentDisqualifiedTest = "TestCollectionViaDependentDisqualifiedTest";
			/// <summary>Member name TestCollectionViaEventCustomerRetest</summary>
			public static readonly string TestCollectionViaEventCustomerRetest = "TestCollectionViaEventCustomerRetest";
			/// <summary>Member name TestCollectionViaEventCustomerTestNotPerformedNotification</summary>
			public static readonly string TestCollectionViaEventCustomerTestNotPerformedNotification = "TestCollectionViaEventCustomerTestNotPerformedNotification";
			/// <summary>Member name TestCollectionViaEventCustomerPreApprovedTest</summary>
			public static readonly string TestCollectionViaEventCustomerPreApprovedTest = "TestCollectionViaEventCustomerPreApprovedTest";
			/// <summary>Member name TestCollectionViaEventCustomerRequiredTest</summary>
			public static readonly string TestCollectionViaEventCustomerRequiredTest = "TestCollectionViaEventCustomerRequiredTest";
			/// <summary>Member name CustomerSkipReview</summary>
			public static readonly string CustomerSkipReview = "CustomerSkipReview";
			/// <summary>Member name EventCustomerBarrier</summary>
			public static readonly string EventCustomerBarrier = "EventCustomerBarrier";
			/// <summary>Member name EventCustomerBasicBioMetric</summary>
			public static readonly string EventCustomerBasicBioMetric = "EventCustomerBasicBioMetric";
			/// <summary>Member name EventCustomerEvaluationLock</summary>
			public static readonly string EventCustomerEvaluationLock = "EventCustomerEvaluationLock";
			/// <summary>Member name EventCustomerResult</summary>
			public static readonly string EventCustomerResult = "EventCustomerResult";
			/// <summary>Member name PcpAppointment_</summary>
			public static readonly string PcpAppointment_ = "PcpAppointment_";
			/// <summary>Member name ScreeningAuthorization</summary>
			public static readonly string ScreeningAuthorization = "ScreeningAuthorization";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static EventCustomersEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public EventCustomersEntity():base("EventCustomersEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public EventCustomersEntity(IEntityFields2 fields):base("EventCustomersEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this EventCustomersEntity</param>
		public EventCustomersEntity(IValidator validator):base("EventCustomersEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="eventCustomerId">PK value for EventCustomers which data should be fetched into this EventCustomers object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EventCustomersEntity(System.Int64 eventCustomerId):base("EventCustomersEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.EventCustomerId = eventCustomerId;
		}

		/// <summary> CTor</summary>
		/// <param name="eventCustomerId">PK value for EventCustomers which data should be fetched into this EventCustomers object</param>
		/// <param name="validator">The custom validator object for this EventCustomersEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EventCustomersEntity(System.Int64 eventCustomerId, IValidator validator):base("EventCustomersEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.EventCustomerId = eventCustomerId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected EventCustomersEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_callQueueCustomer = (EntityCollection<CallQueueCustomerEntity>)info.GetValue("_callQueueCustomer", typeof(EntityCollection<CallQueueCustomerEntity>));
				_chaperoneAnswer = (EntityCollection<ChaperoneAnswerEntity>)info.GetValue("_chaperoneAnswer", typeof(EntityCollection<ChaperoneAnswerEntity>));
				_chaperoneSignature = (EntityCollection<ChaperoneSignatureEntity>)info.GetValue("_chaperoneSignature", typeof(EntityCollection<ChaperoneSignatureEntity>));
				_checkListAnswer = (EntityCollection<CheckListAnswerEntity>)info.GetValue("_checkListAnswer", typeof(EntityCollection<CheckListAnswerEntity>));
				_clickConversion = (EntityCollection<ClickConversionEntity>)info.GetValue("_clickConversion", typeof(EntityCollection<ClickConversionEntity>));
				_customerHealthInfo = (EntityCollection<CustomerHealthInfoEntity>)info.GetValue("_customerHealthInfo", typeof(EntityCollection<CustomerHealthInfoEntity>));
				_customerHealthInfoArchive = (EntityCollection<CustomerHealthInfoArchiveEntity>)info.GetValue("_customerHealthInfoArchive", typeof(EntityCollection<CustomerHealthInfoArchiveEntity>));
				_customerMedicareQuestionAnswer = (EntityCollection<CustomerMedicareQuestionAnswerEntity>)info.GetValue("_customerMedicareQuestionAnswer", typeof(EntityCollection<CustomerMedicareQuestionAnswerEntity>));
				_customerOrderHistory = (EntityCollection<CustomerOrderHistoryEntity>)info.GetValue("_customerOrderHistory", typeof(EntityCollection<CustomerOrderHistoryEntity>));
				_dependentDisqualifiedTest = (EntityCollection<DependentDisqualifiedTestEntity>)info.GetValue("_dependentDisqualifiedTest", typeof(EntityCollection<DependentDisqualifiedTestEntity>));
				_disqualifiedTest = (EntityCollection<DisqualifiedTestEntity>)info.GetValue("_disqualifiedTest", typeof(EntityCollection<DisqualifiedTestEntity>));
				_eventAppointmentCancellationLog = (EntityCollection<EventAppointmentCancellationLogEntity>)info.GetValue("_eventAppointmentCancellationLog", typeof(EntityCollection<EventAppointmentCancellationLogEntity>));
				_eventAppointmentChangeLog = (EntityCollection<EventAppointmentChangeLogEntity>)info.GetValue("_eventAppointmentChangeLog", typeof(EntityCollection<EventAppointmentChangeLogEntity>));
				_eventCustomerCriticalQuestion = (EntityCollection<EventCustomerCriticalQuestionEntity>)info.GetValue("_eventCustomerCriticalQuestion", typeof(EntityCollection<EventCustomerCriticalQuestionEntity>));
				_eventCustomerCurrentMedication = (EntityCollection<EventCustomerCurrentMedicationEntity>)info.GetValue("_eventCustomerCurrentMedication", typeof(EntityCollection<EventCustomerCurrentMedicationEntity>));
				_eventCustomerCustomNotification = (EntityCollection<EventCustomerCustomNotificationEntity>)info.GetValue("_eventCustomerCustomNotification", typeof(EntityCollection<EventCustomerCustomNotificationEntity>));
				_eventCustomerDiagnosis = (EntityCollection<EventCustomerDiagnosisEntity>)info.GetValue("_eventCustomerDiagnosis", typeof(EntityCollection<EventCustomerDiagnosisEntity>));
				_eventCustomerEligibility = (EntityCollection<EventCustomerEligibilityEntity>)info.GetValue("_eventCustomerEligibility", typeof(EntityCollection<EventCustomerEligibilityEntity>));
				_eventCustomerEncounter = (EntityCollection<EventCustomerEncounterEntity>)info.GetValue("_eventCustomerEncounter", typeof(EntityCollection<EventCustomerEncounterEntity>));
				_eventCustomerGiftCard = (EntityCollection<EventCustomerGiftCardEntity>)info.GetValue("_eventCustomerGiftCard", typeof(EntityCollection<EventCustomerGiftCardEntity>));
				_eventCustomerIcdCodes = (EntityCollection<EventCustomerIcdCodesEntity>)info.GetValue("_eventCustomerIcdCodes", typeof(EntityCollection<EventCustomerIcdCodesEntity>));
				_eventCustomerNotification = (EntityCollection<EventCustomerNotificationEntity>)info.GetValue("_eventCustomerNotification", typeof(EntityCollection<EventCustomerNotificationEntity>));
				_eventCustomerOrderDetail = (EntityCollection<EventCustomerOrderDetailEntity>)info.GetValue("_eventCustomerOrderDetail", typeof(EntityCollection<EventCustomerOrderDetailEntity>));
				_eventCustomerPreApprovedPackageTest = (EntityCollection<EventCustomerPreApprovedPackageTestEntity>)info.GetValue("_eventCustomerPreApprovedPackageTest", typeof(EntityCollection<EventCustomerPreApprovedPackageTestEntity>));
				_eventCustomerPreApprovedTest = (EntityCollection<EventCustomerPreApprovedTestEntity>)info.GetValue("_eventCustomerPreApprovedTest", typeof(EntityCollection<EventCustomerPreApprovedTestEntity>));
				_eventCustomerPrimaryCarePhysician = (EntityCollection<EventCustomerPrimaryCarePhysicianEntity>)info.GetValue("_eventCustomerPrimaryCarePhysician", typeof(EntityCollection<EventCustomerPrimaryCarePhysicianEntity>));
				_eventCustomerQuestionAnswer = (EntityCollection<EventCustomerQuestionAnswerEntity>)info.GetValue("_eventCustomerQuestionAnswer", typeof(EntityCollection<EventCustomerQuestionAnswerEntity>));
				_eventCustomerRequiredTest = (EntityCollection<EventCustomerRequiredTestEntity>)info.GetValue("_eventCustomerRequiredTest", typeof(EntityCollection<EventCustomerRequiredTestEntity>));
				_eventCustomerRetest = (EntityCollection<EventCustomerRetestEntity>)info.GetValue("_eventCustomerRetest", typeof(EntityCollection<EventCustomerRetestEntity>));
				_eventCustomerTestNotPerformedNotification = (EntityCollection<EventCustomerTestNotPerformedNotificationEntity>)info.GetValue("_eventCustomerTestNotPerformedNotification", typeof(EntityCollection<EventCustomerTestNotPerformedNotificationEntity>));
				_exitInterviewAnswer = (EntityCollection<ExitInterviewAnswerEntity>)info.GetValue("_exitInterviewAnswer", typeof(EntityCollection<ExitInterviewAnswerEntity>));
				_exitInterviewSignature = (EntityCollection<ExitInterviewSignatureEntity>)info.GetValue("_exitInterviewSignature", typeof(EntityCollection<ExitInterviewSignatureEntity>));
				_fluConsentAnswer = (EntityCollection<FluConsentAnswerEntity>)info.GetValue("_fluConsentAnswer", typeof(EntityCollection<FluConsentAnswerEntity>));
				_fluConsentSignature = (EntityCollection<FluConsentSignatureEntity>)info.GetValue("_fluConsentSignature", typeof(EntityCollection<FluConsentSignatureEntity>));
				_participationConsentSignature = (EntityCollection<ParticipationConsentSignatureEntity>)info.GetValue("_participationConsentSignature", typeof(EntityCollection<ParticipationConsentSignatureEntity>));
				_pcpDisposition = (EntityCollection<PcpDispositionEntity>)info.GetValue("_pcpDisposition", typeof(EntityCollection<PcpDispositionEntity>));
				_physicianCustomerAssignment = (EntityCollection<PhysicianCustomerAssignmentEntity>)info.GetValue("_physicianCustomerAssignment", typeof(EntityCollection<PhysicianCustomerAssignmentEntity>));
				_physicianEvaluation = (EntityCollection<PhysicianEvaluationEntity>)info.GetValue("_physicianEvaluation", typeof(EntityCollection<PhysicianEvaluationEntity>));
				_physicianRecordRequestSignature = (EntityCollection<PhysicianRecordRequestSignatureEntity>)info.GetValue("_physicianRecordRequestSignature", typeof(EntityCollection<PhysicianRecordRequestSignatureEntity>));
				_surveyAnswer = (EntityCollection<SurveyAnswerEntity>)info.GetValue("_surveyAnswer", typeof(EntityCollection<SurveyAnswerEntity>));
				_accountCollectionViaCallQueueCustomer = (EntityCollection<AccountEntity>)info.GetValue("_accountCollectionViaCallQueueCustomer", typeof(EntityCollection<AccountEntity>));
				_activityTypeCollectionViaCallQueueCustomer = (EntityCollection<ActivityTypeEntity>)info.GetValue("_activityTypeCollectionViaCallQueueCustomer", typeof(EntityCollection<ActivityTypeEntity>));
				_callQueueCollectionViaCallQueueCustomer = (EntityCollection<CallQueueEntity>)info.GetValue("_callQueueCollectionViaCallQueueCustomer", typeof(EntityCollection<CallQueueEntity>));
				_callQueueCriteriaCollectionViaCallQueueCustomer = (EntityCollection<CallQueueCriteriaEntity>)info.GetValue("_callQueueCriteriaCollectionViaCallQueueCustomer", typeof(EntityCollection<CallQueueCriteriaEntity>));
				_campaignCollectionViaCallQueueCustomer = (EntityCollection<CampaignEntity>)info.GetValue("_campaignCollectionViaCallQueueCustomer", typeof(EntityCollection<CampaignEntity>));
				_chaperoneQuestionCollectionViaChaperoneAnswer = (EntityCollection<ChaperoneQuestionEntity>)info.GetValue("_chaperoneQuestionCollectionViaChaperoneAnswer", typeof(EntityCollection<ChaperoneQuestionEntity>));
				_chargeCardCollectionViaEventCustomerEligibility = (EntityCollection<ChargeCardEntity>)info.GetValue("_chargeCardCollectionViaEventCustomerEligibility", typeof(EntityCollection<ChargeCardEntity>));
				_checkListQuestionCollectionViaExitInterviewSignature = (EntityCollection<CheckListQuestionEntity>)info.GetValue("_checkListQuestionCollectionViaExitInterviewSignature", typeof(EntityCollection<CheckListQuestionEntity>));
				_checkListQuestionCollectionViaCheckListAnswer = (EntityCollection<CheckListQuestionEntity>)info.GetValue("_checkListQuestionCollectionViaCheckListAnswer", typeof(EntityCollection<CheckListQuestionEntity>));
				_clickLogCollectionViaClickConversion = (EntityCollection<ClickLogEntity>)info.GetValue("_clickLogCollectionViaClickConversion", typeof(EntityCollection<ClickLogEntity>));
				_corporateUploadCollectionViaCustomerOrderHistory = (EntityCollection<CorporateUploadEntity>)info.GetValue("_corporateUploadCollectionViaCustomerOrderHistory", typeof(EntityCollection<CorporateUploadEntity>));
				_criticalQuestionCollectionViaEventCustomerCriticalQuestion = (EntityCollection<CriticalQuestionEntity>)info.GetValue("_criticalQuestionCollectionViaEventCustomerCriticalQuestion", typeof(EntityCollection<CriticalQuestionEntity>));
				_customerHealthQuestionsCollectionViaCustomerHealthInfoArchive = (EntityCollection<CustomerHealthQuestionsEntity>)info.GetValue("_customerHealthQuestionsCollectionViaCustomerHealthInfoArchive", typeof(EntityCollection<CustomerHealthQuestionsEntity>));
				_customerHealthQuestionsCollectionViaCustomerHealthInfo = (EntityCollection<CustomerHealthQuestionsEntity>)info.GetValue("_customerHealthQuestionsCollectionViaCustomerHealthInfo", typeof(EntityCollection<CustomerHealthQuestionsEntity>));
				_customerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician = (EntityCollection<CustomerPrimaryCarePhysicianEntity>)info.GetValue("_customerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician", typeof(EntityCollection<CustomerPrimaryCarePhysicianEntity>));
				_customerProfileCollectionViaCustomerHealthInfo = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerHealthInfo", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaCallQueueCustomer = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCallQueueCustomer", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaDependentDisqualifiedTest = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaDependentDisqualifiedTest", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaClickConversion = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaClickConversion", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaDisqualifiedTest = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaDisqualifiedTest", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaCustomerOrderHistory = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerOrderHistory", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaCustomerHealthInfoArchive = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerHealthInfoArchive", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaEventCustomerQuestionAnswer = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaEventCustomerQuestionAnswer", typeof(EntityCollection<CustomerProfileEntity>));
				_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog = (EntityCollection<CustomerRegistrationNotesEntity>)info.GetValue("_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog", typeof(EntityCollection<CustomerRegistrationNotesEntity>));
				_customEventNotificationCollectionViaEventCustomerCustomNotification = (EntityCollection<CustomEventNotificationEntity>)info.GetValue("_customEventNotificationCollectionViaEventCustomerCustomNotification", typeof(EntityCollection<CustomEventNotificationEntity>));
				_eligibilityCollectionViaEventCustomerEligibility = (EntityCollection<EligibilityEntity>)info.GetValue("_eligibilityCollectionViaEventCustomerEligibility", typeof(EntityCollection<EligibilityEntity>));
				_encounterCollectionViaEventCustomerEncounter = (EntityCollection<EncounterEntity>)info.GetValue("_encounterCollectionViaEventCustomerEncounter", typeof(EntityCollection<EncounterEntity>));
				_eventPackageDetailsCollectionViaCustomerOrderHistory = (EntityCollection<EventPackageDetailsEntity>)info.GetValue("_eventPackageDetailsCollectionViaCustomerOrderHistory", typeof(EntityCollection<EventPackageDetailsEntity>));
				_eventsCollectionViaEventAppointmentChangeLog_ = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventAppointmentChangeLog_", typeof(EntityCollection<EventsEntity>));
				_eventsCollectionViaEventAppointmentChangeLog = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventAppointmentChangeLog", typeof(EntityCollection<EventsEntity>));
				_eventsCollectionViaEventAppointmentCancellationLog = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventAppointmentCancellationLog", typeof(EntityCollection<EventsEntity>));
				_eventsCollectionViaEventCustomerQuestionAnswer = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventCustomerQuestionAnswer", typeof(EntityCollection<EventsEntity>));
				_eventsCollectionViaDependentDisqualifiedTest = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaDependentDisqualifiedTest", typeof(EntityCollection<EventsEntity>));
				_eventsCollectionViaCustomerOrderHistory = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaCustomerOrderHistory", typeof(EntityCollection<EventsEntity>));
				_eventsCollectionViaDisqualifiedTest = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaDisqualifiedTest", typeof(EntityCollection<EventsEntity>));
				_eventsCollectionViaCallQueueCustomer = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaCallQueueCustomer", typeof(EntityCollection<EventsEntity>));
				_eventTestCollectionViaCustomerOrderHistory = (EntityCollection<EventTestEntity>)info.GetValue("_eventTestCollectionViaCustomerOrderHistory", typeof(EntityCollection<EventTestEntity>));
				_exitInterviewQuestionCollectionViaExitInterviewAnswer = (EntityCollection<ExitInterviewQuestionEntity>)info.GetValue("_exitInterviewQuestionCollectionViaExitInterviewAnswer", typeof(EntityCollection<ExitInterviewQuestionEntity>));
				_fileCollectionViaParticipationConsentSignature_ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaParticipationConsentSignature_", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaParticipationConsentSignature = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaParticipationConsentSignature", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaEventCustomerGiftCard = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaEventCustomerGiftCard", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaEventCustomerGiftCard_ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaEventCustomerGiftCard_", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaFluConsentSignature_ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaFluConsentSignature_", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaPhysicianRecordRequestSignature = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaPhysicianRecordRequestSignature", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaChaperoneSignature = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaChaperoneSignature", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaExitInterviewSignature = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaExitInterviewSignature", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaChaperoneSignature_ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaChaperoneSignature_", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaFluConsentSignature = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaFluConsentSignature", typeof(EntityCollection<FileEntity>));
				_fluConsentQuestionCollectionViaFluConsentAnswer = (EntityCollection<FluConsentQuestionEntity>)info.GetValue("_fluConsentQuestionCollectionViaFluConsentAnswer", typeof(EntityCollection<FluConsentQuestionEntity>));
				_icdCodesCollectionViaEventCustomerIcdCodes = (EntityCollection<IcdCodesEntity>)info.GetValue("_icdCodesCollectionViaEventCustomerIcdCodes", typeof(EntityCollection<IcdCodesEntity>));
				_languageCollectionViaCallQueueCustomer = (EntityCollection<LanguageEntity>)info.GetValue("_languageCollectionViaCallQueueCustomer", typeof(EntityCollection<LanguageEntity>));
				_lookupCollectionViaCustomerOrderHistory = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerOrderHistory", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCallQueueCustomer = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCallQueueCustomer", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEventAppointmentChangeLog = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventAppointmentChangeLog", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCheckListAnswer = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCheckListAnswer", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaPcpDisposition = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaPcpDisposition", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEventAppointmentCancellationLog = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventAppointmentCancellationLog", typeof(EntityCollection<LookupEntity>));
				_medicareQuestionCollectionViaCustomerMedicareQuestionAnswer = (EntityCollection<MedicareQuestionEntity>)info.GetValue("_medicareQuestionCollectionViaCustomerMedicareQuestionAnswer", typeof(EntityCollection<MedicareQuestionEntity>));
				_ndcCollectionViaEventCustomerCurrentMedication = (EntityCollection<NdcEntity>)info.GetValue("_ndcCollectionViaEventCustomerCurrentMedication", typeof(EntityCollection<NdcEntity>));
				_notesDetailsCollectionViaCallQueueCustomer = (EntityCollection<NotesDetailsEntity>)info.GetValue("_notesDetailsCollectionViaCallQueueCustomer", typeof(EntityCollection<NotesDetailsEntity>));
				_notificationCollectionViaEventCustomerNotification = (EntityCollection<NotificationEntity>)info.GetValue("_notificationCollectionViaEventCustomerNotification", typeof(EntityCollection<NotificationEntity>));
				_notificationTypeCollectionViaEventCustomerTestNotPerformedNotification = (EntityCollection<NotificationTypeEntity>)info.GetValue("_notificationTypeCollectionViaEventCustomerTestNotPerformedNotification", typeof(EntityCollection<NotificationTypeEntity>));
				_notificationTypeCollectionViaEventCustomerNotification = (EntityCollection<NotificationTypeEntity>)info.GetValue("_notificationTypeCollectionViaEventCustomerNotification", typeof(EntityCollection<NotificationTypeEntity>));
				_orderDetailCollectionViaEventCustomerOrderDetail = (EntityCollection<OrderDetailEntity>)info.GetValue("_orderDetailCollectionViaEventCustomerOrderDetail", typeof(EntityCollection<OrderDetailEntity>));
				_organizationRoleUserCollectionViaExitInterviewAnswer_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaExitInterviewAnswer_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaParticipationConsentSignature = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaParticipationConsentSignature", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaFluConsentSignature = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaFluConsentSignature", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaPcpDisposition_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaPcpDisposition_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaPcpDisposition = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaPcpDisposition", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventCustomerRetest = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventCustomerRetest", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaExitInterviewAnswer = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaExitInterviewAnswer", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaExitInterviewSignature = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaExitInterviewSignature", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaFluConsentAnswer_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaFluConsentAnswer_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventCustomerQuestionAnswer = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventCustomerQuestionAnswer", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventCustomerQuestionAnswer_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventCustomerQuestionAnswer_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaFluConsentAnswer = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaFluConsentAnswer", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaChaperoneSignature = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaChaperoneSignature", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaSurveyAnswer = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaSurveyAnswer", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaDisqualifiedTest_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaDisqualifiedTest_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventAppointmentChangeLog = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventAppointmentChangeLog", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaChaperoneAnswer_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaChaperoneAnswer_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventAppointmentCancellationLog = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventAppointmentCancellationLog", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCheckListAnswer_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCheckListAnswer_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomerHealthInfo = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerHealthInfo", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomerHealthInfoArchive = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerHealthInfoArchive", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaDisqualifiedTest = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaDisqualifiedTest", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCheckListAnswer = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCheckListAnswer", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaSurveyAnswer_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaSurveyAnswer_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaChaperoneAnswer = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaChaperoneAnswer", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallQueueCustomer__ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueCustomer__", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventCustomerGiftCard = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventCustomerGiftCard", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallQueueCustomer = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueCustomer", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallQueueCustomer_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueCustomer_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaPhysicianRecordRequestSignature = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaPhysicianRecordRequestSignature", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_packageCollectionViaEventCustomerPreApprovedPackageTest = (EntityCollection<PackageEntity>)info.GetValue("_packageCollectionViaEventCustomerPreApprovedPackageTest", typeof(EntityCollection<PackageEntity>));
				_physicianProfileCollectionViaPhysicianEvaluation = (EntityCollection<PhysicianProfileEntity>)info.GetValue("_physicianProfileCollectionViaPhysicianEvaluation", typeof(EntityCollection<PhysicianProfileEntity>));
				_physicianProfileCollectionViaPhysicianCustomerAssignment_ = (EntityCollection<PhysicianProfileEntity>)info.GetValue("_physicianProfileCollectionViaPhysicianCustomerAssignment_", typeof(EntityCollection<PhysicianProfileEntity>));
				_physicianProfileCollectionViaPhysicianCustomerAssignment = (EntityCollection<PhysicianProfileEntity>)info.GetValue("_physicianProfileCollectionViaPhysicianCustomerAssignment", typeof(EntityCollection<PhysicianProfileEntity>));
				_preQualificationQuestionCollectionViaEventCustomerQuestionAnswer = (EntityCollection<PreQualificationQuestionEntity>)info.GetValue("_preQualificationQuestionCollectionViaEventCustomerQuestionAnswer", typeof(EntityCollection<PreQualificationQuestionEntity>));
				_preQualificationQuestionCollectionViaDisqualifiedTest = (EntityCollection<PreQualificationQuestionEntity>)info.GetValue("_preQualificationQuestionCollectionViaDisqualifiedTest", typeof(EntityCollection<PreQualificationQuestionEntity>));
				_prospectCustomerCollectionViaClickConversion = (EntityCollection<ProspectCustomerEntity>)info.GetValue("_prospectCustomerCollectionViaClickConversion", typeof(EntityCollection<ProspectCustomerEntity>));
				_prospectCustomerCollectionViaCallQueueCustomer = (EntityCollection<ProspectCustomerEntity>)info.GetValue("_prospectCustomerCollectionViaCallQueueCustomer", typeof(EntityCollection<ProspectCustomerEntity>));
				_refundRequestCollectionViaEventAppointmentCancellationLog = (EntityCollection<RefundRequestEntity>)info.GetValue("_refundRequestCollectionViaEventAppointmentCancellationLog", typeof(EntityCollection<RefundRequestEntity>));
				_rescheduleCancelDispositionCollectionViaEventAppointmentChangeLog = (EntityCollection<RescheduleCancelDispositionEntity>)info.GetValue("_rescheduleCancelDispositionCollectionViaEventAppointmentChangeLog", typeof(EntityCollection<RescheduleCancelDispositionEntity>));
				_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog = (EntityCollection<RescheduleCancelDispositionEntity>)info.GetValue("_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog", typeof(EntityCollection<RescheduleCancelDispositionEntity>));
				_surveyQuestionCollectionViaSurveyAnswer = (EntityCollection<SurveyQuestionEntity>)info.GetValue("_surveyQuestionCollectionViaSurveyAnswer", typeof(EntityCollection<SurveyQuestionEntity>));
				_testCollectionViaEventCustomerPreApprovedPackageTest = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaEventCustomerPreApprovedPackageTest", typeof(EntityCollection<TestEntity>));
				_testCollectionViaDisqualifiedTest = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaDisqualifiedTest", typeof(EntityCollection<TestEntity>));
				_testCollectionViaDependentDisqualifiedTest = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaDependentDisqualifiedTest", typeof(EntityCollection<TestEntity>));
				_testCollectionViaEventCustomerRetest = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaEventCustomerRetest", typeof(EntityCollection<TestEntity>));
				_testCollectionViaEventCustomerTestNotPerformedNotification = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaEventCustomerTestNotPerformedNotification", typeof(EntityCollection<TestEntity>));
				_testCollectionViaEventCustomerPreApprovedTest = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaEventCustomerPreApprovedTest", typeof(EntityCollection<TestEntity>));
				_testCollectionViaEventCustomerRequiredTest = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaEventCustomerRequiredTest", typeof(EntityCollection<TestEntity>));
				_afaffiliateCampaign = (AfaffiliateCampaignEntity)info.GetValue("_afaffiliateCampaign", typeof(AfaffiliateCampaignEntity));
				if(_afaffiliateCampaign!=null)
				{
					_afaffiliateCampaign.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_campaign = (CampaignEntity)info.GetValue("_campaign", typeof(CampaignEntity));
				if(_campaign!=null)
				{
					_campaign.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_customerProfile = (CustomerProfileEntity)info.GetValue("_customerProfile", typeof(CustomerProfileEntity));
				if(_customerProfile!=null)
				{
					_customerProfile.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_customerProfileHistory = (CustomerProfileHistoryEntity)info.GetValue("_customerProfileHistory", typeof(CustomerProfileHistoryEntity));
				if(_customerProfileHistory!=null)
				{
					_customerProfileHistory.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_customerRegistrationNotes = (CustomerRegistrationNotesEntity)info.GetValue("_customerRegistrationNotes", typeof(CustomerRegistrationNotesEntity));
				if(_customerRegistrationNotes!=null)
				{
					_customerRegistrationNotes.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_eventAppointment = (EventAppointmentEntity)info.GetValue("_eventAppointment", typeof(EventAppointmentEntity));
				if(_eventAppointment!=null)
				{
					_eventAppointment.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_events = (EventsEntity)info.GetValue("_events", typeof(EventsEntity));
				if(_events!=null)
				{
					_events.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gcNotGivenReason = (GcNotGivenReasonEntity)info.GetValue("_gcNotGivenReason", typeof(GcNotGivenReasonEntity));
				if(_gcNotGivenReason!=null)
				{
					_gcNotGivenReason.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_hospitalFacility = (HospitalFacilityEntity)info.GetValue("_hospitalFacility", typeof(HospitalFacilityEntity));
				if(_hospitalFacility!=null)
				{
					_hospitalFacility.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup_ = (LookupEntity)info.GetValue("_lookup_", typeof(LookupEntity));
				if(_lookup_!=null)
				{
					_lookup_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser_ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser_", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser_!=null)
				{
					_organizationRoleUser_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser!=null)
				{
					_organizationRoleUser.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_customerSkipReview = (CustomerSkipReviewEntity)info.GetValue("_customerSkipReview", typeof(CustomerSkipReviewEntity));
				if(_customerSkipReview!=null)
				{
					_customerSkipReview.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_eventCustomerBarrier = (EventCustomerBarrierEntity)info.GetValue("_eventCustomerBarrier", typeof(EventCustomerBarrierEntity));
				if(_eventCustomerBarrier!=null)
				{
					_eventCustomerBarrier.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_eventCustomerBasicBioMetric = (EventCustomerBasicBioMetricEntity)info.GetValue("_eventCustomerBasicBioMetric", typeof(EventCustomerBasicBioMetricEntity));
				if(_eventCustomerBasicBioMetric!=null)
				{
					_eventCustomerBasicBioMetric.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_eventCustomerEvaluationLock = (EventCustomerEvaluationLockEntity)info.GetValue("_eventCustomerEvaluationLock", typeof(EventCustomerEvaluationLockEntity));
				if(_eventCustomerEvaluationLock!=null)
				{
					_eventCustomerEvaluationLock.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_eventCustomerResult = (EventCustomerResultEntity)info.GetValue("_eventCustomerResult", typeof(EventCustomerResultEntity));
				if(_eventCustomerResult!=null)
				{
					_eventCustomerResult.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_pcpAppointment_ = (PcpAppointmentEntity)info.GetValue("_pcpAppointment_", typeof(PcpAppointmentEntity));
				if(_pcpAppointment_!=null)
				{
					_pcpAppointment_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_screeningAuthorization = (ScreeningAuthorizationEntity)info.GetValue("_screeningAuthorization", typeof(ScreeningAuthorizationEntity));
				if(_screeningAuthorization!=null)
				{
					_screeningAuthorization.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((EventCustomersFieldIndex)fieldIndex)
			{
				case EventCustomersFieldIndex.EventId:
					DesetupSyncEvents(true, false);
					break;
				case EventCustomersFieldIndex.CustomerId:
					DesetupSyncCustomerProfile(true, false);
					break;
				case EventCustomersFieldIndex.AppointmentId:
					DesetupSyncEventAppointment(true, false);
					break;
				case EventCustomersFieldIndex.AffiliateCampaignId:
					DesetupSyncAfaffiliateCampaign(true, false);
					break;
				case EventCustomersFieldIndex.CreatedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case EventCustomersFieldIndex.HospitalFacilityId:
					DesetupSyncHospitalFacility(true, false);
					break;
				case EventCustomersFieldIndex.CampaignId:
					DesetupSyncCampaign(true, false);
					break;
				case EventCustomersFieldIndex.LeftWithoutScreeningReasonId:
					DesetupSyncLookup(true, false);
					break;
				case EventCustomersFieldIndex.LeftWithoutScreeningNotesId:
					DesetupSyncCustomerRegistrationNotes(true, false);
					break;
				case EventCustomersFieldIndex.CustomerProfileHistoryId:
					DesetupSyncCustomerProfileHistory(true, false);
					break;
				case EventCustomersFieldIndex.ConfirmedBy:
					DesetupSyncOrganizationRoleUser_(true, false);
					break;
				case EventCustomersFieldIndex.PreferredContactType:
					DesetupSyncLookup_(true, false);
					break;
				case EventCustomersFieldIndex.GcNotGivenReasonId:
					DesetupSyncGcNotGivenReason(true, false);
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}
				
		/// <summary>Gets the inheritance info provider instance of the project this entity instance is located in. </summary>
		/// <returns>ready to use inheritance info provider instance.</returns>
		protected override IInheritanceInfoProvider GetInheritanceInfoProvider()
		{
			return InheritanceInfoProviderSingleton.GetInstance();
		}
		
		/// <summary> Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.</summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntityProperty(string propertyName, IEntity2 entity)
		{
			switch(propertyName)
			{
				case "AfaffiliateCampaign":
					this.AfaffiliateCampaign = (AfaffiliateCampaignEntity)entity;
					break;
				case "Campaign":
					this.Campaign = (CampaignEntity)entity;
					break;
				case "CustomerProfile":
					this.CustomerProfile = (CustomerProfileEntity)entity;
					break;
				case "CustomerProfileHistory":
					this.CustomerProfileHistory = (CustomerProfileHistoryEntity)entity;
					break;
				case "CustomerRegistrationNotes":
					this.CustomerRegistrationNotes = (CustomerRegistrationNotesEntity)entity;
					break;
				case "EventAppointment":
					this.EventAppointment = (EventAppointmentEntity)entity;
					break;
				case "Events":
					this.Events = (EventsEntity)entity;
					break;
				case "GcNotGivenReason":
					this.GcNotGivenReason = (GcNotGivenReasonEntity)entity;
					break;
				case "HospitalFacility":
					this.HospitalFacility = (HospitalFacilityEntity)entity;
					break;
				case "Lookup_":
					this.Lookup_ = (LookupEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "OrganizationRoleUser_":
					this.OrganizationRoleUser_ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "CallQueueCustomer":
					this.CallQueueCustomer.Add((CallQueueCustomerEntity)entity);
					break;
				case "ChaperoneAnswer":
					this.ChaperoneAnswer.Add((ChaperoneAnswerEntity)entity);
					break;
				case "ChaperoneSignature":
					this.ChaperoneSignature.Add((ChaperoneSignatureEntity)entity);
					break;
				case "CheckListAnswer":
					this.CheckListAnswer.Add((CheckListAnswerEntity)entity);
					break;
				case "ClickConversion":
					this.ClickConversion.Add((ClickConversionEntity)entity);
					break;
				case "CustomerHealthInfo":
					this.CustomerHealthInfo.Add((CustomerHealthInfoEntity)entity);
					break;
				case "CustomerHealthInfoArchive":
					this.CustomerHealthInfoArchive.Add((CustomerHealthInfoArchiveEntity)entity);
					break;
				case "CustomerMedicareQuestionAnswer":
					this.CustomerMedicareQuestionAnswer.Add((CustomerMedicareQuestionAnswerEntity)entity);
					break;
				case "CustomerOrderHistory":
					this.CustomerOrderHistory.Add((CustomerOrderHistoryEntity)entity);
					break;
				case "DependentDisqualifiedTest":
					this.DependentDisqualifiedTest.Add((DependentDisqualifiedTestEntity)entity);
					break;
				case "DisqualifiedTest":
					this.DisqualifiedTest.Add((DisqualifiedTestEntity)entity);
					break;
				case "EventAppointmentCancellationLog":
					this.EventAppointmentCancellationLog.Add((EventAppointmentCancellationLogEntity)entity);
					break;
				case "EventAppointmentChangeLog":
					this.EventAppointmentChangeLog.Add((EventAppointmentChangeLogEntity)entity);
					break;
				case "EventCustomerCriticalQuestion":
					this.EventCustomerCriticalQuestion.Add((EventCustomerCriticalQuestionEntity)entity);
					break;
				case "EventCustomerCurrentMedication":
					this.EventCustomerCurrentMedication.Add((EventCustomerCurrentMedicationEntity)entity);
					break;
				case "EventCustomerCustomNotification":
					this.EventCustomerCustomNotification.Add((EventCustomerCustomNotificationEntity)entity);
					break;
				case "EventCustomerDiagnosis":
					this.EventCustomerDiagnosis.Add((EventCustomerDiagnosisEntity)entity);
					break;
				case "EventCustomerEligibility":
					this.EventCustomerEligibility.Add((EventCustomerEligibilityEntity)entity);
					break;
				case "EventCustomerEncounter":
					this.EventCustomerEncounter.Add((EventCustomerEncounterEntity)entity);
					break;
				case "EventCustomerGiftCard":
					this.EventCustomerGiftCard.Add((EventCustomerGiftCardEntity)entity);
					break;
				case "EventCustomerIcdCodes":
					this.EventCustomerIcdCodes.Add((EventCustomerIcdCodesEntity)entity);
					break;
				case "EventCustomerNotification":
					this.EventCustomerNotification.Add((EventCustomerNotificationEntity)entity);
					break;
				case "EventCustomerOrderDetail":
					this.EventCustomerOrderDetail.Add((EventCustomerOrderDetailEntity)entity);
					break;
				case "EventCustomerPreApprovedPackageTest":
					this.EventCustomerPreApprovedPackageTest.Add((EventCustomerPreApprovedPackageTestEntity)entity);
					break;
				case "EventCustomerPreApprovedTest":
					this.EventCustomerPreApprovedTest.Add((EventCustomerPreApprovedTestEntity)entity);
					break;
				case "EventCustomerPrimaryCarePhysician":
					this.EventCustomerPrimaryCarePhysician.Add((EventCustomerPrimaryCarePhysicianEntity)entity);
					break;
				case "EventCustomerQuestionAnswer":
					this.EventCustomerQuestionAnswer.Add((EventCustomerQuestionAnswerEntity)entity);
					break;
				case "EventCustomerRequiredTest":
					this.EventCustomerRequiredTest.Add((EventCustomerRequiredTestEntity)entity);
					break;
				case "EventCustomerRetest":
					this.EventCustomerRetest.Add((EventCustomerRetestEntity)entity);
					break;
				case "EventCustomerTestNotPerformedNotification":
					this.EventCustomerTestNotPerformedNotification.Add((EventCustomerTestNotPerformedNotificationEntity)entity);
					break;
				case "ExitInterviewAnswer":
					this.ExitInterviewAnswer.Add((ExitInterviewAnswerEntity)entity);
					break;
				case "ExitInterviewSignature":
					this.ExitInterviewSignature.Add((ExitInterviewSignatureEntity)entity);
					break;
				case "FluConsentAnswer":
					this.FluConsentAnswer.Add((FluConsentAnswerEntity)entity);
					break;
				case "FluConsentSignature":
					this.FluConsentSignature.Add((FluConsentSignatureEntity)entity);
					break;
				case "ParticipationConsentSignature":
					this.ParticipationConsentSignature.Add((ParticipationConsentSignatureEntity)entity);
					break;
				case "PcpDisposition":
					this.PcpDisposition.Add((PcpDispositionEntity)entity);
					break;
				case "PhysicianCustomerAssignment":
					this.PhysicianCustomerAssignment.Add((PhysicianCustomerAssignmentEntity)entity);
					break;
				case "PhysicianEvaluation":
					this.PhysicianEvaluation.Add((PhysicianEvaluationEntity)entity);
					break;
				case "PhysicianRecordRequestSignature":
					this.PhysicianRecordRequestSignature.Add((PhysicianRecordRequestSignatureEntity)entity);
					break;
				case "SurveyAnswer":
					this.SurveyAnswer.Add((SurveyAnswerEntity)entity);
					break;
				case "AccountCollectionViaCallQueueCustomer":
					this.AccountCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.AccountCollectionViaCallQueueCustomer.Add((AccountEntity)entity);
					this.AccountCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "ActivityTypeCollectionViaCallQueueCustomer":
					this.ActivityTypeCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.ActivityTypeCollectionViaCallQueueCustomer.Add((ActivityTypeEntity)entity);
					this.ActivityTypeCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "CallQueueCollectionViaCallQueueCustomer":
					this.CallQueueCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.CallQueueCollectionViaCallQueueCustomer.Add((CallQueueEntity)entity);
					this.CallQueueCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "CallQueueCriteriaCollectionViaCallQueueCustomer":
					this.CallQueueCriteriaCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.CallQueueCriteriaCollectionViaCallQueueCustomer.Add((CallQueueCriteriaEntity)entity);
					this.CallQueueCriteriaCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "CampaignCollectionViaCallQueueCustomer":
					this.CampaignCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.CampaignCollectionViaCallQueueCustomer.Add((CampaignEntity)entity);
					this.CampaignCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "ChaperoneQuestionCollectionViaChaperoneAnswer":
					this.ChaperoneQuestionCollectionViaChaperoneAnswer.IsReadOnly = false;
					this.ChaperoneQuestionCollectionViaChaperoneAnswer.Add((ChaperoneQuestionEntity)entity);
					this.ChaperoneQuestionCollectionViaChaperoneAnswer.IsReadOnly = true;
					break;
				case "ChargeCardCollectionViaEventCustomerEligibility":
					this.ChargeCardCollectionViaEventCustomerEligibility.IsReadOnly = false;
					this.ChargeCardCollectionViaEventCustomerEligibility.Add((ChargeCardEntity)entity);
					this.ChargeCardCollectionViaEventCustomerEligibility.IsReadOnly = true;
					break;
				case "CheckListQuestionCollectionViaExitInterviewSignature":
					this.CheckListQuestionCollectionViaExitInterviewSignature.IsReadOnly = false;
					this.CheckListQuestionCollectionViaExitInterviewSignature.Add((CheckListQuestionEntity)entity);
					this.CheckListQuestionCollectionViaExitInterviewSignature.IsReadOnly = true;
					break;
				case "CheckListQuestionCollectionViaCheckListAnswer":
					this.CheckListQuestionCollectionViaCheckListAnswer.IsReadOnly = false;
					this.CheckListQuestionCollectionViaCheckListAnswer.Add((CheckListQuestionEntity)entity);
					this.CheckListQuestionCollectionViaCheckListAnswer.IsReadOnly = true;
					break;
				case "ClickLogCollectionViaClickConversion":
					this.ClickLogCollectionViaClickConversion.IsReadOnly = false;
					this.ClickLogCollectionViaClickConversion.Add((ClickLogEntity)entity);
					this.ClickLogCollectionViaClickConversion.IsReadOnly = true;
					break;
				case "CorporateUploadCollectionViaCustomerOrderHistory":
					this.CorporateUploadCollectionViaCustomerOrderHistory.IsReadOnly = false;
					this.CorporateUploadCollectionViaCustomerOrderHistory.Add((CorporateUploadEntity)entity);
					this.CorporateUploadCollectionViaCustomerOrderHistory.IsReadOnly = true;
					break;
				case "CriticalQuestionCollectionViaEventCustomerCriticalQuestion":
					this.CriticalQuestionCollectionViaEventCustomerCriticalQuestion.IsReadOnly = false;
					this.CriticalQuestionCollectionViaEventCustomerCriticalQuestion.Add((CriticalQuestionEntity)entity);
					this.CriticalQuestionCollectionViaEventCustomerCriticalQuestion.IsReadOnly = true;
					break;
				case "CustomerHealthQuestionsCollectionViaCustomerHealthInfoArchive":
					this.CustomerHealthQuestionsCollectionViaCustomerHealthInfoArchive.IsReadOnly = false;
					this.CustomerHealthQuestionsCollectionViaCustomerHealthInfoArchive.Add((CustomerHealthQuestionsEntity)entity);
					this.CustomerHealthQuestionsCollectionViaCustomerHealthInfoArchive.IsReadOnly = true;
					break;
				case "CustomerHealthQuestionsCollectionViaCustomerHealthInfo":
					this.CustomerHealthQuestionsCollectionViaCustomerHealthInfo.IsReadOnly = false;
					this.CustomerHealthQuestionsCollectionViaCustomerHealthInfo.Add((CustomerHealthQuestionsEntity)entity);
					this.CustomerHealthQuestionsCollectionViaCustomerHealthInfo.IsReadOnly = true;
					break;
				case "CustomerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician":
					this.CustomerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician.IsReadOnly = false;
					this.CustomerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician.Add((CustomerPrimaryCarePhysicianEntity)entity);
					this.CustomerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCustomerHealthInfo":
					this.CustomerProfileCollectionViaCustomerHealthInfo.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerHealthInfo.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerHealthInfo.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCallQueueCustomer":
					this.CustomerProfileCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.CustomerProfileCollectionViaCallQueueCustomer.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaDependentDisqualifiedTest":
					this.CustomerProfileCollectionViaDependentDisqualifiedTest.IsReadOnly = false;
					this.CustomerProfileCollectionViaDependentDisqualifiedTest.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaDependentDisqualifiedTest.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaClickConversion":
					this.CustomerProfileCollectionViaClickConversion.IsReadOnly = false;
					this.CustomerProfileCollectionViaClickConversion.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaClickConversion.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaDisqualifiedTest":
					this.CustomerProfileCollectionViaDisqualifiedTest.IsReadOnly = false;
					this.CustomerProfileCollectionViaDisqualifiedTest.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaDisqualifiedTest.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCustomerOrderHistory":
					this.CustomerProfileCollectionViaCustomerOrderHistory.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerOrderHistory.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerOrderHistory.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCustomerHealthInfoArchive":
					this.CustomerProfileCollectionViaCustomerHealthInfoArchive.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerHealthInfoArchive.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerHealthInfoArchive.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaEventCustomerQuestionAnswer":
					this.CustomerProfileCollectionViaEventCustomerQuestionAnswer.IsReadOnly = false;
					this.CustomerProfileCollectionViaEventCustomerQuestionAnswer.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaEventCustomerQuestionAnswer.IsReadOnly = true;
					break;
				case "CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog":
					this.CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog.IsReadOnly = false;
					this.CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog.Add((CustomerRegistrationNotesEntity)entity);
					this.CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog.IsReadOnly = true;
					break;
				case "CustomEventNotificationCollectionViaEventCustomerCustomNotification":
					this.CustomEventNotificationCollectionViaEventCustomerCustomNotification.IsReadOnly = false;
					this.CustomEventNotificationCollectionViaEventCustomerCustomNotification.Add((CustomEventNotificationEntity)entity);
					this.CustomEventNotificationCollectionViaEventCustomerCustomNotification.IsReadOnly = true;
					break;
				case "EligibilityCollectionViaEventCustomerEligibility":
					this.EligibilityCollectionViaEventCustomerEligibility.IsReadOnly = false;
					this.EligibilityCollectionViaEventCustomerEligibility.Add((EligibilityEntity)entity);
					this.EligibilityCollectionViaEventCustomerEligibility.IsReadOnly = true;
					break;
				case "EncounterCollectionViaEventCustomerEncounter":
					this.EncounterCollectionViaEventCustomerEncounter.IsReadOnly = false;
					this.EncounterCollectionViaEventCustomerEncounter.Add((EncounterEntity)entity);
					this.EncounterCollectionViaEventCustomerEncounter.IsReadOnly = true;
					break;
				case "EventPackageDetailsCollectionViaCustomerOrderHistory":
					this.EventPackageDetailsCollectionViaCustomerOrderHistory.IsReadOnly = false;
					this.EventPackageDetailsCollectionViaCustomerOrderHistory.Add((EventPackageDetailsEntity)entity);
					this.EventPackageDetailsCollectionViaCustomerOrderHistory.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventAppointmentChangeLog_":
					this.EventsCollectionViaEventAppointmentChangeLog_.IsReadOnly = false;
					this.EventsCollectionViaEventAppointmentChangeLog_.Add((EventsEntity)entity);
					this.EventsCollectionViaEventAppointmentChangeLog_.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventAppointmentChangeLog":
					this.EventsCollectionViaEventAppointmentChangeLog.IsReadOnly = false;
					this.EventsCollectionViaEventAppointmentChangeLog.Add((EventsEntity)entity);
					this.EventsCollectionViaEventAppointmentChangeLog.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventAppointmentCancellationLog":
					this.EventsCollectionViaEventAppointmentCancellationLog.IsReadOnly = false;
					this.EventsCollectionViaEventAppointmentCancellationLog.Add((EventsEntity)entity);
					this.EventsCollectionViaEventAppointmentCancellationLog.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventCustomerQuestionAnswer":
					this.EventsCollectionViaEventCustomerQuestionAnswer.IsReadOnly = false;
					this.EventsCollectionViaEventCustomerQuestionAnswer.Add((EventsEntity)entity);
					this.EventsCollectionViaEventCustomerQuestionAnswer.IsReadOnly = true;
					break;
				case "EventsCollectionViaDependentDisqualifiedTest":
					this.EventsCollectionViaDependentDisqualifiedTest.IsReadOnly = false;
					this.EventsCollectionViaDependentDisqualifiedTest.Add((EventsEntity)entity);
					this.EventsCollectionViaDependentDisqualifiedTest.IsReadOnly = true;
					break;
				case "EventsCollectionViaCustomerOrderHistory":
					this.EventsCollectionViaCustomerOrderHistory.IsReadOnly = false;
					this.EventsCollectionViaCustomerOrderHistory.Add((EventsEntity)entity);
					this.EventsCollectionViaCustomerOrderHistory.IsReadOnly = true;
					break;
				case "EventsCollectionViaDisqualifiedTest":
					this.EventsCollectionViaDisqualifiedTest.IsReadOnly = false;
					this.EventsCollectionViaDisqualifiedTest.Add((EventsEntity)entity);
					this.EventsCollectionViaDisqualifiedTest.IsReadOnly = true;
					break;
				case "EventsCollectionViaCallQueueCustomer":
					this.EventsCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.EventsCollectionViaCallQueueCustomer.Add((EventsEntity)entity);
					this.EventsCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "EventTestCollectionViaCustomerOrderHistory":
					this.EventTestCollectionViaCustomerOrderHistory.IsReadOnly = false;
					this.EventTestCollectionViaCustomerOrderHistory.Add((EventTestEntity)entity);
					this.EventTestCollectionViaCustomerOrderHistory.IsReadOnly = true;
					break;
				case "ExitInterviewQuestionCollectionViaExitInterviewAnswer":
					this.ExitInterviewQuestionCollectionViaExitInterviewAnswer.IsReadOnly = false;
					this.ExitInterviewQuestionCollectionViaExitInterviewAnswer.Add((ExitInterviewQuestionEntity)entity);
					this.ExitInterviewQuestionCollectionViaExitInterviewAnswer.IsReadOnly = true;
					break;
				case "FileCollectionViaParticipationConsentSignature_":
					this.FileCollectionViaParticipationConsentSignature_.IsReadOnly = false;
					this.FileCollectionViaParticipationConsentSignature_.Add((FileEntity)entity);
					this.FileCollectionViaParticipationConsentSignature_.IsReadOnly = true;
					break;
				case "FileCollectionViaParticipationConsentSignature":
					this.FileCollectionViaParticipationConsentSignature.IsReadOnly = false;
					this.FileCollectionViaParticipationConsentSignature.Add((FileEntity)entity);
					this.FileCollectionViaParticipationConsentSignature.IsReadOnly = true;
					break;
				case "FileCollectionViaEventCustomerGiftCard":
					this.FileCollectionViaEventCustomerGiftCard.IsReadOnly = false;
					this.FileCollectionViaEventCustomerGiftCard.Add((FileEntity)entity);
					this.FileCollectionViaEventCustomerGiftCard.IsReadOnly = true;
					break;
				case "FileCollectionViaEventCustomerGiftCard_":
					this.FileCollectionViaEventCustomerGiftCard_.IsReadOnly = false;
					this.FileCollectionViaEventCustomerGiftCard_.Add((FileEntity)entity);
					this.FileCollectionViaEventCustomerGiftCard_.IsReadOnly = true;
					break;
				case "FileCollectionViaFluConsentSignature_":
					this.FileCollectionViaFluConsentSignature_.IsReadOnly = false;
					this.FileCollectionViaFluConsentSignature_.Add((FileEntity)entity);
					this.FileCollectionViaFluConsentSignature_.IsReadOnly = true;
					break;
				case "FileCollectionViaPhysicianRecordRequestSignature":
					this.FileCollectionViaPhysicianRecordRequestSignature.IsReadOnly = false;
					this.FileCollectionViaPhysicianRecordRequestSignature.Add((FileEntity)entity);
					this.FileCollectionViaPhysicianRecordRequestSignature.IsReadOnly = true;
					break;
				case "FileCollectionViaChaperoneSignature":
					this.FileCollectionViaChaperoneSignature.IsReadOnly = false;
					this.FileCollectionViaChaperoneSignature.Add((FileEntity)entity);
					this.FileCollectionViaChaperoneSignature.IsReadOnly = true;
					break;
				case "FileCollectionViaExitInterviewSignature":
					this.FileCollectionViaExitInterviewSignature.IsReadOnly = false;
					this.FileCollectionViaExitInterviewSignature.Add((FileEntity)entity);
					this.FileCollectionViaExitInterviewSignature.IsReadOnly = true;
					break;
				case "FileCollectionViaChaperoneSignature_":
					this.FileCollectionViaChaperoneSignature_.IsReadOnly = false;
					this.FileCollectionViaChaperoneSignature_.Add((FileEntity)entity);
					this.FileCollectionViaChaperoneSignature_.IsReadOnly = true;
					break;
				case "FileCollectionViaFluConsentSignature":
					this.FileCollectionViaFluConsentSignature.IsReadOnly = false;
					this.FileCollectionViaFluConsentSignature.Add((FileEntity)entity);
					this.FileCollectionViaFluConsentSignature.IsReadOnly = true;
					break;
				case "FluConsentQuestionCollectionViaFluConsentAnswer":
					this.FluConsentQuestionCollectionViaFluConsentAnswer.IsReadOnly = false;
					this.FluConsentQuestionCollectionViaFluConsentAnswer.Add((FluConsentQuestionEntity)entity);
					this.FluConsentQuestionCollectionViaFluConsentAnswer.IsReadOnly = true;
					break;
				case "IcdCodesCollectionViaEventCustomerIcdCodes":
					this.IcdCodesCollectionViaEventCustomerIcdCodes.IsReadOnly = false;
					this.IcdCodesCollectionViaEventCustomerIcdCodes.Add((IcdCodesEntity)entity);
					this.IcdCodesCollectionViaEventCustomerIcdCodes.IsReadOnly = true;
					break;
				case "LanguageCollectionViaCallQueueCustomer":
					this.LanguageCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.LanguageCollectionViaCallQueueCustomer.Add((LanguageEntity)entity);
					this.LanguageCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerOrderHistory":
					this.LookupCollectionViaCustomerOrderHistory.IsReadOnly = false;
					this.LookupCollectionViaCustomerOrderHistory.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerOrderHistory.IsReadOnly = true;
					break;
				case "LookupCollectionViaCallQueueCustomer":
					this.LookupCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.LookupCollectionViaCallQueueCustomer.Add((LookupEntity)entity);
					this.LookupCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "LookupCollectionViaEventAppointmentChangeLog":
					this.LookupCollectionViaEventAppointmentChangeLog.IsReadOnly = false;
					this.LookupCollectionViaEventAppointmentChangeLog.Add((LookupEntity)entity);
					this.LookupCollectionViaEventAppointmentChangeLog.IsReadOnly = true;
					break;
				case "LookupCollectionViaCheckListAnswer":
					this.LookupCollectionViaCheckListAnswer.IsReadOnly = false;
					this.LookupCollectionViaCheckListAnswer.Add((LookupEntity)entity);
					this.LookupCollectionViaCheckListAnswer.IsReadOnly = true;
					break;
				case "LookupCollectionViaPcpDisposition":
					this.LookupCollectionViaPcpDisposition.IsReadOnly = false;
					this.LookupCollectionViaPcpDisposition.Add((LookupEntity)entity);
					this.LookupCollectionViaPcpDisposition.IsReadOnly = true;
					break;
				case "LookupCollectionViaEventAppointmentCancellationLog":
					this.LookupCollectionViaEventAppointmentCancellationLog.IsReadOnly = false;
					this.LookupCollectionViaEventAppointmentCancellationLog.Add((LookupEntity)entity);
					this.LookupCollectionViaEventAppointmentCancellationLog.IsReadOnly = true;
					break;
				case "MedicareQuestionCollectionViaCustomerMedicareQuestionAnswer":
					this.MedicareQuestionCollectionViaCustomerMedicareQuestionAnswer.IsReadOnly = false;
					this.MedicareQuestionCollectionViaCustomerMedicareQuestionAnswer.Add((MedicareQuestionEntity)entity);
					this.MedicareQuestionCollectionViaCustomerMedicareQuestionAnswer.IsReadOnly = true;
					break;
				case "NdcCollectionViaEventCustomerCurrentMedication":
					this.NdcCollectionViaEventCustomerCurrentMedication.IsReadOnly = false;
					this.NdcCollectionViaEventCustomerCurrentMedication.Add((NdcEntity)entity);
					this.NdcCollectionViaEventCustomerCurrentMedication.IsReadOnly = true;
					break;
				case "NotesDetailsCollectionViaCallQueueCustomer":
					this.NotesDetailsCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.NotesDetailsCollectionViaCallQueueCustomer.Add((NotesDetailsEntity)entity);
					this.NotesDetailsCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "NotificationCollectionViaEventCustomerNotification":
					this.NotificationCollectionViaEventCustomerNotification.IsReadOnly = false;
					this.NotificationCollectionViaEventCustomerNotification.Add((NotificationEntity)entity);
					this.NotificationCollectionViaEventCustomerNotification.IsReadOnly = true;
					break;
				case "NotificationTypeCollectionViaEventCustomerTestNotPerformedNotification":
					this.NotificationTypeCollectionViaEventCustomerTestNotPerformedNotification.IsReadOnly = false;
					this.NotificationTypeCollectionViaEventCustomerTestNotPerformedNotification.Add((NotificationTypeEntity)entity);
					this.NotificationTypeCollectionViaEventCustomerTestNotPerformedNotification.IsReadOnly = true;
					break;
				case "NotificationTypeCollectionViaEventCustomerNotification":
					this.NotificationTypeCollectionViaEventCustomerNotification.IsReadOnly = false;
					this.NotificationTypeCollectionViaEventCustomerNotification.Add((NotificationTypeEntity)entity);
					this.NotificationTypeCollectionViaEventCustomerNotification.IsReadOnly = true;
					break;
				case "OrderDetailCollectionViaEventCustomerOrderDetail":
					this.OrderDetailCollectionViaEventCustomerOrderDetail.IsReadOnly = false;
					this.OrderDetailCollectionViaEventCustomerOrderDetail.Add((OrderDetailEntity)entity);
					this.OrderDetailCollectionViaEventCustomerOrderDetail.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaExitInterviewAnswer_":
					this.OrganizationRoleUserCollectionViaExitInterviewAnswer_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaExitInterviewAnswer_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaExitInterviewAnswer_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaParticipationConsentSignature":
					this.OrganizationRoleUserCollectionViaParticipationConsentSignature.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaParticipationConsentSignature.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaParticipationConsentSignature.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaFluConsentSignature":
					this.OrganizationRoleUserCollectionViaFluConsentSignature.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaFluConsentSignature.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaFluConsentSignature.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaPcpDisposition_":
					this.OrganizationRoleUserCollectionViaPcpDisposition_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaPcpDisposition_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaPcpDisposition_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaPcpDisposition":
					this.OrganizationRoleUserCollectionViaPcpDisposition.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaPcpDisposition.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaPcpDisposition.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician":
					this.OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification":
					this.OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventCustomerRetest":
					this.OrganizationRoleUserCollectionViaEventCustomerRetest.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventCustomerRetest.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventCustomerRetest.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaExitInterviewAnswer":
					this.OrganizationRoleUserCollectionViaExitInterviewAnswer.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaExitInterviewAnswer.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaExitInterviewAnswer.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaExitInterviewSignature":
					this.OrganizationRoleUserCollectionViaExitInterviewSignature.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaExitInterviewSignature.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaExitInterviewSignature.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaFluConsentAnswer_":
					this.OrganizationRoleUserCollectionViaFluConsentAnswer_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaFluConsentAnswer_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaFluConsentAnswer_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer":
					this.OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_":
					this.OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaFluConsentAnswer":
					this.OrganizationRoleUserCollectionViaFluConsentAnswer.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaFluConsentAnswer.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaFluConsentAnswer.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaChaperoneSignature":
					this.OrganizationRoleUserCollectionViaChaperoneSignature.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaChaperoneSignature.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaChaperoneSignature.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaSurveyAnswer":
					this.OrganizationRoleUserCollectionViaSurveyAnswer.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaSurveyAnswer.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaSurveyAnswer.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaDisqualifiedTest_":
					this.OrganizationRoleUserCollectionViaDisqualifiedTest_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaDisqualifiedTest_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaDisqualifiedTest_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventAppointmentChangeLog":
					this.OrganizationRoleUserCollectionViaEventAppointmentChangeLog.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventAppointmentChangeLog.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventAppointmentChangeLog.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaChaperoneAnswer_":
					this.OrganizationRoleUserCollectionViaChaperoneAnswer_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaChaperoneAnswer_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaChaperoneAnswer_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventAppointmentCancellationLog":
					this.OrganizationRoleUserCollectionViaEventAppointmentCancellationLog.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventAppointmentCancellationLog.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventAppointmentCancellationLog.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCheckListAnswer_":
					this.OrganizationRoleUserCollectionViaCheckListAnswer_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCheckListAnswer_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCheckListAnswer_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerHealthInfo":
					this.OrganizationRoleUserCollectionViaCustomerHealthInfo.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerHealthInfo.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerHealthInfo.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerHealthInfoArchive":
					this.OrganizationRoleUserCollectionViaCustomerHealthInfoArchive.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerHealthInfoArchive.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerHealthInfoArchive.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaDisqualifiedTest":
					this.OrganizationRoleUserCollectionViaDisqualifiedTest.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaDisqualifiedTest.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaDisqualifiedTest.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCheckListAnswer":
					this.OrganizationRoleUserCollectionViaCheckListAnswer.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCheckListAnswer.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCheckListAnswer.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaSurveyAnswer_":
					this.OrganizationRoleUserCollectionViaSurveyAnswer_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaSurveyAnswer_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaSurveyAnswer_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaChaperoneAnswer":
					this.OrganizationRoleUserCollectionViaChaperoneAnswer.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaChaperoneAnswer.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaChaperoneAnswer.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer__":
					this.OrganizationRoleUserCollectionViaCallQueueCustomer__.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueCustomer__.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueCustomer__.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventCustomerGiftCard":
					this.OrganizationRoleUserCollectionViaEventCustomerGiftCard.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventCustomerGiftCard.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventCustomerGiftCard.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer":
					this.OrganizationRoleUserCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueCustomer.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer_":
					this.OrganizationRoleUserCollectionViaCallQueueCustomer_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueCustomer_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueCustomer_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaPhysicianRecordRequestSignature":
					this.OrganizationRoleUserCollectionViaPhysicianRecordRequestSignature.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaPhysicianRecordRequestSignature.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaPhysicianRecordRequestSignature.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer":
					this.OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer.IsReadOnly = true;
					break;
				case "PackageCollectionViaEventCustomerPreApprovedPackageTest":
					this.PackageCollectionViaEventCustomerPreApprovedPackageTest.IsReadOnly = false;
					this.PackageCollectionViaEventCustomerPreApprovedPackageTest.Add((PackageEntity)entity);
					this.PackageCollectionViaEventCustomerPreApprovedPackageTest.IsReadOnly = true;
					break;
				case "PhysicianProfileCollectionViaPhysicianEvaluation":
					this.PhysicianProfileCollectionViaPhysicianEvaluation.IsReadOnly = false;
					this.PhysicianProfileCollectionViaPhysicianEvaluation.Add((PhysicianProfileEntity)entity);
					this.PhysicianProfileCollectionViaPhysicianEvaluation.IsReadOnly = true;
					break;
				case "PhysicianProfileCollectionViaPhysicianCustomerAssignment_":
					this.PhysicianProfileCollectionViaPhysicianCustomerAssignment_.IsReadOnly = false;
					this.PhysicianProfileCollectionViaPhysicianCustomerAssignment_.Add((PhysicianProfileEntity)entity);
					this.PhysicianProfileCollectionViaPhysicianCustomerAssignment_.IsReadOnly = true;
					break;
				case "PhysicianProfileCollectionViaPhysicianCustomerAssignment":
					this.PhysicianProfileCollectionViaPhysicianCustomerAssignment.IsReadOnly = false;
					this.PhysicianProfileCollectionViaPhysicianCustomerAssignment.Add((PhysicianProfileEntity)entity);
					this.PhysicianProfileCollectionViaPhysicianCustomerAssignment.IsReadOnly = true;
					break;
				case "PreQualificationQuestionCollectionViaEventCustomerQuestionAnswer":
					this.PreQualificationQuestionCollectionViaEventCustomerQuestionAnswer.IsReadOnly = false;
					this.PreQualificationQuestionCollectionViaEventCustomerQuestionAnswer.Add((PreQualificationQuestionEntity)entity);
					this.PreQualificationQuestionCollectionViaEventCustomerQuestionAnswer.IsReadOnly = true;
					break;
				case "PreQualificationQuestionCollectionViaDisqualifiedTest":
					this.PreQualificationQuestionCollectionViaDisqualifiedTest.IsReadOnly = false;
					this.PreQualificationQuestionCollectionViaDisqualifiedTest.Add((PreQualificationQuestionEntity)entity);
					this.PreQualificationQuestionCollectionViaDisqualifiedTest.IsReadOnly = true;
					break;
				case "ProspectCustomerCollectionViaClickConversion":
					this.ProspectCustomerCollectionViaClickConversion.IsReadOnly = false;
					this.ProspectCustomerCollectionViaClickConversion.Add((ProspectCustomerEntity)entity);
					this.ProspectCustomerCollectionViaClickConversion.IsReadOnly = true;
					break;
				case "ProspectCustomerCollectionViaCallQueueCustomer":
					this.ProspectCustomerCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.ProspectCustomerCollectionViaCallQueueCustomer.Add((ProspectCustomerEntity)entity);
					this.ProspectCustomerCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "RefundRequestCollectionViaEventAppointmentCancellationLog":
					this.RefundRequestCollectionViaEventAppointmentCancellationLog.IsReadOnly = false;
					this.RefundRequestCollectionViaEventAppointmentCancellationLog.Add((RefundRequestEntity)entity);
					this.RefundRequestCollectionViaEventAppointmentCancellationLog.IsReadOnly = true;
					break;
				case "RescheduleCancelDispositionCollectionViaEventAppointmentChangeLog":
					this.RescheduleCancelDispositionCollectionViaEventAppointmentChangeLog.IsReadOnly = false;
					this.RescheduleCancelDispositionCollectionViaEventAppointmentChangeLog.Add((RescheduleCancelDispositionEntity)entity);
					this.RescheduleCancelDispositionCollectionViaEventAppointmentChangeLog.IsReadOnly = true;
					break;
				case "RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog":
					this.RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog.IsReadOnly = false;
					this.RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog.Add((RescheduleCancelDispositionEntity)entity);
					this.RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog.IsReadOnly = true;
					break;
				case "SurveyQuestionCollectionViaSurveyAnswer":
					this.SurveyQuestionCollectionViaSurveyAnswer.IsReadOnly = false;
					this.SurveyQuestionCollectionViaSurveyAnswer.Add((SurveyQuestionEntity)entity);
					this.SurveyQuestionCollectionViaSurveyAnswer.IsReadOnly = true;
					break;
				case "TestCollectionViaEventCustomerPreApprovedPackageTest":
					this.TestCollectionViaEventCustomerPreApprovedPackageTest.IsReadOnly = false;
					this.TestCollectionViaEventCustomerPreApprovedPackageTest.Add((TestEntity)entity);
					this.TestCollectionViaEventCustomerPreApprovedPackageTest.IsReadOnly = true;
					break;
				case "TestCollectionViaDisqualifiedTest":
					this.TestCollectionViaDisqualifiedTest.IsReadOnly = false;
					this.TestCollectionViaDisqualifiedTest.Add((TestEntity)entity);
					this.TestCollectionViaDisqualifiedTest.IsReadOnly = true;
					break;
				case "TestCollectionViaDependentDisqualifiedTest":
					this.TestCollectionViaDependentDisqualifiedTest.IsReadOnly = false;
					this.TestCollectionViaDependentDisqualifiedTest.Add((TestEntity)entity);
					this.TestCollectionViaDependentDisqualifiedTest.IsReadOnly = true;
					break;
				case "TestCollectionViaEventCustomerRetest":
					this.TestCollectionViaEventCustomerRetest.IsReadOnly = false;
					this.TestCollectionViaEventCustomerRetest.Add((TestEntity)entity);
					this.TestCollectionViaEventCustomerRetest.IsReadOnly = true;
					break;
				case "TestCollectionViaEventCustomerTestNotPerformedNotification":
					this.TestCollectionViaEventCustomerTestNotPerformedNotification.IsReadOnly = false;
					this.TestCollectionViaEventCustomerTestNotPerformedNotification.Add((TestEntity)entity);
					this.TestCollectionViaEventCustomerTestNotPerformedNotification.IsReadOnly = true;
					break;
				case "TestCollectionViaEventCustomerPreApprovedTest":
					this.TestCollectionViaEventCustomerPreApprovedTest.IsReadOnly = false;
					this.TestCollectionViaEventCustomerPreApprovedTest.Add((TestEntity)entity);
					this.TestCollectionViaEventCustomerPreApprovedTest.IsReadOnly = true;
					break;
				case "TestCollectionViaEventCustomerRequiredTest":
					this.TestCollectionViaEventCustomerRequiredTest.IsReadOnly = false;
					this.TestCollectionViaEventCustomerRequiredTest.Add((TestEntity)entity);
					this.TestCollectionViaEventCustomerRequiredTest.IsReadOnly = true;
					break;
				case "CustomerSkipReview":
					this.CustomerSkipReview = (CustomerSkipReviewEntity)entity;
					break;
				case "EventCustomerBarrier":
					this.EventCustomerBarrier = (EventCustomerBarrierEntity)entity;
					break;
				case "EventCustomerBasicBioMetric":
					this.EventCustomerBasicBioMetric = (EventCustomerBasicBioMetricEntity)entity;
					break;
				case "EventCustomerEvaluationLock":
					this.EventCustomerEvaluationLock = (EventCustomerEvaluationLockEntity)entity;
					break;
				case "EventCustomerResult":
					this.EventCustomerResult = (EventCustomerResultEntity)entity;
					break;
				case "PcpAppointment_":
					this.PcpAppointment_ = (PcpAppointmentEntity)entity;
					break;
				case "ScreeningAuthorization":
					this.ScreeningAuthorization = (ScreeningAuthorizationEntity)entity;
					break;
				default:
					break;
			}
		}
		
		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public override RelationCollection GetRelationsForFieldOfType(string fieldName)
		{
			return EventCustomersEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "AfaffiliateCampaign":
					toReturn.Add(EventCustomersEntity.Relations.AfaffiliateCampaignEntityUsingAffiliateCampaignId);
					break;
				case "Campaign":
					toReturn.Add(EventCustomersEntity.Relations.CampaignEntityUsingCampaignId);
					break;
				case "CustomerProfile":
					toReturn.Add(EventCustomersEntity.Relations.CustomerProfileEntityUsingCustomerId);
					break;
				case "CustomerProfileHistory":
					toReturn.Add(EventCustomersEntity.Relations.CustomerProfileHistoryEntityUsingCustomerProfileHistoryId);
					break;
				case "CustomerRegistrationNotes":
					toReturn.Add(EventCustomersEntity.Relations.CustomerRegistrationNotesEntityUsingLeftWithoutScreeningNotesId);
					break;
				case "EventAppointment":
					toReturn.Add(EventCustomersEntity.Relations.EventAppointmentEntityUsingAppointmentId);
					break;
				case "Events":
					toReturn.Add(EventCustomersEntity.Relations.EventsEntityUsingEventId);
					break;
				case "GcNotGivenReason":
					toReturn.Add(EventCustomersEntity.Relations.GcNotGivenReasonEntityUsingGcNotGivenReasonId);
					break;
				case "HospitalFacility":
					toReturn.Add(EventCustomersEntity.Relations.HospitalFacilityEntityUsingHospitalFacilityId);
					break;
				case "Lookup_":
					toReturn.Add(EventCustomersEntity.Relations.LookupEntityUsingPreferredContactType);
					break;
				case "Lookup":
					toReturn.Add(EventCustomersEntity.Relations.LookupEntityUsingLeftWithoutScreeningReasonId);
					break;
				case "OrganizationRoleUser_":
					toReturn.Add(EventCustomersEntity.Relations.OrganizationRoleUserEntityUsingConfirmedBy);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(EventCustomersEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
					break;
				case "CallQueueCustomer":
					toReturn.Add(EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId);
					break;
				case "ChaperoneAnswer":
					toReturn.Add(EventCustomersEntity.Relations.ChaperoneAnswerEntityUsingEventCustomerId);
					break;
				case "ChaperoneSignature":
					toReturn.Add(EventCustomersEntity.Relations.ChaperoneSignatureEntityUsingEventCustomerId);
					break;
				case "CheckListAnswer":
					toReturn.Add(EventCustomersEntity.Relations.CheckListAnswerEntityUsingEventCustomerId);
					break;
				case "ClickConversion":
					toReturn.Add(EventCustomersEntity.Relations.ClickConversionEntityUsingEventCustomerId);
					break;
				case "CustomerHealthInfo":
					toReturn.Add(EventCustomersEntity.Relations.CustomerHealthInfoEntityUsingEventCustomerId);
					break;
				case "CustomerHealthInfoArchive":
					toReturn.Add(EventCustomersEntity.Relations.CustomerHealthInfoArchiveEntityUsingEventCustomerId);
					break;
				case "CustomerMedicareQuestionAnswer":
					toReturn.Add(EventCustomersEntity.Relations.CustomerMedicareQuestionAnswerEntityUsingEventCustomerId);
					break;
				case "CustomerOrderHistory":
					toReturn.Add(EventCustomersEntity.Relations.CustomerOrderHistoryEntityUsingEventCustomerId);
					break;
				case "DependentDisqualifiedTest":
					toReturn.Add(EventCustomersEntity.Relations.DependentDisqualifiedTestEntityUsingEventCustomerId);
					break;
				case "DisqualifiedTest":
					toReturn.Add(EventCustomersEntity.Relations.DisqualifiedTestEntityUsingEventCustomerId);
					break;
				case "EventAppointmentCancellationLog":
					toReturn.Add(EventCustomersEntity.Relations.EventAppointmentCancellationLogEntityUsingEventCustomerId);
					break;
				case "EventAppointmentChangeLog":
					toReturn.Add(EventCustomersEntity.Relations.EventAppointmentChangeLogEntityUsingEventCustomerId);
					break;
				case "EventCustomerCriticalQuestion":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerCriticalQuestionEntityUsingEventCustomerId);
					break;
				case "EventCustomerCurrentMedication":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerCurrentMedicationEntityUsingEventCustomerId);
					break;
				case "EventCustomerCustomNotification":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerCustomNotificationEntityUsingEventCustomerId);
					break;
				case "EventCustomerDiagnosis":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerDiagnosisEntityUsingEventCustomerId);
					break;
				case "EventCustomerEligibility":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerEligibilityEntityUsingEventCustomerId);
					break;
				case "EventCustomerEncounter":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerEncounterEntityUsingEventCustomerId);
					break;
				case "EventCustomerGiftCard":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerGiftCardEntityUsingEventCustomerId);
					break;
				case "EventCustomerIcdCodes":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerIcdCodesEntityUsingEventCustomerId);
					break;
				case "EventCustomerNotification":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerNotificationEntityUsingEventCustomerId);
					break;
				case "EventCustomerOrderDetail":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerOrderDetailEntityUsingEventCustomerId);
					break;
				case "EventCustomerPreApprovedPackageTest":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerPreApprovedPackageTestEntityUsingEventCustomerId);
					break;
				case "EventCustomerPreApprovedTest":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerPreApprovedTestEntityUsingEventCustomerId);
					break;
				case "EventCustomerPrimaryCarePhysician":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerPrimaryCarePhysicianEntityUsingEventCustomerId);
					break;
				case "EventCustomerQuestionAnswer":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerQuestionAnswerEntityUsingEventCustomerId);
					break;
				case "EventCustomerRequiredTest":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerRequiredTestEntityUsingEventCustomerId);
					break;
				case "EventCustomerRetest":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerRetestEntityUsingEventCustomerId);
					break;
				case "EventCustomerTestNotPerformedNotification":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerTestNotPerformedNotificationEntityUsingEventCustomerId);
					break;
				case "ExitInterviewAnswer":
					toReturn.Add(EventCustomersEntity.Relations.ExitInterviewAnswerEntityUsingEventCustomerId);
					break;
				case "ExitInterviewSignature":
					toReturn.Add(EventCustomersEntity.Relations.ExitInterviewSignatureEntityUsingEventCustomerId);
					break;
				case "FluConsentAnswer":
					toReturn.Add(EventCustomersEntity.Relations.FluConsentAnswerEntityUsingEventCustomerId);
					break;
				case "FluConsentSignature":
					toReturn.Add(EventCustomersEntity.Relations.FluConsentSignatureEntityUsingEventCustomerId);
					break;
				case "ParticipationConsentSignature":
					toReturn.Add(EventCustomersEntity.Relations.ParticipationConsentSignatureEntityUsingEventCustomerId);
					break;
				case "PcpDisposition":
					toReturn.Add(EventCustomersEntity.Relations.PcpDispositionEntityUsingEventCustomerId);
					break;
				case "PhysicianCustomerAssignment":
					toReturn.Add(EventCustomersEntity.Relations.PhysicianCustomerAssignmentEntityUsingEventCustomerId);
					break;
				case "PhysicianEvaluation":
					toReturn.Add(EventCustomersEntity.Relations.PhysicianEvaluationEntityUsingEventCustomerId);
					break;
				case "PhysicianRecordRequestSignature":
					toReturn.Add(EventCustomersEntity.Relations.PhysicianRecordRequestSignatureEntityUsingEventCustomerId);
					break;
				case "SurveyAnswer":
					toReturn.Add(EventCustomersEntity.Relations.SurveyAnswerEntityUsingEventCustomerId);
					break;
				case "AccountCollectionViaCallQueueCustomer":
					toReturn.Add(EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId, "EventCustomersEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.AccountEntityUsingHealthPlanId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "ActivityTypeCollectionViaCallQueueCustomer":
					toReturn.Add(EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId, "EventCustomersEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.ActivityTypeEntityUsingActivityId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCollectionViaCallQueueCustomer":
					toReturn.Add(EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId, "EventCustomersEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CallQueueEntityUsingCallQueueId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCriteriaCollectionViaCallQueueCustomer":
					toReturn.Add(EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId, "EventCustomersEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CallQueueCriteriaEntityUsingCallQueueCriteriaId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CampaignCollectionViaCallQueueCustomer":
					toReturn.Add(EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId, "EventCustomersEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CampaignEntityUsingCampaignId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "ChaperoneQuestionCollectionViaChaperoneAnswer":
					toReturn.Add(EventCustomersEntity.Relations.ChaperoneAnswerEntityUsingEventCustomerId, "EventCustomersEntity__", "ChaperoneAnswer_", JoinHint.None);
					toReturn.Add(ChaperoneAnswerEntity.Relations.ChaperoneQuestionEntityUsingQuestionId, "ChaperoneAnswer_", string.Empty, JoinHint.None);
					break;
				case "ChargeCardCollectionViaEventCustomerEligibility":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerEligibilityEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerEligibility_", JoinHint.None);
					toReturn.Add(EventCustomerEligibilityEntity.Relations.ChargeCardEntityUsingChargeCardId, "EventCustomerEligibility_", string.Empty, JoinHint.None);
					break;
				case "CheckListQuestionCollectionViaExitInterviewSignature":
					toReturn.Add(EventCustomersEntity.Relations.ExitInterviewSignatureEntityUsingEventCustomerId, "EventCustomersEntity__", "ExitInterviewSignature_", JoinHint.None);
					toReturn.Add(ExitInterviewSignatureEntity.Relations.CheckListQuestionEntityUsingQuestionId, "ExitInterviewSignature_", string.Empty, JoinHint.None);
					break;
				case "CheckListQuestionCollectionViaCheckListAnswer":
					toReturn.Add(EventCustomersEntity.Relations.CheckListAnswerEntityUsingEventCustomerId, "EventCustomersEntity__", "CheckListAnswer_", JoinHint.None);
					toReturn.Add(CheckListAnswerEntity.Relations.CheckListQuestionEntityUsingQuestionId, "CheckListAnswer_", string.Empty, JoinHint.None);
					break;
				case "ClickLogCollectionViaClickConversion":
					toReturn.Add(EventCustomersEntity.Relations.ClickConversionEntityUsingEventCustomerId, "EventCustomersEntity__", "ClickConversion_", JoinHint.None);
					toReturn.Add(ClickConversionEntity.Relations.ClickLogEntityUsingClickId, "ClickConversion_", string.Empty, JoinHint.None);
					break;
				case "CorporateUploadCollectionViaCustomerOrderHistory":
					toReturn.Add(EventCustomersEntity.Relations.CustomerOrderHistoryEntityUsingEventCustomerId, "EventCustomersEntity__", "CustomerOrderHistory_", JoinHint.None);
					toReturn.Add(CustomerOrderHistoryEntity.Relations.CorporateUploadEntityUsingUploadId, "CustomerOrderHistory_", string.Empty, JoinHint.None);
					break;
				case "CriticalQuestionCollectionViaEventCustomerCriticalQuestion":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerCriticalQuestionEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerCriticalQuestion_", JoinHint.None);
					toReturn.Add(EventCustomerCriticalQuestionEntity.Relations.CriticalQuestionEntityUsingQuestionId, "EventCustomerCriticalQuestion_", string.Empty, JoinHint.None);
					break;
				case "CustomerHealthQuestionsCollectionViaCustomerHealthInfoArchive":
					toReturn.Add(EventCustomersEntity.Relations.CustomerHealthInfoArchiveEntityUsingEventCustomerId, "EventCustomersEntity__", "CustomerHealthInfoArchive_", JoinHint.None);
					toReturn.Add(CustomerHealthInfoArchiveEntity.Relations.CustomerHealthQuestionsEntityUsingCustomerHealthQuestionId, "CustomerHealthInfoArchive_", string.Empty, JoinHint.None);
					break;
				case "CustomerHealthQuestionsCollectionViaCustomerHealthInfo":
					toReturn.Add(EventCustomersEntity.Relations.CustomerHealthInfoEntityUsingEventCustomerId, "EventCustomersEntity__", "CustomerHealthInfo_", JoinHint.None);
					toReturn.Add(CustomerHealthInfoEntity.Relations.CustomerHealthQuestionsEntityUsingCustomerHealthQuestionId, "CustomerHealthInfo_", string.Empty, JoinHint.None);
					break;
				case "CustomerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerPrimaryCarePhysicianEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerPrimaryCarePhysician_", JoinHint.None);
					toReturn.Add(EventCustomerPrimaryCarePhysicianEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPrimaryCarePhysicianId, "EventCustomerPrimaryCarePhysician_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCustomerHealthInfo":
					toReturn.Add(EventCustomersEntity.Relations.CustomerHealthInfoEntityUsingEventCustomerId, "EventCustomersEntity__", "CustomerHealthInfo_", JoinHint.None);
					toReturn.Add(CustomerHealthInfoEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerHealthInfo_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCallQueueCustomer":
					toReturn.Add(EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId, "EventCustomersEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CustomerProfileEntityUsingCustomerId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaDependentDisqualifiedTest":
					toReturn.Add(EventCustomersEntity.Relations.DependentDisqualifiedTestEntityUsingEventCustomerId, "EventCustomersEntity__", "DependentDisqualifiedTest_", JoinHint.None);
					toReturn.Add(DependentDisqualifiedTestEntity.Relations.CustomerProfileEntityUsingCustomerId, "DependentDisqualifiedTest_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaClickConversion":
					toReturn.Add(EventCustomersEntity.Relations.ClickConversionEntityUsingEventCustomerId, "EventCustomersEntity__", "ClickConversion_", JoinHint.None);
					toReturn.Add(ClickConversionEntity.Relations.CustomerProfileEntityUsingCustomerId, "ClickConversion_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaDisqualifiedTest":
					toReturn.Add(EventCustomersEntity.Relations.DisqualifiedTestEntityUsingEventCustomerId, "EventCustomersEntity__", "DisqualifiedTest_", JoinHint.None);
					toReturn.Add(DisqualifiedTestEntity.Relations.CustomerProfileEntityUsingCustomerId, "DisqualifiedTest_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCustomerOrderHistory":
					toReturn.Add(EventCustomersEntity.Relations.CustomerOrderHistoryEntityUsingEventCustomerId, "EventCustomersEntity__", "CustomerOrderHistory_", JoinHint.None);
					toReturn.Add(CustomerOrderHistoryEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerOrderHistory_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCustomerHealthInfoArchive":
					toReturn.Add(EventCustomersEntity.Relations.CustomerHealthInfoArchiveEntityUsingEventCustomerId, "EventCustomersEntity__", "CustomerHealthInfoArchive_", JoinHint.None);
					toReturn.Add(CustomerHealthInfoArchiveEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerHealthInfoArchive_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaEventCustomerQuestionAnswer":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerQuestionAnswerEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerQuestionAnswer_", JoinHint.None);
					toReturn.Add(EventCustomerQuestionAnswerEntity.Relations.CustomerProfileEntityUsingCustomerId, "EventCustomerQuestionAnswer_", string.Empty, JoinHint.None);
					break;
				case "CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog":
					toReturn.Add(EventCustomersEntity.Relations.EventAppointmentCancellationLogEntityUsingEventCustomerId, "EventCustomersEntity__", "EventAppointmentCancellationLog_", JoinHint.None);
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.CustomerRegistrationNotesEntityUsingNoteId, "EventAppointmentCancellationLog_", string.Empty, JoinHint.None);
					break;
				case "CustomEventNotificationCollectionViaEventCustomerCustomNotification":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerCustomNotificationEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerCustomNotification_", JoinHint.None);
					toReturn.Add(EventCustomerCustomNotificationEntity.Relations.CustomEventNotificationEntityUsingCustomEventNotificationId, "EventCustomerCustomNotification_", string.Empty, JoinHint.None);
					break;
				case "EligibilityCollectionViaEventCustomerEligibility":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerEligibilityEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerEligibility_", JoinHint.None);
					toReturn.Add(EventCustomerEligibilityEntity.Relations.EligibilityEntityUsingEligibilityId, "EventCustomerEligibility_", string.Empty, JoinHint.None);
					break;
				case "EncounterCollectionViaEventCustomerEncounter":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerEncounterEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerEncounter_", JoinHint.None);
					toReturn.Add(EventCustomerEncounterEntity.Relations.EncounterEntityUsingEncounterId, "EventCustomerEncounter_", string.Empty, JoinHint.None);
					break;
				case "EventPackageDetailsCollectionViaCustomerOrderHistory":
					toReturn.Add(EventCustomersEntity.Relations.CustomerOrderHistoryEntityUsingEventCustomerId, "EventCustomersEntity__", "CustomerOrderHistory_", JoinHint.None);
					toReturn.Add(CustomerOrderHistoryEntity.Relations.EventPackageDetailsEntityUsingEventPackageId, "CustomerOrderHistory_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventAppointmentChangeLog_":
					toReturn.Add(EventCustomersEntity.Relations.EventAppointmentChangeLogEntityUsingEventCustomerId, "EventCustomersEntity__", "EventAppointmentChangeLog_", JoinHint.None);
					toReturn.Add(EventAppointmentChangeLogEntity.Relations.EventsEntityUsingOldEventId, "EventAppointmentChangeLog_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventAppointmentChangeLog":
					toReturn.Add(EventCustomersEntity.Relations.EventAppointmentChangeLogEntityUsingEventCustomerId, "EventCustomersEntity__", "EventAppointmentChangeLog_", JoinHint.None);
					toReturn.Add(EventAppointmentChangeLogEntity.Relations.EventsEntityUsingNewEventId, "EventAppointmentChangeLog_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventAppointmentCancellationLog":
					toReturn.Add(EventCustomersEntity.Relations.EventAppointmentCancellationLogEntityUsingEventCustomerId, "EventCustomersEntity__", "EventAppointmentCancellationLog_", JoinHint.None);
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.EventsEntityUsingEventId, "EventAppointmentCancellationLog_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventCustomerQuestionAnswer":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerQuestionAnswerEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerQuestionAnswer_", JoinHint.None);
					toReturn.Add(EventCustomerQuestionAnswerEntity.Relations.EventsEntityUsingEventId, "EventCustomerQuestionAnswer_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaDependentDisqualifiedTest":
					toReturn.Add(EventCustomersEntity.Relations.DependentDisqualifiedTestEntityUsingEventCustomerId, "EventCustomersEntity__", "DependentDisqualifiedTest_", JoinHint.None);
					toReturn.Add(DependentDisqualifiedTestEntity.Relations.EventsEntityUsingEventId, "DependentDisqualifiedTest_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaCustomerOrderHistory":
					toReturn.Add(EventCustomersEntity.Relations.CustomerOrderHistoryEntityUsingEventCustomerId, "EventCustomersEntity__", "CustomerOrderHistory_", JoinHint.None);
					toReturn.Add(CustomerOrderHistoryEntity.Relations.EventsEntityUsingEventId, "CustomerOrderHistory_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaDisqualifiedTest":
					toReturn.Add(EventCustomersEntity.Relations.DisqualifiedTestEntityUsingEventCustomerId, "EventCustomersEntity__", "DisqualifiedTest_", JoinHint.None);
					toReturn.Add(DisqualifiedTestEntity.Relations.EventsEntityUsingEventId, "DisqualifiedTest_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaCallQueueCustomer":
					toReturn.Add(EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId, "EventCustomersEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.EventsEntityUsingEventId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "EventTestCollectionViaCustomerOrderHistory":
					toReturn.Add(EventCustomersEntity.Relations.CustomerOrderHistoryEntityUsingEventCustomerId, "EventCustomersEntity__", "CustomerOrderHistory_", JoinHint.None);
					toReturn.Add(CustomerOrderHistoryEntity.Relations.EventTestEntityUsingEventTestId, "CustomerOrderHistory_", string.Empty, JoinHint.None);
					break;
				case "ExitInterviewQuestionCollectionViaExitInterviewAnswer":
					toReturn.Add(EventCustomersEntity.Relations.ExitInterviewAnswerEntityUsingEventCustomerId, "EventCustomersEntity__", "ExitInterviewAnswer_", JoinHint.None);
					toReturn.Add(ExitInterviewAnswerEntity.Relations.ExitInterviewQuestionEntityUsingQuestionId, "ExitInterviewAnswer_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaParticipationConsentSignature_":
					toReturn.Add(EventCustomersEntity.Relations.ParticipationConsentSignatureEntityUsingEventCustomerId, "EventCustomersEntity__", "ParticipationConsentSignature_", JoinHint.None);
					toReturn.Add(ParticipationConsentSignatureEntity.Relations.FileEntityUsingSignatureFileId, "ParticipationConsentSignature_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaParticipationConsentSignature":
					toReturn.Add(EventCustomersEntity.Relations.ParticipationConsentSignatureEntityUsingEventCustomerId, "EventCustomersEntity__", "ParticipationConsentSignature_", JoinHint.None);
					toReturn.Add(ParticipationConsentSignatureEntity.Relations.FileEntityUsingInsuranceSignatureFileId, "ParticipationConsentSignature_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaEventCustomerGiftCard":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerGiftCardEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerGiftCard_", JoinHint.None);
					toReturn.Add(EventCustomerGiftCardEntity.Relations.FileEntityUsingPatientSignatureFileId, "EventCustomerGiftCard_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaEventCustomerGiftCard_":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerGiftCardEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerGiftCard_", JoinHint.None);
					toReturn.Add(EventCustomerGiftCardEntity.Relations.FileEntityUsingTechnicianSignatureFileId, "EventCustomerGiftCard_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaFluConsentSignature_":
					toReturn.Add(EventCustomersEntity.Relations.FluConsentSignatureEntityUsingEventCustomerId, "EventCustomersEntity__", "FluConsentSignature_", JoinHint.None);
					toReturn.Add(FluConsentSignatureEntity.Relations.FileEntityUsingClinicalProviderSignatureFileId, "FluConsentSignature_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaPhysicianRecordRequestSignature":
					toReturn.Add(EventCustomersEntity.Relations.PhysicianRecordRequestSignatureEntityUsingEventCustomerId, "EventCustomersEntity__", "PhysicianRecordRequestSignature_", JoinHint.None);
					toReturn.Add(PhysicianRecordRequestSignatureEntity.Relations.FileEntityUsingSignatureFileId, "PhysicianRecordRequestSignature_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaChaperoneSignature":
					toReturn.Add(EventCustomersEntity.Relations.ChaperoneSignatureEntityUsingEventCustomerId, "EventCustomersEntity__", "ChaperoneSignature_", JoinHint.None);
					toReturn.Add(ChaperoneSignatureEntity.Relations.FileEntityUsingSignatureFileId, "ChaperoneSignature_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaExitInterviewSignature":
					toReturn.Add(EventCustomersEntity.Relations.ExitInterviewSignatureEntityUsingEventCustomerId, "EventCustomersEntity__", "ExitInterviewSignature_", JoinHint.None);
					toReturn.Add(ExitInterviewSignatureEntity.Relations.FileEntityUsingSignatureFileId, "ExitInterviewSignature_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaChaperoneSignature_":
					toReturn.Add(EventCustomersEntity.Relations.ChaperoneSignatureEntityUsingEventCustomerId, "EventCustomersEntity__", "ChaperoneSignature_", JoinHint.None);
					toReturn.Add(ChaperoneSignatureEntity.Relations.FileEntityUsingStaffSignatureFileId, "ChaperoneSignature_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaFluConsentSignature":
					toReturn.Add(EventCustomersEntity.Relations.FluConsentSignatureEntityUsingEventCustomerId, "EventCustomersEntity__", "FluConsentSignature_", JoinHint.None);
					toReturn.Add(FluConsentSignatureEntity.Relations.FileEntityUsingSignatureFileId, "FluConsentSignature_", string.Empty, JoinHint.None);
					break;
				case "FluConsentQuestionCollectionViaFluConsentAnswer":
					toReturn.Add(EventCustomersEntity.Relations.FluConsentAnswerEntityUsingEventCustomerId, "EventCustomersEntity__", "FluConsentAnswer_", JoinHint.None);
					toReturn.Add(FluConsentAnswerEntity.Relations.FluConsentQuestionEntityUsingQuestionId, "FluConsentAnswer_", string.Empty, JoinHint.None);
					break;
				case "IcdCodesCollectionViaEventCustomerIcdCodes":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerIcdCodesEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerIcdCodes_", JoinHint.None);
					toReturn.Add(EventCustomerIcdCodesEntity.Relations.IcdCodesEntityUsingIcdCodeId, "EventCustomerIcdCodes_", string.Empty, JoinHint.None);
					break;
				case "LanguageCollectionViaCallQueueCustomer":
					toReturn.Add(EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId, "EventCustomersEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.LanguageEntityUsingLanguageId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerOrderHistory":
					toReturn.Add(EventCustomersEntity.Relations.CustomerOrderHistoryEntityUsingEventCustomerId, "EventCustomersEntity__", "CustomerOrderHistory_", JoinHint.None);
					toReturn.Add(CustomerOrderHistoryEntity.Relations.LookupEntityUsingOrderItemStatusId, "CustomerOrderHistory_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCallQueueCustomer":
					toReturn.Add(EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId, "EventCustomersEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.LookupEntityUsingDoNotContactUpdateSource, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventAppointmentChangeLog":
					toReturn.Add(EventCustomersEntity.Relations.EventAppointmentChangeLogEntityUsingEventCustomerId, "EventCustomersEntity__", "EventAppointmentChangeLog_", JoinHint.None);
					toReturn.Add(EventAppointmentChangeLogEntity.Relations.LookupEntityUsingReasonId, "EventAppointmentChangeLog_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCheckListAnswer":
					toReturn.Add(EventCustomersEntity.Relations.CheckListAnswerEntityUsingEventCustomerId, "EventCustomersEntity__", "CheckListAnswer_", JoinHint.None);
					toReturn.Add(CheckListAnswerEntity.Relations.LookupEntityUsingType, "CheckListAnswer_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaPcpDisposition":
					toReturn.Add(EventCustomersEntity.Relations.PcpDispositionEntityUsingEventCustomerId, "EventCustomersEntity__", "PcpDisposition_", JoinHint.None);
					toReturn.Add(PcpDispositionEntity.Relations.LookupEntityUsingDispositionId, "PcpDisposition_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventAppointmentCancellationLog":
					toReturn.Add(EventCustomersEntity.Relations.EventAppointmentCancellationLogEntityUsingEventCustomerId, "EventCustomersEntity__", "EventAppointmentCancellationLog_", JoinHint.None);
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.LookupEntityUsingReasonId, "EventAppointmentCancellationLog_", string.Empty, JoinHint.None);
					break;
				case "MedicareQuestionCollectionViaCustomerMedicareQuestionAnswer":
					toReturn.Add(EventCustomersEntity.Relations.CustomerMedicareQuestionAnswerEntityUsingEventCustomerId, "EventCustomersEntity__", "CustomerMedicareQuestionAnswer_", JoinHint.None);
					toReturn.Add(CustomerMedicareQuestionAnswerEntity.Relations.MedicareQuestionEntityUsingQuestionId, "CustomerMedicareQuestionAnswer_", string.Empty, JoinHint.None);
					break;
				case "NdcCollectionViaEventCustomerCurrentMedication":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerCurrentMedicationEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerCurrentMedication_", JoinHint.None);
					toReturn.Add(EventCustomerCurrentMedicationEntity.Relations.NdcEntityUsingNdcId, "EventCustomerCurrentMedication_", string.Empty, JoinHint.None);
					break;
				case "NotesDetailsCollectionViaCallQueueCustomer":
					toReturn.Add(EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId, "EventCustomersEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.NotesDetailsEntityUsingNotesId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "NotificationCollectionViaEventCustomerNotification":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerNotificationEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerNotification_", JoinHint.None);
					toReturn.Add(EventCustomerNotificationEntity.Relations.NotificationEntityUsingNotificationId, "EventCustomerNotification_", string.Empty, JoinHint.None);
					break;
				case "NotificationTypeCollectionViaEventCustomerTestNotPerformedNotification":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerTestNotPerformedNotificationEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerTestNotPerformedNotification_", JoinHint.None);
					toReturn.Add(EventCustomerTestNotPerformedNotificationEntity.Relations.NotificationTypeEntityUsingNotificationTypeId, "EventCustomerTestNotPerformedNotification_", string.Empty, JoinHint.None);
					break;
				case "NotificationTypeCollectionViaEventCustomerNotification":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerNotificationEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerNotification_", JoinHint.None);
					toReturn.Add(EventCustomerNotificationEntity.Relations.NotificationTypeEntityUsingNotificationTypeId, "EventCustomerNotification_", string.Empty, JoinHint.None);
					break;
				case "OrderDetailCollectionViaEventCustomerOrderDetail":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerOrderDetailEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerOrderDetail_", JoinHint.None);
					toReturn.Add(EventCustomerOrderDetailEntity.Relations.OrderDetailEntityUsingOrderDetailId, "EventCustomerOrderDetail_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaExitInterviewAnswer_":
					toReturn.Add(EventCustomersEntity.Relations.ExitInterviewAnswerEntityUsingEventCustomerId, "EventCustomersEntity__", "ExitInterviewAnswer_", JoinHint.None);
					toReturn.Add(ExitInterviewAnswerEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "ExitInterviewAnswer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaParticipationConsentSignature":
					toReturn.Add(EventCustomersEntity.Relations.ParticipationConsentSignatureEntityUsingEventCustomerId, "EventCustomersEntity__", "ParticipationConsentSignature_", JoinHint.None);
					toReturn.Add(ParticipationConsentSignatureEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "ParticipationConsentSignature_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaFluConsentSignature":
					toReturn.Add(EventCustomersEntity.Relations.FluConsentSignatureEntityUsingEventCustomerId, "EventCustomersEntity__", "FluConsentSignature_", JoinHint.None);
					toReturn.Add(FluConsentSignatureEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "FluConsentSignature_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaPcpDisposition_":
					toReturn.Add(EventCustomersEntity.Relations.PcpDispositionEntityUsingEventCustomerId, "EventCustomersEntity__", "PcpDisposition_", JoinHint.None);
					toReturn.Add(PcpDispositionEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "PcpDisposition_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaPcpDisposition":
					toReturn.Add(EventCustomersEntity.Relations.PcpDispositionEntityUsingEventCustomerId, "EventCustomersEntity__", "PcpDisposition_", JoinHint.None);
					toReturn.Add(PcpDispositionEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "PcpDisposition_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerPrimaryCarePhysicianEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerPrimaryCarePhysician_", JoinHint.None);
					toReturn.Add(EventCustomerPrimaryCarePhysicianEntity.Relations.OrganizationRoleUserEntityUsingPcpAddressVerifiedBy, "EventCustomerPrimaryCarePhysician_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerTestNotPerformedNotificationEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerTestNotPerformedNotification_", JoinHint.None);
					toReturn.Add(EventCustomerTestNotPerformedNotificationEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "EventCustomerTestNotPerformedNotification_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventCustomerRetest":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerRetestEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerRetest_", JoinHint.None);
					toReturn.Add(EventCustomerRetestEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "EventCustomerRetest_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaExitInterviewAnswer":
					toReturn.Add(EventCustomersEntity.Relations.ExitInterviewAnswerEntityUsingEventCustomerId, "EventCustomersEntity__", "ExitInterviewAnswer_", JoinHint.None);
					toReturn.Add(ExitInterviewAnswerEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "ExitInterviewAnswer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaExitInterviewSignature":
					toReturn.Add(EventCustomersEntity.Relations.ExitInterviewSignatureEntityUsingEventCustomerId, "EventCustomersEntity__", "ExitInterviewSignature_", JoinHint.None);
					toReturn.Add(ExitInterviewSignatureEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "ExitInterviewSignature_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaFluConsentAnswer_":
					toReturn.Add(EventCustomersEntity.Relations.FluConsentAnswerEntityUsingEventCustomerId, "EventCustomersEntity__", "FluConsentAnswer_", JoinHint.None);
					toReturn.Add(FluConsentAnswerEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "FluConsentAnswer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerQuestionAnswerEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerQuestionAnswer_", JoinHint.None);
					toReturn.Add(EventCustomerQuestionAnswerEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "EventCustomerQuestionAnswer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerQuestionAnswerEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerQuestionAnswer_", JoinHint.None);
					toReturn.Add(EventCustomerQuestionAnswerEntity.Relations.OrganizationRoleUserEntityUsingUpdatedBy, "EventCustomerQuestionAnswer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaFluConsentAnswer":
					toReturn.Add(EventCustomersEntity.Relations.FluConsentAnswerEntityUsingEventCustomerId, "EventCustomersEntity__", "FluConsentAnswer_", JoinHint.None);
					toReturn.Add(FluConsentAnswerEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "FluConsentAnswer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaChaperoneSignature":
					toReturn.Add(EventCustomersEntity.Relations.ChaperoneSignatureEntityUsingEventCustomerId, "EventCustomersEntity__", "ChaperoneSignature_", JoinHint.None);
					toReturn.Add(ChaperoneSignatureEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "ChaperoneSignature_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaSurveyAnswer":
					toReturn.Add(EventCustomersEntity.Relations.SurveyAnswerEntityUsingEventCustomerId, "EventCustomersEntity__", "SurveyAnswer_", JoinHint.None);
					toReturn.Add(SurveyAnswerEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "SurveyAnswer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaDisqualifiedTest_":
					toReturn.Add(EventCustomersEntity.Relations.DisqualifiedTestEntityUsingEventCustomerId, "EventCustomersEntity__", "DisqualifiedTest_", JoinHint.None);
					toReturn.Add(DisqualifiedTestEntity.Relations.OrganizationRoleUserEntityUsingUpdatedBy, "DisqualifiedTest_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventAppointmentChangeLog":
					toReturn.Add(EventCustomersEntity.Relations.EventAppointmentChangeLogEntityUsingEventCustomerId, "EventCustomersEntity__", "EventAppointmentChangeLog_", JoinHint.None);
					toReturn.Add(EventAppointmentChangeLogEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "EventAppointmentChangeLog_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaChaperoneAnswer_":
					toReturn.Add(EventCustomersEntity.Relations.ChaperoneAnswerEntityUsingEventCustomerId, "EventCustomersEntity__", "ChaperoneAnswer_", JoinHint.None);
					toReturn.Add(ChaperoneAnswerEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "ChaperoneAnswer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventAppointmentCancellationLog":
					toReturn.Add(EventCustomersEntity.Relations.EventAppointmentCancellationLogEntityUsingEventCustomerId, "EventCustomersEntity__", "EventAppointmentCancellationLog_", JoinHint.None);
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "EventAppointmentCancellationLog_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCheckListAnswer_":
					toReturn.Add(EventCustomersEntity.Relations.CheckListAnswerEntityUsingEventCustomerId, "EventCustomersEntity__", "CheckListAnswer_", JoinHint.None);
					toReturn.Add(CheckListAnswerEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "CheckListAnswer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerHealthInfo":
					toReturn.Add(EventCustomersEntity.Relations.CustomerHealthInfoEntityUsingEventCustomerId, "EventCustomersEntity__", "CustomerHealthInfo_", JoinHint.None);
					toReturn.Add(CustomerHealthInfoEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "CustomerHealthInfo_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerHealthInfoArchive":
					toReturn.Add(EventCustomersEntity.Relations.CustomerHealthInfoArchiveEntityUsingEventCustomerId, "EventCustomersEntity__", "CustomerHealthInfoArchive_", JoinHint.None);
					toReturn.Add(CustomerHealthInfoArchiveEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "CustomerHealthInfoArchive_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaDisqualifiedTest":
					toReturn.Add(EventCustomersEntity.Relations.DisqualifiedTestEntityUsingEventCustomerId, "EventCustomersEntity__", "DisqualifiedTest_", JoinHint.None);
					toReturn.Add(DisqualifiedTestEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "DisqualifiedTest_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCheckListAnswer":
					toReturn.Add(EventCustomersEntity.Relations.CheckListAnswerEntityUsingEventCustomerId, "EventCustomersEntity__", "CheckListAnswer_", JoinHint.None);
					toReturn.Add(CheckListAnswerEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "CheckListAnswer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaSurveyAnswer_":
					toReturn.Add(EventCustomersEntity.Relations.SurveyAnswerEntityUsingEventCustomerId, "EventCustomersEntity__", "SurveyAnswer_", JoinHint.None);
					toReturn.Add(SurveyAnswerEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "SurveyAnswer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaChaperoneAnswer":
					toReturn.Add(EventCustomersEntity.Relations.ChaperoneAnswerEntityUsingEventCustomerId, "EventCustomersEntity__", "ChaperoneAnswer_", JoinHint.None);
					toReturn.Add(ChaperoneAnswerEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "ChaperoneAnswer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer__":
					toReturn.Add(EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId, "EventCustomersEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventCustomerGiftCard":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerGiftCardEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerGiftCard_", JoinHint.None);
					toReturn.Add(EventCustomerGiftCardEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "EventCustomerGiftCard_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer":
					toReturn.Add(EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId, "EventCustomersEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer_":
					toReturn.Add(EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId, "EventCustomersEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaPhysicianRecordRequestSignature":
					toReturn.Add(EventCustomersEntity.Relations.PhysicianRecordRequestSignatureEntityUsingEventCustomerId, "EventCustomersEntity__", "PhysicianRecordRequestSignature_", JoinHint.None);
					toReturn.Add(PhysicianRecordRequestSignatureEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "PhysicianRecordRequestSignature_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer":
					toReturn.Add(EventCustomersEntity.Relations.CustomerMedicareQuestionAnswerEntityUsingEventCustomerId, "EventCustomersEntity__", "CustomerMedicareQuestionAnswer_", JoinHint.None);
					toReturn.Add(CustomerMedicareQuestionAnswerEntity.Relations.OrganizationRoleUserEntityUsingCreateBy, "CustomerMedicareQuestionAnswer_", string.Empty, JoinHint.None);
					break;
				case "PackageCollectionViaEventCustomerPreApprovedPackageTest":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerPreApprovedPackageTestEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerPreApprovedPackageTest_", JoinHint.None);
					toReturn.Add(EventCustomerPreApprovedPackageTestEntity.Relations.PackageEntityUsingPackageId, "EventCustomerPreApprovedPackageTest_", string.Empty, JoinHint.None);
					break;
				case "PhysicianProfileCollectionViaPhysicianEvaluation":
					toReturn.Add(EventCustomersEntity.Relations.PhysicianEvaluationEntityUsingEventCustomerId, "EventCustomersEntity__", "PhysicianEvaluation_", JoinHint.None);
					toReturn.Add(PhysicianEvaluationEntity.Relations.PhysicianProfileEntityUsingPhysicianId, "PhysicianEvaluation_", string.Empty, JoinHint.None);
					break;
				case "PhysicianProfileCollectionViaPhysicianCustomerAssignment_":
					toReturn.Add(EventCustomersEntity.Relations.PhysicianCustomerAssignmentEntityUsingEventCustomerId, "EventCustomersEntity__", "PhysicianCustomerAssignment_", JoinHint.None);
					toReturn.Add(PhysicianCustomerAssignmentEntity.Relations.PhysicianProfileEntityUsingPhysicianId, "PhysicianCustomerAssignment_", string.Empty, JoinHint.None);
					break;
				case "PhysicianProfileCollectionViaPhysicianCustomerAssignment":
					toReturn.Add(EventCustomersEntity.Relations.PhysicianCustomerAssignmentEntityUsingEventCustomerId, "EventCustomersEntity__", "PhysicianCustomerAssignment_", JoinHint.None);
					toReturn.Add(PhysicianCustomerAssignmentEntity.Relations.PhysicianProfileEntityUsingOverReadPhysicianId, "PhysicianCustomerAssignment_", string.Empty, JoinHint.None);
					break;
				case "PreQualificationQuestionCollectionViaEventCustomerQuestionAnswer":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerQuestionAnswerEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerQuestionAnswer_", JoinHint.None);
					toReturn.Add(EventCustomerQuestionAnswerEntity.Relations.PreQualificationQuestionEntityUsingQuestionId, "EventCustomerQuestionAnswer_", string.Empty, JoinHint.None);
					break;
				case "PreQualificationQuestionCollectionViaDisqualifiedTest":
					toReturn.Add(EventCustomersEntity.Relations.DisqualifiedTestEntityUsingEventCustomerId, "EventCustomersEntity__", "DisqualifiedTest_", JoinHint.None);
					toReturn.Add(DisqualifiedTestEntity.Relations.PreQualificationQuestionEntityUsingQuestionId, "DisqualifiedTest_", string.Empty, JoinHint.None);
					break;
				case "ProspectCustomerCollectionViaClickConversion":
					toReturn.Add(EventCustomersEntity.Relations.ClickConversionEntityUsingEventCustomerId, "EventCustomersEntity__", "ClickConversion_", JoinHint.None);
					toReturn.Add(ClickConversionEntity.Relations.ProspectCustomerEntityUsingProspectCustomerId, "ClickConversion_", string.Empty, JoinHint.None);
					break;
				case "ProspectCustomerCollectionViaCallQueueCustomer":
					toReturn.Add(EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId, "EventCustomersEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.ProspectCustomerEntityUsingProspectCustomerId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "RefundRequestCollectionViaEventAppointmentCancellationLog":
					toReturn.Add(EventCustomersEntity.Relations.EventAppointmentCancellationLogEntityUsingEventCustomerId, "EventCustomersEntity__", "EventAppointmentCancellationLog_", JoinHint.None);
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.RefundRequestEntityUsingRefundRequestId, "EventAppointmentCancellationLog_", string.Empty, JoinHint.None);
					break;
				case "RescheduleCancelDispositionCollectionViaEventAppointmentChangeLog":
					toReturn.Add(EventCustomersEntity.Relations.EventAppointmentChangeLogEntityUsingEventCustomerId, "EventCustomersEntity__", "EventAppointmentChangeLog_", JoinHint.None);
					toReturn.Add(EventAppointmentChangeLogEntity.Relations.RescheduleCancelDispositionEntityUsingSubReasonId, "EventAppointmentChangeLog_", string.Empty, JoinHint.None);
					break;
				case "RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog":
					toReturn.Add(EventCustomersEntity.Relations.EventAppointmentCancellationLogEntityUsingEventCustomerId, "EventCustomersEntity__", "EventAppointmentCancellationLog_", JoinHint.None);
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.RescheduleCancelDispositionEntityUsingSubReasonId, "EventAppointmentCancellationLog_", string.Empty, JoinHint.None);
					break;
				case "SurveyQuestionCollectionViaSurveyAnswer":
					toReturn.Add(EventCustomersEntity.Relations.SurveyAnswerEntityUsingEventCustomerId, "EventCustomersEntity__", "SurveyAnswer_", JoinHint.None);
					toReturn.Add(SurveyAnswerEntity.Relations.SurveyQuestionEntityUsingQuestionId, "SurveyAnswer_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaEventCustomerPreApprovedPackageTest":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerPreApprovedPackageTestEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerPreApprovedPackageTest_", JoinHint.None);
					toReturn.Add(EventCustomerPreApprovedPackageTestEntity.Relations.TestEntityUsingTestId, "EventCustomerPreApprovedPackageTest_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaDisqualifiedTest":
					toReturn.Add(EventCustomersEntity.Relations.DisqualifiedTestEntityUsingEventCustomerId, "EventCustomersEntity__", "DisqualifiedTest_", JoinHint.None);
					toReturn.Add(DisqualifiedTestEntity.Relations.TestEntityUsingTestId, "DisqualifiedTest_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaDependentDisqualifiedTest":
					toReturn.Add(EventCustomersEntity.Relations.DependentDisqualifiedTestEntityUsingEventCustomerId, "EventCustomersEntity__", "DependentDisqualifiedTest_", JoinHint.None);
					toReturn.Add(DependentDisqualifiedTestEntity.Relations.TestEntityUsingTestId, "DependentDisqualifiedTest_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaEventCustomerRetest":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerRetestEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerRetest_", JoinHint.None);
					toReturn.Add(EventCustomerRetestEntity.Relations.TestEntityUsingTestId, "EventCustomerRetest_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaEventCustomerTestNotPerformedNotification":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerTestNotPerformedNotificationEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerTestNotPerformedNotification_", JoinHint.None);
					toReturn.Add(EventCustomerTestNotPerformedNotificationEntity.Relations.TestEntityUsingTestId, "EventCustomerTestNotPerformedNotification_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaEventCustomerPreApprovedTest":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerPreApprovedTestEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerPreApprovedTest_", JoinHint.None);
					toReturn.Add(EventCustomerPreApprovedTestEntity.Relations.TestEntityUsingTestId, "EventCustomerPreApprovedTest_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaEventCustomerRequiredTest":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerRequiredTestEntityUsingEventCustomerId, "EventCustomersEntity__", "EventCustomerRequiredTest_", JoinHint.None);
					toReturn.Add(EventCustomerRequiredTestEntity.Relations.TestEntityUsingTestId, "EventCustomerRequiredTest_", string.Empty, JoinHint.None);
					break;
				case "CustomerSkipReview":
					toReturn.Add(EventCustomersEntity.Relations.CustomerSkipReviewEntityUsingEventCustomerId);
					break;
				case "EventCustomerBarrier":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerBarrierEntityUsingEventCustomerId);
					break;
				case "EventCustomerBasicBioMetric":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerBasicBioMetricEntityUsingEventCustomerId);
					break;
				case "EventCustomerEvaluationLock":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerEvaluationLockEntityUsingEventCustomerId);
					break;
				case "EventCustomerResult":
					toReturn.Add(EventCustomersEntity.Relations.EventCustomerResultEntityUsingEventCustomerResultId);
					break;
				case "PcpAppointment_":
					toReturn.Add(EventCustomersEntity.Relations.PcpAppointmentEntityUsingEventCustomerId);
					break;
				case "ScreeningAuthorization":
					toReturn.Add(EventCustomersEntity.Relations.ScreeningAuthorizationEntityUsingEventCustomerId);
					break;
				default:

					break;				
			}
			return toReturn;
		}
#if !CF
		/// <summary>Checks if the relation mapped by the property with the name specified is a one way / single sided relation. If the passed in name is null, it
		/// will return true if the entity has any single-sided relation</summary>
		/// <param name="propertyName">Name of the property which is mapped onto the relation to check, or null to check if the entity has any relation/ which is single sided</param>
		/// <returns>true if the relation is single sided / one way (so the opposite relation isn't present), false otherwise</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override bool CheckOneWayRelations(string propertyName)
		{
			// use template trick to calculate the # of single-sided / oneway relations
			int numberOfOneWayRelations = 0;
			switch(propertyName)
			{
				case null:
					return ((numberOfOneWayRelations > 0) || base.CheckOneWayRelations(null));




















				default:
					return base.CheckOneWayRelations(propertyName);
			}
		}
#endif
		/// <summary> Sets the internal parameter related to the fieldname passed to the instance relatedEntity. </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntity(IEntity2 relatedEntity, string fieldName)
		{
			switch(fieldName)
			{
				case "AfaffiliateCampaign":
					SetupSyncAfaffiliateCampaign(relatedEntity);
					break;
				case "Campaign":
					SetupSyncCampaign(relatedEntity);
					break;
				case "CustomerProfile":
					SetupSyncCustomerProfile(relatedEntity);
					break;
				case "CustomerProfileHistory":
					SetupSyncCustomerProfileHistory(relatedEntity);
					break;
				case "CustomerRegistrationNotes":
					SetupSyncCustomerRegistrationNotes(relatedEntity);
					break;
				case "EventAppointment":
					SetupSyncEventAppointment(relatedEntity);
					break;
				case "Events":
					SetupSyncEvents(relatedEntity);
					break;
				case "GcNotGivenReason":
					SetupSyncGcNotGivenReason(relatedEntity);
					break;
				case "HospitalFacility":
					SetupSyncHospitalFacility(relatedEntity);
					break;
				case "Lookup_":
					SetupSyncLookup_(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "OrganizationRoleUser_":
					SetupSyncOrganizationRoleUser_(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "CallQueueCustomer":
					this.CallQueueCustomer.Add((CallQueueCustomerEntity)relatedEntity);
					break;
				case "ChaperoneAnswer":
					this.ChaperoneAnswer.Add((ChaperoneAnswerEntity)relatedEntity);
					break;
				case "ChaperoneSignature":
					this.ChaperoneSignature.Add((ChaperoneSignatureEntity)relatedEntity);
					break;
				case "CheckListAnswer":
					this.CheckListAnswer.Add((CheckListAnswerEntity)relatedEntity);
					break;
				case "ClickConversion":
					this.ClickConversion.Add((ClickConversionEntity)relatedEntity);
					break;
				case "CustomerHealthInfo":
					this.CustomerHealthInfo.Add((CustomerHealthInfoEntity)relatedEntity);
					break;
				case "CustomerHealthInfoArchive":
					this.CustomerHealthInfoArchive.Add((CustomerHealthInfoArchiveEntity)relatedEntity);
					break;
				case "CustomerMedicareQuestionAnswer":
					this.CustomerMedicareQuestionAnswer.Add((CustomerMedicareQuestionAnswerEntity)relatedEntity);
					break;
				case "CustomerOrderHistory":
					this.CustomerOrderHistory.Add((CustomerOrderHistoryEntity)relatedEntity);
					break;
				case "DependentDisqualifiedTest":
					this.DependentDisqualifiedTest.Add((DependentDisqualifiedTestEntity)relatedEntity);
					break;
				case "DisqualifiedTest":
					this.DisqualifiedTest.Add((DisqualifiedTestEntity)relatedEntity);
					break;
				case "EventAppointmentCancellationLog":
					this.EventAppointmentCancellationLog.Add((EventAppointmentCancellationLogEntity)relatedEntity);
					break;
				case "EventAppointmentChangeLog":
					this.EventAppointmentChangeLog.Add((EventAppointmentChangeLogEntity)relatedEntity);
					break;
				case "EventCustomerCriticalQuestion":
					this.EventCustomerCriticalQuestion.Add((EventCustomerCriticalQuestionEntity)relatedEntity);
					break;
				case "EventCustomerCurrentMedication":
					this.EventCustomerCurrentMedication.Add((EventCustomerCurrentMedicationEntity)relatedEntity);
					break;
				case "EventCustomerCustomNotification":
					this.EventCustomerCustomNotification.Add((EventCustomerCustomNotificationEntity)relatedEntity);
					break;
				case "EventCustomerDiagnosis":
					this.EventCustomerDiagnosis.Add((EventCustomerDiagnosisEntity)relatedEntity);
					break;
				case "EventCustomerEligibility":
					this.EventCustomerEligibility.Add((EventCustomerEligibilityEntity)relatedEntity);
					break;
				case "EventCustomerEncounter":
					this.EventCustomerEncounter.Add((EventCustomerEncounterEntity)relatedEntity);
					break;
				case "EventCustomerGiftCard":
					this.EventCustomerGiftCard.Add((EventCustomerGiftCardEntity)relatedEntity);
					break;
				case "EventCustomerIcdCodes":
					this.EventCustomerIcdCodes.Add((EventCustomerIcdCodesEntity)relatedEntity);
					break;
				case "EventCustomerNotification":
					this.EventCustomerNotification.Add((EventCustomerNotificationEntity)relatedEntity);
					break;
				case "EventCustomerOrderDetail":
					this.EventCustomerOrderDetail.Add((EventCustomerOrderDetailEntity)relatedEntity);
					break;
				case "EventCustomerPreApprovedPackageTest":
					this.EventCustomerPreApprovedPackageTest.Add((EventCustomerPreApprovedPackageTestEntity)relatedEntity);
					break;
				case "EventCustomerPreApprovedTest":
					this.EventCustomerPreApprovedTest.Add((EventCustomerPreApprovedTestEntity)relatedEntity);
					break;
				case "EventCustomerPrimaryCarePhysician":
					this.EventCustomerPrimaryCarePhysician.Add((EventCustomerPrimaryCarePhysicianEntity)relatedEntity);
					break;
				case "EventCustomerQuestionAnswer":
					this.EventCustomerQuestionAnswer.Add((EventCustomerQuestionAnswerEntity)relatedEntity);
					break;
				case "EventCustomerRequiredTest":
					this.EventCustomerRequiredTest.Add((EventCustomerRequiredTestEntity)relatedEntity);
					break;
				case "EventCustomerRetest":
					this.EventCustomerRetest.Add((EventCustomerRetestEntity)relatedEntity);
					break;
				case "EventCustomerTestNotPerformedNotification":
					this.EventCustomerTestNotPerformedNotification.Add((EventCustomerTestNotPerformedNotificationEntity)relatedEntity);
					break;
				case "ExitInterviewAnswer":
					this.ExitInterviewAnswer.Add((ExitInterviewAnswerEntity)relatedEntity);
					break;
				case "ExitInterviewSignature":
					this.ExitInterviewSignature.Add((ExitInterviewSignatureEntity)relatedEntity);
					break;
				case "FluConsentAnswer":
					this.FluConsentAnswer.Add((FluConsentAnswerEntity)relatedEntity);
					break;
				case "FluConsentSignature":
					this.FluConsentSignature.Add((FluConsentSignatureEntity)relatedEntity);
					break;
				case "ParticipationConsentSignature":
					this.ParticipationConsentSignature.Add((ParticipationConsentSignatureEntity)relatedEntity);
					break;
				case "PcpDisposition":
					this.PcpDisposition.Add((PcpDispositionEntity)relatedEntity);
					break;
				case "PhysicianCustomerAssignment":
					this.PhysicianCustomerAssignment.Add((PhysicianCustomerAssignmentEntity)relatedEntity);
					break;
				case "PhysicianEvaluation":
					this.PhysicianEvaluation.Add((PhysicianEvaluationEntity)relatedEntity);
					break;
				case "PhysicianRecordRequestSignature":
					this.PhysicianRecordRequestSignature.Add((PhysicianRecordRequestSignatureEntity)relatedEntity);
					break;
				case "SurveyAnswer":
					this.SurveyAnswer.Add((SurveyAnswerEntity)relatedEntity);
					break;
				case "CustomerSkipReview":
					SetupSyncCustomerSkipReview(relatedEntity);
					break;
				case "EventCustomerBarrier":
					SetupSyncEventCustomerBarrier(relatedEntity);
					break;
				case "EventCustomerBasicBioMetric":
					SetupSyncEventCustomerBasicBioMetric(relatedEntity);
					break;
				case "EventCustomerEvaluationLock":
					SetupSyncEventCustomerEvaluationLock(relatedEntity);
					break;
				case "EventCustomerResult":
					SetupSyncEventCustomerResult(relatedEntity);
					break;
				case "PcpAppointment_":
					SetupSyncPcpAppointment_(relatedEntity);
					break;
				case "ScreeningAuthorization":
					SetupSyncScreeningAuthorization(relatedEntity);
					break;
				default:
					break;
			}
		}

		/// <summary> Unsets the internal parameter related to the fieldname passed to the instance relatedEntity. Reverses the actions taken by SetRelatedEntity() </summary>
		/// <param name="relatedEntity">Instance to unset as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		/// <param name="signalRelatedEntityManyToOne">if set to true it will notify the manytoone side, if applicable.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void UnsetRelatedEntity(IEntity2 relatedEntity, string fieldName, bool signalRelatedEntityManyToOne)
		{
			switch(fieldName)
			{
				case "AfaffiliateCampaign":
					DesetupSyncAfaffiliateCampaign(false, true);
					break;
				case "Campaign":
					DesetupSyncCampaign(false, true);
					break;
				case "CustomerProfile":
					DesetupSyncCustomerProfile(false, true);
					break;
				case "CustomerProfileHistory":
					DesetupSyncCustomerProfileHistory(false, true);
					break;
				case "CustomerRegistrationNotes":
					DesetupSyncCustomerRegistrationNotes(false, true);
					break;
				case "EventAppointment":
					DesetupSyncEventAppointment(false, true);
					break;
				case "Events":
					DesetupSyncEvents(false, true);
					break;
				case "GcNotGivenReason":
					DesetupSyncGcNotGivenReason(false, true);
					break;
				case "HospitalFacility":
					DesetupSyncHospitalFacility(false, true);
					break;
				case "Lookup_":
					DesetupSyncLookup_(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "OrganizationRoleUser_":
					DesetupSyncOrganizationRoleUser_(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "CallQueueCustomer":
					base.PerformRelatedEntityRemoval(this.CallQueueCustomer, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ChaperoneAnswer":
					base.PerformRelatedEntityRemoval(this.ChaperoneAnswer, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ChaperoneSignature":
					base.PerformRelatedEntityRemoval(this.ChaperoneSignature, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CheckListAnswer":
					base.PerformRelatedEntityRemoval(this.CheckListAnswer, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ClickConversion":
					base.PerformRelatedEntityRemoval(this.ClickConversion, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerHealthInfo":
					base.PerformRelatedEntityRemoval(this.CustomerHealthInfo, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerHealthInfoArchive":
					base.PerformRelatedEntityRemoval(this.CustomerHealthInfoArchive, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerMedicareQuestionAnswer":
					base.PerformRelatedEntityRemoval(this.CustomerMedicareQuestionAnswer, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerOrderHistory":
					base.PerformRelatedEntityRemoval(this.CustomerOrderHistory, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "DependentDisqualifiedTest":
					base.PerformRelatedEntityRemoval(this.DependentDisqualifiedTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "DisqualifiedTest":
					base.PerformRelatedEntityRemoval(this.DisqualifiedTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventAppointmentCancellationLog":
					base.PerformRelatedEntityRemoval(this.EventAppointmentCancellationLog, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventAppointmentChangeLog":
					base.PerformRelatedEntityRemoval(this.EventAppointmentChangeLog, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerCriticalQuestion":
					base.PerformRelatedEntityRemoval(this.EventCustomerCriticalQuestion, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerCurrentMedication":
					base.PerformRelatedEntityRemoval(this.EventCustomerCurrentMedication, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerCustomNotification":
					base.PerformRelatedEntityRemoval(this.EventCustomerCustomNotification, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerDiagnosis":
					base.PerformRelatedEntityRemoval(this.EventCustomerDiagnosis, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerEligibility":
					base.PerformRelatedEntityRemoval(this.EventCustomerEligibility, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerEncounter":
					base.PerformRelatedEntityRemoval(this.EventCustomerEncounter, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerGiftCard":
					base.PerformRelatedEntityRemoval(this.EventCustomerGiftCard, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerIcdCodes":
					base.PerformRelatedEntityRemoval(this.EventCustomerIcdCodes, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerNotification":
					base.PerformRelatedEntityRemoval(this.EventCustomerNotification, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerOrderDetail":
					base.PerformRelatedEntityRemoval(this.EventCustomerOrderDetail, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerPreApprovedPackageTest":
					base.PerformRelatedEntityRemoval(this.EventCustomerPreApprovedPackageTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerPreApprovedTest":
					base.PerformRelatedEntityRemoval(this.EventCustomerPreApprovedTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerPrimaryCarePhysician":
					base.PerformRelatedEntityRemoval(this.EventCustomerPrimaryCarePhysician, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerQuestionAnswer":
					base.PerformRelatedEntityRemoval(this.EventCustomerQuestionAnswer, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerRequiredTest":
					base.PerformRelatedEntityRemoval(this.EventCustomerRequiredTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerRetest":
					base.PerformRelatedEntityRemoval(this.EventCustomerRetest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerTestNotPerformedNotification":
					base.PerformRelatedEntityRemoval(this.EventCustomerTestNotPerformedNotification, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ExitInterviewAnswer":
					base.PerformRelatedEntityRemoval(this.ExitInterviewAnswer, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ExitInterviewSignature":
					base.PerformRelatedEntityRemoval(this.ExitInterviewSignature, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "FluConsentAnswer":
					base.PerformRelatedEntityRemoval(this.FluConsentAnswer, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "FluConsentSignature":
					base.PerformRelatedEntityRemoval(this.FluConsentSignature, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ParticipationConsentSignature":
					base.PerformRelatedEntityRemoval(this.ParticipationConsentSignature, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PcpDisposition":
					base.PerformRelatedEntityRemoval(this.PcpDisposition, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PhysicianCustomerAssignment":
					base.PerformRelatedEntityRemoval(this.PhysicianCustomerAssignment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PhysicianEvaluation":
					base.PerformRelatedEntityRemoval(this.PhysicianEvaluation, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PhysicianRecordRequestSignature":
					base.PerformRelatedEntityRemoval(this.PhysicianRecordRequestSignature, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "SurveyAnswer":
					base.PerformRelatedEntityRemoval(this.SurveyAnswer, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerSkipReview":
					DesetupSyncCustomerSkipReview(false, true);
					break;
				case "EventCustomerBarrier":
					DesetupSyncEventCustomerBarrier(false, true);
					break;
				case "EventCustomerBasicBioMetric":
					DesetupSyncEventCustomerBasicBioMetric(false, true);
					break;
				case "EventCustomerEvaluationLock":
					DesetupSyncEventCustomerEvaluationLock(false, true);
					break;
				case "EventCustomerResult":
					DesetupSyncEventCustomerResult(false, true);
					break;
				case "PcpAppointment_":
					DesetupSyncPcpAppointment_(false, true);
					break;
				case "ScreeningAuthorization":
					DesetupSyncScreeningAuthorization(false, true);
					break;
				default:
					break;
			}
		}

		/// <summary> Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These entities will have to be persisted after this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependingRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			if(_customerSkipReview!=null)
			{
				toReturn.Add(_customerSkipReview);
			}

			if(_eventCustomerBarrier!=null)
			{
				toReturn.Add(_eventCustomerBarrier);
			}

			if(_eventCustomerBasicBioMetric!=null)
			{
				toReturn.Add(_eventCustomerBasicBioMetric);
			}

			if(_eventCustomerEvaluationLock!=null)
			{
				toReturn.Add(_eventCustomerEvaluationLock);
			}

			if(_eventCustomerResult!=null)
			{
				toReturn.Add(_eventCustomerResult);
			}

			if(_pcpAppointment_!=null)
			{
				toReturn.Add(_pcpAppointment_);
			}

			if(_screeningAuthorization!=null)
			{
				toReturn.Add(_screeningAuthorization);
			}

			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			if(_afaffiliateCampaign!=null)
			{
				toReturn.Add(_afaffiliateCampaign);
			}
			if(_campaign!=null)
			{
				toReturn.Add(_campaign);
			}
			if(_customerProfile!=null)
			{
				toReturn.Add(_customerProfile);
			}
			if(_customerProfileHistory!=null)
			{
				toReturn.Add(_customerProfileHistory);
			}
			if(_customerRegistrationNotes!=null)
			{
				toReturn.Add(_customerRegistrationNotes);
			}
			if(_eventAppointment!=null)
			{
				toReturn.Add(_eventAppointment);
			}
			if(_events!=null)
			{
				toReturn.Add(_events);
			}
			if(_gcNotGivenReason!=null)
			{
				toReturn.Add(_gcNotGivenReason);
			}
			if(_hospitalFacility!=null)
			{
				toReturn.Add(_hospitalFacility);
			}
			if(_lookup_!=null)
			{
				toReturn.Add(_lookup_);
			}
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
			}
			if(_organizationRoleUser_!=null)
			{
				toReturn.Add(_organizationRoleUser_);
			}
			if(_organizationRoleUser!=null)
			{
				toReturn.Add(_organizationRoleUser);
			}














			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CallQueueCustomer);
			toReturn.Add(this.ChaperoneAnswer);
			toReturn.Add(this.ChaperoneSignature);
			toReturn.Add(this.CheckListAnswer);
			toReturn.Add(this.ClickConversion);
			toReturn.Add(this.CustomerHealthInfo);
			toReturn.Add(this.CustomerHealthInfoArchive);
			toReturn.Add(this.CustomerMedicareQuestionAnswer);
			toReturn.Add(this.CustomerOrderHistory);
			toReturn.Add(this.DependentDisqualifiedTest);
			toReturn.Add(this.DisqualifiedTest);
			toReturn.Add(this.EventAppointmentCancellationLog);
			toReturn.Add(this.EventAppointmentChangeLog);
			toReturn.Add(this.EventCustomerCriticalQuestion);
			toReturn.Add(this.EventCustomerCurrentMedication);
			toReturn.Add(this.EventCustomerCustomNotification);
			toReturn.Add(this.EventCustomerDiagnosis);
			toReturn.Add(this.EventCustomerEligibility);
			toReturn.Add(this.EventCustomerEncounter);
			toReturn.Add(this.EventCustomerGiftCard);
			toReturn.Add(this.EventCustomerIcdCodes);
			toReturn.Add(this.EventCustomerNotification);
			toReturn.Add(this.EventCustomerOrderDetail);
			toReturn.Add(this.EventCustomerPreApprovedPackageTest);
			toReturn.Add(this.EventCustomerPreApprovedTest);
			toReturn.Add(this.EventCustomerPrimaryCarePhysician);
			toReturn.Add(this.EventCustomerQuestionAnswer);
			toReturn.Add(this.EventCustomerRequiredTest);
			toReturn.Add(this.EventCustomerRetest);
			toReturn.Add(this.EventCustomerTestNotPerformedNotification);
			toReturn.Add(this.ExitInterviewAnswer);
			toReturn.Add(this.ExitInterviewSignature);
			toReturn.Add(this.FluConsentAnswer);
			toReturn.Add(this.FluConsentSignature);
			toReturn.Add(this.ParticipationConsentSignature);
			toReturn.Add(this.PcpDisposition);
			toReturn.Add(this.PhysicianCustomerAssignment);
			toReturn.Add(this.PhysicianEvaluation);
			toReturn.Add(this.PhysicianRecordRequestSignature);
			toReturn.Add(this.SurveyAnswer);

			return toReturn;
		}
		


		/// <summary>ISerializable member. Does custom serialization so event handlers do not get serialized. Serializes members of this entity class and uses the base class' implementation to serialize the rest.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				info.AddValue("_callQueueCustomer", ((_callQueueCustomer!=null) && (_callQueueCustomer.Count>0) && !this.MarkedForDeletion)?_callQueueCustomer:null);
				info.AddValue("_chaperoneAnswer", ((_chaperoneAnswer!=null) && (_chaperoneAnswer.Count>0) && !this.MarkedForDeletion)?_chaperoneAnswer:null);
				info.AddValue("_chaperoneSignature", ((_chaperoneSignature!=null) && (_chaperoneSignature.Count>0) && !this.MarkedForDeletion)?_chaperoneSignature:null);
				info.AddValue("_checkListAnswer", ((_checkListAnswer!=null) && (_checkListAnswer.Count>0) && !this.MarkedForDeletion)?_checkListAnswer:null);
				info.AddValue("_clickConversion", ((_clickConversion!=null) && (_clickConversion.Count>0) && !this.MarkedForDeletion)?_clickConversion:null);
				info.AddValue("_customerHealthInfo", ((_customerHealthInfo!=null) && (_customerHealthInfo.Count>0) && !this.MarkedForDeletion)?_customerHealthInfo:null);
				info.AddValue("_customerHealthInfoArchive", ((_customerHealthInfoArchive!=null) && (_customerHealthInfoArchive.Count>0) && !this.MarkedForDeletion)?_customerHealthInfoArchive:null);
				info.AddValue("_customerMedicareQuestionAnswer", ((_customerMedicareQuestionAnswer!=null) && (_customerMedicareQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_customerMedicareQuestionAnswer:null);
				info.AddValue("_customerOrderHistory", ((_customerOrderHistory!=null) && (_customerOrderHistory.Count>0) && !this.MarkedForDeletion)?_customerOrderHistory:null);
				info.AddValue("_dependentDisqualifiedTest", ((_dependentDisqualifiedTest!=null) && (_dependentDisqualifiedTest.Count>0) && !this.MarkedForDeletion)?_dependentDisqualifiedTest:null);
				info.AddValue("_disqualifiedTest", ((_disqualifiedTest!=null) && (_disqualifiedTest.Count>0) && !this.MarkedForDeletion)?_disqualifiedTest:null);
				info.AddValue("_eventAppointmentCancellationLog", ((_eventAppointmentCancellationLog!=null) && (_eventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_eventAppointmentCancellationLog:null);
				info.AddValue("_eventAppointmentChangeLog", ((_eventAppointmentChangeLog!=null) && (_eventAppointmentChangeLog.Count>0) && !this.MarkedForDeletion)?_eventAppointmentChangeLog:null);
				info.AddValue("_eventCustomerCriticalQuestion", ((_eventCustomerCriticalQuestion!=null) && (_eventCustomerCriticalQuestion.Count>0) && !this.MarkedForDeletion)?_eventCustomerCriticalQuestion:null);
				info.AddValue("_eventCustomerCurrentMedication", ((_eventCustomerCurrentMedication!=null) && (_eventCustomerCurrentMedication.Count>0) && !this.MarkedForDeletion)?_eventCustomerCurrentMedication:null);
				info.AddValue("_eventCustomerCustomNotification", ((_eventCustomerCustomNotification!=null) && (_eventCustomerCustomNotification.Count>0) && !this.MarkedForDeletion)?_eventCustomerCustomNotification:null);
				info.AddValue("_eventCustomerDiagnosis", ((_eventCustomerDiagnosis!=null) && (_eventCustomerDiagnosis.Count>0) && !this.MarkedForDeletion)?_eventCustomerDiagnosis:null);
				info.AddValue("_eventCustomerEligibility", ((_eventCustomerEligibility!=null) && (_eventCustomerEligibility.Count>0) && !this.MarkedForDeletion)?_eventCustomerEligibility:null);
				info.AddValue("_eventCustomerEncounter", ((_eventCustomerEncounter!=null) && (_eventCustomerEncounter.Count>0) && !this.MarkedForDeletion)?_eventCustomerEncounter:null);
				info.AddValue("_eventCustomerGiftCard", ((_eventCustomerGiftCard!=null) && (_eventCustomerGiftCard.Count>0) && !this.MarkedForDeletion)?_eventCustomerGiftCard:null);
				info.AddValue("_eventCustomerIcdCodes", ((_eventCustomerIcdCodes!=null) && (_eventCustomerIcdCodes.Count>0) && !this.MarkedForDeletion)?_eventCustomerIcdCodes:null);
				info.AddValue("_eventCustomerNotification", ((_eventCustomerNotification!=null) && (_eventCustomerNotification.Count>0) && !this.MarkedForDeletion)?_eventCustomerNotification:null);
				info.AddValue("_eventCustomerOrderDetail", ((_eventCustomerOrderDetail!=null) && (_eventCustomerOrderDetail.Count>0) && !this.MarkedForDeletion)?_eventCustomerOrderDetail:null);
				info.AddValue("_eventCustomerPreApprovedPackageTest", ((_eventCustomerPreApprovedPackageTest!=null) && (_eventCustomerPreApprovedPackageTest.Count>0) && !this.MarkedForDeletion)?_eventCustomerPreApprovedPackageTest:null);
				info.AddValue("_eventCustomerPreApprovedTest", ((_eventCustomerPreApprovedTest!=null) && (_eventCustomerPreApprovedTest.Count>0) && !this.MarkedForDeletion)?_eventCustomerPreApprovedTest:null);
				info.AddValue("_eventCustomerPrimaryCarePhysician", ((_eventCustomerPrimaryCarePhysician!=null) && (_eventCustomerPrimaryCarePhysician.Count>0) && !this.MarkedForDeletion)?_eventCustomerPrimaryCarePhysician:null);
				info.AddValue("_eventCustomerQuestionAnswer", ((_eventCustomerQuestionAnswer!=null) && (_eventCustomerQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_eventCustomerQuestionAnswer:null);
				info.AddValue("_eventCustomerRequiredTest", ((_eventCustomerRequiredTest!=null) && (_eventCustomerRequiredTest.Count>0) && !this.MarkedForDeletion)?_eventCustomerRequiredTest:null);
				info.AddValue("_eventCustomerRetest", ((_eventCustomerRetest!=null) && (_eventCustomerRetest.Count>0) && !this.MarkedForDeletion)?_eventCustomerRetest:null);
				info.AddValue("_eventCustomerTestNotPerformedNotification", ((_eventCustomerTestNotPerformedNotification!=null) && (_eventCustomerTestNotPerformedNotification.Count>0) && !this.MarkedForDeletion)?_eventCustomerTestNotPerformedNotification:null);
				info.AddValue("_exitInterviewAnswer", ((_exitInterviewAnswer!=null) && (_exitInterviewAnswer.Count>0) && !this.MarkedForDeletion)?_exitInterviewAnswer:null);
				info.AddValue("_exitInterviewSignature", ((_exitInterviewSignature!=null) && (_exitInterviewSignature.Count>0) && !this.MarkedForDeletion)?_exitInterviewSignature:null);
				info.AddValue("_fluConsentAnswer", ((_fluConsentAnswer!=null) && (_fluConsentAnswer.Count>0) && !this.MarkedForDeletion)?_fluConsentAnswer:null);
				info.AddValue("_fluConsentSignature", ((_fluConsentSignature!=null) && (_fluConsentSignature.Count>0) && !this.MarkedForDeletion)?_fluConsentSignature:null);
				info.AddValue("_participationConsentSignature", ((_participationConsentSignature!=null) && (_participationConsentSignature.Count>0) && !this.MarkedForDeletion)?_participationConsentSignature:null);
				info.AddValue("_pcpDisposition", ((_pcpDisposition!=null) && (_pcpDisposition.Count>0) && !this.MarkedForDeletion)?_pcpDisposition:null);
				info.AddValue("_physicianCustomerAssignment", ((_physicianCustomerAssignment!=null) && (_physicianCustomerAssignment.Count>0) && !this.MarkedForDeletion)?_physicianCustomerAssignment:null);
				info.AddValue("_physicianEvaluation", ((_physicianEvaluation!=null) && (_physicianEvaluation.Count>0) && !this.MarkedForDeletion)?_physicianEvaluation:null);
				info.AddValue("_physicianRecordRequestSignature", ((_physicianRecordRequestSignature!=null) && (_physicianRecordRequestSignature.Count>0) && !this.MarkedForDeletion)?_physicianRecordRequestSignature:null);
				info.AddValue("_surveyAnswer", ((_surveyAnswer!=null) && (_surveyAnswer.Count>0) && !this.MarkedForDeletion)?_surveyAnswer:null);
				info.AddValue("_accountCollectionViaCallQueueCustomer", ((_accountCollectionViaCallQueueCustomer!=null) && (_accountCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_accountCollectionViaCallQueueCustomer:null);
				info.AddValue("_activityTypeCollectionViaCallQueueCustomer", ((_activityTypeCollectionViaCallQueueCustomer!=null) && (_activityTypeCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_activityTypeCollectionViaCallQueueCustomer:null);
				info.AddValue("_callQueueCollectionViaCallQueueCustomer", ((_callQueueCollectionViaCallQueueCustomer!=null) && (_callQueueCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_callQueueCollectionViaCallQueueCustomer:null);
				info.AddValue("_callQueueCriteriaCollectionViaCallQueueCustomer", ((_callQueueCriteriaCollectionViaCallQueueCustomer!=null) && (_callQueueCriteriaCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_callQueueCriteriaCollectionViaCallQueueCustomer:null);
				info.AddValue("_campaignCollectionViaCallQueueCustomer", ((_campaignCollectionViaCallQueueCustomer!=null) && (_campaignCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_campaignCollectionViaCallQueueCustomer:null);
				info.AddValue("_chaperoneQuestionCollectionViaChaperoneAnswer", ((_chaperoneQuestionCollectionViaChaperoneAnswer!=null) && (_chaperoneQuestionCollectionViaChaperoneAnswer.Count>0) && !this.MarkedForDeletion)?_chaperoneQuestionCollectionViaChaperoneAnswer:null);
				info.AddValue("_chargeCardCollectionViaEventCustomerEligibility", ((_chargeCardCollectionViaEventCustomerEligibility!=null) && (_chargeCardCollectionViaEventCustomerEligibility.Count>0) && !this.MarkedForDeletion)?_chargeCardCollectionViaEventCustomerEligibility:null);
				info.AddValue("_checkListQuestionCollectionViaExitInterviewSignature", ((_checkListQuestionCollectionViaExitInterviewSignature!=null) && (_checkListQuestionCollectionViaExitInterviewSignature.Count>0) && !this.MarkedForDeletion)?_checkListQuestionCollectionViaExitInterviewSignature:null);
				info.AddValue("_checkListQuestionCollectionViaCheckListAnswer", ((_checkListQuestionCollectionViaCheckListAnswer!=null) && (_checkListQuestionCollectionViaCheckListAnswer.Count>0) && !this.MarkedForDeletion)?_checkListQuestionCollectionViaCheckListAnswer:null);
				info.AddValue("_clickLogCollectionViaClickConversion", ((_clickLogCollectionViaClickConversion!=null) && (_clickLogCollectionViaClickConversion.Count>0) && !this.MarkedForDeletion)?_clickLogCollectionViaClickConversion:null);
				info.AddValue("_corporateUploadCollectionViaCustomerOrderHistory", ((_corporateUploadCollectionViaCustomerOrderHistory!=null) && (_corporateUploadCollectionViaCustomerOrderHistory.Count>0) && !this.MarkedForDeletion)?_corporateUploadCollectionViaCustomerOrderHistory:null);
				info.AddValue("_criticalQuestionCollectionViaEventCustomerCriticalQuestion", ((_criticalQuestionCollectionViaEventCustomerCriticalQuestion!=null) && (_criticalQuestionCollectionViaEventCustomerCriticalQuestion.Count>0) && !this.MarkedForDeletion)?_criticalQuestionCollectionViaEventCustomerCriticalQuestion:null);
				info.AddValue("_customerHealthQuestionsCollectionViaCustomerHealthInfoArchive", ((_customerHealthQuestionsCollectionViaCustomerHealthInfoArchive!=null) && (_customerHealthQuestionsCollectionViaCustomerHealthInfoArchive.Count>0) && !this.MarkedForDeletion)?_customerHealthQuestionsCollectionViaCustomerHealthInfoArchive:null);
				info.AddValue("_customerHealthQuestionsCollectionViaCustomerHealthInfo", ((_customerHealthQuestionsCollectionViaCustomerHealthInfo!=null) && (_customerHealthQuestionsCollectionViaCustomerHealthInfo.Count>0) && !this.MarkedForDeletion)?_customerHealthQuestionsCollectionViaCustomerHealthInfo:null);
				info.AddValue("_customerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician", ((_customerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician!=null) && (_customerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician.Count>0) && !this.MarkedForDeletion)?_customerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician:null);
				info.AddValue("_customerProfileCollectionViaCustomerHealthInfo", ((_customerProfileCollectionViaCustomerHealthInfo!=null) && (_customerProfileCollectionViaCustomerHealthInfo.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerHealthInfo:null);
				info.AddValue("_customerProfileCollectionViaCallQueueCustomer", ((_customerProfileCollectionViaCallQueueCustomer!=null) && (_customerProfileCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCallQueueCustomer:null);
				info.AddValue("_customerProfileCollectionViaDependentDisqualifiedTest", ((_customerProfileCollectionViaDependentDisqualifiedTest!=null) && (_customerProfileCollectionViaDependentDisqualifiedTest.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaDependentDisqualifiedTest:null);
				info.AddValue("_customerProfileCollectionViaClickConversion", ((_customerProfileCollectionViaClickConversion!=null) && (_customerProfileCollectionViaClickConversion.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaClickConversion:null);
				info.AddValue("_customerProfileCollectionViaDisqualifiedTest", ((_customerProfileCollectionViaDisqualifiedTest!=null) && (_customerProfileCollectionViaDisqualifiedTest.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaDisqualifiedTest:null);
				info.AddValue("_customerProfileCollectionViaCustomerOrderHistory", ((_customerProfileCollectionViaCustomerOrderHistory!=null) && (_customerProfileCollectionViaCustomerOrderHistory.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerOrderHistory:null);
				info.AddValue("_customerProfileCollectionViaCustomerHealthInfoArchive", ((_customerProfileCollectionViaCustomerHealthInfoArchive!=null) && (_customerProfileCollectionViaCustomerHealthInfoArchive.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerHealthInfoArchive:null);
				info.AddValue("_customerProfileCollectionViaEventCustomerQuestionAnswer", ((_customerProfileCollectionViaEventCustomerQuestionAnswer!=null) && (_customerProfileCollectionViaEventCustomerQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaEventCustomerQuestionAnswer:null);
				info.AddValue("_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog", ((_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog!=null) && (_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog:null);
				info.AddValue("_customEventNotificationCollectionViaEventCustomerCustomNotification", ((_customEventNotificationCollectionViaEventCustomerCustomNotification!=null) && (_customEventNotificationCollectionViaEventCustomerCustomNotification.Count>0) && !this.MarkedForDeletion)?_customEventNotificationCollectionViaEventCustomerCustomNotification:null);
				info.AddValue("_eligibilityCollectionViaEventCustomerEligibility", ((_eligibilityCollectionViaEventCustomerEligibility!=null) && (_eligibilityCollectionViaEventCustomerEligibility.Count>0) && !this.MarkedForDeletion)?_eligibilityCollectionViaEventCustomerEligibility:null);
				info.AddValue("_encounterCollectionViaEventCustomerEncounter", ((_encounterCollectionViaEventCustomerEncounter!=null) && (_encounterCollectionViaEventCustomerEncounter.Count>0) && !this.MarkedForDeletion)?_encounterCollectionViaEventCustomerEncounter:null);
				info.AddValue("_eventPackageDetailsCollectionViaCustomerOrderHistory", ((_eventPackageDetailsCollectionViaCustomerOrderHistory!=null) && (_eventPackageDetailsCollectionViaCustomerOrderHistory.Count>0) && !this.MarkedForDeletion)?_eventPackageDetailsCollectionViaCustomerOrderHistory:null);
				info.AddValue("_eventsCollectionViaEventAppointmentChangeLog_", ((_eventsCollectionViaEventAppointmentChangeLog_!=null) && (_eventsCollectionViaEventAppointmentChangeLog_.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventAppointmentChangeLog_:null);
				info.AddValue("_eventsCollectionViaEventAppointmentChangeLog", ((_eventsCollectionViaEventAppointmentChangeLog!=null) && (_eventsCollectionViaEventAppointmentChangeLog.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventAppointmentChangeLog:null);
				info.AddValue("_eventsCollectionViaEventAppointmentCancellationLog", ((_eventsCollectionViaEventAppointmentCancellationLog!=null) && (_eventsCollectionViaEventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventAppointmentCancellationLog:null);
				info.AddValue("_eventsCollectionViaEventCustomerQuestionAnswer", ((_eventsCollectionViaEventCustomerQuestionAnswer!=null) && (_eventsCollectionViaEventCustomerQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventCustomerQuestionAnswer:null);
				info.AddValue("_eventsCollectionViaDependentDisqualifiedTest", ((_eventsCollectionViaDependentDisqualifiedTest!=null) && (_eventsCollectionViaDependentDisqualifiedTest.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaDependentDisqualifiedTest:null);
				info.AddValue("_eventsCollectionViaCustomerOrderHistory", ((_eventsCollectionViaCustomerOrderHistory!=null) && (_eventsCollectionViaCustomerOrderHistory.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaCustomerOrderHistory:null);
				info.AddValue("_eventsCollectionViaDisqualifiedTest", ((_eventsCollectionViaDisqualifiedTest!=null) && (_eventsCollectionViaDisqualifiedTest.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaDisqualifiedTest:null);
				info.AddValue("_eventsCollectionViaCallQueueCustomer", ((_eventsCollectionViaCallQueueCustomer!=null) && (_eventsCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaCallQueueCustomer:null);
				info.AddValue("_eventTestCollectionViaCustomerOrderHistory", ((_eventTestCollectionViaCustomerOrderHistory!=null) && (_eventTestCollectionViaCustomerOrderHistory.Count>0) && !this.MarkedForDeletion)?_eventTestCollectionViaCustomerOrderHistory:null);
				info.AddValue("_exitInterviewQuestionCollectionViaExitInterviewAnswer", ((_exitInterviewQuestionCollectionViaExitInterviewAnswer!=null) && (_exitInterviewQuestionCollectionViaExitInterviewAnswer.Count>0) && !this.MarkedForDeletion)?_exitInterviewQuestionCollectionViaExitInterviewAnswer:null);
				info.AddValue("_fileCollectionViaParticipationConsentSignature_", ((_fileCollectionViaParticipationConsentSignature_!=null) && (_fileCollectionViaParticipationConsentSignature_.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaParticipationConsentSignature_:null);
				info.AddValue("_fileCollectionViaParticipationConsentSignature", ((_fileCollectionViaParticipationConsentSignature!=null) && (_fileCollectionViaParticipationConsentSignature.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaParticipationConsentSignature:null);
				info.AddValue("_fileCollectionViaEventCustomerGiftCard", ((_fileCollectionViaEventCustomerGiftCard!=null) && (_fileCollectionViaEventCustomerGiftCard.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaEventCustomerGiftCard:null);
				info.AddValue("_fileCollectionViaEventCustomerGiftCard_", ((_fileCollectionViaEventCustomerGiftCard_!=null) && (_fileCollectionViaEventCustomerGiftCard_.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaEventCustomerGiftCard_:null);
				info.AddValue("_fileCollectionViaFluConsentSignature_", ((_fileCollectionViaFluConsentSignature_!=null) && (_fileCollectionViaFluConsentSignature_.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaFluConsentSignature_:null);
				info.AddValue("_fileCollectionViaPhysicianRecordRequestSignature", ((_fileCollectionViaPhysicianRecordRequestSignature!=null) && (_fileCollectionViaPhysicianRecordRequestSignature.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaPhysicianRecordRequestSignature:null);
				info.AddValue("_fileCollectionViaChaperoneSignature", ((_fileCollectionViaChaperoneSignature!=null) && (_fileCollectionViaChaperoneSignature.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaChaperoneSignature:null);
				info.AddValue("_fileCollectionViaExitInterviewSignature", ((_fileCollectionViaExitInterviewSignature!=null) && (_fileCollectionViaExitInterviewSignature.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaExitInterviewSignature:null);
				info.AddValue("_fileCollectionViaChaperoneSignature_", ((_fileCollectionViaChaperoneSignature_!=null) && (_fileCollectionViaChaperoneSignature_.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaChaperoneSignature_:null);
				info.AddValue("_fileCollectionViaFluConsentSignature", ((_fileCollectionViaFluConsentSignature!=null) && (_fileCollectionViaFluConsentSignature.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaFluConsentSignature:null);
				info.AddValue("_fluConsentQuestionCollectionViaFluConsentAnswer", ((_fluConsentQuestionCollectionViaFluConsentAnswer!=null) && (_fluConsentQuestionCollectionViaFluConsentAnswer.Count>0) && !this.MarkedForDeletion)?_fluConsentQuestionCollectionViaFluConsentAnswer:null);
				info.AddValue("_icdCodesCollectionViaEventCustomerIcdCodes", ((_icdCodesCollectionViaEventCustomerIcdCodes!=null) && (_icdCodesCollectionViaEventCustomerIcdCodes.Count>0) && !this.MarkedForDeletion)?_icdCodesCollectionViaEventCustomerIcdCodes:null);
				info.AddValue("_languageCollectionViaCallQueueCustomer", ((_languageCollectionViaCallQueueCustomer!=null) && (_languageCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_languageCollectionViaCallQueueCustomer:null);
				info.AddValue("_lookupCollectionViaCustomerOrderHistory", ((_lookupCollectionViaCustomerOrderHistory!=null) && (_lookupCollectionViaCustomerOrderHistory.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerOrderHistory:null);
				info.AddValue("_lookupCollectionViaCallQueueCustomer", ((_lookupCollectionViaCallQueueCustomer!=null) && (_lookupCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCallQueueCustomer:null);
				info.AddValue("_lookupCollectionViaEventAppointmentChangeLog", ((_lookupCollectionViaEventAppointmentChangeLog!=null) && (_lookupCollectionViaEventAppointmentChangeLog.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventAppointmentChangeLog:null);
				info.AddValue("_lookupCollectionViaCheckListAnswer", ((_lookupCollectionViaCheckListAnswer!=null) && (_lookupCollectionViaCheckListAnswer.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCheckListAnswer:null);
				info.AddValue("_lookupCollectionViaPcpDisposition", ((_lookupCollectionViaPcpDisposition!=null) && (_lookupCollectionViaPcpDisposition.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaPcpDisposition:null);
				info.AddValue("_lookupCollectionViaEventAppointmentCancellationLog", ((_lookupCollectionViaEventAppointmentCancellationLog!=null) && (_lookupCollectionViaEventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventAppointmentCancellationLog:null);
				info.AddValue("_medicareQuestionCollectionViaCustomerMedicareQuestionAnswer", ((_medicareQuestionCollectionViaCustomerMedicareQuestionAnswer!=null) && (_medicareQuestionCollectionViaCustomerMedicareQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_medicareQuestionCollectionViaCustomerMedicareQuestionAnswer:null);
				info.AddValue("_ndcCollectionViaEventCustomerCurrentMedication", ((_ndcCollectionViaEventCustomerCurrentMedication!=null) && (_ndcCollectionViaEventCustomerCurrentMedication.Count>0) && !this.MarkedForDeletion)?_ndcCollectionViaEventCustomerCurrentMedication:null);
				info.AddValue("_notesDetailsCollectionViaCallQueueCustomer", ((_notesDetailsCollectionViaCallQueueCustomer!=null) && (_notesDetailsCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_notesDetailsCollectionViaCallQueueCustomer:null);
				info.AddValue("_notificationCollectionViaEventCustomerNotification", ((_notificationCollectionViaEventCustomerNotification!=null) && (_notificationCollectionViaEventCustomerNotification.Count>0) && !this.MarkedForDeletion)?_notificationCollectionViaEventCustomerNotification:null);
				info.AddValue("_notificationTypeCollectionViaEventCustomerTestNotPerformedNotification", ((_notificationTypeCollectionViaEventCustomerTestNotPerformedNotification!=null) && (_notificationTypeCollectionViaEventCustomerTestNotPerformedNotification.Count>0) && !this.MarkedForDeletion)?_notificationTypeCollectionViaEventCustomerTestNotPerformedNotification:null);
				info.AddValue("_notificationTypeCollectionViaEventCustomerNotification", ((_notificationTypeCollectionViaEventCustomerNotification!=null) && (_notificationTypeCollectionViaEventCustomerNotification.Count>0) && !this.MarkedForDeletion)?_notificationTypeCollectionViaEventCustomerNotification:null);
				info.AddValue("_orderDetailCollectionViaEventCustomerOrderDetail", ((_orderDetailCollectionViaEventCustomerOrderDetail!=null) && (_orderDetailCollectionViaEventCustomerOrderDetail.Count>0) && !this.MarkedForDeletion)?_orderDetailCollectionViaEventCustomerOrderDetail:null);
				info.AddValue("_organizationRoleUserCollectionViaExitInterviewAnswer_", ((_organizationRoleUserCollectionViaExitInterviewAnswer_!=null) && (_organizationRoleUserCollectionViaExitInterviewAnswer_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaExitInterviewAnswer_:null);
				info.AddValue("_organizationRoleUserCollectionViaParticipationConsentSignature", ((_organizationRoleUserCollectionViaParticipationConsentSignature!=null) && (_organizationRoleUserCollectionViaParticipationConsentSignature.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaParticipationConsentSignature:null);
				info.AddValue("_organizationRoleUserCollectionViaFluConsentSignature", ((_organizationRoleUserCollectionViaFluConsentSignature!=null) && (_organizationRoleUserCollectionViaFluConsentSignature.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaFluConsentSignature:null);
				info.AddValue("_organizationRoleUserCollectionViaPcpDisposition_", ((_organizationRoleUserCollectionViaPcpDisposition_!=null) && (_organizationRoleUserCollectionViaPcpDisposition_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaPcpDisposition_:null);
				info.AddValue("_organizationRoleUserCollectionViaPcpDisposition", ((_organizationRoleUserCollectionViaPcpDisposition!=null) && (_organizationRoleUserCollectionViaPcpDisposition.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaPcpDisposition:null);
				info.AddValue("_organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician", ((_organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician!=null) && (_organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician:null);
				info.AddValue("_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification", ((_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification!=null) && (_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification:null);
				info.AddValue("_organizationRoleUserCollectionViaEventCustomerRetest", ((_organizationRoleUserCollectionViaEventCustomerRetest!=null) && (_organizationRoleUserCollectionViaEventCustomerRetest.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventCustomerRetest:null);
				info.AddValue("_organizationRoleUserCollectionViaExitInterviewAnswer", ((_organizationRoleUserCollectionViaExitInterviewAnswer!=null) && (_organizationRoleUserCollectionViaExitInterviewAnswer.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaExitInterviewAnswer:null);
				info.AddValue("_organizationRoleUserCollectionViaExitInterviewSignature", ((_organizationRoleUserCollectionViaExitInterviewSignature!=null) && (_organizationRoleUserCollectionViaExitInterviewSignature.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaExitInterviewSignature:null);
				info.AddValue("_organizationRoleUserCollectionViaFluConsentAnswer_", ((_organizationRoleUserCollectionViaFluConsentAnswer_!=null) && (_organizationRoleUserCollectionViaFluConsentAnswer_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaFluConsentAnswer_:null);
				info.AddValue("_organizationRoleUserCollectionViaEventCustomerQuestionAnswer", ((_organizationRoleUserCollectionViaEventCustomerQuestionAnswer!=null) && (_organizationRoleUserCollectionViaEventCustomerQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventCustomerQuestionAnswer:null);
				info.AddValue("_organizationRoleUserCollectionViaEventCustomerQuestionAnswer_", ((_organizationRoleUserCollectionViaEventCustomerQuestionAnswer_!=null) && (_organizationRoleUserCollectionViaEventCustomerQuestionAnswer_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventCustomerQuestionAnswer_:null);
				info.AddValue("_organizationRoleUserCollectionViaFluConsentAnswer", ((_organizationRoleUserCollectionViaFluConsentAnswer!=null) && (_organizationRoleUserCollectionViaFluConsentAnswer.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaFluConsentAnswer:null);
				info.AddValue("_organizationRoleUserCollectionViaChaperoneSignature", ((_organizationRoleUserCollectionViaChaperoneSignature!=null) && (_organizationRoleUserCollectionViaChaperoneSignature.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaChaperoneSignature:null);
				info.AddValue("_organizationRoleUserCollectionViaSurveyAnswer", ((_organizationRoleUserCollectionViaSurveyAnswer!=null) && (_organizationRoleUserCollectionViaSurveyAnswer.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaSurveyAnswer:null);
				info.AddValue("_organizationRoleUserCollectionViaDisqualifiedTest_", ((_organizationRoleUserCollectionViaDisqualifiedTest_!=null) && (_organizationRoleUserCollectionViaDisqualifiedTest_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaDisqualifiedTest_:null);
				info.AddValue("_organizationRoleUserCollectionViaEventAppointmentChangeLog", ((_organizationRoleUserCollectionViaEventAppointmentChangeLog!=null) && (_organizationRoleUserCollectionViaEventAppointmentChangeLog.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventAppointmentChangeLog:null);
				info.AddValue("_organizationRoleUserCollectionViaChaperoneAnswer_", ((_organizationRoleUserCollectionViaChaperoneAnswer_!=null) && (_organizationRoleUserCollectionViaChaperoneAnswer_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaChaperoneAnswer_:null);
				info.AddValue("_organizationRoleUserCollectionViaEventAppointmentCancellationLog", ((_organizationRoleUserCollectionViaEventAppointmentCancellationLog!=null) && (_organizationRoleUserCollectionViaEventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventAppointmentCancellationLog:null);
				info.AddValue("_organizationRoleUserCollectionViaCheckListAnswer_", ((_organizationRoleUserCollectionViaCheckListAnswer_!=null) && (_organizationRoleUserCollectionViaCheckListAnswer_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCheckListAnswer_:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerHealthInfo", ((_organizationRoleUserCollectionViaCustomerHealthInfo!=null) && (_organizationRoleUserCollectionViaCustomerHealthInfo.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerHealthInfo:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerHealthInfoArchive", ((_organizationRoleUserCollectionViaCustomerHealthInfoArchive!=null) && (_organizationRoleUserCollectionViaCustomerHealthInfoArchive.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerHealthInfoArchive:null);
				info.AddValue("_organizationRoleUserCollectionViaDisqualifiedTest", ((_organizationRoleUserCollectionViaDisqualifiedTest!=null) && (_organizationRoleUserCollectionViaDisqualifiedTest.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaDisqualifiedTest:null);
				info.AddValue("_organizationRoleUserCollectionViaCheckListAnswer", ((_organizationRoleUserCollectionViaCheckListAnswer!=null) && (_organizationRoleUserCollectionViaCheckListAnswer.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCheckListAnswer:null);
				info.AddValue("_organizationRoleUserCollectionViaSurveyAnswer_", ((_organizationRoleUserCollectionViaSurveyAnswer_!=null) && (_organizationRoleUserCollectionViaSurveyAnswer_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaSurveyAnswer_:null);
				info.AddValue("_organizationRoleUserCollectionViaChaperoneAnswer", ((_organizationRoleUserCollectionViaChaperoneAnswer!=null) && (_organizationRoleUserCollectionViaChaperoneAnswer.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaChaperoneAnswer:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueCustomer__", ((_organizationRoleUserCollectionViaCallQueueCustomer__!=null) && (_organizationRoleUserCollectionViaCallQueueCustomer__.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueCustomer__:null);
				info.AddValue("_organizationRoleUserCollectionViaEventCustomerGiftCard", ((_organizationRoleUserCollectionViaEventCustomerGiftCard!=null) && (_organizationRoleUserCollectionViaEventCustomerGiftCard.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventCustomerGiftCard:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueCustomer", ((_organizationRoleUserCollectionViaCallQueueCustomer!=null) && (_organizationRoleUserCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueCustomer:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueCustomer_", ((_organizationRoleUserCollectionViaCallQueueCustomer_!=null) && (_organizationRoleUserCollectionViaCallQueueCustomer_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueCustomer_:null);
				info.AddValue("_organizationRoleUserCollectionViaPhysicianRecordRequestSignature", ((_organizationRoleUserCollectionViaPhysicianRecordRequestSignature!=null) && (_organizationRoleUserCollectionViaPhysicianRecordRequestSignature.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaPhysicianRecordRequestSignature:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer", ((_organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer!=null) && (_organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer:null);
				info.AddValue("_packageCollectionViaEventCustomerPreApprovedPackageTest", ((_packageCollectionViaEventCustomerPreApprovedPackageTest!=null) && (_packageCollectionViaEventCustomerPreApprovedPackageTest.Count>0) && !this.MarkedForDeletion)?_packageCollectionViaEventCustomerPreApprovedPackageTest:null);
				info.AddValue("_physicianProfileCollectionViaPhysicianEvaluation", ((_physicianProfileCollectionViaPhysicianEvaluation!=null) && (_physicianProfileCollectionViaPhysicianEvaluation.Count>0) && !this.MarkedForDeletion)?_physicianProfileCollectionViaPhysicianEvaluation:null);
				info.AddValue("_physicianProfileCollectionViaPhysicianCustomerAssignment_", ((_physicianProfileCollectionViaPhysicianCustomerAssignment_!=null) && (_physicianProfileCollectionViaPhysicianCustomerAssignment_.Count>0) && !this.MarkedForDeletion)?_physicianProfileCollectionViaPhysicianCustomerAssignment_:null);
				info.AddValue("_physicianProfileCollectionViaPhysicianCustomerAssignment", ((_physicianProfileCollectionViaPhysicianCustomerAssignment!=null) && (_physicianProfileCollectionViaPhysicianCustomerAssignment.Count>0) && !this.MarkedForDeletion)?_physicianProfileCollectionViaPhysicianCustomerAssignment:null);
				info.AddValue("_preQualificationQuestionCollectionViaEventCustomerQuestionAnswer", ((_preQualificationQuestionCollectionViaEventCustomerQuestionAnswer!=null) && (_preQualificationQuestionCollectionViaEventCustomerQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_preQualificationQuestionCollectionViaEventCustomerQuestionAnswer:null);
				info.AddValue("_preQualificationQuestionCollectionViaDisqualifiedTest", ((_preQualificationQuestionCollectionViaDisqualifiedTest!=null) && (_preQualificationQuestionCollectionViaDisqualifiedTest.Count>0) && !this.MarkedForDeletion)?_preQualificationQuestionCollectionViaDisqualifiedTest:null);
				info.AddValue("_prospectCustomerCollectionViaClickConversion", ((_prospectCustomerCollectionViaClickConversion!=null) && (_prospectCustomerCollectionViaClickConversion.Count>0) && !this.MarkedForDeletion)?_prospectCustomerCollectionViaClickConversion:null);
				info.AddValue("_prospectCustomerCollectionViaCallQueueCustomer", ((_prospectCustomerCollectionViaCallQueueCustomer!=null) && (_prospectCustomerCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_prospectCustomerCollectionViaCallQueueCustomer:null);
				info.AddValue("_refundRequestCollectionViaEventAppointmentCancellationLog", ((_refundRequestCollectionViaEventAppointmentCancellationLog!=null) && (_refundRequestCollectionViaEventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_refundRequestCollectionViaEventAppointmentCancellationLog:null);
				info.AddValue("_rescheduleCancelDispositionCollectionViaEventAppointmentChangeLog", ((_rescheduleCancelDispositionCollectionViaEventAppointmentChangeLog!=null) && (_rescheduleCancelDispositionCollectionViaEventAppointmentChangeLog.Count>0) && !this.MarkedForDeletion)?_rescheduleCancelDispositionCollectionViaEventAppointmentChangeLog:null);
				info.AddValue("_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog", ((_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog!=null) && (_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog:null);
				info.AddValue("_surveyQuestionCollectionViaSurveyAnswer", ((_surveyQuestionCollectionViaSurveyAnswer!=null) && (_surveyQuestionCollectionViaSurveyAnswer.Count>0) && !this.MarkedForDeletion)?_surveyQuestionCollectionViaSurveyAnswer:null);
				info.AddValue("_testCollectionViaEventCustomerPreApprovedPackageTest", ((_testCollectionViaEventCustomerPreApprovedPackageTest!=null) && (_testCollectionViaEventCustomerPreApprovedPackageTest.Count>0) && !this.MarkedForDeletion)?_testCollectionViaEventCustomerPreApprovedPackageTest:null);
				info.AddValue("_testCollectionViaDisqualifiedTest", ((_testCollectionViaDisqualifiedTest!=null) && (_testCollectionViaDisqualifiedTest.Count>0) && !this.MarkedForDeletion)?_testCollectionViaDisqualifiedTest:null);
				info.AddValue("_testCollectionViaDependentDisqualifiedTest", ((_testCollectionViaDependentDisqualifiedTest!=null) && (_testCollectionViaDependentDisqualifiedTest.Count>0) && !this.MarkedForDeletion)?_testCollectionViaDependentDisqualifiedTest:null);
				info.AddValue("_testCollectionViaEventCustomerRetest", ((_testCollectionViaEventCustomerRetest!=null) && (_testCollectionViaEventCustomerRetest.Count>0) && !this.MarkedForDeletion)?_testCollectionViaEventCustomerRetest:null);
				info.AddValue("_testCollectionViaEventCustomerTestNotPerformedNotification", ((_testCollectionViaEventCustomerTestNotPerformedNotification!=null) && (_testCollectionViaEventCustomerTestNotPerformedNotification.Count>0) && !this.MarkedForDeletion)?_testCollectionViaEventCustomerTestNotPerformedNotification:null);
				info.AddValue("_testCollectionViaEventCustomerPreApprovedTest", ((_testCollectionViaEventCustomerPreApprovedTest!=null) && (_testCollectionViaEventCustomerPreApprovedTest.Count>0) && !this.MarkedForDeletion)?_testCollectionViaEventCustomerPreApprovedTest:null);
				info.AddValue("_testCollectionViaEventCustomerRequiredTest", ((_testCollectionViaEventCustomerRequiredTest!=null) && (_testCollectionViaEventCustomerRequiredTest.Count>0) && !this.MarkedForDeletion)?_testCollectionViaEventCustomerRequiredTest:null);
				info.AddValue("_afaffiliateCampaign", (!this.MarkedForDeletion?_afaffiliateCampaign:null));
				info.AddValue("_campaign", (!this.MarkedForDeletion?_campaign:null));
				info.AddValue("_customerProfile", (!this.MarkedForDeletion?_customerProfile:null));
				info.AddValue("_customerProfileHistory", (!this.MarkedForDeletion?_customerProfileHistory:null));
				info.AddValue("_customerRegistrationNotes", (!this.MarkedForDeletion?_customerRegistrationNotes:null));
				info.AddValue("_eventAppointment", (!this.MarkedForDeletion?_eventAppointment:null));
				info.AddValue("_events", (!this.MarkedForDeletion?_events:null));
				info.AddValue("_gcNotGivenReason", (!this.MarkedForDeletion?_gcNotGivenReason:null));
				info.AddValue("_hospitalFacility", (!this.MarkedForDeletion?_hospitalFacility:null));
				info.AddValue("_lookup_", (!this.MarkedForDeletion?_lookup_:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_organizationRoleUser_", (!this.MarkedForDeletion?_organizationRoleUser_:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));
				info.AddValue("_customerSkipReview", (!this.MarkedForDeletion?_customerSkipReview:null));
				info.AddValue("_eventCustomerBarrier", (!this.MarkedForDeletion?_eventCustomerBarrier:null));
				info.AddValue("_eventCustomerBasicBioMetric", (!this.MarkedForDeletion?_eventCustomerBasicBioMetric:null));
				info.AddValue("_eventCustomerEvaluationLock", (!this.MarkedForDeletion?_eventCustomerEvaluationLock:null));
				info.AddValue("_eventCustomerResult", (!this.MarkedForDeletion?_eventCustomerResult:null));
				info.AddValue("_pcpAppointment_", (!this.MarkedForDeletion?_pcpAppointment_:null));
				info.AddValue("_screeningAuthorization", (!this.MarkedForDeletion?_screeningAuthorization:null));
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(EventCustomersFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(EventCustomersFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new EventCustomersRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCustomerFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChaperoneAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChaperoneAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaperoneAnswerFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChaperoneSignature' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChaperoneSignature()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaperoneSignatureFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListAnswerFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ClickConversion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoClickConversion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ClickConversionFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerHealthInfo' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerHealthInfo()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthInfoFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerHealthInfoArchive' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerHealthInfoArchive()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthInfoArchiveFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerMedicareQuestionAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerMedicareQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerMedicareQuestionAnswerFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerOrderHistory' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerOrderHistoryFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DependentDisqualifiedTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDependentDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DependentDisqualifiedTestFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DisqualifiedTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DisqualifiedTestFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventAppointmentCancellationLog' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventAppointmentCancellationLogFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventAppointmentChangeLog' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventAppointmentChangeLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventAppointmentChangeLogFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerCriticalQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerCriticalQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerCriticalQuestionFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerCurrentMedication' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerCurrentMedication()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerCurrentMedicationFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerCustomNotification' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerCustomNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerCustomNotificationFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerDiagnosis' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerDiagnosis()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerDiagnosisFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerEligibility' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerEligibility()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerEligibilityFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerEncounter' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerEncounter()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerEncounterFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerGiftCard' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerGiftCard()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerGiftCardFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerIcdCodes' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerIcdCodes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerIcdCodesFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerNotification' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerNotificationFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerOrderDetail' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerOrderDetail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerOrderDetailFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerPreApprovedPackageTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerPreApprovedPackageTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerPreApprovedPackageTestFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerPreApprovedTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerPreApprovedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerPreApprovedTestFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerPrimaryCarePhysician' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerPrimaryCarePhysician()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerPrimaryCarePhysicianFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerQuestionAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerQuestionAnswerFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerRequiredTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerRequiredTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerRequiredTestFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerRetest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerRetest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerRetestFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerTestNotPerformedNotification' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerTestNotPerformedNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerTestNotPerformedNotificationFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ExitInterviewAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoExitInterviewAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ExitInterviewAnswerFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ExitInterviewSignature' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoExitInterviewSignature()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ExitInterviewSignatureFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FluConsentAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFluConsentAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentAnswerFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FluConsentSignature' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFluConsentSignature()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentSignatureFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ParticipationConsentSignature' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoParticipationConsentSignature()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ParticipationConsentSignatureFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PcpDisposition' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPcpDisposition()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PcpDispositionFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianCustomerAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianCustomerAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianCustomerAssignmentFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianEvaluation' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianEvaluation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianEvaluationFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianRecordRequestSignature' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianRecordRequestSignature()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianRecordRequestSignatureFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SurveyAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSurveyAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SurveyAnswerFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AccountCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ActivityType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActivityTypeCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ActivityTypeCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCriteria' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCriteriaCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCriteriaCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Campaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CampaignCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChaperoneQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChaperoneQuestionCollectionViaChaperoneAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ChaperoneQuestionCollectionViaChaperoneAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChargeCard' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChargeCardCollectionViaEventCustomerEligibility()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ChargeCardCollectionViaEventCustomerEligibility"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListQuestionCollectionViaExitInterviewSignature()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckListQuestionCollectionViaExitInterviewSignature"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListQuestionCollectionViaCheckListAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckListQuestionCollectionViaCheckListAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ClickLog' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoClickLogCollectionViaClickConversion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ClickLogCollectionViaClickConversion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CorporateUpload' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCorporateUploadCollectionViaCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CorporateUploadCollectionViaCustomerOrderHistory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CriticalQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCriticalQuestionCollectionViaEventCustomerCriticalQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CriticalQuestionCollectionViaEventCustomerCriticalQuestion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerHealthQuestions' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerHealthQuestionsCollectionViaCustomerHealthInfoArchive()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerHealthQuestionsCollectionViaCustomerHealthInfoArchive"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerHealthQuestions' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerHealthQuestionsCollectionViaCustomerHealthInfo()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerHealthQuestionsCollectionViaCustomerHealthInfo"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerPrimaryCarePhysician' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerHealthInfo()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerHealthInfo"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaDependentDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaDependentDisqualifiedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaClickConversion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaClickConversion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaDisqualifiedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerOrderHistory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerHealthInfoArchive()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerHealthInfoArchive"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaEventCustomerQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaEventCustomerQuestionAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerRegistrationNotes' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomEventNotification' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomEventNotificationCollectionViaEventCustomerCustomNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomEventNotificationCollectionViaEventCustomerCustomNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Eligibility' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEligibilityCollectionViaEventCustomerEligibility()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EligibilityCollectionViaEventCustomerEligibility"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Encounter' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEncounterCollectionViaEventCustomerEncounter()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EncounterCollectionViaEventCustomerEncounter"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventPackageDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventPackageDetailsCollectionViaCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventPackageDetailsCollectionViaCustomerOrderHistory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventAppointmentChangeLog_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventAppointmentChangeLog_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventAppointmentChangeLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventAppointmentChangeLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventAppointmentCancellationLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventCustomerQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventCustomerQuestionAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaDependentDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaDependentDisqualifiedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaCustomerOrderHistory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaDisqualifiedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventTestCollectionViaCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventTestCollectionViaCustomerOrderHistory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ExitInterviewQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoExitInterviewQuestionCollectionViaExitInterviewAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ExitInterviewQuestionCollectionViaExitInterviewAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaParticipationConsentSignature_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaParticipationConsentSignature_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaParticipationConsentSignature()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaParticipationConsentSignature"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaEventCustomerGiftCard()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaEventCustomerGiftCard"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaEventCustomerGiftCard_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaEventCustomerGiftCard_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaFluConsentSignature_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaFluConsentSignature_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaPhysicianRecordRequestSignature()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaPhysicianRecordRequestSignature"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaChaperoneSignature()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaChaperoneSignature"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaExitInterviewSignature()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaExitInterviewSignature"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaChaperoneSignature_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaChaperoneSignature_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaFluConsentSignature()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaFluConsentSignature"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FluConsentQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFluConsentQuestionCollectionViaFluConsentAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FluConsentQuestionCollectionViaFluConsentAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'IcdCodes' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoIcdCodesCollectionViaEventCustomerIcdCodes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("IcdCodesCollectionViaEventCustomerIcdCodes"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Language' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLanguageCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LanguageCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerOrderHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerOrderHistory"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventAppointmentChangeLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventAppointmentChangeLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCheckListAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCheckListAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaPcpDisposition()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaPcpDisposition"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventAppointmentCancellationLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MedicareQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicareQuestionCollectionViaCustomerMedicareQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("MedicareQuestionCollectionViaCustomerMedicareQuestionAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Ndc' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNdcCollectionViaEventCustomerCurrentMedication()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("NdcCollectionViaEventCustomerCurrentMedication"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'NotesDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotesDetailsCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("NotesDetailsCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Notification' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotificationCollectionViaEventCustomerNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("NotificationCollectionViaEventCustomerNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'NotificationType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotificationTypeCollectionViaEventCustomerTestNotPerformedNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("NotificationTypeCollectionViaEventCustomerTestNotPerformedNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'NotificationType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotificationTypeCollectionViaEventCustomerNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("NotificationTypeCollectionViaEventCustomerNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrderDetail' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrderDetailCollectionViaEventCustomerOrderDetail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrderDetailCollectionViaEventCustomerOrderDetail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaExitInterviewAnswer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaExitInterviewAnswer_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaParticipationConsentSignature()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaParticipationConsentSignature"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaFluConsentSignature()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaFluConsentSignature"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaPcpDisposition_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaPcpDisposition_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaPcpDisposition()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaPcpDisposition"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventCustomerRetest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventCustomerRetest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaExitInterviewAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaExitInterviewAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaExitInterviewSignature()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaExitInterviewSignature"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaFluConsentAnswer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaFluConsentAnswer_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventCustomerQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaFluConsentAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaFluConsentAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaChaperoneSignature()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaChaperoneSignature"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaSurveyAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaSurveyAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaDisqualifiedTest_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaDisqualifiedTest_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventAppointmentChangeLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventAppointmentChangeLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaChaperoneAnswer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaChaperoneAnswer_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventAppointmentCancellationLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCheckListAnswer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCheckListAnswer_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerHealthInfo()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerHealthInfo"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerHealthInfoArchive()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerHealthInfoArchive"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaDisqualifiedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCheckListAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCheckListAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaSurveyAnswer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaSurveyAnswer_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaChaperoneAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaChaperoneAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueCustomer__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueCustomer__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventCustomerGiftCard()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventCustomerGiftCard"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueCustomer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueCustomer_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaPhysicianRecordRequestSignature()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaPhysicianRecordRequestSignature"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Package' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPackageCollectionViaEventCustomerPreApprovedPackageTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PackageCollectionViaEventCustomerPreApprovedPackageTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianProfileCollectionViaPhysicianEvaluation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PhysicianProfileCollectionViaPhysicianEvaluation"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianProfileCollectionViaPhysicianCustomerAssignment_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PhysicianProfileCollectionViaPhysicianCustomerAssignment_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianProfileCollectionViaPhysicianCustomerAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PhysicianProfileCollectionViaPhysicianCustomerAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PreQualificationQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPreQualificationQuestionCollectionViaEventCustomerQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PreQualificationQuestionCollectionViaEventCustomerQuestionAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PreQualificationQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPreQualificationQuestionCollectionViaDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PreQualificationQuestionCollectionViaDisqualifiedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectCustomerCollectionViaClickConversion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectCustomerCollectionViaClickConversion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectCustomerCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectCustomerCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'RefundRequest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRefundRequestCollectionViaEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("RefundRequestCollectionViaEventAppointmentCancellationLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'RescheduleCancelDisposition' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRescheduleCancelDispositionCollectionViaEventAppointmentChangeLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("RescheduleCancelDispositionCollectionViaEventAppointmentChangeLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'RescheduleCancelDisposition' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SurveyQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSurveyQuestionCollectionViaSurveyAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("SurveyQuestionCollectionViaSurveyAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaEventCustomerPreApprovedPackageTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaEventCustomerPreApprovedPackageTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaDisqualifiedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaDependentDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaDependentDisqualifiedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaEventCustomerRetest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaEventCustomerRetest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaEventCustomerTestNotPerformedNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaEventCustomerTestNotPerformedNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaEventCustomerPreApprovedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaEventCustomerPreApprovedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaEventCustomerRequiredTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaEventCustomerRequiredTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId, "EventCustomersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'AfaffiliateCampaign' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfaffiliateCampaign()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfaffiliateCampaignFields.AffiliateCampaignId, null, ComparisonOperator.Equal, this.AffiliateCampaignId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Campaign' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaign()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.CampaignId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileFields.CustomerId, null, ComparisonOperator.Equal, this.CustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerProfileHistory' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileHistoryFields.Id, null, ComparisonOperator.Equal, this.CustomerProfileHistoryId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerRegistrationNotes' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerRegistrationNotes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerRegistrationNotesFields.CustomerRegistrationNotesId, null, ComparisonOperator.Equal, this.LeftWithoutScreeningNotesId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'EventAppointment' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventAppointment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventAppointmentFields.AppointmentId, null, ComparisonOperator.Equal, this.AppointmentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Events' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventsFields.EventId, null, ComparisonOperator.Equal, this.EventId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GcNotGivenReason' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGcNotGivenReason()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GcNotGivenReasonFields.Id, null, ComparisonOperator.Equal, this.GcNotGivenReasonId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'HospitalFacility' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHospitalFacility()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HospitalFacilityFields.HospitalFacilityId, null, ComparisonOperator.Equal, this.HospitalFacilityId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.PreferredContactType));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.LeftWithoutScreeningReasonId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.ConfirmedBy));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.CreatedByOrgRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerSkipReview' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerSkipReview()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerSkipReviewFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'EventCustomerBarrier' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerBarrier()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerBarrierFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'EventCustomerBasicBioMetric' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerBasicBioMetric()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerBasicBioMetricFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'EventCustomerEvaluationLock' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerEvaluationLock()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerEvaluationLockFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'EventCustomerResult' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerResult()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerResultFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'PcpAppointment' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPcpAppointment_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PcpAppointmentFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ScreeningAuthorization' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoScreeningAuthorization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ScreeningAuthorizationFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}
	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.EventCustomersEntity);
		}

		/// <summary>
		/// Creates the ITypeDefaultValue instance used to provide default values for value types which aren't of type nullable(of T)
		/// </summary>
		/// <returns></returns>
		protected override ITypeDefaultValue CreateTypeDefaultValueProvider()
		{
			return new TypeDefaultValue();
		}

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._callQueueCustomer);
			collectionsQueue.Enqueue(this._chaperoneAnswer);
			collectionsQueue.Enqueue(this._chaperoneSignature);
			collectionsQueue.Enqueue(this._checkListAnswer);
			collectionsQueue.Enqueue(this._clickConversion);
			collectionsQueue.Enqueue(this._customerHealthInfo);
			collectionsQueue.Enqueue(this._customerHealthInfoArchive);
			collectionsQueue.Enqueue(this._customerMedicareQuestionAnswer);
			collectionsQueue.Enqueue(this._customerOrderHistory);
			collectionsQueue.Enqueue(this._dependentDisqualifiedTest);
			collectionsQueue.Enqueue(this._disqualifiedTest);
			collectionsQueue.Enqueue(this._eventAppointmentCancellationLog);
			collectionsQueue.Enqueue(this._eventAppointmentChangeLog);
			collectionsQueue.Enqueue(this._eventCustomerCriticalQuestion);
			collectionsQueue.Enqueue(this._eventCustomerCurrentMedication);
			collectionsQueue.Enqueue(this._eventCustomerCustomNotification);
			collectionsQueue.Enqueue(this._eventCustomerDiagnosis);
			collectionsQueue.Enqueue(this._eventCustomerEligibility);
			collectionsQueue.Enqueue(this._eventCustomerEncounter);
			collectionsQueue.Enqueue(this._eventCustomerGiftCard);
			collectionsQueue.Enqueue(this._eventCustomerIcdCodes);
			collectionsQueue.Enqueue(this._eventCustomerNotification);
			collectionsQueue.Enqueue(this._eventCustomerOrderDetail);
			collectionsQueue.Enqueue(this._eventCustomerPreApprovedPackageTest);
			collectionsQueue.Enqueue(this._eventCustomerPreApprovedTest);
			collectionsQueue.Enqueue(this._eventCustomerPrimaryCarePhysician);
			collectionsQueue.Enqueue(this._eventCustomerQuestionAnswer);
			collectionsQueue.Enqueue(this._eventCustomerRequiredTest);
			collectionsQueue.Enqueue(this._eventCustomerRetest);
			collectionsQueue.Enqueue(this._eventCustomerTestNotPerformedNotification);
			collectionsQueue.Enqueue(this._exitInterviewAnswer);
			collectionsQueue.Enqueue(this._exitInterviewSignature);
			collectionsQueue.Enqueue(this._fluConsentAnswer);
			collectionsQueue.Enqueue(this._fluConsentSignature);
			collectionsQueue.Enqueue(this._participationConsentSignature);
			collectionsQueue.Enqueue(this._pcpDisposition);
			collectionsQueue.Enqueue(this._physicianCustomerAssignment);
			collectionsQueue.Enqueue(this._physicianEvaluation);
			collectionsQueue.Enqueue(this._physicianRecordRequestSignature);
			collectionsQueue.Enqueue(this._surveyAnswer);
			collectionsQueue.Enqueue(this._accountCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._activityTypeCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._callQueueCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._callQueueCriteriaCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._campaignCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._chaperoneQuestionCollectionViaChaperoneAnswer);
			collectionsQueue.Enqueue(this._chargeCardCollectionViaEventCustomerEligibility);
			collectionsQueue.Enqueue(this._checkListQuestionCollectionViaExitInterviewSignature);
			collectionsQueue.Enqueue(this._checkListQuestionCollectionViaCheckListAnswer);
			collectionsQueue.Enqueue(this._clickLogCollectionViaClickConversion);
			collectionsQueue.Enqueue(this._corporateUploadCollectionViaCustomerOrderHistory);
			collectionsQueue.Enqueue(this._criticalQuestionCollectionViaEventCustomerCriticalQuestion);
			collectionsQueue.Enqueue(this._customerHealthQuestionsCollectionViaCustomerHealthInfoArchive);
			collectionsQueue.Enqueue(this._customerHealthQuestionsCollectionViaCustomerHealthInfo);
			collectionsQueue.Enqueue(this._customerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerHealthInfo);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaDependentDisqualifiedTest);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaClickConversion);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaDisqualifiedTest);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerOrderHistory);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerHealthInfoArchive);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaEventCustomerQuestionAnswer);
			collectionsQueue.Enqueue(this._customerRegistrationNotesCollectionViaEventAppointmentCancellationLog);
			collectionsQueue.Enqueue(this._customEventNotificationCollectionViaEventCustomerCustomNotification);
			collectionsQueue.Enqueue(this._eligibilityCollectionViaEventCustomerEligibility);
			collectionsQueue.Enqueue(this._encounterCollectionViaEventCustomerEncounter);
			collectionsQueue.Enqueue(this._eventPackageDetailsCollectionViaCustomerOrderHistory);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventAppointmentChangeLog_);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventAppointmentChangeLog);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventAppointmentCancellationLog);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventCustomerQuestionAnswer);
			collectionsQueue.Enqueue(this._eventsCollectionViaDependentDisqualifiedTest);
			collectionsQueue.Enqueue(this._eventsCollectionViaCustomerOrderHistory);
			collectionsQueue.Enqueue(this._eventsCollectionViaDisqualifiedTest);
			collectionsQueue.Enqueue(this._eventsCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._eventTestCollectionViaCustomerOrderHistory);
			collectionsQueue.Enqueue(this._exitInterviewQuestionCollectionViaExitInterviewAnswer);
			collectionsQueue.Enqueue(this._fileCollectionViaParticipationConsentSignature_);
			collectionsQueue.Enqueue(this._fileCollectionViaParticipationConsentSignature);
			collectionsQueue.Enqueue(this._fileCollectionViaEventCustomerGiftCard);
			collectionsQueue.Enqueue(this._fileCollectionViaEventCustomerGiftCard_);
			collectionsQueue.Enqueue(this._fileCollectionViaFluConsentSignature_);
			collectionsQueue.Enqueue(this._fileCollectionViaPhysicianRecordRequestSignature);
			collectionsQueue.Enqueue(this._fileCollectionViaChaperoneSignature);
			collectionsQueue.Enqueue(this._fileCollectionViaExitInterviewSignature);
			collectionsQueue.Enqueue(this._fileCollectionViaChaperoneSignature_);
			collectionsQueue.Enqueue(this._fileCollectionViaFluConsentSignature);
			collectionsQueue.Enqueue(this._fluConsentQuestionCollectionViaFluConsentAnswer);
			collectionsQueue.Enqueue(this._icdCodesCollectionViaEventCustomerIcdCodes);
			collectionsQueue.Enqueue(this._languageCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerOrderHistory);
			collectionsQueue.Enqueue(this._lookupCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._lookupCollectionViaEventAppointmentChangeLog);
			collectionsQueue.Enqueue(this._lookupCollectionViaCheckListAnswer);
			collectionsQueue.Enqueue(this._lookupCollectionViaPcpDisposition);
			collectionsQueue.Enqueue(this._lookupCollectionViaEventAppointmentCancellationLog);
			collectionsQueue.Enqueue(this._medicareQuestionCollectionViaCustomerMedicareQuestionAnswer);
			collectionsQueue.Enqueue(this._ndcCollectionViaEventCustomerCurrentMedication);
			collectionsQueue.Enqueue(this._notesDetailsCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._notificationCollectionViaEventCustomerNotification);
			collectionsQueue.Enqueue(this._notificationTypeCollectionViaEventCustomerTestNotPerformedNotification);
			collectionsQueue.Enqueue(this._notificationTypeCollectionViaEventCustomerNotification);
			collectionsQueue.Enqueue(this._orderDetailCollectionViaEventCustomerOrderDetail);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaExitInterviewAnswer_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaParticipationConsentSignature);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaFluConsentSignature);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaPcpDisposition_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaPcpDisposition);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventCustomerRetest);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaExitInterviewAnswer);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaExitInterviewSignature);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaFluConsentAnswer_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventCustomerQuestionAnswer);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventCustomerQuestionAnswer_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaFluConsentAnswer);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaChaperoneSignature);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaSurveyAnswer);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaDisqualifiedTest_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventAppointmentChangeLog);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaChaperoneAnswer_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventAppointmentCancellationLog);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCheckListAnswer_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerHealthInfo);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerHealthInfoArchive);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaDisqualifiedTest);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCheckListAnswer);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaSurveyAnswer_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaChaperoneAnswer);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueCustomer__);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventCustomerGiftCard);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueCustomer_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaPhysicianRecordRequestSignature);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer);
			collectionsQueue.Enqueue(this._packageCollectionViaEventCustomerPreApprovedPackageTest);
			collectionsQueue.Enqueue(this._physicianProfileCollectionViaPhysicianEvaluation);
			collectionsQueue.Enqueue(this._physicianProfileCollectionViaPhysicianCustomerAssignment_);
			collectionsQueue.Enqueue(this._physicianProfileCollectionViaPhysicianCustomerAssignment);
			collectionsQueue.Enqueue(this._preQualificationQuestionCollectionViaEventCustomerQuestionAnswer);
			collectionsQueue.Enqueue(this._preQualificationQuestionCollectionViaDisqualifiedTest);
			collectionsQueue.Enqueue(this._prospectCustomerCollectionViaClickConversion);
			collectionsQueue.Enqueue(this._prospectCustomerCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._refundRequestCollectionViaEventAppointmentCancellationLog);
			collectionsQueue.Enqueue(this._rescheduleCancelDispositionCollectionViaEventAppointmentChangeLog);
			collectionsQueue.Enqueue(this._rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog);
			collectionsQueue.Enqueue(this._surveyQuestionCollectionViaSurveyAnswer);
			collectionsQueue.Enqueue(this._testCollectionViaEventCustomerPreApprovedPackageTest);
			collectionsQueue.Enqueue(this._testCollectionViaDisqualifiedTest);
			collectionsQueue.Enqueue(this._testCollectionViaDependentDisqualifiedTest);
			collectionsQueue.Enqueue(this._testCollectionViaEventCustomerRetest);
			collectionsQueue.Enqueue(this._testCollectionViaEventCustomerTestNotPerformedNotification);
			collectionsQueue.Enqueue(this._testCollectionViaEventCustomerPreApprovedTest);
			collectionsQueue.Enqueue(this._testCollectionViaEventCustomerRequiredTest);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._callQueueCustomer = (EntityCollection<CallQueueCustomerEntity>) collectionsQueue.Dequeue();
			this._chaperoneAnswer = (EntityCollection<ChaperoneAnswerEntity>) collectionsQueue.Dequeue();
			this._chaperoneSignature = (EntityCollection<ChaperoneSignatureEntity>) collectionsQueue.Dequeue();
			this._checkListAnswer = (EntityCollection<CheckListAnswerEntity>) collectionsQueue.Dequeue();
			this._clickConversion = (EntityCollection<ClickConversionEntity>) collectionsQueue.Dequeue();
			this._customerHealthInfo = (EntityCollection<CustomerHealthInfoEntity>) collectionsQueue.Dequeue();
			this._customerHealthInfoArchive = (EntityCollection<CustomerHealthInfoArchiveEntity>) collectionsQueue.Dequeue();
			this._customerMedicareQuestionAnswer = (EntityCollection<CustomerMedicareQuestionAnswerEntity>) collectionsQueue.Dequeue();
			this._customerOrderHistory = (EntityCollection<CustomerOrderHistoryEntity>) collectionsQueue.Dequeue();
			this._dependentDisqualifiedTest = (EntityCollection<DependentDisqualifiedTestEntity>) collectionsQueue.Dequeue();
			this._disqualifiedTest = (EntityCollection<DisqualifiedTestEntity>) collectionsQueue.Dequeue();
			this._eventAppointmentCancellationLog = (EntityCollection<EventAppointmentCancellationLogEntity>) collectionsQueue.Dequeue();
			this._eventAppointmentChangeLog = (EntityCollection<EventAppointmentChangeLogEntity>) collectionsQueue.Dequeue();
			this._eventCustomerCriticalQuestion = (EntityCollection<EventCustomerCriticalQuestionEntity>) collectionsQueue.Dequeue();
			this._eventCustomerCurrentMedication = (EntityCollection<EventCustomerCurrentMedicationEntity>) collectionsQueue.Dequeue();
			this._eventCustomerCustomNotification = (EntityCollection<EventCustomerCustomNotificationEntity>) collectionsQueue.Dequeue();
			this._eventCustomerDiagnosis = (EntityCollection<EventCustomerDiagnosisEntity>) collectionsQueue.Dequeue();
			this._eventCustomerEligibility = (EntityCollection<EventCustomerEligibilityEntity>) collectionsQueue.Dequeue();
			this._eventCustomerEncounter = (EntityCollection<EventCustomerEncounterEntity>) collectionsQueue.Dequeue();
			this._eventCustomerGiftCard = (EntityCollection<EventCustomerGiftCardEntity>) collectionsQueue.Dequeue();
			this._eventCustomerIcdCodes = (EntityCollection<EventCustomerIcdCodesEntity>) collectionsQueue.Dequeue();
			this._eventCustomerNotification = (EntityCollection<EventCustomerNotificationEntity>) collectionsQueue.Dequeue();
			this._eventCustomerOrderDetail = (EntityCollection<EventCustomerOrderDetailEntity>) collectionsQueue.Dequeue();
			this._eventCustomerPreApprovedPackageTest = (EntityCollection<EventCustomerPreApprovedPackageTestEntity>) collectionsQueue.Dequeue();
			this._eventCustomerPreApprovedTest = (EntityCollection<EventCustomerPreApprovedTestEntity>) collectionsQueue.Dequeue();
			this._eventCustomerPrimaryCarePhysician = (EntityCollection<EventCustomerPrimaryCarePhysicianEntity>) collectionsQueue.Dequeue();
			this._eventCustomerQuestionAnswer = (EntityCollection<EventCustomerQuestionAnswerEntity>) collectionsQueue.Dequeue();
			this._eventCustomerRequiredTest = (EntityCollection<EventCustomerRequiredTestEntity>) collectionsQueue.Dequeue();
			this._eventCustomerRetest = (EntityCollection<EventCustomerRetestEntity>) collectionsQueue.Dequeue();
			this._eventCustomerTestNotPerformedNotification = (EntityCollection<EventCustomerTestNotPerformedNotificationEntity>) collectionsQueue.Dequeue();
			this._exitInterviewAnswer = (EntityCollection<ExitInterviewAnswerEntity>) collectionsQueue.Dequeue();
			this._exitInterviewSignature = (EntityCollection<ExitInterviewSignatureEntity>) collectionsQueue.Dequeue();
			this._fluConsentAnswer = (EntityCollection<FluConsentAnswerEntity>) collectionsQueue.Dequeue();
			this._fluConsentSignature = (EntityCollection<FluConsentSignatureEntity>) collectionsQueue.Dequeue();
			this._participationConsentSignature = (EntityCollection<ParticipationConsentSignatureEntity>) collectionsQueue.Dequeue();
			this._pcpDisposition = (EntityCollection<PcpDispositionEntity>) collectionsQueue.Dequeue();
			this._physicianCustomerAssignment = (EntityCollection<PhysicianCustomerAssignmentEntity>) collectionsQueue.Dequeue();
			this._physicianEvaluation = (EntityCollection<PhysicianEvaluationEntity>) collectionsQueue.Dequeue();
			this._physicianRecordRequestSignature = (EntityCollection<PhysicianRecordRequestSignatureEntity>) collectionsQueue.Dequeue();
			this._surveyAnswer = (EntityCollection<SurveyAnswerEntity>) collectionsQueue.Dequeue();
			this._accountCollectionViaCallQueueCustomer = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._activityTypeCollectionViaCallQueueCustomer = (EntityCollection<ActivityTypeEntity>) collectionsQueue.Dequeue();
			this._callQueueCollectionViaCallQueueCustomer = (EntityCollection<CallQueueEntity>) collectionsQueue.Dequeue();
			this._callQueueCriteriaCollectionViaCallQueueCustomer = (EntityCollection<CallQueueCriteriaEntity>) collectionsQueue.Dequeue();
			this._campaignCollectionViaCallQueueCustomer = (EntityCollection<CampaignEntity>) collectionsQueue.Dequeue();
			this._chaperoneQuestionCollectionViaChaperoneAnswer = (EntityCollection<ChaperoneQuestionEntity>) collectionsQueue.Dequeue();
			this._chargeCardCollectionViaEventCustomerEligibility = (EntityCollection<ChargeCardEntity>) collectionsQueue.Dequeue();
			this._checkListQuestionCollectionViaExitInterviewSignature = (EntityCollection<CheckListQuestionEntity>) collectionsQueue.Dequeue();
			this._checkListQuestionCollectionViaCheckListAnswer = (EntityCollection<CheckListQuestionEntity>) collectionsQueue.Dequeue();
			this._clickLogCollectionViaClickConversion = (EntityCollection<ClickLogEntity>) collectionsQueue.Dequeue();
			this._corporateUploadCollectionViaCustomerOrderHistory = (EntityCollection<CorporateUploadEntity>) collectionsQueue.Dequeue();
			this._criticalQuestionCollectionViaEventCustomerCriticalQuestion = (EntityCollection<CriticalQuestionEntity>) collectionsQueue.Dequeue();
			this._customerHealthQuestionsCollectionViaCustomerHealthInfoArchive = (EntityCollection<CustomerHealthQuestionsEntity>) collectionsQueue.Dequeue();
			this._customerHealthQuestionsCollectionViaCustomerHealthInfo = (EntityCollection<CustomerHealthQuestionsEntity>) collectionsQueue.Dequeue();
			this._customerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician = (EntityCollection<CustomerPrimaryCarePhysicianEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerHealthInfo = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCallQueueCustomer = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaDependentDisqualifiedTest = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaClickConversion = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaDisqualifiedTest = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerOrderHistory = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerHealthInfoArchive = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaEventCustomerQuestionAnswer = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerRegistrationNotesCollectionViaEventAppointmentCancellationLog = (EntityCollection<CustomerRegistrationNotesEntity>) collectionsQueue.Dequeue();
			this._customEventNotificationCollectionViaEventCustomerCustomNotification = (EntityCollection<CustomEventNotificationEntity>) collectionsQueue.Dequeue();
			this._eligibilityCollectionViaEventCustomerEligibility = (EntityCollection<EligibilityEntity>) collectionsQueue.Dequeue();
			this._encounterCollectionViaEventCustomerEncounter = (EntityCollection<EncounterEntity>) collectionsQueue.Dequeue();
			this._eventPackageDetailsCollectionViaCustomerOrderHistory = (EntityCollection<EventPackageDetailsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventAppointmentChangeLog_ = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventAppointmentChangeLog = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventAppointmentCancellationLog = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventCustomerQuestionAnswer = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaDependentDisqualifiedTest = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaCustomerOrderHistory = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaDisqualifiedTest = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaCallQueueCustomer = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventTestCollectionViaCustomerOrderHistory = (EntityCollection<EventTestEntity>) collectionsQueue.Dequeue();
			this._exitInterviewQuestionCollectionViaExitInterviewAnswer = (EntityCollection<ExitInterviewQuestionEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaParticipationConsentSignature_ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaParticipationConsentSignature = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaEventCustomerGiftCard = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaEventCustomerGiftCard_ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaFluConsentSignature_ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaPhysicianRecordRequestSignature = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaChaperoneSignature = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaExitInterviewSignature = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaChaperoneSignature_ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaFluConsentSignature = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fluConsentQuestionCollectionViaFluConsentAnswer = (EntityCollection<FluConsentQuestionEntity>) collectionsQueue.Dequeue();
			this._icdCodesCollectionViaEventCustomerIcdCodes = (EntityCollection<IcdCodesEntity>) collectionsQueue.Dequeue();
			this._languageCollectionViaCallQueueCustomer = (EntityCollection<LanguageEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerOrderHistory = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCallQueueCustomer = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEventAppointmentChangeLog = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCheckListAnswer = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaPcpDisposition = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEventAppointmentCancellationLog = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._medicareQuestionCollectionViaCustomerMedicareQuestionAnswer = (EntityCollection<MedicareQuestionEntity>) collectionsQueue.Dequeue();
			this._ndcCollectionViaEventCustomerCurrentMedication = (EntityCollection<NdcEntity>) collectionsQueue.Dequeue();
			this._notesDetailsCollectionViaCallQueueCustomer = (EntityCollection<NotesDetailsEntity>) collectionsQueue.Dequeue();
			this._notificationCollectionViaEventCustomerNotification = (EntityCollection<NotificationEntity>) collectionsQueue.Dequeue();
			this._notificationTypeCollectionViaEventCustomerTestNotPerformedNotification = (EntityCollection<NotificationTypeEntity>) collectionsQueue.Dequeue();
			this._notificationTypeCollectionViaEventCustomerNotification = (EntityCollection<NotificationTypeEntity>) collectionsQueue.Dequeue();
			this._orderDetailCollectionViaEventCustomerOrderDetail = (EntityCollection<OrderDetailEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaExitInterviewAnswer_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaParticipationConsentSignature = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaFluConsentSignature = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaPcpDisposition_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaPcpDisposition = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventCustomerRetest = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaExitInterviewAnswer = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaExitInterviewSignature = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaFluConsentAnswer_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventCustomerQuestionAnswer = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventCustomerQuestionAnswer_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaFluConsentAnswer = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaChaperoneSignature = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaSurveyAnswer = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaDisqualifiedTest_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventAppointmentChangeLog = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaChaperoneAnswer_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventAppointmentCancellationLog = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCheckListAnswer_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerHealthInfo = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerHealthInfoArchive = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaDisqualifiedTest = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCheckListAnswer = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaSurveyAnswer_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaChaperoneAnswer = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueCustomer__ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventCustomerGiftCard = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueCustomer = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueCustomer_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaPhysicianRecordRequestSignature = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._packageCollectionViaEventCustomerPreApprovedPackageTest = (EntityCollection<PackageEntity>) collectionsQueue.Dequeue();
			this._physicianProfileCollectionViaPhysicianEvaluation = (EntityCollection<PhysicianProfileEntity>) collectionsQueue.Dequeue();
			this._physicianProfileCollectionViaPhysicianCustomerAssignment_ = (EntityCollection<PhysicianProfileEntity>) collectionsQueue.Dequeue();
			this._physicianProfileCollectionViaPhysicianCustomerAssignment = (EntityCollection<PhysicianProfileEntity>) collectionsQueue.Dequeue();
			this._preQualificationQuestionCollectionViaEventCustomerQuestionAnswer = (EntityCollection<PreQualificationQuestionEntity>) collectionsQueue.Dequeue();
			this._preQualificationQuestionCollectionViaDisqualifiedTest = (EntityCollection<PreQualificationQuestionEntity>) collectionsQueue.Dequeue();
			this._prospectCustomerCollectionViaClickConversion = (EntityCollection<ProspectCustomerEntity>) collectionsQueue.Dequeue();
			this._prospectCustomerCollectionViaCallQueueCustomer = (EntityCollection<ProspectCustomerEntity>) collectionsQueue.Dequeue();
			this._refundRequestCollectionViaEventAppointmentCancellationLog = (EntityCollection<RefundRequestEntity>) collectionsQueue.Dequeue();
			this._rescheduleCancelDispositionCollectionViaEventAppointmentChangeLog = (EntityCollection<RescheduleCancelDispositionEntity>) collectionsQueue.Dequeue();
			this._rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog = (EntityCollection<RescheduleCancelDispositionEntity>) collectionsQueue.Dequeue();
			this._surveyQuestionCollectionViaSurveyAnswer = (EntityCollection<SurveyQuestionEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaEventCustomerPreApprovedPackageTest = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaDisqualifiedTest = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaDependentDisqualifiedTest = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaEventCustomerRetest = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaEventCustomerTestNotPerformedNotification = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaEventCustomerPreApprovedTest = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaEventCustomerRequiredTest = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._callQueueCustomer != null)
			{
				return true;
			}
			if (this._chaperoneAnswer != null)
			{
				return true;
			}
			if (this._chaperoneSignature != null)
			{
				return true;
			}
			if (this._checkListAnswer != null)
			{
				return true;
			}
			if (this._clickConversion != null)
			{
				return true;
			}
			if (this._customerHealthInfo != null)
			{
				return true;
			}
			if (this._customerHealthInfoArchive != null)
			{
				return true;
			}
			if (this._customerMedicareQuestionAnswer != null)
			{
				return true;
			}
			if (this._customerOrderHistory != null)
			{
				return true;
			}
			if (this._dependentDisqualifiedTest != null)
			{
				return true;
			}
			if (this._disqualifiedTest != null)
			{
				return true;
			}
			if (this._eventAppointmentCancellationLog != null)
			{
				return true;
			}
			if (this._eventAppointmentChangeLog != null)
			{
				return true;
			}
			if (this._eventCustomerCriticalQuestion != null)
			{
				return true;
			}
			if (this._eventCustomerCurrentMedication != null)
			{
				return true;
			}
			if (this._eventCustomerCustomNotification != null)
			{
				return true;
			}
			if (this._eventCustomerDiagnosis != null)
			{
				return true;
			}
			if (this._eventCustomerEligibility != null)
			{
				return true;
			}
			if (this._eventCustomerEncounter != null)
			{
				return true;
			}
			if (this._eventCustomerGiftCard != null)
			{
				return true;
			}
			if (this._eventCustomerIcdCodes != null)
			{
				return true;
			}
			if (this._eventCustomerNotification != null)
			{
				return true;
			}
			if (this._eventCustomerOrderDetail != null)
			{
				return true;
			}
			if (this._eventCustomerPreApprovedPackageTest != null)
			{
				return true;
			}
			if (this._eventCustomerPreApprovedTest != null)
			{
				return true;
			}
			if (this._eventCustomerPrimaryCarePhysician != null)
			{
				return true;
			}
			if (this._eventCustomerQuestionAnswer != null)
			{
				return true;
			}
			if (this._eventCustomerRequiredTest != null)
			{
				return true;
			}
			if (this._eventCustomerRetest != null)
			{
				return true;
			}
			if (this._eventCustomerTestNotPerformedNotification != null)
			{
				return true;
			}
			if (this._exitInterviewAnswer != null)
			{
				return true;
			}
			if (this._exitInterviewSignature != null)
			{
				return true;
			}
			if (this._fluConsentAnswer != null)
			{
				return true;
			}
			if (this._fluConsentSignature != null)
			{
				return true;
			}
			if (this._participationConsentSignature != null)
			{
				return true;
			}
			if (this._pcpDisposition != null)
			{
				return true;
			}
			if (this._physicianCustomerAssignment != null)
			{
				return true;
			}
			if (this._physicianEvaluation != null)
			{
				return true;
			}
			if (this._physicianRecordRequestSignature != null)
			{
				return true;
			}
			if (this._surveyAnswer != null)
			{
				return true;
			}
			if (this._accountCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._activityTypeCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._callQueueCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._callQueueCriteriaCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._campaignCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._chaperoneQuestionCollectionViaChaperoneAnswer != null)
			{
				return true;
			}
			if (this._chargeCardCollectionViaEventCustomerEligibility != null)
			{
				return true;
			}
			if (this._checkListQuestionCollectionViaExitInterviewSignature != null)
			{
				return true;
			}
			if (this._checkListQuestionCollectionViaCheckListAnswer != null)
			{
				return true;
			}
			if (this._clickLogCollectionViaClickConversion != null)
			{
				return true;
			}
			if (this._corporateUploadCollectionViaCustomerOrderHistory != null)
			{
				return true;
			}
			if (this._criticalQuestionCollectionViaEventCustomerCriticalQuestion != null)
			{
				return true;
			}
			if (this._customerHealthQuestionsCollectionViaCustomerHealthInfoArchive != null)
			{
				return true;
			}
			if (this._customerHealthQuestionsCollectionViaCustomerHealthInfo != null)
			{
				return true;
			}
			if (this._customerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerHealthInfo != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaDependentDisqualifiedTest != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaClickConversion != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaDisqualifiedTest != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerOrderHistory != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerHealthInfoArchive != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaEventCustomerQuestionAnswer != null)
			{
				return true;
			}
			if (this._customerRegistrationNotesCollectionViaEventAppointmentCancellationLog != null)
			{
				return true;
			}
			if (this._customEventNotificationCollectionViaEventCustomerCustomNotification != null)
			{
				return true;
			}
			if (this._eligibilityCollectionViaEventCustomerEligibility != null)
			{
				return true;
			}
			if (this._encounterCollectionViaEventCustomerEncounter != null)
			{
				return true;
			}
			if (this._eventPackageDetailsCollectionViaCustomerOrderHistory != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventAppointmentChangeLog_ != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventAppointmentChangeLog != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventAppointmentCancellationLog != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventCustomerQuestionAnswer != null)
			{
				return true;
			}
			if (this._eventsCollectionViaDependentDisqualifiedTest != null)
			{
				return true;
			}
			if (this._eventsCollectionViaCustomerOrderHistory != null)
			{
				return true;
			}
			if (this._eventsCollectionViaDisqualifiedTest != null)
			{
				return true;
			}
			if (this._eventsCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._eventTestCollectionViaCustomerOrderHistory != null)
			{
				return true;
			}
			if (this._exitInterviewQuestionCollectionViaExitInterviewAnswer != null)
			{
				return true;
			}
			if (this._fileCollectionViaParticipationConsentSignature_ != null)
			{
				return true;
			}
			if (this._fileCollectionViaParticipationConsentSignature != null)
			{
				return true;
			}
			if (this._fileCollectionViaEventCustomerGiftCard != null)
			{
				return true;
			}
			if (this._fileCollectionViaEventCustomerGiftCard_ != null)
			{
				return true;
			}
			if (this._fileCollectionViaFluConsentSignature_ != null)
			{
				return true;
			}
			if (this._fileCollectionViaPhysicianRecordRequestSignature != null)
			{
				return true;
			}
			if (this._fileCollectionViaChaperoneSignature != null)
			{
				return true;
			}
			if (this._fileCollectionViaExitInterviewSignature != null)
			{
				return true;
			}
			if (this._fileCollectionViaChaperoneSignature_ != null)
			{
				return true;
			}
			if (this._fileCollectionViaFluConsentSignature != null)
			{
				return true;
			}
			if (this._fluConsentQuestionCollectionViaFluConsentAnswer != null)
			{
				return true;
			}
			if (this._icdCodesCollectionViaEventCustomerIcdCodes != null)
			{
				return true;
			}
			if (this._languageCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerOrderHistory != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEventAppointmentChangeLog != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCheckListAnswer != null)
			{
				return true;
			}
			if (this._lookupCollectionViaPcpDisposition != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEventAppointmentCancellationLog != null)
			{
				return true;
			}
			if (this._medicareQuestionCollectionViaCustomerMedicareQuestionAnswer != null)
			{
				return true;
			}
			if (this._ndcCollectionViaEventCustomerCurrentMedication != null)
			{
				return true;
			}
			if (this._notesDetailsCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._notificationCollectionViaEventCustomerNotification != null)
			{
				return true;
			}
			if (this._notificationTypeCollectionViaEventCustomerTestNotPerformedNotification != null)
			{
				return true;
			}
			if (this._notificationTypeCollectionViaEventCustomerNotification != null)
			{
				return true;
			}
			if (this._orderDetailCollectionViaEventCustomerOrderDetail != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaExitInterviewAnswer_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaParticipationConsentSignature != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaFluConsentSignature != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaPcpDisposition_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaPcpDisposition != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventCustomerRetest != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaExitInterviewAnswer != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaExitInterviewSignature != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaFluConsentAnswer_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventCustomerQuestionAnswer != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventCustomerQuestionAnswer_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaFluConsentAnswer != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaChaperoneSignature != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaSurveyAnswer != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaDisqualifiedTest_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventAppointmentChangeLog != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaChaperoneAnswer_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventAppointmentCancellationLog != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCheckListAnswer_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerHealthInfo != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerHealthInfoArchive != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaDisqualifiedTest != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCheckListAnswer != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaSurveyAnswer_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaChaperoneAnswer != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueCustomer__ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventCustomerGiftCard != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueCustomer_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaPhysicianRecordRequestSignature != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer != null)
			{
				return true;
			}
			if (this._packageCollectionViaEventCustomerPreApprovedPackageTest != null)
			{
				return true;
			}
			if (this._physicianProfileCollectionViaPhysicianEvaluation != null)
			{
				return true;
			}
			if (this._physicianProfileCollectionViaPhysicianCustomerAssignment_ != null)
			{
				return true;
			}
			if (this._physicianProfileCollectionViaPhysicianCustomerAssignment != null)
			{
				return true;
			}
			if (this._preQualificationQuestionCollectionViaEventCustomerQuestionAnswer != null)
			{
				return true;
			}
			if (this._preQualificationQuestionCollectionViaDisqualifiedTest != null)
			{
				return true;
			}
			if (this._prospectCustomerCollectionViaClickConversion != null)
			{
				return true;
			}
			if (this._prospectCustomerCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._refundRequestCollectionViaEventAppointmentCancellationLog != null)
			{
				return true;
			}
			if (this._rescheduleCancelDispositionCollectionViaEventAppointmentChangeLog != null)
			{
				return true;
			}
			if (this._rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog != null)
			{
				return true;
			}
			if (this._surveyQuestionCollectionViaSurveyAnswer != null)
			{
				return true;
			}
			if (this._testCollectionViaEventCustomerPreApprovedPackageTest != null)
			{
				return true;
			}
			if (this._testCollectionViaDisqualifiedTest != null)
			{
				return true;
			}
			if (this._testCollectionViaDependentDisqualifiedTest != null)
			{
				return true;
			}
			if (this._testCollectionViaEventCustomerRetest != null)
			{
				return true;
			}
			if (this._testCollectionViaEventCustomerTestNotPerformedNotification != null)
			{
				return true;
			}
			if (this._testCollectionViaEventCustomerPreApprovedTest != null)
			{
				return true;
			}
			if (this._testCollectionViaEventCustomerRequiredTest != null)
			{
				return true;
			}
			return base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChaperoneAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaperoneAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChaperoneSignatureEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaperoneSignatureEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ClickConversionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClickConversionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerHealthInfoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthInfoEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerHealthInfoArchiveEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthInfoArchiveEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerMedicareQuestionAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerMedicareQuestionAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerOrderHistoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerOrderHistoryEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DependentDisqualifiedTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DependentDisqualifiedTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DisqualifiedTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DisqualifiedTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventAppointmentCancellationLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentCancellationLogEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventAppointmentChangeLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentChangeLogEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerCriticalQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerCriticalQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerCurrentMedicationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerCurrentMedicationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerCustomNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerCustomNotificationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerDiagnosisEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerDiagnosisEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerEligibilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerEligibilityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerEncounterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerEncounterEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerGiftCardEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerGiftCardEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerIcdCodesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerIcdCodesEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerNotificationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerOrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerOrderDetailEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerPreApprovedPackageTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerPreApprovedPackageTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerPreApprovedTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerPreApprovedTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerPrimaryCarePhysicianEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerPrimaryCarePhysicianEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerQuestionAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerQuestionAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerRequiredTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerRequiredTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerRetestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerRetestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerTestNotPerformedNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerTestNotPerformedNotificationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ExitInterviewAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ExitInterviewAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ExitInterviewSignatureEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ExitInterviewSignatureEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FluConsentAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FluConsentSignatureEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentSignatureEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ParticipationConsentSignatureEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ParticipationConsentSignatureEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PcpDispositionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PcpDispositionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianCustomerAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianCustomerAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianEvaluationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianEvaluationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianRecordRequestSignatureEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianRecordRequestSignatureEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SurveyAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCriteriaEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChaperoneQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaperoneQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChargeCardEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChargeCardEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ClickLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClickLogEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CorporateUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CorporateUploadEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CriticalQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CriticalQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerPrimaryCarePhysicianEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerPrimaryCarePhysicianEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerRegistrationNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerRegistrationNotesEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomEventNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomEventNotificationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EligibilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EligibilityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EncounterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EncounterEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventPackageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ExitInterviewQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ExitInterviewQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FluConsentQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<IcdCodesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IcdCodesEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MedicareQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NdcEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NdcEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NotificationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NotificationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderDetailEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PreQualificationQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PreQualificationQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RefundRequestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundRequestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RescheduleCancelDispositionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RescheduleCancelDispositionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RescheduleCancelDispositionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RescheduleCancelDispositionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SurveyQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("AfaffiliateCampaign", _afaffiliateCampaign);
			toReturn.Add("Campaign", _campaign);
			toReturn.Add("CustomerProfile", _customerProfile);
			toReturn.Add("CustomerProfileHistory", _customerProfileHistory);
			toReturn.Add("CustomerRegistrationNotes", _customerRegistrationNotes);
			toReturn.Add("EventAppointment", _eventAppointment);
			toReturn.Add("Events", _events);
			toReturn.Add("GcNotGivenReason", _gcNotGivenReason);
			toReturn.Add("HospitalFacility", _hospitalFacility);
			toReturn.Add("Lookup_", _lookup_);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("OrganizationRoleUser_", _organizationRoleUser_);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("CallQueueCustomer", _callQueueCustomer);
			toReturn.Add("ChaperoneAnswer", _chaperoneAnswer);
			toReturn.Add("ChaperoneSignature", _chaperoneSignature);
			toReturn.Add("CheckListAnswer", _checkListAnswer);
			toReturn.Add("ClickConversion", _clickConversion);
			toReturn.Add("CustomerHealthInfo", _customerHealthInfo);
			toReturn.Add("CustomerHealthInfoArchive", _customerHealthInfoArchive);
			toReturn.Add("CustomerMedicareQuestionAnswer", _customerMedicareQuestionAnswer);
			toReturn.Add("CustomerOrderHistory", _customerOrderHistory);
			toReturn.Add("DependentDisqualifiedTest", _dependentDisqualifiedTest);
			toReturn.Add("DisqualifiedTest", _disqualifiedTest);
			toReturn.Add("EventAppointmentCancellationLog", _eventAppointmentCancellationLog);
			toReturn.Add("EventAppointmentChangeLog", _eventAppointmentChangeLog);
			toReturn.Add("EventCustomerCriticalQuestion", _eventCustomerCriticalQuestion);
			toReturn.Add("EventCustomerCurrentMedication", _eventCustomerCurrentMedication);
			toReturn.Add("EventCustomerCustomNotification", _eventCustomerCustomNotification);
			toReturn.Add("EventCustomerDiagnosis", _eventCustomerDiagnosis);
			toReturn.Add("EventCustomerEligibility", _eventCustomerEligibility);
			toReturn.Add("EventCustomerEncounter", _eventCustomerEncounter);
			toReturn.Add("EventCustomerGiftCard", _eventCustomerGiftCard);
			toReturn.Add("EventCustomerIcdCodes", _eventCustomerIcdCodes);
			toReturn.Add("EventCustomerNotification", _eventCustomerNotification);
			toReturn.Add("EventCustomerOrderDetail", _eventCustomerOrderDetail);
			toReturn.Add("EventCustomerPreApprovedPackageTest", _eventCustomerPreApprovedPackageTest);
			toReturn.Add("EventCustomerPreApprovedTest", _eventCustomerPreApprovedTest);
			toReturn.Add("EventCustomerPrimaryCarePhysician", _eventCustomerPrimaryCarePhysician);
			toReturn.Add("EventCustomerQuestionAnswer", _eventCustomerQuestionAnswer);
			toReturn.Add("EventCustomerRequiredTest", _eventCustomerRequiredTest);
			toReturn.Add("EventCustomerRetest", _eventCustomerRetest);
			toReturn.Add("EventCustomerTestNotPerformedNotification", _eventCustomerTestNotPerformedNotification);
			toReturn.Add("ExitInterviewAnswer", _exitInterviewAnswer);
			toReturn.Add("ExitInterviewSignature", _exitInterviewSignature);
			toReturn.Add("FluConsentAnswer", _fluConsentAnswer);
			toReturn.Add("FluConsentSignature", _fluConsentSignature);
			toReturn.Add("ParticipationConsentSignature", _participationConsentSignature);
			toReturn.Add("PcpDisposition", _pcpDisposition);
			toReturn.Add("PhysicianCustomerAssignment", _physicianCustomerAssignment);
			toReturn.Add("PhysicianEvaluation", _physicianEvaluation);
			toReturn.Add("PhysicianRecordRequestSignature", _physicianRecordRequestSignature);
			toReturn.Add("SurveyAnswer", _surveyAnswer);
			toReturn.Add("AccountCollectionViaCallQueueCustomer", _accountCollectionViaCallQueueCustomer);
			toReturn.Add("ActivityTypeCollectionViaCallQueueCustomer", _activityTypeCollectionViaCallQueueCustomer);
			toReturn.Add("CallQueueCollectionViaCallQueueCustomer", _callQueueCollectionViaCallQueueCustomer);
			toReturn.Add("CallQueueCriteriaCollectionViaCallQueueCustomer", _callQueueCriteriaCollectionViaCallQueueCustomer);
			toReturn.Add("CampaignCollectionViaCallQueueCustomer", _campaignCollectionViaCallQueueCustomer);
			toReturn.Add("ChaperoneQuestionCollectionViaChaperoneAnswer", _chaperoneQuestionCollectionViaChaperoneAnswer);
			toReturn.Add("ChargeCardCollectionViaEventCustomerEligibility", _chargeCardCollectionViaEventCustomerEligibility);
			toReturn.Add("CheckListQuestionCollectionViaExitInterviewSignature", _checkListQuestionCollectionViaExitInterviewSignature);
			toReturn.Add("CheckListQuestionCollectionViaCheckListAnswer", _checkListQuestionCollectionViaCheckListAnswer);
			toReturn.Add("ClickLogCollectionViaClickConversion", _clickLogCollectionViaClickConversion);
			toReturn.Add("CorporateUploadCollectionViaCustomerOrderHistory", _corporateUploadCollectionViaCustomerOrderHistory);
			toReturn.Add("CriticalQuestionCollectionViaEventCustomerCriticalQuestion", _criticalQuestionCollectionViaEventCustomerCriticalQuestion);
			toReturn.Add("CustomerHealthQuestionsCollectionViaCustomerHealthInfoArchive", _customerHealthQuestionsCollectionViaCustomerHealthInfoArchive);
			toReturn.Add("CustomerHealthQuestionsCollectionViaCustomerHealthInfo", _customerHealthQuestionsCollectionViaCustomerHealthInfo);
			toReturn.Add("CustomerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician", _customerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician);
			toReturn.Add("CustomerProfileCollectionViaCustomerHealthInfo", _customerProfileCollectionViaCustomerHealthInfo);
			toReturn.Add("CustomerProfileCollectionViaCallQueueCustomer", _customerProfileCollectionViaCallQueueCustomer);
			toReturn.Add("CustomerProfileCollectionViaDependentDisqualifiedTest", _customerProfileCollectionViaDependentDisqualifiedTest);
			toReturn.Add("CustomerProfileCollectionViaClickConversion", _customerProfileCollectionViaClickConversion);
			toReturn.Add("CustomerProfileCollectionViaDisqualifiedTest", _customerProfileCollectionViaDisqualifiedTest);
			toReturn.Add("CustomerProfileCollectionViaCustomerOrderHistory", _customerProfileCollectionViaCustomerOrderHistory);
			toReturn.Add("CustomerProfileCollectionViaCustomerHealthInfoArchive", _customerProfileCollectionViaCustomerHealthInfoArchive);
			toReturn.Add("CustomerProfileCollectionViaEventCustomerQuestionAnswer", _customerProfileCollectionViaEventCustomerQuestionAnswer);
			toReturn.Add("CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog", _customerRegistrationNotesCollectionViaEventAppointmentCancellationLog);
			toReturn.Add("CustomEventNotificationCollectionViaEventCustomerCustomNotification", _customEventNotificationCollectionViaEventCustomerCustomNotification);
			toReturn.Add("EligibilityCollectionViaEventCustomerEligibility", _eligibilityCollectionViaEventCustomerEligibility);
			toReturn.Add("EncounterCollectionViaEventCustomerEncounter", _encounterCollectionViaEventCustomerEncounter);
			toReturn.Add("EventPackageDetailsCollectionViaCustomerOrderHistory", _eventPackageDetailsCollectionViaCustomerOrderHistory);
			toReturn.Add("EventsCollectionViaEventAppointmentChangeLog_", _eventsCollectionViaEventAppointmentChangeLog_);
			toReturn.Add("EventsCollectionViaEventAppointmentChangeLog", _eventsCollectionViaEventAppointmentChangeLog);
			toReturn.Add("EventsCollectionViaEventAppointmentCancellationLog", _eventsCollectionViaEventAppointmentCancellationLog);
			toReturn.Add("EventsCollectionViaEventCustomerQuestionAnswer", _eventsCollectionViaEventCustomerQuestionAnswer);
			toReturn.Add("EventsCollectionViaDependentDisqualifiedTest", _eventsCollectionViaDependentDisqualifiedTest);
			toReturn.Add("EventsCollectionViaCustomerOrderHistory", _eventsCollectionViaCustomerOrderHistory);
			toReturn.Add("EventsCollectionViaDisqualifiedTest", _eventsCollectionViaDisqualifiedTest);
			toReturn.Add("EventsCollectionViaCallQueueCustomer", _eventsCollectionViaCallQueueCustomer);
			toReturn.Add("EventTestCollectionViaCustomerOrderHistory", _eventTestCollectionViaCustomerOrderHistory);
			toReturn.Add("ExitInterviewQuestionCollectionViaExitInterviewAnswer", _exitInterviewQuestionCollectionViaExitInterviewAnswer);
			toReturn.Add("FileCollectionViaParticipationConsentSignature_", _fileCollectionViaParticipationConsentSignature_);
			toReturn.Add("FileCollectionViaParticipationConsentSignature", _fileCollectionViaParticipationConsentSignature);
			toReturn.Add("FileCollectionViaEventCustomerGiftCard", _fileCollectionViaEventCustomerGiftCard);
			toReturn.Add("FileCollectionViaEventCustomerGiftCard_", _fileCollectionViaEventCustomerGiftCard_);
			toReturn.Add("FileCollectionViaFluConsentSignature_", _fileCollectionViaFluConsentSignature_);
			toReturn.Add("FileCollectionViaPhysicianRecordRequestSignature", _fileCollectionViaPhysicianRecordRequestSignature);
			toReturn.Add("FileCollectionViaChaperoneSignature", _fileCollectionViaChaperoneSignature);
			toReturn.Add("FileCollectionViaExitInterviewSignature", _fileCollectionViaExitInterviewSignature);
			toReturn.Add("FileCollectionViaChaperoneSignature_", _fileCollectionViaChaperoneSignature_);
			toReturn.Add("FileCollectionViaFluConsentSignature", _fileCollectionViaFluConsentSignature);
			toReturn.Add("FluConsentQuestionCollectionViaFluConsentAnswer", _fluConsentQuestionCollectionViaFluConsentAnswer);
			toReturn.Add("IcdCodesCollectionViaEventCustomerIcdCodes", _icdCodesCollectionViaEventCustomerIcdCodes);
			toReturn.Add("LanguageCollectionViaCallQueueCustomer", _languageCollectionViaCallQueueCustomer);
			toReturn.Add("LookupCollectionViaCustomerOrderHistory", _lookupCollectionViaCustomerOrderHistory);
			toReturn.Add("LookupCollectionViaCallQueueCustomer", _lookupCollectionViaCallQueueCustomer);
			toReturn.Add("LookupCollectionViaEventAppointmentChangeLog", _lookupCollectionViaEventAppointmentChangeLog);
			toReturn.Add("LookupCollectionViaCheckListAnswer", _lookupCollectionViaCheckListAnswer);
			toReturn.Add("LookupCollectionViaPcpDisposition", _lookupCollectionViaPcpDisposition);
			toReturn.Add("LookupCollectionViaEventAppointmentCancellationLog", _lookupCollectionViaEventAppointmentCancellationLog);
			toReturn.Add("MedicareQuestionCollectionViaCustomerMedicareQuestionAnswer", _medicareQuestionCollectionViaCustomerMedicareQuestionAnswer);
			toReturn.Add("NdcCollectionViaEventCustomerCurrentMedication", _ndcCollectionViaEventCustomerCurrentMedication);
			toReturn.Add("NotesDetailsCollectionViaCallQueueCustomer", _notesDetailsCollectionViaCallQueueCustomer);
			toReturn.Add("NotificationCollectionViaEventCustomerNotification", _notificationCollectionViaEventCustomerNotification);
			toReturn.Add("NotificationTypeCollectionViaEventCustomerTestNotPerformedNotification", _notificationTypeCollectionViaEventCustomerTestNotPerformedNotification);
			toReturn.Add("NotificationTypeCollectionViaEventCustomerNotification", _notificationTypeCollectionViaEventCustomerNotification);
			toReturn.Add("OrderDetailCollectionViaEventCustomerOrderDetail", _orderDetailCollectionViaEventCustomerOrderDetail);
			toReturn.Add("OrganizationRoleUserCollectionViaExitInterviewAnswer_", _organizationRoleUserCollectionViaExitInterviewAnswer_);
			toReturn.Add("OrganizationRoleUserCollectionViaParticipationConsentSignature", _organizationRoleUserCollectionViaParticipationConsentSignature);
			toReturn.Add("OrganizationRoleUserCollectionViaFluConsentSignature", _organizationRoleUserCollectionViaFluConsentSignature);
			toReturn.Add("OrganizationRoleUserCollectionViaPcpDisposition_", _organizationRoleUserCollectionViaPcpDisposition_);
			toReturn.Add("OrganizationRoleUserCollectionViaPcpDisposition", _organizationRoleUserCollectionViaPcpDisposition);
			toReturn.Add("OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician", _organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician);
			toReturn.Add("OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification", _organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification);
			toReturn.Add("OrganizationRoleUserCollectionViaEventCustomerRetest", _organizationRoleUserCollectionViaEventCustomerRetest);
			toReturn.Add("OrganizationRoleUserCollectionViaExitInterviewAnswer", _organizationRoleUserCollectionViaExitInterviewAnswer);
			toReturn.Add("OrganizationRoleUserCollectionViaExitInterviewSignature", _organizationRoleUserCollectionViaExitInterviewSignature);
			toReturn.Add("OrganizationRoleUserCollectionViaFluConsentAnswer_", _organizationRoleUserCollectionViaFluConsentAnswer_);
			toReturn.Add("OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer", _organizationRoleUserCollectionViaEventCustomerQuestionAnswer);
			toReturn.Add("OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_", _organizationRoleUserCollectionViaEventCustomerQuestionAnswer_);
			toReturn.Add("OrganizationRoleUserCollectionViaFluConsentAnswer", _organizationRoleUserCollectionViaFluConsentAnswer);
			toReturn.Add("OrganizationRoleUserCollectionViaChaperoneSignature", _organizationRoleUserCollectionViaChaperoneSignature);
			toReturn.Add("OrganizationRoleUserCollectionViaSurveyAnswer", _organizationRoleUserCollectionViaSurveyAnswer);
			toReturn.Add("OrganizationRoleUserCollectionViaDisqualifiedTest_", _organizationRoleUserCollectionViaDisqualifiedTest_);
			toReturn.Add("OrganizationRoleUserCollectionViaEventAppointmentChangeLog", _organizationRoleUserCollectionViaEventAppointmentChangeLog);
			toReturn.Add("OrganizationRoleUserCollectionViaChaperoneAnswer_", _organizationRoleUserCollectionViaChaperoneAnswer_);
			toReturn.Add("OrganizationRoleUserCollectionViaEventAppointmentCancellationLog", _organizationRoleUserCollectionViaEventAppointmentCancellationLog);
			toReturn.Add("OrganizationRoleUserCollectionViaCheckListAnswer_", _organizationRoleUserCollectionViaCheckListAnswer_);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerHealthInfo", _organizationRoleUserCollectionViaCustomerHealthInfo);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerHealthInfoArchive", _organizationRoleUserCollectionViaCustomerHealthInfoArchive);
			toReturn.Add("OrganizationRoleUserCollectionViaDisqualifiedTest", _organizationRoleUserCollectionViaDisqualifiedTest);
			toReturn.Add("OrganizationRoleUserCollectionViaCheckListAnswer", _organizationRoleUserCollectionViaCheckListAnswer);
			toReturn.Add("OrganizationRoleUserCollectionViaSurveyAnswer_", _organizationRoleUserCollectionViaSurveyAnswer_);
			toReturn.Add("OrganizationRoleUserCollectionViaChaperoneAnswer", _organizationRoleUserCollectionViaChaperoneAnswer);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueCustomer__", _organizationRoleUserCollectionViaCallQueueCustomer__);
			toReturn.Add("OrganizationRoleUserCollectionViaEventCustomerGiftCard", _organizationRoleUserCollectionViaEventCustomerGiftCard);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueCustomer", _organizationRoleUserCollectionViaCallQueueCustomer);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueCustomer_", _organizationRoleUserCollectionViaCallQueueCustomer_);
			toReturn.Add("OrganizationRoleUserCollectionViaPhysicianRecordRequestSignature", _organizationRoleUserCollectionViaPhysicianRecordRequestSignature);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer", _organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer);
			toReturn.Add("PackageCollectionViaEventCustomerPreApprovedPackageTest", _packageCollectionViaEventCustomerPreApprovedPackageTest);
			toReturn.Add("PhysicianProfileCollectionViaPhysicianEvaluation", _physicianProfileCollectionViaPhysicianEvaluation);
			toReturn.Add("PhysicianProfileCollectionViaPhysicianCustomerAssignment_", _physicianProfileCollectionViaPhysicianCustomerAssignment_);
			toReturn.Add("PhysicianProfileCollectionViaPhysicianCustomerAssignment", _physicianProfileCollectionViaPhysicianCustomerAssignment);
			toReturn.Add("PreQualificationQuestionCollectionViaEventCustomerQuestionAnswer", _preQualificationQuestionCollectionViaEventCustomerQuestionAnswer);
			toReturn.Add("PreQualificationQuestionCollectionViaDisqualifiedTest", _preQualificationQuestionCollectionViaDisqualifiedTest);
			toReturn.Add("ProspectCustomerCollectionViaClickConversion", _prospectCustomerCollectionViaClickConversion);
			toReturn.Add("ProspectCustomerCollectionViaCallQueueCustomer", _prospectCustomerCollectionViaCallQueueCustomer);
			toReturn.Add("RefundRequestCollectionViaEventAppointmentCancellationLog", _refundRequestCollectionViaEventAppointmentCancellationLog);
			toReturn.Add("RescheduleCancelDispositionCollectionViaEventAppointmentChangeLog", _rescheduleCancelDispositionCollectionViaEventAppointmentChangeLog);
			toReturn.Add("RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog", _rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog);
			toReturn.Add("SurveyQuestionCollectionViaSurveyAnswer", _surveyQuestionCollectionViaSurveyAnswer);
			toReturn.Add("TestCollectionViaEventCustomerPreApprovedPackageTest", _testCollectionViaEventCustomerPreApprovedPackageTest);
			toReturn.Add("TestCollectionViaDisqualifiedTest", _testCollectionViaDisqualifiedTest);
			toReturn.Add("TestCollectionViaDependentDisqualifiedTest", _testCollectionViaDependentDisqualifiedTest);
			toReturn.Add("TestCollectionViaEventCustomerRetest", _testCollectionViaEventCustomerRetest);
			toReturn.Add("TestCollectionViaEventCustomerTestNotPerformedNotification", _testCollectionViaEventCustomerTestNotPerformedNotification);
			toReturn.Add("TestCollectionViaEventCustomerPreApprovedTest", _testCollectionViaEventCustomerPreApprovedTest);
			toReturn.Add("TestCollectionViaEventCustomerRequiredTest", _testCollectionViaEventCustomerRequiredTest);
			toReturn.Add("CustomerSkipReview", _customerSkipReview);
			toReturn.Add("EventCustomerBarrier", _eventCustomerBarrier);
			toReturn.Add("EventCustomerBasicBioMetric", _eventCustomerBasicBioMetric);
			toReturn.Add("EventCustomerEvaluationLock", _eventCustomerEvaluationLock);
			toReturn.Add("EventCustomerResult", _eventCustomerResult);
			toReturn.Add("PcpAppointment_", _pcpAppointment_);
			toReturn.Add("ScreeningAuthorization", _screeningAuthorization);
			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_callQueueCustomer!=null)
			{
				_callQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_chaperoneAnswer!=null)
			{
				_chaperoneAnswer.ActiveContext = base.ActiveContext;
			}
			if(_chaperoneSignature!=null)
			{
				_chaperoneSignature.ActiveContext = base.ActiveContext;
			}
			if(_checkListAnswer!=null)
			{
				_checkListAnswer.ActiveContext = base.ActiveContext;
			}
			if(_clickConversion!=null)
			{
				_clickConversion.ActiveContext = base.ActiveContext;
			}
			if(_customerHealthInfo!=null)
			{
				_customerHealthInfo.ActiveContext = base.ActiveContext;
			}
			if(_customerHealthInfoArchive!=null)
			{
				_customerHealthInfoArchive.ActiveContext = base.ActiveContext;
			}
			if(_customerMedicareQuestionAnswer!=null)
			{
				_customerMedicareQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_customerOrderHistory!=null)
			{
				_customerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_dependentDisqualifiedTest!=null)
			{
				_dependentDisqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_disqualifiedTest!=null)
			{
				_disqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_eventAppointmentCancellationLog!=null)
			{
				_eventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_eventAppointmentChangeLog!=null)
			{
				_eventAppointmentChangeLog.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerCriticalQuestion!=null)
			{
				_eventCustomerCriticalQuestion.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerCurrentMedication!=null)
			{
				_eventCustomerCurrentMedication.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerCustomNotification!=null)
			{
				_eventCustomerCustomNotification.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerDiagnosis!=null)
			{
				_eventCustomerDiagnosis.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerEligibility!=null)
			{
				_eventCustomerEligibility.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerEncounter!=null)
			{
				_eventCustomerEncounter.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerGiftCard!=null)
			{
				_eventCustomerGiftCard.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerIcdCodes!=null)
			{
				_eventCustomerIcdCodes.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerNotification!=null)
			{
				_eventCustomerNotification.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerOrderDetail!=null)
			{
				_eventCustomerOrderDetail.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerPreApprovedPackageTest!=null)
			{
				_eventCustomerPreApprovedPackageTest.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerPreApprovedTest!=null)
			{
				_eventCustomerPreApprovedTest.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerPrimaryCarePhysician!=null)
			{
				_eventCustomerPrimaryCarePhysician.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerQuestionAnswer!=null)
			{
				_eventCustomerQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerRequiredTest!=null)
			{
				_eventCustomerRequiredTest.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerRetest!=null)
			{
				_eventCustomerRetest.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerTestNotPerformedNotification!=null)
			{
				_eventCustomerTestNotPerformedNotification.ActiveContext = base.ActiveContext;
			}
			if(_exitInterviewAnswer!=null)
			{
				_exitInterviewAnswer.ActiveContext = base.ActiveContext;
			}
			if(_exitInterviewSignature!=null)
			{
				_exitInterviewSignature.ActiveContext = base.ActiveContext;
			}
			if(_fluConsentAnswer!=null)
			{
				_fluConsentAnswer.ActiveContext = base.ActiveContext;
			}
			if(_fluConsentSignature!=null)
			{
				_fluConsentSignature.ActiveContext = base.ActiveContext;
			}
			if(_participationConsentSignature!=null)
			{
				_participationConsentSignature.ActiveContext = base.ActiveContext;
			}
			if(_pcpDisposition!=null)
			{
				_pcpDisposition.ActiveContext = base.ActiveContext;
			}
			if(_physicianCustomerAssignment!=null)
			{
				_physicianCustomerAssignment.ActiveContext = base.ActiveContext;
			}
			if(_physicianEvaluation!=null)
			{
				_physicianEvaluation.ActiveContext = base.ActiveContext;
			}
			if(_physicianRecordRequestSignature!=null)
			{
				_physicianRecordRequestSignature.ActiveContext = base.ActiveContext;
			}
			if(_surveyAnswer!=null)
			{
				_surveyAnswer.ActiveContext = base.ActiveContext;
			}
			if(_accountCollectionViaCallQueueCustomer!=null)
			{
				_accountCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_activityTypeCollectionViaCallQueueCustomer!=null)
			{
				_activityTypeCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCollectionViaCallQueueCustomer!=null)
			{
				_callQueueCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCriteriaCollectionViaCallQueueCustomer!=null)
			{
				_callQueueCriteriaCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_campaignCollectionViaCallQueueCustomer!=null)
			{
				_campaignCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_chaperoneQuestionCollectionViaChaperoneAnswer!=null)
			{
				_chaperoneQuestionCollectionViaChaperoneAnswer.ActiveContext = base.ActiveContext;
			}
			if(_chargeCardCollectionViaEventCustomerEligibility!=null)
			{
				_chargeCardCollectionViaEventCustomerEligibility.ActiveContext = base.ActiveContext;
			}
			if(_checkListQuestionCollectionViaExitInterviewSignature!=null)
			{
				_checkListQuestionCollectionViaExitInterviewSignature.ActiveContext = base.ActiveContext;
			}
			if(_checkListQuestionCollectionViaCheckListAnswer!=null)
			{
				_checkListQuestionCollectionViaCheckListAnswer.ActiveContext = base.ActiveContext;
			}
			if(_clickLogCollectionViaClickConversion!=null)
			{
				_clickLogCollectionViaClickConversion.ActiveContext = base.ActiveContext;
			}
			if(_corporateUploadCollectionViaCustomerOrderHistory!=null)
			{
				_corporateUploadCollectionViaCustomerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_criticalQuestionCollectionViaEventCustomerCriticalQuestion!=null)
			{
				_criticalQuestionCollectionViaEventCustomerCriticalQuestion.ActiveContext = base.ActiveContext;
			}
			if(_customerHealthQuestionsCollectionViaCustomerHealthInfoArchive!=null)
			{
				_customerHealthQuestionsCollectionViaCustomerHealthInfoArchive.ActiveContext = base.ActiveContext;
			}
			if(_customerHealthQuestionsCollectionViaCustomerHealthInfo!=null)
			{
				_customerHealthQuestionsCollectionViaCustomerHealthInfo.ActiveContext = base.ActiveContext;
			}
			if(_customerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician!=null)
			{
				_customerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerHealthInfo!=null)
			{
				_customerProfileCollectionViaCustomerHealthInfo.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCallQueueCustomer!=null)
			{
				_customerProfileCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaDependentDisqualifiedTest!=null)
			{
				_customerProfileCollectionViaDependentDisqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaClickConversion!=null)
			{
				_customerProfileCollectionViaClickConversion.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaDisqualifiedTest!=null)
			{
				_customerProfileCollectionViaDisqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerOrderHistory!=null)
			{
				_customerProfileCollectionViaCustomerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerHealthInfoArchive!=null)
			{
				_customerProfileCollectionViaCustomerHealthInfoArchive.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaEventCustomerQuestionAnswer!=null)
			{
				_customerProfileCollectionViaEventCustomerQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog!=null)
			{
				_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_customEventNotificationCollectionViaEventCustomerCustomNotification!=null)
			{
				_customEventNotificationCollectionViaEventCustomerCustomNotification.ActiveContext = base.ActiveContext;
			}
			if(_eligibilityCollectionViaEventCustomerEligibility!=null)
			{
				_eligibilityCollectionViaEventCustomerEligibility.ActiveContext = base.ActiveContext;
			}
			if(_encounterCollectionViaEventCustomerEncounter!=null)
			{
				_encounterCollectionViaEventCustomerEncounter.ActiveContext = base.ActiveContext;
			}
			if(_eventPackageDetailsCollectionViaCustomerOrderHistory!=null)
			{
				_eventPackageDetailsCollectionViaCustomerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventAppointmentChangeLog_!=null)
			{
				_eventsCollectionViaEventAppointmentChangeLog_.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventAppointmentChangeLog!=null)
			{
				_eventsCollectionViaEventAppointmentChangeLog.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventAppointmentCancellationLog!=null)
			{
				_eventsCollectionViaEventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventCustomerQuestionAnswer!=null)
			{
				_eventsCollectionViaEventCustomerQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaDependentDisqualifiedTest!=null)
			{
				_eventsCollectionViaDependentDisqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaCustomerOrderHistory!=null)
			{
				_eventsCollectionViaCustomerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaDisqualifiedTest!=null)
			{
				_eventsCollectionViaDisqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaCallQueueCustomer!=null)
			{
				_eventsCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_eventTestCollectionViaCustomerOrderHistory!=null)
			{
				_eventTestCollectionViaCustomerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_exitInterviewQuestionCollectionViaExitInterviewAnswer!=null)
			{
				_exitInterviewQuestionCollectionViaExitInterviewAnswer.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaParticipationConsentSignature_!=null)
			{
				_fileCollectionViaParticipationConsentSignature_.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaParticipationConsentSignature!=null)
			{
				_fileCollectionViaParticipationConsentSignature.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaEventCustomerGiftCard!=null)
			{
				_fileCollectionViaEventCustomerGiftCard.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaEventCustomerGiftCard_!=null)
			{
				_fileCollectionViaEventCustomerGiftCard_.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaFluConsentSignature_!=null)
			{
				_fileCollectionViaFluConsentSignature_.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaPhysicianRecordRequestSignature!=null)
			{
				_fileCollectionViaPhysicianRecordRequestSignature.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaChaperoneSignature!=null)
			{
				_fileCollectionViaChaperoneSignature.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaExitInterviewSignature!=null)
			{
				_fileCollectionViaExitInterviewSignature.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaChaperoneSignature_!=null)
			{
				_fileCollectionViaChaperoneSignature_.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaFluConsentSignature!=null)
			{
				_fileCollectionViaFluConsentSignature.ActiveContext = base.ActiveContext;
			}
			if(_fluConsentQuestionCollectionViaFluConsentAnswer!=null)
			{
				_fluConsentQuestionCollectionViaFluConsentAnswer.ActiveContext = base.ActiveContext;
			}
			if(_icdCodesCollectionViaEventCustomerIcdCodes!=null)
			{
				_icdCodesCollectionViaEventCustomerIcdCodes.ActiveContext = base.ActiveContext;
			}
			if(_languageCollectionViaCallQueueCustomer!=null)
			{
				_languageCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerOrderHistory!=null)
			{
				_lookupCollectionViaCustomerOrderHistory.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCallQueueCustomer!=null)
			{
				_lookupCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEventAppointmentChangeLog!=null)
			{
				_lookupCollectionViaEventAppointmentChangeLog.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCheckListAnswer!=null)
			{
				_lookupCollectionViaCheckListAnswer.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaPcpDisposition!=null)
			{
				_lookupCollectionViaPcpDisposition.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEventAppointmentCancellationLog!=null)
			{
				_lookupCollectionViaEventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_medicareQuestionCollectionViaCustomerMedicareQuestionAnswer!=null)
			{
				_medicareQuestionCollectionViaCustomerMedicareQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_ndcCollectionViaEventCustomerCurrentMedication!=null)
			{
				_ndcCollectionViaEventCustomerCurrentMedication.ActiveContext = base.ActiveContext;
			}
			if(_notesDetailsCollectionViaCallQueueCustomer!=null)
			{
				_notesDetailsCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_notificationCollectionViaEventCustomerNotification!=null)
			{
				_notificationCollectionViaEventCustomerNotification.ActiveContext = base.ActiveContext;
			}
			if(_notificationTypeCollectionViaEventCustomerTestNotPerformedNotification!=null)
			{
				_notificationTypeCollectionViaEventCustomerTestNotPerformedNotification.ActiveContext = base.ActiveContext;
			}
			if(_notificationTypeCollectionViaEventCustomerNotification!=null)
			{
				_notificationTypeCollectionViaEventCustomerNotification.ActiveContext = base.ActiveContext;
			}
			if(_orderDetailCollectionViaEventCustomerOrderDetail!=null)
			{
				_orderDetailCollectionViaEventCustomerOrderDetail.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaExitInterviewAnswer_!=null)
			{
				_organizationRoleUserCollectionViaExitInterviewAnswer_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaParticipationConsentSignature!=null)
			{
				_organizationRoleUserCollectionViaParticipationConsentSignature.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaFluConsentSignature!=null)
			{
				_organizationRoleUserCollectionViaFluConsentSignature.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaPcpDisposition_!=null)
			{
				_organizationRoleUserCollectionViaPcpDisposition_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaPcpDisposition!=null)
			{
				_organizationRoleUserCollectionViaPcpDisposition.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician!=null)
			{
				_organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification!=null)
			{
				_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventCustomerRetest!=null)
			{
				_organizationRoleUserCollectionViaEventCustomerRetest.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaExitInterviewAnswer!=null)
			{
				_organizationRoleUserCollectionViaExitInterviewAnswer.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaExitInterviewSignature!=null)
			{
				_organizationRoleUserCollectionViaExitInterviewSignature.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaFluConsentAnswer_!=null)
			{
				_organizationRoleUserCollectionViaFluConsentAnswer_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventCustomerQuestionAnswer!=null)
			{
				_organizationRoleUserCollectionViaEventCustomerQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventCustomerQuestionAnswer_!=null)
			{
				_organizationRoleUserCollectionViaEventCustomerQuestionAnswer_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaFluConsentAnswer!=null)
			{
				_organizationRoleUserCollectionViaFluConsentAnswer.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaChaperoneSignature!=null)
			{
				_organizationRoleUserCollectionViaChaperoneSignature.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaSurveyAnswer!=null)
			{
				_organizationRoleUserCollectionViaSurveyAnswer.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaDisqualifiedTest_!=null)
			{
				_organizationRoleUserCollectionViaDisqualifiedTest_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventAppointmentChangeLog!=null)
			{
				_organizationRoleUserCollectionViaEventAppointmentChangeLog.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaChaperoneAnswer_!=null)
			{
				_organizationRoleUserCollectionViaChaperoneAnswer_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventAppointmentCancellationLog!=null)
			{
				_organizationRoleUserCollectionViaEventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCheckListAnswer_!=null)
			{
				_organizationRoleUserCollectionViaCheckListAnswer_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerHealthInfo!=null)
			{
				_organizationRoleUserCollectionViaCustomerHealthInfo.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerHealthInfoArchive!=null)
			{
				_organizationRoleUserCollectionViaCustomerHealthInfoArchive.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaDisqualifiedTest!=null)
			{
				_organizationRoleUserCollectionViaDisqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCheckListAnswer!=null)
			{
				_organizationRoleUserCollectionViaCheckListAnswer.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaSurveyAnswer_!=null)
			{
				_organizationRoleUserCollectionViaSurveyAnswer_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaChaperoneAnswer!=null)
			{
				_organizationRoleUserCollectionViaChaperoneAnswer.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueCustomer__!=null)
			{
				_organizationRoleUserCollectionViaCallQueueCustomer__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventCustomerGiftCard!=null)
			{
				_organizationRoleUserCollectionViaEventCustomerGiftCard.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueCustomer!=null)
			{
				_organizationRoleUserCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueCustomer_!=null)
			{
				_organizationRoleUserCollectionViaCallQueueCustomer_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaPhysicianRecordRequestSignature!=null)
			{
				_organizationRoleUserCollectionViaPhysicianRecordRequestSignature.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer!=null)
			{
				_organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_packageCollectionViaEventCustomerPreApprovedPackageTest!=null)
			{
				_packageCollectionViaEventCustomerPreApprovedPackageTest.ActiveContext = base.ActiveContext;
			}
			if(_physicianProfileCollectionViaPhysicianEvaluation!=null)
			{
				_physicianProfileCollectionViaPhysicianEvaluation.ActiveContext = base.ActiveContext;
			}
			if(_physicianProfileCollectionViaPhysicianCustomerAssignment_!=null)
			{
				_physicianProfileCollectionViaPhysicianCustomerAssignment_.ActiveContext = base.ActiveContext;
			}
			if(_physicianProfileCollectionViaPhysicianCustomerAssignment!=null)
			{
				_physicianProfileCollectionViaPhysicianCustomerAssignment.ActiveContext = base.ActiveContext;
			}
			if(_preQualificationQuestionCollectionViaEventCustomerQuestionAnswer!=null)
			{
				_preQualificationQuestionCollectionViaEventCustomerQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_preQualificationQuestionCollectionViaDisqualifiedTest!=null)
			{
				_preQualificationQuestionCollectionViaDisqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_prospectCustomerCollectionViaClickConversion!=null)
			{
				_prospectCustomerCollectionViaClickConversion.ActiveContext = base.ActiveContext;
			}
			if(_prospectCustomerCollectionViaCallQueueCustomer!=null)
			{
				_prospectCustomerCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_refundRequestCollectionViaEventAppointmentCancellationLog!=null)
			{
				_refundRequestCollectionViaEventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_rescheduleCancelDispositionCollectionViaEventAppointmentChangeLog!=null)
			{
				_rescheduleCancelDispositionCollectionViaEventAppointmentChangeLog.ActiveContext = base.ActiveContext;
			}
			if(_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog!=null)
			{
				_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_surveyQuestionCollectionViaSurveyAnswer!=null)
			{
				_surveyQuestionCollectionViaSurveyAnswer.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaEventCustomerPreApprovedPackageTest!=null)
			{
				_testCollectionViaEventCustomerPreApprovedPackageTest.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaDisqualifiedTest!=null)
			{
				_testCollectionViaDisqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaDependentDisqualifiedTest!=null)
			{
				_testCollectionViaDependentDisqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaEventCustomerRetest!=null)
			{
				_testCollectionViaEventCustomerRetest.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaEventCustomerTestNotPerformedNotification!=null)
			{
				_testCollectionViaEventCustomerTestNotPerformedNotification.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaEventCustomerPreApprovedTest!=null)
			{
				_testCollectionViaEventCustomerPreApprovedTest.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaEventCustomerRequiredTest!=null)
			{
				_testCollectionViaEventCustomerRequiredTest.ActiveContext = base.ActiveContext;
			}
			if(_afaffiliateCampaign!=null)
			{
				_afaffiliateCampaign.ActiveContext = base.ActiveContext;
			}
			if(_campaign!=null)
			{
				_campaign.ActiveContext = base.ActiveContext;
			}
			if(_customerProfile!=null)
			{
				_customerProfile.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileHistory!=null)
			{
				_customerProfileHistory.ActiveContext = base.ActiveContext;
			}
			if(_customerRegistrationNotes!=null)
			{
				_customerRegistrationNotes.ActiveContext = base.ActiveContext;
			}
			if(_eventAppointment!=null)
			{
				_eventAppointment.ActiveContext = base.ActiveContext;
			}
			if(_events!=null)
			{
				_events.ActiveContext = base.ActiveContext;
			}
			if(_gcNotGivenReason!=null)
			{
				_gcNotGivenReason.ActiveContext = base.ActiveContext;
			}
			if(_hospitalFacility!=null)
			{
				_hospitalFacility.ActiveContext = base.ActiveContext;
			}
			if(_lookup_!=null)
			{
				_lookup_.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser_!=null)
			{
				_organizationRoleUser_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_customerSkipReview!=null)
			{
				_customerSkipReview.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerBarrier!=null)
			{
				_eventCustomerBarrier.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerBasicBioMetric!=null)
			{
				_eventCustomerBasicBioMetric.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerEvaluationLock!=null)
			{
				_eventCustomerEvaluationLock.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerResult!=null)
			{
				_eventCustomerResult.ActiveContext = base.ActiveContext;
			}
			if(_pcpAppointment_!=null)
			{
				_pcpAppointment_.ActiveContext = base.ActiveContext;
			}
			if(_screeningAuthorization!=null)
			{
				_screeningAuthorization.ActiveContext = base.ActiveContext;
			}
		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_callQueueCustomer = null;
			_chaperoneAnswer = null;
			_chaperoneSignature = null;
			_checkListAnswer = null;
			_clickConversion = null;
			_customerHealthInfo = null;
			_customerHealthInfoArchive = null;
			_customerMedicareQuestionAnswer = null;
			_customerOrderHistory = null;
			_dependentDisqualifiedTest = null;
			_disqualifiedTest = null;
			_eventAppointmentCancellationLog = null;
			_eventAppointmentChangeLog = null;
			_eventCustomerCriticalQuestion = null;
			_eventCustomerCurrentMedication = null;
			_eventCustomerCustomNotification = null;
			_eventCustomerDiagnosis = null;
			_eventCustomerEligibility = null;
			_eventCustomerEncounter = null;
			_eventCustomerGiftCard = null;
			_eventCustomerIcdCodes = null;
			_eventCustomerNotification = null;
			_eventCustomerOrderDetail = null;
			_eventCustomerPreApprovedPackageTest = null;
			_eventCustomerPreApprovedTest = null;
			_eventCustomerPrimaryCarePhysician = null;
			_eventCustomerQuestionAnswer = null;
			_eventCustomerRequiredTest = null;
			_eventCustomerRetest = null;
			_eventCustomerTestNotPerformedNotification = null;
			_exitInterviewAnswer = null;
			_exitInterviewSignature = null;
			_fluConsentAnswer = null;
			_fluConsentSignature = null;
			_participationConsentSignature = null;
			_pcpDisposition = null;
			_physicianCustomerAssignment = null;
			_physicianEvaluation = null;
			_physicianRecordRequestSignature = null;
			_surveyAnswer = null;
			_accountCollectionViaCallQueueCustomer = null;
			_activityTypeCollectionViaCallQueueCustomer = null;
			_callQueueCollectionViaCallQueueCustomer = null;
			_callQueueCriteriaCollectionViaCallQueueCustomer = null;
			_campaignCollectionViaCallQueueCustomer = null;
			_chaperoneQuestionCollectionViaChaperoneAnswer = null;
			_chargeCardCollectionViaEventCustomerEligibility = null;
			_checkListQuestionCollectionViaExitInterviewSignature = null;
			_checkListQuestionCollectionViaCheckListAnswer = null;
			_clickLogCollectionViaClickConversion = null;
			_corporateUploadCollectionViaCustomerOrderHistory = null;
			_criticalQuestionCollectionViaEventCustomerCriticalQuestion = null;
			_customerHealthQuestionsCollectionViaCustomerHealthInfoArchive = null;
			_customerHealthQuestionsCollectionViaCustomerHealthInfo = null;
			_customerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician = null;
			_customerProfileCollectionViaCustomerHealthInfo = null;
			_customerProfileCollectionViaCallQueueCustomer = null;
			_customerProfileCollectionViaDependentDisqualifiedTest = null;
			_customerProfileCollectionViaClickConversion = null;
			_customerProfileCollectionViaDisqualifiedTest = null;
			_customerProfileCollectionViaCustomerOrderHistory = null;
			_customerProfileCollectionViaCustomerHealthInfoArchive = null;
			_customerProfileCollectionViaEventCustomerQuestionAnswer = null;
			_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog = null;
			_customEventNotificationCollectionViaEventCustomerCustomNotification = null;
			_eligibilityCollectionViaEventCustomerEligibility = null;
			_encounterCollectionViaEventCustomerEncounter = null;
			_eventPackageDetailsCollectionViaCustomerOrderHistory = null;
			_eventsCollectionViaEventAppointmentChangeLog_ = null;
			_eventsCollectionViaEventAppointmentChangeLog = null;
			_eventsCollectionViaEventAppointmentCancellationLog = null;
			_eventsCollectionViaEventCustomerQuestionAnswer = null;
			_eventsCollectionViaDependentDisqualifiedTest = null;
			_eventsCollectionViaCustomerOrderHistory = null;
			_eventsCollectionViaDisqualifiedTest = null;
			_eventsCollectionViaCallQueueCustomer = null;
			_eventTestCollectionViaCustomerOrderHistory = null;
			_exitInterviewQuestionCollectionViaExitInterviewAnswer = null;
			_fileCollectionViaParticipationConsentSignature_ = null;
			_fileCollectionViaParticipationConsentSignature = null;
			_fileCollectionViaEventCustomerGiftCard = null;
			_fileCollectionViaEventCustomerGiftCard_ = null;
			_fileCollectionViaFluConsentSignature_ = null;
			_fileCollectionViaPhysicianRecordRequestSignature = null;
			_fileCollectionViaChaperoneSignature = null;
			_fileCollectionViaExitInterviewSignature = null;
			_fileCollectionViaChaperoneSignature_ = null;
			_fileCollectionViaFluConsentSignature = null;
			_fluConsentQuestionCollectionViaFluConsentAnswer = null;
			_icdCodesCollectionViaEventCustomerIcdCodes = null;
			_languageCollectionViaCallQueueCustomer = null;
			_lookupCollectionViaCustomerOrderHistory = null;
			_lookupCollectionViaCallQueueCustomer = null;
			_lookupCollectionViaEventAppointmentChangeLog = null;
			_lookupCollectionViaCheckListAnswer = null;
			_lookupCollectionViaPcpDisposition = null;
			_lookupCollectionViaEventAppointmentCancellationLog = null;
			_medicareQuestionCollectionViaCustomerMedicareQuestionAnswer = null;
			_ndcCollectionViaEventCustomerCurrentMedication = null;
			_notesDetailsCollectionViaCallQueueCustomer = null;
			_notificationCollectionViaEventCustomerNotification = null;
			_notificationTypeCollectionViaEventCustomerTestNotPerformedNotification = null;
			_notificationTypeCollectionViaEventCustomerNotification = null;
			_orderDetailCollectionViaEventCustomerOrderDetail = null;
			_organizationRoleUserCollectionViaExitInterviewAnswer_ = null;
			_organizationRoleUserCollectionViaParticipationConsentSignature = null;
			_organizationRoleUserCollectionViaFluConsentSignature = null;
			_organizationRoleUserCollectionViaPcpDisposition_ = null;
			_organizationRoleUserCollectionViaPcpDisposition = null;
			_organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician = null;
			_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification = null;
			_organizationRoleUserCollectionViaEventCustomerRetest = null;
			_organizationRoleUserCollectionViaExitInterviewAnswer = null;
			_organizationRoleUserCollectionViaExitInterviewSignature = null;
			_organizationRoleUserCollectionViaFluConsentAnswer_ = null;
			_organizationRoleUserCollectionViaEventCustomerQuestionAnswer = null;
			_organizationRoleUserCollectionViaEventCustomerQuestionAnswer_ = null;
			_organizationRoleUserCollectionViaFluConsentAnswer = null;
			_organizationRoleUserCollectionViaChaperoneSignature = null;
			_organizationRoleUserCollectionViaSurveyAnswer = null;
			_organizationRoleUserCollectionViaDisqualifiedTest_ = null;
			_organizationRoleUserCollectionViaEventAppointmentChangeLog = null;
			_organizationRoleUserCollectionViaChaperoneAnswer_ = null;
			_organizationRoleUserCollectionViaEventAppointmentCancellationLog = null;
			_organizationRoleUserCollectionViaCheckListAnswer_ = null;
			_organizationRoleUserCollectionViaCustomerHealthInfo = null;
			_organizationRoleUserCollectionViaCustomerHealthInfoArchive = null;
			_organizationRoleUserCollectionViaDisqualifiedTest = null;
			_organizationRoleUserCollectionViaCheckListAnswer = null;
			_organizationRoleUserCollectionViaSurveyAnswer_ = null;
			_organizationRoleUserCollectionViaChaperoneAnswer = null;
			_organizationRoleUserCollectionViaCallQueueCustomer__ = null;
			_organizationRoleUserCollectionViaEventCustomerGiftCard = null;
			_organizationRoleUserCollectionViaCallQueueCustomer = null;
			_organizationRoleUserCollectionViaCallQueueCustomer_ = null;
			_organizationRoleUserCollectionViaPhysicianRecordRequestSignature = null;
			_organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer = null;
			_packageCollectionViaEventCustomerPreApprovedPackageTest = null;
			_physicianProfileCollectionViaPhysicianEvaluation = null;
			_physicianProfileCollectionViaPhysicianCustomerAssignment_ = null;
			_physicianProfileCollectionViaPhysicianCustomerAssignment = null;
			_preQualificationQuestionCollectionViaEventCustomerQuestionAnswer = null;
			_preQualificationQuestionCollectionViaDisqualifiedTest = null;
			_prospectCustomerCollectionViaClickConversion = null;
			_prospectCustomerCollectionViaCallQueueCustomer = null;
			_refundRequestCollectionViaEventAppointmentCancellationLog = null;
			_rescheduleCancelDispositionCollectionViaEventAppointmentChangeLog = null;
			_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog = null;
			_surveyQuestionCollectionViaSurveyAnswer = null;
			_testCollectionViaEventCustomerPreApprovedPackageTest = null;
			_testCollectionViaDisqualifiedTest = null;
			_testCollectionViaDependentDisqualifiedTest = null;
			_testCollectionViaEventCustomerRetest = null;
			_testCollectionViaEventCustomerTestNotPerformedNotification = null;
			_testCollectionViaEventCustomerPreApprovedTest = null;
			_testCollectionViaEventCustomerRequiredTest = null;
			_afaffiliateCampaign = null;
			_campaign = null;
			_customerProfile = null;
			_customerProfileHistory = null;
			_customerRegistrationNotes = null;
			_eventAppointment = null;
			_events = null;
			_gcNotGivenReason = null;
			_hospitalFacility = null;
			_lookup_ = null;
			_lookup = null;
			_organizationRoleUser_ = null;
			_organizationRoleUser = null;
			_customerSkipReview = null;
			_eventCustomerBarrier = null;
			_eventCustomerBasicBioMetric = null;
			_eventCustomerEvaluationLock = null;
			_eventCustomerResult = null;
			_pcpAppointment_ = null;
			_screeningAuthorization = null;
			PerformDependencyInjection();
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitClassMembersComplete();
		}

		#region Custom Property Hashtable Setup
		/// <summary> Initializes the hashtables for the entity type and entity field custom properties. </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Dictionary<string, string>();
			_fieldsCustomProperties = new Dictionary<string, Dictionary<string, string>>();

			Dictionary<string, string> fieldHashtable = null;
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventCustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsPaymentOnline", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AppointmentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsTestConducted", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BMailReports", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Notes", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NoShow", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OfflineCustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AffiliateCampaignId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SignInSource", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AdvocateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Hipaastatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MarketingSource", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ClickId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PartnerRelease", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HospitalFacilityId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AbnStatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PcpConsentStatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InsuranceReleaseStatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CampaignId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AwvVisitId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LeftWithoutScreeningReasonId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EnableTexting", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsGiftCertificateDelivered", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GiftCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PatientDetailId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LeftWithoutScreeningNotesId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerProfileHistoryId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsAppointmentConfirmed", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ConfirmedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsForRetest", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PreferredContactType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GcNotGivenReasonId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NoShowDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SingleTestOverride", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsParticipationConsentSigned", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsPhysicianRecordRequestSigned", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsFluVaccineConsentSigned", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _afaffiliateCampaign</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAfaffiliateCampaign(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _afaffiliateCampaign, new PropertyChangedEventHandler( OnAfaffiliateCampaignPropertyChanged ), "AfaffiliateCampaign", EventCustomersEntity.Relations.AfaffiliateCampaignEntityUsingAffiliateCampaignId, true, signalRelatedEntity, "EventCustomers", resetFKFields, new int[] { (int)EventCustomersFieldIndex.AffiliateCampaignId } );		
			_afaffiliateCampaign = null;
		}

		/// <summary> setups the sync logic for member _afaffiliateCampaign</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAfaffiliateCampaign(IEntity2 relatedEntity)
		{
			if(_afaffiliateCampaign!=relatedEntity)
			{
				DesetupSyncAfaffiliateCampaign(true, true);
				_afaffiliateCampaign = (AfaffiliateCampaignEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _afaffiliateCampaign, new PropertyChangedEventHandler( OnAfaffiliateCampaignPropertyChanged ), "AfaffiliateCampaign", EventCustomersEntity.Relations.AfaffiliateCampaignEntityUsingAffiliateCampaignId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAfaffiliateCampaignPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _campaign</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCampaign(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _campaign, new PropertyChangedEventHandler( OnCampaignPropertyChanged ), "Campaign", EventCustomersEntity.Relations.CampaignEntityUsingCampaignId, true, signalRelatedEntity, "EventCustomers", resetFKFields, new int[] { (int)EventCustomersFieldIndex.CampaignId } );		
			_campaign = null;
		}

		/// <summary> setups the sync logic for member _campaign</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCampaign(IEntity2 relatedEntity)
		{
			if(_campaign!=relatedEntity)
			{
				DesetupSyncCampaign(true, true);
				_campaign = (CampaignEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _campaign, new PropertyChangedEventHandler( OnCampaignPropertyChanged ), "Campaign", EventCustomersEntity.Relations.CampaignEntityUsingCampaignId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCampaignPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _customerProfile</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerProfile(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", EventCustomersEntity.Relations.CustomerProfileEntityUsingCustomerId, true, signalRelatedEntity, "EventCustomers", resetFKFields, new int[] { (int)EventCustomersFieldIndex.CustomerId } );		
			_customerProfile = null;
		}

		/// <summary> setups the sync logic for member _customerProfile</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerProfile(IEntity2 relatedEntity)
		{
			if(_customerProfile!=relatedEntity)
			{
				DesetupSyncCustomerProfile(true, true);
				_customerProfile = (CustomerProfileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", EventCustomersEntity.Relations.CustomerProfileEntityUsingCustomerId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerProfilePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _customerProfileHistory</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerProfileHistory(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerProfileHistory, new PropertyChangedEventHandler( OnCustomerProfileHistoryPropertyChanged ), "CustomerProfileHistory", EventCustomersEntity.Relations.CustomerProfileHistoryEntityUsingCustomerProfileHistoryId, true, signalRelatedEntity, "EventCustomers", resetFKFields, new int[] { (int)EventCustomersFieldIndex.CustomerProfileHistoryId } );		
			_customerProfileHistory = null;
		}

		/// <summary> setups the sync logic for member _customerProfileHistory</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerProfileHistory(IEntity2 relatedEntity)
		{
			if(_customerProfileHistory!=relatedEntity)
			{
				DesetupSyncCustomerProfileHistory(true, true);
				_customerProfileHistory = (CustomerProfileHistoryEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerProfileHistory, new PropertyChangedEventHandler( OnCustomerProfileHistoryPropertyChanged ), "CustomerProfileHistory", EventCustomersEntity.Relations.CustomerProfileHistoryEntityUsingCustomerProfileHistoryId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerProfileHistoryPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _customerRegistrationNotes</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerRegistrationNotes(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerRegistrationNotes, new PropertyChangedEventHandler( OnCustomerRegistrationNotesPropertyChanged ), "CustomerRegistrationNotes", EventCustomersEntity.Relations.CustomerRegistrationNotesEntityUsingLeftWithoutScreeningNotesId, true, signalRelatedEntity, "EventCustomers", resetFKFields, new int[] { (int)EventCustomersFieldIndex.LeftWithoutScreeningNotesId } );		
			_customerRegistrationNotes = null;
		}

		/// <summary> setups the sync logic for member _customerRegistrationNotes</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerRegistrationNotes(IEntity2 relatedEntity)
		{
			if(_customerRegistrationNotes!=relatedEntity)
			{
				DesetupSyncCustomerRegistrationNotes(true, true);
				_customerRegistrationNotes = (CustomerRegistrationNotesEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerRegistrationNotes, new PropertyChangedEventHandler( OnCustomerRegistrationNotesPropertyChanged ), "CustomerRegistrationNotes", EventCustomersEntity.Relations.CustomerRegistrationNotesEntityUsingLeftWithoutScreeningNotesId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerRegistrationNotesPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _eventAppointment</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEventAppointment(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _eventAppointment, new PropertyChangedEventHandler( OnEventAppointmentPropertyChanged ), "EventAppointment", EventCustomersEntity.Relations.EventAppointmentEntityUsingAppointmentId, true, signalRelatedEntity, "EventCustomers", resetFKFields, new int[] { (int)EventCustomersFieldIndex.AppointmentId } );		
			_eventAppointment = null;
		}

		/// <summary> setups the sync logic for member _eventAppointment</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEventAppointment(IEntity2 relatedEntity)
		{
			if(_eventAppointment!=relatedEntity)
			{
				DesetupSyncEventAppointment(true, true);
				_eventAppointment = (EventAppointmentEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _eventAppointment, new PropertyChangedEventHandler( OnEventAppointmentPropertyChanged ), "EventAppointment", EventCustomersEntity.Relations.EventAppointmentEntityUsingAppointmentId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEventAppointmentPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _events</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEvents(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", EventCustomersEntity.Relations.EventsEntityUsingEventId, true, signalRelatedEntity, "EventCustomers", resetFKFields, new int[] { (int)EventCustomersFieldIndex.EventId } );		
			_events = null;
		}

		/// <summary> setups the sync logic for member _events</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEvents(IEntity2 relatedEntity)
		{
			if(_events!=relatedEntity)
			{
				DesetupSyncEvents(true, true);
				_events = (EventsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", EventCustomersEntity.Relations.EventsEntityUsingEventId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEventsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gcNotGivenReason</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGcNotGivenReason(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gcNotGivenReason, new PropertyChangedEventHandler( OnGcNotGivenReasonPropertyChanged ), "GcNotGivenReason", EventCustomersEntity.Relations.GcNotGivenReasonEntityUsingGcNotGivenReasonId, true, signalRelatedEntity, "EventCustomers", resetFKFields, new int[] { (int)EventCustomersFieldIndex.GcNotGivenReasonId } );		
			_gcNotGivenReason = null;
		}

		/// <summary> setups the sync logic for member _gcNotGivenReason</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGcNotGivenReason(IEntity2 relatedEntity)
		{
			if(_gcNotGivenReason!=relatedEntity)
			{
				DesetupSyncGcNotGivenReason(true, true);
				_gcNotGivenReason = (GcNotGivenReasonEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _gcNotGivenReason, new PropertyChangedEventHandler( OnGcNotGivenReasonPropertyChanged ), "GcNotGivenReason", EventCustomersEntity.Relations.GcNotGivenReasonEntityUsingGcNotGivenReasonId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGcNotGivenReasonPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _hospitalFacility</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncHospitalFacility(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _hospitalFacility, new PropertyChangedEventHandler( OnHospitalFacilityPropertyChanged ), "HospitalFacility", EventCustomersEntity.Relations.HospitalFacilityEntityUsingHospitalFacilityId, true, signalRelatedEntity, "EventCustomers", resetFKFields, new int[] { (int)EventCustomersFieldIndex.HospitalFacilityId } );		
			_hospitalFacility = null;
		}

		/// <summary> setups the sync logic for member _hospitalFacility</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncHospitalFacility(IEntity2 relatedEntity)
		{
			if(_hospitalFacility!=relatedEntity)
			{
				DesetupSyncHospitalFacility(true, true);
				_hospitalFacility = (HospitalFacilityEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _hospitalFacility, new PropertyChangedEventHandler( OnHospitalFacilityPropertyChanged ), "HospitalFacility", EventCustomersEntity.Relations.HospitalFacilityEntityUsingHospitalFacilityId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnHospitalFacilityPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _lookup_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", EventCustomersEntity.Relations.LookupEntityUsingPreferredContactType, true, signalRelatedEntity, "EventCustomers_", resetFKFields, new int[] { (int)EventCustomersFieldIndex.PreferredContactType } );		
			_lookup_ = null;
		}

		/// <summary> setups the sync logic for member _lookup_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup_(IEntity2 relatedEntity)
		{
			if(_lookup_!=relatedEntity)
			{
				DesetupSyncLookup_(true, true);
				_lookup_ = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", EventCustomersEntity.Relations.LookupEntityUsingPreferredContactType, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookup_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _lookup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", EventCustomersEntity.Relations.LookupEntityUsingLeftWithoutScreeningReasonId, true, signalRelatedEntity, "EventCustomers", resetFKFields, new int[] { (int)EventCustomersFieldIndex.LeftWithoutScreeningReasonId } );		
			_lookup = null;
		}

		/// <summary> setups the sync logic for member _lookup</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup(IEntity2 relatedEntity)
		{
			if(_lookup!=relatedEntity)
			{
				DesetupSyncLookup(true, true);
				_lookup = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", EventCustomersEntity.Relations.LookupEntityUsingLeftWithoutScreeningReasonId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookupPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _organizationRoleUser_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", EventCustomersEntity.Relations.OrganizationRoleUserEntityUsingConfirmedBy, true, signalRelatedEntity, "EventCustomers_", resetFKFields, new int[] { (int)EventCustomersFieldIndex.ConfirmedBy } );		
			_organizationRoleUser_ = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser_(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser_!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser_(true, true);
				_organizationRoleUser_ = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", EventCustomersEntity.Relations.OrganizationRoleUserEntityUsingConfirmedBy, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUser_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _organizationRoleUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", EventCustomersEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, signalRelatedEntity, "EventCustomers", resetFKFields, new int[] { (int)EventCustomersFieldIndex.CreatedByOrgRoleUserId } );		
			_organizationRoleUser = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser(true, true);
				_organizationRoleUser = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", EventCustomersEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _customerSkipReview</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerSkipReview(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerSkipReview, new PropertyChangedEventHandler( OnCustomerSkipReviewPropertyChanged ), "CustomerSkipReview", EventCustomersEntity.Relations.CustomerSkipReviewEntityUsingEventCustomerId, false, signalRelatedEntity, "EventCustomers", false, new int[] { (int)EventCustomersFieldIndex.EventCustomerId } );
			_customerSkipReview = null;
		}
		
		/// <summary> setups the sync logic for member _customerSkipReview</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerSkipReview(IEntity2 relatedEntity)
		{
			if(_customerSkipReview!=relatedEntity)
			{
				DesetupSyncCustomerSkipReview(true, true);
				_customerSkipReview = (CustomerSkipReviewEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerSkipReview, new PropertyChangedEventHandler( OnCustomerSkipReviewPropertyChanged ), "CustomerSkipReview", EventCustomersEntity.Relations.CustomerSkipReviewEntityUsingEventCustomerId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerSkipReviewPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _eventCustomerBarrier</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEventCustomerBarrier(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _eventCustomerBarrier, new PropertyChangedEventHandler( OnEventCustomerBarrierPropertyChanged ), "EventCustomerBarrier", EventCustomersEntity.Relations.EventCustomerBarrierEntityUsingEventCustomerId, false, signalRelatedEntity, "EventCustomers", false, new int[] { (int)EventCustomersFieldIndex.EventCustomerId } );
			_eventCustomerBarrier = null;
		}
		
		/// <summary> setups the sync logic for member _eventCustomerBarrier</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEventCustomerBarrier(IEntity2 relatedEntity)
		{
			if(_eventCustomerBarrier!=relatedEntity)
			{
				DesetupSyncEventCustomerBarrier(true, true);
				_eventCustomerBarrier = (EventCustomerBarrierEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _eventCustomerBarrier, new PropertyChangedEventHandler( OnEventCustomerBarrierPropertyChanged ), "EventCustomerBarrier", EventCustomersEntity.Relations.EventCustomerBarrierEntityUsingEventCustomerId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEventCustomerBarrierPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _eventCustomerBasicBioMetric</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEventCustomerBasicBioMetric(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _eventCustomerBasicBioMetric, new PropertyChangedEventHandler( OnEventCustomerBasicBioMetricPropertyChanged ), "EventCustomerBasicBioMetric", EventCustomersEntity.Relations.EventCustomerBasicBioMetricEntityUsingEventCustomerId, false, signalRelatedEntity, "EventCustomers", false, new int[] { (int)EventCustomersFieldIndex.EventCustomerId } );
			_eventCustomerBasicBioMetric = null;
		}
		
		/// <summary> setups the sync logic for member _eventCustomerBasicBioMetric</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEventCustomerBasicBioMetric(IEntity2 relatedEntity)
		{
			if(_eventCustomerBasicBioMetric!=relatedEntity)
			{
				DesetupSyncEventCustomerBasicBioMetric(true, true);
				_eventCustomerBasicBioMetric = (EventCustomerBasicBioMetricEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _eventCustomerBasicBioMetric, new PropertyChangedEventHandler( OnEventCustomerBasicBioMetricPropertyChanged ), "EventCustomerBasicBioMetric", EventCustomersEntity.Relations.EventCustomerBasicBioMetricEntityUsingEventCustomerId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEventCustomerBasicBioMetricPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _eventCustomerEvaluationLock</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEventCustomerEvaluationLock(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _eventCustomerEvaluationLock, new PropertyChangedEventHandler( OnEventCustomerEvaluationLockPropertyChanged ), "EventCustomerEvaluationLock", EventCustomersEntity.Relations.EventCustomerEvaluationLockEntityUsingEventCustomerId, false, signalRelatedEntity, "EventCustomers", false, new int[] { (int)EventCustomersFieldIndex.EventCustomerId } );
			_eventCustomerEvaluationLock = null;
		}
		
		/// <summary> setups the sync logic for member _eventCustomerEvaluationLock</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEventCustomerEvaluationLock(IEntity2 relatedEntity)
		{
			if(_eventCustomerEvaluationLock!=relatedEntity)
			{
				DesetupSyncEventCustomerEvaluationLock(true, true);
				_eventCustomerEvaluationLock = (EventCustomerEvaluationLockEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _eventCustomerEvaluationLock, new PropertyChangedEventHandler( OnEventCustomerEvaluationLockPropertyChanged ), "EventCustomerEvaluationLock", EventCustomersEntity.Relations.EventCustomerEvaluationLockEntityUsingEventCustomerId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEventCustomerEvaluationLockPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _eventCustomerResult</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEventCustomerResult(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _eventCustomerResult, new PropertyChangedEventHandler( OnEventCustomerResultPropertyChanged ), "EventCustomerResult", EventCustomersEntity.Relations.EventCustomerResultEntityUsingEventCustomerResultId, false, signalRelatedEntity, "EventCustomers", false, new int[] { (int)EventCustomersFieldIndex.EventCustomerId } );
			_eventCustomerResult = null;
		}
		
		/// <summary> setups the sync logic for member _eventCustomerResult</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEventCustomerResult(IEntity2 relatedEntity)
		{
			if(_eventCustomerResult!=relatedEntity)
			{
				DesetupSyncEventCustomerResult(true, true);
				_eventCustomerResult = (EventCustomerResultEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _eventCustomerResult, new PropertyChangedEventHandler( OnEventCustomerResultPropertyChanged ), "EventCustomerResult", EventCustomersEntity.Relations.EventCustomerResultEntityUsingEventCustomerResultId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEventCustomerResultPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _pcpAppointment_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPcpAppointment_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _pcpAppointment_, new PropertyChangedEventHandler( OnPcpAppointment_PropertyChanged ), "PcpAppointment_", EventCustomersEntity.Relations.PcpAppointmentEntityUsingEventCustomerId, false, signalRelatedEntity, "EventCustomers", false, new int[] { (int)EventCustomersFieldIndex.EventCustomerId } );
			_pcpAppointment_ = null;
		}
		
		/// <summary> setups the sync logic for member _pcpAppointment_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPcpAppointment_(IEntity2 relatedEntity)
		{
			if(_pcpAppointment_!=relatedEntity)
			{
				DesetupSyncPcpAppointment_(true, true);
				_pcpAppointment_ = (PcpAppointmentEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _pcpAppointment_, new PropertyChangedEventHandler( OnPcpAppointment_PropertyChanged ), "PcpAppointment_", EventCustomersEntity.Relations.PcpAppointmentEntityUsingEventCustomerId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPcpAppointment_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _screeningAuthorization</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncScreeningAuthorization(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _screeningAuthorization, new PropertyChangedEventHandler( OnScreeningAuthorizationPropertyChanged ), "ScreeningAuthorization", EventCustomersEntity.Relations.ScreeningAuthorizationEntityUsingEventCustomerId, false, signalRelatedEntity, "EventCustomers", false, new int[] { (int)EventCustomersFieldIndex.EventCustomerId } );
			_screeningAuthorization = null;
		}
		
		/// <summary> setups the sync logic for member _screeningAuthorization</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncScreeningAuthorization(IEntity2 relatedEntity)
		{
			if(_screeningAuthorization!=relatedEntity)
			{
				DesetupSyncScreeningAuthorization(true, true);
				_screeningAuthorization = (ScreeningAuthorizationEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _screeningAuthorization, new PropertyChangedEventHandler( OnScreeningAuthorizationPropertyChanged ), "ScreeningAuthorization", EventCustomersEntity.Relations.ScreeningAuthorizationEntityUsingEventCustomerId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnScreeningAuthorizationPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this EventCustomersEntity</param>
		/// <param name="fields">Fields of this entity</param>
		protected virtual void InitClassEmpty(IValidator validator, IEntityFields2 fields)
		{
			OnInitializing();
			base.Fields = fields;
			base.IsNew=true;
			base.Validator = validator;
			InitClassMembers();

			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static EventCustomersRelations Relations
		{
			get	{ return new EventCustomersRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCustomer
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallQueueCustomer")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CallQueueCustomerEntity, 0, null, null, null, null, "CallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChaperoneAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChaperoneAnswer
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ChaperoneAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaperoneAnswerEntityFactory))),
					(IEntityRelation)GetRelationsForField("ChaperoneAnswer")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.ChaperoneAnswerEntity, 0, null, null, null, null, "ChaperoneAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChaperoneSignature' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChaperoneSignature
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ChaperoneSignatureEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaperoneSignatureEntityFactory))),
					(IEntityRelation)GetRelationsForField("ChaperoneSignature")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.ChaperoneSignatureEntity, 0, null, null, null, null, "ChaperoneSignature", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListAnswer
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CheckListAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListAnswerEntityFactory))),
					(IEntityRelation)GetRelationsForField("CheckListAnswer")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CheckListAnswerEntity, 0, null, null, null, null, "CheckListAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ClickConversion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathClickConversion
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ClickConversionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClickConversionEntityFactory))),
					(IEntityRelation)GetRelationsForField("ClickConversion")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.ClickConversionEntity, 0, null, null, null, null, "ClickConversion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerHealthInfo' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerHealthInfo
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerHealthInfoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthInfoEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerHealthInfo")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CustomerHealthInfoEntity, 0, null, null, null, null, "CustomerHealthInfo", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerHealthInfoArchive' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerHealthInfoArchive
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerHealthInfoArchiveEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthInfoArchiveEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerHealthInfoArchive")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CustomerHealthInfoArchiveEntity, 0, null, null, null, null, "CustomerHealthInfoArchive", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerMedicareQuestionAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerMedicareQuestionAnswer
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerMedicareQuestionAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerMedicareQuestionAnswerEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerMedicareQuestionAnswer")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CustomerMedicareQuestionAnswerEntity, 0, null, null, null, null, "CustomerMedicareQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerOrderHistory' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerOrderHistory
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerOrderHistoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerOrderHistoryEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerOrderHistory")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CustomerOrderHistoryEntity, 0, null, null, null, null, "CustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DependentDisqualifiedTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDependentDisqualifiedTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<DependentDisqualifiedTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DependentDisqualifiedTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("DependentDisqualifiedTest")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.DependentDisqualifiedTestEntity, 0, null, null, null, null, "DependentDisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DisqualifiedTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDisqualifiedTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<DisqualifiedTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DisqualifiedTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("DisqualifiedTest")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.DisqualifiedTestEntity, 0, null, null, null, null, "DisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventAppointmentCancellationLog' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventAppointmentCancellationLog
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventAppointmentCancellationLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentCancellationLogEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventAppointmentCancellationLog")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventAppointmentCancellationLogEntity, 0, null, null, null, null, "EventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventAppointmentChangeLog' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventAppointmentChangeLog
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventAppointmentChangeLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentChangeLogEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventAppointmentChangeLog")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventAppointmentChangeLogEntity, 0, null, null, null, null, "EventAppointmentChangeLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerCriticalQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerCriticalQuestion
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerCriticalQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerCriticalQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerCriticalQuestion")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventCustomerCriticalQuestionEntity, 0, null, null, null, null, "EventCustomerCriticalQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerCurrentMedication' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerCurrentMedication
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerCurrentMedicationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerCurrentMedicationEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerCurrentMedication")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventCustomerCurrentMedicationEntity, 0, null, null, null, null, "EventCustomerCurrentMedication", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerCustomNotification' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerCustomNotification
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerCustomNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerCustomNotificationEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerCustomNotification")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventCustomerCustomNotificationEntity, 0, null, null, null, null, "EventCustomerCustomNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerDiagnosis' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerDiagnosis
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerDiagnosisEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerDiagnosisEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerDiagnosis")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventCustomerDiagnosisEntity, 0, null, null, null, null, "EventCustomerDiagnosis", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerEligibility' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerEligibility
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerEligibilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerEligibilityEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerEligibility")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventCustomerEligibilityEntity, 0, null, null, null, null, "EventCustomerEligibility", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerEncounter' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerEncounter
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerEncounterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerEncounterEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerEncounter")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventCustomerEncounterEntity, 0, null, null, null, null, "EventCustomerEncounter", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerGiftCard' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerGiftCard
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerGiftCardEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerGiftCardEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerGiftCard")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventCustomerGiftCardEntity, 0, null, null, null, null, "EventCustomerGiftCard", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerIcdCodes' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerIcdCodes
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerIcdCodesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerIcdCodesEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerIcdCodes")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventCustomerIcdCodesEntity, 0, null, null, null, null, "EventCustomerIcdCodes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerNotification' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerNotification
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerNotificationEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerNotification")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventCustomerNotificationEntity, 0, null, null, null, null, "EventCustomerNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerOrderDetail' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerOrderDetail
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerOrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerOrderDetailEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerOrderDetail")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventCustomerOrderDetailEntity, 0, null, null, null, null, "EventCustomerOrderDetail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerPreApprovedPackageTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerPreApprovedPackageTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerPreApprovedPackageTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerPreApprovedPackageTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerPreApprovedPackageTest")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventCustomerPreApprovedPackageTestEntity, 0, null, null, null, null, "EventCustomerPreApprovedPackageTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerPreApprovedTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerPreApprovedTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerPreApprovedTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerPreApprovedTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerPreApprovedTest")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventCustomerPreApprovedTestEntity, 0, null, null, null, null, "EventCustomerPreApprovedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerPrimaryCarePhysician' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerPrimaryCarePhysician
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerPrimaryCarePhysicianEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerPrimaryCarePhysicianEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerPrimaryCarePhysician")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventCustomerPrimaryCarePhysicianEntity, 0, null, null, null, null, "EventCustomerPrimaryCarePhysician", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerQuestionAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerQuestionAnswer
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerQuestionAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerQuestionAnswerEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerQuestionAnswer")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventCustomerQuestionAnswerEntity, 0, null, null, null, null, "EventCustomerQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerRequiredTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerRequiredTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerRequiredTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerRequiredTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerRequiredTest")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventCustomerRequiredTestEntity, 0, null, null, null, null, "EventCustomerRequiredTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerRetest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerRetest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerRetestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerRetestEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerRetest")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventCustomerRetestEntity, 0, null, null, null, null, "EventCustomerRetest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerTestNotPerformedNotification' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerTestNotPerformedNotification
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerTestNotPerformedNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerTestNotPerformedNotificationEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerTestNotPerformedNotification")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventCustomerTestNotPerformedNotificationEntity, 0, null, null, null, null, "EventCustomerTestNotPerformedNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ExitInterviewAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathExitInterviewAnswer
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ExitInterviewAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ExitInterviewAnswerEntityFactory))),
					(IEntityRelation)GetRelationsForField("ExitInterviewAnswer")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.ExitInterviewAnswerEntity, 0, null, null, null, null, "ExitInterviewAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ExitInterviewSignature' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathExitInterviewSignature
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ExitInterviewSignatureEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ExitInterviewSignatureEntityFactory))),
					(IEntityRelation)GetRelationsForField("ExitInterviewSignature")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.ExitInterviewSignatureEntity, 0, null, null, null, null, "ExitInterviewSignature", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FluConsentAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFluConsentAnswer
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<FluConsentAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentAnswerEntityFactory))),
					(IEntityRelation)GetRelationsForField("FluConsentAnswer")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.FluConsentAnswerEntity, 0, null, null, null, null, "FluConsentAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FluConsentSignature' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFluConsentSignature
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<FluConsentSignatureEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentSignatureEntityFactory))),
					(IEntityRelation)GetRelationsForField("FluConsentSignature")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.FluConsentSignatureEntity, 0, null, null, null, null, "FluConsentSignature", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ParticipationConsentSignature' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathParticipationConsentSignature
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ParticipationConsentSignatureEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ParticipationConsentSignatureEntityFactory))),
					(IEntityRelation)GetRelationsForField("ParticipationConsentSignature")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.ParticipationConsentSignatureEntity, 0, null, null, null, null, "ParticipationConsentSignature", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PcpDisposition' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPcpDisposition
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PcpDispositionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PcpDispositionEntityFactory))),
					(IEntityRelation)GetRelationsForField("PcpDisposition")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.PcpDispositionEntity, 0, null, null, null, null, "PcpDisposition", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianCustomerAssignment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianCustomerAssignment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PhysicianCustomerAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianCustomerAssignmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianCustomerAssignment")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.PhysicianCustomerAssignmentEntity, 0, null, null, null, null, "PhysicianCustomerAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianEvaluation' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianEvaluation
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PhysicianEvaluationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianEvaluationEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianEvaluation")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.PhysicianEvaluationEntity, 0, null, null, null, null, "PhysicianEvaluation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianRecordRequestSignature' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianRecordRequestSignature
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PhysicianRecordRequestSignatureEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianRecordRequestSignatureEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianRecordRequestSignature")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.PhysicianRecordRequestSignatureEntity, 0, null, null, null, null, "PhysicianRecordRequestSignature", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SurveyAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSurveyAnswer
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<SurveyAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyAnswerEntityFactory))),
					(IEntityRelation)GetRelationsForField("SurveyAnswer")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.SurveyAnswerEntity, 0, null, null, null, null, "SurveyAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, GetRelationsForField("AccountCollectionViaCallQueueCustomer"), null, "AccountCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActivityType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActivityTypeCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.ActivityTypeEntity, 0, null, null, GetRelationsForField("ActivityTypeCollectionViaCallQueueCustomer"), null, "ActivityTypeCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CallQueueEntity, 0, null, null, GetRelationsForField("CallQueueCollectionViaCallQueueCustomer"), null, "CallQueueCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCriteria' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCriteriaCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCriteriaEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CallQueueCriteriaEntity, 0, null, null, GetRelationsForField("CallQueueCriteriaCollectionViaCallQueueCustomer"), null, "CallQueueCriteriaCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Campaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CampaignEntity, 0, null, null, GetRelationsForField("CampaignCollectionViaCallQueueCustomer"), null, "CampaignCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChaperoneQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChaperoneQuestionCollectionViaChaperoneAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.ChaperoneAnswerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "ChaperoneAnswer_");
				return new PrefetchPathElement2(new EntityCollection<ChaperoneQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaperoneQuestionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.ChaperoneQuestionEntity, 0, null, null, GetRelationsForField("ChaperoneQuestionCollectionViaChaperoneAnswer"), null, "ChaperoneQuestionCollectionViaChaperoneAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChargeCard' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChargeCardCollectionViaEventCustomerEligibility
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerEligibilityEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerEligibility_");
				return new PrefetchPathElement2(new EntityCollection<ChargeCardEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChargeCardEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.ChargeCardEntity, 0, null, null, GetRelationsForField("ChargeCardCollectionViaEventCustomerEligibility"), null, "ChargeCardCollectionViaEventCustomerEligibility", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListQuestionCollectionViaExitInterviewSignature
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.ExitInterviewSignatureEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "ExitInterviewSignature_");
				return new PrefetchPathElement2(new EntityCollection<CheckListQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListQuestionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CheckListQuestionEntity, 0, null, null, GetRelationsForField("CheckListQuestionCollectionViaExitInterviewSignature"), null, "CheckListQuestionCollectionViaExitInterviewSignature", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListQuestionCollectionViaCheckListAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CheckListAnswerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CheckListAnswer_");
				return new PrefetchPathElement2(new EntityCollection<CheckListQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListQuestionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CheckListQuestionEntity, 0, null, null, GetRelationsForField("CheckListQuestionCollectionViaCheckListAnswer"), null, "CheckListQuestionCollectionViaCheckListAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ClickLog' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathClickLogCollectionViaClickConversion
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.ClickConversionEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "ClickConversion_");
				return new PrefetchPathElement2(new EntityCollection<ClickLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClickLogEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.ClickLogEntity, 0, null, null, GetRelationsForField("ClickLogCollectionViaClickConversion"), null, "ClickLogCollectionViaClickConversion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CorporateUpload' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCorporateUploadCollectionViaCustomerOrderHistory
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CustomerOrderHistoryEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CustomerOrderHistory_");
				return new PrefetchPathElement2(new EntityCollection<CorporateUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CorporateUploadEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CorporateUploadEntity, 0, null, null, GetRelationsForField("CorporateUploadCollectionViaCustomerOrderHistory"), null, "CorporateUploadCollectionViaCustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CriticalQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCriticalQuestionCollectionViaEventCustomerCriticalQuestion
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerCriticalQuestionEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerCriticalQuestion_");
				return new PrefetchPathElement2(new EntityCollection<CriticalQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CriticalQuestionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CriticalQuestionEntity, 0, null, null, GetRelationsForField("CriticalQuestionCollectionViaEventCustomerCriticalQuestion"), null, "CriticalQuestionCollectionViaEventCustomerCriticalQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerHealthQuestions' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerHealthQuestionsCollectionViaCustomerHealthInfoArchive
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CustomerHealthInfoArchiveEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CustomerHealthInfoArchive_");
				return new PrefetchPathElement2(new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, 0, null, null, GetRelationsForField("CustomerHealthQuestionsCollectionViaCustomerHealthInfoArchive"), null, "CustomerHealthQuestionsCollectionViaCustomerHealthInfoArchive", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerHealthQuestions' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerHealthQuestionsCollectionViaCustomerHealthInfo
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CustomerHealthInfoEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CustomerHealthInfo_");
				return new PrefetchPathElement2(new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, 0, null, null, GetRelationsForField("CustomerHealthQuestionsCollectionViaCustomerHealthInfo"), null, "CustomerHealthQuestionsCollectionViaCustomerHealthInfo", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerPrimaryCarePhysician' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerPrimaryCarePhysicianEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerPrimaryCarePhysician_");
				return new PrefetchPathElement2(new EntityCollection<CustomerPrimaryCarePhysicianEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerPrimaryCarePhysicianEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CustomerPrimaryCarePhysicianEntity, 0, null, null, GetRelationsForField("CustomerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician"), null, "CustomerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerHealthInfo
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CustomerHealthInfoEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CustomerHealthInfo_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerHealthInfo"), null, "CustomerProfileCollectionViaCustomerHealthInfo", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCallQueueCustomer"), null, "CustomerProfileCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaDependentDisqualifiedTest
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.DependentDisqualifiedTestEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "DependentDisqualifiedTest_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaDependentDisqualifiedTest"), null, "CustomerProfileCollectionViaDependentDisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaClickConversion
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.ClickConversionEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "ClickConversion_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaClickConversion"), null, "CustomerProfileCollectionViaClickConversion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaDisqualifiedTest
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.DisqualifiedTestEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "DisqualifiedTest_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaDisqualifiedTest"), null, "CustomerProfileCollectionViaDisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerOrderHistory
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CustomerOrderHistoryEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CustomerOrderHistory_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerOrderHistory"), null, "CustomerProfileCollectionViaCustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerHealthInfoArchive
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CustomerHealthInfoArchiveEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CustomerHealthInfoArchive_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerHealthInfoArchive"), null, "CustomerProfileCollectionViaCustomerHealthInfoArchive", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaEventCustomerQuestionAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerQuestionAnswerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerQuestionAnswer_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaEventCustomerQuestionAnswer"), null, "CustomerProfileCollectionViaEventCustomerQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerRegistrationNotes' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventAppointmentCancellationLogEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentCancellationLog_");
				return new PrefetchPathElement2(new EntityCollection<CustomerRegistrationNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerRegistrationNotesEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, 0, null, null, GetRelationsForField("CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog"), null, "CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomEventNotification' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomEventNotificationCollectionViaEventCustomerCustomNotification
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerCustomNotificationEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerCustomNotification_");
				return new PrefetchPathElement2(new EntityCollection<CustomEventNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomEventNotificationEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CustomEventNotificationEntity, 0, null, null, GetRelationsForField("CustomEventNotificationCollectionViaEventCustomerCustomNotification"), null, "CustomEventNotificationCollectionViaEventCustomerCustomNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Eligibility' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEligibilityCollectionViaEventCustomerEligibility
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerEligibilityEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerEligibility_");
				return new PrefetchPathElement2(new EntityCollection<EligibilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EligibilityEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EligibilityEntity, 0, null, null, GetRelationsForField("EligibilityCollectionViaEventCustomerEligibility"), null, "EligibilityCollectionViaEventCustomerEligibility", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Encounter' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEncounterCollectionViaEventCustomerEncounter
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerEncounterEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerEncounter_");
				return new PrefetchPathElement2(new EntityCollection<EncounterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EncounterEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EncounterEntity, 0, null, null, GetRelationsForField("EncounterCollectionViaEventCustomerEncounter"), null, "EncounterCollectionViaEventCustomerEncounter", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventPackageDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventPackageDetailsCollectionViaCustomerOrderHistory
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CustomerOrderHistoryEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CustomerOrderHistory_");
				return new PrefetchPathElement2(new EntityCollection<EventPackageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventPackageDetailsEntity, 0, null, null, GetRelationsForField("EventPackageDetailsCollectionViaCustomerOrderHistory"), null, "EventPackageDetailsCollectionViaCustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventAppointmentChangeLog_
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventAppointmentChangeLogEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentChangeLog_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventAppointmentChangeLog_"), null, "EventsCollectionViaEventAppointmentChangeLog_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventAppointmentChangeLog
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventAppointmentChangeLogEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentChangeLog_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventAppointmentChangeLog"), null, "EventsCollectionViaEventAppointmentChangeLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventAppointmentCancellationLogEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentCancellationLog_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventAppointmentCancellationLog"), null, "EventsCollectionViaEventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventCustomerQuestionAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerQuestionAnswerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerQuestionAnswer_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventCustomerQuestionAnswer"), null, "EventsCollectionViaEventCustomerQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaDependentDisqualifiedTest
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.DependentDisqualifiedTestEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "DependentDisqualifiedTest_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaDependentDisqualifiedTest"), null, "EventsCollectionViaDependentDisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaCustomerOrderHistory
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CustomerOrderHistoryEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CustomerOrderHistory_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaCustomerOrderHistory"), null, "EventsCollectionViaCustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaDisqualifiedTest
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.DisqualifiedTestEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "DisqualifiedTest_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaDisqualifiedTest"), null, "EventsCollectionViaDisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaCallQueueCustomer"), null, "EventsCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventTestCollectionViaCustomerOrderHistory
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CustomerOrderHistoryEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CustomerOrderHistory_");
				return new PrefetchPathElement2(new EntityCollection<EventTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventTestEntity, 0, null, null, GetRelationsForField("EventTestCollectionViaCustomerOrderHistory"), null, "EventTestCollectionViaCustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ExitInterviewQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathExitInterviewQuestionCollectionViaExitInterviewAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.ExitInterviewAnswerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "ExitInterviewAnswer_");
				return new PrefetchPathElement2(new EntityCollection<ExitInterviewQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ExitInterviewQuestionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.ExitInterviewQuestionEntity, 0, null, null, GetRelationsForField("ExitInterviewQuestionCollectionViaExitInterviewAnswer"), null, "ExitInterviewQuestionCollectionViaExitInterviewAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaParticipationConsentSignature_
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.ParticipationConsentSignatureEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "ParticipationConsentSignature_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaParticipationConsentSignature_"), null, "FileCollectionViaParticipationConsentSignature_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaParticipationConsentSignature
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.ParticipationConsentSignatureEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "ParticipationConsentSignature_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaParticipationConsentSignature"), null, "FileCollectionViaParticipationConsentSignature", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaEventCustomerGiftCard
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerGiftCardEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerGiftCard_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaEventCustomerGiftCard"), null, "FileCollectionViaEventCustomerGiftCard", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaEventCustomerGiftCard_
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerGiftCardEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerGiftCard_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaEventCustomerGiftCard_"), null, "FileCollectionViaEventCustomerGiftCard_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaFluConsentSignature_
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.FluConsentSignatureEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "FluConsentSignature_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaFluConsentSignature_"), null, "FileCollectionViaFluConsentSignature_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaPhysicianRecordRequestSignature
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.PhysicianRecordRequestSignatureEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianRecordRequestSignature_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaPhysicianRecordRequestSignature"), null, "FileCollectionViaPhysicianRecordRequestSignature", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaChaperoneSignature
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.ChaperoneSignatureEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "ChaperoneSignature_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaChaperoneSignature"), null, "FileCollectionViaChaperoneSignature", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaExitInterviewSignature
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.ExitInterviewSignatureEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "ExitInterviewSignature_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaExitInterviewSignature"), null, "FileCollectionViaExitInterviewSignature", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaChaperoneSignature_
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.ChaperoneSignatureEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "ChaperoneSignature_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaChaperoneSignature_"), null, "FileCollectionViaChaperoneSignature_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaFluConsentSignature
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.FluConsentSignatureEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "FluConsentSignature_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaFluConsentSignature"), null, "FileCollectionViaFluConsentSignature", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FluConsentQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFluConsentQuestionCollectionViaFluConsentAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.FluConsentAnswerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "FluConsentAnswer_");
				return new PrefetchPathElement2(new EntityCollection<FluConsentQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentQuestionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.FluConsentQuestionEntity, 0, null, null, GetRelationsForField("FluConsentQuestionCollectionViaFluConsentAnswer"), null, "FluConsentQuestionCollectionViaFluConsentAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'IcdCodes' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathIcdCodesCollectionViaEventCustomerIcdCodes
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerIcdCodesEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerIcdCodes_");
				return new PrefetchPathElement2(new EntityCollection<IcdCodesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IcdCodesEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.IcdCodesEntity, 0, null, null, GetRelationsForField("IcdCodesCollectionViaEventCustomerIcdCodes"), null, "IcdCodesCollectionViaEventCustomerIcdCodes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Language' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLanguageCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.LanguageEntity, 0, null, null, GetRelationsForField("LanguageCollectionViaCallQueueCustomer"), null, "LanguageCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerOrderHistory
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CustomerOrderHistoryEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CustomerOrderHistory_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerOrderHistory"), null, "LookupCollectionViaCustomerOrderHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCallQueueCustomer"), null, "LookupCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventAppointmentChangeLog
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventAppointmentChangeLogEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentChangeLog_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventAppointmentChangeLog"), null, "LookupCollectionViaEventAppointmentChangeLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCheckListAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CheckListAnswerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CheckListAnswer_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCheckListAnswer"), null, "LookupCollectionViaCheckListAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaPcpDisposition
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.PcpDispositionEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "PcpDisposition_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaPcpDisposition"), null, "LookupCollectionViaPcpDisposition", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventAppointmentCancellationLogEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentCancellationLog_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventAppointmentCancellationLog"), null, "LookupCollectionViaEventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicareQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicareQuestionCollectionViaCustomerMedicareQuestionAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CustomerMedicareQuestionAnswerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CustomerMedicareQuestionAnswer_");
				return new PrefetchPathElement2(new EntityCollection<MedicareQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.MedicareQuestionEntity, 0, null, null, GetRelationsForField("MedicareQuestionCollectionViaCustomerMedicareQuestionAnswer"), null, "MedicareQuestionCollectionViaCustomerMedicareQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Ndc' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNdcCollectionViaEventCustomerCurrentMedication
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerCurrentMedicationEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerCurrentMedication_");
				return new PrefetchPathElement2(new EntityCollection<NdcEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NdcEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.NdcEntity, 0, null, null, GetRelationsForField("NdcCollectionViaEventCustomerCurrentMedication"), null, "NdcCollectionViaEventCustomerCurrentMedication", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotesDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotesDetailsCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.NotesDetailsEntity, 0, null, null, GetRelationsForField("NotesDetailsCollectionViaCallQueueCustomer"), null, "NotesDetailsCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Notification' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotificationCollectionViaEventCustomerNotification
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerNotificationEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerNotification_");
				return new PrefetchPathElement2(new EntityCollection<NotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.NotificationEntity, 0, null, null, GetRelationsForField("NotificationCollectionViaEventCustomerNotification"), null, "NotificationCollectionViaEventCustomerNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotificationType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotificationTypeCollectionViaEventCustomerTestNotPerformedNotification
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerTestNotPerformedNotificationEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerTestNotPerformedNotification_");
				return new PrefetchPathElement2(new EntityCollection<NotificationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.NotificationTypeEntity, 0, null, null, GetRelationsForField("NotificationTypeCollectionViaEventCustomerTestNotPerformedNotification"), null, "NotificationTypeCollectionViaEventCustomerTestNotPerformedNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotificationType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotificationTypeCollectionViaEventCustomerNotification
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerNotificationEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerNotification_");
				return new PrefetchPathElement2(new EntityCollection<NotificationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.NotificationTypeEntity, 0, null, null, GetRelationsForField("NotificationTypeCollectionViaEventCustomerNotification"), null, "NotificationTypeCollectionViaEventCustomerNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrderDetail' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrderDetailCollectionViaEventCustomerOrderDetail
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerOrderDetailEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerOrderDetail_");
				return new PrefetchPathElement2(new EntityCollection<OrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderDetailEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrderDetailEntity, 0, null, null, GetRelationsForField("OrderDetailCollectionViaEventCustomerOrderDetail"), null, "OrderDetailCollectionViaEventCustomerOrderDetail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaExitInterviewAnswer_
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.ExitInterviewAnswerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "ExitInterviewAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaExitInterviewAnswer_"), null, "OrganizationRoleUserCollectionViaExitInterviewAnswer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaParticipationConsentSignature
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.ParticipationConsentSignatureEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "ParticipationConsentSignature_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaParticipationConsentSignature"), null, "OrganizationRoleUserCollectionViaParticipationConsentSignature", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaFluConsentSignature
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.FluConsentSignatureEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "FluConsentSignature_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaFluConsentSignature"), null, "OrganizationRoleUserCollectionViaFluConsentSignature", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaPcpDisposition_
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.PcpDispositionEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "PcpDisposition_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaPcpDisposition_"), null, "OrganizationRoleUserCollectionViaPcpDisposition_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaPcpDisposition
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.PcpDispositionEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "PcpDisposition_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaPcpDisposition"), null, "OrganizationRoleUserCollectionViaPcpDisposition", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerPrimaryCarePhysicianEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerPrimaryCarePhysician_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician"), null, "OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerTestNotPerformedNotificationEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerTestNotPerformedNotification_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification"), null, "OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventCustomerRetest
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerRetestEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerRetest_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventCustomerRetest"), null, "OrganizationRoleUserCollectionViaEventCustomerRetest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaExitInterviewAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.ExitInterviewAnswerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "ExitInterviewAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaExitInterviewAnswer"), null, "OrganizationRoleUserCollectionViaExitInterviewAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaExitInterviewSignature
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.ExitInterviewSignatureEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "ExitInterviewSignature_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaExitInterviewSignature"), null, "OrganizationRoleUserCollectionViaExitInterviewSignature", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaFluConsentAnswer_
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.FluConsentAnswerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "FluConsentAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaFluConsentAnswer_"), null, "OrganizationRoleUserCollectionViaFluConsentAnswer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventCustomerQuestionAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerQuestionAnswerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerQuestionAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer"), null, "OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerQuestionAnswerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerQuestionAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_"), null, "OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaFluConsentAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.FluConsentAnswerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "FluConsentAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaFluConsentAnswer"), null, "OrganizationRoleUserCollectionViaFluConsentAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaChaperoneSignature
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.ChaperoneSignatureEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "ChaperoneSignature_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaChaperoneSignature"), null, "OrganizationRoleUserCollectionViaChaperoneSignature", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaSurveyAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.SurveyAnswerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "SurveyAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaSurveyAnswer"), null, "OrganizationRoleUserCollectionViaSurveyAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaDisqualifiedTest_
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.DisqualifiedTestEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "DisqualifiedTest_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaDisqualifiedTest_"), null, "OrganizationRoleUserCollectionViaDisqualifiedTest_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventAppointmentChangeLog
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventAppointmentChangeLogEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentChangeLog_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventAppointmentChangeLog"), null, "OrganizationRoleUserCollectionViaEventAppointmentChangeLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaChaperoneAnswer_
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.ChaperoneAnswerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "ChaperoneAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaChaperoneAnswer_"), null, "OrganizationRoleUserCollectionViaChaperoneAnswer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventAppointmentCancellationLogEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentCancellationLog_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventAppointmentCancellationLog"), null, "OrganizationRoleUserCollectionViaEventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCheckListAnswer_
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CheckListAnswerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CheckListAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCheckListAnswer_"), null, "OrganizationRoleUserCollectionViaCheckListAnswer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerHealthInfo
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CustomerHealthInfoEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CustomerHealthInfo_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerHealthInfo"), null, "OrganizationRoleUserCollectionViaCustomerHealthInfo", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerHealthInfoArchive
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CustomerHealthInfoArchiveEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CustomerHealthInfoArchive_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerHealthInfoArchive"), null, "OrganizationRoleUserCollectionViaCustomerHealthInfoArchive", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaDisqualifiedTest
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.DisqualifiedTestEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "DisqualifiedTest_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaDisqualifiedTest"), null, "OrganizationRoleUserCollectionViaDisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCheckListAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CheckListAnswerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CheckListAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCheckListAnswer"), null, "OrganizationRoleUserCollectionViaCheckListAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaSurveyAnswer_
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.SurveyAnswerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "SurveyAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaSurveyAnswer_"), null, "OrganizationRoleUserCollectionViaSurveyAnswer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaChaperoneAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.ChaperoneAnswerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "ChaperoneAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaChaperoneAnswer"), null, "OrganizationRoleUserCollectionViaChaperoneAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueCustomer__
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueCustomer__"), null, "OrganizationRoleUserCollectionViaCallQueueCustomer__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventCustomerGiftCard
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerGiftCardEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerGiftCard_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventCustomerGiftCard"), null, "OrganizationRoleUserCollectionViaEventCustomerGiftCard", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueCustomer"), null, "OrganizationRoleUserCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueCustomer_
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueCustomer_"), null, "OrganizationRoleUserCollectionViaCallQueueCustomer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaPhysicianRecordRequestSignature
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.PhysicianRecordRequestSignatureEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianRecordRequestSignature_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaPhysicianRecordRequestSignature"), null, "OrganizationRoleUserCollectionViaPhysicianRecordRequestSignature", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CustomerMedicareQuestionAnswerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CustomerMedicareQuestionAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer"), null, "OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Package' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPackageCollectionViaEventCustomerPreApprovedPackageTest
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerPreApprovedPackageTestEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerPreApprovedPackageTest_");
				return new PrefetchPathElement2(new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.PackageEntity, 0, null, null, GetRelationsForField("PackageCollectionViaEventCustomerPreApprovedPackageTest"), null, "PackageCollectionViaEventCustomerPreApprovedPackageTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianProfileCollectionViaPhysicianEvaluation
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.PhysicianEvaluationEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianEvaluation_");
				return new PrefetchPathElement2(new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.PhysicianProfileEntity, 0, null, null, GetRelationsForField("PhysicianProfileCollectionViaPhysicianEvaluation"), null, "PhysicianProfileCollectionViaPhysicianEvaluation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianProfileCollectionViaPhysicianCustomerAssignment_
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.PhysicianCustomerAssignmentEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianCustomerAssignment_");
				return new PrefetchPathElement2(new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.PhysicianProfileEntity, 0, null, null, GetRelationsForField("PhysicianProfileCollectionViaPhysicianCustomerAssignment_"), null, "PhysicianProfileCollectionViaPhysicianCustomerAssignment_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianProfileCollectionViaPhysicianCustomerAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.PhysicianCustomerAssignmentEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianCustomerAssignment_");
				return new PrefetchPathElement2(new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.PhysicianProfileEntity, 0, null, null, GetRelationsForField("PhysicianProfileCollectionViaPhysicianCustomerAssignment"), null, "PhysicianProfileCollectionViaPhysicianCustomerAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PreQualificationQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPreQualificationQuestionCollectionViaEventCustomerQuestionAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerQuestionAnswerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerQuestionAnswer_");
				return new PrefetchPathElement2(new EntityCollection<PreQualificationQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationQuestionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.PreQualificationQuestionEntity, 0, null, null, GetRelationsForField("PreQualificationQuestionCollectionViaEventCustomerQuestionAnswer"), null, "PreQualificationQuestionCollectionViaEventCustomerQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PreQualificationQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPreQualificationQuestionCollectionViaDisqualifiedTest
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.DisqualifiedTestEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "DisqualifiedTest_");
				return new PrefetchPathElement2(new EntityCollection<PreQualificationQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationQuestionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.PreQualificationQuestionEntity, 0, null, null, GetRelationsForField("PreQualificationQuestionCollectionViaDisqualifiedTest"), null, "PreQualificationQuestionCollectionViaDisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectCustomerCollectionViaClickConversion
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.ClickConversionEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "ClickConversion_");
				return new PrefetchPathElement2(new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.ProspectCustomerEntity, 0, null, null, GetRelationsForField("ProspectCustomerCollectionViaClickConversion"), null, "ProspectCustomerCollectionViaClickConversion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectCustomerCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.CallQueueCustomerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.ProspectCustomerEntity, 0, null, null, GetRelationsForField("ProspectCustomerCollectionViaCallQueueCustomer"), null, "ProspectCustomerCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RefundRequest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRefundRequestCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventAppointmentCancellationLogEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentCancellationLog_");
				return new PrefetchPathElement2(new EntityCollection<RefundRequestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundRequestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.RefundRequestEntity, 0, null, null, GetRelationsForField("RefundRequestCollectionViaEventAppointmentCancellationLog"), null, "RefundRequestCollectionViaEventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RescheduleCancelDisposition' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRescheduleCancelDispositionCollectionViaEventAppointmentChangeLog
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventAppointmentChangeLogEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentChangeLog_");
				return new PrefetchPathElement2(new EntityCollection<RescheduleCancelDispositionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RescheduleCancelDispositionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.RescheduleCancelDispositionEntity, 0, null, null, GetRelationsForField("RescheduleCancelDispositionCollectionViaEventAppointmentChangeLog"), null, "RescheduleCancelDispositionCollectionViaEventAppointmentChangeLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RescheduleCancelDisposition' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventAppointmentCancellationLogEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentCancellationLog_");
				return new PrefetchPathElement2(new EntityCollection<RescheduleCancelDispositionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RescheduleCancelDispositionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.RescheduleCancelDispositionEntity, 0, null, null, GetRelationsForField("RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog"), null, "RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SurveyQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSurveyQuestionCollectionViaSurveyAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.SurveyAnswerEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "SurveyAnswer_");
				return new PrefetchPathElement2(new EntityCollection<SurveyQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyQuestionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.SurveyQuestionEntity, 0, null, null, GetRelationsForField("SurveyQuestionCollectionViaSurveyAnswer"), null, "SurveyQuestionCollectionViaSurveyAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaEventCustomerPreApprovedPackageTest
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerPreApprovedPackageTestEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerPreApprovedPackageTest_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaEventCustomerPreApprovedPackageTest"), null, "TestCollectionViaEventCustomerPreApprovedPackageTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaDisqualifiedTest
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.DisqualifiedTestEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "DisqualifiedTest_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaDisqualifiedTest"), null, "TestCollectionViaDisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaDependentDisqualifiedTest
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.DependentDisqualifiedTestEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "DependentDisqualifiedTest_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaDependentDisqualifiedTest"), null, "TestCollectionViaDependentDisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaEventCustomerRetest
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerRetestEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerRetest_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaEventCustomerRetest"), null, "TestCollectionViaEventCustomerRetest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaEventCustomerTestNotPerformedNotification
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerTestNotPerformedNotificationEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerTestNotPerformedNotification_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaEventCustomerTestNotPerformedNotification"), null, "TestCollectionViaEventCustomerTestNotPerformedNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaEventCustomerPreApprovedTest
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerPreApprovedTestEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerPreApprovedTest_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaEventCustomerPreApprovedTest"), null, "TestCollectionViaEventCustomerPreApprovedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaEventCustomerRequiredTest
		{
			get
			{
				IEntityRelation intermediateRelation = EventCustomersEntity.Relations.EventCustomerRequiredTestEntityUsingEventCustomerId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerRequiredTest_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaEventCustomerRequiredTest"), null, "TestCollectionViaEventCustomerRequiredTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfaffiliateCampaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfaffiliateCampaign
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignEntityFactory))),
					(IEntityRelation)GetRelationsForField("AfaffiliateCampaign")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.AfaffiliateCampaignEntity, 0, null, null, null, null, "AfaffiliateCampaign", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Campaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaign
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))),
					(IEntityRelation)GetRelationsForField("Campaign")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CampaignEntity, 0, null, null, null, null, "Campaign", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfile
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerProfile")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, null, null, "CustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfileHistory' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileHistory
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileHistoryEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerProfileHistory")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CustomerProfileHistoryEntity, 0, null, null, null, null, "CustomerProfileHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerRegistrationNotes' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerRegistrationNotes
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerRegistrationNotesEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerRegistrationNotes")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, 0, null, null, null, null, "CustomerRegistrationNotes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventAppointment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventAppointment
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventAppointment")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventAppointmentEntity, 0, null, null, null, null, "EventAppointment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEvents
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Events")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, null, null, "Events", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GcNotGivenReason' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGcNotGivenReason
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GcNotGivenReasonEntityFactory))),
					(IEntityRelation)GetRelationsForField("GcNotGivenReason")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.GcNotGivenReasonEntity, 0, null, null, null, null, "GcNotGivenReason", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HospitalFacility' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHospitalFacility
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(HospitalFacilityEntityFactory))),
					(IEntityRelation)GetRelationsForField("HospitalFacility")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.HospitalFacilityEntity, 0, null, null, null, null, "HospitalFacility", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup_")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerSkipReview' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerSkipReview
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerSkipReviewEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerSkipReview")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.CustomerSkipReviewEntity, 0, null, null, null, null, "CustomerSkipReview", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerBarrier' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerBarrier
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerBarrierEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerBarrier")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventCustomerBarrierEntity, 0, null, null, null, null, "EventCustomerBarrier", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerBasicBioMetric' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerBasicBioMetric
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerBasicBioMetricEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerBasicBioMetric")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventCustomerBasicBioMetricEntity, 0, null, null, null, null, "EventCustomerBasicBioMetric", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerEvaluationLock' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerEvaluationLock
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerEvaluationLockEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerEvaluationLock")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventCustomerEvaluationLockEntity, 0, null, null, null, null, "EventCustomerEvaluationLock", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerResult' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerResult
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerResultEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerResult")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.EventCustomerResultEntity, 0, null, null, null, null, "EventCustomerResult", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PcpAppointment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPcpAppointment_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(PcpAppointmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("PcpAppointment_")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.PcpAppointmentEntity, 0, null, null, null, null, "PcpAppointment_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ScreeningAuthorization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathScreeningAuthorization
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ScreeningAuthorizationEntityFactory))),
					(IEntityRelation)GetRelationsForField("ScreeningAuthorization")[0], (int)Falcon.Data.EntityType.EventCustomersEntity, (int)Falcon.Data.EntityType.ScreeningAuthorizationEntity, 0, null, null, null, null, "ScreeningAuthorization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return EventCustomersEntity.CustomProperties;}
		}

		/// <summary> The custom properties for the fields of this entity type. The returned Hashtable contains per fieldname a hashtable of name-value
		/// pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, Dictionary<string, string>> FieldsCustomProperties
		{
			get { return _fieldsCustomProperties;}
		}

		/// <summary> The custom properties for the fields of the type of this entity instance. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, Dictionary<string, string>> FieldsCustomPropertiesOfType
		{
			get { return EventCustomersEntity.FieldsCustomProperties;}
		}

		/// <summary> The EventCustomerId property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."EventCustomerID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 EventCustomerId
		{
			get { return (System.Int64)GetValue((int)EventCustomersFieldIndex.EventCustomerId, true); }
			set	{ SetValue((int)EventCustomersFieldIndex.EventCustomerId, value); }
		}

		/// <summary> The EventId property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."EventID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventId
		{
			get { return (System.Int64)GetValue((int)EventCustomersFieldIndex.EventId, true); }
			set	{ SetValue((int)EventCustomersFieldIndex.EventId, value); }
		}

		/// <summary> The CustomerId property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."CustomerID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerId
		{
			get { return (System.Int64)GetValue((int)EventCustomersFieldIndex.CustomerId, true); }
			set	{ SetValue((int)EventCustomersFieldIndex.CustomerId, value); }
		}

		/// <summary> The IsPaymentOnline property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."IsPaymentOnline"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsPaymentOnline
		{
			get { return (System.Boolean)GetValue((int)EventCustomersFieldIndex.IsPaymentOnline, true); }
			set	{ SetValue((int)EventCustomersFieldIndex.IsPaymentOnline, value); }
		}

		/// <summary> The AppointmentId property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."AppointmentID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> AppointmentId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventCustomersFieldIndex.AppointmentId, false); }
			set	{ SetValue((int)EventCustomersFieldIndex.AppointmentId, value); }
		}

		/// <summary> The IsTestConducted property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."IsTestConducted"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsTestConducted
		{
			get { return (System.Boolean)GetValue((int)EventCustomersFieldIndex.IsTestConducted, true); }
			set	{ SetValue((int)EventCustomersFieldIndex.IsTestConducted, value); }
		}

		/// <summary> The BMailReports property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."bMailReports"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> BMailReports
		{
			get { return (Nullable<System.Boolean>)GetValue((int)EventCustomersFieldIndex.BMailReports, false); }
			set	{ SetValue((int)EventCustomersFieldIndex.BMailReports, value); }
		}

		/// <summary> The Notes property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."Notes"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 5000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Notes
		{
			get { return (System.String)GetValue((int)EventCustomersFieldIndex.Notes, true); }
			set	{ SetValue((int)EventCustomersFieldIndex.Notes, value); }
		}

		/// <summary> The NoShow property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."NoShow"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean NoShow
		{
			get { return (System.Boolean)GetValue((int)EventCustomersFieldIndex.NoShow, true); }
			set	{ SetValue((int)EventCustomersFieldIndex.NoShow, value); }
		}

		/// <summary> The DateCreated property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateCreated
		{
			get { return (Nullable<System.DateTime>)GetValue((int)EventCustomersFieldIndex.DateCreated, false); }
			set	{ SetValue((int)EventCustomersFieldIndex.DateCreated, value); }
		}

		/// <summary> The OfflineCustomerId property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."OfflineCustomerID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> OfflineCustomerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventCustomersFieldIndex.OfflineCustomerId, false); }
			set	{ SetValue((int)EventCustomersFieldIndex.OfflineCustomerId, value); }
		}

		/// <summary> The AffiliateCampaignId property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."AffiliateCampaignID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> AffiliateCampaignId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventCustomersFieldIndex.AffiliateCampaignId, false); }
			set	{ SetValue((int)EventCustomersFieldIndex.AffiliateCampaignId, value); }
		}

		/// <summary> The SignInSource property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."SignInSource"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String SignInSource
		{
			get { return (System.String)GetValue((int)EventCustomersFieldIndex.SignInSource, true); }
			set	{ SetValue((int)EventCustomersFieldIndex.SignInSource, value); }
		}

		/// <summary> The AdvocateId property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."AdvocateID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 AdvocateId
		{
			get { return (System.Int64)GetValue((int)EventCustomersFieldIndex.AdvocateId, true); }
			set	{ SetValue((int)EventCustomersFieldIndex.AdvocateId, value); }
		}

		/// <summary> The Hipaastatus property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."HIPAAStatus"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 Hipaastatus
		{
			get { return (System.Int16)GetValue((int)EventCustomersFieldIndex.Hipaastatus, true); }
			set	{ SetValue((int)EventCustomersFieldIndex.Hipaastatus, value); }
		}

		/// <summary> The MarketingSource property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."MarketingSource"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MarketingSource
		{
			get { return (System.String)GetValue((int)EventCustomersFieldIndex.MarketingSource, true); }
			set	{ SetValue((int)EventCustomersFieldIndex.MarketingSource, value); }
		}

		/// <summary> The ClickId property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."ClickID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ClickId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventCustomersFieldIndex.ClickId, false); }
			set	{ SetValue((int)EventCustomersFieldIndex.ClickId, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)EventCustomersFieldIndex.CreatedByOrgRoleUserId, true); }
			set	{ SetValue((int)EventCustomersFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The PartnerRelease property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."PartnerRelease"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 PartnerRelease
		{
			get { return (System.Int16)GetValue((int)EventCustomersFieldIndex.PartnerRelease, true); }
			set	{ SetValue((int)EventCustomersFieldIndex.PartnerRelease, value); }
		}

		/// <summary> The HospitalFacilityId property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."HospitalFacilityId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> HospitalFacilityId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventCustomersFieldIndex.HospitalFacilityId, false); }
			set	{ SetValue((int)EventCustomersFieldIndex.HospitalFacilityId, value); }
		}

		/// <summary> The AbnStatus property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."ABNStatus"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 AbnStatus
		{
			get { return (System.Int16)GetValue((int)EventCustomersFieldIndex.AbnStatus, true); }
			set	{ SetValue((int)EventCustomersFieldIndex.AbnStatus, value); }
		}

		/// <summary> The PcpConsentStatus property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."PCPConsentStatus"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 PcpConsentStatus
		{
			get { return (System.Int16)GetValue((int)EventCustomersFieldIndex.PcpConsentStatus, true); }
			set	{ SetValue((int)EventCustomersFieldIndex.PcpConsentStatus, value); }
		}

		/// <summary> The InsuranceReleaseStatus property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."InsuranceReleaseStatus"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 InsuranceReleaseStatus
		{
			get { return (System.Int16)GetValue((int)EventCustomersFieldIndex.InsuranceReleaseStatus, true); }
			set	{ SetValue((int)EventCustomersFieldIndex.InsuranceReleaseStatus, value); }
		}

		/// <summary> The CampaignId property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."CampaignId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CampaignId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventCustomersFieldIndex.CampaignId, false); }
			set	{ SetValue((int)EventCustomersFieldIndex.CampaignId, value); }
		}

		/// <summary> The AwvVisitId property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."AwvVisitId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> AwvVisitId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventCustomersFieldIndex.AwvVisitId, false); }
			set	{ SetValue((int)EventCustomersFieldIndex.AwvVisitId, value); }
		}

		/// <summary> The LeftWithoutScreeningReasonId property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."LeftWithoutScreeningReasonId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> LeftWithoutScreeningReasonId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventCustomersFieldIndex.LeftWithoutScreeningReasonId, false); }
			set	{ SetValue((int)EventCustomersFieldIndex.LeftWithoutScreeningReasonId, value); }
		}

		/// <summary> The EnableTexting property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."EnableTexting"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean EnableTexting
		{
			get { return (System.Boolean)GetValue((int)EventCustomersFieldIndex.EnableTexting, true); }
			set	{ SetValue((int)EventCustomersFieldIndex.EnableTexting, value); }
		}

		/// <summary> The IsGiftCertificateDelivered property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."IsGiftCertificateDelivered"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsGiftCertificateDelivered
		{
			get { return (Nullable<System.Boolean>)GetValue((int)EventCustomersFieldIndex.IsGiftCertificateDelivered, false); }
			set	{ SetValue((int)EventCustomersFieldIndex.IsGiftCertificateDelivered, value); }
		}

		/// <summary> The GiftCode property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."GiftCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GiftCode
		{
			get { return (System.String)GetValue((int)EventCustomersFieldIndex.GiftCode, true); }
			set	{ SetValue((int)EventCustomersFieldIndex.GiftCode, value); }
		}

		/// <summary> The PatientDetailId property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."PatientDetailId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> PatientDetailId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventCustomersFieldIndex.PatientDetailId, false); }
			set	{ SetValue((int)EventCustomersFieldIndex.PatientDetailId, value); }
		}

		/// <summary> The LeftWithoutScreeningNotesId property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."LeftWithoutScreeningNotesId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> LeftWithoutScreeningNotesId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventCustomersFieldIndex.LeftWithoutScreeningNotesId, false); }
			set	{ SetValue((int)EventCustomersFieldIndex.LeftWithoutScreeningNotesId, value); }
		}

		/// <summary> The CustomerProfileHistoryId property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."CustomerProfileHistoryId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CustomerProfileHistoryId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventCustomersFieldIndex.CustomerProfileHistoryId, false); }
			set	{ SetValue((int)EventCustomersFieldIndex.CustomerProfileHistoryId, value); }
		}

		/// <summary> The IsAppointmentConfirmed property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."IsAppointmentConfirmed"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsAppointmentConfirmed
		{
			get { return (System.Boolean)GetValue((int)EventCustomersFieldIndex.IsAppointmentConfirmed, true); }
			set	{ SetValue((int)EventCustomersFieldIndex.IsAppointmentConfirmed, value); }
		}

		/// <summary> The ConfirmedBy property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."ConfirmedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ConfirmedBy
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventCustomersFieldIndex.ConfirmedBy, false); }
			set	{ SetValue((int)EventCustomersFieldIndex.ConfirmedBy, value); }
		}

		/// <summary> The IsForRetest property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."IsForRetest"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsForRetest
		{
			get { return (System.Boolean)GetValue((int)EventCustomersFieldIndex.IsForRetest, true); }
			set	{ SetValue((int)EventCustomersFieldIndex.IsForRetest, value); }
		}

		/// <summary> The PreferredContactType property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."PreferredContactType"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> PreferredContactType
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventCustomersFieldIndex.PreferredContactType, false); }
			set	{ SetValue((int)EventCustomersFieldIndex.PreferredContactType, value); }
		}

		/// <summary> The GcNotGivenReasonId property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."GcNotGivenReasonId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GcNotGivenReasonId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventCustomersFieldIndex.GcNotGivenReasonId, false); }
			set	{ SetValue((int)EventCustomersFieldIndex.GcNotGivenReasonId, value); }
		}

		/// <summary> The NoShowDate property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."NoShowDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> NoShowDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)EventCustomersFieldIndex.NoShowDate, false); }
			set	{ SetValue((int)EventCustomersFieldIndex.NoShowDate, value); }
		}

		/// <summary> The SingleTestOverride property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."SingleTestOverride"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean SingleTestOverride
		{
			get { return (System.Boolean)GetValue((int)EventCustomersFieldIndex.SingleTestOverride, true); }
			set	{ SetValue((int)EventCustomersFieldIndex.SingleTestOverride, value); }
		}

		/// <summary> The IsParticipationConsentSigned property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."IsParticipationConsentSigned"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsParticipationConsentSigned
		{
			get { return (System.Boolean)GetValue((int)EventCustomersFieldIndex.IsParticipationConsentSigned, true); }
			set	{ SetValue((int)EventCustomersFieldIndex.IsParticipationConsentSigned, value); }
		}

		/// <summary> The IsPhysicianRecordRequestSigned property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."IsPhysicianRecordRequestSigned"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsPhysicianRecordRequestSigned
		{
			get { return (System.Boolean)GetValue((int)EventCustomersFieldIndex.IsPhysicianRecordRequestSigned, true); }
			set	{ SetValue((int)EventCustomersFieldIndex.IsPhysicianRecordRequestSigned, value); }
		}

		/// <summary> The IsFluVaccineConsentSigned property of the Entity EventCustomers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventCustomers"."IsFluVaccineConsentSigned"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsFluVaccineConsentSigned
		{
			get { return (System.Boolean)GetValue((int)EventCustomersFieldIndex.IsFluVaccineConsentSigned, true); }
			set	{ SetValue((int)EventCustomersFieldIndex.IsFluVaccineConsentSigned, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueCustomerEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueCustomerEntity))]
		public virtual EntityCollection<CallQueueCustomerEntity> CallQueueCustomer
		{
			get
			{
				if(_callQueueCustomer==null)
				{
					_callQueueCustomer = new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory)));
					_callQueueCustomer.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _callQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChaperoneAnswerEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChaperoneAnswerEntity))]
		public virtual EntityCollection<ChaperoneAnswerEntity> ChaperoneAnswer
		{
			get
			{
				if(_chaperoneAnswer==null)
				{
					_chaperoneAnswer = new EntityCollection<ChaperoneAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaperoneAnswerEntityFactory)));
					_chaperoneAnswer.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _chaperoneAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChaperoneSignatureEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChaperoneSignatureEntity))]
		public virtual EntityCollection<ChaperoneSignatureEntity> ChaperoneSignature
		{
			get
			{
				if(_chaperoneSignature==null)
				{
					_chaperoneSignature = new EntityCollection<ChaperoneSignatureEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaperoneSignatureEntityFactory)));
					_chaperoneSignature.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _chaperoneSignature;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckListAnswerEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckListAnswerEntity))]
		public virtual EntityCollection<CheckListAnswerEntity> CheckListAnswer
		{
			get
			{
				if(_checkListAnswer==null)
				{
					_checkListAnswer = new EntityCollection<CheckListAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListAnswerEntityFactory)));
					_checkListAnswer.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _checkListAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ClickConversionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ClickConversionEntity))]
		public virtual EntityCollection<ClickConversionEntity> ClickConversion
		{
			get
			{
				if(_clickConversion==null)
				{
					_clickConversion = new EntityCollection<ClickConversionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClickConversionEntityFactory)));
					_clickConversion.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _clickConversion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerHealthInfoEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerHealthInfoEntity))]
		public virtual EntityCollection<CustomerHealthInfoEntity> CustomerHealthInfo
		{
			get
			{
				if(_customerHealthInfo==null)
				{
					_customerHealthInfo = new EntityCollection<CustomerHealthInfoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthInfoEntityFactory)));
					_customerHealthInfo.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _customerHealthInfo;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerHealthInfoArchiveEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerHealthInfoArchiveEntity))]
		public virtual EntityCollection<CustomerHealthInfoArchiveEntity> CustomerHealthInfoArchive
		{
			get
			{
				if(_customerHealthInfoArchive==null)
				{
					_customerHealthInfoArchive = new EntityCollection<CustomerHealthInfoArchiveEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthInfoArchiveEntityFactory)));
					_customerHealthInfoArchive.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _customerHealthInfoArchive;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerMedicareQuestionAnswerEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerMedicareQuestionAnswerEntity))]
		public virtual EntityCollection<CustomerMedicareQuestionAnswerEntity> CustomerMedicareQuestionAnswer
		{
			get
			{
				if(_customerMedicareQuestionAnswer==null)
				{
					_customerMedicareQuestionAnswer = new EntityCollection<CustomerMedicareQuestionAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerMedicareQuestionAnswerEntityFactory)));
					_customerMedicareQuestionAnswer.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _customerMedicareQuestionAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerOrderHistoryEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerOrderHistoryEntity))]
		public virtual EntityCollection<CustomerOrderHistoryEntity> CustomerOrderHistory
		{
			get
			{
				if(_customerOrderHistory==null)
				{
					_customerOrderHistory = new EntityCollection<CustomerOrderHistoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerOrderHistoryEntityFactory)));
					_customerOrderHistory.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _customerOrderHistory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DependentDisqualifiedTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DependentDisqualifiedTestEntity))]
		public virtual EntityCollection<DependentDisqualifiedTestEntity> DependentDisqualifiedTest
		{
			get
			{
				if(_dependentDisqualifiedTest==null)
				{
					_dependentDisqualifiedTest = new EntityCollection<DependentDisqualifiedTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DependentDisqualifiedTestEntityFactory)));
					_dependentDisqualifiedTest.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _dependentDisqualifiedTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DisqualifiedTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DisqualifiedTestEntity))]
		public virtual EntityCollection<DisqualifiedTestEntity> DisqualifiedTest
		{
			get
			{
				if(_disqualifiedTest==null)
				{
					_disqualifiedTest = new EntityCollection<DisqualifiedTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DisqualifiedTestEntityFactory)));
					_disqualifiedTest.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _disqualifiedTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventAppointmentCancellationLogEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventAppointmentCancellationLogEntity))]
		public virtual EntityCollection<EventAppointmentCancellationLogEntity> EventAppointmentCancellationLog
		{
			get
			{
				if(_eventAppointmentCancellationLog==null)
				{
					_eventAppointmentCancellationLog = new EntityCollection<EventAppointmentCancellationLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentCancellationLogEntityFactory)));
					_eventAppointmentCancellationLog.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _eventAppointmentCancellationLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventAppointmentChangeLogEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventAppointmentChangeLogEntity))]
		public virtual EntityCollection<EventAppointmentChangeLogEntity> EventAppointmentChangeLog
		{
			get
			{
				if(_eventAppointmentChangeLog==null)
				{
					_eventAppointmentChangeLog = new EntityCollection<EventAppointmentChangeLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentChangeLogEntityFactory)));
					_eventAppointmentChangeLog.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _eventAppointmentChangeLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerCriticalQuestionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerCriticalQuestionEntity))]
		public virtual EntityCollection<EventCustomerCriticalQuestionEntity> EventCustomerCriticalQuestion
		{
			get
			{
				if(_eventCustomerCriticalQuestion==null)
				{
					_eventCustomerCriticalQuestion = new EntityCollection<EventCustomerCriticalQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerCriticalQuestionEntityFactory)));
					_eventCustomerCriticalQuestion.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _eventCustomerCriticalQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerCurrentMedicationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerCurrentMedicationEntity))]
		public virtual EntityCollection<EventCustomerCurrentMedicationEntity> EventCustomerCurrentMedication
		{
			get
			{
				if(_eventCustomerCurrentMedication==null)
				{
					_eventCustomerCurrentMedication = new EntityCollection<EventCustomerCurrentMedicationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerCurrentMedicationEntityFactory)));
					_eventCustomerCurrentMedication.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _eventCustomerCurrentMedication;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerCustomNotificationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerCustomNotificationEntity))]
		public virtual EntityCollection<EventCustomerCustomNotificationEntity> EventCustomerCustomNotification
		{
			get
			{
				if(_eventCustomerCustomNotification==null)
				{
					_eventCustomerCustomNotification = new EntityCollection<EventCustomerCustomNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerCustomNotificationEntityFactory)));
					_eventCustomerCustomNotification.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _eventCustomerCustomNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerDiagnosisEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerDiagnosisEntity))]
		public virtual EntityCollection<EventCustomerDiagnosisEntity> EventCustomerDiagnosis
		{
			get
			{
				if(_eventCustomerDiagnosis==null)
				{
					_eventCustomerDiagnosis = new EntityCollection<EventCustomerDiagnosisEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerDiagnosisEntityFactory)));
					_eventCustomerDiagnosis.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _eventCustomerDiagnosis;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerEligibilityEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerEligibilityEntity))]
		public virtual EntityCollection<EventCustomerEligibilityEntity> EventCustomerEligibility
		{
			get
			{
				if(_eventCustomerEligibility==null)
				{
					_eventCustomerEligibility = new EntityCollection<EventCustomerEligibilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerEligibilityEntityFactory)));
					_eventCustomerEligibility.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _eventCustomerEligibility;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerEncounterEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerEncounterEntity))]
		public virtual EntityCollection<EventCustomerEncounterEntity> EventCustomerEncounter
		{
			get
			{
				if(_eventCustomerEncounter==null)
				{
					_eventCustomerEncounter = new EntityCollection<EventCustomerEncounterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerEncounterEntityFactory)));
					_eventCustomerEncounter.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _eventCustomerEncounter;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerGiftCardEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerGiftCardEntity))]
		public virtual EntityCollection<EventCustomerGiftCardEntity> EventCustomerGiftCard
		{
			get
			{
				if(_eventCustomerGiftCard==null)
				{
					_eventCustomerGiftCard = new EntityCollection<EventCustomerGiftCardEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerGiftCardEntityFactory)));
					_eventCustomerGiftCard.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _eventCustomerGiftCard;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerIcdCodesEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerIcdCodesEntity))]
		public virtual EntityCollection<EventCustomerIcdCodesEntity> EventCustomerIcdCodes
		{
			get
			{
				if(_eventCustomerIcdCodes==null)
				{
					_eventCustomerIcdCodes = new EntityCollection<EventCustomerIcdCodesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerIcdCodesEntityFactory)));
					_eventCustomerIcdCodes.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _eventCustomerIcdCodes;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerNotificationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerNotificationEntity))]
		public virtual EntityCollection<EventCustomerNotificationEntity> EventCustomerNotification
		{
			get
			{
				if(_eventCustomerNotification==null)
				{
					_eventCustomerNotification = new EntityCollection<EventCustomerNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerNotificationEntityFactory)));
					_eventCustomerNotification.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _eventCustomerNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerOrderDetailEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerOrderDetailEntity))]
		public virtual EntityCollection<EventCustomerOrderDetailEntity> EventCustomerOrderDetail
		{
			get
			{
				if(_eventCustomerOrderDetail==null)
				{
					_eventCustomerOrderDetail = new EntityCollection<EventCustomerOrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerOrderDetailEntityFactory)));
					_eventCustomerOrderDetail.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _eventCustomerOrderDetail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerPreApprovedPackageTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerPreApprovedPackageTestEntity))]
		public virtual EntityCollection<EventCustomerPreApprovedPackageTestEntity> EventCustomerPreApprovedPackageTest
		{
			get
			{
				if(_eventCustomerPreApprovedPackageTest==null)
				{
					_eventCustomerPreApprovedPackageTest = new EntityCollection<EventCustomerPreApprovedPackageTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerPreApprovedPackageTestEntityFactory)));
					_eventCustomerPreApprovedPackageTest.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _eventCustomerPreApprovedPackageTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerPreApprovedTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerPreApprovedTestEntity))]
		public virtual EntityCollection<EventCustomerPreApprovedTestEntity> EventCustomerPreApprovedTest
		{
			get
			{
				if(_eventCustomerPreApprovedTest==null)
				{
					_eventCustomerPreApprovedTest = new EntityCollection<EventCustomerPreApprovedTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerPreApprovedTestEntityFactory)));
					_eventCustomerPreApprovedTest.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _eventCustomerPreApprovedTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerPrimaryCarePhysicianEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerPrimaryCarePhysicianEntity))]
		public virtual EntityCollection<EventCustomerPrimaryCarePhysicianEntity> EventCustomerPrimaryCarePhysician
		{
			get
			{
				if(_eventCustomerPrimaryCarePhysician==null)
				{
					_eventCustomerPrimaryCarePhysician = new EntityCollection<EventCustomerPrimaryCarePhysicianEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerPrimaryCarePhysicianEntityFactory)));
					_eventCustomerPrimaryCarePhysician.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _eventCustomerPrimaryCarePhysician;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerQuestionAnswerEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerQuestionAnswerEntity))]
		public virtual EntityCollection<EventCustomerQuestionAnswerEntity> EventCustomerQuestionAnswer
		{
			get
			{
				if(_eventCustomerQuestionAnswer==null)
				{
					_eventCustomerQuestionAnswer = new EntityCollection<EventCustomerQuestionAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerQuestionAnswerEntityFactory)));
					_eventCustomerQuestionAnswer.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _eventCustomerQuestionAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerRequiredTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerRequiredTestEntity))]
		public virtual EntityCollection<EventCustomerRequiredTestEntity> EventCustomerRequiredTest
		{
			get
			{
				if(_eventCustomerRequiredTest==null)
				{
					_eventCustomerRequiredTest = new EntityCollection<EventCustomerRequiredTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerRequiredTestEntityFactory)));
					_eventCustomerRequiredTest.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _eventCustomerRequiredTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerRetestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerRetestEntity))]
		public virtual EntityCollection<EventCustomerRetestEntity> EventCustomerRetest
		{
			get
			{
				if(_eventCustomerRetest==null)
				{
					_eventCustomerRetest = new EntityCollection<EventCustomerRetestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerRetestEntityFactory)));
					_eventCustomerRetest.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _eventCustomerRetest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerTestNotPerformedNotificationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerTestNotPerformedNotificationEntity))]
		public virtual EntityCollection<EventCustomerTestNotPerformedNotificationEntity> EventCustomerTestNotPerformedNotification
		{
			get
			{
				if(_eventCustomerTestNotPerformedNotification==null)
				{
					_eventCustomerTestNotPerformedNotification = new EntityCollection<EventCustomerTestNotPerformedNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerTestNotPerformedNotificationEntityFactory)));
					_eventCustomerTestNotPerformedNotification.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _eventCustomerTestNotPerformedNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ExitInterviewAnswerEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ExitInterviewAnswerEntity))]
		public virtual EntityCollection<ExitInterviewAnswerEntity> ExitInterviewAnswer
		{
			get
			{
				if(_exitInterviewAnswer==null)
				{
					_exitInterviewAnswer = new EntityCollection<ExitInterviewAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ExitInterviewAnswerEntityFactory)));
					_exitInterviewAnswer.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _exitInterviewAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ExitInterviewSignatureEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ExitInterviewSignatureEntity))]
		public virtual EntityCollection<ExitInterviewSignatureEntity> ExitInterviewSignature
		{
			get
			{
				if(_exitInterviewSignature==null)
				{
					_exitInterviewSignature = new EntityCollection<ExitInterviewSignatureEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ExitInterviewSignatureEntityFactory)));
					_exitInterviewSignature.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _exitInterviewSignature;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FluConsentAnswerEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FluConsentAnswerEntity))]
		public virtual EntityCollection<FluConsentAnswerEntity> FluConsentAnswer
		{
			get
			{
				if(_fluConsentAnswer==null)
				{
					_fluConsentAnswer = new EntityCollection<FluConsentAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentAnswerEntityFactory)));
					_fluConsentAnswer.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _fluConsentAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FluConsentSignatureEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FluConsentSignatureEntity))]
		public virtual EntityCollection<FluConsentSignatureEntity> FluConsentSignature
		{
			get
			{
				if(_fluConsentSignature==null)
				{
					_fluConsentSignature = new EntityCollection<FluConsentSignatureEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentSignatureEntityFactory)));
					_fluConsentSignature.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _fluConsentSignature;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ParticipationConsentSignatureEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ParticipationConsentSignatureEntity))]
		public virtual EntityCollection<ParticipationConsentSignatureEntity> ParticipationConsentSignature
		{
			get
			{
				if(_participationConsentSignature==null)
				{
					_participationConsentSignature = new EntityCollection<ParticipationConsentSignatureEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ParticipationConsentSignatureEntityFactory)));
					_participationConsentSignature.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _participationConsentSignature;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PcpDispositionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PcpDispositionEntity))]
		public virtual EntityCollection<PcpDispositionEntity> PcpDisposition
		{
			get
			{
				if(_pcpDisposition==null)
				{
					_pcpDisposition = new EntityCollection<PcpDispositionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PcpDispositionEntityFactory)));
					_pcpDisposition.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _pcpDisposition;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianCustomerAssignmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianCustomerAssignmentEntity))]
		public virtual EntityCollection<PhysicianCustomerAssignmentEntity> PhysicianCustomerAssignment
		{
			get
			{
				if(_physicianCustomerAssignment==null)
				{
					_physicianCustomerAssignment = new EntityCollection<PhysicianCustomerAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianCustomerAssignmentEntityFactory)));
					_physicianCustomerAssignment.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _physicianCustomerAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianEvaluationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianEvaluationEntity))]
		public virtual EntityCollection<PhysicianEvaluationEntity> PhysicianEvaluation
		{
			get
			{
				if(_physicianEvaluation==null)
				{
					_physicianEvaluation = new EntityCollection<PhysicianEvaluationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianEvaluationEntityFactory)));
					_physicianEvaluation.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _physicianEvaluation;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianRecordRequestSignatureEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianRecordRequestSignatureEntity))]
		public virtual EntityCollection<PhysicianRecordRequestSignatureEntity> PhysicianRecordRequestSignature
		{
			get
			{
				if(_physicianRecordRequestSignature==null)
				{
					_physicianRecordRequestSignature = new EntityCollection<PhysicianRecordRequestSignatureEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianRecordRequestSignatureEntityFactory)));
					_physicianRecordRequestSignature.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _physicianRecordRequestSignature;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SurveyAnswerEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(SurveyAnswerEntity))]
		public virtual EntityCollection<SurveyAnswerEntity> SurveyAnswer
		{
			get
			{
				if(_surveyAnswer==null)
				{
					_surveyAnswer = new EntityCollection<SurveyAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyAnswerEntityFactory)));
					_surveyAnswer.SetContainingEntityInfo(this, "EventCustomers");
				}
				return _surveyAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountEntity))]
		public virtual EntityCollection<AccountEntity> AccountCollectionViaCallQueueCustomer
		{
			get
			{
				if(_accountCollectionViaCallQueueCustomer==null)
				{
					_accountCollectionViaCallQueueCustomer = new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory)));
					_accountCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _accountCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ActivityTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ActivityTypeEntity))]
		public virtual EntityCollection<ActivityTypeEntity> ActivityTypeCollectionViaCallQueueCustomer
		{
			get
			{
				if(_activityTypeCollectionViaCallQueueCustomer==null)
				{
					_activityTypeCollectionViaCallQueueCustomer = new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory)));
					_activityTypeCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _activityTypeCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueEntity))]
		public virtual EntityCollection<CallQueueEntity> CallQueueCollectionViaCallQueueCustomer
		{
			get
			{
				if(_callQueueCollectionViaCallQueueCustomer==null)
				{
					_callQueueCollectionViaCallQueueCustomer = new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory)));
					_callQueueCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _callQueueCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueCriteriaEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueCriteriaEntity))]
		public virtual EntityCollection<CallQueueCriteriaEntity> CallQueueCriteriaCollectionViaCallQueueCustomer
		{
			get
			{
				if(_callQueueCriteriaCollectionViaCallQueueCustomer==null)
				{
					_callQueueCriteriaCollectionViaCallQueueCustomer = new EntityCollection<CallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCriteriaEntityFactory)));
					_callQueueCriteriaCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _callQueueCriteriaCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CampaignEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CampaignEntity))]
		public virtual EntityCollection<CampaignEntity> CampaignCollectionViaCallQueueCustomer
		{
			get
			{
				if(_campaignCollectionViaCallQueueCustomer==null)
				{
					_campaignCollectionViaCallQueueCustomer = new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory)));
					_campaignCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _campaignCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChaperoneQuestionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChaperoneQuestionEntity))]
		public virtual EntityCollection<ChaperoneQuestionEntity> ChaperoneQuestionCollectionViaChaperoneAnswer
		{
			get
			{
				if(_chaperoneQuestionCollectionViaChaperoneAnswer==null)
				{
					_chaperoneQuestionCollectionViaChaperoneAnswer = new EntityCollection<ChaperoneQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaperoneQuestionEntityFactory)));
					_chaperoneQuestionCollectionViaChaperoneAnswer.IsReadOnly=true;
				}
				return _chaperoneQuestionCollectionViaChaperoneAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChargeCardEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChargeCardEntity))]
		public virtual EntityCollection<ChargeCardEntity> ChargeCardCollectionViaEventCustomerEligibility
		{
			get
			{
				if(_chargeCardCollectionViaEventCustomerEligibility==null)
				{
					_chargeCardCollectionViaEventCustomerEligibility = new EntityCollection<ChargeCardEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChargeCardEntityFactory)));
					_chargeCardCollectionViaEventCustomerEligibility.IsReadOnly=true;
				}
				return _chargeCardCollectionViaEventCustomerEligibility;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckListQuestionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckListQuestionEntity))]
		public virtual EntityCollection<CheckListQuestionEntity> CheckListQuestionCollectionViaExitInterviewSignature
		{
			get
			{
				if(_checkListQuestionCollectionViaExitInterviewSignature==null)
				{
					_checkListQuestionCollectionViaExitInterviewSignature = new EntityCollection<CheckListQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListQuestionEntityFactory)));
					_checkListQuestionCollectionViaExitInterviewSignature.IsReadOnly=true;
				}
				return _checkListQuestionCollectionViaExitInterviewSignature;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckListQuestionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckListQuestionEntity))]
		public virtual EntityCollection<CheckListQuestionEntity> CheckListQuestionCollectionViaCheckListAnswer
		{
			get
			{
				if(_checkListQuestionCollectionViaCheckListAnswer==null)
				{
					_checkListQuestionCollectionViaCheckListAnswer = new EntityCollection<CheckListQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListQuestionEntityFactory)));
					_checkListQuestionCollectionViaCheckListAnswer.IsReadOnly=true;
				}
				return _checkListQuestionCollectionViaCheckListAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ClickLogEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ClickLogEntity))]
		public virtual EntityCollection<ClickLogEntity> ClickLogCollectionViaClickConversion
		{
			get
			{
				if(_clickLogCollectionViaClickConversion==null)
				{
					_clickLogCollectionViaClickConversion = new EntityCollection<ClickLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClickLogEntityFactory)));
					_clickLogCollectionViaClickConversion.IsReadOnly=true;
				}
				return _clickLogCollectionViaClickConversion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CorporateUploadEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CorporateUploadEntity))]
		public virtual EntityCollection<CorporateUploadEntity> CorporateUploadCollectionViaCustomerOrderHistory
		{
			get
			{
				if(_corporateUploadCollectionViaCustomerOrderHistory==null)
				{
					_corporateUploadCollectionViaCustomerOrderHistory = new EntityCollection<CorporateUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CorporateUploadEntityFactory)));
					_corporateUploadCollectionViaCustomerOrderHistory.IsReadOnly=true;
				}
				return _corporateUploadCollectionViaCustomerOrderHistory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CriticalQuestionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CriticalQuestionEntity))]
		public virtual EntityCollection<CriticalQuestionEntity> CriticalQuestionCollectionViaEventCustomerCriticalQuestion
		{
			get
			{
				if(_criticalQuestionCollectionViaEventCustomerCriticalQuestion==null)
				{
					_criticalQuestionCollectionViaEventCustomerCriticalQuestion = new EntityCollection<CriticalQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CriticalQuestionEntityFactory)));
					_criticalQuestionCollectionViaEventCustomerCriticalQuestion.IsReadOnly=true;
				}
				return _criticalQuestionCollectionViaEventCustomerCriticalQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerHealthQuestionsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerHealthQuestionsEntity))]
		public virtual EntityCollection<CustomerHealthQuestionsEntity> CustomerHealthQuestionsCollectionViaCustomerHealthInfoArchive
		{
			get
			{
				if(_customerHealthQuestionsCollectionViaCustomerHealthInfoArchive==null)
				{
					_customerHealthQuestionsCollectionViaCustomerHealthInfoArchive = new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory)));
					_customerHealthQuestionsCollectionViaCustomerHealthInfoArchive.IsReadOnly=true;
				}
				return _customerHealthQuestionsCollectionViaCustomerHealthInfoArchive;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerHealthQuestionsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerHealthQuestionsEntity))]
		public virtual EntityCollection<CustomerHealthQuestionsEntity> CustomerHealthQuestionsCollectionViaCustomerHealthInfo
		{
			get
			{
				if(_customerHealthQuestionsCollectionViaCustomerHealthInfo==null)
				{
					_customerHealthQuestionsCollectionViaCustomerHealthInfo = new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory)));
					_customerHealthQuestionsCollectionViaCustomerHealthInfo.IsReadOnly=true;
				}
				return _customerHealthQuestionsCollectionViaCustomerHealthInfo;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerPrimaryCarePhysicianEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerPrimaryCarePhysicianEntity))]
		public virtual EntityCollection<CustomerPrimaryCarePhysicianEntity> CustomerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician
		{
			get
			{
				if(_customerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician==null)
				{
					_customerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician = new EntityCollection<CustomerPrimaryCarePhysicianEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerPrimaryCarePhysicianEntityFactory)));
					_customerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician.IsReadOnly=true;
				}
				return _customerPrimaryCarePhysicianCollectionViaEventCustomerPrimaryCarePhysician;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCustomerHealthInfo
		{
			get
			{
				if(_customerProfileCollectionViaCustomerHealthInfo==null)
				{
					_customerProfileCollectionViaCustomerHealthInfo = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCustomerHealthInfo.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCustomerHealthInfo;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCallQueueCustomer
		{
			get
			{
				if(_customerProfileCollectionViaCallQueueCustomer==null)
				{
					_customerProfileCollectionViaCallQueueCustomer = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaDependentDisqualifiedTest
		{
			get
			{
				if(_customerProfileCollectionViaDependentDisqualifiedTest==null)
				{
					_customerProfileCollectionViaDependentDisqualifiedTest = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaDependentDisqualifiedTest.IsReadOnly=true;
				}
				return _customerProfileCollectionViaDependentDisqualifiedTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaClickConversion
		{
			get
			{
				if(_customerProfileCollectionViaClickConversion==null)
				{
					_customerProfileCollectionViaClickConversion = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaClickConversion.IsReadOnly=true;
				}
				return _customerProfileCollectionViaClickConversion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaDisqualifiedTest
		{
			get
			{
				if(_customerProfileCollectionViaDisqualifiedTest==null)
				{
					_customerProfileCollectionViaDisqualifiedTest = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaDisqualifiedTest.IsReadOnly=true;
				}
				return _customerProfileCollectionViaDisqualifiedTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCustomerOrderHistory
		{
			get
			{
				if(_customerProfileCollectionViaCustomerOrderHistory==null)
				{
					_customerProfileCollectionViaCustomerOrderHistory = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCustomerOrderHistory.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCustomerOrderHistory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCustomerHealthInfoArchive
		{
			get
			{
				if(_customerProfileCollectionViaCustomerHealthInfoArchive==null)
				{
					_customerProfileCollectionViaCustomerHealthInfoArchive = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCustomerHealthInfoArchive.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCustomerHealthInfoArchive;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaEventCustomerQuestionAnswer
		{
			get
			{
				if(_customerProfileCollectionViaEventCustomerQuestionAnswer==null)
				{
					_customerProfileCollectionViaEventCustomerQuestionAnswer = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaEventCustomerQuestionAnswer.IsReadOnly=true;
				}
				return _customerProfileCollectionViaEventCustomerQuestionAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerRegistrationNotesEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerRegistrationNotesEntity))]
		public virtual EntityCollection<CustomerRegistrationNotesEntity> CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				if(_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog==null)
				{
					_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog = new EntityCollection<CustomerRegistrationNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerRegistrationNotesEntityFactory)));
					_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog.IsReadOnly=true;
				}
				return _customerRegistrationNotesCollectionViaEventAppointmentCancellationLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomEventNotificationEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomEventNotificationEntity))]
		public virtual EntityCollection<CustomEventNotificationEntity> CustomEventNotificationCollectionViaEventCustomerCustomNotification
		{
			get
			{
				if(_customEventNotificationCollectionViaEventCustomerCustomNotification==null)
				{
					_customEventNotificationCollectionViaEventCustomerCustomNotification = new EntityCollection<CustomEventNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomEventNotificationEntityFactory)));
					_customEventNotificationCollectionViaEventCustomerCustomNotification.IsReadOnly=true;
				}
				return _customEventNotificationCollectionViaEventCustomerCustomNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EligibilityEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EligibilityEntity))]
		public virtual EntityCollection<EligibilityEntity> EligibilityCollectionViaEventCustomerEligibility
		{
			get
			{
				if(_eligibilityCollectionViaEventCustomerEligibility==null)
				{
					_eligibilityCollectionViaEventCustomerEligibility = new EntityCollection<EligibilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EligibilityEntityFactory)));
					_eligibilityCollectionViaEventCustomerEligibility.IsReadOnly=true;
				}
				return _eligibilityCollectionViaEventCustomerEligibility;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EncounterEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EncounterEntity))]
		public virtual EntityCollection<EncounterEntity> EncounterCollectionViaEventCustomerEncounter
		{
			get
			{
				if(_encounterCollectionViaEventCustomerEncounter==null)
				{
					_encounterCollectionViaEventCustomerEncounter = new EntityCollection<EncounterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EncounterEntityFactory)));
					_encounterCollectionViaEventCustomerEncounter.IsReadOnly=true;
				}
				return _encounterCollectionViaEventCustomerEncounter;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventPackageDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventPackageDetailsEntity))]
		public virtual EntityCollection<EventPackageDetailsEntity> EventPackageDetailsCollectionViaCustomerOrderHistory
		{
			get
			{
				if(_eventPackageDetailsCollectionViaCustomerOrderHistory==null)
				{
					_eventPackageDetailsCollectionViaCustomerOrderHistory = new EntityCollection<EventPackageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageDetailsEntityFactory)));
					_eventPackageDetailsCollectionViaCustomerOrderHistory.IsReadOnly=true;
				}
				return _eventPackageDetailsCollectionViaCustomerOrderHistory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventAppointmentChangeLog_
		{
			get
			{
				if(_eventsCollectionViaEventAppointmentChangeLog_==null)
				{
					_eventsCollectionViaEventAppointmentChangeLog_ = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventAppointmentChangeLog_.IsReadOnly=true;
				}
				return _eventsCollectionViaEventAppointmentChangeLog_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventAppointmentChangeLog
		{
			get
			{
				if(_eventsCollectionViaEventAppointmentChangeLog==null)
				{
					_eventsCollectionViaEventAppointmentChangeLog = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventAppointmentChangeLog.IsReadOnly=true;
				}
				return _eventsCollectionViaEventAppointmentChangeLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				if(_eventsCollectionViaEventAppointmentCancellationLog==null)
				{
					_eventsCollectionViaEventAppointmentCancellationLog = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventAppointmentCancellationLog.IsReadOnly=true;
				}
				return _eventsCollectionViaEventAppointmentCancellationLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventCustomerQuestionAnswer
		{
			get
			{
				if(_eventsCollectionViaEventCustomerQuestionAnswer==null)
				{
					_eventsCollectionViaEventCustomerQuestionAnswer = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventCustomerQuestionAnswer.IsReadOnly=true;
				}
				return _eventsCollectionViaEventCustomerQuestionAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaDependentDisqualifiedTest
		{
			get
			{
				if(_eventsCollectionViaDependentDisqualifiedTest==null)
				{
					_eventsCollectionViaDependentDisqualifiedTest = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaDependentDisqualifiedTest.IsReadOnly=true;
				}
				return _eventsCollectionViaDependentDisqualifiedTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaCustomerOrderHistory
		{
			get
			{
				if(_eventsCollectionViaCustomerOrderHistory==null)
				{
					_eventsCollectionViaCustomerOrderHistory = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaCustomerOrderHistory.IsReadOnly=true;
				}
				return _eventsCollectionViaCustomerOrderHistory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaDisqualifiedTest
		{
			get
			{
				if(_eventsCollectionViaDisqualifiedTest==null)
				{
					_eventsCollectionViaDisqualifiedTest = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaDisqualifiedTest.IsReadOnly=true;
				}
				return _eventsCollectionViaDisqualifiedTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaCallQueueCustomer
		{
			get
			{
				if(_eventsCollectionViaCallQueueCustomer==null)
				{
					_eventsCollectionViaCallQueueCustomer = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _eventsCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventTestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventTestEntity))]
		public virtual EntityCollection<EventTestEntity> EventTestCollectionViaCustomerOrderHistory
		{
			get
			{
				if(_eventTestCollectionViaCustomerOrderHistory==null)
				{
					_eventTestCollectionViaCustomerOrderHistory = new EntityCollection<EventTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestEntityFactory)));
					_eventTestCollectionViaCustomerOrderHistory.IsReadOnly=true;
				}
				return _eventTestCollectionViaCustomerOrderHistory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ExitInterviewQuestionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ExitInterviewQuestionEntity))]
		public virtual EntityCollection<ExitInterviewQuestionEntity> ExitInterviewQuestionCollectionViaExitInterviewAnswer
		{
			get
			{
				if(_exitInterviewQuestionCollectionViaExitInterviewAnswer==null)
				{
					_exitInterviewQuestionCollectionViaExitInterviewAnswer = new EntityCollection<ExitInterviewQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ExitInterviewQuestionEntityFactory)));
					_exitInterviewQuestionCollectionViaExitInterviewAnswer.IsReadOnly=true;
				}
				return _exitInterviewQuestionCollectionViaExitInterviewAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaParticipationConsentSignature_
		{
			get
			{
				if(_fileCollectionViaParticipationConsentSignature_==null)
				{
					_fileCollectionViaParticipationConsentSignature_ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaParticipationConsentSignature_.IsReadOnly=true;
				}
				return _fileCollectionViaParticipationConsentSignature_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaParticipationConsentSignature
		{
			get
			{
				if(_fileCollectionViaParticipationConsentSignature==null)
				{
					_fileCollectionViaParticipationConsentSignature = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaParticipationConsentSignature.IsReadOnly=true;
				}
				return _fileCollectionViaParticipationConsentSignature;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaEventCustomerGiftCard
		{
			get
			{
				if(_fileCollectionViaEventCustomerGiftCard==null)
				{
					_fileCollectionViaEventCustomerGiftCard = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaEventCustomerGiftCard.IsReadOnly=true;
				}
				return _fileCollectionViaEventCustomerGiftCard;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaEventCustomerGiftCard_
		{
			get
			{
				if(_fileCollectionViaEventCustomerGiftCard_==null)
				{
					_fileCollectionViaEventCustomerGiftCard_ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaEventCustomerGiftCard_.IsReadOnly=true;
				}
				return _fileCollectionViaEventCustomerGiftCard_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaFluConsentSignature_
		{
			get
			{
				if(_fileCollectionViaFluConsentSignature_==null)
				{
					_fileCollectionViaFluConsentSignature_ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaFluConsentSignature_.IsReadOnly=true;
				}
				return _fileCollectionViaFluConsentSignature_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaPhysicianRecordRequestSignature
		{
			get
			{
				if(_fileCollectionViaPhysicianRecordRequestSignature==null)
				{
					_fileCollectionViaPhysicianRecordRequestSignature = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaPhysicianRecordRequestSignature.IsReadOnly=true;
				}
				return _fileCollectionViaPhysicianRecordRequestSignature;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaChaperoneSignature
		{
			get
			{
				if(_fileCollectionViaChaperoneSignature==null)
				{
					_fileCollectionViaChaperoneSignature = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaChaperoneSignature.IsReadOnly=true;
				}
				return _fileCollectionViaChaperoneSignature;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaExitInterviewSignature
		{
			get
			{
				if(_fileCollectionViaExitInterviewSignature==null)
				{
					_fileCollectionViaExitInterviewSignature = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaExitInterviewSignature.IsReadOnly=true;
				}
				return _fileCollectionViaExitInterviewSignature;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaChaperoneSignature_
		{
			get
			{
				if(_fileCollectionViaChaperoneSignature_==null)
				{
					_fileCollectionViaChaperoneSignature_ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaChaperoneSignature_.IsReadOnly=true;
				}
				return _fileCollectionViaChaperoneSignature_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaFluConsentSignature
		{
			get
			{
				if(_fileCollectionViaFluConsentSignature==null)
				{
					_fileCollectionViaFluConsentSignature = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaFluConsentSignature.IsReadOnly=true;
				}
				return _fileCollectionViaFluConsentSignature;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FluConsentQuestionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FluConsentQuestionEntity))]
		public virtual EntityCollection<FluConsentQuestionEntity> FluConsentQuestionCollectionViaFluConsentAnswer
		{
			get
			{
				if(_fluConsentQuestionCollectionViaFluConsentAnswer==null)
				{
					_fluConsentQuestionCollectionViaFluConsentAnswer = new EntityCollection<FluConsentQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentQuestionEntityFactory)));
					_fluConsentQuestionCollectionViaFluConsentAnswer.IsReadOnly=true;
				}
				return _fluConsentQuestionCollectionViaFluConsentAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'IcdCodesEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(IcdCodesEntity))]
		public virtual EntityCollection<IcdCodesEntity> IcdCodesCollectionViaEventCustomerIcdCodes
		{
			get
			{
				if(_icdCodesCollectionViaEventCustomerIcdCodes==null)
				{
					_icdCodesCollectionViaEventCustomerIcdCodes = new EntityCollection<IcdCodesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IcdCodesEntityFactory)));
					_icdCodesCollectionViaEventCustomerIcdCodes.IsReadOnly=true;
				}
				return _icdCodesCollectionViaEventCustomerIcdCodes;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LanguageEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LanguageEntity))]
		public virtual EntityCollection<LanguageEntity> LanguageCollectionViaCallQueueCustomer
		{
			get
			{
				if(_languageCollectionViaCallQueueCustomer==null)
				{
					_languageCollectionViaCallQueueCustomer = new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory)));
					_languageCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _languageCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerOrderHistory
		{
			get
			{
				if(_lookupCollectionViaCustomerOrderHistory==null)
				{
					_lookupCollectionViaCustomerOrderHistory = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerOrderHistory.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerOrderHistory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCallQueueCustomer
		{
			get
			{
				if(_lookupCollectionViaCallQueueCustomer==null)
				{
					_lookupCollectionViaCallQueueCustomer = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _lookupCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEventAppointmentChangeLog
		{
			get
			{
				if(_lookupCollectionViaEventAppointmentChangeLog==null)
				{
					_lookupCollectionViaEventAppointmentChangeLog = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEventAppointmentChangeLog.IsReadOnly=true;
				}
				return _lookupCollectionViaEventAppointmentChangeLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCheckListAnswer
		{
			get
			{
				if(_lookupCollectionViaCheckListAnswer==null)
				{
					_lookupCollectionViaCheckListAnswer = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCheckListAnswer.IsReadOnly=true;
				}
				return _lookupCollectionViaCheckListAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaPcpDisposition
		{
			get
			{
				if(_lookupCollectionViaPcpDisposition==null)
				{
					_lookupCollectionViaPcpDisposition = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaPcpDisposition.IsReadOnly=true;
				}
				return _lookupCollectionViaPcpDisposition;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				if(_lookupCollectionViaEventAppointmentCancellationLog==null)
				{
					_lookupCollectionViaEventAppointmentCancellationLog = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEventAppointmentCancellationLog.IsReadOnly=true;
				}
				return _lookupCollectionViaEventAppointmentCancellationLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MedicareQuestionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MedicareQuestionEntity))]
		public virtual EntityCollection<MedicareQuestionEntity> MedicareQuestionCollectionViaCustomerMedicareQuestionAnswer
		{
			get
			{
				if(_medicareQuestionCollectionViaCustomerMedicareQuestionAnswer==null)
				{
					_medicareQuestionCollectionViaCustomerMedicareQuestionAnswer = new EntityCollection<MedicareQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicareQuestionEntityFactory)));
					_medicareQuestionCollectionViaCustomerMedicareQuestionAnswer.IsReadOnly=true;
				}
				return _medicareQuestionCollectionViaCustomerMedicareQuestionAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NdcEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NdcEntity))]
		public virtual EntityCollection<NdcEntity> NdcCollectionViaEventCustomerCurrentMedication
		{
			get
			{
				if(_ndcCollectionViaEventCustomerCurrentMedication==null)
				{
					_ndcCollectionViaEventCustomerCurrentMedication = new EntityCollection<NdcEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NdcEntityFactory)));
					_ndcCollectionViaEventCustomerCurrentMedication.IsReadOnly=true;
				}
				return _ndcCollectionViaEventCustomerCurrentMedication;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NotesDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NotesDetailsEntity))]
		public virtual EntityCollection<NotesDetailsEntity> NotesDetailsCollectionViaCallQueueCustomer
		{
			get
			{
				if(_notesDetailsCollectionViaCallQueueCustomer==null)
				{
					_notesDetailsCollectionViaCallQueueCustomer = new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory)));
					_notesDetailsCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _notesDetailsCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NotificationEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NotificationEntity))]
		public virtual EntityCollection<NotificationEntity> NotificationCollectionViaEventCustomerNotification
		{
			get
			{
				if(_notificationCollectionViaEventCustomerNotification==null)
				{
					_notificationCollectionViaEventCustomerNotification = new EntityCollection<NotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationEntityFactory)));
					_notificationCollectionViaEventCustomerNotification.IsReadOnly=true;
				}
				return _notificationCollectionViaEventCustomerNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NotificationTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NotificationTypeEntity))]
		public virtual EntityCollection<NotificationTypeEntity> NotificationTypeCollectionViaEventCustomerTestNotPerformedNotification
		{
			get
			{
				if(_notificationTypeCollectionViaEventCustomerTestNotPerformedNotification==null)
				{
					_notificationTypeCollectionViaEventCustomerTestNotPerformedNotification = new EntityCollection<NotificationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationTypeEntityFactory)));
					_notificationTypeCollectionViaEventCustomerTestNotPerformedNotification.IsReadOnly=true;
				}
				return _notificationTypeCollectionViaEventCustomerTestNotPerformedNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NotificationTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NotificationTypeEntity))]
		public virtual EntityCollection<NotificationTypeEntity> NotificationTypeCollectionViaEventCustomerNotification
		{
			get
			{
				if(_notificationTypeCollectionViaEventCustomerNotification==null)
				{
					_notificationTypeCollectionViaEventCustomerNotification = new EntityCollection<NotificationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationTypeEntityFactory)));
					_notificationTypeCollectionViaEventCustomerNotification.IsReadOnly=true;
				}
				return _notificationTypeCollectionViaEventCustomerNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrderDetailEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrderDetailEntity))]
		public virtual EntityCollection<OrderDetailEntity> OrderDetailCollectionViaEventCustomerOrderDetail
		{
			get
			{
				if(_orderDetailCollectionViaEventCustomerOrderDetail==null)
				{
					_orderDetailCollectionViaEventCustomerOrderDetail = new EntityCollection<OrderDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderDetailEntityFactory)));
					_orderDetailCollectionViaEventCustomerOrderDetail.IsReadOnly=true;
				}
				return _orderDetailCollectionViaEventCustomerOrderDetail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaExitInterviewAnswer_
		{
			get
			{
				if(_organizationRoleUserCollectionViaExitInterviewAnswer_==null)
				{
					_organizationRoleUserCollectionViaExitInterviewAnswer_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaExitInterviewAnswer_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaExitInterviewAnswer_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaParticipationConsentSignature
		{
			get
			{
				if(_organizationRoleUserCollectionViaParticipationConsentSignature==null)
				{
					_organizationRoleUserCollectionViaParticipationConsentSignature = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaParticipationConsentSignature.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaParticipationConsentSignature;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaFluConsentSignature
		{
			get
			{
				if(_organizationRoleUserCollectionViaFluConsentSignature==null)
				{
					_organizationRoleUserCollectionViaFluConsentSignature = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaFluConsentSignature.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaFluConsentSignature;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaPcpDisposition_
		{
			get
			{
				if(_organizationRoleUserCollectionViaPcpDisposition_==null)
				{
					_organizationRoleUserCollectionViaPcpDisposition_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaPcpDisposition_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaPcpDisposition_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaPcpDisposition
		{
			get
			{
				if(_organizationRoleUserCollectionViaPcpDisposition==null)
				{
					_organizationRoleUserCollectionViaPcpDisposition = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaPcpDisposition.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaPcpDisposition;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician==null)
				{
					_organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventCustomerPrimaryCarePhysician;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification==null)
				{
					_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventCustomerRetest
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventCustomerRetest==null)
				{
					_organizationRoleUserCollectionViaEventCustomerRetest = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventCustomerRetest.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventCustomerRetest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaExitInterviewAnswer
		{
			get
			{
				if(_organizationRoleUserCollectionViaExitInterviewAnswer==null)
				{
					_organizationRoleUserCollectionViaExitInterviewAnswer = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaExitInterviewAnswer.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaExitInterviewAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaExitInterviewSignature
		{
			get
			{
				if(_organizationRoleUserCollectionViaExitInterviewSignature==null)
				{
					_organizationRoleUserCollectionViaExitInterviewSignature = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaExitInterviewSignature.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaExitInterviewSignature;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaFluConsentAnswer_
		{
			get
			{
				if(_organizationRoleUserCollectionViaFluConsentAnswer_==null)
				{
					_organizationRoleUserCollectionViaFluConsentAnswer_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaFluConsentAnswer_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaFluConsentAnswer_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventCustomerQuestionAnswer==null)
				{
					_organizationRoleUserCollectionViaEventCustomerQuestionAnswer = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventCustomerQuestionAnswer.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventCustomerQuestionAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventCustomerQuestionAnswer_==null)
				{
					_organizationRoleUserCollectionViaEventCustomerQuestionAnswer_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventCustomerQuestionAnswer_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventCustomerQuestionAnswer_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaFluConsentAnswer
		{
			get
			{
				if(_organizationRoleUserCollectionViaFluConsentAnswer==null)
				{
					_organizationRoleUserCollectionViaFluConsentAnswer = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaFluConsentAnswer.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaFluConsentAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaChaperoneSignature
		{
			get
			{
				if(_organizationRoleUserCollectionViaChaperoneSignature==null)
				{
					_organizationRoleUserCollectionViaChaperoneSignature = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaChaperoneSignature.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaChaperoneSignature;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaSurveyAnswer
		{
			get
			{
				if(_organizationRoleUserCollectionViaSurveyAnswer==null)
				{
					_organizationRoleUserCollectionViaSurveyAnswer = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaSurveyAnswer.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaSurveyAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaDisqualifiedTest_
		{
			get
			{
				if(_organizationRoleUserCollectionViaDisqualifiedTest_==null)
				{
					_organizationRoleUserCollectionViaDisqualifiedTest_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaDisqualifiedTest_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaDisqualifiedTest_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventAppointmentChangeLog
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventAppointmentChangeLog==null)
				{
					_organizationRoleUserCollectionViaEventAppointmentChangeLog = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventAppointmentChangeLog.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventAppointmentChangeLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaChaperoneAnswer_
		{
			get
			{
				if(_organizationRoleUserCollectionViaChaperoneAnswer_==null)
				{
					_organizationRoleUserCollectionViaChaperoneAnswer_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaChaperoneAnswer_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaChaperoneAnswer_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventAppointmentCancellationLog==null)
				{
					_organizationRoleUserCollectionViaEventAppointmentCancellationLog = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventAppointmentCancellationLog.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventAppointmentCancellationLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCheckListAnswer_
		{
			get
			{
				if(_organizationRoleUserCollectionViaCheckListAnswer_==null)
				{
					_organizationRoleUserCollectionViaCheckListAnswer_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCheckListAnswer_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCheckListAnswer_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerHealthInfo
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerHealthInfo==null)
				{
					_organizationRoleUserCollectionViaCustomerHealthInfo = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerHealthInfo.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerHealthInfo;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerHealthInfoArchive
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerHealthInfoArchive==null)
				{
					_organizationRoleUserCollectionViaCustomerHealthInfoArchive = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerHealthInfoArchive.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerHealthInfoArchive;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaDisqualifiedTest
		{
			get
			{
				if(_organizationRoleUserCollectionViaDisqualifiedTest==null)
				{
					_organizationRoleUserCollectionViaDisqualifiedTest = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaDisqualifiedTest.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaDisqualifiedTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCheckListAnswer
		{
			get
			{
				if(_organizationRoleUserCollectionViaCheckListAnswer==null)
				{
					_organizationRoleUserCollectionViaCheckListAnswer = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCheckListAnswer.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCheckListAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaSurveyAnswer_
		{
			get
			{
				if(_organizationRoleUserCollectionViaSurveyAnswer_==null)
				{
					_organizationRoleUserCollectionViaSurveyAnswer_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaSurveyAnswer_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaSurveyAnswer_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaChaperoneAnswer
		{
			get
			{
				if(_organizationRoleUserCollectionViaChaperoneAnswer==null)
				{
					_organizationRoleUserCollectionViaChaperoneAnswer = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaChaperoneAnswer.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaChaperoneAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCallQueueCustomer__
		{
			get
			{
				if(_organizationRoleUserCollectionViaCallQueueCustomer__==null)
				{
					_organizationRoleUserCollectionViaCallQueueCustomer__ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCallQueueCustomer__.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCallQueueCustomer__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventCustomerGiftCard
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventCustomerGiftCard==null)
				{
					_organizationRoleUserCollectionViaEventCustomerGiftCard = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventCustomerGiftCard.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventCustomerGiftCard;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCallQueueCustomer
		{
			get
			{
				if(_organizationRoleUserCollectionViaCallQueueCustomer==null)
				{
					_organizationRoleUserCollectionViaCallQueueCustomer = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCallQueueCustomer_
		{
			get
			{
				if(_organizationRoleUserCollectionViaCallQueueCustomer_==null)
				{
					_organizationRoleUserCollectionViaCallQueueCustomer_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCallQueueCustomer_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCallQueueCustomer_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaPhysicianRecordRequestSignature
		{
			get
			{
				if(_organizationRoleUserCollectionViaPhysicianRecordRequestSignature==null)
				{
					_organizationRoleUserCollectionViaPhysicianRecordRequestSignature = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaPhysicianRecordRequestSignature.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaPhysicianRecordRequestSignature;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerMedicareQuestionAnswer
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer==null)
				{
					_organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerMedicareQuestionAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PackageEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PackageEntity))]
		public virtual EntityCollection<PackageEntity> PackageCollectionViaEventCustomerPreApprovedPackageTest
		{
			get
			{
				if(_packageCollectionViaEventCustomerPreApprovedPackageTest==null)
				{
					_packageCollectionViaEventCustomerPreApprovedPackageTest = new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory)));
					_packageCollectionViaEventCustomerPreApprovedPackageTest.IsReadOnly=true;
				}
				return _packageCollectionViaEventCustomerPreApprovedPackageTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianProfileEntity))]
		public virtual EntityCollection<PhysicianProfileEntity> PhysicianProfileCollectionViaPhysicianEvaluation
		{
			get
			{
				if(_physicianProfileCollectionViaPhysicianEvaluation==null)
				{
					_physicianProfileCollectionViaPhysicianEvaluation = new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory)));
					_physicianProfileCollectionViaPhysicianEvaluation.IsReadOnly=true;
				}
				return _physicianProfileCollectionViaPhysicianEvaluation;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianProfileEntity))]
		public virtual EntityCollection<PhysicianProfileEntity> PhysicianProfileCollectionViaPhysicianCustomerAssignment_
		{
			get
			{
				if(_physicianProfileCollectionViaPhysicianCustomerAssignment_==null)
				{
					_physicianProfileCollectionViaPhysicianCustomerAssignment_ = new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory)));
					_physicianProfileCollectionViaPhysicianCustomerAssignment_.IsReadOnly=true;
				}
				return _physicianProfileCollectionViaPhysicianCustomerAssignment_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianProfileEntity))]
		public virtual EntityCollection<PhysicianProfileEntity> PhysicianProfileCollectionViaPhysicianCustomerAssignment
		{
			get
			{
				if(_physicianProfileCollectionViaPhysicianCustomerAssignment==null)
				{
					_physicianProfileCollectionViaPhysicianCustomerAssignment = new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory)));
					_physicianProfileCollectionViaPhysicianCustomerAssignment.IsReadOnly=true;
				}
				return _physicianProfileCollectionViaPhysicianCustomerAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PreQualificationQuestionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PreQualificationQuestionEntity))]
		public virtual EntityCollection<PreQualificationQuestionEntity> PreQualificationQuestionCollectionViaEventCustomerQuestionAnswer
		{
			get
			{
				if(_preQualificationQuestionCollectionViaEventCustomerQuestionAnswer==null)
				{
					_preQualificationQuestionCollectionViaEventCustomerQuestionAnswer = new EntityCollection<PreQualificationQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationQuestionEntityFactory)));
					_preQualificationQuestionCollectionViaEventCustomerQuestionAnswer.IsReadOnly=true;
				}
				return _preQualificationQuestionCollectionViaEventCustomerQuestionAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PreQualificationQuestionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PreQualificationQuestionEntity))]
		public virtual EntityCollection<PreQualificationQuestionEntity> PreQualificationQuestionCollectionViaDisqualifiedTest
		{
			get
			{
				if(_preQualificationQuestionCollectionViaDisqualifiedTest==null)
				{
					_preQualificationQuestionCollectionViaDisqualifiedTest = new EntityCollection<PreQualificationQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationQuestionEntityFactory)));
					_preQualificationQuestionCollectionViaDisqualifiedTest.IsReadOnly=true;
				}
				return _preQualificationQuestionCollectionViaDisqualifiedTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectCustomerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectCustomerEntity))]
		public virtual EntityCollection<ProspectCustomerEntity> ProspectCustomerCollectionViaClickConversion
		{
			get
			{
				if(_prospectCustomerCollectionViaClickConversion==null)
				{
					_prospectCustomerCollectionViaClickConversion = new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory)));
					_prospectCustomerCollectionViaClickConversion.IsReadOnly=true;
				}
				return _prospectCustomerCollectionViaClickConversion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectCustomerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectCustomerEntity))]
		public virtual EntityCollection<ProspectCustomerEntity> ProspectCustomerCollectionViaCallQueueCustomer
		{
			get
			{
				if(_prospectCustomerCollectionViaCallQueueCustomer==null)
				{
					_prospectCustomerCollectionViaCallQueueCustomer = new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory)));
					_prospectCustomerCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _prospectCustomerCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RefundRequestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RefundRequestEntity))]
		public virtual EntityCollection<RefundRequestEntity> RefundRequestCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				if(_refundRequestCollectionViaEventAppointmentCancellationLog==null)
				{
					_refundRequestCollectionViaEventAppointmentCancellationLog = new EntityCollection<RefundRequestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundRequestEntityFactory)));
					_refundRequestCollectionViaEventAppointmentCancellationLog.IsReadOnly=true;
				}
				return _refundRequestCollectionViaEventAppointmentCancellationLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RescheduleCancelDispositionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RescheduleCancelDispositionEntity))]
		public virtual EntityCollection<RescheduleCancelDispositionEntity> RescheduleCancelDispositionCollectionViaEventAppointmentChangeLog
		{
			get
			{
				if(_rescheduleCancelDispositionCollectionViaEventAppointmentChangeLog==null)
				{
					_rescheduleCancelDispositionCollectionViaEventAppointmentChangeLog = new EntityCollection<RescheduleCancelDispositionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RescheduleCancelDispositionEntityFactory)));
					_rescheduleCancelDispositionCollectionViaEventAppointmentChangeLog.IsReadOnly=true;
				}
				return _rescheduleCancelDispositionCollectionViaEventAppointmentChangeLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RescheduleCancelDispositionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RescheduleCancelDispositionEntity))]
		public virtual EntityCollection<RescheduleCancelDispositionEntity> RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				if(_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog==null)
				{
					_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog = new EntityCollection<RescheduleCancelDispositionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RescheduleCancelDispositionEntityFactory)));
					_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog.IsReadOnly=true;
				}
				return _rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SurveyQuestionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(SurveyQuestionEntity))]
		public virtual EntityCollection<SurveyQuestionEntity> SurveyQuestionCollectionViaSurveyAnswer
		{
			get
			{
				if(_surveyQuestionCollectionViaSurveyAnswer==null)
				{
					_surveyQuestionCollectionViaSurveyAnswer = new EntityCollection<SurveyQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyQuestionEntityFactory)));
					_surveyQuestionCollectionViaSurveyAnswer.IsReadOnly=true;
				}
				return _surveyQuestionCollectionViaSurveyAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaEventCustomerPreApprovedPackageTest
		{
			get
			{
				if(_testCollectionViaEventCustomerPreApprovedPackageTest==null)
				{
					_testCollectionViaEventCustomerPreApprovedPackageTest = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaEventCustomerPreApprovedPackageTest.IsReadOnly=true;
				}
				return _testCollectionViaEventCustomerPreApprovedPackageTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaDisqualifiedTest
		{
			get
			{
				if(_testCollectionViaDisqualifiedTest==null)
				{
					_testCollectionViaDisqualifiedTest = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaDisqualifiedTest.IsReadOnly=true;
				}
				return _testCollectionViaDisqualifiedTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaDependentDisqualifiedTest
		{
			get
			{
				if(_testCollectionViaDependentDisqualifiedTest==null)
				{
					_testCollectionViaDependentDisqualifiedTest = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaDependentDisqualifiedTest.IsReadOnly=true;
				}
				return _testCollectionViaDependentDisqualifiedTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaEventCustomerRetest
		{
			get
			{
				if(_testCollectionViaEventCustomerRetest==null)
				{
					_testCollectionViaEventCustomerRetest = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaEventCustomerRetest.IsReadOnly=true;
				}
				return _testCollectionViaEventCustomerRetest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaEventCustomerTestNotPerformedNotification
		{
			get
			{
				if(_testCollectionViaEventCustomerTestNotPerformedNotification==null)
				{
					_testCollectionViaEventCustomerTestNotPerformedNotification = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaEventCustomerTestNotPerformedNotification.IsReadOnly=true;
				}
				return _testCollectionViaEventCustomerTestNotPerformedNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaEventCustomerPreApprovedTest
		{
			get
			{
				if(_testCollectionViaEventCustomerPreApprovedTest==null)
				{
					_testCollectionViaEventCustomerPreApprovedTest = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaEventCustomerPreApprovedTest.IsReadOnly=true;
				}
				return _testCollectionViaEventCustomerPreApprovedTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaEventCustomerRequiredTest
		{
			get
			{
				if(_testCollectionViaEventCustomerRequiredTest==null)
				{
					_testCollectionViaEventCustomerRequiredTest = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaEventCustomerRequiredTest.IsReadOnly=true;
				}
				return _testCollectionViaEventCustomerRequiredTest;
			}
		}

		/// <summary> Gets / sets related entity of type 'AfaffiliateCampaignEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AfaffiliateCampaignEntity AfaffiliateCampaign
		{
			get
			{
				return _afaffiliateCampaign;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAfaffiliateCampaign(value);
				}
				else
				{
					if(value==null)
					{
						if(_afaffiliateCampaign != null)
						{
							_afaffiliateCampaign.UnsetRelatedEntity(this, "EventCustomers");
						}
					}
					else
					{
						if(_afaffiliateCampaign!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventCustomers");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CampaignEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CampaignEntity Campaign
		{
			get
			{
				return _campaign;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCampaign(value);
				}
				else
				{
					if(value==null)
					{
						if(_campaign != null)
						{
							_campaign.UnsetRelatedEntity(this, "EventCustomers");
						}
					}
					else
					{
						if(_campaign!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventCustomers");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CustomerProfileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerProfileEntity CustomerProfile
		{
			get
			{
				return _customerProfile;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerProfile(value);
				}
				else
				{
					if(value==null)
					{
						if(_customerProfile != null)
						{
							_customerProfile.UnsetRelatedEntity(this, "EventCustomers");
						}
					}
					else
					{
						if(_customerProfile!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventCustomers");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CustomerProfileHistoryEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerProfileHistoryEntity CustomerProfileHistory
		{
			get
			{
				return _customerProfileHistory;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerProfileHistory(value);
				}
				else
				{
					if(value==null)
					{
						if(_customerProfileHistory != null)
						{
							_customerProfileHistory.UnsetRelatedEntity(this, "EventCustomers");
						}
					}
					else
					{
						if(_customerProfileHistory!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventCustomers");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CustomerRegistrationNotesEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerRegistrationNotesEntity CustomerRegistrationNotes
		{
			get
			{
				return _customerRegistrationNotes;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerRegistrationNotes(value);
				}
				else
				{
					if(value==null)
					{
						if(_customerRegistrationNotes != null)
						{
							_customerRegistrationNotes.UnsetRelatedEntity(this, "EventCustomers");
						}
					}
					else
					{
						if(_customerRegistrationNotes!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventCustomers");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'EventAppointmentEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EventAppointmentEntity EventAppointment
		{
			get
			{
				return _eventAppointment;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEventAppointment(value);
				}
				else
				{
					if(value==null)
					{
						if(_eventAppointment != null)
						{
							_eventAppointment.UnsetRelatedEntity(this, "EventCustomers");
						}
					}
					else
					{
						if(_eventAppointment!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventCustomers");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'EventsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EventsEntity Events
		{
			get
			{
				return _events;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEvents(value);
				}
				else
				{
					if(value==null)
					{
						if(_events != null)
						{
							_events.UnsetRelatedEntity(this, "EventCustomers");
						}
					}
					else
					{
						if(_events!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventCustomers");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GcNotGivenReasonEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GcNotGivenReasonEntity GcNotGivenReason
		{
			get
			{
				return _gcNotGivenReason;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGcNotGivenReason(value);
				}
				else
				{
					if(value==null)
					{
						if(_gcNotGivenReason != null)
						{
							_gcNotGivenReason.UnsetRelatedEntity(this, "EventCustomers");
						}
					}
					else
					{
						if(_gcNotGivenReason!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventCustomers");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'HospitalFacilityEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual HospitalFacilityEntity HospitalFacility
		{
			get
			{
				return _hospitalFacility;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncHospitalFacility(value);
				}
				else
				{
					if(value==null)
					{
						if(_hospitalFacility != null)
						{
							_hospitalFacility.UnsetRelatedEntity(this, "EventCustomers");
						}
					}
					else
					{
						if(_hospitalFacility!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventCustomers");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup_
		{
			get
			{
				return _lookup_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup_(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup_ != null)
						{
							_lookup_.UnsetRelatedEntity(this, "EventCustomers_");
						}
					}
					else
					{
						if(_lookup_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventCustomers_");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup
		{
			get
			{
				return _lookup;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup != null)
						{
							_lookup.UnsetRelatedEntity(this, "EventCustomers");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventCustomers");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser_
		{
			get
			{
				return _organizationRoleUser_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser_(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser_ != null)
						{
							_organizationRoleUser_.UnsetRelatedEntity(this, "EventCustomers_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventCustomers_");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser
		{
			get
			{
				return _organizationRoleUser;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser != null)
						{
							_organizationRoleUser.UnsetRelatedEntity(this, "EventCustomers");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventCustomers");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CustomerSkipReviewEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerSkipReviewEntity CustomerSkipReview
		{
			get
			{
				return _customerSkipReview;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerSkipReview(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "EventCustomers");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_customerSkipReview !=null);
						DesetupSyncCustomerSkipReview(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("CustomerSkipReview");
						}
					}
					else
					{
						if(_customerSkipReview!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "EventCustomers");
							SetupSyncCustomerSkipReview(relatedEntity);
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'EventCustomerBarrierEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EventCustomerBarrierEntity EventCustomerBarrier
		{
			get
			{
				return _eventCustomerBarrier;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEventCustomerBarrier(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "EventCustomers");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_eventCustomerBarrier !=null);
						DesetupSyncEventCustomerBarrier(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("EventCustomerBarrier");
						}
					}
					else
					{
						if(_eventCustomerBarrier!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "EventCustomers");
							SetupSyncEventCustomerBarrier(relatedEntity);
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'EventCustomerBasicBioMetricEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EventCustomerBasicBioMetricEntity EventCustomerBasicBioMetric
		{
			get
			{
				return _eventCustomerBasicBioMetric;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEventCustomerBasicBioMetric(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "EventCustomers");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_eventCustomerBasicBioMetric !=null);
						DesetupSyncEventCustomerBasicBioMetric(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("EventCustomerBasicBioMetric");
						}
					}
					else
					{
						if(_eventCustomerBasicBioMetric!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "EventCustomers");
							SetupSyncEventCustomerBasicBioMetric(relatedEntity);
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'EventCustomerEvaluationLockEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EventCustomerEvaluationLockEntity EventCustomerEvaluationLock
		{
			get
			{
				return _eventCustomerEvaluationLock;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEventCustomerEvaluationLock(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "EventCustomers");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_eventCustomerEvaluationLock !=null);
						DesetupSyncEventCustomerEvaluationLock(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("EventCustomerEvaluationLock");
						}
					}
					else
					{
						if(_eventCustomerEvaluationLock!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "EventCustomers");
							SetupSyncEventCustomerEvaluationLock(relatedEntity);
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'EventCustomerResultEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EventCustomerResultEntity EventCustomerResult
		{
			get
			{
				return _eventCustomerResult;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEventCustomerResult(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "EventCustomers");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_eventCustomerResult !=null);
						DesetupSyncEventCustomerResult(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("EventCustomerResult");
						}
					}
					else
					{
						if(_eventCustomerResult!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "EventCustomers");
							SetupSyncEventCustomerResult(relatedEntity);
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'PcpAppointmentEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual PcpAppointmentEntity PcpAppointment_
		{
			get
			{
				return _pcpAppointment_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncPcpAppointment_(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "EventCustomers");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_pcpAppointment_ !=null);
						DesetupSyncPcpAppointment_(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("PcpAppointment_");
						}
					}
					else
					{
						if(_pcpAppointment_!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "EventCustomers");
							SetupSyncPcpAppointment_(relatedEntity);
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ScreeningAuthorizationEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ScreeningAuthorizationEntity ScreeningAuthorization
		{
			get
			{
				return _screeningAuthorization;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncScreeningAuthorization(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "EventCustomers");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_screeningAuthorization !=null);
						DesetupSyncScreeningAuthorization(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("ScreeningAuthorization");
						}
					}
					else
					{
						if(_screeningAuthorization!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "EventCustomers");
							SetupSyncScreeningAuthorization(relatedEntity);
						}
					}
				}
			}
		}
	
		
		/// <summary> Gets the type of the hierarchy this entity is in. </summary>
		protected override InheritanceHierarchyType LLBLGenProIsInHierarchyOfType
		{
			get { return InheritanceHierarchyType.None;}
		}
		
		/// <summary> Gets or sets a value indicating whether this entity is a subtype</summary>
		protected override bool LLBLGenProIsSubType
		{
			get { return false;}
		}
		
		/// <summary>Returns the Falcon.Data.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)Falcon.Data.EntityType.EventCustomersEntity; }
		}
		#endregion


		#region Custom Entity code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Included code

		#endregion
	}
}
