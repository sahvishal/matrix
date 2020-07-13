///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:37
// Code is generated using templates: SD.TemplateBindings.Linq
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

using Falcon.Data;
using Falcon.Data.EntityClasses;
using Falcon.Data.FactoryClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.RelationClasses;

namespace Falcon.Data.Linq
{
	/// <summary>Meta-data class for the construction of Linq queries which are to be executed using LLBLGen Pro code.</summary>
	public partial class LinqMetaData: ILinqMetaData
	{
		#region Class Member Declarations
		private IDataAccessAdapter _adapterToUse;
		private FunctionMappingStore _customFunctionMappings;
		private Context _contextToUse;
		#endregion
		
		/// <summary>CTor. Using this ctor will leave the IDataAccessAdapter object to use empty. To be able to execute the query, an IDataAccessAdapter instance
		/// is required, and has to be set on the LLBLGenProProvider2 object in the query to execute. </summary>
		public LinqMetaData() : this(null, null)
		{
		}
		
		/// <summary>CTor which accepts an IDataAccessAdapter implementing object, which will be used to execute queries created with this metadata class.</summary>
		/// <param name="adapterToUse">the IDataAccessAdapter to use in queries created with this meta data</param>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public LinqMetaData(IDataAccessAdapter adapterToUse) : this (adapterToUse, null)
		{
		}

		/// <summary>CTor which accepts an IDataAccessAdapter implementing object, which will be used to execute queries created with this metadata class.</summary>
		/// <param name="adapterToUse">the IDataAccessAdapter to use in queries created with this meta data</param>
		/// <param name="customFunctionMappings">The custom function mappings to use. These take higher precedence than the ones in the DQE to use.</param>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public LinqMetaData(IDataAccessAdapter adapterToUse, FunctionMappingStore customFunctionMappings)
		{
			_adapterToUse = adapterToUse;
			_customFunctionMappings = customFunctionMappings;
		}
	
		/// <summary>returns the datasource to use in a Linq query for the entity type specified</summary>
		/// <param name="typeOfEntity">the type of the entity to get the datasource for</param>
		/// <returns>the requested datasource</returns>
		public IDataSource GetQueryableForEntity(int typeOfEntity)
		{
			IDataSource toReturn = null;
			switch((Falcon.Data.EntityType)typeOfEntity)
			{
				case Falcon.Data.EntityType.AccessControlObjectEntity:
					toReturn = this.AccessControlObject;
					break;
				case Falcon.Data.EntityType.AccessControlObjectUrlEntity:
					toReturn = this.AccessControlObjectUrl;
					break;
				case Falcon.Data.EntityType.AccessObjectScopeOptionEntity:
					toReturn = this.AccessObjectScopeOption;
					break;
				case Falcon.Data.EntityType.AccountEntity:
					toReturn = this.Account;
					break;
				case Falcon.Data.EntityType.AccountAdditionalFieldsEntity:
					toReturn = this.AccountAdditionalFields;
					break;
				case Falcon.Data.EntityType.AccountCallCenterOrganizationEntity:
					toReturn = this.AccountCallCenterOrganization;
					break;
				case Falcon.Data.EntityType.AccountCallQueueSettingEntity:
					toReturn = this.AccountCallQueueSetting;
					break;
				case Falcon.Data.EntityType.AccountCheckoutPhoneNumberEntity:
					toReturn = this.AccountCheckoutPhoneNumber;
					break;
				case Falcon.Data.EntityType.AccountCoordinatorProfileEntity:
					toReturn = this.AccountCoordinatorProfile;
					break;
				case Falcon.Data.EntityType.AccountCustomerResultTestDependencyEntity:
					toReturn = this.AccountCustomerResultTestDependency;
					break;
				case Falcon.Data.EntityType.AccountEventZipEntity:
					toReturn = this.AccountEventZip;
					break;
				case Falcon.Data.EntityType.AccountEventZipSubstituteEntity:
					toReturn = this.AccountEventZipSubstitute;
					break;
				case Falcon.Data.EntityType.AccountHealthPlanResultTestDependencyEntity:
					toReturn = this.AccountHealthPlanResultTestDependency;
					break;
				case Falcon.Data.EntityType.AccountHraChatQuestionnaireEntity:
					toReturn = this.AccountHraChatQuestionnaire;
					break;
				case Falcon.Data.EntityType.AccountNotReviewableTestEntity:
					toReturn = this.AccountNotReviewableTest;
					break;
				case Falcon.Data.EntityType.AccountPackageEntity:
					toReturn = this.AccountPackage;
					break;
				case Falcon.Data.EntityType.AccountPcpResultTestDependencyEntity:
					toReturn = this.AccountPcpResultTestDependency;
					break;
				case Falcon.Data.EntityType.AccountTestEntity:
					toReturn = this.AccountTest;
					break;
				case Falcon.Data.EntityType.AccountTestHcpcsCodeEntity:
					toReturn = this.AccountTestHcpcsCode;
					break;
				case Falcon.Data.EntityType.ActivityEntity:
					toReturn = this.Activity;
					break;
				case Falcon.Data.EntityType.ActivityTypeEntity:
					toReturn = this.ActivityType;
					break;
				case Falcon.Data.EntityType.AdditionalFieldsEntity:
					toReturn = this.AdditionalFields;
					break;
				case Falcon.Data.EntityType.AddressEntity:
					toReturn = this.Address;
					break;
				case Falcon.Data.EntityType.AdvocateManagerTeamEntity:
					toReturn = this.AdvocateManagerTeam;
					break;
				case Falcon.Data.EntityType.AfadvertiserEntity:
					toReturn = this.Afadvertiser;
					break;
				case Falcon.Data.EntityType.AfAdvertisingCommissionEntity:
					toReturn = this.AfAdvertisingCommission;
					break;
				case Falcon.Data.EntityType.AfaffiliateCampaignEntity:
					toReturn = this.AfaffiliateCampaign;
					break;
				case Falcon.Data.EntityType.AfaffiliateCampaignMarketingMaterialEntity:
					toReturn = this.AfaffiliateCampaignMarketingMaterial;
					break;
				case Falcon.Data.EntityType.AfcampaignEntity:
					toReturn = this.Afcampaign;
					break;
				case Falcon.Data.EntityType.AfcampaignCreativeEntity:
					toReturn = this.AfcampaignCreative;
					break;
				case Falcon.Data.EntityType.AfcampaignSubAdvocateEntity:
					toReturn = this.AfcampaignSubAdvocate;
					break;
				case Falcon.Data.EntityType.AfcampaignTemplateEntity:
					toReturn = this.AfcampaignTemplate;
					break;
				case Falcon.Data.EntityType.AfchannelEntity:
					toReturn = this.Afchannel;
					break;
				case Falcon.Data.EntityType.AfcommisionEntity:
					toReturn = this.Afcommision;
					break;
				case Falcon.Data.EntityType.AfDailyLogImpressionClickEntity:
					toReturn = this.AfDailyLogImpressionClick;
					break;
				case Falcon.Data.EntityType.AffiliateProfileEntity:
					toReturn = this.AffiliateProfile;
					break;
				case Falcon.Data.EntityType.AfimpressionEntity:
					toReturn = this.Afimpression;
					break;
				case Falcon.Data.EntityType.AfimpressionLogEntity:
					toReturn = this.AfimpressionLog;
					break;
				case Falcon.Data.EntityType.AfincomingPhoneEntity:
					toReturn = this.AfincomingPhone;
					break;
				case Falcon.Data.EntityType.AflAffiliatePaymentMethodEntity:
					toReturn = this.AflAffiliatePaymentMethod;
					break;
				case Falcon.Data.EntityType.AfmanualCheckEntity:
					toReturn = this.AfmanualCheck;
					break;
				case Falcon.Data.EntityType.AfmarketingMaterialEntity:
					toReturn = this.AfmarketingMaterial;
					break;
				case Falcon.Data.EntityType.AfMarketingMaterialBannerSizeEntity:
					toReturn = this.AfMarketingMaterialBannerSize;
					break;
				case Falcon.Data.EntityType.AfmarketingMaterialGroupEntity:
					toReturn = this.AfmarketingMaterialGroup;
					break;
				case Falcon.Data.EntityType.AfmarketingMaterialTypeEntity:
					toReturn = this.AfmarketingMaterialType;
					break;
				case Falcon.Data.EntityType.AfpaymentEntity:
					toReturn = this.Afpayment;
					break;
				case Falcon.Data.EntityType.AfpaypalEntity:
					toReturn = this.Afpaypal;
					break;
				case Falcon.Data.EntityType.AfppcclickLogEntity:
					toReturn = this.AfppcclickLog;
					break;
				case Falcon.Data.EntityType.AfredirectUrlEntity:
					toReturn = this.AfredirectUrl;
					break;
				case Falcon.Data.EntityType.ApplicationAuthenticationEntity:
					toReturn = this.ApplicationAuthentication;
					break;
				case Falcon.Data.EntityType.BarrierEntity:
					toReturn = this.Barrier;
					break;
				case Falcon.Data.EntityType.BillingAccountEntity:
					toReturn = this.BillingAccount;
					break;
				case Falcon.Data.EntityType.BillingAccountTestEntity:
					toReturn = this.BillingAccountTest;
					break;
				case Falcon.Data.EntityType.BlockedDaysEntity:
					toReturn = this.BlockedDays;
					break;
				case Falcon.Data.EntityType.BlockedDaysFranchiseeEntity:
					toReturn = this.BlockedDaysFranchisee;
					break;
				case Falcon.Data.EntityType.CallCenterAgentTeamEntity:
					toReturn = this.CallCenterAgentTeam;
					break;
				case Falcon.Data.EntityType.CallCenterAgentTeamLogEntity:
					toReturn = this.CallCenterAgentTeamLog;
					break;
				case Falcon.Data.EntityType.CallCenterNotesEntity:
					toReturn = this.CallCenterNotes;
					break;
				case Falcon.Data.EntityType.CallCenterRepProfileEntity:
					toReturn = this.CallCenterRepProfile;
					break;
				case Falcon.Data.EntityType.CallCenterTeamEntity:
					toReturn = this.CallCenterTeam;
					break;
				case Falcon.Data.EntityType.CallDetailsEntity:
					toReturn = this.CallDetails;
					break;
				case Falcon.Data.EntityType.CallQueueEntity:
					toReturn = this.CallQueue;
					break;
				case Falcon.Data.EntityType.CallQueueAssignmentEntity:
					toReturn = this.CallQueueAssignment;
					break;
				case Falcon.Data.EntityType.CallQueueCriteriaEntity:
					toReturn = this.CallQueueCriteria;
					break;
				case Falcon.Data.EntityType.CallQueueCustomerEntity:
					toReturn = this.CallQueueCustomer;
					break;
				case Falcon.Data.EntityType.CallQueueCustomerCallEntity:
					toReturn = this.CallQueueCustomerCall;
					break;
				case Falcon.Data.EntityType.CallQueueCustomerLockEntity:
					toReturn = this.CallQueueCustomerLock;
					break;
				case Falcon.Data.EntityType.CallQueueCustomTagEntity:
					toReturn = this.CallQueueCustomTag;
					break;
				case Falcon.Data.EntityType.CallRoundCallQueueEntity:
					toReturn = this.CallRoundCallQueue;
					break;
				case Falcon.Data.EntityType.CallRoundCallQueueCriteriaAssignmentEntity:
					toReturn = this.CallRoundCallQueueCriteriaAssignment;
					break;
				case Falcon.Data.EntityType.CallsEntity:
					toReturn = this.Calls;
					break;
				case Falcon.Data.EntityType.CallUploadEntity:
					toReturn = this.CallUpload;
					break;
				case Falcon.Data.EntityType.CallUploadLogEntity:
					toReturn = this.CallUploadLog;
					break;
				case Falcon.Data.EntityType.CampaignEntity:
					toReturn = this.Campaign;
					break;
				case Falcon.Data.EntityType.CampaignActivityEntity:
					toReturn = this.CampaignActivity;
					break;
				case Falcon.Data.EntityType.CampaignActivityAssignmentEntity:
					toReturn = this.CampaignActivityAssignment;
					break;
				case Falcon.Data.EntityType.CampaignAssignmentEntity:
					toReturn = this.CampaignAssignment;
					break;
				case Falcon.Data.EntityType.CampaignTagEntity:
					toReturn = this.CampaignTag;
					break;
				case Falcon.Data.EntityType.CampaignTagMappingEntity:
					toReturn = this.CampaignTagMapping;
					break;
				case Falcon.Data.EntityType.CareCodingOutboundEntity:
					toReturn = this.CareCodingOutbound;
					break;
				case Falcon.Data.EntityType.CarrierEntity:
					toReturn = this.Carrier;
					break;
				case Falcon.Data.EntityType.CashPaymentEntity:
					toReturn = this.CashPayment;
					break;
				case Falcon.Data.EntityType.CategoriesEntity:
					toReturn = this.Categories;
					break;
				case Falcon.Data.EntityType.CdcontentGeneratorTrackingEntity:
					toReturn = this.CdcontentGeneratorTracking;
					break;
				case Falcon.Data.EntityType.ChaperoneAnswerEntity:
					toReturn = this.ChaperoneAnswer;
					break;
				case Falcon.Data.EntityType.ChaperoneQuestionEntity:
					toReturn = this.ChaperoneQuestion;
					break;
				case Falcon.Data.EntityType.ChaperoneSignatureEntity:
					toReturn = this.ChaperoneSignature;
					break;
				case Falcon.Data.EntityType.ChargeCardEntity:
					toReturn = this.ChargeCard;
					break;
				case Falcon.Data.EntityType.ChargeCardPaymentEntity:
					toReturn = this.ChargeCardPayment;
					break;
				case Falcon.Data.EntityType.ChaseCampaignEntity:
					toReturn = this.ChaseCampaign;
					break;
				case Falcon.Data.EntityType.ChaseCampaignTypeEntity:
					toReturn = this.ChaseCampaignType;
					break;
				case Falcon.Data.EntityType.ChaseChannelLevelEntity:
					toReturn = this.ChaseChannelLevel;
					break;
				case Falcon.Data.EntityType.ChaseGroupEntity:
					toReturn = this.ChaseGroup;
					break;
				case Falcon.Data.EntityType.ChaseOutboundEntity:
					toReturn = this.ChaseOutbound;
					break;
				case Falcon.Data.EntityType.ChaseProductEntity:
					toReturn = this.ChaseProduct;
					break;
				case Falcon.Data.EntityType.CheckEntity:
					toReturn = this.Check;
					break;
				case Falcon.Data.EntityType.CheckListAnswerEntity:
					toReturn = this.CheckListAnswer;
					break;
				case Falcon.Data.EntityType.CheckListGroupEntity:
					toReturn = this.CheckListGroup;
					break;
				case Falcon.Data.EntityType.ChecklistGroupQuestionEntity:
					toReturn = this.ChecklistGroupQuestion;
					break;
				case Falcon.Data.EntityType.CheckListQuestionEntity:
					toReturn = this.CheckListQuestion;
					break;
				case Falcon.Data.EntityType.CheckListTemplateEntity:
					toReturn = this.CheckListTemplate;
					break;
				case Falcon.Data.EntityType.CheckListTemplateQuestionEntity:
					toReturn = this.CheckListTemplateQuestion;
					break;
				case Falcon.Data.EntityType.CheckPaymentEntity:
					toReturn = this.CheckPayment;
					break;
				case Falcon.Data.EntityType.CityEntity:
					toReturn = this.City;
					break;
				case Falcon.Data.EntityType.ClaimEntity:
					toReturn = this.Claim;
					break;
				case Falcon.Data.EntityType.ClickConversionEntity:
					toReturn = this.ClickConversion;
					break;
				case Falcon.Data.EntityType.ClickKeywordEntity:
					toReturn = this.ClickKeyword;
					break;
				case Falcon.Data.EntityType.ClickLogEntity:
					toReturn = this.ClickLog;
					break;
				case Falcon.Data.EntityType.ClientEntity:
					toReturn = this.Client;
					break;
				case Falcon.Data.EntityType.ClinicalTestQualificationCriteriaEntity:
					toReturn = this.ClinicalTestQualificationCriteria;
					break;
				case Falcon.Data.EntityType.CommunicationModeEntity:
					toReturn = this.CommunicationMode;
					break;
				case Falcon.Data.EntityType.ContactCallEntity:
					toReturn = this.ContactCall;
					break;
				case Falcon.Data.EntityType.ContactCallStatusEntity:
					toReturn = this.ContactCallStatus;
					break;
				case Falcon.Data.EntityType.ContactFranchiseeAccessEntity:
					toReturn = this.ContactFranchiseeAccess;
					break;
				case Falcon.Data.EntityType.ContactMeetingEntity:
					toReturn = this.ContactMeeting;
					break;
				case Falcon.Data.EntityType.ContactNotesEntity:
					toReturn = this.ContactNotes;
					break;
				case Falcon.Data.EntityType.ContactsEntity:
					toReturn = this.Contacts;
					break;
				case Falcon.Data.EntityType.ContactTypeEntity:
					toReturn = this.ContactType;
					break;
				case Falcon.Data.EntityType.ContentEntity:
					toReturn = this.Content;
					break;
				case Falcon.Data.EntityType.ContractEntity:
					toReturn = this.Contract;
					break;
				case Falcon.Data.EntityType.CorporateShippingOptionEntity:
					toReturn = this.CorporateShippingOption;
					break;
				case Falcon.Data.EntityType.CorporateTagEntity:
					toReturn = this.CorporateTag;
					break;
				case Falcon.Data.EntityType.CorporateUploadEntity:
					toReturn = this.CorporateUpload;
					break;
				case Falcon.Data.EntityType.CountryEntity:
					toReturn = this.Country;
					break;
				case Falcon.Data.EntityType.CouponsEntity:
					toReturn = this.Coupons;
					break;
				case Falcon.Data.EntityType.CouponSignUpModeEntity:
					toReturn = this.CouponSignUpMode;
					break;
				case Falcon.Data.EntityType.CouponTypeEntity:
					toReturn = this.CouponType;
					break;
				case Falcon.Data.EntityType.CreditCardTypeEntity:
					toReturn = this.CreditCardType;
					break;
				case Falcon.Data.EntityType.CriteriaEntity:
					toReturn = this.Criteria;
					break;
				case Falcon.Data.EntityType.CriticalCustomerCommunicationRecordEntity:
					toReturn = this.CriticalCustomerCommunicationRecord;
					break;
				case Falcon.Data.EntityType.CriticalQuestionEntity:
					toReturn = this.CriticalQuestion;
					break;
				case Falcon.Data.EntityType.CurrentMedicationEntity:
					toReturn = this.CurrentMedication;
					break;
				case Falcon.Data.EntityType.CustomCampaignContentEntity:
					toReturn = this.CustomCampaignContent;
					break;
				case Falcon.Data.EntityType.CustomerAccountGlocomNumberEntity:
					toReturn = this.CustomerAccountGlocomNumber;
					break;
				case Falcon.Data.EntityType.CustomerActivityTypeUploadEntity:
					toReturn = this.CustomerActivityTypeUpload;
					break;
				case Falcon.Data.EntityType.CustomerBillingAccountEntity:
					toReturn = this.CustomerBillingAccount;
					break;
				case Falcon.Data.EntityType.CustomerCallAttemptsEntity:
					toReturn = this.CustomerCallAttempts;
					break;
				case Falcon.Data.EntityType.CustomerCallQueueCallAttemptEntity:
					toReturn = this.CustomerCallQueueCallAttempt;
					break;
				case Falcon.Data.EntityType.CustomerChaseCampaignEntity:
					toReturn = this.CustomerChaseCampaign;
					break;
				case Falcon.Data.EntityType.CustomerChaseChannelEntity:
					toReturn = this.CustomerChaseChannel;
					break;
				case Falcon.Data.EntityType.CustomerChaseProductEntity:
					toReturn = this.CustomerChaseProduct;
					break;
				case Falcon.Data.EntityType.CustomerClinicalQuestionAnswerEntity:
					toReturn = this.CustomerClinicalQuestionAnswer;
					break;
				case Falcon.Data.EntityType.CustomerEligibilityEntity:
					toReturn = this.CustomerEligibility;
					break;
				case Falcon.Data.EntityType.CustomerEventCriticalTestDataEntity:
					toReturn = this.CustomerEventCriticalTestData;
					break;
				case Falcon.Data.EntityType.CustomerEventPriorityInQueueDataEntity:
					toReturn = this.CustomerEventPriorityInQueueData;
					break;
				case Falcon.Data.EntityType.CustomerEventReadingEntity:
					toReturn = this.CustomerEventReading;
					break;
				case Falcon.Data.EntityType.CustomerEventScreeningTestsEntity:
					toReturn = this.CustomerEventScreeningTests;
					break;
				case Falcon.Data.EntityType.CustomerEventTestFindingEntity:
					toReturn = this.CustomerEventTestFinding;
					break;
				case Falcon.Data.EntityType.CustomerEventTestIncidentalFindingEntity:
					toReturn = this.CustomerEventTestIncidentalFinding;
					break;
				case Falcon.Data.EntityType.CustomerEventTestIncidentalFindingDetailEntity:
					toReturn = this.CustomerEventTestIncidentalFindingDetail;
					break;
				case Falcon.Data.EntityType.CustomerEventTestPhysicianEvaluationEntity:
					toReturn = this.CustomerEventTestPhysicianEvaluation;
					break;
				case Falcon.Data.EntityType.CustomerEventTestPhysicianNoteEntity:
					toReturn = this.CustomerEventTestPhysicianNote;
					break;
				case Falcon.Data.EntityType.CustomerEventTestStandardFindingEntity:
					toReturn = this.CustomerEventTestStandardFinding;
					break;
				case Falcon.Data.EntityType.CustomerEventTestStateEntity:
					toReturn = this.CustomerEventTestState;
					break;
				case Falcon.Data.EntityType.CustomerEventUnableScreenReasonEntity:
					toReturn = this.CustomerEventUnableScreenReason;
					break;
				case Falcon.Data.EntityType.CustomerHealthInfoEntity:
					toReturn = this.CustomerHealthInfo;
					break;
				case Falcon.Data.EntityType.CustomerHealthInfoArchiveEntity:
					toReturn = this.CustomerHealthInfoArchive;
					break;
				case Falcon.Data.EntityType.CustomerHealthQuestionGroupEntity:
					toReturn = this.CustomerHealthQuestionGroup;
					break;
				case Falcon.Data.EntityType.CustomerHealthQuestionsEntity:
					toReturn = this.CustomerHealthQuestions;
					break;
				case Falcon.Data.EntityType.CustomerIcdCodeEntity:
					toReturn = this.CustomerIcdCode;
					break;
				case Falcon.Data.EntityType.CustomerLockForCallEntity:
					toReturn = this.CustomerLockForCall;
					break;
				case Falcon.Data.EntityType.CustomerMedicareQuestionAnswerEntity:
					toReturn = this.CustomerMedicareQuestionAnswer;
					break;
				case Falcon.Data.EntityType.CustomerOrderHistoryEntity:
					toReturn = this.CustomerOrderHistory;
					break;
				case Falcon.Data.EntityType.CustomerPhoneNumberUpdateUploadEntity:
					toReturn = this.CustomerPhoneNumberUpdateUpload;
					break;
				case Falcon.Data.EntityType.CustomerPhoneNumberUpdateUploadLogEntity:
					toReturn = this.CustomerPhoneNumberUpdateUploadLog;
					break;
				case Falcon.Data.EntityType.CustomerPredictedZipEntity:
					toReturn = this.CustomerPredictedZip;
					break;
				case Falcon.Data.EntityType.CustomerPrimaryCarePhysicianEntity:
					toReturn = this.CustomerPrimaryCarePhysician;
					break;
				case Falcon.Data.EntityType.CustomerProfileEntity:
					toReturn = this.CustomerProfile;
					break;
				case Falcon.Data.EntityType.CustomerProfileHistoryEntity:
					toReturn = this.CustomerProfileHistory;
					break;
				case Falcon.Data.EntityType.CustomerRegistrationNotesEntity:
					toReturn = this.CustomerRegistrationNotes;
					break;
				case Falcon.Data.EntityType.CustomerResultPostedEntity:
					toReturn = this.CustomerResultPosted;
					break;
				case Falcon.Data.EntityType.CustomerResultScreeningCommunicationEntity:
					toReturn = this.CustomerResultScreeningCommunication;
					break;
				case Falcon.Data.EntityType.CustomerSkipReviewEntity:
					toReturn = this.CustomerSkipReview;
					break;
				case Falcon.Data.EntityType.CustomerSurveyEntity:
					toReturn = this.CustomerSurvey;
					break;
				case Falcon.Data.EntityType.CustomerSurveyQuestionEntity:
					toReturn = this.CustomerSurveyQuestion;
					break;
				case Falcon.Data.EntityType.CustomerSurveyQuestionAnswerEntity:
					toReturn = this.CustomerSurveyQuestionAnswer;
					break;
				case Falcon.Data.EntityType.CustomerTagEntity:
					toReturn = this.CustomerTag;
					break;
				case Falcon.Data.EntityType.CustomerTargetedEntity:
					toReturn = this.CustomerTargeted;
					break;
				case Falcon.Data.EntityType.CustomerTraleEntity:
					toReturn = this.CustomerTrale;
					break;
				case Falcon.Data.EntityType.CustomerUnsubscribedSmsNotificationEntity:
					toReturn = this.CustomerUnsubscribedSmsNotification;
					break;
				case Falcon.Data.EntityType.CustomerWarmTransferEntity:
					toReturn = this.CustomerWarmTransfer;
					break;
				case Falcon.Data.EntityType.CustomEventNotificationEntity:
					toReturn = this.CustomEventNotification;
					break;
				case Falcon.Data.EntityType.DemandDraftPaymentDetailsEntity:
					toReturn = this.DemandDraftPaymentDetails;
					break;
				case Falcon.Data.EntityType.DependentDisqualifiedTestEntity:
					toReturn = this.DependentDisqualifiedTest;
					break;
				case Falcon.Data.EntityType.DiabeticRetinopathyParserlogEntity:
					toReturn = this.DiabeticRetinopathyParserlog;
					break;
				case Falcon.Data.EntityType.DigitalAssetAccessLogEntity:
					toReturn = this.DigitalAssetAccessLog;
					break;
				case Falcon.Data.EntityType.DirectMailEntity:
					toReturn = this.DirectMail;
					break;
				case Falcon.Data.EntityType.DirectMailTypeEntity:
					toReturn = this.DirectMailType;
					break;
				case Falcon.Data.EntityType.DisqualifiedTestEntity:
					toReturn = this.DisqualifiedTest;
					break;
				case Falcon.Data.EntityType.EcheckPaymentEntity:
					toReturn = this.EcheckPayment;
					break;
				case Falcon.Data.EntityType.EligibilityEntity:
					toReturn = this.Eligibility;
					break;
				case Falcon.Data.EntityType.EligibilityUploadEntity:
					toReturn = this.EligibilityUpload;
					break;
				case Falcon.Data.EntityType.EmailTemplateEntity:
					toReturn = this.EmailTemplate;
					break;
				case Falcon.Data.EntityType.EmailTemplateMacroEntity:
					toReturn = this.EmailTemplateMacro;
					break;
				case Falcon.Data.EntityType.EncounterEntity:
					toReturn = this.Encounter;
					break;
				case Falcon.Data.EntityType.EventAccountEntity:
					toReturn = this.EventAccount;
					break;
				case Falcon.Data.EntityType.EventAccountTestHcpcsCodeEntity:
					toReturn = this.EventAccountTestHcpcsCode;
					break;
				case Falcon.Data.EntityType.EventActivityTemplateEntity:
					toReturn = this.EventActivityTemplate;
					break;
				case Falcon.Data.EntityType.EventActivityTemplateCallEntity:
					toReturn = this.EventActivityTemplateCall;
					break;
				case Falcon.Data.EntityType.EventActivityTemplateEmailEntity:
					toReturn = this.EventActivityTemplateEmail;
					break;
				case Falcon.Data.EntityType.EventActivityTemplateHostEntity:
					toReturn = this.EventActivityTemplateHost;
					break;
				case Falcon.Data.EntityType.EventActivityTemplateMeetingEntity:
					toReturn = this.EventActivityTemplateMeeting;
					break;
				case Falcon.Data.EntityType.EventActivityTemplateTaskEntity:
					toReturn = this.EventActivityTemplateTask;
					break;
				case Falcon.Data.EntityType.EventAffiliateDetailsEntity:
					toReturn = this.EventAffiliateDetails;
					break;
				case Falcon.Data.EntityType.EventAppointmentEntity:
					toReturn = this.EventAppointment;
					break;
				case Falcon.Data.EntityType.EventAppointmentCancellationLogEntity:
					toReturn = this.EventAppointmentCancellationLog;
					break;
				case Falcon.Data.EntityType.EventAppointmentChangeLogEntity:
					toReturn = this.EventAppointmentChangeLog;
					break;
				case Falcon.Data.EntityType.EventCallDetailsEntity:
					toReturn = this.EventCallDetails;
					break;
				case Falcon.Data.EntityType.EventCampaignDetailsEntity:
					toReturn = this.EventCampaignDetails;
					break;
				case Falcon.Data.EntityType.EventChecklistTemplateEntity:
					toReturn = this.EventChecklistTemplate;
					break;
				case Falcon.Data.EntityType.EventCouponsEntity:
					toReturn = this.EventCoupons;
					break;
				case Falcon.Data.EntityType.EventCustomerBarrierEntity:
					toReturn = this.EventCustomerBarrier;
					break;
				case Falcon.Data.EntityType.EventCustomerBasicBioMetricEntity:
					toReturn = this.EventCustomerBasicBioMetric;
					break;
				case Falcon.Data.EntityType.EventCustomerCriticalQuestionEntity:
					toReturn = this.EventCustomerCriticalQuestion;
					break;
				case Falcon.Data.EntityType.EventCustomerCurrentMedicationEntity:
					toReturn = this.EventCustomerCurrentMedication;
					break;
				case Falcon.Data.EntityType.EventCustomerCustomNotificationEntity:
					toReturn = this.EventCustomerCustomNotification;
					break;
				case Falcon.Data.EntityType.EventCustomerDiagnosisEntity:
					toReturn = this.EventCustomerDiagnosis;
					break;
				case Falcon.Data.EntityType.EventCustomerEligibilityEntity:
					toReturn = this.EventCustomerEligibility;
					break;
				case Falcon.Data.EntityType.EventCustomerEncounterEntity:
					toReturn = this.EventCustomerEncounter;
					break;
				case Falcon.Data.EntityType.EventCustomerEvaluationLockEntity:
					toReturn = this.EventCustomerEvaluationLock;
					break;
				case Falcon.Data.EntityType.EventCustomerGiftCardEntity:
					toReturn = this.EventCustomerGiftCard;
					break;
				case Falcon.Data.EntityType.EventCustomerIcdCodesEntity:
					toReturn = this.EventCustomerIcdCodes;
					break;
				case Falcon.Data.EntityType.EventCustomerNotificationEntity:
					toReturn = this.EventCustomerNotification;
					break;
				case Falcon.Data.EntityType.EventCustomerOrderDetailEntity:
					toReturn = this.EventCustomerOrderDetail;
					break;
				case Falcon.Data.EntityType.EventCustomerPaymentEntity:
					toReturn = this.EventCustomerPayment;
					break;
				case Falcon.Data.EntityType.EventCustomerPdfgenerationErrorLogEntity:
					toReturn = this.EventCustomerPdfgenerationErrorLog;
					break;
				case Falcon.Data.EntityType.EventCustomerPreApprovedPackageTestEntity:
					toReturn = this.EventCustomerPreApprovedPackageTest;
					break;
				case Falcon.Data.EntityType.EventCustomerPreApprovedTestEntity:
					toReturn = this.EventCustomerPreApprovedTest;
					break;
				case Falcon.Data.EntityType.EventCustomerPrimaryCarePhysicianEntity:
					toReturn = this.EventCustomerPrimaryCarePhysician;
					break;
				case Falcon.Data.EntityType.EventCustomerQuestionAnswerEntity:
					toReturn = this.EventCustomerQuestionAnswer;
					break;
				case Falcon.Data.EntityType.EventCustomerRequiredTestEntity:
					toReturn = this.EventCustomerRequiredTest;
					break;
				case Falcon.Data.EntityType.EventCustomerResultEntity:
					toReturn = this.EventCustomerResult;
					break;
				case Falcon.Data.EntityType.EventCustomerResultBloodLabEntity:
					toReturn = this.EventCustomerResultBloodLab;
					break;
				case Falcon.Data.EntityType.EventCustomerResultBloodLabParserEntity:
					toReturn = this.EventCustomerResultBloodLabParser;
					break;
				case Falcon.Data.EntityType.EventCustomerResultHistoryEntity:
					toReturn = this.EventCustomerResultHistory;
					break;
				case Falcon.Data.EntityType.EventCustomerResultTraleEntity:
					toReturn = this.EventCustomerResultTrale;
					break;
				case Falcon.Data.EntityType.EventCustomerRetestEntity:
					toReturn = this.EventCustomerRetest;
					break;
				case Falcon.Data.EntityType.EventCustomersEntity:
					toReturn = this.EventCustomers;
					break;
				case Falcon.Data.EntityType.EventCustomerTestNotPerformedNotificationEntity:
					toReturn = this.EventCustomerTestNotPerformedNotification;
					break;
				case Falcon.Data.EntityType.EventFluConsentTemplateEntity:
					toReturn = this.EventFluConsentTemplate;
					break;
				case Falcon.Data.EntityType.EventHospitalFacilityEntity:
					toReturn = this.EventHospitalFacility;
					break;
				case Falcon.Data.EntityType.EventHospitalPartnerEntity:
					toReturn = this.EventHospitalPartner;
					break;
				case Falcon.Data.EntityType.EventHostPromotionsEntity:
					toReturn = this.EventHostPromotions;
					break;
				case Falcon.Data.EntityType.EventMarketingOffersEntity:
					toReturn = this.EventMarketingOffers;
					break;
				case Falcon.Data.EntityType.EventMeetingDetailsEntity:
					toReturn = this.EventMeetingDetails;
					break;
				case Falcon.Data.EntityType.EventNoteEntity:
					toReturn = this.EventNote;
					break;
				case Falcon.Data.EntityType.EventNotesLogEntity:
					toReturn = this.EventNotesLog;
					break;
				case Falcon.Data.EntityType.EventNotificationEntity:
					toReturn = this.EventNotification;
					break;
				case Falcon.Data.EntityType.EventPackageDetailsEntity:
					toReturn = this.EventPackageDetails;
					break;
				case Falcon.Data.EntityType.EventPackageOrderItemEntity:
					toReturn = this.EventPackageOrderItem;
					break;
				case Falcon.Data.EntityType.EventPackageTestEntity:
					toReturn = this.EventPackageTest;
					break;
				case Falcon.Data.EntityType.EventPaymentDetailsEntity:
					toReturn = this.EventPaymentDetails;
					break;
				case Falcon.Data.EntityType.EventPerformanceMailStatusEntity:
					toReturn = this.EventPerformanceMailStatus;
					break;
				case Falcon.Data.EntityType.EventPhysicianTestEntity:
					toReturn = this.EventPhysicianTest;
					break;
				case Falcon.Data.EntityType.EventPodEntity:
					toReturn = this.EventPod;
					break;
				case Falcon.Data.EntityType.EventPodRoomEntity:
					toReturn = this.EventPodRoom;
					break;
				case Falcon.Data.EntityType.EventPodRoomTestEntity:
					toReturn = this.EventPodRoomTest;
					break;
				case Falcon.Data.EntityType.EventProductExclusionEntity:
					toReturn = this.EventProductExclusion;
					break;
				case Falcon.Data.EntityType.EventProductTypeEntity:
					toReturn = this.EventProductType;
					break;
				case Falcon.Data.EntityType.EventPublicationEntity:
					toReturn = this.EventPublication;
					break;
				case Falcon.Data.EntityType.EventsEntity:
					toReturn = this.Events;
					break;
				case Falcon.Data.EntityType.EventScheduleTemplateEntity:
					toReturn = this.EventScheduleTemplate;
					break;
				case Falcon.Data.EntityType.EventSchedulingSlotEntity:
					toReturn = this.EventSchedulingSlot;
					break;
				case Falcon.Data.EntityType.EventSlotAppointmentEntity:
					toReturn = this.EventSlotAppointment;
					break;
				case Falcon.Data.EntityType.EventStaffAssignmentEntity:
					toReturn = this.EventStaffAssignment;
					break;
				case Falcon.Data.EntityType.EventSurveyTemplateEntity:
					toReturn = this.EventSurveyTemplate;
					break;
				case Falcon.Data.EntityType.EventTaskDetailsEntity:
					toReturn = this.EventTaskDetails;
					break;
				case Falcon.Data.EntityType.EventTestEntity:
					toReturn = this.EventTest;
					break;
				case Falcon.Data.EntityType.EventTestOrderItemEntity:
					toReturn = this.EventTestOrderItem;
					break;
				case Falcon.Data.EntityType.EventTypeEntity:
					toReturn = this.EventType;
					break;
				case Falcon.Data.EntityType.EventZipEntity:
					toReturn = this.EventZip;
					break;
				case Falcon.Data.EntityType.EventZipProductTypeEntity:
					toReturn = this.EventZipProductType;
					break;
				case Falcon.Data.EntityType.EventZipProductTypeSubstituteEntity:
					toReturn = this.EventZipProductTypeSubstitute;
					break;
				case Falcon.Data.EntityType.ExitInterviewAnswerEntity:
					toReturn = this.ExitInterviewAnswer;
					break;
				case Falcon.Data.EntityType.ExitInterviewQuestionEntity:
					toReturn = this.ExitInterviewQuestion;
					break;
				case Falcon.Data.EntityType.ExitInterviewSignatureEntity:
					toReturn = this.ExitInterviewSignature;
					break;
				case Falcon.Data.EntityType.ExportableReportsEntity:
					toReturn = this.ExportableReports;
					break;
				case Falcon.Data.EntityType.ExportableReportsQueueEntity:
					toReturn = this.ExportableReportsQueue;
					break;
				case Falcon.Data.EntityType.FileEntity:
					toReturn = this.File;
					break;
				case Falcon.Data.EntityType.FillEventCallQueueEntity:
					toReturn = this.FillEventCallQueue;
					break;
				case Falcon.Data.EntityType.FillEventCallQueueCriteriaAssignmentEntity:
					toReturn = this.FillEventCallQueueCriteriaAssignment;
					break;
				case Falcon.Data.EntityType.FluConsentAnswerEntity:
					toReturn = this.FluConsentAnswer;
					break;
				case Falcon.Data.EntityType.FluConsentQuestionEntity:
					toReturn = this.FluConsentQuestion;
					break;
				case Falcon.Data.EntityType.FluConsentSignatureEntity:
					toReturn = this.FluConsentSignature;
					break;
				case Falcon.Data.EntityType.FluConsentTemplateEntity:
					toReturn = this.FluConsentTemplate;
					break;
				case Falcon.Data.EntityType.FluConsentTemplateQuestionEntity:
					toReturn = this.FluConsentTemplateQuestion;
					break;
				case Falcon.Data.EntityType.FraminghamCalculationSourceEntity:
					toReturn = this.FraminghamCalculationSource;
					break;
				case Falcon.Data.EntityType.FraminghamScoreRangeEntity:
					toReturn = this.FraminghamScoreRange;
					break;
				case Falcon.Data.EntityType.FranchiseeApplicationEntity:
					toReturn = this.FranchiseeApplication;
					break;
				case Falcon.Data.EntityType.FranchiseeTerritoryEntity:
					toReturn = this.FranchiseeTerritory;
					break;
				case Falcon.Data.EntityType.FranchiseeWiringInstructionsEntity:
					toReturn = this.FranchiseeWiringInstructions;
					break;
				case Falcon.Data.EntityType.GcNotGivenReasonEntity:
					toReturn = this.GcNotGivenReason;
					break;
				case Falcon.Data.EntityType.GiftCertificateEntity:
					toReturn = this.GiftCertificate;
					break;
				case Falcon.Data.EntityType.GiftCertificateOrderItemEntity:
					toReturn = this.GiftCertificateOrderItem;
					break;
				case Falcon.Data.EntityType.GiftCertificatePaymentEntity:
					toReturn = this.GiftCertificatePayment;
					break;
				case Falcon.Data.EntityType.GiftCertificateTypeEntity:
					toReturn = this.GiftCertificateType;
					break;
				case Falcon.Data.EntityType.GlobalConfigurationEntity:
					toReturn = this.GlobalConfiguration;
					break;
				case Falcon.Data.EntityType.GuardianDetailsEntity:
					toReturn = this.GuardianDetails;
					break;
				case Falcon.Data.EntityType.HafTemplateEntity:
					toReturn = this.HafTemplate;
					break;
				case Falcon.Data.EntityType.HafTemplateQuestionEntity:
					toReturn = this.HafTemplateQuestion;
					break;
				case Falcon.Data.EntityType.HcpcsCodeEntity:
					toReturn = this.HcpcsCode;
					break;
				case Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity:
					toReturn = this.HealthPlanCallQueueCriteria;
					break;
				case Falcon.Data.EntityType.HealthPlanCallQueueCriteriaAssignmentEntity:
					toReturn = this.HealthPlanCallQueueCriteriaAssignment;
					break;
				case Falcon.Data.EntityType.HealthPlanCriteriaAssignmentEntity:
					toReturn = this.HealthPlanCriteriaAssignment;
					break;
				case Falcon.Data.EntityType.HealthPlanCriteriaAssignmentUploadEntity:
					toReturn = this.HealthPlanCriteriaAssignmentUpload;
					break;
				case Falcon.Data.EntityType.HealthPlanCriteriaDirectMailEntity:
					toReturn = this.HealthPlanCriteriaDirectMail;
					break;
				case Falcon.Data.EntityType.HealthPlanCriteriaTeamAssignmentEntity:
					toReturn = this.HealthPlanCriteriaTeamAssignment;
					break;
				case Falcon.Data.EntityType.HealthPlanEventZipEntity:
					toReturn = this.HealthPlanEventZip;
					break;
				case Falcon.Data.EntityType.HealthPlanFillEventCallQueueEntity:
					toReturn = this.HealthPlanFillEventCallQueue;
					break;
				case Falcon.Data.EntityType.HealthPlanRevenueEntity:
					toReturn = this.HealthPlanRevenue;
					break;
				case Falcon.Data.EntityType.HealthPlanRevenueItemEntity:
					toReturn = this.HealthPlanRevenueItem;
					break;
				case Falcon.Data.EntityType.HealthQuestionDependencyRuleEntity:
					toReturn = this.HealthQuestionDependencyRule;
					break;
				case Falcon.Data.EntityType.HospitalFacilityEntity:
					toReturn = this.HospitalFacility;
					break;
				case Falcon.Data.EntityType.HospitalFacilityCampaignEntity:
					toReturn = this.HospitalFacilityCampaign;
					break;
				case Falcon.Data.EntityType.HospitalPartnerEntity:
					toReturn = this.HospitalPartner;
					break;
				case Falcon.Data.EntityType.HospitalPartnerCustomerEntity:
					toReturn = this.HospitalPartnerCustomer;
					break;
				case Falcon.Data.EntityType.HospitalPartnerEventNotesEntity:
					toReturn = this.HospitalPartnerEventNotes;
					break;
				case Falcon.Data.EntityType.HospitalPartnerHospitalFacilityEntity:
					toReturn = this.HospitalPartnerHospitalFacility;
					break;
				case Falcon.Data.EntityType.HospitalPartnerPackageEntity:
					toReturn = this.HospitalPartnerPackage;
					break;
				case Falcon.Data.EntityType.HospitalPartnerShippingOptionEntity:
					toReturn = this.HospitalPartnerShippingOption;
					break;
				case Falcon.Data.EntityType.HospitalPartnerTerritoryEntity:
					toReturn = this.HospitalPartnerTerritory;
					break;
				case Falcon.Data.EntityType.HostAdvocateDetailEntity:
					toReturn = this.HostAdvocateDetail;
					break;
				case Falcon.Data.EntityType.HostEventDetailsEntity:
					toReturn = this.HostEventDetails;
					break;
				case Falcon.Data.EntityType.HostFacilityRankingEntity:
					toReturn = this.HostFacilityRanking;
					break;
				case Falcon.Data.EntityType.HostImageEntity:
					toReturn = this.HostImage;
					break;
				case Falcon.Data.EntityType.HostNotesEntity:
					toReturn = this.HostNotes;
					break;
				case Falcon.Data.EntityType.HostPaymentEntity:
					toReturn = this.HostPayment;
					break;
				case Falcon.Data.EntityType.HostPaymentTransactionEntity:
					toReturn = this.HostPaymentTransaction;
					break;
				case Falcon.Data.EntityType.IcdCodesEntity:
					toReturn = this.IcdCodes;
					break;
				case Falcon.Data.EntityType.IflocationMasterEntity:
					toReturn = this.IflocationMaster;
					break;
				case Falcon.Data.EntityType.IncidentalFindingIncidentalFindingReadingGroupEntity:
					toReturn = this.IncidentalFindingIncidentalFindingReadingGroup;
					break;
				case Falcon.Data.EntityType.IncidentalFindingReadingGroupEntity:
					toReturn = this.IncidentalFindingReadingGroup;
					break;
				case Falcon.Data.EntityType.IncidentalFindingReadingGroupItemEntity:
					toReturn = this.IncidentalFindingReadingGroupItem;
					break;
				case Falcon.Data.EntityType.IncidentalFindingsEntity:
					toReturn = this.IncidentalFindings;
					break;
				case Falcon.Data.EntityType.IncomingPhoneNumberResolverRuleEntity:
					toReturn = this.IncomingPhoneNumberResolverRule;
					break;
				case Falcon.Data.EntityType.InsuranceCompanyEntity:
					toReturn = this.InsuranceCompany;
					break;
				case Falcon.Data.EntityType.InsurancePaymentEntity:
					toReturn = this.InsurancePayment;
					break;
				case Falcon.Data.EntityType.InsuranceServiceTypeEntity:
					toReturn = this.InsuranceServiceType;
					break;
				case Falcon.Data.EntityType.InventoryItemEntity:
					toReturn = this.InventoryItem;
					break;
				case Falcon.Data.EntityType.InventoryItemTestEntity:
					toReturn = this.InventoryItemTest;
					break;
				case Falcon.Data.EntityType.ItemEntity:
					toReturn = this.Item;
					break;
				case Falcon.Data.EntityType.ItemTypeEntity:
					toReturn = this.ItemType;
					break;
				case Falcon.Data.EntityType.KynLabValuesEntity:
					toReturn = this.KynLabValues;
					break;
				case Falcon.Data.EntityType.LabEntity:
					toReturn = this.Lab;
					break;
				case Falcon.Data.EntityType.LanguageEntity:
					toReturn = this.Language;
					break;
				case Falcon.Data.EntityType.LanguageBarrierCallQueueEntity:
					toReturn = this.LanguageBarrierCallQueue;
					break;
				case Falcon.Data.EntityType.LanguageBarrierCallQueueCriteriaAssignmentEntity:
					toReturn = this.LanguageBarrierCallQueueCriteriaAssignment;
					break;
				case Falcon.Data.EntityType.LoginOtpEntity:
					toReturn = this.LoginOtp;
					break;
				case Falcon.Data.EntityType.LoginSettingsEntity:
					toReturn = this.LoginSettings;
					break;
				case Falcon.Data.EntityType.LoincCrosswalkEntity:
					toReturn = this.LoincCrosswalk;
					break;
				case Falcon.Data.EntityType.LoincLabDataEntity:
					toReturn = this.LoincLabData;
					break;
				case Falcon.Data.EntityType.LookupEntity:
					toReturn = this.Lookup;
					break;
				case Falcon.Data.EntityType.LookupTypeEntity:
					toReturn = this.LookupType;
					break;
				case Falcon.Data.EntityType.MailRoundCallQueueEntity:
					toReturn = this.MailRoundCallQueue;
					break;
				case Falcon.Data.EntityType.MailRoundCallQueueCriteriaAssignmentEntity:
					toReturn = this.MailRoundCallQueueCriteriaAssignment;
					break;
				case Falcon.Data.EntityType.MarketingOfferRoleMappingEntity:
					toReturn = this.MarketingOfferRoleMapping;
					break;
				case Falcon.Data.EntityType.MarketingOffersEntity:
					toReturn = this.MarketingOffers;
					break;
				case Falcon.Data.EntityType.MarketingOfferSignUpModeEntity:
					toReturn = this.MarketingOfferSignUpMode;
					break;
				case Falcon.Data.EntityType.MarketingOfferTypeEntity:
					toReturn = this.MarketingOfferType;
					break;
				case Falcon.Data.EntityType.MarketingOrderShippingInfoEntity:
					toReturn = this.MarketingOrderShippingInfo;
					break;
				case Falcon.Data.EntityType.MarketingPrintOrderEntity:
					toReturn = this.MarketingPrintOrder;
					break;
				case Falcon.Data.EntityType.MarketingPrintOrderEventMappingEntity:
					toReturn = this.MarketingPrintOrderEventMapping;
					break;
				case Falcon.Data.EntityType.MarketingPrintOrderItemEntity:
					toReturn = this.MarketingPrintOrderItem;
					break;
				case Falcon.Data.EntityType.MarketingPrintOrderProspectListMappingEntity:
					toReturn = this.MarketingPrintOrderProspectListMapping;
					break;
				case Falcon.Data.EntityType.MarketingSourceEntity:
					toReturn = this.MarketingSource;
					break;
				case Falcon.Data.EntityType.MarketingSourceTerritoryEntity:
					toReturn = this.MarketingSourceTerritory;
					break;
				case Falcon.Data.EntityType.MedicalHistoryReadingAssosciationEntity:
					toReturn = this.MedicalHistoryReadingAssosciation;
					break;
				case Falcon.Data.EntityType.MedicalVendorProfileEntity:
					toReturn = this.MedicalVendorProfile;
					break;
				case Falcon.Data.EntityType.MedicalVendorTypeEntity:
					toReturn = this.MedicalVendorType;
					break;
				case Falcon.Data.EntityType.MedicareGroupDependencyRuleEntity:
					toReturn = this.MedicareGroupDependencyRule;
					break;
				case Falcon.Data.EntityType.MedicareQuestionEntity:
					toReturn = this.MedicareQuestion;
					break;
				case Falcon.Data.EntityType.MedicareQuestionDependencyRuleEntity:
					toReturn = this.MedicareQuestionDependencyRule;
					break;
				case Falcon.Data.EntityType.MedicareQuestionGroupEntity:
					toReturn = this.MedicareQuestionGroup;
					break;
				case Falcon.Data.EntityType.MedicareQuestionsRemarksEntity:
					toReturn = this.MedicareQuestionsRemarks;
					break;
				case Falcon.Data.EntityType.MedicationEntity:
					toReturn = this.Medication;
					break;
				case Falcon.Data.EntityType.MedicationUploadEntity:
					toReturn = this.MedicationUpload;
					break;
				case Falcon.Data.EntityType.MedicationUploadLogEntity:
					toReturn = this.MedicationUploadLog;
					break;
				case Falcon.Data.EntityType.MemberUploadLogEntity:
					toReturn = this.MemberUploadLog;
					break;
				case Falcon.Data.EntityType.MemberUploadParseDetailEntity:
					toReturn = this.MemberUploadParseDetail;
					break;
				case Falcon.Data.EntityType.MergeCustomerUploadEntity:
					toReturn = this.MergeCustomerUpload;
					break;
				case Falcon.Data.EntityType.MergeCustomerUploadLogEntity:
					toReturn = this.MergeCustomerUploadLog;
					break;
				case Falcon.Data.EntityType.MolinaAttestationEntity:
					toReturn = this.MolinaAttestation;
					break;
				case Falcon.Data.EntityType.MVPaymentCheckDetailsEntity:
					toReturn = this.MVPaymentCheckDetails;
					break;
				case Falcon.Data.EntityType.MvuserClassificationEntity:
					toReturn = this.MvuserClassification;
					break;
				case Falcon.Data.EntityType.NdcEntity:
					toReturn = this.Ndc;
					break;
				case Falcon.Data.EntityType.NoShowCallQueueEntity:
					toReturn = this.NoShowCallQueue;
					break;
				case Falcon.Data.EntityType.NoShowCallQueueCriteriaAssignmentEntity:
					toReturn = this.NoShowCallQueueCriteriaAssignment;
					break;
				case Falcon.Data.EntityType.NoteEntity:
					toReturn = this.Note;
					break;
				case Falcon.Data.EntityType.NotesDetailsEntity:
					toReturn = this.NotesDetails;
					break;
				case Falcon.Data.EntityType.NotificationEntity:
					toReturn = this.Notification;
					break;
				case Falcon.Data.EntityType.NotificationEmailEntity:
					toReturn = this.NotificationEmail;
					break;
				case Falcon.Data.EntityType.NotificationMediumEntity:
					toReturn = this.NotificationMedium;
					break;
				case Falcon.Data.EntityType.NotificationPhoneEntity:
					toReturn = this.NotificationPhone;
					break;
				case Falcon.Data.EntityType.NotificationSubscribersEntity:
					toReturn = this.NotificationSubscribers;
					break;
				case Falcon.Data.EntityType.NotificationTypeEntity:
					toReturn = this.NotificationType;
					break;
				case Falcon.Data.EntityType.OrderEntity:
					toReturn = this.Order;
					break;
				case Falcon.Data.EntityType.OrderDetailEntity:
					toReturn = this.OrderDetail;
					break;
				case Falcon.Data.EntityType.OrderItemEntity:
					toReturn = this.OrderItem;
					break;
				case Falcon.Data.EntityType.OrganizationEntity:
					toReturn = this.Organization;
					break;
				case Falcon.Data.EntityType.OrganizationRoleUserEntity:
					toReturn = this.OrganizationRoleUser;
					break;
				case Falcon.Data.EntityType.OrganizationRoleUserTerritoryEntity:
					toReturn = this.OrganizationRoleUserTerritory;
					break;
				case Falcon.Data.EntityType.OrganizationTypeEntity:
					toReturn = this.OrganizationType;
					break;
				case Falcon.Data.EntityType.OrgRoleUserActivityEntity:
					toReturn = this.OrgRoleUserActivity;
					break;
				case Falcon.Data.EntityType.OutboundUploadEntity:
					toReturn = this.OutboundUpload;
					break;
				case Falcon.Data.EntityType.PackageEntity:
					toReturn = this.Package;
					break;
				case Falcon.Data.EntityType.PackageAvailabilityToRolesEntity:
					toReturn = this.PackageAvailabilityToRoles;
					break;
				case Falcon.Data.EntityType.PackageMarketingOfferDiscountEntity:
					toReturn = this.PackageMarketingOfferDiscount;
					break;
				case Falcon.Data.EntityType.PackageSourceCodeDiscountEntity:
					toReturn = this.PackageSourceCodeDiscount;
					break;
				case Falcon.Data.EntityType.PackageTestEntity:
					toReturn = this.PackageTest;
					break;
				case Falcon.Data.EntityType.ParticipationConsentSignatureEntity:
					toReturn = this.ParticipationConsentSignature;
					break;
				case Falcon.Data.EntityType.PasswordChangelogEntity:
					toReturn = this.PasswordChangelog;
					break;
				case Falcon.Data.EntityType.PaymentEntity:
					toReturn = this.Payment;
					break;
				case Falcon.Data.EntityType.PaymentFrequencyEntity:
					toReturn = this.PaymentFrequency;
					break;
				case Falcon.Data.EntityType.PaymentInstructionsEntity:
					toReturn = this.PaymentInstructions;
					break;
				case Falcon.Data.EntityType.PaymentOrderEntity:
					toReturn = this.PaymentOrder;
					break;
				case Falcon.Data.EntityType.PaymentTypeEntity:
					toReturn = this.PaymentType;
					break;
				case Falcon.Data.EntityType.PayPeriodEntity:
					toReturn = this.PayPeriod;
					break;
				case Falcon.Data.EntityType.PayPeriodCriteriaEntity:
					toReturn = this.PayPeriodCriteria;
					break;
				case Falcon.Data.EntityType.PcpAppointmentEntity:
					toReturn = this.PcpAppointment;
					break;
				case Falcon.Data.EntityType.PcpDispositionEntity:
					toReturn = this.PcpDisposition;
					break;
				case Falcon.Data.EntityType.PhysicianCustomerAssignmentEntity:
					toReturn = this.PhysicianCustomerAssignment;
					break;
				case Falcon.Data.EntityType.PhysicianCustomerPayRateEntity:
					toReturn = this.PhysicianCustomerPayRate;
					break;
				case Falcon.Data.EntityType.PhysicianEarningsEntity:
					toReturn = this.PhysicianEarnings;
					break;
				case Falcon.Data.EntityType.PhysicianEvaluationEntity:
					toReturn = this.PhysicianEvaluation;
					break;
				case Falcon.Data.EntityType.PhysicianEventAssignmentEntity:
					toReturn = this.PhysicianEventAssignment;
					break;
				case Falcon.Data.EntityType.PhysicianInvoiceEntity:
					toReturn = this.PhysicianInvoice;
					break;
				case Falcon.Data.EntityType.PhysicianInvoiceItemEntity:
					toReturn = this.PhysicianInvoiceItem;
					break;
				case Falcon.Data.EntityType.PhysicianLabTestEntity:
					toReturn = this.PhysicianLabTest;
					break;
				case Falcon.Data.EntityType.PhysicianLicenseEntity:
					toReturn = this.PhysicianLicense;
					break;
				case Falcon.Data.EntityType.PhysicianMasterEntity:
					toReturn = this.PhysicianMaster;
					break;
				case Falcon.Data.EntityType.PhysicianPaymentEntity:
					toReturn = this.PhysicianPayment;
					break;
				case Falcon.Data.EntityType.PhysicianPaymentInvoiceEntity:
					toReturn = this.PhysicianPaymentInvoice;
					break;
				case Falcon.Data.EntityType.PhysicianPermittedTestEntity:
					toReturn = this.PhysicianPermittedTest;
					break;
				case Falcon.Data.EntityType.PhysicianPodEntity:
					toReturn = this.PhysicianPod;
					break;
				case Falcon.Data.EntityType.PhysicianProfileEntity:
					toReturn = this.PhysicianProfile;
					break;
				case Falcon.Data.EntityType.PhysicianRecordRequestSignatureEntity:
					toReturn = this.PhysicianRecordRequestSignature;
					break;
				case Falcon.Data.EntityType.PhysicianSpecializationEntity:
					toReturn = this.PhysicianSpecialization;
					break;
				case Falcon.Data.EntityType.PinChangelogEntity:
					toReturn = this.PinChangelog;
					break;
				case Falcon.Data.EntityType.PodDefaultTeamEntity:
					toReturn = this.PodDefaultTeam;
					break;
				case Falcon.Data.EntityType.PodDetailsEntity:
					toReturn = this.PodDetails;
					break;
				case Falcon.Data.EntityType.PodInventoryItemEntity:
					toReturn = this.PodInventoryItem;
					break;
				case Falcon.Data.EntityType.PodPackageEntity:
					toReturn = this.PodPackage;
					break;
				case Falcon.Data.EntityType.PodRoomEntity:
					toReturn = this.PodRoom;
					break;
				case Falcon.Data.EntityType.PodRoomTestEntity:
					toReturn = this.PodRoomTest;
					break;
				case Falcon.Data.EntityType.PodTerritoryEntity:
					toReturn = this.PodTerritory;
					break;
				case Falcon.Data.EntityType.PodTestEntity:
					toReturn = this.PodTest;
					break;
				case Falcon.Data.EntityType.PreApprovedPackageEntity:
					toReturn = this.PreApprovedPackage;
					break;
				case Falcon.Data.EntityType.PreApprovedTestEntity:
					toReturn = this.PreApprovedTest;
					break;
				case Falcon.Data.EntityType.PreAssessmentCallQueueCustomerLockEntity:
					toReturn = this.PreAssessmentCallQueueCustomerLock;
					break;
				case Falcon.Data.EntityType.PreAssessmentCustomerCallQueueCallAttemptEntity:
					toReturn = this.PreAssessmentCustomerCallQueueCallAttempt;
					break;
				case Falcon.Data.EntityType.PreQualificationQuestionEntity:
					toReturn = this.PreQualificationQuestion;
					break;
				case Falcon.Data.EntityType.PreQualificationQuestionRuleEntity:
					toReturn = this.PreQualificationQuestionRule;
					break;
				case Falcon.Data.EntityType.PreQualificationResultEntity:
					toReturn = this.PreQualificationResult;
					break;
				case Falcon.Data.EntityType.PreQualificationTemplateDependentTestEntity:
					toReturn = this.PreQualificationTemplateDependentTest;
					break;
				case Falcon.Data.EntityType.PreQualificationTemplateQuestionEntity:
					toReturn = this.PreQualificationTemplateQuestion;
					break;
				case Falcon.Data.EntityType.PreQualificationTestTemplateEntity:
					toReturn = this.PreQualificationTestTemplate;
					break;
				case Falcon.Data.EntityType.PrintOrderItemTrackingEntity:
					toReturn = this.PrintOrderItemTracking;
					break;
				case Falcon.Data.EntityType.PriorityInQueueEntity:
					toReturn = this.PriorityInQueue;
					break;
				case Falcon.Data.EntityType.ProductEntity:
					toReturn = this.Product;
					break;
				case Falcon.Data.EntityType.ProductOrderItemEntity:
					toReturn = this.ProductOrderItem;
					break;
				case Falcon.Data.EntityType.ProductShippingOptionEntity:
					toReturn = this.ProductShippingOption;
					break;
				case Falcon.Data.EntityType.ProductSourceCodeDiscountEntity:
					toReturn = this.ProductSourceCodeDiscount;
					break;
				case Falcon.Data.EntityType.ProspectActivityEntity:
					toReturn = this.ProspectActivity;
					break;
				case Falcon.Data.EntityType.ProspectActivityDetailsEntity:
					toReturn = this.ProspectActivityDetails;
					break;
				case Falcon.Data.EntityType.ProspectAddressEntity:
					toReturn = this.ProspectAddress;
					break;
				case Falcon.Data.EntityType.ProspectCallDetailsEntity:
					toReturn = this.ProspectCallDetails;
					break;
				case Falcon.Data.EntityType.ProspectCallsEntity:
					toReturn = this.ProspectCalls;
					break;
				case Falcon.Data.EntityType.ProspectContactEntity:
					toReturn = this.ProspectContact;
					break;
				case Falcon.Data.EntityType.ProspectContactCallsEntity:
					toReturn = this.ProspectContactCalls;
					break;
				case Falcon.Data.EntityType.ProspectContactMeetingsEntity:
					toReturn = this.ProspectContactMeetings;
					break;
				case Falcon.Data.EntityType.ProspectContactRoleEntity:
					toReturn = this.ProspectContactRole;
					break;
				case Falcon.Data.EntityType.ProspectContactRoleMappingEntity:
					toReturn = this.ProspectContactRoleMapping;
					break;
				case Falcon.Data.EntityType.ProspectContactTasksEntity:
					toReturn = this.ProspectContactTasks;
					break;
				case Falcon.Data.EntityType.ProspectCustomerEntity:
					toReturn = this.ProspectCustomer;
					break;
				case Falcon.Data.EntityType.ProspectCustomerCallEntity:
					toReturn = this.ProspectCustomerCall;
					break;
				case Falcon.Data.EntityType.ProspectCustomerDeletedEntity:
					toReturn = this.ProspectCustomerDeleted;
					break;
				case Falcon.Data.EntityType.ProspectCustomerNotificationEntity:
					toReturn = this.ProspectCustomerNotification;
					break;
				case Falcon.Data.EntityType.ProspectDetailsEntity:
					toReturn = this.ProspectDetails;
					break;
				case Falcon.Data.EntityType.ProspectFaliureReportEntity:
					toReturn = this.ProspectFaliureReport;
					break;
				case Falcon.Data.EntityType.ProspectListDetailsEntity:
					toReturn = this.ProspectListDetails;
					break;
				case Falcon.Data.EntityType.ProspectListTypeEntity:
					toReturn = this.ProspectListType;
					break;
				case Falcon.Data.EntityType.ProspectMeetingsEntity:
					toReturn = this.ProspectMeetings;
					break;
				case Falcon.Data.EntityType.ProspectNotesDetailsEntity:
					toReturn = this.ProspectNotesDetails;
					break;
				case Falcon.Data.EntityType.ProspectsEntity:
					toReturn = this.Prospects;
					break;
				case Falcon.Data.EntityType.ProspectTasksEntity:
					toReturn = this.ProspectTasks;
					break;
				case Falcon.Data.EntityType.ProspectTypeEntity:
					toReturn = this.ProspectType;
					break;
				case Falcon.Data.EntityType.RapsEntity:
					toReturn = this.Raps;
					break;
				case Falcon.Data.EntityType.RapsUploadEntity:
					toReturn = this.RapsUpload;
					break;
				case Falcon.Data.EntityType.RapsUploadLogEntity:
					toReturn = this.RapsUploadLog;
					break;
				case Falcon.Data.EntityType.ReadingEntity:
					toReturn = this.Reading;
					break;
				case Falcon.Data.EntityType.ReferralEntity:
					toReturn = this.Referral;
					break;
				case Falcon.Data.EntityType.RefundEntity:
					toReturn = this.Refund;
					break;
				case Falcon.Data.EntityType.RefundOrderItemEntity:
					toReturn = this.RefundOrderItem;
					break;
				case Falcon.Data.EntityType.RefundRequestEntity:
					toReturn = this.RefundRequest;
					break;
				case Falcon.Data.EntityType.RefundRequestGiftCertificateEntity:
					toReturn = this.RefundRequestGiftCertificate;
					break;
				case Falcon.Data.EntityType.RelationshipEntity:
					toReturn = this.Relationship;
					break;
				case Falcon.Data.EntityType.RequiredTestEntity:
					toReturn = this.RequiredTest;
					break;
				case Falcon.Data.EntityType.RescheduleCancelDispositionEntity:
					toReturn = this.RescheduleCancelDisposition;
					break;
				case Falcon.Data.EntityType.ResultArchiveUploadEntity:
					toReturn = this.ResultArchiveUpload;
					break;
				case Falcon.Data.EntityType.ResultArchiveUploadLogEntity:
					toReturn = this.ResultArchiveUploadLog;
					break;
				case Falcon.Data.EntityType.RoleEntity:
					toReturn = this.Role;
					break;
				case Falcon.Data.EntityType.RoleAccessControlObjectEntity:
					toReturn = this.RoleAccessControlObject;
					break;
				case Falcon.Data.EntityType.RolePermisibleAccessControlObjectEntity:
					toReturn = this.RolePermisibleAccessControlObject;
					break;
				case Falcon.Data.EntityType.RoleScopeOptionEntity:
					toReturn = this.RoleScopeOption;
					break;
				case Falcon.Data.EntityType.SafeComputerHistoryEntity:
					toReturn = this.SafeComputerHistory;
					break;
				case Falcon.Data.EntityType.SalesRepPodAssigmentsEntity:
					toReturn = this.SalesRepPodAssigments;
					break;
				case Falcon.Data.EntityType.ScheduleMethodEntity:
					toReturn = this.ScheduleMethod;
					break;
				case Falcon.Data.EntityType.ScheduleTemplateEntity:
					toReturn = this.ScheduleTemplate;
					break;
				case Falcon.Data.EntityType.ScheduleTemplateFranchiseeAccessEntity:
					toReturn = this.ScheduleTemplateFranchiseeAccess;
					break;
				case Falcon.Data.EntityType.ScheduleTemplateTimeEntity:
					toReturn = this.ScheduleTemplateTime;
					break;
				case Falcon.Data.EntityType.ScreeningAuthorizationEntity:
					toReturn = this.ScreeningAuthorization;
					break;
				case Falcon.Data.EntityType.ScriptsEntity:
					toReturn = this.Scripts;
					break;
				case Falcon.Data.EntityType.ScriptTypeEntity:
					toReturn = this.ScriptType;
					break;
				case Falcon.Data.EntityType.SecurityQuestionEntity:
					toReturn = this.SecurityQuestion;
					break;
				case Falcon.Data.EntityType.SeminarCampaignDetailsEntity:
					toReturn = this.SeminarCampaignDetails;
					break;
				case Falcon.Data.EntityType.SeminarsEntity:
					toReturn = this.Seminars;
					break;
				case Falcon.Data.EntityType.ShippingDetailEntity:
					toReturn = this.ShippingDetail;
					break;
				case Falcon.Data.EntityType.ShippingDetailOrderDetailEntity:
					toReturn = this.ShippingDetailOrderDetail;
					break;
				case Falcon.Data.EntityType.ShippingOptionEntity:
					toReturn = this.ShippingOption;
					break;
				case Falcon.Data.EntityType.ShippingOptionOrderItemEntity:
					toReturn = this.ShippingOptionOrderItem;
					break;
				case Falcon.Data.EntityType.ShippingOptionSourceCodeDiscountEntity:
					toReturn = this.ShippingOptionSourceCodeDiscount;
					break;
				case Falcon.Data.EntityType.SmsReceivedEntity:
					toReturn = this.SmsReceived;
					break;
				case Falcon.Data.EntityType.SourceCodeChangeLogEntity:
					toReturn = this.SourceCodeChangeLog;
					break;
				case Falcon.Data.EntityType.SourceCodeOrderDetailEntity:
					toReturn = this.SourceCodeOrderDetail;
					break;
				case Falcon.Data.EntityType.StaffEventRoleEntity:
					toReturn = this.StaffEventRole;
					break;
				case Falcon.Data.EntityType.StaffEventRoleTestEntity:
					toReturn = this.StaffEventRoleTest;
					break;
				case Falcon.Data.EntityType.StaffEventScheduleUploadEntity:
					toReturn = this.StaffEventScheduleUpload;
					break;
				case Falcon.Data.EntityType.StaffEventScheduleUploadLogEntity:
					toReturn = this.StaffEventScheduleUploadLog;
					break;
				case Falcon.Data.EntityType.StandardFindingEntity:
					toReturn = this.StandardFinding;
					break;
				case Falcon.Data.EntityType.StandardFindingTestReadingEntity:
					toReturn = this.StandardFindingTestReading;
					break;
				case Falcon.Data.EntityType.StateEntity:
					toReturn = this.State;
					break;
				case Falcon.Data.EntityType.SurveyAnswerEntity:
					toReturn = this.SurveyAnswer;
					break;
				case Falcon.Data.EntityType.SurveyQuestionEntity:
					toReturn = this.SurveyQuestion;
					break;
				case Falcon.Data.EntityType.SurveyTemplateEntity:
					toReturn = this.SurveyTemplate;
					break;
				case Falcon.Data.EntityType.SurveyTemplateQuestionEntity:
					toReturn = this.SurveyTemplateQuestion;
					break;
				case Falcon.Data.EntityType.SuspectConditionEntity:
					toReturn = this.SuspectCondition;
					break;
				case Falcon.Data.EntityType.SuspectConditionUploadEntity:
					toReturn = this.SuspectConditionUpload;
					break;
				case Falcon.Data.EntityType.SuspectConditionUploadLogEntity:
					toReturn = this.SuspectConditionUploadLog;
					break;
				case Falcon.Data.EntityType.SystemGeneratedCallQueueAssignmentEntity:
					toReturn = this.SystemGeneratedCallQueueAssignment;
					break;
				case Falcon.Data.EntityType.SystemGeneratedCallQueueCriteriaEntity:
					toReturn = this.SystemGeneratedCallQueueCriteria;
					break;
				case Falcon.Data.EntityType.SystemUserInfoEntity:
					toReturn = this.SystemUserInfo;
					break;
				case Falcon.Data.EntityType.TagEntity:
					toReturn = this.Tag;
					break;
				case Falcon.Data.EntityType.TaskEntity:
					toReturn = this.Task;
					break;
				case Falcon.Data.EntityType.TaskDetailsEntity:
					toReturn = this.TaskDetails;
					break;
				case Falcon.Data.EntityType.TaskPriorityTypesEntity:
					toReturn = this.TaskPriorityTypes;
					break;
				case Falcon.Data.EntityType.TaskStatusTypesEntity:
					toReturn = this.TaskStatusTypes;
					break;
				case Falcon.Data.EntityType.TechnicianProfileEntity:
					toReturn = this.TechnicianProfile;
					break;
				case Falcon.Data.EntityType.TempCartEntity:
					toReturn = this.TempCart;
					break;
				case Falcon.Data.EntityType.TemplateEntity:
					toReturn = this.Template;
					break;
				case Falcon.Data.EntityType.TemplateMacroEntity:
					toReturn = this.TemplateMacro;
					break;
				case Falcon.Data.EntityType.TemplateTagEntity:
					toReturn = this.TemplateTag;
					break;
				case Falcon.Data.EntityType.TerritoryEntity:
					toReturn = this.Territory;
					break;
				case Falcon.Data.EntityType.TerritoryPackageEntity:
					toReturn = this.TerritoryPackage;
					break;
				case Falcon.Data.EntityType.TerritoryZipEntity:
					toReturn = this.TerritoryZip;
					break;
				case Falcon.Data.EntityType.TestEntity:
					toReturn = this.Test;
					break;
				case Falcon.Data.EntityType.TestAvailabilityToRolesEntity:
					toReturn = this.TestAvailabilityToRoles;
					break;
				case Falcon.Data.EntityType.TestDependencyRuleEntity:
					toReturn = this.TestDependencyRule;
					break;
				case Falcon.Data.EntityType.TestHcpcsCodeEntity:
					toReturn = this.TestHcpcsCode;
					break;
				case Falcon.Data.EntityType.TestimonialEntity:
					toReturn = this.Testimonial;
					break;
				case Falcon.Data.EntityType.TestIncidentalFindingEntity:
					toReturn = this.TestIncidentalFinding;
					break;
				case Falcon.Data.EntityType.TestMediaEntity:
					toReturn = this.TestMedia;
					break;
				case Falcon.Data.EntityType.TestNotPerformedEntity:
					toReturn = this.TestNotPerformed;
					break;
				case Falcon.Data.EntityType.TestNotPerformedReasonEntity:
					toReturn = this.TestNotPerformedReason;
					break;
				case Falcon.Data.EntityType.TestOrderItemEntity:
					toReturn = this.TestOrderItem;
					break;
				case Falcon.Data.EntityType.TestPerformedExternallyEntity:
					toReturn = this.TestPerformedExternally;
					break;
				case Falcon.Data.EntityType.TestReadingEntity:
					toReturn = this.TestReading;
					break;
				case Falcon.Data.EntityType.TestSourceCodeDiscountEntity:
					toReturn = this.TestSourceCodeDiscount;
					break;
				case Falcon.Data.EntityType.TestUnableScreenReasonEntity:
					toReturn = this.TestUnableScreenReason;
					break;
				case Falcon.Data.EntityType.ToolTipEntity:
					toReturn = this.ToolTip;
					break;
				case Falcon.Data.EntityType.TrackingMarketingEntity:
					toReturn = this.TrackingMarketing;
					break;
				case Falcon.Data.EntityType.UncontactedCustomerCallQueueEntity:
					toReturn = this.UncontactedCustomerCallQueue;
					break;
				case Falcon.Data.EntityType.UncontactedCustomerCallQueueCriteriaAssignmentEntity:
					toReturn = this.UncontactedCustomerCallQueueCriteriaAssignment;
					break;
				case Falcon.Data.EntityType.UnitEntity:
					toReturn = this.Unit;
					break;
				case Falcon.Data.EntityType.UploadTestInfoEntity:
					toReturn = this.UploadTestInfo;
					break;
				case Falcon.Data.EntityType.UploadZipInfoEntity:
					toReturn = this.UploadZipInfo;
					break;
				case Falcon.Data.EntityType.UserEntity:
					toReturn = this.User;
					break;
				case Falcon.Data.EntityType.UserLoginEntity:
					toReturn = this.UserLogin;
					break;
				case Falcon.Data.EntityType.UserLoginLogEntity:
					toReturn = this.UserLoginLog;
					break;
				case Falcon.Data.EntityType.UserNpiInfoEntity:
					toReturn = this.UserNpiInfo;
					break;
				case Falcon.Data.EntityType.UserSecurityQuestionEntity:
					toReturn = this.UserSecurityQuestion;
					break;
				case Falcon.Data.EntityType.VanDetailsEntity:
					toReturn = this.VanDetails;
					break;
				case Falcon.Data.EntityType.VwCallCenterCallReportEntity:
					toReturn = this.VwCallCenterCallReport;
					break;
				case Falcon.Data.EntityType.VwCallQueueCustomerCallDetailsEntity:
					toReturn = this.VwCallQueueCustomerCallDetails;
					break;
				case Falcon.Data.EntityType.VwCallQueueCustomerCriteraAssignmentEntity:
					toReturn = this.VwCallQueueCustomerCriteraAssignment;
					break;
				case Falcon.Data.EntityType.VwCallQueueCustomerCriteraAssignmentForGmsEntity:
					toReturn = this.VwCallQueueCustomerCriteraAssignmentForGms;
					break;
				case Falcon.Data.EntityType.VwCallQueueCustomerCriteraAssignmentForGmsStatsEntity:
					toReturn = this.VwCallQueueCustomerCriteraAssignmentForGmsStats;
					break;
				case Falcon.Data.EntityType.VwCallQueueCustomerCriteraAssignmentForStatsEntity:
					toReturn = this.VwCallQueueCustomerCriteraAssignmentForStats;
					break;
				case Falcon.Data.EntityType.VwCallQueueCustomerCriteraAssignmentWithCustomerEntity:
					toReturn = this.VwCallQueueCustomerCriteraAssignmentWithCustomer;
					break;
				case Falcon.Data.EntityType.VwCallRoundCallQueueCriteraAssignmentEntity:
					toReturn = this.VwCallRoundCallQueueCriteraAssignment;
					break;
				case Falcon.Data.EntityType.VwCampaignClickConversionEntity:
					toReturn = this.VwCampaignClickConversion;
					break;
				case Falcon.Data.EntityType.VwCustomerAggregateResultSummaryEntity:
					toReturn = this.VwCustomerAggregateResultSummary;
					break;
				case Falcon.Data.EntityType.VwEventAppointmentEntity:
					toReturn = this.VwEventAppointment;
					break;
				case Falcon.Data.EntityType.VwEventCustomerPreApprovedTestListEntity:
					toReturn = this.VwEventCustomerPreApprovedTestList;
					break;
				case Falcon.Data.EntityType.VwEventCustomersAccountEntity:
					toReturn = this.VwEventCustomersAccount;
					break;
				case Falcon.Data.EntityType.VwEventCustomersViewServiceReportEntity:
					toReturn = this.VwEventCustomersViewServiceReport;
					break;
				case Falcon.Data.EntityType.VwFillEventCallQueueCriteraAssignmentEntity:
					toReturn = this.VwFillEventCallQueueCriteraAssignment;
					break;
				case Falcon.Data.EntityType.VwGetAllTestForCustomersEntity:
					toReturn = this.VwGetAllTestForCustomers;
					break;
				case Falcon.Data.EntityType.VwGetBookedAppointmentForCalculatingBonusEntity:
					toReturn = this.VwGetBookedAppointmentForCalculatingBonus;
					break;
				case Falcon.Data.EntityType.VwGetCallCenterAgentsForConversionReportEntity:
					toReturn = this.VwGetCallCenterAgentsForConversionReport;
					break;
				case Falcon.Data.EntityType.VwGetCallQueueCustomersEntity:
					toReturn = this.VwGetCallQueueCustomers;
					break;
				case Falcon.Data.EntityType.VwGetCallQueueExcludedCustomersEntity:
					toReturn = this.VwGetCallQueueExcludedCustomers;
					break;
				case Falcon.Data.EntityType.VwGetCallsEntity:
					toReturn = this.VwGetCalls;
					break;
				case Falcon.Data.EntityType.VwGetCallsForCalculatingBonusEntity:
					toReturn = this.VwGetCallsForCalculatingBonus;
					break;
				case Falcon.Data.EntityType.VwGetCallsForCallQueueEntity:
					toReturn = this.VwGetCallsForCallQueue;
					break;
				case Falcon.Data.EntityType.VwGetCallsForSuppressionEntity:
					toReturn = this.VwGetCallsForSuppression;
					break;
				case Falcon.Data.EntityType.VwGetConfirmationCallQueueCustomersWithoutSuppressionEntity:
					toReturn = this.VwGetConfirmationCallQueueCustomersWithoutSuppression;
					break;
				case Falcon.Data.EntityType.VwGetCustomerForMailRoundInsertionEntity:
					toReturn = this.VwGetCustomerForMailRoundInsertion;
					break;
				case Falcon.Data.EntityType.VwGetCustomerIdsHavingSingleTagForCallQueueEntity:
					toReturn = this.VwGetCustomerIdsHavingSingleTagForCallQueue;
					break;
				case Falcon.Data.EntityType.VwGetCustomersForCallQueueWithCustomerEntity:
					toReturn = this.VwGetCustomersForCallQueueWithCustomer;
					break;
				case Falcon.Data.EntityType.VwGetCustomersForCallQueueWithCustomerViciEntity:
					toReturn = this.VwGetCustomersForCallQueueWithCustomerVici;
					break;
				case Falcon.Data.EntityType.VwGetCustomersForConfirmationCallQueueEntity:
					toReturn = this.VwGetCustomersForConfirmationCallQueue;
					break;
				case Falcon.Data.EntityType.VwGetCustomersForNotInCallQueueEntity:
					toReturn = this.VwGetCustomersForNotInCallQueue;
					break;
				case Falcon.Data.EntityType.VwGetCustomersToGenerateCallQueueEntity:
					toReturn = this.VwGetCustomersToGenerateCallQueue;
					break;
				case Falcon.Data.EntityType.VwGetCustomersToGenerateConfirmationCallQueueEntity:
					toReturn = this.VwGetCustomersToGenerateConfirmationCallQueue;
					break;
				case Falcon.Data.EntityType.VwGetCustomersToGenerateFillEventCallQueueEntity:
					toReturn = this.VwGetCustomersToGenerateFillEventCallQueue;
					break;
				case Falcon.Data.EntityType.VwGetCustomersToGenerateFillEventCallQueue_Entity:
					toReturn = this.VwGetCustomersToGenerateFillEventCallQueue_;
					break;
				case Falcon.Data.EntityType.VwGetCustomerTagForCallQueueEntity:
					toReturn = this.VwGetCustomerTagForCallQueue;
					break;
				case Falcon.Data.EntityType.VwGetDataForSkippedCallReportEntity:
					toReturn = this.VwGetDataForSkippedCallReport;
					break;
				case Falcon.Data.EntityType.VwGetDirectMailForCallQueueEntity:
					toReturn = this.VwGetDirectMailForCallQueue;
					break;
				case Falcon.Data.EntityType.VwGetEventCustomerEawvTestInOrderEntity:
					toReturn = this.VwGetEventCustomerEawvTestInOrder;
					break;
				case Falcon.Data.EntityType.VwGetHkynTestCustomersEntity:
					toReturn = this.VwGetHkynTestCustomers;
					break;
				case Falcon.Data.EntityType.VwGetKynTestCustomersEntity:
					toReturn = this.VwGetKynTestCustomers;
					break;
				case Falcon.Data.EntityType.VwGetMyBioCheckTestCustomersEntity:
					toReturn = this.VwGetMyBioCheckTestCustomers;
					break;
				case Falcon.Data.EntityType.VwGetOutboundCallsEntity:
					toReturn = this.VwGetOutboundCalls;
					break;
				case Falcon.Data.EntityType.VwGetTestPerformedReportEntity:
					toReturn = this.VwGetTestPerformedReport;
					break;
				case Falcon.Data.EntityType.VwHospitalPartnerCustomersEntity:
					toReturn = this.VwHospitalPartnerCustomers;
					break;
				case Falcon.Data.EntityType.VwHostEventDetailsEntity:
					toReturn = this.VwHostEventDetails;
					break;
				case Falcon.Data.EntityType.VwLanguageBarrierCallQueueCriteraAssignmentEntity:
					toReturn = this.VwLanguageBarrierCallQueueCriteraAssignment;
					break;
				case Falcon.Data.EntityType.VwMailRoundCallQueueCriteraAssignmentEntity:
					toReturn = this.VwMailRoundCallQueueCriteraAssignment;
					break;
				case Falcon.Data.EntityType.VwOutreachCallReportEntity:
					toReturn = this.VwOutreachCallReport;
					break;
				case Falcon.Data.EntityType.VwPcpAppointmetnDispositionEntity:
					toReturn = this.VwPcpAppointmetnDisposition;
					break;
				case Falcon.Data.EntityType.VwPhysicianQueueRecordEntity:
					toReturn = this.VwPhysicianQueueRecord;
					break;
				case Falcon.Data.EntityType.VwUncontactedCustomerCallQueueCriteraAssignmentEntity:
					toReturn = this.VwUncontactedCustomerCallQueueCriteraAssignment;
					break;
				case Falcon.Data.EntityType.WellMedAttestationEntity:
					toReturn = this.WellMedAttestation;
					break;
				case Falcon.Data.EntityType.WfEntity:
					toReturn = this.Wf;
					break;
				case Falcon.Data.EntityType.WidgetEntity:
					toReturn = this.Widget;
					break;
				case Falcon.Data.EntityType.ZipEntity:
					toReturn = this.Zip;
					break;
				case Falcon.Data.EntityType.ZipDataEntity:
					toReturn = this.ZipData;
					break;
				case Falcon.Data.EntityType.ZipRadiusDistanceEntity:
					toReturn = this.ZipRadiusDistance;
					break;
				default:
					toReturn = null;
					break;
			}
			return toReturn;
		}

		/// <summary>returns the datasource to use in a Linq query when targeting AccessControlObjectEntity instances in the database.</summary>
		public DataSource2<AccessControlObjectEntity> AccessControlObject
		{
			get { return new DataSource2<AccessControlObjectEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AccessControlObjectUrlEntity instances in the database.</summary>
		public DataSource2<AccessControlObjectUrlEntity> AccessControlObjectUrl
		{
			get { return new DataSource2<AccessControlObjectUrlEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AccessObjectScopeOptionEntity instances in the database.</summary>
		public DataSource2<AccessObjectScopeOptionEntity> AccessObjectScopeOption
		{
			get { return new DataSource2<AccessObjectScopeOptionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AccountEntity instances in the database.</summary>
		public DataSource2<AccountEntity> Account
		{
			get { return new DataSource2<AccountEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AccountAdditionalFieldsEntity instances in the database.</summary>
		public DataSource2<AccountAdditionalFieldsEntity> AccountAdditionalFields
		{
			get { return new DataSource2<AccountAdditionalFieldsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AccountCallCenterOrganizationEntity instances in the database.</summary>
		public DataSource2<AccountCallCenterOrganizationEntity> AccountCallCenterOrganization
		{
			get { return new DataSource2<AccountCallCenterOrganizationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AccountCallQueueSettingEntity instances in the database.</summary>
		public DataSource2<AccountCallQueueSettingEntity> AccountCallQueueSetting
		{
			get { return new DataSource2<AccountCallQueueSettingEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AccountCheckoutPhoneNumberEntity instances in the database.</summary>
		public DataSource2<AccountCheckoutPhoneNumberEntity> AccountCheckoutPhoneNumber
		{
			get { return new DataSource2<AccountCheckoutPhoneNumberEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AccountCoordinatorProfileEntity instances in the database.</summary>
		public DataSource2<AccountCoordinatorProfileEntity> AccountCoordinatorProfile
		{
			get { return new DataSource2<AccountCoordinatorProfileEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AccountCustomerResultTestDependencyEntity instances in the database.</summary>
		public DataSource2<AccountCustomerResultTestDependencyEntity> AccountCustomerResultTestDependency
		{
			get { return new DataSource2<AccountCustomerResultTestDependencyEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AccountEventZipEntity instances in the database.</summary>
		public DataSource2<AccountEventZipEntity> AccountEventZip
		{
			get { return new DataSource2<AccountEventZipEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AccountEventZipSubstituteEntity instances in the database.</summary>
		public DataSource2<AccountEventZipSubstituteEntity> AccountEventZipSubstitute
		{
			get { return new DataSource2<AccountEventZipSubstituteEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AccountHealthPlanResultTestDependencyEntity instances in the database.</summary>
		public DataSource2<AccountHealthPlanResultTestDependencyEntity> AccountHealthPlanResultTestDependency
		{
			get { return new DataSource2<AccountHealthPlanResultTestDependencyEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AccountHraChatQuestionnaireEntity instances in the database.</summary>
		public DataSource2<AccountHraChatQuestionnaireEntity> AccountHraChatQuestionnaire
		{
			get { return new DataSource2<AccountHraChatQuestionnaireEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AccountNotReviewableTestEntity instances in the database.</summary>
		public DataSource2<AccountNotReviewableTestEntity> AccountNotReviewableTest
		{
			get { return new DataSource2<AccountNotReviewableTestEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AccountPackageEntity instances in the database.</summary>
		public DataSource2<AccountPackageEntity> AccountPackage
		{
			get { return new DataSource2<AccountPackageEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AccountPcpResultTestDependencyEntity instances in the database.</summary>
		public DataSource2<AccountPcpResultTestDependencyEntity> AccountPcpResultTestDependency
		{
			get { return new DataSource2<AccountPcpResultTestDependencyEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AccountTestEntity instances in the database.</summary>
		public DataSource2<AccountTestEntity> AccountTest
		{
			get { return new DataSource2<AccountTestEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AccountTestHcpcsCodeEntity instances in the database.</summary>
		public DataSource2<AccountTestHcpcsCodeEntity> AccountTestHcpcsCode
		{
			get { return new DataSource2<AccountTestHcpcsCodeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ActivityEntity instances in the database.</summary>
		public DataSource2<ActivityEntity> Activity
		{
			get { return new DataSource2<ActivityEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ActivityTypeEntity instances in the database.</summary>
		public DataSource2<ActivityTypeEntity> ActivityType
		{
			get { return new DataSource2<ActivityTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AdditionalFieldsEntity instances in the database.</summary>
		public DataSource2<AdditionalFieldsEntity> AdditionalFields
		{
			get { return new DataSource2<AdditionalFieldsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AddressEntity instances in the database.</summary>
		public DataSource2<AddressEntity> Address
		{
			get { return new DataSource2<AddressEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AdvocateManagerTeamEntity instances in the database.</summary>
		public DataSource2<AdvocateManagerTeamEntity> AdvocateManagerTeam
		{
			get { return new DataSource2<AdvocateManagerTeamEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AfadvertiserEntity instances in the database.</summary>
		public DataSource2<AfadvertiserEntity> Afadvertiser
		{
			get { return new DataSource2<AfadvertiserEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AfAdvertisingCommissionEntity instances in the database.</summary>
		public DataSource2<AfAdvertisingCommissionEntity> AfAdvertisingCommission
		{
			get { return new DataSource2<AfAdvertisingCommissionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AfaffiliateCampaignEntity instances in the database.</summary>
		public DataSource2<AfaffiliateCampaignEntity> AfaffiliateCampaign
		{
			get { return new DataSource2<AfaffiliateCampaignEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AfaffiliateCampaignMarketingMaterialEntity instances in the database.</summary>
		public DataSource2<AfaffiliateCampaignMarketingMaterialEntity> AfaffiliateCampaignMarketingMaterial
		{
			get { return new DataSource2<AfaffiliateCampaignMarketingMaterialEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AfcampaignEntity instances in the database.</summary>
		public DataSource2<AfcampaignEntity> Afcampaign
		{
			get { return new DataSource2<AfcampaignEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AfcampaignCreativeEntity instances in the database.</summary>
		public DataSource2<AfcampaignCreativeEntity> AfcampaignCreative
		{
			get { return new DataSource2<AfcampaignCreativeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AfcampaignSubAdvocateEntity instances in the database.</summary>
		public DataSource2<AfcampaignSubAdvocateEntity> AfcampaignSubAdvocate
		{
			get { return new DataSource2<AfcampaignSubAdvocateEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AfcampaignTemplateEntity instances in the database.</summary>
		public DataSource2<AfcampaignTemplateEntity> AfcampaignTemplate
		{
			get { return new DataSource2<AfcampaignTemplateEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AfchannelEntity instances in the database.</summary>
		public DataSource2<AfchannelEntity> Afchannel
		{
			get { return new DataSource2<AfchannelEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AfcommisionEntity instances in the database.</summary>
		public DataSource2<AfcommisionEntity> Afcommision
		{
			get { return new DataSource2<AfcommisionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AfDailyLogImpressionClickEntity instances in the database.</summary>
		public DataSource2<AfDailyLogImpressionClickEntity> AfDailyLogImpressionClick
		{
			get { return new DataSource2<AfDailyLogImpressionClickEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AffiliateProfileEntity instances in the database.</summary>
		public DataSource2<AffiliateProfileEntity> AffiliateProfile
		{
			get { return new DataSource2<AffiliateProfileEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AfimpressionEntity instances in the database.</summary>
		public DataSource2<AfimpressionEntity> Afimpression
		{
			get { return new DataSource2<AfimpressionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AfimpressionLogEntity instances in the database.</summary>
		public DataSource2<AfimpressionLogEntity> AfimpressionLog
		{
			get { return new DataSource2<AfimpressionLogEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AfincomingPhoneEntity instances in the database.</summary>
		public DataSource2<AfincomingPhoneEntity> AfincomingPhone
		{
			get { return new DataSource2<AfincomingPhoneEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AflAffiliatePaymentMethodEntity instances in the database.</summary>
		public DataSource2<AflAffiliatePaymentMethodEntity> AflAffiliatePaymentMethod
		{
			get { return new DataSource2<AflAffiliatePaymentMethodEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AfmanualCheckEntity instances in the database.</summary>
		public DataSource2<AfmanualCheckEntity> AfmanualCheck
		{
			get { return new DataSource2<AfmanualCheckEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AfmarketingMaterialEntity instances in the database.</summary>
		public DataSource2<AfmarketingMaterialEntity> AfmarketingMaterial
		{
			get { return new DataSource2<AfmarketingMaterialEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AfMarketingMaterialBannerSizeEntity instances in the database.</summary>
		public DataSource2<AfMarketingMaterialBannerSizeEntity> AfMarketingMaterialBannerSize
		{
			get { return new DataSource2<AfMarketingMaterialBannerSizeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AfmarketingMaterialGroupEntity instances in the database.</summary>
		public DataSource2<AfmarketingMaterialGroupEntity> AfmarketingMaterialGroup
		{
			get { return new DataSource2<AfmarketingMaterialGroupEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AfmarketingMaterialTypeEntity instances in the database.</summary>
		public DataSource2<AfmarketingMaterialTypeEntity> AfmarketingMaterialType
		{
			get { return new DataSource2<AfmarketingMaterialTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AfpaymentEntity instances in the database.</summary>
		public DataSource2<AfpaymentEntity> Afpayment
		{
			get { return new DataSource2<AfpaymentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AfpaypalEntity instances in the database.</summary>
		public DataSource2<AfpaypalEntity> Afpaypal
		{
			get { return new DataSource2<AfpaypalEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AfppcclickLogEntity instances in the database.</summary>
		public DataSource2<AfppcclickLogEntity> AfppcclickLog
		{
			get { return new DataSource2<AfppcclickLogEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AfredirectUrlEntity instances in the database.</summary>
		public DataSource2<AfredirectUrlEntity> AfredirectUrl
		{
			get { return new DataSource2<AfredirectUrlEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ApplicationAuthenticationEntity instances in the database.</summary>
		public DataSource2<ApplicationAuthenticationEntity> ApplicationAuthentication
		{
			get { return new DataSource2<ApplicationAuthenticationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting BarrierEntity instances in the database.</summary>
		public DataSource2<BarrierEntity> Barrier
		{
			get { return new DataSource2<BarrierEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting BillingAccountEntity instances in the database.</summary>
		public DataSource2<BillingAccountEntity> BillingAccount
		{
			get { return new DataSource2<BillingAccountEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting BillingAccountTestEntity instances in the database.</summary>
		public DataSource2<BillingAccountTestEntity> BillingAccountTest
		{
			get { return new DataSource2<BillingAccountTestEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting BlockedDaysEntity instances in the database.</summary>
		public DataSource2<BlockedDaysEntity> BlockedDays
		{
			get { return new DataSource2<BlockedDaysEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting BlockedDaysFranchiseeEntity instances in the database.</summary>
		public DataSource2<BlockedDaysFranchiseeEntity> BlockedDaysFranchisee
		{
			get { return new DataSource2<BlockedDaysFranchiseeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CallCenterAgentTeamEntity instances in the database.</summary>
		public DataSource2<CallCenterAgentTeamEntity> CallCenterAgentTeam
		{
			get { return new DataSource2<CallCenterAgentTeamEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CallCenterAgentTeamLogEntity instances in the database.</summary>
		public DataSource2<CallCenterAgentTeamLogEntity> CallCenterAgentTeamLog
		{
			get { return new DataSource2<CallCenterAgentTeamLogEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CallCenterNotesEntity instances in the database.</summary>
		public DataSource2<CallCenterNotesEntity> CallCenterNotes
		{
			get { return new DataSource2<CallCenterNotesEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CallCenterRepProfileEntity instances in the database.</summary>
		public DataSource2<CallCenterRepProfileEntity> CallCenterRepProfile
		{
			get { return new DataSource2<CallCenterRepProfileEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CallCenterTeamEntity instances in the database.</summary>
		public DataSource2<CallCenterTeamEntity> CallCenterTeam
		{
			get { return new DataSource2<CallCenterTeamEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CallDetailsEntity instances in the database.</summary>
		public DataSource2<CallDetailsEntity> CallDetails
		{
			get { return new DataSource2<CallDetailsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CallQueueEntity instances in the database.</summary>
		public DataSource2<CallQueueEntity> CallQueue
		{
			get { return new DataSource2<CallQueueEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CallQueueAssignmentEntity instances in the database.</summary>
		public DataSource2<CallQueueAssignmentEntity> CallQueueAssignment
		{
			get { return new DataSource2<CallQueueAssignmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CallQueueCriteriaEntity instances in the database.</summary>
		public DataSource2<CallQueueCriteriaEntity> CallQueueCriteria
		{
			get { return new DataSource2<CallQueueCriteriaEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CallQueueCustomerEntity instances in the database.</summary>
		public DataSource2<CallQueueCustomerEntity> CallQueueCustomer
		{
			get { return new DataSource2<CallQueueCustomerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CallQueueCustomerCallEntity instances in the database.</summary>
		public DataSource2<CallQueueCustomerCallEntity> CallQueueCustomerCall
		{
			get { return new DataSource2<CallQueueCustomerCallEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CallQueueCustomerLockEntity instances in the database.</summary>
		public DataSource2<CallQueueCustomerLockEntity> CallQueueCustomerLock
		{
			get { return new DataSource2<CallQueueCustomerLockEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CallQueueCustomTagEntity instances in the database.</summary>
		public DataSource2<CallQueueCustomTagEntity> CallQueueCustomTag
		{
			get { return new DataSource2<CallQueueCustomTagEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CallRoundCallQueueEntity instances in the database.</summary>
		public DataSource2<CallRoundCallQueueEntity> CallRoundCallQueue
		{
			get { return new DataSource2<CallRoundCallQueueEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CallRoundCallQueueCriteriaAssignmentEntity instances in the database.</summary>
		public DataSource2<CallRoundCallQueueCriteriaAssignmentEntity> CallRoundCallQueueCriteriaAssignment
		{
			get { return new DataSource2<CallRoundCallQueueCriteriaAssignmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CallsEntity instances in the database.</summary>
		public DataSource2<CallsEntity> Calls
		{
			get { return new DataSource2<CallsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CallUploadEntity instances in the database.</summary>
		public DataSource2<CallUploadEntity> CallUpload
		{
			get { return new DataSource2<CallUploadEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CallUploadLogEntity instances in the database.</summary>
		public DataSource2<CallUploadLogEntity> CallUploadLog
		{
			get { return new DataSource2<CallUploadLogEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CampaignEntity instances in the database.</summary>
		public DataSource2<CampaignEntity> Campaign
		{
			get { return new DataSource2<CampaignEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CampaignActivityEntity instances in the database.</summary>
		public DataSource2<CampaignActivityEntity> CampaignActivity
		{
			get { return new DataSource2<CampaignActivityEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CampaignActivityAssignmentEntity instances in the database.</summary>
		public DataSource2<CampaignActivityAssignmentEntity> CampaignActivityAssignment
		{
			get { return new DataSource2<CampaignActivityAssignmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CampaignAssignmentEntity instances in the database.</summary>
		public DataSource2<CampaignAssignmentEntity> CampaignAssignment
		{
			get { return new DataSource2<CampaignAssignmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CampaignTagEntity instances in the database.</summary>
		public DataSource2<CampaignTagEntity> CampaignTag
		{
			get { return new DataSource2<CampaignTagEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CampaignTagMappingEntity instances in the database.</summary>
		public DataSource2<CampaignTagMappingEntity> CampaignTagMapping
		{
			get { return new DataSource2<CampaignTagMappingEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CareCodingOutboundEntity instances in the database.</summary>
		public DataSource2<CareCodingOutboundEntity> CareCodingOutbound
		{
			get { return new DataSource2<CareCodingOutboundEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CarrierEntity instances in the database.</summary>
		public DataSource2<CarrierEntity> Carrier
		{
			get { return new DataSource2<CarrierEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CashPaymentEntity instances in the database.</summary>
		public DataSource2<CashPaymentEntity> CashPayment
		{
			get { return new DataSource2<CashPaymentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CategoriesEntity instances in the database.</summary>
		public DataSource2<CategoriesEntity> Categories
		{
			get { return new DataSource2<CategoriesEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CdcontentGeneratorTrackingEntity instances in the database.</summary>
		public DataSource2<CdcontentGeneratorTrackingEntity> CdcontentGeneratorTracking
		{
			get { return new DataSource2<CdcontentGeneratorTrackingEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ChaperoneAnswerEntity instances in the database.</summary>
		public DataSource2<ChaperoneAnswerEntity> ChaperoneAnswer
		{
			get { return new DataSource2<ChaperoneAnswerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ChaperoneQuestionEntity instances in the database.</summary>
		public DataSource2<ChaperoneQuestionEntity> ChaperoneQuestion
		{
			get { return new DataSource2<ChaperoneQuestionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ChaperoneSignatureEntity instances in the database.</summary>
		public DataSource2<ChaperoneSignatureEntity> ChaperoneSignature
		{
			get { return new DataSource2<ChaperoneSignatureEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ChargeCardEntity instances in the database.</summary>
		public DataSource2<ChargeCardEntity> ChargeCard
		{
			get { return new DataSource2<ChargeCardEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ChargeCardPaymentEntity instances in the database.</summary>
		public DataSource2<ChargeCardPaymentEntity> ChargeCardPayment
		{
			get { return new DataSource2<ChargeCardPaymentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ChaseCampaignEntity instances in the database.</summary>
		public DataSource2<ChaseCampaignEntity> ChaseCampaign
		{
			get { return new DataSource2<ChaseCampaignEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ChaseCampaignTypeEntity instances in the database.</summary>
		public DataSource2<ChaseCampaignTypeEntity> ChaseCampaignType
		{
			get { return new DataSource2<ChaseCampaignTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ChaseChannelLevelEntity instances in the database.</summary>
		public DataSource2<ChaseChannelLevelEntity> ChaseChannelLevel
		{
			get { return new DataSource2<ChaseChannelLevelEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ChaseGroupEntity instances in the database.</summary>
		public DataSource2<ChaseGroupEntity> ChaseGroup
		{
			get { return new DataSource2<ChaseGroupEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ChaseOutboundEntity instances in the database.</summary>
		public DataSource2<ChaseOutboundEntity> ChaseOutbound
		{
			get { return new DataSource2<ChaseOutboundEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ChaseProductEntity instances in the database.</summary>
		public DataSource2<ChaseProductEntity> ChaseProduct
		{
			get { return new DataSource2<ChaseProductEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CheckEntity instances in the database.</summary>
		public DataSource2<CheckEntity> Check
		{
			get { return new DataSource2<CheckEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CheckListAnswerEntity instances in the database.</summary>
		public DataSource2<CheckListAnswerEntity> CheckListAnswer
		{
			get { return new DataSource2<CheckListAnswerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CheckListGroupEntity instances in the database.</summary>
		public DataSource2<CheckListGroupEntity> CheckListGroup
		{
			get { return new DataSource2<CheckListGroupEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ChecklistGroupQuestionEntity instances in the database.</summary>
		public DataSource2<ChecklistGroupQuestionEntity> ChecklistGroupQuestion
		{
			get { return new DataSource2<ChecklistGroupQuestionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CheckListQuestionEntity instances in the database.</summary>
		public DataSource2<CheckListQuestionEntity> CheckListQuestion
		{
			get { return new DataSource2<CheckListQuestionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CheckListTemplateEntity instances in the database.</summary>
		public DataSource2<CheckListTemplateEntity> CheckListTemplate
		{
			get { return new DataSource2<CheckListTemplateEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CheckListTemplateQuestionEntity instances in the database.</summary>
		public DataSource2<CheckListTemplateQuestionEntity> CheckListTemplateQuestion
		{
			get { return new DataSource2<CheckListTemplateQuestionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CheckPaymentEntity instances in the database.</summary>
		public DataSource2<CheckPaymentEntity> CheckPayment
		{
			get { return new DataSource2<CheckPaymentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CityEntity instances in the database.</summary>
		public DataSource2<CityEntity> City
		{
			get { return new DataSource2<CityEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ClaimEntity instances in the database.</summary>
		public DataSource2<ClaimEntity> Claim
		{
			get { return new DataSource2<ClaimEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ClickConversionEntity instances in the database.</summary>
		public DataSource2<ClickConversionEntity> ClickConversion
		{
			get { return new DataSource2<ClickConversionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ClickKeywordEntity instances in the database.</summary>
		public DataSource2<ClickKeywordEntity> ClickKeyword
		{
			get { return new DataSource2<ClickKeywordEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ClickLogEntity instances in the database.</summary>
		public DataSource2<ClickLogEntity> ClickLog
		{
			get { return new DataSource2<ClickLogEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ClientEntity instances in the database.</summary>
		public DataSource2<ClientEntity> Client
		{
			get { return new DataSource2<ClientEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ClinicalTestQualificationCriteriaEntity instances in the database.</summary>
		public DataSource2<ClinicalTestQualificationCriteriaEntity> ClinicalTestQualificationCriteria
		{
			get { return new DataSource2<ClinicalTestQualificationCriteriaEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CommunicationModeEntity instances in the database.</summary>
		public DataSource2<CommunicationModeEntity> CommunicationMode
		{
			get { return new DataSource2<CommunicationModeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ContactCallEntity instances in the database.</summary>
		public DataSource2<ContactCallEntity> ContactCall
		{
			get { return new DataSource2<ContactCallEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ContactCallStatusEntity instances in the database.</summary>
		public DataSource2<ContactCallStatusEntity> ContactCallStatus
		{
			get { return new DataSource2<ContactCallStatusEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ContactFranchiseeAccessEntity instances in the database.</summary>
		public DataSource2<ContactFranchiseeAccessEntity> ContactFranchiseeAccess
		{
			get { return new DataSource2<ContactFranchiseeAccessEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ContactMeetingEntity instances in the database.</summary>
		public DataSource2<ContactMeetingEntity> ContactMeeting
		{
			get { return new DataSource2<ContactMeetingEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ContactNotesEntity instances in the database.</summary>
		public DataSource2<ContactNotesEntity> ContactNotes
		{
			get { return new DataSource2<ContactNotesEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ContactsEntity instances in the database.</summary>
		public DataSource2<ContactsEntity> Contacts
		{
			get { return new DataSource2<ContactsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ContactTypeEntity instances in the database.</summary>
		public DataSource2<ContactTypeEntity> ContactType
		{
			get { return new DataSource2<ContactTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ContentEntity instances in the database.</summary>
		public DataSource2<ContentEntity> Content
		{
			get { return new DataSource2<ContentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ContractEntity instances in the database.</summary>
		public DataSource2<ContractEntity> Contract
		{
			get { return new DataSource2<ContractEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CorporateShippingOptionEntity instances in the database.</summary>
		public DataSource2<CorporateShippingOptionEntity> CorporateShippingOption
		{
			get { return new DataSource2<CorporateShippingOptionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CorporateTagEntity instances in the database.</summary>
		public DataSource2<CorporateTagEntity> CorporateTag
		{
			get { return new DataSource2<CorporateTagEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CorporateUploadEntity instances in the database.</summary>
		public DataSource2<CorporateUploadEntity> CorporateUpload
		{
			get { return new DataSource2<CorporateUploadEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CountryEntity instances in the database.</summary>
		public DataSource2<CountryEntity> Country
		{
			get { return new DataSource2<CountryEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CouponsEntity instances in the database.</summary>
		public DataSource2<CouponsEntity> Coupons
		{
			get { return new DataSource2<CouponsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CouponSignUpModeEntity instances in the database.</summary>
		public DataSource2<CouponSignUpModeEntity> CouponSignUpMode
		{
			get { return new DataSource2<CouponSignUpModeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CouponTypeEntity instances in the database.</summary>
		public DataSource2<CouponTypeEntity> CouponType
		{
			get { return new DataSource2<CouponTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CreditCardTypeEntity instances in the database.</summary>
		public DataSource2<CreditCardTypeEntity> CreditCardType
		{
			get { return new DataSource2<CreditCardTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CriteriaEntity instances in the database.</summary>
		public DataSource2<CriteriaEntity> Criteria
		{
			get { return new DataSource2<CriteriaEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CriticalCustomerCommunicationRecordEntity instances in the database.</summary>
		public DataSource2<CriticalCustomerCommunicationRecordEntity> CriticalCustomerCommunicationRecord
		{
			get { return new DataSource2<CriticalCustomerCommunicationRecordEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CriticalQuestionEntity instances in the database.</summary>
		public DataSource2<CriticalQuestionEntity> CriticalQuestion
		{
			get { return new DataSource2<CriticalQuestionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CurrentMedicationEntity instances in the database.</summary>
		public DataSource2<CurrentMedicationEntity> CurrentMedication
		{
			get { return new DataSource2<CurrentMedicationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomCampaignContentEntity instances in the database.</summary>
		public DataSource2<CustomCampaignContentEntity> CustomCampaignContent
		{
			get { return new DataSource2<CustomCampaignContentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerAccountGlocomNumberEntity instances in the database.</summary>
		public DataSource2<CustomerAccountGlocomNumberEntity> CustomerAccountGlocomNumber
		{
			get { return new DataSource2<CustomerAccountGlocomNumberEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerActivityTypeUploadEntity instances in the database.</summary>
		public DataSource2<CustomerActivityTypeUploadEntity> CustomerActivityTypeUpload
		{
			get { return new DataSource2<CustomerActivityTypeUploadEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerBillingAccountEntity instances in the database.</summary>
		public DataSource2<CustomerBillingAccountEntity> CustomerBillingAccount
		{
			get { return new DataSource2<CustomerBillingAccountEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerCallAttemptsEntity instances in the database.</summary>
		public DataSource2<CustomerCallAttemptsEntity> CustomerCallAttempts
		{
			get { return new DataSource2<CustomerCallAttemptsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerCallQueueCallAttemptEntity instances in the database.</summary>
		public DataSource2<CustomerCallQueueCallAttemptEntity> CustomerCallQueueCallAttempt
		{
			get { return new DataSource2<CustomerCallQueueCallAttemptEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerChaseCampaignEntity instances in the database.</summary>
		public DataSource2<CustomerChaseCampaignEntity> CustomerChaseCampaign
		{
			get { return new DataSource2<CustomerChaseCampaignEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerChaseChannelEntity instances in the database.</summary>
		public DataSource2<CustomerChaseChannelEntity> CustomerChaseChannel
		{
			get { return new DataSource2<CustomerChaseChannelEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerChaseProductEntity instances in the database.</summary>
		public DataSource2<CustomerChaseProductEntity> CustomerChaseProduct
		{
			get { return new DataSource2<CustomerChaseProductEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerClinicalQuestionAnswerEntity instances in the database.</summary>
		public DataSource2<CustomerClinicalQuestionAnswerEntity> CustomerClinicalQuestionAnswer
		{
			get { return new DataSource2<CustomerClinicalQuestionAnswerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerEligibilityEntity instances in the database.</summary>
		public DataSource2<CustomerEligibilityEntity> CustomerEligibility
		{
			get { return new DataSource2<CustomerEligibilityEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerEventCriticalTestDataEntity instances in the database.</summary>
		public DataSource2<CustomerEventCriticalTestDataEntity> CustomerEventCriticalTestData
		{
			get { return new DataSource2<CustomerEventCriticalTestDataEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerEventPriorityInQueueDataEntity instances in the database.</summary>
		public DataSource2<CustomerEventPriorityInQueueDataEntity> CustomerEventPriorityInQueueData
		{
			get { return new DataSource2<CustomerEventPriorityInQueueDataEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerEventReadingEntity instances in the database.</summary>
		public DataSource2<CustomerEventReadingEntity> CustomerEventReading
		{
			get { return new DataSource2<CustomerEventReadingEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerEventScreeningTestsEntity instances in the database.</summary>
		public DataSource2<CustomerEventScreeningTestsEntity> CustomerEventScreeningTests
		{
			get { return new DataSource2<CustomerEventScreeningTestsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerEventTestFindingEntity instances in the database.</summary>
		public DataSource2<CustomerEventTestFindingEntity> CustomerEventTestFinding
		{
			get { return new DataSource2<CustomerEventTestFindingEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerEventTestIncidentalFindingEntity instances in the database.</summary>
		public DataSource2<CustomerEventTestIncidentalFindingEntity> CustomerEventTestIncidentalFinding
		{
			get { return new DataSource2<CustomerEventTestIncidentalFindingEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerEventTestIncidentalFindingDetailEntity instances in the database.</summary>
		public DataSource2<CustomerEventTestIncidentalFindingDetailEntity> CustomerEventTestIncidentalFindingDetail
		{
			get { return new DataSource2<CustomerEventTestIncidentalFindingDetailEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerEventTestPhysicianEvaluationEntity instances in the database.</summary>
		public DataSource2<CustomerEventTestPhysicianEvaluationEntity> CustomerEventTestPhysicianEvaluation
		{
			get { return new DataSource2<CustomerEventTestPhysicianEvaluationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerEventTestPhysicianNoteEntity instances in the database.</summary>
		public DataSource2<CustomerEventTestPhysicianNoteEntity> CustomerEventTestPhysicianNote
		{
			get { return new DataSource2<CustomerEventTestPhysicianNoteEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerEventTestStandardFindingEntity instances in the database.</summary>
		public DataSource2<CustomerEventTestStandardFindingEntity> CustomerEventTestStandardFinding
		{
			get { return new DataSource2<CustomerEventTestStandardFindingEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerEventTestStateEntity instances in the database.</summary>
		public DataSource2<CustomerEventTestStateEntity> CustomerEventTestState
		{
			get { return new DataSource2<CustomerEventTestStateEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerEventUnableScreenReasonEntity instances in the database.</summary>
		public DataSource2<CustomerEventUnableScreenReasonEntity> CustomerEventUnableScreenReason
		{
			get { return new DataSource2<CustomerEventUnableScreenReasonEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerHealthInfoEntity instances in the database.</summary>
		public DataSource2<CustomerHealthInfoEntity> CustomerHealthInfo
		{
			get { return new DataSource2<CustomerHealthInfoEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerHealthInfoArchiveEntity instances in the database.</summary>
		public DataSource2<CustomerHealthInfoArchiveEntity> CustomerHealthInfoArchive
		{
			get { return new DataSource2<CustomerHealthInfoArchiveEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerHealthQuestionGroupEntity instances in the database.</summary>
		public DataSource2<CustomerHealthQuestionGroupEntity> CustomerHealthQuestionGroup
		{
			get { return new DataSource2<CustomerHealthQuestionGroupEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerHealthQuestionsEntity instances in the database.</summary>
		public DataSource2<CustomerHealthQuestionsEntity> CustomerHealthQuestions
		{
			get { return new DataSource2<CustomerHealthQuestionsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerIcdCodeEntity instances in the database.</summary>
		public DataSource2<CustomerIcdCodeEntity> CustomerIcdCode
		{
			get { return new DataSource2<CustomerIcdCodeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerLockForCallEntity instances in the database.</summary>
		public DataSource2<CustomerLockForCallEntity> CustomerLockForCall
		{
			get { return new DataSource2<CustomerLockForCallEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerMedicareQuestionAnswerEntity instances in the database.</summary>
		public DataSource2<CustomerMedicareQuestionAnswerEntity> CustomerMedicareQuestionAnswer
		{
			get { return new DataSource2<CustomerMedicareQuestionAnswerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerOrderHistoryEntity instances in the database.</summary>
		public DataSource2<CustomerOrderHistoryEntity> CustomerOrderHistory
		{
			get { return new DataSource2<CustomerOrderHistoryEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerPhoneNumberUpdateUploadEntity instances in the database.</summary>
		public DataSource2<CustomerPhoneNumberUpdateUploadEntity> CustomerPhoneNumberUpdateUpload
		{
			get { return new DataSource2<CustomerPhoneNumberUpdateUploadEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerPhoneNumberUpdateUploadLogEntity instances in the database.</summary>
		public DataSource2<CustomerPhoneNumberUpdateUploadLogEntity> CustomerPhoneNumberUpdateUploadLog
		{
			get { return new DataSource2<CustomerPhoneNumberUpdateUploadLogEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerPredictedZipEntity instances in the database.</summary>
		public DataSource2<CustomerPredictedZipEntity> CustomerPredictedZip
		{
			get { return new DataSource2<CustomerPredictedZipEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerPrimaryCarePhysicianEntity instances in the database.</summary>
		public DataSource2<CustomerPrimaryCarePhysicianEntity> CustomerPrimaryCarePhysician
		{
			get { return new DataSource2<CustomerPrimaryCarePhysicianEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerProfileEntity instances in the database.</summary>
		public DataSource2<CustomerProfileEntity> CustomerProfile
		{
			get { return new DataSource2<CustomerProfileEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerProfileHistoryEntity instances in the database.</summary>
		public DataSource2<CustomerProfileHistoryEntity> CustomerProfileHistory
		{
			get { return new DataSource2<CustomerProfileHistoryEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerRegistrationNotesEntity instances in the database.</summary>
		public DataSource2<CustomerRegistrationNotesEntity> CustomerRegistrationNotes
		{
			get { return new DataSource2<CustomerRegistrationNotesEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerResultPostedEntity instances in the database.</summary>
		public DataSource2<CustomerResultPostedEntity> CustomerResultPosted
		{
			get { return new DataSource2<CustomerResultPostedEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerResultScreeningCommunicationEntity instances in the database.</summary>
		public DataSource2<CustomerResultScreeningCommunicationEntity> CustomerResultScreeningCommunication
		{
			get { return new DataSource2<CustomerResultScreeningCommunicationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerSkipReviewEntity instances in the database.</summary>
		public DataSource2<CustomerSkipReviewEntity> CustomerSkipReview
		{
			get { return new DataSource2<CustomerSkipReviewEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerSurveyEntity instances in the database.</summary>
		public DataSource2<CustomerSurveyEntity> CustomerSurvey
		{
			get { return new DataSource2<CustomerSurveyEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerSurveyQuestionEntity instances in the database.</summary>
		public DataSource2<CustomerSurveyQuestionEntity> CustomerSurveyQuestion
		{
			get { return new DataSource2<CustomerSurveyQuestionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerSurveyQuestionAnswerEntity instances in the database.</summary>
		public DataSource2<CustomerSurveyQuestionAnswerEntity> CustomerSurveyQuestionAnswer
		{
			get { return new DataSource2<CustomerSurveyQuestionAnswerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerTagEntity instances in the database.</summary>
		public DataSource2<CustomerTagEntity> CustomerTag
		{
			get { return new DataSource2<CustomerTagEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerTargetedEntity instances in the database.</summary>
		public DataSource2<CustomerTargetedEntity> CustomerTargeted
		{
			get { return new DataSource2<CustomerTargetedEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerTraleEntity instances in the database.</summary>
		public DataSource2<CustomerTraleEntity> CustomerTrale
		{
			get { return new DataSource2<CustomerTraleEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerUnsubscribedSmsNotificationEntity instances in the database.</summary>
		public DataSource2<CustomerUnsubscribedSmsNotificationEntity> CustomerUnsubscribedSmsNotification
		{
			get { return new DataSource2<CustomerUnsubscribedSmsNotificationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomerWarmTransferEntity instances in the database.</summary>
		public DataSource2<CustomerWarmTransferEntity> CustomerWarmTransfer
		{
			get { return new DataSource2<CustomerWarmTransferEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CustomEventNotificationEntity instances in the database.</summary>
		public DataSource2<CustomEventNotificationEntity> CustomEventNotification
		{
			get { return new DataSource2<CustomEventNotificationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting DemandDraftPaymentDetailsEntity instances in the database.</summary>
		public DataSource2<DemandDraftPaymentDetailsEntity> DemandDraftPaymentDetails
		{
			get { return new DataSource2<DemandDraftPaymentDetailsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting DependentDisqualifiedTestEntity instances in the database.</summary>
		public DataSource2<DependentDisqualifiedTestEntity> DependentDisqualifiedTest
		{
			get { return new DataSource2<DependentDisqualifiedTestEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting DiabeticRetinopathyParserlogEntity instances in the database.</summary>
		public DataSource2<DiabeticRetinopathyParserlogEntity> DiabeticRetinopathyParserlog
		{
			get { return new DataSource2<DiabeticRetinopathyParserlogEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting DigitalAssetAccessLogEntity instances in the database.</summary>
		public DataSource2<DigitalAssetAccessLogEntity> DigitalAssetAccessLog
		{
			get { return new DataSource2<DigitalAssetAccessLogEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting DirectMailEntity instances in the database.</summary>
		public DataSource2<DirectMailEntity> DirectMail
		{
			get { return new DataSource2<DirectMailEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting DirectMailTypeEntity instances in the database.</summary>
		public DataSource2<DirectMailTypeEntity> DirectMailType
		{
			get { return new DataSource2<DirectMailTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting DisqualifiedTestEntity instances in the database.</summary>
		public DataSource2<DisqualifiedTestEntity> DisqualifiedTest
		{
			get { return new DataSource2<DisqualifiedTestEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EcheckPaymentEntity instances in the database.</summary>
		public DataSource2<EcheckPaymentEntity> EcheckPayment
		{
			get { return new DataSource2<EcheckPaymentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EligibilityEntity instances in the database.</summary>
		public DataSource2<EligibilityEntity> Eligibility
		{
			get { return new DataSource2<EligibilityEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EligibilityUploadEntity instances in the database.</summary>
		public DataSource2<EligibilityUploadEntity> EligibilityUpload
		{
			get { return new DataSource2<EligibilityUploadEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EmailTemplateEntity instances in the database.</summary>
		public DataSource2<EmailTemplateEntity> EmailTemplate
		{
			get { return new DataSource2<EmailTemplateEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EmailTemplateMacroEntity instances in the database.</summary>
		public DataSource2<EmailTemplateMacroEntity> EmailTemplateMacro
		{
			get { return new DataSource2<EmailTemplateMacroEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EncounterEntity instances in the database.</summary>
		public DataSource2<EncounterEntity> Encounter
		{
			get { return new DataSource2<EncounterEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventAccountEntity instances in the database.</summary>
		public DataSource2<EventAccountEntity> EventAccount
		{
			get { return new DataSource2<EventAccountEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventAccountTestHcpcsCodeEntity instances in the database.</summary>
		public DataSource2<EventAccountTestHcpcsCodeEntity> EventAccountTestHcpcsCode
		{
			get { return new DataSource2<EventAccountTestHcpcsCodeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventActivityTemplateEntity instances in the database.</summary>
		public DataSource2<EventActivityTemplateEntity> EventActivityTemplate
		{
			get { return new DataSource2<EventActivityTemplateEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventActivityTemplateCallEntity instances in the database.</summary>
		public DataSource2<EventActivityTemplateCallEntity> EventActivityTemplateCall
		{
			get { return new DataSource2<EventActivityTemplateCallEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventActivityTemplateEmailEntity instances in the database.</summary>
		public DataSource2<EventActivityTemplateEmailEntity> EventActivityTemplateEmail
		{
			get { return new DataSource2<EventActivityTemplateEmailEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventActivityTemplateHostEntity instances in the database.</summary>
		public DataSource2<EventActivityTemplateHostEntity> EventActivityTemplateHost
		{
			get { return new DataSource2<EventActivityTemplateHostEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventActivityTemplateMeetingEntity instances in the database.</summary>
		public DataSource2<EventActivityTemplateMeetingEntity> EventActivityTemplateMeeting
		{
			get { return new DataSource2<EventActivityTemplateMeetingEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventActivityTemplateTaskEntity instances in the database.</summary>
		public DataSource2<EventActivityTemplateTaskEntity> EventActivityTemplateTask
		{
			get { return new DataSource2<EventActivityTemplateTaskEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventAffiliateDetailsEntity instances in the database.</summary>
		public DataSource2<EventAffiliateDetailsEntity> EventAffiliateDetails
		{
			get { return new DataSource2<EventAffiliateDetailsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventAppointmentEntity instances in the database.</summary>
		public DataSource2<EventAppointmentEntity> EventAppointment
		{
			get { return new DataSource2<EventAppointmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventAppointmentCancellationLogEntity instances in the database.</summary>
		public DataSource2<EventAppointmentCancellationLogEntity> EventAppointmentCancellationLog
		{
			get { return new DataSource2<EventAppointmentCancellationLogEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventAppointmentChangeLogEntity instances in the database.</summary>
		public DataSource2<EventAppointmentChangeLogEntity> EventAppointmentChangeLog
		{
			get { return new DataSource2<EventAppointmentChangeLogEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCallDetailsEntity instances in the database.</summary>
		public DataSource2<EventCallDetailsEntity> EventCallDetails
		{
			get { return new DataSource2<EventCallDetailsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCampaignDetailsEntity instances in the database.</summary>
		public DataSource2<EventCampaignDetailsEntity> EventCampaignDetails
		{
			get { return new DataSource2<EventCampaignDetailsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventChecklistTemplateEntity instances in the database.</summary>
		public DataSource2<EventChecklistTemplateEntity> EventChecklistTemplate
		{
			get { return new DataSource2<EventChecklistTemplateEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCouponsEntity instances in the database.</summary>
		public DataSource2<EventCouponsEntity> EventCoupons
		{
			get { return new DataSource2<EventCouponsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerBarrierEntity instances in the database.</summary>
		public DataSource2<EventCustomerBarrierEntity> EventCustomerBarrier
		{
			get { return new DataSource2<EventCustomerBarrierEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerBasicBioMetricEntity instances in the database.</summary>
		public DataSource2<EventCustomerBasicBioMetricEntity> EventCustomerBasicBioMetric
		{
			get { return new DataSource2<EventCustomerBasicBioMetricEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerCriticalQuestionEntity instances in the database.</summary>
		public DataSource2<EventCustomerCriticalQuestionEntity> EventCustomerCriticalQuestion
		{
			get { return new DataSource2<EventCustomerCriticalQuestionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerCurrentMedicationEntity instances in the database.</summary>
		public DataSource2<EventCustomerCurrentMedicationEntity> EventCustomerCurrentMedication
		{
			get { return new DataSource2<EventCustomerCurrentMedicationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerCustomNotificationEntity instances in the database.</summary>
		public DataSource2<EventCustomerCustomNotificationEntity> EventCustomerCustomNotification
		{
			get { return new DataSource2<EventCustomerCustomNotificationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerDiagnosisEntity instances in the database.</summary>
		public DataSource2<EventCustomerDiagnosisEntity> EventCustomerDiagnosis
		{
			get { return new DataSource2<EventCustomerDiagnosisEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerEligibilityEntity instances in the database.</summary>
		public DataSource2<EventCustomerEligibilityEntity> EventCustomerEligibility
		{
			get { return new DataSource2<EventCustomerEligibilityEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerEncounterEntity instances in the database.</summary>
		public DataSource2<EventCustomerEncounterEntity> EventCustomerEncounter
		{
			get { return new DataSource2<EventCustomerEncounterEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerEvaluationLockEntity instances in the database.</summary>
		public DataSource2<EventCustomerEvaluationLockEntity> EventCustomerEvaluationLock
		{
			get { return new DataSource2<EventCustomerEvaluationLockEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerGiftCardEntity instances in the database.</summary>
		public DataSource2<EventCustomerGiftCardEntity> EventCustomerGiftCard
		{
			get { return new DataSource2<EventCustomerGiftCardEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerIcdCodesEntity instances in the database.</summary>
		public DataSource2<EventCustomerIcdCodesEntity> EventCustomerIcdCodes
		{
			get { return new DataSource2<EventCustomerIcdCodesEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerNotificationEntity instances in the database.</summary>
		public DataSource2<EventCustomerNotificationEntity> EventCustomerNotification
		{
			get { return new DataSource2<EventCustomerNotificationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerOrderDetailEntity instances in the database.</summary>
		public DataSource2<EventCustomerOrderDetailEntity> EventCustomerOrderDetail
		{
			get { return new DataSource2<EventCustomerOrderDetailEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerPaymentEntity instances in the database.</summary>
		public DataSource2<EventCustomerPaymentEntity> EventCustomerPayment
		{
			get { return new DataSource2<EventCustomerPaymentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerPdfgenerationErrorLogEntity instances in the database.</summary>
		public DataSource2<EventCustomerPdfgenerationErrorLogEntity> EventCustomerPdfgenerationErrorLog
		{
			get { return new DataSource2<EventCustomerPdfgenerationErrorLogEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerPreApprovedPackageTestEntity instances in the database.</summary>
		public DataSource2<EventCustomerPreApprovedPackageTestEntity> EventCustomerPreApprovedPackageTest
		{
			get { return new DataSource2<EventCustomerPreApprovedPackageTestEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerPreApprovedTestEntity instances in the database.</summary>
		public DataSource2<EventCustomerPreApprovedTestEntity> EventCustomerPreApprovedTest
		{
			get { return new DataSource2<EventCustomerPreApprovedTestEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerPrimaryCarePhysicianEntity instances in the database.</summary>
		public DataSource2<EventCustomerPrimaryCarePhysicianEntity> EventCustomerPrimaryCarePhysician
		{
			get { return new DataSource2<EventCustomerPrimaryCarePhysicianEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerQuestionAnswerEntity instances in the database.</summary>
		public DataSource2<EventCustomerQuestionAnswerEntity> EventCustomerQuestionAnswer
		{
			get { return new DataSource2<EventCustomerQuestionAnswerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerRequiredTestEntity instances in the database.</summary>
		public DataSource2<EventCustomerRequiredTestEntity> EventCustomerRequiredTest
		{
			get { return new DataSource2<EventCustomerRequiredTestEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerResultEntity instances in the database.</summary>
		public DataSource2<EventCustomerResultEntity> EventCustomerResult
		{
			get { return new DataSource2<EventCustomerResultEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerResultBloodLabEntity instances in the database.</summary>
		public DataSource2<EventCustomerResultBloodLabEntity> EventCustomerResultBloodLab
		{
			get { return new DataSource2<EventCustomerResultBloodLabEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerResultBloodLabParserEntity instances in the database.</summary>
		public DataSource2<EventCustomerResultBloodLabParserEntity> EventCustomerResultBloodLabParser
		{
			get { return new DataSource2<EventCustomerResultBloodLabParserEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerResultHistoryEntity instances in the database.</summary>
		public DataSource2<EventCustomerResultHistoryEntity> EventCustomerResultHistory
		{
			get { return new DataSource2<EventCustomerResultHistoryEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerResultTraleEntity instances in the database.</summary>
		public DataSource2<EventCustomerResultTraleEntity> EventCustomerResultTrale
		{
			get { return new DataSource2<EventCustomerResultTraleEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerRetestEntity instances in the database.</summary>
		public DataSource2<EventCustomerRetestEntity> EventCustomerRetest
		{
			get { return new DataSource2<EventCustomerRetestEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomersEntity instances in the database.</summary>
		public DataSource2<EventCustomersEntity> EventCustomers
		{
			get { return new DataSource2<EventCustomersEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventCustomerTestNotPerformedNotificationEntity instances in the database.</summary>
		public DataSource2<EventCustomerTestNotPerformedNotificationEntity> EventCustomerTestNotPerformedNotification
		{
			get { return new DataSource2<EventCustomerTestNotPerformedNotificationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventFluConsentTemplateEntity instances in the database.</summary>
		public DataSource2<EventFluConsentTemplateEntity> EventFluConsentTemplate
		{
			get { return new DataSource2<EventFluConsentTemplateEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventHospitalFacilityEntity instances in the database.</summary>
		public DataSource2<EventHospitalFacilityEntity> EventHospitalFacility
		{
			get { return new DataSource2<EventHospitalFacilityEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventHospitalPartnerEntity instances in the database.</summary>
		public DataSource2<EventHospitalPartnerEntity> EventHospitalPartner
		{
			get { return new DataSource2<EventHospitalPartnerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventHostPromotionsEntity instances in the database.</summary>
		public DataSource2<EventHostPromotionsEntity> EventHostPromotions
		{
			get { return new DataSource2<EventHostPromotionsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventMarketingOffersEntity instances in the database.</summary>
		public DataSource2<EventMarketingOffersEntity> EventMarketingOffers
		{
			get { return new DataSource2<EventMarketingOffersEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventMeetingDetailsEntity instances in the database.</summary>
		public DataSource2<EventMeetingDetailsEntity> EventMeetingDetails
		{
			get { return new DataSource2<EventMeetingDetailsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventNoteEntity instances in the database.</summary>
		public DataSource2<EventNoteEntity> EventNote
		{
			get { return new DataSource2<EventNoteEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventNotesLogEntity instances in the database.</summary>
		public DataSource2<EventNotesLogEntity> EventNotesLog
		{
			get { return new DataSource2<EventNotesLogEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventNotificationEntity instances in the database.</summary>
		public DataSource2<EventNotificationEntity> EventNotification
		{
			get { return new DataSource2<EventNotificationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventPackageDetailsEntity instances in the database.</summary>
		public DataSource2<EventPackageDetailsEntity> EventPackageDetails
		{
			get { return new DataSource2<EventPackageDetailsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventPackageOrderItemEntity instances in the database.</summary>
		public DataSource2<EventPackageOrderItemEntity> EventPackageOrderItem
		{
			get { return new DataSource2<EventPackageOrderItemEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventPackageTestEntity instances in the database.</summary>
		public DataSource2<EventPackageTestEntity> EventPackageTest
		{
			get { return new DataSource2<EventPackageTestEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventPaymentDetailsEntity instances in the database.</summary>
		public DataSource2<EventPaymentDetailsEntity> EventPaymentDetails
		{
			get { return new DataSource2<EventPaymentDetailsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventPerformanceMailStatusEntity instances in the database.</summary>
		public DataSource2<EventPerformanceMailStatusEntity> EventPerformanceMailStatus
		{
			get { return new DataSource2<EventPerformanceMailStatusEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventPhysicianTestEntity instances in the database.</summary>
		public DataSource2<EventPhysicianTestEntity> EventPhysicianTest
		{
			get { return new DataSource2<EventPhysicianTestEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventPodEntity instances in the database.</summary>
		public DataSource2<EventPodEntity> EventPod
		{
			get { return new DataSource2<EventPodEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventPodRoomEntity instances in the database.</summary>
		public DataSource2<EventPodRoomEntity> EventPodRoom
		{
			get { return new DataSource2<EventPodRoomEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventPodRoomTestEntity instances in the database.</summary>
		public DataSource2<EventPodRoomTestEntity> EventPodRoomTest
		{
			get { return new DataSource2<EventPodRoomTestEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventProductExclusionEntity instances in the database.</summary>
		public DataSource2<EventProductExclusionEntity> EventProductExclusion
		{
			get { return new DataSource2<EventProductExclusionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventProductTypeEntity instances in the database.</summary>
		public DataSource2<EventProductTypeEntity> EventProductType
		{
			get { return new DataSource2<EventProductTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventPublicationEntity instances in the database.</summary>
		public DataSource2<EventPublicationEntity> EventPublication
		{
			get { return new DataSource2<EventPublicationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventsEntity instances in the database.</summary>
		public DataSource2<EventsEntity> Events
		{
			get { return new DataSource2<EventsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventScheduleTemplateEntity instances in the database.</summary>
		public DataSource2<EventScheduleTemplateEntity> EventScheduleTemplate
		{
			get { return new DataSource2<EventScheduleTemplateEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventSchedulingSlotEntity instances in the database.</summary>
		public DataSource2<EventSchedulingSlotEntity> EventSchedulingSlot
		{
			get { return new DataSource2<EventSchedulingSlotEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventSlotAppointmentEntity instances in the database.</summary>
		public DataSource2<EventSlotAppointmentEntity> EventSlotAppointment
		{
			get { return new DataSource2<EventSlotAppointmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventStaffAssignmentEntity instances in the database.</summary>
		public DataSource2<EventStaffAssignmentEntity> EventStaffAssignment
		{
			get { return new DataSource2<EventStaffAssignmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventSurveyTemplateEntity instances in the database.</summary>
		public DataSource2<EventSurveyTemplateEntity> EventSurveyTemplate
		{
			get { return new DataSource2<EventSurveyTemplateEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventTaskDetailsEntity instances in the database.</summary>
		public DataSource2<EventTaskDetailsEntity> EventTaskDetails
		{
			get { return new DataSource2<EventTaskDetailsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventTestEntity instances in the database.</summary>
		public DataSource2<EventTestEntity> EventTest
		{
			get { return new DataSource2<EventTestEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventTestOrderItemEntity instances in the database.</summary>
		public DataSource2<EventTestOrderItemEntity> EventTestOrderItem
		{
			get { return new DataSource2<EventTestOrderItemEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventTypeEntity instances in the database.</summary>
		public DataSource2<EventTypeEntity> EventType
		{
			get { return new DataSource2<EventTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventZipEntity instances in the database.</summary>
		public DataSource2<EventZipEntity> EventZip
		{
			get { return new DataSource2<EventZipEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventZipProductTypeEntity instances in the database.</summary>
		public DataSource2<EventZipProductTypeEntity> EventZipProductType
		{
			get { return new DataSource2<EventZipProductTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EventZipProductTypeSubstituteEntity instances in the database.</summary>
		public DataSource2<EventZipProductTypeSubstituteEntity> EventZipProductTypeSubstitute
		{
			get { return new DataSource2<EventZipProductTypeSubstituteEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ExitInterviewAnswerEntity instances in the database.</summary>
		public DataSource2<ExitInterviewAnswerEntity> ExitInterviewAnswer
		{
			get { return new DataSource2<ExitInterviewAnswerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ExitInterviewQuestionEntity instances in the database.</summary>
		public DataSource2<ExitInterviewQuestionEntity> ExitInterviewQuestion
		{
			get { return new DataSource2<ExitInterviewQuestionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ExitInterviewSignatureEntity instances in the database.</summary>
		public DataSource2<ExitInterviewSignatureEntity> ExitInterviewSignature
		{
			get { return new DataSource2<ExitInterviewSignatureEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ExportableReportsEntity instances in the database.</summary>
		public DataSource2<ExportableReportsEntity> ExportableReports
		{
			get { return new DataSource2<ExportableReportsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ExportableReportsQueueEntity instances in the database.</summary>
		public DataSource2<ExportableReportsQueueEntity> ExportableReportsQueue
		{
			get { return new DataSource2<ExportableReportsQueueEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting FileEntity instances in the database.</summary>
		public DataSource2<FileEntity> File
		{
			get { return new DataSource2<FileEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting FillEventCallQueueEntity instances in the database.</summary>
		public DataSource2<FillEventCallQueueEntity> FillEventCallQueue
		{
			get { return new DataSource2<FillEventCallQueueEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting FillEventCallQueueCriteriaAssignmentEntity instances in the database.</summary>
		public DataSource2<FillEventCallQueueCriteriaAssignmentEntity> FillEventCallQueueCriteriaAssignment
		{
			get { return new DataSource2<FillEventCallQueueCriteriaAssignmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting FluConsentAnswerEntity instances in the database.</summary>
		public DataSource2<FluConsentAnswerEntity> FluConsentAnswer
		{
			get { return new DataSource2<FluConsentAnswerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting FluConsentQuestionEntity instances in the database.</summary>
		public DataSource2<FluConsentQuestionEntity> FluConsentQuestion
		{
			get { return new DataSource2<FluConsentQuestionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting FluConsentSignatureEntity instances in the database.</summary>
		public DataSource2<FluConsentSignatureEntity> FluConsentSignature
		{
			get { return new DataSource2<FluConsentSignatureEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting FluConsentTemplateEntity instances in the database.</summary>
		public DataSource2<FluConsentTemplateEntity> FluConsentTemplate
		{
			get { return new DataSource2<FluConsentTemplateEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting FluConsentTemplateQuestionEntity instances in the database.</summary>
		public DataSource2<FluConsentTemplateQuestionEntity> FluConsentTemplateQuestion
		{
			get { return new DataSource2<FluConsentTemplateQuestionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting FraminghamCalculationSourceEntity instances in the database.</summary>
		public DataSource2<FraminghamCalculationSourceEntity> FraminghamCalculationSource
		{
			get { return new DataSource2<FraminghamCalculationSourceEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting FraminghamScoreRangeEntity instances in the database.</summary>
		public DataSource2<FraminghamScoreRangeEntity> FraminghamScoreRange
		{
			get { return new DataSource2<FraminghamScoreRangeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting FranchiseeApplicationEntity instances in the database.</summary>
		public DataSource2<FranchiseeApplicationEntity> FranchiseeApplication
		{
			get { return new DataSource2<FranchiseeApplicationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting FranchiseeTerritoryEntity instances in the database.</summary>
		public DataSource2<FranchiseeTerritoryEntity> FranchiseeTerritory
		{
			get { return new DataSource2<FranchiseeTerritoryEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting FranchiseeWiringInstructionsEntity instances in the database.</summary>
		public DataSource2<FranchiseeWiringInstructionsEntity> FranchiseeWiringInstructions
		{
			get { return new DataSource2<FranchiseeWiringInstructionsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GcNotGivenReasonEntity instances in the database.</summary>
		public DataSource2<GcNotGivenReasonEntity> GcNotGivenReason
		{
			get { return new DataSource2<GcNotGivenReasonEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GiftCertificateEntity instances in the database.</summary>
		public DataSource2<GiftCertificateEntity> GiftCertificate
		{
			get { return new DataSource2<GiftCertificateEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GiftCertificateOrderItemEntity instances in the database.</summary>
		public DataSource2<GiftCertificateOrderItemEntity> GiftCertificateOrderItem
		{
			get { return new DataSource2<GiftCertificateOrderItemEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GiftCertificatePaymentEntity instances in the database.</summary>
		public DataSource2<GiftCertificatePaymentEntity> GiftCertificatePayment
		{
			get { return new DataSource2<GiftCertificatePaymentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GiftCertificateTypeEntity instances in the database.</summary>
		public DataSource2<GiftCertificateTypeEntity> GiftCertificateType
		{
			get { return new DataSource2<GiftCertificateTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GlobalConfigurationEntity instances in the database.</summary>
		public DataSource2<GlobalConfigurationEntity> GlobalConfiguration
		{
			get { return new DataSource2<GlobalConfigurationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting GuardianDetailsEntity instances in the database.</summary>
		public DataSource2<GuardianDetailsEntity> GuardianDetails
		{
			get { return new DataSource2<GuardianDetailsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HafTemplateEntity instances in the database.</summary>
		public DataSource2<HafTemplateEntity> HafTemplate
		{
			get { return new DataSource2<HafTemplateEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HafTemplateQuestionEntity instances in the database.</summary>
		public DataSource2<HafTemplateQuestionEntity> HafTemplateQuestion
		{
			get { return new DataSource2<HafTemplateQuestionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HcpcsCodeEntity instances in the database.</summary>
		public DataSource2<HcpcsCodeEntity> HcpcsCode
		{
			get { return new DataSource2<HcpcsCodeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HealthPlanCallQueueCriteriaEntity instances in the database.</summary>
		public DataSource2<HealthPlanCallQueueCriteriaEntity> HealthPlanCallQueueCriteria
		{
			get { return new DataSource2<HealthPlanCallQueueCriteriaEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HealthPlanCallQueueCriteriaAssignmentEntity instances in the database.</summary>
		public DataSource2<HealthPlanCallQueueCriteriaAssignmentEntity> HealthPlanCallQueueCriteriaAssignment
		{
			get { return new DataSource2<HealthPlanCallQueueCriteriaAssignmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HealthPlanCriteriaAssignmentEntity instances in the database.</summary>
		public DataSource2<HealthPlanCriteriaAssignmentEntity> HealthPlanCriteriaAssignment
		{
			get { return new DataSource2<HealthPlanCriteriaAssignmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HealthPlanCriteriaAssignmentUploadEntity instances in the database.</summary>
		public DataSource2<HealthPlanCriteriaAssignmentUploadEntity> HealthPlanCriteriaAssignmentUpload
		{
			get { return new DataSource2<HealthPlanCriteriaAssignmentUploadEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HealthPlanCriteriaDirectMailEntity instances in the database.</summary>
		public DataSource2<HealthPlanCriteriaDirectMailEntity> HealthPlanCriteriaDirectMail
		{
			get { return new DataSource2<HealthPlanCriteriaDirectMailEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HealthPlanCriteriaTeamAssignmentEntity instances in the database.</summary>
		public DataSource2<HealthPlanCriteriaTeamAssignmentEntity> HealthPlanCriteriaTeamAssignment
		{
			get { return new DataSource2<HealthPlanCriteriaTeamAssignmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HealthPlanEventZipEntity instances in the database.</summary>
		public DataSource2<HealthPlanEventZipEntity> HealthPlanEventZip
		{
			get { return new DataSource2<HealthPlanEventZipEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HealthPlanFillEventCallQueueEntity instances in the database.</summary>
		public DataSource2<HealthPlanFillEventCallQueueEntity> HealthPlanFillEventCallQueue
		{
			get { return new DataSource2<HealthPlanFillEventCallQueueEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HealthPlanRevenueEntity instances in the database.</summary>
		public DataSource2<HealthPlanRevenueEntity> HealthPlanRevenue
		{
			get { return new DataSource2<HealthPlanRevenueEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HealthPlanRevenueItemEntity instances in the database.</summary>
		public DataSource2<HealthPlanRevenueItemEntity> HealthPlanRevenueItem
		{
			get { return new DataSource2<HealthPlanRevenueItemEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HealthQuestionDependencyRuleEntity instances in the database.</summary>
		public DataSource2<HealthQuestionDependencyRuleEntity> HealthQuestionDependencyRule
		{
			get { return new DataSource2<HealthQuestionDependencyRuleEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HospitalFacilityEntity instances in the database.</summary>
		public DataSource2<HospitalFacilityEntity> HospitalFacility
		{
			get { return new DataSource2<HospitalFacilityEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HospitalFacilityCampaignEntity instances in the database.</summary>
		public DataSource2<HospitalFacilityCampaignEntity> HospitalFacilityCampaign
		{
			get { return new DataSource2<HospitalFacilityCampaignEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HospitalPartnerEntity instances in the database.</summary>
		public DataSource2<HospitalPartnerEntity> HospitalPartner
		{
			get { return new DataSource2<HospitalPartnerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HospitalPartnerCustomerEntity instances in the database.</summary>
		public DataSource2<HospitalPartnerCustomerEntity> HospitalPartnerCustomer
		{
			get { return new DataSource2<HospitalPartnerCustomerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HospitalPartnerEventNotesEntity instances in the database.</summary>
		public DataSource2<HospitalPartnerEventNotesEntity> HospitalPartnerEventNotes
		{
			get { return new DataSource2<HospitalPartnerEventNotesEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HospitalPartnerHospitalFacilityEntity instances in the database.</summary>
		public DataSource2<HospitalPartnerHospitalFacilityEntity> HospitalPartnerHospitalFacility
		{
			get { return new DataSource2<HospitalPartnerHospitalFacilityEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HospitalPartnerPackageEntity instances in the database.</summary>
		public DataSource2<HospitalPartnerPackageEntity> HospitalPartnerPackage
		{
			get { return new DataSource2<HospitalPartnerPackageEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HospitalPartnerShippingOptionEntity instances in the database.</summary>
		public DataSource2<HospitalPartnerShippingOptionEntity> HospitalPartnerShippingOption
		{
			get { return new DataSource2<HospitalPartnerShippingOptionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HospitalPartnerTerritoryEntity instances in the database.</summary>
		public DataSource2<HospitalPartnerTerritoryEntity> HospitalPartnerTerritory
		{
			get { return new DataSource2<HospitalPartnerTerritoryEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HostAdvocateDetailEntity instances in the database.</summary>
		public DataSource2<HostAdvocateDetailEntity> HostAdvocateDetail
		{
			get { return new DataSource2<HostAdvocateDetailEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HostEventDetailsEntity instances in the database.</summary>
		public DataSource2<HostEventDetailsEntity> HostEventDetails
		{
			get { return new DataSource2<HostEventDetailsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HostFacilityRankingEntity instances in the database.</summary>
		public DataSource2<HostFacilityRankingEntity> HostFacilityRanking
		{
			get { return new DataSource2<HostFacilityRankingEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HostImageEntity instances in the database.</summary>
		public DataSource2<HostImageEntity> HostImage
		{
			get { return new DataSource2<HostImageEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HostNotesEntity instances in the database.</summary>
		public DataSource2<HostNotesEntity> HostNotes
		{
			get { return new DataSource2<HostNotesEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HostPaymentEntity instances in the database.</summary>
		public DataSource2<HostPaymentEntity> HostPayment
		{
			get { return new DataSource2<HostPaymentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HostPaymentTransactionEntity instances in the database.</summary>
		public DataSource2<HostPaymentTransactionEntity> HostPaymentTransaction
		{
			get { return new DataSource2<HostPaymentTransactionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting IcdCodesEntity instances in the database.</summary>
		public DataSource2<IcdCodesEntity> IcdCodes
		{
			get { return new DataSource2<IcdCodesEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting IflocationMasterEntity instances in the database.</summary>
		public DataSource2<IflocationMasterEntity> IflocationMaster
		{
			get { return new DataSource2<IflocationMasterEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting IncidentalFindingIncidentalFindingReadingGroupEntity instances in the database.</summary>
		public DataSource2<IncidentalFindingIncidentalFindingReadingGroupEntity> IncidentalFindingIncidentalFindingReadingGroup
		{
			get { return new DataSource2<IncidentalFindingIncidentalFindingReadingGroupEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting IncidentalFindingReadingGroupEntity instances in the database.</summary>
		public DataSource2<IncidentalFindingReadingGroupEntity> IncidentalFindingReadingGroup
		{
			get { return new DataSource2<IncidentalFindingReadingGroupEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting IncidentalFindingReadingGroupItemEntity instances in the database.</summary>
		public DataSource2<IncidentalFindingReadingGroupItemEntity> IncidentalFindingReadingGroupItem
		{
			get { return new DataSource2<IncidentalFindingReadingGroupItemEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting IncidentalFindingsEntity instances in the database.</summary>
		public DataSource2<IncidentalFindingsEntity> IncidentalFindings
		{
			get { return new DataSource2<IncidentalFindingsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting IncomingPhoneNumberResolverRuleEntity instances in the database.</summary>
		public DataSource2<IncomingPhoneNumberResolverRuleEntity> IncomingPhoneNumberResolverRule
		{
			get { return new DataSource2<IncomingPhoneNumberResolverRuleEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting InsuranceCompanyEntity instances in the database.</summary>
		public DataSource2<InsuranceCompanyEntity> InsuranceCompany
		{
			get { return new DataSource2<InsuranceCompanyEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting InsurancePaymentEntity instances in the database.</summary>
		public DataSource2<InsurancePaymentEntity> InsurancePayment
		{
			get { return new DataSource2<InsurancePaymentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting InsuranceServiceTypeEntity instances in the database.</summary>
		public DataSource2<InsuranceServiceTypeEntity> InsuranceServiceType
		{
			get { return new DataSource2<InsuranceServiceTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting InventoryItemEntity instances in the database.</summary>
		public DataSource2<InventoryItemEntity> InventoryItem
		{
			get { return new DataSource2<InventoryItemEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting InventoryItemTestEntity instances in the database.</summary>
		public DataSource2<InventoryItemTestEntity> InventoryItemTest
		{
			get { return new DataSource2<InventoryItemTestEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ItemEntity instances in the database.</summary>
		public DataSource2<ItemEntity> Item
		{
			get { return new DataSource2<ItemEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ItemTypeEntity instances in the database.</summary>
		public DataSource2<ItemTypeEntity> ItemType
		{
			get { return new DataSource2<ItemTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting KynLabValuesEntity instances in the database.</summary>
		public DataSource2<KynLabValuesEntity> KynLabValues
		{
			get { return new DataSource2<KynLabValuesEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting LabEntity instances in the database.</summary>
		public DataSource2<LabEntity> Lab
		{
			get { return new DataSource2<LabEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting LanguageEntity instances in the database.</summary>
		public DataSource2<LanguageEntity> Language
		{
			get { return new DataSource2<LanguageEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting LanguageBarrierCallQueueEntity instances in the database.</summary>
		public DataSource2<LanguageBarrierCallQueueEntity> LanguageBarrierCallQueue
		{
			get { return new DataSource2<LanguageBarrierCallQueueEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting LanguageBarrierCallQueueCriteriaAssignmentEntity instances in the database.</summary>
		public DataSource2<LanguageBarrierCallQueueCriteriaAssignmentEntity> LanguageBarrierCallQueueCriteriaAssignment
		{
			get { return new DataSource2<LanguageBarrierCallQueueCriteriaAssignmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting LoginOtpEntity instances in the database.</summary>
		public DataSource2<LoginOtpEntity> LoginOtp
		{
			get { return new DataSource2<LoginOtpEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting LoginSettingsEntity instances in the database.</summary>
		public DataSource2<LoginSettingsEntity> LoginSettings
		{
			get { return new DataSource2<LoginSettingsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting LoincCrosswalkEntity instances in the database.</summary>
		public DataSource2<LoincCrosswalkEntity> LoincCrosswalk
		{
			get { return new DataSource2<LoincCrosswalkEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting LoincLabDataEntity instances in the database.</summary>
		public DataSource2<LoincLabDataEntity> LoincLabData
		{
			get { return new DataSource2<LoincLabDataEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting LookupEntity instances in the database.</summary>
		public DataSource2<LookupEntity> Lookup
		{
			get { return new DataSource2<LookupEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting LookupTypeEntity instances in the database.</summary>
		public DataSource2<LookupTypeEntity> LookupType
		{
			get { return new DataSource2<LookupTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MailRoundCallQueueEntity instances in the database.</summary>
		public DataSource2<MailRoundCallQueueEntity> MailRoundCallQueue
		{
			get { return new DataSource2<MailRoundCallQueueEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MailRoundCallQueueCriteriaAssignmentEntity instances in the database.</summary>
		public DataSource2<MailRoundCallQueueCriteriaAssignmentEntity> MailRoundCallQueueCriteriaAssignment
		{
			get { return new DataSource2<MailRoundCallQueueCriteriaAssignmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MarketingOfferRoleMappingEntity instances in the database.</summary>
		public DataSource2<MarketingOfferRoleMappingEntity> MarketingOfferRoleMapping
		{
			get { return new DataSource2<MarketingOfferRoleMappingEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MarketingOffersEntity instances in the database.</summary>
		public DataSource2<MarketingOffersEntity> MarketingOffers
		{
			get { return new DataSource2<MarketingOffersEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MarketingOfferSignUpModeEntity instances in the database.</summary>
		public DataSource2<MarketingOfferSignUpModeEntity> MarketingOfferSignUpMode
		{
			get { return new DataSource2<MarketingOfferSignUpModeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MarketingOfferTypeEntity instances in the database.</summary>
		public DataSource2<MarketingOfferTypeEntity> MarketingOfferType
		{
			get { return new DataSource2<MarketingOfferTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MarketingOrderShippingInfoEntity instances in the database.</summary>
		public DataSource2<MarketingOrderShippingInfoEntity> MarketingOrderShippingInfo
		{
			get { return new DataSource2<MarketingOrderShippingInfoEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MarketingPrintOrderEntity instances in the database.</summary>
		public DataSource2<MarketingPrintOrderEntity> MarketingPrintOrder
		{
			get { return new DataSource2<MarketingPrintOrderEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MarketingPrintOrderEventMappingEntity instances in the database.</summary>
		public DataSource2<MarketingPrintOrderEventMappingEntity> MarketingPrintOrderEventMapping
		{
			get { return new DataSource2<MarketingPrintOrderEventMappingEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MarketingPrintOrderItemEntity instances in the database.</summary>
		public DataSource2<MarketingPrintOrderItemEntity> MarketingPrintOrderItem
		{
			get { return new DataSource2<MarketingPrintOrderItemEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MarketingPrintOrderProspectListMappingEntity instances in the database.</summary>
		public DataSource2<MarketingPrintOrderProspectListMappingEntity> MarketingPrintOrderProspectListMapping
		{
			get { return new DataSource2<MarketingPrintOrderProspectListMappingEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MarketingSourceEntity instances in the database.</summary>
		public DataSource2<MarketingSourceEntity> MarketingSource
		{
			get { return new DataSource2<MarketingSourceEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MarketingSourceTerritoryEntity instances in the database.</summary>
		public DataSource2<MarketingSourceTerritoryEntity> MarketingSourceTerritory
		{
			get { return new DataSource2<MarketingSourceTerritoryEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MedicalHistoryReadingAssosciationEntity instances in the database.</summary>
		public DataSource2<MedicalHistoryReadingAssosciationEntity> MedicalHistoryReadingAssosciation
		{
			get { return new DataSource2<MedicalHistoryReadingAssosciationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MedicalVendorProfileEntity instances in the database.</summary>
		public DataSource2<MedicalVendorProfileEntity> MedicalVendorProfile
		{
			get { return new DataSource2<MedicalVendorProfileEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MedicalVendorTypeEntity instances in the database.</summary>
		public DataSource2<MedicalVendorTypeEntity> MedicalVendorType
		{
			get { return new DataSource2<MedicalVendorTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MedicareGroupDependencyRuleEntity instances in the database.</summary>
		public DataSource2<MedicareGroupDependencyRuleEntity> MedicareGroupDependencyRule
		{
			get { return new DataSource2<MedicareGroupDependencyRuleEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MedicareQuestionEntity instances in the database.</summary>
		public DataSource2<MedicareQuestionEntity> MedicareQuestion
		{
			get { return new DataSource2<MedicareQuestionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MedicareQuestionDependencyRuleEntity instances in the database.</summary>
		public DataSource2<MedicareQuestionDependencyRuleEntity> MedicareQuestionDependencyRule
		{
			get { return new DataSource2<MedicareQuestionDependencyRuleEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MedicareQuestionGroupEntity instances in the database.</summary>
		public DataSource2<MedicareQuestionGroupEntity> MedicareQuestionGroup
		{
			get { return new DataSource2<MedicareQuestionGroupEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MedicareQuestionsRemarksEntity instances in the database.</summary>
		public DataSource2<MedicareQuestionsRemarksEntity> MedicareQuestionsRemarks
		{
			get { return new DataSource2<MedicareQuestionsRemarksEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MedicationEntity instances in the database.</summary>
		public DataSource2<MedicationEntity> Medication
		{
			get { return new DataSource2<MedicationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MedicationUploadEntity instances in the database.</summary>
		public DataSource2<MedicationUploadEntity> MedicationUpload
		{
			get { return new DataSource2<MedicationUploadEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MedicationUploadLogEntity instances in the database.</summary>
		public DataSource2<MedicationUploadLogEntity> MedicationUploadLog
		{
			get { return new DataSource2<MedicationUploadLogEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MemberUploadLogEntity instances in the database.</summary>
		public DataSource2<MemberUploadLogEntity> MemberUploadLog
		{
			get { return new DataSource2<MemberUploadLogEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MemberUploadParseDetailEntity instances in the database.</summary>
		public DataSource2<MemberUploadParseDetailEntity> MemberUploadParseDetail
		{
			get { return new DataSource2<MemberUploadParseDetailEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MergeCustomerUploadEntity instances in the database.</summary>
		public DataSource2<MergeCustomerUploadEntity> MergeCustomerUpload
		{
			get { return new DataSource2<MergeCustomerUploadEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MergeCustomerUploadLogEntity instances in the database.</summary>
		public DataSource2<MergeCustomerUploadLogEntity> MergeCustomerUploadLog
		{
			get { return new DataSource2<MergeCustomerUploadLogEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MolinaAttestationEntity instances in the database.</summary>
		public DataSource2<MolinaAttestationEntity> MolinaAttestation
		{
			get { return new DataSource2<MolinaAttestationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MVPaymentCheckDetailsEntity instances in the database.</summary>
		public DataSource2<MVPaymentCheckDetailsEntity> MVPaymentCheckDetails
		{
			get { return new DataSource2<MVPaymentCheckDetailsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MvuserClassificationEntity instances in the database.</summary>
		public DataSource2<MvuserClassificationEntity> MvuserClassification
		{
			get { return new DataSource2<MvuserClassificationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting NdcEntity instances in the database.</summary>
		public DataSource2<NdcEntity> Ndc
		{
			get { return new DataSource2<NdcEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting NoShowCallQueueEntity instances in the database.</summary>
		public DataSource2<NoShowCallQueueEntity> NoShowCallQueue
		{
			get { return new DataSource2<NoShowCallQueueEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting NoShowCallQueueCriteriaAssignmentEntity instances in the database.</summary>
		public DataSource2<NoShowCallQueueCriteriaAssignmentEntity> NoShowCallQueueCriteriaAssignment
		{
			get { return new DataSource2<NoShowCallQueueCriteriaAssignmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting NoteEntity instances in the database.</summary>
		public DataSource2<NoteEntity> Note
		{
			get { return new DataSource2<NoteEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting NotesDetailsEntity instances in the database.</summary>
		public DataSource2<NotesDetailsEntity> NotesDetails
		{
			get { return new DataSource2<NotesDetailsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting NotificationEntity instances in the database.</summary>
		public DataSource2<NotificationEntity> Notification
		{
			get { return new DataSource2<NotificationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting NotificationEmailEntity instances in the database.</summary>
		public DataSource2<NotificationEmailEntity> NotificationEmail
		{
			get { return new DataSource2<NotificationEmailEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting NotificationMediumEntity instances in the database.</summary>
		public DataSource2<NotificationMediumEntity> NotificationMedium
		{
			get { return new DataSource2<NotificationMediumEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting NotificationPhoneEntity instances in the database.</summary>
		public DataSource2<NotificationPhoneEntity> NotificationPhone
		{
			get { return new DataSource2<NotificationPhoneEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting NotificationSubscribersEntity instances in the database.</summary>
		public DataSource2<NotificationSubscribersEntity> NotificationSubscribers
		{
			get { return new DataSource2<NotificationSubscribersEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting NotificationTypeEntity instances in the database.</summary>
		public DataSource2<NotificationTypeEntity> NotificationType
		{
			get { return new DataSource2<NotificationTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting OrderEntity instances in the database.</summary>
		public DataSource2<OrderEntity> Order
		{
			get { return new DataSource2<OrderEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting OrderDetailEntity instances in the database.</summary>
		public DataSource2<OrderDetailEntity> OrderDetail
		{
			get { return new DataSource2<OrderDetailEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting OrderItemEntity instances in the database.</summary>
		public DataSource2<OrderItemEntity> OrderItem
		{
			get { return new DataSource2<OrderItemEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting OrganizationEntity instances in the database.</summary>
		public DataSource2<OrganizationEntity> Organization
		{
			get { return new DataSource2<OrganizationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting OrganizationRoleUserEntity instances in the database.</summary>
		public DataSource2<OrganizationRoleUserEntity> OrganizationRoleUser
		{
			get { return new DataSource2<OrganizationRoleUserEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting OrganizationRoleUserTerritoryEntity instances in the database.</summary>
		public DataSource2<OrganizationRoleUserTerritoryEntity> OrganizationRoleUserTerritory
		{
			get { return new DataSource2<OrganizationRoleUserTerritoryEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting OrganizationTypeEntity instances in the database.</summary>
		public DataSource2<OrganizationTypeEntity> OrganizationType
		{
			get { return new DataSource2<OrganizationTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting OrgRoleUserActivityEntity instances in the database.</summary>
		public DataSource2<OrgRoleUserActivityEntity> OrgRoleUserActivity
		{
			get { return new DataSource2<OrgRoleUserActivityEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting OutboundUploadEntity instances in the database.</summary>
		public DataSource2<OutboundUploadEntity> OutboundUpload
		{
			get { return new DataSource2<OutboundUploadEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PackageEntity instances in the database.</summary>
		public DataSource2<PackageEntity> Package
		{
			get { return new DataSource2<PackageEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PackageAvailabilityToRolesEntity instances in the database.</summary>
		public DataSource2<PackageAvailabilityToRolesEntity> PackageAvailabilityToRoles
		{
			get { return new DataSource2<PackageAvailabilityToRolesEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PackageMarketingOfferDiscountEntity instances in the database.</summary>
		public DataSource2<PackageMarketingOfferDiscountEntity> PackageMarketingOfferDiscount
		{
			get { return new DataSource2<PackageMarketingOfferDiscountEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PackageSourceCodeDiscountEntity instances in the database.</summary>
		public DataSource2<PackageSourceCodeDiscountEntity> PackageSourceCodeDiscount
		{
			get { return new DataSource2<PackageSourceCodeDiscountEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PackageTestEntity instances in the database.</summary>
		public DataSource2<PackageTestEntity> PackageTest
		{
			get { return new DataSource2<PackageTestEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ParticipationConsentSignatureEntity instances in the database.</summary>
		public DataSource2<ParticipationConsentSignatureEntity> ParticipationConsentSignature
		{
			get { return new DataSource2<ParticipationConsentSignatureEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PasswordChangelogEntity instances in the database.</summary>
		public DataSource2<PasswordChangelogEntity> PasswordChangelog
		{
			get { return new DataSource2<PasswordChangelogEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PaymentEntity instances in the database.</summary>
		public DataSource2<PaymentEntity> Payment
		{
			get { return new DataSource2<PaymentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PaymentFrequencyEntity instances in the database.</summary>
		public DataSource2<PaymentFrequencyEntity> PaymentFrequency
		{
			get { return new DataSource2<PaymentFrequencyEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PaymentInstructionsEntity instances in the database.</summary>
		public DataSource2<PaymentInstructionsEntity> PaymentInstructions
		{
			get { return new DataSource2<PaymentInstructionsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PaymentOrderEntity instances in the database.</summary>
		public DataSource2<PaymentOrderEntity> PaymentOrder
		{
			get { return new DataSource2<PaymentOrderEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PaymentTypeEntity instances in the database.</summary>
		public DataSource2<PaymentTypeEntity> PaymentType
		{
			get { return new DataSource2<PaymentTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PayPeriodEntity instances in the database.</summary>
		public DataSource2<PayPeriodEntity> PayPeriod
		{
			get { return new DataSource2<PayPeriodEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PayPeriodCriteriaEntity instances in the database.</summary>
		public DataSource2<PayPeriodCriteriaEntity> PayPeriodCriteria
		{
			get { return new DataSource2<PayPeriodCriteriaEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PcpAppointmentEntity instances in the database.</summary>
		public DataSource2<PcpAppointmentEntity> PcpAppointment
		{
			get { return new DataSource2<PcpAppointmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PcpDispositionEntity instances in the database.</summary>
		public DataSource2<PcpDispositionEntity> PcpDisposition
		{
			get { return new DataSource2<PcpDispositionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PhysicianCustomerAssignmentEntity instances in the database.</summary>
		public DataSource2<PhysicianCustomerAssignmentEntity> PhysicianCustomerAssignment
		{
			get { return new DataSource2<PhysicianCustomerAssignmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PhysicianCustomerPayRateEntity instances in the database.</summary>
		public DataSource2<PhysicianCustomerPayRateEntity> PhysicianCustomerPayRate
		{
			get { return new DataSource2<PhysicianCustomerPayRateEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PhysicianEarningsEntity instances in the database.</summary>
		public DataSource2<PhysicianEarningsEntity> PhysicianEarnings
		{
			get { return new DataSource2<PhysicianEarningsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PhysicianEvaluationEntity instances in the database.</summary>
		public DataSource2<PhysicianEvaluationEntity> PhysicianEvaluation
		{
			get { return new DataSource2<PhysicianEvaluationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PhysicianEventAssignmentEntity instances in the database.</summary>
		public DataSource2<PhysicianEventAssignmentEntity> PhysicianEventAssignment
		{
			get { return new DataSource2<PhysicianEventAssignmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PhysicianInvoiceEntity instances in the database.</summary>
		public DataSource2<PhysicianInvoiceEntity> PhysicianInvoice
		{
			get { return new DataSource2<PhysicianInvoiceEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PhysicianInvoiceItemEntity instances in the database.</summary>
		public DataSource2<PhysicianInvoiceItemEntity> PhysicianInvoiceItem
		{
			get { return new DataSource2<PhysicianInvoiceItemEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PhysicianLabTestEntity instances in the database.</summary>
		public DataSource2<PhysicianLabTestEntity> PhysicianLabTest
		{
			get { return new DataSource2<PhysicianLabTestEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PhysicianLicenseEntity instances in the database.</summary>
		public DataSource2<PhysicianLicenseEntity> PhysicianLicense
		{
			get { return new DataSource2<PhysicianLicenseEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PhysicianMasterEntity instances in the database.</summary>
		public DataSource2<PhysicianMasterEntity> PhysicianMaster
		{
			get { return new DataSource2<PhysicianMasterEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PhysicianPaymentEntity instances in the database.</summary>
		public DataSource2<PhysicianPaymentEntity> PhysicianPayment
		{
			get { return new DataSource2<PhysicianPaymentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PhysicianPaymentInvoiceEntity instances in the database.</summary>
		public DataSource2<PhysicianPaymentInvoiceEntity> PhysicianPaymentInvoice
		{
			get { return new DataSource2<PhysicianPaymentInvoiceEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PhysicianPermittedTestEntity instances in the database.</summary>
		public DataSource2<PhysicianPermittedTestEntity> PhysicianPermittedTest
		{
			get { return new DataSource2<PhysicianPermittedTestEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PhysicianPodEntity instances in the database.</summary>
		public DataSource2<PhysicianPodEntity> PhysicianPod
		{
			get { return new DataSource2<PhysicianPodEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PhysicianProfileEntity instances in the database.</summary>
		public DataSource2<PhysicianProfileEntity> PhysicianProfile
		{
			get { return new DataSource2<PhysicianProfileEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PhysicianRecordRequestSignatureEntity instances in the database.</summary>
		public DataSource2<PhysicianRecordRequestSignatureEntity> PhysicianRecordRequestSignature
		{
			get { return new DataSource2<PhysicianRecordRequestSignatureEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PhysicianSpecializationEntity instances in the database.</summary>
		public DataSource2<PhysicianSpecializationEntity> PhysicianSpecialization
		{
			get { return new DataSource2<PhysicianSpecializationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PinChangelogEntity instances in the database.</summary>
		public DataSource2<PinChangelogEntity> PinChangelog
		{
			get { return new DataSource2<PinChangelogEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PodDefaultTeamEntity instances in the database.</summary>
		public DataSource2<PodDefaultTeamEntity> PodDefaultTeam
		{
			get { return new DataSource2<PodDefaultTeamEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PodDetailsEntity instances in the database.</summary>
		public DataSource2<PodDetailsEntity> PodDetails
		{
			get { return new DataSource2<PodDetailsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PodInventoryItemEntity instances in the database.</summary>
		public DataSource2<PodInventoryItemEntity> PodInventoryItem
		{
			get { return new DataSource2<PodInventoryItemEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PodPackageEntity instances in the database.</summary>
		public DataSource2<PodPackageEntity> PodPackage
		{
			get { return new DataSource2<PodPackageEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PodRoomEntity instances in the database.</summary>
		public DataSource2<PodRoomEntity> PodRoom
		{
			get { return new DataSource2<PodRoomEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PodRoomTestEntity instances in the database.</summary>
		public DataSource2<PodRoomTestEntity> PodRoomTest
		{
			get { return new DataSource2<PodRoomTestEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PodTerritoryEntity instances in the database.</summary>
		public DataSource2<PodTerritoryEntity> PodTerritory
		{
			get { return new DataSource2<PodTerritoryEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PodTestEntity instances in the database.</summary>
		public DataSource2<PodTestEntity> PodTest
		{
			get { return new DataSource2<PodTestEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PreApprovedPackageEntity instances in the database.</summary>
		public DataSource2<PreApprovedPackageEntity> PreApprovedPackage
		{
			get { return new DataSource2<PreApprovedPackageEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PreApprovedTestEntity instances in the database.</summary>
		public DataSource2<PreApprovedTestEntity> PreApprovedTest
		{
			get { return new DataSource2<PreApprovedTestEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PreAssessmentCallQueueCustomerLockEntity instances in the database.</summary>
		public DataSource2<PreAssessmentCallQueueCustomerLockEntity> PreAssessmentCallQueueCustomerLock
		{
			get { return new DataSource2<PreAssessmentCallQueueCustomerLockEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PreAssessmentCustomerCallQueueCallAttemptEntity instances in the database.</summary>
		public DataSource2<PreAssessmentCustomerCallQueueCallAttemptEntity> PreAssessmentCustomerCallQueueCallAttempt
		{
			get { return new DataSource2<PreAssessmentCustomerCallQueueCallAttemptEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PreQualificationQuestionEntity instances in the database.</summary>
		public DataSource2<PreQualificationQuestionEntity> PreQualificationQuestion
		{
			get { return new DataSource2<PreQualificationQuestionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PreQualificationQuestionRuleEntity instances in the database.</summary>
		public DataSource2<PreQualificationQuestionRuleEntity> PreQualificationQuestionRule
		{
			get { return new DataSource2<PreQualificationQuestionRuleEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PreQualificationResultEntity instances in the database.</summary>
		public DataSource2<PreQualificationResultEntity> PreQualificationResult
		{
			get { return new DataSource2<PreQualificationResultEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PreQualificationTemplateDependentTestEntity instances in the database.</summary>
		public DataSource2<PreQualificationTemplateDependentTestEntity> PreQualificationTemplateDependentTest
		{
			get { return new DataSource2<PreQualificationTemplateDependentTestEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PreQualificationTemplateQuestionEntity instances in the database.</summary>
		public DataSource2<PreQualificationTemplateQuestionEntity> PreQualificationTemplateQuestion
		{
			get { return new DataSource2<PreQualificationTemplateQuestionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PreQualificationTestTemplateEntity instances in the database.</summary>
		public DataSource2<PreQualificationTestTemplateEntity> PreQualificationTestTemplate
		{
			get { return new DataSource2<PreQualificationTestTemplateEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PrintOrderItemTrackingEntity instances in the database.</summary>
		public DataSource2<PrintOrderItemTrackingEntity> PrintOrderItemTracking
		{
			get { return new DataSource2<PrintOrderItemTrackingEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting PriorityInQueueEntity instances in the database.</summary>
		public DataSource2<PriorityInQueueEntity> PriorityInQueue
		{
			get { return new DataSource2<PriorityInQueueEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProductEntity instances in the database.</summary>
		public DataSource2<ProductEntity> Product
		{
			get { return new DataSource2<ProductEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProductOrderItemEntity instances in the database.</summary>
		public DataSource2<ProductOrderItemEntity> ProductOrderItem
		{
			get { return new DataSource2<ProductOrderItemEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProductShippingOptionEntity instances in the database.</summary>
		public DataSource2<ProductShippingOptionEntity> ProductShippingOption
		{
			get { return new DataSource2<ProductShippingOptionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProductSourceCodeDiscountEntity instances in the database.</summary>
		public DataSource2<ProductSourceCodeDiscountEntity> ProductSourceCodeDiscount
		{
			get { return new DataSource2<ProductSourceCodeDiscountEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProspectActivityEntity instances in the database.</summary>
		public DataSource2<ProspectActivityEntity> ProspectActivity
		{
			get { return new DataSource2<ProspectActivityEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProspectActivityDetailsEntity instances in the database.</summary>
		public DataSource2<ProspectActivityDetailsEntity> ProspectActivityDetails
		{
			get { return new DataSource2<ProspectActivityDetailsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProspectAddressEntity instances in the database.</summary>
		public DataSource2<ProspectAddressEntity> ProspectAddress
		{
			get { return new DataSource2<ProspectAddressEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProspectCallDetailsEntity instances in the database.</summary>
		public DataSource2<ProspectCallDetailsEntity> ProspectCallDetails
		{
			get { return new DataSource2<ProspectCallDetailsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProspectCallsEntity instances in the database.</summary>
		public DataSource2<ProspectCallsEntity> ProspectCalls
		{
			get { return new DataSource2<ProspectCallsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProspectContactEntity instances in the database.</summary>
		public DataSource2<ProspectContactEntity> ProspectContact
		{
			get { return new DataSource2<ProspectContactEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProspectContactCallsEntity instances in the database.</summary>
		public DataSource2<ProspectContactCallsEntity> ProspectContactCalls
		{
			get { return new DataSource2<ProspectContactCallsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProspectContactMeetingsEntity instances in the database.</summary>
		public DataSource2<ProspectContactMeetingsEntity> ProspectContactMeetings
		{
			get { return new DataSource2<ProspectContactMeetingsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProspectContactRoleEntity instances in the database.</summary>
		public DataSource2<ProspectContactRoleEntity> ProspectContactRole
		{
			get { return new DataSource2<ProspectContactRoleEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProspectContactRoleMappingEntity instances in the database.</summary>
		public DataSource2<ProspectContactRoleMappingEntity> ProspectContactRoleMapping
		{
			get { return new DataSource2<ProspectContactRoleMappingEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProspectContactTasksEntity instances in the database.</summary>
		public DataSource2<ProspectContactTasksEntity> ProspectContactTasks
		{
			get { return new DataSource2<ProspectContactTasksEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProspectCustomerEntity instances in the database.</summary>
		public DataSource2<ProspectCustomerEntity> ProspectCustomer
		{
			get { return new DataSource2<ProspectCustomerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProspectCustomerCallEntity instances in the database.</summary>
		public DataSource2<ProspectCustomerCallEntity> ProspectCustomerCall
		{
			get { return new DataSource2<ProspectCustomerCallEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProspectCustomerDeletedEntity instances in the database.</summary>
		public DataSource2<ProspectCustomerDeletedEntity> ProspectCustomerDeleted
		{
			get { return new DataSource2<ProspectCustomerDeletedEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProspectCustomerNotificationEntity instances in the database.</summary>
		public DataSource2<ProspectCustomerNotificationEntity> ProspectCustomerNotification
		{
			get { return new DataSource2<ProspectCustomerNotificationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProspectDetailsEntity instances in the database.</summary>
		public DataSource2<ProspectDetailsEntity> ProspectDetails
		{
			get { return new DataSource2<ProspectDetailsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProspectFaliureReportEntity instances in the database.</summary>
		public DataSource2<ProspectFaliureReportEntity> ProspectFaliureReport
		{
			get { return new DataSource2<ProspectFaliureReportEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProspectListDetailsEntity instances in the database.</summary>
		public DataSource2<ProspectListDetailsEntity> ProspectListDetails
		{
			get { return new DataSource2<ProspectListDetailsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProspectListTypeEntity instances in the database.</summary>
		public DataSource2<ProspectListTypeEntity> ProspectListType
		{
			get { return new DataSource2<ProspectListTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProspectMeetingsEntity instances in the database.</summary>
		public DataSource2<ProspectMeetingsEntity> ProspectMeetings
		{
			get { return new DataSource2<ProspectMeetingsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProspectNotesDetailsEntity instances in the database.</summary>
		public DataSource2<ProspectNotesDetailsEntity> ProspectNotesDetails
		{
			get { return new DataSource2<ProspectNotesDetailsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProspectsEntity instances in the database.</summary>
		public DataSource2<ProspectsEntity> Prospects
		{
			get { return new DataSource2<ProspectsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProspectTasksEntity instances in the database.</summary>
		public DataSource2<ProspectTasksEntity> ProspectTasks
		{
			get { return new DataSource2<ProspectTasksEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ProspectTypeEntity instances in the database.</summary>
		public DataSource2<ProspectTypeEntity> ProspectType
		{
			get { return new DataSource2<ProspectTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting RapsEntity instances in the database.</summary>
		public DataSource2<RapsEntity> Raps
		{
			get { return new DataSource2<RapsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting RapsUploadEntity instances in the database.</summary>
		public DataSource2<RapsUploadEntity> RapsUpload
		{
			get { return new DataSource2<RapsUploadEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting RapsUploadLogEntity instances in the database.</summary>
		public DataSource2<RapsUploadLogEntity> RapsUploadLog
		{
			get { return new DataSource2<RapsUploadLogEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ReadingEntity instances in the database.</summary>
		public DataSource2<ReadingEntity> Reading
		{
			get { return new DataSource2<ReadingEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ReferralEntity instances in the database.</summary>
		public DataSource2<ReferralEntity> Referral
		{
			get { return new DataSource2<ReferralEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting RefundEntity instances in the database.</summary>
		public DataSource2<RefundEntity> Refund
		{
			get { return new DataSource2<RefundEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting RefundOrderItemEntity instances in the database.</summary>
		public DataSource2<RefundOrderItemEntity> RefundOrderItem
		{
			get { return new DataSource2<RefundOrderItemEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting RefundRequestEntity instances in the database.</summary>
		public DataSource2<RefundRequestEntity> RefundRequest
		{
			get { return new DataSource2<RefundRequestEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting RefundRequestGiftCertificateEntity instances in the database.</summary>
		public DataSource2<RefundRequestGiftCertificateEntity> RefundRequestGiftCertificate
		{
			get { return new DataSource2<RefundRequestGiftCertificateEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting RelationshipEntity instances in the database.</summary>
		public DataSource2<RelationshipEntity> Relationship
		{
			get { return new DataSource2<RelationshipEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting RequiredTestEntity instances in the database.</summary>
		public DataSource2<RequiredTestEntity> RequiredTest
		{
			get { return new DataSource2<RequiredTestEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting RescheduleCancelDispositionEntity instances in the database.</summary>
		public DataSource2<RescheduleCancelDispositionEntity> RescheduleCancelDisposition
		{
			get { return new DataSource2<RescheduleCancelDispositionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ResultArchiveUploadEntity instances in the database.</summary>
		public DataSource2<ResultArchiveUploadEntity> ResultArchiveUpload
		{
			get { return new DataSource2<ResultArchiveUploadEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ResultArchiveUploadLogEntity instances in the database.</summary>
		public DataSource2<ResultArchiveUploadLogEntity> ResultArchiveUploadLog
		{
			get { return new DataSource2<ResultArchiveUploadLogEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting RoleEntity instances in the database.</summary>
		public DataSource2<RoleEntity> Role
		{
			get { return new DataSource2<RoleEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting RoleAccessControlObjectEntity instances in the database.</summary>
		public DataSource2<RoleAccessControlObjectEntity> RoleAccessControlObject
		{
			get { return new DataSource2<RoleAccessControlObjectEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting RolePermisibleAccessControlObjectEntity instances in the database.</summary>
		public DataSource2<RolePermisibleAccessControlObjectEntity> RolePermisibleAccessControlObject
		{
			get { return new DataSource2<RolePermisibleAccessControlObjectEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting RoleScopeOptionEntity instances in the database.</summary>
		public DataSource2<RoleScopeOptionEntity> RoleScopeOption
		{
			get { return new DataSource2<RoleScopeOptionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SafeComputerHistoryEntity instances in the database.</summary>
		public DataSource2<SafeComputerHistoryEntity> SafeComputerHistory
		{
			get { return new DataSource2<SafeComputerHistoryEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SalesRepPodAssigmentsEntity instances in the database.</summary>
		public DataSource2<SalesRepPodAssigmentsEntity> SalesRepPodAssigments
		{
			get { return new DataSource2<SalesRepPodAssigmentsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ScheduleMethodEntity instances in the database.</summary>
		public DataSource2<ScheduleMethodEntity> ScheduleMethod
		{
			get { return new DataSource2<ScheduleMethodEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ScheduleTemplateEntity instances in the database.</summary>
		public DataSource2<ScheduleTemplateEntity> ScheduleTemplate
		{
			get { return new DataSource2<ScheduleTemplateEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ScheduleTemplateFranchiseeAccessEntity instances in the database.</summary>
		public DataSource2<ScheduleTemplateFranchiseeAccessEntity> ScheduleTemplateFranchiseeAccess
		{
			get { return new DataSource2<ScheduleTemplateFranchiseeAccessEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ScheduleTemplateTimeEntity instances in the database.</summary>
		public DataSource2<ScheduleTemplateTimeEntity> ScheduleTemplateTime
		{
			get { return new DataSource2<ScheduleTemplateTimeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ScreeningAuthorizationEntity instances in the database.</summary>
		public DataSource2<ScreeningAuthorizationEntity> ScreeningAuthorization
		{
			get { return new DataSource2<ScreeningAuthorizationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ScriptsEntity instances in the database.</summary>
		public DataSource2<ScriptsEntity> Scripts
		{
			get { return new DataSource2<ScriptsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ScriptTypeEntity instances in the database.</summary>
		public DataSource2<ScriptTypeEntity> ScriptType
		{
			get { return new DataSource2<ScriptTypeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SecurityQuestionEntity instances in the database.</summary>
		public DataSource2<SecurityQuestionEntity> SecurityQuestion
		{
			get { return new DataSource2<SecurityQuestionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SeminarCampaignDetailsEntity instances in the database.</summary>
		public DataSource2<SeminarCampaignDetailsEntity> SeminarCampaignDetails
		{
			get { return new DataSource2<SeminarCampaignDetailsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SeminarsEntity instances in the database.</summary>
		public DataSource2<SeminarsEntity> Seminars
		{
			get { return new DataSource2<SeminarsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ShippingDetailEntity instances in the database.</summary>
		public DataSource2<ShippingDetailEntity> ShippingDetail
		{
			get { return new DataSource2<ShippingDetailEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ShippingDetailOrderDetailEntity instances in the database.</summary>
		public DataSource2<ShippingDetailOrderDetailEntity> ShippingDetailOrderDetail
		{
			get { return new DataSource2<ShippingDetailOrderDetailEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ShippingOptionEntity instances in the database.</summary>
		public DataSource2<ShippingOptionEntity> ShippingOption
		{
			get { return new DataSource2<ShippingOptionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ShippingOptionOrderItemEntity instances in the database.</summary>
		public DataSource2<ShippingOptionOrderItemEntity> ShippingOptionOrderItem
		{
			get { return new DataSource2<ShippingOptionOrderItemEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ShippingOptionSourceCodeDiscountEntity instances in the database.</summary>
		public DataSource2<ShippingOptionSourceCodeDiscountEntity> ShippingOptionSourceCodeDiscount
		{
			get { return new DataSource2<ShippingOptionSourceCodeDiscountEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SmsReceivedEntity instances in the database.</summary>
		public DataSource2<SmsReceivedEntity> SmsReceived
		{
			get { return new DataSource2<SmsReceivedEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SourceCodeChangeLogEntity instances in the database.</summary>
		public DataSource2<SourceCodeChangeLogEntity> SourceCodeChangeLog
		{
			get { return new DataSource2<SourceCodeChangeLogEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SourceCodeOrderDetailEntity instances in the database.</summary>
		public DataSource2<SourceCodeOrderDetailEntity> SourceCodeOrderDetail
		{
			get { return new DataSource2<SourceCodeOrderDetailEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting StaffEventRoleEntity instances in the database.</summary>
		public DataSource2<StaffEventRoleEntity> StaffEventRole
		{
			get { return new DataSource2<StaffEventRoleEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting StaffEventRoleTestEntity instances in the database.</summary>
		public DataSource2<StaffEventRoleTestEntity> StaffEventRoleTest
		{
			get { return new DataSource2<StaffEventRoleTestEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting StaffEventScheduleUploadEntity instances in the database.</summary>
		public DataSource2<StaffEventScheduleUploadEntity> StaffEventScheduleUpload
		{
			get { return new DataSource2<StaffEventScheduleUploadEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting StaffEventScheduleUploadLogEntity instances in the database.</summary>
		public DataSource2<StaffEventScheduleUploadLogEntity> StaffEventScheduleUploadLog
		{
			get { return new DataSource2<StaffEventScheduleUploadLogEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting StandardFindingEntity instances in the database.</summary>
		public DataSource2<StandardFindingEntity> StandardFinding
		{
			get { return new DataSource2<StandardFindingEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting StandardFindingTestReadingEntity instances in the database.</summary>
		public DataSource2<StandardFindingTestReadingEntity> StandardFindingTestReading
		{
			get { return new DataSource2<StandardFindingTestReadingEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting StateEntity instances in the database.</summary>
		public DataSource2<StateEntity> State
		{
			get { return new DataSource2<StateEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SurveyAnswerEntity instances in the database.</summary>
		public DataSource2<SurveyAnswerEntity> SurveyAnswer
		{
			get { return new DataSource2<SurveyAnswerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SurveyQuestionEntity instances in the database.</summary>
		public DataSource2<SurveyQuestionEntity> SurveyQuestion
		{
			get { return new DataSource2<SurveyQuestionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SurveyTemplateEntity instances in the database.</summary>
		public DataSource2<SurveyTemplateEntity> SurveyTemplate
		{
			get { return new DataSource2<SurveyTemplateEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SurveyTemplateQuestionEntity instances in the database.</summary>
		public DataSource2<SurveyTemplateQuestionEntity> SurveyTemplateQuestion
		{
			get { return new DataSource2<SurveyTemplateQuestionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SuspectConditionEntity instances in the database.</summary>
		public DataSource2<SuspectConditionEntity> SuspectCondition
		{
			get { return new DataSource2<SuspectConditionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SuspectConditionUploadEntity instances in the database.</summary>
		public DataSource2<SuspectConditionUploadEntity> SuspectConditionUpload
		{
			get { return new DataSource2<SuspectConditionUploadEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SuspectConditionUploadLogEntity instances in the database.</summary>
		public DataSource2<SuspectConditionUploadLogEntity> SuspectConditionUploadLog
		{
			get { return new DataSource2<SuspectConditionUploadLogEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SystemGeneratedCallQueueAssignmentEntity instances in the database.</summary>
		public DataSource2<SystemGeneratedCallQueueAssignmentEntity> SystemGeneratedCallQueueAssignment
		{
			get { return new DataSource2<SystemGeneratedCallQueueAssignmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SystemGeneratedCallQueueCriteriaEntity instances in the database.</summary>
		public DataSource2<SystemGeneratedCallQueueCriteriaEntity> SystemGeneratedCallQueueCriteria
		{
			get { return new DataSource2<SystemGeneratedCallQueueCriteriaEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SystemUserInfoEntity instances in the database.</summary>
		public DataSource2<SystemUserInfoEntity> SystemUserInfo
		{
			get { return new DataSource2<SystemUserInfoEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TagEntity instances in the database.</summary>
		public DataSource2<TagEntity> Tag
		{
			get { return new DataSource2<TagEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TaskEntity instances in the database.</summary>
		public DataSource2<TaskEntity> Task
		{
			get { return new DataSource2<TaskEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TaskDetailsEntity instances in the database.</summary>
		public DataSource2<TaskDetailsEntity> TaskDetails
		{
			get { return new DataSource2<TaskDetailsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TaskPriorityTypesEntity instances in the database.</summary>
		public DataSource2<TaskPriorityTypesEntity> TaskPriorityTypes
		{
			get { return new DataSource2<TaskPriorityTypesEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TaskStatusTypesEntity instances in the database.</summary>
		public DataSource2<TaskStatusTypesEntity> TaskStatusTypes
		{
			get { return new DataSource2<TaskStatusTypesEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TechnicianProfileEntity instances in the database.</summary>
		public DataSource2<TechnicianProfileEntity> TechnicianProfile
		{
			get { return new DataSource2<TechnicianProfileEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TempCartEntity instances in the database.</summary>
		public DataSource2<TempCartEntity> TempCart
		{
			get { return new DataSource2<TempCartEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TemplateEntity instances in the database.</summary>
		public DataSource2<TemplateEntity> Template
		{
			get { return new DataSource2<TemplateEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TemplateMacroEntity instances in the database.</summary>
		public DataSource2<TemplateMacroEntity> TemplateMacro
		{
			get { return new DataSource2<TemplateMacroEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TemplateTagEntity instances in the database.</summary>
		public DataSource2<TemplateTagEntity> TemplateTag
		{
			get { return new DataSource2<TemplateTagEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TerritoryEntity instances in the database.</summary>
		public DataSource2<TerritoryEntity> Territory
		{
			get { return new DataSource2<TerritoryEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TerritoryPackageEntity instances in the database.</summary>
		public DataSource2<TerritoryPackageEntity> TerritoryPackage
		{
			get { return new DataSource2<TerritoryPackageEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TerritoryZipEntity instances in the database.</summary>
		public DataSource2<TerritoryZipEntity> TerritoryZip
		{
			get { return new DataSource2<TerritoryZipEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TestEntity instances in the database.</summary>
		public DataSource2<TestEntity> Test
		{
			get { return new DataSource2<TestEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TestAvailabilityToRolesEntity instances in the database.</summary>
		public DataSource2<TestAvailabilityToRolesEntity> TestAvailabilityToRoles
		{
			get { return new DataSource2<TestAvailabilityToRolesEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TestDependencyRuleEntity instances in the database.</summary>
		public DataSource2<TestDependencyRuleEntity> TestDependencyRule
		{
			get { return new DataSource2<TestDependencyRuleEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TestHcpcsCodeEntity instances in the database.</summary>
		public DataSource2<TestHcpcsCodeEntity> TestHcpcsCode
		{
			get { return new DataSource2<TestHcpcsCodeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TestimonialEntity instances in the database.</summary>
		public DataSource2<TestimonialEntity> Testimonial
		{
			get { return new DataSource2<TestimonialEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TestIncidentalFindingEntity instances in the database.</summary>
		public DataSource2<TestIncidentalFindingEntity> TestIncidentalFinding
		{
			get { return new DataSource2<TestIncidentalFindingEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TestMediaEntity instances in the database.</summary>
		public DataSource2<TestMediaEntity> TestMedia
		{
			get { return new DataSource2<TestMediaEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TestNotPerformedEntity instances in the database.</summary>
		public DataSource2<TestNotPerformedEntity> TestNotPerformed
		{
			get { return new DataSource2<TestNotPerformedEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TestNotPerformedReasonEntity instances in the database.</summary>
		public DataSource2<TestNotPerformedReasonEntity> TestNotPerformedReason
		{
			get { return new DataSource2<TestNotPerformedReasonEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TestOrderItemEntity instances in the database.</summary>
		public DataSource2<TestOrderItemEntity> TestOrderItem
		{
			get { return new DataSource2<TestOrderItemEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TestPerformedExternallyEntity instances in the database.</summary>
		public DataSource2<TestPerformedExternallyEntity> TestPerformedExternally
		{
			get { return new DataSource2<TestPerformedExternallyEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TestReadingEntity instances in the database.</summary>
		public DataSource2<TestReadingEntity> TestReading
		{
			get { return new DataSource2<TestReadingEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TestSourceCodeDiscountEntity instances in the database.</summary>
		public DataSource2<TestSourceCodeDiscountEntity> TestSourceCodeDiscount
		{
			get { return new DataSource2<TestSourceCodeDiscountEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TestUnableScreenReasonEntity instances in the database.</summary>
		public DataSource2<TestUnableScreenReasonEntity> TestUnableScreenReason
		{
			get { return new DataSource2<TestUnableScreenReasonEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ToolTipEntity instances in the database.</summary>
		public DataSource2<ToolTipEntity> ToolTip
		{
			get { return new DataSource2<ToolTipEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TrackingMarketingEntity instances in the database.</summary>
		public DataSource2<TrackingMarketingEntity> TrackingMarketing
		{
			get { return new DataSource2<TrackingMarketingEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting UncontactedCustomerCallQueueEntity instances in the database.</summary>
		public DataSource2<UncontactedCustomerCallQueueEntity> UncontactedCustomerCallQueue
		{
			get { return new DataSource2<UncontactedCustomerCallQueueEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting UncontactedCustomerCallQueueCriteriaAssignmentEntity instances in the database.</summary>
		public DataSource2<UncontactedCustomerCallQueueCriteriaAssignmentEntity> UncontactedCustomerCallQueueCriteriaAssignment
		{
			get { return new DataSource2<UncontactedCustomerCallQueueCriteriaAssignmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting UnitEntity instances in the database.</summary>
		public DataSource2<UnitEntity> Unit
		{
			get { return new DataSource2<UnitEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting UploadTestInfoEntity instances in the database.</summary>
		public DataSource2<UploadTestInfoEntity> UploadTestInfo
		{
			get { return new DataSource2<UploadTestInfoEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting UploadZipInfoEntity instances in the database.</summary>
		public DataSource2<UploadZipInfoEntity> UploadZipInfo
		{
			get { return new DataSource2<UploadZipInfoEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting UserEntity instances in the database.</summary>
		public DataSource2<UserEntity> User
		{
			get { return new DataSource2<UserEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting UserLoginEntity instances in the database.</summary>
		public DataSource2<UserLoginEntity> UserLogin
		{
			get { return new DataSource2<UserLoginEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting UserLoginLogEntity instances in the database.</summary>
		public DataSource2<UserLoginLogEntity> UserLoginLog
		{
			get { return new DataSource2<UserLoginLogEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting UserNpiInfoEntity instances in the database.</summary>
		public DataSource2<UserNpiInfoEntity> UserNpiInfo
		{
			get { return new DataSource2<UserNpiInfoEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting UserSecurityQuestionEntity instances in the database.</summary>
		public DataSource2<UserSecurityQuestionEntity> UserSecurityQuestion
		{
			get { return new DataSource2<UserSecurityQuestionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VanDetailsEntity instances in the database.</summary>
		public DataSource2<VanDetailsEntity> VanDetails
		{
			get { return new DataSource2<VanDetailsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwCallCenterCallReportEntity instances in the database.</summary>
		public DataSource2<VwCallCenterCallReportEntity> VwCallCenterCallReport
		{
			get { return new DataSource2<VwCallCenterCallReportEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwCallQueueCustomerCallDetailsEntity instances in the database.</summary>
		public DataSource2<VwCallQueueCustomerCallDetailsEntity> VwCallQueueCustomerCallDetails
		{
			get { return new DataSource2<VwCallQueueCustomerCallDetailsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwCallQueueCustomerCriteraAssignmentEntity instances in the database.</summary>
		public DataSource2<VwCallQueueCustomerCriteraAssignmentEntity> VwCallQueueCustomerCriteraAssignment
		{
			get { return new DataSource2<VwCallQueueCustomerCriteraAssignmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwCallQueueCustomerCriteraAssignmentForGmsEntity instances in the database.</summary>
		public DataSource2<VwCallQueueCustomerCriteraAssignmentForGmsEntity> VwCallQueueCustomerCriteraAssignmentForGms
		{
			get { return new DataSource2<VwCallQueueCustomerCriteraAssignmentForGmsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwCallQueueCustomerCriteraAssignmentForGmsStatsEntity instances in the database.</summary>
		public DataSource2<VwCallQueueCustomerCriteraAssignmentForGmsStatsEntity> VwCallQueueCustomerCriteraAssignmentForGmsStats
		{
			get { return new DataSource2<VwCallQueueCustomerCriteraAssignmentForGmsStatsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwCallQueueCustomerCriteraAssignmentForStatsEntity instances in the database.</summary>
		public DataSource2<VwCallQueueCustomerCriteraAssignmentForStatsEntity> VwCallQueueCustomerCriteraAssignmentForStats
		{
			get { return new DataSource2<VwCallQueueCustomerCriteraAssignmentForStatsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwCallQueueCustomerCriteraAssignmentWithCustomerEntity instances in the database.</summary>
		public DataSource2<VwCallQueueCustomerCriteraAssignmentWithCustomerEntity> VwCallQueueCustomerCriteraAssignmentWithCustomer
		{
			get { return new DataSource2<VwCallQueueCustomerCriteraAssignmentWithCustomerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwCallRoundCallQueueCriteraAssignmentEntity instances in the database.</summary>
		public DataSource2<VwCallRoundCallQueueCriteraAssignmentEntity> VwCallRoundCallQueueCriteraAssignment
		{
			get { return new DataSource2<VwCallRoundCallQueueCriteraAssignmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwCampaignClickConversionEntity instances in the database.</summary>
		public DataSource2<VwCampaignClickConversionEntity> VwCampaignClickConversion
		{
			get { return new DataSource2<VwCampaignClickConversionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwCustomerAggregateResultSummaryEntity instances in the database.</summary>
		public DataSource2<VwCustomerAggregateResultSummaryEntity> VwCustomerAggregateResultSummary
		{
			get { return new DataSource2<VwCustomerAggregateResultSummaryEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwEventAppointmentEntity instances in the database.</summary>
		public DataSource2<VwEventAppointmentEntity> VwEventAppointment
		{
			get { return new DataSource2<VwEventAppointmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwEventCustomerPreApprovedTestListEntity instances in the database.</summary>
		public DataSource2<VwEventCustomerPreApprovedTestListEntity> VwEventCustomerPreApprovedTestList
		{
			get { return new DataSource2<VwEventCustomerPreApprovedTestListEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwEventCustomersAccountEntity instances in the database.</summary>
		public DataSource2<VwEventCustomersAccountEntity> VwEventCustomersAccount
		{
			get { return new DataSource2<VwEventCustomersAccountEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwEventCustomersViewServiceReportEntity instances in the database.</summary>
		public DataSource2<VwEventCustomersViewServiceReportEntity> VwEventCustomersViewServiceReport
		{
			get { return new DataSource2<VwEventCustomersViewServiceReportEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwFillEventCallQueueCriteraAssignmentEntity instances in the database.</summary>
		public DataSource2<VwFillEventCallQueueCriteraAssignmentEntity> VwFillEventCallQueueCriteraAssignment
		{
			get { return new DataSource2<VwFillEventCallQueueCriteraAssignmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetAllTestForCustomersEntity instances in the database.</summary>
		public DataSource2<VwGetAllTestForCustomersEntity> VwGetAllTestForCustomers
		{
			get { return new DataSource2<VwGetAllTestForCustomersEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetBookedAppointmentForCalculatingBonusEntity instances in the database.</summary>
		public DataSource2<VwGetBookedAppointmentForCalculatingBonusEntity> VwGetBookedAppointmentForCalculatingBonus
		{
			get { return new DataSource2<VwGetBookedAppointmentForCalculatingBonusEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetCallCenterAgentsForConversionReportEntity instances in the database.</summary>
		public DataSource2<VwGetCallCenterAgentsForConversionReportEntity> VwGetCallCenterAgentsForConversionReport
		{
			get { return new DataSource2<VwGetCallCenterAgentsForConversionReportEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetCallQueueCustomersEntity instances in the database.</summary>
		public DataSource2<VwGetCallQueueCustomersEntity> VwGetCallQueueCustomers
		{
			get { return new DataSource2<VwGetCallQueueCustomersEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetCallQueueExcludedCustomersEntity instances in the database.</summary>
		public DataSource2<VwGetCallQueueExcludedCustomersEntity> VwGetCallQueueExcludedCustomers
		{
			get { return new DataSource2<VwGetCallQueueExcludedCustomersEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetCallsEntity instances in the database.</summary>
		public DataSource2<VwGetCallsEntity> VwGetCalls
		{
			get { return new DataSource2<VwGetCallsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetCallsForCalculatingBonusEntity instances in the database.</summary>
		public DataSource2<VwGetCallsForCalculatingBonusEntity> VwGetCallsForCalculatingBonus
		{
			get { return new DataSource2<VwGetCallsForCalculatingBonusEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetCallsForCallQueueEntity instances in the database.</summary>
		public DataSource2<VwGetCallsForCallQueueEntity> VwGetCallsForCallQueue
		{
			get { return new DataSource2<VwGetCallsForCallQueueEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetCallsForSuppressionEntity instances in the database.</summary>
		public DataSource2<VwGetCallsForSuppressionEntity> VwGetCallsForSuppression
		{
			get { return new DataSource2<VwGetCallsForSuppressionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetConfirmationCallQueueCustomersWithoutSuppressionEntity instances in the database.</summary>
		public DataSource2<VwGetConfirmationCallQueueCustomersWithoutSuppressionEntity> VwGetConfirmationCallQueueCustomersWithoutSuppression
		{
			get { return new DataSource2<VwGetConfirmationCallQueueCustomersWithoutSuppressionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetCustomerForMailRoundInsertionEntity instances in the database.</summary>
		public DataSource2<VwGetCustomerForMailRoundInsertionEntity> VwGetCustomerForMailRoundInsertion
		{
			get { return new DataSource2<VwGetCustomerForMailRoundInsertionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetCustomerIdsHavingSingleTagForCallQueueEntity instances in the database.</summary>
		public DataSource2<VwGetCustomerIdsHavingSingleTagForCallQueueEntity> VwGetCustomerIdsHavingSingleTagForCallQueue
		{
			get { return new DataSource2<VwGetCustomerIdsHavingSingleTagForCallQueueEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetCustomersForCallQueueWithCustomerEntity instances in the database.</summary>
		public DataSource2<VwGetCustomersForCallQueueWithCustomerEntity> VwGetCustomersForCallQueueWithCustomer
		{
			get { return new DataSource2<VwGetCustomersForCallQueueWithCustomerEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetCustomersForCallQueueWithCustomerViciEntity instances in the database.</summary>
		public DataSource2<VwGetCustomersForCallQueueWithCustomerViciEntity> VwGetCustomersForCallQueueWithCustomerVici
		{
			get { return new DataSource2<VwGetCustomersForCallQueueWithCustomerViciEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetCustomersForConfirmationCallQueueEntity instances in the database.</summary>
		public DataSource2<VwGetCustomersForConfirmationCallQueueEntity> VwGetCustomersForConfirmationCallQueue
		{
			get { return new DataSource2<VwGetCustomersForConfirmationCallQueueEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetCustomersForNotInCallQueueEntity instances in the database.</summary>
		public DataSource2<VwGetCustomersForNotInCallQueueEntity> VwGetCustomersForNotInCallQueue
		{
			get { return new DataSource2<VwGetCustomersForNotInCallQueueEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetCustomersToGenerateCallQueueEntity instances in the database.</summary>
		public DataSource2<VwGetCustomersToGenerateCallQueueEntity> VwGetCustomersToGenerateCallQueue
		{
			get { return new DataSource2<VwGetCustomersToGenerateCallQueueEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetCustomersToGenerateConfirmationCallQueueEntity instances in the database.</summary>
		public DataSource2<VwGetCustomersToGenerateConfirmationCallQueueEntity> VwGetCustomersToGenerateConfirmationCallQueue
		{
			get { return new DataSource2<VwGetCustomersToGenerateConfirmationCallQueueEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetCustomersToGenerateFillEventCallQueueEntity instances in the database.</summary>
		public DataSource2<VwGetCustomersToGenerateFillEventCallQueueEntity> VwGetCustomersToGenerateFillEventCallQueue
		{
			get { return new DataSource2<VwGetCustomersToGenerateFillEventCallQueueEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetCustomersToGenerateFillEventCallQueue_Entity instances in the database.</summary>
		public DataSource2<VwGetCustomersToGenerateFillEventCallQueue_Entity> VwGetCustomersToGenerateFillEventCallQueue_
		{
			get { return new DataSource2<VwGetCustomersToGenerateFillEventCallQueue_Entity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetCustomerTagForCallQueueEntity instances in the database.</summary>
		public DataSource2<VwGetCustomerTagForCallQueueEntity> VwGetCustomerTagForCallQueue
		{
			get { return new DataSource2<VwGetCustomerTagForCallQueueEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetDataForSkippedCallReportEntity instances in the database.</summary>
		public DataSource2<VwGetDataForSkippedCallReportEntity> VwGetDataForSkippedCallReport
		{
			get { return new DataSource2<VwGetDataForSkippedCallReportEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetDirectMailForCallQueueEntity instances in the database.</summary>
		public DataSource2<VwGetDirectMailForCallQueueEntity> VwGetDirectMailForCallQueue
		{
			get { return new DataSource2<VwGetDirectMailForCallQueueEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetEventCustomerEawvTestInOrderEntity instances in the database.</summary>
		public DataSource2<VwGetEventCustomerEawvTestInOrderEntity> VwGetEventCustomerEawvTestInOrder
		{
			get { return new DataSource2<VwGetEventCustomerEawvTestInOrderEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetHkynTestCustomersEntity instances in the database.</summary>
		public DataSource2<VwGetHkynTestCustomersEntity> VwGetHkynTestCustomers
		{
			get { return new DataSource2<VwGetHkynTestCustomersEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetKynTestCustomersEntity instances in the database.</summary>
		public DataSource2<VwGetKynTestCustomersEntity> VwGetKynTestCustomers
		{
			get { return new DataSource2<VwGetKynTestCustomersEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetMyBioCheckTestCustomersEntity instances in the database.</summary>
		public DataSource2<VwGetMyBioCheckTestCustomersEntity> VwGetMyBioCheckTestCustomers
		{
			get { return new DataSource2<VwGetMyBioCheckTestCustomersEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetOutboundCallsEntity instances in the database.</summary>
		public DataSource2<VwGetOutboundCallsEntity> VwGetOutboundCalls
		{
			get { return new DataSource2<VwGetOutboundCallsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwGetTestPerformedReportEntity instances in the database.</summary>
		public DataSource2<VwGetTestPerformedReportEntity> VwGetTestPerformedReport
		{
			get { return new DataSource2<VwGetTestPerformedReportEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwHospitalPartnerCustomersEntity instances in the database.</summary>
		public DataSource2<VwHospitalPartnerCustomersEntity> VwHospitalPartnerCustomers
		{
			get { return new DataSource2<VwHospitalPartnerCustomersEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwHostEventDetailsEntity instances in the database.</summary>
		public DataSource2<VwHostEventDetailsEntity> VwHostEventDetails
		{
			get { return new DataSource2<VwHostEventDetailsEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwLanguageBarrierCallQueueCriteraAssignmentEntity instances in the database.</summary>
		public DataSource2<VwLanguageBarrierCallQueueCriteraAssignmentEntity> VwLanguageBarrierCallQueueCriteraAssignment
		{
			get { return new DataSource2<VwLanguageBarrierCallQueueCriteraAssignmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwMailRoundCallQueueCriteraAssignmentEntity instances in the database.</summary>
		public DataSource2<VwMailRoundCallQueueCriteraAssignmentEntity> VwMailRoundCallQueueCriteraAssignment
		{
			get { return new DataSource2<VwMailRoundCallQueueCriteraAssignmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwOutreachCallReportEntity instances in the database.</summary>
		public DataSource2<VwOutreachCallReportEntity> VwOutreachCallReport
		{
			get { return new DataSource2<VwOutreachCallReportEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwPcpAppointmetnDispositionEntity instances in the database.</summary>
		public DataSource2<VwPcpAppointmetnDispositionEntity> VwPcpAppointmetnDisposition
		{
			get { return new DataSource2<VwPcpAppointmetnDispositionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwPhysicianQueueRecordEntity instances in the database.</summary>
		public DataSource2<VwPhysicianQueueRecordEntity> VwPhysicianQueueRecord
		{
			get { return new DataSource2<VwPhysicianQueueRecordEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting VwUncontactedCustomerCallQueueCriteraAssignmentEntity instances in the database.</summary>
		public DataSource2<VwUncontactedCustomerCallQueueCriteraAssignmentEntity> VwUncontactedCustomerCallQueueCriteraAssignment
		{
			get { return new DataSource2<VwUncontactedCustomerCallQueueCriteraAssignmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting WellMedAttestationEntity instances in the database.</summary>
		public DataSource2<WellMedAttestationEntity> WellMedAttestation
		{
			get { return new DataSource2<WellMedAttestationEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting WfEntity instances in the database.</summary>
		public DataSource2<WfEntity> Wf
		{
			get { return new DataSource2<WfEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting WidgetEntity instances in the database.</summary>
		public DataSource2<WidgetEntity> Widget
		{
			get { return new DataSource2<WidgetEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ZipEntity instances in the database.</summary>
		public DataSource2<ZipEntity> Zip
		{
			get { return new DataSource2<ZipEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ZipDataEntity instances in the database.</summary>
		public DataSource2<ZipDataEntity> ZipData
		{
			get { return new DataSource2<ZipDataEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ZipRadiusDistanceEntity instances in the database.</summary>
		public DataSource2<ZipRadiusDistanceEntity> ZipRadiusDistance
		{
			get { return new DataSource2<ZipRadiusDistanceEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		
		#region Class Property Declarations
		/// <summary> Gets / sets the IDataAccessAdapter to use for the queries created with this meta data object.</summary>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public IDataAccessAdapter AdapterToUse
		{
			get { return _adapterToUse;}
			set { _adapterToUse = value;}
		}

		/// <summary>Gets or sets the custom function mappings to use. These take higher precedence than the ones in the DQE to use</summary>
		public FunctionMappingStore CustomFunctionMappings
		{
			get { return _customFunctionMappings; }
			set { _customFunctionMappings = value; }
		}
		
		/// <summary>Gets or sets the Context instance to use for entity fetches.</summary>
		public Context ContextToUse
		{
			get { return _contextToUse;}
			set { _contextToUse = value;}
		}
		#endregion
	}
}