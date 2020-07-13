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
	/// Entity class which represents the entity 'MessageDetails'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class MessageDetailsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<MessageDetailsEntity> _messageDetails_;
		private EntityCollection<MessageUserActivityEntity> _messageUserActivity;
		private EntityCollection<ItemDetailsEntity> _itemDetailsCollectionViaMessageDetails;
		private EntityCollection<MessageSendTypeOptionsEntity> _messageSendTypeOptionsCollectionViaMessageUserActivity;
		private ItemDetailsEntity _itemDetails;
		private MessageDetailsEntity _messageDetails;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name ItemDetails</summary>
			public static readonly string ItemDetails = "ItemDetails";
			/// <summary>Member name MessageDetails</summary>
			public static readonly string MessageDetails = "MessageDetails";
			/// <summary>Member name MessageDetails_</summary>
			public static readonly string MessageDetails_ = "MessageDetails_";
			/// <summary>Member name MessageUserActivity</summary>
			public static readonly string MessageUserActivity = "MessageUserActivity";
			/// <summary>Member name ItemDetailsCollectionViaMessageDetails</summary>
			public static readonly string ItemDetailsCollectionViaMessageDetails = "ItemDetailsCollectionViaMessageDetails";
			/// <summary>Member name MessageSendTypeOptionsCollectionViaMessageUserActivity</summary>
			public static readonly string MessageSendTypeOptionsCollectionViaMessageUserActivity = "MessageSendTypeOptionsCollectionViaMessageUserActivity";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static MessageDetailsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public MessageDetailsEntity():base("MessageDetailsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public MessageDetailsEntity(IEntityFields2 fields):base("MessageDetailsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this MessageDetailsEntity</param>
		public MessageDetailsEntity(IValidator validator):base("MessageDetailsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="messageId">PK value for MessageDetails which data should be fetched into this MessageDetails object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MessageDetailsEntity(System.Int64 messageId):base("MessageDetailsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.MessageId = messageId;
		}

		/// <summary> CTor</summary>
		/// <param name="messageId">PK value for MessageDetails which data should be fetched into this MessageDetails object</param>
		/// <param name="validator">The custom validator object for this MessageDetailsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MessageDetailsEntity(System.Int64 messageId, IValidator validator):base("MessageDetailsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.MessageId = messageId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MessageDetailsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_messageDetails_ = (EntityCollection<MessageDetailsEntity>)info.GetValue("_messageDetails_", typeof(EntityCollection<MessageDetailsEntity>));
				_messageUserActivity = (EntityCollection<MessageUserActivityEntity>)info.GetValue("_messageUserActivity", typeof(EntityCollection<MessageUserActivityEntity>));
				_itemDetailsCollectionViaMessageDetails = (EntityCollection<ItemDetailsEntity>)info.GetValue("_itemDetailsCollectionViaMessageDetails", typeof(EntityCollection<ItemDetailsEntity>));
				_messageSendTypeOptionsCollectionViaMessageUserActivity = (EntityCollection<MessageSendTypeOptionsEntity>)info.GetValue("_messageSendTypeOptionsCollectionViaMessageUserActivity", typeof(EntityCollection<MessageSendTypeOptionsEntity>));
				_itemDetails = (ItemDetailsEntity)info.GetValue("_itemDetails", typeof(ItemDetailsEntity));
				if(_itemDetails!=null)
				{
					_itemDetails.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_messageDetails = (MessageDetailsEntity)info.GetValue("_messageDetails", typeof(MessageDetailsEntity));
				if(_messageDetails!=null)
				{
					_messageDetails.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((MessageDetailsFieldIndex)fieldIndex)
			{
				case MessageDetailsFieldIndex.ParentMessageId:
					DesetupSyncMessageDetails(true, false);
					break;
				case MessageDetailsFieldIndex.ItemId:
					DesetupSyncItemDetails(true, false);
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
				case "ItemDetails":
					this.ItemDetails = (ItemDetailsEntity)entity;
					break;
				case "MessageDetails":
					this.MessageDetails = (MessageDetailsEntity)entity;
					break;
				case "MessageDetails_":
					this.MessageDetails_.Add((MessageDetailsEntity)entity);
					break;
				case "MessageUserActivity":
					this.MessageUserActivity.Add((MessageUserActivityEntity)entity);
					break;
				case "ItemDetailsCollectionViaMessageDetails":
					this.ItemDetailsCollectionViaMessageDetails.IsReadOnly = false;
					this.ItemDetailsCollectionViaMessageDetails.Add((ItemDetailsEntity)entity);
					this.ItemDetailsCollectionViaMessageDetails.IsReadOnly = true;
					break;
				case "MessageSendTypeOptionsCollectionViaMessageUserActivity":
					this.MessageSendTypeOptionsCollectionViaMessageUserActivity.IsReadOnly = false;
					this.MessageSendTypeOptionsCollectionViaMessageUserActivity.Add((MessageSendTypeOptionsEntity)entity);
					this.MessageSendTypeOptionsCollectionViaMessageUserActivity.IsReadOnly = true;
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
			return MessageDetailsEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "ItemDetails":
					toReturn.Add(MessageDetailsEntity.Relations.ItemDetailsEntityUsingItemId);
					break;
				case "MessageDetails":
					toReturn.Add(MessageDetailsEntity.Relations.MessageDetailsEntityUsingMessageIdParentMessageId);
					break;
				case "MessageDetails_":
					toReturn.Add(MessageDetailsEntity.Relations.MessageDetailsEntityUsingParentMessageId);
					break;
				case "MessageUserActivity":
					toReturn.Add(MessageDetailsEntity.Relations.MessageUserActivityEntityUsingMessageId);
					break;
				case "ItemDetailsCollectionViaMessageDetails":
					toReturn.Add(MessageDetailsEntity.Relations.MessageDetailsEntityUsingParentMessageId, "MessageDetailsEntity__", "MessageDetails_", JoinHint.None);
					toReturn.Add(MessageDetailsEntity.Relations.ItemDetailsEntityUsingItemId, "MessageDetails_", string.Empty, JoinHint.None);
					break;
				case "MessageSendTypeOptionsCollectionViaMessageUserActivity":
					toReturn.Add(MessageDetailsEntity.Relations.MessageUserActivityEntityUsingMessageId, "MessageDetailsEntity__", "MessageUserActivity_", JoinHint.None);
					toReturn.Add(MessageUserActivityEntity.Relations.MessageSendTypeOptionsEntityUsingMessageSendoptionId, "MessageUserActivity_", string.Empty, JoinHint.None);
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
				case "ItemDetails":
					SetupSyncItemDetails(relatedEntity);
					break;
				case "MessageDetails":
					SetupSyncMessageDetails(relatedEntity);
					break;
				case "MessageDetails_":
					this.MessageDetails_.Add((MessageDetailsEntity)relatedEntity);
					break;
				case "MessageUserActivity":
					this.MessageUserActivity.Add((MessageUserActivityEntity)relatedEntity);
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
				case "ItemDetails":
					DesetupSyncItemDetails(false, true);
					break;
				case "MessageDetails":
					DesetupSyncMessageDetails(false, true);
					break;
				case "MessageDetails_":
					base.PerformRelatedEntityRemoval(this.MessageDetails_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MessageUserActivity":
					base.PerformRelatedEntityRemoval(this.MessageUserActivity, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_itemDetails!=null)
			{
				toReturn.Add(_itemDetails);
			}
			if(_messageDetails!=null)
			{
				toReturn.Add(_messageDetails);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.MessageDetails_);
			toReturn.Add(this.MessageUserActivity);

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
				info.AddValue("_messageDetails_", ((_messageDetails_!=null) && (_messageDetails_.Count>0) && !this.MarkedForDeletion)?_messageDetails_:null);
				info.AddValue("_messageUserActivity", ((_messageUserActivity!=null) && (_messageUserActivity.Count>0) && !this.MarkedForDeletion)?_messageUserActivity:null);
				info.AddValue("_itemDetailsCollectionViaMessageDetails", ((_itemDetailsCollectionViaMessageDetails!=null) && (_itemDetailsCollectionViaMessageDetails.Count>0) && !this.MarkedForDeletion)?_itemDetailsCollectionViaMessageDetails:null);
				info.AddValue("_messageSendTypeOptionsCollectionViaMessageUserActivity", ((_messageSendTypeOptionsCollectionViaMessageUserActivity!=null) && (_messageSendTypeOptionsCollectionViaMessageUserActivity.Count>0) && !this.MarkedForDeletion)?_messageSendTypeOptionsCollectionViaMessageUserActivity:null);
				info.AddValue("_itemDetails", (!this.MarkedForDeletion?_itemDetails:null));
				info.AddValue("_messageDetails", (!this.MarkedForDeletion?_messageDetails:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(MessageDetailsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(MessageDetailsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new MessageDetailsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MessageDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMessageDetails_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MessageDetailsFields.ParentMessageId, null, ComparisonOperator.Equal, this.MessageId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MessageUserActivity' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMessageUserActivity()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MessageUserActivityFields.MessageId, null, ComparisonOperator.Equal, this.MessageId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ItemDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoItemDetailsCollectionViaMessageDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ItemDetailsCollectionViaMessageDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MessageDetailsFields.MessageId, null, ComparisonOperator.Equal, this.MessageId, "MessageDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MessageSendTypeOptions' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMessageSendTypeOptionsCollectionViaMessageUserActivity()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("MessageSendTypeOptionsCollectionViaMessageUserActivity"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MessageDetailsFields.MessageId, null, ComparisonOperator.Equal, this.MessageId, "MessageDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ItemDetails' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoItemDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ItemDetailsFields.ItemId, null, ComparisonOperator.Equal, this.ItemId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'MessageDetails' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMessageDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MessageDetailsFields.MessageId, null, ComparisonOperator.Equal, this.ParentMessageId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(HealthYes.Data.EntityType.MessageDetailsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(MessageDetailsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._messageDetails_);
			collectionsQueue.Enqueue(this._messageUserActivity);
			collectionsQueue.Enqueue(this._itemDetailsCollectionViaMessageDetails);
			collectionsQueue.Enqueue(this._messageSendTypeOptionsCollectionViaMessageUserActivity);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._messageDetails_ = (EntityCollection<MessageDetailsEntity>) collectionsQueue.Dequeue();
			this._messageUserActivity = (EntityCollection<MessageUserActivityEntity>) collectionsQueue.Dequeue();
			this._itemDetailsCollectionViaMessageDetails = (EntityCollection<ItemDetailsEntity>) collectionsQueue.Dequeue();
			this._messageSendTypeOptionsCollectionViaMessageUserActivity = (EntityCollection<MessageSendTypeOptionsEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._messageDetails_ != null)
			{
				return true;
			}
			if (this._messageUserActivity != null)
			{
				return true;
			}
			if (this._itemDetailsCollectionViaMessageDetails != null)
			{
				return true;
			}
			if (this._messageSendTypeOptionsCollectionViaMessageUserActivity != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MessageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MessageDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MessageUserActivityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MessageUserActivityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ItemDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ItemDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MessageSendTypeOptionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MessageSendTypeOptionsEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("ItemDetails", _itemDetails);
			toReturn.Add("MessageDetails", _messageDetails);
			toReturn.Add("MessageDetails_", _messageDetails_);
			toReturn.Add("MessageUserActivity", _messageUserActivity);
			toReturn.Add("ItemDetailsCollectionViaMessageDetails", _itemDetailsCollectionViaMessageDetails);
			toReturn.Add("MessageSendTypeOptionsCollectionViaMessageUserActivity", _messageSendTypeOptionsCollectionViaMessageUserActivity);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_messageDetails_!=null)
			{
				_messageDetails_.ActiveContext = base.ActiveContext;
			}
			if(_messageUserActivity!=null)
			{
				_messageUserActivity.ActiveContext = base.ActiveContext;
			}
			if(_itemDetailsCollectionViaMessageDetails!=null)
			{
				_itemDetailsCollectionViaMessageDetails.ActiveContext = base.ActiveContext;
			}
			if(_messageSendTypeOptionsCollectionViaMessageUserActivity!=null)
			{
				_messageSendTypeOptionsCollectionViaMessageUserActivity.ActiveContext = base.ActiveContext;
			}
			if(_itemDetails!=null)
			{
				_itemDetails.ActiveContext = base.ActiveContext;
			}
			if(_messageDetails!=null)
			{
				_messageDetails.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_messageDetails_ = null;
			_messageUserActivity = null;
			_itemDetailsCollectionViaMessageDetails = null;
			_messageSendTypeOptionsCollectionViaMessageUserActivity = null;
			_itemDetails = null;
			_messageDetails = null;

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

			_fieldsCustomProperties.Add("MessageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Subject", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentMessageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Body", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ItemId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _itemDetails</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncItemDetails(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _itemDetails, new PropertyChangedEventHandler( OnItemDetailsPropertyChanged ), "ItemDetails", MessageDetailsEntity.Relations.ItemDetailsEntityUsingItemId, true, signalRelatedEntity, "MessageDetails", resetFKFields, new int[] { (int)MessageDetailsFieldIndex.ItemId } );		
			_itemDetails = null;
		}

		/// <summary> setups the sync logic for member _itemDetails</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncItemDetails(IEntity2 relatedEntity)
		{
			if(_itemDetails!=relatedEntity)
			{
				DesetupSyncItemDetails(true, true);
				_itemDetails = (ItemDetailsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _itemDetails, new PropertyChangedEventHandler( OnItemDetailsPropertyChanged ), "ItemDetails", MessageDetailsEntity.Relations.ItemDetailsEntityUsingItemId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnItemDetailsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _messageDetails</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncMessageDetails(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _messageDetails, new PropertyChangedEventHandler( OnMessageDetailsPropertyChanged ), "MessageDetails", MessageDetailsEntity.Relations.MessageDetailsEntityUsingMessageIdParentMessageId, true, signalRelatedEntity, "MessageDetails_", resetFKFields, new int[] { (int)MessageDetailsFieldIndex.ParentMessageId } );		
			_messageDetails = null;
		}

		/// <summary> setups the sync logic for member _messageDetails</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncMessageDetails(IEntity2 relatedEntity)
		{
			if(_messageDetails!=relatedEntity)
			{
				DesetupSyncMessageDetails(true, true);
				_messageDetails = (MessageDetailsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _messageDetails, new PropertyChangedEventHandler( OnMessageDetailsPropertyChanged ), "MessageDetails", MessageDetailsEntity.Relations.MessageDetailsEntityUsingMessageIdParentMessageId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMessageDetailsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this MessageDetailsEntity</param>
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
		public  static MessageDetailsRelations Relations
		{
			get	{ return new MessageDetailsRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MessageDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMessageDetails_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MessageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MessageDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("MessageDetails_")[0], (int)HealthYes.Data.EntityType.MessageDetailsEntity, (int)HealthYes.Data.EntityType.MessageDetailsEntity, 0, null, null, null, null, "MessageDetails_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MessageUserActivity' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMessageUserActivity
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MessageUserActivityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MessageUserActivityEntityFactory))),
					(IEntityRelation)GetRelationsForField("MessageUserActivity")[0], (int)HealthYes.Data.EntityType.MessageDetailsEntity, (int)HealthYes.Data.EntityType.MessageUserActivityEntity, 0, null, null, null, null, "MessageUserActivity", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ItemDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathItemDetailsCollectionViaMessageDetails
		{
			get
			{
				IEntityRelation intermediateRelation = MessageDetailsEntity.Relations.MessageDetailsEntityUsingParentMessageId;
				intermediateRelation.SetAliases(string.Empty, "MessageDetails_");
				return new PrefetchPathElement2(new EntityCollection<ItemDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ItemDetailsEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.MessageDetailsEntity, (int)HealthYes.Data.EntityType.ItemDetailsEntity, 0, null, null, GetRelationsForField("ItemDetailsCollectionViaMessageDetails"), null, "ItemDetailsCollectionViaMessageDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MessageSendTypeOptions' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMessageSendTypeOptionsCollectionViaMessageUserActivity
		{
			get
			{
				IEntityRelation intermediateRelation = MessageDetailsEntity.Relations.MessageUserActivityEntityUsingMessageId;
				intermediateRelation.SetAliases(string.Empty, "MessageUserActivity_");
				return new PrefetchPathElement2(new EntityCollection<MessageSendTypeOptionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MessageSendTypeOptionsEntityFactory))), intermediateRelation,
					(int)HealthYes.Data.EntityType.MessageDetailsEntity, (int)HealthYes.Data.EntityType.MessageSendTypeOptionsEntity, 0, null, null, GetRelationsForField("MessageSendTypeOptionsCollectionViaMessageUserActivity"), null, "MessageSendTypeOptionsCollectionViaMessageUserActivity", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ItemDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathItemDetails
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ItemDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("ItemDetails")[0], (int)HealthYes.Data.EntityType.MessageDetailsEntity, (int)HealthYes.Data.EntityType.ItemDetailsEntity, 0, null, null, null, null, "ItemDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MessageDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMessageDetails
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(MessageDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("MessageDetails")[0], (int)HealthYes.Data.EntityType.MessageDetailsEntity, (int)HealthYes.Data.EntityType.MessageDetailsEntity, 0, null, null, null, null, "MessageDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return MessageDetailsEntity.CustomProperties;}
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
			get { return MessageDetailsEntity.FieldsCustomProperties;}
		}

		/// <summary> The MessageId property of the Entity MessageDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMessageDetails"."MessageID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 MessageId
		{
			get { return (System.Int64)GetValue((int)MessageDetailsFieldIndex.MessageId, true); }
			set	{ SetValue((int)MessageDetailsFieldIndex.MessageId, value); }
		}

		/// <summary> The Subject property of the Entity MessageDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMessageDetails"."Subject"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Subject
		{
			get { return (System.String)GetValue((int)MessageDetailsFieldIndex.Subject, true); }
			set	{ SetValue((int)MessageDetailsFieldIndex.Subject, value); }
		}

		/// <summary> The DateCreated property of the Entity MessageDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMessageDetails"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)MessageDetailsFieldIndex.DateCreated, true); }
			set	{ SetValue((int)MessageDetailsFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity MessageDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMessageDetails"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)MessageDetailsFieldIndex.DateModified, true); }
			set	{ SetValue((int)MessageDetailsFieldIndex.DateModified, value); }
		}

		/// <summary> The ParentMessageId property of the Entity MessageDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMessageDetails"."ParentMessageID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ParentMessageId
		{
			get { return (System.Int64)GetValue((int)MessageDetailsFieldIndex.ParentMessageId, true); }
			set	{ SetValue((int)MessageDetailsFieldIndex.ParentMessageId, value); }
		}

		/// <summary> The Body property of the Entity MessageDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMessageDetails"."Body"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 5000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Body
		{
			get { return (System.String)GetValue((int)MessageDetailsFieldIndex.Body, true); }
			set	{ SetValue((int)MessageDetailsFieldIndex.Body, value); }
		}

		/// <summary> The ItemId property of the Entity MessageDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblMessageDetails"."ItemID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ItemId
		{
			get { return (System.Int64)GetValue((int)MessageDetailsFieldIndex.ItemId, true); }
			set	{ SetValue((int)MessageDetailsFieldIndex.ItemId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MessageDetailsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MessageDetailsEntity))]
		public virtual EntityCollection<MessageDetailsEntity> MessageDetails_
		{
			get
			{
				if(_messageDetails_==null)
				{
					_messageDetails_ = new EntityCollection<MessageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MessageDetailsEntityFactory)));
					_messageDetails_.SetContainingEntityInfo(this, "MessageDetails");
				}
				return _messageDetails_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MessageUserActivityEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MessageUserActivityEntity))]
		public virtual EntityCollection<MessageUserActivityEntity> MessageUserActivity
		{
			get
			{
				if(_messageUserActivity==null)
				{
					_messageUserActivity = new EntityCollection<MessageUserActivityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MessageUserActivityEntityFactory)));
					_messageUserActivity.SetContainingEntityInfo(this, "MessageDetails");
				}
				return _messageUserActivity;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ItemDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ItemDetailsEntity))]
		public virtual EntityCollection<ItemDetailsEntity> ItemDetailsCollectionViaMessageDetails
		{
			get
			{
				if(_itemDetailsCollectionViaMessageDetails==null)
				{
					_itemDetailsCollectionViaMessageDetails = new EntityCollection<ItemDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ItemDetailsEntityFactory)));
					_itemDetailsCollectionViaMessageDetails.IsReadOnly=true;
				}
				return _itemDetailsCollectionViaMessageDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MessageSendTypeOptionsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MessageSendTypeOptionsEntity))]
		public virtual EntityCollection<MessageSendTypeOptionsEntity> MessageSendTypeOptionsCollectionViaMessageUserActivity
		{
			get
			{
				if(_messageSendTypeOptionsCollectionViaMessageUserActivity==null)
				{
					_messageSendTypeOptionsCollectionViaMessageUserActivity = new EntityCollection<MessageSendTypeOptionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MessageSendTypeOptionsEntityFactory)));
					_messageSendTypeOptionsCollectionViaMessageUserActivity.IsReadOnly=true;
				}
				return _messageSendTypeOptionsCollectionViaMessageUserActivity;
			}
		}

		/// <summary> Gets / sets related entity of type 'ItemDetailsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ItemDetailsEntity ItemDetails
		{
			get
			{
				return _itemDetails;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncItemDetails(value);
				}
				else
				{
					if(value==null)
					{
						if(_itemDetails != null)
						{
							_itemDetails.UnsetRelatedEntity(this, "MessageDetails");
						}
					}
					else
					{
						if(_itemDetails!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MessageDetails");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'MessageDetailsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual MessageDetailsEntity MessageDetails
		{
			get
			{
				return _messageDetails;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncMessageDetails(value);
				}
				else
				{
					if(value==null)
					{
						if(_messageDetails != null)
						{
							_messageDetails.UnsetRelatedEntity(this, "MessageDetails_");
						}
					}
					else
					{
						if(_messageDetails!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "MessageDetails_");
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
			get { return (int)HealthYes.Data.EntityType.MessageDetailsEntity; }
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
