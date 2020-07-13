///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:49
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
	/// Entity class which represents the entity 'TestNotPerformedReason'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class TestNotPerformedReasonEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<TestNotPerformedEntity> _testNotPerformed;
		private EntityCollection<CustomerEventScreeningTestsEntity> _customerEventScreeningTestsCollectionViaTestNotPerformed;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaTestNotPerformed_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaTestNotPerformed;
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
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name TestNotPerformed</summary>
			public static readonly string TestNotPerformed = "TestNotPerformed";
			/// <summary>Member name CustomerEventScreeningTestsCollectionViaTestNotPerformed</summary>
			public static readonly string CustomerEventScreeningTestsCollectionViaTestNotPerformed = "CustomerEventScreeningTestsCollectionViaTestNotPerformed";
			/// <summary>Member name OrganizationRoleUserCollectionViaTestNotPerformed_</summary>
			public static readonly string OrganizationRoleUserCollectionViaTestNotPerformed_ = "OrganizationRoleUserCollectionViaTestNotPerformed_";
			/// <summary>Member name OrganizationRoleUserCollectionViaTestNotPerformed</summary>
			public static readonly string OrganizationRoleUserCollectionViaTestNotPerformed = "OrganizationRoleUserCollectionViaTestNotPerformed";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static TestNotPerformedReasonEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public TestNotPerformedReasonEntity():base("TestNotPerformedReasonEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public TestNotPerformedReasonEntity(IEntityFields2 fields):base("TestNotPerformedReasonEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this TestNotPerformedReasonEntity</param>
		public TestNotPerformedReasonEntity(IValidator validator):base("TestNotPerformedReasonEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for TestNotPerformedReason which data should be fetched into this TestNotPerformedReason object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TestNotPerformedReasonEntity(System.Int64 id):base("TestNotPerformedReasonEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for TestNotPerformedReason which data should be fetched into this TestNotPerformedReason object</param>
		/// <param name="validator">The custom validator object for this TestNotPerformedReasonEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TestNotPerformedReasonEntity(System.Int64 id, IValidator validator):base("TestNotPerformedReasonEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected TestNotPerformedReasonEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_testNotPerformed = (EntityCollection<TestNotPerformedEntity>)info.GetValue("_testNotPerformed", typeof(EntityCollection<TestNotPerformedEntity>));
				_customerEventScreeningTestsCollectionViaTestNotPerformed = (EntityCollection<CustomerEventScreeningTestsEntity>)info.GetValue("_customerEventScreeningTestsCollectionViaTestNotPerformed", typeof(EntityCollection<CustomerEventScreeningTestsEntity>));
				_organizationRoleUserCollectionViaTestNotPerformed_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaTestNotPerformed_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaTestNotPerformed = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaTestNotPerformed", typeof(EntityCollection<OrganizationRoleUserEntity>));
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
			switch((TestNotPerformedReasonFieldIndex)fieldIndex)
			{
				case TestNotPerformedReasonFieldIndex.CreatedBy:
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
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "TestNotPerformed":
					this.TestNotPerformed.Add((TestNotPerformedEntity)entity);
					break;
				case "CustomerEventScreeningTestsCollectionViaTestNotPerformed":
					this.CustomerEventScreeningTestsCollectionViaTestNotPerformed.IsReadOnly = false;
					this.CustomerEventScreeningTestsCollectionViaTestNotPerformed.Add((CustomerEventScreeningTestsEntity)entity);
					this.CustomerEventScreeningTestsCollectionViaTestNotPerformed.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaTestNotPerformed_":
					this.OrganizationRoleUserCollectionViaTestNotPerformed_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaTestNotPerformed_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaTestNotPerformed_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaTestNotPerformed":
					this.OrganizationRoleUserCollectionViaTestNotPerformed.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaTestNotPerformed.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaTestNotPerformed.IsReadOnly = true;
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
			return TestNotPerformedReasonEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "OrganizationRoleUser":
					toReturn.Add(TestNotPerformedReasonEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy);
					break;
				case "TestNotPerformed":
					toReturn.Add(TestNotPerformedReasonEntity.Relations.TestNotPerformedEntityUsingTestNotPerformedReasonId);
					break;
				case "CustomerEventScreeningTestsCollectionViaTestNotPerformed":
					toReturn.Add(TestNotPerformedReasonEntity.Relations.TestNotPerformedEntityUsingTestNotPerformedReasonId, "TestNotPerformedReasonEntity__", "TestNotPerformed_", JoinHint.None);
					toReturn.Add(TestNotPerformedEntity.Relations.CustomerEventScreeningTestsEntityUsingCustomerEventScreeningTestId, "TestNotPerformed_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaTestNotPerformed_":
					toReturn.Add(TestNotPerformedReasonEntity.Relations.TestNotPerformedEntityUsingTestNotPerformedReasonId, "TestNotPerformedReasonEntity__", "TestNotPerformed_", JoinHint.None);
					toReturn.Add(TestNotPerformedEntity.Relations.OrganizationRoleUserEntityUsingUpdatedBy, "TestNotPerformed_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaTestNotPerformed":
					toReturn.Add(TestNotPerformedReasonEntity.Relations.TestNotPerformedEntityUsingTestNotPerformedReasonId, "TestNotPerformedReasonEntity__", "TestNotPerformed_", JoinHint.None);
					toReturn.Add(TestNotPerformedEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "TestNotPerformed_", string.Empty, JoinHint.None);
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
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "TestNotPerformed":
					this.TestNotPerformed.Add((TestNotPerformedEntity)relatedEntity);
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
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "TestNotPerformed":
					base.PerformRelatedEntityRemoval(this.TestNotPerformed, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.TestNotPerformed);

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
				info.AddValue("_testNotPerformed", ((_testNotPerformed!=null) && (_testNotPerformed.Count>0) && !this.MarkedForDeletion)?_testNotPerformed:null);
				info.AddValue("_customerEventScreeningTestsCollectionViaTestNotPerformed", ((_customerEventScreeningTestsCollectionViaTestNotPerformed!=null) && (_customerEventScreeningTestsCollectionViaTestNotPerformed.Count>0) && !this.MarkedForDeletion)?_customerEventScreeningTestsCollectionViaTestNotPerformed:null);
				info.AddValue("_organizationRoleUserCollectionViaTestNotPerformed_", ((_organizationRoleUserCollectionViaTestNotPerformed_!=null) && (_organizationRoleUserCollectionViaTestNotPerformed_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaTestNotPerformed_:null);
				info.AddValue("_organizationRoleUserCollectionViaTestNotPerformed", ((_organizationRoleUserCollectionViaTestNotPerformed!=null) && (_organizationRoleUserCollectionViaTestNotPerformed.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaTestNotPerformed:null);
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
		public bool TestOriginalFieldValueForNull(TestNotPerformedReasonFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(TestNotPerformedReasonFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new TestNotPerformedReasonRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TestNotPerformed' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestNotPerformed()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestNotPerformedFields.TestNotPerformedReasonId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerEventScreeningTests' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventScreeningTestsCollectionViaTestNotPerformed()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerEventScreeningTestsCollectionViaTestNotPerformed"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestNotPerformedReasonFields.Id, null, ComparisonOperator.Equal, this.Id, "TestNotPerformedReasonEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaTestNotPerformed_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaTestNotPerformed_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestNotPerformedReasonFields.Id, null, ComparisonOperator.Equal, this.Id, "TestNotPerformedReasonEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaTestNotPerformed()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaTestNotPerformed"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestNotPerformedReasonFields.Id, null, ComparisonOperator.Equal, this.Id, "TestNotPerformedReasonEntity__"));
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

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.TestNotPerformedReasonEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(TestNotPerformedReasonEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._testNotPerformed);
			collectionsQueue.Enqueue(this._customerEventScreeningTestsCollectionViaTestNotPerformed);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaTestNotPerformed_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaTestNotPerformed);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._testNotPerformed = (EntityCollection<TestNotPerformedEntity>) collectionsQueue.Dequeue();
			this._customerEventScreeningTestsCollectionViaTestNotPerformed = (EntityCollection<CustomerEventScreeningTestsEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaTestNotPerformed_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaTestNotPerformed = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._testNotPerformed != null)
			{
				return true;
			}
			if (this._customerEventScreeningTestsCollectionViaTestNotPerformed != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaTestNotPerformed_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaTestNotPerformed != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestNotPerformedEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestNotPerformedEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerEventScreeningTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventScreeningTestsEntityFactory))) : null);
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
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("TestNotPerformed", _testNotPerformed);
			toReturn.Add("CustomerEventScreeningTestsCollectionViaTestNotPerformed", _customerEventScreeningTestsCollectionViaTestNotPerformed);
			toReturn.Add("OrganizationRoleUserCollectionViaTestNotPerformed_", _organizationRoleUserCollectionViaTestNotPerformed_);
			toReturn.Add("OrganizationRoleUserCollectionViaTestNotPerformed", _organizationRoleUserCollectionViaTestNotPerformed);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_testNotPerformed!=null)
			{
				_testNotPerformed.ActiveContext = base.ActiveContext;
			}
			if(_customerEventScreeningTestsCollectionViaTestNotPerformed!=null)
			{
				_customerEventScreeningTestsCollectionViaTestNotPerformed.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaTestNotPerformed_!=null)
			{
				_organizationRoleUserCollectionViaTestNotPerformed_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaTestNotPerformed!=null)
			{
				_organizationRoleUserCollectionViaTestNotPerformed.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_testNotPerformed = null;
			_customerEventScreeningTestsCollectionViaTestNotPerformed = null;
			_organizationRoleUserCollectionViaTestNotPerformed_ = null;
			_organizationRoleUserCollectionViaTestNotPerformed = null;
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

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Alias", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedOn", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organizationRoleUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", TestNotPerformedReasonEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, signalRelatedEntity, "TestNotPerformedReason", resetFKFields, new int[] { (int)TestNotPerformedReasonFieldIndex.CreatedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", TestNotPerformedReasonEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this TestNotPerformedReasonEntity</param>
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
		public  static TestNotPerformedReasonRelations Relations
		{
			get	{ return new TestNotPerformedReasonRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TestNotPerformed' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestNotPerformed
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TestNotPerformedEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestNotPerformedEntityFactory))),
					(IEntityRelation)GetRelationsForField("TestNotPerformed")[0], (int)Falcon.Data.EntityType.TestNotPerformedReasonEntity, (int)Falcon.Data.EntityType.TestNotPerformedEntity, 0, null, null, null, null, "TestNotPerformed", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventScreeningTests' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventScreeningTestsCollectionViaTestNotPerformed
		{
			get
			{
				IEntityRelation intermediateRelation = TestNotPerformedReasonEntity.Relations.TestNotPerformedEntityUsingTestNotPerformedReasonId;
				intermediateRelation.SetAliases(string.Empty, "TestNotPerformed_");
				return new PrefetchPathElement2(new EntityCollection<CustomerEventScreeningTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventScreeningTestsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestNotPerformedReasonEntity, (int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, 0, null, null, GetRelationsForField("CustomerEventScreeningTestsCollectionViaTestNotPerformed"), null, "CustomerEventScreeningTestsCollectionViaTestNotPerformed", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaTestNotPerformed_
		{
			get
			{
				IEntityRelation intermediateRelation = TestNotPerformedReasonEntity.Relations.TestNotPerformedEntityUsingTestNotPerformedReasonId;
				intermediateRelation.SetAliases(string.Empty, "TestNotPerformed_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestNotPerformedReasonEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaTestNotPerformed_"), null, "OrganizationRoleUserCollectionViaTestNotPerformed_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaTestNotPerformed
		{
			get
			{
				IEntityRelation intermediateRelation = TestNotPerformedReasonEntity.Relations.TestNotPerformedEntityUsingTestNotPerformedReasonId;
				intermediateRelation.SetAliases(string.Empty, "TestNotPerformed_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestNotPerformedReasonEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaTestNotPerformed"), null, "OrganizationRoleUserCollectionViaTestNotPerformed", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.TestNotPerformedReasonEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return TestNotPerformedReasonEntity.CustomProperties;}
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
			get { return TestNotPerformedReasonEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity TestNotPerformedReason<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTestNotPerformedReason"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)TestNotPerformedReasonFieldIndex.Id, true); }
			set	{ SetValue((int)TestNotPerformedReasonFieldIndex.Id, value); }
		}

		/// <summary> The Name property of the Entity TestNotPerformedReason<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTestNotPerformedReason"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)TestNotPerformedReasonFieldIndex.Name, true); }
			set	{ SetValue((int)TestNotPerformedReasonFieldIndex.Name, value); }
		}

		/// <summary> The Alias property of the Entity TestNotPerformedReason<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTestNotPerformedReason"."Alias"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Alias
		{
			get { return (System.String)GetValue((int)TestNotPerformedReasonFieldIndex.Alias, true); }
			set	{ SetValue((int)TestNotPerformedReasonFieldIndex.Alias, value); }
		}

		/// <summary> The CreatedBy property of the Entity TestNotPerformedReason<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTestNotPerformedReason"."CreatedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedBy
		{
			get { return (System.Int64)GetValue((int)TestNotPerformedReasonFieldIndex.CreatedBy, true); }
			set	{ SetValue((int)TestNotPerformedReasonFieldIndex.CreatedBy, value); }
		}

		/// <summary> The CreatedOn property of the Entity TestNotPerformedReason<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTestNotPerformedReason"."CreatedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> CreatedOn
		{
			get { return (Nullable<System.DateTime>)GetValue((int)TestNotPerformedReasonFieldIndex.CreatedOn, false); }
			set	{ SetValue((int)TestNotPerformedReasonFieldIndex.CreatedOn, value); }
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
					_testNotPerformed.SetContainingEntityInfo(this, "TestNotPerformedReason");
				}
				return _testNotPerformed;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerEventScreeningTestsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerEventScreeningTestsEntity))]
		public virtual EntityCollection<CustomerEventScreeningTestsEntity> CustomerEventScreeningTestsCollectionViaTestNotPerformed
		{
			get
			{
				if(_customerEventScreeningTestsCollectionViaTestNotPerformed==null)
				{
					_customerEventScreeningTestsCollectionViaTestNotPerformed = new EntityCollection<CustomerEventScreeningTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventScreeningTestsEntityFactory)));
					_customerEventScreeningTestsCollectionViaTestNotPerformed.IsReadOnly=true;
				}
				return _customerEventScreeningTestsCollectionViaTestNotPerformed;
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
							_organizationRoleUser.UnsetRelatedEntity(this, "TestNotPerformedReason");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "TestNotPerformedReason");
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
			get { return (int)Falcon.Data.EntityType.TestNotPerformedReasonEntity; }
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
