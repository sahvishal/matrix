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
	/// Entity class which represents the entity 'Test'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class TestEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AccountCustomerResultTestDependencyEntity> _accountCustomerResultTestDependency;
		private EntityCollection<AccountHealthPlanResultTestDependencyEntity> _accountHealthPlanResultTestDependency;
		private EntityCollection<AccountNotReviewableTestEntity> _accountNotReviewableTest;
		private EntityCollection<AccountPcpResultTestDependencyEntity> _accountPcpResultTestDependency;
		private EntityCollection<AccountTestEntity> _accountTest;
		private EntityCollection<BillingAccountTestEntity> _billingAccountTest;
		private EntityCollection<ClinicalTestQualificationCriteriaEntity> _clinicalTestQualificationCriteria;
		private EntityCollection<CustomerEventScreeningTestsEntity> _customerEventScreeningTests;
		private EntityCollection<CustomerEventTestFindingEntity> _customerEventTestFinding;
		private EntityCollection<CustomerHealthQuestionGroupEntity> _customerHealthQuestionGroup;
		private EntityCollection<DependentDisqualifiedTestEntity> _dependentDisqualifiedTest;
		private EntityCollection<DisqualifiedTestEntity> _disqualifiedTest;
		private EntityCollection<EventCustomerPreApprovedPackageTestEntity> _eventCustomerPreApprovedPackageTest;
		private EntityCollection<EventCustomerPreApprovedTestEntity> _eventCustomerPreApprovedTest;
		private EntityCollection<EventCustomerRequiredTestEntity> _eventCustomerRequiredTest;
		private EntityCollection<EventCustomerRetestEntity> _eventCustomerRetest;
		private EntityCollection<EventCustomerTestNotPerformedNotificationEntity> _eventCustomerTestNotPerformedNotification;
		private EntityCollection<EventPhysicianTestEntity> _eventPhysicianTest;
		private EntityCollection<EventPodRoomTestEntity> _eventPodRoomTest;
		private EntityCollection<EventTestEntity> _eventTest;
		private EntityCollection<HealthPlanRevenueItemEntity> _healthPlanRevenueItem;
		private EntityCollection<InventoryItemTestEntity> _inventoryItemTest;
		private EntityCollection<KynLabValuesEntity> _kynLabValues;
		private EntityCollection<PackageTestEntity> _packageTest;
		private EntityCollection<PhysicianPermittedTestEntity> _physicianPermittedTest;
		private EntityCollection<PodRoomTestEntity> _podRoomTest;
		private EntityCollection<PodTestEntity> _podTest;
		private EntityCollection<PreApprovedTestEntity> _preApprovedTest;
		private EntityCollection<PreQualificationQuestionEntity> _preQualificationQuestion;
		private EntityCollection<PreQualificationTemplateDependentTestEntity> _preQualificationTemplateDependentTest;
		private EntityCollection<PreQualificationTestTemplateEntity> _preQualificationTestTemplate;
		private EntityCollection<ProspectActivityEntity> _prospectActivity;
		private EntityCollection<RequiredTestEntity> _requiredTest;
		private EntityCollection<ResultArchiveUploadLogEntity> _resultArchiveUploadLog;
		private EntityCollection<StaffEventRoleTestEntity> _staffEventRoleTest;
		private EntityCollection<StandardFindingTestReadingEntity> _standardFindingTestReading;
		private EntityCollection<TestDependencyRuleEntity> _testDependencyRule;
		private EntityCollection<TestDependencyRuleEntity> _testDependencyRule_;
		private EntityCollection<TestHcpcsCodeEntity> _testHcpcsCode;
		private EntityCollection<TestIncidentalFindingEntity> _testIncidentalFinding;
		private EntityCollection<TestReadingEntity> _testReading;
		private EntityCollection<TestSourceCodeDiscountEntity> _testSourceCodeDiscount;
		private EntityCollection<TestUnableScreenReasonEntity> _testUnableScreenReason;
		private EntityCollection<AccountEntity> _accountCollectionViaAccountPcpResultTestDependency;
		private EntityCollection<AccountEntity> _accountCollectionViaAccountTest;
		private EntityCollection<AccountEntity> _accountCollectionViaAccountNotReviewableTest;
		private EntityCollection<AccountEntity> _accountCollectionViaAccountCustomerResultTestDependency;
		private EntityCollection<AccountEntity> _accountCollectionViaAccountHealthPlanResultTestDependency;
		private EntityCollection<BillingAccountEntity> _billingAccountCollectionViaBillingAccountTest;
		private EntityCollection<CouponsEntity> _couponsCollectionViaTestSourceCodeDiscount;
		private EntityCollection<CustomerHealthQuestionsEntity> _customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_;
		private EntityCollection<CustomerHealthQuestionsEntity> _customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaDependentDisqualifiedTest;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerEventTestFinding;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaDisqualifiedTest;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaResultArchiveUploadLog;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaRequiredTest;
		private EntityCollection<EventCustomerResultEntity> _eventCustomerResultCollectionViaKynLabValues;
		private EntityCollection<EventCustomerResultEntity> _eventCustomerResultCollectionViaCustomerEventScreeningTests;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaDisqualifiedTest;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaEventCustomerPreApprovedTest;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaEventCustomerPreApprovedPackageTest;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaEventCustomerRequiredTest;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaEventCustomerTestNotPerformedNotification;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaDependentDisqualifiedTest;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaEventCustomerRetest;
		private EntityCollection<EventPodRoomEntity> _eventPodRoomCollectionViaEventPodRoomTest;
		private EntityCollection<EventsEntity> _eventsCollectionViaDependentDisqualifiedTest;
		private EntityCollection<EventsEntity> _eventsCollectionViaDisqualifiedTest;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventPhysicianTest;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventTest;
		private EntityCollection<EventsEntity> _eventsCollectionViaCustomerEventTestFinding;
		private EntityCollection<HafTemplateEntity> _hafTemplateCollectionViaClinicalTestQualificationCriteria;
		private EntityCollection<HafTemplateEntity> _hafTemplateCollectionViaEventTest;
		private EntityCollection<HcpcsCodeEntity> _hcpcsCodeCollectionViaTestHcpcsCode;
		private EntityCollection<HealthPlanRevenueEntity> _healthPlanRevenueCollectionViaHealthPlanRevenueItem;
		private EntityCollection<IncidentalFindingsEntity> _incidentalFindingsCollectionViaTestIncidentalFinding;
		private EntityCollection<InventoryItemEntity> _inventoryItemCollectionViaInventoryItemTest;
		private EntityCollection<LookupEntity> _lookupCollectionViaTestUnableScreenReason;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventTest_;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventTest;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventTest__;
		private EntityCollection<LookupEntity> _lookupCollectionViaClinicalTestQualificationCriteria;
		private EntityCollection<LookupEntity> _lookupCollectionViaPreQualificationQuestion;
		private EntityCollection<LookupEntity> _lookupCollectionViaClinicalTestQualificationCriteria_;
		private EntityCollection<LookupEntity> _lookupCollectionViaKynLabValues;
		private EntityCollection<NotificationTypeEntity> _notificationTypeCollectionViaEventCustomerTestNotPerformedNotification;
		private EntityCollection<OrderItemEntity> _orderItemCollectionViaProspectActivity;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaPreQualificationQuestion;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaPreApprovedTest;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaTestHcpcsCode;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaTestHcpcsCode_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaRequiredTest;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaPreQualificationTestTemplate;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaPreQualificationTestTemplate_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventCustomerRetest;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaClinicalTestQualificationCriteria;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventPhysicianTest__;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaClinicalTestQualificationCriteria_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventPhysicianTest;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaDisqualifiedTest_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventPhysicianTest_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaDisqualifiedTest;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaKynLabValues;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaKynLabValues_;
		private EntityCollection<PackageEntity> _packageCollectionViaEventCustomerPreApprovedPackageTest;
		private EntityCollection<PackageEntity> _packageCollectionViaPackageTest;
		private EntityCollection<PackageEntity> _packageCollectionViaHealthPlanRevenueItem;
		private EntityCollection<PhysicianProfileEntity> _physicianProfileCollectionViaPhysicianPermittedTest;
		private EntityCollection<PodDetailsEntity> _podDetailsCollectionViaPodTest;
		private EntityCollection<PodRoomEntity> _podRoomCollectionViaPodRoomTest;
		private EntityCollection<PreQualificationQuestionEntity> _preQualificationQuestionCollectionViaDisqualifiedTest;
		private EntityCollection<PreQualificationTestTemplateEntity> _preQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest;
		private EntityCollection<PreQualificationTestTemplateEntity> _preQualificationTestTemplateCollectionViaEventTest;
		private EntityCollection<ReadingEntity> _readingCollectionViaTestReading;
		private EntityCollection<ReadingEntity> _readingCollectionViaStandardFindingTestReading;
		private EntityCollection<ResultArchiveUploadEntity> _resultArchiveUploadCollectionViaResultArchiveUploadLog;
		private EntityCollection<StaffEventRoleEntity> _staffEventRoleCollectionViaStaffEventRoleTest;
		private EntityCollection<StandardFindingEntity> _standardFindingCollectionViaStandardFindingTestReading;
		private HafTemplateEntity _hafTemplate;
		private LookupEntity _lookup__;
		private LookupEntity _lookup_;
		private LookupEntity _lookup;
		private PreQualificationTestTemplateEntity _preQualificationTestTemplate_;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name HafTemplate</summary>
			public static readonly string HafTemplate = "HafTemplate";
			/// <summary>Member name Lookup__</summary>
			public static readonly string Lookup__ = "Lookup__";
			/// <summary>Member name Lookup_</summary>
			public static readonly string Lookup_ = "Lookup_";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name PreQualificationTestTemplate_</summary>
			public static readonly string PreQualificationTestTemplate_ = "PreQualificationTestTemplate_";
			/// <summary>Member name AccountCustomerResultTestDependency</summary>
			public static readonly string AccountCustomerResultTestDependency = "AccountCustomerResultTestDependency";
			/// <summary>Member name AccountHealthPlanResultTestDependency</summary>
			public static readonly string AccountHealthPlanResultTestDependency = "AccountHealthPlanResultTestDependency";
			/// <summary>Member name AccountNotReviewableTest</summary>
			public static readonly string AccountNotReviewableTest = "AccountNotReviewableTest";
			/// <summary>Member name AccountPcpResultTestDependency</summary>
			public static readonly string AccountPcpResultTestDependency = "AccountPcpResultTestDependency";
			/// <summary>Member name AccountTest</summary>
			public static readonly string AccountTest = "AccountTest";
			/// <summary>Member name BillingAccountTest</summary>
			public static readonly string BillingAccountTest = "BillingAccountTest";
			/// <summary>Member name ClinicalTestQualificationCriteria</summary>
			public static readonly string ClinicalTestQualificationCriteria = "ClinicalTestQualificationCriteria";
			/// <summary>Member name CustomerEventScreeningTests</summary>
			public static readonly string CustomerEventScreeningTests = "CustomerEventScreeningTests";
			/// <summary>Member name CustomerEventTestFinding</summary>
			public static readonly string CustomerEventTestFinding = "CustomerEventTestFinding";
			/// <summary>Member name CustomerHealthQuestionGroup</summary>
			public static readonly string CustomerHealthQuestionGroup = "CustomerHealthQuestionGroup";
			/// <summary>Member name DependentDisqualifiedTest</summary>
			public static readonly string DependentDisqualifiedTest = "DependentDisqualifiedTest";
			/// <summary>Member name DisqualifiedTest</summary>
			public static readonly string DisqualifiedTest = "DisqualifiedTest";
			/// <summary>Member name EventCustomerPreApprovedPackageTest</summary>
			public static readonly string EventCustomerPreApprovedPackageTest = "EventCustomerPreApprovedPackageTest";
			/// <summary>Member name EventCustomerPreApprovedTest</summary>
			public static readonly string EventCustomerPreApprovedTest = "EventCustomerPreApprovedTest";
			/// <summary>Member name EventCustomerRequiredTest</summary>
			public static readonly string EventCustomerRequiredTest = "EventCustomerRequiredTest";
			/// <summary>Member name EventCustomerRetest</summary>
			public static readonly string EventCustomerRetest = "EventCustomerRetest";
			/// <summary>Member name EventCustomerTestNotPerformedNotification</summary>
			public static readonly string EventCustomerTestNotPerformedNotification = "EventCustomerTestNotPerformedNotification";
			/// <summary>Member name EventPhysicianTest</summary>
			public static readonly string EventPhysicianTest = "EventPhysicianTest";
			/// <summary>Member name EventPodRoomTest</summary>
			public static readonly string EventPodRoomTest = "EventPodRoomTest";
			/// <summary>Member name EventTest</summary>
			public static readonly string EventTest = "EventTest";
			/// <summary>Member name HealthPlanRevenueItem</summary>
			public static readonly string HealthPlanRevenueItem = "HealthPlanRevenueItem";
			/// <summary>Member name InventoryItemTest</summary>
			public static readonly string InventoryItemTest = "InventoryItemTest";
			/// <summary>Member name KynLabValues</summary>
			public static readonly string KynLabValues = "KynLabValues";
			/// <summary>Member name PackageTest</summary>
			public static readonly string PackageTest = "PackageTest";
			/// <summary>Member name PhysicianPermittedTest</summary>
			public static readonly string PhysicianPermittedTest = "PhysicianPermittedTest";
			/// <summary>Member name PodRoomTest</summary>
			public static readonly string PodRoomTest = "PodRoomTest";
			/// <summary>Member name PodTest</summary>
			public static readonly string PodTest = "PodTest";
			/// <summary>Member name PreApprovedTest</summary>
			public static readonly string PreApprovedTest = "PreApprovedTest";
			/// <summary>Member name PreQualificationQuestion</summary>
			public static readonly string PreQualificationQuestion = "PreQualificationQuestion";
			/// <summary>Member name PreQualificationTemplateDependentTest</summary>
			public static readonly string PreQualificationTemplateDependentTest = "PreQualificationTemplateDependentTest";
			/// <summary>Member name PreQualificationTestTemplate</summary>
			public static readonly string PreQualificationTestTemplate = "PreQualificationTestTemplate";
			/// <summary>Member name ProspectActivity</summary>
			public static readonly string ProspectActivity = "ProspectActivity";
			/// <summary>Member name RequiredTest</summary>
			public static readonly string RequiredTest = "RequiredTest";
			/// <summary>Member name ResultArchiveUploadLog</summary>
			public static readonly string ResultArchiveUploadLog = "ResultArchiveUploadLog";
			/// <summary>Member name StaffEventRoleTest</summary>
			public static readonly string StaffEventRoleTest = "StaffEventRoleTest";
			/// <summary>Member name StandardFindingTestReading</summary>
			public static readonly string StandardFindingTestReading = "StandardFindingTestReading";
			/// <summary>Member name TestDependencyRule</summary>
			public static readonly string TestDependencyRule = "TestDependencyRule";
			/// <summary>Member name TestDependencyRule_</summary>
			public static readonly string TestDependencyRule_ = "TestDependencyRule_";
			/// <summary>Member name TestHcpcsCode</summary>
			public static readonly string TestHcpcsCode = "TestHcpcsCode";
			/// <summary>Member name TestIncidentalFinding</summary>
			public static readonly string TestIncidentalFinding = "TestIncidentalFinding";
			/// <summary>Member name TestReading</summary>
			public static readonly string TestReading = "TestReading";
			/// <summary>Member name TestSourceCodeDiscount</summary>
			public static readonly string TestSourceCodeDiscount = "TestSourceCodeDiscount";
			/// <summary>Member name TestUnableScreenReason</summary>
			public static readonly string TestUnableScreenReason = "TestUnableScreenReason";
			/// <summary>Member name AccountCollectionViaAccountPcpResultTestDependency</summary>
			public static readonly string AccountCollectionViaAccountPcpResultTestDependency = "AccountCollectionViaAccountPcpResultTestDependency";
			/// <summary>Member name AccountCollectionViaAccountTest</summary>
			public static readonly string AccountCollectionViaAccountTest = "AccountCollectionViaAccountTest";
			/// <summary>Member name AccountCollectionViaAccountNotReviewableTest</summary>
			public static readonly string AccountCollectionViaAccountNotReviewableTest = "AccountCollectionViaAccountNotReviewableTest";
			/// <summary>Member name AccountCollectionViaAccountCustomerResultTestDependency</summary>
			public static readonly string AccountCollectionViaAccountCustomerResultTestDependency = "AccountCollectionViaAccountCustomerResultTestDependency";
			/// <summary>Member name AccountCollectionViaAccountHealthPlanResultTestDependency</summary>
			public static readonly string AccountCollectionViaAccountHealthPlanResultTestDependency = "AccountCollectionViaAccountHealthPlanResultTestDependency";
			/// <summary>Member name BillingAccountCollectionViaBillingAccountTest</summary>
			public static readonly string BillingAccountCollectionViaBillingAccountTest = "BillingAccountCollectionViaBillingAccountTest";
			/// <summary>Member name CouponsCollectionViaTestSourceCodeDiscount</summary>
			public static readonly string CouponsCollectionViaTestSourceCodeDiscount = "CouponsCollectionViaTestSourceCodeDiscount";
			/// <summary>Member name CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_</summary>
			public static readonly string CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_ = "CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_";
			/// <summary>Member name CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria</summary>
			public static readonly string CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria = "CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria";
			/// <summary>Member name CustomerProfileCollectionViaDependentDisqualifiedTest</summary>
			public static readonly string CustomerProfileCollectionViaDependentDisqualifiedTest = "CustomerProfileCollectionViaDependentDisqualifiedTest";
			/// <summary>Member name CustomerProfileCollectionViaCustomerEventTestFinding</summary>
			public static readonly string CustomerProfileCollectionViaCustomerEventTestFinding = "CustomerProfileCollectionViaCustomerEventTestFinding";
			/// <summary>Member name CustomerProfileCollectionViaDisqualifiedTest</summary>
			public static readonly string CustomerProfileCollectionViaDisqualifiedTest = "CustomerProfileCollectionViaDisqualifiedTest";
			/// <summary>Member name CustomerProfileCollectionViaResultArchiveUploadLog</summary>
			public static readonly string CustomerProfileCollectionViaResultArchiveUploadLog = "CustomerProfileCollectionViaResultArchiveUploadLog";
			/// <summary>Member name CustomerProfileCollectionViaRequiredTest</summary>
			public static readonly string CustomerProfileCollectionViaRequiredTest = "CustomerProfileCollectionViaRequiredTest";
			/// <summary>Member name EventCustomerResultCollectionViaKynLabValues</summary>
			public static readonly string EventCustomerResultCollectionViaKynLabValues = "EventCustomerResultCollectionViaKynLabValues";
			/// <summary>Member name EventCustomerResultCollectionViaCustomerEventScreeningTests</summary>
			public static readonly string EventCustomerResultCollectionViaCustomerEventScreeningTests = "EventCustomerResultCollectionViaCustomerEventScreeningTests";
			/// <summary>Member name EventCustomersCollectionViaDisqualifiedTest</summary>
			public static readonly string EventCustomersCollectionViaDisqualifiedTest = "EventCustomersCollectionViaDisqualifiedTest";
			/// <summary>Member name EventCustomersCollectionViaEventCustomerPreApprovedTest</summary>
			public static readonly string EventCustomersCollectionViaEventCustomerPreApprovedTest = "EventCustomersCollectionViaEventCustomerPreApprovedTest";
			/// <summary>Member name EventCustomersCollectionViaEventCustomerPreApprovedPackageTest</summary>
			public static readonly string EventCustomersCollectionViaEventCustomerPreApprovedPackageTest = "EventCustomersCollectionViaEventCustomerPreApprovedPackageTest";
			/// <summary>Member name EventCustomersCollectionViaEventCustomerRequiredTest</summary>
			public static readonly string EventCustomersCollectionViaEventCustomerRequiredTest = "EventCustomersCollectionViaEventCustomerRequiredTest";
			/// <summary>Member name EventCustomersCollectionViaEventCustomerTestNotPerformedNotification</summary>
			public static readonly string EventCustomersCollectionViaEventCustomerTestNotPerformedNotification = "EventCustomersCollectionViaEventCustomerTestNotPerformedNotification";
			/// <summary>Member name EventCustomersCollectionViaDependentDisqualifiedTest</summary>
			public static readonly string EventCustomersCollectionViaDependentDisqualifiedTest = "EventCustomersCollectionViaDependentDisqualifiedTest";
			/// <summary>Member name EventCustomersCollectionViaEventCustomerRetest</summary>
			public static readonly string EventCustomersCollectionViaEventCustomerRetest = "EventCustomersCollectionViaEventCustomerRetest";
			/// <summary>Member name EventPodRoomCollectionViaEventPodRoomTest</summary>
			public static readonly string EventPodRoomCollectionViaEventPodRoomTest = "EventPodRoomCollectionViaEventPodRoomTest";
			/// <summary>Member name EventsCollectionViaDependentDisqualifiedTest</summary>
			public static readonly string EventsCollectionViaDependentDisqualifiedTest = "EventsCollectionViaDependentDisqualifiedTest";
			/// <summary>Member name EventsCollectionViaDisqualifiedTest</summary>
			public static readonly string EventsCollectionViaDisqualifiedTest = "EventsCollectionViaDisqualifiedTest";
			/// <summary>Member name EventsCollectionViaEventPhysicianTest</summary>
			public static readonly string EventsCollectionViaEventPhysicianTest = "EventsCollectionViaEventPhysicianTest";
			/// <summary>Member name EventsCollectionViaEventTest</summary>
			public static readonly string EventsCollectionViaEventTest = "EventsCollectionViaEventTest";
			/// <summary>Member name EventsCollectionViaCustomerEventTestFinding</summary>
			public static readonly string EventsCollectionViaCustomerEventTestFinding = "EventsCollectionViaCustomerEventTestFinding";
			/// <summary>Member name HafTemplateCollectionViaClinicalTestQualificationCriteria</summary>
			public static readonly string HafTemplateCollectionViaClinicalTestQualificationCriteria = "HafTemplateCollectionViaClinicalTestQualificationCriteria";
			/// <summary>Member name HafTemplateCollectionViaEventTest</summary>
			public static readonly string HafTemplateCollectionViaEventTest = "HafTemplateCollectionViaEventTest";
			/// <summary>Member name HcpcsCodeCollectionViaTestHcpcsCode</summary>
			public static readonly string HcpcsCodeCollectionViaTestHcpcsCode = "HcpcsCodeCollectionViaTestHcpcsCode";
			/// <summary>Member name HealthPlanRevenueCollectionViaHealthPlanRevenueItem</summary>
			public static readonly string HealthPlanRevenueCollectionViaHealthPlanRevenueItem = "HealthPlanRevenueCollectionViaHealthPlanRevenueItem";
			/// <summary>Member name IncidentalFindingsCollectionViaTestIncidentalFinding</summary>
			public static readonly string IncidentalFindingsCollectionViaTestIncidentalFinding = "IncidentalFindingsCollectionViaTestIncidentalFinding";
			/// <summary>Member name InventoryItemCollectionViaInventoryItemTest</summary>
			public static readonly string InventoryItemCollectionViaInventoryItemTest = "InventoryItemCollectionViaInventoryItemTest";
			/// <summary>Member name LookupCollectionViaTestUnableScreenReason</summary>
			public static readonly string LookupCollectionViaTestUnableScreenReason = "LookupCollectionViaTestUnableScreenReason";
			/// <summary>Member name LookupCollectionViaEventTest_</summary>
			public static readonly string LookupCollectionViaEventTest_ = "LookupCollectionViaEventTest_";
			/// <summary>Member name LookupCollectionViaEventTest</summary>
			public static readonly string LookupCollectionViaEventTest = "LookupCollectionViaEventTest";
			/// <summary>Member name LookupCollectionViaEventTest__</summary>
			public static readonly string LookupCollectionViaEventTest__ = "LookupCollectionViaEventTest__";
			/// <summary>Member name LookupCollectionViaClinicalTestQualificationCriteria</summary>
			public static readonly string LookupCollectionViaClinicalTestQualificationCriteria = "LookupCollectionViaClinicalTestQualificationCriteria";
			/// <summary>Member name LookupCollectionViaPreQualificationQuestion</summary>
			public static readonly string LookupCollectionViaPreQualificationQuestion = "LookupCollectionViaPreQualificationQuestion";
			/// <summary>Member name LookupCollectionViaClinicalTestQualificationCriteria_</summary>
			public static readonly string LookupCollectionViaClinicalTestQualificationCriteria_ = "LookupCollectionViaClinicalTestQualificationCriteria_";
			/// <summary>Member name LookupCollectionViaKynLabValues</summary>
			public static readonly string LookupCollectionViaKynLabValues = "LookupCollectionViaKynLabValues";
			/// <summary>Member name NotificationTypeCollectionViaEventCustomerTestNotPerformedNotification</summary>
			public static readonly string NotificationTypeCollectionViaEventCustomerTestNotPerformedNotification = "NotificationTypeCollectionViaEventCustomerTestNotPerformedNotification";
			/// <summary>Member name OrderItemCollectionViaProspectActivity</summary>
			public static readonly string OrderItemCollectionViaProspectActivity = "OrderItemCollectionViaProspectActivity";
			/// <summary>Member name OrganizationRoleUserCollectionViaPreQualificationQuestion</summary>
			public static readonly string OrganizationRoleUserCollectionViaPreQualificationQuestion = "OrganizationRoleUserCollectionViaPreQualificationQuestion";
			/// <summary>Member name OrganizationRoleUserCollectionViaPreApprovedTest</summary>
			public static readonly string OrganizationRoleUserCollectionViaPreApprovedTest = "OrganizationRoleUserCollectionViaPreApprovedTest";
			/// <summary>Member name OrganizationRoleUserCollectionViaTestHcpcsCode</summary>
			public static readonly string OrganizationRoleUserCollectionViaTestHcpcsCode = "OrganizationRoleUserCollectionViaTestHcpcsCode";
			/// <summary>Member name OrganizationRoleUserCollectionViaTestHcpcsCode_</summary>
			public static readonly string OrganizationRoleUserCollectionViaTestHcpcsCode_ = "OrganizationRoleUserCollectionViaTestHcpcsCode_";
			/// <summary>Member name OrganizationRoleUserCollectionViaRequiredTest</summary>
			public static readonly string OrganizationRoleUserCollectionViaRequiredTest = "OrganizationRoleUserCollectionViaRequiredTest";
			/// <summary>Member name OrganizationRoleUserCollectionViaPreQualificationTestTemplate</summary>
			public static readonly string OrganizationRoleUserCollectionViaPreQualificationTestTemplate = "OrganizationRoleUserCollectionViaPreQualificationTestTemplate";
			/// <summary>Member name OrganizationRoleUserCollectionViaPreQualificationTestTemplate_</summary>
			public static readonly string OrganizationRoleUserCollectionViaPreQualificationTestTemplate_ = "OrganizationRoleUserCollectionViaPreQualificationTestTemplate_";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification = "OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventCustomerRetest</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventCustomerRetest = "OrganizationRoleUserCollectionViaEventCustomerRetest";
			/// <summary>Member name OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria</summary>
			public static readonly string OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria = "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventPhysicianTest__</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventPhysicianTest__ = "OrganizationRoleUserCollectionViaEventPhysicianTest__";
			/// <summary>Member name OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_</summary>
			public static readonly string OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_ = "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventPhysicianTest</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventPhysicianTest = "OrganizationRoleUserCollectionViaEventPhysicianTest";
			/// <summary>Member name OrganizationRoleUserCollectionViaDisqualifiedTest_</summary>
			public static readonly string OrganizationRoleUserCollectionViaDisqualifiedTest_ = "OrganizationRoleUserCollectionViaDisqualifiedTest_";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventPhysicianTest_</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventPhysicianTest_ = "OrganizationRoleUserCollectionViaEventPhysicianTest_";
			/// <summary>Member name OrganizationRoleUserCollectionViaDisqualifiedTest</summary>
			public static readonly string OrganizationRoleUserCollectionViaDisqualifiedTest = "OrganizationRoleUserCollectionViaDisqualifiedTest";
			/// <summary>Member name OrganizationRoleUserCollectionViaKynLabValues</summary>
			public static readonly string OrganizationRoleUserCollectionViaKynLabValues = "OrganizationRoleUserCollectionViaKynLabValues";
			/// <summary>Member name OrganizationRoleUserCollectionViaKynLabValues_</summary>
			public static readonly string OrganizationRoleUserCollectionViaKynLabValues_ = "OrganizationRoleUserCollectionViaKynLabValues_";
			/// <summary>Member name PackageCollectionViaEventCustomerPreApprovedPackageTest</summary>
			public static readonly string PackageCollectionViaEventCustomerPreApprovedPackageTest = "PackageCollectionViaEventCustomerPreApprovedPackageTest";
			/// <summary>Member name PackageCollectionViaPackageTest</summary>
			public static readonly string PackageCollectionViaPackageTest = "PackageCollectionViaPackageTest";
			/// <summary>Member name PackageCollectionViaHealthPlanRevenueItem</summary>
			public static readonly string PackageCollectionViaHealthPlanRevenueItem = "PackageCollectionViaHealthPlanRevenueItem";
			/// <summary>Member name PhysicianProfileCollectionViaPhysicianPermittedTest</summary>
			public static readonly string PhysicianProfileCollectionViaPhysicianPermittedTest = "PhysicianProfileCollectionViaPhysicianPermittedTest";
			/// <summary>Member name PodDetailsCollectionViaPodTest</summary>
			public static readonly string PodDetailsCollectionViaPodTest = "PodDetailsCollectionViaPodTest";
			/// <summary>Member name PodRoomCollectionViaPodRoomTest</summary>
			public static readonly string PodRoomCollectionViaPodRoomTest = "PodRoomCollectionViaPodRoomTest";
			/// <summary>Member name PreQualificationQuestionCollectionViaDisqualifiedTest</summary>
			public static readonly string PreQualificationQuestionCollectionViaDisqualifiedTest = "PreQualificationQuestionCollectionViaDisqualifiedTest";
			/// <summary>Member name PreQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest</summary>
			public static readonly string PreQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest = "PreQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest";
			/// <summary>Member name PreQualificationTestTemplateCollectionViaEventTest</summary>
			public static readonly string PreQualificationTestTemplateCollectionViaEventTest = "PreQualificationTestTemplateCollectionViaEventTest";
			/// <summary>Member name ReadingCollectionViaTestReading</summary>
			public static readonly string ReadingCollectionViaTestReading = "ReadingCollectionViaTestReading";
			/// <summary>Member name ReadingCollectionViaStandardFindingTestReading</summary>
			public static readonly string ReadingCollectionViaStandardFindingTestReading = "ReadingCollectionViaStandardFindingTestReading";
			/// <summary>Member name ResultArchiveUploadCollectionViaResultArchiveUploadLog</summary>
			public static readonly string ResultArchiveUploadCollectionViaResultArchiveUploadLog = "ResultArchiveUploadCollectionViaResultArchiveUploadLog";
			/// <summary>Member name StaffEventRoleCollectionViaStaffEventRoleTest</summary>
			public static readonly string StaffEventRoleCollectionViaStaffEventRoleTest = "StaffEventRoleCollectionViaStaffEventRoleTest";
			/// <summary>Member name StandardFindingCollectionViaStandardFindingTestReading</summary>
			public static readonly string StandardFindingCollectionViaStandardFindingTestReading = "StandardFindingCollectionViaStandardFindingTestReading";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static TestEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public TestEntity():base("TestEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public TestEntity(IEntityFields2 fields):base("TestEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this TestEntity</param>
		public TestEntity(IValidator validator):base("TestEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="testId">PK value for Test which data should be fetched into this Test object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TestEntity(System.Int64 testId):base("TestEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.TestId = testId;
		}

		/// <summary> CTor</summary>
		/// <param name="testId">PK value for Test which data should be fetched into this Test object</param>
		/// <param name="validator">The custom validator object for this TestEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TestEntity(System.Int64 testId, IValidator validator):base("TestEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.TestId = testId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected TestEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_accountCustomerResultTestDependency = (EntityCollection<AccountCustomerResultTestDependencyEntity>)info.GetValue("_accountCustomerResultTestDependency", typeof(EntityCollection<AccountCustomerResultTestDependencyEntity>));
				_accountHealthPlanResultTestDependency = (EntityCollection<AccountHealthPlanResultTestDependencyEntity>)info.GetValue("_accountHealthPlanResultTestDependency", typeof(EntityCollection<AccountHealthPlanResultTestDependencyEntity>));
				_accountNotReviewableTest = (EntityCollection<AccountNotReviewableTestEntity>)info.GetValue("_accountNotReviewableTest", typeof(EntityCollection<AccountNotReviewableTestEntity>));
				_accountPcpResultTestDependency = (EntityCollection<AccountPcpResultTestDependencyEntity>)info.GetValue("_accountPcpResultTestDependency", typeof(EntityCollection<AccountPcpResultTestDependencyEntity>));
				_accountTest = (EntityCollection<AccountTestEntity>)info.GetValue("_accountTest", typeof(EntityCollection<AccountTestEntity>));
				_billingAccountTest = (EntityCollection<BillingAccountTestEntity>)info.GetValue("_billingAccountTest", typeof(EntityCollection<BillingAccountTestEntity>));
				_clinicalTestQualificationCriteria = (EntityCollection<ClinicalTestQualificationCriteriaEntity>)info.GetValue("_clinicalTestQualificationCriteria", typeof(EntityCollection<ClinicalTestQualificationCriteriaEntity>));
				_customerEventScreeningTests = (EntityCollection<CustomerEventScreeningTestsEntity>)info.GetValue("_customerEventScreeningTests", typeof(EntityCollection<CustomerEventScreeningTestsEntity>));
				_customerEventTestFinding = (EntityCollection<CustomerEventTestFindingEntity>)info.GetValue("_customerEventTestFinding", typeof(EntityCollection<CustomerEventTestFindingEntity>));
				_customerHealthQuestionGroup = (EntityCollection<CustomerHealthQuestionGroupEntity>)info.GetValue("_customerHealthQuestionGroup", typeof(EntityCollection<CustomerHealthQuestionGroupEntity>));
				_dependentDisqualifiedTest = (EntityCollection<DependentDisqualifiedTestEntity>)info.GetValue("_dependentDisqualifiedTest", typeof(EntityCollection<DependentDisqualifiedTestEntity>));
				_disqualifiedTest = (EntityCollection<DisqualifiedTestEntity>)info.GetValue("_disqualifiedTest", typeof(EntityCollection<DisqualifiedTestEntity>));
				_eventCustomerPreApprovedPackageTest = (EntityCollection<EventCustomerPreApprovedPackageTestEntity>)info.GetValue("_eventCustomerPreApprovedPackageTest", typeof(EntityCollection<EventCustomerPreApprovedPackageTestEntity>));
				_eventCustomerPreApprovedTest = (EntityCollection<EventCustomerPreApprovedTestEntity>)info.GetValue("_eventCustomerPreApprovedTest", typeof(EntityCollection<EventCustomerPreApprovedTestEntity>));
				_eventCustomerRequiredTest = (EntityCollection<EventCustomerRequiredTestEntity>)info.GetValue("_eventCustomerRequiredTest", typeof(EntityCollection<EventCustomerRequiredTestEntity>));
				_eventCustomerRetest = (EntityCollection<EventCustomerRetestEntity>)info.GetValue("_eventCustomerRetest", typeof(EntityCollection<EventCustomerRetestEntity>));
				_eventCustomerTestNotPerformedNotification = (EntityCollection<EventCustomerTestNotPerformedNotificationEntity>)info.GetValue("_eventCustomerTestNotPerformedNotification", typeof(EntityCollection<EventCustomerTestNotPerformedNotificationEntity>));
				_eventPhysicianTest = (EntityCollection<EventPhysicianTestEntity>)info.GetValue("_eventPhysicianTest", typeof(EntityCollection<EventPhysicianTestEntity>));
				_eventPodRoomTest = (EntityCollection<EventPodRoomTestEntity>)info.GetValue("_eventPodRoomTest", typeof(EntityCollection<EventPodRoomTestEntity>));
				_eventTest = (EntityCollection<EventTestEntity>)info.GetValue("_eventTest", typeof(EntityCollection<EventTestEntity>));
				_healthPlanRevenueItem = (EntityCollection<HealthPlanRevenueItemEntity>)info.GetValue("_healthPlanRevenueItem", typeof(EntityCollection<HealthPlanRevenueItemEntity>));
				_inventoryItemTest = (EntityCollection<InventoryItemTestEntity>)info.GetValue("_inventoryItemTest", typeof(EntityCollection<InventoryItemTestEntity>));
				_kynLabValues = (EntityCollection<KynLabValuesEntity>)info.GetValue("_kynLabValues", typeof(EntityCollection<KynLabValuesEntity>));
				_packageTest = (EntityCollection<PackageTestEntity>)info.GetValue("_packageTest", typeof(EntityCollection<PackageTestEntity>));
				_physicianPermittedTest = (EntityCollection<PhysicianPermittedTestEntity>)info.GetValue("_physicianPermittedTest", typeof(EntityCollection<PhysicianPermittedTestEntity>));
				_podRoomTest = (EntityCollection<PodRoomTestEntity>)info.GetValue("_podRoomTest", typeof(EntityCollection<PodRoomTestEntity>));
				_podTest = (EntityCollection<PodTestEntity>)info.GetValue("_podTest", typeof(EntityCollection<PodTestEntity>));
				_preApprovedTest = (EntityCollection<PreApprovedTestEntity>)info.GetValue("_preApprovedTest", typeof(EntityCollection<PreApprovedTestEntity>));
				_preQualificationQuestion = (EntityCollection<PreQualificationQuestionEntity>)info.GetValue("_preQualificationQuestion", typeof(EntityCollection<PreQualificationQuestionEntity>));
				_preQualificationTemplateDependentTest = (EntityCollection<PreQualificationTemplateDependentTestEntity>)info.GetValue("_preQualificationTemplateDependentTest", typeof(EntityCollection<PreQualificationTemplateDependentTestEntity>));
				_preQualificationTestTemplate = (EntityCollection<PreQualificationTestTemplateEntity>)info.GetValue("_preQualificationTestTemplate", typeof(EntityCollection<PreQualificationTestTemplateEntity>));
				_prospectActivity = (EntityCollection<ProspectActivityEntity>)info.GetValue("_prospectActivity", typeof(EntityCollection<ProspectActivityEntity>));
				_requiredTest = (EntityCollection<RequiredTestEntity>)info.GetValue("_requiredTest", typeof(EntityCollection<RequiredTestEntity>));
				_resultArchiveUploadLog = (EntityCollection<ResultArchiveUploadLogEntity>)info.GetValue("_resultArchiveUploadLog", typeof(EntityCollection<ResultArchiveUploadLogEntity>));
				_staffEventRoleTest = (EntityCollection<StaffEventRoleTestEntity>)info.GetValue("_staffEventRoleTest", typeof(EntityCollection<StaffEventRoleTestEntity>));
				_standardFindingTestReading = (EntityCollection<StandardFindingTestReadingEntity>)info.GetValue("_standardFindingTestReading", typeof(EntityCollection<StandardFindingTestReadingEntity>));
				_testDependencyRule = (EntityCollection<TestDependencyRuleEntity>)info.GetValue("_testDependencyRule", typeof(EntityCollection<TestDependencyRuleEntity>));
				_testDependencyRule_ = (EntityCollection<TestDependencyRuleEntity>)info.GetValue("_testDependencyRule_", typeof(EntityCollection<TestDependencyRuleEntity>));
				_testHcpcsCode = (EntityCollection<TestHcpcsCodeEntity>)info.GetValue("_testHcpcsCode", typeof(EntityCollection<TestHcpcsCodeEntity>));
				_testIncidentalFinding = (EntityCollection<TestIncidentalFindingEntity>)info.GetValue("_testIncidentalFinding", typeof(EntityCollection<TestIncidentalFindingEntity>));
				_testReading = (EntityCollection<TestReadingEntity>)info.GetValue("_testReading", typeof(EntityCollection<TestReadingEntity>));
				_testSourceCodeDiscount = (EntityCollection<TestSourceCodeDiscountEntity>)info.GetValue("_testSourceCodeDiscount", typeof(EntityCollection<TestSourceCodeDiscountEntity>));
				_testUnableScreenReason = (EntityCollection<TestUnableScreenReasonEntity>)info.GetValue("_testUnableScreenReason", typeof(EntityCollection<TestUnableScreenReasonEntity>));
				_accountCollectionViaAccountPcpResultTestDependency = (EntityCollection<AccountEntity>)info.GetValue("_accountCollectionViaAccountPcpResultTestDependency", typeof(EntityCollection<AccountEntity>));
				_accountCollectionViaAccountTest = (EntityCollection<AccountEntity>)info.GetValue("_accountCollectionViaAccountTest", typeof(EntityCollection<AccountEntity>));
				_accountCollectionViaAccountNotReviewableTest = (EntityCollection<AccountEntity>)info.GetValue("_accountCollectionViaAccountNotReviewableTest", typeof(EntityCollection<AccountEntity>));
				_accountCollectionViaAccountCustomerResultTestDependency = (EntityCollection<AccountEntity>)info.GetValue("_accountCollectionViaAccountCustomerResultTestDependency", typeof(EntityCollection<AccountEntity>));
				_accountCollectionViaAccountHealthPlanResultTestDependency = (EntityCollection<AccountEntity>)info.GetValue("_accountCollectionViaAccountHealthPlanResultTestDependency", typeof(EntityCollection<AccountEntity>));
				_billingAccountCollectionViaBillingAccountTest = (EntityCollection<BillingAccountEntity>)info.GetValue("_billingAccountCollectionViaBillingAccountTest", typeof(EntityCollection<BillingAccountEntity>));
				_couponsCollectionViaTestSourceCodeDiscount = (EntityCollection<CouponsEntity>)info.GetValue("_couponsCollectionViaTestSourceCodeDiscount", typeof(EntityCollection<CouponsEntity>));
				_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_ = (EntityCollection<CustomerHealthQuestionsEntity>)info.GetValue("_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_", typeof(EntityCollection<CustomerHealthQuestionsEntity>));
				_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria = (EntityCollection<CustomerHealthQuestionsEntity>)info.GetValue("_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria", typeof(EntityCollection<CustomerHealthQuestionsEntity>));
				_customerProfileCollectionViaDependentDisqualifiedTest = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaDependentDisqualifiedTest", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaCustomerEventTestFinding = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerEventTestFinding", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaDisqualifiedTest = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaDisqualifiedTest", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaResultArchiveUploadLog = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaResultArchiveUploadLog", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaRequiredTest = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaRequiredTest", typeof(EntityCollection<CustomerProfileEntity>));
				_eventCustomerResultCollectionViaKynLabValues = (EntityCollection<EventCustomerResultEntity>)info.GetValue("_eventCustomerResultCollectionViaKynLabValues", typeof(EntityCollection<EventCustomerResultEntity>));
				_eventCustomerResultCollectionViaCustomerEventScreeningTests = (EntityCollection<EventCustomerResultEntity>)info.GetValue("_eventCustomerResultCollectionViaCustomerEventScreeningTests", typeof(EntityCollection<EventCustomerResultEntity>));
				_eventCustomersCollectionViaDisqualifiedTest = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaDisqualifiedTest", typeof(EntityCollection<EventCustomersEntity>));
				_eventCustomersCollectionViaEventCustomerPreApprovedTest = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaEventCustomerPreApprovedTest", typeof(EntityCollection<EventCustomersEntity>));
				_eventCustomersCollectionViaEventCustomerPreApprovedPackageTest = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaEventCustomerPreApprovedPackageTest", typeof(EntityCollection<EventCustomersEntity>));
				_eventCustomersCollectionViaEventCustomerRequiredTest = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaEventCustomerRequiredTest", typeof(EntityCollection<EventCustomersEntity>));
				_eventCustomersCollectionViaEventCustomerTestNotPerformedNotification = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaEventCustomerTestNotPerformedNotification", typeof(EntityCollection<EventCustomersEntity>));
				_eventCustomersCollectionViaDependentDisqualifiedTest = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaDependentDisqualifiedTest", typeof(EntityCollection<EventCustomersEntity>));
				_eventCustomersCollectionViaEventCustomerRetest = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaEventCustomerRetest", typeof(EntityCollection<EventCustomersEntity>));
				_eventPodRoomCollectionViaEventPodRoomTest = (EntityCollection<EventPodRoomEntity>)info.GetValue("_eventPodRoomCollectionViaEventPodRoomTest", typeof(EntityCollection<EventPodRoomEntity>));
				_eventsCollectionViaDependentDisqualifiedTest = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaDependentDisqualifiedTest", typeof(EntityCollection<EventsEntity>));
				_eventsCollectionViaDisqualifiedTest = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaDisqualifiedTest", typeof(EntityCollection<EventsEntity>));
				_eventsCollectionViaEventPhysicianTest = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventPhysicianTest", typeof(EntityCollection<EventsEntity>));
				_eventsCollectionViaEventTest = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventTest", typeof(EntityCollection<EventsEntity>));
				_eventsCollectionViaCustomerEventTestFinding = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaCustomerEventTestFinding", typeof(EntityCollection<EventsEntity>));
				_hafTemplateCollectionViaClinicalTestQualificationCriteria = (EntityCollection<HafTemplateEntity>)info.GetValue("_hafTemplateCollectionViaClinicalTestQualificationCriteria", typeof(EntityCollection<HafTemplateEntity>));
				_hafTemplateCollectionViaEventTest = (EntityCollection<HafTemplateEntity>)info.GetValue("_hafTemplateCollectionViaEventTest", typeof(EntityCollection<HafTemplateEntity>));
				_hcpcsCodeCollectionViaTestHcpcsCode = (EntityCollection<HcpcsCodeEntity>)info.GetValue("_hcpcsCodeCollectionViaTestHcpcsCode", typeof(EntityCollection<HcpcsCodeEntity>));
				_healthPlanRevenueCollectionViaHealthPlanRevenueItem = (EntityCollection<HealthPlanRevenueEntity>)info.GetValue("_healthPlanRevenueCollectionViaHealthPlanRevenueItem", typeof(EntityCollection<HealthPlanRevenueEntity>));
				_incidentalFindingsCollectionViaTestIncidentalFinding = (EntityCollection<IncidentalFindingsEntity>)info.GetValue("_incidentalFindingsCollectionViaTestIncidentalFinding", typeof(EntityCollection<IncidentalFindingsEntity>));
				_inventoryItemCollectionViaInventoryItemTest = (EntityCollection<InventoryItemEntity>)info.GetValue("_inventoryItemCollectionViaInventoryItemTest", typeof(EntityCollection<InventoryItemEntity>));
				_lookupCollectionViaTestUnableScreenReason = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaTestUnableScreenReason", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEventTest_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventTest_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEventTest = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventTest", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEventTest__ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventTest__", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaClinicalTestQualificationCriteria = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaClinicalTestQualificationCriteria", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaPreQualificationQuestion = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaPreQualificationQuestion", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaClinicalTestQualificationCriteria_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaClinicalTestQualificationCriteria_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaKynLabValues = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaKynLabValues", typeof(EntityCollection<LookupEntity>));
				_notificationTypeCollectionViaEventCustomerTestNotPerformedNotification = (EntityCollection<NotificationTypeEntity>)info.GetValue("_notificationTypeCollectionViaEventCustomerTestNotPerformedNotification", typeof(EntityCollection<NotificationTypeEntity>));
				_orderItemCollectionViaProspectActivity = (EntityCollection<OrderItemEntity>)info.GetValue("_orderItemCollectionViaProspectActivity", typeof(EntityCollection<OrderItemEntity>));
				_organizationRoleUserCollectionViaPreQualificationQuestion = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaPreQualificationQuestion", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaPreApprovedTest = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaPreApprovedTest", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaTestHcpcsCode = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaTestHcpcsCode", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaTestHcpcsCode_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaTestHcpcsCode_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaRequiredTest = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaRequiredTest", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaPreQualificationTestTemplate = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaPreQualificationTestTemplate", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaPreQualificationTestTemplate_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaPreQualificationTestTemplate_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventCustomerRetest = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventCustomerRetest", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaClinicalTestQualificationCriteria = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaClinicalTestQualificationCriteria", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventPhysicianTest__ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventPhysicianTest__", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventPhysicianTest = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventPhysicianTest", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaDisqualifiedTest_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaDisqualifiedTest_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventPhysicianTest_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventPhysicianTest_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaDisqualifiedTest = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaDisqualifiedTest", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaKynLabValues = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaKynLabValues", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaKynLabValues_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaKynLabValues_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_packageCollectionViaEventCustomerPreApprovedPackageTest = (EntityCollection<PackageEntity>)info.GetValue("_packageCollectionViaEventCustomerPreApprovedPackageTest", typeof(EntityCollection<PackageEntity>));
				_packageCollectionViaPackageTest = (EntityCollection<PackageEntity>)info.GetValue("_packageCollectionViaPackageTest", typeof(EntityCollection<PackageEntity>));
				_packageCollectionViaHealthPlanRevenueItem = (EntityCollection<PackageEntity>)info.GetValue("_packageCollectionViaHealthPlanRevenueItem", typeof(EntityCollection<PackageEntity>));
				_physicianProfileCollectionViaPhysicianPermittedTest = (EntityCollection<PhysicianProfileEntity>)info.GetValue("_physicianProfileCollectionViaPhysicianPermittedTest", typeof(EntityCollection<PhysicianProfileEntity>));
				_podDetailsCollectionViaPodTest = (EntityCollection<PodDetailsEntity>)info.GetValue("_podDetailsCollectionViaPodTest", typeof(EntityCollection<PodDetailsEntity>));
				_podRoomCollectionViaPodRoomTest = (EntityCollection<PodRoomEntity>)info.GetValue("_podRoomCollectionViaPodRoomTest", typeof(EntityCollection<PodRoomEntity>));
				_preQualificationQuestionCollectionViaDisqualifiedTest = (EntityCollection<PreQualificationQuestionEntity>)info.GetValue("_preQualificationQuestionCollectionViaDisqualifiedTest", typeof(EntityCollection<PreQualificationQuestionEntity>));
				_preQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest = (EntityCollection<PreQualificationTestTemplateEntity>)info.GetValue("_preQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest", typeof(EntityCollection<PreQualificationTestTemplateEntity>));
				_preQualificationTestTemplateCollectionViaEventTest = (EntityCollection<PreQualificationTestTemplateEntity>)info.GetValue("_preQualificationTestTemplateCollectionViaEventTest", typeof(EntityCollection<PreQualificationTestTemplateEntity>));
				_readingCollectionViaTestReading = (EntityCollection<ReadingEntity>)info.GetValue("_readingCollectionViaTestReading", typeof(EntityCollection<ReadingEntity>));
				_readingCollectionViaStandardFindingTestReading = (EntityCollection<ReadingEntity>)info.GetValue("_readingCollectionViaStandardFindingTestReading", typeof(EntityCollection<ReadingEntity>));
				_resultArchiveUploadCollectionViaResultArchiveUploadLog = (EntityCollection<ResultArchiveUploadEntity>)info.GetValue("_resultArchiveUploadCollectionViaResultArchiveUploadLog", typeof(EntityCollection<ResultArchiveUploadEntity>));
				_staffEventRoleCollectionViaStaffEventRoleTest = (EntityCollection<StaffEventRoleEntity>)info.GetValue("_staffEventRoleCollectionViaStaffEventRoleTest", typeof(EntityCollection<StaffEventRoleEntity>));
				_standardFindingCollectionViaStandardFindingTestReading = (EntityCollection<StandardFindingEntity>)info.GetValue("_standardFindingCollectionViaStandardFindingTestReading", typeof(EntityCollection<StandardFindingEntity>));
				_hafTemplate = (HafTemplateEntity)info.GetValue("_hafTemplate", typeof(HafTemplateEntity));
				if(_hafTemplate!=null)
				{
					_hafTemplate.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup__ = (LookupEntity)info.GetValue("_lookup__", typeof(LookupEntity));
				if(_lookup__!=null)
				{
					_lookup__.AfterSave+=new EventHandler(OnEntityAfterSave);
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
				_preQualificationTestTemplate_ = (PreQualificationTestTemplateEntity)info.GetValue("_preQualificationTestTemplate_", typeof(PreQualificationTestTemplateEntity));
				if(_preQualificationTestTemplate_!=null)
				{
					_preQualificationTestTemplate_.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((TestFieldIndex)fieldIndex)
			{
				case TestFieldIndex.HafTemplateId:
					DesetupSyncHafTemplate(true, false);
					break;
				case TestFieldIndex.Gender:
					DesetupSyncLookup(true, false);
					break;
				case TestFieldIndex.GroupId:
					DesetupSyncLookup_(true, false);
					break;
				case TestFieldIndex.PreQualificationQuestionTemplateId:
					DesetupSyncPreQualificationTestTemplate_(true, false);
					break;
				case TestFieldIndex.ResultEntryTypeId:
					DesetupSyncLookup__(true, false);
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
				case "HafTemplate":
					this.HafTemplate = (HafTemplateEntity)entity;
					break;
				case "Lookup__":
					this.Lookup__ = (LookupEntity)entity;
					break;
				case "Lookup_":
					this.Lookup_ = (LookupEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "PreQualificationTestTemplate_":
					this.PreQualificationTestTemplate_ = (PreQualificationTestTemplateEntity)entity;
					break;
				case "AccountCustomerResultTestDependency":
					this.AccountCustomerResultTestDependency.Add((AccountCustomerResultTestDependencyEntity)entity);
					break;
				case "AccountHealthPlanResultTestDependency":
					this.AccountHealthPlanResultTestDependency.Add((AccountHealthPlanResultTestDependencyEntity)entity);
					break;
				case "AccountNotReviewableTest":
					this.AccountNotReviewableTest.Add((AccountNotReviewableTestEntity)entity);
					break;
				case "AccountPcpResultTestDependency":
					this.AccountPcpResultTestDependency.Add((AccountPcpResultTestDependencyEntity)entity);
					break;
				case "AccountTest":
					this.AccountTest.Add((AccountTestEntity)entity);
					break;
				case "BillingAccountTest":
					this.BillingAccountTest.Add((BillingAccountTestEntity)entity);
					break;
				case "ClinicalTestQualificationCriteria":
					this.ClinicalTestQualificationCriteria.Add((ClinicalTestQualificationCriteriaEntity)entity);
					break;
				case "CustomerEventScreeningTests":
					this.CustomerEventScreeningTests.Add((CustomerEventScreeningTestsEntity)entity);
					break;
				case "CustomerEventTestFinding":
					this.CustomerEventTestFinding.Add((CustomerEventTestFindingEntity)entity);
					break;
				case "CustomerHealthQuestionGroup":
					this.CustomerHealthQuestionGroup.Add((CustomerHealthQuestionGroupEntity)entity);
					break;
				case "DependentDisqualifiedTest":
					this.DependentDisqualifiedTest.Add((DependentDisqualifiedTestEntity)entity);
					break;
				case "DisqualifiedTest":
					this.DisqualifiedTest.Add((DisqualifiedTestEntity)entity);
					break;
				case "EventCustomerPreApprovedPackageTest":
					this.EventCustomerPreApprovedPackageTest.Add((EventCustomerPreApprovedPackageTestEntity)entity);
					break;
				case "EventCustomerPreApprovedTest":
					this.EventCustomerPreApprovedTest.Add((EventCustomerPreApprovedTestEntity)entity);
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
				case "EventPhysicianTest":
					this.EventPhysicianTest.Add((EventPhysicianTestEntity)entity);
					break;
				case "EventPodRoomTest":
					this.EventPodRoomTest.Add((EventPodRoomTestEntity)entity);
					break;
				case "EventTest":
					this.EventTest.Add((EventTestEntity)entity);
					break;
				case "HealthPlanRevenueItem":
					this.HealthPlanRevenueItem.Add((HealthPlanRevenueItemEntity)entity);
					break;
				case "InventoryItemTest":
					this.InventoryItemTest.Add((InventoryItemTestEntity)entity);
					break;
				case "KynLabValues":
					this.KynLabValues.Add((KynLabValuesEntity)entity);
					break;
				case "PackageTest":
					this.PackageTest.Add((PackageTestEntity)entity);
					break;
				case "PhysicianPermittedTest":
					this.PhysicianPermittedTest.Add((PhysicianPermittedTestEntity)entity);
					break;
				case "PodRoomTest":
					this.PodRoomTest.Add((PodRoomTestEntity)entity);
					break;
				case "PodTest":
					this.PodTest.Add((PodTestEntity)entity);
					break;
				case "PreApprovedTest":
					this.PreApprovedTest.Add((PreApprovedTestEntity)entity);
					break;
				case "PreQualificationQuestion":
					this.PreQualificationQuestion.Add((PreQualificationQuestionEntity)entity);
					break;
				case "PreQualificationTemplateDependentTest":
					this.PreQualificationTemplateDependentTest.Add((PreQualificationTemplateDependentTestEntity)entity);
					break;
				case "PreQualificationTestTemplate":
					this.PreQualificationTestTemplate.Add((PreQualificationTestTemplateEntity)entity);
					break;
				case "ProspectActivity":
					this.ProspectActivity.Add((ProspectActivityEntity)entity);
					break;
				case "RequiredTest":
					this.RequiredTest.Add((RequiredTestEntity)entity);
					break;
				case "ResultArchiveUploadLog":
					this.ResultArchiveUploadLog.Add((ResultArchiveUploadLogEntity)entity);
					break;
				case "StaffEventRoleTest":
					this.StaffEventRoleTest.Add((StaffEventRoleTestEntity)entity);
					break;
				case "StandardFindingTestReading":
					this.StandardFindingTestReading.Add((StandardFindingTestReadingEntity)entity);
					break;
				case "TestDependencyRule":
					this.TestDependencyRule.Add((TestDependencyRuleEntity)entity);
					break;
				case "TestDependencyRule_":
					this.TestDependencyRule_.Add((TestDependencyRuleEntity)entity);
					break;
				case "TestHcpcsCode":
					this.TestHcpcsCode.Add((TestHcpcsCodeEntity)entity);
					break;
				case "TestIncidentalFinding":
					this.TestIncidentalFinding.Add((TestIncidentalFindingEntity)entity);
					break;
				case "TestReading":
					this.TestReading.Add((TestReadingEntity)entity);
					break;
				case "TestSourceCodeDiscount":
					this.TestSourceCodeDiscount.Add((TestSourceCodeDiscountEntity)entity);
					break;
				case "TestUnableScreenReason":
					this.TestUnableScreenReason.Add((TestUnableScreenReasonEntity)entity);
					break;
				case "AccountCollectionViaAccountPcpResultTestDependency":
					this.AccountCollectionViaAccountPcpResultTestDependency.IsReadOnly = false;
					this.AccountCollectionViaAccountPcpResultTestDependency.Add((AccountEntity)entity);
					this.AccountCollectionViaAccountPcpResultTestDependency.IsReadOnly = true;
					break;
				case "AccountCollectionViaAccountTest":
					this.AccountCollectionViaAccountTest.IsReadOnly = false;
					this.AccountCollectionViaAccountTest.Add((AccountEntity)entity);
					this.AccountCollectionViaAccountTest.IsReadOnly = true;
					break;
				case "AccountCollectionViaAccountNotReviewableTest":
					this.AccountCollectionViaAccountNotReviewableTest.IsReadOnly = false;
					this.AccountCollectionViaAccountNotReviewableTest.Add((AccountEntity)entity);
					this.AccountCollectionViaAccountNotReviewableTest.IsReadOnly = true;
					break;
				case "AccountCollectionViaAccountCustomerResultTestDependency":
					this.AccountCollectionViaAccountCustomerResultTestDependency.IsReadOnly = false;
					this.AccountCollectionViaAccountCustomerResultTestDependency.Add((AccountEntity)entity);
					this.AccountCollectionViaAccountCustomerResultTestDependency.IsReadOnly = true;
					break;
				case "AccountCollectionViaAccountHealthPlanResultTestDependency":
					this.AccountCollectionViaAccountHealthPlanResultTestDependency.IsReadOnly = false;
					this.AccountCollectionViaAccountHealthPlanResultTestDependency.Add((AccountEntity)entity);
					this.AccountCollectionViaAccountHealthPlanResultTestDependency.IsReadOnly = true;
					break;
				case "BillingAccountCollectionViaBillingAccountTest":
					this.BillingAccountCollectionViaBillingAccountTest.IsReadOnly = false;
					this.BillingAccountCollectionViaBillingAccountTest.Add((BillingAccountEntity)entity);
					this.BillingAccountCollectionViaBillingAccountTest.IsReadOnly = true;
					break;
				case "CouponsCollectionViaTestSourceCodeDiscount":
					this.CouponsCollectionViaTestSourceCodeDiscount.IsReadOnly = false;
					this.CouponsCollectionViaTestSourceCodeDiscount.Add((CouponsEntity)entity);
					this.CouponsCollectionViaTestSourceCodeDiscount.IsReadOnly = true;
					break;
				case "CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_":
					this.CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_.IsReadOnly = false;
					this.CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_.Add((CustomerHealthQuestionsEntity)entity);
					this.CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_.IsReadOnly = true;
					break;
				case "CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria":
					this.CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria.IsReadOnly = false;
					this.CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria.Add((CustomerHealthQuestionsEntity)entity);
					this.CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaDependentDisqualifiedTest":
					this.CustomerProfileCollectionViaDependentDisqualifiedTest.IsReadOnly = false;
					this.CustomerProfileCollectionViaDependentDisqualifiedTest.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaDependentDisqualifiedTest.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCustomerEventTestFinding":
					this.CustomerProfileCollectionViaCustomerEventTestFinding.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerEventTestFinding.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerEventTestFinding.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaDisqualifiedTest":
					this.CustomerProfileCollectionViaDisqualifiedTest.IsReadOnly = false;
					this.CustomerProfileCollectionViaDisqualifiedTest.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaDisqualifiedTest.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaResultArchiveUploadLog":
					this.CustomerProfileCollectionViaResultArchiveUploadLog.IsReadOnly = false;
					this.CustomerProfileCollectionViaResultArchiveUploadLog.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaResultArchiveUploadLog.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaRequiredTest":
					this.CustomerProfileCollectionViaRequiredTest.IsReadOnly = false;
					this.CustomerProfileCollectionViaRequiredTest.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaRequiredTest.IsReadOnly = true;
					break;
				case "EventCustomerResultCollectionViaKynLabValues":
					this.EventCustomerResultCollectionViaKynLabValues.IsReadOnly = false;
					this.EventCustomerResultCollectionViaKynLabValues.Add((EventCustomerResultEntity)entity);
					this.EventCustomerResultCollectionViaKynLabValues.IsReadOnly = true;
					break;
				case "EventCustomerResultCollectionViaCustomerEventScreeningTests":
					this.EventCustomerResultCollectionViaCustomerEventScreeningTests.IsReadOnly = false;
					this.EventCustomerResultCollectionViaCustomerEventScreeningTests.Add((EventCustomerResultEntity)entity);
					this.EventCustomerResultCollectionViaCustomerEventScreeningTests.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaDisqualifiedTest":
					this.EventCustomersCollectionViaDisqualifiedTest.IsReadOnly = false;
					this.EventCustomersCollectionViaDisqualifiedTest.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaDisqualifiedTest.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaEventCustomerPreApprovedTest":
					this.EventCustomersCollectionViaEventCustomerPreApprovedTest.IsReadOnly = false;
					this.EventCustomersCollectionViaEventCustomerPreApprovedTest.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaEventCustomerPreApprovedTest.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaEventCustomerPreApprovedPackageTest":
					this.EventCustomersCollectionViaEventCustomerPreApprovedPackageTest.IsReadOnly = false;
					this.EventCustomersCollectionViaEventCustomerPreApprovedPackageTest.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaEventCustomerPreApprovedPackageTest.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaEventCustomerRequiredTest":
					this.EventCustomersCollectionViaEventCustomerRequiredTest.IsReadOnly = false;
					this.EventCustomersCollectionViaEventCustomerRequiredTest.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaEventCustomerRequiredTest.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaEventCustomerTestNotPerformedNotification":
					this.EventCustomersCollectionViaEventCustomerTestNotPerformedNotification.IsReadOnly = false;
					this.EventCustomersCollectionViaEventCustomerTestNotPerformedNotification.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaEventCustomerTestNotPerformedNotification.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaDependentDisqualifiedTest":
					this.EventCustomersCollectionViaDependentDisqualifiedTest.IsReadOnly = false;
					this.EventCustomersCollectionViaDependentDisqualifiedTest.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaDependentDisqualifiedTest.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaEventCustomerRetest":
					this.EventCustomersCollectionViaEventCustomerRetest.IsReadOnly = false;
					this.EventCustomersCollectionViaEventCustomerRetest.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaEventCustomerRetest.IsReadOnly = true;
					break;
				case "EventPodRoomCollectionViaEventPodRoomTest":
					this.EventPodRoomCollectionViaEventPodRoomTest.IsReadOnly = false;
					this.EventPodRoomCollectionViaEventPodRoomTest.Add((EventPodRoomEntity)entity);
					this.EventPodRoomCollectionViaEventPodRoomTest.IsReadOnly = true;
					break;
				case "EventsCollectionViaDependentDisqualifiedTest":
					this.EventsCollectionViaDependentDisqualifiedTest.IsReadOnly = false;
					this.EventsCollectionViaDependentDisqualifiedTest.Add((EventsEntity)entity);
					this.EventsCollectionViaDependentDisqualifiedTest.IsReadOnly = true;
					break;
				case "EventsCollectionViaDisqualifiedTest":
					this.EventsCollectionViaDisqualifiedTest.IsReadOnly = false;
					this.EventsCollectionViaDisqualifiedTest.Add((EventsEntity)entity);
					this.EventsCollectionViaDisqualifiedTest.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventPhysicianTest":
					this.EventsCollectionViaEventPhysicianTest.IsReadOnly = false;
					this.EventsCollectionViaEventPhysicianTest.Add((EventsEntity)entity);
					this.EventsCollectionViaEventPhysicianTest.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventTest":
					this.EventsCollectionViaEventTest.IsReadOnly = false;
					this.EventsCollectionViaEventTest.Add((EventsEntity)entity);
					this.EventsCollectionViaEventTest.IsReadOnly = true;
					break;
				case "EventsCollectionViaCustomerEventTestFinding":
					this.EventsCollectionViaCustomerEventTestFinding.IsReadOnly = false;
					this.EventsCollectionViaCustomerEventTestFinding.Add((EventsEntity)entity);
					this.EventsCollectionViaCustomerEventTestFinding.IsReadOnly = true;
					break;
				case "HafTemplateCollectionViaClinicalTestQualificationCriteria":
					this.HafTemplateCollectionViaClinicalTestQualificationCriteria.IsReadOnly = false;
					this.HafTemplateCollectionViaClinicalTestQualificationCriteria.Add((HafTemplateEntity)entity);
					this.HafTemplateCollectionViaClinicalTestQualificationCriteria.IsReadOnly = true;
					break;
				case "HafTemplateCollectionViaEventTest":
					this.HafTemplateCollectionViaEventTest.IsReadOnly = false;
					this.HafTemplateCollectionViaEventTest.Add((HafTemplateEntity)entity);
					this.HafTemplateCollectionViaEventTest.IsReadOnly = true;
					break;
				case "HcpcsCodeCollectionViaTestHcpcsCode":
					this.HcpcsCodeCollectionViaTestHcpcsCode.IsReadOnly = false;
					this.HcpcsCodeCollectionViaTestHcpcsCode.Add((HcpcsCodeEntity)entity);
					this.HcpcsCodeCollectionViaTestHcpcsCode.IsReadOnly = true;
					break;
				case "HealthPlanRevenueCollectionViaHealthPlanRevenueItem":
					this.HealthPlanRevenueCollectionViaHealthPlanRevenueItem.IsReadOnly = false;
					this.HealthPlanRevenueCollectionViaHealthPlanRevenueItem.Add((HealthPlanRevenueEntity)entity);
					this.HealthPlanRevenueCollectionViaHealthPlanRevenueItem.IsReadOnly = true;
					break;
				case "IncidentalFindingsCollectionViaTestIncidentalFinding":
					this.IncidentalFindingsCollectionViaTestIncidentalFinding.IsReadOnly = false;
					this.IncidentalFindingsCollectionViaTestIncidentalFinding.Add((IncidentalFindingsEntity)entity);
					this.IncidentalFindingsCollectionViaTestIncidentalFinding.IsReadOnly = true;
					break;
				case "InventoryItemCollectionViaInventoryItemTest":
					this.InventoryItemCollectionViaInventoryItemTest.IsReadOnly = false;
					this.InventoryItemCollectionViaInventoryItemTest.Add((InventoryItemEntity)entity);
					this.InventoryItemCollectionViaInventoryItemTest.IsReadOnly = true;
					break;
				case "LookupCollectionViaTestUnableScreenReason":
					this.LookupCollectionViaTestUnableScreenReason.IsReadOnly = false;
					this.LookupCollectionViaTestUnableScreenReason.Add((LookupEntity)entity);
					this.LookupCollectionViaTestUnableScreenReason.IsReadOnly = true;
					break;
				case "LookupCollectionViaEventTest_":
					this.LookupCollectionViaEventTest_.IsReadOnly = false;
					this.LookupCollectionViaEventTest_.Add((LookupEntity)entity);
					this.LookupCollectionViaEventTest_.IsReadOnly = true;
					break;
				case "LookupCollectionViaEventTest":
					this.LookupCollectionViaEventTest.IsReadOnly = false;
					this.LookupCollectionViaEventTest.Add((LookupEntity)entity);
					this.LookupCollectionViaEventTest.IsReadOnly = true;
					break;
				case "LookupCollectionViaEventTest__":
					this.LookupCollectionViaEventTest__.IsReadOnly = false;
					this.LookupCollectionViaEventTest__.Add((LookupEntity)entity);
					this.LookupCollectionViaEventTest__.IsReadOnly = true;
					break;
				case "LookupCollectionViaClinicalTestQualificationCriteria":
					this.LookupCollectionViaClinicalTestQualificationCriteria.IsReadOnly = false;
					this.LookupCollectionViaClinicalTestQualificationCriteria.Add((LookupEntity)entity);
					this.LookupCollectionViaClinicalTestQualificationCriteria.IsReadOnly = true;
					break;
				case "LookupCollectionViaPreQualificationQuestion":
					this.LookupCollectionViaPreQualificationQuestion.IsReadOnly = false;
					this.LookupCollectionViaPreQualificationQuestion.Add((LookupEntity)entity);
					this.LookupCollectionViaPreQualificationQuestion.IsReadOnly = true;
					break;
				case "LookupCollectionViaClinicalTestQualificationCriteria_":
					this.LookupCollectionViaClinicalTestQualificationCriteria_.IsReadOnly = false;
					this.LookupCollectionViaClinicalTestQualificationCriteria_.Add((LookupEntity)entity);
					this.LookupCollectionViaClinicalTestQualificationCriteria_.IsReadOnly = true;
					break;
				case "LookupCollectionViaKynLabValues":
					this.LookupCollectionViaKynLabValues.IsReadOnly = false;
					this.LookupCollectionViaKynLabValues.Add((LookupEntity)entity);
					this.LookupCollectionViaKynLabValues.IsReadOnly = true;
					break;
				case "NotificationTypeCollectionViaEventCustomerTestNotPerformedNotification":
					this.NotificationTypeCollectionViaEventCustomerTestNotPerformedNotification.IsReadOnly = false;
					this.NotificationTypeCollectionViaEventCustomerTestNotPerformedNotification.Add((NotificationTypeEntity)entity);
					this.NotificationTypeCollectionViaEventCustomerTestNotPerformedNotification.IsReadOnly = true;
					break;
				case "OrderItemCollectionViaProspectActivity":
					this.OrderItemCollectionViaProspectActivity.IsReadOnly = false;
					this.OrderItemCollectionViaProspectActivity.Add((OrderItemEntity)entity);
					this.OrderItemCollectionViaProspectActivity.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaPreQualificationQuestion":
					this.OrganizationRoleUserCollectionViaPreQualificationQuestion.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaPreQualificationQuestion.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaPreQualificationQuestion.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaPreApprovedTest":
					this.OrganizationRoleUserCollectionViaPreApprovedTest.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaPreApprovedTest.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaPreApprovedTest.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaTestHcpcsCode":
					this.OrganizationRoleUserCollectionViaTestHcpcsCode.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaTestHcpcsCode.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaTestHcpcsCode.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaTestHcpcsCode_":
					this.OrganizationRoleUserCollectionViaTestHcpcsCode_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaTestHcpcsCode_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaTestHcpcsCode_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaRequiredTest":
					this.OrganizationRoleUserCollectionViaRequiredTest.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaRequiredTest.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaRequiredTest.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaPreQualificationTestTemplate":
					this.OrganizationRoleUserCollectionViaPreQualificationTestTemplate.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaPreQualificationTestTemplate.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaPreQualificationTestTemplate.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaPreQualificationTestTemplate_":
					this.OrganizationRoleUserCollectionViaPreQualificationTestTemplate_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaPreQualificationTestTemplate_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaPreQualificationTestTemplate_.IsReadOnly = true;
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
				case "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria":
					this.OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventPhysicianTest__":
					this.OrganizationRoleUserCollectionViaEventPhysicianTest__.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventPhysicianTest__.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventPhysicianTest__.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_":
					this.OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventPhysicianTest":
					this.OrganizationRoleUserCollectionViaEventPhysicianTest.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventPhysicianTest.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventPhysicianTest.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaDisqualifiedTest_":
					this.OrganizationRoleUserCollectionViaDisqualifiedTest_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaDisqualifiedTest_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaDisqualifiedTest_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventPhysicianTest_":
					this.OrganizationRoleUserCollectionViaEventPhysicianTest_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventPhysicianTest_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventPhysicianTest_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaDisqualifiedTest":
					this.OrganizationRoleUserCollectionViaDisqualifiedTest.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaDisqualifiedTest.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaDisqualifiedTest.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaKynLabValues":
					this.OrganizationRoleUserCollectionViaKynLabValues.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaKynLabValues.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaKynLabValues.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaKynLabValues_":
					this.OrganizationRoleUserCollectionViaKynLabValues_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaKynLabValues_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaKynLabValues_.IsReadOnly = true;
					break;
				case "PackageCollectionViaEventCustomerPreApprovedPackageTest":
					this.PackageCollectionViaEventCustomerPreApprovedPackageTest.IsReadOnly = false;
					this.PackageCollectionViaEventCustomerPreApprovedPackageTest.Add((PackageEntity)entity);
					this.PackageCollectionViaEventCustomerPreApprovedPackageTest.IsReadOnly = true;
					break;
				case "PackageCollectionViaPackageTest":
					this.PackageCollectionViaPackageTest.IsReadOnly = false;
					this.PackageCollectionViaPackageTest.Add((PackageEntity)entity);
					this.PackageCollectionViaPackageTest.IsReadOnly = true;
					break;
				case "PackageCollectionViaHealthPlanRevenueItem":
					this.PackageCollectionViaHealthPlanRevenueItem.IsReadOnly = false;
					this.PackageCollectionViaHealthPlanRevenueItem.Add((PackageEntity)entity);
					this.PackageCollectionViaHealthPlanRevenueItem.IsReadOnly = true;
					break;
				case "PhysicianProfileCollectionViaPhysicianPermittedTest":
					this.PhysicianProfileCollectionViaPhysicianPermittedTest.IsReadOnly = false;
					this.PhysicianProfileCollectionViaPhysicianPermittedTest.Add((PhysicianProfileEntity)entity);
					this.PhysicianProfileCollectionViaPhysicianPermittedTest.IsReadOnly = true;
					break;
				case "PodDetailsCollectionViaPodTest":
					this.PodDetailsCollectionViaPodTest.IsReadOnly = false;
					this.PodDetailsCollectionViaPodTest.Add((PodDetailsEntity)entity);
					this.PodDetailsCollectionViaPodTest.IsReadOnly = true;
					break;
				case "PodRoomCollectionViaPodRoomTest":
					this.PodRoomCollectionViaPodRoomTest.IsReadOnly = false;
					this.PodRoomCollectionViaPodRoomTest.Add((PodRoomEntity)entity);
					this.PodRoomCollectionViaPodRoomTest.IsReadOnly = true;
					break;
				case "PreQualificationQuestionCollectionViaDisqualifiedTest":
					this.PreQualificationQuestionCollectionViaDisqualifiedTest.IsReadOnly = false;
					this.PreQualificationQuestionCollectionViaDisqualifiedTest.Add((PreQualificationQuestionEntity)entity);
					this.PreQualificationQuestionCollectionViaDisqualifiedTest.IsReadOnly = true;
					break;
				case "PreQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest":
					this.PreQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest.IsReadOnly = false;
					this.PreQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest.Add((PreQualificationTestTemplateEntity)entity);
					this.PreQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest.IsReadOnly = true;
					break;
				case "PreQualificationTestTemplateCollectionViaEventTest":
					this.PreQualificationTestTemplateCollectionViaEventTest.IsReadOnly = false;
					this.PreQualificationTestTemplateCollectionViaEventTest.Add((PreQualificationTestTemplateEntity)entity);
					this.PreQualificationTestTemplateCollectionViaEventTest.IsReadOnly = true;
					break;
				case "ReadingCollectionViaTestReading":
					this.ReadingCollectionViaTestReading.IsReadOnly = false;
					this.ReadingCollectionViaTestReading.Add((ReadingEntity)entity);
					this.ReadingCollectionViaTestReading.IsReadOnly = true;
					break;
				case "ReadingCollectionViaStandardFindingTestReading":
					this.ReadingCollectionViaStandardFindingTestReading.IsReadOnly = false;
					this.ReadingCollectionViaStandardFindingTestReading.Add((ReadingEntity)entity);
					this.ReadingCollectionViaStandardFindingTestReading.IsReadOnly = true;
					break;
				case "ResultArchiveUploadCollectionViaResultArchiveUploadLog":
					this.ResultArchiveUploadCollectionViaResultArchiveUploadLog.IsReadOnly = false;
					this.ResultArchiveUploadCollectionViaResultArchiveUploadLog.Add((ResultArchiveUploadEntity)entity);
					this.ResultArchiveUploadCollectionViaResultArchiveUploadLog.IsReadOnly = true;
					break;
				case "StaffEventRoleCollectionViaStaffEventRoleTest":
					this.StaffEventRoleCollectionViaStaffEventRoleTest.IsReadOnly = false;
					this.StaffEventRoleCollectionViaStaffEventRoleTest.Add((StaffEventRoleEntity)entity);
					this.StaffEventRoleCollectionViaStaffEventRoleTest.IsReadOnly = true;
					break;
				case "StandardFindingCollectionViaStandardFindingTestReading":
					this.StandardFindingCollectionViaStandardFindingTestReading.IsReadOnly = false;
					this.StandardFindingCollectionViaStandardFindingTestReading.Add((StandardFindingEntity)entity);
					this.StandardFindingCollectionViaStandardFindingTestReading.IsReadOnly = true;
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
			return TestEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "HafTemplate":
					toReturn.Add(TestEntity.Relations.HafTemplateEntityUsingHafTemplateId);
					break;
				case "Lookup__":
					toReturn.Add(TestEntity.Relations.LookupEntityUsingResultEntryTypeId);
					break;
				case "Lookup_":
					toReturn.Add(TestEntity.Relations.LookupEntityUsingGroupId);
					break;
				case "Lookup":
					toReturn.Add(TestEntity.Relations.LookupEntityUsingGender);
					break;
				case "PreQualificationTestTemplate_":
					toReturn.Add(TestEntity.Relations.PreQualificationTestTemplateEntityUsingPreQualificationQuestionTemplateId);
					break;
				case "AccountCustomerResultTestDependency":
					toReturn.Add(TestEntity.Relations.AccountCustomerResultTestDependencyEntityUsingTestId);
					break;
				case "AccountHealthPlanResultTestDependency":
					toReturn.Add(TestEntity.Relations.AccountHealthPlanResultTestDependencyEntityUsingTestId);
					break;
				case "AccountNotReviewableTest":
					toReturn.Add(TestEntity.Relations.AccountNotReviewableTestEntityUsingTestId);
					break;
				case "AccountPcpResultTestDependency":
					toReturn.Add(TestEntity.Relations.AccountPcpResultTestDependencyEntityUsingTestId);
					break;
				case "AccountTest":
					toReturn.Add(TestEntity.Relations.AccountTestEntityUsingTestId);
					break;
				case "BillingAccountTest":
					toReturn.Add(TestEntity.Relations.BillingAccountTestEntityUsingTestId);
					break;
				case "ClinicalTestQualificationCriteria":
					toReturn.Add(TestEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTestId);
					break;
				case "CustomerEventScreeningTests":
					toReturn.Add(TestEntity.Relations.CustomerEventScreeningTestsEntityUsingTestId);
					break;
				case "CustomerEventTestFinding":
					toReturn.Add(TestEntity.Relations.CustomerEventTestFindingEntityUsingTestId);
					break;
				case "CustomerHealthQuestionGroup":
					toReturn.Add(TestEntity.Relations.CustomerHealthQuestionGroupEntityUsingTestId);
					break;
				case "DependentDisqualifiedTest":
					toReturn.Add(TestEntity.Relations.DependentDisqualifiedTestEntityUsingTestId);
					break;
				case "DisqualifiedTest":
					toReturn.Add(TestEntity.Relations.DisqualifiedTestEntityUsingTestId);
					break;
				case "EventCustomerPreApprovedPackageTest":
					toReturn.Add(TestEntity.Relations.EventCustomerPreApprovedPackageTestEntityUsingTestId);
					break;
				case "EventCustomerPreApprovedTest":
					toReturn.Add(TestEntity.Relations.EventCustomerPreApprovedTestEntityUsingTestId);
					break;
				case "EventCustomerRequiredTest":
					toReturn.Add(TestEntity.Relations.EventCustomerRequiredTestEntityUsingTestId);
					break;
				case "EventCustomerRetest":
					toReturn.Add(TestEntity.Relations.EventCustomerRetestEntityUsingTestId);
					break;
				case "EventCustomerTestNotPerformedNotification":
					toReturn.Add(TestEntity.Relations.EventCustomerTestNotPerformedNotificationEntityUsingTestId);
					break;
				case "EventPhysicianTest":
					toReturn.Add(TestEntity.Relations.EventPhysicianTestEntityUsingTestId);
					break;
				case "EventPodRoomTest":
					toReturn.Add(TestEntity.Relations.EventPodRoomTestEntityUsingTestId);
					break;
				case "EventTest":
					toReturn.Add(TestEntity.Relations.EventTestEntityUsingTestId);
					break;
				case "HealthPlanRevenueItem":
					toReturn.Add(TestEntity.Relations.HealthPlanRevenueItemEntityUsingTestId);
					break;
				case "InventoryItemTest":
					toReturn.Add(TestEntity.Relations.InventoryItemTestEntityUsingTestId);
					break;
				case "KynLabValues":
					toReturn.Add(TestEntity.Relations.KynLabValuesEntityUsingTestId);
					break;
				case "PackageTest":
					toReturn.Add(TestEntity.Relations.PackageTestEntityUsingTestId);
					break;
				case "PhysicianPermittedTest":
					toReturn.Add(TestEntity.Relations.PhysicianPermittedTestEntityUsingTestId);
					break;
				case "PodRoomTest":
					toReturn.Add(TestEntity.Relations.PodRoomTestEntityUsingTestId);
					break;
				case "PodTest":
					toReturn.Add(TestEntity.Relations.PodTestEntityUsingTestId);
					break;
				case "PreApprovedTest":
					toReturn.Add(TestEntity.Relations.PreApprovedTestEntityUsingTestId);
					break;
				case "PreQualificationQuestion":
					toReturn.Add(TestEntity.Relations.PreQualificationQuestionEntityUsingTestId);
					break;
				case "PreQualificationTemplateDependentTest":
					toReturn.Add(TestEntity.Relations.PreQualificationTemplateDependentTestEntityUsingTestId);
					break;
				case "PreQualificationTestTemplate":
					toReturn.Add(TestEntity.Relations.PreQualificationTestTemplateEntityUsingTestId);
					break;
				case "ProspectActivity":
					toReturn.Add(TestEntity.Relations.ProspectActivityEntityUsingActivityId);
					break;
				case "RequiredTest":
					toReturn.Add(TestEntity.Relations.RequiredTestEntityUsingTestId);
					break;
				case "ResultArchiveUploadLog":
					toReturn.Add(TestEntity.Relations.ResultArchiveUploadLogEntityUsingTestId);
					break;
				case "StaffEventRoleTest":
					toReturn.Add(TestEntity.Relations.StaffEventRoleTestEntityUsingTestId);
					break;
				case "StandardFindingTestReading":
					toReturn.Add(TestEntity.Relations.StandardFindingTestReadingEntityUsingTestId);
					break;
				case "TestDependencyRule":
					toReturn.Add(TestEntity.Relations.TestDependencyRuleEntityUsingDependantTestId);
					break;
				case "TestDependencyRule_":
					toReturn.Add(TestEntity.Relations.TestDependencyRuleEntityUsingTestId);
					break;
				case "TestHcpcsCode":
					toReturn.Add(TestEntity.Relations.TestHcpcsCodeEntityUsingTestId);
					break;
				case "TestIncidentalFinding":
					toReturn.Add(TestEntity.Relations.TestIncidentalFindingEntityUsingTestId);
					break;
				case "TestReading":
					toReturn.Add(TestEntity.Relations.TestReadingEntityUsingTestId);
					break;
				case "TestSourceCodeDiscount":
					toReturn.Add(TestEntity.Relations.TestSourceCodeDiscountEntityUsingTestId);
					break;
				case "TestUnableScreenReason":
					toReturn.Add(TestEntity.Relations.TestUnableScreenReasonEntityUsingTestId);
					break;
				case "AccountCollectionViaAccountPcpResultTestDependency":
					toReturn.Add(TestEntity.Relations.AccountPcpResultTestDependencyEntityUsingTestId, "TestEntity__", "AccountPcpResultTestDependency_", JoinHint.None);
					toReturn.Add(AccountPcpResultTestDependencyEntity.Relations.AccountEntityUsingAccountId, "AccountPcpResultTestDependency_", string.Empty, JoinHint.None);
					break;
				case "AccountCollectionViaAccountTest":
					toReturn.Add(TestEntity.Relations.AccountTestEntityUsingTestId, "TestEntity__", "AccountTest_", JoinHint.None);
					toReturn.Add(AccountTestEntity.Relations.AccountEntityUsingAccountId, "AccountTest_", string.Empty, JoinHint.None);
					break;
				case "AccountCollectionViaAccountNotReviewableTest":
					toReturn.Add(TestEntity.Relations.AccountNotReviewableTestEntityUsingTestId, "TestEntity__", "AccountNotReviewableTest_", JoinHint.None);
					toReturn.Add(AccountNotReviewableTestEntity.Relations.AccountEntityUsingAccountId, "AccountNotReviewableTest_", string.Empty, JoinHint.None);
					break;
				case "AccountCollectionViaAccountCustomerResultTestDependency":
					toReturn.Add(TestEntity.Relations.AccountCustomerResultTestDependencyEntityUsingTestId, "TestEntity__", "AccountCustomerResultTestDependency_", JoinHint.None);
					toReturn.Add(AccountCustomerResultTestDependencyEntity.Relations.AccountEntityUsingAccountId, "AccountCustomerResultTestDependency_", string.Empty, JoinHint.None);
					break;
				case "AccountCollectionViaAccountHealthPlanResultTestDependency":
					toReturn.Add(TestEntity.Relations.AccountHealthPlanResultTestDependencyEntityUsingTestId, "TestEntity__", "AccountHealthPlanResultTestDependency_", JoinHint.None);
					toReturn.Add(AccountHealthPlanResultTestDependencyEntity.Relations.AccountEntityUsingAccountId, "AccountHealthPlanResultTestDependency_", string.Empty, JoinHint.None);
					break;
				case "BillingAccountCollectionViaBillingAccountTest":
					toReturn.Add(TestEntity.Relations.BillingAccountTestEntityUsingTestId, "TestEntity__", "BillingAccountTest_", JoinHint.None);
					toReturn.Add(BillingAccountTestEntity.Relations.BillingAccountEntityUsingBillingAccountId, "BillingAccountTest_", string.Empty, JoinHint.None);
					break;
				case "CouponsCollectionViaTestSourceCodeDiscount":
					toReturn.Add(TestEntity.Relations.TestSourceCodeDiscountEntityUsingTestId, "TestEntity__", "TestSourceCodeDiscount_", JoinHint.None);
					toReturn.Add(TestSourceCodeDiscountEntity.Relations.CouponsEntityUsingSourceCodeId, "TestSourceCodeDiscount_", string.Empty, JoinHint.None);
					break;
				case "CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_":
					toReturn.Add(TestEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTestId, "TestEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.CustomerHealthQuestionsEntityUsingDisqualifierQuestionId, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
					break;
				case "CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria":
					toReturn.Add(TestEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTestId, "TestEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.CustomerHealthQuestionsEntityUsingMedicationQuestionId, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaDependentDisqualifiedTest":
					toReturn.Add(TestEntity.Relations.DependentDisqualifiedTestEntityUsingTestId, "TestEntity__", "DependentDisqualifiedTest_", JoinHint.None);
					toReturn.Add(DependentDisqualifiedTestEntity.Relations.CustomerProfileEntityUsingCustomerId, "DependentDisqualifiedTest_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCustomerEventTestFinding":
					toReturn.Add(TestEntity.Relations.CustomerEventTestFindingEntityUsingTestId, "TestEntity__", "CustomerEventTestFinding_", JoinHint.None);
					toReturn.Add(CustomerEventTestFindingEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerEventTestFinding_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaDisqualifiedTest":
					toReturn.Add(TestEntity.Relations.DisqualifiedTestEntityUsingTestId, "TestEntity__", "DisqualifiedTest_", JoinHint.None);
					toReturn.Add(DisqualifiedTestEntity.Relations.CustomerProfileEntityUsingCustomerId, "DisqualifiedTest_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaResultArchiveUploadLog":
					toReturn.Add(TestEntity.Relations.ResultArchiveUploadLogEntityUsingTestId, "TestEntity__", "ResultArchiveUploadLog_", JoinHint.None);
					toReturn.Add(ResultArchiveUploadLogEntity.Relations.CustomerProfileEntityUsingCustomerId, "ResultArchiveUploadLog_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaRequiredTest":
					toReturn.Add(TestEntity.Relations.RequiredTestEntityUsingTestId, "TestEntity__", "RequiredTest_", JoinHint.None);
					toReturn.Add(RequiredTestEntity.Relations.CustomerProfileEntityUsingCustomerId, "RequiredTest_", string.Empty, JoinHint.None);
					break;
				case "EventCustomerResultCollectionViaKynLabValues":
					toReturn.Add(TestEntity.Relations.KynLabValuesEntityUsingTestId, "TestEntity__", "KynLabValues_", JoinHint.None);
					toReturn.Add(KynLabValuesEntity.Relations.EventCustomerResultEntityUsingEventCustomerResultId, "KynLabValues_", string.Empty, JoinHint.None);
					break;
				case "EventCustomerResultCollectionViaCustomerEventScreeningTests":
					toReturn.Add(TestEntity.Relations.CustomerEventScreeningTestsEntityUsingTestId, "TestEntity__", "CustomerEventScreeningTests_", JoinHint.None);
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.EventCustomerResultEntityUsingEventCustomerResultId, "CustomerEventScreeningTests_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaDisqualifiedTest":
					toReturn.Add(TestEntity.Relations.DisqualifiedTestEntityUsingTestId, "TestEntity__", "DisqualifiedTest_", JoinHint.None);
					toReturn.Add(DisqualifiedTestEntity.Relations.EventCustomersEntityUsingEventCustomerId, "DisqualifiedTest_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaEventCustomerPreApprovedTest":
					toReturn.Add(TestEntity.Relations.EventCustomerPreApprovedTestEntityUsingTestId, "TestEntity__", "EventCustomerPreApprovedTest_", JoinHint.None);
					toReturn.Add(EventCustomerPreApprovedTestEntity.Relations.EventCustomersEntityUsingEventCustomerId, "EventCustomerPreApprovedTest_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaEventCustomerPreApprovedPackageTest":
					toReturn.Add(TestEntity.Relations.EventCustomerPreApprovedPackageTestEntityUsingTestId, "TestEntity__", "EventCustomerPreApprovedPackageTest_", JoinHint.None);
					toReturn.Add(EventCustomerPreApprovedPackageTestEntity.Relations.EventCustomersEntityUsingEventCustomerId, "EventCustomerPreApprovedPackageTest_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaEventCustomerRequiredTest":
					toReturn.Add(TestEntity.Relations.EventCustomerRequiredTestEntityUsingTestId, "TestEntity__", "EventCustomerRequiredTest_", JoinHint.None);
					toReturn.Add(EventCustomerRequiredTestEntity.Relations.EventCustomersEntityUsingEventCustomerId, "EventCustomerRequiredTest_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaEventCustomerTestNotPerformedNotification":
					toReturn.Add(TestEntity.Relations.EventCustomerTestNotPerformedNotificationEntityUsingTestId, "TestEntity__", "EventCustomerTestNotPerformedNotification_", JoinHint.None);
					toReturn.Add(EventCustomerTestNotPerformedNotificationEntity.Relations.EventCustomersEntityUsingEventCustomerId, "EventCustomerTestNotPerformedNotification_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaDependentDisqualifiedTest":
					toReturn.Add(TestEntity.Relations.DependentDisqualifiedTestEntityUsingTestId, "TestEntity__", "DependentDisqualifiedTest_", JoinHint.None);
					toReturn.Add(DependentDisqualifiedTestEntity.Relations.EventCustomersEntityUsingEventCustomerId, "DependentDisqualifiedTest_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaEventCustomerRetest":
					toReturn.Add(TestEntity.Relations.EventCustomerRetestEntityUsingTestId, "TestEntity__", "EventCustomerRetest_", JoinHint.None);
					toReturn.Add(EventCustomerRetestEntity.Relations.EventCustomersEntityUsingEventCustomerId, "EventCustomerRetest_", string.Empty, JoinHint.None);
					break;
				case "EventPodRoomCollectionViaEventPodRoomTest":
					toReturn.Add(TestEntity.Relations.EventPodRoomTestEntityUsingTestId, "TestEntity__", "EventPodRoomTest_", JoinHint.None);
					toReturn.Add(EventPodRoomTestEntity.Relations.EventPodRoomEntityUsingEventPodRoomId, "EventPodRoomTest_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaDependentDisqualifiedTest":
					toReturn.Add(TestEntity.Relations.DependentDisqualifiedTestEntityUsingTestId, "TestEntity__", "DependentDisqualifiedTest_", JoinHint.None);
					toReturn.Add(DependentDisqualifiedTestEntity.Relations.EventsEntityUsingEventId, "DependentDisqualifiedTest_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaDisqualifiedTest":
					toReturn.Add(TestEntity.Relations.DisqualifiedTestEntityUsingTestId, "TestEntity__", "DisqualifiedTest_", JoinHint.None);
					toReturn.Add(DisqualifiedTestEntity.Relations.EventsEntityUsingEventId, "DisqualifiedTest_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventPhysicianTest":
					toReturn.Add(TestEntity.Relations.EventPhysicianTestEntityUsingTestId, "TestEntity__", "EventPhysicianTest_", JoinHint.None);
					toReturn.Add(EventPhysicianTestEntity.Relations.EventsEntityUsingEventId, "EventPhysicianTest_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventTest":
					toReturn.Add(TestEntity.Relations.EventTestEntityUsingTestId, "TestEntity__", "EventTest_", JoinHint.None);
					toReturn.Add(EventTestEntity.Relations.EventsEntityUsingEventId, "EventTest_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaCustomerEventTestFinding":
					toReturn.Add(TestEntity.Relations.CustomerEventTestFindingEntityUsingTestId, "TestEntity__", "CustomerEventTestFinding_", JoinHint.None);
					toReturn.Add(CustomerEventTestFindingEntity.Relations.EventsEntityUsingEventId, "CustomerEventTestFinding_", string.Empty, JoinHint.None);
					break;
				case "HafTemplateCollectionViaClinicalTestQualificationCriteria":
					toReturn.Add(TestEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTestId, "TestEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.HafTemplateEntityUsingTemplateId, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
					break;
				case "HafTemplateCollectionViaEventTest":
					toReturn.Add(TestEntity.Relations.EventTestEntityUsingTestId, "TestEntity__", "EventTest_", JoinHint.None);
					toReturn.Add(EventTestEntity.Relations.HafTemplateEntityUsingHafTemplateId, "EventTest_", string.Empty, JoinHint.None);
					break;
				case "HcpcsCodeCollectionViaTestHcpcsCode":
					toReturn.Add(TestEntity.Relations.TestHcpcsCodeEntityUsingTestId, "TestEntity__", "TestHcpcsCode_", JoinHint.None);
					toReturn.Add(TestHcpcsCodeEntity.Relations.HcpcsCodeEntityUsingHcpcsCodeId, "TestHcpcsCode_", string.Empty, JoinHint.None);
					break;
				case "HealthPlanRevenueCollectionViaHealthPlanRevenueItem":
					toReturn.Add(TestEntity.Relations.HealthPlanRevenueItemEntityUsingTestId, "TestEntity__", "HealthPlanRevenueItem_", JoinHint.None);
					toReturn.Add(HealthPlanRevenueItemEntity.Relations.HealthPlanRevenueEntityUsingHealthPlanRevenueId, "HealthPlanRevenueItem_", string.Empty, JoinHint.None);
					break;
				case "IncidentalFindingsCollectionViaTestIncidentalFinding":
					toReturn.Add(TestEntity.Relations.TestIncidentalFindingEntityUsingTestId, "TestEntity__", "TestIncidentalFinding_", JoinHint.None);
					toReturn.Add(TestIncidentalFindingEntity.Relations.IncidentalFindingsEntityUsingIncidentalFindingId, "TestIncidentalFinding_", string.Empty, JoinHint.None);
					break;
				case "InventoryItemCollectionViaInventoryItemTest":
					toReturn.Add(TestEntity.Relations.InventoryItemTestEntityUsingTestId, "TestEntity__", "InventoryItemTest_", JoinHint.None);
					toReturn.Add(InventoryItemTestEntity.Relations.InventoryItemEntityUsingInventoryItemId, "InventoryItemTest_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaTestUnableScreenReason":
					toReturn.Add(TestEntity.Relations.TestUnableScreenReasonEntityUsingTestId, "TestEntity__", "TestUnableScreenReason_", JoinHint.None);
					toReturn.Add(TestUnableScreenReasonEntity.Relations.LookupEntityUsingUnableScreenReasonId, "TestUnableScreenReason_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventTest_":
					toReturn.Add(TestEntity.Relations.EventTestEntityUsingTestId, "TestEntity__", "EventTest_", JoinHint.None);
					toReturn.Add(EventTestEntity.Relations.LookupEntityUsingGroupId, "EventTest_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventTest":
					toReturn.Add(TestEntity.Relations.EventTestEntityUsingTestId, "TestEntity__", "EventTest_", JoinHint.None);
					toReturn.Add(EventTestEntity.Relations.LookupEntityUsingGender, "EventTest_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventTest__":
					toReturn.Add(TestEntity.Relations.EventTestEntityUsingTestId, "TestEntity__", "EventTest_", JoinHint.None);
					toReturn.Add(EventTestEntity.Relations.LookupEntityUsingResultEntryTypeId, "EventTest_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaClinicalTestQualificationCriteria":
					toReturn.Add(TestEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTestId, "TestEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.LookupEntityUsingAgeCondition, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaPreQualificationQuestion":
					toReturn.Add(TestEntity.Relations.PreQualificationQuestionEntityUsingTestId, "TestEntity__", "PreQualificationQuestion_", JoinHint.None);
					toReturn.Add(PreQualificationQuestionEntity.Relations.LookupEntityUsingTypeId, "PreQualificationQuestion_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaClinicalTestQualificationCriteria_":
					toReturn.Add(TestEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTestId, "TestEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.LookupEntityUsingGender, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaKynLabValues":
					toReturn.Add(TestEntity.Relations.KynLabValuesEntityUsingTestId, "TestEntity__", "KynLabValues_", JoinHint.None);
					toReturn.Add(KynLabValuesEntity.Relations.LookupEntityUsingFastingStatus, "KynLabValues_", string.Empty, JoinHint.None);
					break;
				case "NotificationTypeCollectionViaEventCustomerTestNotPerformedNotification":
					toReturn.Add(TestEntity.Relations.EventCustomerTestNotPerformedNotificationEntityUsingTestId, "TestEntity__", "EventCustomerTestNotPerformedNotification_", JoinHint.None);
					toReturn.Add(EventCustomerTestNotPerformedNotificationEntity.Relations.NotificationTypeEntityUsingNotificationTypeId, "EventCustomerTestNotPerformedNotification_", string.Empty, JoinHint.None);
					break;
				case "OrderItemCollectionViaProspectActivity":
					toReturn.Add(TestEntity.Relations.ProspectActivityEntityUsingActivityId, "TestEntity__", "ProspectActivity_", JoinHint.None);
					toReturn.Add(ProspectActivityEntity.Relations.OrderItemEntityUsingProspectId, "ProspectActivity_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaPreQualificationQuestion":
					toReturn.Add(TestEntity.Relations.PreQualificationQuestionEntityUsingTestId, "TestEntity__", "PreQualificationQuestion_", JoinHint.None);
					toReturn.Add(PreQualificationQuestionEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "PreQualificationQuestion_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaPreApprovedTest":
					toReturn.Add(TestEntity.Relations.PreApprovedTestEntityUsingTestId, "TestEntity__", "PreApprovedTest_", JoinHint.None);
					toReturn.Add(PreApprovedTestEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "PreApprovedTest_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaTestHcpcsCode":
					toReturn.Add(TestEntity.Relations.TestHcpcsCodeEntityUsingTestId, "TestEntity__", "TestHcpcsCode_", JoinHint.None);
					toReturn.Add(TestHcpcsCodeEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "TestHcpcsCode_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaTestHcpcsCode_":
					toReturn.Add(TestEntity.Relations.TestHcpcsCodeEntityUsingTestId, "TestEntity__", "TestHcpcsCode_", JoinHint.None);
					toReturn.Add(TestHcpcsCodeEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "TestHcpcsCode_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaRequiredTest":
					toReturn.Add(TestEntity.Relations.RequiredTestEntityUsingTestId, "TestEntity__", "RequiredTest_", JoinHint.None);
					toReturn.Add(RequiredTestEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "RequiredTest_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaPreQualificationTestTemplate":
					toReturn.Add(TestEntity.Relations.PreQualificationTestTemplateEntityUsingTestId, "TestEntity__", "PreQualificationTestTemplate_", JoinHint.None);
					toReturn.Add(PreQualificationTestTemplateEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "PreQualificationTestTemplate_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaPreQualificationTestTemplate_":
					toReturn.Add(TestEntity.Relations.PreQualificationTestTemplateEntityUsingTestId, "TestEntity__", "PreQualificationTestTemplate_", JoinHint.None);
					toReturn.Add(PreQualificationTestTemplateEntity.Relations.OrganizationRoleUserEntityUsingUpdatedBy, "PreQualificationTestTemplate_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification":
					toReturn.Add(TestEntity.Relations.EventCustomerTestNotPerformedNotificationEntityUsingTestId, "TestEntity__", "EventCustomerTestNotPerformedNotification_", JoinHint.None);
					toReturn.Add(EventCustomerTestNotPerformedNotificationEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "EventCustomerTestNotPerformedNotification_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventCustomerRetest":
					toReturn.Add(TestEntity.Relations.EventCustomerRetestEntityUsingTestId, "TestEntity__", "EventCustomerRetest_", JoinHint.None);
					toReturn.Add(EventCustomerRetestEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "EventCustomerRetest_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria":
					toReturn.Add(TestEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTestId, "TestEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventPhysicianTest__":
					toReturn.Add(TestEntity.Relations.EventPhysicianTestEntityUsingTestId, "TestEntity__", "EventPhysicianTest_", JoinHint.None);
					toReturn.Add(EventPhysicianTestEntity.Relations.OrganizationRoleUserEntityUsingPhysicianId, "EventPhysicianTest_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_":
					toReturn.Add(TestEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTestId, "TestEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventPhysicianTest":
					toReturn.Add(TestEntity.Relations.EventPhysicianTestEntityUsingTestId, "TestEntity__", "EventPhysicianTest_", JoinHint.None);
					toReturn.Add(EventPhysicianTestEntity.Relations.OrganizationRoleUserEntityUsingAssignedByOrgRoleUserId, "EventPhysicianTest_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaDisqualifiedTest_":
					toReturn.Add(TestEntity.Relations.DisqualifiedTestEntityUsingTestId, "TestEntity__", "DisqualifiedTest_", JoinHint.None);
					toReturn.Add(DisqualifiedTestEntity.Relations.OrganizationRoleUserEntityUsingUpdatedBy, "DisqualifiedTest_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventPhysicianTest_":
					toReturn.Add(TestEntity.Relations.EventPhysicianTestEntityUsingTestId, "TestEntity__", "EventPhysicianTest_", JoinHint.None);
					toReturn.Add(EventPhysicianTestEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, "EventPhysicianTest_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaDisqualifiedTest":
					toReturn.Add(TestEntity.Relations.DisqualifiedTestEntityUsingTestId, "TestEntity__", "DisqualifiedTest_", JoinHint.None);
					toReturn.Add(DisqualifiedTestEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "DisqualifiedTest_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaKynLabValues":
					toReturn.Add(TestEntity.Relations.KynLabValuesEntityUsingTestId, "TestEntity__", "KynLabValues_", JoinHint.None);
					toReturn.Add(KynLabValuesEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "KynLabValues_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaKynLabValues_":
					toReturn.Add(TestEntity.Relations.KynLabValuesEntityUsingTestId, "TestEntity__", "KynLabValues_", JoinHint.None);
					toReturn.Add(KynLabValuesEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, "KynLabValues_", string.Empty, JoinHint.None);
					break;
				case "PackageCollectionViaEventCustomerPreApprovedPackageTest":
					toReturn.Add(TestEntity.Relations.EventCustomerPreApprovedPackageTestEntityUsingTestId, "TestEntity__", "EventCustomerPreApprovedPackageTest_", JoinHint.None);
					toReturn.Add(EventCustomerPreApprovedPackageTestEntity.Relations.PackageEntityUsingPackageId, "EventCustomerPreApprovedPackageTest_", string.Empty, JoinHint.None);
					break;
				case "PackageCollectionViaPackageTest":
					toReturn.Add(TestEntity.Relations.PackageTestEntityUsingTestId, "TestEntity__", "PackageTest_", JoinHint.None);
					toReturn.Add(PackageTestEntity.Relations.PackageEntityUsingPackageId, "PackageTest_", string.Empty, JoinHint.None);
					break;
				case "PackageCollectionViaHealthPlanRevenueItem":
					toReturn.Add(TestEntity.Relations.HealthPlanRevenueItemEntityUsingTestId, "TestEntity__", "HealthPlanRevenueItem_", JoinHint.None);
					toReturn.Add(HealthPlanRevenueItemEntity.Relations.PackageEntityUsingPackageId, "HealthPlanRevenueItem_", string.Empty, JoinHint.None);
					break;
				case "PhysicianProfileCollectionViaPhysicianPermittedTest":
					toReturn.Add(TestEntity.Relations.PhysicianPermittedTestEntityUsingTestId, "TestEntity__", "PhysicianPermittedTest_", JoinHint.None);
					toReturn.Add(PhysicianPermittedTestEntity.Relations.PhysicianProfileEntityUsingOrganizationRoleUserId, "PhysicianPermittedTest_", string.Empty, JoinHint.None);
					break;
				case "PodDetailsCollectionViaPodTest":
					toReturn.Add(TestEntity.Relations.PodTestEntityUsingTestId, "TestEntity__", "PodTest_", JoinHint.None);
					toReturn.Add(PodTestEntity.Relations.PodDetailsEntityUsingPodId, "PodTest_", string.Empty, JoinHint.None);
					break;
				case "PodRoomCollectionViaPodRoomTest":
					toReturn.Add(TestEntity.Relations.PodRoomTestEntityUsingTestId, "TestEntity__", "PodRoomTest_", JoinHint.None);
					toReturn.Add(PodRoomTestEntity.Relations.PodRoomEntityUsingPodRoomId, "PodRoomTest_", string.Empty, JoinHint.None);
					break;
				case "PreQualificationQuestionCollectionViaDisqualifiedTest":
					toReturn.Add(TestEntity.Relations.DisqualifiedTestEntityUsingTestId, "TestEntity__", "DisqualifiedTest_", JoinHint.None);
					toReturn.Add(DisqualifiedTestEntity.Relations.PreQualificationQuestionEntityUsingQuestionId, "DisqualifiedTest_", string.Empty, JoinHint.None);
					break;
				case "PreQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest":
					toReturn.Add(TestEntity.Relations.PreQualificationTemplateDependentTestEntityUsingTestId, "TestEntity__", "PreQualificationTemplateDependentTest_", JoinHint.None);
					toReturn.Add(PreQualificationTemplateDependentTestEntity.Relations.PreQualificationTestTemplateEntityUsingTemplateId, "PreQualificationTemplateDependentTest_", string.Empty, JoinHint.None);
					break;
				case "PreQualificationTestTemplateCollectionViaEventTest":
					toReturn.Add(TestEntity.Relations.EventTestEntityUsingTestId, "TestEntity__", "EventTest_", JoinHint.None);
					toReturn.Add(EventTestEntity.Relations.PreQualificationTestTemplateEntityUsingPreQualificationQuestionTemplateId, "EventTest_", string.Empty, JoinHint.None);
					break;
				case "ReadingCollectionViaTestReading":
					toReturn.Add(TestEntity.Relations.TestReadingEntityUsingTestId, "TestEntity__", "TestReading_", JoinHint.None);
					toReturn.Add(TestReadingEntity.Relations.ReadingEntityUsingReadingId, "TestReading_", string.Empty, JoinHint.None);
					break;
				case "ReadingCollectionViaStandardFindingTestReading":
					toReturn.Add(TestEntity.Relations.StandardFindingTestReadingEntityUsingTestId, "TestEntity__", "StandardFindingTestReading_", JoinHint.None);
					toReturn.Add(StandardFindingTestReadingEntity.Relations.ReadingEntityUsingReadingId, "StandardFindingTestReading_", string.Empty, JoinHint.None);
					break;
				case "ResultArchiveUploadCollectionViaResultArchiveUploadLog":
					toReturn.Add(TestEntity.Relations.ResultArchiveUploadLogEntityUsingTestId, "TestEntity__", "ResultArchiveUploadLog_", JoinHint.None);
					toReturn.Add(ResultArchiveUploadLogEntity.Relations.ResultArchiveUploadEntityUsingResultArchiveUploadId, "ResultArchiveUploadLog_", string.Empty, JoinHint.None);
					break;
				case "StaffEventRoleCollectionViaStaffEventRoleTest":
					toReturn.Add(TestEntity.Relations.StaffEventRoleTestEntityUsingTestId, "TestEntity__", "StaffEventRoleTest_", JoinHint.None);
					toReturn.Add(StaffEventRoleTestEntity.Relations.StaffEventRoleEntityUsingStaffEventRoleId, "StaffEventRoleTest_", string.Empty, JoinHint.None);
					break;
				case "StandardFindingCollectionViaStandardFindingTestReading":
					toReturn.Add(TestEntity.Relations.StandardFindingTestReadingEntityUsingTestId, "TestEntity__", "StandardFindingTestReading_", JoinHint.None);
					toReturn.Add(StandardFindingTestReadingEntity.Relations.StandardFindingEntityUsingStandardFindingId, "StandardFindingTestReading_", string.Empty, JoinHint.None);
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
				case "HafTemplate":
					SetupSyncHafTemplate(relatedEntity);
					break;
				case "Lookup__":
					SetupSyncLookup__(relatedEntity);
					break;
				case "Lookup_":
					SetupSyncLookup_(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "PreQualificationTestTemplate_":
					SetupSyncPreQualificationTestTemplate_(relatedEntity);
					break;
				case "AccountCustomerResultTestDependency":
					this.AccountCustomerResultTestDependency.Add((AccountCustomerResultTestDependencyEntity)relatedEntity);
					break;
				case "AccountHealthPlanResultTestDependency":
					this.AccountHealthPlanResultTestDependency.Add((AccountHealthPlanResultTestDependencyEntity)relatedEntity);
					break;
				case "AccountNotReviewableTest":
					this.AccountNotReviewableTest.Add((AccountNotReviewableTestEntity)relatedEntity);
					break;
				case "AccountPcpResultTestDependency":
					this.AccountPcpResultTestDependency.Add((AccountPcpResultTestDependencyEntity)relatedEntity);
					break;
				case "AccountTest":
					this.AccountTest.Add((AccountTestEntity)relatedEntity);
					break;
				case "BillingAccountTest":
					this.BillingAccountTest.Add((BillingAccountTestEntity)relatedEntity);
					break;
				case "ClinicalTestQualificationCriteria":
					this.ClinicalTestQualificationCriteria.Add((ClinicalTestQualificationCriteriaEntity)relatedEntity);
					break;
				case "CustomerEventScreeningTests":
					this.CustomerEventScreeningTests.Add((CustomerEventScreeningTestsEntity)relatedEntity);
					break;
				case "CustomerEventTestFinding":
					this.CustomerEventTestFinding.Add((CustomerEventTestFindingEntity)relatedEntity);
					break;
				case "CustomerHealthQuestionGroup":
					this.CustomerHealthQuestionGroup.Add((CustomerHealthQuestionGroupEntity)relatedEntity);
					break;
				case "DependentDisqualifiedTest":
					this.DependentDisqualifiedTest.Add((DependentDisqualifiedTestEntity)relatedEntity);
					break;
				case "DisqualifiedTest":
					this.DisqualifiedTest.Add((DisqualifiedTestEntity)relatedEntity);
					break;
				case "EventCustomerPreApprovedPackageTest":
					this.EventCustomerPreApprovedPackageTest.Add((EventCustomerPreApprovedPackageTestEntity)relatedEntity);
					break;
				case "EventCustomerPreApprovedTest":
					this.EventCustomerPreApprovedTest.Add((EventCustomerPreApprovedTestEntity)relatedEntity);
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
				case "EventPhysicianTest":
					this.EventPhysicianTest.Add((EventPhysicianTestEntity)relatedEntity);
					break;
				case "EventPodRoomTest":
					this.EventPodRoomTest.Add((EventPodRoomTestEntity)relatedEntity);
					break;
				case "EventTest":
					this.EventTest.Add((EventTestEntity)relatedEntity);
					break;
				case "HealthPlanRevenueItem":
					this.HealthPlanRevenueItem.Add((HealthPlanRevenueItemEntity)relatedEntity);
					break;
				case "InventoryItemTest":
					this.InventoryItemTest.Add((InventoryItemTestEntity)relatedEntity);
					break;
				case "KynLabValues":
					this.KynLabValues.Add((KynLabValuesEntity)relatedEntity);
					break;
				case "PackageTest":
					this.PackageTest.Add((PackageTestEntity)relatedEntity);
					break;
				case "PhysicianPermittedTest":
					this.PhysicianPermittedTest.Add((PhysicianPermittedTestEntity)relatedEntity);
					break;
				case "PodRoomTest":
					this.PodRoomTest.Add((PodRoomTestEntity)relatedEntity);
					break;
				case "PodTest":
					this.PodTest.Add((PodTestEntity)relatedEntity);
					break;
				case "PreApprovedTest":
					this.PreApprovedTest.Add((PreApprovedTestEntity)relatedEntity);
					break;
				case "PreQualificationQuestion":
					this.PreQualificationQuestion.Add((PreQualificationQuestionEntity)relatedEntity);
					break;
				case "PreQualificationTemplateDependentTest":
					this.PreQualificationTemplateDependentTest.Add((PreQualificationTemplateDependentTestEntity)relatedEntity);
					break;
				case "PreQualificationTestTemplate":
					this.PreQualificationTestTemplate.Add((PreQualificationTestTemplateEntity)relatedEntity);
					break;
				case "ProspectActivity":
					this.ProspectActivity.Add((ProspectActivityEntity)relatedEntity);
					break;
				case "RequiredTest":
					this.RequiredTest.Add((RequiredTestEntity)relatedEntity);
					break;
				case "ResultArchiveUploadLog":
					this.ResultArchiveUploadLog.Add((ResultArchiveUploadLogEntity)relatedEntity);
					break;
				case "StaffEventRoleTest":
					this.StaffEventRoleTest.Add((StaffEventRoleTestEntity)relatedEntity);
					break;
				case "StandardFindingTestReading":
					this.StandardFindingTestReading.Add((StandardFindingTestReadingEntity)relatedEntity);
					break;
				case "TestDependencyRule":
					this.TestDependencyRule.Add((TestDependencyRuleEntity)relatedEntity);
					break;
				case "TestDependencyRule_":
					this.TestDependencyRule_.Add((TestDependencyRuleEntity)relatedEntity);
					break;
				case "TestHcpcsCode":
					this.TestHcpcsCode.Add((TestHcpcsCodeEntity)relatedEntity);
					break;
				case "TestIncidentalFinding":
					this.TestIncidentalFinding.Add((TestIncidentalFindingEntity)relatedEntity);
					break;
				case "TestReading":
					this.TestReading.Add((TestReadingEntity)relatedEntity);
					break;
				case "TestSourceCodeDiscount":
					this.TestSourceCodeDiscount.Add((TestSourceCodeDiscountEntity)relatedEntity);
					break;
				case "TestUnableScreenReason":
					this.TestUnableScreenReason.Add((TestUnableScreenReasonEntity)relatedEntity);
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
				case "HafTemplate":
					DesetupSyncHafTemplate(false, true);
					break;
				case "Lookup__":
					DesetupSyncLookup__(false, true);
					break;
				case "Lookup_":
					DesetupSyncLookup_(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "PreQualificationTestTemplate_":
					DesetupSyncPreQualificationTestTemplate_(false, true);
					break;
				case "AccountCustomerResultTestDependency":
					base.PerformRelatedEntityRemoval(this.AccountCustomerResultTestDependency, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AccountHealthPlanResultTestDependency":
					base.PerformRelatedEntityRemoval(this.AccountHealthPlanResultTestDependency, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AccountNotReviewableTest":
					base.PerformRelatedEntityRemoval(this.AccountNotReviewableTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AccountPcpResultTestDependency":
					base.PerformRelatedEntityRemoval(this.AccountPcpResultTestDependency, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AccountTest":
					base.PerformRelatedEntityRemoval(this.AccountTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "BillingAccountTest":
					base.PerformRelatedEntityRemoval(this.BillingAccountTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ClinicalTestQualificationCriteria":
					base.PerformRelatedEntityRemoval(this.ClinicalTestQualificationCriteria, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerEventScreeningTests":
					base.PerformRelatedEntityRemoval(this.CustomerEventScreeningTests, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerEventTestFinding":
					base.PerformRelatedEntityRemoval(this.CustomerEventTestFinding, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerHealthQuestionGroup":
					base.PerformRelatedEntityRemoval(this.CustomerHealthQuestionGroup, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "DependentDisqualifiedTest":
					base.PerformRelatedEntityRemoval(this.DependentDisqualifiedTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "DisqualifiedTest":
					base.PerformRelatedEntityRemoval(this.DisqualifiedTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerPreApprovedPackageTest":
					base.PerformRelatedEntityRemoval(this.EventCustomerPreApprovedPackageTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerPreApprovedTest":
					base.PerformRelatedEntityRemoval(this.EventCustomerPreApprovedTest, relatedEntity, signalRelatedEntityManyToOne);
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
				case "EventPhysicianTest":
					base.PerformRelatedEntityRemoval(this.EventPhysicianTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventPodRoomTest":
					base.PerformRelatedEntityRemoval(this.EventPodRoomTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventTest":
					base.PerformRelatedEntityRemoval(this.EventTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HealthPlanRevenueItem":
					base.PerformRelatedEntityRemoval(this.HealthPlanRevenueItem, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "InventoryItemTest":
					base.PerformRelatedEntityRemoval(this.InventoryItemTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "KynLabValues":
					base.PerformRelatedEntityRemoval(this.KynLabValues, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PackageTest":
					base.PerformRelatedEntityRemoval(this.PackageTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PhysicianPermittedTest":
					base.PerformRelatedEntityRemoval(this.PhysicianPermittedTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PodRoomTest":
					base.PerformRelatedEntityRemoval(this.PodRoomTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PodTest":
					base.PerformRelatedEntityRemoval(this.PodTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PreApprovedTest":
					base.PerformRelatedEntityRemoval(this.PreApprovedTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PreQualificationQuestion":
					base.PerformRelatedEntityRemoval(this.PreQualificationQuestion, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PreQualificationTemplateDependentTest":
					base.PerformRelatedEntityRemoval(this.PreQualificationTemplateDependentTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PreQualificationTestTemplate":
					base.PerformRelatedEntityRemoval(this.PreQualificationTestTemplate, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ProspectActivity":
					base.PerformRelatedEntityRemoval(this.ProspectActivity, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "RequiredTest":
					base.PerformRelatedEntityRemoval(this.RequiredTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ResultArchiveUploadLog":
					base.PerformRelatedEntityRemoval(this.ResultArchiveUploadLog, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "StaffEventRoleTest":
					base.PerformRelatedEntityRemoval(this.StaffEventRoleTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "StandardFindingTestReading":
					base.PerformRelatedEntityRemoval(this.StandardFindingTestReading, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "TestDependencyRule":
					base.PerformRelatedEntityRemoval(this.TestDependencyRule, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "TestDependencyRule_":
					base.PerformRelatedEntityRemoval(this.TestDependencyRule_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "TestHcpcsCode":
					base.PerformRelatedEntityRemoval(this.TestHcpcsCode, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "TestIncidentalFinding":
					base.PerformRelatedEntityRemoval(this.TestIncidentalFinding, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "TestReading":
					base.PerformRelatedEntityRemoval(this.TestReading, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "TestSourceCodeDiscount":
					base.PerformRelatedEntityRemoval(this.TestSourceCodeDiscount, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "TestUnableScreenReason":
					base.PerformRelatedEntityRemoval(this.TestUnableScreenReason, relatedEntity, signalRelatedEntityManyToOne);
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

			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			if(_hafTemplate!=null)
			{
				toReturn.Add(_hafTemplate);
			}
			if(_lookup__!=null)
			{
				toReturn.Add(_lookup__);
			}
			if(_lookup_!=null)
			{
				toReturn.Add(_lookup_);
			}
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
			}
			if(_preQualificationTestTemplate_!=null)
			{
				toReturn.Add(_preQualificationTestTemplate_);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.AccountCustomerResultTestDependency);
			toReturn.Add(this.AccountHealthPlanResultTestDependency);
			toReturn.Add(this.AccountNotReviewableTest);
			toReturn.Add(this.AccountPcpResultTestDependency);
			toReturn.Add(this.AccountTest);
			toReturn.Add(this.BillingAccountTest);
			toReturn.Add(this.ClinicalTestQualificationCriteria);
			toReturn.Add(this.CustomerEventScreeningTests);
			toReturn.Add(this.CustomerEventTestFinding);
			toReturn.Add(this.CustomerHealthQuestionGroup);
			toReturn.Add(this.DependentDisqualifiedTest);
			toReturn.Add(this.DisqualifiedTest);
			toReturn.Add(this.EventCustomerPreApprovedPackageTest);
			toReturn.Add(this.EventCustomerPreApprovedTest);
			toReturn.Add(this.EventCustomerRequiredTest);
			toReturn.Add(this.EventCustomerRetest);
			toReturn.Add(this.EventCustomerTestNotPerformedNotification);
			toReturn.Add(this.EventPhysicianTest);
			toReturn.Add(this.EventPodRoomTest);
			toReturn.Add(this.EventTest);
			toReturn.Add(this.HealthPlanRevenueItem);
			toReturn.Add(this.InventoryItemTest);
			toReturn.Add(this.KynLabValues);
			toReturn.Add(this.PackageTest);
			toReturn.Add(this.PhysicianPermittedTest);
			toReturn.Add(this.PodRoomTest);
			toReturn.Add(this.PodTest);
			toReturn.Add(this.PreApprovedTest);
			toReturn.Add(this.PreQualificationQuestion);
			toReturn.Add(this.PreQualificationTemplateDependentTest);
			toReturn.Add(this.PreQualificationTestTemplate);
			toReturn.Add(this.ProspectActivity);
			toReturn.Add(this.RequiredTest);
			toReturn.Add(this.ResultArchiveUploadLog);
			toReturn.Add(this.StaffEventRoleTest);
			toReturn.Add(this.StandardFindingTestReading);
			toReturn.Add(this.TestDependencyRule);
			toReturn.Add(this.TestDependencyRule_);
			toReturn.Add(this.TestHcpcsCode);
			toReturn.Add(this.TestIncidentalFinding);
			toReturn.Add(this.TestReading);
			toReturn.Add(this.TestSourceCodeDiscount);
			toReturn.Add(this.TestUnableScreenReason);

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
				info.AddValue("_accountCustomerResultTestDependency", ((_accountCustomerResultTestDependency!=null) && (_accountCustomerResultTestDependency.Count>0) && !this.MarkedForDeletion)?_accountCustomerResultTestDependency:null);
				info.AddValue("_accountHealthPlanResultTestDependency", ((_accountHealthPlanResultTestDependency!=null) && (_accountHealthPlanResultTestDependency.Count>0) && !this.MarkedForDeletion)?_accountHealthPlanResultTestDependency:null);
				info.AddValue("_accountNotReviewableTest", ((_accountNotReviewableTest!=null) && (_accountNotReviewableTest.Count>0) && !this.MarkedForDeletion)?_accountNotReviewableTest:null);
				info.AddValue("_accountPcpResultTestDependency", ((_accountPcpResultTestDependency!=null) && (_accountPcpResultTestDependency.Count>0) && !this.MarkedForDeletion)?_accountPcpResultTestDependency:null);
				info.AddValue("_accountTest", ((_accountTest!=null) && (_accountTest.Count>0) && !this.MarkedForDeletion)?_accountTest:null);
				info.AddValue("_billingAccountTest", ((_billingAccountTest!=null) && (_billingAccountTest.Count>0) && !this.MarkedForDeletion)?_billingAccountTest:null);
				info.AddValue("_clinicalTestQualificationCriteria", ((_clinicalTestQualificationCriteria!=null) && (_clinicalTestQualificationCriteria.Count>0) && !this.MarkedForDeletion)?_clinicalTestQualificationCriteria:null);
				info.AddValue("_customerEventScreeningTests", ((_customerEventScreeningTests!=null) && (_customerEventScreeningTests.Count>0) && !this.MarkedForDeletion)?_customerEventScreeningTests:null);
				info.AddValue("_customerEventTestFinding", ((_customerEventTestFinding!=null) && (_customerEventTestFinding.Count>0) && !this.MarkedForDeletion)?_customerEventTestFinding:null);
				info.AddValue("_customerHealthQuestionGroup", ((_customerHealthQuestionGroup!=null) && (_customerHealthQuestionGroup.Count>0) && !this.MarkedForDeletion)?_customerHealthQuestionGroup:null);
				info.AddValue("_dependentDisqualifiedTest", ((_dependentDisqualifiedTest!=null) && (_dependentDisqualifiedTest.Count>0) && !this.MarkedForDeletion)?_dependentDisqualifiedTest:null);
				info.AddValue("_disqualifiedTest", ((_disqualifiedTest!=null) && (_disqualifiedTest.Count>0) && !this.MarkedForDeletion)?_disqualifiedTest:null);
				info.AddValue("_eventCustomerPreApprovedPackageTest", ((_eventCustomerPreApprovedPackageTest!=null) && (_eventCustomerPreApprovedPackageTest.Count>0) && !this.MarkedForDeletion)?_eventCustomerPreApprovedPackageTest:null);
				info.AddValue("_eventCustomerPreApprovedTest", ((_eventCustomerPreApprovedTest!=null) && (_eventCustomerPreApprovedTest.Count>0) && !this.MarkedForDeletion)?_eventCustomerPreApprovedTest:null);
				info.AddValue("_eventCustomerRequiredTest", ((_eventCustomerRequiredTest!=null) && (_eventCustomerRequiredTest.Count>0) && !this.MarkedForDeletion)?_eventCustomerRequiredTest:null);
				info.AddValue("_eventCustomerRetest", ((_eventCustomerRetest!=null) && (_eventCustomerRetest.Count>0) && !this.MarkedForDeletion)?_eventCustomerRetest:null);
				info.AddValue("_eventCustomerTestNotPerformedNotification", ((_eventCustomerTestNotPerformedNotification!=null) && (_eventCustomerTestNotPerformedNotification.Count>0) && !this.MarkedForDeletion)?_eventCustomerTestNotPerformedNotification:null);
				info.AddValue("_eventPhysicianTest", ((_eventPhysicianTest!=null) && (_eventPhysicianTest.Count>0) && !this.MarkedForDeletion)?_eventPhysicianTest:null);
				info.AddValue("_eventPodRoomTest", ((_eventPodRoomTest!=null) && (_eventPodRoomTest.Count>0) && !this.MarkedForDeletion)?_eventPodRoomTest:null);
				info.AddValue("_eventTest", ((_eventTest!=null) && (_eventTest.Count>0) && !this.MarkedForDeletion)?_eventTest:null);
				info.AddValue("_healthPlanRevenueItem", ((_healthPlanRevenueItem!=null) && (_healthPlanRevenueItem.Count>0) && !this.MarkedForDeletion)?_healthPlanRevenueItem:null);
				info.AddValue("_inventoryItemTest", ((_inventoryItemTest!=null) && (_inventoryItemTest.Count>0) && !this.MarkedForDeletion)?_inventoryItemTest:null);
				info.AddValue("_kynLabValues", ((_kynLabValues!=null) && (_kynLabValues.Count>0) && !this.MarkedForDeletion)?_kynLabValues:null);
				info.AddValue("_packageTest", ((_packageTest!=null) && (_packageTest.Count>0) && !this.MarkedForDeletion)?_packageTest:null);
				info.AddValue("_physicianPermittedTest", ((_physicianPermittedTest!=null) && (_physicianPermittedTest.Count>0) && !this.MarkedForDeletion)?_physicianPermittedTest:null);
				info.AddValue("_podRoomTest", ((_podRoomTest!=null) && (_podRoomTest.Count>0) && !this.MarkedForDeletion)?_podRoomTest:null);
				info.AddValue("_podTest", ((_podTest!=null) && (_podTest.Count>0) && !this.MarkedForDeletion)?_podTest:null);
				info.AddValue("_preApprovedTest", ((_preApprovedTest!=null) && (_preApprovedTest.Count>0) && !this.MarkedForDeletion)?_preApprovedTest:null);
				info.AddValue("_preQualificationQuestion", ((_preQualificationQuestion!=null) && (_preQualificationQuestion.Count>0) && !this.MarkedForDeletion)?_preQualificationQuestion:null);
				info.AddValue("_preQualificationTemplateDependentTest", ((_preQualificationTemplateDependentTest!=null) && (_preQualificationTemplateDependentTest.Count>0) && !this.MarkedForDeletion)?_preQualificationTemplateDependentTest:null);
				info.AddValue("_preQualificationTestTemplate", ((_preQualificationTestTemplate!=null) && (_preQualificationTestTemplate.Count>0) && !this.MarkedForDeletion)?_preQualificationTestTemplate:null);
				info.AddValue("_prospectActivity", ((_prospectActivity!=null) && (_prospectActivity.Count>0) && !this.MarkedForDeletion)?_prospectActivity:null);
				info.AddValue("_requiredTest", ((_requiredTest!=null) && (_requiredTest.Count>0) && !this.MarkedForDeletion)?_requiredTest:null);
				info.AddValue("_resultArchiveUploadLog", ((_resultArchiveUploadLog!=null) && (_resultArchiveUploadLog.Count>0) && !this.MarkedForDeletion)?_resultArchiveUploadLog:null);
				info.AddValue("_staffEventRoleTest", ((_staffEventRoleTest!=null) && (_staffEventRoleTest.Count>0) && !this.MarkedForDeletion)?_staffEventRoleTest:null);
				info.AddValue("_standardFindingTestReading", ((_standardFindingTestReading!=null) && (_standardFindingTestReading.Count>0) && !this.MarkedForDeletion)?_standardFindingTestReading:null);
				info.AddValue("_testDependencyRule", ((_testDependencyRule!=null) && (_testDependencyRule.Count>0) && !this.MarkedForDeletion)?_testDependencyRule:null);
				info.AddValue("_testDependencyRule_", ((_testDependencyRule_!=null) && (_testDependencyRule_.Count>0) && !this.MarkedForDeletion)?_testDependencyRule_:null);
				info.AddValue("_testHcpcsCode", ((_testHcpcsCode!=null) && (_testHcpcsCode.Count>0) && !this.MarkedForDeletion)?_testHcpcsCode:null);
				info.AddValue("_testIncidentalFinding", ((_testIncidentalFinding!=null) && (_testIncidentalFinding.Count>0) && !this.MarkedForDeletion)?_testIncidentalFinding:null);
				info.AddValue("_testReading", ((_testReading!=null) && (_testReading.Count>0) && !this.MarkedForDeletion)?_testReading:null);
				info.AddValue("_testSourceCodeDiscount", ((_testSourceCodeDiscount!=null) && (_testSourceCodeDiscount.Count>0) && !this.MarkedForDeletion)?_testSourceCodeDiscount:null);
				info.AddValue("_testUnableScreenReason", ((_testUnableScreenReason!=null) && (_testUnableScreenReason.Count>0) && !this.MarkedForDeletion)?_testUnableScreenReason:null);
				info.AddValue("_accountCollectionViaAccountPcpResultTestDependency", ((_accountCollectionViaAccountPcpResultTestDependency!=null) && (_accountCollectionViaAccountPcpResultTestDependency.Count>0) && !this.MarkedForDeletion)?_accountCollectionViaAccountPcpResultTestDependency:null);
				info.AddValue("_accountCollectionViaAccountTest", ((_accountCollectionViaAccountTest!=null) && (_accountCollectionViaAccountTest.Count>0) && !this.MarkedForDeletion)?_accountCollectionViaAccountTest:null);
				info.AddValue("_accountCollectionViaAccountNotReviewableTest", ((_accountCollectionViaAccountNotReviewableTest!=null) && (_accountCollectionViaAccountNotReviewableTest.Count>0) && !this.MarkedForDeletion)?_accountCollectionViaAccountNotReviewableTest:null);
				info.AddValue("_accountCollectionViaAccountCustomerResultTestDependency", ((_accountCollectionViaAccountCustomerResultTestDependency!=null) && (_accountCollectionViaAccountCustomerResultTestDependency.Count>0) && !this.MarkedForDeletion)?_accountCollectionViaAccountCustomerResultTestDependency:null);
				info.AddValue("_accountCollectionViaAccountHealthPlanResultTestDependency", ((_accountCollectionViaAccountHealthPlanResultTestDependency!=null) && (_accountCollectionViaAccountHealthPlanResultTestDependency.Count>0) && !this.MarkedForDeletion)?_accountCollectionViaAccountHealthPlanResultTestDependency:null);
				info.AddValue("_billingAccountCollectionViaBillingAccountTest", ((_billingAccountCollectionViaBillingAccountTest!=null) && (_billingAccountCollectionViaBillingAccountTest.Count>0) && !this.MarkedForDeletion)?_billingAccountCollectionViaBillingAccountTest:null);
				info.AddValue("_couponsCollectionViaTestSourceCodeDiscount", ((_couponsCollectionViaTestSourceCodeDiscount!=null) && (_couponsCollectionViaTestSourceCodeDiscount.Count>0) && !this.MarkedForDeletion)?_couponsCollectionViaTestSourceCodeDiscount:null);
				info.AddValue("_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_", ((_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_!=null) && (_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_.Count>0) && !this.MarkedForDeletion)?_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_:null);
				info.AddValue("_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria", ((_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria!=null) && (_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria.Count>0) && !this.MarkedForDeletion)?_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria:null);
				info.AddValue("_customerProfileCollectionViaDependentDisqualifiedTest", ((_customerProfileCollectionViaDependentDisqualifiedTest!=null) && (_customerProfileCollectionViaDependentDisqualifiedTest.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaDependentDisqualifiedTest:null);
				info.AddValue("_customerProfileCollectionViaCustomerEventTestFinding", ((_customerProfileCollectionViaCustomerEventTestFinding!=null) && (_customerProfileCollectionViaCustomerEventTestFinding.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerEventTestFinding:null);
				info.AddValue("_customerProfileCollectionViaDisqualifiedTest", ((_customerProfileCollectionViaDisqualifiedTest!=null) && (_customerProfileCollectionViaDisqualifiedTest.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaDisqualifiedTest:null);
				info.AddValue("_customerProfileCollectionViaResultArchiveUploadLog", ((_customerProfileCollectionViaResultArchiveUploadLog!=null) && (_customerProfileCollectionViaResultArchiveUploadLog.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaResultArchiveUploadLog:null);
				info.AddValue("_customerProfileCollectionViaRequiredTest", ((_customerProfileCollectionViaRequiredTest!=null) && (_customerProfileCollectionViaRequiredTest.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaRequiredTest:null);
				info.AddValue("_eventCustomerResultCollectionViaKynLabValues", ((_eventCustomerResultCollectionViaKynLabValues!=null) && (_eventCustomerResultCollectionViaKynLabValues.Count>0) && !this.MarkedForDeletion)?_eventCustomerResultCollectionViaKynLabValues:null);
				info.AddValue("_eventCustomerResultCollectionViaCustomerEventScreeningTests", ((_eventCustomerResultCollectionViaCustomerEventScreeningTests!=null) && (_eventCustomerResultCollectionViaCustomerEventScreeningTests.Count>0) && !this.MarkedForDeletion)?_eventCustomerResultCollectionViaCustomerEventScreeningTests:null);
				info.AddValue("_eventCustomersCollectionViaDisqualifiedTest", ((_eventCustomersCollectionViaDisqualifiedTest!=null) && (_eventCustomersCollectionViaDisqualifiedTest.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaDisqualifiedTest:null);
				info.AddValue("_eventCustomersCollectionViaEventCustomerPreApprovedTest", ((_eventCustomersCollectionViaEventCustomerPreApprovedTest!=null) && (_eventCustomersCollectionViaEventCustomerPreApprovedTest.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaEventCustomerPreApprovedTest:null);
				info.AddValue("_eventCustomersCollectionViaEventCustomerPreApprovedPackageTest", ((_eventCustomersCollectionViaEventCustomerPreApprovedPackageTest!=null) && (_eventCustomersCollectionViaEventCustomerPreApprovedPackageTest.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaEventCustomerPreApprovedPackageTest:null);
				info.AddValue("_eventCustomersCollectionViaEventCustomerRequiredTest", ((_eventCustomersCollectionViaEventCustomerRequiredTest!=null) && (_eventCustomersCollectionViaEventCustomerRequiredTest.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaEventCustomerRequiredTest:null);
				info.AddValue("_eventCustomersCollectionViaEventCustomerTestNotPerformedNotification", ((_eventCustomersCollectionViaEventCustomerTestNotPerformedNotification!=null) && (_eventCustomersCollectionViaEventCustomerTestNotPerformedNotification.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaEventCustomerTestNotPerformedNotification:null);
				info.AddValue("_eventCustomersCollectionViaDependentDisqualifiedTest", ((_eventCustomersCollectionViaDependentDisqualifiedTest!=null) && (_eventCustomersCollectionViaDependentDisqualifiedTest.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaDependentDisqualifiedTest:null);
				info.AddValue("_eventCustomersCollectionViaEventCustomerRetest", ((_eventCustomersCollectionViaEventCustomerRetest!=null) && (_eventCustomersCollectionViaEventCustomerRetest.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaEventCustomerRetest:null);
				info.AddValue("_eventPodRoomCollectionViaEventPodRoomTest", ((_eventPodRoomCollectionViaEventPodRoomTest!=null) && (_eventPodRoomCollectionViaEventPodRoomTest.Count>0) && !this.MarkedForDeletion)?_eventPodRoomCollectionViaEventPodRoomTest:null);
				info.AddValue("_eventsCollectionViaDependentDisqualifiedTest", ((_eventsCollectionViaDependentDisqualifiedTest!=null) && (_eventsCollectionViaDependentDisqualifiedTest.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaDependentDisqualifiedTest:null);
				info.AddValue("_eventsCollectionViaDisqualifiedTest", ((_eventsCollectionViaDisqualifiedTest!=null) && (_eventsCollectionViaDisqualifiedTest.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaDisqualifiedTest:null);
				info.AddValue("_eventsCollectionViaEventPhysicianTest", ((_eventsCollectionViaEventPhysicianTest!=null) && (_eventsCollectionViaEventPhysicianTest.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventPhysicianTest:null);
				info.AddValue("_eventsCollectionViaEventTest", ((_eventsCollectionViaEventTest!=null) && (_eventsCollectionViaEventTest.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventTest:null);
				info.AddValue("_eventsCollectionViaCustomerEventTestFinding", ((_eventsCollectionViaCustomerEventTestFinding!=null) && (_eventsCollectionViaCustomerEventTestFinding.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaCustomerEventTestFinding:null);
				info.AddValue("_hafTemplateCollectionViaClinicalTestQualificationCriteria", ((_hafTemplateCollectionViaClinicalTestQualificationCriteria!=null) && (_hafTemplateCollectionViaClinicalTestQualificationCriteria.Count>0) && !this.MarkedForDeletion)?_hafTemplateCollectionViaClinicalTestQualificationCriteria:null);
				info.AddValue("_hafTemplateCollectionViaEventTest", ((_hafTemplateCollectionViaEventTest!=null) && (_hafTemplateCollectionViaEventTest.Count>0) && !this.MarkedForDeletion)?_hafTemplateCollectionViaEventTest:null);
				info.AddValue("_hcpcsCodeCollectionViaTestHcpcsCode", ((_hcpcsCodeCollectionViaTestHcpcsCode!=null) && (_hcpcsCodeCollectionViaTestHcpcsCode.Count>0) && !this.MarkedForDeletion)?_hcpcsCodeCollectionViaTestHcpcsCode:null);
				info.AddValue("_healthPlanRevenueCollectionViaHealthPlanRevenueItem", ((_healthPlanRevenueCollectionViaHealthPlanRevenueItem!=null) && (_healthPlanRevenueCollectionViaHealthPlanRevenueItem.Count>0) && !this.MarkedForDeletion)?_healthPlanRevenueCollectionViaHealthPlanRevenueItem:null);
				info.AddValue("_incidentalFindingsCollectionViaTestIncidentalFinding", ((_incidentalFindingsCollectionViaTestIncidentalFinding!=null) && (_incidentalFindingsCollectionViaTestIncidentalFinding.Count>0) && !this.MarkedForDeletion)?_incidentalFindingsCollectionViaTestIncidentalFinding:null);
				info.AddValue("_inventoryItemCollectionViaInventoryItemTest", ((_inventoryItemCollectionViaInventoryItemTest!=null) && (_inventoryItemCollectionViaInventoryItemTest.Count>0) && !this.MarkedForDeletion)?_inventoryItemCollectionViaInventoryItemTest:null);
				info.AddValue("_lookupCollectionViaTestUnableScreenReason", ((_lookupCollectionViaTestUnableScreenReason!=null) && (_lookupCollectionViaTestUnableScreenReason.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaTestUnableScreenReason:null);
				info.AddValue("_lookupCollectionViaEventTest_", ((_lookupCollectionViaEventTest_!=null) && (_lookupCollectionViaEventTest_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventTest_:null);
				info.AddValue("_lookupCollectionViaEventTest", ((_lookupCollectionViaEventTest!=null) && (_lookupCollectionViaEventTest.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventTest:null);
				info.AddValue("_lookupCollectionViaEventTest__", ((_lookupCollectionViaEventTest__!=null) && (_lookupCollectionViaEventTest__.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventTest__:null);
				info.AddValue("_lookupCollectionViaClinicalTestQualificationCriteria", ((_lookupCollectionViaClinicalTestQualificationCriteria!=null) && (_lookupCollectionViaClinicalTestQualificationCriteria.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaClinicalTestQualificationCriteria:null);
				info.AddValue("_lookupCollectionViaPreQualificationQuestion", ((_lookupCollectionViaPreQualificationQuestion!=null) && (_lookupCollectionViaPreQualificationQuestion.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaPreQualificationQuestion:null);
				info.AddValue("_lookupCollectionViaClinicalTestQualificationCriteria_", ((_lookupCollectionViaClinicalTestQualificationCriteria_!=null) && (_lookupCollectionViaClinicalTestQualificationCriteria_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaClinicalTestQualificationCriteria_:null);
				info.AddValue("_lookupCollectionViaKynLabValues", ((_lookupCollectionViaKynLabValues!=null) && (_lookupCollectionViaKynLabValues.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaKynLabValues:null);
				info.AddValue("_notificationTypeCollectionViaEventCustomerTestNotPerformedNotification", ((_notificationTypeCollectionViaEventCustomerTestNotPerformedNotification!=null) && (_notificationTypeCollectionViaEventCustomerTestNotPerformedNotification.Count>0) && !this.MarkedForDeletion)?_notificationTypeCollectionViaEventCustomerTestNotPerformedNotification:null);
				info.AddValue("_orderItemCollectionViaProspectActivity", ((_orderItemCollectionViaProspectActivity!=null) && (_orderItemCollectionViaProspectActivity.Count>0) && !this.MarkedForDeletion)?_orderItemCollectionViaProspectActivity:null);
				info.AddValue("_organizationRoleUserCollectionViaPreQualificationQuestion", ((_organizationRoleUserCollectionViaPreQualificationQuestion!=null) && (_organizationRoleUserCollectionViaPreQualificationQuestion.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaPreQualificationQuestion:null);
				info.AddValue("_organizationRoleUserCollectionViaPreApprovedTest", ((_organizationRoleUserCollectionViaPreApprovedTest!=null) && (_organizationRoleUserCollectionViaPreApprovedTest.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaPreApprovedTest:null);
				info.AddValue("_organizationRoleUserCollectionViaTestHcpcsCode", ((_organizationRoleUserCollectionViaTestHcpcsCode!=null) && (_organizationRoleUserCollectionViaTestHcpcsCode.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaTestHcpcsCode:null);
				info.AddValue("_organizationRoleUserCollectionViaTestHcpcsCode_", ((_organizationRoleUserCollectionViaTestHcpcsCode_!=null) && (_organizationRoleUserCollectionViaTestHcpcsCode_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaTestHcpcsCode_:null);
				info.AddValue("_organizationRoleUserCollectionViaRequiredTest", ((_organizationRoleUserCollectionViaRequiredTest!=null) && (_organizationRoleUserCollectionViaRequiredTest.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaRequiredTest:null);
				info.AddValue("_organizationRoleUserCollectionViaPreQualificationTestTemplate", ((_organizationRoleUserCollectionViaPreQualificationTestTemplate!=null) && (_organizationRoleUserCollectionViaPreQualificationTestTemplate.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaPreQualificationTestTemplate:null);
				info.AddValue("_organizationRoleUserCollectionViaPreQualificationTestTemplate_", ((_organizationRoleUserCollectionViaPreQualificationTestTemplate_!=null) && (_organizationRoleUserCollectionViaPreQualificationTestTemplate_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaPreQualificationTestTemplate_:null);
				info.AddValue("_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification", ((_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification!=null) && (_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification:null);
				info.AddValue("_organizationRoleUserCollectionViaEventCustomerRetest", ((_organizationRoleUserCollectionViaEventCustomerRetest!=null) && (_organizationRoleUserCollectionViaEventCustomerRetest.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventCustomerRetest:null);
				info.AddValue("_organizationRoleUserCollectionViaClinicalTestQualificationCriteria", ((_organizationRoleUserCollectionViaClinicalTestQualificationCriteria!=null) && (_organizationRoleUserCollectionViaClinicalTestQualificationCriteria.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaClinicalTestQualificationCriteria:null);
				info.AddValue("_organizationRoleUserCollectionViaEventPhysicianTest__", ((_organizationRoleUserCollectionViaEventPhysicianTest__!=null) && (_organizationRoleUserCollectionViaEventPhysicianTest__.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventPhysicianTest__:null);
				info.AddValue("_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_", ((_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_!=null) && (_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_:null);
				info.AddValue("_organizationRoleUserCollectionViaEventPhysicianTest", ((_organizationRoleUserCollectionViaEventPhysicianTest!=null) && (_organizationRoleUserCollectionViaEventPhysicianTest.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventPhysicianTest:null);
				info.AddValue("_organizationRoleUserCollectionViaDisqualifiedTest_", ((_organizationRoleUserCollectionViaDisqualifiedTest_!=null) && (_organizationRoleUserCollectionViaDisqualifiedTest_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaDisqualifiedTest_:null);
				info.AddValue("_organizationRoleUserCollectionViaEventPhysicianTest_", ((_organizationRoleUserCollectionViaEventPhysicianTest_!=null) && (_organizationRoleUserCollectionViaEventPhysicianTest_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventPhysicianTest_:null);
				info.AddValue("_organizationRoleUserCollectionViaDisqualifiedTest", ((_organizationRoleUserCollectionViaDisqualifiedTest!=null) && (_organizationRoleUserCollectionViaDisqualifiedTest.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaDisqualifiedTest:null);
				info.AddValue("_organizationRoleUserCollectionViaKynLabValues", ((_organizationRoleUserCollectionViaKynLabValues!=null) && (_organizationRoleUserCollectionViaKynLabValues.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaKynLabValues:null);
				info.AddValue("_organizationRoleUserCollectionViaKynLabValues_", ((_organizationRoleUserCollectionViaKynLabValues_!=null) && (_organizationRoleUserCollectionViaKynLabValues_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaKynLabValues_:null);
				info.AddValue("_packageCollectionViaEventCustomerPreApprovedPackageTest", ((_packageCollectionViaEventCustomerPreApprovedPackageTest!=null) && (_packageCollectionViaEventCustomerPreApprovedPackageTest.Count>0) && !this.MarkedForDeletion)?_packageCollectionViaEventCustomerPreApprovedPackageTest:null);
				info.AddValue("_packageCollectionViaPackageTest", ((_packageCollectionViaPackageTest!=null) && (_packageCollectionViaPackageTest.Count>0) && !this.MarkedForDeletion)?_packageCollectionViaPackageTest:null);
				info.AddValue("_packageCollectionViaHealthPlanRevenueItem", ((_packageCollectionViaHealthPlanRevenueItem!=null) && (_packageCollectionViaHealthPlanRevenueItem.Count>0) && !this.MarkedForDeletion)?_packageCollectionViaHealthPlanRevenueItem:null);
				info.AddValue("_physicianProfileCollectionViaPhysicianPermittedTest", ((_physicianProfileCollectionViaPhysicianPermittedTest!=null) && (_physicianProfileCollectionViaPhysicianPermittedTest.Count>0) && !this.MarkedForDeletion)?_physicianProfileCollectionViaPhysicianPermittedTest:null);
				info.AddValue("_podDetailsCollectionViaPodTest", ((_podDetailsCollectionViaPodTest!=null) && (_podDetailsCollectionViaPodTest.Count>0) && !this.MarkedForDeletion)?_podDetailsCollectionViaPodTest:null);
				info.AddValue("_podRoomCollectionViaPodRoomTest", ((_podRoomCollectionViaPodRoomTest!=null) && (_podRoomCollectionViaPodRoomTest.Count>0) && !this.MarkedForDeletion)?_podRoomCollectionViaPodRoomTest:null);
				info.AddValue("_preQualificationQuestionCollectionViaDisqualifiedTest", ((_preQualificationQuestionCollectionViaDisqualifiedTest!=null) && (_preQualificationQuestionCollectionViaDisqualifiedTest.Count>0) && !this.MarkedForDeletion)?_preQualificationQuestionCollectionViaDisqualifiedTest:null);
				info.AddValue("_preQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest", ((_preQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest!=null) && (_preQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest.Count>0) && !this.MarkedForDeletion)?_preQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest:null);
				info.AddValue("_preQualificationTestTemplateCollectionViaEventTest", ((_preQualificationTestTemplateCollectionViaEventTest!=null) && (_preQualificationTestTemplateCollectionViaEventTest.Count>0) && !this.MarkedForDeletion)?_preQualificationTestTemplateCollectionViaEventTest:null);
				info.AddValue("_readingCollectionViaTestReading", ((_readingCollectionViaTestReading!=null) && (_readingCollectionViaTestReading.Count>0) && !this.MarkedForDeletion)?_readingCollectionViaTestReading:null);
				info.AddValue("_readingCollectionViaStandardFindingTestReading", ((_readingCollectionViaStandardFindingTestReading!=null) && (_readingCollectionViaStandardFindingTestReading.Count>0) && !this.MarkedForDeletion)?_readingCollectionViaStandardFindingTestReading:null);
				info.AddValue("_resultArchiveUploadCollectionViaResultArchiveUploadLog", ((_resultArchiveUploadCollectionViaResultArchiveUploadLog!=null) && (_resultArchiveUploadCollectionViaResultArchiveUploadLog.Count>0) && !this.MarkedForDeletion)?_resultArchiveUploadCollectionViaResultArchiveUploadLog:null);
				info.AddValue("_staffEventRoleCollectionViaStaffEventRoleTest", ((_staffEventRoleCollectionViaStaffEventRoleTest!=null) && (_staffEventRoleCollectionViaStaffEventRoleTest.Count>0) && !this.MarkedForDeletion)?_staffEventRoleCollectionViaStaffEventRoleTest:null);
				info.AddValue("_standardFindingCollectionViaStandardFindingTestReading", ((_standardFindingCollectionViaStandardFindingTestReading!=null) && (_standardFindingCollectionViaStandardFindingTestReading.Count>0) && !this.MarkedForDeletion)?_standardFindingCollectionViaStandardFindingTestReading:null);
				info.AddValue("_hafTemplate", (!this.MarkedForDeletion?_hafTemplate:null));
				info.AddValue("_lookup__", (!this.MarkedForDeletion?_lookup__:null));
				info.AddValue("_lookup_", (!this.MarkedForDeletion?_lookup_:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_preQualificationTestTemplate_", (!this.MarkedForDeletion?_preQualificationTestTemplate_:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(TestFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(TestFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new TestRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccountCustomerResultTestDependency' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCustomerResultTestDependency()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountCustomerResultTestDependencyFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccountHealthPlanResultTestDependency' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountHealthPlanResultTestDependency()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountHealthPlanResultTestDependencyFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccountNotReviewableTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountNotReviewableTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountNotReviewableTestFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccountPcpResultTestDependency' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountPcpResultTestDependency()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountPcpResultTestDependencyFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccountTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountTestFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BillingAccountTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBillingAccountTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BillingAccountTestFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ClinicalTestQualificationCriteria' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoClinicalTestQualificationCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ClinicalTestQualificationCriteriaFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerEventScreeningTests' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventScreeningTests()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventScreeningTestsFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerEventTestFinding' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventTestFinding()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventTestFindingFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerHealthQuestionGroup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerHealthQuestionGroup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionGroupFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DependentDisqualifiedTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDependentDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DependentDisqualifiedTestFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DisqualifiedTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DisqualifiedTestFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerPreApprovedPackageTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerPreApprovedPackageTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerPreApprovedPackageTestFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerPreApprovedTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerPreApprovedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerPreApprovedTestFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerRequiredTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerRequiredTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerRequiredTestFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerRetest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerRetest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerRetestFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerTestNotPerformedNotification' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerTestNotPerformedNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerTestNotPerformedNotificationFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventPhysicianTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventPhysicianTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPhysicianTestFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventPodRoomTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventPodRoomTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPodRoomTestFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventTestFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthPlanRevenueItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthPlanRevenueItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanRevenueItemFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'InventoryItemTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoInventoryItemTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(InventoryItemTestFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'KynLabValues' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoKynLabValues()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(KynLabValuesFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PackageTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPackageTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PackageTestFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianPermittedTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianPermittedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PhysicianPermittedTestFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodRoomTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodRoomTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodRoomTestFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodTestFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PreApprovedTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPreApprovedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreApprovedTestFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PreQualificationQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPreQualificationQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationQuestionFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PreQualificationTemplateDependentTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPreQualificationTemplateDependentTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationTemplateDependentTestFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PreQualificationTestTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPreQualificationTestTemplate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationTestTemplateFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectActivity' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectActivity()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectActivityFields.ActivityId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'RequiredTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRequiredTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RequiredTestFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ResultArchiveUploadLog' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoResultArchiveUploadLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ResultArchiveUploadLogFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'StaffEventRoleTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoStaffEventRoleTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StaffEventRoleTestFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'StandardFindingTestReading' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoStandardFindingTestReading()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StandardFindingTestReadingFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TestDependencyRule' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestDependencyRule()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestDependencyRuleFields.DependantTestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TestDependencyRule' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestDependencyRule_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestDependencyRuleFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TestHcpcsCode' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestHcpcsCode()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestHcpcsCodeFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TestIncidentalFinding' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestIncidentalFinding()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestIncidentalFindingFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TestReading' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestReading()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestReadingFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TestSourceCodeDiscount' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestSourceCodeDiscount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestSourceCodeDiscountFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TestUnableScreenReason' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestUnableScreenReason()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestUnableScreenReasonFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCollectionViaAccountPcpResultTestDependency()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AccountCollectionViaAccountPcpResultTestDependency"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCollectionViaAccountTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AccountCollectionViaAccountTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCollectionViaAccountNotReviewableTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AccountCollectionViaAccountNotReviewableTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCollectionViaAccountCustomerResultTestDependency()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AccountCollectionViaAccountCustomerResultTestDependency"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCollectionViaAccountHealthPlanResultTestDependency()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AccountCollectionViaAccountHealthPlanResultTestDependency"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BillingAccount' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBillingAccountCollectionViaBillingAccountTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("BillingAccountCollectionViaBillingAccountTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Coupons' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCouponsCollectionViaTestSourceCodeDiscount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CouponsCollectionViaTestSourceCodeDiscount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerHealthQuestions' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerHealthQuestions' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaDependentDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaDependentDisqualifiedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerEventTestFinding()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerEventTestFinding"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaDisqualifiedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaResultArchiveUploadLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaResultArchiveUploadLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaRequiredTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaRequiredTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerResult' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerResultCollectionViaKynLabValues()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomerResultCollectionViaKynLabValues"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerResult' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerResultCollectionViaCustomerEventScreeningTests()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomerResultCollectionViaCustomerEventScreeningTests"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaDisqualifiedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaEventCustomerPreApprovedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaEventCustomerPreApprovedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaEventCustomerPreApprovedPackageTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaEventCustomerPreApprovedPackageTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaEventCustomerRequiredTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaEventCustomerRequiredTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaEventCustomerTestNotPerformedNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaEventCustomerTestNotPerformedNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaDependentDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaDependentDisqualifiedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaEventCustomerRetest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaEventCustomerRetest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventPodRoom' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventPodRoomCollectionViaEventPodRoomTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventPodRoomCollectionViaEventPodRoomTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaDependentDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaDependentDisqualifiedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaDisqualifiedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventPhysicianTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventPhysicianTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaCustomerEventTestFinding()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaCustomerEventTestFinding"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HafTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplateCollectionViaClinicalTestQualificationCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HafTemplateCollectionViaClinicalTestQualificationCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HafTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplateCollectionViaEventTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HafTemplateCollectionViaEventTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HcpcsCode' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHcpcsCodeCollectionViaTestHcpcsCode()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HcpcsCodeCollectionViaTestHcpcsCode"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthPlanRevenue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthPlanRevenueCollectionViaHealthPlanRevenueItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HealthPlanRevenueCollectionViaHealthPlanRevenueItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'IncidentalFindings' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoIncidentalFindingsCollectionViaTestIncidentalFinding()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("IncidentalFindingsCollectionViaTestIncidentalFinding"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'InventoryItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoInventoryItemCollectionViaInventoryItemTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("InventoryItemCollectionViaInventoryItemTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaTestUnableScreenReason()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaTestUnableScreenReason"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventTest_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventTest_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventTest__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventTest__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaClinicalTestQualificationCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaClinicalTestQualificationCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaPreQualificationQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaPreQualificationQuestion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaClinicalTestQualificationCriteria_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaClinicalTestQualificationCriteria_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaKynLabValues()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaKynLabValues"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'NotificationType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotificationTypeCollectionViaEventCustomerTestNotPerformedNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("NotificationTypeCollectionViaEventCustomerTestNotPerformedNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrderItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrderItemCollectionViaProspectActivity()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrderItemCollectionViaProspectActivity"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaPreQualificationQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaPreQualificationQuestion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaPreApprovedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaPreApprovedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaTestHcpcsCode()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaTestHcpcsCode"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaTestHcpcsCode_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaTestHcpcsCode_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaRequiredTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaRequiredTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaPreQualificationTestTemplate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaPreQualificationTestTemplate"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaPreQualificationTestTemplate_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaPreQualificationTestTemplate_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventCustomerRetest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventCustomerRetest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaClinicalTestQualificationCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventPhysicianTest__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventPhysicianTest__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventPhysicianTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventPhysicianTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaDisqualifiedTest_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaDisqualifiedTest_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventPhysicianTest_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventPhysicianTest_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaDisqualifiedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaKynLabValues()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaKynLabValues"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaKynLabValues_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaKynLabValues_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Package' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPackageCollectionViaEventCustomerPreApprovedPackageTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PackageCollectionViaEventCustomerPreApprovedPackageTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Package' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPackageCollectionViaPackageTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PackageCollectionViaPackageTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Package' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPackageCollectionViaHealthPlanRevenueItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PackageCollectionViaHealthPlanRevenueItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianProfileCollectionViaPhysicianPermittedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PhysicianProfileCollectionViaPhysicianPermittedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodDetailsCollectionViaPodTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PodDetailsCollectionViaPodTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodRoom' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodRoomCollectionViaPodRoomTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PodRoomCollectionViaPodRoomTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PreQualificationQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPreQualificationQuestionCollectionViaDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PreQualificationQuestionCollectionViaDisqualifiedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PreQualificationTestTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPreQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PreQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PreQualificationTestTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPreQualificationTestTemplateCollectionViaEventTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PreQualificationTestTemplateCollectionViaEventTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Reading' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoReadingCollectionViaTestReading()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ReadingCollectionViaTestReading"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Reading' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoReadingCollectionViaStandardFindingTestReading()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ReadingCollectionViaStandardFindingTestReading"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ResultArchiveUpload' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoResultArchiveUploadCollectionViaResultArchiveUploadLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ResultArchiveUploadCollectionViaResultArchiveUploadLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'StaffEventRole' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoStaffEventRoleCollectionViaStaffEventRoleTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("StaffEventRoleCollectionViaStaffEventRoleTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'StandardFinding' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoStandardFindingCollectionViaStandardFindingTestReading()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("StandardFindingCollectionViaStandardFindingTestReading"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId, "TestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'HafTemplate' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HafTemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.ResultEntryTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.GroupId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.Gender));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'PreQualificationTestTemplate' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPreQualificationTestTemplate_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationTestTemplateFields.Id, null, ComparisonOperator.Equal, this.PreQualificationQuestionTemplateId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.TestEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._accountCustomerResultTestDependency);
			collectionsQueue.Enqueue(this._accountHealthPlanResultTestDependency);
			collectionsQueue.Enqueue(this._accountNotReviewableTest);
			collectionsQueue.Enqueue(this._accountPcpResultTestDependency);
			collectionsQueue.Enqueue(this._accountTest);
			collectionsQueue.Enqueue(this._billingAccountTest);
			collectionsQueue.Enqueue(this._clinicalTestQualificationCriteria);
			collectionsQueue.Enqueue(this._customerEventScreeningTests);
			collectionsQueue.Enqueue(this._customerEventTestFinding);
			collectionsQueue.Enqueue(this._customerHealthQuestionGroup);
			collectionsQueue.Enqueue(this._dependentDisqualifiedTest);
			collectionsQueue.Enqueue(this._disqualifiedTest);
			collectionsQueue.Enqueue(this._eventCustomerPreApprovedPackageTest);
			collectionsQueue.Enqueue(this._eventCustomerPreApprovedTest);
			collectionsQueue.Enqueue(this._eventCustomerRequiredTest);
			collectionsQueue.Enqueue(this._eventCustomerRetest);
			collectionsQueue.Enqueue(this._eventCustomerTestNotPerformedNotification);
			collectionsQueue.Enqueue(this._eventPhysicianTest);
			collectionsQueue.Enqueue(this._eventPodRoomTest);
			collectionsQueue.Enqueue(this._eventTest);
			collectionsQueue.Enqueue(this._healthPlanRevenueItem);
			collectionsQueue.Enqueue(this._inventoryItemTest);
			collectionsQueue.Enqueue(this._kynLabValues);
			collectionsQueue.Enqueue(this._packageTest);
			collectionsQueue.Enqueue(this._physicianPermittedTest);
			collectionsQueue.Enqueue(this._podRoomTest);
			collectionsQueue.Enqueue(this._podTest);
			collectionsQueue.Enqueue(this._preApprovedTest);
			collectionsQueue.Enqueue(this._preQualificationQuestion);
			collectionsQueue.Enqueue(this._preQualificationTemplateDependentTest);
			collectionsQueue.Enqueue(this._preQualificationTestTemplate);
			collectionsQueue.Enqueue(this._prospectActivity);
			collectionsQueue.Enqueue(this._requiredTest);
			collectionsQueue.Enqueue(this._resultArchiveUploadLog);
			collectionsQueue.Enqueue(this._staffEventRoleTest);
			collectionsQueue.Enqueue(this._standardFindingTestReading);
			collectionsQueue.Enqueue(this._testDependencyRule);
			collectionsQueue.Enqueue(this._testDependencyRule_);
			collectionsQueue.Enqueue(this._testHcpcsCode);
			collectionsQueue.Enqueue(this._testIncidentalFinding);
			collectionsQueue.Enqueue(this._testReading);
			collectionsQueue.Enqueue(this._testSourceCodeDiscount);
			collectionsQueue.Enqueue(this._testUnableScreenReason);
			collectionsQueue.Enqueue(this._accountCollectionViaAccountPcpResultTestDependency);
			collectionsQueue.Enqueue(this._accountCollectionViaAccountTest);
			collectionsQueue.Enqueue(this._accountCollectionViaAccountNotReviewableTest);
			collectionsQueue.Enqueue(this._accountCollectionViaAccountCustomerResultTestDependency);
			collectionsQueue.Enqueue(this._accountCollectionViaAccountHealthPlanResultTestDependency);
			collectionsQueue.Enqueue(this._billingAccountCollectionViaBillingAccountTest);
			collectionsQueue.Enqueue(this._couponsCollectionViaTestSourceCodeDiscount);
			collectionsQueue.Enqueue(this._customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_);
			collectionsQueue.Enqueue(this._customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaDependentDisqualifiedTest);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerEventTestFinding);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaDisqualifiedTest);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaResultArchiveUploadLog);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaRequiredTest);
			collectionsQueue.Enqueue(this._eventCustomerResultCollectionViaKynLabValues);
			collectionsQueue.Enqueue(this._eventCustomerResultCollectionViaCustomerEventScreeningTests);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaDisqualifiedTest);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaEventCustomerPreApprovedTest);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaEventCustomerPreApprovedPackageTest);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaEventCustomerRequiredTest);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaEventCustomerTestNotPerformedNotification);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaDependentDisqualifiedTest);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaEventCustomerRetest);
			collectionsQueue.Enqueue(this._eventPodRoomCollectionViaEventPodRoomTest);
			collectionsQueue.Enqueue(this._eventsCollectionViaDependentDisqualifiedTest);
			collectionsQueue.Enqueue(this._eventsCollectionViaDisqualifiedTest);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventPhysicianTest);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventTest);
			collectionsQueue.Enqueue(this._eventsCollectionViaCustomerEventTestFinding);
			collectionsQueue.Enqueue(this._hafTemplateCollectionViaClinicalTestQualificationCriteria);
			collectionsQueue.Enqueue(this._hafTemplateCollectionViaEventTest);
			collectionsQueue.Enqueue(this._hcpcsCodeCollectionViaTestHcpcsCode);
			collectionsQueue.Enqueue(this._healthPlanRevenueCollectionViaHealthPlanRevenueItem);
			collectionsQueue.Enqueue(this._incidentalFindingsCollectionViaTestIncidentalFinding);
			collectionsQueue.Enqueue(this._inventoryItemCollectionViaInventoryItemTest);
			collectionsQueue.Enqueue(this._lookupCollectionViaTestUnableScreenReason);
			collectionsQueue.Enqueue(this._lookupCollectionViaEventTest_);
			collectionsQueue.Enqueue(this._lookupCollectionViaEventTest);
			collectionsQueue.Enqueue(this._lookupCollectionViaEventTest__);
			collectionsQueue.Enqueue(this._lookupCollectionViaClinicalTestQualificationCriteria);
			collectionsQueue.Enqueue(this._lookupCollectionViaPreQualificationQuestion);
			collectionsQueue.Enqueue(this._lookupCollectionViaClinicalTestQualificationCriteria_);
			collectionsQueue.Enqueue(this._lookupCollectionViaKynLabValues);
			collectionsQueue.Enqueue(this._notificationTypeCollectionViaEventCustomerTestNotPerformedNotification);
			collectionsQueue.Enqueue(this._orderItemCollectionViaProspectActivity);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaPreQualificationQuestion);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaPreApprovedTest);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaTestHcpcsCode);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaTestHcpcsCode_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaRequiredTest);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaPreQualificationTestTemplate);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaPreQualificationTestTemplate_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventCustomerRetest);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaClinicalTestQualificationCriteria);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventPhysicianTest__);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaClinicalTestQualificationCriteria_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventPhysicianTest);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaDisqualifiedTest_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventPhysicianTest_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaDisqualifiedTest);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaKynLabValues);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaKynLabValues_);
			collectionsQueue.Enqueue(this._packageCollectionViaEventCustomerPreApprovedPackageTest);
			collectionsQueue.Enqueue(this._packageCollectionViaPackageTest);
			collectionsQueue.Enqueue(this._packageCollectionViaHealthPlanRevenueItem);
			collectionsQueue.Enqueue(this._physicianProfileCollectionViaPhysicianPermittedTest);
			collectionsQueue.Enqueue(this._podDetailsCollectionViaPodTest);
			collectionsQueue.Enqueue(this._podRoomCollectionViaPodRoomTest);
			collectionsQueue.Enqueue(this._preQualificationQuestionCollectionViaDisqualifiedTest);
			collectionsQueue.Enqueue(this._preQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest);
			collectionsQueue.Enqueue(this._preQualificationTestTemplateCollectionViaEventTest);
			collectionsQueue.Enqueue(this._readingCollectionViaTestReading);
			collectionsQueue.Enqueue(this._readingCollectionViaStandardFindingTestReading);
			collectionsQueue.Enqueue(this._resultArchiveUploadCollectionViaResultArchiveUploadLog);
			collectionsQueue.Enqueue(this._staffEventRoleCollectionViaStaffEventRoleTest);
			collectionsQueue.Enqueue(this._standardFindingCollectionViaStandardFindingTestReading);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._accountCustomerResultTestDependency = (EntityCollection<AccountCustomerResultTestDependencyEntity>) collectionsQueue.Dequeue();
			this._accountHealthPlanResultTestDependency = (EntityCollection<AccountHealthPlanResultTestDependencyEntity>) collectionsQueue.Dequeue();
			this._accountNotReviewableTest = (EntityCollection<AccountNotReviewableTestEntity>) collectionsQueue.Dequeue();
			this._accountPcpResultTestDependency = (EntityCollection<AccountPcpResultTestDependencyEntity>) collectionsQueue.Dequeue();
			this._accountTest = (EntityCollection<AccountTestEntity>) collectionsQueue.Dequeue();
			this._billingAccountTest = (EntityCollection<BillingAccountTestEntity>) collectionsQueue.Dequeue();
			this._clinicalTestQualificationCriteria = (EntityCollection<ClinicalTestQualificationCriteriaEntity>) collectionsQueue.Dequeue();
			this._customerEventScreeningTests = (EntityCollection<CustomerEventScreeningTestsEntity>) collectionsQueue.Dequeue();
			this._customerEventTestFinding = (EntityCollection<CustomerEventTestFindingEntity>) collectionsQueue.Dequeue();
			this._customerHealthQuestionGroup = (EntityCollection<CustomerHealthQuestionGroupEntity>) collectionsQueue.Dequeue();
			this._dependentDisqualifiedTest = (EntityCollection<DependentDisqualifiedTestEntity>) collectionsQueue.Dequeue();
			this._disqualifiedTest = (EntityCollection<DisqualifiedTestEntity>) collectionsQueue.Dequeue();
			this._eventCustomerPreApprovedPackageTest = (EntityCollection<EventCustomerPreApprovedPackageTestEntity>) collectionsQueue.Dequeue();
			this._eventCustomerPreApprovedTest = (EntityCollection<EventCustomerPreApprovedTestEntity>) collectionsQueue.Dequeue();
			this._eventCustomerRequiredTest = (EntityCollection<EventCustomerRequiredTestEntity>) collectionsQueue.Dequeue();
			this._eventCustomerRetest = (EntityCollection<EventCustomerRetestEntity>) collectionsQueue.Dequeue();
			this._eventCustomerTestNotPerformedNotification = (EntityCollection<EventCustomerTestNotPerformedNotificationEntity>) collectionsQueue.Dequeue();
			this._eventPhysicianTest = (EntityCollection<EventPhysicianTestEntity>) collectionsQueue.Dequeue();
			this._eventPodRoomTest = (EntityCollection<EventPodRoomTestEntity>) collectionsQueue.Dequeue();
			this._eventTest = (EntityCollection<EventTestEntity>) collectionsQueue.Dequeue();
			this._healthPlanRevenueItem = (EntityCollection<HealthPlanRevenueItemEntity>) collectionsQueue.Dequeue();
			this._inventoryItemTest = (EntityCollection<InventoryItemTestEntity>) collectionsQueue.Dequeue();
			this._kynLabValues = (EntityCollection<KynLabValuesEntity>) collectionsQueue.Dequeue();
			this._packageTest = (EntityCollection<PackageTestEntity>) collectionsQueue.Dequeue();
			this._physicianPermittedTest = (EntityCollection<PhysicianPermittedTestEntity>) collectionsQueue.Dequeue();
			this._podRoomTest = (EntityCollection<PodRoomTestEntity>) collectionsQueue.Dequeue();
			this._podTest = (EntityCollection<PodTestEntity>) collectionsQueue.Dequeue();
			this._preApprovedTest = (EntityCollection<PreApprovedTestEntity>) collectionsQueue.Dequeue();
			this._preQualificationQuestion = (EntityCollection<PreQualificationQuestionEntity>) collectionsQueue.Dequeue();
			this._preQualificationTemplateDependentTest = (EntityCollection<PreQualificationTemplateDependentTestEntity>) collectionsQueue.Dequeue();
			this._preQualificationTestTemplate = (EntityCollection<PreQualificationTestTemplateEntity>) collectionsQueue.Dequeue();
			this._prospectActivity = (EntityCollection<ProspectActivityEntity>) collectionsQueue.Dequeue();
			this._requiredTest = (EntityCollection<RequiredTestEntity>) collectionsQueue.Dequeue();
			this._resultArchiveUploadLog = (EntityCollection<ResultArchiveUploadLogEntity>) collectionsQueue.Dequeue();
			this._staffEventRoleTest = (EntityCollection<StaffEventRoleTestEntity>) collectionsQueue.Dequeue();
			this._standardFindingTestReading = (EntityCollection<StandardFindingTestReadingEntity>) collectionsQueue.Dequeue();
			this._testDependencyRule = (EntityCollection<TestDependencyRuleEntity>) collectionsQueue.Dequeue();
			this._testDependencyRule_ = (EntityCollection<TestDependencyRuleEntity>) collectionsQueue.Dequeue();
			this._testHcpcsCode = (EntityCollection<TestHcpcsCodeEntity>) collectionsQueue.Dequeue();
			this._testIncidentalFinding = (EntityCollection<TestIncidentalFindingEntity>) collectionsQueue.Dequeue();
			this._testReading = (EntityCollection<TestReadingEntity>) collectionsQueue.Dequeue();
			this._testSourceCodeDiscount = (EntityCollection<TestSourceCodeDiscountEntity>) collectionsQueue.Dequeue();
			this._testUnableScreenReason = (EntityCollection<TestUnableScreenReasonEntity>) collectionsQueue.Dequeue();
			this._accountCollectionViaAccountPcpResultTestDependency = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._accountCollectionViaAccountTest = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._accountCollectionViaAccountNotReviewableTest = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._accountCollectionViaAccountCustomerResultTestDependency = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._accountCollectionViaAccountHealthPlanResultTestDependency = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._billingAccountCollectionViaBillingAccountTest = (EntityCollection<BillingAccountEntity>) collectionsQueue.Dequeue();
			this._couponsCollectionViaTestSourceCodeDiscount = (EntityCollection<CouponsEntity>) collectionsQueue.Dequeue();
			this._customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_ = (EntityCollection<CustomerHealthQuestionsEntity>) collectionsQueue.Dequeue();
			this._customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria = (EntityCollection<CustomerHealthQuestionsEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaDependentDisqualifiedTest = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerEventTestFinding = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaDisqualifiedTest = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaResultArchiveUploadLog = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaRequiredTest = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._eventCustomerResultCollectionViaKynLabValues = (EntityCollection<EventCustomerResultEntity>) collectionsQueue.Dequeue();
			this._eventCustomerResultCollectionViaCustomerEventScreeningTests = (EntityCollection<EventCustomerResultEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaDisqualifiedTest = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaEventCustomerPreApprovedTest = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaEventCustomerPreApprovedPackageTest = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaEventCustomerRequiredTest = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaEventCustomerTestNotPerformedNotification = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaDependentDisqualifiedTest = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaEventCustomerRetest = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventPodRoomCollectionViaEventPodRoomTest = (EntityCollection<EventPodRoomEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaDependentDisqualifiedTest = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaDisqualifiedTest = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventPhysicianTest = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventTest = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaCustomerEventTestFinding = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._hafTemplateCollectionViaClinicalTestQualificationCriteria = (EntityCollection<HafTemplateEntity>) collectionsQueue.Dequeue();
			this._hafTemplateCollectionViaEventTest = (EntityCollection<HafTemplateEntity>) collectionsQueue.Dequeue();
			this._hcpcsCodeCollectionViaTestHcpcsCode = (EntityCollection<HcpcsCodeEntity>) collectionsQueue.Dequeue();
			this._healthPlanRevenueCollectionViaHealthPlanRevenueItem = (EntityCollection<HealthPlanRevenueEntity>) collectionsQueue.Dequeue();
			this._incidentalFindingsCollectionViaTestIncidentalFinding = (EntityCollection<IncidentalFindingsEntity>) collectionsQueue.Dequeue();
			this._inventoryItemCollectionViaInventoryItemTest = (EntityCollection<InventoryItemEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaTestUnableScreenReason = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEventTest_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEventTest = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEventTest__ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaClinicalTestQualificationCriteria = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaPreQualificationQuestion = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaClinicalTestQualificationCriteria_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaKynLabValues = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._notificationTypeCollectionViaEventCustomerTestNotPerformedNotification = (EntityCollection<NotificationTypeEntity>) collectionsQueue.Dequeue();
			this._orderItemCollectionViaProspectActivity = (EntityCollection<OrderItemEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaPreQualificationQuestion = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaPreApprovedTest = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaTestHcpcsCode = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaTestHcpcsCode_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaRequiredTest = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaPreQualificationTestTemplate = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaPreQualificationTestTemplate_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventCustomerRetest = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaClinicalTestQualificationCriteria = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventPhysicianTest__ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaClinicalTestQualificationCriteria_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventPhysicianTest = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaDisqualifiedTest_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventPhysicianTest_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaDisqualifiedTest = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaKynLabValues = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaKynLabValues_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._packageCollectionViaEventCustomerPreApprovedPackageTest = (EntityCollection<PackageEntity>) collectionsQueue.Dequeue();
			this._packageCollectionViaPackageTest = (EntityCollection<PackageEntity>) collectionsQueue.Dequeue();
			this._packageCollectionViaHealthPlanRevenueItem = (EntityCollection<PackageEntity>) collectionsQueue.Dequeue();
			this._physicianProfileCollectionViaPhysicianPermittedTest = (EntityCollection<PhysicianProfileEntity>) collectionsQueue.Dequeue();
			this._podDetailsCollectionViaPodTest = (EntityCollection<PodDetailsEntity>) collectionsQueue.Dequeue();
			this._podRoomCollectionViaPodRoomTest = (EntityCollection<PodRoomEntity>) collectionsQueue.Dequeue();
			this._preQualificationQuestionCollectionViaDisqualifiedTest = (EntityCollection<PreQualificationQuestionEntity>) collectionsQueue.Dequeue();
			this._preQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest = (EntityCollection<PreQualificationTestTemplateEntity>) collectionsQueue.Dequeue();
			this._preQualificationTestTemplateCollectionViaEventTest = (EntityCollection<PreQualificationTestTemplateEntity>) collectionsQueue.Dequeue();
			this._readingCollectionViaTestReading = (EntityCollection<ReadingEntity>) collectionsQueue.Dequeue();
			this._readingCollectionViaStandardFindingTestReading = (EntityCollection<ReadingEntity>) collectionsQueue.Dequeue();
			this._resultArchiveUploadCollectionViaResultArchiveUploadLog = (EntityCollection<ResultArchiveUploadEntity>) collectionsQueue.Dequeue();
			this._staffEventRoleCollectionViaStaffEventRoleTest = (EntityCollection<StaffEventRoleEntity>) collectionsQueue.Dequeue();
			this._standardFindingCollectionViaStandardFindingTestReading = (EntityCollection<StandardFindingEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._accountCustomerResultTestDependency != null)
			{
				return true;
			}
			if (this._accountHealthPlanResultTestDependency != null)
			{
				return true;
			}
			if (this._accountNotReviewableTest != null)
			{
				return true;
			}
			if (this._accountPcpResultTestDependency != null)
			{
				return true;
			}
			if (this._accountTest != null)
			{
				return true;
			}
			if (this._billingAccountTest != null)
			{
				return true;
			}
			if (this._clinicalTestQualificationCriteria != null)
			{
				return true;
			}
			if (this._customerEventScreeningTests != null)
			{
				return true;
			}
			if (this._customerEventTestFinding != null)
			{
				return true;
			}
			if (this._customerHealthQuestionGroup != null)
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
			if (this._eventCustomerPreApprovedPackageTest != null)
			{
				return true;
			}
			if (this._eventCustomerPreApprovedTest != null)
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
			if (this._eventPhysicianTest != null)
			{
				return true;
			}
			if (this._eventPodRoomTest != null)
			{
				return true;
			}
			if (this._eventTest != null)
			{
				return true;
			}
			if (this._healthPlanRevenueItem != null)
			{
				return true;
			}
			if (this._inventoryItemTest != null)
			{
				return true;
			}
			if (this._kynLabValues != null)
			{
				return true;
			}
			if (this._packageTest != null)
			{
				return true;
			}
			if (this._physicianPermittedTest != null)
			{
				return true;
			}
			if (this._podRoomTest != null)
			{
				return true;
			}
			if (this._podTest != null)
			{
				return true;
			}
			if (this._preApprovedTest != null)
			{
				return true;
			}
			if (this._preQualificationQuestion != null)
			{
				return true;
			}
			if (this._preQualificationTemplateDependentTest != null)
			{
				return true;
			}
			if (this._preQualificationTestTemplate != null)
			{
				return true;
			}
			if (this._prospectActivity != null)
			{
				return true;
			}
			if (this._requiredTest != null)
			{
				return true;
			}
			if (this._resultArchiveUploadLog != null)
			{
				return true;
			}
			if (this._staffEventRoleTest != null)
			{
				return true;
			}
			if (this._standardFindingTestReading != null)
			{
				return true;
			}
			if (this._testDependencyRule != null)
			{
				return true;
			}
			if (this._testDependencyRule_ != null)
			{
				return true;
			}
			if (this._testHcpcsCode != null)
			{
				return true;
			}
			if (this._testIncidentalFinding != null)
			{
				return true;
			}
			if (this._testReading != null)
			{
				return true;
			}
			if (this._testSourceCodeDiscount != null)
			{
				return true;
			}
			if (this._testUnableScreenReason != null)
			{
				return true;
			}
			if (this._accountCollectionViaAccountPcpResultTestDependency != null)
			{
				return true;
			}
			if (this._accountCollectionViaAccountTest != null)
			{
				return true;
			}
			if (this._accountCollectionViaAccountNotReviewableTest != null)
			{
				return true;
			}
			if (this._accountCollectionViaAccountCustomerResultTestDependency != null)
			{
				return true;
			}
			if (this._accountCollectionViaAccountHealthPlanResultTestDependency != null)
			{
				return true;
			}
			if (this._billingAccountCollectionViaBillingAccountTest != null)
			{
				return true;
			}
			if (this._couponsCollectionViaTestSourceCodeDiscount != null)
			{
				return true;
			}
			if (this._customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_ != null)
			{
				return true;
			}
			if (this._customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaDependentDisqualifiedTest != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerEventTestFinding != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaDisqualifiedTest != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaResultArchiveUploadLog != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaRequiredTest != null)
			{
				return true;
			}
			if (this._eventCustomerResultCollectionViaKynLabValues != null)
			{
				return true;
			}
			if (this._eventCustomerResultCollectionViaCustomerEventScreeningTests != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaDisqualifiedTest != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaEventCustomerPreApprovedTest != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaEventCustomerPreApprovedPackageTest != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaEventCustomerRequiredTest != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaEventCustomerTestNotPerformedNotification != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaDependentDisqualifiedTest != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaEventCustomerRetest != null)
			{
				return true;
			}
			if (this._eventPodRoomCollectionViaEventPodRoomTest != null)
			{
				return true;
			}
			if (this._eventsCollectionViaDependentDisqualifiedTest != null)
			{
				return true;
			}
			if (this._eventsCollectionViaDisqualifiedTest != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventPhysicianTest != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventTest != null)
			{
				return true;
			}
			if (this._eventsCollectionViaCustomerEventTestFinding != null)
			{
				return true;
			}
			if (this._hafTemplateCollectionViaClinicalTestQualificationCriteria != null)
			{
				return true;
			}
			if (this._hafTemplateCollectionViaEventTest != null)
			{
				return true;
			}
			if (this._hcpcsCodeCollectionViaTestHcpcsCode != null)
			{
				return true;
			}
			if (this._healthPlanRevenueCollectionViaHealthPlanRevenueItem != null)
			{
				return true;
			}
			if (this._incidentalFindingsCollectionViaTestIncidentalFinding != null)
			{
				return true;
			}
			if (this._inventoryItemCollectionViaInventoryItemTest != null)
			{
				return true;
			}
			if (this._lookupCollectionViaTestUnableScreenReason != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEventTest_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEventTest != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEventTest__ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaClinicalTestQualificationCriteria != null)
			{
				return true;
			}
			if (this._lookupCollectionViaPreQualificationQuestion != null)
			{
				return true;
			}
			if (this._lookupCollectionViaClinicalTestQualificationCriteria_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaKynLabValues != null)
			{
				return true;
			}
			if (this._notificationTypeCollectionViaEventCustomerTestNotPerformedNotification != null)
			{
				return true;
			}
			if (this._orderItemCollectionViaProspectActivity != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaPreQualificationQuestion != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaPreApprovedTest != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaTestHcpcsCode != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaTestHcpcsCode_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaRequiredTest != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaPreQualificationTestTemplate != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaPreQualificationTestTemplate_ != null)
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
			if (this._organizationRoleUserCollectionViaClinicalTestQualificationCriteria != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventPhysicianTest__ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaClinicalTestQualificationCriteria_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventPhysicianTest != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaDisqualifiedTest_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventPhysicianTest_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaDisqualifiedTest != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaKynLabValues != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaKynLabValues_ != null)
			{
				return true;
			}
			if (this._packageCollectionViaEventCustomerPreApprovedPackageTest != null)
			{
				return true;
			}
			if (this._packageCollectionViaPackageTest != null)
			{
				return true;
			}
			if (this._packageCollectionViaHealthPlanRevenueItem != null)
			{
				return true;
			}
			if (this._physicianProfileCollectionViaPhysicianPermittedTest != null)
			{
				return true;
			}
			if (this._podDetailsCollectionViaPodTest != null)
			{
				return true;
			}
			if (this._podRoomCollectionViaPodRoomTest != null)
			{
				return true;
			}
			if (this._preQualificationQuestionCollectionViaDisqualifiedTest != null)
			{
				return true;
			}
			if (this._preQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest != null)
			{
				return true;
			}
			if (this._preQualificationTestTemplateCollectionViaEventTest != null)
			{
				return true;
			}
			if (this._readingCollectionViaTestReading != null)
			{
				return true;
			}
			if (this._readingCollectionViaStandardFindingTestReading != null)
			{
				return true;
			}
			if (this._resultArchiveUploadCollectionViaResultArchiveUploadLog != null)
			{
				return true;
			}
			if (this._staffEventRoleCollectionViaStaffEventRoleTest != null)
			{
				return true;
			}
			if (this._standardFindingCollectionViaStandardFindingTestReading != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountCustomerResultTestDependencyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountCustomerResultTestDependencyEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountHealthPlanResultTestDependencyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountHealthPlanResultTestDependencyEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountNotReviewableTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountNotReviewableTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountPcpResultTestDependencyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountPcpResultTestDependencyEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BillingAccountTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BillingAccountTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ClinicalTestQualificationCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClinicalTestQualificationCriteriaEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerEventScreeningTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventScreeningTestsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerEventTestFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestFindingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerHealthQuestionGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionGroupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DependentDisqualifiedTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DependentDisqualifiedTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DisqualifiedTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DisqualifiedTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerPreApprovedPackageTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerPreApprovedPackageTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerPreApprovedTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerPreApprovedTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerRequiredTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerRequiredTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerRetestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerRetestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerTestNotPerformedNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerTestNotPerformedNotificationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventPhysicianTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPhysicianTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventPodRoomTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPodRoomTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthPlanRevenueItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanRevenueItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<InventoryItemTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InventoryItemTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<KynLabValuesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(KynLabValuesEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PackageTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianPermittedTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianPermittedTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodRoomTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodRoomTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PreApprovedTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreApprovedTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PreQualificationQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PreQualificationTemplateDependentTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTemplateDependentTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PreQualificationTestTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTestTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectActivityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectActivityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RequiredTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RequiredTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ResultArchiveUploadLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ResultArchiveUploadLogEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<StaffEventRoleTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StaffEventRoleTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<StandardFindingTestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StandardFindingTestReadingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestDependencyRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestDependencyRuleEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestDependencyRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestDependencyRuleEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestHcpcsCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestHcpcsCodeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestIncidentalFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestIncidentalFindingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestReadingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestSourceCodeDiscountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestSourceCodeDiscountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestUnableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestUnableScreenReasonEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BillingAccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BillingAccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerResultEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerResultEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerResultEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerResultEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventPodRoomEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPodRoomEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HcpcsCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HcpcsCodeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthPlanRevenueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanRevenueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<IncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<InventoryItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InventoryItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NotificationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderItemEntityFactory))) : null);
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodRoomEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodRoomEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PreQualificationQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PreQualificationTestTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTestTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PreQualificationTestTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTestTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReadingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReadingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ResultArchiveUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ResultArchiveUploadEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<StaffEventRoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StaffEventRoleEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<StandardFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StandardFindingEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("HafTemplate", _hafTemplate);
			toReturn.Add("Lookup__", _lookup__);
			toReturn.Add("Lookup_", _lookup_);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("PreQualificationTestTemplate_", _preQualificationTestTemplate_);
			toReturn.Add("AccountCustomerResultTestDependency", _accountCustomerResultTestDependency);
			toReturn.Add("AccountHealthPlanResultTestDependency", _accountHealthPlanResultTestDependency);
			toReturn.Add("AccountNotReviewableTest", _accountNotReviewableTest);
			toReturn.Add("AccountPcpResultTestDependency", _accountPcpResultTestDependency);
			toReturn.Add("AccountTest", _accountTest);
			toReturn.Add("BillingAccountTest", _billingAccountTest);
			toReturn.Add("ClinicalTestQualificationCriteria", _clinicalTestQualificationCriteria);
			toReturn.Add("CustomerEventScreeningTests", _customerEventScreeningTests);
			toReturn.Add("CustomerEventTestFinding", _customerEventTestFinding);
			toReturn.Add("CustomerHealthQuestionGroup", _customerHealthQuestionGroup);
			toReturn.Add("DependentDisqualifiedTest", _dependentDisqualifiedTest);
			toReturn.Add("DisqualifiedTest", _disqualifiedTest);
			toReturn.Add("EventCustomerPreApprovedPackageTest", _eventCustomerPreApprovedPackageTest);
			toReturn.Add("EventCustomerPreApprovedTest", _eventCustomerPreApprovedTest);
			toReturn.Add("EventCustomerRequiredTest", _eventCustomerRequiredTest);
			toReturn.Add("EventCustomerRetest", _eventCustomerRetest);
			toReturn.Add("EventCustomerTestNotPerformedNotification", _eventCustomerTestNotPerformedNotification);
			toReturn.Add("EventPhysicianTest", _eventPhysicianTest);
			toReturn.Add("EventPodRoomTest", _eventPodRoomTest);
			toReturn.Add("EventTest", _eventTest);
			toReturn.Add("HealthPlanRevenueItem", _healthPlanRevenueItem);
			toReturn.Add("InventoryItemTest", _inventoryItemTest);
			toReturn.Add("KynLabValues", _kynLabValues);
			toReturn.Add("PackageTest", _packageTest);
			toReturn.Add("PhysicianPermittedTest", _physicianPermittedTest);
			toReturn.Add("PodRoomTest", _podRoomTest);
			toReturn.Add("PodTest", _podTest);
			toReturn.Add("PreApprovedTest", _preApprovedTest);
			toReturn.Add("PreQualificationQuestion", _preQualificationQuestion);
			toReturn.Add("PreQualificationTemplateDependentTest", _preQualificationTemplateDependentTest);
			toReturn.Add("PreQualificationTestTemplate", _preQualificationTestTemplate);
			toReturn.Add("ProspectActivity", _prospectActivity);
			toReturn.Add("RequiredTest", _requiredTest);
			toReturn.Add("ResultArchiveUploadLog", _resultArchiveUploadLog);
			toReturn.Add("StaffEventRoleTest", _staffEventRoleTest);
			toReturn.Add("StandardFindingTestReading", _standardFindingTestReading);
			toReturn.Add("TestDependencyRule", _testDependencyRule);
			toReturn.Add("TestDependencyRule_", _testDependencyRule_);
			toReturn.Add("TestHcpcsCode", _testHcpcsCode);
			toReturn.Add("TestIncidentalFinding", _testIncidentalFinding);
			toReturn.Add("TestReading", _testReading);
			toReturn.Add("TestSourceCodeDiscount", _testSourceCodeDiscount);
			toReturn.Add("TestUnableScreenReason", _testUnableScreenReason);
			toReturn.Add("AccountCollectionViaAccountPcpResultTestDependency", _accountCollectionViaAccountPcpResultTestDependency);
			toReturn.Add("AccountCollectionViaAccountTest", _accountCollectionViaAccountTest);
			toReturn.Add("AccountCollectionViaAccountNotReviewableTest", _accountCollectionViaAccountNotReviewableTest);
			toReturn.Add("AccountCollectionViaAccountCustomerResultTestDependency", _accountCollectionViaAccountCustomerResultTestDependency);
			toReturn.Add("AccountCollectionViaAccountHealthPlanResultTestDependency", _accountCollectionViaAccountHealthPlanResultTestDependency);
			toReturn.Add("BillingAccountCollectionViaBillingAccountTest", _billingAccountCollectionViaBillingAccountTest);
			toReturn.Add("CouponsCollectionViaTestSourceCodeDiscount", _couponsCollectionViaTestSourceCodeDiscount);
			toReturn.Add("CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_", _customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_);
			toReturn.Add("CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria", _customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria);
			toReturn.Add("CustomerProfileCollectionViaDependentDisqualifiedTest", _customerProfileCollectionViaDependentDisqualifiedTest);
			toReturn.Add("CustomerProfileCollectionViaCustomerEventTestFinding", _customerProfileCollectionViaCustomerEventTestFinding);
			toReturn.Add("CustomerProfileCollectionViaDisqualifiedTest", _customerProfileCollectionViaDisqualifiedTest);
			toReturn.Add("CustomerProfileCollectionViaResultArchiveUploadLog", _customerProfileCollectionViaResultArchiveUploadLog);
			toReturn.Add("CustomerProfileCollectionViaRequiredTest", _customerProfileCollectionViaRequiredTest);
			toReturn.Add("EventCustomerResultCollectionViaKynLabValues", _eventCustomerResultCollectionViaKynLabValues);
			toReturn.Add("EventCustomerResultCollectionViaCustomerEventScreeningTests", _eventCustomerResultCollectionViaCustomerEventScreeningTests);
			toReturn.Add("EventCustomersCollectionViaDisqualifiedTest", _eventCustomersCollectionViaDisqualifiedTest);
			toReturn.Add("EventCustomersCollectionViaEventCustomerPreApprovedTest", _eventCustomersCollectionViaEventCustomerPreApprovedTest);
			toReturn.Add("EventCustomersCollectionViaEventCustomerPreApprovedPackageTest", _eventCustomersCollectionViaEventCustomerPreApprovedPackageTest);
			toReturn.Add("EventCustomersCollectionViaEventCustomerRequiredTest", _eventCustomersCollectionViaEventCustomerRequiredTest);
			toReturn.Add("EventCustomersCollectionViaEventCustomerTestNotPerformedNotification", _eventCustomersCollectionViaEventCustomerTestNotPerformedNotification);
			toReturn.Add("EventCustomersCollectionViaDependentDisqualifiedTest", _eventCustomersCollectionViaDependentDisqualifiedTest);
			toReturn.Add("EventCustomersCollectionViaEventCustomerRetest", _eventCustomersCollectionViaEventCustomerRetest);
			toReturn.Add("EventPodRoomCollectionViaEventPodRoomTest", _eventPodRoomCollectionViaEventPodRoomTest);
			toReturn.Add("EventsCollectionViaDependentDisqualifiedTest", _eventsCollectionViaDependentDisqualifiedTest);
			toReturn.Add("EventsCollectionViaDisqualifiedTest", _eventsCollectionViaDisqualifiedTest);
			toReturn.Add("EventsCollectionViaEventPhysicianTest", _eventsCollectionViaEventPhysicianTest);
			toReturn.Add("EventsCollectionViaEventTest", _eventsCollectionViaEventTest);
			toReturn.Add("EventsCollectionViaCustomerEventTestFinding", _eventsCollectionViaCustomerEventTestFinding);
			toReturn.Add("HafTemplateCollectionViaClinicalTestQualificationCriteria", _hafTemplateCollectionViaClinicalTestQualificationCriteria);
			toReturn.Add("HafTemplateCollectionViaEventTest", _hafTemplateCollectionViaEventTest);
			toReturn.Add("HcpcsCodeCollectionViaTestHcpcsCode", _hcpcsCodeCollectionViaTestHcpcsCode);
			toReturn.Add("HealthPlanRevenueCollectionViaHealthPlanRevenueItem", _healthPlanRevenueCollectionViaHealthPlanRevenueItem);
			toReturn.Add("IncidentalFindingsCollectionViaTestIncidentalFinding", _incidentalFindingsCollectionViaTestIncidentalFinding);
			toReturn.Add("InventoryItemCollectionViaInventoryItemTest", _inventoryItemCollectionViaInventoryItemTest);
			toReturn.Add("LookupCollectionViaTestUnableScreenReason", _lookupCollectionViaTestUnableScreenReason);
			toReturn.Add("LookupCollectionViaEventTest_", _lookupCollectionViaEventTest_);
			toReturn.Add("LookupCollectionViaEventTest", _lookupCollectionViaEventTest);
			toReturn.Add("LookupCollectionViaEventTest__", _lookupCollectionViaEventTest__);
			toReturn.Add("LookupCollectionViaClinicalTestQualificationCriteria", _lookupCollectionViaClinicalTestQualificationCriteria);
			toReturn.Add("LookupCollectionViaPreQualificationQuestion", _lookupCollectionViaPreQualificationQuestion);
			toReturn.Add("LookupCollectionViaClinicalTestQualificationCriteria_", _lookupCollectionViaClinicalTestQualificationCriteria_);
			toReturn.Add("LookupCollectionViaKynLabValues", _lookupCollectionViaKynLabValues);
			toReturn.Add("NotificationTypeCollectionViaEventCustomerTestNotPerformedNotification", _notificationTypeCollectionViaEventCustomerTestNotPerformedNotification);
			toReturn.Add("OrderItemCollectionViaProspectActivity", _orderItemCollectionViaProspectActivity);
			toReturn.Add("OrganizationRoleUserCollectionViaPreQualificationQuestion", _organizationRoleUserCollectionViaPreQualificationQuestion);
			toReturn.Add("OrganizationRoleUserCollectionViaPreApprovedTest", _organizationRoleUserCollectionViaPreApprovedTest);
			toReturn.Add("OrganizationRoleUserCollectionViaTestHcpcsCode", _organizationRoleUserCollectionViaTestHcpcsCode);
			toReturn.Add("OrganizationRoleUserCollectionViaTestHcpcsCode_", _organizationRoleUserCollectionViaTestHcpcsCode_);
			toReturn.Add("OrganizationRoleUserCollectionViaRequiredTest", _organizationRoleUserCollectionViaRequiredTest);
			toReturn.Add("OrganizationRoleUserCollectionViaPreQualificationTestTemplate", _organizationRoleUserCollectionViaPreQualificationTestTemplate);
			toReturn.Add("OrganizationRoleUserCollectionViaPreQualificationTestTemplate_", _organizationRoleUserCollectionViaPreQualificationTestTemplate_);
			toReturn.Add("OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification", _organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification);
			toReturn.Add("OrganizationRoleUserCollectionViaEventCustomerRetest", _organizationRoleUserCollectionViaEventCustomerRetest);
			toReturn.Add("OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria", _organizationRoleUserCollectionViaClinicalTestQualificationCriteria);
			toReturn.Add("OrganizationRoleUserCollectionViaEventPhysicianTest__", _organizationRoleUserCollectionViaEventPhysicianTest__);
			toReturn.Add("OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_", _organizationRoleUserCollectionViaClinicalTestQualificationCriteria_);
			toReturn.Add("OrganizationRoleUserCollectionViaEventPhysicianTest", _organizationRoleUserCollectionViaEventPhysicianTest);
			toReturn.Add("OrganizationRoleUserCollectionViaDisqualifiedTest_", _organizationRoleUserCollectionViaDisqualifiedTest_);
			toReturn.Add("OrganizationRoleUserCollectionViaEventPhysicianTest_", _organizationRoleUserCollectionViaEventPhysicianTest_);
			toReturn.Add("OrganizationRoleUserCollectionViaDisqualifiedTest", _organizationRoleUserCollectionViaDisqualifiedTest);
			toReturn.Add("OrganizationRoleUserCollectionViaKynLabValues", _organizationRoleUserCollectionViaKynLabValues);
			toReturn.Add("OrganizationRoleUserCollectionViaKynLabValues_", _organizationRoleUserCollectionViaKynLabValues_);
			toReturn.Add("PackageCollectionViaEventCustomerPreApprovedPackageTest", _packageCollectionViaEventCustomerPreApprovedPackageTest);
			toReturn.Add("PackageCollectionViaPackageTest", _packageCollectionViaPackageTest);
			toReturn.Add("PackageCollectionViaHealthPlanRevenueItem", _packageCollectionViaHealthPlanRevenueItem);
			toReturn.Add("PhysicianProfileCollectionViaPhysicianPermittedTest", _physicianProfileCollectionViaPhysicianPermittedTest);
			toReturn.Add("PodDetailsCollectionViaPodTest", _podDetailsCollectionViaPodTest);
			toReturn.Add("PodRoomCollectionViaPodRoomTest", _podRoomCollectionViaPodRoomTest);
			toReturn.Add("PreQualificationQuestionCollectionViaDisqualifiedTest", _preQualificationQuestionCollectionViaDisqualifiedTest);
			toReturn.Add("PreQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest", _preQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest);
			toReturn.Add("PreQualificationTestTemplateCollectionViaEventTest", _preQualificationTestTemplateCollectionViaEventTest);
			toReturn.Add("ReadingCollectionViaTestReading", _readingCollectionViaTestReading);
			toReturn.Add("ReadingCollectionViaStandardFindingTestReading", _readingCollectionViaStandardFindingTestReading);
			toReturn.Add("ResultArchiveUploadCollectionViaResultArchiveUploadLog", _resultArchiveUploadCollectionViaResultArchiveUploadLog);
			toReturn.Add("StaffEventRoleCollectionViaStaffEventRoleTest", _staffEventRoleCollectionViaStaffEventRoleTest);
			toReturn.Add("StandardFindingCollectionViaStandardFindingTestReading", _standardFindingCollectionViaStandardFindingTestReading);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_accountCustomerResultTestDependency!=null)
			{
				_accountCustomerResultTestDependency.ActiveContext = base.ActiveContext;
			}
			if(_accountHealthPlanResultTestDependency!=null)
			{
				_accountHealthPlanResultTestDependency.ActiveContext = base.ActiveContext;
			}
			if(_accountNotReviewableTest!=null)
			{
				_accountNotReviewableTest.ActiveContext = base.ActiveContext;
			}
			if(_accountPcpResultTestDependency!=null)
			{
				_accountPcpResultTestDependency.ActiveContext = base.ActiveContext;
			}
			if(_accountTest!=null)
			{
				_accountTest.ActiveContext = base.ActiveContext;
			}
			if(_billingAccountTest!=null)
			{
				_billingAccountTest.ActiveContext = base.ActiveContext;
			}
			if(_clinicalTestQualificationCriteria!=null)
			{
				_clinicalTestQualificationCriteria.ActiveContext = base.ActiveContext;
			}
			if(_customerEventScreeningTests!=null)
			{
				_customerEventScreeningTests.ActiveContext = base.ActiveContext;
			}
			if(_customerEventTestFinding!=null)
			{
				_customerEventTestFinding.ActiveContext = base.ActiveContext;
			}
			if(_customerHealthQuestionGroup!=null)
			{
				_customerHealthQuestionGroup.ActiveContext = base.ActiveContext;
			}
			if(_dependentDisqualifiedTest!=null)
			{
				_dependentDisqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_disqualifiedTest!=null)
			{
				_disqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerPreApprovedPackageTest!=null)
			{
				_eventCustomerPreApprovedPackageTest.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerPreApprovedTest!=null)
			{
				_eventCustomerPreApprovedTest.ActiveContext = base.ActiveContext;
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
			if(_eventPhysicianTest!=null)
			{
				_eventPhysicianTest.ActiveContext = base.ActiveContext;
			}
			if(_eventPodRoomTest!=null)
			{
				_eventPodRoomTest.ActiveContext = base.ActiveContext;
			}
			if(_eventTest!=null)
			{
				_eventTest.ActiveContext = base.ActiveContext;
			}
			if(_healthPlanRevenueItem!=null)
			{
				_healthPlanRevenueItem.ActiveContext = base.ActiveContext;
			}
			if(_inventoryItemTest!=null)
			{
				_inventoryItemTest.ActiveContext = base.ActiveContext;
			}
			if(_kynLabValues!=null)
			{
				_kynLabValues.ActiveContext = base.ActiveContext;
			}
			if(_packageTest!=null)
			{
				_packageTest.ActiveContext = base.ActiveContext;
			}
			if(_physicianPermittedTest!=null)
			{
				_physicianPermittedTest.ActiveContext = base.ActiveContext;
			}
			if(_podRoomTest!=null)
			{
				_podRoomTest.ActiveContext = base.ActiveContext;
			}
			if(_podTest!=null)
			{
				_podTest.ActiveContext = base.ActiveContext;
			}
			if(_preApprovedTest!=null)
			{
				_preApprovedTest.ActiveContext = base.ActiveContext;
			}
			if(_preQualificationQuestion!=null)
			{
				_preQualificationQuestion.ActiveContext = base.ActiveContext;
			}
			if(_preQualificationTemplateDependentTest!=null)
			{
				_preQualificationTemplateDependentTest.ActiveContext = base.ActiveContext;
			}
			if(_preQualificationTestTemplate!=null)
			{
				_preQualificationTestTemplate.ActiveContext = base.ActiveContext;
			}
			if(_prospectActivity!=null)
			{
				_prospectActivity.ActiveContext = base.ActiveContext;
			}
			if(_requiredTest!=null)
			{
				_requiredTest.ActiveContext = base.ActiveContext;
			}
			if(_resultArchiveUploadLog!=null)
			{
				_resultArchiveUploadLog.ActiveContext = base.ActiveContext;
			}
			if(_staffEventRoleTest!=null)
			{
				_staffEventRoleTest.ActiveContext = base.ActiveContext;
			}
			if(_standardFindingTestReading!=null)
			{
				_standardFindingTestReading.ActiveContext = base.ActiveContext;
			}
			if(_testDependencyRule!=null)
			{
				_testDependencyRule.ActiveContext = base.ActiveContext;
			}
			if(_testDependencyRule_!=null)
			{
				_testDependencyRule_.ActiveContext = base.ActiveContext;
			}
			if(_testHcpcsCode!=null)
			{
				_testHcpcsCode.ActiveContext = base.ActiveContext;
			}
			if(_testIncidentalFinding!=null)
			{
				_testIncidentalFinding.ActiveContext = base.ActiveContext;
			}
			if(_testReading!=null)
			{
				_testReading.ActiveContext = base.ActiveContext;
			}
			if(_testSourceCodeDiscount!=null)
			{
				_testSourceCodeDiscount.ActiveContext = base.ActiveContext;
			}
			if(_testUnableScreenReason!=null)
			{
				_testUnableScreenReason.ActiveContext = base.ActiveContext;
			}
			if(_accountCollectionViaAccountPcpResultTestDependency!=null)
			{
				_accountCollectionViaAccountPcpResultTestDependency.ActiveContext = base.ActiveContext;
			}
			if(_accountCollectionViaAccountTest!=null)
			{
				_accountCollectionViaAccountTest.ActiveContext = base.ActiveContext;
			}
			if(_accountCollectionViaAccountNotReviewableTest!=null)
			{
				_accountCollectionViaAccountNotReviewableTest.ActiveContext = base.ActiveContext;
			}
			if(_accountCollectionViaAccountCustomerResultTestDependency!=null)
			{
				_accountCollectionViaAccountCustomerResultTestDependency.ActiveContext = base.ActiveContext;
			}
			if(_accountCollectionViaAccountHealthPlanResultTestDependency!=null)
			{
				_accountCollectionViaAccountHealthPlanResultTestDependency.ActiveContext = base.ActiveContext;
			}
			if(_billingAccountCollectionViaBillingAccountTest!=null)
			{
				_billingAccountCollectionViaBillingAccountTest.ActiveContext = base.ActiveContext;
			}
			if(_couponsCollectionViaTestSourceCodeDiscount!=null)
			{
				_couponsCollectionViaTestSourceCodeDiscount.ActiveContext = base.ActiveContext;
			}
			if(_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_!=null)
			{
				_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_.ActiveContext = base.ActiveContext;
			}
			if(_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria!=null)
			{
				_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaDependentDisqualifiedTest!=null)
			{
				_customerProfileCollectionViaDependentDisqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerEventTestFinding!=null)
			{
				_customerProfileCollectionViaCustomerEventTestFinding.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaDisqualifiedTest!=null)
			{
				_customerProfileCollectionViaDisqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaResultArchiveUploadLog!=null)
			{
				_customerProfileCollectionViaResultArchiveUploadLog.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaRequiredTest!=null)
			{
				_customerProfileCollectionViaRequiredTest.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerResultCollectionViaKynLabValues!=null)
			{
				_eventCustomerResultCollectionViaKynLabValues.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerResultCollectionViaCustomerEventScreeningTests!=null)
			{
				_eventCustomerResultCollectionViaCustomerEventScreeningTests.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaDisqualifiedTest!=null)
			{
				_eventCustomersCollectionViaDisqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaEventCustomerPreApprovedTest!=null)
			{
				_eventCustomersCollectionViaEventCustomerPreApprovedTest.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaEventCustomerPreApprovedPackageTest!=null)
			{
				_eventCustomersCollectionViaEventCustomerPreApprovedPackageTest.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaEventCustomerRequiredTest!=null)
			{
				_eventCustomersCollectionViaEventCustomerRequiredTest.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaEventCustomerTestNotPerformedNotification!=null)
			{
				_eventCustomersCollectionViaEventCustomerTestNotPerformedNotification.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaDependentDisqualifiedTest!=null)
			{
				_eventCustomersCollectionViaDependentDisqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaEventCustomerRetest!=null)
			{
				_eventCustomersCollectionViaEventCustomerRetest.ActiveContext = base.ActiveContext;
			}
			if(_eventPodRoomCollectionViaEventPodRoomTest!=null)
			{
				_eventPodRoomCollectionViaEventPodRoomTest.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaDependentDisqualifiedTest!=null)
			{
				_eventsCollectionViaDependentDisqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaDisqualifiedTest!=null)
			{
				_eventsCollectionViaDisqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventPhysicianTest!=null)
			{
				_eventsCollectionViaEventPhysicianTest.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventTest!=null)
			{
				_eventsCollectionViaEventTest.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaCustomerEventTestFinding!=null)
			{
				_eventsCollectionViaCustomerEventTestFinding.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplateCollectionViaClinicalTestQualificationCriteria!=null)
			{
				_hafTemplateCollectionViaClinicalTestQualificationCriteria.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplateCollectionViaEventTest!=null)
			{
				_hafTemplateCollectionViaEventTest.ActiveContext = base.ActiveContext;
			}
			if(_hcpcsCodeCollectionViaTestHcpcsCode!=null)
			{
				_hcpcsCodeCollectionViaTestHcpcsCode.ActiveContext = base.ActiveContext;
			}
			if(_healthPlanRevenueCollectionViaHealthPlanRevenueItem!=null)
			{
				_healthPlanRevenueCollectionViaHealthPlanRevenueItem.ActiveContext = base.ActiveContext;
			}
			if(_incidentalFindingsCollectionViaTestIncidentalFinding!=null)
			{
				_incidentalFindingsCollectionViaTestIncidentalFinding.ActiveContext = base.ActiveContext;
			}
			if(_inventoryItemCollectionViaInventoryItemTest!=null)
			{
				_inventoryItemCollectionViaInventoryItemTest.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaTestUnableScreenReason!=null)
			{
				_lookupCollectionViaTestUnableScreenReason.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEventTest_!=null)
			{
				_lookupCollectionViaEventTest_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEventTest!=null)
			{
				_lookupCollectionViaEventTest.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEventTest__!=null)
			{
				_lookupCollectionViaEventTest__.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaClinicalTestQualificationCriteria!=null)
			{
				_lookupCollectionViaClinicalTestQualificationCriteria.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaPreQualificationQuestion!=null)
			{
				_lookupCollectionViaPreQualificationQuestion.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaClinicalTestQualificationCriteria_!=null)
			{
				_lookupCollectionViaClinicalTestQualificationCriteria_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaKynLabValues!=null)
			{
				_lookupCollectionViaKynLabValues.ActiveContext = base.ActiveContext;
			}
			if(_notificationTypeCollectionViaEventCustomerTestNotPerformedNotification!=null)
			{
				_notificationTypeCollectionViaEventCustomerTestNotPerformedNotification.ActiveContext = base.ActiveContext;
			}
			if(_orderItemCollectionViaProspectActivity!=null)
			{
				_orderItemCollectionViaProspectActivity.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaPreQualificationQuestion!=null)
			{
				_organizationRoleUserCollectionViaPreQualificationQuestion.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaPreApprovedTest!=null)
			{
				_organizationRoleUserCollectionViaPreApprovedTest.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaTestHcpcsCode!=null)
			{
				_organizationRoleUserCollectionViaTestHcpcsCode.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaTestHcpcsCode_!=null)
			{
				_organizationRoleUserCollectionViaTestHcpcsCode_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaRequiredTest!=null)
			{
				_organizationRoleUserCollectionViaRequiredTest.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaPreQualificationTestTemplate!=null)
			{
				_organizationRoleUserCollectionViaPreQualificationTestTemplate.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaPreQualificationTestTemplate_!=null)
			{
				_organizationRoleUserCollectionViaPreQualificationTestTemplate_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification!=null)
			{
				_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventCustomerRetest!=null)
			{
				_organizationRoleUserCollectionViaEventCustomerRetest.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaClinicalTestQualificationCriteria!=null)
			{
				_organizationRoleUserCollectionViaClinicalTestQualificationCriteria.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventPhysicianTest__!=null)
			{
				_organizationRoleUserCollectionViaEventPhysicianTest__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_!=null)
			{
				_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventPhysicianTest!=null)
			{
				_organizationRoleUserCollectionViaEventPhysicianTest.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaDisqualifiedTest_!=null)
			{
				_organizationRoleUserCollectionViaDisqualifiedTest_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventPhysicianTest_!=null)
			{
				_organizationRoleUserCollectionViaEventPhysicianTest_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaDisqualifiedTest!=null)
			{
				_organizationRoleUserCollectionViaDisqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaKynLabValues!=null)
			{
				_organizationRoleUserCollectionViaKynLabValues.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaKynLabValues_!=null)
			{
				_organizationRoleUserCollectionViaKynLabValues_.ActiveContext = base.ActiveContext;
			}
			if(_packageCollectionViaEventCustomerPreApprovedPackageTest!=null)
			{
				_packageCollectionViaEventCustomerPreApprovedPackageTest.ActiveContext = base.ActiveContext;
			}
			if(_packageCollectionViaPackageTest!=null)
			{
				_packageCollectionViaPackageTest.ActiveContext = base.ActiveContext;
			}
			if(_packageCollectionViaHealthPlanRevenueItem!=null)
			{
				_packageCollectionViaHealthPlanRevenueItem.ActiveContext = base.ActiveContext;
			}
			if(_physicianProfileCollectionViaPhysicianPermittedTest!=null)
			{
				_physicianProfileCollectionViaPhysicianPermittedTest.ActiveContext = base.ActiveContext;
			}
			if(_podDetailsCollectionViaPodTest!=null)
			{
				_podDetailsCollectionViaPodTest.ActiveContext = base.ActiveContext;
			}
			if(_podRoomCollectionViaPodRoomTest!=null)
			{
				_podRoomCollectionViaPodRoomTest.ActiveContext = base.ActiveContext;
			}
			if(_preQualificationQuestionCollectionViaDisqualifiedTest!=null)
			{
				_preQualificationQuestionCollectionViaDisqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_preQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest!=null)
			{
				_preQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest.ActiveContext = base.ActiveContext;
			}
			if(_preQualificationTestTemplateCollectionViaEventTest!=null)
			{
				_preQualificationTestTemplateCollectionViaEventTest.ActiveContext = base.ActiveContext;
			}
			if(_readingCollectionViaTestReading!=null)
			{
				_readingCollectionViaTestReading.ActiveContext = base.ActiveContext;
			}
			if(_readingCollectionViaStandardFindingTestReading!=null)
			{
				_readingCollectionViaStandardFindingTestReading.ActiveContext = base.ActiveContext;
			}
			if(_resultArchiveUploadCollectionViaResultArchiveUploadLog!=null)
			{
				_resultArchiveUploadCollectionViaResultArchiveUploadLog.ActiveContext = base.ActiveContext;
			}
			if(_staffEventRoleCollectionViaStaffEventRoleTest!=null)
			{
				_staffEventRoleCollectionViaStaffEventRoleTest.ActiveContext = base.ActiveContext;
			}
			if(_standardFindingCollectionViaStandardFindingTestReading!=null)
			{
				_standardFindingCollectionViaStandardFindingTestReading.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplate!=null)
			{
				_hafTemplate.ActiveContext = base.ActiveContext;
			}
			if(_lookup__!=null)
			{
				_lookup__.ActiveContext = base.ActiveContext;
			}
			if(_lookup_!=null)
			{
				_lookup_.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_preQualificationTestTemplate_!=null)
			{
				_preQualificationTestTemplate_.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_accountCustomerResultTestDependency = null;
			_accountHealthPlanResultTestDependency = null;
			_accountNotReviewableTest = null;
			_accountPcpResultTestDependency = null;
			_accountTest = null;
			_billingAccountTest = null;
			_clinicalTestQualificationCriteria = null;
			_customerEventScreeningTests = null;
			_customerEventTestFinding = null;
			_customerHealthQuestionGroup = null;
			_dependentDisqualifiedTest = null;
			_disqualifiedTest = null;
			_eventCustomerPreApprovedPackageTest = null;
			_eventCustomerPreApprovedTest = null;
			_eventCustomerRequiredTest = null;
			_eventCustomerRetest = null;
			_eventCustomerTestNotPerformedNotification = null;
			_eventPhysicianTest = null;
			_eventPodRoomTest = null;
			_eventTest = null;
			_healthPlanRevenueItem = null;
			_inventoryItemTest = null;
			_kynLabValues = null;
			_packageTest = null;
			_physicianPermittedTest = null;
			_podRoomTest = null;
			_podTest = null;
			_preApprovedTest = null;
			_preQualificationQuestion = null;
			_preQualificationTemplateDependentTest = null;
			_preQualificationTestTemplate = null;
			_prospectActivity = null;
			_requiredTest = null;
			_resultArchiveUploadLog = null;
			_staffEventRoleTest = null;
			_standardFindingTestReading = null;
			_testDependencyRule = null;
			_testDependencyRule_ = null;
			_testHcpcsCode = null;
			_testIncidentalFinding = null;
			_testReading = null;
			_testSourceCodeDiscount = null;
			_testUnableScreenReason = null;
			_accountCollectionViaAccountPcpResultTestDependency = null;
			_accountCollectionViaAccountTest = null;
			_accountCollectionViaAccountNotReviewableTest = null;
			_accountCollectionViaAccountCustomerResultTestDependency = null;
			_accountCollectionViaAccountHealthPlanResultTestDependency = null;
			_billingAccountCollectionViaBillingAccountTest = null;
			_couponsCollectionViaTestSourceCodeDiscount = null;
			_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_ = null;
			_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria = null;
			_customerProfileCollectionViaDependentDisqualifiedTest = null;
			_customerProfileCollectionViaCustomerEventTestFinding = null;
			_customerProfileCollectionViaDisqualifiedTest = null;
			_customerProfileCollectionViaResultArchiveUploadLog = null;
			_customerProfileCollectionViaRequiredTest = null;
			_eventCustomerResultCollectionViaKynLabValues = null;
			_eventCustomerResultCollectionViaCustomerEventScreeningTests = null;
			_eventCustomersCollectionViaDisqualifiedTest = null;
			_eventCustomersCollectionViaEventCustomerPreApprovedTest = null;
			_eventCustomersCollectionViaEventCustomerPreApprovedPackageTest = null;
			_eventCustomersCollectionViaEventCustomerRequiredTest = null;
			_eventCustomersCollectionViaEventCustomerTestNotPerformedNotification = null;
			_eventCustomersCollectionViaDependentDisqualifiedTest = null;
			_eventCustomersCollectionViaEventCustomerRetest = null;
			_eventPodRoomCollectionViaEventPodRoomTest = null;
			_eventsCollectionViaDependentDisqualifiedTest = null;
			_eventsCollectionViaDisqualifiedTest = null;
			_eventsCollectionViaEventPhysicianTest = null;
			_eventsCollectionViaEventTest = null;
			_eventsCollectionViaCustomerEventTestFinding = null;
			_hafTemplateCollectionViaClinicalTestQualificationCriteria = null;
			_hafTemplateCollectionViaEventTest = null;
			_hcpcsCodeCollectionViaTestHcpcsCode = null;
			_healthPlanRevenueCollectionViaHealthPlanRevenueItem = null;
			_incidentalFindingsCollectionViaTestIncidentalFinding = null;
			_inventoryItemCollectionViaInventoryItemTest = null;
			_lookupCollectionViaTestUnableScreenReason = null;
			_lookupCollectionViaEventTest_ = null;
			_lookupCollectionViaEventTest = null;
			_lookupCollectionViaEventTest__ = null;
			_lookupCollectionViaClinicalTestQualificationCriteria = null;
			_lookupCollectionViaPreQualificationQuestion = null;
			_lookupCollectionViaClinicalTestQualificationCriteria_ = null;
			_lookupCollectionViaKynLabValues = null;
			_notificationTypeCollectionViaEventCustomerTestNotPerformedNotification = null;
			_orderItemCollectionViaProspectActivity = null;
			_organizationRoleUserCollectionViaPreQualificationQuestion = null;
			_organizationRoleUserCollectionViaPreApprovedTest = null;
			_organizationRoleUserCollectionViaTestHcpcsCode = null;
			_organizationRoleUserCollectionViaTestHcpcsCode_ = null;
			_organizationRoleUserCollectionViaRequiredTest = null;
			_organizationRoleUserCollectionViaPreQualificationTestTemplate = null;
			_organizationRoleUserCollectionViaPreQualificationTestTemplate_ = null;
			_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification = null;
			_organizationRoleUserCollectionViaEventCustomerRetest = null;
			_organizationRoleUserCollectionViaClinicalTestQualificationCriteria = null;
			_organizationRoleUserCollectionViaEventPhysicianTest__ = null;
			_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_ = null;
			_organizationRoleUserCollectionViaEventPhysicianTest = null;
			_organizationRoleUserCollectionViaDisqualifiedTest_ = null;
			_organizationRoleUserCollectionViaEventPhysicianTest_ = null;
			_organizationRoleUserCollectionViaDisqualifiedTest = null;
			_organizationRoleUserCollectionViaKynLabValues = null;
			_organizationRoleUserCollectionViaKynLabValues_ = null;
			_packageCollectionViaEventCustomerPreApprovedPackageTest = null;
			_packageCollectionViaPackageTest = null;
			_packageCollectionViaHealthPlanRevenueItem = null;
			_physicianProfileCollectionViaPhysicianPermittedTest = null;
			_podDetailsCollectionViaPodTest = null;
			_podRoomCollectionViaPodRoomTest = null;
			_preQualificationQuestionCollectionViaDisqualifiedTest = null;
			_preQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest = null;
			_preQualificationTestTemplateCollectionViaEventTest = null;
			_readingCollectionViaTestReading = null;
			_readingCollectionViaStandardFindingTestReading = null;
			_resultArchiveUploadCollectionViaResultArchiveUploadLog = null;
			_staffEventRoleCollectionViaStaffEventRoleTest = null;
			_standardFindingCollectionViaStandardFindingTestReading = null;
			_hafTemplate = null;
			_lookup__ = null;
			_lookup_ = null;
			_lookup = null;
			_preQualificationTestTemplate_ = null;

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

			_fieldsCustomProperties.Add("TestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Alias", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Version", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RelativeOrder", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Cptcode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsRecordable", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsTestReviewableByPhysician", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShowInCustomerPdf", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Price", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DefaultPackagePrice", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RefundPrice", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DefaultPackageRefundPrice", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MinAge", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MaxAge", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShowInAlaCarte", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DiagnosisCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ScreeningTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HafTemplateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsSelectedByDefaultForEvent", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Gender", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GroupId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ReimbursementRate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("WithPackagePrice", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsDefaultSelectionForPackage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsDefaultSelectionForOrder", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MediaUrl", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsBillableToHealthPlan", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PreQualificationQuestionTemplateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ResultEntryTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ChatStartDate", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _hafTemplate</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncHafTemplate(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _hafTemplate, new PropertyChangedEventHandler( OnHafTemplatePropertyChanged ), "HafTemplate", TestEntity.Relations.HafTemplateEntityUsingHafTemplateId, true, signalRelatedEntity, "Test", resetFKFields, new int[] { (int)TestFieldIndex.HafTemplateId } );		
			_hafTemplate = null;
		}

		/// <summary> setups the sync logic for member _hafTemplate</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncHafTemplate(IEntity2 relatedEntity)
		{
			if(_hafTemplate!=relatedEntity)
			{
				DesetupSyncHafTemplate(true, true);
				_hafTemplate = (HafTemplateEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _hafTemplate, new PropertyChangedEventHandler( OnHafTemplatePropertyChanged ), "HafTemplate", TestEntity.Relations.HafTemplateEntityUsingHafTemplateId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnHafTemplatePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _lookup__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup__, new PropertyChangedEventHandler( OnLookup__PropertyChanged ), "Lookup__", TestEntity.Relations.LookupEntityUsingResultEntryTypeId, true, signalRelatedEntity, "Test__", resetFKFields, new int[] { (int)TestFieldIndex.ResultEntryTypeId } );		
			_lookup__ = null;
		}

		/// <summary> setups the sync logic for member _lookup__</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup__(IEntity2 relatedEntity)
		{
			if(_lookup__!=relatedEntity)
			{
				DesetupSyncLookup__(true, true);
				_lookup__ = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup__, new PropertyChangedEventHandler( OnLookup__PropertyChanged ), "Lookup__", TestEntity.Relations.LookupEntityUsingResultEntryTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookup__PropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", TestEntity.Relations.LookupEntityUsingGroupId, true, signalRelatedEntity, "Test_", resetFKFields, new int[] { (int)TestFieldIndex.GroupId } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", TestEntity.Relations.LookupEntityUsingGroupId, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", TestEntity.Relations.LookupEntityUsingGender, true, signalRelatedEntity, "Test", resetFKFields, new int[] { (int)TestFieldIndex.Gender } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", TestEntity.Relations.LookupEntityUsingGender, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _preQualificationTestTemplate_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPreQualificationTestTemplate_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _preQualificationTestTemplate_, new PropertyChangedEventHandler( OnPreQualificationTestTemplate_PropertyChanged ), "PreQualificationTestTemplate_", TestEntity.Relations.PreQualificationTestTemplateEntityUsingPreQualificationQuestionTemplateId, true, signalRelatedEntity, "Test_", resetFKFields, new int[] { (int)TestFieldIndex.PreQualificationQuestionTemplateId } );		
			_preQualificationTestTemplate_ = null;
		}

		/// <summary> setups the sync logic for member _preQualificationTestTemplate_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPreQualificationTestTemplate_(IEntity2 relatedEntity)
		{
			if(_preQualificationTestTemplate_!=relatedEntity)
			{
				DesetupSyncPreQualificationTestTemplate_(true, true);
				_preQualificationTestTemplate_ = (PreQualificationTestTemplateEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _preQualificationTestTemplate_, new PropertyChangedEventHandler( OnPreQualificationTestTemplate_PropertyChanged ), "PreQualificationTestTemplate_", TestEntity.Relations.PreQualificationTestTemplateEntityUsingPreQualificationQuestionTemplateId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPreQualificationTestTemplate_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this TestEntity</param>
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
		public  static TestRelations Relations
		{
			get	{ return new TestRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccountCustomerResultTestDependency' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCustomerResultTestDependency
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountCustomerResultTestDependencyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountCustomerResultTestDependencyEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccountCustomerResultTestDependency")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.AccountCustomerResultTestDependencyEntity, 0, null, null, null, null, "AccountCustomerResultTestDependency", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccountHealthPlanResultTestDependency' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountHealthPlanResultTestDependency
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountHealthPlanResultTestDependencyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountHealthPlanResultTestDependencyEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccountHealthPlanResultTestDependency")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.AccountHealthPlanResultTestDependencyEntity, 0, null, null, null, null, "AccountHealthPlanResultTestDependency", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccountNotReviewableTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountNotReviewableTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountNotReviewableTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountNotReviewableTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccountNotReviewableTest")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.AccountNotReviewableTestEntity, 0, null, null, null, null, "AccountNotReviewableTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccountPcpResultTestDependency' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountPcpResultTestDependency
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountPcpResultTestDependencyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountPcpResultTestDependencyEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccountPcpResultTestDependency")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.AccountPcpResultTestDependencyEntity, 0, null, null, null, null, "AccountPcpResultTestDependency", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccountTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccountTest")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.AccountTestEntity, 0, null, null, null, null, "AccountTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BillingAccountTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBillingAccountTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<BillingAccountTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BillingAccountTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("BillingAccountTest")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.BillingAccountTestEntity, 0, null, null, null, null, "BillingAccountTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ClinicalTestQualificationCriteria' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathClinicalTestQualificationCriteria
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ClinicalTestQualificationCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClinicalTestQualificationCriteriaEntityFactory))),
					(IEntityRelation)GetRelationsForField("ClinicalTestQualificationCriteria")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.ClinicalTestQualificationCriteriaEntity, 0, null, null, null, null, "ClinicalTestQualificationCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventScreeningTests' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventScreeningTests
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerEventScreeningTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventScreeningTestsEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerEventScreeningTests")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, 0, null, null, null, null, "CustomerEventScreeningTests", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventTestFinding' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventTestFinding
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerEventTestFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestFindingEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerEventTestFinding")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.CustomerEventTestFindingEntity, 0, null, null, null, null, "CustomerEventTestFinding", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerHealthQuestionGroup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerHealthQuestionGroup
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerHealthQuestionGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionGroupEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerHealthQuestionGroup")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.CustomerHealthQuestionGroupEntity, 0, null, null, null, null, "CustomerHealthQuestionGroup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("DependentDisqualifiedTest")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.DependentDisqualifiedTestEntity, 0, null, null, null, null, "DependentDisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("DisqualifiedTest")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.DisqualifiedTestEntity, 0, null, null, null, null, "DisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("EventCustomerPreApprovedPackageTest")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.EventCustomerPreApprovedPackageTestEntity, 0, null, null, null, null, "EventCustomerPreApprovedPackageTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("EventCustomerPreApprovedTest")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.EventCustomerPreApprovedTestEntity, 0, null, null, null, null, "EventCustomerPreApprovedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("EventCustomerRequiredTest")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.EventCustomerRequiredTestEntity, 0, null, null, null, null, "EventCustomerRequiredTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("EventCustomerRetest")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.EventCustomerRetestEntity, 0, null, null, null, null, "EventCustomerRetest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("EventCustomerTestNotPerformedNotification")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.EventCustomerTestNotPerformedNotificationEntity, 0, null, null, null, null, "EventCustomerTestNotPerformedNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventPhysicianTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventPhysicianTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventPhysicianTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPhysicianTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventPhysicianTest")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.EventPhysicianTestEntity, 0, null, null, null, null, "EventPhysicianTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventPodRoomTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventPodRoomTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventPodRoomTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPodRoomTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventPodRoomTest")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.EventPodRoomTestEntity, 0, null, null, null, null, "EventPodRoomTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventTest")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.EventTestEntity, 0, null, null, null, null, "EventTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HealthPlanRevenueItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHealthPlanRevenueItem
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HealthPlanRevenueItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanRevenueItemEntityFactory))),
					(IEntityRelation)GetRelationsForField("HealthPlanRevenueItem")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.HealthPlanRevenueItemEntity, 0, null, null, null, null, "HealthPlanRevenueItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'InventoryItemTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathInventoryItemTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<InventoryItemTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InventoryItemTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("InventoryItemTest")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.InventoryItemTestEntity, 0, null, null, null, null, "InventoryItemTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'KynLabValues' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathKynLabValues
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<KynLabValuesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(KynLabValuesEntityFactory))),
					(IEntityRelation)GetRelationsForField("KynLabValues")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.KynLabValuesEntity, 0, null, null, null, null, "KynLabValues", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PackageTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPackageTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PackageTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("PackageTest")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.PackageTestEntity, 0, null, null, null, null, "PackageTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianPermittedTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianPermittedTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PhysicianPermittedTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianPermittedTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("PhysicianPermittedTest")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.PhysicianPermittedTestEntity, 0, null, null, null, null, "PhysicianPermittedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodRoomTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodRoomTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PodRoomTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodRoomTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("PodRoomTest")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.PodRoomTestEntity, 0, null, null, null, null, "PodRoomTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PodTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("PodTest")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.PodTestEntity, 0, null, null, null, null, "PodTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PreApprovedTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPreApprovedTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PreApprovedTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreApprovedTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("PreApprovedTest")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.PreApprovedTestEntity, 0, null, null, null, null, "PreApprovedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PreQualificationQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPreQualificationQuestion
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PreQualificationQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("PreQualificationQuestion")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.PreQualificationQuestionEntity, 0, null, null, null, null, "PreQualificationQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PreQualificationTemplateDependentTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPreQualificationTemplateDependentTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PreQualificationTemplateDependentTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTemplateDependentTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("PreQualificationTemplateDependentTest")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.PreQualificationTemplateDependentTestEntity, 0, null, null, null, null, "PreQualificationTemplateDependentTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PreQualificationTestTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPreQualificationTestTemplate
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PreQualificationTestTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTestTemplateEntityFactory))),
					(IEntityRelation)GetRelationsForField("PreQualificationTestTemplate")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, 0, null, null, null, null, "PreQualificationTestTemplate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectActivity' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectActivity
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ProspectActivityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectActivityEntityFactory))),
					(IEntityRelation)GetRelationsForField("ProspectActivity")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.ProspectActivityEntity, 0, null, null, null, null, "ProspectActivity", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RequiredTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRequiredTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<RequiredTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RequiredTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("RequiredTest")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.RequiredTestEntity, 0, null, null, null, null, "RequiredTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ResultArchiveUploadLog' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathResultArchiveUploadLog
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ResultArchiveUploadLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ResultArchiveUploadLogEntityFactory))),
					(IEntityRelation)GetRelationsForField("ResultArchiveUploadLog")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.ResultArchiveUploadLogEntity, 0, null, null, null, null, "ResultArchiveUploadLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'StaffEventRoleTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathStaffEventRoleTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<StaffEventRoleTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StaffEventRoleTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("StaffEventRoleTest")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.StaffEventRoleTestEntity, 0, null, null, null, null, "StaffEventRoleTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'StandardFindingTestReading' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathStandardFindingTestReading
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<StandardFindingTestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StandardFindingTestReadingEntityFactory))),
					(IEntityRelation)GetRelationsForField("StandardFindingTestReading")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.StandardFindingTestReadingEntity, 0, null, null, null, null, "StandardFindingTestReading", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TestDependencyRule' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestDependencyRule
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TestDependencyRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestDependencyRuleEntityFactory))),
					(IEntityRelation)GetRelationsForField("TestDependencyRule")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.TestDependencyRuleEntity, 0, null, null, null, null, "TestDependencyRule", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TestDependencyRule' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestDependencyRule_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TestDependencyRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestDependencyRuleEntityFactory))),
					(IEntityRelation)GetRelationsForField("TestDependencyRule_")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.TestDependencyRuleEntity, 0, null, null, null, null, "TestDependencyRule_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TestHcpcsCode' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestHcpcsCode
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TestHcpcsCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestHcpcsCodeEntityFactory))),
					(IEntityRelation)GetRelationsForField("TestHcpcsCode")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.TestHcpcsCodeEntity, 0, null, null, null, null, "TestHcpcsCode", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TestIncidentalFinding' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestIncidentalFinding
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TestIncidentalFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestIncidentalFindingEntityFactory))),
					(IEntityRelation)GetRelationsForField("TestIncidentalFinding")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.TestIncidentalFindingEntity, 0, null, null, null, null, "TestIncidentalFinding", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TestReading' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestReading
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestReadingEntityFactory))),
					(IEntityRelation)GetRelationsForField("TestReading")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.TestReadingEntity, 0, null, null, null, null, "TestReading", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TestSourceCodeDiscount' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestSourceCodeDiscount
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TestSourceCodeDiscountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestSourceCodeDiscountEntityFactory))),
					(IEntityRelation)GetRelationsForField("TestSourceCodeDiscount")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.TestSourceCodeDiscountEntity, 0, null, null, null, null, "TestSourceCodeDiscount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TestUnableScreenReason' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestUnableScreenReason
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TestUnableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestUnableScreenReasonEntityFactory))),
					(IEntityRelation)GetRelationsForField("TestUnableScreenReason")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.TestUnableScreenReasonEntity, 0, null, null, null, null, "TestUnableScreenReason", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCollectionViaAccountPcpResultTestDependency
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.AccountPcpResultTestDependencyEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "AccountPcpResultTestDependency_");
				return new PrefetchPathElement2(new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, GetRelationsForField("AccountCollectionViaAccountPcpResultTestDependency"), null, "AccountCollectionViaAccountPcpResultTestDependency", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCollectionViaAccountTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.AccountTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "AccountTest_");
				return new PrefetchPathElement2(new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, GetRelationsForField("AccountCollectionViaAccountTest"), null, "AccountCollectionViaAccountTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCollectionViaAccountNotReviewableTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.AccountNotReviewableTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "AccountNotReviewableTest_");
				return new PrefetchPathElement2(new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, GetRelationsForField("AccountCollectionViaAccountNotReviewableTest"), null, "AccountCollectionViaAccountNotReviewableTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCollectionViaAccountCustomerResultTestDependency
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.AccountCustomerResultTestDependencyEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "AccountCustomerResultTestDependency_");
				return new PrefetchPathElement2(new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, GetRelationsForField("AccountCollectionViaAccountCustomerResultTestDependency"), null, "AccountCollectionViaAccountCustomerResultTestDependency", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCollectionViaAccountHealthPlanResultTestDependency
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.AccountHealthPlanResultTestDependencyEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "AccountHealthPlanResultTestDependency_");
				return new PrefetchPathElement2(new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, GetRelationsForField("AccountCollectionViaAccountHealthPlanResultTestDependency"), null, "AccountCollectionViaAccountHealthPlanResultTestDependency", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BillingAccount' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBillingAccountCollectionViaBillingAccountTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.BillingAccountTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "BillingAccountTest_");
				return new PrefetchPathElement2(new EntityCollection<BillingAccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BillingAccountEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.BillingAccountEntity, 0, null, null, GetRelationsForField("BillingAccountCollectionViaBillingAccountTest"), null, "BillingAccountCollectionViaBillingAccountTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Coupons' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCouponsCollectionViaTestSourceCodeDiscount
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.TestSourceCodeDiscountEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "TestSourceCodeDiscount_");
				return new PrefetchPathElement2(new EntityCollection<CouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.CouponsEntity, 0, null, null, GetRelationsForField("CouponsCollectionViaTestSourceCodeDiscount"), null, "CouponsCollectionViaTestSourceCodeDiscount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerHealthQuestions' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, 0, null, null, GetRelationsForField("CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_"), null, "CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerHealthQuestions' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, 0, null, null, GetRelationsForField("CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria"), null, "CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaDependentDisqualifiedTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.DependentDisqualifiedTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "DependentDisqualifiedTest_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaDependentDisqualifiedTest"), null, "CustomerProfileCollectionViaDependentDisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerEventTestFinding
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.CustomerEventTestFindingEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "CustomerEventTestFinding_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerEventTestFinding"), null, "CustomerProfileCollectionViaCustomerEventTestFinding", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaDisqualifiedTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.DisqualifiedTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "DisqualifiedTest_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaDisqualifiedTest"), null, "CustomerProfileCollectionViaDisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaResultArchiveUploadLog
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.ResultArchiveUploadLogEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "ResultArchiveUploadLog_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaResultArchiveUploadLog"), null, "CustomerProfileCollectionViaResultArchiveUploadLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaRequiredTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.RequiredTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "RequiredTest_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaRequiredTest"), null, "CustomerProfileCollectionViaRequiredTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerResult' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerResultCollectionViaKynLabValues
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.KynLabValuesEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "KynLabValues_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomerResultEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerResultEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.EventCustomerResultEntity, 0, null, null, GetRelationsForField("EventCustomerResultCollectionViaKynLabValues"), null, "EventCustomerResultCollectionViaKynLabValues", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerResult' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerResultCollectionViaCustomerEventScreeningTests
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.CustomerEventScreeningTestsEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "CustomerEventScreeningTests_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomerResultEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerResultEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.EventCustomerResultEntity, 0, null, null, GetRelationsForField("EventCustomerResultCollectionViaCustomerEventScreeningTests"), null, "EventCustomerResultCollectionViaCustomerEventScreeningTests", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaDisqualifiedTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.DisqualifiedTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "DisqualifiedTest_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaDisqualifiedTest"), null, "EventCustomersCollectionViaDisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaEventCustomerPreApprovedTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.EventCustomerPreApprovedTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerPreApprovedTest_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaEventCustomerPreApprovedTest"), null, "EventCustomersCollectionViaEventCustomerPreApprovedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaEventCustomerPreApprovedPackageTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.EventCustomerPreApprovedPackageTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerPreApprovedPackageTest_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaEventCustomerPreApprovedPackageTest"), null, "EventCustomersCollectionViaEventCustomerPreApprovedPackageTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaEventCustomerRequiredTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.EventCustomerRequiredTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerRequiredTest_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaEventCustomerRequiredTest"), null, "EventCustomersCollectionViaEventCustomerRequiredTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaEventCustomerTestNotPerformedNotification
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.EventCustomerTestNotPerformedNotificationEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerTestNotPerformedNotification_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaEventCustomerTestNotPerformedNotification"), null, "EventCustomersCollectionViaEventCustomerTestNotPerformedNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaDependentDisqualifiedTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.DependentDisqualifiedTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "DependentDisqualifiedTest_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaDependentDisqualifiedTest"), null, "EventCustomersCollectionViaDependentDisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaEventCustomerRetest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.EventCustomerRetestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerRetest_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaEventCustomerRetest"), null, "EventCustomersCollectionViaEventCustomerRetest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventPodRoom' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventPodRoomCollectionViaEventPodRoomTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.EventPodRoomTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "EventPodRoomTest_");
				return new PrefetchPathElement2(new EntityCollection<EventPodRoomEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPodRoomEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.EventPodRoomEntity, 0, null, null, GetRelationsForField("EventPodRoomCollectionViaEventPodRoomTest"), null, "EventPodRoomCollectionViaEventPodRoomTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaDependentDisqualifiedTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.DependentDisqualifiedTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "DependentDisqualifiedTest_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaDependentDisqualifiedTest"), null, "EventsCollectionViaDependentDisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaDisqualifiedTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.DisqualifiedTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "DisqualifiedTest_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaDisqualifiedTest"), null, "EventsCollectionViaDisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventPhysicianTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.EventPhysicianTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "EventPhysicianTest_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventPhysicianTest"), null, "EventsCollectionViaEventPhysicianTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.EventTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "EventTest_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventTest"), null, "EventsCollectionViaEventTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaCustomerEventTestFinding
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.CustomerEventTestFindingEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "CustomerEventTestFinding_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaCustomerEventTestFinding"), null, "EventsCollectionViaCustomerEventTestFinding", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplateCollectionViaClinicalTestQualificationCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, GetRelationsForField("HafTemplateCollectionViaClinicalTestQualificationCriteria"), null, "HafTemplateCollectionViaClinicalTestQualificationCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplateCollectionViaEventTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.EventTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "EventTest_");
				return new PrefetchPathElement2(new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, GetRelationsForField("HafTemplateCollectionViaEventTest"), null, "HafTemplateCollectionViaEventTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HcpcsCode' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHcpcsCodeCollectionViaTestHcpcsCode
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.TestHcpcsCodeEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "TestHcpcsCode_");
				return new PrefetchPathElement2(new EntityCollection<HcpcsCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HcpcsCodeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.HcpcsCodeEntity, 0, null, null, GetRelationsForField("HcpcsCodeCollectionViaTestHcpcsCode"), null, "HcpcsCodeCollectionViaTestHcpcsCode", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HealthPlanRevenue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHealthPlanRevenueCollectionViaHealthPlanRevenueItem
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.HealthPlanRevenueItemEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanRevenueItem_");
				return new PrefetchPathElement2(new EntityCollection<HealthPlanRevenueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanRevenueEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.HealthPlanRevenueEntity, 0, null, null, GetRelationsForField("HealthPlanRevenueCollectionViaHealthPlanRevenueItem"), null, "HealthPlanRevenueCollectionViaHealthPlanRevenueItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'IncidentalFindings' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathIncidentalFindingsCollectionViaTestIncidentalFinding
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.TestIncidentalFindingEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "TestIncidentalFinding_");
				return new PrefetchPathElement2(new EntityCollection<IncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.IncidentalFindingsEntity, 0, null, null, GetRelationsForField("IncidentalFindingsCollectionViaTestIncidentalFinding"), null, "IncidentalFindingsCollectionViaTestIncidentalFinding", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'InventoryItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathInventoryItemCollectionViaInventoryItemTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.InventoryItemTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "InventoryItemTest_");
				return new PrefetchPathElement2(new EntityCollection<InventoryItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InventoryItemEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.InventoryItemEntity, 0, null, null, GetRelationsForField("InventoryItemCollectionViaInventoryItemTest"), null, "InventoryItemCollectionViaInventoryItemTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaTestUnableScreenReason
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.TestUnableScreenReasonEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "TestUnableScreenReason_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaTestUnableScreenReason"), null, "LookupCollectionViaTestUnableScreenReason", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventTest_
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.EventTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "EventTest_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventTest_"), null, "LookupCollectionViaEventTest_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.EventTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "EventTest_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventTest"), null, "LookupCollectionViaEventTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventTest__
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.EventTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "EventTest_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventTest__"), null, "LookupCollectionViaEventTest__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaClinicalTestQualificationCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaClinicalTestQualificationCriteria"), null, "LookupCollectionViaClinicalTestQualificationCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaPreQualificationQuestion
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.PreQualificationQuestionEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationQuestion_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaPreQualificationQuestion"), null, "LookupCollectionViaPreQualificationQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaClinicalTestQualificationCriteria_
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaClinicalTestQualificationCriteria_"), null, "LookupCollectionViaClinicalTestQualificationCriteria_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaKynLabValues
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.KynLabValuesEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "KynLabValues_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaKynLabValues"), null, "LookupCollectionViaKynLabValues", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotificationType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotificationTypeCollectionViaEventCustomerTestNotPerformedNotification
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.EventCustomerTestNotPerformedNotificationEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerTestNotPerformedNotification_");
				return new PrefetchPathElement2(new EntityCollection<NotificationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.NotificationTypeEntity, 0, null, null, GetRelationsForField("NotificationTypeCollectionViaEventCustomerTestNotPerformedNotification"), null, "NotificationTypeCollectionViaEventCustomerTestNotPerformedNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrderItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrderItemCollectionViaProspectActivity
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.ProspectActivityEntityUsingActivityId;
				intermediateRelation.SetAliases(string.Empty, "ProspectActivity_");
				return new PrefetchPathElement2(new EntityCollection<OrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderItemEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.OrderItemEntity, 0, null, null, GetRelationsForField("OrderItemCollectionViaProspectActivity"), null, "OrderItemCollectionViaProspectActivity", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaPreQualificationQuestion
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.PreQualificationQuestionEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationQuestion_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaPreQualificationQuestion"), null, "OrganizationRoleUserCollectionViaPreQualificationQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaPreApprovedTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.PreApprovedTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "PreApprovedTest_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaPreApprovedTest"), null, "OrganizationRoleUserCollectionViaPreApprovedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaTestHcpcsCode
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.TestHcpcsCodeEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "TestHcpcsCode_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaTestHcpcsCode"), null, "OrganizationRoleUserCollectionViaTestHcpcsCode", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaTestHcpcsCode_
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.TestHcpcsCodeEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "TestHcpcsCode_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaTestHcpcsCode_"), null, "OrganizationRoleUserCollectionViaTestHcpcsCode_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaRequiredTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.RequiredTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "RequiredTest_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaRequiredTest"), null, "OrganizationRoleUserCollectionViaRequiredTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaPreQualificationTestTemplate
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.PreQualificationTestTemplateEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationTestTemplate_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaPreQualificationTestTemplate"), null, "OrganizationRoleUserCollectionViaPreQualificationTestTemplate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaPreQualificationTestTemplate_
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.PreQualificationTestTemplateEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationTestTemplate_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaPreQualificationTestTemplate_"), null, "OrganizationRoleUserCollectionViaPreQualificationTestTemplate_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.EventCustomerTestNotPerformedNotificationEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerTestNotPerformedNotification_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification"), null, "OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventCustomerRetest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.EventCustomerRetestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerRetest_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventCustomerRetest"), null, "OrganizationRoleUserCollectionViaEventCustomerRetest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaClinicalTestQualificationCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria"), null, "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventPhysicianTest__
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.EventPhysicianTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "EventPhysicianTest_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventPhysicianTest__"), null, "OrganizationRoleUserCollectionViaEventPhysicianTest__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_"), null, "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventPhysicianTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.EventPhysicianTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "EventPhysicianTest_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventPhysicianTest"), null, "OrganizationRoleUserCollectionViaEventPhysicianTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaDisqualifiedTest_
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.DisqualifiedTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "DisqualifiedTest_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaDisqualifiedTest_"), null, "OrganizationRoleUserCollectionViaDisqualifiedTest_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventPhysicianTest_
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.EventPhysicianTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "EventPhysicianTest_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventPhysicianTest_"), null, "OrganizationRoleUserCollectionViaEventPhysicianTest_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaDisqualifiedTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.DisqualifiedTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "DisqualifiedTest_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaDisqualifiedTest"), null, "OrganizationRoleUserCollectionViaDisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaKynLabValues
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.KynLabValuesEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "KynLabValues_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaKynLabValues"), null, "OrganizationRoleUserCollectionViaKynLabValues", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaKynLabValues_
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.KynLabValuesEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "KynLabValues_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaKynLabValues_"), null, "OrganizationRoleUserCollectionViaKynLabValues_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Package' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPackageCollectionViaEventCustomerPreApprovedPackageTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.EventCustomerPreApprovedPackageTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerPreApprovedPackageTest_");
				return new PrefetchPathElement2(new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.PackageEntity, 0, null, null, GetRelationsForField("PackageCollectionViaEventCustomerPreApprovedPackageTest"), null, "PackageCollectionViaEventCustomerPreApprovedPackageTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Package' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPackageCollectionViaPackageTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.PackageTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "PackageTest_");
				return new PrefetchPathElement2(new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.PackageEntity, 0, null, null, GetRelationsForField("PackageCollectionViaPackageTest"), null, "PackageCollectionViaPackageTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Package' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPackageCollectionViaHealthPlanRevenueItem
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.HealthPlanRevenueItemEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanRevenueItem_");
				return new PrefetchPathElement2(new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.PackageEntity, 0, null, null, GetRelationsForField("PackageCollectionViaHealthPlanRevenueItem"), null, "PackageCollectionViaHealthPlanRevenueItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianProfileCollectionViaPhysicianPermittedTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.PhysicianPermittedTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "PhysicianPermittedTest_");
				return new PrefetchPathElement2(new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.PhysicianProfileEntity, 0, null, null, GetRelationsForField("PhysicianProfileCollectionViaPhysicianPermittedTest"), null, "PhysicianProfileCollectionViaPhysicianPermittedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodDetailsCollectionViaPodTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.PodTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "PodTest_");
				return new PrefetchPathElement2(new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.PodDetailsEntity, 0, null, null, GetRelationsForField("PodDetailsCollectionViaPodTest"), null, "PodDetailsCollectionViaPodTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodRoom' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodRoomCollectionViaPodRoomTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.PodRoomTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "PodRoomTest_");
				return new PrefetchPathElement2(new EntityCollection<PodRoomEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodRoomEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.PodRoomEntity, 0, null, null, GetRelationsForField("PodRoomCollectionViaPodRoomTest"), null, "PodRoomCollectionViaPodRoomTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PreQualificationQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPreQualificationQuestionCollectionViaDisqualifiedTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.DisqualifiedTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "DisqualifiedTest_");
				return new PrefetchPathElement2(new EntityCollection<PreQualificationQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationQuestionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.PreQualificationQuestionEntity, 0, null, null, GetRelationsForField("PreQualificationQuestionCollectionViaDisqualifiedTest"), null, "PreQualificationQuestionCollectionViaDisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PreQualificationTestTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPreQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.PreQualificationTemplateDependentTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationTemplateDependentTest_");
				return new PrefetchPathElement2(new EntityCollection<PreQualificationTestTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTestTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, 0, null, null, GetRelationsForField("PreQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest"), null, "PreQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PreQualificationTestTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPreQualificationTestTemplateCollectionViaEventTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.EventTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "EventTest_");
				return new PrefetchPathElement2(new EntityCollection<PreQualificationTestTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTestTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, 0, null, null, GetRelationsForField("PreQualificationTestTemplateCollectionViaEventTest"), null, "PreQualificationTestTemplateCollectionViaEventTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Reading' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathReadingCollectionViaTestReading
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.TestReadingEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "TestReading_");
				return new PrefetchPathElement2(new EntityCollection<ReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReadingEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.ReadingEntity, 0, null, null, GetRelationsForField("ReadingCollectionViaTestReading"), null, "ReadingCollectionViaTestReading", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Reading' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathReadingCollectionViaStandardFindingTestReading
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.StandardFindingTestReadingEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "StandardFindingTestReading_");
				return new PrefetchPathElement2(new EntityCollection<ReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReadingEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.ReadingEntity, 0, null, null, GetRelationsForField("ReadingCollectionViaStandardFindingTestReading"), null, "ReadingCollectionViaStandardFindingTestReading", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ResultArchiveUpload' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathResultArchiveUploadCollectionViaResultArchiveUploadLog
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.ResultArchiveUploadLogEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "ResultArchiveUploadLog_");
				return new PrefetchPathElement2(new EntityCollection<ResultArchiveUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ResultArchiveUploadEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.ResultArchiveUploadEntity, 0, null, null, GetRelationsForField("ResultArchiveUploadCollectionViaResultArchiveUploadLog"), null, "ResultArchiveUploadCollectionViaResultArchiveUploadLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'StaffEventRole' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathStaffEventRoleCollectionViaStaffEventRoleTest
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.StaffEventRoleTestEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "StaffEventRoleTest_");
				return new PrefetchPathElement2(new EntityCollection<StaffEventRoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StaffEventRoleEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.StaffEventRoleEntity, 0, null, null, GetRelationsForField("StaffEventRoleCollectionViaStaffEventRoleTest"), null, "StaffEventRoleCollectionViaStaffEventRoleTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'StandardFinding' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathStandardFindingCollectionViaStandardFindingTestReading
		{
			get
			{
				IEntityRelation intermediateRelation = TestEntity.Relations.StandardFindingTestReadingEntityUsingTestId;
				intermediateRelation.SetAliases(string.Empty, "StandardFindingTestReading_");
				return new PrefetchPathElement2(new EntityCollection<StandardFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StandardFindingEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.StandardFindingEntity, 0, null, null, GetRelationsForField("StandardFindingCollectionViaStandardFindingTestReading"), null, "StandardFindingCollectionViaStandardFindingTestReading", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplate
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))),
					(IEntityRelation)GetRelationsForField("HafTemplate")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, null, null, "HafTemplate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup__
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup__")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup_")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PreQualificationTestTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPreQualificationTestTemplate_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTestTemplateEntityFactory))),
					(IEntityRelation)GetRelationsForField("PreQualificationTestTemplate_")[0], (int)Falcon.Data.EntityType.TestEntity, (int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, 0, null, null, null, null, "PreQualificationTestTemplate_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return TestEntity.CustomProperties;}
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
			get { return TestEntity.FieldsCustomProperties;}
		}

		/// <summary> The TestId property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."TestID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 TestId
		{
			get { return (System.Int64)GetValue((int)TestFieldIndex.TestId, true); }
			set	{ SetValue((int)TestFieldIndex.TestId, value); }
		}

		/// <summary> The Name property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)TestFieldIndex.Name, true); }
			set	{ SetValue((int)TestFieldIndex.Name, value); }
		}

		/// <summary> The Description property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)TestFieldIndex.Description, true); }
			set	{ SetValue((int)TestFieldIndex.Description, value); }
		}

		/// <summary> The IsActive property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)TestFieldIndex.IsActive, true); }
			set	{ SetValue((int)TestFieldIndex.IsActive, value); }
		}

		/// <summary> The DateCreated property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)TestFieldIndex.DateCreated, true); }
			set	{ SetValue((int)TestFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)TestFieldIndex.DateModified, true); }
			set	{ SetValue((int)TestFieldIndex.DateModified, value); }
		}

		/// <summary> The Alias property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."Alias"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Alias
		{
			get { return (System.String)GetValue((int)TestFieldIndex.Alias, true); }
			set	{ SetValue((int)TestFieldIndex.Alias, value); }
		}

		/// <summary> The Version property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."Version"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 Version
		{
			get { return (System.Int16)GetValue((int)TestFieldIndex.Version, true); }
			set	{ SetValue((int)TestFieldIndex.Version, value); }
		}

		/// <summary> The RelativeOrder property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."RelativeOrder"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 RelativeOrder
		{
			get { return (System.Int32)GetValue((int)TestFieldIndex.RelativeOrder, true); }
			set	{ SetValue((int)TestFieldIndex.RelativeOrder, value); }
		}

		/// <summary> The Cptcode property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."CPTCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 250<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Cptcode
		{
			get { return (System.String)GetValue((int)TestFieldIndex.Cptcode, true); }
			set	{ SetValue((int)TestFieldIndex.Cptcode, value); }
		}

		/// <summary> The IsRecordable property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."IsRecordable"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsRecordable
		{
			get { return (System.Boolean)GetValue((int)TestFieldIndex.IsRecordable, true); }
			set	{ SetValue((int)TestFieldIndex.IsRecordable, value); }
		}

		/// <summary> The IsTestReviewableByPhysician property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."IsTestReviewableByPhysician"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsTestReviewableByPhysician
		{
			get { return (System.Boolean)GetValue((int)TestFieldIndex.IsTestReviewableByPhysician, true); }
			set	{ SetValue((int)TestFieldIndex.IsTestReviewableByPhysician, value); }
		}

		/// <summary> The ShowInCustomerPdf property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."ShowInCustomerPDF"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean ShowInCustomerPdf
		{
			get { return (System.Boolean)GetValue((int)TestFieldIndex.ShowInCustomerPdf, true); }
			set	{ SetValue((int)TestFieldIndex.ShowInCustomerPdf, value); }
		}

		/// <summary> The Price property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."Price"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Price
		{
			get { return (System.Decimal)GetValue((int)TestFieldIndex.Price, true); }
			set	{ SetValue((int)TestFieldIndex.Price, value); }
		}

		/// <summary> The DefaultPackagePrice property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."DefaultPackagePrice"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal DefaultPackagePrice
		{
			get { return (System.Decimal)GetValue((int)TestFieldIndex.DefaultPackagePrice, true); }
			set	{ SetValue((int)TestFieldIndex.DefaultPackagePrice, value); }
		}

		/// <summary> The RefundPrice property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."RefundPrice"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal RefundPrice
		{
			get { return (System.Decimal)GetValue((int)TestFieldIndex.RefundPrice, true); }
			set	{ SetValue((int)TestFieldIndex.RefundPrice, value); }
		}

		/// <summary> The DefaultPackageRefundPrice property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."DefaultPackageRefundPrice"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal DefaultPackageRefundPrice
		{
			get { return (System.Decimal)GetValue((int)TestFieldIndex.DefaultPackageRefundPrice, true); }
			set	{ SetValue((int)TestFieldIndex.DefaultPackageRefundPrice, value); }
		}

		/// <summary> The MinAge property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."MinAge"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> MinAge
		{
			get { return (Nullable<System.Int32>)GetValue((int)TestFieldIndex.MinAge, false); }
			set	{ SetValue((int)TestFieldIndex.MinAge, value); }
		}

		/// <summary> The MaxAge property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."MaxAge"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> MaxAge
		{
			get { return (Nullable<System.Int32>)GetValue((int)TestFieldIndex.MaxAge, false); }
			set	{ SetValue((int)TestFieldIndex.MaxAge, value); }
		}

		/// <summary> The ShowInAlaCarte property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."ShowInAlaCarte"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean ShowInAlaCarte
		{
			get { return (System.Boolean)GetValue((int)TestFieldIndex.ShowInAlaCarte, true); }
			set	{ SetValue((int)TestFieldIndex.ShowInAlaCarte, value); }
		}

		/// <summary> The DiagnosisCode property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."DiagnosisCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 250<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String DiagnosisCode
		{
			get { return (System.String)GetValue((int)TestFieldIndex.DiagnosisCode, true); }
			set	{ SetValue((int)TestFieldIndex.DiagnosisCode, value); }
		}

		/// <summary> The ScreeningTime property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."ScreeningTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> ScreeningTime
		{
			get { return (Nullable<System.Int32>)GetValue((int)TestFieldIndex.ScreeningTime, false); }
			set	{ SetValue((int)TestFieldIndex.ScreeningTime, value); }
		}

		/// <summary> The HafTemplateId property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."HAFTemplateId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> HafTemplateId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TestFieldIndex.HafTemplateId, false); }
			set	{ SetValue((int)TestFieldIndex.HafTemplateId, value); }
		}

		/// <summary> The IsSelectedByDefaultForEvent property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."IsSelectedByDefaultForEvent"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsSelectedByDefaultForEvent
		{
			get { return (System.Boolean)GetValue((int)TestFieldIndex.IsSelectedByDefaultForEvent, true); }
			set	{ SetValue((int)TestFieldIndex.IsSelectedByDefaultForEvent, value); }
		}

		/// <summary> The Gender property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."Gender"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Gender
		{
			get { return (System.Int64)GetValue((int)TestFieldIndex.Gender, true); }
			set	{ SetValue((int)TestFieldIndex.Gender, value); }
		}

		/// <summary> The GroupId property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."GroupId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 GroupId
		{
			get { return (System.Int64)GetValue((int)TestFieldIndex.GroupId, true); }
			set	{ SetValue((int)TestFieldIndex.GroupId, value); }
		}

		/// <summary> The ReimbursementRate property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."ReimbursementRate"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal ReimbursementRate
		{
			get { return (System.Decimal)GetValue((int)TestFieldIndex.ReimbursementRate, true); }
			set	{ SetValue((int)TestFieldIndex.ReimbursementRate, value); }
		}

		/// <summary> The WithPackagePrice property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."WithPackagePrice"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal WithPackagePrice
		{
			get { return (System.Decimal)GetValue((int)TestFieldIndex.WithPackagePrice, true); }
			set	{ SetValue((int)TestFieldIndex.WithPackagePrice, value); }
		}

		/// <summary> The IsDefaultSelectionForPackage property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."IsDefaultSelectionForPackage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsDefaultSelectionForPackage
		{
			get { return (System.Boolean)GetValue((int)TestFieldIndex.IsDefaultSelectionForPackage, true); }
			set	{ SetValue((int)TestFieldIndex.IsDefaultSelectionForPackage, value); }
		}

		/// <summary> The IsDefaultSelectionForOrder property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."IsDefaultSelectionForOrder"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsDefaultSelectionForOrder
		{
			get { return (System.Boolean)GetValue((int)TestFieldIndex.IsDefaultSelectionForOrder, true); }
			set	{ SetValue((int)TestFieldIndex.IsDefaultSelectionForOrder, value); }
		}

		/// <summary> The MediaUrl property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."MediaUrl"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MediaUrl
		{
			get { return (System.String)GetValue((int)TestFieldIndex.MediaUrl, true); }
			set	{ SetValue((int)TestFieldIndex.MediaUrl, value); }
		}

		/// <summary> The IsBillableToHealthPlan property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."IsBillableToHealthPlan"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsBillableToHealthPlan
		{
			get { return (Nullable<System.Boolean>)GetValue((int)TestFieldIndex.IsBillableToHealthPlan, false); }
			set	{ SetValue((int)TestFieldIndex.IsBillableToHealthPlan, value); }
		}

		/// <summary> The PreQualificationQuestionTemplateId property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."PreQualificationQuestionTemplateId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> PreQualificationQuestionTemplateId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TestFieldIndex.PreQualificationQuestionTemplateId, false); }
			set	{ SetValue((int)TestFieldIndex.PreQualificationQuestionTemplateId, value); }
		}

		/// <summary> The ResultEntryTypeId property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."ResultEntryTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ResultEntryTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TestFieldIndex.ResultEntryTypeId, false); }
			set	{ SetValue((int)TestFieldIndex.ResultEntryTypeId, value); }
		}

		/// <summary> The ChatStartDate property of the Entity Test<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTest"."ChatStartDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ChatStartDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)TestFieldIndex.ChatStartDate, false); }
			set	{ SetValue((int)TestFieldIndex.ChatStartDate, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountCustomerResultTestDependencyEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountCustomerResultTestDependencyEntity))]
		public virtual EntityCollection<AccountCustomerResultTestDependencyEntity> AccountCustomerResultTestDependency
		{
			get
			{
				if(_accountCustomerResultTestDependency==null)
				{
					_accountCustomerResultTestDependency = new EntityCollection<AccountCustomerResultTestDependencyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountCustomerResultTestDependencyEntityFactory)));
					_accountCustomerResultTestDependency.SetContainingEntityInfo(this, "Test");
				}
				return _accountCustomerResultTestDependency;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountHealthPlanResultTestDependencyEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountHealthPlanResultTestDependencyEntity))]
		public virtual EntityCollection<AccountHealthPlanResultTestDependencyEntity> AccountHealthPlanResultTestDependency
		{
			get
			{
				if(_accountHealthPlanResultTestDependency==null)
				{
					_accountHealthPlanResultTestDependency = new EntityCollection<AccountHealthPlanResultTestDependencyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountHealthPlanResultTestDependencyEntityFactory)));
					_accountHealthPlanResultTestDependency.SetContainingEntityInfo(this, "Test");
				}
				return _accountHealthPlanResultTestDependency;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountNotReviewableTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountNotReviewableTestEntity))]
		public virtual EntityCollection<AccountNotReviewableTestEntity> AccountNotReviewableTest
		{
			get
			{
				if(_accountNotReviewableTest==null)
				{
					_accountNotReviewableTest = new EntityCollection<AccountNotReviewableTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountNotReviewableTestEntityFactory)));
					_accountNotReviewableTest.SetContainingEntityInfo(this, "Test");
				}
				return _accountNotReviewableTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountPcpResultTestDependencyEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountPcpResultTestDependencyEntity))]
		public virtual EntityCollection<AccountPcpResultTestDependencyEntity> AccountPcpResultTestDependency
		{
			get
			{
				if(_accountPcpResultTestDependency==null)
				{
					_accountPcpResultTestDependency = new EntityCollection<AccountPcpResultTestDependencyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountPcpResultTestDependencyEntityFactory)));
					_accountPcpResultTestDependency.SetContainingEntityInfo(this, "Test");
				}
				return _accountPcpResultTestDependency;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountTestEntity))]
		public virtual EntityCollection<AccountTestEntity> AccountTest
		{
			get
			{
				if(_accountTest==null)
				{
					_accountTest = new EntityCollection<AccountTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountTestEntityFactory)));
					_accountTest.SetContainingEntityInfo(this, "Test");
				}
				return _accountTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BillingAccountTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BillingAccountTestEntity))]
		public virtual EntityCollection<BillingAccountTestEntity> BillingAccountTest
		{
			get
			{
				if(_billingAccountTest==null)
				{
					_billingAccountTest = new EntityCollection<BillingAccountTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BillingAccountTestEntityFactory)));
					_billingAccountTest.SetContainingEntityInfo(this, "Test");
				}
				return _billingAccountTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ClinicalTestQualificationCriteriaEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ClinicalTestQualificationCriteriaEntity))]
		public virtual EntityCollection<ClinicalTestQualificationCriteriaEntity> ClinicalTestQualificationCriteria
		{
			get
			{
				if(_clinicalTestQualificationCriteria==null)
				{
					_clinicalTestQualificationCriteria = new EntityCollection<ClinicalTestQualificationCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClinicalTestQualificationCriteriaEntityFactory)));
					_clinicalTestQualificationCriteria.SetContainingEntityInfo(this, "Test");
				}
				return _clinicalTestQualificationCriteria;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerEventScreeningTestsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerEventScreeningTestsEntity))]
		public virtual EntityCollection<CustomerEventScreeningTestsEntity> CustomerEventScreeningTests
		{
			get
			{
				if(_customerEventScreeningTests==null)
				{
					_customerEventScreeningTests = new EntityCollection<CustomerEventScreeningTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventScreeningTestsEntityFactory)));
					_customerEventScreeningTests.SetContainingEntityInfo(this, "Test");
				}
				return _customerEventScreeningTests;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerEventTestFindingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerEventTestFindingEntity))]
		public virtual EntityCollection<CustomerEventTestFindingEntity> CustomerEventTestFinding
		{
			get
			{
				if(_customerEventTestFinding==null)
				{
					_customerEventTestFinding = new EntityCollection<CustomerEventTestFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestFindingEntityFactory)));
					_customerEventTestFinding.SetContainingEntityInfo(this, "Test");
				}
				return _customerEventTestFinding;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerHealthQuestionGroupEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerHealthQuestionGroupEntity))]
		public virtual EntityCollection<CustomerHealthQuestionGroupEntity> CustomerHealthQuestionGroup
		{
			get
			{
				if(_customerHealthQuestionGroup==null)
				{
					_customerHealthQuestionGroup = new EntityCollection<CustomerHealthQuestionGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionGroupEntityFactory)));
					_customerHealthQuestionGroup.SetContainingEntityInfo(this, "Test");
				}
				return _customerHealthQuestionGroup;
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
					_dependentDisqualifiedTest.SetContainingEntityInfo(this, "Test");
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
					_disqualifiedTest.SetContainingEntityInfo(this, "Test");
				}
				return _disqualifiedTest;
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
					_eventCustomerPreApprovedPackageTest.SetContainingEntityInfo(this, "Test");
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
					_eventCustomerPreApprovedTest.SetContainingEntityInfo(this, "Test");
				}
				return _eventCustomerPreApprovedTest;
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
					_eventCustomerRequiredTest.SetContainingEntityInfo(this, "Test");
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
					_eventCustomerRetest.SetContainingEntityInfo(this, "Test");
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
					_eventCustomerTestNotPerformedNotification.SetContainingEntityInfo(this, "Test");
				}
				return _eventCustomerTestNotPerformedNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventPhysicianTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventPhysicianTestEntity))]
		public virtual EntityCollection<EventPhysicianTestEntity> EventPhysicianTest
		{
			get
			{
				if(_eventPhysicianTest==null)
				{
					_eventPhysicianTest = new EntityCollection<EventPhysicianTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPhysicianTestEntityFactory)));
					_eventPhysicianTest.SetContainingEntityInfo(this, "Test");
				}
				return _eventPhysicianTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventPodRoomTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventPodRoomTestEntity))]
		public virtual EntityCollection<EventPodRoomTestEntity> EventPodRoomTest
		{
			get
			{
				if(_eventPodRoomTest==null)
				{
					_eventPodRoomTest = new EntityCollection<EventPodRoomTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPodRoomTestEntityFactory)));
					_eventPodRoomTest.SetContainingEntityInfo(this, "Test");
				}
				return _eventPodRoomTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventTestEntity))]
		public virtual EntityCollection<EventTestEntity> EventTest
		{
			get
			{
				if(_eventTest==null)
				{
					_eventTest = new EntityCollection<EventTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestEntityFactory)));
					_eventTest.SetContainingEntityInfo(this, "Test");
				}
				return _eventTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HealthPlanRevenueItemEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HealthPlanRevenueItemEntity))]
		public virtual EntityCollection<HealthPlanRevenueItemEntity> HealthPlanRevenueItem
		{
			get
			{
				if(_healthPlanRevenueItem==null)
				{
					_healthPlanRevenueItem = new EntityCollection<HealthPlanRevenueItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanRevenueItemEntityFactory)));
					_healthPlanRevenueItem.SetContainingEntityInfo(this, "Test");
				}
				return _healthPlanRevenueItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'InventoryItemTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(InventoryItemTestEntity))]
		public virtual EntityCollection<InventoryItemTestEntity> InventoryItemTest
		{
			get
			{
				if(_inventoryItemTest==null)
				{
					_inventoryItemTest = new EntityCollection<InventoryItemTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InventoryItemTestEntityFactory)));
					_inventoryItemTest.SetContainingEntityInfo(this, "Test");
				}
				return _inventoryItemTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'KynLabValuesEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(KynLabValuesEntity))]
		public virtual EntityCollection<KynLabValuesEntity> KynLabValues
		{
			get
			{
				if(_kynLabValues==null)
				{
					_kynLabValues = new EntityCollection<KynLabValuesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(KynLabValuesEntityFactory)));
					_kynLabValues.SetContainingEntityInfo(this, "Test");
				}
				return _kynLabValues;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PackageTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PackageTestEntity))]
		public virtual EntityCollection<PackageTestEntity> PackageTest
		{
			get
			{
				if(_packageTest==null)
				{
					_packageTest = new EntityCollection<PackageTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageTestEntityFactory)));
					_packageTest.SetContainingEntityInfo(this, "Test");
				}
				return _packageTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianPermittedTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianPermittedTestEntity))]
		public virtual EntityCollection<PhysicianPermittedTestEntity> PhysicianPermittedTest
		{
			get
			{
				if(_physicianPermittedTest==null)
				{
					_physicianPermittedTest = new EntityCollection<PhysicianPermittedTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianPermittedTestEntityFactory)));
					_physicianPermittedTest.SetContainingEntityInfo(this, "Test");
				}
				return _physicianPermittedTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PodRoomTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodRoomTestEntity))]
		public virtual EntityCollection<PodRoomTestEntity> PodRoomTest
		{
			get
			{
				if(_podRoomTest==null)
				{
					_podRoomTest = new EntityCollection<PodRoomTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodRoomTestEntityFactory)));
					_podRoomTest.SetContainingEntityInfo(this, "Test");
				}
				return _podRoomTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PodTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodTestEntity))]
		public virtual EntityCollection<PodTestEntity> PodTest
		{
			get
			{
				if(_podTest==null)
				{
					_podTest = new EntityCollection<PodTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodTestEntityFactory)));
					_podTest.SetContainingEntityInfo(this, "Test");
				}
				return _podTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PreApprovedTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PreApprovedTestEntity))]
		public virtual EntityCollection<PreApprovedTestEntity> PreApprovedTest
		{
			get
			{
				if(_preApprovedTest==null)
				{
					_preApprovedTest = new EntityCollection<PreApprovedTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreApprovedTestEntityFactory)));
					_preApprovedTest.SetContainingEntityInfo(this, "Test");
				}
				return _preApprovedTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PreQualificationQuestionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PreQualificationQuestionEntity))]
		public virtual EntityCollection<PreQualificationQuestionEntity> PreQualificationQuestion
		{
			get
			{
				if(_preQualificationQuestion==null)
				{
					_preQualificationQuestion = new EntityCollection<PreQualificationQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationQuestionEntityFactory)));
					_preQualificationQuestion.SetContainingEntityInfo(this, "Test");
				}
				return _preQualificationQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PreQualificationTemplateDependentTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PreQualificationTemplateDependentTestEntity))]
		public virtual EntityCollection<PreQualificationTemplateDependentTestEntity> PreQualificationTemplateDependentTest
		{
			get
			{
				if(_preQualificationTemplateDependentTest==null)
				{
					_preQualificationTemplateDependentTest = new EntityCollection<PreQualificationTemplateDependentTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTemplateDependentTestEntityFactory)));
					_preQualificationTemplateDependentTest.SetContainingEntityInfo(this, "Test");
				}
				return _preQualificationTemplateDependentTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PreQualificationTestTemplateEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PreQualificationTestTemplateEntity))]
		public virtual EntityCollection<PreQualificationTestTemplateEntity> PreQualificationTestTemplate
		{
			get
			{
				if(_preQualificationTestTemplate==null)
				{
					_preQualificationTestTemplate = new EntityCollection<PreQualificationTestTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTestTemplateEntityFactory)));
					_preQualificationTestTemplate.SetContainingEntityInfo(this, "Test");
				}
				return _preQualificationTestTemplate;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectActivityEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectActivityEntity))]
		public virtual EntityCollection<ProspectActivityEntity> ProspectActivity
		{
			get
			{
				if(_prospectActivity==null)
				{
					_prospectActivity = new EntityCollection<ProspectActivityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectActivityEntityFactory)));
					_prospectActivity.SetContainingEntityInfo(this, "Test");
				}
				return _prospectActivity;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RequiredTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RequiredTestEntity))]
		public virtual EntityCollection<RequiredTestEntity> RequiredTest
		{
			get
			{
				if(_requiredTest==null)
				{
					_requiredTest = new EntityCollection<RequiredTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RequiredTestEntityFactory)));
					_requiredTest.SetContainingEntityInfo(this, "Test");
				}
				return _requiredTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ResultArchiveUploadLogEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ResultArchiveUploadLogEntity))]
		public virtual EntityCollection<ResultArchiveUploadLogEntity> ResultArchiveUploadLog
		{
			get
			{
				if(_resultArchiveUploadLog==null)
				{
					_resultArchiveUploadLog = new EntityCollection<ResultArchiveUploadLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ResultArchiveUploadLogEntityFactory)));
					_resultArchiveUploadLog.SetContainingEntityInfo(this, "Test");
				}
				return _resultArchiveUploadLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'StaffEventRoleTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(StaffEventRoleTestEntity))]
		public virtual EntityCollection<StaffEventRoleTestEntity> StaffEventRoleTest
		{
			get
			{
				if(_staffEventRoleTest==null)
				{
					_staffEventRoleTest = new EntityCollection<StaffEventRoleTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StaffEventRoleTestEntityFactory)));
					_staffEventRoleTest.SetContainingEntityInfo(this, "Test");
				}
				return _staffEventRoleTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'StandardFindingTestReadingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(StandardFindingTestReadingEntity))]
		public virtual EntityCollection<StandardFindingTestReadingEntity> StandardFindingTestReading
		{
			get
			{
				if(_standardFindingTestReading==null)
				{
					_standardFindingTestReading = new EntityCollection<StandardFindingTestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StandardFindingTestReadingEntityFactory)));
					_standardFindingTestReading.SetContainingEntityInfo(this, "Test");
				}
				return _standardFindingTestReading;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestDependencyRuleEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestDependencyRuleEntity))]
		public virtual EntityCollection<TestDependencyRuleEntity> TestDependencyRule
		{
			get
			{
				if(_testDependencyRule==null)
				{
					_testDependencyRule = new EntityCollection<TestDependencyRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestDependencyRuleEntityFactory)));
					_testDependencyRule.SetContainingEntityInfo(this, "Test");
				}
				return _testDependencyRule;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestDependencyRuleEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestDependencyRuleEntity))]
		public virtual EntityCollection<TestDependencyRuleEntity> TestDependencyRule_
		{
			get
			{
				if(_testDependencyRule_==null)
				{
					_testDependencyRule_ = new EntityCollection<TestDependencyRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestDependencyRuleEntityFactory)));
					_testDependencyRule_.SetContainingEntityInfo(this, "Test_");
				}
				return _testDependencyRule_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestHcpcsCodeEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestHcpcsCodeEntity))]
		public virtual EntityCollection<TestHcpcsCodeEntity> TestHcpcsCode
		{
			get
			{
				if(_testHcpcsCode==null)
				{
					_testHcpcsCode = new EntityCollection<TestHcpcsCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestHcpcsCodeEntityFactory)));
					_testHcpcsCode.SetContainingEntityInfo(this, "Test");
				}
				return _testHcpcsCode;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestIncidentalFindingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestIncidentalFindingEntity))]
		public virtual EntityCollection<TestIncidentalFindingEntity> TestIncidentalFinding
		{
			get
			{
				if(_testIncidentalFinding==null)
				{
					_testIncidentalFinding = new EntityCollection<TestIncidentalFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestIncidentalFindingEntityFactory)));
					_testIncidentalFinding.SetContainingEntityInfo(this, "Test");
				}
				return _testIncidentalFinding;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestReadingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestReadingEntity))]
		public virtual EntityCollection<TestReadingEntity> TestReading
		{
			get
			{
				if(_testReading==null)
				{
					_testReading = new EntityCollection<TestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestReadingEntityFactory)));
					_testReading.SetContainingEntityInfo(this, "Test");
				}
				return _testReading;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestSourceCodeDiscountEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestSourceCodeDiscountEntity))]
		public virtual EntityCollection<TestSourceCodeDiscountEntity> TestSourceCodeDiscount
		{
			get
			{
				if(_testSourceCodeDiscount==null)
				{
					_testSourceCodeDiscount = new EntityCollection<TestSourceCodeDiscountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestSourceCodeDiscountEntityFactory)));
					_testSourceCodeDiscount.SetContainingEntityInfo(this, "Test");
				}
				return _testSourceCodeDiscount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestUnableScreenReasonEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestUnableScreenReasonEntity))]
		public virtual EntityCollection<TestUnableScreenReasonEntity> TestUnableScreenReason
		{
			get
			{
				if(_testUnableScreenReason==null)
				{
					_testUnableScreenReason = new EntityCollection<TestUnableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestUnableScreenReasonEntityFactory)));
					_testUnableScreenReason.SetContainingEntityInfo(this, "Test");
				}
				return _testUnableScreenReason;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountEntity))]
		public virtual EntityCollection<AccountEntity> AccountCollectionViaAccountPcpResultTestDependency
		{
			get
			{
				if(_accountCollectionViaAccountPcpResultTestDependency==null)
				{
					_accountCollectionViaAccountPcpResultTestDependency = new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory)));
					_accountCollectionViaAccountPcpResultTestDependency.IsReadOnly=true;
				}
				return _accountCollectionViaAccountPcpResultTestDependency;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountEntity))]
		public virtual EntityCollection<AccountEntity> AccountCollectionViaAccountTest
		{
			get
			{
				if(_accountCollectionViaAccountTest==null)
				{
					_accountCollectionViaAccountTest = new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory)));
					_accountCollectionViaAccountTest.IsReadOnly=true;
				}
				return _accountCollectionViaAccountTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountEntity))]
		public virtual EntityCollection<AccountEntity> AccountCollectionViaAccountNotReviewableTest
		{
			get
			{
				if(_accountCollectionViaAccountNotReviewableTest==null)
				{
					_accountCollectionViaAccountNotReviewableTest = new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory)));
					_accountCollectionViaAccountNotReviewableTest.IsReadOnly=true;
				}
				return _accountCollectionViaAccountNotReviewableTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountEntity))]
		public virtual EntityCollection<AccountEntity> AccountCollectionViaAccountCustomerResultTestDependency
		{
			get
			{
				if(_accountCollectionViaAccountCustomerResultTestDependency==null)
				{
					_accountCollectionViaAccountCustomerResultTestDependency = new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory)));
					_accountCollectionViaAccountCustomerResultTestDependency.IsReadOnly=true;
				}
				return _accountCollectionViaAccountCustomerResultTestDependency;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountEntity))]
		public virtual EntityCollection<AccountEntity> AccountCollectionViaAccountHealthPlanResultTestDependency
		{
			get
			{
				if(_accountCollectionViaAccountHealthPlanResultTestDependency==null)
				{
					_accountCollectionViaAccountHealthPlanResultTestDependency = new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory)));
					_accountCollectionViaAccountHealthPlanResultTestDependency.IsReadOnly=true;
				}
				return _accountCollectionViaAccountHealthPlanResultTestDependency;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BillingAccountEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BillingAccountEntity))]
		public virtual EntityCollection<BillingAccountEntity> BillingAccountCollectionViaBillingAccountTest
		{
			get
			{
				if(_billingAccountCollectionViaBillingAccountTest==null)
				{
					_billingAccountCollectionViaBillingAccountTest = new EntityCollection<BillingAccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BillingAccountEntityFactory)));
					_billingAccountCollectionViaBillingAccountTest.IsReadOnly=true;
				}
				return _billingAccountCollectionViaBillingAccountTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CouponsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CouponsEntity))]
		public virtual EntityCollection<CouponsEntity> CouponsCollectionViaTestSourceCodeDiscount
		{
			get
			{
				if(_couponsCollectionViaTestSourceCodeDiscount==null)
				{
					_couponsCollectionViaTestSourceCodeDiscount = new EntityCollection<CouponsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouponsEntityFactory)));
					_couponsCollectionViaTestSourceCodeDiscount.IsReadOnly=true;
				}
				return _couponsCollectionViaTestSourceCodeDiscount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerHealthQuestionsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerHealthQuestionsEntity))]
		public virtual EntityCollection<CustomerHealthQuestionsEntity> CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_
		{
			get
			{
				if(_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_==null)
				{
					_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_ = new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory)));
					_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_.IsReadOnly=true;
				}
				return _customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerHealthQuestionsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerHealthQuestionsEntity))]
		public virtual EntityCollection<CustomerHealthQuestionsEntity> CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria
		{
			get
			{
				if(_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria==null)
				{
					_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria = new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory)));
					_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria.IsReadOnly=true;
				}
				return _customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria;
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
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCustomerEventTestFinding
		{
			get
			{
				if(_customerProfileCollectionViaCustomerEventTestFinding==null)
				{
					_customerProfileCollectionViaCustomerEventTestFinding = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCustomerEventTestFinding.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCustomerEventTestFinding;
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
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaResultArchiveUploadLog
		{
			get
			{
				if(_customerProfileCollectionViaResultArchiveUploadLog==null)
				{
					_customerProfileCollectionViaResultArchiveUploadLog = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaResultArchiveUploadLog.IsReadOnly=true;
				}
				return _customerProfileCollectionViaResultArchiveUploadLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaRequiredTest
		{
			get
			{
				if(_customerProfileCollectionViaRequiredTest==null)
				{
					_customerProfileCollectionViaRequiredTest = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaRequiredTest.IsReadOnly=true;
				}
				return _customerProfileCollectionViaRequiredTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerResultEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerResultEntity))]
		public virtual EntityCollection<EventCustomerResultEntity> EventCustomerResultCollectionViaKynLabValues
		{
			get
			{
				if(_eventCustomerResultCollectionViaKynLabValues==null)
				{
					_eventCustomerResultCollectionViaKynLabValues = new EntityCollection<EventCustomerResultEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerResultEntityFactory)));
					_eventCustomerResultCollectionViaKynLabValues.IsReadOnly=true;
				}
				return _eventCustomerResultCollectionViaKynLabValues;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerResultEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerResultEntity))]
		public virtual EntityCollection<EventCustomerResultEntity> EventCustomerResultCollectionViaCustomerEventScreeningTests
		{
			get
			{
				if(_eventCustomerResultCollectionViaCustomerEventScreeningTests==null)
				{
					_eventCustomerResultCollectionViaCustomerEventScreeningTests = new EntityCollection<EventCustomerResultEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerResultEntityFactory)));
					_eventCustomerResultCollectionViaCustomerEventScreeningTests.IsReadOnly=true;
				}
				return _eventCustomerResultCollectionViaCustomerEventScreeningTests;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaDisqualifiedTest
		{
			get
			{
				if(_eventCustomersCollectionViaDisqualifiedTest==null)
				{
					_eventCustomersCollectionViaDisqualifiedTest = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaDisqualifiedTest.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaDisqualifiedTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaEventCustomerPreApprovedTest
		{
			get
			{
				if(_eventCustomersCollectionViaEventCustomerPreApprovedTest==null)
				{
					_eventCustomersCollectionViaEventCustomerPreApprovedTest = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaEventCustomerPreApprovedTest.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaEventCustomerPreApprovedTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaEventCustomerPreApprovedPackageTest
		{
			get
			{
				if(_eventCustomersCollectionViaEventCustomerPreApprovedPackageTest==null)
				{
					_eventCustomersCollectionViaEventCustomerPreApprovedPackageTest = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaEventCustomerPreApprovedPackageTest.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaEventCustomerPreApprovedPackageTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaEventCustomerRequiredTest
		{
			get
			{
				if(_eventCustomersCollectionViaEventCustomerRequiredTest==null)
				{
					_eventCustomersCollectionViaEventCustomerRequiredTest = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaEventCustomerRequiredTest.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaEventCustomerRequiredTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaEventCustomerTestNotPerformedNotification
		{
			get
			{
				if(_eventCustomersCollectionViaEventCustomerTestNotPerformedNotification==null)
				{
					_eventCustomersCollectionViaEventCustomerTestNotPerformedNotification = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaEventCustomerTestNotPerformedNotification.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaEventCustomerTestNotPerformedNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaDependentDisqualifiedTest
		{
			get
			{
				if(_eventCustomersCollectionViaDependentDisqualifiedTest==null)
				{
					_eventCustomersCollectionViaDependentDisqualifiedTest = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaDependentDisqualifiedTest.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaDependentDisqualifiedTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaEventCustomerRetest
		{
			get
			{
				if(_eventCustomersCollectionViaEventCustomerRetest==null)
				{
					_eventCustomersCollectionViaEventCustomerRetest = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaEventCustomerRetest.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaEventCustomerRetest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventPodRoomEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventPodRoomEntity))]
		public virtual EntityCollection<EventPodRoomEntity> EventPodRoomCollectionViaEventPodRoomTest
		{
			get
			{
				if(_eventPodRoomCollectionViaEventPodRoomTest==null)
				{
					_eventPodRoomCollectionViaEventPodRoomTest = new EntityCollection<EventPodRoomEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPodRoomEntityFactory)));
					_eventPodRoomCollectionViaEventPodRoomTest.IsReadOnly=true;
				}
				return _eventPodRoomCollectionViaEventPodRoomTest;
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
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventPhysicianTest
		{
			get
			{
				if(_eventsCollectionViaEventPhysicianTest==null)
				{
					_eventsCollectionViaEventPhysicianTest = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventPhysicianTest.IsReadOnly=true;
				}
				return _eventsCollectionViaEventPhysicianTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventTest
		{
			get
			{
				if(_eventsCollectionViaEventTest==null)
				{
					_eventsCollectionViaEventTest = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventTest.IsReadOnly=true;
				}
				return _eventsCollectionViaEventTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaCustomerEventTestFinding
		{
			get
			{
				if(_eventsCollectionViaCustomerEventTestFinding==null)
				{
					_eventsCollectionViaCustomerEventTestFinding = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaCustomerEventTestFinding.IsReadOnly=true;
				}
				return _eventsCollectionViaCustomerEventTestFinding;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HafTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HafTemplateEntity))]
		public virtual EntityCollection<HafTemplateEntity> HafTemplateCollectionViaClinicalTestQualificationCriteria
		{
			get
			{
				if(_hafTemplateCollectionViaClinicalTestQualificationCriteria==null)
				{
					_hafTemplateCollectionViaClinicalTestQualificationCriteria = new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory)));
					_hafTemplateCollectionViaClinicalTestQualificationCriteria.IsReadOnly=true;
				}
				return _hafTemplateCollectionViaClinicalTestQualificationCriteria;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HafTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HafTemplateEntity))]
		public virtual EntityCollection<HafTemplateEntity> HafTemplateCollectionViaEventTest
		{
			get
			{
				if(_hafTemplateCollectionViaEventTest==null)
				{
					_hafTemplateCollectionViaEventTest = new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory)));
					_hafTemplateCollectionViaEventTest.IsReadOnly=true;
				}
				return _hafTemplateCollectionViaEventTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HcpcsCodeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HcpcsCodeEntity))]
		public virtual EntityCollection<HcpcsCodeEntity> HcpcsCodeCollectionViaTestHcpcsCode
		{
			get
			{
				if(_hcpcsCodeCollectionViaTestHcpcsCode==null)
				{
					_hcpcsCodeCollectionViaTestHcpcsCode = new EntityCollection<HcpcsCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HcpcsCodeEntityFactory)));
					_hcpcsCodeCollectionViaTestHcpcsCode.IsReadOnly=true;
				}
				return _hcpcsCodeCollectionViaTestHcpcsCode;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HealthPlanRevenueEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HealthPlanRevenueEntity))]
		public virtual EntityCollection<HealthPlanRevenueEntity> HealthPlanRevenueCollectionViaHealthPlanRevenueItem
		{
			get
			{
				if(_healthPlanRevenueCollectionViaHealthPlanRevenueItem==null)
				{
					_healthPlanRevenueCollectionViaHealthPlanRevenueItem = new EntityCollection<HealthPlanRevenueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanRevenueEntityFactory)));
					_healthPlanRevenueCollectionViaHealthPlanRevenueItem.IsReadOnly=true;
				}
				return _healthPlanRevenueCollectionViaHealthPlanRevenueItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'IncidentalFindingsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(IncidentalFindingsEntity))]
		public virtual EntityCollection<IncidentalFindingsEntity> IncidentalFindingsCollectionViaTestIncidentalFinding
		{
			get
			{
				if(_incidentalFindingsCollectionViaTestIncidentalFinding==null)
				{
					_incidentalFindingsCollectionViaTestIncidentalFinding = new EntityCollection<IncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingsEntityFactory)));
					_incidentalFindingsCollectionViaTestIncidentalFinding.IsReadOnly=true;
				}
				return _incidentalFindingsCollectionViaTestIncidentalFinding;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'InventoryItemEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(InventoryItemEntity))]
		public virtual EntityCollection<InventoryItemEntity> InventoryItemCollectionViaInventoryItemTest
		{
			get
			{
				if(_inventoryItemCollectionViaInventoryItemTest==null)
				{
					_inventoryItemCollectionViaInventoryItemTest = new EntityCollection<InventoryItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InventoryItemEntityFactory)));
					_inventoryItemCollectionViaInventoryItemTest.IsReadOnly=true;
				}
				return _inventoryItemCollectionViaInventoryItemTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaTestUnableScreenReason
		{
			get
			{
				if(_lookupCollectionViaTestUnableScreenReason==null)
				{
					_lookupCollectionViaTestUnableScreenReason = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaTestUnableScreenReason.IsReadOnly=true;
				}
				return _lookupCollectionViaTestUnableScreenReason;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEventTest_
		{
			get
			{
				if(_lookupCollectionViaEventTest_==null)
				{
					_lookupCollectionViaEventTest_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEventTest_.IsReadOnly=true;
				}
				return _lookupCollectionViaEventTest_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEventTest
		{
			get
			{
				if(_lookupCollectionViaEventTest==null)
				{
					_lookupCollectionViaEventTest = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEventTest.IsReadOnly=true;
				}
				return _lookupCollectionViaEventTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEventTest__
		{
			get
			{
				if(_lookupCollectionViaEventTest__==null)
				{
					_lookupCollectionViaEventTest__ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEventTest__.IsReadOnly=true;
				}
				return _lookupCollectionViaEventTest__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaClinicalTestQualificationCriteria
		{
			get
			{
				if(_lookupCollectionViaClinicalTestQualificationCriteria==null)
				{
					_lookupCollectionViaClinicalTestQualificationCriteria = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaClinicalTestQualificationCriteria.IsReadOnly=true;
				}
				return _lookupCollectionViaClinicalTestQualificationCriteria;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaPreQualificationQuestion
		{
			get
			{
				if(_lookupCollectionViaPreQualificationQuestion==null)
				{
					_lookupCollectionViaPreQualificationQuestion = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaPreQualificationQuestion.IsReadOnly=true;
				}
				return _lookupCollectionViaPreQualificationQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaClinicalTestQualificationCriteria_
		{
			get
			{
				if(_lookupCollectionViaClinicalTestQualificationCriteria_==null)
				{
					_lookupCollectionViaClinicalTestQualificationCriteria_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaClinicalTestQualificationCriteria_.IsReadOnly=true;
				}
				return _lookupCollectionViaClinicalTestQualificationCriteria_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaKynLabValues
		{
			get
			{
				if(_lookupCollectionViaKynLabValues==null)
				{
					_lookupCollectionViaKynLabValues = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaKynLabValues.IsReadOnly=true;
				}
				return _lookupCollectionViaKynLabValues;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'OrderItemEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrderItemEntity))]
		public virtual EntityCollection<OrderItemEntity> OrderItemCollectionViaProspectActivity
		{
			get
			{
				if(_orderItemCollectionViaProspectActivity==null)
				{
					_orderItemCollectionViaProspectActivity = new EntityCollection<OrderItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrderItemEntityFactory)));
					_orderItemCollectionViaProspectActivity.IsReadOnly=true;
				}
				return _orderItemCollectionViaProspectActivity;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaPreQualificationQuestion
		{
			get
			{
				if(_organizationRoleUserCollectionViaPreQualificationQuestion==null)
				{
					_organizationRoleUserCollectionViaPreQualificationQuestion = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaPreQualificationQuestion.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaPreQualificationQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaPreApprovedTest
		{
			get
			{
				if(_organizationRoleUserCollectionViaPreApprovedTest==null)
				{
					_organizationRoleUserCollectionViaPreApprovedTest = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaPreApprovedTest.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaPreApprovedTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaTestHcpcsCode
		{
			get
			{
				if(_organizationRoleUserCollectionViaTestHcpcsCode==null)
				{
					_organizationRoleUserCollectionViaTestHcpcsCode = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaTestHcpcsCode.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaTestHcpcsCode;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaTestHcpcsCode_
		{
			get
			{
				if(_organizationRoleUserCollectionViaTestHcpcsCode_==null)
				{
					_organizationRoleUserCollectionViaTestHcpcsCode_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaTestHcpcsCode_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaTestHcpcsCode_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaRequiredTest
		{
			get
			{
				if(_organizationRoleUserCollectionViaRequiredTest==null)
				{
					_organizationRoleUserCollectionViaRequiredTest = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaRequiredTest.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaRequiredTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaPreQualificationTestTemplate
		{
			get
			{
				if(_organizationRoleUserCollectionViaPreQualificationTestTemplate==null)
				{
					_organizationRoleUserCollectionViaPreQualificationTestTemplate = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaPreQualificationTestTemplate.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaPreQualificationTestTemplate;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaPreQualificationTestTemplate_
		{
			get
			{
				if(_organizationRoleUserCollectionViaPreQualificationTestTemplate_==null)
				{
					_organizationRoleUserCollectionViaPreQualificationTestTemplate_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaPreQualificationTestTemplate_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaPreQualificationTestTemplate_;
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
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria
		{
			get
			{
				if(_organizationRoleUserCollectionViaClinicalTestQualificationCriteria==null)
				{
					_organizationRoleUserCollectionViaClinicalTestQualificationCriteria = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaClinicalTestQualificationCriteria.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaClinicalTestQualificationCriteria;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventPhysicianTest__
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventPhysicianTest__==null)
				{
					_organizationRoleUserCollectionViaEventPhysicianTest__ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventPhysicianTest__.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventPhysicianTest__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_
		{
			get
			{
				if(_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_==null)
				{
					_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaClinicalTestQualificationCriteria_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventPhysicianTest
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventPhysicianTest==null)
				{
					_organizationRoleUserCollectionViaEventPhysicianTest = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventPhysicianTest.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventPhysicianTest;
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
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventPhysicianTest_
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventPhysicianTest_==null)
				{
					_organizationRoleUserCollectionViaEventPhysicianTest_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventPhysicianTest_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventPhysicianTest_;
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
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaKynLabValues
		{
			get
			{
				if(_organizationRoleUserCollectionViaKynLabValues==null)
				{
					_organizationRoleUserCollectionViaKynLabValues = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaKynLabValues.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaKynLabValues;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaKynLabValues_
		{
			get
			{
				if(_organizationRoleUserCollectionViaKynLabValues_==null)
				{
					_organizationRoleUserCollectionViaKynLabValues_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaKynLabValues_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaKynLabValues_;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'PackageEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PackageEntity))]
		public virtual EntityCollection<PackageEntity> PackageCollectionViaPackageTest
		{
			get
			{
				if(_packageCollectionViaPackageTest==null)
				{
					_packageCollectionViaPackageTest = new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory)));
					_packageCollectionViaPackageTest.IsReadOnly=true;
				}
				return _packageCollectionViaPackageTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PackageEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PackageEntity))]
		public virtual EntityCollection<PackageEntity> PackageCollectionViaHealthPlanRevenueItem
		{
			get
			{
				if(_packageCollectionViaHealthPlanRevenueItem==null)
				{
					_packageCollectionViaHealthPlanRevenueItem = new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory)));
					_packageCollectionViaHealthPlanRevenueItem.IsReadOnly=true;
				}
				return _packageCollectionViaHealthPlanRevenueItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianProfileEntity))]
		public virtual EntityCollection<PhysicianProfileEntity> PhysicianProfileCollectionViaPhysicianPermittedTest
		{
			get
			{
				if(_physicianProfileCollectionViaPhysicianPermittedTest==null)
				{
					_physicianProfileCollectionViaPhysicianPermittedTest = new EntityCollection<PhysicianProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianProfileEntityFactory)));
					_physicianProfileCollectionViaPhysicianPermittedTest.IsReadOnly=true;
				}
				return _physicianProfileCollectionViaPhysicianPermittedTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PodDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodDetailsEntity))]
		public virtual EntityCollection<PodDetailsEntity> PodDetailsCollectionViaPodTest
		{
			get
			{
				if(_podDetailsCollectionViaPodTest==null)
				{
					_podDetailsCollectionViaPodTest = new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory)));
					_podDetailsCollectionViaPodTest.IsReadOnly=true;
				}
				return _podDetailsCollectionViaPodTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PodRoomEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodRoomEntity))]
		public virtual EntityCollection<PodRoomEntity> PodRoomCollectionViaPodRoomTest
		{
			get
			{
				if(_podRoomCollectionViaPodRoomTest==null)
				{
					_podRoomCollectionViaPodRoomTest = new EntityCollection<PodRoomEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodRoomEntityFactory)));
					_podRoomCollectionViaPodRoomTest.IsReadOnly=true;
				}
				return _podRoomCollectionViaPodRoomTest;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'PreQualificationTestTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PreQualificationTestTemplateEntity))]
		public virtual EntityCollection<PreQualificationTestTemplateEntity> PreQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest
		{
			get
			{
				if(_preQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest==null)
				{
					_preQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest = new EntityCollection<PreQualificationTestTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTestTemplateEntityFactory)));
					_preQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest.IsReadOnly=true;
				}
				return _preQualificationTestTemplateCollectionViaPreQualificationTemplateDependentTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PreQualificationTestTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PreQualificationTestTemplateEntity))]
		public virtual EntityCollection<PreQualificationTestTemplateEntity> PreQualificationTestTemplateCollectionViaEventTest
		{
			get
			{
				if(_preQualificationTestTemplateCollectionViaEventTest==null)
				{
					_preQualificationTestTemplateCollectionViaEventTest = new EntityCollection<PreQualificationTestTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTestTemplateEntityFactory)));
					_preQualificationTestTemplateCollectionViaEventTest.IsReadOnly=true;
				}
				return _preQualificationTestTemplateCollectionViaEventTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ReadingEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ReadingEntity))]
		public virtual EntityCollection<ReadingEntity> ReadingCollectionViaTestReading
		{
			get
			{
				if(_readingCollectionViaTestReading==null)
				{
					_readingCollectionViaTestReading = new EntityCollection<ReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReadingEntityFactory)));
					_readingCollectionViaTestReading.IsReadOnly=true;
				}
				return _readingCollectionViaTestReading;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ReadingEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ReadingEntity))]
		public virtual EntityCollection<ReadingEntity> ReadingCollectionViaStandardFindingTestReading
		{
			get
			{
				if(_readingCollectionViaStandardFindingTestReading==null)
				{
					_readingCollectionViaStandardFindingTestReading = new EntityCollection<ReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReadingEntityFactory)));
					_readingCollectionViaStandardFindingTestReading.IsReadOnly=true;
				}
				return _readingCollectionViaStandardFindingTestReading;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ResultArchiveUploadEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ResultArchiveUploadEntity))]
		public virtual EntityCollection<ResultArchiveUploadEntity> ResultArchiveUploadCollectionViaResultArchiveUploadLog
		{
			get
			{
				if(_resultArchiveUploadCollectionViaResultArchiveUploadLog==null)
				{
					_resultArchiveUploadCollectionViaResultArchiveUploadLog = new EntityCollection<ResultArchiveUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ResultArchiveUploadEntityFactory)));
					_resultArchiveUploadCollectionViaResultArchiveUploadLog.IsReadOnly=true;
				}
				return _resultArchiveUploadCollectionViaResultArchiveUploadLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'StaffEventRoleEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(StaffEventRoleEntity))]
		public virtual EntityCollection<StaffEventRoleEntity> StaffEventRoleCollectionViaStaffEventRoleTest
		{
			get
			{
				if(_staffEventRoleCollectionViaStaffEventRoleTest==null)
				{
					_staffEventRoleCollectionViaStaffEventRoleTest = new EntityCollection<StaffEventRoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StaffEventRoleEntityFactory)));
					_staffEventRoleCollectionViaStaffEventRoleTest.IsReadOnly=true;
				}
				return _staffEventRoleCollectionViaStaffEventRoleTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'StandardFindingEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(StandardFindingEntity))]
		public virtual EntityCollection<StandardFindingEntity> StandardFindingCollectionViaStandardFindingTestReading
		{
			get
			{
				if(_standardFindingCollectionViaStandardFindingTestReading==null)
				{
					_standardFindingCollectionViaStandardFindingTestReading = new EntityCollection<StandardFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StandardFindingEntityFactory)));
					_standardFindingCollectionViaStandardFindingTestReading.IsReadOnly=true;
				}
				return _standardFindingCollectionViaStandardFindingTestReading;
			}
		}

		/// <summary> Gets / sets related entity of type 'HafTemplateEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual HafTemplateEntity HafTemplate
		{
			get
			{
				return _hafTemplate;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncHafTemplate(value);
				}
				else
				{
					if(value==null)
					{
						if(_hafTemplate != null)
						{
							_hafTemplate.UnsetRelatedEntity(this, "Test");
						}
					}
					else
					{
						if(_hafTemplate!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Test");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup__
		{
			get
			{
				return _lookup__;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup__(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup__ != null)
						{
							_lookup__.UnsetRelatedEntity(this, "Test__");
						}
					}
					else
					{
						if(_lookup__!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Test__");
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
							_lookup_.UnsetRelatedEntity(this, "Test_");
						}
					}
					else
					{
						if(_lookup_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Test_");
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
							_lookup.UnsetRelatedEntity(this, "Test");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Test");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'PreQualificationTestTemplateEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual PreQualificationTestTemplateEntity PreQualificationTestTemplate_
		{
			get
			{
				return _preQualificationTestTemplate_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncPreQualificationTestTemplate_(value);
				}
				else
				{
					if(value==null)
					{
						if(_preQualificationTestTemplate_ != null)
						{
							_preQualificationTestTemplate_.UnsetRelatedEntity(this, "Test_");
						}
					}
					else
					{
						if(_preQualificationTestTemplate_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Test_");
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
			get { return (int)Falcon.Data.EntityType.TestEntity; }
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
