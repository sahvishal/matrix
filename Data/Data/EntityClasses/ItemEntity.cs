///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:43
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
	/// Entity class which represents the entity 'Item'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ItemEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<PodInventoryItemEntity> _podInventoryItem;
		private EntityCollection<PodDetailsEntity> _podDetailsCollectionViaPodInventoryItem;
		private InventoryItemEntity _inventoryItem;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name InventoryItem</summary>
			public static readonly string InventoryItem = "InventoryItem";
			/// <summary>Member name PodInventoryItem</summary>
			public static readonly string PodInventoryItem = "PodInventoryItem";
			/// <summary>Member name PodDetailsCollectionViaPodInventoryItem</summary>
			public static readonly string PodDetailsCollectionViaPodInventoryItem = "PodDetailsCollectionViaPodInventoryItem";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ItemEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ItemEntity():base("ItemEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ItemEntity(IEntityFields2 fields):base("ItemEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ItemEntity</param>
		public ItemEntity(IValidator validator):base("ItemEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="itemId">PK value for Item which data should be fetched into this Item object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ItemEntity(System.Int64 itemId):base("ItemEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ItemId = itemId;
		}

		/// <summary> CTor</summary>
		/// <param name="itemId">PK value for Item which data should be fetched into this Item object</param>
		/// <param name="validator">The custom validator object for this ItemEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ItemEntity(System.Int64 itemId, IValidator validator):base("ItemEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ItemId = itemId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ItemEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_podInventoryItem = (EntityCollection<PodInventoryItemEntity>)info.GetValue("_podInventoryItem", typeof(EntityCollection<PodInventoryItemEntity>));
				_podDetailsCollectionViaPodInventoryItem = (EntityCollection<PodDetailsEntity>)info.GetValue("_podDetailsCollectionViaPodInventoryItem", typeof(EntityCollection<PodDetailsEntity>));
				_inventoryItem = (InventoryItemEntity)info.GetValue("_inventoryItem", typeof(InventoryItemEntity));
				if(_inventoryItem!=null)
				{
					_inventoryItem.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ItemFieldIndex)fieldIndex)
			{
				case ItemFieldIndex.InventoryItemId:
					DesetupSyncInventoryItem(true, false);
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
				case "InventoryItem":
					this.InventoryItem = (InventoryItemEntity)entity;
					break;
				case "PodInventoryItem":
					this.PodInventoryItem.Add((PodInventoryItemEntity)entity);
					break;
				case "PodDetailsCollectionViaPodInventoryItem":
					this.PodDetailsCollectionViaPodInventoryItem.IsReadOnly = false;
					this.PodDetailsCollectionViaPodInventoryItem.Add((PodDetailsEntity)entity);
					this.PodDetailsCollectionViaPodInventoryItem.IsReadOnly = true;
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
			return ItemEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "InventoryItem":
					toReturn.Add(ItemEntity.Relations.InventoryItemEntityUsingInventoryItemId);
					break;
				case "PodInventoryItem":
					toReturn.Add(ItemEntity.Relations.PodInventoryItemEntityUsingItemId);
					break;
				case "PodDetailsCollectionViaPodInventoryItem":
					toReturn.Add(ItemEntity.Relations.PodInventoryItemEntityUsingItemId, "ItemEntity__", "PodInventoryItem_", JoinHint.None);
					toReturn.Add(PodInventoryItemEntity.Relations.PodDetailsEntityUsingPodId, "PodInventoryItem_", string.Empty, JoinHint.None);
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
				case "InventoryItem":
					SetupSyncInventoryItem(relatedEntity);
					break;
				case "PodInventoryItem":
					this.PodInventoryItem.Add((PodInventoryItemEntity)relatedEntity);
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
				case "InventoryItem":
					DesetupSyncInventoryItem(false, true);
					break;
				case "PodInventoryItem":
					base.PerformRelatedEntityRemoval(this.PodInventoryItem, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_inventoryItem!=null)
			{
				toReturn.Add(_inventoryItem);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.PodInventoryItem);

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
				info.AddValue("_podInventoryItem", ((_podInventoryItem!=null) && (_podInventoryItem.Count>0) && !this.MarkedForDeletion)?_podInventoryItem:null);
				info.AddValue("_podDetailsCollectionViaPodInventoryItem", ((_podDetailsCollectionViaPodInventoryItem!=null) && (_podDetailsCollectionViaPodInventoryItem.Count>0) && !this.MarkedForDeletion)?_podDetailsCollectionViaPodInventoryItem:null);
				info.AddValue("_inventoryItem", (!this.MarkedForDeletion?_inventoryItem:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ItemFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ItemFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ItemRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodInventoryItem' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodInventoryItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodInventoryItemFields.ItemId, null, ComparisonOperator.Equal, this.ItemId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodDetailsCollectionViaPodInventoryItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PodDetailsCollectionViaPodInventoryItem"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ItemFields.ItemId, null, ComparisonOperator.Equal, this.ItemId, "ItemEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'InventoryItem' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoInventoryItem()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(InventoryItemFields.InventoryItemId, null, ComparisonOperator.Equal, this.InventoryItemId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ItemEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ItemEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._podInventoryItem);
			collectionsQueue.Enqueue(this._podDetailsCollectionViaPodInventoryItem);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._podInventoryItem = (EntityCollection<PodInventoryItemEntity>) collectionsQueue.Dequeue();
			this._podDetailsCollectionViaPodInventoryItem = (EntityCollection<PodDetailsEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._podInventoryItem != null)
			{
				return true;
			}
			if (this._podDetailsCollectionViaPodInventoryItem != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodInventoryItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodInventoryItemEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("InventoryItem", _inventoryItem);
			toReturn.Add("PodInventoryItem", _podInventoryItem);
			toReturn.Add("PodDetailsCollectionViaPodInventoryItem", _podDetailsCollectionViaPodInventoryItem);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_podInventoryItem!=null)
			{
				_podInventoryItem.ActiveContext = base.ActiveContext;
			}
			if(_podDetailsCollectionViaPodInventoryItem!=null)
			{
				_podDetailsCollectionViaPodInventoryItem.ActiveContext = base.ActiveContext;
			}
			if(_inventoryItem!=null)
			{
				_inventoryItem.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_podInventoryItem = null;
			_podDetailsCollectionViaPodInventoryItem = null;
			_inventoryItem = null;

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

			_fieldsCustomProperties.Add("InventoryItemId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ItemCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Skucode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ManufacturerName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ManufacturerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsAllocated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Notes", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _inventoryItem</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncInventoryItem(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _inventoryItem, new PropertyChangedEventHandler( OnInventoryItemPropertyChanged ), "InventoryItem", ItemEntity.Relations.InventoryItemEntityUsingInventoryItemId, true, signalRelatedEntity, "Item", resetFKFields, new int[] { (int)ItemFieldIndex.InventoryItemId } );		
			_inventoryItem = null;
		}

		/// <summary> setups the sync logic for member _inventoryItem</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncInventoryItem(IEntity2 relatedEntity)
		{
			if(_inventoryItem!=relatedEntity)
			{
				DesetupSyncInventoryItem(true, true);
				_inventoryItem = (InventoryItemEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _inventoryItem, new PropertyChangedEventHandler( OnInventoryItemPropertyChanged ), "InventoryItem", ItemEntity.Relations.InventoryItemEntityUsingInventoryItemId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnInventoryItemPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ItemEntity</param>
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
		public  static ItemRelations Relations
		{
			get	{ return new ItemRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodInventoryItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodInventoryItem
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PodInventoryItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodInventoryItemEntityFactory))),
					(IEntityRelation)GetRelationsForField("PodInventoryItem")[0], (int)Falcon.Data.EntityType.ItemEntity, (int)Falcon.Data.EntityType.PodInventoryItemEntity, 0, null, null, null, null, "PodInventoryItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodDetailsCollectionViaPodInventoryItem
		{
			get
			{
				IEntityRelation intermediateRelation = ItemEntity.Relations.PodInventoryItemEntityUsingItemId;
				intermediateRelation.SetAliases(string.Empty, "PodInventoryItem_");
				return new PrefetchPathElement2(new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ItemEntity, (int)Falcon.Data.EntityType.PodDetailsEntity, 0, null, null, GetRelationsForField("PodDetailsCollectionViaPodInventoryItem"), null, "PodDetailsCollectionViaPodInventoryItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'InventoryItem' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathInventoryItem
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(InventoryItemEntityFactory))),
					(IEntityRelation)GetRelationsForField("InventoryItem")[0], (int)Falcon.Data.EntityType.ItemEntity, (int)Falcon.Data.EntityType.InventoryItemEntity, 0, null, null, null, null, "InventoryItem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ItemEntity.CustomProperties;}
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
			get { return ItemEntity.FieldsCustomProperties;}
		}

		/// <summary> The ItemId property of the Entity Item<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblItem"."ItemID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ItemId
		{
			get { return (System.Int64)GetValue((int)ItemFieldIndex.ItemId, true); }
			set	{ SetValue((int)ItemFieldIndex.ItemId, value); }
		}

		/// <summary> The InventoryItemId property of the Entity Item<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblItem"."InventoryItemID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 InventoryItemId
		{
			get { return (System.Int64)GetValue((int)ItemFieldIndex.InventoryItemId, true); }
			set	{ SetValue((int)ItemFieldIndex.InventoryItemId, value); }
		}

		/// <summary> The ItemCode property of the Entity Item<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblItem"."ItemCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ItemCode
		{
			get { return (System.String)GetValue((int)ItemFieldIndex.ItemCode, true); }
			set	{ SetValue((int)ItemFieldIndex.ItemCode, value); }
		}

		/// <summary> The Skucode property of the Entity Item<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblItem"."SKUCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Skucode
		{
			get { return (System.String)GetValue((int)ItemFieldIndex.Skucode, true); }
			set	{ SetValue((int)ItemFieldIndex.Skucode, value); }
		}

		/// <summary> The ManufacturerName property of the Entity Item<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblItem"."ManufacturerName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ManufacturerName
		{
			get { return (System.String)GetValue((int)ItemFieldIndex.ManufacturerName, true); }
			set	{ SetValue((int)ItemFieldIndex.ManufacturerName, value); }
		}

		/// <summary> The ManufacturerId property of the Entity Item<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblItem"."ManufacturerID"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ManufacturerId
		{
			get { return (System.String)GetValue((int)ItemFieldIndex.ManufacturerId, true); }
			set	{ SetValue((int)ItemFieldIndex.ManufacturerId, value); }
		}

		/// <summary> The DateCreated property of the Entity Item<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblItem"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)ItemFieldIndex.DateCreated, true); }
			set	{ SetValue((int)ItemFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity Item<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblItem"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)ItemFieldIndex.DateModified, true); }
			set	{ SetValue((int)ItemFieldIndex.DateModified, value); }
		}

		/// <summary> The IsActive property of the Entity Item<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblItem"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)ItemFieldIndex.IsActive, true); }
			set	{ SetValue((int)ItemFieldIndex.IsActive, value); }
		}

		/// <summary> The IsAllocated property of the Entity Item<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblItem"."IsAllocated"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsAllocated
		{
			get { return (Nullable<System.Boolean>)GetValue((int)ItemFieldIndex.IsAllocated, false); }
			set	{ SetValue((int)ItemFieldIndex.IsAllocated, value); }
		}

		/// <summary> The Notes property of the Entity Item<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblItem"."Notes"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Notes
		{
			get { return (System.String)GetValue((int)ItemFieldIndex.Notes, true); }
			set	{ SetValue((int)ItemFieldIndex.Notes, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PodInventoryItemEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodInventoryItemEntity))]
		public virtual EntityCollection<PodInventoryItemEntity> PodInventoryItem
		{
			get
			{
				if(_podInventoryItem==null)
				{
					_podInventoryItem = new EntityCollection<PodInventoryItemEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodInventoryItemEntityFactory)));
					_podInventoryItem.SetContainingEntityInfo(this, "Item");
				}
				return _podInventoryItem;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PodDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodDetailsEntity))]
		public virtual EntityCollection<PodDetailsEntity> PodDetailsCollectionViaPodInventoryItem
		{
			get
			{
				if(_podDetailsCollectionViaPodInventoryItem==null)
				{
					_podDetailsCollectionViaPodInventoryItem = new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory)));
					_podDetailsCollectionViaPodInventoryItem.IsReadOnly=true;
				}
				return _podDetailsCollectionViaPodInventoryItem;
			}
		}

		/// <summary> Gets / sets related entity of type 'InventoryItemEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual InventoryItemEntity InventoryItem
		{
			get
			{
				return _inventoryItem;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncInventoryItem(value);
				}
				else
				{
					if(value==null)
					{
						if(_inventoryItem != null)
						{
							_inventoryItem.UnsetRelatedEntity(this, "Item");
						}
					}
					else
					{
						if(_inventoryItem!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Item");
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
			get { return (int)Falcon.Data.EntityType.ItemEntity; }
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
