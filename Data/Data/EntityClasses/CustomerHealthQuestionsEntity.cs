///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:48
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
	/// Entity class which represents the entity 'CustomerHealthQuestions'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CustomerHealthQuestionsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ClinicalTestQualificationCriteriaEntity> _clinicalTestQualificationCriteria_;
		private EntityCollection<ClinicalTestQualificationCriteriaEntity> _clinicalTestQualificationCriteria;
		private EntityCollection<CustomerClinicalQuestionAnswerEntity> _customerClinicalQuestionAnswer;
		private EntityCollection<CustomerHealthInfoEntity> _customerHealthInfo;
		private EntityCollection<CustomerHealthInfoArchiveEntity> _customerHealthInfoArchive;
		private EntityCollection<CustomerHealthQuestionsEntity> _customerHealthQuestions_;
		private EntityCollection<HafTemplateQuestionEntity> _hafTemplateQuestion;
		private EntityCollection<HealthQuestionDependencyRuleEntity> _healthQuestionDependencyRule_;
		private EntityCollection<HealthQuestionDependencyRuleEntity> _healthQuestionDependencyRule;
		private EntityCollection<MedicalHistoryReadingAssosciationEntity> _medicalHistoryReadingAssosciation;
		private EntityCollection<CustomerHealthQuestionGroupEntity> _customerHealthQuestionGroupCollectionViaCustomerHealthQuestions;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerHealthInfo;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerClinicalQuestionAnswer;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerHealthInfoArchive;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaCustomerHealthInfoArchive;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaCustomerHealthInfo;
		private EntityCollection<EventsEntity> _eventsCollectionViaCustomerClinicalQuestionAnswer;
		private EntityCollection<HafTemplateEntity> _hafTemplateCollectionViaHafTemplateQuestion;
		private EntityCollection<HafTemplateEntity> _hafTemplateCollectionViaClinicalTestQualificationCriteria;
		private EntityCollection<HafTemplateEntity> _hafTemplateCollectionViaCustomerClinicalQuestionAnswer;
		private EntityCollection<HafTemplateEntity> _hafTemplateCollectionViaClinicalTestQualificationCriteria_;
		private EntityCollection<LookupEntity> _lookupCollectionViaClinicalTestQualificationCriteria__;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerHealthQuestions;
		private EntityCollection<LookupEntity> _lookupCollectionViaClinicalTestQualificationCriteria___;
		private EntityCollection<LookupEntity> _lookupCollectionViaClinicalTestQualificationCriteria;
		private EntityCollection<LookupEntity> _lookupCollectionViaClinicalTestQualificationCriteria_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaClinicalTestQualificationCriteria_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaClinicalTestQualificationCriteria___;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerHealthInfoArchive;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaClinicalTestQualificationCriteria;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaClinicalTestQualificationCriteria__;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerHealthInfo;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_;
		private EntityCollection<ReadingEntity> _readingCollectionViaMedicalHistoryReadingAssosciation;
		private EntityCollection<TestEntity> _testCollectionViaClinicalTestQualificationCriteria;
		private EntityCollection<TestEntity> _testCollectionViaClinicalTestQualificationCriteria_;
		private CustomerHealthQuestionGroupEntity _customerHealthQuestionGroup;
		private CustomerHealthQuestionsEntity _customerHealthQuestions;
		private LookupEntity _lookup;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CustomerHealthQuestionGroup</summary>
			public static readonly string CustomerHealthQuestionGroup = "CustomerHealthQuestionGroup";
			/// <summary>Member name CustomerHealthQuestions</summary>
			public static readonly string CustomerHealthQuestions = "CustomerHealthQuestions";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name ClinicalTestQualificationCriteria_</summary>
			public static readonly string ClinicalTestQualificationCriteria_ = "ClinicalTestQualificationCriteria_";
			/// <summary>Member name ClinicalTestQualificationCriteria</summary>
			public static readonly string ClinicalTestQualificationCriteria = "ClinicalTestQualificationCriteria";
			/// <summary>Member name CustomerClinicalQuestionAnswer</summary>
			public static readonly string CustomerClinicalQuestionAnswer = "CustomerClinicalQuestionAnswer";
			/// <summary>Member name CustomerHealthInfo</summary>
			public static readonly string CustomerHealthInfo = "CustomerHealthInfo";
			/// <summary>Member name CustomerHealthInfoArchive</summary>
			public static readonly string CustomerHealthInfoArchive = "CustomerHealthInfoArchive";
			/// <summary>Member name CustomerHealthQuestions_</summary>
			public static readonly string CustomerHealthQuestions_ = "CustomerHealthQuestions_";
			/// <summary>Member name HafTemplateQuestion</summary>
			public static readonly string HafTemplateQuestion = "HafTemplateQuestion";
			/// <summary>Member name HealthQuestionDependencyRule_</summary>
			public static readonly string HealthQuestionDependencyRule_ = "HealthQuestionDependencyRule_";
			/// <summary>Member name HealthQuestionDependencyRule</summary>
			public static readonly string HealthQuestionDependencyRule = "HealthQuestionDependencyRule";
			/// <summary>Member name MedicalHistoryReadingAssosciation</summary>
			public static readonly string MedicalHistoryReadingAssosciation = "MedicalHistoryReadingAssosciation";
			/// <summary>Member name CustomerHealthQuestionGroupCollectionViaCustomerHealthQuestions</summary>
			public static readonly string CustomerHealthQuestionGroupCollectionViaCustomerHealthQuestions = "CustomerHealthQuestionGroupCollectionViaCustomerHealthQuestions";
			/// <summary>Member name CustomerProfileCollectionViaCustomerHealthInfo</summary>
			public static readonly string CustomerProfileCollectionViaCustomerHealthInfo = "CustomerProfileCollectionViaCustomerHealthInfo";
			/// <summary>Member name CustomerProfileCollectionViaCustomerClinicalQuestionAnswer</summary>
			public static readonly string CustomerProfileCollectionViaCustomerClinicalQuestionAnswer = "CustomerProfileCollectionViaCustomerClinicalQuestionAnswer";
			/// <summary>Member name CustomerProfileCollectionViaCustomerHealthInfoArchive</summary>
			public static readonly string CustomerProfileCollectionViaCustomerHealthInfoArchive = "CustomerProfileCollectionViaCustomerHealthInfoArchive";
			/// <summary>Member name EventCustomersCollectionViaCustomerHealthInfoArchive</summary>
			public static readonly string EventCustomersCollectionViaCustomerHealthInfoArchive = "EventCustomersCollectionViaCustomerHealthInfoArchive";
			/// <summary>Member name EventCustomersCollectionViaCustomerHealthInfo</summary>
			public static readonly string EventCustomersCollectionViaCustomerHealthInfo = "EventCustomersCollectionViaCustomerHealthInfo";
			/// <summary>Member name EventsCollectionViaCustomerClinicalQuestionAnswer</summary>
			public static readonly string EventsCollectionViaCustomerClinicalQuestionAnswer = "EventsCollectionViaCustomerClinicalQuestionAnswer";
			/// <summary>Member name HafTemplateCollectionViaHafTemplateQuestion</summary>
			public static readonly string HafTemplateCollectionViaHafTemplateQuestion = "HafTemplateCollectionViaHafTemplateQuestion";
			/// <summary>Member name HafTemplateCollectionViaClinicalTestQualificationCriteria</summary>
			public static readonly string HafTemplateCollectionViaClinicalTestQualificationCriteria = "HafTemplateCollectionViaClinicalTestQualificationCriteria";
			/// <summary>Member name HafTemplateCollectionViaCustomerClinicalQuestionAnswer</summary>
			public static readonly string HafTemplateCollectionViaCustomerClinicalQuestionAnswer = "HafTemplateCollectionViaCustomerClinicalQuestionAnswer";
			/// <summary>Member name HafTemplateCollectionViaClinicalTestQualificationCriteria_</summary>
			public static readonly string HafTemplateCollectionViaClinicalTestQualificationCriteria_ = "HafTemplateCollectionViaClinicalTestQualificationCriteria_";
			/// <summary>Member name LookupCollectionViaClinicalTestQualificationCriteria__</summary>
			public static readonly string LookupCollectionViaClinicalTestQualificationCriteria__ = "LookupCollectionViaClinicalTestQualificationCriteria__";
			/// <summary>Member name LookupCollectionViaCustomerHealthQuestions</summary>
			public static readonly string LookupCollectionViaCustomerHealthQuestions = "LookupCollectionViaCustomerHealthQuestions";
			/// <summary>Member name LookupCollectionViaClinicalTestQualificationCriteria___</summary>
			public static readonly string LookupCollectionViaClinicalTestQualificationCriteria___ = "LookupCollectionViaClinicalTestQualificationCriteria___";
			/// <summary>Member name LookupCollectionViaClinicalTestQualificationCriteria</summary>
			public static readonly string LookupCollectionViaClinicalTestQualificationCriteria = "LookupCollectionViaClinicalTestQualificationCriteria";
			/// <summary>Member name LookupCollectionViaClinicalTestQualificationCriteria_</summary>
			public static readonly string LookupCollectionViaClinicalTestQualificationCriteria_ = "LookupCollectionViaClinicalTestQualificationCriteria_";
			/// <summary>Member name OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_</summary>
			public static readonly string OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_ = "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_";
			/// <summary>Member name OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria___</summary>
			public static readonly string OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria___ = "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria___";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerHealthInfoArchive</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerHealthInfoArchive = "OrganizationRoleUserCollectionViaCustomerHealthInfoArchive";
			/// <summary>Member name OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria</summary>
			public static readonly string OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria = "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer = "OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer";
			/// <summary>Member name OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria__</summary>
			public static readonly string OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria__ = "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria__";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerHealthInfo</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerHealthInfo = "OrganizationRoleUserCollectionViaCustomerHealthInfo";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_ = "OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_";
			/// <summary>Member name ReadingCollectionViaMedicalHistoryReadingAssosciation</summary>
			public static readonly string ReadingCollectionViaMedicalHistoryReadingAssosciation = "ReadingCollectionViaMedicalHistoryReadingAssosciation";
			/// <summary>Member name TestCollectionViaClinicalTestQualificationCriteria</summary>
			public static readonly string TestCollectionViaClinicalTestQualificationCriteria = "TestCollectionViaClinicalTestQualificationCriteria";
			/// <summary>Member name TestCollectionViaClinicalTestQualificationCriteria_</summary>
			public static readonly string TestCollectionViaClinicalTestQualificationCriteria_ = "TestCollectionViaClinicalTestQualificationCriteria_";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CustomerHealthQuestionsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CustomerHealthQuestionsEntity():base("CustomerHealthQuestionsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CustomerHealthQuestionsEntity(IEntityFields2 fields):base("CustomerHealthQuestionsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CustomerHealthQuestionsEntity</param>
		public CustomerHealthQuestionsEntity(IValidator validator):base("CustomerHealthQuestionsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="customerHealthQuestionId">PK value for CustomerHealthQuestions which data should be fetched into this CustomerHealthQuestions object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CustomerHealthQuestionsEntity(System.Int64 customerHealthQuestionId):base("CustomerHealthQuestionsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CustomerHealthQuestionId = customerHealthQuestionId;
		}

		/// <summary> CTor</summary>
		/// <param name="customerHealthQuestionId">PK value for CustomerHealthQuestions which data should be fetched into this CustomerHealthQuestions object</param>
		/// <param name="validator">The custom validator object for this CustomerHealthQuestionsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CustomerHealthQuestionsEntity(System.Int64 customerHealthQuestionId, IValidator validator):base("CustomerHealthQuestionsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CustomerHealthQuestionId = customerHealthQuestionId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CustomerHealthQuestionsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_clinicalTestQualificationCriteria_ = (EntityCollection<ClinicalTestQualificationCriteriaEntity>)info.GetValue("_clinicalTestQualificationCriteria_", typeof(EntityCollection<ClinicalTestQualificationCriteriaEntity>));
				_clinicalTestQualificationCriteria = (EntityCollection<ClinicalTestQualificationCriteriaEntity>)info.GetValue("_clinicalTestQualificationCriteria", typeof(EntityCollection<ClinicalTestQualificationCriteriaEntity>));
				_customerClinicalQuestionAnswer = (EntityCollection<CustomerClinicalQuestionAnswerEntity>)info.GetValue("_customerClinicalQuestionAnswer", typeof(EntityCollection<CustomerClinicalQuestionAnswerEntity>));
				_customerHealthInfo = (EntityCollection<CustomerHealthInfoEntity>)info.GetValue("_customerHealthInfo", typeof(EntityCollection<CustomerHealthInfoEntity>));
				_customerHealthInfoArchive = (EntityCollection<CustomerHealthInfoArchiveEntity>)info.GetValue("_customerHealthInfoArchive", typeof(EntityCollection<CustomerHealthInfoArchiveEntity>));
				_customerHealthQuestions_ = (EntityCollection<CustomerHealthQuestionsEntity>)info.GetValue("_customerHealthQuestions_", typeof(EntityCollection<CustomerHealthQuestionsEntity>));
				_hafTemplateQuestion = (EntityCollection<HafTemplateQuestionEntity>)info.GetValue("_hafTemplateQuestion", typeof(EntityCollection<HafTemplateQuestionEntity>));
				_healthQuestionDependencyRule_ = (EntityCollection<HealthQuestionDependencyRuleEntity>)info.GetValue("_healthQuestionDependencyRule_", typeof(EntityCollection<HealthQuestionDependencyRuleEntity>));
				_healthQuestionDependencyRule = (EntityCollection<HealthQuestionDependencyRuleEntity>)info.GetValue("_healthQuestionDependencyRule", typeof(EntityCollection<HealthQuestionDependencyRuleEntity>));
				_medicalHistoryReadingAssosciation = (EntityCollection<MedicalHistoryReadingAssosciationEntity>)info.GetValue("_medicalHistoryReadingAssosciation", typeof(EntityCollection<MedicalHistoryReadingAssosciationEntity>));
				_customerHealthQuestionGroupCollectionViaCustomerHealthQuestions = (EntityCollection<CustomerHealthQuestionGroupEntity>)info.GetValue("_customerHealthQuestionGroupCollectionViaCustomerHealthQuestions", typeof(EntityCollection<CustomerHealthQuestionGroupEntity>));
				_customerProfileCollectionViaCustomerHealthInfo = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerHealthInfo", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaCustomerClinicalQuestionAnswer = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerClinicalQuestionAnswer", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaCustomerHealthInfoArchive = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerHealthInfoArchive", typeof(EntityCollection<CustomerProfileEntity>));
				_eventCustomersCollectionViaCustomerHealthInfoArchive = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaCustomerHealthInfoArchive", typeof(EntityCollection<EventCustomersEntity>));
				_eventCustomersCollectionViaCustomerHealthInfo = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaCustomerHealthInfo", typeof(EntityCollection<EventCustomersEntity>));
				_eventsCollectionViaCustomerClinicalQuestionAnswer = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaCustomerClinicalQuestionAnswer", typeof(EntityCollection<EventsEntity>));
				_hafTemplateCollectionViaHafTemplateQuestion = (EntityCollection<HafTemplateEntity>)info.GetValue("_hafTemplateCollectionViaHafTemplateQuestion", typeof(EntityCollection<HafTemplateEntity>));
				_hafTemplateCollectionViaClinicalTestQualificationCriteria = (EntityCollection<HafTemplateEntity>)info.GetValue("_hafTemplateCollectionViaClinicalTestQualificationCriteria", typeof(EntityCollection<HafTemplateEntity>));
				_hafTemplateCollectionViaCustomerClinicalQuestionAnswer = (EntityCollection<HafTemplateEntity>)info.GetValue("_hafTemplateCollectionViaCustomerClinicalQuestionAnswer", typeof(EntityCollection<HafTemplateEntity>));
				_hafTemplateCollectionViaClinicalTestQualificationCriteria_ = (EntityCollection<HafTemplateEntity>)info.GetValue("_hafTemplateCollectionViaClinicalTestQualificationCriteria_", typeof(EntityCollection<HafTemplateEntity>));
				_lookupCollectionViaClinicalTestQualificationCriteria__ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaClinicalTestQualificationCriteria__", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerHealthQuestions = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerHealthQuestions", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaClinicalTestQualificationCriteria___ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaClinicalTestQualificationCriteria___", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaClinicalTestQualificationCriteria = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaClinicalTestQualificationCriteria", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaClinicalTestQualificationCriteria_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaClinicalTestQualificationCriteria_", typeof(EntityCollection<LookupEntity>));
				_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaClinicalTestQualificationCriteria___ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaClinicalTestQualificationCriteria___", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomerHealthInfoArchive = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerHealthInfoArchive", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaClinicalTestQualificationCriteria = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaClinicalTestQualificationCriteria", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaClinicalTestQualificationCriteria__ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaClinicalTestQualificationCriteria__", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomerHealthInfo = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerHealthInfo", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_readingCollectionViaMedicalHistoryReadingAssosciation = (EntityCollection<ReadingEntity>)info.GetValue("_readingCollectionViaMedicalHistoryReadingAssosciation", typeof(EntityCollection<ReadingEntity>));
				_testCollectionViaClinicalTestQualificationCriteria = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaClinicalTestQualificationCriteria", typeof(EntityCollection<TestEntity>));
				_testCollectionViaClinicalTestQualificationCriteria_ = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaClinicalTestQualificationCriteria_", typeof(EntityCollection<TestEntity>));
				_customerHealthQuestionGroup = (CustomerHealthQuestionGroupEntity)info.GetValue("_customerHealthQuestionGroup", typeof(CustomerHealthQuestionGroupEntity));
				if(_customerHealthQuestionGroup!=null)
				{
					_customerHealthQuestionGroup.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_customerHealthQuestions = (CustomerHealthQuestionsEntity)info.GetValue("_customerHealthQuestions", typeof(CustomerHealthQuestionsEntity));
				if(_customerHealthQuestions!=null)
				{
					_customerHealthQuestions.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((CustomerHealthQuestionsFieldIndex)fieldIndex)
			{
				case CustomerHealthQuestionsFieldIndex.CustomerHealthQuestionGroupId:
					DesetupSyncCustomerHealthQuestionGroup(true, false);
					break;
				case CustomerHealthQuestionsFieldIndex.ControlType:
					DesetupSyncLookup(true, false);
					break;
				case CustomerHealthQuestionsFieldIndex.ParentQuestionId:
					DesetupSyncCustomerHealthQuestions(true, false);
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
				case "CustomerHealthQuestionGroup":
					this.CustomerHealthQuestionGroup = (CustomerHealthQuestionGroupEntity)entity;
					break;
				case "CustomerHealthQuestions":
					this.CustomerHealthQuestions = (CustomerHealthQuestionsEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "ClinicalTestQualificationCriteria_":
					this.ClinicalTestQualificationCriteria_.Add((ClinicalTestQualificationCriteriaEntity)entity);
					break;
				case "ClinicalTestQualificationCriteria":
					this.ClinicalTestQualificationCriteria.Add((ClinicalTestQualificationCriteriaEntity)entity);
					break;
				case "CustomerClinicalQuestionAnswer":
					this.CustomerClinicalQuestionAnswer.Add((CustomerClinicalQuestionAnswerEntity)entity);
					break;
				case "CustomerHealthInfo":
					this.CustomerHealthInfo.Add((CustomerHealthInfoEntity)entity);
					break;
				case "CustomerHealthInfoArchive":
					this.CustomerHealthInfoArchive.Add((CustomerHealthInfoArchiveEntity)entity);
					break;
				case "CustomerHealthQuestions_":
					this.CustomerHealthQuestions_.Add((CustomerHealthQuestionsEntity)entity);
					break;
				case "HafTemplateQuestion":
					this.HafTemplateQuestion.Add((HafTemplateQuestionEntity)entity);
					break;
				case "HealthQuestionDependencyRule_":
					this.HealthQuestionDependencyRule_.Add((HealthQuestionDependencyRuleEntity)entity);
					break;
				case "HealthQuestionDependencyRule":
					this.HealthQuestionDependencyRule.Add((HealthQuestionDependencyRuleEntity)entity);
					break;
				case "MedicalHistoryReadingAssosciation":
					this.MedicalHistoryReadingAssosciation.Add((MedicalHistoryReadingAssosciationEntity)entity);
					break;
				case "CustomerHealthQuestionGroupCollectionViaCustomerHealthQuestions":
					this.CustomerHealthQuestionGroupCollectionViaCustomerHealthQuestions.IsReadOnly = false;
					this.CustomerHealthQuestionGroupCollectionViaCustomerHealthQuestions.Add((CustomerHealthQuestionGroupEntity)entity);
					this.CustomerHealthQuestionGroupCollectionViaCustomerHealthQuestions.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCustomerHealthInfo":
					this.CustomerProfileCollectionViaCustomerHealthInfo.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerHealthInfo.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerHealthInfo.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCustomerClinicalQuestionAnswer":
					this.CustomerProfileCollectionViaCustomerClinicalQuestionAnswer.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerClinicalQuestionAnswer.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerClinicalQuestionAnswer.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCustomerHealthInfoArchive":
					this.CustomerProfileCollectionViaCustomerHealthInfoArchive.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerHealthInfoArchive.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerHealthInfoArchive.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaCustomerHealthInfoArchive":
					this.EventCustomersCollectionViaCustomerHealthInfoArchive.IsReadOnly = false;
					this.EventCustomersCollectionViaCustomerHealthInfoArchive.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaCustomerHealthInfoArchive.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaCustomerHealthInfo":
					this.EventCustomersCollectionViaCustomerHealthInfo.IsReadOnly = false;
					this.EventCustomersCollectionViaCustomerHealthInfo.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaCustomerHealthInfo.IsReadOnly = true;
					break;
				case "EventsCollectionViaCustomerClinicalQuestionAnswer":
					this.EventsCollectionViaCustomerClinicalQuestionAnswer.IsReadOnly = false;
					this.EventsCollectionViaCustomerClinicalQuestionAnswer.Add((EventsEntity)entity);
					this.EventsCollectionViaCustomerClinicalQuestionAnswer.IsReadOnly = true;
					break;
				case "HafTemplateCollectionViaHafTemplateQuestion":
					this.HafTemplateCollectionViaHafTemplateQuestion.IsReadOnly = false;
					this.HafTemplateCollectionViaHafTemplateQuestion.Add((HafTemplateEntity)entity);
					this.HafTemplateCollectionViaHafTemplateQuestion.IsReadOnly = true;
					break;
				case "HafTemplateCollectionViaClinicalTestQualificationCriteria":
					this.HafTemplateCollectionViaClinicalTestQualificationCriteria.IsReadOnly = false;
					this.HafTemplateCollectionViaClinicalTestQualificationCriteria.Add((HafTemplateEntity)entity);
					this.HafTemplateCollectionViaClinicalTestQualificationCriteria.IsReadOnly = true;
					break;
				case "HafTemplateCollectionViaCustomerClinicalQuestionAnswer":
					this.HafTemplateCollectionViaCustomerClinicalQuestionAnswer.IsReadOnly = false;
					this.HafTemplateCollectionViaCustomerClinicalQuestionAnswer.Add((HafTemplateEntity)entity);
					this.HafTemplateCollectionViaCustomerClinicalQuestionAnswer.IsReadOnly = true;
					break;
				case "HafTemplateCollectionViaClinicalTestQualificationCriteria_":
					this.HafTemplateCollectionViaClinicalTestQualificationCriteria_.IsReadOnly = false;
					this.HafTemplateCollectionViaClinicalTestQualificationCriteria_.Add((HafTemplateEntity)entity);
					this.HafTemplateCollectionViaClinicalTestQualificationCriteria_.IsReadOnly = true;
					break;
				case "LookupCollectionViaClinicalTestQualificationCriteria__":
					this.LookupCollectionViaClinicalTestQualificationCriteria__.IsReadOnly = false;
					this.LookupCollectionViaClinicalTestQualificationCriteria__.Add((LookupEntity)entity);
					this.LookupCollectionViaClinicalTestQualificationCriteria__.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerHealthQuestions":
					this.LookupCollectionViaCustomerHealthQuestions.IsReadOnly = false;
					this.LookupCollectionViaCustomerHealthQuestions.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerHealthQuestions.IsReadOnly = true;
					break;
				case "LookupCollectionViaClinicalTestQualificationCriteria___":
					this.LookupCollectionViaClinicalTestQualificationCriteria___.IsReadOnly = false;
					this.LookupCollectionViaClinicalTestQualificationCriteria___.Add((LookupEntity)entity);
					this.LookupCollectionViaClinicalTestQualificationCriteria___.IsReadOnly = true;
					break;
				case "LookupCollectionViaClinicalTestQualificationCriteria":
					this.LookupCollectionViaClinicalTestQualificationCriteria.IsReadOnly = false;
					this.LookupCollectionViaClinicalTestQualificationCriteria.Add((LookupEntity)entity);
					this.LookupCollectionViaClinicalTestQualificationCriteria.IsReadOnly = true;
					break;
				case "LookupCollectionViaClinicalTestQualificationCriteria_":
					this.LookupCollectionViaClinicalTestQualificationCriteria_.IsReadOnly = false;
					this.LookupCollectionViaClinicalTestQualificationCriteria_.Add((LookupEntity)entity);
					this.LookupCollectionViaClinicalTestQualificationCriteria_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_":
					this.OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria___":
					this.OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria___.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria___.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria___.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerHealthInfoArchive":
					this.OrganizationRoleUserCollectionViaCustomerHealthInfoArchive.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerHealthInfoArchive.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerHealthInfoArchive.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria":
					this.OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer":
					this.OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria__":
					this.OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria__.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria__.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria__.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerHealthInfo":
					this.OrganizationRoleUserCollectionViaCustomerHealthInfo.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerHealthInfo.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerHealthInfo.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_":
					this.OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_.IsReadOnly = true;
					break;
				case "ReadingCollectionViaMedicalHistoryReadingAssosciation":
					this.ReadingCollectionViaMedicalHistoryReadingAssosciation.IsReadOnly = false;
					this.ReadingCollectionViaMedicalHistoryReadingAssosciation.Add((ReadingEntity)entity);
					this.ReadingCollectionViaMedicalHistoryReadingAssosciation.IsReadOnly = true;
					break;
				case "TestCollectionViaClinicalTestQualificationCriteria":
					this.TestCollectionViaClinicalTestQualificationCriteria.IsReadOnly = false;
					this.TestCollectionViaClinicalTestQualificationCriteria.Add((TestEntity)entity);
					this.TestCollectionViaClinicalTestQualificationCriteria.IsReadOnly = true;
					break;
				case "TestCollectionViaClinicalTestQualificationCriteria_":
					this.TestCollectionViaClinicalTestQualificationCriteria_.IsReadOnly = false;
					this.TestCollectionViaClinicalTestQualificationCriteria_.Add((TestEntity)entity);
					this.TestCollectionViaClinicalTestQualificationCriteria_.IsReadOnly = true;
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
			return CustomerHealthQuestionsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "CustomerHealthQuestionGroup":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.CustomerHealthQuestionGroupEntityUsingCustomerHealthQuestionGroupId);
					break;
				case "CustomerHealthQuestions":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.CustomerHealthQuestionsEntityUsingCustomerHealthQuestionIdParentQuestionId);
					break;
				case "Lookup":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.LookupEntityUsingControlType);
					break;
				case "ClinicalTestQualificationCriteria_":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingDisqualifierQuestionId);
					break;
				case "ClinicalTestQualificationCriteria":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingMedicationQuestionId);
					break;
				case "CustomerClinicalQuestionAnswer":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.CustomerClinicalQuestionAnswerEntityUsingClinicalHealthQuestionId);
					break;
				case "CustomerHealthInfo":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.CustomerHealthInfoEntityUsingCustomerHealthQuestionId);
					break;
				case "CustomerHealthInfoArchive":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.CustomerHealthInfoArchiveEntityUsingCustomerHealthQuestionId);
					break;
				case "CustomerHealthQuestions_":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.CustomerHealthQuestionsEntityUsingParentQuestionId);
					break;
				case "HafTemplateQuestion":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.HafTemplateQuestionEntityUsingQuestionId);
					break;
				case "HealthQuestionDependencyRule_":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.HealthQuestionDependencyRuleEntityUsingQuestionId);
					break;
				case "HealthQuestionDependencyRule":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.HealthQuestionDependencyRuleEntityUsingDependantQuestionId);
					break;
				case "MedicalHistoryReadingAssosciation":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.MedicalHistoryReadingAssosciationEntityUsingMedicalHistoryQuestionId);
					break;
				case "CustomerHealthQuestionGroupCollectionViaCustomerHealthQuestions":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.CustomerHealthQuestionsEntityUsingParentQuestionId, "CustomerHealthQuestionsEntity__", "CustomerHealthQuestions_", JoinHint.None);
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.CustomerHealthQuestionGroupEntityUsingCustomerHealthQuestionGroupId, "CustomerHealthQuestions_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCustomerHealthInfo":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.CustomerHealthInfoEntityUsingCustomerHealthQuestionId, "CustomerHealthQuestionsEntity__", "CustomerHealthInfo_", JoinHint.None);
					toReturn.Add(CustomerHealthInfoEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerHealthInfo_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCustomerClinicalQuestionAnswer":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.CustomerClinicalQuestionAnswerEntityUsingClinicalHealthQuestionId, "CustomerHealthQuestionsEntity__", "CustomerClinicalQuestionAnswer_", JoinHint.None);
					toReturn.Add(CustomerClinicalQuestionAnswerEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerClinicalQuestionAnswer_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCustomerHealthInfoArchive":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.CustomerHealthInfoArchiveEntityUsingCustomerHealthQuestionId, "CustomerHealthQuestionsEntity__", "CustomerHealthInfoArchive_", JoinHint.None);
					toReturn.Add(CustomerHealthInfoArchiveEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerHealthInfoArchive_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaCustomerHealthInfoArchive":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.CustomerHealthInfoArchiveEntityUsingCustomerHealthQuestionId, "CustomerHealthQuestionsEntity__", "CustomerHealthInfoArchive_", JoinHint.None);
					toReturn.Add(CustomerHealthInfoArchiveEntity.Relations.EventCustomersEntityUsingEventCustomerId, "CustomerHealthInfoArchive_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaCustomerHealthInfo":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.CustomerHealthInfoEntityUsingCustomerHealthQuestionId, "CustomerHealthQuestionsEntity__", "CustomerHealthInfo_", JoinHint.None);
					toReturn.Add(CustomerHealthInfoEntity.Relations.EventCustomersEntityUsingEventCustomerId, "CustomerHealthInfo_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaCustomerClinicalQuestionAnswer":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.CustomerClinicalQuestionAnswerEntityUsingClinicalHealthQuestionId, "CustomerHealthQuestionsEntity__", "CustomerClinicalQuestionAnswer_", JoinHint.None);
					toReturn.Add(CustomerClinicalQuestionAnswerEntity.Relations.EventsEntityUsingEventId, "CustomerClinicalQuestionAnswer_", string.Empty, JoinHint.None);
					break;
				case "HafTemplateCollectionViaHafTemplateQuestion":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.HafTemplateQuestionEntityUsingQuestionId, "CustomerHealthQuestionsEntity__", "HafTemplateQuestion_", JoinHint.None);
					toReturn.Add(HafTemplateQuestionEntity.Relations.HafTemplateEntityUsingHaftemplateId, "HafTemplateQuestion_", string.Empty, JoinHint.None);
					break;
				case "HafTemplateCollectionViaClinicalTestQualificationCriteria":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingMedicationQuestionId, "CustomerHealthQuestionsEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.HafTemplateEntityUsingTemplateId, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
					break;
				case "HafTemplateCollectionViaCustomerClinicalQuestionAnswer":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.CustomerClinicalQuestionAnswerEntityUsingClinicalHealthQuestionId, "CustomerHealthQuestionsEntity__", "CustomerClinicalQuestionAnswer_", JoinHint.None);
					toReturn.Add(CustomerClinicalQuestionAnswerEntity.Relations.HafTemplateEntityUsingClinicalQuestionTemplateId, "CustomerClinicalQuestionAnswer_", string.Empty, JoinHint.None);
					break;
				case "HafTemplateCollectionViaClinicalTestQualificationCriteria_":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingDisqualifierQuestionId, "CustomerHealthQuestionsEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.HafTemplateEntityUsingTemplateId, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaClinicalTestQualificationCriteria__":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingDisqualifierQuestionId, "CustomerHealthQuestionsEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.LookupEntityUsingAgeCondition, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerHealthQuestions":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.CustomerHealthQuestionsEntityUsingParentQuestionId, "CustomerHealthQuestionsEntity__", "CustomerHealthQuestions_", JoinHint.None);
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.LookupEntityUsingControlType, "CustomerHealthQuestions_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaClinicalTestQualificationCriteria___":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingDisqualifierQuestionId, "CustomerHealthQuestionsEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.LookupEntityUsingGender, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaClinicalTestQualificationCriteria":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingMedicationQuestionId, "CustomerHealthQuestionsEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.LookupEntityUsingAgeCondition, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaClinicalTestQualificationCriteria_":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingMedicationQuestionId, "CustomerHealthQuestionsEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.LookupEntityUsingGender, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingMedicationQuestionId, "CustomerHealthQuestionsEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria___":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingDisqualifierQuestionId, "CustomerHealthQuestionsEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerHealthInfoArchive":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.CustomerHealthInfoArchiveEntityUsingCustomerHealthQuestionId, "CustomerHealthQuestionsEntity__", "CustomerHealthInfoArchive_", JoinHint.None);
					toReturn.Add(CustomerHealthInfoArchiveEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "CustomerHealthInfoArchive_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingMedicationQuestionId, "CustomerHealthQuestionsEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.CustomerClinicalQuestionAnswerEntityUsingClinicalHealthQuestionId, "CustomerHealthQuestionsEntity__", "CustomerClinicalQuestionAnswer_", JoinHint.None);
					toReturn.Add(CustomerClinicalQuestionAnswerEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "CustomerClinicalQuestionAnswer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria__":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingDisqualifierQuestionId, "CustomerHealthQuestionsEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerHealthInfo":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.CustomerHealthInfoEntityUsingCustomerHealthQuestionId, "CustomerHealthQuestionsEntity__", "CustomerHealthInfo_", JoinHint.None);
					toReturn.Add(CustomerHealthInfoEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "CustomerHealthInfo_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.CustomerClinicalQuestionAnswerEntityUsingClinicalHealthQuestionId, "CustomerHealthQuestionsEntity__", "CustomerClinicalQuestionAnswer_", JoinHint.None);
					toReturn.Add(CustomerClinicalQuestionAnswerEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "CustomerClinicalQuestionAnswer_", string.Empty, JoinHint.None);
					break;
				case "ReadingCollectionViaMedicalHistoryReadingAssosciation":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.MedicalHistoryReadingAssosciationEntityUsingMedicalHistoryQuestionId, "CustomerHealthQuestionsEntity__", "MedicalHistoryReadingAssosciation_", JoinHint.None);
					toReturn.Add(MedicalHistoryReadingAssosciationEntity.Relations.ReadingEntityUsingReadingId, "MedicalHistoryReadingAssosciation_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaClinicalTestQualificationCriteria":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingMedicationQuestionId, "CustomerHealthQuestionsEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.TestEntityUsingTestId, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaClinicalTestQualificationCriteria_":
					toReturn.Add(CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingDisqualifierQuestionId, "CustomerHealthQuestionsEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.TestEntityUsingTestId, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
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
				case "CustomerHealthQuestionGroup":
					SetupSyncCustomerHealthQuestionGroup(relatedEntity);
					break;
				case "CustomerHealthQuestions":
					SetupSyncCustomerHealthQuestions(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "ClinicalTestQualificationCriteria_":
					this.ClinicalTestQualificationCriteria_.Add((ClinicalTestQualificationCriteriaEntity)relatedEntity);
					break;
				case "ClinicalTestQualificationCriteria":
					this.ClinicalTestQualificationCriteria.Add((ClinicalTestQualificationCriteriaEntity)relatedEntity);
					break;
				case "CustomerClinicalQuestionAnswer":
					this.CustomerClinicalQuestionAnswer.Add((CustomerClinicalQuestionAnswerEntity)relatedEntity);
					break;
				case "CustomerHealthInfo":
					this.CustomerHealthInfo.Add((CustomerHealthInfoEntity)relatedEntity);
					break;
				case "CustomerHealthInfoArchive":
					this.CustomerHealthInfoArchive.Add((CustomerHealthInfoArchiveEntity)relatedEntity);
					break;
				case "CustomerHealthQuestions_":
					this.CustomerHealthQuestions_.Add((CustomerHealthQuestionsEntity)relatedEntity);
					break;
				case "HafTemplateQuestion":
					this.HafTemplateQuestion.Add((HafTemplateQuestionEntity)relatedEntity);
					break;
				case "HealthQuestionDependencyRule_":
					this.HealthQuestionDependencyRule_.Add((HealthQuestionDependencyRuleEntity)relatedEntity);
					break;
				case "HealthQuestionDependencyRule":
					this.HealthQuestionDependencyRule.Add((HealthQuestionDependencyRuleEntity)relatedEntity);
					break;
				case "MedicalHistoryReadingAssosciation":
					this.MedicalHistoryReadingAssosciation.Add((MedicalHistoryReadingAssosciationEntity)relatedEntity);
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
				case "CustomerHealthQuestionGroup":
					DesetupSyncCustomerHealthQuestionGroup(false, true);
					break;
				case "CustomerHealthQuestions":
					DesetupSyncCustomerHealthQuestions(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "ClinicalTestQualificationCriteria_":
					base.PerformRelatedEntityRemoval(this.ClinicalTestQualificationCriteria_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ClinicalTestQualificationCriteria":
					base.PerformRelatedEntityRemoval(this.ClinicalTestQualificationCriteria, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerClinicalQuestionAnswer":
					base.PerformRelatedEntityRemoval(this.CustomerClinicalQuestionAnswer, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerHealthInfo":
					base.PerformRelatedEntityRemoval(this.CustomerHealthInfo, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerHealthInfoArchive":
					base.PerformRelatedEntityRemoval(this.CustomerHealthInfoArchive, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerHealthQuestions_":
					base.PerformRelatedEntityRemoval(this.CustomerHealthQuestions_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HafTemplateQuestion":
					base.PerformRelatedEntityRemoval(this.HafTemplateQuestion, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HealthQuestionDependencyRule_":
					base.PerformRelatedEntityRemoval(this.HealthQuestionDependencyRule_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HealthQuestionDependencyRule":
					base.PerformRelatedEntityRemoval(this.HealthQuestionDependencyRule, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MedicalHistoryReadingAssosciation":
					base.PerformRelatedEntityRemoval(this.MedicalHistoryReadingAssosciation, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_customerHealthQuestionGroup!=null)
			{
				toReturn.Add(_customerHealthQuestionGroup);
			}
			if(_customerHealthQuestions!=null)
			{
				toReturn.Add(_customerHealthQuestions);
			}
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.ClinicalTestQualificationCriteria_);
			toReturn.Add(this.ClinicalTestQualificationCriteria);
			toReturn.Add(this.CustomerClinicalQuestionAnswer);
			toReturn.Add(this.CustomerHealthInfo);
			toReturn.Add(this.CustomerHealthInfoArchive);
			toReturn.Add(this.CustomerHealthQuestions_);
			toReturn.Add(this.HafTemplateQuestion);
			toReturn.Add(this.HealthQuestionDependencyRule_);
			toReturn.Add(this.HealthQuestionDependencyRule);
			toReturn.Add(this.MedicalHistoryReadingAssosciation);

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
				info.AddValue("_clinicalTestQualificationCriteria_", ((_clinicalTestQualificationCriteria_!=null) && (_clinicalTestQualificationCriteria_.Count>0) && !this.MarkedForDeletion)?_clinicalTestQualificationCriteria_:null);
				info.AddValue("_clinicalTestQualificationCriteria", ((_clinicalTestQualificationCriteria!=null) && (_clinicalTestQualificationCriteria.Count>0) && !this.MarkedForDeletion)?_clinicalTestQualificationCriteria:null);
				info.AddValue("_customerClinicalQuestionAnswer", ((_customerClinicalQuestionAnswer!=null) && (_customerClinicalQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_customerClinicalQuestionAnswer:null);
				info.AddValue("_customerHealthInfo", ((_customerHealthInfo!=null) && (_customerHealthInfo.Count>0) && !this.MarkedForDeletion)?_customerHealthInfo:null);
				info.AddValue("_customerHealthInfoArchive", ((_customerHealthInfoArchive!=null) && (_customerHealthInfoArchive.Count>0) && !this.MarkedForDeletion)?_customerHealthInfoArchive:null);
				info.AddValue("_customerHealthQuestions_", ((_customerHealthQuestions_!=null) && (_customerHealthQuestions_.Count>0) && !this.MarkedForDeletion)?_customerHealthQuestions_:null);
				info.AddValue("_hafTemplateQuestion", ((_hafTemplateQuestion!=null) && (_hafTemplateQuestion.Count>0) && !this.MarkedForDeletion)?_hafTemplateQuestion:null);
				info.AddValue("_healthQuestionDependencyRule_", ((_healthQuestionDependencyRule_!=null) && (_healthQuestionDependencyRule_.Count>0) && !this.MarkedForDeletion)?_healthQuestionDependencyRule_:null);
				info.AddValue("_healthQuestionDependencyRule", ((_healthQuestionDependencyRule!=null) && (_healthQuestionDependencyRule.Count>0) && !this.MarkedForDeletion)?_healthQuestionDependencyRule:null);
				info.AddValue("_medicalHistoryReadingAssosciation", ((_medicalHistoryReadingAssosciation!=null) && (_medicalHistoryReadingAssosciation.Count>0) && !this.MarkedForDeletion)?_medicalHistoryReadingAssosciation:null);
				info.AddValue("_customerHealthQuestionGroupCollectionViaCustomerHealthQuestions", ((_customerHealthQuestionGroupCollectionViaCustomerHealthQuestions!=null) && (_customerHealthQuestionGroupCollectionViaCustomerHealthQuestions.Count>0) && !this.MarkedForDeletion)?_customerHealthQuestionGroupCollectionViaCustomerHealthQuestions:null);
				info.AddValue("_customerProfileCollectionViaCustomerHealthInfo", ((_customerProfileCollectionViaCustomerHealthInfo!=null) && (_customerProfileCollectionViaCustomerHealthInfo.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerHealthInfo:null);
				info.AddValue("_customerProfileCollectionViaCustomerClinicalQuestionAnswer", ((_customerProfileCollectionViaCustomerClinicalQuestionAnswer!=null) && (_customerProfileCollectionViaCustomerClinicalQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerClinicalQuestionAnswer:null);
				info.AddValue("_customerProfileCollectionViaCustomerHealthInfoArchive", ((_customerProfileCollectionViaCustomerHealthInfoArchive!=null) && (_customerProfileCollectionViaCustomerHealthInfoArchive.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerHealthInfoArchive:null);
				info.AddValue("_eventCustomersCollectionViaCustomerHealthInfoArchive", ((_eventCustomersCollectionViaCustomerHealthInfoArchive!=null) && (_eventCustomersCollectionViaCustomerHealthInfoArchive.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaCustomerHealthInfoArchive:null);
				info.AddValue("_eventCustomersCollectionViaCustomerHealthInfo", ((_eventCustomersCollectionViaCustomerHealthInfo!=null) && (_eventCustomersCollectionViaCustomerHealthInfo.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaCustomerHealthInfo:null);
				info.AddValue("_eventsCollectionViaCustomerClinicalQuestionAnswer", ((_eventsCollectionViaCustomerClinicalQuestionAnswer!=null) && (_eventsCollectionViaCustomerClinicalQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaCustomerClinicalQuestionAnswer:null);
				info.AddValue("_hafTemplateCollectionViaHafTemplateQuestion", ((_hafTemplateCollectionViaHafTemplateQuestion!=null) && (_hafTemplateCollectionViaHafTemplateQuestion.Count>0) && !this.MarkedForDeletion)?_hafTemplateCollectionViaHafTemplateQuestion:null);
				info.AddValue("_hafTemplateCollectionViaClinicalTestQualificationCriteria", ((_hafTemplateCollectionViaClinicalTestQualificationCriteria!=null) && (_hafTemplateCollectionViaClinicalTestQualificationCriteria.Count>0) && !this.MarkedForDeletion)?_hafTemplateCollectionViaClinicalTestQualificationCriteria:null);
				info.AddValue("_hafTemplateCollectionViaCustomerClinicalQuestionAnswer", ((_hafTemplateCollectionViaCustomerClinicalQuestionAnswer!=null) && (_hafTemplateCollectionViaCustomerClinicalQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_hafTemplateCollectionViaCustomerClinicalQuestionAnswer:null);
				info.AddValue("_hafTemplateCollectionViaClinicalTestQualificationCriteria_", ((_hafTemplateCollectionViaClinicalTestQualificationCriteria_!=null) && (_hafTemplateCollectionViaClinicalTestQualificationCriteria_.Count>0) && !this.MarkedForDeletion)?_hafTemplateCollectionViaClinicalTestQualificationCriteria_:null);
				info.AddValue("_lookupCollectionViaClinicalTestQualificationCriteria__", ((_lookupCollectionViaClinicalTestQualificationCriteria__!=null) && (_lookupCollectionViaClinicalTestQualificationCriteria__.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaClinicalTestQualificationCriteria__:null);
				info.AddValue("_lookupCollectionViaCustomerHealthQuestions", ((_lookupCollectionViaCustomerHealthQuestions!=null) && (_lookupCollectionViaCustomerHealthQuestions.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerHealthQuestions:null);
				info.AddValue("_lookupCollectionViaClinicalTestQualificationCriteria___", ((_lookupCollectionViaClinicalTestQualificationCriteria___!=null) && (_lookupCollectionViaClinicalTestQualificationCriteria___.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaClinicalTestQualificationCriteria___:null);
				info.AddValue("_lookupCollectionViaClinicalTestQualificationCriteria", ((_lookupCollectionViaClinicalTestQualificationCriteria!=null) && (_lookupCollectionViaClinicalTestQualificationCriteria.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaClinicalTestQualificationCriteria:null);
				info.AddValue("_lookupCollectionViaClinicalTestQualificationCriteria_", ((_lookupCollectionViaClinicalTestQualificationCriteria_!=null) && (_lookupCollectionViaClinicalTestQualificationCriteria_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaClinicalTestQualificationCriteria_:null);
				info.AddValue("_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_", ((_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_!=null) && (_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_:null);
				info.AddValue("_organizationRoleUserCollectionViaClinicalTestQualificationCriteria___", ((_organizationRoleUserCollectionViaClinicalTestQualificationCriteria___!=null) && (_organizationRoleUserCollectionViaClinicalTestQualificationCriteria___.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaClinicalTestQualificationCriteria___:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerHealthInfoArchive", ((_organizationRoleUserCollectionViaCustomerHealthInfoArchive!=null) && (_organizationRoleUserCollectionViaCustomerHealthInfoArchive.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerHealthInfoArchive:null);
				info.AddValue("_organizationRoleUserCollectionViaClinicalTestQualificationCriteria", ((_organizationRoleUserCollectionViaClinicalTestQualificationCriteria!=null) && (_organizationRoleUserCollectionViaClinicalTestQualificationCriteria.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaClinicalTestQualificationCriteria:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer", ((_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer!=null) && (_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer:null);
				info.AddValue("_organizationRoleUserCollectionViaClinicalTestQualificationCriteria__", ((_organizationRoleUserCollectionViaClinicalTestQualificationCriteria__!=null) && (_organizationRoleUserCollectionViaClinicalTestQualificationCriteria__.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaClinicalTestQualificationCriteria__:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerHealthInfo", ((_organizationRoleUserCollectionViaCustomerHealthInfo!=null) && (_organizationRoleUserCollectionViaCustomerHealthInfo.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerHealthInfo:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_", ((_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_!=null) && (_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_:null);
				info.AddValue("_readingCollectionViaMedicalHistoryReadingAssosciation", ((_readingCollectionViaMedicalHistoryReadingAssosciation!=null) && (_readingCollectionViaMedicalHistoryReadingAssosciation.Count>0) && !this.MarkedForDeletion)?_readingCollectionViaMedicalHistoryReadingAssosciation:null);
				info.AddValue("_testCollectionViaClinicalTestQualificationCriteria", ((_testCollectionViaClinicalTestQualificationCriteria!=null) && (_testCollectionViaClinicalTestQualificationCriteria.Count>0) && !this.MarkedForDeletion)?_testCollectionViaClinicalTestQualificationCriteria:null);
				info.AddValue("_testCollectionViaClinicalTestQualificationCriteria_", ((_testCollectionViaClinicalTestQualificationCriteria_!=null) && (_testCollectionViaClinicalTestQualificationCriteria_.Count>0) && !this.MarkedForDeletion)?_testCollectionViaClinicalTestQualificationCriteria_:null);
				info.AddValue("_customerHealthQuestionGroup", (!this.MarkedForDeletion?_customerHealthQuestionGroup:null));
				info.AddValue("_customerHealthQuestions", (!this.MarkedForDeletion?_customerHealthQuestions:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(CustomerHealthQuestionsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CustomerHealthQuestionsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CustomerHealthQuestionsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ClinicalTestQualificationCriteria' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoClinicalTestQualificationCriteria_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ClinicalTestQualificationCriteriaFields.DisqualifierQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ClinicalTestQualificationCriteria' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoClinicalTestQualificationCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ClinicalTestQualificationCriteriaFields.MedicationQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerClinicalQuestionAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerClinicalQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerClinicalQuestionAnswerFields.ClinicalHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerHealthInfo' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerHealthInfo()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthInfoFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerHealthInfoArchive' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerHealthInfoArchive()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthInfoArchiveFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerHealthQuestions' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerHealthQuestions_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.ParentQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HafTemplateQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplateQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateQuestionFields.QuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthQuestionDependencyRule' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthQuestionDependencyRule_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthQuestionDependencyRuleFields.QuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthQuestionDependencyRule' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthQuestionDependencyRule()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthQuestionDependencyRuleFields.DependantQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MedicalHistoryReadingAssosciation' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicalHistoryReadingAssosciation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicalHistoryReadingAssosciationFields.MedicalHistoryQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerHealthQuestionGroup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerHealthQuestionGroupCollectionViaCustomerHealthQuestions()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerHealthQuestionGroupCollectionViaCustomerHealthQuestions"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerHealthInfo()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerHealthInfo"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerClinicalQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerClinicalQuestionAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerHealthInfoArchive()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerHealthInfoArchive"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaCustomerHealthInfoArchive()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaCustomerHealthInfoArchive"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaCustomerHealthInfo()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaCustomerHealthInfo"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaCustomerClinicalQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaCustomerClinicalQuestionAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HafTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplateCollectionViaHafTemplateQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HafTemplateCollectionViaHafTemplateQuestion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HafTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplateCollectionViaClinicalTestQualificationCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HafTemplateCollectionViaClinicalTestQualificationCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HafTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplateCollectionViaCustomerClinicalQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HafTemplateCollectionViaCustomerClinicalQuestionAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HafTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplateCollectionViaClinicalTestQualificationCriteria_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HafTemplateCollectionViaClinicalTestQualificationCriteria_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaClinicalTestQualificationCriteria__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaClinicalTestQualificationCriteria__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerHealthQuestions()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerHealthQuestions"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaClinicalTestQualificationCriteria___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaClinicalTestQualificationCriteria___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaClinicalTestQualificationCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaClinicalTestQualificationCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaClinicalTestQualificationCriteria_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaClinicalTestQualificationCriteria_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaClinicalTestQualificationCriteria___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerHealthInfoArchive()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerHealthInfoArchive"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaClinicalTestQualificationCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaClinicalTestQualificationCriteria__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerHealthInfo()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerHealthInfo"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Reading' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoReadingCollectionViaMedicalHistoryReadingAssosciation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ReadingCollectionViaMedicalHistoryReadingAssosciation"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaClinicalTestQualificationCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaClinicalTestQualificationCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaClinicalTestQualificationCriteria_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaClinicalTestQualificationCriteria_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionId, "CustomerHealthQuestionsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerHealthQuestionGroup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerHealthQuestionGroup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionGroupFields.CustomerHealthQuestionGroupId, null, ComparisonOperator.Equal, this.CustomerHealthQuestionGroupId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerHealthQuestions' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerHealthQuestions()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerHealthQuestionsFields.CustomerHealthQuestionId, null, ComparisonOperator.Equal, this.ParentQuestionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.ControlType));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CustomerHealthQuestionsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._clinicalTestQualificationCriteria_);
			collectionsQueue.Enqueue(this._clinicalTestQualificationCriteria);
			collectionsQueue.Enqueue(this._customerClinicalQuestionAnswer);
			collectionsQueue.Enqueue(this._customerHealthInfo);
			collectionsQueue.Enqueue(this._customerHealthInfoArchive);
			collectionsQueue.Enqueue(this._customerHealthQuestions_);
			collectionsQueue.Enqueue(this._hafTemplateQuestion);
			collectionsQueue.Enqueue(this._healthQuestionDependencyRule_);
			collectionsQueue.Enqueue(this._healthQuestionDependencyRule);
			collectionsQueue.Enqueue(this._medicalHistoryReadingAssosciation);
			collectionsQueue.Enqueue(this._customerHealthQuestionGroupCollectionViaCustomerHealthQuestions);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerHealthInfo);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerClinicalQuestionAnswer);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerHealthInfoArchive);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaCustomerHealthInfoArchive);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaCustomerHealthInfo);
			collectionsQueue.Enqueue(this._eventsCollectionViaCustomerClinicalQuestionAnswer);
			collectionsQueue.Enqueue(this._hafTemplateCollectionViaHafTemplateQuestion);
			collectionsQueue.Enqueue(this._hafTemplateCollectionViaClinicalTestQualificationCriteria);
			collectionsQueue.Enqueue(this._hafTemplateCollectionViaCustomerClinicalQuestionAnswer);
			collectionsQueue.Enqueue(this._hafTemplateCollectionViaClinicalTestQualificationCriteria_);
			collectionsQueue.Enqueue(this._lookupCollectionViaClinicalTestQualificationCriteria__);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerHealthQuestions);
			collectionsQueue.Enqueue(this._lookupCollectionViaClinicalTestQualificationCriteria___);
			collectionsQueue.Enqueue(this._lookupCollectionViaClinicalTestQualificationCriteria);
			collectionsQueue.Enqueue(this._lookupCollectionViaClinicalTestQualificationCriteria_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaClinicalTestQualificationCriteria_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaClinicalTestQualificationCriteria___);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerHealthInfoArchive);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaClinicalTestQualificationCriteria);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaClinicalTestQualificationCriteria__);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerHealthInfo);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_);
			collectionsQueue.Enqueue(this._readingCollectionViaMedicalHistoryReadingAssosciation);
			collectionsQueue.Enqueue(this._testCollectionViaClinicalTestQualificationCriteria);
			collectionsQueue.Enqueue(this._testCollectionViaClinicalTestQualificationCriteria_);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._clinicalTestQualificationCriteria_ = (EntityCollection<ClinicalTestQualificationCriteriaEntity>) collectionsQueue.Dequeue();
			this._clinicalTestQualificationCriteria = (EntityCollection<ClinicalTestQualificationCriteriaEntity>) collectionsQueue.Dequeue();
			this._customerClinicalQuestionAnswer = (EntityCollection<CustomerClinicalQuestionAnswerEntity>) collectionsQueue.Dequeue();
			this._customerHealthInfo = (EntityCollection<CustomerHealthInfoEntity>) collectionsQueue.Dequeue();
			this._customerHealthInfoArchive = (EntityCollection<CustomerHealthInfoArchiveEntity>) collectionsQueue.Dequeue();
			this._customerHealthQuestions_ = (EntityCollection<CustomerHealthQuestionsEntity>) collectionsQueue.Dequeue();
			this._hafTemplateQuestion = (EntityCollection<HafTemplateQuestionEntity>) collectionsQueue.Dequeue();
			this._healthQuestionDependencyRule_ = (EntityCollection<HealthQuestionDependencyRuleEntity>) collectionsQueue.Dequeue();
			this._healthQuestionDependencyRule = (EntityCollection<HealthQuestionDependencyRuleEntity>) collectionsQueue.Dequeue();
			this._medicalHistoryReadingAssosciation = (EntityCollection<MedicalHistoryReadingAssosciationEntity>) collectionsQueue.Dequeue();
			this._customerHealthQuestionGroupCollectionViaCustomerHealthQuestions = (EntityCollection<CustomerHealthQuestionGroupEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerHealthInfo = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerClinicalQuestionAnswer = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerHealthInfoArchive = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaCustomerHealthInfoArchive = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaCustomerHealthInfo = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaCustomerClinicalQuestionAnswer = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._hafTemplateCollectionViaHafTemplateQuestion = (EntityCollection<HafTemplateEntity>) collectionsQueue.Dequeue();
			this._hafTemplateCollectionViaClinicalTestQualificationCriteria = (EntityCollection<HafTemplateEntity>) collectionsQueue.Dequeue();
			this._hafTemplateCollectionViaCustomerClinicalQuestionAnswer = (EntityCollection<HafTemplateEntity>) collectionsQueue.Dequeue();
			this._hafTemplateCollectionViaClinicalTestQualificationCriteria_ = (EntityCollection<HafTemplateEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaClinicalTestQualificationCriteria__ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerHealthQuestions = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaClinicalTestQualificationCriteria___ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaClinicalTestQualificationCriteria = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaClinicalTestQualificationCriteria_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaClinicalTestQualificationCriteria_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaClinicalTestQualificationCriteria___ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerHealthInfoArchive = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaClinicalTestQualificationCriteria = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaClinicalTestQualificationCriteria__ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerHealthInfo = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._readingCollectionViaMedicalHistoryReadingAssosciation = (EntityCollection<ReadingEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaClinicalTestQualificationCriteria = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaClinicalTestQualificationCriteria_ = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._clinicalTestQualificationCriteria_ != null)
			{
				return true;
			}
			if (this._clinicalTestQualificationCriteria != null)
			{
				return true;
			}
			if (this._customerClinicalQuestionAnswer != null)
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
			if (this._customerHealthQuestions_ != null)
			{
				return true;
			}
			if (this._hafTemplateQuestion != null)
			{
				return true;
			}
			if (this._healthQuestionDependencyRule_ != null)
			{
				return true;
			}
			if (this._healthQuestionDependencyRule != null)
			{
				return true;
			}
			if (this._medicalHistoryReadingAssosciation != null)
			{
				return true;
			}
			if (this._customerHealthQuestionGroupCollectionViaCustomerHealthQuestions != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerHealthInfo != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerClinicalQuestionAnswer != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerHealthInfoArchive != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaCustomerHealthInfoArchive != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaCustomerHealthInfo != null)
			{
				return true;
			}
			if (this._eventsCollectionViaCustomerClinicalQuestionAnswer != null)
			{
				return true;
			}
			if (this._hafTemplateCollectionViaHafTemplateQuestion != null)
			{
				return true;
			}
			if (this._hafTemplateCollectionViaClinicalTestQualificationCriteria != null)
			{
				return true;
			}
			if (this._hafTemplateCollectionViaCustomerClinicalQuestionAnswer != null)
			{
				return true;
			}
			if (this._hafTemplateCollectionViaClinicalTestQualificationCriteria_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaClinicalTestQualificationCriteria__ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerHealthQuestions != null)
			{
				return true;
			}
			if (this._lookupCollectionViaClinicalTestQualificationCriteria___ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaClinicalTestQualificationCriteria != null)
			{
				return true;
			}
			if (this._lookupCollectionViaClinicalTestQualificationCriteria_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaClinicalTestQualificationCriteria_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaClinicalTestQualificationCriteria___ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerHealthInfoArchive != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaClinicalTestQualificationCriteria != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaClinicalTestQualificationCriteria__ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerHealthInfo != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_ != null)
			{
				return true;
			}
			if (this._readingCollectionViaMedicalHistoryReadingAssosciation != null)
			{
				return true;
			}
			if (this._testCollectionViaClinicalTestQualificationCriteria != null)
			{
				return true;
			}
			if (this._testCollectionViaClinicalTestQualificationCriteria_ != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ClinicalTestQualificationCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClinicalTestQualificationCriteriaEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ClinicalTestQualificationCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClinicalTestQualificationCriteriaEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerClinicalQuestionAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerClinicalQuestionAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerHealthInfoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthInfoEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerHealthInfoArchiveEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthInfoArchiveEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HafTemplateQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthQuestionDependencyRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthQuestionDependencyRuleEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthQuestionDependencyRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthQuestionDependencyRuleEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MedicalHistoryReadingAssosciationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalHistoryReadingAssosciationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerHealthQuestionGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionGroupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReadingEntityFactory))) : null);
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
			toReturn.Add("CustomerHealthQuestionGroup", _customerHealthQuestionGroup);
			toReturn.Add("CustomerHealthQuestions", _customerHealthQuestions);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("ClinicalTestQualificationCriteria_", _clinicalTestQualificationCriteria_);
			toReturn.Add("ClinicalTestQualificationCriteria", _clinicalTestQualificationCriteria);
			toReturn.Add("CustomerClinicalQuestionAnswer", _customerClinicalQuestionAnswer);
			toReturn.Add("CustomerHealthInfo", _customerHealthInfo);
			toReturn.Add("CustomerHealthInfoArchive", _customerHealthInfoArchive);
			toReturn.Add("CustomerHealthQuestions_", _customerHealthQuestions_);
			toReturn.Add("HafTemplateQuestion", _hafTemplateQuestion);
			toReturn.Add("HealthQuestionDependencyRule_", _healthQuestionDependencyRule_);
			toReturn.Add("HealthQuestionDependencyRule", _healthQuestionDependencyRule);
			toReturn.Add("MedicalHistoryReadingAssosciation", _medicalHistoryReadingAssosciation);
			toReturn.Add("CustomerHealthQuestionGroupCollectionViaCustomerHealthQuestions", _customerHealthQuestionGroupCollectionViaCustomerHealthQuestions);
			toReturn.Add("CustomerProfileCollectionViaCustomerHealthInfo", _customerProfileCollectionViaCustomerHealthInfo);
			toReturn.Add("CustomerProfileCollectionViaCustomerClinicalQuestionAnswer", _customerProfileCollectionViaCustomerClinicalQuestionAnswer);
			toReturn.Add("CustomerProfileCollectionViaCustomerHealthInfoArchive", _customerProfileCollectionViaCustomerHealthInfoArchive);
			toReturn.Add("EventCustomersCollectionViaCustomerHealthInfoArchive", _eventCustomersCollectionViaCustomerHealthInfoArchive);
			toReturn.Add("EventCustomersCollectionViaCustomerHealthInfo", _eventCustomersCollectionViaCustomerHealthInfo);
			toReturn.Add("EventsCollectionViaCustomerClinicalQuestionAnswer", _eventsCollectionViaCustomerClinicalQuestionAnswer);
			toReturn.Add("HafTemplateCollectionViaHafTemplateQuestion", _hafTemplateCollectionViaHafTemplateQuestion);
			toReturn.Add("HafTemplateCollectionViaClinicalTestQualificationCriteria", _hafTemplateCollectionViaClinicalTestQualificationCriteria);
			toReturn.Add("HafTemplateCollectionViaCustomerClinicalQuestionAnswer", _hafTemplateCollectionViaCustomerClinicalQuestionAnswer);
			toReturn.Add("HafTemplateCollectionViaClinicalTestQualificationCriteria_", _hafTemplateCollectionViaClinicalTestQualificationCriteria_);
			toReturn.Add("LookupCollectionViaClinicalTestQualificationCriteria__", _lookupCollectionViaClinicalTestQualificationCriteria__);
			toReturn.Add("LookupCollectionViaCustomerHealthQuestions", _lookupCollectionViaCustomerHealthQuestions);
			toReturn.Add("LookupCollectionViaClinicalTestQualificationCriteria___", _lookupCollectionViaClinicalTestQualificationCriteria___);
			toReturn.Add("LookupCollectionViaClinicalTestQualificationCriteria", _lookupCollectionViaClinicalTestQualificationCriteria);
			toReturn.Add("LookupCollectionViaClinicalTestQualificationCriteria_", _lookupCollectionViaClinicalTestQualificationCriteria_);
			toReturn.Add("OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_", _organizationRoleUserCollectionViaClinicalTestQualificationCriteria_);
			toReturn.Add("OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria___", _organizationRoleUserCollectionViaClinicalTestQualificationCriteria___);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerHealthInfoArchive", _organizationRoleUserCollectionViaCustomerHealthInfoArchive);
			toReturn.Add("OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria", _organizationRoleUserCollectionViaClinicalTestQualificationCriteria);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer", _organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer);
			toReturn.Add("OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria__", _organizationRoleUserCollectionViaClinicalTestQualificationCriteria__);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerHealthInfo", _organizationRoleUserCollectionViaCustomerHealthInfo);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_", _organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_);
			toReturn.Add("ReadingCollectionViaMedicalHistoryReadingAssosciation", _readingCollectionViaMedicalHistoryReadingAssosciation);
			toReturn.Add("TestCollectionViaClinicalTestQualificationCriteria", _testCollectionViaClinicalTestQualificationCriteria);
			toReturn.Add("TestCollectionViaClinicalTestQualificationCriteria_", _testCollectionViaClinicalTestQualificationCriteria_);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_clinicalTestQualificationCriteria_!=null)
			{
				_clinicalTestQualificationCriteria_.ActiveContext = base.ActiveContext;
			}
			if(_clinicalTestQualificationCriteria!=null)
			{
				_clinicalTestQualificationCriteria.ActiveContext = base.ActiveContext;
			}
			if(_customerClinicalQuestionAnswer!=null)
			{
				_customerClinicalQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_customerHealthInfo!=null)
			{
				_customerHealthInfo.ActiveContext = base.ActiveContext;
			}
			if(_customerHealthInfoArchive!=null)
			{
				_customerHealthInfoArchive.ActiveContext = base.ActiveContext;
			}
			if(_customerHealthQuestions_!=null)
			{
				_customerHealthQuestions_.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplateQuestion!=null)
			{
				_hafTemplateQuestion.ActiveContext = base.ActiveContext;
			}
			if(_healthQuestionDependencyRule_!=null)
			{
				_healthQuestionDependencyRule_.ActiveContext = base.ActiveContext;
			}
			if(_healthQuestionDependencyRule!=null)
			{
				_healthQuestionDependencyRule.ActiveContext = base.ActiveContext;
			}
			if(_medicalHistoryReadingAssosciation!=null)
			{
				_medicalHistoryReadingAssosciation.ActiveContext = base.ActiveContext;
			}
			if(_customerHealthQuestionGroupCollectionViaCustomerHealthQuestions!=null)
			{
				_customerHealthQuestionGroupCollectionViaCustomerHealthQuestions.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerHealthInfo!=null)
			{
				_customerProfileCollectionViaCustomerHealthInfo.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerClinicalQuestionAnswer!=null)
			{
				_customerProfileCollectionViaCustomerClinicalQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerHealthInfoArchive!=null)
			{
				_customerProfileCollectionViaCustomerHealthInfoArchive.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaCustomerHealthInfoArchive!=null)
			{
				_eventCustomersCollectionViaCustomerHealthInfoArchive.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaCustomerHealthInfo!=null)
			{
				_eventCustomersCollectionViaCustomerHealthInfo.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaCustomerClinicalQuestionAnswer!=null)
			{
				_eventsCollectionViaCustomerClinicalQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplateCollectionViaHafTemplateQuestion!=null)
			{
				_hafTemplateCollectionViaHafTemplateQuestion.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplateCollectionViaClinicalTestQualificationCriteria!=null)
			{
				_hafTemplateCollectionViaClinicalTestQualificationCriteria.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplateCollectionViaCustomerClinicalQuestionAnswer!=null)
			{
				_hafTemplateCollectionViaCustomerClinicalQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplateCollectionViaClinicalTestQualificationCriteria_!=null)
			{
				_hafTemplateCollectionViaClinicalTestQualificationCriteria_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaClinicalTestQualificationCriteria__!=null)
			{
				_lookupCollectionViaClinicalTestQualificationCriteria__.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerHealthQuestions!=null)
			{
				_lookupCollectionViaCustomerHealthQuestions.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaClinicalTestQualificationCriteria___!=null)
			{
				_lookupCollectionViaClinicalTestQualificationCriteria___.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaClinicalTestQualificationCriteria!=null)
			{
				_lookupCollectionViaClinicalTestQualificationCriteria.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaClinicalTestQualificationCriteria_!=null)
			{
				_lookupCollectionViaClinicalTestQualificationCriteria_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_!=null)
			{
				_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaClinicalTestQualificationCriteria___!=null)
			{
				_organizationRoleUserCollectionViaClinicalTestQualificationCriteria___.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerHealthInfoArchive!=null)
			{
				_organizationRoleUserCollectionViaCustomerHealthInfoArchive.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaClinicalTestQualificationCriteria!=null)
			{
				_organizationRoleUserCollectionViaClinicalTestQualificationCriteria.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer!=null)
			{
				_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaClinicalTestQualificationCriteria__!=null)
			{
				_organizationRoleUserCollectionViaClinicalTestQualificationCriteria__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerHealthInfo!=null)
			{
				_organizationRoleUserCollectionViaCustomerHealthInfo.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_!=null)
			{
				_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_.ActiveContext = base.ActiveContext;
			}
			if(_readingCollectionViaMedicalHistoryReadingAssosciation!=null)
			{
				_readingCollectionViaMedicalHistoryReadingAssosciation.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaClinicalTestQualificationCriteria!=null)
			{
				_testCollectionViaClinicalTestQualificationCriteria.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaClinicalTestQualificationCriteria_!=null)
			{
				_testCollectionViaClinicalTestQualificationCriteria_.ActiveContext = base.ActiveContext;
			}
			if(_customerHealthQuestionGroup!=null)
			{
				_customerHealthQuestionGroup.ActiveContext = base.ActiveContext;
			}
			if(_customerHealthQuestions!=null)
			{
				_customerHealthQuestions.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_clinicalTestQualificationCriteria_ = null;
			_clinicalTestQualificationCriteria = null;
			_customerClinicalQuestionAnswer = null;
			_customerHealthInfo = null;
			_customerHealthInfoArchive = null;
			_customerHealthQuestions_ = null;
			_hafTemplateQuestion = null;
			_healthQuestionDependencyRule_ = null;
			_healthQuestionDependencyRule = null;
			_medicalHistoryReadingAssosciation = null;
			_customerHealthQuestionGroupCollectionViaCustomerHealthQuestions = null;
			_customerProfileCollectionViaCustomerHealthInfo = null;
			_customerProfileCollectionViaCustomerClinicalQuestionAnswer = null;
			_customerProfileCollectionViaCustomerHealthInfoArchive = null;
			_eventCustomersCollectionViaCustomerHealthInfoArchive = null;
			_eventCustomersCollectionViaCustomerHealthInfo = null;
			_eventsCollectionViaCustomerClinicalQuestionAnswer = null;
			_hafTemplateCollectionViaHafTemplateQuestion = null;
			_hafTemplateCollectionViaClinicalTestQualificationCriteria = null;
			_hafTemplateCollectionViaCustomerClinicalQuestionAnswer = null;
			_hafTemplateCollectionViaClinicalTestQualificationCriteria_ = null;
			_lookupCollectionViaClinicalTestQualificationCriteria__ = null;
			_lookupCollectionViaCustomerHealthQuestions = null;
			_lookupCollectionViaClinicalTestQualificationCriteria___ = null;
			_lookupCollectionViaClinicalTestQualificationCriteria = null;
			_lookupCollectionViaClinicalTestQualificationCriteria_ = null;
			_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_ = null;
			_organizationRoleUserCollectionViaClinicalTestQualificationCriteria___ = null;
			_organizationRoleUserCollectionViaCustomerHealthInfoArchive = null;
			_organizationRoleUserCollectionViaClinicalTestQualificationCriteria = null;
			_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer = null;
			_organizationRoleUserCollectionViaClinicalTestQualificationCriteria__ = null;
			_organizationRoleUserCollectionViaCustomerHealthInfo = null;
			_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_ = null;
			_readingCollectionViaMedicalHistoryReadingAssosciation = null;
			_testCollectionViaClinicalTestQualificationCriteria = null;
			_testCollectionViaClinicalTestQualificationCriteria_ = null;
			_customerHealthQuestionGroup = null;
			_customerHealthQuestions = null;
			_lookup = null;

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

			_fieldsCustomProperties.Add("CustomerHealthQuestionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerHealthQuestionGroupId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Question", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Label", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ControlType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ControlValues", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ControlValueDelimiter", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsRequired", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DisplaySequence", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DefaultValue", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentQuestionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsForFemale", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _customerHealthQuestionGroup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerHealthQuestionGroup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerHealthQuestionGroup, new PropertyChangedEventHandler( OnCustomerHealthQuestionGroupPropertyChanged ), "CustomerHealthQuestionGroup", CustomerHealthQuestionsEntity.Relations.CustomerHealthQuestionGroupEntityUsingCustomerHealthQuestionGroupId, true, signalRelatedEntity, "CustomerHealthQuestions", resetFKFields, new int[] { (int)CustomerHealthQuestionsFieldIndex.CustomerHealthQuestionGroupId } );		
			_customerHealthQuestionGroup = null;
		}

		/// <summary> setups the sync logic for member _customerHealthQuestionGroup</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerHealthQuestionGroup(IEntity2 relatedEntity)
		{
			if(_customerHealthQuestionGroup!=relatedEntity)
			{
				DesetupSyncCustomerHealthQuestionGroup(true, true);
				_customerHealthQuestionGroup = (CustomerHealthQuestionGroupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerHealthQuestionGroup, new PropertyChangedEventHandler( OnCustomerHealthQuestionGroupPropertyChanged ), "CustomerHealthQuestionGroup", CustomerHealthQuestionsEntity.Relations.CustomerHealthQuestionGroupEntityUsingCustomerHealthQuestionGroupId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerHealthQuestionGroupPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _customerHealthQuestions</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerHealthQuestions(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerHealthQuestions, new PropertyChangedEventHandler( OnCustomerHealthQuestionsPropertyChanged ), "CustomerHealthQuestions", CustomerHealthQuestionsEntity.Relations.CustomerHealthQuestionsEntityUsingCustomerHealthQuestionIdParentQuestionId, true, signalRelatedEntity, "CustomerHealthQuestions_", resetFKFields, new int[] { (int)CustomerHealthQuestionsFieldIndex.ParentQuestionId } );		
			_customerHealthQuestions = null;
		}

		/// <summary> setups the sync logic for member _customerHealthQuestions</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerHealthQuestions(IEntity2 relatedEntity)
		{
			if(_customerHealthQuestions!=relatedEntity)
			{
				DesetupSyncCustomerHealthQuestions(true, true);
				_customerHealthQuestions = (CustomerHealthQuestionsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerHealthQuestions, new PropertyChangedEventHandler( OnCustomerHealthQuestionsPropertyChanged ), "CustomerHealthQuestions", CustomerHealthQuestionsEntity.Relations.CustomerHealthQuestionsEntityUsingCustomerHealthQuestionIdParentQuestionId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerHealthQuestionsPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CustomerHealthQuestionsEntity.Relations.LookupEntityUsingControlType, true, signalRelatedEntity, "CustomerHealthQuestions", resetFKFields, new int[] { (int)CustomerHealthQuestionsFieldIndex.ControlType } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CustomerHealthQuestionsEntity.Relations.LookupEntityUsingControlType, true, new string[] {  } );
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


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this CustomerHealthQuestionsEntity</param>
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
		public  static CustomerHealthQuestionsRelations Relations
		{
			get	{ return new CustomerHealthQuestionsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ClinicalTestQualificationCriteria' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathClinicalTestQualificationCriteria_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ClinicalTestQualificationCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClinicalTestQualificationCriteriaEntityFactory))),
					(IEntityRelation)GetRelationsForField("ClinicalTestQualificationCriteria_")[0], (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.ClinicalTestQualificationCriteriaEntity, 0, null, null, null, null, "ClinicalTestQualificationCriteria_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("ClinicalTestQualificationCriteria")[0], (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.ClinicalTestQualificationCriteriaEntity, 0, null, null, null, null, "ClinicalTestQualificationCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerClinicalQuestionAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerClinicalQuestionAnswer
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerClinicalQuestionAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerClinicalQuestionAnswerEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerClinicalQuestionAnswer")[0], (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.CustomerClinicalQuestionAnswerEntity, 0, null, null, null, null, "CustomerClinicalQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("CustomerHealthInfo")[0], (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.CustomerHealthInfoEntity, 0, null, null, null, null, "CustomerHealthInfo", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("CustomerHealthInfoArchive")[0], (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.CustomerHealthInfoArchiveEntity, 0, null, null, null, null, "CustomerHealthInfoArchive", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerHealthQuestions' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerHealthQuestions_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerHealthQuestions_")[0], (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, 0, null, null, null, null, "CustomerHealthQuestions_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplateQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplateQuestion
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HafTemplateQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("HafTemplateQuestion")[0], (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.HafTemplateQuestionEntity, 0, null, null, null, null, "HafTemplateQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HealthQuestionDependencyRule' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHealthQuestionDependencyRule_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HealthQuestionDependencyRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthQuestionDependencyRuleEntityFactory))),
					(IEntityRelation)GetRelationsForField("HealthQuestionDependencyRule_")[0], (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.HealthQuestionDependencyRuleEntity, 0, null, null, null, null, "HealthQuestionDependencyRule_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HealthQuestionDependencyRule' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHealthQuestionDependencyRule
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HealthQuestionDependencyRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthQuestionDependencyRuleEntityFactory))),
					(IEntityRelation)GetRelationsForField("HealthQuestionDependencyRule")[0], (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.HealthQuestionDependencyRuleEntity, 0, null, null, null, null, "HealthQuestionDependencyRule", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicalHistoryReadingAssosciation' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicalHistoryReadingAssosciation
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MedicalHistoryReadingAssosciationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalHistoryReadingAssosciationEntityFactory))),
					(IEntityRelation)GetRelationsForField("MedicalHistoryReadingAssosciation")[0], (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.MedicalHistoryReadingAssosciationEntity, 0, null, null, null, null, "MedicalHistoryReadingAssosciation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerHealthQuestionGroup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerHealthQuestionGroupCollectionViaCustomerHealthQuestions
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.CustomerHealthQuestionsEntityUsingParentQuestionId;
				intermediateRelation.SetAliases(string.Empty, "CustomerHealthQuestions_");
				return new PrefetchPathElement2(new EntityCollection<CustomerHealthQuestionGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionGroupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.CustomerHealthQuestionGroupEntity, 0, null, null, GetRelationsForField("CustomerHealthQuestionGroupCollectionViaCustomerHealthQuestions"), null, "CustomerHealthQuestionGroupCollectionViaCustomerHealthQuestions", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerHealthInfo
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.CustomerHealthInfoEntityUsingCustomerHealthQuestionId;
				intermediateRelation.SetAliases(string.Empty, "CustomerHealthInfo_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerHealthInfo"), null, "CustomerProfileCollectionViaCustomerHealthInfo", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerClinicalQuestionAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.CustomerClinicalQuestionAnswerEntityUsingClinicalHealthQuestionId;
				intermediateRelation.SetAliases(string.Empty, "CustomerClinicalQuestionAnswer_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerClinicalQuestionAnswer"), null, "CustomerProfileCollectionViaCustomerClinicalQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerHealthInfoArchive
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.CustomerHealthInfoArchiveEntityUsingCustomerHealthQuestionId;
				intermediateRelation.SetAliases(string.Empty, "CustomerHealthInfoArchive_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerHealthInfoArchive"), null, "CustomerProfileCollectionViaCustomerHealthInfoArchive", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaCustomerHealthInfoArchive
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.CustomerHealthInfoArchiveEntityUsingCustomerHealthQuestionId;
				intermediateRelation.SetAliases(string.Empty, "CustomerHealthInfoArchive_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaCustomerHealthInfoArchive"), null, "EventCustomersCollectionViaCustomerHealthInfoArchive", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaCustomerHealthInfo
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.CustomerHealthInfoEntityUsingCustomerHealthQuestionId;
				intermediateRelation.SetAliases(string.Empty, "CustomerHealthInfo_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaCustomerHealthInfo"), null, "EventCustomersCollectionViaCustomerHealthInfo", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaCustomerClinicalQuestionAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.CustomerClinicalQuestionAnswerEntityUsingClinicalHealthQuestionId;
				intermediateRelation.SetAliases(string.Empty, "CustomerClinicalQuestionAnswer_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaCustomerClinicalQuestionAnswer"), null, "EventsCollectionViaCustomerClinicalQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplateCollectionViaHafTemplateQuestion
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.HafTemplateQuestionEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "HafTemplateQuestion_");
				return new PrefetchPathElement2(new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, GetRelationsForField("HafTemplateCollectionViaHafTemplateQuestion"), null, "HafTemplateCollectionViaHafTemplateQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplateCollectionViaClinicalTestQualificationCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingMedicationQuestionId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, GetRelationsForField("HafTemplateCollectionViaClinicalTestQualificationCriteria"), null, "HafTemplateCollectionViaClinicalTestQualificationCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplateCollectionViaCustomerClinicalQuestionAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.CustomerClinicalQuestionAnswerEntityUsingClinicalHealthQuestionId;
				intermediateRelation.SetAliases(string.Empty, "CustomerClinicalQuestionAnswer_");
				return new PrefetchPathElement2(new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, GetRelationsForField("HafTemplateCollectionViaCustomerClinicalQuestionAnswer"), null, "HafTemplateCollectionViaCustomerClinicalQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplateCollectionViaClinicalTestQualificationCriteria_
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingDisqualifierQuestionId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, GetRelationsForField("HafTemplateCollectionViaClinicalTestQualificationCriteria_"), null, "HafTemplateCollectionViaClinicalTestQualificationCriteria_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaClinicalTestQualificationCriteria__
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingDisqualifierQuestionId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaClinicalTestQualificationCriteria__"), null, "LookupCollectionViaClinicalTestQualificationCriteria__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerHealthQuestions
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.CustomerHealthQuestionsEntityUsingParentQuestionId;
				intermediateRelation.SetAliases(string.Empty, "CustomerHealthQuestions_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerHealthQuestions"), null, "LookupCollectionViaCustomerHealthQuestions", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaClinicalTestQualificationCriteria___
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingDisqualifierQuestionId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaClinicalTestQualificationCriteria___"), null, "LookupCollectionViaClinicalTestQualificationCriteria___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaClinicalTestQualificationCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingMedicationQuestionId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaClinicalTestQualificationCriteria"), null, "LookupCollectionViaClinicalTestQualificationCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaClinicalTestQualificationCriteria_
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingMedicationQuestionId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaClinicalTestQualificationCriteria_"), null, "LookupCollectionViaClinicalTestQualificationCriteria_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingMedicationQuestionId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_"), null, "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaClinicalTestQualificationCriteria___
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingDisqualifierQuestionId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria___"), null, "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerHealthInfoArchive
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.CustomerHealthInfoArchiveEntityUsingCustomerHealthQuestionId;
				intermediateRelation.SetAliases(string.Empty, "CustomerHealthInfoArchive_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerHealthInfoArchive"), null, "OrganizationRoleUserCollectionViaCustomerHealthInfoArchive", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaClinicalTestQualificationCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingMedicationQuestionId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria"), null, "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.CustomerClinicalQuestionAnswerEntityUsingClinicalHealthQuestionId;
				intermediateRelation.SetAliases(string.Empty, "CustomerClinicalQuestionAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer"), null, "OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaClinicalTestQualificationCriteria__
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingDisqualifierQuestionId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria__"), null, "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerHealthInfo
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.CustomerHealthInfoEntityUsingCustomerHealthQuestionId;
				intermediateRelation.SetAliases(string.Empty, "CustomerHealthInfo_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerHealthInfo"), null, "OrganizationRoleUserCollectionViaCustomerHealthInfo", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.CustomerClinicalQuestionAnswerEntityUsingClinicalHealthQuestionId;
				intermediateRelation.SetAliases(string.Empty, "CustomerClinicalQuestionAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_"), null, "OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Reading' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathReadingCollectionViaMedicalHistoryReadingAssosciation
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.MedicalHistoryReadingAssosciationEntityUsingMedicalHistoryQuestionId;
				intermediateRelation.SetAliases(string.Empty, "MedicalHistoryReadingAssosciation_");
				return new PrefetchPathElement2(new EntityCollection<ReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReadingEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.ReadingEntity, 0, null, null, GetRelationsForField("ReadingCollectionViaMedicalHistoryReadingAssosciation"), null, "ReadingCollectionViaMedicalHistoryReadingAssosciation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaClinicalTestQualificationCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingMedicationQuestionId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaClinicalTestQualificationCriteria"), null, "TestCollectionViaClinicalTestQualificationCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaClinicalTestQualificationCriteria_
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerHealthQuestionsEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingDisqualifierQuestionId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaClinicalTestQualificationCriteria_"), null, "TestCollectionViaClinicalTestQualificationCriteria_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerHealthQuestionGroup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerHealthQuestionGroup
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionGroupEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerHealthQuestionGroup")[0], (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.CustomerHealthQuestionGroupEntity, 0, null, null, null, null, "CustomerHealthQuestionGroup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerHealthQuestions' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerHealthQuestions
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerHealthQuestions")[0], (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, 0, null, null, null, null, "CustomerHealthQuestions", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CustomerHealthQuestionsEntity.CustomProperties;}
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
			get { return CustomerHealthQuestionsEntity.FieldsCustomProperties;}
		}

		/// <summary> The CustomerHealthQuestionId property of the Entity CustomerHealthQuestions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerHealthQuestions"."CustomerHealthQuestionID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 CustomerHealthQuestionId
		{
			get { return (System.Int64)GetValue((int)CustomerHealthQuestionsFieldIndex.CustomerHealthQuestionId, true); }
			set	{ SetValue((int)CustomerHealthQuestionsFieldIndex.CustomerHealthQuestionId, value); }
		}

		/// <summary> The CustomerHealthQuestionGroupId property of the Entity CustomerHealthQuestions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerHealthQuestions"."CustomerHealthQuestionGroupID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerHealthQuestionGroupId
		{
			get { return (System.Int64)GetValue((int)CustomerHealthQuestionsFieldIndex.CustomerHealthQuestionGroupId, true); }
			set	{ SetValue((int)CustomerHealthQuestionsFieldIndex.CustomerHealthQuestionGroupId, value); }
		}

		/// <summary> The Question property of the Entity CustomerHealthQuestions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerHealthQuestions"."Question"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Question
		{
			get { return (System.String)GetValue((int)CustomerHealthQuestionsFieldIndex.Question, true); }
			set	{ SetValue((int)CustomerHealthQuestionsFieldIndex.Question, value); }
		}

		/// <summary> The Label property of the Entity CustomerHealthQuestions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerHealthQuestions"."Label"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Label
		{
			get { return (System.String)GetValue((int)CustomerHealthQuestionsFieldIndex.Label, true); }
			set	{ SetValue((int)CustomerHealthQuestionsFieldIndex.Label, value); }
		}

		/// <summary> The ControlType property of the Entity CustomerHealthQuestions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerHealthQuestions"."ControlType"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ControlType
		{
			get { return (System.Int64)GetValue((int)CustomerHealthQuestionsFieldIndex.ControlType, true); }
			set	{ SetValue((int)CustomerHealthQuestionsFieldIndex.ControlType, value); }
		}

		/// <summary> The ControlValues property of the Entity CustomerHealthQuestions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerHealthQuestions"."ControlValues"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 5000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ControlValues
		{
			get { return (System.String)GetValue((int)CustomerHealthQuestionsFieldIndex.ControlValues, true); }
			set	{ SetValue((int)CustomerHealthQuestionsFieldIndex.ControlValues, value); }
		}

		/// <summary> The ControlValueDelimiter property of the Entity CustomerHealthQuestions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerHealthQuestions"."ControlValueDelimiter"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ControlValueDelimiter
		{
			get { return (System.String)GetValue((int)CustomerHealthQuestionsFieldIndex.ControlValueDelimiter, true); }
			set	{ SetValue((int)CustomerHealthQuestionsFieldIndex.ControlValueDelimiter, value); }
		}

		/// <summary> The IsActive property of the Entity CustomerHealthQuestions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerHealthQuestions"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)CustomerHealthQuestionsFieldIndex.IsActive, true); }
			set	{ SetValue((int)CustomerHealthQuestionsFieldIndex.IsActive, value); }
		}

		/// <summary> The IsRequired property of the Entity CustomerHealthQuestions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerHealthQuestions"."IsRequired"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsRequired
		{
			get { return (Nullable<System.Boolean>)GetValue((int)CustomerHealthQuestionsFieldIndex.IsRequired, false); }
			set	{ SetValue((int)CustomerHealthQuestionsFieldIndex.IsRequired, value); }
		}

		/// <summary> The DisplaySequence property of the Entity CustomerHealthQuestions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerHealthQuestions"."DisplaySequence"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> DisplaySequence
		{
			get { return (Nullable<System.Int32>)GetValue((int)CustomerHealthQuestionsFieldIndex.DisplaySequence, false); }
			set	{ SetValue((int)CustomerHealthQuestionsFieldIndex.DisplaySequence, value); }
		}

		/// <summary> The DefaultValue property of the Entity CustomerHealthQuestions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerHealthQuestions"."DefaultValue"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String DefaultValue
		{
			get { return (System.String)GetValue((int)CustomerHealthQuestionsFieldIndex.DefaultValue, true); }
			set	{ SetValue((int)CustomerHealthQuestionsFieldIndex.DefaultValue, value); }
		}

		/// <summary> The ParentQuestionId property of the Entity CustomerHealthQuestions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerHealthQuestions"."ParentQuestionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentQuestionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerHealthQuestionsFieldIndex.ParentQuestionId, false); }
			set	{ SetValue((int)CustomerHealthQuestionsFieldIndex.ParentQuestionId, value); }
		}

		/// <summary> The IsForFemale property of the Entity CustomerHealthQuestions<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerHealthQuestions"."IsForFemale"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsForFemale
		{
			get { return (Nullable<System.Boolean>)GetValue((int)CustomerHealthQuestionsFieldIndex.IsForFemale, false); }
			set	{ SetValue((int)CustomerHealthQuestionsFieldIndex.IsForFemale, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ClinicalTestQualificationCriteriaEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ClinicalTestQualificationCriteriaEntity))]
		public virtual EntityCollection<ClinicalTestQualificationCriteriaEntity> ClinicalTestQualificationCriteria_
		{
			get
			{
				if(_clinicalTestQualificationCriteria_==null)
				{
					_clinicalTestQualificationCriteria_ = new EntityCollection<ClinicalTestQualificationCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClinicalTestQualificationCriteriaEntityFactory)));
					_clinicalTestQualificationCriteria_.SetContainingEntityInfo(this, "CustomerHealthQuestions_");
				}
				return _clinicalTestQualificationCriteria_;
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
					_clinicalTestQualificationCriteria.SetContainingEntityInfo(this, "CustomerHealthQuestions");
				}
				return _clinicalTestQualificationCriteria;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerClinicalQuestionAnswerEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerClinicalQuestionAnswerEntity))]
		public virtual EntityCollection<CustomerClinicalQuestionAnswerEntity> CustomerClinicalQuestionAnswer
		{
			get
			{
				if(_customerClinicalQuestionAnswer==null)
				{
					_customerClinicalQuestionAnswer = new EntityCollection<CustomerClinicalQuestionAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerClinicalQuestionAnswerEntityFactory)));
					_customerClinicalQuestionAnswer.SetContainingEntityInfo(this, "CustomerHealthQuestions");
				}
				return _customerClinicalQuestionAnswer;
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
					_customerHealthInfo.SetContainingEntityInfo(this, "CustomerHealthQuestions");
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
					_customerHealthInfoArchive.SetContainingEntityInfo(this, "CustomerHealthQuestions");
				}
				return _customerHealthInfoArchive;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerHealthQuestionsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerHealthQuestionsEntity))]
		public virtual EntityCollection<CustomerHealthQuestionsEntity> CustomerHealthQuestions_
		{
			get
			{
				if(_customerHealthQuestions_==null)
				{
					_customerHealthQuestions_ = new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory)));
					_customerHealthQuestions_.SetContainingEntityInfo(this, "CustomerHealthQuestions");
				}
				return _customerHealthQuestions_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HafTemplateQuestionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HafTemplateQuestionEntity))]
		public virtual EntityCollection<HafTemplateQuestionEntity> HafTemplateQuestion
		{
			get
			{
				if(_hafTemplateQuestion==null)
				{
					_hafTemplateQuestion = new EntityCollection<HafTemplateQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateQuestionEntityFactory)));
					_hafTemplateQuestion.SetContainingEntityInfo(this, "CustomerHealthQuestions");
				}
				return _hafTemplateQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HealthQuestionDependencyRuleEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HealthQuestionDependencyRuleEntity))]
		public virtual EntityCollection<HealthQuestionDependencyRuleEntity> HealthQuestionDependencyRule_
		{
			get
			{
				if(_healthQuestionDependencyRule_==null)
				{
					_healthQuestionDependencyRule_ = new EntityCollection<HealthQuestionDependencyRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthQuestionDependencyRuleEntityFactory)));
					_healthQuestionDependencyRule_.SetContainingEntityInfo(this, "CustomerHealthQuestions_");
				}
				return _healthQuestionDependencyRule_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HealthQuestionDependencyRuleEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HealthQuestionDependencyRuleEntity))]
		public virtual EntityCollection<HealthQuestionDependencyRuleEntity> HealthQuestionDependencyRule
		{
			get
			{
				if(_healthQuestionDependencyRule==null)
				{
					_healthQuestionDependencyRule = new EntityCollection<HealthQuestionDependencyRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthQuestionDependencyRuleEntityFactory)));
					_healthQuestionDependencyRule.SetContainingEntityInfo(this, "CustomerHealthQuestions");
				}
				return _healthQuestionDependencyRule;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MedicalHistoryReadingAssosciationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MedicalHistoryReadingAssosciationEntity))]
		public virtual EntityCollection<MedicalHistoryReadingAssosciationEntity> MedicalHistoryReadingAssosciation
		{
			get
			{
				if(_medicalHistoryReadingAssosciation==null)
				{
					_medicalHistoryReadingAssosciation = new EntityCollection<MedicalHistoryReadingAssosciationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MedicalHistoryReadingAssosciationEntityFactory)));
					_medicalHistoryReadingAssosciation.SetContainingEntityInfo(this, "CustomerHealthQuestions");
				}
				return _medicalHistoryReadingAssosciation;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerHealthQuestionGroupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerHealthQuestionGroupEntity))]
		public virtual EntityCollection<CustomerHealthQuestionGroupEntity> CustomerHealthQuestionGroupCollectionViaCustomerHealthQuestions
		{
			get
			{
				if(_customerHealthQuestionGroupCollectionViaCustomerHealthQuestions==null)
				{
					_customerHealthQuestionGroupCollectionViaCustomerHealthQuestions = new EntityCollection<CustomerHealthQuestionGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionGroupEntityFactory)));
					_customerHealthQuestionGroupCollectionViaCustomerHealthQuestions.IsReadOnly=true;
				}
				return _customerHealthQuestionGroupCollectionViaCustomerHealthQuestions;
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
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCustomerClinicalQuestionAnswer
		{
			get
			{
				if(_customerProfileCollectionViaCustomerClinicalQuestionAnswer==null)
				{
					_customerProfileCollectionViaCustomerClinicalQuestionAnswer = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCustomerClinicalQuestionAnswer.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCustomerClinicalQuestionAnswer;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaCustomerHealthInfoArchive
		{
			get
			{
				if(_eventCustomersCollectionViaCustomerHealthInfoArchive==null)
				{
					_eventCustomersCollectionViaCustomerHealthInfoArchive = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaCustomerHealthInfoArchive.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaCustomerHealthInfoArchive;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaCustomerHealthInfo
		{
			get
			{
				if(_eventCustomersCollectionViaCustomerHealthInfo==null)
				{
					_eventCustomersCollectionViaCustomerHealthInfo = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaCustomerHealthInfo.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaCustomerHealthInfo;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaCustomerClinicalQuestionAnswer
		{
			get
			{
				if(_eventsCollectionViaCustomerClinicalQuestionAnswer==null)
				{
					_eventsCollectionViaCustomerClinicalQuestionAnswer = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaCustomerClinicalQuestionAnswer.IsReadOnly=true;
				}
				return _eventsCollectionViaCustomerClinicalQuestionAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HafTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HafTemplateEntity))]
		public virtual EntityCollection<HafTemplateEntity> HafTemplateCollectionViaHafTemplateQuestion
		{
			get
			{
				if(_hafTemplateCollectionViaHafTemplateQuestion==null)
				{
					_hafTemplateCollectionViaHafTemplateQuestion = new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory)));
					_hafTemplateCollectionViaHafTemplateQuestion.IsReadOnly=true;
				}
				return _hafTemplateCollectionViaHafTemplateQuestion;
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
		public virtual EntityCollection<HafTemplateEntity> HafTemplateCollectionViaCustomerClinicalQuestionAnswer
		{
			get
			{
				if(_hafTemplateCollectionViaCustomerClinicalQuestionAnswer==null)
				{
					_hafTemplateCollectionViaCustomerClinicalQuestionAnswer = new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory)));
					_hafTemplateCollectionViaCustomerClinicalQuestionAnswer.IsReadOnly=true;
				}
				return _hafTemplateCollectionViaCustomerClinicalQuestionAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HafTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HafTemplateEntity))]
		public virtual EntityCollection<HafTemplateEntity> HafTemplateCollectionViaClinicalTestQualificationCriteria_
		{
			get
			{
				if(_hafTemplateCollectionViaClinicalTestQualificationCriteria_==null)
				{
					_hafTemplateCollectionViaClinicalTestQualificationCriteria_ = new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory)));
					_hafTemplateCollectionViaClinicalTestQualificationCriteria_.IsReadOnly=true;
				}
				return _hafTemplateCollectionViaClinicalTestQualificationCriteria_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaClinicalTestQualificationCriteria__
		{
			get
			{
				if(_lookupCollectionViaClinicalTestQualificationCriteria__==null)
				{
					_lookupCollectionViaClinicalTestQualificationCriteria__ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaClinicalTestQualificationCriteria__.IsReadOnly=true;
				}
				return _lookupCollectionViaClinicalTestQualificationCriteria__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerHealthQuestions
		{
			get
			{
				if(_lookupCollectionViaCustomerHealthQuestions==null)
				{
					_lookupCollectionViaCustomerHealthQuestions = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerHealthQuestions.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerHealthQuestions;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaClinicalTestQualificationCriteria___
		{
			get
			{
				if(_lookupCollectionViaClinicalTestQualificationCriteria___==null)
				{
					_lookupCollectionViaClinicalTestQualificationCriteria___ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaClinicalTestQualificationCriteria___.IsReadOnly=true;
				}
				return _lookupCollectionViaClinicalTestQualificationCriteria___;
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
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria___
		{
			get
			{
				if(_organizationRoleUserCollectionViaClinicalTestQualificationCriteria___==null)
				{
					_organizationRoleUserCollectionViaClinicalTestQualificationCriteria___ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaClinicalTestQualificationCriteria___.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaClinicalTestQualificationCriteria___;
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
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer==null)
				{
					_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria__
		{
			get
			{
				if(_organizationRoleUserCollectionViaClinicalTestQualificationCriteria__==null)
				{
					_organizationRoleUserCollectionViaClinicalTestQualificationCriteria__ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaClinicalTestQualificationCriteria__.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaClinicalTestQualificationCriteria__;
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
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_==null)
				{
					_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ReadingEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ReadingEntity))]
		public virtual EntityCollection<ReadingEntity> ReadingCollectionViaMedicalHistoryReadingAssosciation
		{
			get
			{
				if(_readingCollectionViaMedicalHistoryReadingAssosciation==null)
				{
					_readingCollectionViaMedicalHistoryReadingAssosciation = new EntityCollection<ReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReadingEntityFactory)));
					_readingCollectionViaMedicalHistoryReadingAssosciation.IsReadOnly=true;
				}
				return _readingCollectionViaMedicalHistoryReadingAssosciation;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaClinicalTestQualificationCriteria
		{
			get
			{
				if(_testCollectionViaClinicalTestQualificationCriteria==null)
				{
					_testCollectionViaClinicalTestQualificationCriteria = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaClinicalTestQualificationCriteria.IsReadOnly=true;
				}
				return _testCollectionViaClinicalTestQualificationCriteria;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaClinicalTestQualificationCriteria_
		{
			get
			{
				if(_testCollectionViaClinicalTestQualificationCriteria_==null)
				{
					_testCollectionViaClinicalTestQualificationCriteria_ = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaClinicalTestQualificationCriteria_.IsReadOnly=true;
				}
				return _testCollectionViaClinicalTestQualificationCriteria_;
			}
		}

		/// <summary> Gets / sets related entity of type 'CustomerHealthQuestionGroupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerHealthQuestionGroupEntity CustomerHealthQuestionGroup
		{
			get
			{
				return _customerHealthQuestionGroup;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerHealthQuestionGroup(value);
				}
				else
				{
					if(value==null)
					{
						if(_customerHealthQuestionGroup != null)
						{
							_customerHealthQuestionGroup.UnsetRelatedEntity(this, "CustomerHealthQuestions");
						}
					}
					else
					{
						if(_customerHealthQuestionGroup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerHealthQuestions");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CustomerHealthQuestionsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerHealthQuestionsEntity CustomerHealthQuestions
		{
			get
			{
				return _customerHealthQuestions;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerHealthQuestions(value);
				}
				else
				{
					if(value==null)
					{
						if(_customerHealthQuestions != null)
						{
							_customerHealthQuestions.UnsetRelatedEntity(this, "CustomerHealthQuestions_");
						}
					}
					else
					{
						if(_customerHealthQuestions!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerHealthQuestions_");
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
							_lookup.UnsetRelatedEntity(this, "CustomerHealthQuestions");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerHealthQuestions");
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
			get { return (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity; }
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
