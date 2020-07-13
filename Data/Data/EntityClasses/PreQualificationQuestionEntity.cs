///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:52
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
	/// Entity class which represents the entity 'PreQualificationQuestion'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class PreQualificationQuestionEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<DisqualifiedTestEntity> _disqualifiedTest;
		private EntityCollection<EventCustomerQuestionAnswerEntity> _eventCustomerQuestionAnswer;
		private EntityCollection<PreQualificationQuestionRuleEntity> _preQualificationQuestionRule_;
		private EntityCollection<PreQualificationQuestionRuleEntity> _preQualificationQuestionRule;
		private EntityCollection<PreQualificationTemplateQuestionEntity> _preQualificationTemplateQuestion;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaEventCustomerQuestionAnswer;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaDisqualifiedTest;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaEventCustomerQuestionAnswer;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaDisqualifiedTest;
		private EntityCollection<EventsEntity> _eventsCollectionViaDisqualifiedTest;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventCustomerQuestionAnswer;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventCustomerQuestionAnswer;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaDisqualifiedTest;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaDisqualifiedTest_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventCustomerQuestionAnswer_;
		private EntityCollection<PreQualificationTestTemplateEntity> _preQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion;
		private EntityCollection<TestEntity> _testCollectionViaDisqualifiedTest;
		private LookupEntity _lookup;
		private OrganizationRoleUserEntity _organizationRoleUser;
		private TestEntity _test;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name Test</summary>
			public static readonly string Test = "Test";
			/// <summary>Member name DisqualifiedTest</summary>
			public static readonly string DisqualifiedTest = "DisqualifiedTest";
			/// <summary>Member name EventCustomerQuestionAnswer</summary>
			public static readonly string EventCustomerQuestionAnswer = "EventCustomerQuestionAnswer";
			/// <summary>Member name PreQualificationQuestionRule_</summary>
			public static readonly string PreQualificationQuestionRule_ = "PreQualificationQuestionRule_";
			/// <summary>Member name PreQualificationQuestionRule</summary>
			public static readonly string PreQualificationQuestionRule = "PreQualificationQuestionRule";
			/// <summary>Member name PreQualificationTemplateQuestion</summary>
			public static readonly string PreQualificationTemplateQuestion = "PreQualificationTemplateQuestion";
			/// <summary>Member name CustomerProfileCollectionViaEventCustomerQuestionAnswer</summary>
			public static readonly string CustomerProfileCollectionViaEventCustomerQuestionAnswer = "CustomerProfileCollectionViaEventCustomerQuestionAnswer";
			/// <summary>Member name CustomerProfileCollectionViaDisqualifiedTest</summary>
			public static readonly string CustomerProfileCollectionViaDisqualifiedTest = "CustomerProfileCollectionViaDisqualifiedTest";
			/// <summary>Member name EventCustomersCollectionViaEventCustomerQuestionAnswer</summary>
			public static readonly string EventCustomersCollectionViaEventCustomerQuestionAnswer = "EventCustomersCollectionViaEventCustomerQuestionAnswer";
			/// <summary>Member name EventCustomersCollectionViaDisqualifiedTest</summary>
			public static readonly string EventCustomersCollectionViaDisqualifiedTest = "EventCustomersCollectionViaDisqualifiedTest";
			/// <summary>Member name EventsCollectionViaDisqualifiedTest</summary>
			public static readonly string EventsCollectionViaDisqualifiedTest = "EventsCollectionViaDisqualifiedTest";
			/// <summary>Member name EventsCollectionViaEventCustomerQuestionAnswer</summary>
			public static readonly string EventsCollectionViaEventCustomerQuestionAnswer = "EventsCollectionViaEventCustomerQuestionAnswer";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer = "OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer";
			/// <summary>Member name OrganizationRoleUserCollectionViaDisqualifiedTest</summary>
			public static readonly string OrganizationRoleUserCollectionViaDisqualifiedTest = "OrganizationRoleUserCollectionViaDisqualifiedTest";
			/// <summary>Member name OrganizationRoleUserCollectionViaDisqualifiedTest_</summary>
			public static readonly string OrganizationRoleUserCollectionViaDisqualifiedTest_ = "OrganizationRoleUserCollectionViaDisqualifiedTest_";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_ = "OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_";
			/// <summary>Member name PreQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion</summary>
			public static readonly string PreQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion = "PreQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion";
			/// <summary>Member name TestCollectionViaDisqualifiedTest</summary>
			public static readonly string TestCollectionViaDisqualifiedTest = "TestCollectionViaDisqualifiedTest";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static PreQualificationQuestionEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public PreQualificationQuestionEntity():base("PreQualificationQuestionEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public PreQualificationQuestionEntity(IEntityFields2 fields):base("PreQualificationQuestionEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this PreQualificationQuestionEntity</param>
		public PreQualificationQuestionEntity(IValidator validator):base("PreQualificationQuestionEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for PreQualificationQuestion which data should be fetched into this PreQualificationQuestion object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PreQualificationQuestionEntity(System.Int64 id):base("PreQualificationQuestionEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for PreQualificationQuestion which data should be fetched into this PreQualificationQuestion object</param>
		/// <param name="validator">The custom validator object for this PreQualificationQuestionEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PreQualificationQuestionEntity(System.Int64 id, IValidator validator):base("PreQualificationQuestionEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected PreQualificationQuestionEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_disqualifiedTest = (EntityCollection<DisqualifiedTestEntity>)info.GetValue("_disqualifiedTest", typeof(EntityCollection<DisqualifiedTestEntity>));
				_eventCustomerQuestionAnswer = (EntityCollection<EventCustomerQuestionAnswerEntity>)info.GetValue("_eventCustomerQuestionAnswer", typeof(EntityCollection<EventCustomerQuestionAnswerEntity>));
				_preQualificationQuestionRule_ = (EntityCollection<PreQualificationQuestionRuleEntity>)info.GetValue("_preQualificationQuestionRule_", typeof(EntityCollection<PreQualificationQuestionRuleEntity>));
				_preQualificationQuestionRule = (EntityCollection<PreQualificationQuestionRuleEntity>)info.GetValue("_preQualificationQuestionRule", typeof(EntityCollection<PreQualificationQuestionRuleEntity>));
				_preQualificationTemplateQuestion = (EntityCollection<PreQualificationTemplateQuestionEntity>)info.GetValue("_preQualificationTemplateQuestion", typeof(EntityCollection<PreQualificationTemplateQuestionEntity>));
				_customerProfileCollectionViaEventCustomerQuestionAnswer = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaEventCustomerQuestionAnswer", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaDisqualifiedTest = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaDisqualifiedTest", typeof(EntityCollection<CustomerProfileEntity>));
				_eventCustomersCollectionViaEventCustomerQuestionAnswer = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaEventCustomerQuestionAnswer", typeof(EntityCollection<EventCustomersEntity>));
				_eventCustomersCollectionViaDisqualifiedTest = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaDisqualifiedTest", typeof(EntityCollection<EventCustomersEntity>));
				_eventsCollectionViaDisqualifiedTest = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaDisqualifiedTest", typeof(EntityCollection<EventsEntity>));
				_eventsCollectionViaEventCustomerQuestionAnswer = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventCustomerQuestionAnswer", typeof(EntityCollection<EventsEntity>));
				_organizationRoleUserCollectionViaEventCustomerQuestionAnswer = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventCustomerQuestionAnswer", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaDisqualifiedTest = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaDisqualifiedTest", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaDisqualifiedTest_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaDisqualifiedTest_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventCustomerQuestionAnswer_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventCustomerQuestionAnswer_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_preQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion = (EntityCollection<PreQualificationTestTemplateEntity>)info.GetValue("_preQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion", typeof(EntityCollection<PreQualificationTestTemplateEntity>));
				_testCollectionViaDisqualifiedTest = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaDisqualifiedTest", typeof(EntityCollection<TestEntity>));
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser!=null)
				{
					_organizationRoleUser.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_test = (TestEntity)info.GetValue("_test", typeof(TestEntity));
				if(_test!=null)
				{
					_test.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((PreQualificationQuestionFieldIndex)fieldIndex)
			{
				case PreQualificationQuestionFieldIndex.TestId:
					DesetupSyncTest(true, false);
					break;
				case PreQualificationQuestionFieldIndex.CreatedBy:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case PreQualificationQuestionFieldIndex.TypeId:
					DesetupSyncLookup(true, false);
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
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "Test":
					this.Test = (TestEntity)entity;
					break;
				case "DisqualifiedTest":
					this.DisqualifiedTest.Add((DisqualifiedTestEntity)entity);
					break;
				case "EventCustomerQuestionAnswer":
					this.EventCustomerQuestionAnswer.Add((EventCustomerQuestionAnswerEntity)entity);
					break;
				case "PreQualificationQuestionRule_":
					this.PreQualificationQuestionRule_.Add((PreQualificationQuestionRuleEntity)entity);
					break;
				case "PreQualificationQuestionRule":
					this.PreQualificationQuestionRule.Add((PreQualificationQuestionRuleEntity)entity);
					break;
				case "PreQualificationTemplateQuestion":
					this.PreQualificationTemplateQuestion.Add((PreQualificationTemplateQuestionEntity)entity);
					break;
				case "CustomerProfileCollectionViaEventCustomerQuestionAnswer":
					this.CustomerProfileCollectionViaEventCustomerQuestionAnswer.IsReadOnly = false;
					this.CustomerProfileCollectionViaEventCustomerQuestionAnswer.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaEventCustomerQuestionAnswer.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaDisqualifiedTest":
					this.CustomerProfileCollectionViaDisqualifiedTest.IsReadOnly = false;
					this.CustomerProfileCollectionViaDisqualifiedTest.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaDisqualifiedTest.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaEventCustomerQuestionAnswer":
					this.EventCustomersCollectionViaEventCustomerQuestionAnswer.IsReadOnly = false;
					this.EventCustomersCollectionViaEventCustomerQuestionAnswer.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaEventCustomerQuestionAnswer.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaDisqualifiedTest":
					this.EventCustomersCollectionViaDisqualifiedTest.IsReadOnly = false;
					this.EventCustomersCollectionViaDisqualifiedTest.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaDisqualifiedTest.IsReadOnly = true;
					break;
				case "EventsCollectionViaDisqualifiedTest":
					this.EventsCollectionViaDisqualifiedTest.IsReadOnly = false;
					this.EventsCollectionViaDisqualifiedTest.Add((EventsEntity)entity);
					this.EventsCollectionViaDisqualifiedTest.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventCustomerQuestionAnswer":
					this.EventsCollectionViaEventCustomerQuestionAnswer.IsReadOnly = false;
					this.EventsCollectionViaEventCustomerQuestionAnswer.Add((EventsEntity)entity);
					this.EventsCollectionViaEventCustomerQuestionAnswer.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer":
					this.OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaDisqualifiedTest":
					this.OrganizationRoleUserCollectionViaDisqualifiedTest.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaDisqualifiedTest.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaDisqualifiedTest.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaDisqualifiedTest_":
					this.OrganizationRoleUserCollectionViaDisqualifiedTest_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaDisqualifiedTest_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaDisqualifiedTest_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_":
					this.OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_.IsReadOnly = true;
					break;
				case "PreQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion":
					this.PreQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion.IsReadOnly = false;
					this.PreQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion.Add((PreQualificationTestTemplateEntity)entity);
					this.PreQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion.IsReadOnly = true;
					break;
				case "TestCollectionViaDisqualifiedTest":
					this.TestCollectionViaDisqualifiedTest.IsReadOnly = false;
					this.TestCollectionViaDisqualifiedTest.Add((TestEntity)entity);
					this.TestCollectionViaDisqualifiedTest.IsReadOnly = true;
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
			return PreQualificationQuestionEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Lookup":
					toReturn.Add(PreQualificationQuestionEntity.Relations.LookupEntityUsingTypeId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(PreQualificationQuestionEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy);
					break;
				case "Test":
					toReturn.Add(PreQualificationQuestionEntity.Relations.TestEntityUsingTestId);
					break;
				case "DisqualifiedTest":
					toReturn.Add(PreQualificationQuestionEntity.Relations.DisqualifiedTestEntityUsingQuestionId);
					break;
				case "EventCustomerQuestionAnswer":
					toReturn.Add(PreQualificationQuestionEntity.Relations.EventCustomerQuestionAnswerEntityUsingQuestionId);
					break;
				case "PreQualificationQuestionRule_":
					toReturn.Add(PreQualificationQuestionEntity.Relations.PreQualificationQuestionRuleEntityUsingDependentQuestionId);
					break;
				case "PreQualificationQuestionRule":
					toReturn.Add(PreQualificationQuestionEntity.Relations.PreQualificationQuestionRuleEntityUsingQuestionId);
					break;
				case "PreQualificationTemplateQuestion":
					toReturn.Add(PreQualificationQuestionEntity.Relations.PreQualificationTemplateQuestionEntityUsingQuestionId);
					break;
				case "CustomerProfileCollectionViaEventCustomerQuestionAnswer":
					toReturn.Add(PreQualificationQuestionEntity.Relations.EventCustomerQuestionAnswerEntityUsingQuestionId, "PreQualificationQuestionEntity__", "EventCustomerQuestionAnswer_", JoinHint.None);
					toReturn.Add(EventCustomerQuestionAnswerEntity.Relations.CustomerProfileEntityUsingCustomerId, "EventCustomerQuestionAnswer_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaDisqualifiedTest":
					toReturn.Add(PreQualificationQuestionEntity.Relations.DisqualifiedTestEntityUsingQuestionId, "PreQualificationQuestionEntity__", "DisqualifiedTest_", JoinHint.None);
					toReturn.Add(DisqualifiedTestEntity.Relations.CustomerProfileEntityUsingCustomerId, "DisqualifiedTest_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaEventCustomerQuestionAnswer":
					toReturn.Add(PreQualificationQuestionEntity.Relations.EventCustomerQuestionAnswerEntityUsingQuestionId, "PreQualificationQuestionEntity__", "EventCustomerQuestionAnswer_", JoinHint.None);
					toReturn.Add(EventCustomerQuestionAnswerEntity.Relations.EventCustomersEntityUsingEventCustomerId, "EventCustomerQuestionAnswer_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaDisqualifiedTest":
					toReturn.Add(PreQualificationQuestionEntity.Relations.DisqualifiedTestEntityUsingQuestionId, "PreQualificationQuestionEntity__", "DisqualifiedTest_", JoinHint.None);
					toReturn.Add(DisqualifiedTestEntity.Relations.EventCustomersEntityUsingEventCustomerId, "DisqualifiedTest_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaDisqualifiedTest":
					toReturn.Add(PreQualificationQuestionEntity.Relations.DisqualifiedTestEntityUsingQuestionId, "PreQualificationQuestionEntity__", "DisqualifiedTest_", JoinHint.None);
					toReturn.Add(DisqualifiedTestEntity.Relations.EventsEntityUsingEventId, "DisqualifiedTest_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventCustomerQuestionAnswer":
					toReturn.Add(PreQualificationQuestionEntity.Relations.EventCustomerQuestionAnswerEntityUsingQuestionId, "PreQualificationQuestionEntity__", "EventCustomerQuestionAnswer_", JoinHint.None);
					toReturn.Add(EventCustomerQuestionAnswerEntity.Relations.EventsEntityUsingEventId, "EventCustomerQuestionAnswer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer":
					toReturn.Add(PreQualificationQuestionEntity.Relations.EventCustomerQuestionAnswerEntityUsingQuestionId, "PreQualificationQuestionEntity__", "EventCustomerQuestionAnswer_", JoinHint.None);
					toReturn.Add(EventCustomerQuestionAnswerEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "EventCustomerQuestionAnswer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaDisqualifiedTest":
					toReturn.Add(PreQualificationQuestionEntity.Relations.DisqualifiedTestEntityUsingQuestionId, "PreQualificationQuestionEntity__", "DisqualifiedTest_", JoinHint.None);
					toReturn.Add(DisqualifiedTestEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "DisqualifiedTest_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaDisqualifiedTest_":
					toReturn.Add(PreQualificationQuestionEntity.Relations.DisqualifiedTestEntityUsingQuestionId, "PreQualificationQuestionEntity__", "DisqualifiedTest_", JoinHint.None);
					toReturn.Add(DisqualifiedTestEntity.Relations.OrganizationRoleUserEntityUsingUpdatedBy, "DisqualifiedTest_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_":
					toReturn.Add(PreQualificationQuestionEntity.Relations.EventCustomerQuestionAnswerEntityUsingQuestionId, "PreQualificationQuestionEntity__", "EventCustomerQuestionAnswer_", JoinHint.None);
					toReturn.Add(EventCustomerQuestionAnswerEntity.Relations.OrganizationRoleUserEntityUsingUpdatedBy, "EventCustomerQuestionAnswer_", string.Empty, JoinHint.None);
					break;
				case "PreQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion":
					toReturn.Add(PreQualificationQuestionEntity.Relations.PreQualificationTemplateQuestionEntityUsingQuestionId, "PreQualificationQuestionEntity__", "PreQualificationTemplateQuestion_", JoinHint.None);
					toReturn.Add(PreQualificationTemplateQuestionEntity.Relations.PreQualificationTestTemplateEntityUsingTemplateId, "PreQualificationTemplateQuestion_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaDisqualifiedTest":
					toReturn.Add(PreQualificationQuestionEntity.Relations.DisqualifiedTestEntityUsingQuestionId, "PreQualificationQuestionEntity__", "DisqualifiedTest_", JoinHint.None);
					toReturn.Add(DisqualifiedTestEntity.Relations.TestEntityUsingTestId, "DisqualifiedTest_", string.Empty, JoinHint.None);
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
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "Test":
					SetupSyncTest(relatedEntity);
					break;
				case "DisqualifiedTest":
					this.DisqualifiedTest.Add((DisqualifiedTestEntity)relatedEntity);
					break;
				case "EventCustomerQuestionAnswer":
					this.EventCustomerQuestionAnswer.Add((EventCustomerQuestionAnswerEntity)relatedEntity);
					break;
				case "PreQualificationQuestionRule_":
					this.PreQualificationQuestionRule_.Add((PreQualificationQuestionRuleEntity)relatedEntity);
					break;
				case "PreQualificationQuestionRule":
					this.PreQualificationQuestionRule.Add((PreQualificationQuestionRuleEntity)relatedEntity);
					break;
				case "PreQualificationTemplateQuestion":
					this.PreQualificationTemplateQuestion.Add((PreQualificationTemplateQuestionEntity)relatedEntity);
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
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "Test":
					DesetupSyncTest(false, true);
					break;
				case "DisqualifiedTest":
					base.PerformRelatedEntityRemoval(this.DisqualifiedTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerQuestionAnswer":
					base.PerformRelatedEntityRemoval(this.EventCustomerQuestionAnswer, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PreQualificationQuestionRule_":
					base.PerformRelatedEntityRemoval(this.PreQualificationQuestionRule_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PreQualificationQuestionRule":
					base.PerformRelatedEntityRemoval(this.PreQualificationQuestionRule, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PreQualificationTemplateQuestion":
					base.PerformRelatedEntityRemoval(this.PreQualificationTemplateQuestion, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
			}
			if(_organizationRoleUser!=null)
			{
				toReturn.Add(_organizationRoleUser);
			}
			if(_test!=null)
			{
				toReturn.Add(_test);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.DisqualifiedTest);
			toReturn.Add(this.EventCustomerQuestionAnswer);
			toReturn.Add(this.PreQualificationQuestionRule_);
			toReturn.Add(this.PreQualificationQuestionRule);
			toReturn.Add(this.PreQualificationTemplateQuestion);

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
				info.AddValue("_disqualifiedTest", ((_disqualifiedTest!=null) && (_disqualifiedTest.Count>0) && !this.MarkedForDeletion)?_disqualifiedTest:null);
				info.AddValue("_eventCustomerQuestionAnswer", ((_eventCustomerQuestionAnswer!=null) && (_eventCustomerQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_eventCustomerQuestionAnswer:null);
				info.AddValue("_preQualificationQuestionRule_", ((_preQualificationQuestionRule_!=null) && (_preQualificationQuestionRule_.Count>0) && !this.MarkedForDeletion)?_preQualificationQuestionRule_:null);
				info.AddValue("_preQualificationQuestionRule", ((_preQualificationQuestionRule!=null) && (_preQualificationQuestionRule.Count>0) && !this.MarkedForDeletion)?_preQualificationQuestionRule:null);
				info.AddValue("_preQualificationTemplateQuestion", ((_preQualificationTemplateQuestion!=null) && (_preQualificationTemplateQuestion.Count>0) && !this.MarkedForDeletion)?_preQualificationTemplateQuestion:null);
				info.AddValue("_customerProfileCollectionViaEventCustomerQuestionAnswer", ((_customerProfileCollectionViaEventCustomerQuestionAnswer!=null) && (_customerProfileCollectionViaEventCustomerQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaEventCustomerQuestionAnswer:null);
				info.AddValue("_customerProfileCollectionViaDisqualifiedTest", ((_customerProfileCollectionViaDisqualifiedTest!=null) && (_customerProfileCollectionViaDisqualifiedTest.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaDisqualifiedTest:null);
				info.AddValue("_eventCustomersCollectionViaEventCustomerQuestionAnswer", ((_eventCustomersCollectionViaEventCustomerQuestionAnswer!=null) && (_eventCustomersCollectionViaEventCustomerQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaEventCustomerQuestionAnswer:null);
				info.AddValue("_eventCustomersCollectionViaDisqualifiedTest", ((_eventCustomersCollectionViaDisqualifiedTest!=null) && (_eventCustomersCollectionViaDisqualifiedTest.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaDisqualifiedTest:null);
				info.AddValue("_eventsCollectionViaDisqualifiedTest", ((_eventsCollectionViaDisqualifiedTest!=null) && (_eventsCollectionViaDisqualifiedTest.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaDisqualifiedTest:null);
				info.AddValue("_eventsCollectionViaEventCustomerQuestionAnswer", ((_eventsCollectionViaEventCustomerQuestionAnswer!=null) && (_eventsCollectionViaEventCustomerQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventCustomerQuestionAnswer:null);
				info.AddValue("_organizationRoleUserCollectionViaEventCustomerQuestionAnswer", ((_organizationRoleUserCollectionViaEventCustomerQuestionAnswer!=null) && (_organizationRoleUserCollectionViaEventCustomerQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventCustomerQuestionAnswer:null);
				info.AddValue("_organizationRoleUserCollectionViaDisqualifiedTest", ((_organizationRoleUserCollectionViaDisqualifiedTest!=null) && (_organizationRoleUserCollectionViaDisqualifiedTest.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaDisqualifiedTest:null);
				info.AddValue("_organizationRoleUserCollectionViaDisqualifiedTest_", ((_organizationRoleUserCollectionViaDisqualifiedTest_!=null) && (_organizationRoleUserCollectionViaDisqualifiedTest_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaDisqualifiedTest_:null);
				info.AddValue("_organizationRoleUserCollectionViaEventCustomerQuestionAnswer_", ((_organizationRoleUserCollectionViaEventCustomerQuestionAnswer_!=null) && (_organizationRoleUserCollectionViaEventCustomerQuestionAnswer_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventCustomerQuestionAnswer_:null);
				info.AddValue("_preQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion", ((_preQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion!=null) && (_preQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion.Count>0) && !this.MarkedForDeletion)?_preQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion:null);
				info.AddValue("_testCollectionViaDisqualifiedTest", ((_testCollectionViaDisqualifiedTest!=null) && (_testCollectionViaDisqualifiedTest.Count>0) && !this.MarkedForDeletion)?_testCollectionViaDisqualifiedTest:null);
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));
				info.AddValue("_test", (!this.MarkedForDeletion?_test:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(PreQualificationQuestionFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(PreQualificationQuestionFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new PreQualificationQuestionRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DisqualifiedTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DisqualifiedTestFields.QuestionId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerQuestionAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerQuestionAnswerFields.QuestionId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PreQualificationQuestionRule' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPreQualificationQuestionRule_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationQuestionRuleFields.DependentQuestionId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PreQualificationQuestionRule' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPreQualificationQuestionRule()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationQuestionRuleFields.QuestionId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PreQualificationTemplateQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPreQualificationTemplateQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationTemplateQuestionFields.QuestionId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaEventCustomerQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaEventCustomerQuestionAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "PreQualificationQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaDisqualifiedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "PreQualificationQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaEventCustomerQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaEventCustomerQuestionAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "PreQualificationQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaDisqualifiedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "PreQualificationQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaDisqualifiedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "PreQualificationQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventCustomerQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventCustomerQuestionAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "PreQualificationQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventCustomerQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "PreQualificationQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaDisqualifiedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "PreQualificationQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaDisqualifiedTest_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaDisqualifiedTest_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "PreQualificationQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "PreQualificationQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PreQualificationTestTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPreQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PreQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "PreQualificationQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaDisqualifiedTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaDisqualifiedTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationQuestionFields.Id, null, ComparisonOperator.Equal, this.Id, "PreQualificationQuestionEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.TypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.CreatedBy));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Test' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.TestId, null, ComparisonOperator.Equal, this.TestId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.PreQualificationQuestionEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationQuestionEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._disqualifiedTest);
			collectionsQueue.Enqueue(this._eventCustomerQuestionAnswer);
			collectionsQueue.Enqueue(this._preQualificationQuestionRule_);
			collectionsQueue.Enqueue(this._preQualificationQuestionRule);
			collectionsQueue.Enqueue(this._preQualificationTemplateQuestion);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaEventCustomerQuestionAnswer);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaDisqualifiedTest);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaEventCustomerQuestionAnswer);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaDisqualifiedTest);
			collectionsQueue.Enqueue(this._eventsCollectionViaDisqualifiedTest);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventCustomerQuestionAnswer);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventCustomerQuestionAnswer);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaDisqualifiedTest);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaDisqualifiedTest_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventCustomerQuestionAnswer_);
			collectionsQueue.Enqueue(this._preQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion);
			collectionsQueue.Enqueue(this._testCollectionViaDisqualifiedTest);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._disqualifiedTest = (EntityCollection<DisqualifiedTestEntity>) collectionsQueue.Dequeue();
			this._eventCustomerQuestionAnswer = (EntityCollection<EventCustomerQuestionAnswerEntity>) collectionsQueue.Dequeue();
			this._preQualificationQuestionRule_ = (EntityCollection<PreQualificationQuestionRuleEntity>) collectionsQueue.Dequeue();
			this._preQualificationQuestionRule = (EntityCollection<PreQualificationQuestionRuleEntity>) collectionsQueue.Dequeue();
			this._preQualificationTemplateQuestion = (EntityCollection<PreQualificationTemplateQuestionEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaEventCustomerQuestionAnswer = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaDisqualifiedTest = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaEventCustomerQuestionAnswer = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaDisqualifiedTest = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaDisqualifiedTest = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventCustomerQuestionAnswer = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventCustomerQuestionAnswer = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaDisqualifiedTest = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaDisqualifiedTest_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventCustomerQuestionAnswer_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._preQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion = (EntityCollection<PreQualificationTestTemplateEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaDisqualifiedTest = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._disqualifiedTest != null)
			{
				return true;
			}
			if (this._eventCustomerQuestionAnswer != null)
			{
				return true;
			}
			if (this._preQualificationQuestionRule_ != null)
			{
				return true;
			}
			if (this._preQualificationQuestionRule != null)
			{
				return true;
			}
			if (this._preQualificationTemplateQuestion != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaEventCustomerQuestionAnswer != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaDisqualifiedTest != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaEventCustomerQuestionAnswer != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaDisqualifiedTest != null)
			{
				return true;
			}
			if (this._eventsCollectionViaDisqualifiedTest != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventCustomerQuestionAnswer != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventCustomerQuestionAnswer != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaDisqualifiedTest != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaDisqualifiedTest_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventCustomerQuestionAnswer_ != null)
			{
				return true;
			}
			if (this._preQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion != null)
			{
				return true;
			}
			if (this._testCollectionViaDisqualifiedTest != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DisqualifiedTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DisqualifiedTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerQuestionAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerQuestionAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PreQualificationQuestionRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationQuestionRuleEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PreQualificationQuestionRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationQuestionRuleEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PreQualificationTemplateQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTemplateQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PreQualificationTestTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTestTemplateEntityFactory))) : null);
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
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("Test", _test);
			toReturn.Add("DisqualifiedTest", _disqualifiedTest);
			toReturn.Add("EventCustomerQuestionAnswer", _eventCustomerQuestionAnswer);
			toReturn.Add("PreQualificationQuestionRule_", _preQualificationQuestionRule_);
			toReturn.Add("PreQualificationQuestionRule", _preQualificationQuestionRule);
			toReturn.Add("PreQualificationTemplateQuestion", _preQualificationTemplateQuestion);
			toReturn.Add("CustomerProfileCollectionViaEventCustomerQuestionAnswer", _customerProfileCollectionViaEventCustomerQuestionAnswer);
			toReturn.Add("CustomerProfileCollectionViaDisqualifiedTest", _customerProfileCollectionViaDisqualifiedTest);
			toReturn.Add("EventCustomersCollectionViaEventCustomerQuestionAnswer", _eventCustomersCollectionViaEventCustomerQuestionAnswer);
			toReturn.Add("EventCustomersCollectionViaDisqualifiedTest", _eventCustomersCollectionViaDisqualifiedTest);
			toReturn.Add("EventsCollectionViaDisqualifiedTest", _eventsCollectionViaDisqualifiedTest);
			toReturn.Add("EventsCollectionViaEventCustomerQuestionAnswer", _eventsCollectionViaEventCustomerQuestionAnswer);
			toReturn.Add("OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer", _organizationRoleUserCollectionViaEventCustomerQuestionAnswer);
			toReturn.Add("OrganizationRoleUserCollectionViaDisqualifiedTest", _organizationRoleUserCollectionViaDisqualifiedTest);
			toReturn.Add("OrganizationRoleUserCollectionViaDisqualifiedTest_", _organizationRoleUserCollectionViaDisqualifiedTest_);
			toReturn.Add("OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_", _organizationRoleUserCollectionViaEventCustomerQuestionAnswer_);
			toReturn.Add("PreQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion", _preQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion);
			toReturn.Add("TestCollectionViaDisqualifiedTest", _testCollectionViaDisqualifiedTest);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_disqualifiedTest!=null)
			{
				_disqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerQuestionAnswer!=null)
			{
				_eventCustomerQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_preQualificationQuestionRule_!=null)
			{
				_preQualificationQuestionRule_.ActiveContext = base.ActiveContext;
			}
			if(_preQualificationQuestionRule!=null)
			{
				_preQualificationQuestionRule.ActiveContext = base.ActiveContext;
			}
			if(_preQualificationTemplateQuestion!=null)
			{
				_preQualificationTemplateQuestion.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaEventCustomerQuestionAnswer!=null)
			{
				_customerProfileCollectionViaEventCustomerQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaDisqualifiedTest!=null)
			{
				_customerProfileCollectionViaDisqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaEventCustomerQuestionAnswer!=null)
			{
				_eventCustomersCollectionViaEventCustomerQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaDisqualifiedTest!=null)
			{
				_eventCustomersCollectionViaDisqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaDisqualifiedTest!=null)
			{
				_eventsCollectionViaDisqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventCustomerQuestionAnswer!=null)
			{
				_eventsCollectionViaEventCustomerQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventCustomerQuestionAnswer!=null)
			{
				_organizationRoleUserCollectionViaEventCustomerQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaDisqualifiedTest!=null)
			{
				_organizationRoleUserCollectionViaDisqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaDisqualifiedTest_!=null)
			{
				_organizationRoleUserCollectionViaDisqualifiedTest_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventCustomerQuestionAnswer_!=null)
			{
				_organizationRoleUserCollectionViaEventCustomerQuestionAnswer_.ActiveContext = base.ActiveContext;
			}
			if(_preQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion!=null)
			{
				_preQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaDisqualifiedTest!=null)
			{
				_testCollectionViaDisqualifiedTest.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_test!=null)
			{
				_test.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_disqualifiedTest = null;
			_eventCustomerQuestionAnswer = null;
			_preQualificationQuestionRule_ = null;
			_preQualificationQuestionRule = null;
			_preQualificationTemplateQuestion = null;
			_customerProfileCollectionViaEventCustomerQuestionAnswer = null;
			_customerProfileCollectionViaDisqualifiedTest = null;
			_eventCustomersCollectionViaEventCustomerQuestionAnswer = null;
			_eventCustomersCollectionViaDisqualifiedTest = null;
			_eventsCollectionViaDisqualifiedTest = null;
			_eventsCollectionViaEventCustomerQuestionAnswer = null;
			_organizationRoleUserCollectionViaEventCustomerQuestionAnswer = null;
			_organizationRoleUserCollectionViaDisqualifiedTest = null;
			_organizationRoleUserCollectionViaDisqualifiedTest_ = null;
			_organizationRoleUserCollectionViaEventCustomerQuestionAnswer_ = null;
			_preQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion = null;
			_testCollectionViaDisqualifiedTest = null;
			_lookup = null;
			_organizationRoleUser = null;
			_test = null;

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

			_fieldsCustomProperties.Add("Id", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Question", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ControlValues", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ControlValueDelimiter", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Index", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DisqualifiedReason", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TypeId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _lookup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", PreQualificationQuestionEntity.Relations.LookupEntityUsingTypeId, true, signalRelatedEntity, "PreQualificationQuestion", resetFKFields, new int[] { (int)PreQualificationQuestionFieldIndex.TypeId } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", PreQualificationQuestionEntity.Relations.LookupEntityUsingTypeId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _organizationRoleUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", PreQualificationQuestionEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, signalRelatedEntity, "PreQualificationQuestion", resetFKFields, new int[] { (int)PreQualificationQuestionFieldIndex.CreatedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", PreQualificationQuestionEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _test</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTest(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _test, new PropertyChangedEventHandler( OnTestPropertyChanged ), "Test", PreQualificationQuestionEntity.Relations.TestEntityUsingTestId, true, signalRelatedEntity, "PreQualificationQuestion", resetFKFields, new int[] { (int)PreQualificationQuestionFieldIndex.TestId } );		
			_test = null;
		}

		/// <summary> setups the sync logic for member _test</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTest(IEntity2 relatedEntity)
		{
			if(_test!=relatedEntity)
			{
				DesetupSyncTest(true, true);
				_test = (TestEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _test, new PropertyChangedEventHandler( OnTestPropertyChanged ), "Test", PreQualificationQuestionEntity.Relations.TestEntityUsingTestId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTestPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this PreQualificationQuestionEntity</param>
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
		public  static PreQualificationQuestionRelations Relations
		{
			get	{ return new PreQualificationQuestionRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DisqualifiedTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDisqualifiedTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<DisqualifiedTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DisqualifiedTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("DisqualifiedTest")[0], (int)Falcon.Data.EntityType.PreQualificationQuestionEntity, (int)Falcon.Data.EntityType.DisqualifiedTestEntity, 0, null, null, null, null, "DisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("EventCustomerQuestionAnswer")[0], (int)Falcon.Data.EntityType.PreQualificationQuestionEntity, (int)Falcon.Data.EntityType.EventCustomerQuestionAnswerEntity, 0, null, null, null, null, "EventCustomerQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PreQualificationQuestionRule' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPreQualificationQuestionRule_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PreQualificationQuestionRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationQuestionRuleEntityFactory))),
					(IEntityRelation)GetRelationsForField("PreQualificationQuestionRule_")[0], (int)Falcon.Data.EntityType.PreQualificationQuestionEntity, (int)Falcon.Data.EntityType.PreQualificationQuestionRuleEntity, 0, null, null, null, null, "PreQualificationQuestionRule_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PreQualificationQuestionRule' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPreQualificationQuestionRule
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PreQualificationQuestionRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationQuestionRuleEntityFactory))),
					(IEntityRelation)GetRelationsForField("PreQualificationQuestionRule")[0], (int)Falcon.Data.EntityType.PreQualificationQuestionEntity, (int)Falcon.Data.EntityType.PreQualificationQuestionRuleEntity, 0, null, null, null, null, "PreQualificationQuestionRule", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PreQualificationTemplateQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPreQualificationTemplateQuestion
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PreQualificationTemplateQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTemplateQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("PreQualificationTemplateQuestion")[0], (int)Falcon.Data.EntityType.PreQualificationQuestionEntity, (int)Falcon.Data.EntityType.PreQualificationTemplateQuestionEntity, 0, null, null, null, null, "PreQualificationTemplateQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaEventCustomerQuestionAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = PreQualificationQuestionEntity.Relations.EventCustomerQuestionAnswerEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerQuestionAnswer_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PreQualificationQuestionEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaEventCustomerQuestionAnswer"), null, "CustomerProfileCollectionViaEventCustomerQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaDisqualifiedTest
		{
			get
			{
				IEntityRelation intermediateRelation = PreQualificationQuestionEntity.Relations.DisqualifiedTestEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "DisqualifiedTest_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PreQualificationQuestionEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaDisqualifiedTest"), null, "CustomerProfileCollectionViaDisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaEventCustomerQuestionAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = PreQualificationQuestionEntity.Relations.EventCustomerQuestionAnswerEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerQuestionAnswer_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PreQualificationQuestionEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaEventCustomerQuestionAnswer"), null, "EventCustomersCollectionViaEventCustomerQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaDisqualifiedTest
		{
			get
			{
				IEntityRelation intermediateRelation = PreQualificationQuestionEntity.Relations.DisqualifiedTestEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "DisqualifiedTest_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PreQualificationQuestionEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaDisqualifiedTest"), null, "EventCustomersCollectionViaDisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaDisqualifiedTest
		{
			get
			{
				IEntityRelation intermediateRelation = PreQualificationQuestionEntity.Relations.DisqualifiedTestEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "DisqualifiedTest_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PreQualificationQuestionEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaDisqualifiedTest"), null, "EventsCollectionViaDisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventCustomerQuestionAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = PreQualificationQuestionEntity.Relations.EventCustomerQuestionAnswerEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerQuestionAnswer_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PreQualificationQuestionEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventCustomerQuestionAnswer"), null, "EventsCollectionViaEventCustomerQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventCustomerQuestionAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = PreQualificationQuestionEntity.Relations.EventCustomerQuestionAnswerEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerQuestionAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PreQualificationQuestionEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer"), null, "OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaDisqualifiedTest
		{
			get
			{
				IEntityRelation intermediateRelation = PreQualificationQuestionEntity.Relations.DisqualifiedTestEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "DisqualifiedTest_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PreQualificationQuestionEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaDisqualifiedTest"), null, "OrganizationRoleUserCollectionViaDisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaDisqualifiedTest_
		{
			get
			{
				IEntityRelation intermediateRelation = PreQualificationQuestionEntity.Relations.DisqualifiedTestEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "DisqualifiedTest_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PreQualificationQuestionEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaDisqualifiedTest_"), null, "OrganizationRoleUserCollectionViaDisqualifiedTest_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_
		{
			get
			{
				IEntityRelation intermediateRelation = PreQualificationQuestionEntity.Relations.EventCustomerQuestionAnswerEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerQuestionAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PreQualificationQuestionEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_"), null, "OrganizationRoleUserCollectionViaEventCustomerQuestionAnswer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PreQualificationTestTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPreQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion
		{
			get
			{
				IEntityRelation intermediateRelation = PreQualificationQuestionEntity.Relations.PreQualificationTemplateQuestionEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationTemplateQuestion_");
				return new PrefetchPathElement2(new EntityCollection<PreQualificationTestTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTestTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PreQualificationQuestionEntity, (int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, 0, null, null, GetRelationsForField("PreQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion"), null, "PreQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaDisqualifiedTest
		{
			get
			{
				IEntityRelation intermediateRelation = PreQualificationQuestionEntity.Relations.DisqualifiedTestEntityUsingQuestionId;
				intermediateRelation.SetAliases(string.Empty, "DisqualifiedTest_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PreQualificationQuestionEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaDisqualifiedTest"), null, "TestCollectionViaDisqualifiedTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.PreQualificationQuestionEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.PreQualificationQuestionEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTest
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))),
					(IEntityRelation)GetRelationsForField("Test")[0], (int)Falcon.Data.EntityType.PreQualificationQuestionEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, null, null, "Test", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return PreQualificationQuestionEntity.CustomProperties;}
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
			get { return PreQualificationQuestionEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity PreQualificationQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationQuestion"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)PreQualificationQuestionFieldIndex.Id, true); }
			set	{ SetValue((int)PreQualificationQuestionFieldIndex.Id, value); }
		}

		/// <summary> The Question property of the Entity PreQualificationQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationQuestion"."Question"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 4000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Question
		{
			get { return (System.String)GetValue((int)PreQualificationQuestionFieldIndex.Question, true); }
			set	{ SetValue((int)PreQualificationQuestionFieldIndex.Question, value); }
		}

		/// <summary> The TestId property of the Entity PreQualificationQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationQuestion"."TestId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TestId
		{
			get { return (System.Int64)GetValue((int)PreQualificationQuestionFieldIndex.TestId, true); }
			set	{ SetValue((int)PreQualificationQuestionFieldIndex.TestId, value); }
		}

		/// <summary> The ControlValues property of the Entity PreQualificationQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationQuestion"."ControlValues"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ControlValues
		{
			get { return (System.String)GetValue((int)PreQualificationQuestionFieldIndex.ControlValues, true); }
			set	{ SetValue((int)PreQualificationQuestionFieldIndex.ControlValues, value); }
		}

		/// <summary> The ControlValueDelimiter property of the Entity PreQualificationQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationQuestion"."ControlValueDelimiter"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 10<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ControlValueDelimiter
		{
			get { return (System.String)GetValue((int)PreQualificationQuestionFieldIndex.ControlValueDelimiter, true); }
			set	{ SetValue((int)PreQualificationQuestionFieldIndex.ControlValueDelimiter, value); }
		}

		/// <summary> The IsActive property of the Entity PreQualificationQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationQuestion"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)PreQualificationQuestionFieldIndex.IsActive, true); }
			set	{ SetValue((int)PreQualificationQuestionFieldIndex.IsActive, value); }
		}

		/// <summary> The Index property of the Entity PreQualificationQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationQuestion"."Index"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Index
		{
			get { return (System.Int32)GetValue((int)PreQualificationQuestionFieldIndex.Index, true); }
			set	{ SetValue((int)PreQualificationQuestionFieldIndex.Index, value); }
		}

		/// <summary> The CreatedBy property of the Entity PreQualificationQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationQuestion"."CreatedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CreatedBy
		{
			get { return (Nullable<System.Int64>)GetValue((int)PreQualificationQuestionFieldIndex.CreatedBy, false); }
			set	{ SetValue((int)PreQualificationQuestionFieldIndex.CreatedBy, value); }
		}

		/// <summary> The CreatedDate property of the Entity PreQualificationQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationQuestion"."CreatedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> CreatedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)PreQualificationQuestionFieldIndex.CreatedDate, false); }
			set	{ SetValue((int)PreQualificationQuestionFieldIndex.CreatedDate, value); }
		}

		/// <summary> The DisqualifiedReason property of the Entity PreQualificationQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationQuestion"."DisqualifiedReason"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String DisqualifiedReason
		{
			get { return (System.String)GetValue((int)PreQualificationQuestionFieldIndex.DisqualifiedReason, true); }
			set	{ SetValue((int)PreQualificationQuestionFieldIndex.DisqualifiedReason, value); }
		}

		/// <summary> The ParentId property of the Entity PreQualificationQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationQuestion"."ParentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PreQualificationQuestionFieldIndex.ParentId, false); }
			set	{ SetValue((int)PreQualificationQuestionFieldIndex.ParentId, value); }
		}

		/// <summary> The TypeId property of the Entity PreQualificationQuestion<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationQuestion"."TypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> TypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)PreQualificationQuestionFieldIndex.TypeId, false); }
			set	{ SetValue((int)PreQualificationQuestionFieldIndex.TypeId, value); }
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
					_disqualifiedTest.SetContainingEntityInfo(this, "PreQualificationQuestion");
				}
				return _disqualifiedTest;
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
					_eventCustomerQuestionAnswer.SetContainingEntityInfo(this, "PreQualificationQuestion");
				}
				return _eventCustomerQuestionAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PreQualificationQuestionRuleEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PreQualificationQuestionRuleEntity))]
		public virtual EntityCollection<PreQualificationQuestionRuleEntity> PreQualificationQuestionRule_
		{
			get
			{
				if(_preQualificationQuestionRule_==null)
				{
					_preQualificationQuestionRule_ = new EntityCollection<PreQualificationQuestionRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationQuestionRuleEntityFactory)));
					_preQualificationQuestionRule_.SetContainingEntityInfo(this, "PreQualificationQuestion_");
				}
				return _preQualificationQuestionRule_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PreQualificationQuestionRuleEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PreQualificationQuestionRuleEntity))]
		public virtual EntityCollection<PreQualificationQuestionRuleEntity> PreQualificationQuestionRule
		{
			get
			{
				if(_preQualificationQuestionRule==null)
				{
					_preQualificationQuestionRule = new EntityCollection<PreQualificationQuestionRuleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationQuestionRuleEntityFactory)));
					_preQualificationQuestionRule.SetContainingEntityInfo(this, "PreQualificationQuestion");
				}
				return _preQualificationQuestionRule;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PreQualificationTemplateQuestionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PreQualificationTemplateQuestionEntity))]
		public virtual EntityCollection<PreQualificationTemplateQuestionEntity> PreQualificationTemplateQuestion
		{
			get
			{
				if(_preQualificationTemplateQuestion==null)
				{
					_preQualificationTemplateQuestion = new EntityCollection<PreQualificationTemplateQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTemplateQuestionEntityFactory)));
					_preQualificationTemplateQuestion.SetContainingEntityInfo(this, "PreQualificationQuestion");
				}
				return _preQualificationTemplateQuestion;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaEventCustomerQuestionAnswer
		{
			get
			{
				if(_eventCustomersCollectionViaEventCustomerQuestionAnswer==null)
				{
					_eventCustomersCollectionViaEventCustomerQuestionAnswer = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaEventCustomerQuestionAnswer.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaEventCustomerQuestionAnswer;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'PreQualificationTestTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PreQualificationTestTemplateEntity))]
		public virtual EntityCollection<PreQualificationTestTemplateEntity> PreQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion
		{
			get
			{
				if(_preQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion==null)
				{
					_preQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion = new EntityCollection<PreQualificationTestTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTestTemplateEntityFactory)));
					_preQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion.IsReadOnly=true;
				}
				return _preQualificationTestTemplateCollectionViaPreQualificationTemplateQuestion;
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
							_lookup.UnsetRelatedEntity(this, "PreQualificationQuestion");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PreQualificationQuestion");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "PreQualificationQuestion");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PreQualificationQuestion");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'TestEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TestEntity Test
		{
			get
			{
				return _test;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTest(value);
				}
				else
				{
					if(value==null)
					{
						if(_test != null)
						{
							_test.UnsetRelatedEntity(this, "PreQualificationQuestion");
						}
					}
					else
					{
						if(_test!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PreQualificationQuestion");
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
			get { return (int)Falcon.Data.EntityType.PreQualificationQuestionEntity; }
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
