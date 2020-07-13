///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:46
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
	/// Entity class which represents the entity 'CustomerEventScreeningTests'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CustomerEventScreeningTestsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CustomerEventReadingEntity> _customerEventReading;
		private EntityCollection<CustomerEventTestIncidentalFindingEntity> _customerEventTestIncidentalFinding;
		private EntityCollection<CustomerEventTestPhysicianEvaluationEntity> _customerEventTestPhysicianEvaluation;
		private EntityCollection<CustomerEventTestStandardFindingEntity> _customerEventTestStandardFinding;
		private EntityCollection<CustomerEventTestStateEntity> _customerEventTestState;
		private EntityCollection<CustomerEventUnableScreenReasonEntity> _customerEventUnableScreenReason;
		private EntityCollection<TestMediaEntity> _testMedia;
		private EntityCollection<TestNotPerformedEntity> _testNotPerformed;
		private EntityCollection<TestPerformedExternallyEntity> _testPerformedExternally;
		private EntityCollection<FileEntity> _fileCollectionViaTestMedia;
		private EntityCollection<IncidentalFindingsEntity> _incidentalFindingsCollectionViaCustomerEventTestIncidentalFinding;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerEventTestState;
		private EntityCollection<LookupEntity> _lookupCollectionViaTestPerformedExternally;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerEventUnableScreenReason;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaTestNotPerformed;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaTestPerformedExternally_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaTestPerformedExternally;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaTestNotPerformed_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerEventTestState__;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerEventTestState;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerEventReading;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerEventTestState_;
		private EntityCollection<StandardFindingTestReadingEntity> _standardFindingTestReadingCollectionViaCustomerEventReading;
		private EntityCollection<StandardFindingTestReadingEntity> _standardFindingTestReadingCollectionViaCustomerEventTestStandardFinding;
		private EntityCollection<TestNotPerformedReasonEntity> _testNotPerformedReasonCollectionViaTestNotPerformed;
		private EntityCollection<TestReadingEntity> _testReadingCollectionViaCustomerEventReading;
		private EntityCollection<TestUnableScreenReasonEntity> _testUnableScreenReasonCollectionViaCustomerEventUnableScreenReason;
		private EventCustomerResultEntity _eventCustomerResult;
		private TestEntity _test;
		private CustomerEventCriticalTestDataEntity _customerEventCriticalTestData;
		private CustomerEventPriorityInQueueDataEntity _customerEventPriorityInQueueData;
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name EventCustomerResult</summary>
			public static readonly string EventCustomerResult = "EventCustomerResult";
			/// <summary>Member name Test</summary>
			public static readonly string Test = "Test";
			/// <summary>Member name CustomerEventReading</summary>
			public static readonly string CustomerEventReading = "CustomerEventReading";
			/// <summary>Member name CustomerEventTestIncidentalFinding</summary>
			public static readonly string CustomerEventTestIncidentalFinding = "CustomerEventTestIncidentalFinding";
			/// <summary>Member name CustomerEventTestPhysicianEvaluation</summary>
			public static readonly string CustomerEventTestPhysicianEvaluation = "CustomerEventTestPhysicianEvaluation";
			/// <summary>Member name CustomerEventTestStandardFinding</summary>
			public static readonly string CustomerEventTestStandardFinding = "CustomerEventTestStandardFinding";
			/// <summary>Member name CustomerEventTestState</summary>
			public static readonly string CustomerEventTestState = "CustomerEventTestState";
			/// <summary>Member name CustomerEventUnableScreenReason</summary>
			public static readonly string CustomerEventUnableScreenReason = "CustomerEventUnableScreenReason";
			/// <summary>Member name TestMedia</summary>
			public static readonly string TestMedia = "TestMedia";
			/// <summary>Member name TestNotPerformed</summary>
			public static readonly string TestNotPerformed = "TestNotPerformed";
			/// <summary>Member name TestPerformedExternally</summary>
			public static readonly string TestPerformedExternally = "TestPerformedExternally";
			/// <summary>Member name FileCollectionViaTestMedia</summary>
			public static readonly string FileCollectionViaTestMedia = "FileCollectionViaTestMedia";
			/// <summary>Member name IncidentalFindingsCollectionViaCustomerEventTestIncidentalFinding</summary>
			public static readonly string IncidentalFindingsCollectionViaCustomerEventTestIncidentalFinding = "IncidentalFindingsCollectionViaCustomerEventTestIncidentalFinding";
			/// <summary>Member name LookupCollectionViaCustomerEventTestState</summary>
			public static readonly string LookupCollectionViaCustomerEventTestState = "LookupCollectionViaCustomerEventTestState";
			/// <summary>Member name LookupCollectionViaTestPerformedExternally</summary>
			public static readonly string LookupCollectionViaTestPerformedExternally = "LookupCollectionViaTestPerformedExternally";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerEventUnableScreenReason</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerEventUnableScreenReason = "OrganizationRoleUserCollectionViaCustomerEventUnableScreenReason";
			/// <summary>Member name OrganizationRoleUserCollectionViaTestNotPerformed</summary>
			public static readonly string OrganizationRoleUserCollectionViaTestNotPerformed = "OrganizationRoleUserCollectionViaTestNotPerformed";
			/// <summary>Member name OrganizationRoleUserCollectionViaTestPerformedExternally_</summary>
			public static readonly string OrganizationRoleUserCollectionViaTestPerformedExternally_ = "OrganizationRoleUserCollectionViaTestPerformedExternally_";
			/// <summary>Member name OrganizationRoleUserCollectionViaTestPerformedExternally</summary>
			public static readonly string OrganizationRoleUserCollectionViaTestPerformedExternally = "OrganizationRoleUserCollectionViaTestPerformedExternally";
			/// <summary>Member name OrganizationRoleUserCollectionViaTestNotPerformed_</summary>
			public static readonly string OrganizationRoleUserCollectionViaTestNotPerformed_ = "OrganizationRoleUserCollectionViaTestNotPerformed_";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerEventTestState__</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerEventTestState__ = "OrganizationRoleUserCollectionViaCustomerEventTestState__";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerEventTestState</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerEventTestState = "OrganizationRoleUserCollectionViaCustomerEventTestState";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerEventReading</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerEventReading = "OrganizationRoleUserCollectionViaCustomerEventReading";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation = "OrganizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerEventTestState_</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerEventTestState_ = "OrganizationRoleUserCollectionViaCustomerEventTestState_";
			/// <summary>Member name StandardFindingTestReadingCollectionViaCustomerEventReading</summary>
			public static readonly string StandardFindingTestReadingCollectionViaCustomerEventReading = "StandardFindingTestReadingCollectionViaCustomerEventReading";
			/// <summary>Member name StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding</summary>
			public static readonly string StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding = "StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding";
			/// <summary>Member name TestNotPerformedReasonCollectionViaTestNotPerformed</summary>
			public static readonly string TestNotPerformedReasonCollectionViaTestNotPerformed = "TestNotPerformedReasonCollectionViaTestNotPerformed";
			/// <summary>Member name TestReadingCollectionViaCustomerEventReading</summary>
			public static readonly string TestReadingCollectionViaCustomerEventReading = "TestReadingCollectionViaCustomerEventReading";
			/// <summary>Member name TestUnableScreenReasonCollectionViaCustomerEventUnableScreenReason</summary>
			public static readonly string TestUnableScreenReasonCollectionViaCustomerEventUnableScreenReason = "TestUnableScreenReasonCollectionViaCustomerEventUnableScreenReason";
			/// <summary>Member name CustomerEventCriticalTestData</summary>
			public static readonly string CustomerEventCriticalTestData = "CustomerEventCriticalTestData";
			/// <summary>Member name CustomerEventPriorityInQueueData</summary>
			public static readonly string CustomerEventPriorityInQueueData = "CustomerEventPriorityInQueueData";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CustomerEventScreeningTestsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CustomerEventScreeningTestsEntity():base("CustomerEventScreeningTestsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CustomerEventScreeningTestsEntity(IEntityFields2 fields):base("CustomerEventScreeningTestsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CustomerEventScreeningTestsEntity</param>
		public CustomerEventScreeningTestsEntity(IValidator validator):base("CustomerEventScreeningTestsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="customerEventScreeningTestId">PK value for CustomerEventScreeningTests which data should be fetched into this CustomerEventScreeningTests object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CustomerEventScreeningTestsEntity(System.Int64 customerEventScreeningTestId):base("CustomerEventScreeningTestsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CustomerEventScreeningTestId = customerEventScreeningTestId;
		}

		/// <summary> CTor</summary>
		/// <param name="customerEventScreeningTestId">PK value for CustomerEventScreeningTests which data should be fetched into this CustomerEventScreeningTests object</param>
		/// <param name="validator">The custom validator object for this CustomerEventScreeningTestsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CustomerEventScreeningTestsEntity(System.Int64 customerEventScreeningTestId, IValidator validator):base("CustomerEventScreeningTestsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CustomerEventScreeningTestId = customerEventScreeningTestId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CustomerEventScreeningTestsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_customerEventReading = (EntityCollection<CustomerEventReadingEntity>)info.GetValue("_customerEventReading", typeof(EntityCollection<CustomerEventReadingEntity>));
				_customerEventTestIncidentalFinding = (EntityCollection<CustomerEventTestIncidentalFindingEntity>)info.GetValue("_customerEventTestIncidentalFinding", typeof(EntityCollection<CustomerEventTestIncidentalFindingEntity>));
				_customerEventTestPhysicianEvaluation = (EntityCollection<CustomerEventTestPhysicianEvaluationEntity>)info.GetValue("_customerEventTestPhysicianEvaluation", typeof(EntityCollection<CustomerEventTestPhysicianEvaluationEntity>));
				_customerEventTestStandardFinding = (EntityCollection<CustomerEventTestStandardFindingEntity>)info.GetValue("_customerEventTestStandardFinding", typeof(EntityCollection<CustomerEventTestStandardFindingEntity>));
				_customerEventTestState = (EntityCollection<CustomerEventTestStateEntity>)info.GetValue("_customerEventTestState", typeof(EntityCollection<CustomerEventTestStateEntity>));
				_customerEventUnableScreenReason = (EntityCollection<CustomerEventUnableScreenReasonEntity>)info.GetValue("_customerEventUnableScreenReason", typeof(EntityCollection<CustomerEventUnableScreenReasonEntity>));
				_testMedia = (EntityCollection<TestMediaEntity>)info.GetValue("_testMedia", typeof(EntityCollection<TestMediaEntity>));
				_testNotPerformed = (EntityCollection<TestNotPerformedEntity>)info.GetValue("_testNotPerformed", typeof(EntityCollection<TestNotPerformedEntity>));
				_testPerformedExternally = (EntityCollection<TestPerformedExternallyEntity>)info.GetValue("_testPerformedExternally", typeof(EntityCollection<TestPerformedExternallyEntity>));
				_fileCollectionViaTestMedia = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaTestMedia", typeof(EntityCollection<FileEntity>));
				_incidentalFindingsCollectionViaCustomerEventTestIncidentalFinding = (EntityCollection<IncidentalFindingsEntity>)info.GetValue("_incidentalFindingsCollectionViaCustomerEventTestIncidentalFinding", typeof(EntityCollection<IncidentalFindingsEntity>));
				_lookupCollectionViaCustomerEventTestState = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerEventTestState", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaTestPerformedExternally = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaTestPerformedExternally", typeof(EntityCollection<LookupEntity>));
				_organizationRoleUserCollectionViaCustomerEventUnableScreenReason = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerEventUnableScreenReason", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaTestNotPerformed = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaTestNotPerformed", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaTestPerformedExternally_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaTestPerformedExternally_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaTestPerformedExternally = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaTestPerformedExternally", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaTestNotPerformed_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaTestNotPerformed_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomerEventTestState__ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerEventTestState__", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomerEventTestState = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerEventTestState", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomerEventReading = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerEventReading", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomerEventTestState_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerEventTestState_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_standardFindingTestReadingCollectionViaCustomerEventReading = (EntityCollection<StandardFindingTestReadingEntity>)info.GetValue("_standardFindingTestReadingCollectionViaCustomerEventReading", typeof(EntityCollection<StandardFindingTestReadingEntity>));
				_standardFindingTestReadingCollectionViaCustomerEventTestStandardFinding = (EntityCollection<StandardFindingTestReadingEntity>)info.GetValue("_standardFindingTestReadingCollectionViaCustomerEventTestStandardFinding", typeof(EntityCollection<StandardFindingTestReadingEntity>));
				_testNotPerformedReasonCollectionViaTestNotPerformed = (EntityCollection<TestNotPerformedReasonEntity>)info.GetValue("_testNotPerformedReasonCollectionViaTestNotPerformed", typeof(EntityCollection<TestNotPerformedReasonEntity>));
				_testReadingCollectionViaCustomerEventReading = (EntityCollection<TestReadingEntity>)info.GetValue("_testReadingCollectionViaCustomerEventReading", typeof(EntityCollection<TestReadingEntity>));
				_testUnableScreenReasonCollectionViaCustomerEventUnableScreenReason = (EntityCollection<TestUnableScreenReasonEntity>)info.GetValue("_testUnableScreenReasonCollectionViaCustomerEventUnableScreenReason", typeof(EntityCollection<TestUnableScreenReasonEntity>));
				_eventCustomerResult = (EventCustomerResultEntity)info.GetValue("_eventCustomerResult", typeof(EventCustomerResultEntity));
				if(_eventCustomerResult!=null)
				{
					_eventCustomerResult.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_test = (TestEntity)info.GetValue("_test", typeof(TestEntity));
				if(_test!=null)
				{
					_test.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_customerEventCriticalTestData = (CustomerEventCriticalTestDataEntity)info.GetValue("_customerEventCriticalTestData", typeof(CustomerEventCriticalTestDataEntity));
				if(_customerEventCriticalTestData!=null)
				{
					_customerEventCriticalTestData.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_customerEventPriorityInQueueData = (CustomerEventPriorityInQueueDataEntity)info.GetValue("_customerEventPriorityInQueueData", typeof(CustomerEventPriorityInQueueDataEntity));
				if(_customerEventPriorityInQueueData!=null)
				{
					_customerEventPriorityInQueueData.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((CustomerEventScreeningTestsFieldIndex)fieldIndex)
			{
				case CustomerEventScreeningTestsFieldIndex.TestId:
					DesetupSyncTest(true, false);
					break;
				case CustomerEventScreeningTestsFieldIndex.EventCustomerResultId:
					DesetupSyncEventCustomerResult(true, false);
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
				case "EventCustomerResult":
					this.EventCustomerResult = (EventCustomerResultEntity)entity;
					break;
				case "Test":
					this.Test = (TestEntity)entity;
					break;
				case "CustomerEventReading":
					this.CustomerEventReading.Add((CustomerEventReadingEntity)entity);
					break;
				case "CustomerEventTestIncidentalFinding":
					this.CustomerEventTestIncidentalFinding.Add((CustomerEventTestIncidentalFindingEntity)entity);
					break;
				case "CustomerEventTestPhysicianEvaluation":
					this.CustomerEventTestPhysicianEvaluation.Add((CustomerEventTestPhysicianEvaluationEntity)entity);
					break;
				case "CustomerEventTestStandardFinding":
					this.CustomerEventTestStandardFinding.Add((CustomerEventTestStandardFindingEntity)entity);
					break;
				case "CustomerEventTestState":
					this.CustomerEventTestState.Add((CustomerEventTestStateEntity)entity);
					break;
				case "CustomerEventUnableScreenReason":
					this.CustomerEventUnableScreenReason.Add((CustomerEventUnableScreenReasonEntity)entity);
					break;
				case "TestMedia":
					this.TestMedia.Add((TestMediaEntity)entity);
					break;
				case "TestNotPerformed":
					this.TestNotPerformed.Add((TestNotPerformedEntity)entity);
					break;
				case "TestPerformedExternally":
					this.TestPerformedExternally.Add((TestPerformedExternallyEntity)entity);
					break;
				case "FileCollectionViaTestMedia":
					this.FileCollectionViaTestMedia.IsReadOnly = false;
					this.FileCollectionViaTestMedia.Add((FileEntity)entity);
					this.FileCollectionViaTestMedia.IsReadOnly = true;
					break;
				case "IncidentalFindingsCollectionViaCustomerEventTestIncidentalFinding":
					this.IncidentalFindingsCollectionViaCustomerEventTestIncidentalFinding.IsReadOnly = false;
					this.IncidentalFindingsCollectionViaCustomerEventTestIncidentalFinding.Add((IncidentalFindingsEntity)entity);
					this.IncidentalFindingsCollectionViaCustomerEventTestIncidentalFinding.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerEventTestState":
					this.LookupCollectionViaCustomerEventTestState.IsReadOnly = false;
					this.LookupCollectionViaCustomerEventTestState.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerEventTestState.IsReadOnly = true;
					break;
				case "LookupCollectionViaTestPerformedExternally":
					this.LookupCollectionViaTestPerformedExternally.IsReadOnly = false;
					this.LookupCollectionViaTestPerformedExternally.Add((LookupEntity)entity);
					this.LookupCollectionViaTestPerformedExternally.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerEventUnableScreenReason":
					this.OrganizationRoleUserCollectionViaCustomerEventUnableScreenReason.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerEventUnableScreenReason.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerEventUnableScreenReason.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaTestNotPerformed":
					this.OrganizationRoleUserCollectionViaTestNotPerformed.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaTestNotPerformed.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaTestNotPerformed.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaTestPerformedExternally_":
					this.OrganizationRoleUserCollectionViaTestPerformedExternally_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaTestPerformedExternally_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaTestPerformedExternally_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaTestPerformedExternally":
					this.OrganizationRoleUserCollectionViaTestPerformedExternally.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaTestPerformedExternally.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaTestPerformedExternally.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaTestNotPerformed_":
					this.OrganizationRoleUserCollectionViaTestNotPerformed_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaTestNotPerformed_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaTestNotPerformed_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerEventTestState__":
					this.OrganizationRoleUserCollectionViaCustomerEventTestState__.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerEventTestState__.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerEventTestState__.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerEventTestState":
					this.OrganizationRoleUserCollectionViaCustomerEventTestState.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerEventTestState.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerEventTestState.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerEventReading":
					this.OrganizationRoleUserCollectionViaCustomerEventReading.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerEventReading.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerEventReading.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation":
					this.OrganizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerEventTestState_":
					this.OrganizationRoleUserCollectionViaCustomerEventTestState_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerEventTestState_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerEventTestState_.IsReadOnly = true;
					break;
				case "StandardFindingTestReadingCollectionViaCustomerEventReading":
					this.StandardFindingTestReadingCollectionViaCustomerEventReading.IsReadOnly = false;
					this.StandardFindingTestReadingCollectionViaCustomerEventReading.Add((StandardFindingTestReadingEntity)entity);
					this.StandardFindingTestReadingCollectionViaCustomerEventReading.IsReadOnly = true;
					break;
				case "StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding":
					this.StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding.IsReadOnly = false;
					this.StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding.Add((StandardFindingTestReadingEntity)entity);
					this.StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding.IsReadOnly = true;
					break;
				case "TestNotPerformedReasonCollectionViaTestNotPerformed":
					this.TestNotPerformedReasonCollectionViaTestNotPerformed.IsReadOnly = false;
					this.TestNotPerformedReasonCollectionViaTestNotPerformed.Add((TestNotPerformedReasonEntity)entity);
					this.TestNotPerformedReasonCollectionViaTestNotPerformed.IsReadOnly = true;
					break;
				case "TestReadingCollectionViaCustomerEventReading":
					this.TestReadingCollectionViaCustomerEventReading.IsReadOnly = false;
					this.TestReadingCollectionViaCustomerEventReading.Add((TestReadingEntity)entity);
					this.TestReadingCollectionViaCustomerEventReading.IsReadOnly = true;
					break;
				case "TestUnableScreenReasonCollectionViaCustomerEventUnableScreenReason":
					this.TestUnableScreenReasonCollectionViaCustomerEventUnableScreenReason.IsReadOnly = false;
					this.TestUnableScreenReasonCollectionViaCustomerEventUnableScreenReason.Add((TestUnableScreenReasonEntity)entity);
					this.TestUnableScreenReasonCollectionViaCustomerEventUnableScreenReason.IsReadOnly = true;
					break;
				case "CustomerEventCriticalTestData":
					this.CustomerEventCriticalTestData = (CustomerEventCriticalTestDataEntity)entity;
					break;
				case "CustomerEventPriorityInQueueData":
					this.CustomerEventPriorityInQueueData = (CustomerEventPriorityInQueueDataEntity)entity;
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
			return CustomerEventScreeningTestsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "EventCustomerResult":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.EventCustomerResultEntityUsingEventCustomerResultId);
					break;
				case "Test":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.TestEntityUsingTestId);
					break;
				case "CustomerEventReading":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.CustomerEventReadingEntityUsingCustomerEventScreeningTestId);
					break;
				case "CustomerEventTestIncidentalFinding":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.CustomerEventTestIncidentalFindingEntityUsingCustomerEventScreeningTestId);
					break;
				case "CustomerEventTestPhysicianEvaluation":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.CustomerEventTestPhysicianEvaluationEntityUsingCustomerEventScreeningTestId);
					break;
				case "CustomerEventTestStandardFinding":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.CustomerEventTestStandardFindingEntityUsingCustomerEventScreeningTestId);
					break;
				case "CustomerEventTestState":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.CustomerEventTestStateEntityUsingCustomerEventScreeningTestId);
					break;
				case "CustomerEventUnableScreenReason":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.CustomerEventUnableScreenReasonEntityUsingCustomerEventScreeningTestId);
					break;
				case "TestMedia":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.TestMediaEntityUsingCustomerEventScreeningTestId);
					break;
				case "TestNotPerformed":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.TestNotPerformedEntityUsingCustomerEventScreeningTestId);
					break;
				case "TestPerformedExternally":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.TestPerformedExternallyEntityUsingCustomerEventScreeningTestId);
					break;
				case "FileCollectionViaTestMedia":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.TestMediaEntityUsingCustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__", "TestMedia_", JoinHint.None);
					toReturn.Add(TestMediaEntity.Relations.FileEntityUsingFileId, "TestMedia_", string.Empty, JoinHint.None);
					break;
				case "IncidentalFindingsCollectionViaCustomerEventTestIncidentalFinding":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.CustomerEventTestIncidentalFindingEntityUsingCustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__", "CustomerEventTestIncidentalFinding_", JoinHint.None);
					toReturn.Add(CustomerEventTestIncidentalFindingEntity.Relations.IncidentalFindingsEntityUsingIncidentalFindingId, "CustomerEventTestIncidentalFinding_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerEventTestState":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.CustomerEventTestStateEntityUsingCustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__", "CustomerEventTestState_", JoinHint.None);
					toReturn.Add(CustomerEventTestStateEntity.Relations.LookupEntityUsingTestSummary, "CustomerEventTestState_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaTestPerformedExternally":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.TestPerformedExternallyEntityUsingCustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__", "TestPerformedExternally_", JoinHint.None);
					toReturn.Add(TestPerformedExternallyEntity.Relations.LookupEntityUsingResultEntryTypeId, "TestPerformedExternally_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerEventUnableScreenReason":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.CustomerEventUnableScreenReasonEntityUsingCustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__", "CustomerEventUnableScreenReason_", JoinHint.None);
					toReturn.Add(CustomerEventUnableScreenReasonEntity.Relations.OrganizationRoleUserEntityUsingUpdatedByOrgRoleUserId, "CustomerEventUnableScreenReason_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaTestNotPerformed":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.TestNotPerformedEntityUsingCustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__", "TestNotPerformed_", JoinHint.None);
					toReturn.Add(TestNotPerformedEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "TestNotPerformed_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaTestPerformedExternally_":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.TestPerformedExternallyEntityUsingCustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__", "TestPerformedExternally_", JoinHint.None);
					toReturn.Add(TestPerformedExternallyEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "TestPerformedExternally_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaTestPerformedExternally":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.TestPerformedExternallyEntityUsingCustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__", "TestPerformedExternally_", JoinHint.None);
					toReturn.Add(TestPerformedExternallyEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "TestPerformedExternally_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaTestNotPerformed_":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.TestNotPerformedEntityUsingCustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__", "TestNotPerformed_", JoinHint.None);
					toReturn.Add(TestNotPerformedEntity.Relations.OrganizationRoleUserEntityUsingUpdatedBy, "TestNotPerformed_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerEventTestState__":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.CustomerEventTestStateEntityUsingCustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__", "CustomerEventTestState_", JoinHint.None);
					toReturn.Add(CustomerEventTestStateEntity.Relations.OrganizationRoleUserEntityUsingUpdatedByOrgRoleUserId, "CustomerEventTestState_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerEventTestState":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.CustomerEventTestStateEntityUsingCustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__", "CustomerEventTestState_", JoinHint.None);
					toReturn.Add(CustomerEventTestStateEntity.Relations.OrganizationRoleUserEntityUsingConductedByOrgRoleUserId, "CustomerEventTestState_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerEventReading":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.CustomerEventReadingEntityUsingCustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__", "CustomerEventReading_", JoinHint.None);
					toReturn.Add(CustomerEventReadingEntity.Relations.OrganizationRoleUserEntityUsingUpdatedByOrgRoleUserId, "CustomerEventReading_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.CustomerEventTestPhysicianEvaluationEntityUsingCustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__", "CustomerEventTestPhysicianEvaluation_", JoinHint.None);
					toReturn.Add(CustomerEventTestPhysicianEvaluationEntity.Relations.OrganizationRoleUserEntityUsingUpdatedByOrgRoleUserId, "CustomerEventTestPhysicianEvaluation_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerEventTestState_":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.CustomerEventTestStateEntityUsingCustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__", "CustomerEventTestState_", JoinHint.None);
					toReturn.Add(CustomerEventTestStateEntity.Relations.OrganizationRoleUserEntityUsingEvaluatedByOrgRoleUserId, "CustomerEventTestState_", string.Empty, JoinHint.None);
					break;
				case "StandardFindingTestReadingCollectionViaCustomerEventReading":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.CustomerEventReadingEntityUsingCustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__", "CustomerEventReading_", JoinHint.None);
					toReturn.Add(CustomerEventReadingEntity.Relations.StandardFindingTestReadingEntityUsingStandardFindingTestReadingId, "CustomerEventReading_", string.Empty, JoinHint.None);
					break;
				case "StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.CustomerEventTestStandardFindingEntityUsingCustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__", "CustomerEventTestStandardFinding_", JoinHint.None);
					toReturn.Add(CustomerEventTestStandardFindingEntity.Relations.StandardFindingTestReadingEntityUsingStandardFindingTestReadingId, "CustomerEventTestStandardFinding_", string.Empty, JoinHint.None);
					break;
				case "TestNotPerformedReasonCollectionViaTestNotPerformed":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.TestNotPerformedEntityUsingCustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__", "TestNotPerformed_", JoinHint.None);
					toReturn.Add(TestNotPerformedEntity.Relations.TestNotPerformedReasonEntityUsingTestNotPerformedReasonId, "TestNotPerformed_", string.Empty, JoinHint.None);
					break;
				case "TestReadingCollectionViaCustomerEventReading":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.CustomerEventReadingEntityUsingCustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__", "CustomerEventReading_", JoinHint.None);
					toReturn.Add(CustomerEventReadingEntity.Relations.TestReadingEntityUsingTestReadingId, "CustomerEventReading_", string.Empty, JoinHint.None);
					break;
				case "TestUnableScreenReasonCollectionViaCustomerEventUnableScreenReason":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.CustomerEventUnableScreenReasonEntityUsingCustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__", "CustomerEventUnableScreenReason_", JoinHint.None);
					toReturn.Add(CustomerEventUnableScreenReasonEntity.Relations.TestUnableScreenReasonEntityUsingTestUnableScreenReasonId, "CustomerEventUnableScreenReason_", string.Empty, JoinHint.None);
					break;
				case "CustomerEventCriticalTestData":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.CustomerEventCriticalTestDataEntityUsingCustomerEventScreeningTestId);
					break;
				case "CustomerEventPriorityInQueueData":
					toReturn.Add(CustomerEventScreeningTestsEntity.Relations.CustomerEventPriorityInQueueDataEntityUsingCustomerEventScreeningTestId);
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
				case "EventCustomerResult":
					SetupSyncEventCustomerResult(relatedEntity);
					break;
				case "Test":
					SetupSyncTest(relatedEntity);
					break;
				case "CustomerEventReading":
					this.CustomerEventReading.Add((CustomerEventReadingEntity)relatedEntity);
					break;
				case "CustomerEventTestIncidentalFinding":
					this.CustomerEventTestIncidentalFinding.Add((CustomerEventTestIncidentalFindingEntity)relatedEntity);
					break;
				case "CustomerEventTestPhysicianEvaluation":
					this.CustomerEventTestPhysicianEvaluation.Add((CustomerEventTestPhysicianEvaluationEntity)relatedEntity);
					break;
				case "CustomerEventTestStandardFinding":
					this.CustomerEventTestStandardFinding.Add((CustomerEventTestStandardFindingEntity)relatedEntity);
					break;
				case "CustomerEventTestState":
					this.CustomerEventTestState.Add((CustomerEventTestStateEntity)relatedEntity);
					break;
				case "CustomerEventUnableScreenReason":
					this.CustomerEventUnableScreenReason.Add((CustomerEventUnableScreenReasonEntity)relatedEntity);
					break;
				case "TestMedia":
					this.TestMedia.Add((TestMediaEntity)relatedEntity);
					break;
				case "TestNotPerformed":
					this.TestNotPerformed.Add((TestNotPerformedEntity)relatedEntity);
					break;
				case "TestPerformedExternally":
					this.TestPerformedExternally.Add((TestPerformedExternallyEntity)relatedEntity);
					break;
				case "CustomerEventCriticalTestData":
					SetupSyncCustomerEventCriticalTestData(relatedEntity);
					break;
				case "CustomerEventPriorityInQueueData":
					SetupSyncCustomerEventPriorityInQueueData(relatedEntity);
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
				case "EventCustomerResult":
					DesetupSyncEventCustomerResult(false, true);
					break;
				case "Test":
					DesetupSyncTest(false, true);
					break;
				case "CustomerEventReading":
					base.PerformRelatedEntityRemoval(this.CustomerEventReading, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerEventTestIncidentalFinding":
					base.PerformRelatedEntityRemoval(this.CustomerEventTestIncidentalFinding, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerEventTestPhysicianEvaluation":
					base.PerformRelatedEntityRemoval(this.CustomerEventTestPhysicianEvaluation, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerEventTestStandardFinding":
					base.PerformRelatedEntityRemoval(this.CustomerEventTestStandardFinding, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerEventTestState":
					base.PerformRelatedEntityRemoval(this.CustomerEventTestState, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerEventUnableScreenReason":
					base.PerformRelatedEntityRemoval(this.CustomerEventUnableScreenReason, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "TestMedia":
					base.PerformRelatedEntityRemoval(this.TestMedia, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "TestNotPerformed":
					base.PerformRelatedEntityRemoval(this.TestNotPerformed, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "TestPerformedExternally":
					base.PerformRelatedEntityRemoval(this.TestPerformedExternally, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerEventCriticalTestData":
					DesetupSyncCustomerEventCriticalTestData(false, true);
					break;
				case "CustomerEventPriorityInQueueData":
					DesetupSyncCustomerEventPriorityInQueueData(false, true);
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
			if(_customerEventCriticalTestData!=null)
			{
				toReturn.Add(_customerEventCriticalTestData);
			}

			if(_customerEventPriorityInQueueData!=null)
			{
				toReturn.Add(_customerEventPriorityInQueueData);
			}

			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			if(_eventCustomerResult!=null)
			{
				toReturn.Add(_eventCustomerResult);
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
			toReturn.Add(this.CustomerEventReading);
			toReturn.Add(this.CustomerEventTestIncidentalFinding);
			toReturn.Add(this.CustomerEventTestPhysicianEvaluation);
			toReturn.Add(this.CustomerEventTestStandardFinding);
			toReturn.Add(this.CustomerEventTestState);
			toReturn.Add(this.CustomerEventUnableScreenReason);
			toReturn.Add(this.TestMedia);
			toReturn.Add(this.TestNotPerformed);
			toReturn.Add(this.TestPerformedExternally);

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
				info.AddValue("_customerEventReading", ((_customerEventReading!=null) && (_customerEventReading.Count>0) && !this.MarkedForDeletion)?_customerEventReading:null);
				info.AddValue("_customerEventTestIncidentalFinding", ((_customerEventTestIncidentalFinding!=null) && (_customerEventTestIncidentalFinding.Count>0) && !this.MarkedForDeletion)?_customerEventTestIncidentalFinding:null);
				info.AddValue("_customerEventTestPhysicianEvaluation", ((_customerEventTestPhysicianEvaluation!=null) && (_customerEventTestPhysicianEvaluation.Count>0) && !this.MarkedForDeletion)?_customerEventTestPhysicianEvaluation:null);
				info.AddValue("_customerEventTestStandardFinding", ((_customerEventTestStandardFinding!=null) && (_customerEventTestStandardFinding.Count>0) && !this.MarkedForDeletion)?_customerEventTestStandardFinding:null);
				info.AddValue("_customerEventTestState", ((_customerEventTestState!=null) && (_customerEventTestState.Count>0) && !this.MarkedForDeletion)?_customerEventTestState:null);
				info.AddValue("_customerEventUnableScreenReason", ((_customerEventUnableScreenReason!=null) && (_customerEventUnableScreenReason.Count>0) && !this.MarkedForDeletion)?_customerEventUnableScreenReason:null);
				info.AddValue("_testMedia", ((_testMedia!=null) && (_testMedia.Count>0) && !this.MarkedForDeletion)?_testMedia:null);
				info.AddValue("_testNotPerformed", ((_testNotPerformed!=null) && (_testNotPerformed.Count>0) && !this.MarkedForDeletion)?_testNotPerformed:null);
				info.AddValue("_testPerformedExternally", ((_testPerformedExternally!=null) && (_testPerformedExternally.Count>0) && !this.MarkedForDeletion)?_testPerformedExternally:null);
				info.AddValue("_fileCollectionViaTestMedia", ((_fileCollectionViaTestMedia!=null) && (_fileCollectionViaTestMedia.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaTestMedia:null);
				info.AddValue("_incidentalFindingsCollectionViaCustomerEventTestIncidentalFinding", ((_incidentalFindingsCollectionViaCustomerEventTestIncidentalFinding!=null) && (_incidentalFindingsCollectionViaCustomerEventTestIncidentalFinding.Count>0) && !this.MarkedForDeletion)?_incidentalFindingsCollectionViaCustomerEventTestIncidentalFinding:null);
				info.AddValue("_lookupCollectionViaCustomerEventTestState", ((_lookupCollectionViaCustomerEventTestState!=null) && (_lookupCollectionViaCustomerEventTestState.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerEventTestState:null);
				info.AddValue("_lookupCollectionViaTestPerformedExternally", ((_lookupCollectionViaTestPerformedExternally!=null) && (_lookupCollectionViaTestPerformedExternally.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaTestPerformedExternally:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerEventUnableScreenReason", ((_organizationRoleUserCollectionViaCustomerEventUnableScreenReason!=null) && (_organizationRoleUserCollectionViaCustomerEventUnableScreenReason.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerEventUnableScreenReason:null);
				info.AddValue("_organizationRoleUserCollectionViaTestNotPerformed", ((_organizationRoleUserCollectionViaTestNotPerformed!=null) && (_organizationRoleUserCollectionViaTestNotPerformed.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaTestNotPerformed:null);
				info.AddValue("_organizationRoleUserCollectionViaTestPerformedExternally_", ((_organizationRoleUserCollectionViaTestPerformedExternally_!=null) && (_organizationRoleUserCollectionViaTestPerformedExternally_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaTestPerformedExternally_:null);
				info.AddValue("_organizationRoleUserCollectionViaTestPerformedExternally", ((_organizationRoleUserCollectionViaTestPerformedExternally!=null) && (_organizationRoleUserCollectionViaTestPerformedExternally.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaTestPerformedExternally:null);
				info.AddValue("_organizationRoleUserCollectionViaTestNotPerformed_", ((_organizationRoleUserCollectionViaTestNotPerformed_!=null) && (_organizationRoleUserCollectionViaTestNotPerformed_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaTestNotPerformed_:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerEventTestState__", ((_organizationRoleUserCollectionViaCustomerEventTestState__!=null) && (_organizationRoleUserCollectionViaCustomerEventTestState__.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerEventTestState__:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerEventTestState", ((_organizationRoleUserCollectionViaCustomerEventTestState!=null) && (_organizationRoleUserCollectionViaCustomerEventTestState.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerEventTestState:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerEventReading", ((_organizationRoleUserCollectionViaCustomerEventReading!=null) && (_organizationRoleUserCollectionViaCustomerEventReading.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerEventReading:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation", ((_organizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation!=null) && (_organizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerEventTestState_", ((_organizationRoleUserCollectionViaCustomerEventTestState_!=null) && (_organizationRoleUserCollectionViaCustomerEventTestState_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerEventTestState_:null);
				info.AddValue("_standardFindingTestReadingCollectionViaCustomerEventReading", ((_standardFindingTestReadingCollectionViaCustomerEventReading!=null) && (_standardFindingTestReadingCollectionViaCustomerEventReading.Count>0) && !this.MarkedForDeletion)?_standardFindingTestReadingCollectionViaCustomerEventReading:null);
				info.AddValue("_standardFindingTestReadingCollectionViaCustomerEventTestStandardFinding", ((_standardFindingTestReadingCollectionViaCustomerEventTestStandardFinding!=null) && (_standardFindingTestReadingCollectionViaCustomerEventTestStandardFinding.Count>0) && !this.MarkedForDeletion)?_standardFindingTestReadingCollectionViaCustomerEventTestStandardFinding:null);
				info.AddValue("_testNotPerformedReasonCollectionViaTestNotPerformed", ((_testNotPerformedReasonCollectionViaTestNotPerformed!=null) && (_testNotPerformedReasonCollectionViaTestNotPerformed.Count>0) && !this.MarkedForDeletion)?_testNotPerformedReasonCollectionViaTestNotPerformed:null);
				info.AddValue("_testReadingCollectionViaCustomerEventReading", ((_testReadingCollectionViaCustomerEventReading!=null) && (_testReadingCollectionViaCustomerEventReading.Count>0) && !this.MarkedForDeletion)?_testReadingCollectionViaCustomerEventReading:null);
				info.AddValue("_testUnableScreenReasonCollectionViaCustomerEventUnableScreenReason", ((_testUnableScreenReasonCollectionViaCustomerEventUnableScreenReason!=null) && (_testUnableScreenReasonCollectionViaCustomerEventUnableScreenReason.Count>0) && !this.MarkedForDeletion)?_testUnableScreenReasonCollectionViaCustomerEventUnableScreenReason:null);
				info.AddValue("_eventCustomerResult", (!this.MarkedForDeletion?_eventCustomerResult:null));
				info.AddValue("_test", (!this.MarkedForDeletion?_test:null));
				info.AddValue("_customerEventCriticalTestData", (!this.MarkedForDeletion?_customerEventCriticalTestData:null));
				info.AddValue("_customerEventPriorityInQueueData", (!this.MarkedForDeletion?_customerEventPriorityInQueueData:null));
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(CustomerEventScreeningTestsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CustomerEventScreeningTestsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CustomerEventScreeningTestsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerEventReading' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventReading()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventReadingFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerEventTestIncidentalFinding' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventTestIncidentalFinding()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventTestIncidentalFindingFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerEventTestPhysicianEvaluation' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventTestPhysicianEvaluation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventTestPhysicianEvaluationFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerEventTestStandardFinding' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventTestStandardFinding()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventTestStandardFindingFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerEventTestState' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventTestState()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventTestStateFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerEventUnableScreenReason' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventUnableScreenReason()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventUnableScreenReasonFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TestMedia' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestMedia()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestMediaFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TestNotPerformed' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestNotPerformed()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestNotPerformedFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TestPerformedExternally' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestPerformedExternally()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestPerformedExternallyFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaTestMedia()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaTestMedia"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'IncidentalFindings' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoIncidentalFindingsCollectionViaCustomerEventTestIncidentalFinding()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("IncidentalFindingsCollectionViaCustomerEventTestIncidentalFinding"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerEventTestState()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerEventTestState"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaTestPerformedExternally()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaTestPerformedExternally"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerEventUnableScreenReason()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerEventUnableScreenReason"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaTestNotPerformed()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaTestNotPerformed"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaTestPerformedExternally_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaTestPerformedExternally_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaTestPerformedExternally()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaTestPerformedExternally"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaTestNotPerformed_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaTestNotPerformed_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerEventTestState__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerEventTestState__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerEventTestState()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerEventTestState"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerEventReading()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerEventReading"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerEventTestState_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerEventTestState_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'StandardFindingTestReading' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoStandardFindingTestReadingCollectionViaCustomerEventReading()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("StandardFindingTestReadingCollectionViaCustomerEventReading"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'StandardFindingTestReading' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoStandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TestNotPerformedReason' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestNotPerformedReasonCollectionViaTestNotPerformed()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestNotPerformedReasonCollectionViaTestNotPerformed"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TestReading' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestReadingCollectionViaCustomerEventReading()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestReadingCollectionViaCustomerEventReading"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TestUnableScreenReason' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestUnableScreenReasonCollectionViaCustomerEventUnableScreenReason()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestUnableScreenReasonCollectionViaCustomerEventUnableScreenReason"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId, "CustomerEventScreeningTestsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'EventCustomerResult' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerResult()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerResultFields.EventCustomerResultId, null, ComparisonOperator.Equal, this.EventCustomerResultId));
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

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerEventCriticalTestData' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventCriticalTestData()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventCriticalTestDataFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerEventPriorityInQueueData' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventPriorityInQueueData()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventPriorityInQueueDataFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId));
			return bucket;
		}
	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CustomerEventScreeningTestsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventScreeningTestsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._customerEventReading);
			collectionsQueue.Enqueue(this._customerEventTestIncidentalFinding);
			collectionsQueue.Enqueue(this._customerEventTestPhysicianEvaluation);
			collectionsQueue.Enqueue(this._customerEventTestStandardFinding);
			collectionsQueue.Enqueue(this._customerEventTestState);
			collectionsQueue.Enqueue(this._customerEventUnableScreenReason);
			collectionsQueue.Enqueue(this._testMedia);
			collectionsQueue.Enqueue(this._testNotPerformed);
			collectionsQueue.Enqueue(this._testPerformedExternally);
			collectionsQueue.Enqueue(this._fileCollectionViaTestMedia);
			collectionsQueue.Enqueue(this._incidentalFindingsCollectionViaCustomerEventTestIncidentalFinding);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerEventTestState);
			collectionsQueue.Enqueue(this._lookupCollectionViaTestPerformedExternally);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerEventUnableScreenReason);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaTestNotPerformed);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaTestPerformedExternally_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaTestPerformedExternally);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaTestNotPerformed_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerEventTestState__);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerEventTestState);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerEventReading);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerEventTestState_);
			collectionsQueue.Enqueue(this._standardFindingTestReadingCollectionViaCustomerEventReading);
			collectionsQueue.Enqueue(this._standardFindingTestReadingCollectionViaCustomerEventTestStandardFinding);
			collectionsQueue.Enqueue(this._testNotPerformedReasonCollectionViaTestNotPerformed);
			collectionsQueue.Enqueue(this._testReadingCollectionViaCustomerEventReading);
			collectionsQueue.Enqueue(this._testUnableScreenReasonCollectionViaCustomerEventUnableScreenReason);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._customerEventReading = (EntityCollection<CustomerEventReadingEntity>) collectionsQueue.Dequeue();
			this._customerEventTestIncidentalFinding = (EntityCollection<CustomerEventTestIncidentalFindingEntity>) collectionsQueue.Dequeue();
			this._customerEventTestPhysicianEvaluation = (EntityCollection<CustomerEventTestPhysicianEvaluationEntity>) collectionsQueue.Dequeue();
			this._customerEventTestStandardFinding = (EntityCollection<CustomerEventTestStandardFindingEntity>) collectionsQueue.Dequeue();
			this._customerEventTestState = (EntityCollection<CustomerEventTestStateEntity>) collectionsQueue.Dequeue();
			this._customerEventUnableScreenReason = (EntityCollection<CustomerEventUnableScreenReasonEntity>) collectionsQueue.Dequeue();
			this._testMedia = (EntityCollection<TestMediaEntity>) collectionsQueue.Dequeue();
			this._testNotPerformed = (EntityCollection<TestNotPerformedEntity>) collectionsQueue.Dequeue();
			this._testPerformedExternally = (EntityCollection<TestPerformedExternallyEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaTestMedia = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._incidentalFindingsCollectionViaCustomerEventTestIncidentalFinding = (EntityCollection<IncidentalFindingsEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerEventTestState = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaTestPerformedExternally = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerEventUnableScreenReason = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaTestNotPerformed = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaTestPerformedExternally_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaTestPerformedExternally = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaTestNotPerformed_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerEventTestState__ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerEventTestState = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerEventReading = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerEventTestState_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._standardFindingTestReadingCollectionViaCustomerEventReading = (EntityCollection<StandardFindingTestReadingEntity>) collectionsQueue.Dequeue();
			this._standardFindingTestReadingCollectionViaCustomerEventTestStandardFinding = (EntityCollection<StandardFindingTestReadingEntity>) collectionsQueue.Dequeue();
			this._testNotPerformedReasonCollectionViaTestNotPerformed = (EntityCollection<TestNotPerformedReasonEntity>) collectionsQueue.Dequeue();
			this._testReadingCollectionViaCustomerEventReading = (EntityCollection<TestReadingEntity>) collectionsQueue.Dequeue();
			this._testUnableScreenReasonCollectionViaCustomerEventUnableScreenReason = (EntityCollection<TestUnableScreenReasonEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._customerEventReading != null)
			{
				return true;
			}
			if (this._customerEventTestIncidentalFinding != null)
			{
				return true;
			}
			if (this._customerEventTestPhysicianEvaluation != null)
			{
				return true;
			}
			if (this._customerEventTestStandardFinding != null)
			{
				return true;
			}
			if (this._customerEventTestState != null)
			{
				return true;
			}
			if (this._customerEventUnableScreenReason != null)
			{
				return true;
			}
			if (this._testMedia != null)
			{
				return true;
			}
			if (this._testNotPerformed != null)
			{
				return true;
			}
			if (this._testPerformedExternally != null)
			{
				return true;
			}
			if (this._fileCollectionViaTestMedia != null)
			{
				return true;
			}
			if (this._incidentalFindingsCollectionViaCustomerEventTestIncidentalFinding != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerEventTestState != null)
			{
				return true;
			}
			if (this._lookupCollectionViaTestPerformedExternally != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerEventUnableScreenReason != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaTestNotPerformed != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaTestPerformedExternally_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaTestPerformedExternally != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaTestNotPerformed_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerEventTestState__ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerEventTestState != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerEventReading != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerEventTestState_ != null)
			{
				return true;
			}
			if (this._standardFindingTestReadingCollectionViaCustomerEventReading != null)
			{
				return true;
			}
			if (this._standardFindingTestReadingCollectionViaCustomerEventTestStandardFinding != null)
			{
				return true;
			}
			if (this._testNotPerformedReasonCollectionViaTestNotPerformed != null)
			{
				return true;
			}
			if (this._testReadingCollectionViaCustomerEventReading != null)
			{
				return true;
			}
			if (this._testUnableScreenReasonCollectionViaCustomerEventUnableScreenReason != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerEventReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventReadingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerEventTestIncidentalFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestIncidentalFindingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerEventTestPhysicianEvaluationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestPhysicianEvaluationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerEventTestStandardFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestStandardFindingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerEventTestStateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestStateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerEventUnableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventUnableScreenReasonEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestMediaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestMediaEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestNotPerformedEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestNotPerformedEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestPerformedExternallyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestPerformedExternallyEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<IncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingsEntityFactory))) : null);
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<StandardFindingTestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StandardFindingTestReadingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<StandardFindingTestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StandardFindingTestReadingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestNotPerformedReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestNotPerformedReasonEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestReadingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestUnableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestUnableScreenReasonEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("EventCustomerResult", _eventCustomerResult);
			toReturn.Add("Test", _test);
			toReturn.Add("CustomerEventReading", _customerEventReading);
			toReturn.Add("CustomerEventTestIncidentalFinding", _customerEventTestIncidentalFinding);
			toReturn.Add("CustomerEventTestPhysicianEvaluation", _customerEventTestPhysicianEvaluation);
			toReturn.Add("CustomerEventTestStandardFinding", _customerEventTestStandardFinding);
			toReturn.Add("CustomerEventTestState", _customerEventTestState);
			toReturn.Add("CustomerEventUnableScreenReason", _customerEventUnableScreenReason);
			toReturn.Add("TestMedia", _testMedia);
			toReturn.Add("TestNotPerformed", _testNotPerformed);
			toReturn.Add("TestPerformedExternally", _testPerformedExternally);
			toReturn.Add("FileCollectionViaTestMedia", _fileCollectionViaTestMedia);
			toReturn.Add("IncidentalFindingsCollectionViaCustomerEventTestIncidentalFinding", _incidentalFindingsCollectionViaCustomerEventTestIncidentalFinding);
			toReturn.Add("LookupCollectionViaCustomerEventTestState", _lookupCollectionViaCustomerEventTestState);
			toReturn.Add("LookupCollectionViaTestPerformedExternally", _lookupCollectionViaTestPerformedExternally);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerEventUnableScreenReason", _organizationRoleUserCollectionViaCustomerEventUnableScreenReason);
			toReturn.Add("OrganizationRoleUserCollectionViaTestNotPerformed", _organizationRoleUserCollectionViaTestNotPerformed);
			toReturn.Add("OrganizationRoleUserCollectionViaTestPerformedExternally_", _organizationRoleUserCollectionViaTestPerformedExternally_);
			toReturn.Add("OrganizationRoleUserCollectionViaTestPerformedExternally", _organizationRoleUserCollectionViaTestPerformedExternally);
			toReturn.Add("OrganizationRoleUserCollectionViaTestNotPerformed_", _organizationRoleUserCollectionViaTestNotPerformed_);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerEventTestState__", _organizationRoleUserCollectionViaCustomerEventTestState__);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerEventTestState", _organizationRoleUserCollectionViaCustomerEventTestState);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerEventReading", _organizationRoleUserCollectionViaCustomerEventReading);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation", _organizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerEventTestState_", _organizationRoleUserCollectionViaCustomerEventTestState_);
			toReturn.Add("StandardFindingTestReadingCollectionViaCustomerEventReading", _standardFindingTestReadingCollectionViaCustomerEventReading);
			toReturn.Add("StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding", _standardFindingTestReadingCollectionViaCustomerEventTestStandardFinding);
			toReturn.Add("TestNotPerformedReasonCollectionViaTestNotPerformed", _testNotPerformedReasonCollectionViaTestNotPerformed);
			toReturn.Add("TestReadingCollectionViaCustomerEventReading", _testReadingCollectionViaCustomerEventReading);
			toReturn.Add("TestUnableScreenReasonCollectionViaCustomerEventUnableScreenReason", _testUnableScreenReasonCollectionViaCustomerEventUnableScreenReason);
			toReturn.Add("CustomerEventCriticalTestData", _customerEventCriticalTestData);
			toReturn.Add("CustomerEventPriorityInQueueData", _customerEventPriorityInQueueData);
			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_customerEventReading!=null)
			{
				_customerEventReading.ActiveContext = base.ActiveContext;
			}
			if(_customerEventTestIncidentalFinding!=null)
			{
				_customerEventTestIncidentalFinding.ActiveContext = base.ActiveContext;
			}
			if(_customerEventTestPhysicianEvaluation!=null)
			{
				_customerEventTestPhysicianEvaluation.ActiveContext = base.ActiveContext;
			}
			if(_customerEventTestStandardFinding!=null)
			{
				_customerEventTestStandardFinding.ActiveContext = base.ActiveContext;
			}
			if(_customerEventTestState!=null)
			{
				_customerEventTestState.ActiveContext = base.ActiveContext;
			}
			if(_customerEventUnableScreenReason!=null)
			{
				_customerEventUnableScreenReason.ActiveContext = base.ActiveContext;
			}
			if(_testMedia!=null)
			{
				_testMedia.ActiveContext = base.ActiveContext;
			}
			if(_testNotPerformed!=null)
			{
				_testNotPerformed.ActiveContext = base.ActiveContext;
			}
			if(_testPerformedExternally!=null)
			{
				_testPerformedExternally.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaTestMedia!=null)
			{
				_fileCollectionViaTestMedia.ActiveContext = base.ActiveContext;
			}
			if(_incidentalFindingsCollectionViaCustomerEventTestIncidentalFinding!=null)
			{
				_incidentalFindingsCollectionViaCustomerEventTestIncidentalFinding.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerEventTestState!=null)
			{
				_lookupCollectionViaCustomerEventTestState.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaTestPerformedExternally!=null)
			{
				_lookupCollectionViaTestPerformedExternally.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerEventUnableScreenReason!=null)
			{
				_organizationRoleUserCollectionViaCustomerEventUnableScreenReason.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaTestNotPerformed!=null)
			{
				_organizationRoleUserCollectionViaTestNotPerformed.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaTestPerformedExternally_!=null)
			{
				_organizationRoleUserCollectionViaTestPerformedExternally_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaTestPerformedExternally!=null)
			{
				_organizationRoleUserCollectionViaTestPerformedExternally.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaTestNotPerformed_!=null)
			{
				_organizationRoleUserCollectionViaTestNotPerformed_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerEventTestState__!=null)
			{
				_organizationRoleUserCollectionViaCustomerEventTestState__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerEventTestState!=null)
			{
				_organizationRoleUserCollectionViaCustomerEventTestState.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerEventReading!=null)
			{
				_organizationRoleUserCollectionViaCustomerEventReading.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation!=null)
			{
				_organizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerEventTestState_!=null)
			{
				_organizationRoleUserCollectionViaCustomerEventTestState_.ActiveContext = base.ActiveContext;
			}
			if(_standardFindingTestReadingCollectionViaCustomerEventReading!=null)
			{
				_standardFindingTestReadingCollectionViaCustomerEventReading.ActiveContext = base.ActiveContext;
			}
			if(_standardFindingTestReadingCollectionViaCustomerEventTestStandardFinding!=null)
			{
				_standardFindingTestReadingCollectionViaCustomerEventTestStandardFinding.ActiveContext = base.ActiveContext;
			}
			if(_testNotPerformedReasonCollectionViaTestNotPerformed!=null)
			{
				_testNotPerformedReasonCollectionViaTestNotPerformed.ActiveContext = base.ActiveContext;
			}
			if(_testReadingCollectionViaCustomerEventReading!=null)
			{
				_testReadingCollectionViaCustomerEventReading.ActiveContext = base.ActiveContext;
			}
			if(_testUnableScreenReasonCollectionViaCustomerEventUnableScreenReason!=null)
			{
				_testUnableScreenReasonCollectionViaCustomerEventUnableScreenReason.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerResult!=null)
			{
				_eventCustomerResult.ActiveContext = base.ActiveContext;
			}
			if(_test!=null)
			{
				_test.ActiveContext = base.ActiveContext;
			}
			if(_customerEventCriticalTestData!=null)
			{
				_customerEventCriticalTestData.ActiveContext = base.ActiveContext;
			}
			if(_customerEventPriorityInQueueData!=null)
			{
				_customerEventPriorityInQueueData.ActiveContext = base.ActiveContext;
			}
		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_customerEventReading = null;
			_customerEventTestIncidentalFinding = null;
			_customerEventTestPhysicianEvaluation = null;
			_customerEventTestStandardFinding = null;
			_customerEventTestState = null;
			_customerEventUnableScreenReason = null;
			_testMedia = null;
			_testNotPerformed = null;
			_testPerformedExternally = null;
			_fileCollectionViaTestMedia = null;
			_incidentalFindingsCollectionViaCustomerEventTestIncidentalFinding = null;
			_lookupCollectionViaCustomerEventTestState = null;
			_lookupCollectionViaTestPerformedExternally = null;
			_organizationRoleUserCollectionViaCustomerEventUnableScreenReason = null;
			_organizationRoleUserCollectionViaTestNotPerformed = null;
			_organizationRoleUserCollectionViaTestPerformedExternally_ = null;
			_organizationRoleUserCollectionViaTestPerformedExternally = null;
			_organizationRoleUserCollectionViaTestNotPerformed_ = null;
			_organizationRoleUserCollectionViaCustomerEventTestState__ = null;
			_organizationRoleUserCollectionViaCustomerEventTestState = null;
			_organizationRoleUserCollectionViaCustomerEventReading = null;
			_organizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation = null;
			_organizationRoleUserCollectionViaCustomerEventTestState_ = null;
			_standardFindingTestReadingCollectionViaCustomerEventReading = null;
			_standardFindingTestReadingCollectionViaCustomerEventTestStandardFinding = null;
			_testNotPerformedReasonCollectionViaTestNotPerformed = null;
			_testReadingCollectionViaCustomerEventReading = null;
			_testUnableScreenReasonCollectionViaCustomerEventUnableScreenReason = null;
			_eventCustomerResult = null;
			_test = null;
			_customerEventCriticalTestData = null;
			_customerEventPriorityInQueueData = null;
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

			_fieldsCustomProperties.Add("CustomerEventScreeningTestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventCustomerResultId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _eventCustomerResult</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEventCustomerResult(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _eventCustomerResult, new PropertyChangedEventHandler( OnEventCustomerResultPropertyChanged ), "EventCustomerResult", CustomerEventScreeningTestsEntity.Relations.EventCustomerResultEntityUsingEventCustomerResultId, true, signalRelatedEntity, "CustomerEventScreeningTests", resetFKFields, new int[] { (int)CustomerEventScreeningTestsFieldIndex.EventCustomerResultId } );		
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
				base.PerformSetupSyncRelatedEntity( _eventCustomerResult, new PropertyChangedEventHandler( OnEventCustomerResultPropertyChanged ), "EventCustomerResult", CustomerEventScreeningTestsEntity.Relations.EventCustomerResultEntityUsingEventCustomerResultId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _test</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTest(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _test, new PropertyChangedEventHandler( OnTestPropertyChanged ), "Test", CustomerEventScreeningTestsEntity.Relations.TestEntityUsingTestId, true, signalRelatedEntity, "CustomerEventScreeningTests", resetFKFields, new int[] { (int)CustomerEventScreeningTestsFieldIndex.TestId } );		
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
				base.PerformSetupSyncRelatedEntity( _test, new PropertyChangedEventHandler( OnTestPropertyChanged ), "Test", CustomerEventScreeningTestsEntity.Relations.TestEntityUsingTestId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _customerEventCriticalTestData</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerEventCriticalTestData(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerEventCriticalTestData, new PropertyChangedEventHandler( OnCustomerEventCriticalTestDataPropertyChanged ), "CustomerEventCriticalTestData", CustomerEventScreeningTestsEntity.Relations.CustomerEventCriticalTestDataEntityUsingCustomerEventScreeningTestId, false, signalRelatedEntity, "CustomerEventScreeningTests", false, new int[] { (int)CustomerEventScreeningTestsFieldIndex.CustomerEventScreeningTestId } );
			_customerEventCriticalTestData = null;
		}
		
		/// <summary> setups the sync logic for member _customerEventCriticalTestData</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerEventCriticalTestData(IEntity2 relatedEntity)
		{
			if(_customerEventCriticalTestData!=relatedEntity)
			{
				DesetupSyncCustomerEventCriticalTestData(true, true);
				_customerEventCriticalTestData = (CustomerEventCriticalTestDataEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerEventCriticalTestData, new PropertyChangedEventHandler( OnCustomerEventCriticalTestDataPropertyChanged ), "CustomerEventCriticalTestData", CustomerEventScreeningTestsEntity.Relations.CustomerEventCriticalTestDataEntityUsingCustomerEventScreeningTestId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerEventCriticalTestDataPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _customerEventPriorityInQueueData</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerEventPriorityInQueueData(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerEventPriorityInQueueData, new PropertyChangedEventHandler( OnCustomerEventPriorityInQueueDataPropertyChanged ), "CustomerEventPriorityInQueueData", CustomerEventScreeningTestsEntity.Relations.CustomerEventPriorityInQueueDataEntityUsingCustomerEventScreeningTestId, false, signalRelatedEntity, "CustomerEventScreeningTests", false, new int[] { (int)CustomerEventScreeningTestsFieldIndex.CustomerEventScreeningTestId } );
			_customerEventPriorityInQueueData = null;
		}
		
		/// <summary> setups the sync logic for member _customerEventPriorityInQueueData</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerEventPriorityInQueueData(IEntity2 relatedEntity)
		{
			if(_customerEventPriorityInQueueData!=relatedEntity)
			{
				DesetupSyncCustomerEventPriorityInQueueData(true, true);
				_customerEventPriorityInQueueData = (CustomerEventPriorityInQueueDataEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerEventPriorityInQueueData, new PropertyChangedEventHandler( OnCustomerEventPriorityInQueueDataPropertyChanged ), "CustomerEventPriorityInQueueData", CustomerEventScreeningTestsEntity.Relations.CustomerEventPriorityInQueueDataEntityUsingCustomerEventScreeningTestId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerEventPriorityInQueueDataPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this CustomerEventScreeningTestsEntity</param>
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
		public  static CustomerEventScreeningTestsRelations Relations
		{
			get	{ return new CustomerEventScreeningTestsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventReading' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventReading
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerEventReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventReadingEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerEventReading")[0], (int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.CustomerEventReadingEntity, 0, null, null, null, null, "CustomerEventReading", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventTestIncidentalFinding' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventTestIncidentalFinding
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerEventTestIncidentalFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestIncidentalFindingEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerEventTestIncidentalFinding")[0], (int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.CustomerEventTestIncidentalFindingEntity, 0, null, null, null, null, "CustomerEventTestIncidentalFinding", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventTestPhysicianEvaluation' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventTestPhysicianEvaluation
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerEventTestPhysicianEvaluationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestPhysicianEvaluationEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerEventTestPhysicianEvaluation")[0], (int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.CustomerEventTestPhysicianEvaluationEntity, 0, null, null, null, null, "CustomerEventTestPhysicianEvaluation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventTestStandardFinding' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventTestStandardFinding
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerEventTestStandardFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestStandardFindingEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerEventTestStandardFinding")[0], (int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.CustomerEventTestStandardFindingEntity, 0, null, null, null, null, "CustomerEventTestStandardFinding", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventTestState' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventTestState
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerEventTestStateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestStateEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerEventTestState")[0], (int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.CustomerEventTestStateEntity, 0, null, null, null, null, "CustomerEventTestState", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventUnableScreenReason' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventUnableScreenReason
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerEventUnableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventUnableScreenReasonEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerEventUnableScreenReason")[0], (int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.CustomerEventUnableScreenReasonEntity, 0, null, null, null, null, "CustomerEventUnableScreenReason", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TestMedia' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestMedia
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TestMediaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestMediaEntityFactory))),
					(IEntityRelation)GetRelationsForField("TestMedia")[0], (int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.TestMediaEntity, 0, null, null, null, null, "TestMedia", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TestNotPerformed' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestNotPerformed
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TestNotPerformedEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestNotPerformedEntityFactory))),
					(IEntityRelation)GetRelationsForField("TestNotPerformed")[0], (int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.TestNotPerformedEntity, 0, null, null, null, null, "TestNotPerformed", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TestPerformedExternally' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestPerformedExternally
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TestPerformedExternallyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestPerformedExternallyEntityFactory))),
					(IEntityRelation)GetRelationsForField("TestPerformedExternally")[0], (int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.TestPerformedExternallyEntity, 0, null, null, null, null, "TestPerformedExternally", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaTestMedia
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerEventScreeningTestsEntity.Relations.TestMediaEntityUsingCustomerEventScreeningTestId;
				intermediateRelation.SetAliases(string.Empty, "TestMedia_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaTestMedia"), null, "FileCollectionViaTestMedia", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'IncidentalFindings' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathIncidentalFindingsCollectionViaCustomerEventTestIncidentalFinding
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerEventScreeningTestsEntity.Relations.CustomerEventTestIncidentalFindingEntityUsingCustomerEventScreeningTestId;
				intermediateRelation.SetAliases(string.Empty, "CustomerEventTestIncidentalFinding_");
				return new PrefetchPathElement2(new EntityCollection<IncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.IncidentalFindingsEntity, 0, null, null, GetRelationsForField("IncidentalFindingsCollectionViaCustomerEventTestIncidentalFinding"), null, "IncidentalFindingsCollectionViaCustomerEventTestIncidentalFinding", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerEventTestState
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerEventScreeningTestsEntity.Relations.CustomerEventTestStateEntityUsingCustomerEventScreeningTestId;
				intermediateRelation.SetAliases(string.Empty, "CustomerEventTestState_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerEventTestState"), null, "LookupCollectionViaCustomerEventTestState", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaTestPerformedExternally
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerEventScreeningTestsEntity.Relations.TestPerformedExternallyEntityUsingCustomerEventScreeningTestId;
				intermediateRelation.SetAliases(string.Empty, "TestPerformedExternally_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaTestPerformedExternally"), null, "LookupCollectionViaTestPerformedExternally", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerEventUnableScreenReason
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerEventScreeningTestsEntity.Relations.CustomerEventUnableScreenReasonEntityUsingCustomerEventScreeningTestId;
				intermediateRelation.SetAliases(string.Empty, "CustomerEventUnableScreenReason_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerEventUnableScreenReason"), null, "OrganizationRoleUserCollectionViaCustomerEventUnableScreenReason", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaTestNotPerformed
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerEventScreeningTestsEntity.Relations.TestNotPerformedEntityUsingCustomerEventScreeningTestId;
				intermediateRelation.SetAliases(string.Empty, "TestNotPerformed_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaTestNotPerformed"), null, "OrganizationRoleUserCollectionViaTestNotPerformed", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaTestPerformedExternally_
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerEventScreeningTestsEntity.Relations.TestPerformedExternallyEntityUsingCustomerEventScreeningTestId;
				intermediateRelation.SetAliases(string.Empty, "TestPerformedExternally_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaTestPerformedExternally_"), null, "OrganizationRoleUserCollectionViaTestPerformedExternally_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaTestPerformedExternally
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerEventScreeningTestsEntity.Relations.TestPerformedExternallyEntityUsingCustomerEventScreeningTestId;
				intermediateRelation.SetAliases(string.Empty, "TestPerformedExternally_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaTestPerformedExternally"), null, "OrganizationRoleUserCollectionViaTestPerformedExternally", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaTestNotPerformed_
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerEventScreeningTestsEntity.Relations.TestNotPerformedEntityUsingCustomerEventScreeningTestId;
				intermediateRelation.SetAliases(string.Empty, "TestNotPerformed_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaTestNotPerformed_"), null, "OrganizationRoleUserCollectionViaTestNotPerformed_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerEventTestState__
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerEventScreeningTestsEntity.Relations.CustomerEventTestStateEntityUsingCustomerEventScreeningTestId;
				intermediateRelation.SetAliases(string.Empty, "CustomerEventTestState_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerEventTestState__"), null, "OrganizationRoleUserCollectionViaCustomerEventTestState__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerEventTestState
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerEventScreeningTestsEntity.Relations.CustomerEventTestStateEntityUsingCustomerEventScreeningTestId;
				intermediateRelation.SetAliases(string.Empty, "CustomerEventTestState_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerEventTestState"), null, "OrganizationRoleUserCollectionViaCustomerEventTestState", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerEventReading
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerEventScreeningTestsEntity.Relations.CustomerEventReadingEntityUsingCustomerEventScreeningTestId;
				intermediateRelation.SetAliases(string.Empty, "CustomerEventReading_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerEventReading"), null, "OrganizationRoleUserCollectionViaCustomerEventReading", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerEventScreeningTestsEntity.Relations.CustomerEventTestPhysicianEvaluationEntityUsingCustomerEventScreeningTestId;
				intermediateRelation.SetAliases(string.Empty, "CustomerEventTestPhysicianEvaluation_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation"), null, "OrganizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerEventTestState_
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerEventScreeningTestsEntity.Relations.CustomerEventTestStateEntityUsingCustomerEventScreeningTestId;
				intermediateRelation.SetAliases(string.Empty, "CustomerEventTestState_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerEventTestState_"), null, "OrganizationRoleUserCollectionViaCustomerEventTestState_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'StandardFindingTestReading' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathStandardFindingTestReadingCollectionViaCustomerEventReading
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerEventScreeningTestsEntity.Relations.CustomerEventReadingEntityUsingCustomerEventScreeningTestId;
				intermediateRelation.SetAliases(string.Empty, "CustomerEventReading_");
				return new PrefetchPathElement2(new EntityCollection<StandardFindingTestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StandardFindingTestReadingEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.StandardFindingTestReadingEntity, 0, null, null, GetRelationsForField("StandardFindingTestReadingCollectionViaCustomerEventReading"), null, "StandardFindingTestReadingCollectionViaCustomerEventReading", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'StandardFindingTestReading' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathStandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerEventScreeningTestsEntity.Relations.CustomerEventTestStandardFindingEntityUsingCustomerEventScreeningTestId;
				intermediateRelation.SetAliases(string.Empty, "CustomerEventTestStandardFinding_");
				return new PrefetchPathElement2(new EntityCollection<StandardFindingTestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StandardFindingTestReadingEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.StandardFindingTestReadingEntity, 0, null, null, GetRelationsForField("StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding"), null, "StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TestNotPerformedReason' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestNotPerformedReasonCollectionViaTestNotPerformed
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerEventScreeningTestsEntity.Relations.TestNotPerformedEntityUsingCustomerEventScreeningTestId;
				intermediateRelation.SetAliases(string.Empty, "TestNotPerformed_");
				return new PrefetchPathElement2(new EntityCollection<TestNotPerformedReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestNotPerformedReasonEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.TestNotPerformedReasonEntity, 0, null, null, GetRelationsForField("TestNotPerformedReasonCollectionViaTestNotPerformed"), null, "TestNotPerformedReasonCollectionViaTestNotPerformed", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TestReading' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestReadingCollectionViaCustomerEventReading
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerEventScreeningTestsEntity.Relations.CustomerEventReadingEntityUsingCustomerEventScreeningTestId;
				intermediateRelation.SetAliases(string.Empty, "CustomerEventReading_");
				return new PrefetchPathElement2(new EntityCollection<TestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestReadingEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.TestReadingEntity, 0, null, null, GetRelationsForField("TestReadingCollectionViaCustomerEventReading"), null, "TestReadingCollectionViaCustomerEventReading", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TestUnableScreenReason' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestUnableScreenReasonCollectionViaCustomerEventUnableScreenReason
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerEventScreeningTestsEntity.Relations.CustomerEventUnableScreenReasonEntityUsingCustomerEventScreeningTestId;
				intermediateRelation.SetAliases(string.Empty, "CustomerEventUnableScreenReason_");
				return new PrefetchPathElement2(new EntityCollection<TestUnableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestUnableScreenReasonEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.TestUnableScreenReasonEntity, 0, null, null, GetRelationsForField("TestUnableScreenReasonCollectionViaCustomerEventUnableScreenReason"), null, "TestUnableScreenReasonCollectionViaCustomerEventUnableScreenReason", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("EventCustomerResult")[0], (int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.EventCustomerResultEntity, 0, null, null, null, null, "EventCustomerResult", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Test")[0], (int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, null, null, "Test", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventCriticalTestData' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventCriticalTestData
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventCriticalTestDataEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerEventCriticalTestData")[0], (int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.CustomerEventCriticalTestDataEntity, 0, null, null, null, null, "CustomerEventCriticalTestData", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventPriorityInQueueData' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventPriorityInQueueData
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventPriorityInQueueDataEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerEventPriorityInQueueData")[0], (int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, (int)Falcon.Data.EntityType.CustomerEventPriorityInQueueDataEntity, 0, null, null, null, null, "CustomerEventPriorityInQueueData", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CustomerEventScreeningTestsEntity.CustomProperties;}
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
			get { return CustomerEventScreeningTestsEntity.FieldsCustomProperties;}
		}

		/// <summary> The CustomerEventScreeningTestId property of the Entity CustomerEventScreeningTests<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerEventScreeningTests"."CustomerEventScreeningTestID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 CustomerEventScreeningTestId
		{
			get { return (System.Int64)GetValue((int)CustomerEventScreeningTestsFieldIndex.CustomerEventScreeningTestId, true); }
			set	{ SetValue((int)CustomerEventScreeningTestsFieldIndex.CustomerEventScreeningTestId, value); }
		}

		/// <summary> The TestId property of the Entity CustomerEventScreeningTests<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerEventScreeningTests"."TestId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TestId
		{
			get { return (System.Int64)GetValue((int)CustomerEventScreeningTestsFieldIndex.TestId, true); }
			set	{ SetValue((int)CustomerEventScreeningTestsFieldIndex.TestId, value); }
		}

		/// <summary> The EventCustomerResultId property of the Entity CustomerEventScreeningTests<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerEventScreeningTests"."EventCustomerResultId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventCustomerResultId
		{
			get { return (System.Int64)GetValue((int)CustomerEventScreeningTestsFieldIndex.EventCustomerResultId, true); }
			set	{ SetValue((int)CustomerEventScreeningTestsFieldIndex.EventCustomerResultId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerEventReadingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerEventReadingEntity))]
		public virtual EntityCollection<CustomerEventReadingEntity> CustomerEventReading
		{
			get
			{
				if(_customerEventReading==null)
				{
					_customerEventReading = new EntityCollection<CustomerEventReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventReadingEntityFactory)));
					_customerEventReading.SetContainingEntityInfo(this, "CustomerEventScreeningTests");
				}
				return _customerEventReading;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerEventTestIncidentalFindingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerEventTestIncidentalFindingEntity))]
		public virtual EntityCollection<CustomerEventTestIncidentalFindingEntity> CustomerEventTestIncidentalFinding
		{
			get
			{
				if(_customerEventTestIncidentalFinding==null)
				{
					_customerEventTestIncidentalFinding = new EntityCollection<CustomerEventTestIncidentalFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestIncidentalFindingEntityFactory)));
					_customerEventTestIncidentalFinding.SetContainingEntityInfo(this, "CustomerEventScreeningTests");
				}
				return _customerEventTestIncidentalFinding;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerEventTestPhysicianEvaluationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerEventTestPhysicianEvaluationEntity))]
		public virtual EntityCollection<CustomerEventTestPhysicianEvaluationEntity> CustomerEventTestPhysicianEvaluation
		{
			get
			{
				if(_customerEventTestPhysicianEvaluation==null)
				{
					_customerEventTestPhysicianEvaluation = new EntityCollection<CustomerEventTestPhysicianEvaluationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestPhysicianEvaluationEntityFactory)));
					_customerEventTestPhysicianEvaluation.SetContainingEntityInfo(this, "CustomerEventScreeningTests");
				}
				return _customerEventTestPhysicianEvaluation;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerEventTestStandardFindingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerEventTestStandardFindingEntity))]
		public virtual EntityCollection<CustomerEventTestStandardFindingEntity> CustomerEventTestStandardFinding
		{
			get
			{
				if(_customerEventTestStandardFinding==null)
				{
					_customerEventTestStandardFinding = new EntityCollection<CustomerEventTestStandardFindingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestStandardFindingEntityFactory)));
					_customerEventTestStandardFinding.SetContainingEntityInfo(this, "CustomerEventScreeningTests");
				}
				return _customerEventTestStandardFinding;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerEventTestStateEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerEventTestStateEntity))]
		public virtual EntityCollection<CustomerEventTestStateEntity> CustomerEventTestState
		{
			get
			{
				if(_customerEventTestState==null)
				{
					_customerEventTestState = new EntityCollection<CustomerEventTestStateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestStateEntityFactory)));
					_customerEventTestState.SetContainingEntityInfo(this, "CustomerEventScreeningTests");
				}
				return _customerEventTestState;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerEventUnableScreenReasonEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerEventUnableScreenReasonEntity))]
		public virtual EntityCollection<CustomerEventUnableScreenReasonEntity> CustomerEventUnableScreenReason
		{
			get
			{
				if(_customerEventUnableScreenReason==null)
				{
					_customerEventUnableScreenReason = new EntityCollection<CustomerEventUnableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventUnableScreenReasonEntityFactory)));
					_customerEventUnableScreenReason.SetContainingEntityInfo(this, "CustomerEventScreeningTests");
				}
				return _customerEventUnableScreenReason;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestMediaEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestMediaEntity))]
		public virtual EntityCollection<TestMediaEntity> TestMedia
		{
			get
			{
				if(_testMedia==null)
				{
					_testMedia = new EntityCollection<TestMediaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestMediaEntityFactory)));
					_testMedia.SetContainingEntityInfo(this, "CustomerEventScreeningTests");
				}
				return _testMedia;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestNotPerformedEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestNotPerformedEntity))]
		public virtual EntityCollection<TestNotPerformedEntity> TestNotPerformed
		{
			get
			{
				if(_testNotPerformed==null)
				{
					_testNotPerformed = new EntityCollection<TestNotPerformedEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestNotPerformedEntityFactory)));
					_testNotPerformed.SetContainingEntityInfo(this, "CustomerEventScreeningTests");
				}
				return _testNotPerformed;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestPerformedExternallyEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestPerformedExternallyEntity))]
		public virtual EntityCollection<TestPerformedExternallyEntity> TestPerformedExternally
		{
			get
			{
				if(_testPerformedExternally==null)
				{
					_testPerformedExternally = new EntityCollection<TestPerformedExternallyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestPerformedExternallyEntityFactory)));
					_testPerformedExternally.SetContainingEntityInfo(this, "CustomerEventScreeningTests");
				}
				return _testPerformedExternally;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaTestMedia
		{
			get
			{
				if(_fileCollectionViaTestMedia==null)
				{
					_fileCollectionViaTestMedia = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaTestMedia.IsReadOnly=true;
				}
				return _fileCollectionViaTestMedia;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'IncidentalFindingsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(IncidentalFindingsEntity))]
		public virtual EntityCollection<IncidentalFindingsEntity> IncidentalFindingsCollectionViaCustomerEventTestIncidentalFinding
		{
			get
			{
				if(_incidentalFindingsCollectionViaCustomerEventTestIncidentalFinding==null)
				{
					_incidentalFindingsCollectionViaCustomerEventTestIncidentalFinding = new EntityCollection<IncidentalFindingsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingsEntityFactory)));
					_incidentalFindingsCollectionViaCustomerEventTestIncidentalFinding.IsReadOnly=true;
				}
				return _incidentalFindingsCollectionViaCustomerEventTestIncidentalFinding;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerEventTestState
		{
			get
			{
				if(_lookupCollectionViaCustomerEventTestState==null)
				{
					_lookupCollectionViaCustomerEventTestState = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerEventTestState.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerEventTestState;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaTestPerformedExternally
		{
			get
			{
				if(_lookupCollectionViaTestPerformedExternally==null)
				{
					_lookupCollectionViaTestPerformedExternally = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaTestPerformedExternally.IsReadOnly=true;
				}
				return _lookupCollectionViaTestPerformedExternally;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerEventUnableScreenReason
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerEventUnableScreenReason==null)
				{
					_organizationRoleUserCollectionViaCustomerEventUnableScreenReason = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerEventUnableScreenReason.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerEventUnableScreenReason;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaTestNotPerformed
		{
			get
			{
				if(_organizationRoleUserCollectionViaTestNotPerformed==null)
				{
					_organizationRoleUserCollectionViaTestNotPerformed = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaTestNotPerformed.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaTestNotPerformed;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaTestPerformedExternally_
		{
			get
			{
				if(_organizationRoleUserCollectionViaTestPerformedExternally_==null)
				{
					_organizationRoleUserCollectionViaTestPerformedExternally_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaTestPerformedExternally_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaTestPerformedExternally_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaTestPerformedExternally
		{
			get
			{
				if(_organizationRoleUserCollectionViaTestPerformedExternally==null)
				{
					_organizationRoleUserCollectionViaTestPerformedExternally = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaTestPerformedExternally.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaTestPerformedExternally;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaTestNotPerformed_
		{
			get
			{
				if(_organizationRoleUserCollectionViaTestNotPerformed_==null)
				{
					_organizationRoleUserCollectionViaTestNotPerformed_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaTestNotPerformed_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaTestNotPerformed_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerEventTestState__
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerEventTestState__==null)
				{
					_organizationRoleUserCollectionViaCustomerEventTestState__ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerEventTestState__.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerEventTestState__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerEventTestState
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerEventTestState==null)
				{
					_organizationRoleUserCollectionViaCustomerEventTestState = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerEventTestState.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerEventTestState;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerEventReading
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerEventReading==null)
				{
					_organizationRoleUserCollectionViaCustomerEventReading = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerEventReading.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerEventReading;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation==null)
				{
					_organizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerEventTestPhysicianEvaluation;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerEventTestState_
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerEventTestState_==null)
				{
					_organizationRoleUserCollectionViaCustomerEventTestState_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerEventTestState_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerEventTestState_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'StandardFindingTestReadingEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(StandardFindingTestReadingEntity))]
		public virtual EntityCollection<StandardFindingTestReadingEntity> StandardFindingTestReadingCollectionViaCustomerEventReading
		{
			get
			{
				if(_standardFindingTestReadingCollectionViaCustomerEventReading==null)
				{
					_standardFindingTestReadingCollectionViaCustomerEventReading = new EntityCollection<StandardFindingTestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StandardFindingTestReadingEntityFactory)));
					_standardFindingTestReadingCollectionViaCustomerEventReading.IsReadOnly=true;
				}
				return _standardFindingTestReadingCollectionViaCustomerEventReading;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'StandardFindingTestReadingEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(StandardFindingTestReadingEntity))]
		public virtual EntityCollection<StandardFindingTestReadingEntity> StandardFindingTestReadingCollectionViaCustomerEventTestStandardFinding
		{
			get
			{
				if(_standardFindingTestReadingCollectionViaCustomerEventTestStandardFinding==null)
				{
					_standardFindingTestReadingCollectionViaCustomerEventTestStandardFinding = new EntityCollection<StandardFindingTestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StandardFindingTestReadingEntityFactory)));
					_standardFindingTestReadingCollectionViaCustomerEventTestStandardFinding.IsReadOnly=true;
				}
				return _standardFindingTestReadingCollectionViaCustomerEventTestStandardFinding;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestNotPerformedReasonEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestNotPerformedReasonEntity))]
		public virtual EntityCollection<TestNotPerformedReasonEntity> TestNotPerformedReasonCollectionViaTestNotPerformed
		{
			get
			{
				if(_testNotPerformedReasonCollectionViaTestNotPerformed==null)
				{
					_testNotPerformedReasonCollectionViaTestNotPerformed = new EntityCollection<TestNotPerformedReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestNotPerformedReasonEntityFactory)));
					_testNotPerformedReasonCollectionViaTestNotPerformed.IsReadOnly=true;
				}
				return _testNotPerformedReasonCollectionViaTestNotPerformed;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestReadingEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestReadingEntity))]
		public virtual EntityCollection<TestReadingEntity> TestReadingCollectionViaCustomerEventReading
		{
			get
			{
				if(_testReadingCollectionViaCustomerEventReading==null)
				{
					_testReadingCollectionViaCustomerEventReading = new EntityCollection<TestReadingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestReadingEntityFactory)));
					_testReadingCollectionViaCustomerEventReading.IsReadOnly=true;
				}
				return _testReadingCollectionViaCustomerEventReading;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestUnableScreenReasonEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestUnableScreenReasonEntity))]
		public virtual EntityCollection<TestUnableScreenReasonEntity> TestUnableScreenReasonCollectionViaCustomerEventUnableScreenReason
		{
			get
			{
				if(_testUnableScreenReasonCollectionViaCustomerEventUnableScreenReason==null)
				{
					_testUnableScreenReasonCollectionViaCustomerEventUnableScreenReason = new EntityCollection<TestUnableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestUnableScreenReasonEntityFactory)));
					_testUnableScreenReasonCollectionViaCustomerEventUnableScreenReason.IsReadOnly=true;
				}
				return _testUnableScreenReasonCollectionViaCustomerEventUnableScreenReason;
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
				}
				else
				{
					if(value==null)
					{
						if(_eventCustomerResult != null)
						{
							_eventCustomerResult.UnsetRelatedEntity(this, "CustomerEventScreeningTests");
						}
					}
					else
					{
						if(_eventCustomerResult!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerEventScreeningTests");
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
							_test.UnsetRelatedEntity(this, "CustomerEventScreeningTests");
						}
					}
					else
					{
						if(_test!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerEventScreeningTests");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CustomerEventCriticalTestDataEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerEventCriticalTestDataEntity CustomerEventCriticalTestData
		{
			get
			{
				return _customerEventCriticalTestData;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerEventCriticalTestData(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "CustomerEventScreeningTests");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_customerEventCriticalTestData !=null);
						DesetupSyncCustomerEventCriticalTestData(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("CustomerEventCriticalTestData");
						}
					}
					else
					{
						if(_customerEventCriticalTestData!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "CustomerEventScreeningTests");
							SetupSyncCustomerEventCriticalTestData(relatedEntity);
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CustomerEventPriorityInQueueDataEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerEventPriorityInQueueDataEntity CustomerEventPriorityInQueueData
		{
			get
			{
				return _customerEventPriorityInQueueData;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerEventPriorityInQueueData(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "CustomerEventScreeningTests");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_customerEventPriorityInQueueData !=null);
						DesetupSyncCustomerEventPriorityInQueueData(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("CustomerEventPriorityInQueueData");
						}
					}
					else
					{
						if(_customerEventPriorityInQueueData!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "CustomerEventScreeningTests");
							SetupSyncCustomerEventPriorityInQueueData(relatedEntity);
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
			get { return (int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity; }
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
