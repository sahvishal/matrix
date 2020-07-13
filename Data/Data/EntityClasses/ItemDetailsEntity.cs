///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: Wednesday, July 14, 2010 6:00:33 AM
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
using HealthYes.Data;
using HealthYes.Data.HelperClasses;
using HealthYes.Data.FactoryClasses;
using HealthYes.Data.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace HealthYes.Data.EntityClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>
	/// Entity class which represents the entity 'ItemDetails'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ItemDetailsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ItemUserAccessEntity> _itemUserAccess;
		private EntityCollection<MessageDetailsEntity> _messageDetails;
		private EntityCollection<MessageDetailsEntity> _messageDetailsCollectionViaMessageDetails;
		private ItemTypeEntity _itemType;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name ItemType</summary>
			public static readonly string ItemType = "ItemType";
			/// <summary>Member name ItemUserAccess</summary>
			public static readonly string ItemUserAccess = "ItemUserAccess";
			/// <summary>Member name MessageDetails</summary>
			public static readonly string MessageDetails = "MessageDetails";
			/// <summary>Member name MessageDetailsCollectionViaMessageDetails</summary>
			public static readonly string MessageDetailsCollectionViaMessageDetails = "MessageDetailsCollectionViaMessageDetails";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ItemDetailsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ItemDetailsEntity():base("ItemDetailsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ItemDetailsEntity(IEntityFields2 fields):base("ItemDetailsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ItemDetailsEntity</param>
		public ItemDetailsEntity(IValidator validator):base("ItemDetailsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="itemId">PK value for ItemDetails which data should be fetched into this ItemDetails object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ItemDetailsEntity(System.Int64 itemId):base("ItemDetailsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ItemId = itemId;
		}

		/// <summary> CTor</summary>
		/// <param name="itemId">PK value for ItemDetails which data should be fetched into this ItemDetails object</param>
		/// <param name="validator">The custom validator object for this ItemDetailsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ItemDetailsEntity(System.Int64 itemId, IValidator validator):base("ItemDetailsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ItemId = itemId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ItemDetailsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_itemUserAccess = (EntityCollection<ItemUserAccessEntity>)info.GetValue("_itemUserAccess", typeof(EntityCollection<ItemUserAccessEntity>));
				_messageDetails = (EntityCollection<MessageDetailsEntity>)info.GetValue("_messageDetails", typeof(EntityCollection<MessageDetailsEntity>));
				_messageDetailsCollectionViaMessageDetails = (EntityCollection<MessageDetailsEntity>)info.GetValue("_messageDetailsCollectionViaMessageDetails", typeof(EntityCollection<MessageDetailsEntity>));
				_itemType = (ItemTypeEntity)info.GetValue("_itemType", typeof(ItemTypeEntity));
				if(_itemType!=null)
				{
					_itemType.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ItemDetailsFieldIndex)fieldIndex)
			{
				case ItemDetailsFieldIndex.ItemTypeId:
					DesetupSyncItemType(true, false);
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
				case "ItemType":
					this.ItemType = (ItemTypeEntity)entity;
					break;
				case "ItemUserAccess":
					this.ItemUserAccess.Add((ItemUserAccessEntity)entity);
					break;
				case "MessageDetails":
					this.MessageDetails.Add((MessageDetailsEntity)entity);
					break;
				case "MessageDetailsCollectionViaMessageDetails":
					this.MessageDetailsCollectionViaMessageDetails.IsReadOnly = false;
					this.MessageDetailsCollectionViaMessageDetails.Add((MessageDetailsEntity)entity);
					this.MessageDetailsCollectionViaMessageDetails.IsReadOnly = true;
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
			return ItemDetailsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "ItemType":
					toReturn.Add(ItemDetailsEntity.Relations.ItemTypeEntityUsingItemTypeId);
					break;
				case "ItemUserAccess":
					toReturn.Add(ItemDetailsEntity.Relations.ItemUserAccessEntityUsingItemId);
					break;
				case "MessageDetails":
					toReturn.Add(ItemDetailsEntity.Relations.MessageDetailsEntityUsingItemId);
					break;
				case "MessageDetailsCollectionViaMessageDetails":
					toReturn.Add(ItemDetailsEntity.Relations.MessageDetailsEntityUsingItemId, "ItemDetailsEntity__", "MessageDetails_", JoinHint.None);
					toReturn.Add(MessageDetailsEntity.Relations.MessageDetailsEntityUsingParentMessageId, "MessageDetails_", string.Empty, JoinHint.None);
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
				case "ItemType":
					SetupSyncItemType(relatedEntity);
					break;
				case "ItemUserAccess":
					this.ItemUserAccess.Add((ItemUserAccessEntity)relatedEntity);
					break;
				case "MessageDetails":
					this.MessageDetails.Add((MessageDetailsEntity)relatedEntity);
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
				case "ItemType":
					DesetupSyncItemType(false, true);
					break;
				case "ItemUserAccess":
					base.PerformRelatedEntityRemoval(this.ItemUserAccess, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MessageDetails":
					base.PerformRelatedEntityRemoval(this.MessageDetails, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_itemType!=null)
			{
				toReturn.Add(_itemType);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.ItemUserAccess);
			toReturn.Add(this.MessageDetails);

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
				info.AddValue("_itemUserAccess", ((_itemUserAccess!=null) && (_itemUserAccess.Count>0) && !this.MarkedForDeletion)?_itemUserAccess:null);
				info.AddValue("_messageDetails", ((_messageDetails!=null) && (_messageDetails.Count>0) && !this.MarkedForDeletion)?_messageDetails:null);
				info.AddValue("_messageDetailsCollectionViaMessageDetails", ((_messageDetailsCollectionViaMessageDetails!=null) && (_messageDetailsCollectionViaMessageDetails.Count>0) && !this.MarkedForDeletion)?_messageDetailsCollectionViaMessageDetails:null);
				info.AddValue("_itemType", (!this.MarkedForDeletion?_itemType:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ItemDetailsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ItemDetailsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ItemDetailsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ItemUserAccess' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoItemUserAccess()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ItemUserAccessFields.ItemId, null, ComparisonOperator.Equal, this.ItemId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MessageDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMessageDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MessageDetailsFields.ItemId, null, ComparisonOperator.Equal, this.ItemId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MessageDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMessageDetailsCollectionViaMessageDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("MessageDetailsCollectionViaMessageDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ItemDetailsFields.ItemId, null, ComparisonOperator.Equal, this.ItemId, "ItemDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ItemType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoItemType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ItemTypeFields.ItemTypeId, null, ComparisonOperator.Equal, this.ItemTypeId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.ItemDetailsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ItemDetailsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._itemUserAccess);
			collectionsQueue.Enqueue(this._messageDetails);
			collectionsQueue.Enqueue(this._messageDetailsCollectionViaMessageDetails);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._itemUserAccess = (EntityCollection<ItemUserAccessEntity>) collectionsQueue.Dequeue();
			this._messageDetails = (EntityCollection<MessageDetailsEntity>) collectionsQueue.Dequeue();
			this._messageDetailsCollectionViaMessageDetails = (EntityCollection<MessageDetailsEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._itemUserAccess != null)
			{
				return true;
			}
			if (this._messageDetails != null)
			{
				return true;
			}
			if (this._messageDetailsCollectionViaMessageDetails != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ItemUserAccessEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ItemUserAccessEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MessageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MessageDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MessageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MessageDetailsEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("ItemType", _itemType);
			toReturn.Add("ItemUserAccess", _itemUserAccess);
			toReturn.Add("MessageDetails", _messageDetails);
			toReturn.Add("MessageDetailsCollectionViaMessageDetails", _messageDetailsCollectionViaMessageDetails);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_itemUserAccess!=null)
			{
				_itemUserAccess.ActiveContext = base.ActiveContext;
			}
			if(_messageDetails!=null)
			{
				_messageDetails.ActiveContext = base.ActiveContext;
			}
			if(_messageDetailsCollectionViaMessageDetails!=null)
			{
				_messageDetailsCollectionViaMessageDetails.ActiveContext = base.ActiveContext;
			}
			if(_itemType!=null)
			{
				_itemType.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_itemUserAccess = null;
			_messageDetails = null;
			_messageDetailsCollectionViaMessageDetails = null;
			_itemType = null;

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

			_fieldsCustomProperties.Add("ItemId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ItemTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedById", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedById", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsValid", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _itemType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncItemType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _itemType, new PropertyChangedEventHandler( OnItemTypePropertyChanged ), "ItemType", ItemDetailsEntity.Relations.ItemTypeEntityUsingItemTypeId, true, signalRelatedEntity, "ItemDetails", resetFKFields, new int[] { (int)ItemDetailsFieldIndex.ItemTypeId } );		
			_itemType = null;
		}

		/// <summary> setups the sync logic for member _itemType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncItemType(IEntity2 relatedEntity)
		{
			if(_itemType!=relatedEntity)
			{
				DesetupSyncItemType(true, true);
				_itemType = (ItemTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _itemType, new PropertyChangedEventHandler( OnItemTypePropertyChanged ), "ItemType", ItemDetailsEntity.Relations.ItemTypeEntityUsingItemTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnItemTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ItemDetailsEntity</param>
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
		public  static ItemDetailsRelations Relations
		{
			get	{ return new ItemDetailsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ItemUserAccess' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathItemUserAccess
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ItemUserAccessEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ItemUserAccessEntityFactory))),
					(IEntityRelation)GetRelationsForField("ItemUserAccess")[0], (int)HealthYes.Data.EntityType.ItemDetailsEntity, (int)HealthYes.Data.EntityType.ItemUserAccessEntity, 0, null, null, null, null, "ItemUserAccess", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MessageDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMessageDetails
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MessageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MessageDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("MessageDetails")[0], (int)HealthYes.Data.EntityType.ItemDetailsEntity, (int)HealthYes.Data.EntityType.MessageDetailsEntity, 0, null, null, null, null, "MessageDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MessageDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMessageDetailsCollectionViaMessageDetails
		{
			get
			{
				IEntityRelation intermediateRelation = ItemDetailsEntity.Relations.MessageDetailsEntityUsingItemId;
				intermediateRelation.SetAliases(string.Empty, "MessageDetails_");
				return new PrefetchPathElement2(new EntityCollection<MessageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MessageDetailsEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.ItemDetailsEntity, (int)HealthYes.Data.EntityType.MessageDetailsEntity, 0, null, null, GetRelationsForField("MessageDetailsCollectionViaMessageDetails"), null, "MessageDetailsCollectionViaMessageDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ItemType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathItemType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ItemTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("ItemType")[0], (int)HealthYes.Data.EntityType.ItemDetailsEntity, (int)HealthYes.Data.EntityType.ItemTypeEntity, 0, null, null, null, null, "ItemType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ItemDetailsEntity.CustomProperties;}
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
			get { return ItemDetailsEntity.FieldsCustomProperties;}
		}

		/// <summary> The ItemId property of the Entity ItemDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblItemDetails"."ItemID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ItemId
		{
			get { return (System.Int64)GetValue((int)ItemDetailsFieldIndex.ItemId, true); }
			set	{ SetValue((int)ItemDetailsFieldIndex.ItemId, value); }
		}

		/// <summary> The Name property of the Entity ItemDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblItemDetails"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)ItemDetailsFieldIndex.Name, true); }
			set	{ SetValue((int)ItemDetailsFieldIndex.Name, value); }
		}

		/// <summary> The Description property of the Entity ItemDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblItemDetails"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)ItemDetailsFieldIndex.Description, true); }
			set	{ SetValue((int)ItemDetailsFieldIndex.Description, value); }
		}

		/// <summary> The ItemTypeId property of the Entity ItemDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblItemDetails"."ItemTypeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte ItemTypeId
		{
			get { return (System.Byte)GetValue((int)ItemDetailsFieldIndex.ItemTypeId, true); }
			set	{ SetValue((int)ItemDetailsFieldIndex.ItemTypeId, value); }
		}

		/// <summary> The DateCreated property of the Entity ItemDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblItemDetails"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)ItemDetailsFieldIndex.DateCreated, true); }
			set	{ SetValue((int)ItemDetailsFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity ItemDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblItemDetails"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)ItemDetailsFieldIndex.DateModified, true); }
			set	{ SetValue((int)ItemDetailsFieldIndex.DateModified, value); }
		}

		/// <summary> The CreatedById property of the Entity ItemDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblItemDetails"."CreatedByID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedById
		{
			get { return (System.Int64)GetValue((int)ItemDetailsFieldIndex.CreatedById, true); }
			set	{ SetValue((int)ItemDetailsFieldIndex.CreatedById, value); }
		}

		/// <summary> The ModifiedById property of the Entity ItemDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblItemDetails"."ModifiedByID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ModifiedById
		{
			get { return (System.Int64)GetValue((int)ItemDetailsFieldIndex.ModifiedById, true); }
			set	{ SetValue((int)ItemDetailsFieldIndex.ModifiedById, value); }
		}

		/// <summary> The IsValid property of the Entity ItemDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblItemDetails"."IsValid"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsValid
		{
			get { return (System.Boolean)GetValue((int)ItemDetailsFieldIndex.IsValid, true); }
			set	{ SetValue((int)ItemDetailsFieldIndex.IsValid, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ItemUserAccessEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ItemUserAccessEntity))]
		public virtual EntityCollection<ItemUserAccessEntity> ItemUserAccess
		{
			get
			{
				if(_itemUserAccess==null)
				{
					_itemUserAccess = new EntityCollection<ItemUserAccessEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ItemUserAccessEntityFactory)));
					_itemUserAccess.SetContainingEntityInfo(this, "ItemDetails");
				}
				return _itemUserAccess;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MessageDetailsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MessageDetailsEntity))]
		public virtual EntityCollection<MessageDetailsEntity> MessageDetails
		{
			get
			{
				if(_messageDetails==null)
				{
					_messageDetails = new EntityCollection<MessageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MessageDetailsEntityFactory)));
					_messageDetails.SetContainingEntityInfo(this, "ItemDetails");
				}
				return _messageDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MessageDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MessageDetailsEntity))]
		public virtual EntityCollection<MessageDetailsEntity> MessageDetailsCollectionViaMessageDetails
		{
			get
			{
				if(_messageDetailsCollectionViaMessageDetails==null)
				{
					_messageDetailsCollectionViaMessageDetails = new EntityCollection<MessageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MessageDetailsEntityFactory)));
					_messageDetailsCollectionViaMessageDetails.IsReadOnly=true;
				}
				return _messageDetailsCollectionViaMessageDetails;
			}
		}

		/// <summary> Gets / sets related entity of type 'ItemTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ItemTypeEntity ItemType
		{
			get
			{
				return _itemType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncItemType(value);
				}
				else
				{
					if(value==null)
					{
						if(_itemType != null)
						{
							_itemType.UnsetRelatedEntity(this, "ItemDetails");
						}
					}
					else
					{
						if(_itemType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ItemDetails");
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
		
		/// <summary>Returns the HealthYes.Data.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)HealthYes.Data.EntityType.ItemDetailsEntity; }
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
