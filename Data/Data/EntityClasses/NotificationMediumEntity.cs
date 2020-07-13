///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:44
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
	/// Entity class which represents the entity 'NotificationMedium'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class NotificationMediumEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<NotificationEntity> _notification;
		private EntityCollection<NotificationTypeEntity> _notificationType;
		private EntityCollection<NotificationTypeEntity> _notificationTypeCollectionViaNotification;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaNotificationType;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaNotification;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{

			/// <summary>Member name Notification</summary>
			public static readonly string Notification = "Notification";
			/// <summary>Member name NotificationType</summary>
			public static readonly string NotificationType = "NotificationType";
			/// <summary>Member name NotificationTypeCollectionViaNotification</summary>
			public static readonly string NotificationTypeCollectionViaNotification = "NotificationTypeCollectionViaNotification";
			/// <summary>Member name OrganizationRoleUserCollectionViaNotificationType</summary>
			public static readonly string OrganizationRoleUserCollectionViaNotificationType = "OrganizationRoleUserCollectionViaNotificationType";
			/// <summary>Member name OrganizationRoleUserCollectionViaNotification</summary>
			public static readonly string OrganizationRoleUserCollectionViaNotification = "OrganizationRoleUserCollectionViaNotification";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static NotificationMediumEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public NotificationMediumEntity():base("NotificationMediumEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public NotificationMediumEntity(IEntityFields2 fields):base("NotificationMediumEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this NotificationMediumEntity</param>
		public NotificationMediumEntity(IValidator validator):base("NotificationMediumEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="notificationMediumId">PK value for NotificationMedium which data should be fetched into this NotificationMedium object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public NotificationMediumEntity(System.Int32 notificationMediumId):base("NotificationMediumEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.NotificationMediumId = notificationMediumId;
		}

		/// <summary> CTor</summary>
		/// <param name="notificationMediumId">PK value for NotificationMedium which data should be fetched into this NotificationMedium object</param>
		/// <param name="validator">The custom validator object for this NotificationMediumEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public NotificationMediumEntity(System.Int32 notificationMediumId, IValidator validator):base("NotificationMediumEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.NotificationMediumId = notificationMediumId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected NotificationMediumEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_notification = (EntityCollection<NotificationEntity>)info.GetValue("_notification", typeof(EntityCollection<NotificationEntity>));
				_notificationType = (EntityCollection<NotificationTypeEntity>)info.GetValue("_notificationType", typeof(EntityCollection<NotificationTypeEntity>));
				_notificationTypeCollectionViaNotification = (EntityCollection<NotificationTypeEntity>)info.GetValue("_notificationTypeCollectionViaNotification", typeof(EntityCollection<NotificationTypeEntity>));
				_organizationRoleUserCollectionViaNotificationType = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaNotificationType", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaNotification = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaNotification", typeof(EntityCollection<OrganizationRoleUserEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((NotificationMediumFieldIndex)fieldIndex)
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

				case "Notification":
					this.Notification.Add((NotificationEntity)entity);
					break;
				case "NotificationType":
					this.NotificationType.Add((NotificationTypeEntity)entity);
					break;
				case "NotificationTypeCollectionViaNotification":
					this.NotificationTypeCollectionViaNotification.IsReadOnly = false;
					this.NotificationTypeCollectionViaNotification.Add((NotificationTypeEntity)entity);
					this.NotificationTypeCollectionViaNotification.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaNotificationType":
					this.OrganizationRoleUserCollectionViaNotificationType.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaNotificationType.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaNotificationType.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaNotification":
					this.OrganizationRoleUserCollectionViaNotification.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaNotification.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaNotification.IsReadOnly = true;
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
			return NotificationMediumEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{

				case "Notification":
					toReturn.Add(NotificationMediumEntity.Relations.NotificationEntityUsingNotificationMediumId);
					break;
				case "NotificationType":
					toReturn.Add(NotificationMediumEntity.Relations.NotificationTypeEntityUsingNotificationMediumId);
					break;
				case "NotificationTypeCollectionViaNotification":
					toReturn.Add(NotificationMediumEntity.Relations.NotificationEntityUsingNotificationMediumId, "NotificationMediumEntity__", "Notification_", JoinHint.None);
					toReturn.Add(NotificationEntity.Relations.NotificationTypeEntityUsingNotificationTypeId, "Notification_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaNotificationType":
					toReturn.Add(NotificationMediumEntity.Relations.NotificationTypeEntityUsingNotificationMediumId, "NotificationMediumEntity__", "NotificationType_", JoinHint.None);
					toReturn.Add(NotificationTypeEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, "NotificationType_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaNotification":
					toReturn.Add(NotificationMediumEntity.Relations.NotificationEntityUsingNotificationMediumId, "NotificationMediumEntity__", "Notification_", JoinHint.None);
					toReturn.Add(NotificationEntity.Relations.OrganizationRoleUserEntityUsingRequestedByOrgRoleUserId, "Notification_", string.Empty, JoinHint.None);
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

				case "Notification":
					this.Notification.Add((NotificationEntity)relatedEntity);
					break;
				case "NotificationType":
					this.NotificationType.Add((NotificationTypeEntity)relatedEntity);
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

				case "Notification":
					base.PerformRelatedEntityRemoval(this.Notification, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "NotificationType":
					base.PerformRelatedEntityRemoval(this.NotificationType, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.Notification);
			toReturn.Add(this.NotificationType);

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
				info.AddValue("_notification", ((_notification!=null) && (_notification.Count>0) && !this.MarkedForDeletion)?_notification:null);
				info.AddValue("_notificationType", ((_notificationType!=null) && (_notificationType.Count>0) && !this.MarkedForDeletion)?_notificationType:null);
				info.AddValue("_notificationTypeCollectionViaNotification", ((_notificationTypeCollectionViaNotification!=null) && (_notificationTypeCollectionViaNotification.Count>0) && !this.MarkedForDeletion)?_notificationTypeCollectionViaNotification:null);
				info.AddValue("_organizationRoleUserCollectionViaNotificationType", ((_organizationRoleUserCollectionViaNotificationType!=null) && (_organizationRoleUserCollectionViaNotificationType.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaNotificationType:null);
				info.AddValue("_organizationRoleUserCollectionViaNotification", ((_organizationRoleUserCollectionViaNotification!=null) && (_organizationRoleUserCollectionViaNotification.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaNotification:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(NotificationMediumFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(NotificationMediumFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new NotificationMediumRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Notification' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationFields.NotificationMediumId, null, ComparisonOperator.Equal, this.NotificationMediumId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'NotificationType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotificationType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationTypeFields.NotificationMediumId, null, ComparisonOperator.Equal, this.NotificationMediumId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'NotificationType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotificationTypeCollectionViaNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("NotificationTypeCollectionViaNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationMediumFields.NotificationMediumId, null, ComparisonOperator.Equal, this.NotificationMediumId, "NotificationMediumEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaNotificationType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaNotificationType"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationMediumFields.NotificationMediumId, null, ComparisonOperator.Equal, this.NotificationMediumId, "NotificationMediumEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationMediumFields.NotificationMediumId, null, ComparisonOperator.Equal, this.NotificationMediumId, "NotificationMediumEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.NotificationMediumEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(NotificationMediumEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._notification);
			collectionsQueue.Enqueue(this._notificationType);
			collectionsQueue.Enqueue(this._notificationTypeCollectionViaNotification);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaNotificationType);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaNotification);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._notification = (EntityCollection<NotificationEntity>) collectionsQueue.Dequeue();
			this._notificationType = (EntityCollection<NotificationTypeEntity>) collectionsQueue.Dequeue();
			this._notificationTypeCollectionViaNotification = (EntityCollection<NotificationTypeEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaNotificationType = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaNotification = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._notification != null)
			{
				return true;
			}
			if (this._notificationType != null)
			{
				return true;
			}
			if (this._notificationTypeCollectionViaNotification != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaNotificationType != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaNotification != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NotificationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NotificationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationTypeEntityFactory))) : null);
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

			toReturn.Add("Notification", _notification);
			toReturn.Add("NotificationType", _notificationType);
			toReturn.Add("NotificationTypeCollectionViaNotification", _notificationTypeCollectionViaNotification);
			toReturn.Add("OrganizationRoleUserCollectionViaNotificationType", _organizationRoleUserCollectionViaNotificationType);
			toReturn.Add("OrganizationRoleUserCollectionViaNotification", _organizationRoleUserCollectionViaNotification);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_notification!=null)
			{
				_notification.ActiveContext = base.ActiveContext;
			}
			if(_notificationType!=null)
			{
				_notificationType.ActiveContext = base.ActiveContext;
			}
			if(_notificationTypeCollectionViaNotification!=null)
			{
				_notificationTypeCollectionViaNotification.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaNotificationType!=null)
			{
				_organizationRoleUserCollectionViaNotificationType.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaNotification!=null)
			{
				_organizationRoleUserCollectionViaNotification.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_notification = null;
			_notificationType = null;
			_notificationTypeCollectionViaNotification = null;
			_organizationRoleUserCollectionViaNotificationType = null;
			_organizationRoleUserCollectionViaNotification = null;


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

			_fieldsCustomProperties.Add("NotificationMediumId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NotificationMedium", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this NotificationMediumEntity</param>
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
		public  static NotificationMediumRelations Relations
		{
			get	{ return new NotificationMediumRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Notification' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotification
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<NotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationEntityFactory))),
					(IEntityRelation)GetRelationsForField("Notification")[0], (int)Falcon.Data.EntityType.NotificationMediumEntity, (int)Falcon.Data.EntityType.NotificationEntity, 0, null, null, null, null, "Notification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotificationType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotificationType
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<NotificationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("NotificationType")[0], (int)Falcon.Data.EntityType.NotificationMediumEntity, (int)Falcon.Data.EntityType.NotificationTypeEntity, 0, null, null, null, null, "NotificationType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotificationType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotificationTypeCollectionViaNotification
		{
			get
			{
				IEntityRelation intermediateRelation = NotificationMediumEntity.Relations.NotificationEntityUsingNotificationMediumId;
				intermediateRelation.SetAliases(string.Empty, "Notification_");
				return new PrefetchPathElement2(new EntityCollection<NotificationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotificationMediumEntity, (int)Falcon.Data.EntityType.NotificationTypeEntity, 0, null, null, GetRelationsForField("NotificationTypeCollectionViaNotification"), null, "NotificationTypeCollectionViaNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaNotificationType
		{
			get
			{
				IEntityRelation intermediateRelation = NotificationMediumEntity.Relations.NotificationTypeEntityUsingNotificationMediumId;
				intermediateRelation.SetAliases(string.Empty, "NotificationType_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotificationMediumEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaNotificationType"), null, "OrganizationRoleUserCollectionViaNotificationType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaNotification
		{
			get
			{
				IEntityRelation intermediateRelation = NotificationMediumEntity.Relations.NotificationEntityUsingNotificationMediumId;
				intermediateRelation.SetAliases(string.Empty, "Notification_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotificationMediumEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaNotification"), null, "OrganizationRoleUserCollectionViaNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return NotificationMediumEntity.CustomProperties;}
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
			get { return NotificationMediumEntity.FieldsCustomProperties;}
		}

		/// <summary> The NotificationMediumId property of the Entity NotificationMedium<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotificationMedium"."NotificationMediumID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 NotificationMediumId
		{
			get { return (System.Int32)GetValue((int)NotificationMediumFieldIndex.NotificationMediumId, true); }
			set	{ SetValue((int)NotificationMediumFieldIndex.NotificationMediumId, value); }
		}

		/// <summary> The NotificationMedium property of the Entity NotificationMedium<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotificationMedium"."NotificationMedium"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String NotificationMedium
		{
			get { return (System.String)GetValue((int)NotificationMediumFieldIndex.NotificationMedium, true); }
			set	{ SetValue((int)NotificationMediumFieldIndex.NotificationMedium, value); }
		}

		/// <summary> The Description property of the Entity NotificationMedium<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotificationMedium"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)NotificationMediumFieldIndex.Description, true); }
			set	{ SetValue((int)NotificationMediumFieldIndex.Description, value); }
		}

		/// <summary> The DateCreated property of the Entity NotificationMedium<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotificationMedium"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)NotificationMediumFieldIndex.DateCreated, true); }
			set	{ SetValue((int)NotificationMediumFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity NotificationMedium<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotificationMedium"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)NotificationMediumFieldIndex.DateModified, false); }
			set	{ SetValue((int)NotificationMediumFieldIndex.DateModified, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NotificationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NotificationEntity))]
		public virtual EntityCollection<NotificationEntity> Notification
		{
			get
			{
				if(_notification==null)
				{
					_notification = new EntityCollection<NotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationEntityFactory)));
					_notification.SetContainingEntityInfo(this, "NotificationMedium");
				}
				return _notification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NotificationTypeEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NotificationTypeEntity))]
		public virtual EntityCollection<NotificationTypeEntity> NotificationType
		{
			get
			{
				if(_notificationType==null)
				{
					_notificationType = new EntityCollection<NotificationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationTypeEntityFactory)));
					_notificationType.SetContainingEntityInfo(this, "NotificationMedium");
				}
				return _notificationType;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NotificationTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NotificationTypeEntity))]
		public virtual EntityCollection<NotificationTypeEntity> NotificationTypeCollectionViaNotification
		{
			get
			{
				if(_notificationTypeCollectionViaNotification==null)
				{
					_notificationTypeCollectionViaNotification = new EntityCollection<NotificationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationTypeEntityFactory)));
					_notificationTypeCollectionViaNotification.IsReadOnly=true;
				}
				return _notificationTypeCollectionViaNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaNotificationType
		{
			get
			{
				if(_organizationRoleUserCollectionViaNotificationType==null)
				{
					_organizationRoleUserCollectionViaNotificationType = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaNotificationType.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaNotificationType;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaNotification
		{
			get
			{
				if(_organizationRoleUserCollectionViaNotification==null)
				{
					_organizationRoleUserCollectionViaNotification = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaNotification.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaNotification;
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
			get { return (int)Falcon.Data.EntityType.NotificationMediumEntity; }
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
