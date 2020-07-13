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
	/// Entity class which represents the entity 'ChaseGroup'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ChaseGroupEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ChaseOutboundEntity> _chaseOutbound;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaChaseOutbound;
		private EntityCollection<LookupEntity> _lookupCollectionViaChaseOutbound;
		private EntityCollection<RelationshipEntity> _relationshipCollectionViaChaseOutbound;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name ChaseOutbound</summary>
			public static readonly string ChaseOutbound = "ChaseOutbound";
			/// <summary>Member name CustomerProfileCollectionViaChaseOutbound</summary>
			public static readonly string CustomerProfileCollectionViaChaseOutbound = "CustomerProfileCollectionViaChaseOutbound";
			/// <summary>Member name LookupCollectionViaChaseOutbound</summary>
			public static readonly string LookupCollectionViaChaseOutbound = "LookupCollectionViaChaseOutbound";
			/// <summary>Member name RelationshipCollectionViaChaseOutbound</summary>
			public static readonly string RelationshipCollectionViaChaseOutbound = "RelationshipCollectionViaChaseOutbound";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ChaseGroupEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ChaseGroupEntity():base("ChaseGroupEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ChaseGroupEntity(IEntityFields2 fields):base("ChaseGroupEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ChaseGroupEntity</param>
		public ChaseGroupEntity(IValidator validator):base("ChaseGroupEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="chaseGroupId">PK value for ChaseGroup which data should be fetched into this ChaseGroup object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ChaseGroupEntity(System.Int64 chaseGroupId):base("ChaseGroupEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ChaseGroupId = chaseGroupId;
		}

		/// <summary> CTor</summary>
		/// <param name="chaseGroupId">PK value for ChaseGroup which data should be fetched into this ChaseGroup object</param>
		/// <param name="validator">The custom validator object for this ChaseGroupEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ChaseGroupEntity(System.Int64 chaseGroupId, IValidator validator):base("ChaseGroupEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ChaseGroupId = chaseGroupId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ChaseGroupEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_chaseOutbound = (EntityCollection<ChaseOutboundEntity>)info.GetValue("_chaseOutbound", typeof(EntityCollection<ChaseOutboundEntity>));
				_customerProfileCollectionViaChaseOutbound = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaChaseOutbound", typeof(EntityCollection<CustomerProfileEntity>));
				_lookupCollectionViaChaseOutbound = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaChaseOutbound", typeof(EntityCollection<LookupEntity>));
				_relationshipCollectionViaChaseOutbound = (EntityCollection<RelationshipEntity>)info.GetValue("_relationshipCollectionViaChaseOutbound", typeof(EntityCollection<RelationshipEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((ChaseGroupFieldIndex)fieldIndex)
			{
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

				case "ChaseOutbound":
					this.ChaseOutbound.Add((ChaseOutboundEntity)entity);
					break;
				case "CustomerProfileCollectionViaChaseOutbound":
					this.CustomerProfileCollectionViaChaseOutbound.IsReadOnly = false;
					this.CustomerProfileCollectionViaChaseOutbound.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaChaseOutbound.IsReadOnly = true;
					break;
				case "LookupCollectionViaChaseOutbound":
					this.LookupCollectionViaChaseOutbound.IsReadOnly = false;
					this.LookupCollectionViaChaseOutbound.Add((LookupEntity)entity);
					this.LookupCollectionViaChaseOutbound.IsReadOnly = true;
					break;
				case "RelationshipCollectionViaChaseOutbound":
					this.RelationshipCollectionViaChaseOutbound.IsReadOnly = false;
					this.RelationshipCollectionViaChaseOutbound.Add((RelationshipEntity)entity);
					this.RelationshipCollectionViaChaseOutbound.IsReadOnly = true;
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
			return ChaseGroupEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "ChaseOutbound":
					toReturn.Add(ChaseGroupEntity.Relations.ChaseOutboundEntityUsingChaseGroupId);
					break;
				case "CustomerProfileCollectionViaChaseOutbound":
					toReturn.Add(ChaseGroupEntity.Relations.ChaseOutboundEntityUsingChaseGroupId, "ChaseGroupEntity__", "ChaseOutbound_", JoinHint.None);
					toReturn.Add(ChaseOutboundEntity.Relations.CustomerProfileEntityUsingCustomerId, "ChaseOutbound_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaChaseOutbound":
					toReturn.Add(ChaseGroupEntity.Relations.ChaseOutboundEntityUsingChaseGroupId, "ChaseGroupEntity__", "ChaseOutbound_", JoinHint.None);
					toReturn.Add(ChaseOutboundEntity.Relations.LookupEntityUsingConfidenceScoreId, "ChaseOutbound_", string.Empty, JoinHint.None);
					break;
				case "RelationshipCollectionViaChaseOutbound":
					toReturn.Add(ChaseGroupEntity.Relations.ChaseOutboundEntityUsingChaseGroupId, "ChaseGroupEntity__", "ChaseOutbound_", JoinHint.None);
					toReturn.Add(ChaseOutboundEntity.Relations.RelationshipEntityUsingRelationshipId, "ChaseOutbound_", string.Empty, JoinHint.None);
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

				case "ChaseOutbound":
					this.ChaseOutbound.Add((ChaseOutboundEntity)relatedEntity);
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

				case "ChaseOutbound":
					base.PerformRelatedEntityRemoval(this.ChaseOutbound, relatedEntity, signalRelatedEntityManyToOne);
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


			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.ChaseOutbound);

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
				info.AddValue("_chaseOutbound", ((_chaseOutbound!=null) && (_chaseOutbound.Count>0) && !this.MarkedForDeletion)?_chaseOutbound:null);
				info.AddValue("_customerProfileCollectionViaChaseOutbound", ((_customerProfileCollectionViaChaseOutbound!=null) && (_customerProfileCollectionViaChaseOutbound.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaChaseOutbound:null);
				info.AddValue("_lookupCollectionViaChaseOutbound", ((_lookupCollectionViaChaseOutbound!=null) && (_lookupCollectionViaChaseOutbound.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaChaseOutbound:null);
				info.AddValue("_relationshipCollectionViaChaseOutbound", ((_relationshipCollectionViaChaseOutbound!=null) && (_relationshipCollectionViaChaseOutbound.Count>0) && !this.MarkedForDeletion)?_relationshipCollectionViaChaseOutbound:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ChaseGroupFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ChaseGroupFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ChaseGroupRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChaseOutbound' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChaseOutbound()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaseOutboundFields.ChaseGroupId, null, ComparisonOperator.Equal, this.ChaseGroupId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaChaseOutbound()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaChaseOutbound"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaseGroupFields.ChaseGroupId, null, ComparisonOperator.Equal, this.ChaseGroupId, "ChaseGroupEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaChaseOutbound()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaChaseOutbound"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaseGroupFields.ChaseGroupId, null, ComparisonOperator.Equal, this.ChaseGroupId, "ChaseGroupEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Relationship' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRelationshipCollectionViaChaseOutbound()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("RelationshipCollectionViaChaseOutbound"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ChaseGroupFields.ChaseGroupId, null, ComparisonOperator.Equal, this.ChaseGroupId, "ChaseGroupEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ChaseGroupEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ChaseGroupEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._chaseOutbound);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaChaseOutbound);
			collectionsQueue.Enqueue(this._lookupCollectionViaChaseOutbound);
			collectionsQueue.Enqueue(this._relationshipCollectionViaChaseOutbound);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._chaseOutbound = (EntityCollection<ChaseOutboundEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaChaseOutbound = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaChaseOutbound = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._relationshipCollectionViaChaseOutbound = (EntityCollection<RelationshipEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._chaseOutbound != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaChaseOutbound != null)
			{
				return true;
			}
			if (this._lookupCollectionViaChaseOutbound != null)
			{
				return true;
			}
			if (this._relationshipCollectionViaChaseOutbound != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChaseOutboundEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseOutboundEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RelationshipEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RelationshipEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("ChaseOutbound", _chaseOutbound);
			toReturn.Add("CustomerProfileCollectionViaChaseOutbound", _customerProfileCollectionViaChaseOutbound);
			toReturn.Add("LookupCollectionViaChaseOutbound", _lookupCollectionViaChaseOutbound);
			toReturn.Add("RelationshipCollectionViaChaseOutbound", _relationshipCollectionViaChaseOutbound);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_chaseOutbound!=null)
			{
				_chaseOutbound.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaChaseOutbound!=null)
			{
				_customerProfileCollectionViaChaseOutbound.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaChaseOutbound!=null)
			{
				_lookupCollectionViaChaseOutbound.ActiveContext = base.ActiveContext;
			}
			if(_relationshipCollectionViaChaseOutbound!=null)
			{
				_relationshipCollectionViaChaseOutbound.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_chaseOutbound = null;
			_customerProfileCollectionViaChaseOutbound = null;
			_lookupCollectionViaChaseOutbound = null;
			_relationshipCollectionViaChaseOutbound = null;


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

			_fieldsCustomProperties.Add("ChaseGroupId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Number", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Division", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ChaseGroupEntity</param>
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
		public  static ChaseGroupRelations Relations
		{
			get	{ return new ChaseGroupRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChaseOutbound' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChaseOutbound
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ChaseOutboundEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseOutboundEntityFactory))),
					(IEntityRelation)GetRelationsForField("ChaseOutbound")[0], (int)Falcon.Data.EntityType.ChaseGroupEntity, (int)Falcon.Data.EntityType.ChaseOutboundEntity, 0, null, null, null, null, "ChaseOutbound", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaChaseOutbound
		{
			get
			{
				IEntityRelation intermediateRelation = ChaseGroupEntity.Relations.ChaseOutboundEntityUsingChaseGroupId;
				intermediateRelation.SetAliases(string.Empty, "ChaseOutbound_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChaseGroupEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaChaseOutbound"), null, "CustomerProfileCollectionViaChaseOutbound", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaChaseOutbound
		{
			get
			{
				IEntityRelation intermediateRelation = ChaseGroupEntity.Relations.ChaseOutboundEntityUsingChaseGroupId;
				intermediateRelation.SetAliases(string.Empty, "ChaseOutbound_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChaseGroupEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaChaseOutbound"), null, "LookupCollectionViaChaseOutbound", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Relationship' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRelationshipCollectionViaChaseOutbound
		{
			get
			{
				IEntityRelation intermediateRelation = ChaseGroupEntity.Relations.ChaseOutboundEntityUsingChaseGroupId;
				intermediateRelation.SetAliases(string.Empty, "ChaseOutbound_");
				return new PrefetchPathElement2(new EntityCollection<RelationshipEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RelationshipEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ChaseGroupEntity, (int)Falcon.Data.EntityType.RelationshipEntity, 0, null, null, GetRelationsForField("RelationshipCollectionViaChaseOutbound"), null, "RelationshipCollectionViaChaseOutbound", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ChaseGroupEntity.CustomProperties;}
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
			get { return ChaseGroupEntity.FieldsCustomProperties;}
		}

		/// <summary> The ChaseGroupId property of the Entity ChaseGroup<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseGroup"."ChaseGroupId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ChaseGroupId
		{
			get { return (System.Int64)GetValue((int)ChaseGroupFieldIndex.ChaseGroupId, true); }
			set	{ SetValue((int)ChaseGroupFieldIndex.ChaseGroupId, value); }
		}

		/// <summary> The Name property of the Entity ChaseGroup<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseGroup"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)ChaseGroupFieldIndex.Name, true); }
			set	{ SetValue((int)ChaseGroupFieldIndex.Name, value); }
		}

		/// <summary> The Number property of the Entity ChaseGroup<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseGroup"."Number"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Number
		{
			get { return (System.String)GetValue((int)ChaseGroupFieldIndex.Number, true); }
			set	{ SetValue((int)ChaseGroupFieldIndex.Number, value); }
		}

		/// <summary> The Division property of the Entity ChaseGroup<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblChaseGroup"."Division"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Division
		{
			get { return (System.String)GetValue((int)ChaseGroupFieldIndex.Division, true); }
			set	{ SetValue((int)ChaseGroupFieldIndex.Division, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChaseOutboundEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChaseOutboundEntity))]
		public virtual EntityCollection<ChaseOutboundEntity> ChaseOutbound
		{
			get
			{
				if(_chaseOutbound==null)
				{
					_chaseOutbound = new EntityCollection<ChaseOutboundEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChaseOutboundEntityFactory)));
					_chaseOutbound.SetContainingEntityInfo(this, "ChaseGroup");
				}
				return _chaseOutbound;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaChaseOutbound
		{
			get
			{
				if(_customerProfileCollectionViaChaseOutbound==null)
				{
					_customerProfileCollectionViaChaseOutbound = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaChaseOutbound.IsReadOnly=true;
				}
				return _customerProfileCollectionViaChaseOutbound;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaChaseOutbound
		{
			get
			{
				if(_lookupCollectionViaChaseOutbound==null)
				{
					_lookupCollectionViaChaseOutbound = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaChaseOutbound.IsReadOnly=true;
				}
				return _lookupCollectionViaChaseOutbound;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RelationshipEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RelationshipEntity))]
		public virtual EntityCollection<RelationshipEntity> RelationshipCollectionViaChaseOutbound
		{
			get
			{
				if(_relationshipCollectionViaChaseOutbound==null)
				{
					_relationshipCollectionViaChaseOutbound = new EntityCollection<RelationshipEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RelationshipEntityFactory)));
					_relationshipCollectionViaChaseOutbound.IsReadOnly=true;
				}
				return _relationshipCollectionViaChaseOutbound;
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
			get { return (int)Falcon.Data.EntityType.ChaseGroupEntity; }
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
