///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:45
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
	/// Entity class which represents the entity 'MarketingOffers'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class MarketingOffersEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<EventMarketingOffersEntity> _eventMarketingOffers;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventMarketingOffers;
		private CouponTypeEntity _couponType;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CouponType</summary>
			public static readonly string CouponType = "CouponType";
			/// <summary>Member name EventMarketingOffers</summary>
			public static readonly string EventMarketingOffers = "EventMarketingOffers";
			/// <summary>Member name EventsCollectionViaEventMarketingOffers</summary>
			public static readonly string EventsCollectionViaEventMarketingOffers = "EventsCollectionViaEventMarketingOffers";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static MarketingOffersEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public MarketingOffersEntity():base("MarketingOffersEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public MarketingOffersEntity(IEntityFields2 fields):base("MarketingOffersEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this MarketingOffersEntity</param>
		public MarketingOffersEntity(IValidator validator):base("MarketingOffersEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="marketingOfferId">PK value for MarketingOffers which data should be fetched into this MarketingOffers object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MarketingOffersEntity(System.Int64 marketingOfferId):base("MarketingOffersEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.MarketingOfferId = marketingOfferId;
		}

		/// <summary> CTor</summary>
		/// <param name="marketingOfferId">PK value for MarketingOffers which data should be fetched into this MarketingOffers object</param>
		/// <param name="validator">The custom validator object for this MarketingOffersEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MarketingOffersEntity(System.Int64 marketingOfferId, IValidator validator):base("MarketingOffersEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.MarketingOfferId = marketingOfferId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MarketingOffersEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_eventMarketingOffers = (EntityCollection<EventMarketingOffersEntity>)info.GetValue("_eventMarketingOffers", typeof(EntityCollection<EventMarketingOffersEntity>));
				_eventsCollectionViaEventMarketingOffers = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventMarketingOffers", typeof(EntityCollection<EventsEntity>));
				_couponType = (CouponTypeEntity)info.GetValue("_couponType", typeof(CouponTypeEntity));
				if(_couponType!=null)
				{
					_couponType.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((MarketingOffersFieldIndex)fieldIndex)
			{
				case MarketingOffersFieldIndex.MarketingOfferTypeId:
					DesetupSyncCouponType(true, false);
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
				case "CouponType":
					this.CouponType = (CouponTypeEntity)entity;
					break;
				case "EventMarketingOffers":
					this.EventMarketingOffers.Add((EventMarketingOffersEntity)entity);
					break;
				case "EventsCollectionViaEventMarketingOffers":
					this.EventsCollectionViaEventMarketingOffers.IsReadOnly = false;
					this.EventsCollectionViaEventMarketingOffers.Add((EventsEntity)entity);
					this.EventsCollectionViaEventMarketingOffers.IsReadOnly = true;
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
			return MarketingOffersEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "CouponType":
					toReturn.Add(MarketingOffersEntity.Relations.CouponTypeEntityUsingMarketingOfferTypeId);
					break;
				case "EventMarketingOffers":
					toReturn.Add(MarketingOffersEntity.Relations.EventMarketingOffersEntityUsingMarketingOfferId);
					break;
				case "EventsCollectionViaEventMarketingOffers":
					toReturn.Add(MarketingOffersEntity.Relations.EventMarketingOffersEntityUsingMarketingOfferId, "MarketingOffersEntity__", "EventMarketingOffers_", JoinHint.None);
					toReturn.Add(EventMarketingOffersEntity.Relations.EventsEntityUsingEventId, "EventMarketingOffers_", string.Empty, JoinHint.None);
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
				case "CouponType":
					SetupSyncCouponType(relatedEntity);
					break;
				case "EventMarketingOffers":
					this.EventMarketingOffers.Add((EventMarketingOffersEntity)relatedEntity);
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
				case "CouponType":
					DesetupSyncCouponType(false, true);
					break;
				case "EventMarketingOffers":
					base.PerformRelatedEntityRemoval(this.EventMarketingOffers, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_couponType!=null)
			{
				toReturn.Add(_couponType);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.EventMarketingOffers);

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
				info.AddValue("_eventMarketingOffers", ((_eventMarketingOffers!=null) && (_eventMarketingOffers.Count>0) && !this.MarkedForDeletion)?_eventMarketingOffers:null);
				info.AddValue("_eventsCollectionViaEventMarketingOffers", ((_eventsCollectionViaEventMarketingOffers!=null) && (_eventsCollectionViaEventMarketingOffers.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventMarketingOffers:null);
				info.AddValue("_couponType", (!this.MarkedForDeletion?_couponType:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(MarketingOffersFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(MarketingOffersFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new MarketingOffersRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventMarketingOffers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventMarketingOffers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventMarketingOffersFields.MarketingOfferId, null, ComparisonOperator.Equal, this.MarketingOfferId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventMarketingOffers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventMarketingOffers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MarketingOffersFields.MarketingOfferId, null, ComparisonOperator.Equal, this.MarketingOfferId, "MarketingOffersEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CouponType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCouponType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CouponTypeFields.CouponTypeId, null, ComparisonOperator.Equal, this.MarketingOfferTypeId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.MarketingOffersEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(MarketingOffersEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._eventMarketingOffers);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventMarketingOffers);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._eventMarketingOffers = (EntityCollection<EventMarketingOffersEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventMarketingOffers = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._eventMarketingOffers != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventMarketingOffers != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventMarketingOffersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventMarketingOffersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("CouponType", _couponType);
			toReturn.Add("EventMarketingOffers", _eventMarketingOffers);
			toReturn.Add("EventsCollectionViaEventMarketingOffers", _eventsCollectionViaEventMarketingOffers);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_eventMarketingOffers!=null)
			{
				_eventMarketingOffers.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventMarketingOffers!=null)
			{
				_eventsCollectionViaEventMarketingOffers.ActiveContext = base.ActiveContext;
			}
			if(_couponType!=null)
			{
				_couponType.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_eventMarketingOffers = null;
			_eventsCollectionViaEventMarketingOffers = null;
			_couponType = null;

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

			_fieldsCustomProperties.Add("MarketingOfferId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MarketingOfferTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsGlobal", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsPercentage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DiscountType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MarketingOfferValue", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MarketingOfferDescription", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsFree", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsEventbased", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MinimumPurchaseAmount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ValidityStartDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ValidityEndDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MaximumNumberTimesUsed", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MarketingOfferCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerRange", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _couponType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCouponType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _couponType, new PropertyChangedEventHandler( OnCouponTypePropertyChanged ), "CouponType", MarketingOffersEntity.Relations.CouponTypeEntityUsingMarketingOfferTypeId, true, signalRelatedEntity, "MarketingOffers", resetFKFields, new int[] { (int)MarketingOffersFieldIndex.MarketingOfferTypeId } );		
			_couponType = null;
		}

		/// <summary> setups the sync logic for member _couponType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCouponType(IEntity2 relatedEntity)
		{
			if(_couponType!=relatedEntity)
			{
				DesetupSyncCouponType(true, true);
				_couponType = (CouponTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _couponType, new PropertyChangedEventHandler( OnCouponTypePropertyChanged ), "CouponType", MarketingOffersEntity.Relations.CouponTypeEntityUsingMarketingOfferTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCouponTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this MarketingOffersEntity</param>
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
		public  static MarketingOffersRelations Relations
		{
			get	{ return new MarketingOffersRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventMarketingOffers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventMarketingOffers
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventMarketingOffersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventMarketingOffersEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventMarketingOffers")[0], (int)Falcon.Data.EntityType.MarketingOffersEntity, (int)Falcon.Data.EntityType.EventMarketingOffersEntity, 0, null, null, null, null, "EventMarketingOffers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventMarketingOffers
		{
			get
			{
				IEntityRelation intermediateRelation = MarketingOffersEntity.Relations.EventMarketingOffersEntityUsingMarketingOfferId;
				intermediateRelation.SetAliases(string.Empty, "EventMarketingOffers_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.MarketingOffersEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventMarketingOffers"), null, "EventsCollectionViaEventMarketingOffers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CouponType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCouponType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CouponTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("CouponType")[0], (int)Falcon.Data.EntityType.MarketingOffersEntity, (int)Falcon.Data.EntityType.CouponTypeEntity, 0, null, null, null, null, "CouponType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return MarketingOffersEntity.CustomProperties;}
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
			get { return MarketingOffersEntity.FieldsCustomProperties;}
		}

		/// <summary> The MarketingOfferId property of the Entity MarketingOffers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingOffers"."MarketingOfferID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 MarketingOfferId
		{
			get { return (System.Int64)GetValue((int)MarketingOffersFieldIndex.MarketingOfferId, true); }
			set	{ SetValue((int)MarketingOffersFieldIndex.MarketingOfferId, value); }
		}

		/// <summary> The MarketingOfferTypeId property of the Entity MarketingOffers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingOffers"."MarketingOfferTypeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 MarketingOfferTypeId
		{
			get { return (System.Int64)GetValue((int)MarketingOffersFieldIndex.MarketingOfferTypeId, true); }
			set	{ SetValue((int)MarketingOffersFieldIndex.MarketingOfferTypeId, value); }
		}

		/// <summary> The IsGlobal property of the Entity MarketingOffers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingOffers"."IsGlobal"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsGlobal
		{
			get { return (System.Boolean)GetValue((int)MarketingOffersFieldIndex.IsGlobal, true); }
			set	{ SetValue((int)MarketingOffersFieldIndex.IsGlobal, value); }
		}

		/// <summary> The IsPercentage property of the Entity MarketingOffers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingOffers"."IsPercentage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsPercentage
		{
			get { return (System.Boolean)GetValue((int)MarketingOffersFieldIndex.IsPercentage, true); }
			set	{ SetValue((int)MarketingOffersFieldIndex.IsPercentage, value); }
		}

		/// <summary> The DiscountType property of the Entity MarketingOffers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingOffers"."DiscountType"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean DiscountType
		{
			get { return (System.Boolean)GetValue((int)MarketingOffersFieldIndex.DiscountType, true); }
			set	{ SetValue((int)MarketingOffersFieldIndex.DiscountType, value); }
		}

		/// <summary> The MarketingOfferValue property of the Entity MarketingOffers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingOffers"."MarketingOfferValue"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal MarketingOfferValue
		{
			get { return (System.Decimal)GetValue((int)MarketingOffersFieldIndex.MarketingOfferValue, true); }
			set	{ SetValue((int)MarketingOffersFieldIndex.MarketingOfferValue, value); }
		}

		/// <summary> The MarketingOfferDescription property of the Entity MarketingOffers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingOffers"."MarketingOfferDescription"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MarketingOfferDescription
		{
			get { return (System.String)GetValue((int)MarketingOffersFieldIndex.MarketingOfferDescription, true); }
			set	{ SetValue((int)MarketingOffersFieldIndex.MarketingOfferDescription, value); }
		}

		/// <summary> The IsFree property of the Entity MarketingOffers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingOffers"."IsFree"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsFree
		{
			get { return (System.Boolean)GetValue((int)MarketingOffersFieldIndex.IsFree, true); }
			set	{ SetValue((int)MarketingOffersFieldIndex.IsFree, value); }
		}

		/// <summary> The IsEventbased property of the Entity MarketingOffers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingOffers"."IsEventbased"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsEventbased
		{
			get { return (System.Boolean)GetValue((int)MarketingOffersFieldIndex.IsEventbased, true); }
			set	{ SetValue((int)MarketingOffersFieldIndex.IsEventbased, value); }
		}

		/// <summary> The MinimumPurchaseAmount property of the Entity MarketingOffers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingOffers"."MinimumPurchaseAmount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> MinimumPurchaseAmount
		{
			get { return (Nullable<System.Decimal>)GetValue((int)MarketingOffersFieldIndex.MinimumPurchaseAmount, false); }
			set	{ SetValue((int)MarketingOffersFieldIndex.MinimumPurchaseAmount, value); }
		}

		/// <summary> The CreatedUserId property of the Entity MarketingOffers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingOffers"."CreatedUserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedUserId
		{
			get { return (System.Int64)GetValue((int)MarketingOffersFieldIndex.CreatedUserId, true); }
			set	{ SetValue((int)MarketingOffersFieldIndex.CreatedUserId, value); }
		}

		/// <summary> The ValidityStartDate property of the Entity MarketingOffers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingOffers"."ValidityStartDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime ValidityStartDate
		{
			get { return (System.DateTime)GetValue((int)MarketingOffersFieldIndex.ValidityStartDate, true); }
			set	{ SetValue((int)MarketingOffersFieldIndex.ValidityStartDate, value); }
		}

		/// <summary> The ValidityEndDate property of the Entity MarketingOffers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingOffers"."ValidityEndDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ValidityEndDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)MarketingOffersFieldIndex.ValidityEndDate, false); }
			set	{ SetValue((int)MarketingOffersFieldIndex.ValidityEndDate, value); }
		}

		/// <summary> The DateCreated property of the Entity MarketingOffers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingOffers"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)MarketingOffersFieldIndex.DateCreated, true); }
			set	{ SetValue((int)MarketingOffersFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity MarketingOffers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingOffers"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)MarketingOffersFieldIndex.DateModified, true); }
			set	{ SetValue((int)MarketingOffersFieldIndex.DateModified, value); }
		}

		/// <summary> The IsActive property of the Entity MarketingOffers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingOffers"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)MarketingOffersFieldIndex.IsActive, true); }
			set	{ SetValue((int)MarketingOffersFieldIndex.IsActive, value); }
		}

		/// <summary> The MaximumNumberTimesUsed property of the Entity MarketingOffers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingOffers"."MaximumNumberTimesUsed"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal MaximumNumberTimesUsed
		{
			get { return (System.Decimal)GetValue((int)MarketingOffersFieldIndex.MaximumNumberTimesUsed, true); }
			set	{ SetValue((int)MarketingOffersFieldIndex.MaximumNumberTimesUsed, value); }
		}

		/// <summary> The MarketingOfferCode property of the Entity MarketingOffers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingOffers"."MarketingOfferCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String MarketingOfferCode
		{
			get { return (System.String)GetValue((int)MarketingOffersFieldIndex.MarketingOfferCode, true); }
			set	{ SetValue((int)MarketingOffersFieldIndex.MarketingOfferCode, value); }
		}

		/// <summary> The CustomerRange property of the Entity MarketingOffers<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMarketingOffers"."CustomerRange"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte CustomerRange
		{
			get { return (System.Byte)GetValue((int)MarketingOffersFieldIndex.CustomerRange, true); }
			set	{ SetValue((int)MarketingOffersFieldIndex.CustomerRange, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventMarketingOffersEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventMarketingOffersEntity))]
		public virtual EntityCollection<EventMarketingOffersEntity> EventMarketingOffers
		{
			get
			{
				if(_eventMarketingOffers==null)
				{
					_eventMarketingOffers = new EntityCollection<EventMarketingOffersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventMarketingOffersEntityFactory)));
					_eventMarketingOffers.SetContainingEntityInfo(this, "MarketingOffers");
				}
				return _eventMarketingOffers;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventMarketingOffers
		{
			get
			{
				if(_eventsCollectionViaEventMarketingOffers==null)
				{
					_eventsCollectionViaEventMarketingOffers = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventMarketingOffers.IsReadOnly=true;
				}
				return _eventsCollectionViaEventMarketingOffers;
			}
		}

		/// <summary> Gets / sets related entity of type 'CouponTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CouponTypeEntity CouponType
		{
			get
			{
				return _couponType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCouponType(value);
				}
				else
				{
					if(value==null)
					{
						if(_couponType != null)
						{
							_couponType.UnsetRelatedEntity(this, "MarketingOffers");
						}
					}
					else
					{
						if(_couponType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MarketingOffers");
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
			get { return (int)Falcon.Data.EntityType.MarketingOffersEntity; }
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
