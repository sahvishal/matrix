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
	/// Entity class which represents the entity 'CustomerEventTestIncidentalFinding'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CustomerEventTestIncidentalFindingEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CustomerEventTestIncidentalFindingDetailEntity> _customerEventTestIncidentalFindingDetail;
		private EntityCollection<IncidentalFindingReadingGroupItemEntity> _incidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail;
		private CustomerEventScreeningTestsEntity _customerEventScreeningTests;
		private IncidentalFindingsEntity _incidentalFindings;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CustomerEventScreeningTests</summary>
			public static readonly string CustomerEventScreeningTests = "CustomerEventScreeningTests";
			/// <summary>Member name IncidentalFindings</summary>
			public static readonly string IncidentalFindings = "IncidentalFindings";
			/// <summary>Member name CustomerEventTestIncidentalFindingDetail</summary>
			public static readonly string CustomerEventTestIncidentalFindingDetail = "CustomerEventTestIncidentalFindingDetail";
			/// <summary>Member name IncidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail</summary>
			public static readonly string IncidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail = "IncidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CustomerEventTestIncidentalFindingEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CustomerEventTestIncidentalFindingEntity():base("CustomerEventTestIncidentalFindingEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CustomerEventTestIncidentalFindingEntity(IEntityFields2 fields):base("CustomerEventTestIncidentalFindingEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CustomerEventTestIncidentalFindingEntity</param>
		public CustomerEventTestIncidentalFindingEntity(IValidator validator):base("CustomerEventTestIncidentalFindingEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="customerEventTestIncidentalFindingId">PK value for CustomerEventTestIncidentalFinding which data should be fetched into this CustomerEventTestIncidentalFinding object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CustomerEventTestIncidentalFindingEntity(System.Int64 customerEventTestIncidentalFindingId):base("CustomerEventTestIncidentalFindingEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CustomerEventTestIncidentalFindingId = customerEventTestIncidentalFindingId;
		}

		/// <summary> CTor</summary>
		/// <param name="customerEventTestIncidentalFindingId">PK value for CustomerEventTestIncidentalFinding which data should be fetched into this CustomerEventTestIncidentalFinding object</param>
		/// <param name="validator">The custom validator object for this CustomerEventTestIncidentalFindingEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CustomerEventTestIncidentalFindingEntity(System.Int64 customerEventTestIncidentalFindingId, IValidator validator):base("CustomerEventTestIncidentalFindingEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CustomerEventTestIncidentalFindingId = customerEventTestIncidentalFindingId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CustomerEventTestIncidentalFindingEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_customerEventTestIncidentalFindingDetail = (EntityCollection<CustomerEventTestIncidentalFindingDetailEntity>)info.GetValue("_customerEventTestIncidentalFindingDetail", typeof(EntityCollection<CustomerEventTestIncidentalFindingDetailEntity>));
				_incidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail = (EntityCollection<IncidentalFindingReadingGroupItemEntity>)info.GetValue("_incidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail", typeof(EntityCollection<IncidentalFindingReadingGroupItemEntity>));
				_customerEventScreeningTests = (CustomerEventScreeningTestsEntity)info.GetValue("_customerEventScreeningTests", typeof(CustomerEventScreeningTestsEntity));
				if(_customerEventScreeningTests!=null)
				{
					_customerEventScreeningTests.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_incidentalFindings = (IncidentalFindingsEntity)info.GetValue("_incidentalFindings", typeof(IncidentalFindingsEntity));
				if(_incidentalFindings!=null)
				{
					_incidentalFindings.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((CustomerEventTestIncidentalFindingFieldIndex)fieldIndex)
			{
				case CustomerEventTestIncidentalFindingFieldIndex.CustomerEventScreeningTestId:
					DesetupSyncCustomerEventScreeningTests(true, false);
					break;
				case CustomerEventTestIncidentalFindingFieldIndex.IncidentalFindingId:
					DesetupSyncIncidentalFindings(true, false);
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
				case "CustomerEventScreeningTests":
					this.CustomerEventScreeningTests = (CustomerEventScreeningTestsEntity)entity;
					break;
				case "IncidentalFindings":
					this.IncidentalFindings = (IncidentalFindingsEntity)entity;
					break;
				case "CustomerEventTestIncidentalFindingDetail":
					this.CustomerEventTestIncidentalFindingDetail.Add((CustomerEventTestIncidentalFindingDetailEntity)entity);
					break;
				case "IncidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail":
					this.IncidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail.IsReadOnly = false;
					this.IncidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail.Add((IncidentalFindingReadingGroupItemEntity)entity);
					this.IncidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail.IsReadOnly = true;
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
			return CustomerEventTestIncidentalFindingEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "CustomerEventScreeningTests":
					toReturn.Add(CustomerEventTestIncidentalFindingEntity.Relations.CustomerEventScreeningTestsEntityUsingCustomerEventScreeningTestId);
					break;
				case "IncidentalFindings":
					toReturn.Add(CustomerEventTestIncidentalFindingEntity.Relations.IncidentalFindingsEntityUsingIncidentalFindingId);
					break;
				case "CustomerEventTestIncidentalFindingDetail":
					toReturn.Add(CustomerEventTestIncidentalFindingEntity.Relations.CustomerEventTestIncidentalFindingDetailEntityUsingCustomerEventTestIncidentalFindingId);
					break;
				case "IncidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail":
					toReturn.Add(CustomerEventTestIncidentalFindingEntity.Relations.CustomerEventTestIncidentalFindingDetailEntityUsingCustomerEventTestIncidentalFindingId, "CustomerEventTestIncidentalFindingEntity__", "CustomerEventTestIncidentalFindingDetail_", JoinHint.None);
					toReturn.Add(CustomerEventTestIncidentalFindingDetailEntity.Relations.IncidentalFindingReadingGroupItemEntityUsingGroupItemId, "CustomerEventTestIncidentalFindingDetail_", string.Empty, JoinHint.None);
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
				case "CustomerEventScreeningTests":
					SetupSyncCustomerEventScreeningTests(relatedEntity);
					break;
				case "IncidentalFindings":
					SetupSyncIncidentalFindings(relatedEntity);
					break;
				case "CustomerEventTestIncidentalFindingDetail":
					this.CustomerEventTestIncidentalFindingDetail.Add((CustomerEventTestIncidentalFindingDetailEntity)relatedEntity);
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
				case "CustomerEventScreeningTests":
					DesetupSyncCustomerEventScreeningTests(false, true);
					break;
				case "IncidentalFindings":
					DesetupSyncIncidentalFindings(false, true);
					break;
				case "CustomerEventTestIncidentalFindingDetail":
					base.PerformRelatedEntityRemoval(this.CustomerEventTestIncidentalFindingDetail, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_customerEventScreeningTests!=null)
			{
				toReturn.Add(_customerEventScreeningTests);
			}
			if(_incidentalFindings!=null)
			{
				toReturn.Add(_incidentalFindings);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CustomerEventTestIncidentalFindingDetail);

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
				info.AddValue("_customerEventTestIncidentalFindingDetail", ((_customerEventTestIncidentalFindingDetail!=null) && (_customerEventTestIncidentalFindingDetail.Count>0) && !this.MarkedForDeletion)?_customerEventTestIncidentalFindingDetail:null);
				info.AddValue("_incidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail", ((_incidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail!=null) && (_incidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail.Count>0) && !this.MarkedForDeletion)?_incidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail:null);
				info.AddValue("_customerEventScreeningTests", (!this.MarkedForDeletion?_customerEventScreeningTests:null));
				info.AddValue("_incidentalFindings", (!this.MarkedForDeletion?_incidentalFindings:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(CustomerEventTestIncidentalFindingFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CustomerEventTestIncidentalFindingFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CustomerEventTestIncidentalFindingRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerEventTestIncidentalFindingDetail' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventTestIncidentalFindingDetail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventTestIncidentalFindingDetailFields.CustomerEventTestIncidentalFindingId, null, ComparisonOperator.Equal, this.CustomerEventTestIncidentalFindingId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'IncidentalFindingReadingGroupItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoIncidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("IncidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventTestIncidentalFindingFields.CustomerEventTestIncidentalFindingId, null, ComparisonOperator.Equal, this.CustomerEventTestIncidentalFindingId, "CustomerEventTestIncidentalFindingEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerEventScreeningTests' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerEventScreeningTests()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerEventScreeningTestsFields.CustomerEventScreeningTestId, null, ComparisonOperator.Equal, this.CustomerEventScreeningTestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'IncidentalFindings' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoIncidentalFindings()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(IncidentalFindingsFields.IncidentalFindingsId, null, ComparisonOperator.Equal, this.IncidentalFindingId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CustomerEventTestIncidentalFindingEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestIncidentalFindingEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._customerEventTestIncidentalFindingDetail);
			collectionsQueue.Enqueue(this._incidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._customerEventTestIncidentalFindingDetail = (EntityCollection<CustomerEventTestIncidentalFindingDetailEntity>) collectionsQueue.Dequeue();
			this._incidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail = (EntityCollection<IncidentalFindingReadingGroupItemEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._customerEventTestIncidentalFindingDetail != null)
			{
				return true;
			}
			if (this._incidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerEventTestIncidentalFindingDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestIncidentalFindingDetailEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<IncidentalFindingReadingGroupItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingReadingGroupItemEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("CustomerEventScreeningTests", _customerEventScreeningTests);
			toReturn.Add("IncidentalFindings", _incidentalFindings);
			toReturn.Add("CustomerEventTestIncidentalFindingDetail", _customerEventTestIncidentalFindingDetail);
			toReturn.Add("IncidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail", _incidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_customerEventTestIncidentalFindingDetail!=null)
			{
				_customerEventTestIncidentalFindingDetail.ActiveContext = base.ActiveContext;
			}
			if(_incidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail!=null)
			{
				_incidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail.ActiveContext = base.ActiveContext;
			}
			if(_customerEventScreeningTests!=null)
			{
				_customerEventScreeningTests.ActiveContext = base.ActiveContext;
			}
			if(_incidentalFindings!=null)
			{
				_incidentalFindings.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_customerEventTestIncidentalFindingDetail = null;
			_incidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail = null;
			_customerEventScreeningTests = null;
			_incidentalFindings = null;

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

			_fieldsCustomProperties.Add("CustomerEventTestIncidentalFindingId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerEventScreeningTestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IncidentalFindingId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedOn", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _customerEventScreeningTests</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerEventScreeningTests(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerEventScreeningTests, new PropertyChangedEventHandler( OnCustomerEventScreeningTestsPropertyChanged ), "CustomerEventScreeningTests", CustomerEventTestIncidentalFindingEntity.Relations.CustomerEventScreeningTestsEntityUsingCustomerEventScreeningTestId, true, signalRelatedEntity, "CustomerEventTestIncidentalFinding", resetFKFields, new int[] { (int)CustomerEventTestIncidentalFindingFieldIndex.CustomerEventScreeningTestId } );		
			_customerEventScreeningTests = null;
		}

		/// <summary> setups the sync logic for member _customerEventScreeningTests</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerEventScreeningTests(IEntity2 relatedEntity)
		{
			if(_customerEventScreeningTests!=relatedEntity)
			{
				DesetupSyncCustomerEventScreeningTests(true, true);
				_customerEventScreeningTests = (CustomerEventScreeningTestsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerEventScreeningTests, new PropertyChangedEventHandler( OnCustomerEventScreeningTestsPropertyChanged ), "CustomerEventScreeningTests", CustomerEventTestIncidentalFindingEntity.Relations.CustomerEventScreeningTestsEntityUsingCustomerEventScreeningTestId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerEventScreeningTestsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _incidentalFindings</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncIncidentalFindings(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _incidentalFindings, new PropertyChangedEventHandler( OnIncidentalFindingsPropertyChanged ), "IncidentalFindings", CustomerEventTestIncidentalFindingEntity.Relations.IncidentalFindingsEntityUsingIncidentalFindingId, true, signalRelatedEntity, "CustomerEventTestIncidentalFinding", resetFKFields, new int[] { (int)CustomerEventTestIncidentalFindingFieldIndex.IncidentalFindingId } );		
			_incidentalFindings = null;
		}

		/// <summary> setups the sync logic for member _incidentalFindings</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncIncidentalFindings(IEntity2 relatedEntity)
		{
			if(_incidentalFindings!=relatedEntity)
			{
				DesetupSyncIncidentalFindings(true, true);
				_incidentalFindings = (IncidentalFindingsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _incidentalFindings, new PropertyChangedEventHandler( OnIncidentalFindingsPropertyChanged ), "IncidentalFindings", CustomerEventTestIncidentalFindingEntity.Relations.IncidentalFindingsEntityUsingIncidentalFindingId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnIncidentalFindingsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this CustomerEventTestIncidentalFindingEntity</param>
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
		public  static CustomerEventTestIncidentalFindingRelations Relations
		{
			get	{ return new CustomerEventTestIncidentalFindingRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventTestIncidentalFindingDetail' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventTestIncidentalFindingDetail
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerEventTestIncidentalFindingDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestIncidentalFindingDetailEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerEventTestIncidentalFindingDetail")[0], (int)Falcon.Data.EntityType.CustomerEventTestIncidentalFindingEntity, (int)Falcon.Data.EntityType.CustomerEventTestIncidentalFindingDetailEntity, 0, null, null, null, null, "CustomerEventTestIncidentalFindingDetail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'IncidentalFindingReadingGroupItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathIncidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerEventTestIncidentalFindingEntity.Relations.CustomerEventTestIncidentalFindingDetailEntityUsingCustomerEventTestIncidentalFindingId;
				intermediateRelation.SetAliases(string.Empty, "CustomerEventTestIncidentalFindingDetail_");
				return new PrefetchPathElement2(new EntityCollection<IncidentalFindingReadingGroupItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingReadingGroupItemEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerEventTestIncidentalFindingEntity, (int)Falcon.Data.EntityType.IncidentalFindingReadingGroupItemEntity, 0, null, null, GetRelationsForField("IncidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail"), null, "IncidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerEventScreeningTests' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerEventScreeningTests
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventScreeningTestsEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerEventScreeningTests")[0], (int)Falcon.Data.EntityType.CustomerEventTestIncidentalFindingEntity, (int)Falcon.Data.EntityType.CustomerEventScreeningTestsEntity, 0, null, null, null, null, "CustomerEventScreeningTests", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'IncidentalFindings' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathIncidentalFindings
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingsEntityFactory))),
					(IEntityRelation)GetRelationsForField("IncidentalFindings")[0], (int)Falcon.Data.EntityType.CustomerEventTestIncidentalFindingEntity, (int)Falcon.Data.EntityType.IncidentalFindingsEntity, 0, null, null, null, null, "IncidentalFindings", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CustomerEventTestIncidentalFindingEntity.CustomProperties;}
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
			get { return CustomerEventTestIncidentalFindingEntity.FieldsCustomProperties;}
		}

		/// <summary> The CustomerEventTestIncidentalFindingId property of the Entity CustomerEventTestIncidentalFinding<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerEventTestIncidentalFinding"."CustomerEventTestIncidentalFindingId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 CustomerEventTestIncidentalFindingId
		{
			get { return (System.Int64)GetValue((int)CustomerEventTestIncidentalFindingFieldIndex.CustomerEventTestIncidentalFindingId, true); }
			set	{ SetValue((int)CustomerEventTestIncidentalFindingFieldIndex.CustomerEventTestIncidentalFindingId, value); }
		}

		/// <summary> The CustomerEventScreeningTestId property of the Entity CustomerEventTestIncidentalFinding<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerEventTestIncidentalFinding"."CustomerEventScreeningTestId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerEventScreeningTestId
		{
			get { return (System.Int64)GetValue((int)CustomerEventTestIncidentalFindingFieldIndex.CustomerEventScreeningTestId, true); }
			set	{ SetValue((int)CustomerEventTestIncidentalFindingFieldIndex.CustomerEventScreeningTestId, value); }
		}

		/// <summary> The IncidentalFindingId property of the Entity CustomerEventTestIncidentalFinding<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerEventTestIncidentalFinding"."IncidentalFindingId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 IncidentalFindingId
		{
			get { return (System.Int64)GetValue((int)CustomerEventTestIncidentalFindingFieldIndex.IncidentalFindingId, true); }
			set	{ SetValue((int)CustomerEventTestIncidentalFindingFieldIndex.IncidentalFindingId, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity CustomerEventTestIncidentalFinding<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerEventTestIncidentalFinding"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)CustomerEventTestIncidentalFindingFieldIndex.CreatedByOrgRoleUserId, true); }
			set	{ SetValue((int)CustomerEventTestIncidentalFindingFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The CreatedOn property of the Entity CustomerEventTestIncidentalFinding<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerEventTestIncidentalFinding"."CreatedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime CreatedOn
		{
			get { return (System.DateTime)GetValue((int)CustomerEventTestIncidentalFindingFieldIndex.CreatedOn, true); }
			set	{ SetValue((int)CustomerEventTestIncidentalFindingFieldIndex.CreatedOn, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerEventTestIncidentalFindingDetailEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerEventTestIncidentalFindingDetailEntity))]
		public virtual EntityCollection<CustomerEventTestIncidentalFindingDetailEntity> CustomerEventTestIncidentalFindingDetail
		{
			get
			{
				if(_customerEventTestIncidentalFindingDetail==null)
				{
					_customerEventTestIncidentalFindingDetail = new EntityCollection<CustomerEventTestIncidentalFindingDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerEventTestIncidentalFindingDetailEntityFactory)));
					_customerEventTestIncidentalFindingDetail.SetContainingEntityInfo(this, "CustomerEventTestIncidentalFinding");
				}
				return _customerEventTestIncidentalFindingDetail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'IncidentalFindingReadingGroupItemEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(IncidentalFindingReadingGroupItemEntity))]
		public virtual EntityCollection<IncidentalFindingReadingGroupItemEntity> IncidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail
		{
			get
			{
				if(_incidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail==null)
				{
					_incidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail = new EntityCollection<IncidentalFindingReadingGroupItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IncidentalFindingReadingGroupItemEntityFactory)));
					_incidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail.IsReadOnly=true;
				}
				return _incidentalFindingReadingGroupItemCollectionViaCustomerEventTestIncidentalFindingDetail;
			}
		}

		/// <summary> Gets / sets related entity of type 'CustomerEventScreeningTestsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerEventScreeningTestsEntity CustomerEventScreeningTests
		{
			get
			{
				return _customerEventScreeningTests;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerEventScreeningTests(value);
				}
				else
				{
					if(value==null)
					{
						if(_customerEventScreeningTests != null)
						{
							_customerEventScreeningTests.UnsetRelatedEntity(this, "CustomerEventTestIncidentalFinding");
						}
					}
					else
					{
						if(_customerEventScreeningTests!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerEventTestIncidentalFinding");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'IncidentalFindingsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual IncidentalFindingsEntity IncidentalFindings
		{
			get
			{
				return _incidentalFindings;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncIncidentalFindings(value);
				}
				else
				{
					if(value==null)
					{
						if(_incidentalFindings != null)
						{
							_incidentalFindings.UnsetRelatedEntity(this, "CustomerEventTestIncidentalFinding");
						}
					}
					else
					{
						if(_incidentalFindings!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerEventTestIncidentalFinding");
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
			get { return (int)Falcon.Data.EntityType.CustomerEventTestIncidentalFindingEntity; }
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
