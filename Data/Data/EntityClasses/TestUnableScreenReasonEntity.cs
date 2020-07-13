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
	/// Entity class which represents the entity 'TestUnableScreenReason'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class TestUnableScreenReasonEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CustomerEventUnableScreenReasonEntity> _customerEventUnableScreenReason;
		private EntityCollection<CustomerEventScreeningTestsEntity> _customerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerEventUnableScreenReason;
		private LookupEntity _lookup;
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
			/// <summary>Member name Test</summary>
			public static readonly string Test = "Test";
			/// <summary>Member name CustomerEventUnableScreenReason</summary>
			public static readonly string CustomerEventUnableScreenReason = "CustomerEventUnableScreenReason";
			/// <summary>Member name CustomerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason</summary>
			public static readonly string CustomerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason = "CustomerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerEventUnableScreenReason</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerEventUnableScreenReason = "OrganizationRoleUserCollectionViaCustomerEventUnableScreenReason";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static TestUnableScreenReasonEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public TestUnableScreenReasonEntity():base("TestUnableScreenReasonEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public TestUnableScreenReasonEntity(IEntityFields2 fields):base("TestUnableScreenReasonEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this TestUnableScreenReasonEntity</param>
		public TestUnableScreenReasonEntity(IValidator validator):base("TestUnableScreenReasonEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="testUnableScreenReasonId">PK value for TestUnableScreenReason which data should be fetched into this TestUnableScreenReason object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TestUnableScreenReasonEntity(System.Byte testUnableScreenReasonId):base("TestUnableScreenReasonEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.TestUnableScreenReasonId = testUnableScreenReasonId;
		}

		/// <summary> CTor</summary>
		/// <param name="testUnableScreenReasonId">PK value for TestUnableScreenReason which data should be fetched into this TestUnableScreenReason object</param>
		/// <param name="validator">The custom validator object for this TestUnableScreenReasonEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TestUnableScreenReasonEntity(System.Byte testUnableScreenReasonId, IValidator validator):base("TestUnableScreenReasonEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.TestUnableScreenReasonId = testUnableScreenReasonId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected TestUnableScreenReasonEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_customerEventUnableScreenReason = (EntityCollection<CustomerEventUnableScreenReasonEntity>)info.GetValue("_customerEventUnableScreenReason", typeof(EntityCollection<CustomerEventUnableScreenReasonEntity>));
				_customerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason = (EntityCollection<CustomerEventScreeningTestsEntity>)info.GetValue("_customerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason", typeof(EntityCollection<CustomerEventScreeningTestsEntity>));
				_organizationRoleUserCollectionViaCustomerEventUnableScreenReason = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerEventUnableScreenReason", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((TestUnableScreenReasonFieldIndex)fieldIndex)
			{
				case TestUnableScreenReasonFieldIndex.TestId:
					DesetupSyncTest(true, false);
					break;
				case TestUnableScreenReasonFieldIndex.UnableScreenReasonId:
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
				case "Test":
					this.Test = (TestEntity)entity;
					break;
				case "CustomerEventUnableScreenReason":
					this.CustomerEventUnableScreenReason.Add((CustomerEventUnableScreenReasonEntity)entity);
					break;
				case "CustomerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason":
					this.CustomerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason.IsReadOnly = false;
					this.CustomerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason.Add((CustomerEventScreeningTestsEntity)entity);
					this.CustomerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerEventUnableScreenReason":
					this.OrganizationRoleUserCollectionViaCustomerEventUnableScreenReason.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerEventUnableScreenReason.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerEventUnableScreenReason.IsReadOnly = true;
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
			return TestUnableScreenReasonEntity.GetRelationsForField(fieldName);
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
					toReturn.Add(TestUnableScreenReasonEntity.Relations.LookupEntityUsingUnableScreenReasonId);
					break;
				case "Test":
					toReturn.Add(TestUnableScreenReasonEntity.Relations.TestEntityUsingTestId);
					break;
				case "CustomerEventUnableScreenReason":
					toReturn.Add(TestUnableScreenReasonEntity.Relations.CustomerEventUnableScreenReasonEntityUsingTestUnableScreenReasonId);
					break;
				case "CustomerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason":
					toReturn.Add(TestUnableScreenReasonEntity.Relations.CustomerEventUnableScreenReasonEntityUsingTestUnableScreenReasonId, "TestUnableScreenReasonEntity__", "CustomerEventUnableScreenReason_", JoinHint.None);
					toReturn.Add(CustomerEventUnableScreenReasonEntity.Relations.CustomerEventScreeningTestsEntityUsingCustomerEventScreeningTestId, "CustomerEventUnableScreenReason_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerEventUnableScreenReason":
					toReturn.Add(TestUnableScreenReasonEntity.Relations.CustomerEventUnableScreenReasonEntityUsingTestUnableScreenReasonId, "TestUnableScreenReasonEntity__", "CustomerEventUnableScreenReason_", JoinHint.None);
					toReturn.Add(CustomerEventUnableScreenReasonEntity.Relations.OrganizationRoleUserEntityUsingUpdatedByOrgRoleUserId, "CustomerEventUnableScreenReason_", string.Empty, JoinHint.None);
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
				case "Test":
					SetupSyncTest(relatedEntity);
					break;
				case "CustomerEventUnableScreenReason":
					this.CustomerEventUnableScreenReason.Add((CustomerEventUnableScreenReasonEntity)relatedEntity);
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
				case "Test":
					DesetupSyncTest(false, true);
					break;
				case "CustomerEventUnableScreenReason":
					base.PerformRelatedEntityRemoval(this.CustomerEventUnableScreenReason, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.CustomerEventUnableScreenReason);

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
				info.AddValue("_customerEventUnableScreenReason", ((_customerEventUnableScreenReason!=null) && (_customerEventUnableScreenReason.Count>0) && !this.MarkedForDeletion)?_customerEventUnableScreenReason:null);
				info.AddValue("_customerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason", ((_customerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason!=null) && (_customerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason.Count>0) && !this.MarkedForDeletion)?_customerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerEventUnableScreenReason", ((_organizationRoleUserCollectionViaCustomerEventUnableScreenReason!=null) && (_organizationRoleUserCollectionViaCustomerEventUnableScreenReason.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerEventUnableScreenReason:null);
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
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
		public bool TestOriginalFieldValueForNull(TestUnableScreenReasonFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(TestUnableScreenReasonFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new TestUnableScreenReasonRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerEventUnableScreenReason' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventUnableScreenReason()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventUnableScreenReasonFields.TestUnableScreenReasonId, null, ComparisonOperator.Equal, this.TestUnableScreenReasonId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerEventScreeningTests' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestUnableScreenReasonFields.TestUnableScreenReasonId, null, ComparisonOperator.Equal, this.TestUnableScreenReasonId, "TestUnableScreenReasonEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerEventUnableScreenReason()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerEventUnableScreenReason"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestUnableScreenReasonFields.TestUnableScreenReasonId, null, ComparisonOperator.Equal, this.TestUnableScreenReasonId, "TestUnableScreenReasonEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.UnableScreenReasonId));
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
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.TestUnableScreenReasonEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(TestUnableScreenReasonEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._customerEventUnableScreenReason);
			collectionsQueue.Enqueue(this._customerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerEventUnableScreenReason);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._customerEventUnableScreenReason = (EntityCollection<CustomerEventUnableScreenReasonEntity>) collectionsQueue.Dequeue();
			this._customerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason = (EntityCollection<CustomerEventScreeningTestsEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerEventUnableScreenReason = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._customerEventUnableScreenReason != null)
			{
				return true;
			}
			if (this._customerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerEventUnableScreenReason != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerEventUnableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventUnableScreenReasonEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerEventScreeningTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventScreeningTestsEntityFactory))) : null);
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
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("Test", _test);
			toReturn.Add("CustomerEventUnableScreenReason", _customerEventUnableScreenReason);
			toReturn.Add("CustomerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason", _customerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerEventUnableScreenReason", _organizationRoleUserCollectionViaCustomerEventUnableScreenReason);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_customerEventUnableScreenReason!=null)
			{
				_customerEventUnableScreenReason.ActiveContext = base.ActiveContext;
			}
			if(_customerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason!=null)
			{
				_customerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerEventUnableScreenReason!=null)
			{
				_organizationRoleUserCollectionViaCustomerEventUnableScreenReason.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_test!=null)
			{
				_test.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_customerEventUnableScreenReason = null;
			_customerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason = null;
			_organizationRoleUserCollectionViaCustomerEventUnableScreenReason = null;
			_lookup = null;
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

			_fieldsCustomProperties.Add("TestUnableScreenReasonId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UnableScreenReasonId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _lookup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", TestUnableScreenReasonEntity.Relations.LookupEntityUsingUnableScreenReasonId, true, signalRelatedEntity, "TestUnableScreenReason", resetFKFields, new int[] { (int)TestUnableScreenReasonFieldIndex.UnableScreenReasonId } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", TestUnableScreenReasonEntity.Relations.LookupEntityUsingUnableScreenReasonId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _test</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTest(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _test, new PropertyChangedEventHandler( OnTestPropertyChanged ), "Test", TestUnableScreenReasonEntity.Relations.TestEntityUsingTestId, true, signalRelatedEntity, "TestUnableScreenReason", resetFKFields, new int[] { (int)TestUnableScreenReasonFieldIndex.TestId } );		
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
				base.PerformSetupSyncRelatedEntity( _test, new PropertyChangedEventHandler( OnTestPropertyChanged ), "Test", TestUnableScreenReasonEntity.Relations.TestEntityUsingTestId, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this TestUnableScreenReasonEntity</param>
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
		public  static TestUnableScreenReasonRelations Relations
		{
			get	{ return new TestUnableScreenReasonRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventUnableScreenReason' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventUnableScreenReason
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerEventUnableScreenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventUnableScreenReasonEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerEventUnableScreenReason")[0], (int)Falcon.Data.EntityType.TestUnableScreenReasonEntity, (int)Falcon.Data.EntityType.CustomerEventUnableScreenReasonEntity, 0, null, null, null, null, "CustomerEventUnableScreenReason", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventScreeningTests' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason
		{
			get
			{
				IEntityRelation intermediateRelation = TestUnableScreenReasonEntity.Relations.CustomerEventUnableScreenReasonEntityUsingTestUnableScreenReasonId;
				intermediateRelation.SetAliases(string.Empty, "CustomerEventUnableScreenReason_");
				return new PrefetchPathElement2(new EntityCollection<CustomerEventScreeningTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventScreeningTestsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestUnableScreenReasonEntity, (int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, 0, null, null, GetRelationsForField("CustomerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason"), null, "CustomerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerEventUnableScreenReason
		{
			get
			{
				IEntityRelation intermediateRelation = TestUnableScreenReasonEntity.Relations.CustomerEventUnableScreenReasonEntityUsingTestUnableScreenReasonId;
				intermediateRelation.SetAliases(string.Empty, "CustomerEventUnableScreenReason_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.TestUnableScreenReasonEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerEventUnableScreenReason"), null, "OrganizationRoleUserCollectionViaCustomerEventUnableScreenReason", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.TestUnableScreenReasonEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Test")[0], (int)Falcon.Data.EntityType.TestUnableScreenReasonEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, null, null, "Test", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return TestUnableScreenReasonEntity.CustomProperties;}
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
			get { return TestUnableScreenReasonEntity.FieldsCustomProperties;}
		}

		/// <summary> The TestUnableScreenReasonId property of the Entity TestUnableScreenReason<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTestUnableScreenReason"."TestUnableScreenReasonId"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Byte TestUnableScreenReasonId
		{
			get { return (System.Byte)GetValue((int)TestUnableScreenReasonFieldIndex.TestUnableScreenReasonId, true); }
			set	{ SetValue((int)TestUnableScreenReasonFieldIndex.TestUnableScreenReasonId, value); }
		}

		/// <summary> The TestId property of the Entity TestUnableScreenReason<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTestUnableScreenReason"."TestId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TestId
		{
			get { return (System.Int64)GetValue((int)TestUnableScreenReasonFieldIndex.TestId, true); }
			set	{ SetValue((int)TestUnableScreenReasonFieldIndex.TestId, value); }
		}

		/// <summary> The UnableScreenReasonId property of the Entity TestUnableScreenReason<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTestUnableScreenReason"."UnableScreenReasonId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 UnableScreenReasonId
		{
			get { return (System.Int64)GetValue((int)TestUnableScreenReasonFieldIndex.UnableScreenReasonId, true); }
			set	{ SetValue((int)TestUnableScreenReasonFieldIndex.UnableScreenReasonId, value); }
		}

		/// <summary> The Description property of the Entity TestUnableScreenReason<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblTestUnableScreenReason"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)TestUnableScreenReasonFieldIndex.Description, true); }
			set	{ SetValue((int)TestUnableScreenReasonFieldIndex.Description, value); }
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
					_customerEventUnableScreenReason.SetContainingEntityInfo(this, "TestUnableScreenReason");
				}
				return _customerEventUnableScreenReason;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerEventScreeningTestsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerEventScreeningTestsEntity))]
		public virtual EntityCollection<CustomerEventScreeningTestsEntity> CustomerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason
		{
			get
			{
				if(_customerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason==null)
				{
					_customerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason = new EntityCollection<CustomerEventScreeningTestsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventScreeningTestsEntityFactory)));
					_customerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason.IsReadOnly=true;
				}
				return _customerEventScreeningTestsCollectionViaCustomerEventUnableScreenReason;
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
							_lookup.UnsetRelatedEntity(this, "TestUnableScreenReason");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "TestUnableScreenReason");
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
							_test.UnsetRelatedEntity(this, "TestUnableScreenReason");
						}
					}
					else
					{
						if(_test!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "TestUnableScreenReason");
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
			get { return (int)Falcon.Data.EntityType.TestUnableScreenReasonEntity; }
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
