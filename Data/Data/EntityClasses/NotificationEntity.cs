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
	/// Entity class which represents the entity 'Notification'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class NotificationEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<EventCustomerNotificationEntity> _eventCustomerNotification;
		private EntityCollection<EventNotificationEntity> _eventNotification;
		private EntityCollection<ProspectCustomerNotificationEntity> _prospectCustomerNotification;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaEventCustomerNotification;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventNotification;
		private EntityCollection<NotificationTypeEntity> _notificationTypeCollectionViaEventCustomerNotification;
		private EntityCollection<ProspectCustomerEntity> _prospectCustomerCollectionViaProspectCustomerNotification;
		private NotificationMediumEntity _notificationMedium;
		private NotificationTypeEntity _notificationType;
		private OrganizationRoleUserEntity _organizationRoleUser;
		private NotificationEmailEntity _notificationEmail;
		private NotificationPhoneEntity _notificationPhone;
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name NotificationMedium</summary>
			public static readonly string NotificationMedium = "NotificationMedium";
			/// <summary>Member name NotificationType</summary>
			public static readonly string NotificationType = "NotificationType";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name EventCustomerNotification</summary>
			public static readonly string EventCustomerNotification = "EventCustomerNotification";
			/// <summary>Member name EventNotification</summary>
			public static readonly string EventNotification = "EventNotification";
			/// <summary>Member name ProspectCustomerNotification</summary>
			public static readonly string ProspectCustomerNotification = "ProspectCustomerNotification";
			/// <summary>Member name EventCustomersCollectionViaEventCustomerNotification</summary>
			public static readonly string EventCustomersCollectionViaEventCustomerNotification = "EventCustomersCollectionViaEventCustomerNotification";
			/// <summary>Member name EventsCollectionViaEventNotification</summary>
			public static readonly string EventsCollectionViaEventNotification = "EventsCollectionViaEventNotification";
			/// <summary>Member name NotificationTypeCollectionViaEventCustomerNotification</summary>
			public static readonly string NotificationTypeCollectionViaEventCustomerNotification = "NotificationTypeCollectionViaEventCustomerNotification";
			/// <summary>Member name ProspectCustomerCollectionViaProspectCustomerNotification</summary>
			public static readonly string ProspectCustomerCollectionViaProspectCustomerNotification = "ProspectCustomerCollectionViaProspectCustomerNotification";
			/// <summary>Member name NotificationEmail</summary>
			public static readonly string NotificationEmail = "NotificationEmail";
			/// <summary>Member name NotificationPhone</summary>
			public static readonly string NotificationPhone = "NotificationPhone";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static NotificationEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public NotificationEntity():base("NotificationEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public NotificationEntity(IEntityFields2 fields):base("NotificationEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this NotificationEntity</param>
		public NotificationEntity(IValidator validator):base("NotificationEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="notificationId">PK value for Notification which data should be fetched into this Notification object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public NotificationEntity(System.Int64 notificationId):base("NotificationEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.NotificationId = notificationId;
		}

		/// <summary> CTor</summary>
		/// <param name="notificationId">PK value for Notification which data should be fetched into this Notification object</param>
		/// <param name="validator">The custom validator object for this NotificationEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public NotificationEntity(System.Int64 notificationId, IValidator validator):base("NotificationEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.NotificationId = notificationId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected NotificationEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_eventCustomerNotification = (EntityCollection<EventCustomerNotificationEntity>)info.GetValue("_eventCustomerNotification", typeof(EntityCollection<EventCustomerNotificationEntity>));
				_eventNotification = (EntityCollection<EventNotificationEntity>)info.GetValue("_eventNotification", typeof(EntityCollection<EventNotificationEntity>));
				_prospectCustomerNotification = (EntityCollection<ProspectCustomerNotificationEntity>)info.GetValue("_prospectCustomerNotification", typeof(EntityCollection<ProspectCustomerNotificationEntity>));
				_eventCustomersCollectionViaEventCustomerNotification = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaEventCustomerNotification", typeof(EntityCollection<EventCustomersEntity>));
				_eventsCollectionViaEventNotification = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventNotification", typeof(EntityCollection<EventsEntity>));
				_notificationTypeCollectionViaEventCustomerNotification = (EntityCollection<NotificationTypeEntity>)info.GetValue("_notificationTypeCollectionViaEventCustomerNotification", typeof(EntityCollection<NotificationTypeEntity>));
				_prospectCustomerCollectionViaProspectCustomerNotification = (EntityCollection<ProspectCustomerEntity>)info.GetValue("_prospectCustomerCollectionViaProspectCustomerNotification", typeof(EntityCollection<ProspectCustomerEntity>));
				_notificationMedium = (NotificationMediumEntity)info.GetValue("_notificationMedium", typeof(NotificationMediumEntity));
				if(_notificationMedium!=null)
				{
					_notificationMedium.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_notificationType = (NotificationTypeEntity)info.GetValue("_notificationType", typeof(NotificationTypeEntity));
				if(_notificationType!=null)
				{
					_notificationType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser!=null)
				{
					_organizationRoleUser.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_notificationEmail = (NotificationEmailEntity)info.GetValue("_notificationEmail", typeof(NotificationEmailEntity));
				if(_notificationEmail!=null)
				{
					_notificationEmail.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_notificationPhone = (NotificationPhoneEntity)info.GetValue("_notificationPhone", typeof(NotificationPhoneEntity));
				if(_notificationPhone!=null)
				{
					_notificationPhone.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((NotificationFieldIndex)fieldIndex)
			{
				case NotificationFieldIndex.NotificationMediumId:
					DesetupSyncNotificationMedium(true, false);
					break;
				case NotificationFieldIndex.NotificationTypeId:
					DesetupSyncNotificationType(true, false);
					break;
				case NotificationFieldIndex.RequestedByOrgRoleUserId:
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
				case "NotificationMedium":
					this.NotificationMedium = (NotificationMediumEntity)entity;
					break;
				case "NotificationType":
					this.NotificationType = (NotificationTypeEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "EventCustomerNotification":
					this.EventCustomerNotification.Add((EventCustomerNotificationEntity)entity);
					break;
				case "EventNotification":
					this.EventNotification.Add((EventNotificationEntity)entity);
					break;
				case "ProspectCustomerNotification":
					this.ProspectCustomerNotification.Add((ProspectCustomerNotificationEntity)entity);
					break;
				case "EventCustomersCollectionViaEventCustomerNotification":
					this.EventCustomersCollectionViaEventCustomerNotification.IsReadOnly = false;
					this.EventCustomersCollectionViaEventCustomerNotification.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaEventCustomerNotification.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventNotification":
					this.EventsCollectionViaEventNotification.IsReadOnly = false;
					this.EventsCollectionViaEventNotification.Add((EventsEntity)entity);
					this.EventsCollectionViaEventNotification.IsReadOnly = true;
					break;
				case "NotificationTypeCollectionViaEventCustomerNotification":
					this.NotificationTypeCollectionViaEventCustomerNotification.IsReadOnly = false;
					this.NotificationTypeCollectionViaEventCustomerNotification.Add((NotificationTypeEntity)entity);
					this.NotificationTypeCollectionViaEventCustomerNotification.IsReadOnly = true;
					break;
				case "ProspectCustomerCollectionViaProspectCustomerNotification":
					this.ProspectCustomerCollectionViaProspectCustomerNotification.IsReadOnly = false;
					this.ProspectCustomerCollectionViaProspectCustomerNotification.Add((ProspectCustomerEntity)entity);
					this.ProspectCustomerCollectionViaProspectCustomerNotification.IsReadOnly = true;
					break;
				case "NotificationEmail":
					this.NotificationEmail = (NotificationEmailEntity)entity;
					break;
				case "NotificationPhone":
					this.NotificationPhone = (NotificationPhoneEntity)entity;
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
			return NotificationEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "NotificationMedium":
					toReturn.Add(NotificationEntity.Relations.NotificationMediumEntityUsingNotificationMediumId);
					break;
				case "NotificationType":
					toReturn.Add(NotificationEntity.Relations.NotificationTypeEntityUsingNotificationTypeId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(NotificationEntity.Relations.OrganizationRoleUserEntityUsingRequestedByOrgRoleUserId);
					break;
				case "EventCustomerNotification":
					toReturn.Add(NotificationEntity.Relations.EventCustomerNotificationEntityUsingNotificationId);
					break;
				case "EventNotification":
					toReturn.Add(NotificationEntity.Relations.EventNotificationEntityUsingNotificationId);
					break;
				case "ProspectCustomerNotification":
					toReturn.Add(NotificationEntity.Relations.ProspectCustomerNotificationEntityUsingNotificationId);
					break;
				case "EventCustomersCollectionViaEventCustomerNotification":
					toReturn.Add(NotificationEntity.Relations.EventCustomerNotificationEntityUsingNotificationId, "NotificationEntity__", "EventCustomerNotification_", JoinHint.None);
					toReturn.Add(EventCustomerNotificationEntity.Relations.EventCustomersEntityUsingEventCustomerId, "EventCustomerNotification_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventNotification":
					toReturn.Add(NotificationEntity.Relations.EventNotificationEntityUsingNotificationId, "NotificationEntity__", "EventNotification_", JoinHint.None);
					toReturn.Add(EventNotificationEntity.Relations.EventsEntityUsingEventId, "EventNotification_", string.Empty, JoinHint.None);
					break;
				case "NotificationTypeCollectionViaEventCustomerNotification":
					toReturn.Add(NotificationEntity.Relations.EventCustomerNotificationEntityUsingNotificationId, "NotificationEntity__", "EventCustomerNotification_", JoinHint.None);
					toReturn.Add(EventCustomerNotificationEntity.Relations.NotificationTypeEntityUsingNotificationTypeId, "EventCustomerNotification_", string.Empty, JoinHint.None);
					break;
				case "ProspectCustomerCollectionViaProspectCustomerNotification":
					toReturn.Add(NotificationEntity.Relations.ProspectCustomerNotificationEntityUsingNotificationId, "NotificationEntity__", "ProspectCustomerNotification_", JoinHint.None);
					toReturn.Add(ProspectCustomerNotificationEntity.Relations.ProspectCustomerEntityUsingProspectCustomerId, "ProspectCustomerNotification_", string.Empty, JoinHint.None);
					break;
				case "NotificationEmail":
					toReturn.Add(NotificationEntity.Relations.NotificationEmailEntityUsingNotificationEmailId);
					break;
				case "NotificationPhone":
					toReturn.Add(NotificationEntity.Relations.NotificationPhoneEntityUsingNotificationPhoneId);
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
				case "NotificationMedium":
					SetupSyncNotificationMedium(relatedEntity);
					break;
				case "NotificationType":
					SetupSyncNotificationType(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "EventCustomerNotification":
					this.EventCustomerNotification.Add((EventCustomerNotificationEntity)relatedEntity);
					break;
				case "EventNotification":
					this.EventNotification.Add((EventNotificationEntity)relatedEntity);
					break;
				case "ProspectCustomerNotification":
					this.ProspectCustomerNotification.Add((ProspectCustomerNotificationEntity)relatedEntity);
					break;
				case "NotificationEmail":
					SetupSyncNotificationEmail(relatedEntity);
					break;
				case "NotificationPhone":
					SetupSyncNotificationPhone(relatedEntity);
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
				case "NotificationMedium":
					DesetupSyncNotificationMedium(false, true);
					break;
				case "NotificationType":
					DesetupSyncNotificationType(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "EventCustomerNotification":
					base.PerformRelatedEntityRemoval(this.EventCustomerNotification, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventNotification":
					base.PerformRelatedEntityRemoval(this.EventNotification, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ProspectCustomerNotification":
					base.PerformRelatedEntityRemoval(this.ProspectCustomerNotification, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "NotificationEmail":
					DesetupSyncNotificationEmail(false, true);
					break;
				case "NotificationPhone":
					DesetupSyncNotificationPhone(false, true);
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
			if(_notificationEmail!=null)
			{
				toReturn.Add(_notificationEmail);
			}

			if(_notificationPhone!=null)
			{
				toReturn.Add(_notificationPhone);
			}

			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			if(_notificationMedium!=null)
			{
				toReturn.Add(_notificationMedium);
			}
			if(_notificationType!=null)
			{
				toReturn.Add(_notificationType);
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
			toReturn.Add(this.EventCustomerNotification);
			toReturn.Add(this.EventNotification);
			toReturn.Add(this.ProspectCustomerNotification);

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
				info.AddValue("_eventCustomerNotification", ((_eventCustomerNotification!=null) && (_eventCustomerNotification.Count>0) && !this.MarkedForDeletion)?_eventCustomerNotification:null);
				info.AddValue("_eventNotification", ((_eventNotification!=null) && (_eventNotification.Count>0) && !this.MarkedForDeletion)?_eventNotification:null);
				info.AddValue("_prospectCustomerNotification", ((_prospectCustomerNotification!=null) && (_prospectCustomerNotification.Count>0) && !this.MarkedForDeletion)?_prospectCustomerNotification:null);
				info.AddValue("_eventCustomersCollectionViaEventCustomerNotification", ((_eventCustomersCollectionViaEventCustomerNotification!=null) && (_eventCustomersCollectionViaEventCustomerNotification.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaEventCustomerNotification:null);
				info.AddValue("_eventsCollectionViaEventNotification", ((_eventsCollectionViaEventNotification!=null) && (_eventsCollectionViaEventNotification.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventNotification:null);
				info.AddValue("_notificationTypeCollectionViaEventCustomerNotification", ((_notificationTypeCollectionViaEventCustomerNotification!=null) && (_notificationTypeCollectionViaEventCustomerNotification.Count>0) && !this.MarkedForDeletion)?_notificationTypeCollectionViaEventCustomerNotification:null);
				info.AddValue("_prospectCustomerCollectionViaProspectCustomerNotification", ((_prospectCustomerCollectionViaProspectCustomerNotification!=null) && (_prospectCustomerCollectionViaProspectCustomerNotification.Count>0) && !this.MarkedForDeletion)?_prospectCustomerCollectionViaProspectCustomerNotification:null);
				info.AddValue("_notificationMedium", (!this.MarkedForDeletion?_notificationMedium:null));
				info.AddValue("_notificationType", (!this.MarkedForDeletion?_notificationType:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));
				info.AddValue("_notificationEmail", (!this.MarkedForDeletion?_notificationEmail:null));
				info.AddValue("_notificationPhone", (!this.MarkedForDeletion?_notificationPhone:null));
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(NotificationFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(NotificationFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new NotificationRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerNotification' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerNotificationFields.NotificationId, null, ComparisonOperator.Equal, this.NotificationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventNotification' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventNotificationFields.NotificationId, null, ComparisonOperator.Equal, this.NotificationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectCustomerNotification' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectCustomerNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerNotificationFields.NotificationId, null, ComparisonOperator.Equal, this.NotificationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaEventCustomerNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaEventCustomerNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationFields.NotificationId, null, ComparisonOperator.Equal, this.NotificationId, "NotificationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationFields.NotificationId, null, ComparisonOperator.Equal, this.NotificationId, "NotificationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'NotificationType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotificationTypeCollectionViaEventCustomerNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("NotificationTypeCollectionViaEventCustomerNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationFields.NotificationId, null, ComparisonOperator.Equal, this.NotificationId, "NotificationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectCustomerCollectionViaProspectCustomerNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectCustomerCollectionViaProspectCustomerNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationFields.NotificationId, null, ComparisonOperator.Equal, this.NotificationId, "NotificationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'NotificationMedium' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotificationMedium()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationMediumFields.NotificationMediumId, null, ComparisonOperator.Equal, this.NotificationMediumId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'NotificationType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotificationType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationTypeFields.NotificationTypeId, null, ComparisonOperator.Equal, this.NotificationTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.RequestedByOrgRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'NotificationEmail' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotificationEmail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationEmailFields.NotificationEmailId, null, ComparisonOperator.Equal, this.NotificationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'NotificationPhone' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotificationPhone()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationPhoneFields.NotificationPhoneId, null, ComparisonOperator.Equal, this.NotificationId));
			return bucket;
		}
	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.NotificationEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(NotificationEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._eventCustomerNotification);
			collectionsQueue.Enqueue(this._eventNotification);
			collectionsQueue.Enqueue(this._prospectCustomerNotification);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaEventCustomerNotification);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventNotification);
			collectionsQueue.Enqueue(this._notificationTypeCollectionViaEventCustomerNotification);
			collectionsQueue.Enqueue(this._prospectCustomerCollectionViaProspectCustomerNotification);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._eventCustomerNotification = (EntityCollection<EventCustomerNotificationEntity>) collectionsQueue.Dequeue();
			this._eventNotification = (EntityCollection<EventNotificationEntity>) collectionsQueue.Dequeue();
			this._prospectCustomerNotification = (EntityCollection<ProspectCustomerNotificationEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaEventCustomerNotification = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventNotification = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._notificationTypeCollectionViaEventCustomerNotification = (EntityCollection<NotificationTypeEntity>) collectionsQueue.Dequeue();
			this._prospectCustomerCollectionViaProspectCustomerNotification = (EntityCollection<ProspectCustomerEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._eventCustomerNotification != null)
			{
				return true;
			}
			if (this._eventNotification != null)
			{
				return true;
			}
			if (this._prospectCustomerNotification != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaEventCustomerNotification != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventNotification != null)
			{
				return true;
			}
			if (this._notificationTypeCollectionViaEventCustomerNotification != null)
			{
				return true;
			}
			if (this._prospectCustomerCollectionViaProspectCustomerNotification != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerNotificationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventNotificationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectCustomerNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerNotificationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NotificationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("NotificationMedium", _notificationMedium);
			toReturn.Add("NotificationType", _notificationType);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("EventCustomerNotification", _eventCustomerNotification);
			toReturn.Add("EventNotification", _eventNotification);
			toReturn.Add("ProspectCustomerNotification", _prospectCustomerNotification);
			toReturn.Add("EventCustomersCollectionViaEventCustomerNotification", _eventCustomersCollectionViaEventCustomerNotification);
			toReturn.Add("EventsCollectionViaEventNotification", _eventsCollectionViaEventNotification);
			toReturn.Add("NotificationTypeCollectionViaEventCustomerNotification", _notificationTypeCollectionViaEventCustomerNotification);
			toReturn.Add("ProspectCustomerCollectionViaProspectCustomerNotification", _prospectCustomerCollectionViaProspectCustomerNotification);
			toReturn.Add("NotificationEmail", _notificationEmail);
			toReturn.Add("NotificationPhone", _notificationPhone);
			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_eventCustomerNotification!=null)
			{
				_eventCustomerNotification.ActiveContext = base.ActiveContext;
			}
			if(_eventNotification!=null)
			{
				_eventNotification.ActiveContext = base.ActiveContext;
			}
			if(_prospectCustomerNotification!=null)
			{
				_prospectCustomerNotification.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaEventCustomerNotification!=null)
			{
				_eventCustomersCollectionViaEventCustomerNotification.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventNotification!=null)
			{
				_eventsCollectionViaEventNotification.ActiveContext = base.ActiveContext;
			}
			if(_notificationTypeCollectionViaEventCustomerNotification!=null)
			{
				_notificationTypeCollectionViaEventCustomerNotification.ActiveContext = base.ActiveContext;
			}
			if(_prospectCustomerCollectionViaProspectCustomerNotification!=null)
			{
				_prospectCustomerCollectionViaProspectCustomerNotification.ActiveContext = base.ActiveContext;
			}
			if(_notificationMedium!=null)
			{
				_notificationMedium.ActiveContext = base.ActiveContext;
			}
			if(_notificationType!=null)
			{
				_notificationType.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_notificationEmail!=null)
			{
				_notificationEmail.ActiveContext = base.ActiveContext;
			}
			if(_notificationPhone!=null)
			{
				_notificationPhone.ActiveContext = base.ActiveContext;
			}
		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_eventCustomerNotification = null;
			_eventNotification = null;
			_prospectCustomerNotification = null;
			_eventCustomersCollectionViaEventCustomerNotification = null;
			_eventsCollectionViaEventNotification = null;
			_notificationTypeCollectionViaEventCustomerNotification = null;
			_prospectCustomerCollectionViaProspectCustomerNotification = null;
			_notificationMedium = null;
			_notificationType = null;
			_organizationRoleUser = null;
			_notificationEmail = null;
			_notificationPhone = null;
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

			_fieldsCustomProperties.Add("NotificationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NotificationDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NotificationMediumId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NotificationTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ClientLabel", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Priority", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AttemptCount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ServiceStatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ServicedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Notes", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RequestedByOrgRoleUserId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _notificationMedium</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncNotificationMedium(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _notificationMedium, new PropertyChangedEventHandler( OnNotificationMediumPropertyChanged ), "NotificationMedium", NotificationEntity.Relations.NotificationMediumEntityUsingNotificationMediumId, true, signalRelatedEntity, "Notification", resetFKFields, new int[] { (int)NotificationFieldIndex.NotificationMediumId } );		
			_notificationMedium = null;
		}

		/// <summary> setups the sync logic for member _notificationMedium</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncNotificationMedium(IEntity2 relatedEntity)
		{
			if(_notificationMedium!=relatedEntity)
			{
				DesetupSyncNotificationMedium(true, true);
				_notificationMedium = (NotificationMediumEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _notificationMedium, new PropertyChangedEventHandler( OnNotificationMediumPropertyChanged ), "NotificationMedium", NotificationEntity.Relations.NotificationMediumEntityUsingNotificationMediumId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnNotificationMediumPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _notificationType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncNotificationType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _notificationType, new PropertyChangedEventHandler( OnNotificationTypePropertyChanged ), "NotificationType", NotificationEntity.Relations.NotificationTypeEntityUsingNotificationTypeId, true, signalRelatedEntity, "Notification", resetFKFields, new int[] { (int)NotificationFieldIndex.NotificationTypeId } );		
			_notificationType = null;
		}

		/// <summary> setups the sync logic for member _notificationType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncNotificationType(IEntity2 relatedEntity)
		{
			if(_notificationType!=relatedEntity)
			{
				DesetupSyncNotificationType(true, true);
				_notificationType = (NotificationTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _notificationType, new PropertyChangedEventHandler( OnNotificationTypePropertyChanged ), "NotificationType", NotificationEntity.Relations.NotificationTypeEntityUsingNotificationTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnNotificationTypePropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", NotificationEntity.Relations.OrganizationRoleUserEntityUsingRequestedByOrgRoleUserId, true, signalRelatedEntity, "Notification", resetFKFields, new int[] { (int)NotificationFieldIndex.RequestedByOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", NotificationEntity.Relations.OrganizationRoleUserEntityUsingRequestedByOrgRoleUserId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _notificationEmail</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncNotificationEmail(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _notificationEmail, new PropertyChangedEventHandler( OnNotificationEmailPropertyChanged ), "NotificationEmail", NotificationEntity.Relations.NotificationEmailEntityUsingNotificationEmailId, false, signalRelatedEntity, "Notification", false, new int[] { (int)NotificationFieldIndex.NotificationId } );
			_notificationEmail = null;
		}
		
		/// <summary> setups the sync logic for member _notificationEmail</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncNotificationEmail(IEntity2 relatedEntity)
		{
			if(_notificationEmail!=relatedEntity)
			{
				DesetupSyncNotificationEmail(true, true);
				_notificationEmail = (NotificationEmailEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _notificationEmail, new PropertyChangedEventHandler( OnNotificationEmailPropertyChanged ), "NotificationEmail", NotificationEntity.Relations.NotificationEmailEntityUsingNotificationEmailId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnNotificationEmailPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _notificationPhone</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncNotificationPhone(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _notificationPhone, new PropertyChangedEventHandler( OnNotificationPhonePropertyChanged ), "NotificationPhone", NotificationEntity.Relations.NotificationPhoneEntityUsingNotificationPhoneId, false, signalRelatedEntity, "Notification", false, new int[] { (int)NotificationFieldIndex.NotificationId } );
			_notificationPhone = null;
		}
		
		/// <summary> setups the sync logic for member _notificationPhone</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncNotificationPhone(IEntity2 relatedEntity)
		{
			if(_notificationPhone!=relatedEntity)
			{
				DesetupSyncNotificationPhone(true, true);
				_notificationPhone = (NotificationPhoneEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _notificationPhone, new PropertyChangedEventHandler( OnNotificationPhonePropertyChanged ), "NotificationPhone", NotificationEntity.Relations.NotificationPhoneEntityUsingNotificationPhoneId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnNotificationPhonePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this NotificationEntity</param>
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
		public  static NotificationRelations Relations
		{
			get	{ return new NotificationRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerNotification' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerNotification
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerNotificationEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerNotification")[0], (int)Falcon.Data.EntityType.NotificationEntity, (int)Falcon.Data.EntityType.EventCustomerNotificationEntity, 0, null, null, null, null, "EventCustomerNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventNotification' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventNotification
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventNotificationEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventNotification")[0], (int)Falcon.Data.EntityType.NotificationEntity, (int)Falcon.Data.EntityType.EventNotificationEntity, 0, null, null, null, null, "EventNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectCustomerNotification' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectCustomerNotification
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ProspectCustomerNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerNotificationEntityFactory))),
					(IEntityRelation)GetRelationsForField("ProspectCustomerNotification")[0], (int)Falcon.Data.EntityType.NotificationEntity, (int)Falcon.Data.EntityType.ProspectCustomerNotificationEntity, 0, null, null, null, null, "ProspectCustomerNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaEventCustomerNotification
		{
			get
			{
				IEntityRelation intermediateRelation = NotificationEntity.Relations.EventCustomerNotificationEntityUsingNotificationId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerNotification_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotificationEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaEventCustomerNotification"), null, "EventCustomersCollectionViaEventCustomerNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventNotification
		{
			get
			{
				IEntityRelation intermediateRelation = NotificationEntity.Relations.EventNotificationEntityUsingNotificationId;
				intermediateRelation.SetAliases(string.Empty, "EventNotification_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotificationEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventNotification"), null, "EventsCollectionViaEventNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotificationType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotificationTypeCollectionViaEventCustomerNotification
		{
			get
			{
				IEntityRelation intermediateRelation = NotificationEntity.Relations.EventCustomerNotificationEntityUsingNotificationId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerNotification_");
				return new PrefetchPathElement2(new EntityCollection<NotificationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotificationEntity, (int)Falcon.Data.EntityType.NotificationTypeEntity, 0, null, null, GetRelationsForField("NotificationTypeCollectionViaEventCustomerNotification"), null, "NotificationTypeCollectionViaEventCustomerNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectCustomerCollectionViaProspectCustomerNotification
		{
			get
			{
				IEntityRelation intermediateRelation = NotificationEntity.Relations.ProspectCustomerNotificationEntityUsingNotificationId;
				intermediateRelation.SetAliases(string.Empty, "ProspectCustomerNotification_");
				return new PrefetchPathElement2(new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotificationEntity, (int)Falcon.Data.EntityType.ProspectCustomerEntity, 0, null, null, GetRelationsForField("ProspectCustomerCollectionViaProspectCustomerNotification"), null, "ProspectCustomerCollectionViaProspectCustomerNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotificationMedium' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotificationMedium
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(NotificationMediumEntityFactory))),
					(IEntityRelation)GetRelationsForField("NotificationMedium")[0], (int)Falcon.Data.EntityType.NotificationEntity, (int)Falcon.Data.EntityType.NotificationMediumEntity, 0, null, null, null, null, "NotificationMedium", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotificationType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotificationType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(NotificationTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("NotificationType")[0], (int)Falcon.Data.EntityType.NotificationEntity, (int)Falcon.Data.EntityType.NotificationTypeEntity, 0, null, null, null, null, "NotificationType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.NotificationEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotificationEmail' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotificationEmail
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(NotificationEmailEntityFactory))),
					(IEntityRelation)GetRelationsForField("NotificationEmail")[0], (int)Falcon.Data.EntityType.NotificationEntity, (int)Falcon.Data.EntityType.NotificationEmailEntity, 0, null, null, null, null, "NotificationEmail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotificationPhone' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotificationPhone
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(NotificationPhoneEntityFactory))),
					(IEntityRelation)GetRelationsForField("NotificationPhone")[0], (int)Falcon.Data.EntityType.NotificationEntity, (int)Falcon.Data.EntityType.NotificationPhoneEntity, 0, null, null, null, null, "NotificationPhone", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return NotificationEntity.CustomProperties;}
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
			get { return NotificationEntity.FieldsCustomProperties;}
		}

		/// <summary> The NotificationId property of the Entity Notification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotification"."NotificationID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 NotificationId
		{
			get { return (System.Int64)GetValue((int)NotificationFieldIndex.NotificationId, true); }
			set	{ SetValue((int)NotificationFieldIndex.NotificationId, value); }
		}

		/// <summary> The UserId property of the Entity Notification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotification"."UserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 UserId
		{
			get { return (System.Int64)GetValue((int)NotificationFieldIndex.UserId, true); }
			set	{ SetValue((int)NotificationFieldIndex.UserId, value); }
		}

		/// <summary> The NotificationDate property of the Entity Notification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotification"."NotificationDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime NotificationDate
		{
			get { return (System.DateTime)GetValue((int)NotificationFieldIndex.NotificationDate, true); }
			set	{ SetValue((int)NotificationFieldIndex.NotificationDate, value); }
		}

		/// <summary> The NotificationMediumId property of the Entity Notification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotification"."NotificationMediumID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 NotificationMediumId
		{
			get { return (System.Int32)GetValue((int)NotificationFieldIndex.NotificationMediumId, true); }
			set	{ SetValue((int)NotificationFieldIndex.NotificationMediumId, value); }
		}

		/// <summary> The NotificationTypeId property of the Entity Notification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotification"."NotificationTypeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 NotificationTypeId
		{
			get { return (System.Int32)GetValue((int)NotificationFieldIndex.NotificationTypeId, true); }
			set	{ SetValue((int)NotificationFieldIndex.NotificationTypeId, value); }
		}

		/// <summary> The ClientLabel property of the Entity Notification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotification"."Source"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ClientLabel
		{
			get { return (System.String)GetValue((int)NotificationFieldIndex.ClientLabel, true); }
			set	{ SetValue((int)NotificationFieldIndex.ClientLabel, value); }
		}

		/// <summary> The Priority property of the Entity Notification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotification"."Priority"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Priority
		{
			get { return (System.Int32)GetValue((int)NotificationFieldIndex.Priority, true); }
			set	{ SetValue((int)NotificationFieldIndex.Priority, value); }
		}

		/// <summary> The AttemptCount property of the Entity Notification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotification"."AttemptCount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 AttemptCount
		{
			get { return (System.Int32)GetValue((int)NotificationFieldIndex.AttemptCount, true); }
			set	{ SetValue((int)NotificationFieldIndex.AttemptCount, value); }
		}

		/// <summary> The ServiceStatus property of the Entity Notification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotification"."ServiceStatus"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Byte> ServiceStatus
		{
			get { return (Nullable<System.Byte>)GetValue((int)NotificationFieldIndex.ServiceStatus, false); }
			set	{ SetValue((int)NotificationFieldIndex.ServiceStatus, value); }
		}

		/// <summary> The ServicedDate property of the Entity Notification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotification"."ServicedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ServicedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)NotificationFieldIndex.ServicedDate, false); }
			set	{ SetValue((int)NotificationFieldIndex.ServicedDate, value); }
		}

		/// <summary> The DateCreated property of the Entity Notification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotification"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateCreated
		{
			get { return (Nullable<System.DateTime>)GetValue((int)NotificationFieldIndex.DateCreated, false); }
			set	{ SetValue((int)NotificationFieldIndex.DateCreated, value); }
		}

		/// <summary> The Notes property of the Entity Notification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotification"."Notes"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Notes
		{
			get { return (System.String)GetValue((int)NotificationFieldIndex.Notes, true); }
			set	{ SetValue((int)NotificationFieldIndex.Notes, value); }
		}

		/// <summary> The RequestedByOrgRoleUserId property of the Entity Notification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotification"."RequestedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> RequestedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)NotificationFieldIndex.RequestedByOrgRoleUserId, false); }
			set	{ SetValue((int)NotificationFieldIndex.RequestedByOrgRoleUserId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerNotificationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerNotificationEntity))]
		public virtual EntityCollection<EventCustomerNotificationEntity> EventCustomerNotification
		{
			get
			{
				if(_eventCustomerNotification==null)
				{
					_eventCustomerNotification = new EntityCollection<EventCustomerNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerNotificationEntityFactory)));
					_eventCustomerNotification.SetContainingEntityInfo(this, "Notification");
				}
				return _eventCustomerNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventNotificationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventNotificationEntity))]
		public virtual EntityCollection<EventNotificationEntity> EventNotification
		{
			get
			{
				if(_eventNotification==null)
				{
					_eventNotification = new EntityCollection<EventNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventNotificationEntityFactory)));
					_eventNotification.SetContainingEntityInfo(this, "Notification");
				}
				return _eventNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectCustomerNotificationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectCustomerNotificationEntity))]
		public virtual EntityCollection<ProspectCustomerNotificationEntity> ProspectCustomerNotification
		{
			get
			{
				if(_prospectCustomerNotification==null)
				{
					_prospectCustomerNotification = new EntityCollection<ProspectCustomerNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerNotificationEntityFactory)));
					_prospectCustomerNotification.SetContainingEntityInfo(this, "Notification");
				}
				return _prospectCustomerNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaEventCustomerNotification
		{
			get
			{
				if(_eventCustomersCollectionViaEventCustomerNotification==null)
				{
					_eventCustomersCollectionViaEventCustomerNotification = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaEventCustomerNotification.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaEventCustomerNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventNotification
		{
			get
			{
				if(_eventsCollectionViaEventNotification==null)
				{
					_eventsCollectionViaEventNotification = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventNotification.IsReadOnly=true;
				}
				return _eventsCollectionViaEventNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NotificationTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NotificationTypeEntity))]
		public virtual EntityCollection<NotificationTypeEntity> NotificationTypeCollectionViaEventCustomerNotification
		{
			get
			{
				if(_notificationTypeCollectionViaEventCustomerNotification==null)
				{
					_notificationTypeCollectionViaEventCustomerNotification = new EntityCollection<NotificationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationTypeEntityFactory)));
					_notificationTypeCollectionViaEventCustomerNotification.IsReadOnly=true;
				}
				return _notificationTypeCollectionViaEventCustomerNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectCustomerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectCustomerEntity))]
		public virtual EntityCollection<ProspectCustomerEntity> ProspectCustomerCollectionViaProspectCustomerNotification
		{
			get
			{
				if(_prospectCustomerCollectionViaProspectCustomerNotification==null)
				{
					_prospectCustomerCollectionViaProspectCustomerNotification = new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory)));
					_prospectCustomerCollectionViaProspectCustomerNotification.IsReadOnly=true;
				}
				return _prospectCustomerCollectionViaProspectCustomerNotification;
			}
		}

		/// <summary> Gets / sets related entity of type 'NotificationMediumEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual NotificationMediumEntity NotificationMedium
		{
			get
			{
				return _notificationMedium;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncNotificationMedium(value);
				}
				else
				{
					if(value==null)
					{
						if(_notificationMedium != null)
						{
							_notificationMedium.UnsetRelatedEntity(this, "Notification");
						}
					}
					else
					{
						if(_notificationMedium!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Notification");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'NotificationTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual NotificationTypeEntity NotificationType
		{
			get
			{
				return _notificationType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncNotificationType(value);
				}
				else
				{
					if(value==null)
					{
						if(_notificationType != null)
						{
							_notificationType.UnsetRelatedEntity(this, "Notification");
						}
					}
					else
					{
						if(_notificationType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Notification");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "Notification");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Notification");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'NotificationEmailEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual NotificationEmailEntity NotificationEmail
		{
			get
			{
				return _notificationEmail;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncNotificationEmail(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "Notification");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_notificationEmail !=null);
						DesetupSyncNotificationEmail(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("NotificationEmail");
						}
					}
					else
					{
						if(_notificationEmail!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "Notification");
							SetupSyncNotificationEmail(relatedEntity);
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'NotificationPhoneEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual NotificationPhoneEntity NotificationPhone
		{
			get
			{
				return _notificationPhone;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncNotificationPhone(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "Notification");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_notificationPhone !=null);
						DesetupSyncNotificationPhone(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("NotificationPhone");
						}
					}
					else
					{
						if(_notificationPhone!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "Notification");
							SetupSyncNotificationPhone(relatedEntity);
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
			get { return (int)Falcon.Data.EntityType.NotificationEntity; }
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
