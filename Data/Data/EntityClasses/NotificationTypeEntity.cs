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
	/// Entity class which represents the entity 'NotificationType'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class NotificationTypeEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<EmailTemplateEntity> _emailTemplate;
		private EntityCollection<EventCustomerNotificationEntity> _eventCustomerNotification;
		private EntityCollection<EventCustomerTestNotPerformedNotificationEntity> _eventCustomerTestNotPerformedNotification;
		private EntityCollection<NotificationEntity> _notification;
		private EntityCollection<NotificationSubscribersEntity> _notificationSubscribers;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaEventCustomerTestNotPerformedNotification;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaEventCustomerNotification;
		private EntityCollection<LookupEntity> _lookupCollectionViaEmailTemplate;
		private EntityCollection<LookupEntity> _lookupCollectionViaEmailTemplate_;
		private EntityCollection<NotificationEntity> _notificationCollectionViaEventCustomerNotification;
		private EntityCollection<NotificationMediumEntity> _notificationMediumCollectionViaNotification;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaNotification;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEmailTemplate;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification;
		private EntityCollection<TestEntity> _testCollectionViaEventCustomerTestNotPerformedNotification;
		private NotificationMediumEntity _notificationMedium;
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
			/// <summary>Member name NotificationMedium</summary>
			public static readonly string NotificationMedium = "NotificationMedium";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name EmailTemplate</summary>
			public static readonly string EmailTemplate = "EmailTemplate";
			/// <summary>Member name EventCustomerNotification</summary>
			public static readonly string EventCustomerNotification = "EventCustomerNotification";
			/// <summary>Member name EventCustomerTestNotPerformedNotification</summary>
			public static readonly string EventCustomerTestNotPerformedNotification = "EventCustomerTestNotPerformedNotification";
			/// <summary>Member name Notification</summary>
			public static readonly string Notification = "Notification";
			/// <summary>Member name NotificationSubscribers</summary>
			public static readonly string NotificationSubscribers = "NotificationSubscribers";
			/// <summary>Member name EventCustomersCollectionViaEventCustomerTestNotPerformedNotification</summary>
			public static readonly string EventCustomersCollectionViaEventCustomerTestNotPerformedNotification = "EventCustomersCollectionViaEventCustomerTestNotPerformedNotification";
			/// <summary>Member name EventCustomersCollectionViaEventCustomerNotification</summary>
			public static readonly string EventCustomersCollectionViaEventCustomerNotification = "EventCustomersCollectionViaEventCustomerNotification";
			/// <summary>Member name LookupCollectionViaEmailTemplate</summary>
			public static readonly string LookupCollectionViaEmailTemplate = "LookupCollectionViaEmailTemplate";
			/// <summary>Member name LookupCollectionViaEmailTemplate_</summary>
			public static readonly string LookupCollectionViaEmailTemplate_ = "LookupCollectionViaEmailTemplate_";
			/// <summary>Member name NotificationCollectionViaEventCustomerNotification</summary>
			public static readonly string NotificationCollectionViaEventCustomerNotification = "NotificationCollectionViaEventCustomerNotification";
			/// <summary>Member name NotificationMediumCollectionViaNotification</summary>
			public static readonly string NotificationMediumCollectionViaNotification = "NotificationMediumCollectionViaNotification";
			/// <summary>Member name OrganizationRoleUserCollectionViaNotification</summary>
			public static readonly string OrganizationRoleUserCollectionViaNotification = "OrganizationRoleUserCollectionViaNotification";
			/// <summary>Member name OrganizationRoleUserCollectionViaEmailTemplate</summary>
			public static readonly string OrganizationRoleUserCollectionViaEmailTemplate = "OrganizationRoleUserCollectionViaEmailTemplate";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification = "OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification";
			/// <summary>Member name TestCollectionViaEventCustomerTestNotPerformedNotification</summary>
			public static readonly string TestCollectionViaEventCustomerTestNotPerformedNotification = "TestCollectionViaEventCustomerTestNotPerformedNotification";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static NotificationTypeEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public NotificationTypeEntity():base("NotificationTypeEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public NotificationTypeEntity(IEntityFields2 fields):base("NotificationTypeEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this NotificationTypeEntity</param>
		public NotificationTypeEntity(IValidator validator):base("NotificationTypeEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="notificationTypeId">PK value for NotificationType which data should be fetched into this NotificationType object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public NotificationTypeEntity(System.Int32 notificationTypeId):base("NotificationTypeEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.NotificationTypeId = notificationTypeId;
		}

		/// <summary> CTor</summary>
		/// <param name="notificationTypeId">PK value for NotificationType which data should be fetched into this NotificationType object</param>
		/// <param name="validator">The custom validator object for this NotificationTypeEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public NotificationTypeEntity(System.Int32 notificationTypeId, IValidator validator):base("NotificationTypeEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.NotificationTypeId = notificationTypeId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected NotificationTypeEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_emailTemplate = (EntityCollection<EmailTemplateEntity>)info.GetValue("_emailTemplate", typeof(EntityCollection<EmailTemplateEntity>));
				_eventCustomerNotification = (EntityCollection<EventCustomerNotificationEntity>)info.GetValue("_eventCustomerNotification", typeof(EntityCollection<EventCustomerNotificationEntity>));
				_eventCustomerTestNotPerformedNotification = (EntityCollection<EventCustomerTestNotPerformedNotificationEntity>)info.GetValue("_eventCustomerTestNotPerformedNotification", typeof(EntityCollection<EventCustomerTestNotPerformedNotificationEntity>));
				_notification = (EntityCollection<NotificationEntity>)info.GetValue("_notification", typeof(EntityCollection<NotificationEntity>));
				_notificationSubscribers = (EntityCollection<NotificationSubscribersEntity>)info.GetValue("_notificationSubscribers", typeof(EntityCollection<NotificationSubscribersEntity>));
				_eventCustomersCollectionViaEventCustomerTestNotPerformedNotification = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaEventCustomerTestNotPerformedNotification", typeof(EntityCollection<EventCustomersEntity>));
				_eventCustomersCollectionViaEventCustomerNotification = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaEventCustomerNotification", typeof(EntityCollection<EventCustomersEntity>));
				_lookupCollectionViaEmailTemplate = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEmailTemplate", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEmailTemplate_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEmailTemplate_", typeof(EntityCollection<LookupEntity>));
				_notificationCollectionViaEventCustomerNotification = (EntityCollection<NotificationEntity>)info.GetValue("_notificationCollectionViaEventCustomerNotification", typeof(EntityCollection<NotificationEntity>));
				_notificationMediumCollectionViaNotification = (EntityCollection<NotificationMediumEntity>)info.GetValue("_notificationMediumCollectionViaNotification", typeof(EntityCollection<NotificationMediumEntity>));
				_organizationRoleUserCollectionViaNotification = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaNotification", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEmailTemplate = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEmailTemplate", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_testCollectionViaEventCustomerTestNotPerformedNotification = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaEventCustomerTestNotPerformedNotification", typeof(EntityCollection<TestEntity>));
				_notificationMedium = (NotificationMediumEntity)info.GetValue("_notificationMedium", typeof(NotificationMediumEntity));
				if(_notificationMedium!=null)
				{
					_notificationMedium.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
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
			switch((NotificationTypeFieldIndex)fieldIndex)
			{
				case NotificationTypeFieldIndex.NotificationMediumId:
					DesetupSyncNotificationMedium(true, false);
					break;
				case NotificationTypeFieldIndex.ModifiedByOrgRoleUserId:
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
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "EmailTemplate":
					this.EmailTemplate.Add((EmailTemplateEntity)entity);
					break;
				case "EventCustomerNotification":
					this.EventCustomerNotification.Add((EventCustomerNotificationEntity)entity);
					break;
				case "EventCustomerTestNotPerformedNotification":
					this.EventCustomerTestNotPerformedNotification.Add((EventCustomerTestNotPerformedNotificationEntity)entity);
					break;
				case "Notification":
					this.Notification.Add((NotificationEntity)entity);
					break;
				case "NotificationSubscribers":
					this.NotificationSubscribers.Add((NotificationSubscribersEntity)entity);
					break;
				case "EventCustomersCollectionViaEventCustomerTestNotPerformedNotification":
					this.EventCustomersCollectionViaEventCustomerTestNotPerformedNotification.IsReadOnly = false;
					this.EventCustomersCollectionViaEventCustomerTestNotPerformedNotification.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaEventCustomerTestNotPerformedNotification.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaEventCustomerNotification":
					this.EventCustomersCollectionViaEventCustomerNotification.IsReadOnly = false;
					this.EventCustomersCollectionViaEventCustomerNotification.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaEventCustomerNotification.IsReadOnly = true;
					break;
				case "LookupCollectionViaEmailTemplate":
					this.LookupCollectionViaEmailTemplate.IsReadOnly = false;
					this.LookupCollectionViaEmailTemplate.Add((LookupEntity)entity);
					this.LookupCollectionViaEmailTemplate.IsReadOnly = true;
					break;
				case "LookupCollectionViaEmailTemplate_":
					this.LookupCollectionViaEmailTemplate_.IsReadOnly = false;
					this.LookupCollectionViaEmailTemplate_.Add((LookupEntity)entity);
					this.LookupCollectionViaEmailTemplate_.IsReadOnly = true;
					break;
				case "NotificationCollectionViaEventCustomerNotification":
					this.NotificationCollectionViaEventCustomerNotification.IsReadOnly = false;
					this.NotificationCollectionViaEventCustomerNotification.Add((NotificationEntity)entity);
					this.NotificationCollectionViaEventCustomerNotification.IsReadOnly = true;
					break;
				case "NotificationMediumCollectionViaNotification":
					this.NotificationMediumCollectionViaNotification.IsReadOnly = false;
					this.NotificationMediumCollectionViaNotification.Add((NotificationMediumEntity)entity);
					this.NotificationMediumCollectionViaNotification.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaNotification":
					this.OrganizationRoleUserCollectionViaNotification.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaNotification.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaNotification.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEmailTemplate":
					this.OrganizationRoleUserCollectionViaEmailTemplate.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEmailTemplate.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEmailTemplate.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification":
					this.OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification.IsReadOnly = true;
					break;
				case "TestCollectionViaEventCustomerTestNotPerformedNotification":
					this.TestCollectionViaEventCustomerTestNotPerformedNotification.IsReadOnly = false;
					this.TestCollectionViaEventCustomerTestNotPerformedNotification.Add((TestEntity)entity);
					this.TestCollectionViaEventCustomerTestNotPerformedNotification.IsReadOnly = true;
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
			return NotificationTypeEntity.GetRelationsForField(fieldName);
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
					toReturn.Add(NotificationTypeEntity.Relations.NotificationMediumEntityUsingNotificationMediumId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(NotificationTypeEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId);
					break;
				case "EmailTemplate":
					toReturn.Add(NotificationTypeEntity.Relations.EmailTemplateEntityUsingNotificationTypeId);
					break;
				case "EventCustomerNotification":
					toReturn.Add(NotificationTypeEntity.Relations.EventCustomerNotificationEntityUsingNotificationTypeId);
					break;
				case "EventCustomerTestNotPerformedNotification":
					toReturn.Add(NotificationTypeEntity.Relations.EventCustomerTestNotPerformedNotificationEntityUsingNotificationTypeId);
					break;
				case "Notification":
					toReturn.Add(NotificationTypeEntity.Relations.NotificationEntityUsingNotificationTypeId);
					break;
				case "NotificationSubscribers":
					toReturn.Add(NotificationTypeEntity.Relations.NotificationSubscribersEntityUsingNotificationTypeId);
					break;
				case "EventCustomersCollectionViaEventCustomerTestNotPerformedNotification":
					toReturn.Add(NotificationTypeEntity.Relations.EventCustomerTestNotPerformedNotificationEntityUsingNotificationTypeId, "NotificationTypeEntity__", "EventCustomerTestNotPerformedNotification_", JoinHint.None);
					toReturn.Add(EventCustomerTestNotPerformedNotificationEntity.Relations.EventCustomersEntityUsingEventCustomerId, "EventCustomerTestNotPerformedNotification_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaEventCustomerNotification":
					toReturn.Add(NotificationTypeEntity.Relations.EventCustomerNotificationEntityUsingNotificationTypeId, "NotificationTypeEntity__", "EventCustomerNotification_", JoinHint.None);
					toReturn.Add(EventCustomerNotificationEntity.Relations.EventCustomersEntityUsingEventCustomerId, "EventCustomerNotification_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEmailTemplate":
					toReturn.Add(NotificationTypeEntity.Relations.EmailTemplateEntityUsingNotificationTypeId, "NotificationTypeEntity__", "EmailTemplate_", JoinHint.None);
					toReturn.Add(EmailTemplateEntity.Relations.LookupEntityUsingTemplateType, "EmailTemplate_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEmailTemplate_":
					toReturn.Add(NotificationTypeEntity.Relations.EmailTemplateEntityUsingNotificationTypeId, "NotificationTypeEntity__", "EmailTemplate_", JoinHint.None);
					toReturn.Add(EmailTemplateEntity.Relations.LookupEntityUsingCoverLetterTypeLookupId, "EmailTemplate_", string.Empty, JoinHint.None);
					break;
				case "NotificationCollectionViaEventCustomerNotification":
					toReturn.Add(NotificationTypeEntity.Relations.EventCustomerNotificationEntityUsingNotificationTypeId, "NotificationTypeEntity__", "EventCustomerNotification_", JoinHint.None);
					toReturn.Add(EventCustomerNotificationEntity.Relations.NotificationEntityUsingNotificationId, "EventCustomerNotification_", string.Empty, JoinHint.None);
					break;
				case "NotificationMediumCollectionViaNotification":
					toReturn.Add(NotificationTypeEntity.Relations.NotificationEntityUsingNotificationTypeId, "NotificationTypeEntity__", "Notification_", JoinHint.None);
					toReturn.Add(NotificationEntity.Relations.NotificationMediumEntityUsingNotificationMediumId, "Notification_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaNotification":
					toReturn.Add(NotificationTypeEntity.Relations.NotificationEntityUsingNotificationTypeId, "NotificationTypeEntity__", "Notification_", JoinHint.None);
					toReturn.Add(NotificationEntity.Relations.OrganizationRoleUserEntityUsingRequestedByOrgRoleUserId, "Notification_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEmailTemplate":
					toReturn.Add(NotificationTypeEntity.Relations.EmailTemplateEntityUsingNotificationTypeId, "NotificationTypeEntity__", "EmailTemplate_", JoinHint.None);
					toReturn.Add(EmailTemplateEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, "EmailTemplate_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification":
					toReturn.Add(NotificationTypeEntity.Relations.EventCustomerTestNotPerformedNotificationEntityUsingNotificationTypeId, "NotificationTypeEntity__", "EventCustomerTestNotPerformedNotification_", JoinHint.None);
					toReturn.Add(EventCustomerTestNotPerformedNotificationEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "EventCustomerTestNotPerformedNotification_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaEventCustomerTestNotPerformedNotification":
					toReturn.Add(NotificationTypeEntity.Relations.EventCustomerTestNotPerformedNotificationEntityUsingNotificationTypeId, "NotificationTypeEntity__", "EventCustomerTestNotPerformedNotification_", JoinHint.None);
					toReturn.Add(EventCustomerTestNotPerformedNotificationEntity.Relations.TestEntityUsingTestId, "EventCustomerTestNotPerformedNotification_", string.Empty, JoinHint.None);
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
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "EmailTemplate":
					this.EmailTemplate.Add((EmailTemplateEntity)relatedEntity);
					break;
				case "EventCustomerNotification":
					this.EventCustomerNotification.Add((EventCustomerNotificationEntity)relatedEntity);
					break;
				case "EventCustomerTestNotPerformedNotification":
					this.EventCustomerTestNotPerformedNotification.Add((EventCustomerTestNotPerformedNotificationEntity)relatedEntity);
					break;
				case "Notification":
					this.Notification.Add((NotificationEntity)relatedEntity);
					break;
				case "NotificationSubscribers":
					this.NotificationSubscribers.Add((NotificationSubscribersEntity)relatedEntity);
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
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "EmailTemplate":
					base.PerformRelatedEntityRemoval(this.EmailTemplate, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerNotification":
					base.PerformRelatedEntityRemoval(this.EventCustomerNotification, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomerTestNotPerformedNotification":
					base.PerformRelatedEntityRemoval(this.EventCustomerTestNotPerformedNotification, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Notification":
					base.PerformRelatedEntityRemoval(this.Notification, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "NotificationSubscribers":
					base.PerformRelatedEntityRemoval(this.NotificationSubscribers, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_notificationMedium!=null)
			{
				toReturn.Add(_notificationMedium);
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
			toReturn.Add(this.EmailTemplate);
			toReturn.Add(this.EventCustomerNotification);
			toReturn.Add(this.EventCustomerTestNotPerformedNotification);
			toReturn.Add(this.Notification);
			toReturn.Add(this.NotificationSubscribers);

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
				info.AddValue("_emailTemplate", ((_emailTemplate!=null) && (_emailTemplate.Count>0) && !this.MarkedForDeletion)?_emailTemplate:null);
				info.AddValue("_eventCustomerNotification", ((_eventCustomerNotification!=null) && (_eventCustomerNotification.Count>0) && !this.MarkedForDeletion)?_eventCustomerNotification:null);
				info.AddValue("_eventCustomerTestNotPerformedNotification", ((_eventCustomerTestNotPerformedNotification!=null) && (_eventCustomerTestNotPerformedNotification.Count>0) && !this.MarkedForDeletion)?_eventCustomerTestNotPerformedNotification:null);
				info.AddValue("_notification", ((_notification!=null) && (_notification.Count>0) && !this.MarkedForDeletion)?_notification:null);
				info.AddValue("_notificationSubscribers", ((_notificationSubscribers!=null) && (_notificationSubscribers.Count>0) && !this.MarkedForDeletion)?_notificationSubscribers:null);
				info.AddValue("_eventCustomersCollectionViaEventCustomerTestNotPerformedNotification", ((_eventCustomersCollectionViaEventCustomerTestNotPerformedNotification!=null) && (_eventCustomersCollectionViaEventCustomerTestNotPerformedNotification.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaEventCustomerTestNotPerformedNotification:null);
				info.AddValue("_eventCustomersCollectionViaEventCustomerNotification", ((_eventCustomersCollectionViaEventCustomerNotification!=null) && (_eventCustomersCollectionViaEventCustomerNotification.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaEventCustomerNotification:null);
				info.AddValue("_lookupCollectionViaEmailTemplate", ((_lookupCollectionViaEmailTemplate!=null) && (_lookupCollectionViaEmailTemplate.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEmailTemplate:null);
				info.AddValue("_lookupCollectionViaEmailTemplate_", ((_lookupCollectionViaEmailTemplate_!=null) && (_lookupCollectionViaEmailTemplate_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEmailTemplate_:null);
				info.AddValue("_notificationCollectionViaEventCustomerNotification", ((_notificationCollectionViaEventCustomerNotification!=null) && (_notificationCollectionViaEventCustomerNotification.Count>0) && !this.MarkedForDeletion)?_notificationCollectionViaEventCustomerNotification:null);
				info.AddValue("_notificationMediumCollectionViaNotification", ((_notificationMediumCollectionViaNotification!=null) && (_notificationMediumCollectionViaNotification.Count>0) && !this.MarkedForDeletion)?_notificationMediumCollectionViaNotification:null);
				info.AddValue("_organizationRoleUserCollectionViaNotification", ((_organizationRoleUserCollectionViaNotification!=null) && (_organizationRoleUserCollectionViaNotification.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaNotification:null);
				info.AddValue("_organizationRoleUserCollectionViaEmailTemplate", ((_organizationRoleUserCollectionViaEmailTemplate!=null) && (_organizationRoleUserCollectionViaEmailTemplate.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEmailTemplate:null);
				info.AddValue("_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification", ((_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification!=null) && (_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification:null);
				info.AddValue("_testCollectionViaEventCustomerTestNotPerformedNotification", ((_testCollectionViaEventCustomerTestNotPerformedNotification!=null) && (_testCollectionViaEventCustomerTestNotPerformedNotification.Count>0) && !this.MarkedForDeletion)?_testCollectionViaEventCustomerTestNotPerformedNotification:null);
				info.AddValue("_notificationMedium", (!this.MarkedForDeletion?_notificationMedium:null));
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
		public bool TestOriginalFieldValueForNull(NotificationTypeFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(NotificationTypeFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new NotificationTypeRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EmailTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.NotificationTypeId, null, ComparisonOperator.Equal, this.NotificationTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerNotification' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerNotificationFields.NotificationTypeId, null, ComparisonOperator.Equal, this.NotificationTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerTestNotPerformedNotification' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerTestNotPerformedNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomerTestNotPerformedNotificationFields.NotificationTypeId, null, ComparisonOperator.Equal, this.NotificationTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Notification' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationFields.NotificationTypeId, null, ComparisonOperator.Equal, this.NotificationTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'NotificationSubscribers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotificationSubscribers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationSubscribersFields.NotificationTypeId, null, ComparisonOperator.Equal, this.NotificationTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaEventCustomerTestNotPerformedNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaEventCustomerTestNotPerformedNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationTypeFields.NotificationTypeId, null, ComparisonOperator.Equal, this.NotificationTypeId, "NotificationTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaEventCustomerNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaEventCustomerNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationTypeFields.NotificationTypeId, null, ComparisonOperator.Equal, this.NotificationTypeId, "NotificationTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEmailTemplate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEmailTemplate"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationTypeFields.NotificationTypeId, null, ComparisonOperator.Equal, this.NotificationTypeId, "NotificationTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEmailTemplate_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEmailTemplate_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationTypeFields.NotificationTypeId, null, ComparisonOperator.Equal, this.NotificationTypeId, "NotificationTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Notification' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotificationCollectionViaEventCustomerNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("NotificationCollectionViaEventCustomerNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationTypeFields.NotificationTypeId, null, ComparisonOperator.Equal, this.NotificationTypeId, "NotificationTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'NotificationMedium' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotificationMediumCollectionViaNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("NotificationMediumCollectionViaNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationTypeFields.NotificationTypeId, null, ComparisonOperator.Equal, this.NotificationTypeId, "NotificationTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationTypeFields.NotificationTypeId, null, ComparisonOperator.Equal, this.NotificationTypeId, "NotificationTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEmailTemplate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEmailTemplate"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationTypeFields.NotificationTypeId, null, ComparisonOperator.Equal, this.NotificationTypeId, "NotificationTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationTypeFields.NotificationTypeId, null, ComparisonOperator.Equal, this.NotificationTypeId, "NotificationTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaEventCustomerTestNotPerformedNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaEventCustomerTestNotPerformedNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotificationTypeFields.NotificationTypeId, null, ComparisonOperator.Equal, this.NotificationTypeId, "NotificationTypeEntity__"));
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
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.ModifiedByOrgRoleUserId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.NotificationTypeEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(NotificationTypeEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._emailTemplate);
			collectionsQueue.Enqueue(this._eventCustomerNotification);
			collectionsQueue.Enqueue(this._eventCustomerTestNotPerformedNotification);
			collectionsQueue.Enqueue(this._notification);
			collectionsQueue.Enqueue(this._notificationSubscribers);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaEventCustomerTestNotPerformedNotification);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaEventCustomerNotification);
			collectionsQueue.Enqueue(this._lookupCollectionViaEmailTemplate);
			collectionsQueue.Enqueue(this._lookupCollectionViaEmailTemplate_);
			collectionsQueue.Enqueue(this._notificationCollectionViaEventCustomerNotification);
			collectionsQueue.Enqueue(this._notificationMediumCollectionViaNotification);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaNotification);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEmailTemplate);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification);
			collectionsQueue.Enqueue(this._testCollectionViaEventCustomerTestNotPerformedNotification);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._emailTemplate = (EntityCollection<EmailTemplateEntity>) collectionsQueue.Dequeue();
			this._eventCustomerNotification = (EntityCollection<EventCustomerNotificationEntity>) collectionsQueue.Dequeue();
			this._eventCustomerTestNotPerformedNotification = (EntityCollection<EventCustomerTestNotPerformedNotificationEntity>) collectionsQueue.Dequeue();
			this._notification = (EntityCollection<NotificationEntity>) collectionsQueue.Dequeue();
			this._notificationSubscribers = (EntityCollection<NotificationSubscribersEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaEventCustomerTestNotPerformedNotification = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaEventCustomerNotification = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEmailTemplate = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEmailTemplate_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._notificationCollectionViaEventCustomerNotification = (EntityCollection<NotificationEntity>) collectionsQueue.Dequeue();
			this._notificationMediumCollectionViaNotification = (EntityCollection<NotificationMediumEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaNotification = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEmailTemplate = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaEventCustomerTestNotPerformedNotification = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._emailTemplate != null)
			{
				return true;
			}
			if (this._eventCustomerNotification != null)
			{
				return true;
			}
			if (this._eventCustomerTestNotPerformedNotification != null)
			{
				return true;
			}
			if (this._notification != null)
			{
				return true;
			}
			if (this._notificationSubscribers != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaEventCustomerTestNotPerformedNotification != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaEventCustomerNotification != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEmailTemplate != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEmailTemplate_ != null)
			{
				return true;
			}
			if (this._notificationCollectionViaEventCustomerNotification != null)
			{
				return true;
			}
			if (this._notificationMediumCollectionViaNotification != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaNotification != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEmailTemplate != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification != null)
			{
				return true;
			}
			if (this._testCollectionViaEventCustomerTestNotPerformedNotification != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerNotificationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerTestNotPerformedNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerTestNotPerformedNotificationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NotificationSubscribersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationSubscribersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NotificationMediumEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationMediumEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
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
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("EmailTemplate", _emailTemplate);
			toReturn.Add("EventCustomerNotification", _eventCustomerNotification);
			toReturn.Add("EventCustomerTestNotPerformedNotification", _eventCustomerTestNotPerformedNotification);
			toReturn.Add("Notification", _notification);
			toReturn.Add("NotificationSubscribers", _notificationSubscribers);
			toReturn.Add("EventCustomersCollectionViaEventCustomerTestNotPerformedNotification", _eventCustomersCollectionViaEventCustomerTestNotPerformedNotification);
			toReturn.Add("EventCustomersCollectionViaEventCustomerNotification", _eventCustomersCollectionViaEventCustomerNotification);
			toReturn.Add("LookupCollectionViaEmailTemplate", _lookupCollectionViaEmailTemplate);
			toReturn.Add("LookupCollectionViaEmailTemplate_", _lookupCollectionViaEmailTemplate_);
			toReturn.Add("NotificationCollectionViaEventCustomerNotification", _notificationCollectionViaEventCustomerNotification);
			toReturn.Add("NotificationMediumCollectionViaNotification", _notificationMediumCollectionViaNotification);
			toReturn.Add("OrganizationRoleUserCollectionViaNotification", _organizationRoleUserCollectionViaNotification);
			toReturn.Add("OrganizationRoleUserCollectionViaEmailTemplate", _organizationRoleUserCollectionViaEmailTemplate);
			toReturn.Add("OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification", _organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification);
			toReturn.Add("TestCollectionViaEventCustomerTestNotPerformedNotification", _testCollectionViaEventCustomerTestNotPerformedNotification);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_emailTemplate!=null)
			{
				_emailTemplate.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerNotification!=null)
			{
				_eventCustomerNotification.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerTestNotPerformedNotification!=null)
			{
				_eventCustomerTestNotPerformedNotification.ActiveContext = base.ActiveContext;
			}
			if(_notification!=null)
			{
				_notification.ActiveContext = base.ActiveContext;
			}
			if(_notificationSubscribers!=null)
			{
				_notificationSubscribers.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaEventCustomerTestNotPerformedNotification!=null)
			{
				_eventCustomersCollectionViaEventCustomerTestNotPerformedNotification.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaEventCustomerNotification!=null)
			{
				_eventCustomersCollectionViaEventCustomerNotification.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEmailTemplate!=null)
			{
				_lookupCollectionViaEmailTemplate.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEmailTemplate_!=null)
			{
				_lookupCollectionViaEmailTemplate_.ActiveContext = base.ActiveContext;
			}
			if(_notificationCollectionViaEventCustomerNotification!=null)
			{
				_notificationCollectionViaEventCustomerNotification.ActiveContext = base.ActiveContext;
			}
			if(_notificationMediumCollectionViaNotification!=null)
			{
				_notificationMediumCollectionViaNotification.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaNotification!=null)
			{
				_organizationRoleUserCollectionViaNotification.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEmailTemplate!=null)
			{
				_organizationRoleUserCollectionViaEmailTemplate.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification!=null)
			{
				_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaEventCustomerTestNotPerformedNotification!=null)
			{
				_testCollectionViaEventCustomerTestNotPerformedNotification.ActiveContext = base.ActiveContext;
			}
			if(_notificationMedium!=null)
			{
				_notificationMedium.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_emailTemplate = null;
			_eventCustomerNotification = null;
			_eventCustomerTestNotPerformedNotification = null;
			_notification = null;
			_notificationSubscribers = null;
			_eventCustomersCollectionViaEventCustomerTestNotPerformedNotification = null;
			_eventCustomersCollectionViaEventCustomerNotification = null;
			_lookupCollectionViaEmailTemplate = null;
			_lookupCollectionViaEmailTemplate_ = null;
			_notificationCollectionViaEventCustomerNotification = null;
			_notificationMediumCollectionViaNotification = null;
			_organizationRoleUserCollectionViaNotification = null;
			_organizationRoleUserCollectionViaEmailTemplate = null;
			_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification = null;
			_testCollectionViaEventCustomerTestNotPerformedNotification = null;
			_notificationMedium = null;
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

			_fieldsCustomProperties.Add("NotificationTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NotificationTypeName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NotificationTypeNameAlias", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NoOfAttempts", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NotificationMediumId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AllowTemplateCreation", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsServiceEnabled", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsQueuingEnabled", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedByOrgRoleUserId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _notificationMedium</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncNotificationMedium(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _notificationMedium, new PropertyChangedEventHandler( OnNotificationMediumPropertyChanged ), "NotificationMedium", NotificationTypeEntity.Relations.NotificationMediumEntityUsingNotificationMediumId, true, signalRelatedEntity, "NotificationType", resetFKFields, new int[] { (int)NotificationTypeFieldIndex.NotificationMediumId } );		
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
				base.PerformSetupSyncRelatedEntity( _notificationMedium, new PropertyChangedEventHandler( OnNotificationMediumPropertyChanged ), "NotificationMedium", NotificationTypeEntity.Relations.NotificationMediumEntityUsingNotificationMediumId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _organizationRoleUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", NotificationTypeEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, true, signalRelatedEntity, "NotificationType", resetFKFields, new int[] { (int)NotificationTypeFieldIndex.ModifiedByOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", NotificationTypeEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this NotificationTypeEntity</param>
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
		public  static NotificationTypeRelations Relations
		{
			get	{ return new NotificationTypeRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplate
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))),
					(IEntityRelation)GetRelationsForField("EmailTemplate")[0], (int)Falcon.Data.EntityType.NotificationTypeEntity, (int)Falcon.Data.EntityType.EmailTemplateEntity, 0, null, null, null, null, "EmailTemplate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerNotification' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerNotification
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerNotificationEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerNotification")[0], (int)Falcon.Data.EntityType.NotificationTypeEntity, (int)Falcon.Data.EntityType.EventCustomerNotificationEntity, 0, null, null, null, null, "EventCustomerNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerTestNotPerformedNotification' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerTestNotPerformedNotification
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomerTestNotPerformedNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerTestNotPerformedNotificationEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomerTestNotPerformedNotification")[0], (int)Falcon.Data.EntityType.NotificationTypeEntity, (int)Falcon.Data.EntityType.EventCustomerTestNotPerformedNotificationEntity, 0, null, null, null, null, "EventCustomerTestNotPerformedNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Notification' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotification
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<NotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationEntityFactory))),
					(IEntityRelation)GetRelationsForField("Notification")[0], (int)Falcon.Data.EntityType.NotificationTypeEntity, (int)Falcon.Data.EntityType.NotificationEntity, 0, null, null, null, null, "Notification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotificationSubscribers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotificationSubscribers
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<NotificationSubscribersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationSubscribersEntityFactory))),
					(IEntityRelation)GetRelationsForField("NotificationSubscribers")[0], (int)Falcon.Data.EntityType.NotificationTypeEntity, (int)Falcon.Data.EntityType.NotificationSubscribersEntity, 0, null, null, null, null, "NotificationSubscribers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaEventCustomerTestNotPerformedNotification
		{
			get
			{
				IEntityRelation intermediateRelation = NotificationTypeEntity.Relations.EventCustomerTestNotPerformedNotificationEntityUsingNotificationTypeId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerTestNotPerformedNotification_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotificationTypeEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaEventCustomerTestNotPerformedNotification"), null, "EventCustomersCollectionViaEventCustomerTestNotPerformedNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaEventCustomerNotification
		{
			get
			{
				IEntityRelation intermediateRelation = NotificationTypeEntity.Relations.EventCustomerNotificationEntityUsingNotificationTypeId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerNotification_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotificationTypeEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaEventCustomerNotification"), null, "EventCustomersCollectionViaEventCustomerNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEmailTemplate
		{
			get
			{
				IEntityRelation intermediateRelation = NotificationTypeEntity.Relations.EmailTemplateEntityUsingNotificationTypeId;
				intermediateRelation.SetAliases(string.Empty, "EmailTemplate_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotificationTypeEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEmailTemplate"), null, "LookupCollectionViaEmailTemplate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEmailTemplate_
		{
			get
			{
				IEntityRelation intermediateRelation = NotificationTypeEntity.Relations.EmailTemplateEntityUsingNotificationTypeId;
				intermediateRelation.SetAliases(string.Empty, "EmailTemplate_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotificationTypeEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEmailTemplate_"), null, "LookupCollectionViaEmailTemplate_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Notification' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotificationCollectionViaEventCustomerNotification
		{
			get
			{
				IEntityRelation intermediateRelation = NotificationTypeEntity.Relations.EventCustomerNotificationEntityUsingNotificationTypeId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerNotification_");
				return new PrefetchPathElement2(new EntityCollection<NotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotificationTypeEntity, (int)Falcon.Data.EntityType.NotificationEntity, 0, null, null, GetRelationsForField("NotificationCollectionViaEventCustomerNotification"), null, "NotificationCollectionViaEventCustomerNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotificationMedium' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotificationMediumCollectionViaNotification
		{
			get
			{
				IEntityRelation intermediateRelation = NotificationTypeEntity.Relations.NotificationEntityUsingNotificationTypeId;
				intermediateRelation.SetAliases(string.Empty, "Notification_");
				return new PrefetchPathElement2(new EntityCollection<NotificationMediumEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationMediumEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotificationTypeEntity, (int)Falcon.Data.EntityType.NotificationMediumEntity, 0, null, null, GetRelationsForField("NotificationMediumCollectionViaNotification"), null, "NotificationMediumCollectionViaNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaNotification
		{
			get
			{
				IEntityRelation intermediateRelation = NotificationTypeEntity.Relations.NotificationEntityUsingNotificationTypeId;
				intermediateRelation.SetAliases(string.Empty, "Notification_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotificationTypeEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaNotification"), null, "OrganizationRoleUserCollectionViaNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEmailTemplate
		{
			get
			{
				IEntityRelation intermediateRelation = NotificationTypeEntity.Relations.EmailTemplateEntityUsingNotificationTypeId;
				intermediateRelation.SetAliases(string.Empty, "EmailTemplate_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotificationTypeEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEmailTemplate"), null, "OrganizationRoleUserCollectionViaEmailTemplate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification
		{
			get
			{
				IEntityRelation intermediateRelation = NotificationTypeEntity.Relations.EventCustomerTestNotPerformedNotificationEntityUsingNotificationTypeId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerTestNotPerformedNotification_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotificationTypeEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification"), null, "OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaEventCustomerTestNotPerformedNotification
		{
			get
			{
				IEntityRelation intermediateRelation = NotificationTypeEntity.Relations.EventCustomerTestNotPerformedNotificationEntityUsingNotificationTypeId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomerTestNotPerformedNotification_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotificationTypeEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaEventCustomerTestNotPerformedNotification"), null, "TestCollectionViaEventCustomerTestNotPerformedNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("NotificationMedium")[0], (int)Falcon.Data.EntityType.NotificationTypeEntity, (int)Falcon.Data.EntityType.NotificationMediumEntity, 0, null, null, null, null, "NotificationMedium", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.NotificationTypeEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return NotificationTypeEntity.CustomProperties;}
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
			get { return NotificationTypeEntity.FieldsCustomProperties;}
		}

		/// <summary> The NotificationTypeId property of the Entity NotificationType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotificationType"."NotificationTypeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 NotificationTypeId
		{
			get { return (System.Int32)GetValue((int)NotificationTypeFieldIndex.NotificationTypeId, true); }
			set	{ SetValue((int)NotificationTypeFieldIndex.NotificationTypeId, value); }
		}

		/// <summary> The NotificationTypeName property of the Entity NotificationType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotificationType"."NotificationTypeName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String NotificationTypeName
		{
			get { return (System.String)GetValue((int)NotificationTypeFieldIndex.NotificationTypeName, true); }
			set	{ SetValue((int)NotificationTypeFieldIndex.NotificationTypeName, value); }
		}

		/// <summary> The NotificationTypeNameAlias property of the Entity NotificationType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotificationType"."NotificationTypeNameAlias"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String NotificationTypeNameAlias
		{
			get { return (System.String)GetValue((int)NotificationTypeFieldIndex.NotificationTypeNameAlias, true); }
			set	{ SetValue((int)NotificationTypeFieldIndex.NotificationTypeNameAlias, value); }
		}

		/// <summary> The Description property of the Entity NotificationType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotificationType"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)NotificationTypeFieldIndex.Description, true); }
			set	{ SetValue((int)NotificationTypeFieldIndex.Description, value); }
		}

		/// <summary> The DateCreated property of the Entity NotificationType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotificationType"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)NotificationTypeFieldIndex.DateCreated, true); }
			set	{ SetValue((int)NotificationTypeFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity NotificationType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotificationType"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)NotificationTypeFieldIndex.DateModified, false); }
			set	{ SetValue((int)NotificationTypeFieldIndex.DateModified, value); }
		}

		/// <summary> The IsActive property of the Entity NotificationType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotificationType"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)NotificationTypeFieldIndex.IsActive, true); }
			set	{ SetValue((int)NotificationTypeFieldIndex.IsActive, value); }
		}

		/// <summary> The NoOfAttempts property of the Entity NotificationType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotificationType"."NoOfAttempts"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 NoOfAttempts
		{
			get { return (System.Int32)GetValue((int)NotificationTypeFieldIndex.NoOfAttempts, true); }
			set	{ SetValue((int)NotificationTypeFieldIndex.NoOfAttempts, value); }
		}

		/// <summary> The NotificationMediumId property of the Entity NotificationType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotificationType"."NotificationMediumId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 NotificationMediumId
		{
			get { return (System.Int32)GetValue((int)NotificationTypeFieldIndex.NotificationMediumId, true); }
			set	{ SetValue((int)NotificationTypeFieldIndex.NotificationMediumId, value); }
		}

		/// <summary> The AllowTemplateCreation property of the Entity NotificationType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotificationType"."AllowTemplateCreation"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AllowTemplateCreation
		{
			get { return (System.Boolean)GetValue((int)NotificationTypeFieldIndex.AllowTemplateCreation, true); }
			set	{ SetValue((int)NotificationTypeFieldIndex.AllowTemplateCreation, value); }
		}

		/// <summary> The IsServiceEnabled property of the Entity NotificationType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotificationType"."IsServiceEnabled"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsServiceEnabled
		{
			get { return (System.Boolean)GetValue((int)NotificationTypeFieldIndex.IsServiceEnabled, true); }
			set	{ SetValue((int)NotificationTypeFieldIndex.IsServiceEnabled, value); }
		}

		/// <summary> The IsQueuingEnabled property of the Entity NotificationType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotificationType"."IsQueuingEnabled"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsQueuingEnabled
		{
			get { return (System.Boolean)GetValue((int)NotificationTypeFieldIndex.IsQueuingEnabled, true); }
			set	{ SetValue((int)NotificationTypeFieldIndex.IsQueuingEnabled, value); }
		}

		/// <summary> The ModifiedByOrgRoleUserId property of the Entity NotificationType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotificationType"."ModifiedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)NotificationTypeFieldIndex.ModifiedByOrgRoleUserId, false); }
			set	{ SetValue((int)NotificationTypeFieldIndex.ModifiedByOrgRoleUserId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EmailTemplateEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EmailTemplateEntity))]
		public virtual EntityCollection<EmailTemplateEntity> EmailTemplate
		{
			get
			{
				if(_emailTemplate==null)
				{
					_emailTemplate = new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory)));
					_emailTemplate.SetContainingEntityInfo(this, "NotificationType");
				}
				return _emailTemplate;
			}
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
					_eventCustomerNotification.SetContainingEntityInfo(this, "NotificationType");
				}
				return _eventCustomerNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerTestNotPerformedNotificationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerTestNotPerformedNotificationEntity))]
		public virtual EntityCollection<EventCustomerTestNotPerformedNotificationEntity> EventCustomerTestNotPerformedNotification
		{
			get
			{
				if(_eventCustomerTestNotPerformedNotification==null)
				{
					_eventCustomerTestNotPerformedNotification = new EntityCollection<EventCustomerTestNotPerformedNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerTestNotPerformedNotificationEntityFactory)));
					_eventCustomerTestNotPerformedNotification.SetContainingEntityInfo(this, "NotificationType");
				}
				return _eventCustomerTestNotPerformedNotification;
			}
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
					_notification.SetContainingEntityInfo(this, "NotificationType");
				}
				return _notification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NotificationSubscribersEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NotificationSubscribersEntity))]
		public virtual EntityCollection<NotificationSubscribersEntity> NotificationSubscribers
		{
			get
			{
				if(_notificationSubscribers==null)
				{
					_notificationSubscribers = new EntityCollection<NotificationSubscribersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationSubscribersEntityFactory)));
					_notificationSubscribers.SetContainingEntityInfo(this, "NotificationType");
				}
				return _notificationSubscribers;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaEventCustomerTestNotPerformedNotification
		{
			get
			{
				if(_eventCustomersCollectionViaEventCustomerTestNotPerformedNotification==null)
				{
					_eventCustomersCollectionViaEventCustomerTestNotPerformedNotification = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaEventCustomerTestNotPerformedNotification.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaEventCustomerTestNotPerformedNotification;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEmailTemplate
		{
			get
			{
				if(_lookupCollectionViaEmailTemplate==null)
				{
					_lookupCollectionViaEmailTemplate = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEmailTemplate.IsReadOnly=true;
				}
				return _lookupCollectionViaEmailTemplate;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEmailTemplate_
		{
			get
			{
				if(_lookupCollectionViaEmailTemplate_==null)
				{
					_lookupCollectionViaEmailTemplate_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEmailTemplate_.IsReadOnly=true;
				}
				return _lookupCollectionViaEmailTemplate_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NotificationEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NotificationEntity))]
		public virtual EntityCollection<NotificationEntity> NotificationCollectionViaEventCustomerNotification
		{
			get
			{
				if(_notificationCollectionViaEventCustomerNotification==null)
				{
					_notificationCollectionViaEventCustomerNotification = new EntityCollection<NotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationEntityFactory)));
					_notificationCollectionViaEventCustomerNotification.IsReadOnly=true;
				}
				return _notificationCollectionViaEventCustomerNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NotificationMediumEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NotificationMediumEntity))]
		public virtual EntityCollection<NotificationMediumEntity> NotificationMediumCollectionViaNotification
		{
			get
			{
				if(_notificationMediumCollectionViaNotification==null)
				{
					_notificationMediumCollectionViaNotification = new EntityCollection<NotificationMediumEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationMediumEntityFactory)));
					_notificationMediumCollectionViaNotification.IsReadOnly=true;
				}
				return _notificationMediumCollectionViaNotification;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEmailTemplate
		{
			get
			{
				if(_organizationRoleUserCollectionViaEmailTemplate==null)
				{
					_organizationRoleUserCollectionViaEmailTemplate = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEmailTemplate.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEmailTemplate;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification==null)
				{
					_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventCustomerTestNotPerformedNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaEventCustomerTestNotPerformedNotification
		{
			get
			{
				if(_testCollectionViaEventCustomerTestNotPerformedNotification==null)
				{
					_testCollectionViaEventCustomerTestNotPerformedNotification = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaEventCustomerTestNotPerformedNotification.IsReadOnly=true;
				}
				return _testCollectionViaEventCustomerTestNotPerformedNotification;
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
							_notificationMedium.UnsetRelatedEntity(this, "NotificationType");
						}
					}
					else
					{
						if(_notificationMedium!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "NotificationType");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "NotificationType");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "NotificationType");
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
			get { return (int)Falcon.Data.EntityType.NotificationTypeEntity; }
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
