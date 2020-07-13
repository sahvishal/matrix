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
	/// Entity class which represents the entity 'CallRoundCallQueue'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CallRoundCallQueueEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CallRoundCallQueueCriteriaAssignmentEntity> _callRoundCallQueueCriteriaAssignment;
		private EntityCollection<HealthPlanCallQueueCriteriaEntity> _healthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment;
		private AccountEntity _account;
		private CustomerProfileEntity _customerProfile;
		private LookupEntity _lookup;
		private OrganizationRoleUserEntity _organizationRoleUser;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Account</summary>
			public static readonly string Account = "Account";
			/// <summary>Member name CustomerProfile</summary>
			public static readonly string CustomerProfile = "CustomerProfile";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name CallRoundCallQueueCriteriaAssignment</summary>
			public static readonly string CallRoundCallQueueCriteriaAssignment = "CallRoundCallQueueCriteriaAssignment";
			/// <summary>Member name HealthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment</summary>
			public static readonly string HealthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment = "HealthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CallRoundCallQueueEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CallRoundCallQueueEntity():base("CallRoundCallQueueEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CallRoundCallQueueEntity(IEntityFields2 fields):base("CallRoundCallQueueEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CallRoundCallQueueEntity</param>
		public CallRoundCallQueueEntity(IValidator validator):base("CallRoundCallQueueEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for CallRoundCallQueue which data should be fetched into this CallRoundCallQueue object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CallRoundCallQueueEntity(System.Int64 id):base("CallRoundCallQueueEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for CallRoundCallQueue which data should be fetched into this CallRoundCallQueue object</param>
		/// <param name="validator">The custom validator object for this CallRoundCallQueueEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CallRoundCallQueueEntity(System.Int64 id, IValidator validator):base("CallRoundCallQueueEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CallRoundCallQueueEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_callRoundCallQueueCriteriaAssignment = (EntityCollection<CallRoundCallQueueCriteriaAssignmentEntity>)info.GetValue("_callRoundCallQueueCriteriaAssignment", typeof(EntityCollection<CallRoundCallQueueCriteriaAssignmentEntity>));
				_healthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment = (EntityCollection<HealthPlanCallQueueCriteriaEntity>)info.GetValue("_healthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment", typeof(EntityCollection<HealthPlanCallQueueCriteriaEntity>));
				_account = (AccountEntity)info.GetValue("_account", typeof(AccountEntity));
				if(_account!=null)
				{
					_account.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_customerProfile = (CustomerProfileEntity)info.GetValue("_customerProfile", typeof(CustomerProfileEntity));
				if(_customerProfile!=null)
				{
					_customerProfile.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
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

				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((CallRoundCallQueueFieldIndex)fieldIndex)
			{
				case CallRoundCallQueueFieldIndex.HealthPlanId:
					DesetupSyncAccount(true, false);
					break;
				case CallRoundCallQueueFieldIndex.CustomerId:
					DesetupSyncCustomerProfile(true, false);
					break;
				case CallRoundCallQueueFieldIndex.Status:
					DesetupSyncLookup(true, false);
					break;
				case CallRoundCallQueueFieldIndex.ModifiedBy:
					DesetupSyncOrganizationRoleUser(true, false);
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
				case "Account":
					this.Account = (AccountEntity)entity;
					break;
				case "CustomerProfile":
					this.CustomerProfile = (CustomerProfileEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "CallRoundCallQueueCriteriaAssignment":
					this.CallRoundCallQueueCriteriaAssignment.Add((CallRoundCallQueueCriteriaAssignmentEntity)entity);
					break;
				case "HealthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment":
					this.HealthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment.IsReadOnly = false;
					this.HealthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment.Add((HealthPlanCallQueueCriteriaEntity)entity);
					this.HealthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment.IsReadOnly = true;
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
			return CallRoundCallQueueEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Account":
					toReturn.Add(CallRoundCallQueueEntity.Relations.AccountEntityUsingHealthPlanId);
					break;
				case "CustomerProfile":
					toReturn.Add(CallRoundCallQueueEntity.Relations.CustomerProfileEntityUsingCustomerId);
					break;
				case "Lookup":
					toReturn.Add(CallRoundCallQueueEntity.Relations.LookupEntityUsingStatus);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(CallRoundCallQueueEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy);
					break;
				case "CallRoundCallQueueCriteriaAssignment":
					toReturn.Add(CallRoundCallQueueEntity.Relations.CallRoundCallQueueCriteriaAssignmentEntityUsingCallRoundCallQueueId);
					break;
				case "HealthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment":
					toReturn.Add(CallRoundCallQueueEntity.Relations.CallRoundCallQueueCriteriaAssignmentEntityUsingCallRoundCallQueueId, "CallRoundCallQueueEntity__", "CallRoundCallQueueCriteriaAssignment_", JoinHint.None);
					toReturn.Add(CallRoundCallQueueCriteriaAssignmentEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCriteriaId, "CallRoundCallQueueCriteriaAssignment_", string.Empty, JoinHint.None);
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
				case "Account":
					SetupSyncAccount(relatedEntity);
					break;
				case "CustomerProfile":
					SetupSyncCustomerProfile(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "CallRoundCallQueueCriteriaAssignment":
					this.CallRoundCallQueueCriteriaAssignment.Add((CallRoundCallQueueCriteriaAssignmentEntity)relatedEntity);
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
				case "Account":
					DesetupSyncAccount(false, true);
					break;
				case "CustomerProfile":
					DesetupSyncCustomerProfile(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "CallRoundCallQueueCriteriaAssignment":
					base.PerformRelatedEntityRemoval(this.CallRoundCallQueueCriteriaAssignment, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_account!=null)
			{
				toReturn.Add(_account);
			}
			if(_customerProfile!=null)
			{
				toReturn.Add(_customerProfile);
			}
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
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
			toReturn.Add(this.CallRoundCallQueueCriteriaAssignment);

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
				info.AddValue("_callRoundCallQueueCriteriaAssignment", ((_callRoundCallQueueCriteriaAssignment!=null) && (_callRoundCallQueueCriteriaAssignment.Count>0) && !this.MarkedForDeletion)?_callRoundCallQueueCriteriaAssignment:null);
				info.AddValue("_healthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment", ((_healthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment!=null) && (_healthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment.Count>0) && !this.MarkedForDeletion)?_healthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment:null);
				info.AddValue("_account", (!this.MarkedForDeletion?_account:null));
				info.AddValue("_customerProfile", (!this.MarkedForDeletion?_customerProfile:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(CallRoundCallQueueFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CallRoundCallQueueFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CallRoundCallQueueRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallRoundCallQueueCriteriaAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallRoundCallQueueCriteriaAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallRoundCallQueueCriteriaAssignmentFields.CallRoundCallQueueId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthPlanCallQueueCriteria' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HealthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallRoundCallQueueFields.Id, null, ComparisonOperator.Equal, this.Id, "CallRoundCallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Account' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.HealthPlanId));
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
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.Status));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.ModifiedBy));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CallRoundCallQueueEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CallRoundCallQueueEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._callRoundCallQueueCriteriaAssignment);
			collectionsQueue.Enqueue(this._healthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._callRoundCallQueueCriteriaAssignment = (EntityCollection<CallRoundCallQueueCriteriaAssignmentEntity>) collectionsQueue.Dequeue();
			this._healthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment = (EntityCollection<HealthPlanCallQueueCriteriaEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._callRoundCallQueueCriteriaAssignment != null)
			{
				return true;
			}
			if (this._healthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallRoundCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallRoundCallQueueCriteriaAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthPlanCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Account", _account);
			toReturn.Add("CustomerProfile", _customerProfile);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("CallRoundCallQueueCriteriaAssignment", _callRoundCallQueueCriteriaAssignment);
			toReturn.Add("HealthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment", _healthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_callRoundCallQueueCriteriaAssignment!=null)
			{
				_callRoundCallQueueCriteriaAssignment.ActiveContext = base.ActiveContext;
			}
			if(_healthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment!=null)
			{
				_healthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment.ActiveContext = base.ActiveContext;
			}
			if(_account!=null)
			{
				_account.ActiveContext = base.ActiveContext;
			}
			if(_customerProfile!=null)
			{
				_customerProfile.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_callRoundCallQueueCriteriaAssignment = null;
			_healthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment = null;
			_account = null;
			_customerProfile = null;
			_lookup = null;
			_organizationRoleUser = null;

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

			_fieldsCustomProperties.Add("HealthPlanId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Status", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallDate", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _account</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAccount(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _account, new PropertyChangedEventHandler( OnAccountPropertyChanged ), "Account", CallRoundCallQueueEntity.Relations.AccountEntityUsingHealthPlanId, true, signalRelatedEntity, "CallRoundCallQueue", resetFKFields, new int[] { (int)CallRoundCallQueueFieldIndex.HealthPlanId } );		
			_account = null;
		}

		/// <summary> setups the sync logic for member _account</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAccount(IEntity2 relatedEntity)
		{
			if(_account!=relatedEntity)
			{
				DesetupSyncAccount(true, true);
				_account = (AccountEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _account, new PropertyChangedEventHandler( OnAccountPropertyChanged ), "Account", CallRoundCallQueueEntity.Relations.AccountEntityUsingHealthPlanId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAccountPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", CallRoundCallQueueEntity.Relations.CustomerProfileEntityUsingCustomerId, true, signalRelatedEntity, "CallRoundCallQueue", resetFKFields, new int[] { (int)CallRoundCallQueueFieldIndex.CustomerId } );		
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
				base.PerformSetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", CallRoundCallQueueEntity.Relations.CustomerProfileEntityUsingCustomerId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _lookup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CallRoundCallQueueEntity.Relations.LookupEntityUsingStatus, true, signalRelatedEntity, "CallRoundCallQueue", resetFKFields, new int[] { (int)CallRoundCallQueueFieldIndex.Status } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CallRoundCallQueueEntity.Relations.LookupEntityUsingStatus, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CallRoundCallQueueEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, true, signalRelatedEntity, "CallRoundCallQueue", resetFKFields, new int[] { (int)CallRoundCallQueueFieldIndex.ModifiedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CallRoundCallQueueEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, true, new string[] {  } );
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


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this CallRoundCallQueueEntity</param>
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
		public  static CallRoundCallQueueRelations Relations
		{
			get	{ return new CallRoundCallQueueRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallRoundCallQueueCriteriaAssignment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallRoundCallQueueCriteriaAssignment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CallRoundCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallRoundCallQueueCriteriaAssignmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallRoundCallQueueCriteriaAssignment")[0], (int)Falcon.Data.EntityType.CallRoundCallQueueEntity, (int)Falcon.Data.EntityType.CallRoundCallQueueCriteriaAssignmentEntity, 0, null, null, null, null, "CallRoundCallQueueCriteriaAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HealthPlanCallQueueCriteria' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHealthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = CallRoundCallQueueEntity.Relations.CallRoundCallQueueCriteriaAssignmentEntityUsingCallRoundCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "CallRoundCallQueueCriteriaAssignment_");
				return new PrefetchPathElement2(new EntityCollection<HealthPlanCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallRoundCallQueueEntity, (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, 0, null, null, GetRelationsForField("HealthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment"), null, "HealthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccount
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))),
					(IEntityRelation)GetRelationsForField("Account")[0], (int)Falcon.Data.EntityType.CallRoundCallQueueEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, null, null, "Account", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("CustomerProfile")[0], (int)Falcon.Data.EntityType.CallRoundCallQueueEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, null, null, "CustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.CallRoundCallQueueEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.CallRoundCallQueueEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CallRoundCallQueueEntity.CustomProperties;}
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
			get { return CallRoundCallQueueEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity CallRoundCallQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallRoundCallQueue"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)CallRoundCallQueueFieldIndex.Id, true); }
			set	{ SetValue((int)CallRoundCallQueueFieldIndex.Id, value); }
		}

		/// <summary> The HealthPlanId property of the Entity CallRoundCallQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallRoundCallQueue"."HealthPlanId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 HealthPlanId
		{
			get { return (System.Int64)GetValue((int)CallRoundCallQueueFieldIndex.HealthPlanId, true); }
			set	{ SetValue((int)CallRoundCallQueueFieldIndex.HealthPlanId, value); }
		}

		/// <summary> The CustomerId property of the Entity CallRoundCallQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallRoundCallQueue"."CustomerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerId
		{
			get { return (System.Int64)GetValue((int)CallRoundCallQueueFieldIndex.CustomerId, true); }
			set	{ SetValue((int)CallRoundCallQueueFieldIndex.CustomerId, value); }
		}

		/// <summary> The Status property of the Entity CallRoundCallQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallRoundCallQueue"."Status"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Status
		{
			get { return (System.Int64)GetValue((int)CallRoundCallQueueFieldIndex.Status, true); }
			set	{ SetValue((int)CallRoundCallQueueFieldIndex.Status, value); }
		}

		/// <summary> The DateCreated property of the Entity CallRoundCallQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallRoundCallQueue"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)CallRoundCallQueueFieldIndex.DateCreated, true); }
			set	{ SetValue((int)CallRoundCallQueueFieldIndex.DateCreated, value); }
		}

		/// <summary> The ModifiedBy property of the Entity CallRoundCallQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallRoundCallQueue"."ModifiedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedBy
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallRoundCallQueueFieldIndex.ModifiedBy, false); }
			set	{ SetValue((int)CallRoundCallQueueFieldIndex.ModifiedBy, value); }
		}

		/// <summary> The DateModified property of the Entity CallRoundCallQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallRoundCallQueue"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CallRoundCallQueueFieldIndex.DateModified, false); }
			set	{ SetValue((int)CallRoundCallQueueFieldIndex.DateModified, value); }
		}

		/// <summary> The CallDate property of the Entity CallRoundCallQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallRoundCallQueue"."CallDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime CallDate
		{
			get { return (System.DateTime)GetValue((int)CallRoundCallQueueFieldIndex.CallDate, true); }
			set	{ SetValue((int)CallRoundCallQueueFieldIndex.CallDate, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallRoundCallQueueCriteriaAssignmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallRoundCallQueueCriteriaAssignmentEntity))]
		public virtual EntityCollection<CallRoundCallQueueCriteriaAssignmentEntity> CallRoundCallQueueCriteriaAssignment
		{
			get
			{
				if(_callRoundCallQueueCriteriaAssignment==null)
				{
					_callRoundCallQueueCriteriaAssignment = new EntityCollection<CallRoundCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallRoundCallQueueCriteriaAssignmentEntityFactory)));
					_callRoundCallQueueCriteriaAssignment.SetContainingEntityInfo(this, "CallRoundCallQueue");
				}
				return _callRoundCallQueueCriteriaAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HealthPlanCallQueueCriteriaEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HealthPlanCallQueueCriteriaEntity))]
		public virtual EntityCollection<HealthPlanCallQueueCriteriaEntity> HealthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment
		{
			get
			{
				if(_healthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment==null)
				{
					_healthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment = new EntityCollection<HealthPlanCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaEntityFactory)));
					_healthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment.IsReadOnly=true;
				}
				return _healthPlanCallQueueCriteriaCollectionViaCallRoundCallQueueCriteriaAssignment;
			}
		}

		/// <summary> Gets / sets related entity of type 'AccountEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AccountEntity Account
		{
			get
			{
				return _account;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAccount(value);
				}
				else
				{
					if(value==null)
					{
						if(_account != null)
						{
							_account.UnsetRelatedEntity(this, "CallRoundCallQueue");
						}
					}
					else
					{
						if(_account!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallRoundCallQueue");
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
							_customerProfile.UnsetRelatedEntity(this, "CallRoundCallQueue");
						}
					}
					else
					{
						if(_customerProfile!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallRoundCallQueue");
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
							_lookup.UnsetRelatedEntity(this, "CallRoundCallQueue");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallRoundCallQueue");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "CallRoundCallQueue");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallRoundCallQueue");
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
			get { return (int)Falcon.Data.EntityType.CallRoundCallQueueEntity; }
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
