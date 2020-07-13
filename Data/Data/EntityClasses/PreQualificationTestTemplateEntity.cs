///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:51
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
	/// Entity class which represents the entity 'PreQualificationTestTemplate'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class PreQualificationTestTemplateEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<EventTestEntity> _eventTest;
		private EntityCollection<PreQualificationTemplateDependentTestEntity> _preQualificationTemplateDependentTest;
		private EntityCollection<PreQualificationTemplateQuestionEntity> _preQualificationTemplateQuestion;
		private EntityCollection<TestEntity> _test_;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventTest;
		private EntityCollection<HafTemplateEntity> _hafTemplateCollectionViaTest;
		private EntityCollection<HafTemplateEntity> _hafTemplateCollectionViaEventTest;
		private EntityCollection<LookupEntity> _lookupCollectionViaTest;
		private EntityCollection<LookupEntity> _lookupCollectionViaTest_;
		private EntityCollection<LookupEntity> _lookupCollectionViaTest__;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventTest;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventTest_;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventTest__;
		private EntityCollection<PreQualificationQuestionEntity> _preQualificationQuestionCollectionViaPreQualificationTemplateQuestion;
		private EntityCollection<TestEntity> _testCollectionViaEventTest;
		private EntityCollection<TestEntity> _testCollectionViaPreQualificationTemplateDependentTest;
		private OrganizationRoleUserEntity _organizationRoleUser_;
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
			/// <summary>Member name OrganizationRoleUser_</summary>
			public static readonly string OrganizationRoleUser_ = "OrganizationRoleUser_";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name Test</summary>
			public static readonly string Test = "Test";
			/// <summary>Member name EventTest</summary>
			public static readonly string EventTest = "EventTest";
			/// <summary>Member name PreQualificationTemplateDependentTest</summary>
			public static readonly string PreQualificationTemplateDependentTest = "PreQualificationTemplateDependentTest";
			/// <summary>Member name PreQualificationTemplateQuestion</summary>
			public static readonly string PreQualificationTemplateQuestion = "PreQualificationTemplateQuestion";
			/// <summary>Member name Test_</summary>
			public static readonly string Test_ = "Test_";
			/// <summary>Member name EventsCollectionViaEventTest</summary>
			public static readonly string EventsCollectionViaEventTest = "EventsCollectionViaEventTest";
			/// <summary>Member name HafTemplateCollectionViaTest</summary>
			public static readonly string HafTemplateCollectionViaTest = "HafTemplateCollectionViaTest";
			/// <summary>Member name HafTemplateCollectionViaEventTest</summary>
			public static readonly string HafTemplateCollectionViaEventTest = "HafTemplateCollectionViaEventTest";
			/// <summary>Member name LookupCollectionViaTest</summary>
			public static readonly string LookupCollectionViaTest = "LookupCollectionViaTest";
			/// <summary>Member name LookupCollectionViaTest_</summary>
			public static readonly string LookupCollectionViaTest_ = "LookupCollectionViaTest_";
			/// <summary>Member name LookupCollectionViaTest__</summary>
			public static readonly string LookupCollectionViaTest__ = "LookupCollectionViaTest__";
			/// <summary>Member name LookupCollectionViaEventTest</summary>
			public static readonly string LookupCollectionViaEventTest = "LookupCollectionViaEventTest";
			/// <summary>Member name LookupCollectionViaEventTest_</summary>
			public static readonly string LookupCollectionViaEventTest_ = "LookupCollectionViaEventTest_";
			/// <summary>Member name LookupCollectionViaEventTest__</summary>
			public static readonly string LookupCollectionViaEventTest__ = "LookupCollectionViaEventTest__";
			/// <summary>Member name PreQualificationQuestionCollectionViaPreQualificationTemplateQuestion</summary>
			public static readonly string PreQualificationQuestionCollectionViaPreQualificationTemplateQuestion = "PreQualificationQuestionCollectionViaPreQualificationTemplateQuestion";
			/// <summary>Member name TestCollectionViaEventTest</summary>
			public static readonly string TestCollectionViaEventTest = "TestCollectionViaEventTest";
			/// <summary>Member name TestCollectionViaPreQualificationTemplateDependentTest</summary>
			public static readonly string TestCollectionViaPreQualificationTemplateDependentTest = "TestCollectionViaPreQualificationTemplateDependentTest";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static PreQualificationTestTemplateEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public PreQualificationTestTemplateEntity():base("PreQualificationTestTemplateEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public PreQualificationTestTemplateEntity(IEntityFields2 fields):base("PreQualificationTestTemplateEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this PreQualificationTestTemplateEntity</param>
		public PreQualificationTestTemplateEntity(IValidator validator):base("PreQualificationTestTemplateEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for PreQualificationTestTemplate which data should be fetched into this PreQualificationTestTemplate object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PreQualificationTestTemplateEntity(System.Int64 id):base("PreQualificationTestTemplateEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for PreQualificationTestTemplate which data should be fetched into this PreQualificationTestTemplate object</param>
		/// <param name="validator">The custom validator object for this PreQualificationTestTemplateEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public PreQualificationTestTemplateEntity(System.Int64 id, IValidator validator):base("PreQualificationTestTemplateEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected PreQualificationTestTemplateEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_eventTest = (EntityCollection<EventTestEntity>)info.GetValue("_eventTest", typeof(EntityCollection<EventTestEntity>));
				_preQualificationTemplateDependentTest = (EntityCollection<PreQualificationTemplateDependentTestEntity>)info.GetValue("_preQualificationTemplateDependentTest", typeof(EntityCollection<PreQualificationTemplateDependentTestEntity>));
				_preQualificationTemplateQuestion = (EntityCollection<PreQualificationTemplateQuestionEntity>)info.GetValue("_preQualificationTemplateQuestion", typeof(EntityCollection<PreQualificationTemplateQuestionEntity>));
				_test_ = (EntityCollection<TestEntity>)info.GetValue("_test_", typeof(EntityCollection<TestEntity>));
				_eventsCollectionViaEventTest = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventTest", typeof(EntityCollection<EventsEntity>));
				_hafTemplateCollectionViaTest = (EntityCollection<HafTemplateEntity>)info.GetValue("_hafTemplateCollectionViaTest", typeof(EntityCollection<HafTemplateEntity>));
				_hafTemplateCollectionViaEventTest = (EntityCollection<HafTemplateEntity>)info.GetValue("_hafTemplateCollectionViaEventTest", typeof(EntityCollection<HafTemplateEntity>));
				_lookupCollectionViaTest = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaTest", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaTest_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaTest_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaTest__ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaTest__", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEventTest = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventTest", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEventTest_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventTest_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEventTest__ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventTest__", typeof(EntityCollection<LookupEntity>));
				_preQualificationQuestionCollectionViaPreQualificationTemplateQuestion = (EntityCollection<PreQualificationQuestionEntity>)info.GetValue("_preQualificationQuestionCollectionViaPreQualificationTemplateQuestion", typeof(EntityCollection<PreQualificationQuestionEntity>));
				_testCollectionViaEventTest = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaEventTest", typeof(EntityCollection<TestEntity>));
				_testCollectionViaPreQualificationTemplateDependentTest = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaPreQualificationTemplateDependentTest", typeof(EntityCollection<TestEntity>));
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
			switch((PreQualificationTestTemplateFieldIndex)fieldIndex)
			{
				case PreQualificationTestTemplateFieldIndex.TestId:
					DesetupSyncTest(true, false);
					break;
				case PreQualificationTestTemplateFieldIndex.CreatedBy:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case PreQualificationTestTemplateFieldIndex.UpdatedBy:
					DesetupSyncOrganizationRoleUser_(true, false);
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
				case "OrganizationRoleUser_":
					this.OrganizationRoleUser_ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "Test":
					this.Test = (TestEntity)entity;
					break;
				case "EventTest":
					this.EventTest.Add((EventTestEntity)entity);
					break;
				case "PreQualificationTemplateDependentTest":
					this.PreQualificationTemplateDependentTest.Add((PreQualificationTemplateDependentTestEntity)entity);
					break;
				case "PreQualificationTemplateQuestion":
					this.PreQualificationTemplateQuestion.Add((PreQualificationTemplateQuestionEntity)entity);
					break;
				case "Test_":
					this.Test_.Add((TestEntity)entity);
					break;
				case "EventsCollectionViaEventTest":
					this.EventsCollectionViaEventTest.IsReadOnly = false;
					this.EventsCollectionViaEventTest.Add((EventsEntity)entity);
					this.EventsCollectionViaEventTest.IsReadOnly = true;
					break;
				case "HafTemplateCollectionViaTest":
					this.HafTemplateCollectionViaTest.IsReadOnly = false;
					this.HafTemplateCollectionViaTest.Add((HafTemplateEntity)entity);
					this.HafTemplateCollectionViaTest.IsReadOnly = true;
					break;
				case "HafTemplateCollectionViaEventTest":
					this.HafTemplateCollectionViaEventTest.IsReadOnly = false;
					this.HafTemplateCollectionViaEventTest.Add((HafTemplateEntity)entity);
					this.HafTemplateCollectionViaEventTest.IsReadOnly = true;
					break;
				case "LookupCollectionViaTest":
					this.LookupCollectionViaTest.IsReadOnly = false;
					this.LookupCollectionViaTest.Add((LookupEntity)entity);
					this.LookupCollectionViaTest.IsReadOnly = true;
					break;
				case "LookupCollectionViaTest_":
					this.LookupCollectionViaTest_.IsReadOnly = false;
					this.LookupCollectionViaTest_.Add((LookupEntity)entity);
					this.LookupCollectionViaTest_.IsReadOnly = true;
					break;
				case "LookupCollectionViaTest__":
					this.LookupCollectionViaTest__.IsReadOnly = false;
					this.LookupCollectionViaTest__.Add((LookupEntity)entity);
					this.LookupCollectionViaTest__.IsReadOnly = true;
					break;
				case "LookupCollectionViaEventTest":
					this.LookupCollectionViaEventTest.IsReadOnly = false;
					this.LookupCollectionViaEventTest.Add((LookupEntity)entity);
					this.LookupCollectionViaEventTest.IsReadOnly = true;
					break;
				case "LookupCollectionViaEventTest_":
					this.LookupCollectionViaEventTest_.IsReadOnly = false;
					this.LookupCollectionViaEventTest_.Add((LookupEntity)entity);
					this.LookupCollectionViaEventTest_.IsReadOnly = true;
					break;
				case "LookupCollectionViaEventTest__":
					this.LookupCollectionViaEventTest__.IsReadOnly = false;
					this.LookupCollectionViaEventTest__.Add((LookupEntity)entity);
					this.LookupCollectionViaEventTest__.IsReadOnly = true;
					break;
				case "PreQualificationQuestionCollectionViaPreQualificationTemplateQuestion":
					this.PreQualificationQuestionCollectionViaPreQualificationTemplateQuestion.IsReadOnly = false;
					this.PreQualificationQuestionCollectionViaPreQualificationTemplateQuestion.Add((PreQualificationQuestionEntity)entity);
					this.PreQualificationQuestionCollectionViaPreQualificationTemplateQuestion.IsReadOnly = true;
					break;
				case "TestCollectionViaEventTest":
					this.TestCollectionViaEventTest.IsReadOnly = false;
					this.TestCollectionViaEventTest.Add((TestEntity)entity);
					this.TestCollectionViaEventTest.IsReadOnly = true;
					break;
				case "TestCollectionViaPreQualificationTemplateDependentTest":
					this.TestCollectionViaPreQualificationTemplateDependentTest.IsReadOnly = false;
					this.TestCollectionViaPreQualificationTemplateDependentTest.Add((TestEntity)entity);
					this.TestCollectionViaPreQualificationTemplateDependentTest.IsReadOnly = true;
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
			return PreQualificationTestTemplateEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "OrganizationRoleUser_":
					toReturn.Add(PreQualificationTestTemplateEntity.Relations.OrganizationRoleUserEntityUsingUpdatedBy);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(PreQualificationTestTemplateEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy);
					break;
				case "Test":
					toReturn.Add(PreQualificationTestTemplateEntity.Relations.TestEntityUsingTestId);
					break;
				case "EventTest":
					toReturn.Add(PreQualificationTestTemplateEntity.Relations.EventTestEntityUsingPreQualificationQuestionTemplateId);
					break;
				case "PreQualificationTemplateDependentTest":
					toReturn.Add(PreQualificationTestTemplateEntity.Relations.PreQualificationTemplateDependentTestEntityUsingTemplateId);
					break;
				case "PreQualificationTemplateQuestion":
					toReturn.Add(PreQualificationTestTemplateEntity.Relations.PreQualificationTemplateQuestionEntityUsingTemplateId);
					break;
				case "Test_":
					toReturn.Add(PreQualificationTestTemplateEntity.Relations.TestEntityUsingPreQualificationQuestionTemplateId);
					break;
				case "EventsCollectionViaEventTest":
					toReturn.Add(PreQualificationTestTemplateEntity.Relations.EventTestEntityUsingPreQualificationQuestionTemplateId, "PreQualificationTestTemplateEntity__", "EventTest_", JoinHint.None);
					toReturn.Add(EventTestEntity.Relations.EventsEntityUsingEventId, "EventTest_", string.Empty, JoinHint.None);
					break;
				case "HafTemplateCollectionViaTest":
					toReturn.Add(PreQualificationTestTemplateEntity.Relations.TestEntityUsingPreQualificationQuestionTemplateId, "PreQualificationTestTemplateEntity__", "Test_", JoinHint.None);
					toReturn.Add(TestEntity.Relations.HafTemplateEntityUsingHafTemplateId, "Test_", string.Empty, JoinHint.None);
					break;
				case "HafTemplateCollectionViaEventTest":
					toReturn.Add(PreQualificationTestTemplateEntity.Relations.EventTestEntityUsingPreQualificationQuestionTemplateId, "PreQualificationTestTemplateEntity__", "EventTest_", JoinHint.None);
					toReturn.Add(EventTestEntity.Relations.HafTemplateEntityUsingHafTemplateId, "EventTest_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaTest":
					toReturn.Add(PreQualificationTestTemplateEntity.Relations.TestEntityUsingPreQualificationQuestionTemplateId, "PreQualificationTestTemplateEntity__", "Test_", JoinHint.None);
					toReturn.Add(TestEntity.Relations.LookupEntityUsingGender, "Test_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaTest_":
					toReturn.Add(PreQualificationTestTemplateEntity.Relations.TestEntityUsingPreQualificationQuestionTemplateId, "PreQualificationTestTemplateEntity__", "Test_", JoinHint.None);
					toReturn.Add(TestEntity.Relations.LookupEntityUsingGroupId, "Test_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaTest__":
					toReturn.Add(PreQualificationTestTemplateEntity.Relations.TestEntityUsingPreQualificationQuestionTemplateId, "PreQualificationTestTemplateEntity__", "Test_", JoinHint.None);
					toReturn.Add(TestEntity.Relations.LookupEntityUsingResultEntryTypeId, "Test_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventTest":
					toReturn.Add(PreQualificationTestTemplateEntity.Relations.EventTestEntityUsingPreQualificationQuestionTemplateId, "PreQualificationTestTemplateEntity__", "EventTest_", JoinHint.None);
					toReturn.Add(EventTestEntity.Relations.LookupEntityUsingGender, "EventTest_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventTest_":
					toReturn.Add(PreQualificationTestTemplateEntity.Relations.EventTestEntityUsingPreQualificationQuestionTemplateId, "PreQualificationTestTemplateEntity__", "EventTest_", JoinHint.None);
					toReturn.Add(EventTestEntity.Relations.LookupEntityUsingGroupId, "EventTest_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventTest__":
					toReturn.Add(PreQualificationTestTemplateEntity.Relations.EventTestEntityUsingPreQualificationQuestionTemplateId, "PreQualificationTestTemplateEntity__", "EventTest_", JoinHint.None);
					toReturn.Add(EventTestEntity.Relations.LookupEntityUsingResultEntryTypeId, "EventTest_", string.Empty, JoinHint.None);
					break;
				case "PreQualificationQuestionCollectionViaPreQualificationTemplateQuestion":
					toReturn.Add(PreQualificationTestTemplateEntity.Relations.PreQualificationTemplateQuestionEntityUsingTemplateId, "PreQualificationTestTemplateEntity__", "PreQualificationTemplateQuestion_", JoinHint.None);
					toReturn.Add(PreQualificationTemplateQuestionEntity.Relations.PreQualificationQuestionEntityUsingQuestionId, "PreQualificationTemplateQuestion_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaEventTest":
					toReturn.Add(PreQualificationTestTemplateEntity.Relations.EventTestEntityUsingPreQualificationQuestionTemplateId, "PreQualificationTestTemplateEntity__", "EventTest_", JoinHint.None);
					toReturn.Add(EventTestEntity.Relations.TestEntityUsingTestId, "EventTest_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaPreQualificationTemplateDependentTest":
					toReturn.Add(PreQualificationTestTemplateEntity.Relations.PreQualificationTemplateDependentTestEntityUsingTemplateId, "PreQualificationTestTemplateEntity__", "PreQualificationTemplateDependentTest_", JoinHint.None);
					toReturn.Add(PreQualificationTemplateDependentTestEntity.Relations.TestEntityUsingTestId, "PreQualificationTemplateDependentTest_", string.Empty, JoinHint.None);
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
				case "OrganizationRoleUser_":
					SetupSyncOrganizationRoleUser_(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "Test":
					SetupSyncTest(relatedEntity);
					break;
				case "EventTest":
					this.EventTest.Add((EventTestEntity)relatedEntity);
					break;
				case "PreQualificationTemplateDependentTest":
					this.PreQualificationTemplateDependentTest.Add((PreQualificationTemplateDependentTestEntity)relatedEntity);
					break;
				case "PreQualificationTemplateQuestion":
					this.PreQualificationTemplateQuestion.Add((PreQualificationTemplateQuestionEntity)relatedEntity);
					break;
				case "Test_":
					this.Test_.Add((TestEntity)relatedEntity);
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
				case "OrganizationRoleUser_":
					DesetupSyncOrganizationRoleUser_(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "Test":
					DesetupSyncTest(false, true);
					break;
				case "EventTest":
					base.PerformRelatedEntityRemoval(this.EventTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PreQualificationTemplateDependentTest":
					base.PerformRelatedEntityRemoval(this.PreQualificationTemplateDependentTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PreQualificationTemplateQuestion":
					base.PerformRelatedEntityRemoval(this.PreQualificationTemplateQuestion, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Test_":
					base.PerformRelatedEntityRemoval(this.Test_, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_organizationRoleUser_!=null)
			{
				toReturn.Add(_organizationRoleUser_);
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
			toReturn.Add(this.EventTest);
			toReturn.Add(this.PreQualificationTemplateDependentTest);
			toReturn.Add(this.PreQualificationTemplateQuestion);
			toReturn.Add(this.Test_);

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
				info.AddValue("_eventTest", ((_eventTest!=null) && (_eventTest.Count>0) && !this.MarkedForDeletion)?_eventTest:null);
				info.AddValue("_preQualificationTemplateDependentTest", ((_preQualificationTemplateDependentTest!=null) && (_preQualificationTemplateDependentTest.Count>0) && !this.MarkedForDeletion)?_preQualificationTemplateDependentTest:null);
				info.AddValue("_preQualificationTemplateQuestion", ((_preQualificationTemplateQuestion!=null) && (_preQualificationTemplateQuestion.Count>0) && !this.MarkedForDeletion)?_preQualificationTemplateQuestion:null);
				info.AddValue("_test_", ((_test_!=null) && (_test_.Count>0) && !this.MarkedForDeletion)?_test_:null);
				info.AddValue("_eventsCollectionViaEventTest", ((_eventsCollectionViaEventTest!=null) && (_eventsCollectionViaEventTest.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventTest:null);
				info.AddValue("_hafTemplateCollectionViaTest", ((_hafTemplateCollectionViaTest!=null) && (_hafTemplateCollectionViaTest.Count>0) && !this.MarkedForDeletion)?_hafTemplateCollectionViaTest:null);
				info.AddValue("_hafTemplateCollectionViaEventTest", ((_hafTemplateCollectionViaEventTest!=null) && (_hafTemplateCollectionViaEventTest.Count>0) && !this.MarkedForDeletion)?_hafTemplateCollectionViaEventTest:null);
				info.AddValue("_lookupCollectionViaTest", ((_lookupCollectionViaTest!=null) && (_lookupCollectionViaTest.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaTest:null);
				info.AddValue("_lookupCollectionViaTest_", ((_lookupCollectionViaTest_!=null) && (_lookupCollectionViaTest_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaTest_:null);
				info.AddValue("_lookupCollectionViaTest__", ((_lookupCollectionViaTest__!=null) && (_lookupCollectionViaTest__.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaTest__:null);
				info.AddValue("_lookupCollectionViaEventTest", ((_lookupCollectionViaEventTest!=null) && (_lookupCollectionViaEventTest.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventTest:null);
				info.AddValue("_lookupCollectionViaEventTest_", ((_lookupCollectionViaEventTest_!=null) && (_lookupCollectionViaEventTest_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventTest_:null);
				info.AddValue("_lookupCollectionViaEventTest__", ((_lookupCollectionViaEventTest__!=null) && (_lookupCollectionViaEventTest__.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventTest__:null);
				info.AddValue("_preQualificationQuestionCollectionViaPreQualificationTemplateQuestion", ((_preQualificationQuestionCollectionViaPreQualificationTemplateQuestion!=null) && (_preQualificationQuestionCollectionViaPreQualificationTemplateQuestion.Count>0) && !this.MarkedForDeletion)?_preQualificationQuestionCollectionViaPreQualificationTemplateQuestion:null);
				info.AddValue("_testCollectionViaEventTest", ((_testCollectionViaEventTest!=null) && (_testCollectionViaEventTest.Count>0) && !this.MarkedForDeletion)?_testCollectionViaEventTest:null);
				info.AddValue("_testCollectionViaPreQualificationTemplateDependentTest", ((_testCollectionViaPreQualificationTemplateDependentTest!=null) && (_testCollectionViaPreQualificationTemplateDependentTest.Count>0) && !this.MarkedForDeletion)?_testCollectionViaPreQualificationTemplateDependentTest:null);
				info.AddValue("_organizationRoleUser_", (!this.MarkedForDeletion?_organizationRoleUser_:null));
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
		public bool TestOriginalFieldValueForNull(PreQualificationTestTemplateFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(PreQualificationTestTemplateFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new PreQualificationTestTemplateRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventTestFields.PreQualificationQuestionTemplateId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PreQualificationTemplateDependentTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPreQualificationTemplateDependentTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationTemplateDependentTestFields.TemplateId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PreQualificationTemplateQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPreQualificationTemplateQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationTemplateQuestionFields.TemplateId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTest_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.PreQualificationQuestionTemplateId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationTestTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "PreQualificationTestTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HafTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplateCollectionViaTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HafTemplateCollectionViaTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationTestTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "PreQualificationTestTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HafTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplateCollectionViaEventTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HafTemplateCollectionViaEventTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationTestTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "PreQualificationTestTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationTestTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "PreQualificationTestTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaTest_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaTest_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationTestTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "PreQualificationTestTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaTest__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaTest__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationTestTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "PreQualificationTestTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationTestTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "PreQualificationTestTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventTest_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventTest_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationTestTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "PreQualificationTestTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventTest__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventTest__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationTestTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "PreQualificationTestTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PreQualificationQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPreQualificationQuestionCollectionViaPreQualificationTemplateQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PreQualificationQuestionCollectionViaPreQualificationTemplateQuestion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationTestTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "PreQualificationTestTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaEventTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaEventTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationTestTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "PreQualificationTestTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaPreQualificationTemplateDependentTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaPreQualificationTemplateDependentTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PreQualificationTestTemplateFields.Id, null, ComparisonOperator.Equal, this.Id, "PreQualificationTestTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.UpdatedBy));
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
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.PreQualificationTestTemplateEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTestTemplateEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._eventTest);
			collectionsQueue.Enqueue(this._preQualificationTemplateDependentTest);
			collectionsQueue.Enqueue(this._preQualificationTemplateQuestion);
			collectionsQueue.Enqueue(this._test_);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventTest);
			collectionsQueue.Enqueue(this._hafTemplateCollectionViaTest);
			collectionsQueue.Enqueue(this._hafTemplateCollectionViaEventTest);
			collectionsQueue.Enqueue(this._lookupCollectionViaTest);
			collectionsQueue.Enqueue(this._lookupCollectionViaTest_);
			collectionsQueue.Enqueue(this._lookupCollectionViaTest__);
			collectionsQueue.Enqueue(this._lookupCollectionViaEventTest);
			collectionsQueue.Enqueue(this._lookupCollectionViaEventTest_);
			collectionsQueue.Enqueue(this._lookupCollectionViaEventTest__);
			collectionsQueue.Enqueue(this._preQualificationQuestionCollectionViaPreQualificationTemplateQuestion);
			collectionsQueue.Enqueue(this._testCollectionViaEventTest);
			collectionsQueue.Enqueue(this._testCollectionViaPreQualificationTemplateDependentTest);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._eventTest = (EntityCollection<EventTestEntity>) collectionsQueue.Dequeue();
			this._preQualificationTemplateDependentTest = (EntityCollection<PreQualificationTemplateDependentTestEntity>) collectionsQueue.Dequeue();
			this._preQualificationTemplateQuestion = (EntityCollection<PreQualificationTemplateQuestionEntity>) collectionsQueue.Dequeue();
			this._test_ = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventTest = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._hafTemplateCollectionViaTest = (EntityCollection<HafTemplateEntity>) collectionsQueue.Dequeue();
			this._hafTemplateCollectionViaEventTest = (EntityCollection<HafTemplateEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaTest = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaTest_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaTest__ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEventTest = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEventTest_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEventTest__ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._preQualificationQuestionCollectionViaPreQualificationTemplateQuestion = (EntityCollection<PreQualificationQuestionEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaEventTest = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaPreQualificationTemplateDependentTest = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._eventTest != null)
			{
				return true;
			}
			if (this._preQualificationTemplateDependentTest != null)
			{
				return true;
			}
			if (this._preQualificationTemplateQuestion != null)
			{
				return true;
			}
			if (this._test_ != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventTest != null)
			{
				return true;
			}
			if (this._hafTemplateCollectionViaTest != null)
			{
				return true;
			}
			if (this._hafTemplateCollectionViaEventTest != null)
			{
				return true;
			}
			if (this._lookupCollectionViaTest != null)
			{
				return true;
			}
			if (this._lookupCollectionViaTest_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaTest__ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEventTest != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEventTest_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEventTest__ != null)
			{
				return true;
			}
			if (this._preQualificationQuestionCollectionViaPreQualificationTemplateQuestion != null)
			{
				return true;
			}
			if (this._testCollectionViaEventTest != null)
			{
				return true;
			}
			if (this._testCollectionViaPreQualificationTemplateDependentTest != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PreQualificationTemplateDependentTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTemplateDependentTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PreQualificationTemplateQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTemplateQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PreQualificationQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationQuestionEntityFactory))) : null);
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
			toReturn.Add("OrganizationRoleUser_", _organizationRoleUser_);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("Test", _test);
			toReturn.Add("EventTest", _eventTest);
			toReturn.Add("PreQualificationTemplateDependentTest", _preQualificationTemplateDependentTest);
			toReturn.Add("PreQualificationTemplateQuestion", _preQualificationTemplateQuestion);
			toReturn.Add("Test_", _test_);
			toReturn.Add("EventsCollectionViaEventTest", _eventsCollectionViaEventTest);
			toReturn.Add("HafTemplateCollectionViaTest", _hafTemplateCollectionViaTest);
			toReturn.Add("HafTemplateCollectionViaEventTest", _hafTemplateCollectionViaEventTest);
			toReturn.Add("LookupCollectionViaTest", _lookupCollectionViaTest);
			toReturn.Add("LookupCollectionViaTest_", _lookupCollectionViaTest_);
			toReturn.Add("LookupCollectionViaTest__", _lookupCollectionViaTest__);
			toReturn.Add("LookupCollectionViaEventTest", _lookupCollectionViaEventTest);
			toReturn.Add("LookupCollectionViaEventTest_", _lookupCollectionViaEventTest_);
			toReturn.Add("LookupCollectionViaEventTest__", _lookupCollectionViaEventTest__);
			toReturn.Add("PreQualificationQuestionCollectionViaPreQualificationTemplateQuestion", _preQualificationQuestionCollectionViaPreQualificationTemplateQuestion);
			toReturn.Add("TestCollectionViaEventTest", _testCollectionViaEventTest);
			toReturn.Add("TestCollectionViaPreQualificationTemplateDependentTest", _testCollectionViaPreQualificationTemplateDependentTest);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_eventTest!=null)
			{
				_eventTest.ActiveContext = base.ActiveContext;
			}
			if(_preQualificationTemplateDependentTest!=null)
			{
				_preQualificationTemplateDependentTest.ActiveContext = base.ActiveContext;
			}
			if(_preQualificationTemplateQuestion!=null)
			{
				_preQualificationTemplateQuestion.ActiveContext = base.ActiveContext;
			}
			if(_test_!=null)
			{
				_test_.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventTest!=null)
			{
				_eventsCollectionViaEventTest.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplateCollectionViaTest!=null)
			{
				_hafTemplateCollectionViaTest.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplateCollectionViaEventTest!=null)
			{
				_hafTemplateCollectionViaEventTest.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaTest!=null)
			{
				_lookupCollectionViaTest.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaTest_!=null)
			{
				_lookupCollectionViaTest_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaTest__!=null)
			{
				_lookupCollectionViaTest__.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEventTest!=null)
			{
				_lookupCollectionViaEventTest.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEventTest_!=null)
			{
				_lookupCollectionViaEventTest_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEventTest__!=null)
			{
				_lookupCollectionViaEventTest__.ActiveContext = base.ActiveContext;
			}
			if(_preQualificationQuestionCollectionViaPreQualificationTemplateQuestion!=null)
			{
				_preQualificationQuestionCollectionViaPreQualificationTemplateQuestion.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaEventTest!=null)
			{
				_testCollectionViaEventTest.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaPreQualificationTemplateDependentTest!=null)
			{
				_testCollectionViaPreQualificationTemplateDependentTest.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser_!=null)
			{
				_organizationRoleUser_.ActiveContext = base.ActiveContext;
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

			_eventTest = null;
			_preQualificationTemplateDependentTest = null;
			_preQualificationTemplateQuestion = null;
			_test_ = null;
			_eventsCollectionViaEventTest = null;
			_hafTemplateCollectionViaTest = null;
			_hafTemplateCollectionViaEventTest = null;
			_lookupCollectionViaTest = null;
			_lookupCollectionViaTest_ = null;
			_lookupCollectionViaTest__ = null;
			_lookupCollectionViaEventTest = null;
			_lookupCollectionViaEventTest_ = null;
			_lookupCollectionViaEventTest__ = null;
			_preQualificationQuestionCollectionViaPreQualificationTemplateQuestion = null;
			_testCollectionViaEventTest = null;
			_testCollectionViaPreQualificationTemplateDependentTest = null;
			_organizationRoleUser_ = null;
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

			_fieldsCustomProperties.Add("TemplateName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsPublished", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UpdatedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UpdatedDate", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organizationRoleUser_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", PreQualificationTestTemplateEntity.Relations.OrganizationRoleUserEntityUsingUpdatedBy, true, signalRelatedEntity, "PreQualificationTestTemplate_", resetFKFields, new int[] { (int)PreQualificationTestTemplateFieldIndex.UpdatedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", PreQualificationTestTemplateEntity.Relations.OrganizationRoleUserEntityUsingUpdatedBy, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", PreQualificationTestTemplateEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, signalRelatedEntity, "PreQualificationTestTemplate", resetFKFields, new int[] { (int)PreQualificationTestTemplateFieldIndex.CreatedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", PreQualificationTestTemplateEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _test, new PropertyChangedEventHandler( OnTestPropertyChanged ), "Test", PreQualificationTestTemplateEntity.Relations.TestEntityUsingTestId, true, signalRelatedEntity, "PreQualificationTestTemplate", resetFKFields, new int[] { (int)PreQualificationTestTemplateFieldIndex.TestId } );		
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
				base.PerformSetupSyncRelatedEntity( _test, new PropertyChangedEventHandler( OnTestPropertyChanged ), "Test", PreQualificationTestTemplateEntity.Relations.TestEntityUsingTestId, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this PreQualificationTestTemplateEntity</param>
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
		public  static PreQualificationTestTemplateRelations Relations
		{
			get	{ return new PreQualificationTestTemplateRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventTest")[0], (int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, (int)Falcon.Data.EntityType.EventTestEntity, 0, null, null, null, null, "EventTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("PreQualificationTemplateDependentTest")[0], (int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, (int)Falcon.Data.EntityType.PreQualificationTemplateDependentTestEntity, 0, null, null, null, null, "PreQualificationTemplateDependentTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("PreQualificationTemplateQuestion")[0], (int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, (int)Falcon.Data.EntityType.PreQualificationTemplateQuestionEntity, 0, null, null, null, null, "PreQualificationTemplateQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTest_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))),
					(IEntityRelation)GetRelationsForField("Test_")[0], (int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, null, null, "Test_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventTest
		{
			get
			{
				IEntityRelation intermediateRelation = PreQualificationTestTemplateEntity.Relations.EventTestEntityUsingPreQualificationQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "EventTest_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventTest"), null, "EventsCollectionViaEventTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplateCollectionViaTest
		{
			get
			{
				IEntityRelation intermediateRelation = PreQualificationTestTemplateEntity.Relations.TestEntityUsingPreQualificationQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Test_");
				return new PrefetchPathElement2(new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, GetRelationsForField("HafTemplateCollectionViaTest"), null, "HafTemplateCollectionViaTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplateCollectionViaEventTest
		{
			get
			{
				IEntityRelation intermediateRelation = PreQualificationTestTemplateEntity.Relations.EventTestEntityUsingPreQualificationQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "EventTest_");
				return new PrefetchPathElement2(new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, GetRelationsForField("HafTemplateCollectionViaEventTest"), null, "HafTemplateCollectionViaEventTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaTest
		{
			get
			{
				IEntityRelation intermediateRelation = PreQualificationTestTemplateEntity.Relations.TestEntityUsingPreQualificationQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Test_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaTest"), null, "LookupCollectionViaTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaTest_
		{
			get
			{
				IEntityRelation intermediateRelation = PreQualificationTestTemplateEntity.Relations.TestEntityUsingPreQualificationQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Test_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaTest_"), null, "LookupCollectionViaTest_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaTest__
		{
			get
			{
				IEntityRelation intermediateRelation = PreQualificationTestTemplateEntity.Relations.TestEntityUsingPreQualificationQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Test_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaTest__"), null, "LookupCollectionViaTest__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventTest
		{
			get
			{
				IEntityRelation intermediateRelation = PreQualificationTestTemplateEntity.Relations.EventTestEntityUsingPreQualificationQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "EventTest_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventTest"), null, "LookupCollectionViaEventTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventTest_
		{
			get
			{
				IEntityRelation intermediateRelation = PreQualificationTestTemplateEntity.Relations.EventTestEntityUsingPreQualificationQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "EventTest_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventTest_"), null, "LookupCollectionViaEventTest_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventTest__
		{
			get
			{
				IEntityRelation intermediateRelation = PreQualificationTestTemplateEntity.Relations.EventTestEntityUsingPreQualificationQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "EventTest_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventTest__"), null, "LookupCollectionViaEventTest__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PreQualificationQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPreQualificationQuestionCollectionViaPreQualificationTemplateQuestion
		{
			get
			{
				IEntityRelation intermediateRelation = PreQualificationTestTemplateEntity.Relations.PreQualificationTemplateQuestionEntityUsingTemplateId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationTemplateQuestion_");
				return new PrefetchPathElement2(new EntityCollection<PreQualificationQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationQuestionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, (int)Falcon.Data.EntityType.PreQualificationQuestionEntity, 0, null, null, GetRelationsForField("PreQualificationQuestionCollectionViaPreQualificationTemplateQuestion"), null, "PreQualificationQuestionCollectionViaPreQualificationTemplateQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaEventTest
		{
			get
			{
				IEntityRelation intermediateRelation = PreQualificationTestTemplateEntity.Relations.EventTestEntityUsingPreQualificationQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "EventTest_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaEventTest"), null, "TestCollectionViaEventTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaPreQualificationTemplateDependentTest
		{
			get
			{
				IEntityRelation intermediateRelation = PreQualificationTestTemplateEntity.Relations.PreQualificationTemplateDependentTestEntityUsingTemplateId;
				intermediateRelation.SetAliases(string.Empty, "PreQualificationTemplateDependentTest_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaPreQualificationTemplateDependentTest"), null, "TestCollectionViaPreQualificationTemplateDependentTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Test")[0], (int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, null, null, "Test", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return PreQualificationTestTemplateEntity.CustomProperties;}
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
			get { return PreQualificationTestTemplateEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity PreQualificationTestTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationTestTemplate"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)PreQualificationTestTemplateFieldIndex.Id, true); }
			set	{ SetValue((int)PreQualificationTestTemplateFieldIndex.Id, value); }
		}

		/// <summary> The TemplateName property of the Entity PreQualificationTestTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationTestTemplate"."TemplateName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 250<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String TemplateName
		{
			get { return (System.String)GetValue((int)PreQualificationTestTemplateFieldIndex.TemplateName, true); }
			set	{ SetValue((int)PreQualificationTestTemplateFieldIndex.TemplateName, value); }
		}

		/// <summary> The TestId property of the Entity PreQualificationTestTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationTestTemplate"."TestId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TestId
		{
			get { return (System.Int64)GetValue((int)PreQualificationTestTemplateFieldIndex.TestId, true); }
			set	{ SetValue((int)PreQualificationTestTemplateFieldIndex.TestId, value); }
		}

		/// <summary> The IsActive property of the Entity PreQualificationTestTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationTestTemplate"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)PreQualificationTestTemplateFieldIndex.IsActive, true); }
			set	{ SetValue((int)PreQualificationTestTemplateFieldIndex.IsActive, value); }
		}

		/// <summary> The IsPublished property of the Entity PreQualificationTestTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationTestTemplate"."IsPublished"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsPublished
		{
			get { return (System.Boolean)GetValue((int)PreQualificationTestTemplateFieldIndex.IsPublished, true); }
			set	{ SetValue((int)PreQualificationTestTemplateFieldIndex.IsPublished, value); }
		}

		/// <summary> The CreatedBy property of the Entity PreQualificationTestTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationTestTemplate"."CreatedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CreatedBy
		{
			get { return (Nullable<System.Int64>)GetValue((int)PreQualificationTestTemplateFieldIndex.CreatedBy, false); }
			set	{ SetValue((int)PreQualificationTestTemplateFieldIndex.CreatedBy, value); }
		}

		/// <summary> The CreatedDate property of the Entity PreQualificationTestTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationTestTemplate"."CreatedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> CreatedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)PreQualificationTestTemplateFieldIndex.CreatedDate, false); }
			set	{ SetValue((int)PreQualificationTestTemplateFieldIndex.CreatedDate, value); }
		}

		/// <summary> The UpdatedBy property of the Entity PreQualificationTestTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationTestTemplate"."UpdatedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> UpdatedBy
		{
			get { return (Nullable<System.Int64>)GetValue((int)PreQualificationTestTemplateFieldIndex.UpdatedBy, false); }
			set	{ SetValue((int)PreQualificationTestTemplateFieldIndex.UpdatedBy, value); }
		}

		/// <summary> The UpdatedDate property of the Entity PreQualificationTestTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblPreQualificationTestTemplate"."UpdatedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> UpdatedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)PreQualificationTestTemplateFieldIndex.UpdatedDate, false); }
			set	{ SetValue((int)PreQualificationTestTemplateFieldIndex.UpdatedDate, value); }
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
					_eventTest.SetContainingEntityInfo(this, "PreQualificationTestTemplate");
				}
				return _eventTest;
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
					_preQualificationTemplateDependentTest.SetContainingEntityInfo(this, "PreQualificationTestTemplate");
				}
				return _preQualificationTemplateDependentTest;
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
					_preQualificationTemplateQuestion.SetContainingEntityInfo(this, "PreQualificationTestTemplate");
				}
				return _preQualificationTemplateQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> Test_
		{
			get
			{
				if(_test_==null)
				{
					_test_ = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_test_.SetContainingEntityInfo(this, "PreQualificationTestTemplate_");
				}
				return _test_;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'HafTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HafTemplateEntity))]
		public virtual EntityCollection<HafTemplateEntity> HafTemplateCollectionViaTest
		{
			get
			{
				if(_hafTemplateCollectionViaTest==null)
				{
					_hafTemplateCollectionViaTest = new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory)));
					_hafTemplateCollectionViaTest.IsReadOnly=true;
				}
				return _hafTemplateCollectionViaTest;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaTest
		{
			get
			{
				if(_lookupCollectionViaTest==null)
				{
					_lookupCollectionViaTest = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaTest.IsReadOnly=true;
				}
				return _lookupCollectionViaTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaTest_
		{
			get
			{
				if(_lookupCollectionViaTest_==null)
				{
					_lookupCollectionViaTest_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaTest_.IsReadOnly=true;
				}
				return _lookupCollectionViaTest_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaTest__
		{
			get
			{
				if(_lookupCollectionViaTest__==null)
				{
					_lookupCollectionViaTest__ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaTest__.IsReadOnly=true;
				}
				return _lookupCollectionViaTest__;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'PreQualificationQuestionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PreQualificationQuestionEntity))]
		public virtual EntityCollection<PreQualificationQuestionEntity> PreQualificationQuestionCollectionViaPreQualificationTemplateQuestion
		{
			get
			{
				if(_preQualificationQuestionCollectionViaPreQualificationTemplateQuestion==null)
				{
					_preQualificationQuestionCollectionViaPreQualificationTemplateQuestion = new EntityCollection<PreQualificationQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationQuestionEntityFactory)));
					_preQualificationQuestionCollectionViaPreQualificationTemplateQuestion.IsReadOnly=true;
				}
				return _preQualificationQuestionCollectionViaPreQualificationTemplateQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaEventTest
		{
			get
			{
				if(_testCollectionViaEventTest==null)
				{
					_testCollectionViaEventTest = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaEventTest.IsReadOnly=true;
				}
				return _testCollectionViaEventTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaPreQualificationTemplateDependentTest
		{
			get
			{
				if(_testCollectionViaPreQualificationTemplateDependentTest==null)
				{
					_testCollectionViaPreQualificationTemplateDependentTest = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaPreQualificationTemplateDependentTest.IsReadOnly=true;
				}
				return _testCollectionViaPreQualificationTemplateDependentTest;
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
							_organizationRoleUser_.UnsetRelatedEntity(this, "PreQualificationTestTemplate_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PreQualificationTestTemplate_");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "PreQualificationTestTemplate");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PreQualificationTestTemplate");
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
							_test.UnsetRelatedEntity(this, "PreQualificationTestTemplate");
						}
					}
					else
					{
						if(_test!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "PreQualificationTestTemplate");
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
			get { return (int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity; }
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
