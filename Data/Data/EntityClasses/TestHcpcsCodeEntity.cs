///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:50
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
	/// Entity class which represents the entity 'TestHcpcsCode'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class TestHcpcsCodeEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AccountTestHcpcsCodeEntity> _accountTestHcpcsCode;
		private EntityCollection<EventAccountTestHcpcsCodeEntity> _eventAccountTestHcpcsCode;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventAccountTestHcpcsCode;
		private EntityCollection<OrganizationEntity> _organizationCollectionViaAccountTestHcpcsCode;
		private EntityCollection<OrganizationEntity> _organizationCollectionViaEventAccountTestHcpcsCode;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventAccountTestHcpcsCode;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventAccountTestHcpcsCode_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaAccountTestHcpcsCode_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaAccountTestHcpcsCode;
		private HcpcsCodeEntity _hcpcsCode;
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
			/// <summary>Member name HcpcsCode</summary>
			public static readonly string HcpcsCode = "HcpcsCode";
			/// <summary>Member name OrganizationRoleUser_</summary>
			public static readonly string OrganizationRoleUser_ = "OrganizationRoleUser_";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name Test</summary>
			public static readonly string Test = "Test";
			/// <summary>Member name AccountTestHcpcsCode</summary>
			public static readonly string AccountTestHcpcsCode = "AccountTestHcpcsCode";
			/// <summary>Member name EventAccountTestHcpcsCode</summary>
			public static readonly string EventAccountTestHcpcsCode = "EventAccountTestHcpcsCode";
			/// <summary>Member name EventsCollectionViaEventAccountTestHcpcsCode</summary>
			public static readonly string EventsCollectionViaEventAccountTestHcpcsCode = "EventsCollectionViaEventAccountTestHcpcsCode";
			/// <summary>Member name OrganizationCollectionViaAccountTestHcpcsCode</summary>
			public static readonly string OrganizationCollectionViaAccountTestHcpcsCode = "OrganizationCollectionViaAccountTestHcpcsCode";
			/// <summary>Member name OrganizationCollectionViaEventAccountTestHcpcsCode</summary>
			public static readonly string OrganizationCollectionViaEventAccountTestHcpcsCode = "OrganizationCollectionViaEventAccountTestHcpcsCode";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode = "OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_ = "OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_";
			/// <summary>Member name OrganizationRoleUserCollectionViaAccountTestHcpcsCode_</summary>
			public static readonly string OrganizationRoleUserCollectionViaAccountTestHcpcsCode_ = "OrganizationRoleUserCollectionViaAccountTestHcpcsCode_";
			/// <summary>Member name OrganizationRoleUserCollectionViaAccountTestHcpcsCode</summary>
			public static readonly string OrganizationRoleUserCollectionViaAccountTestHcpcsCode = "OrganizationRoleUserCollectionViaAccountTestHcpcsCode";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static TestHcpcsCodeEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public TestHcpcsCodeEntity():base("TestHcpcsCodeEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public TestHcpcsCodeEntity(IEntityFields2 fields):base("TestHcpcsCodeEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this TestHcpcsCodeEntity</param>
		public TestHcpcsCodeEntity(IValidator validator):base("TestHcpcsCodeEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for TestHcpcsCode which data should be fetched into this TestHcpcsCode object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TestHcpcsCodeEntity(System.Int64 id):base("TestHcpcsCodeEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for TestHcpcsCode which data should be fetched into this TestHcpcsCode object</param>
		/// <param name="validator">The custom validator object for this TestHcpcsCodeEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TestHcpcsCodeEntity(System.Int64 id, IValidator validator):base("TestHcpcsCodeEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected TestHcpcsCodeEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_accountTestHcpcsCode = (EntityCollection<AccountTestHcpcsCodeEntity>)info.GetValue("_accountTestHcpcsCode", typeof(EntityCollection<AccountTestHcpcsCodeEntity>));
				_eventAccountTestHcpcsCode = (EntityCollection<EventAccountTestHcpcsCodeEntity>)info.GetValue("_eventAccountTestHcpcsCode", typeof(EntityCollection<EventAccountTestHcpcsCodeEntity>));
				_eventsCollectionViaEventAccountTestHcpcsCode = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventAccountTestHcpcsCode", typeof(EntityCollection<EventsEntity>));
				_organizationCollectionViaAccountTestHcpcsCode = (EntityCollection<OrganizationEntity>)info.GetValue("_organizationCollectionViaAccountTestHcpcsCode", typeof(EntityCollection<OrganizationEntity>));
				_organizationCollectionViaEventAccountTestHcpcsCode = (EntityCollection<OrganizationEntity>)info.GetValue("_organizationCollectionViaEventAccountTestHcpcsCode", typeof(EntityCollection<OrganizationEntity>));
				_organizationRoleUserCollectionViaEventAccountTestHcpcsCode = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventAccountTestHcpcsCode", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventAccountTestHcpcsCode_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventAccountTestHcpcsCode_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaAccountTestHcpcsCode_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaAccountTestHcpcsCode_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaAccountTestHcpcsCode = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaAccountTestHcpcsCode", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_hcpcsCode = (HcpcsCodeEntity)info.GetValue("_hcpcsCode", typeof(HcpcsCodeEntity));
				if(_hcpcsCode!=null)
				{
					_hcpcsCode.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((TestHcpcsCodeFieldIndex)fieldIndex)
			{
				case TestHcpcsCodeFieldIndex.TestId:
					DesetupSyncTest(true, false);
					break;
				case TestHcpcsCodeFieldIndex.HcpcsCodeId:
					DesetupSyncHcpcsCode(true, false);
					break;
				case TestHcpcsCodeFieldIndex.CreatedBy:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case TestHcpcsCodeFieldIndex.ModifiedBy:
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
				case "HcpcsCode":
					this.HcpcsCode = (HcpcsCodeEntity)entity;
					break;
				case "OrganizationRoleUser_":
					this.OrganizationRoleUser_ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "Test":
					this.Test = (TestEntity)entity;
					break;
				case "AccountTestHcpcsCode":
					this.AccountTestHcpcsCode.Add((AccountTestHcpcsCodeEntity)entity);
					break;
				case "EventAccountTestHcpcsCode":
					this.EventAccountTestHcpcsCode.Add((EventAccountTestHcpcsCodeEntity)entity);
					break;
				case "EventsCollectionViaEventAccountTestHcpcsCode":
					this.EventsCollectionViaEventAccountTestHcpcsCode.IsReadOnly = false;
					this.EventsCollectionViaEventAccountTestHcpcsCode.Add((EventsEntity)entity);
					this.EventsCollectionViaEventAccountTestHcpcsCode.IsReadOnly = true;
					break;
				case "OrganizationCollectionViaAccountTestHcpcsCode":
					this.OrganizationCollectionViaAccountTestHcpcsCode.IsReadOnly = false;
					this.OrganizationCollectionViaAccountTestHcpcsCode.Add((OrganizationEntity)entity);
					this.OrganizationCollectionViaAccountTestHcpcsCode.IsReadOnly = true;
					break;
				case "OrganizationCollectionViaEventAccountTestHcpcsCode":
					this.OrganizationCollectionViaEventAccountTestHcpcsCode.IsReadOnly = false;
					this.OrganizationCollectionViaEventAccountTestHcpcsCode.Add((OrganizationEntity)entity);
					this.OrganizationCollectionViaEventAccountTestHcpcsCode.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode":
					this.OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_":
					this.OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaAccountTestHcpcsCode_":
					this.OrganizationRoleUserCollectionViaAccountTestHcpcsCode_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaAccountTestHcpcsCode_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaAccountTestHcpcsCode_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaAccountTestHcpcsCode":
					this.OrganizationRoleUserCollectionViaAccountTestHcpcsCode.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaAccountTestHcpcsCode.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaAccountTestHcpcsCode.IsReadOnly = true;
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
			return TestHcpcsCodeEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "HcpcsCode":
					toReturn.Add(TestHcpcsCodeEntity.Relations.HcpcsCodeEntityUsingHcpcsCodeId);
					break;
				case "OrganizationRoleUser_":
					toReturn.Add(TestHcpcsCodeEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(TestHcpcsCodeEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy);
					break;
				case "Test":
					toReturn.Add(TestHcpcsCodeEntity.Relations.TestEntityUsingTestId);
					break;
				case "AccountTestHcpcsCode":
					toReturn.Add(TestHcpcsCodeEntity.Relations.AccountTestHcpcsCodeEntityUsingTestHcpcsCodeId);
					break;
				case "EventAccountTestHcpcsCode":
					toReturn.Add(TestHcpcsCodeEntity.Relations.EventAccountTestHcpcsCodeEntityUsingTestHcpcsCodeId);
					break;
				case "EventsCollectionViaEventAccountTestHcpcsCode":
					toReturn.Add(TestHcpcsCodeEntity.Relations.EventAccountTestHcpcsCodeEntityUsingTestHcpcsCodeId, "TestHcpcsCodeEntity__", "EventAccountTestHcpcsCode_", JoinHint.None);
					toReturn.Add(EventAccountTestHcpcsCodeEntity.Relations.EventsEntityUsingEventId, "EventAccountTestHcpcsCode_", string.Empty, JoinHint.None);
					break;
				case "OrganizationCollectionViaAccountTestHcpcsCode":
					toReturn.Add(TestHcpcsCodeEntity.Relations.AccountTestHcpcsCodeEntityUsingTestHcpcsCodeId, "TestHcpcsCodeEntity__", "AccountTestHcpcsCode_", JoinHint.None);
					toReturn.Add(AccountTestHcpcsCodeEntity.Relations.OrganizationEntityUsingAccountId, "AccountTestHcpcsCode_", string.Empty, JoinHint.None);
					break;
				case "OrganizationCollectionViaEventAccountTestHcpcsCode":
					toReturn.Add(TestHcpcsCodeEntity.Relations.EventAccountTestHcpcsCodeEntityUsingTestHcpcsCodeId, "TestHcpcsCodeEntity__", "EventAccountTestHcpcsCode_", JoinHint.None);
					toReturn.Add(EventAccountTestHcpcsCodeEntity.Relations.OrganizationEntityUsingAccountId, "EventAccountTestHcpcsCode_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode":
					toReturn.Add(TestHcpcsCodeEntity.Relations.EventAccountTestHcpcsCodeEntityUsingTestHcpcsCodeId, "TestHcpcsCodeEntity__", "EventAccountTestHcpcsCode_", JoinHint.None);
					toReturn.Add(EventAccountTestHcpcsCodeEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "EventAccountTestHcpcsCode_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_":
					toReturn.Add(TestHcpcsCodeEntity.Relations.EventAccountTestHcpcsCodeEntityUsingTestHcpcsCodeId, "TestHcpcsCodeEntity__", "EventAccountTestHcpcsCode_", JoinHint.None);
					toReturn.Add(EventAccountTestHcpcsCodeEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "EventAccountTestHcpcsCode_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaAccountTestHcpcsCode_":
					toReturn.Add(TestHcpcsCodeEntity.Relations.AccountTestHcpcsCodeEntityUsingTestHcpcsCodeId, "TestHcpcsCodeEntity__", "AccountTestHcpcsCode_", JoinHint.None);
					toReturn.Add(AccountTestHcpcsCodeEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "AccountTestHcpcsCode_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaAccountTestHcpcsCode":
					toReturn.Add(TestHcpcsCodeEntity.Relations.AccountTestHcpcsCodeEntityUsingTestHcpcsCodeId, "TestHcpcsCodeEntity__", "AccountTestHcpcsCode_", JoinHint.None);
					toReturn.Add(AccountTestHcpcsCodeEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "AccountTestHcpcsCode_", string.Empty, JoinHint.None);
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
				case "HcpcsCode":
					SetupSyncHcpcsCode(relatedEntity);
					break;
				case "OrganizationRoleUser_":
					SetupSyncOrganizationRoleUser_(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "Test":
					SetupSyncTest(relatedEntity);
					break;
				case "AccountTestHcpcsCode":
					this.AccountTestHcpcsCode.Add((AccountTestHcpcsCodeEntity)relatedEntity);
					break;
				case "EventAccountTestHcpcsCode":
					this.EventAccountTestHcpcsCode.Add((EventAccountTestHcpcsCodeEntity)relatedEntity);
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
				case "HcpcsCode":
					DesetupSyncHcpcsCode(false, true);
					break;
				case "OrganizationRoleUser_":
					DesetupSyncOrganizationRoleUser_(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "Test":
					DesetupSyncTest(false, true);
					break;
				case "AccountTestHcpcsCode":
					base.PerformRelatedEntityRemoval(this.AccountTestHcpcsCode, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventAccountTestHcpcsCode":
					base.PerformRelatedEntityRemoval(this.EventAccountTestHcpcsCode, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_hcpcsCode!=null)
			{
				toReturn.Add(_hcpcsCode);
			}
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
			toReturn.Add(this.AccountTestHcpcsCode);
			toReturn.Add(this.EventAccountTestHcpcsCode);

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
				info.AddValue("_accountTestHcpcsCode", ((_accountTestHcpcsCode!=null) && (_accountTestHcpcsCode.Count>0) && !this.MarkedForDeletion)?_accountTestHcpcsCode:null);
				info.AddValue("_eventAccountTestHcpcsCode", ((_eventAccountTestHcpcsCode!=null) && (_eventAccountTestHcpcsCode.Count>0) && !this.MarkedForDeletion)?_eventAccountTestHcpcsCode:null);
				info.AddValue("_eventsCollectionViaEventAccountTestHcpcsCode", ((_eventsCollectionViaEventAccountTestHcpcsCode!=null) && (_eventsCollectionViaEventAccountTestHcpcsCode.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventAccountTestHcpcsCode:null);
				info.AddValue("_organizationCollectionViaAccountTestHcpcsCode", ((_organizationCollectionViaAccountTestHcpcsCode!=null) && (_organizationCollectionViaAccountTestHcpcsCode.Count>0) && !this.MarkedForDeletion)?_organizationCollectionViaAccountTestHcpcsCode:null);
				info.AddValue("_organizationCollectionViaEventAccountTestHcpcsCode", ((_organizationCollectionViaEventAccountTestHcpcsCode!=null) && (_organizationCollectionViaEventAccountTestHcpcsCode.Count>0) && !this.MarkedForDeletion)?_organizationCollectionViaEventAccountTestHcpcsCode:null);
				info.AddValue("_organizationRoleUserCollectionViaEventAccountTestHcpcsCode", ((_organizationRoleUserCollectionViaEventAccountTestHcpcsCode!=null) && (_organizationRoleUserCollectionViaEventAccountTestHcpcsCode.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventAccountTestHcpcsCode:null);
				info.AddValue("_organizationRoleUserCollectionViaEventAccountTestHcpcsCode_", ((_organizationRoleUserCollectionViaEventAccountTestHcpcsCode_!=null) && (_organizationRoleUserCollectionViaEventAccountTestHcpcsCode_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventAccountTestHcpcsCode_:null);
				info.AddValue("_organizationRoleUserCollectionViaAccountTestHcpcsCode_", ((_organizationRoleUserCollectionViaAccountTestHcpcsCode_!=null) && (_organizationRoleUserCollectionViaAccountTestHcpcsCode_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaAccountTestHcpcsCode_:null);
				info.AddValue("_organizationRoleUserCollectionViaAccountTestHcpcsCode", ((_organizationRoleUserCollectionViaAccountTestHcpcsCode!=null) && (_organizationRoleUserCollectionViaAccountTestHcpcsCode.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaAccountTestHcpcsCode:null);
				info.AddValue("_hcpcsCode", (!this.MarkedForDeletion?_hcpcsCode:null));
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
		public bool TestOriginalFieldValueForNull(TestHcpcsCodeFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(TestHcpcsCodeFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new TestHcpcsCodeRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccountTestHcpcsCode' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountTestHcpcsCode()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountTestHcpcsCodeFields.TestHcpcsCodeId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventAccountTestHcpcsCode' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventAccountTestHcpcsCode()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventAccountTestHcpcsCodeFields.TestHcpcsCodeId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventAccountTestHcpcsCode()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventAccountTestHcpcsCode"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestHcpcsCodeFields.Id, null, ComparisonOperator.Equal, this.Id, "TestHcpcsCodeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Organization' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationCollectionViaAccountTestHcpcsCode()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationCollectionViaAccountTestHcpcsCode"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestHcpcsCodeFields.Id, null, ComparisonOperator.Equal, this.Id, "TestHcpcsCodeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Organization' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationCollectionViaEventAccountTestHcpcsCode()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationCollectionViaEventAccountTestHcpcsCode"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestHcpcsCodeFields.Id, null, ComparisonOperator.Equal, this.Id, "TestHcpcsCodeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventAccountTestHcpcsCode()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestHcpcsCodeFields.Id, null, ComparisonOperator.Equal, this.Id, "TestHcpcsCodeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestHcpcsCodeFields.Id, null, ComparisonOperator.Equal, this.Id, "TestHcpcsCodeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaAccountTestHcpcsCode_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaAccountTestHcpcsCode_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestHcpcsCodeFields.Id, null, ComparisonOperator.Equal, this.Id, "TestHcpcsCodeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaAccountTestHcpcsCode()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaAccountTestHcpcsCode"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestHcpcsCodeFields.Id, null, ComparisonOperator.Equal, this.Id, "TestHcpcsCodeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'HcpcsCode' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHcpcsCode()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HcpcsCodeFields.Id, null, ComparisonOperator.Equal, this.HcpcsCodeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.ModifiedBy));
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
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.TestHcpcsCodeEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(TestHcpcsCodeEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._accountTestHcpcsCode);
			collectionsQueue.Enqueue(this._eventAccountTestHcpcsCode);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventAccountTestHcpcsCode);
			collectionsQueue.Enqueue(this._organizationCollectionViaAccountTestHcpcsCode);
			collectionsQueue.Enqueue(this._organizationCollectionViaEventAccountTestHcpcsCode);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventAccountTestHcpcsCode);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventAccountTestHcpcsCode_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaAccountTestHcpcsCode_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaAccountTestHcpcsCode);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._accountTestHcpcsCode = (EntityCollection<AccountTestHcpcsCodeEntity>) collectionsQueue.Dequeue();
			this._eventAccountTestHcpcsCode = (EntityCollection<EventAccountTestHcpcsCodeEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventAccountTestHcpcsCode = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._organizationCollectionViaAccountTestHcpcsCode = (EntityCollection<OrganizationEntity>) collectionsQueue.Dequeue();
			this._organizationCollectionViaEventAccountTestHcpcsCode = (EntityCollection<OrganizationEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventAccountTestHcpcsCode = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventAccountTestHcpcsCode_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaAccountTestHcpcsCode_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaAccountTestHcpcsCode = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._accountTestHcpcsCode != null)
			{
				return true;
			}
			if (this._eventAccountTestHcpcsCode != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventAccountTestHcpcsCode != null)
			{
				return true;
			}
			if (this._organizationCollectionViaAccountTestHcpcsCode != null)
			{
				return true;
			}
			if (this._organizationCollectionViaEventAccountTestHcpcsCode != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventAccountTestHcpcsCode != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventAccountTestHcpcsCode_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaAccountTestHcpcsCode_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaAccountTestHcpcsCode != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountTestHcpcsCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountTestHcpcsCodeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventAccountTestHcpcsCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAccountTestHcpcsCodeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("HcpcsCode", _hcpcsCode);
			toReturn.Add("OrganizationRoleUser_", _organizationRoleUser_);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("Test", _test);
			toReturn.Add("AccountTestHcpcsCode", _accountTestHcpcsCode);
			toReturn.Add("EventAccountTestHcpcsCode", _eventAccountTestHcpcsCode);
			toReturn.Add("EventsCollectionViaEventAccountTestHcpcsCode", _eventsCollectionViaEventAccountTestHcpcsCode);
			toReturn.Add("OrganizationCollectionViaAccountTestHcpcsCode", _organizationCollectionViaAccountTestHcpcsCode);
			toReturn.Add("OrganizationCollectionViaEventAccountTestHcpcsCode", _organizationCollectionViaEventAccountTestHcpcsCode);
			toReturn.Add("OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode", _organizationRoleUserCollectionViaEventAccountTestHcpcsCode);
			toReturn.Add("OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_", _organizationRoleUserCollectionViaEventAccountTestHcpcsCode_);
			toReturn.Add("OrganizationRoleUserCollectionViaAccountTestHcpcsCode_", _organizationRoleUserCollectionViaAccountTestHcpcsCode_);
			toReturn.Add("OrganizationRoleUserCollectionViaAccountTestHcpcsCode", _organizationRoleUserCollectionViaAccountTestHcpcsCode);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_accountTestHcpcsCode!=null)
			{
				_accountTestHcpcsCode.ActiveContext = base.ActiveContext;
			}
			if(_eventAccountTestHcpcsCode!=null)
			{
				_eventAccountTestHcpcsCode.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventAccountTestHcpcsCode!=null)
			{
				_eventsCollectionViaEventAccountTestHcpcsCode.ActiveContext = base.ActiveContext;
			}
			if(_organizationCollectionViaAccountTestHcpcsCode!=null)
			{
				_organizationCollectionViaAccountTestHcpcsCode.ActiveContext = base.ActiveContext;
			}
			if(_organizationCollectionViaEventAccountTestHcpcsCode!=null)
			{
				_organizationCollectionViaEventAccountTestHcpcsCode.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventAccountTestHcpcsCode!=null)
			{
				_organizationRoleUserCollectionViaEventAccountTestHcpcsCode.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventAccountTestHcpcsCode_!=null)
			{
				_organizationRoleUserCollectionViaEventAccountTestHcpcsCode_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaAccountTestHcpcsCode_!=null)
			{
				_organizationRoleUserCollectionViaAccountTestHcpcsCode_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaAccountTestHcpcsCode!=null)
			{
				_organizationRoleUserCollectionViaAccountTestHcpcsCode.ActiveContext = base.ActiveContext;
			}
			if(_hcpcsCode!=null)
			{
				_hcpcsCode.ActiveContext = base.ActiveContext;
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

			_accountTestHcpcsCode = null;
			_eventAccountTestHcpcsCode = null;
			_eventsCollectionViaEventAccountTestHcpcsCode = null;
			_organizationCollectionViaAccountTestHcpcsCode = null;
			_organizationCollectionViaEventAccountTestHcpcsCode = null;
			_organizationRoleUserCollectionViaEventAccountTestHcpcsCode = null;
			_organizationRoleUserCollectionViaEventAccountTestHcpcsCode_ = null;
			_organizationRoleUserCollectionViaAccountTestHcpcsCode_ = null;
			_organizationRoleUserCollectionViaAccountTestHcpcsCode = null;
			_hcpcsCode = null;
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

			_fieldsCustomProperties.Add("TestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HcpcsCodeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsRetired", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _hcpcsCode</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncHcpcsCode(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _hcpcsCode, new PropertyChangedEventHandler( OnHcpcsCodePropertyChanged ), "HcpcsCode", TestHcpcsCodeEntity.Relations.HcpcsCodeEntityUsingHcpcsCodeId, true, signalRelatedEntity, "TestHcpcsCode", resetFKFields, new int[] { (int)TestHcpcsCodeFieldIndex.HcpcsCodeId } );		
			_hcpcsCode = null;
		}

		/// <summary> setups the sync logic for member _hcpcsCode</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncHcpcsCode(IEntity2 relatedEntity)
		{
			if(_hcpcsCode!=relatedEntity)
			{
				DesetupSyncHcpcsCode(true, true);
				_hcpcsCode = (HcpcsCodeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _hcpcsCode, new PropertyChangedEventHandler( OnHcpcsCodePropertyChanged ), "HcpcsCode", TestHcpcsCodeEntity.Relations.HcpcsCodeEntityUsingHcpcsCodeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnHcpcsCodePropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", TestHcpcsCodeEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, true, signalRelatedEntity, "TestHcpcsCode_", resetFKFields, new int[] { (int)TestHcpcsCodeFieldIndex.ModifiedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", TestHcpcsCodeEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", TestHcpcsCodeEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, signalRelatedEntity, "TestHcpcsCode", resetFKFields, new int[] { (int)TestHcpcsCodeFieldIndex.CreatedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", TestHcpcsCodeEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _test, new PropertyChangedEventHandler( OnTestPropertyChanged ), "Test", TestHcpcsCodeEntity.Relations.TestEntityUsingTestId, true, signalRelatedEntity, "TestHcpcsCode", resetFKFields, new int[] { (int)TestHcpcsCodeFieldIndex.TestId } );		
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
				base.PerformSetupSyncRelatedEntity( _test, new PropertyChangedEventHandler( OnTestPropertyChanged ), "Test", TestHcpcsCodeEntity.Relations.TestEntityUsingTestId, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this TestHcpcsCodeEntity</param>
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
		public  static TestHcpcsCodeRelations Relations
		{
			get	{ return new TestHcpcsCodeRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccountTestHcpcsCode' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountTestHcpcsCode
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountTestHcpcsCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountTestHcpcsCodeEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccountTestHcpcsCode")[0], (int)Falcon.Data.EntityType.TestHcpcsCodeEntity, (int)Falcon.Data.EntityType.AccountTestHcpcsCodeEntity, 0, null, null, null, null, "AccountTestHcpcsCode", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventAccountTestHcpcsCode' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventAccountTestHcpcsCode
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventAccountTestHcpcsCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAccountTestHcpcsCodeEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventAccountTestHcpcsCode")[0], (int)Falcon.Data.EntityType.TestHcpcsCodeEntity, (int)Falcon.Data.EntityType.EventAccountTestHcpcsCodeEntity, 0, null, null, null, null, "EventAccountTestHcpcsCode", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventAccountTestHcpcsCode
		{
			get
			{
				IEntityRelation intermediateRelation = TestHcpcsCodeEntity.Relations.EventAccountTestHcpcsCodeEntityUsingTestHcpcsCodeId;
				intermediateRelation.SetAliases(string.Empty, "EventAccountTestHcpcsCode_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestHcpcsCodeEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventAccountTestHcpcsCode"), null, "EventsCollectionViaEventAccountTestHcpcsCode", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Organization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationCollectionViaAccountTestHcpcsCode
		{
			get
			{
				IEntityRelation intermediateRelation = TestHcpcsCodeEntity.Relations.AccountTestHcpcsCodeEntityUsingTestHcpcsCodeId;
				intermediateRelation.SetAliases(string.Empty, "AccountTestHcpcsCode_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestHcpcsCodeEntity, (int)Falcon.Data.EntityType.OrganizationEntity, 0, null, null, GetRelationsForField("OrganizationCollectionViaAccountTestHcpcsCode"), null, "OrganizationCollectionViaAccountTestHcpcsCode", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Organization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationCollectionViaEventAccountTestHcpcsCode
		{
			get
			{
				IEntityRelation intermediateRelation = TestHcpcsCodeEntity.Relations.EventAccountTestHcpcsCodeEntityUsingTestHcpcsCodeId;
				intermediateRelation.SetAliases(string.Empty, "EventAccountTestHcpcsCode_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestHcpcsCodeEntity, (int)Falcon.Data.EntityType.OrganizationEntity, 0, null, null, GetRelationsForField("OrganizationCollectionViaEventAccountTestHcpcsCode"), null, "OrganizationCollectionViaEventAccountTestHcpcsCode", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventAccountTestHcpcsCode
		{
			get
			{
				IEntityRelation intermediateRelation = TestHcpcsCodeEntity.Relations.EventAccountTestHcpcsCodeEntityUsingTestHcpcsCodeId;
				intermediateRelation.SetAliases(string.Empty, "EventAccountTestHcpcsCode_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestHcpcsCodeEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode"), null, "OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_
		{
			get
			{
				IEntityRelation intermediateRelation = TestHcpcsCodeEntity.Relations.EventAccountTestHcpcsCodeEntityUsingTestHcpcsCodeId;
				intermediateRelation.SetAliases(string.Empty, "EventAccountTestHcpcsCode_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestHcpcsCodeEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_"), null, "OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaAccountTestHcpcsCode_
		{
			get
			{
				IEntityRelation intermediateRelation = TestHcpcsCodeEntity.Relations.AccountTestHcpcsCodeEntityUsingTestHcpcsCodeId;
				intermediateRelation.SetAliases(string.Empty, "AccountTestHcpcsCode_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestHcpcsCodeEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaAccountTestHcpcsCode_"), null, "OrganizationRoleUserCollectionViaAccountTestHcpcsCode_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaAccountTestHcpcsCode
		{
			get
			{
				IEntityRelation intermediateRelation = TestHcpcsCodeEntity.Relations.AccountTestHcpcsCodeEntityUsingTestHcpcsCodeId;
				intermediateRelation.SetAliases(string.Empty, "AccountTestHcpcsCode_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestHcpcsCodeEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaAccountTestHcpcsCode"), null, "OrganizationRoleUserCollectionViaAccountTestHcpcsCode", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HcpcsCode' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHcpcsCode
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(HcpcsCodeEntityFactory))),
					(IEntityRelation)GetRelationsForField("HcpcsCode")[0], (int)Falcon.Data.EntityType.TestHcpcsCodeEntity, (int)Falcon.Data.EntityType.HcpcsCodeEntity, 0, null, null, null, null, "HcpcsCode", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.TestHcpcsCodeEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.TestHcpcsCodeEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Test")[0], (int)Falcon.Data.EntityType.TestHcpcsCodeEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, null, null, "Test", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return TestHcpcsCodeEntity.CustomProperties;}
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
			get { return TestHcpcsCodeEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity TestHcpcsCode<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTestHcpcsCode"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)TestHcpcsCodeFieldIndex.Id, true); }
			set	{ SetValue((int)TestHcpcsCodeFieldIndex.Id, value); }
		}

		/// <summary> The TestId property of the Entity TestHcpcsCode<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTestHcpcsCode"."TestId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TestId
		{
			get { return (System.Int64)GetValue((int)TestHcpcsCodeFieldIndex.TestId, true); }
			set	{ SetValue((int)TestHcpcsCodeFieldIndex.TestId, value); }
		}

		/// <summary> The HcpcsCodeId property of the Entity TestHcpcsCode<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTestHcpcsCode"."HcpcsCodeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 HcpcsCodeId
		{
			get { return (System.Int64)GetValue((int)TestHcpcsCodeFieldIndex.HcpcsCodeId, true); }
			set	{ SetValue((int)TestHcpcsCodeFieldIndex.HcpcsCodeId, value); }
		}

		/// <summary> The IsRetired property of the Entity TestHcpcsCode<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTestHcpcsCode"."IsRetired"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsRetired
		{
			get { return (System.Boolean)GetValue((int)TestHcpcsCodeFieldIndex.IsRetired, true); }
			set	{ SetValue((int)TestHcpcsCodeFieldIndex.IsRetired, value); }
		}

		/// <summary> The CreatedBy property of the Entity TestHcpcsCode<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTestHcpcsCode"."CreatedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedBy
		{
			get { return (System.Int64)GetValue((int)TestHcpcsCodeFieldIndex.CreatedBy, true); }
			set	{ SetValue((int)TestHcpcsCodeFieldIndex.CreatedBy, value); }
		}

		/// <summary> The CreatedDate property of the Entity TestHcpcsCode<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTestHcpcsCode"."CreatedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime CreatedDate
		{
			get { return (System.DateTime)GetValue((int)TestHcpcsCodeFieldIndex.CreatedDate, true); }
			set	{ SetValue((int)TestHcpcsCodeFieldIndex.CreatedDate, value); }
		}

		/// <summary> The ModifiedBy property of the Entity TestHcpcsCode<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTestHcpcsCode"."ModifiedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedBy
		{
			get { return (Nullable<System.Int64>)GetValue((int)TestHcpcsCodeFieldIndex.ModifiedBy, false); }
			set	{ SetValue((int)TestHcpcsCodeFieldIndex.ModifiedBy, value); }
		}

		/// <summary> The ModifiedDate property of the Entity TestHcpcsCode<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTestHcpcsCode"."ModifiedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ModifiedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)TestHcpcsCodeFieldIndex.ModifiedDate, false); }
			set	{ SetValue((int)TestHcpcsCodeFieldIndex.ModifiedDate, value); }
		}

		/// <summary> The IsActive property of the Entity TestHcpcsCode<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTestHcpcsCode"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)TestHcpcsCodeFieldIndex.IsActive, true); }
			set	{ SetValue((int)TestHcpcsCodeFieldIndex.IsActive, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountTestHcpcsCodeEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountTestHcpcsCodeEntity))]
		public virtual EntityCollection<AccountTestHcpcsCodeEntity> AccountTestHcpcsCode
		{
			get
			{
				if(_accountTestHcpcsCode==null)
				{
					_accountTestHcpcsCode = new EntityCollection<AccountTestHcpcsCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountTestHcpcsCodeEntityFactory)));
					_accountTestHcpcsCode.SetContainingEntityInfo(this, "TestHcpcsCode");
				}
				return _accountTestHcpcsCode;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventAccountTestHcpcsCodeEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventAccountTestHcpcsCodeEntity))]
		public virtual EntityCollection<EventAccountTestHcpcsCodeEntity> EventAccountTestHcpcsCode
		{
			get
			{
				if(_eventAccountTestHcpcsCode==null)
				{
					_eventAccountTestHcpcsCode = new EntityCollection<EventAccountTestHcpcsCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAccountTestHcpcsCodeEntityFactory)));
					_eventAccountTestHcpcsCode.SetContainingEntityInfo(this, "TestHcpcsCode");
				}
				return _eventAccountTestHcpcsCode;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventAccountTestHcpcsCode
		{
			get
			{
				if(_eventsCollectionViaEventAccountTestHcpcsCode==null)
				{
					_eventsCollectionViaEventAccountTestHcpcsCode = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventAccountTestHcpcsCode.IsReadOnly=true;
				}
				return _eventsCollectionViaEventAccountTestHcpcsCode;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationEntity))]
		public virtual EntityCollection<OrganizationEntity> OrganizationCollectionViaAccountTestHcpcsCode
		{
			get
			{
				if(_organizationCollectionViaAccountTestHcpcsCode==null)
				{
					_organizationCollectionViaAccountTestHcpcsCode = new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory)));
					_organizationCollectionViaAccountTestHcpcsCode.IsReadOnly=true;
				}
				return _organizationCollectionViaAccountTestHcpcsCode;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationEntity))]
		public virtual EntityCollection<OrganizationEntity> OrganizationCollectionViaEventAccountTestHcpcsCode
		{
			get
			{
				if(_organizationCollectionViaEventAccountTestHcpcsCode==null)
				{
					_organizationCollectionViaEventAccountTestHcpcsCode = new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory)));
					_organizationCollectionViaEventAccountTestHcpcsCode.IsReadOnly=true;
				}
				return _organizationCollectionViaEventAccountTestHcpcsCode;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventAccountTestHcpcsCode==null)
				{
					_organizationRoleUserCollectionViaEventAccountTestHcpcsCode = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventAccountTestHcpcsCode.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventAccountTestHcpcsCode;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventAccountTestHcpcsCode_==null)
				{
					_organizationRoleUserCollectionViaEventAccountTestHcpcsCode_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventAccountTestHcpcsCode_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventAccountTestHcpcsCode_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaAccountTestHcpcsCode_
		{
			get
			{
				if(_organizationRoleUserCollectionViaAccountTestHcpcsCode_==null)
				{
					_organizationRoleUserCollectionViaAccountTestHcpcsCode_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaAccountTestHcpcsCode_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaAccountTestHcpcsCode_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaAccountTestHcpcsCode
		{
			get
			{
				if(_organizationRoleUserCollectionViaAccountTestHcpcsCode==null)
				{
					_organizationRoleUserCollectionViaAccountTestHcpcsCode = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaAccountTestHcpcsCode.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaAccountTestHcpcsCode;
			}
		}

		/// <summary> Gets / sets related entity of type 'HcpcsCodeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual HcpcsCodeEntity HcpcsCode
		{
			get
			{
				return _hcpcsCode;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncHcpcsCode(value);
				}
				else
				{
					if(value==null)
					{
						if(_hcpcsCode != null)
						{
							_hcpcsCode.UnsetRelatedEntity(this, "TestHcpcsCode");
						}
					}
					else
					{
						if(_hcpcsCode!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "TestHcpcsCode");
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
							_organizationRoleUser_.UnsetRelatedEntity(this, "TestHcpcsCode_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "TestHcpcsCode_");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "TestHcpcsCode");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "TestHcpcsCode");
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
							_test.UnsetRelatedEntity(this, "TestHcpcsCode");
						}
					}
					else
					{
						if(_test!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "TestHcpcsCode");
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
			get { return (int)Falcon.Data.EntityType.TestHcpcsCodeEntity; }
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
