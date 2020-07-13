///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:47
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
	/// Entity class which represents the entity 'RefundRequest'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class RefundRequestEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<EventAppointmentCancellationLogEntity> _eventAppointmentCancellationLog;
		private EntityCollection<RefundRequestGiftCertificateEntity> _refundRequestGiftCertificate;
		private EntityCollection<CustomerRegistrationNotesEntity> _customerRegistrationNotesCollectionViaEventAppointmentCancellationLog;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaEventAppointmentCancellationLog;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventAppointmentCancellationLog;
		private EntityCollection<GiftCertificateEntity> _giftCertificateCollectionViaRefundRequestGiftCertificate;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventAppointmentCancellationLog;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventAppointmentCancellationLog;
		private EntityCollection<RescheduleCancelDispositionEntity> _rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog;
		private LookupEntity _lookup;
		private OrderEntity _order;
		private OrganizationRoleUserEntity _organizationRoleUser_;
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
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name Order</summary>
			public static readonly string Order = "Order";
			/// <summary>Member name OrganizationRoleUser_</summary>
			public static readonly string OrganizationRoleUser_ = "OrganizationRoleUser_";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name EventAppointmentCancellationLog</summary>
			public static readonly string EventAppointmentCancellationLog = "EventAppointmentCancellationLog";
			/// <summary>Member name RefundRequestGiftCertificate</summary>
			public static readonly string RefundRequestGiftCertificate = "RefundRequestGiftCertificate";
			/// <summary>Member name CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog</summary>
			public static readonly string CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog = "CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog";
			/// <summary>Member name EventCustomersCollectionViaEventAppointmentCancellationLog</summary>
			public static readonly string EventCustomersCollectionViaEventAppointmentCancellationLog = "EventCustomersCollectionViaEventAppointmentCancellationLog";
			/// <summary>Member name EventsCollectionViaEventAppointmentCancellationLog</summary>
			public static readonly string EventsCollectionViaEventAppointmentCancellationLog = "EventsCollectionViaEventAppointmentCancellationLog";
			/// <summary>Member name GiftCertificateCollectionViaRefundRequestGiftCertificate</summary>
			public static readonly string GiftCertificateCollectionViaRefundRequestGiftCertificate = "GiftCertificateCollectionViaRefundRequestGiftCertificate";
			/// <summary>Member name LookupCollectionViaEventAppointmentCancellationLog</summary>
			public static readonly string LookupCollectionViaEventAppointmentCancellationLog = "LookupCollectionViaEventAppointmentCancellationLog";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventAppointmentCancellationLog</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventAppointmentCancellationLog = "OrganizationRoleUserCollectionViaEventAppointmentCancellationLog";
			/// <summary>Member name RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog</summary>
			public static readonly string RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog = "RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static RefundRequestEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public RefundRequestEntity():base("RefundRequestEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public RefundRequestEntity(IEntityFields2 fields):base("RefundRequestEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this RefundRequestEntity</param>
		public RefundRequestEntity(IValidator validator):base("RefundRequestEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="refundRequestId">PK value for RefundRequest which data should be fetched into this RefundRequest object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public RefundRequestEntity(System.Int64 refundRequestId):base("RefundRequestEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.RefundRequestId = refundRequestId;
		}

		/// <summary> CTor</summary>
		/// <param name="refundRequestId">PK value for RefundRequest which data should be fetched into this RefundRequest object</param>
		/// <param name="validator">The custom validator object for this RefundRequestEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public RefundRequestEntity(System.Int64 refundRequestId, IValidator validator):base("RefundRequestEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.RefundRequestId = refundRequestId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected RefundRequestEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_eventAppointmentCancellationLog = (EntityCollection<EventAppointmentCancellationLogEntity>)info.GetValue("_eventAppointmentCancellationLog", typeof(EntityCollection<EventAppointmentCancellationLogEntity>));
				_refundRequestGiftCertificate = (EntityCollection<RefundRequestGiftCertificateEntity>)info.GetValue("_refundRequestGiftCertificate", typeof(EntityCollection<RefundRequestGiftCertificateEntity>));
				_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog = (EntityCollection<CustomerRegistrationNotesEntity>)info.GetValue("_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog", typeof(EntityCollection<CustomerRegistrationNotesEntity>));
				_eventCustomersCollectionViaEventAppointmentCancellationLog = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaEventAppointmentCancellationLog", typeof(EntityCollection<EventCustomersEntity>));
				_eventsCollectionViaEventAppointmentCancellationLog = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventAppointmentCancellationLog", typeof(EntityCollection<EventsEntity>));
				_giftCertificateCollectionViaRefundRequestGiftCertificate = (EntityCollection<GiftCertificateEntity>)info.GetValue("_giftCertificateCollectionViaRefundRequestGiftCertificate", typeof(EntityCollection<GiftCertificateEntity>));
				_lookupCollectionViaEventAppointmentCancellationLog = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventAppointmentCancellationLog", typeof(EntityCollection<LookupEntity>));
				_organizationRoleUserCollectionViaEventAppointmentCancellationLog = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventAppointmentCancellationLog", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog = (EntityCollection<RescheduleCancelDispositionEntity>)info.GetValue("_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog", typeof(EntityCollection<RescheduleCancelDispositionEntity>));
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_order = (OrderEntity)info.GetValue("_order", typeof(OrderEntity));
				if(_order!=null)
				{
					_order.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser_ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser_", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser_!=null)
				{
					_organizationRoleUser_.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((RefundRequestFieldIndex)fieldIndex)
			{
				case RefundRequestFieldIndex.OrderId:
					DesetupSyncOrder(true, false);
					break;
				case RefundRequestFieldIndex.RequestedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case RefundRequestFieldIndex.ProcessedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser_(true, false);
					break;
				case RefundRequestFieldIndex.RequestStatus:
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
				case "Order":
					this.Order = (OrderEntity)entity;
					break;
				case "OrganizationRoleUser_":
					this.OrganizationRoleUser_ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "EventAppointmentCancellationLog":
					this.EventAppointmentCancellationLog.Add((EventAppointmentCancellationLogEntity)entity);
					break;
				case "RefundRequestGiftCertificate":
					this.RefundRequestGiftCertificate.Add((RefundRequestGiftCertificateEntity)entity);
					break;
				case "CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog":
					this.CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog.IsReadOnly = false;
					this.CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog.Add((CustomerRegistrationNotesEntity)entity);
					this.CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaEventAppointmentCancellationLog":
					this.EventCustomersCollectionViaEventAppointmentCancellationLog.IsReadOnly = false;
					this.EventCustomersCollectionViaEventAppointmentCancellationLog.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaEventAppointmentCancellationLog.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventAppointmentCancellationLog":
					this.EventsCollectionViaEventAppointmentCancellationLog.IsReadOnly = false;
					this.EventsCollectionViaEventAppointmentCancellationLog.Add((EventsEntity)entity);
					this.EventsCollectionViaEventAppointmentCancellationLog.IsReadOnly = true;
					break;
				case "GiftCertificateCollectionViaRefundRequestGiftCertificate":
					this.GiftCertificateCollectionViaRefundRequestGiftCertificate.IsReadOnly = false;
					this.GiftCertificateCollectionViaRefundRequestGiftCertificate.Add((GiftCertificateEntity)entity);
					this.GiftCertificateCollectionViaRefundRequestGiftCertificate.IsReadOnly = true;
					break;
				case "LookupCollectionViaEventAppointmentCancellationLog":
					this.LookupCollectionViaEventAppointmentCancellationLog.IsReadOnly = false;
					this.LookupCollectionViaEventAppointmentCancellationLog.Add((LookupEntity)entity);
					this.LookupCollectionViaEventAppointmentCancellationLog.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventAppointmentCancellationLog":
					this.OrganizationRoleUserCollectionViaEventAppointmentCancellationLog.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventAppointmentCancellationLog.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventAppointmentCancellationLog.IsReadOnly = true;
					break;
				case "RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog":
					this.RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog.IsReadOnly = false;
					this.RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog.Add((RescheduleCancelDispositionEntity)entity);
					this.RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog.IsReadOnly = true;
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
			return RefundRequestEntity.GetRelationsForField(fieldName);
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
					toReturn.Add(RefundRequestEntity.Relations.LookupEntityUsingRequestStatus);
					break;
				case "Order":
					toReturn.Add(RefundRequestEntity.Relations.OrderEntityUsingOrderId);
					break;
				case "OrganizationRoleUser_":
					toReturn.Add(RefundRequestEntity.Relations.OrganizationRoleUserEntityUsingProcessedByOrgRoleUserId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(RefundRequestEntity.Relations.OrganizationRoleUserEntityUsingRequestedByOrgRoleUserId);
					break;
				case "EventAppointmentCancellationLog":
					toReturn.Add(RefundRequestEntity.Relations.EventAppointmentCancellationLogEntityUsingRefundRequestId);
					break;
				case "RefundRequestGiftCertificate":
					toReturn.Add(RefundRequestEntity.Relations.RefundRequestGiftCertificateEntityUsingRefundRequestId);
					break;
				case "CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog":
					toReturn.Add(RefundRequestEntity.Relations.EventAppointmentCancellationLogEntityUsingRefundRequestId, "RefundRequestEntity__", "EventAppointmentCancellationLog_", JoinHint.None);
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.CustomerRegistrationNotesEntityUsingNoteId, "EventAppointmentCancellationLog_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaEventAppointmentCancellationLog":
					toReturn.Add(RefundRequestEntity.Relations.EventAppointmentCancellationLogEntityUsingRefundRequestId, "RefundRequestEntity__", "EventAppointmentCancellationLog_", JoinHint.None);
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.EventCustomersEntityUsingEventCustomerId, "EventAppointmentCancellationLog_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventAppointmentCancellationLog":
					toReturn.Add(RefundRequestEntity.Relations.EventAppointmentCancellationLogEntityUsingRefundRequestId, "RefundRequestEntity__", "EventAppointmentCancellationLog_", JoinHint.None);
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.EventsEntityUsingEventId, "EventAppointmentCancellationLog_", string.Empty, JoinHint.None);
					break;
				case "GiftCertificateCollectionViaRefundRequestGiftCertificate":
					toReturn.Add(RefundRequestEntity.Relations.RefundRequestGiftCertificateEntityUsingRefundRequestId, "RefundRequestEntity__", "RefundRequestGiftCertificate_", JoinHint.None);
					toReturn.Add(RefundRequestGiftCertificateEntity.Relations.GiftCertificateEntityUsingGiftCertificateId, "RefundRequestGiftCertificate_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventAppointmentCancellationLog":
					toReturn.Add(RefundRequestEntity.Relations.EventAppointmentCancellationLogEntityUsingRefundRequestId, "RefundRequestEntity__", "EventAppointmentCancellationLog_", JoinHint.None);
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.LookupEntityUsingReasonId, "EventAppointmentCancellationLog_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventAppointmentCancellationLog":
					toReturn.Add(RefundRequestEntity.Relations.EventAppointmentCancellationLogEntityUsingRefundRequestId, "RefundRequestEntity__", "EventAppointmentCancellationLog_", JoinHint.None);
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "EventAppointmentCancellationLog_", string.Empty, JoinHint.None);
					break;
				case "RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog":
					toReturn.Add(RefundRequestEntity.Relations.EventAppointmentCancellationLogEntityUsingRefundRequestId, "RefundRequestEntity__", "EventAppointmentCancellationLog_", JoinHint.None);
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.RescheduleCancelDispositionEntityUsingSubReasonId, "EventAppointmentCancellationLog_", string.Empty, JoinHint.None);
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
				case "Order":
					SetupSyncOrder(relatedEntity);
					break;
				case "OrganizationRoleUser_":
					SetupSyncOrganizationRoleUser_(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "EventAppointmentCancellationLog":
					this.EventAppointmentCancellationLog.Add((EventAppointmentCancellationLogEntity)relatedEntity);
					break;
				case "RefundRequestGiftCertificate":
					this.RefundRequestGiftCertificate.Add((RefundRequestGiftCertificateEntity)relatedEntity);
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
				case "Order":
					DesetupSyncOrder(false, true);
					break;
				case "OrganizationRoleUser_":
					DesetupSyncOrganizationRoleUser_(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "EventAppointmentCancellationLog":
					base.PerformRelatedEntityRemoval(this.EventAppointmentCancellationLog, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "RefundRequestGiftCertificate":
					base.PerformRelatedEntityRemoval(this.RefundRequestGiftCertificate, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_order!=null)
			{
				toReturn.Add(_order);
			}
			if(_organizationRoleUser_!=null)
			{
				toReturn.Add(_organizationRoleUser_);
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
			toReturn.Add(this.EventAppointmentCancellationLog);
			toReturn.Add(this.RefundRequestGiftCertificate);

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
				info.AddValue("_eventAppointmentCancellationLog", ((_eventAppointmentCancellationLog!=null) && (_eventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_eventAppointmentCancellationLog:null);
				info.AddValue("_refundRequestGiftCertificate", ((_refundRequestGiftCertificate!=null) && (_refundRequestGiftCertificate.Count>0) && !this.MarkedForDeletion)?_refundRequestGiftCertificate:null);
				info.AddValue("_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog", ((_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog!=null) && (_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog:null);
				info.AddValue("_eventCustomersCollectionViaEventAppointmentCancellationLog", ((_eventCustomersCollectionViaEventAppointmentCancellationLog!=null) && (_eventCustomersCollectionViaEventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaEventAppointmentCancellationLog:null);
				info.AddValue("_eventsCollectionViaEventAppointmentCancellationLog", ((_eventsCollectionViaEventAppointmentCancellationLog!=null) && (_eventsCollectionViaEventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventAppointmentCancellationLog:null);
				info.AddValue("_giftCertificateCollectionViaRefundRequestGiftCertificate", ((_giftCertificateCollectionViaRefundRequestGiftCertificate!=null) && (_giftCertificateCollectionViaRefundRequestGiftCertificate.Count>0) && !this.MarkedForDeletion)?_giftCertificateCollectionViaRefundRequestGiftCertificate:null);
				info.AddValue("_lookupCollectionViaEventAppointmentCancellationLog", ((_lookupCollectionViaEventAppointmentCancellationLog!=null) && (_lookupCollectionViaEventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventAppointmentCancellationLog:null);
				info.AddValue("_organizationRoleUserCollectionViaEventAppointmentCancellationLog", ((_organizationRoleUserCollectionViaEventAppointmentCancellationLog!=null) && (_organizationRoleUserCollectionViaEventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventAppointmentCancellationLog:null);
				info.AddValue("_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog", ((_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog!=null) && (_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog:null);
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_order", (!this.MarkedForDeletion?_order:null));
				info.AddValue("_organizationRoleUser_", (!this.MarkedForDeletion?_organizationRoleUser_:null));
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
		public bool TestOriginalFieldValueForNull(RefundRequestFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(RefundRequestFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new RefundRequestRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventAppointmentCancellationLog' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventAppointmentCancellationLogFields.RefundRequestId, null, ComparisonOperator.Equal, this.RefundRequestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'RefundRequestGiftCertificate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRefundRequestGiftCertificate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RefundRequestGiftCertificateFields.RefundRequestId, null, ComparisonOperator.Equal, this.RefundRequestId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerRegistrationNotes' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RefundRequestFields.RefundRequestId, null, ComparisonOperator.Equal, this.RefundRequestId, "RefundRequestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaEventAppointmentCancellationLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RefundRequestFields.RefundRequestId, null, ComparisonOperator.Equal, this.RefundRequestId, "RefundRequestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventAppointmentCancellationLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RefundRequestFields.RefundRequestId, null, ComparisonOperator.Equal, this.RefundRequestId, "RefundRequestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GiftCertificate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGiftCertificateCollectionViaRefundRequestGiftCertificate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("GiftCertificateCollectionViaRefundRequestGiftCertificate"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RefundRequestFields.RefundRequestId, null, ComparisonOperator.Equal, this.RefundRequestId, "RefundRequestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventAppointmentCancellationLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RefundRequestFields.RefundRequestId, null, ComparisonOperator.Equal, this.RefundRequestId, "RefundRequestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventAppointmentCancellationLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RefundRequestFields.RefundRequestId, null, ComparisonOperator.Equal, this.RefundRequestId, "RefundRequestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'RescheduleCancelDisposition' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RefundRequestFields.RefundRequestId, null, ComparisonOperator.Equal, this.RefundRequestId, "RefundRequestEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.RequestStatus));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Order' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrder()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrderFields.OrderId, null, ComparisonOperator.Equal, this.OrderId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.ProcessedByOrgRoleUserId));
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

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.RefundRequestEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(RefundRequestEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._eventAppointmentCancellationLog);
			collectionsQueue.Enqueue(this._refundRequestGiftCertificate);
			collectionsQueue.Enqueue(this._customerRegistrationNotesCollectionViaEventAppointmentCancellationLog);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaEventAppointmentCancellationLog);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventAppointmentCancellationLog);
			collectionsQueue.Enqueue(this._giftCertificateCollectionViaRefundRequestGiftCertificate);
			collectionsQueue.Enqueue(this._lookupCollectionViaEventAppointmentCancellationLog);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventAppointmentCancellationLog);
			collectionsQueue.Enqueue(this._rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._eventAppointmentCancellationLog = (EntityCollection<EventAppointmentCancellationLogEntity>) collectionsQueue.Dequeue();
			this._refundRequestGiftCertificate = (EntityCollection<RefundRequestGiftCertificateEntity>) collectionsQueue.Dequeue();
			this._customerRegistrationNotesCollectionViaEventAppointmentCancellationLog = (EntityCollection<CustomerRegistrationNotesEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaEventAppointmentCancellationLog = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventAppointmentCancellationLog = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._giftCertificateCollectionViaRefundRequestGiftCertificate = (EntityCollection<GiftCertificateEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEventAppointmentCancellationLog = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventAppointmentCancellationLog = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog = (EntityCollection<RescheduleCancelDispositionEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._eventAppointmentCancellationLog != null)
			{
				return true;
			}
			if (this._refundRequestGiftCertificate != null)
			{
				return true;
			}
			if (this._customerRegistrationNotesCollectionViaEventAppointmentCancellationLog != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaEventAppointmentCancellationLog != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventAppointmentCancellationLog != null)
			{
				return true;
			}
			if (this._giftCertificateCollectionViaRefundRequestGiftCertificate != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEventAppointmentCancellationLog != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventAppointmentCancellationLog != null)
			{
				return true;
			}
			if (this._rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventAppointmentCancellationLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentCancellationLogEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RefundRequestGiftCertificateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundRequestGiftCertificateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerRegistrationNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerRegistrationNotesEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GiftCertificateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RescheduleCancelDispositionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RescheduleCancelDispositionEntityFactory))) : null);
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
			toReturn.Add("Order", _order);
			toReturn.Add("OrganizationRoleUser_", _organizationRoleUser_);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("EventAppointmentCancellationLog", _eventAppointmentCancellationLog);
			toReturn.Add("RefundRequestGiftCertificate", _refundRequestGiftCertificate);
			toReturn.Add("CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog", _customerRegistrationNotesCollectionViaEventAppointmentCancellationLog);
			toReturn.Add("EventCustomersCollectionViaEventAppointmentCancellationLog", _eventCustomersCollectionViaEventAppointmentCancellationLog);
			toReturn.Add("EventsCollectionViaEventAppointmentCancellationLog", _eventsCollectionViaEventAppointmentCancellationLog);
			toReturn.Add("GiftCertificateCollectionViaRefundRequestGiftCertificate", _giftCertificateCollectionViaRefundRequestGiftCertificate);
			toReturn.Add("LookupCollectionViaEventAppointmentCancellationLog", _lookupCollectionViaEventAppointmentCancellationLog);
			toReturn.Add("OrganizationRoleUserCollectionViaEventAppointmentCancellationLog", _organizationRoleUserCollectionViaEventAppointmentCancellationLog);
			toReturn.Add("RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog", _rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_eventAppointmentCancellationLog!=null)
			{
				_eventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_refundRequestGiftCertificate!=null)
			{
				_refundRequestGiftCertificate.ActiveContext = base.ActiveContext;
			}
			if(_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog!=null)
			{
				_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaEventAppointmentCancellationLog!=null)
			{
				_eventCustomersCollectionViaEventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventAppointmentCancellationLog!=null)
			{
				_eventsCollectionViaEventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_giftCertificateCollectionViaRefundRequestGiftCertificate!=null)
			{
				_giftCertificateCollectionViaRefundRequestGiftCertificate.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEventAppointmentCancellationLog!=null)
			{
				_lookupCollectionViaEventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventAppointmentCancellationLog!=null)
			{
				_organizationRoleUserCollectionViaEventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog!=null)
			{
				_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_order!=null)
			{
				_order.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser_!=null)
			{
				_organizationRoleUser_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_eventAppointmentCancellationLog = null;
			_refundRequestGiftCertificate = null;
			_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog = null;
			_eventCustomersCollectionViaEventAppointmentCancellationLog = null;
			_eventsCollectionViaEventAppointmentCancellationLog = null;
			_giftCertificateCollectionViaRefundRequestGiftCertificate = null;
			_lookupCollectionViaEventAppointmentCancellationLog = null;
			_organizationRoleUserCollectionViaEventAppointmentCancellationLog = null;
			_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog = null;
			_lookup = null;
			_order = null;
			_organizationRoleUser_ = null;
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

			_fieldsCustomProperties.Add("RefundRequestId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ReasonType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ReasonComment", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OrderId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RequestedRefundAmount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FinalRefundAmount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RequestedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProcessedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProcessorNotes", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RequestedOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProcessedOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RequestResult", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RequestStatus", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _lookup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", RefundRequestEntity.Relations.LookupEntityUsingRequestStatus, true, signalRelatedEntity, "RefundRequest", resetFKFields, new int[] { (int)RefundRequestFieldIndex.RequestStatus } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", RefundRequestEntity.Relations.LookupEntityUsingRequestStatus, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _order</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrder(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _order, new PropertyChangedEventHandler( OnOrderPropertyChanged ), "Order", RefundRequestEntity.Relations.OrderEntityUsingOrderId, true, signalRelatedEntity, "RefundRequest", resetFKFields, new int[] { (int)RefundRequestFieldIndex.OrderId } );		
			_order = null;
		}

		/// <summary> setups the sync logic for member _order</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrder(IEntity2 relatedEntity)
		{
			if(_order!=relatedEntity)
			{
				DesetupSyncOrder(true, true);
				_order = (OrderEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _order, new PropertyChangedEventHandler( OnOrderPropertyChanged ), "Order", RefundRequestEntity.Relations.OrderEntityUsingOrderId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrderPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _organizationRoleUser_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", RefundRequestEntity.Relations.OrganizationRoleUserEntityUsingProcessedByOrgRoleUserId, true, signalRelatedEntity, "RefundRequest_", resetFKFields, new int[] { (int)RefundRequestFieldIndex.ProcessedByOrgRoleUserId } );		
			_organizationRoleUser_ = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser_(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser_!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser_(true, true);
				_organizationRoleUser_ = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", RefundRequestEntity.Relations.OrganizationRoleUserEntityUsingProcessedByOrgRoleUserId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUser_PropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", RefundRequestEntity.Relations.OrganizationRoleUserEntityUsingRequestedByOrgRoleUserId, true, signalRelatedEntity, "RefundRequest", resetFKFields, new int[] { (int)RefundRequestFieldIndex.RequestedByOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", RefundRequestEntity.Relations.OrganizationRoleUserEntityUsingRequestedByOrgRoleUserId, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this RefundRequestEntity</param>
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
		public  static RefundRequestRelations Relations
		{
			get	{ return new RefundRequestRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventAppointmentCancellationLog' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventAppointmentCancellationLog
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventAppointmentCancellationLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentCancellationLogEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventAppointmentCancellationLog")[0], (int)Falcon.Data.EntityType.RefundRequestEntity, (int)Falcon.Data.EntityType.EventAppointmentCancellationLogEntity, 0, null, null, null, null, "EventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RefundRequestGiftCertificate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRefundRequestGiftCertificate
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<RefundRequestGiftCertificateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundRequestGiftCertificateEntityFactory))),
					(IEntityRelation)GetRelationsForField("RefundRequestGiftCertificate")[0], (int)Falcon.Data.EntityType.RefundRequestEntity, (int)Falcon.Data.EntityType.RefundRequestGiftCertificateEntity, 0, null, null, null, null, "RefundRequestGiftCertificate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerRegistrationNotes' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				IEntityRelation intermediateRelation = RefundRequestEntity.Relations.EventAppointmentCancellationLogEntityUsingRefundRequestId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentCancellationLog_");
				return new PrefetchPathElement2(new EntityCollection<CustomerRegistrationNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerRegistrationNotesEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RefundRequestEntity, (int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, 0, null, null, GetRelationsForField("CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog"), null, "CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				IEntityRelation intermediateRelation = RefundRequestEntity.Relations.EventAppointmentCancellationLogEntityUsingRefundRequestId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentCancellationLog_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RefundRequestEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaEventAppointmentCancellationLog"), null, "EventCustomersCollectionViaEventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				IEntityRelation intermediateRelation = RefundRequestEntity.Relations.EventAppointmentCancellationLogEntityUsingRefundRequestId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentCancellationLog_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RefundRequestEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventAppointmentCancellationLog"), null, "EventsCollectionViaEventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GiftCertificate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGiftCertificateCollectionViaRefundRequestGiftCertificate
		{
			get
			{
				IEntityRelation intermediateRelation = RefundRequestEntity.Relations.RefundRequestGiftCertificateEntityUsingRefundRequestId;
				intermediateRelation.SetAliases(string.Empty, "RefundRequestGiftCertificate_");
				return new PrefetchPathElement2(new EntityCollection<GiftCertificateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RefundRequestEntity, (int)Falcon.Data.EntityType.GiftCertificateEntity, 0, null, null, GetRelationsForField("GiftCertificateCollectionViaRefundRequestGiftCertificate"), null, "GiftCertificateCollectionViaRefundRequestGiftCertificate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				IEntityRelation intermediateRelation = RefundRequestEntity.Relations.EventAppointmentCancellationLogEntityUsingRefundRequestId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentCancellationLog_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RefundRequestEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventAppointmentCancellationLog"), null, "LookupCollectionViaEventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				IEntityRelation intermediateRelation = RefundRequestEntity.Relations.EventAppointmentCancellationLogEntityUsingRefundRequestId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentCancellationLog_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RefundRequestEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventAppointmentCancellationLog"), null, "OrganizationRoleUserCollectionViaEventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RescheduleCancelDisposition' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				IEntityRelation intermediateRelation = RefundRequestEntity.Relations.EventAppointmentCancellationLogEntityUsingRefundRequestId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentCancellationLog_");
				return new PrefetchPathElement2(new EntityCollection<RescheduleCancelDispositionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RescheduleCancelDispositionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RefundRequestEntity, (int)Falcon.Data.EntityType.RescheduleCancelDispositionEntity, 0, null, null, GetRelationsForField("RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog"), null, "RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.RefundRequestEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Order' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrder
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrderEntityFactory))),
					(IEntityRelation)GetRelationsForField("Order")[0], (int)Falcon.Data.EntityType.RefundRequestEntity, (int)Falcon.Data.EntityType.OrderEntity, 0, null, null, null, null, "Order", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.RefundRequestEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.RefundRequestEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return RefundRequestEntity.CustomProperties;}
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
			get { return RefundRequestEntity.FieldsCustomProperties;}
		}

		/// <summary> The RefundRequestId property of the Entity RefundRequest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRefundRequest"."RefundRequestID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 RefundRequestId
		{
			get { return (System.Int64)GetValue((int)RefundRequestFieldIndex.RefundRequestId, true); }
			set	{ SetValue((int)RefundRequestFieldIndex.RefundRequestId, value); }
		}

		/// <summary> The ReasonType property of the Entity RefundRequest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRefundRequest"."ReasonType"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ReasonType
		{
			get { return (System.Int64)GetValue((int)RefundRequestFieldIndex.ReasonType, true); }
			set	{ SetValue((int)RefundRequestFieldIndex.ReasonType, value); }
		}

		/// <summary> The ReasonComment property of the Entity RefundRequest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRefundRequest"."ReasonComment"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ReasonComment
		{
			get { return (System.String)GetValue((int)RefundRequestFieldIndex.ReasonComment, true); }
			set	{ SetValue((int)RefundRequestFieldIndex.ReasonComment, value); }
		}

		/// <summary> The OrderId property of the Entity RefundRequest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRefundRequest"."OrderID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 OrderId
		{
			get { return (System.Int64)GetValue((int)RefundRequestFieldIndex.OrderId, true); }
			set	{ SetValue((int)RefundRequestFieldIndex.OrderId, value); }
		}

		/// <summary> The RequestedRefundAmount property of the Entity RefundRequest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRefundRequest"."RequestedRefundAmount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal RequestedRefundAmount
		{
			get { return (System.Decimal)GetValue((int)RefundRequestFieldIndex.RequestedRefundAmount, true); }
			set	{ SetValue((int)RefundRequestFieldIndex.RequestedRefundAmount, value); }
		}

		/// <summary> The FinalRefundAmount property of the Entity RefundRequest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRefundRequest"."FinalRefundAmount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> FinalRefundAmount
		{
			get { return (Nullable<System.Decimal>)GetValue((int)RefundRequestFieldIndex.FinalRefundAmount, false); }
			set	{ SetValue((int)RefundRequestFieldIndex.FinalRefundAmount, value); }
		}

		/// <summary> The RequestedByOrgRoleUserId property of the Entity RefundRequest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRefundRequest"."RequestedByOrgRoleUserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 RequestedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)RefundRequestFieldIndex.RequestedByOrgRoleUserId, true); }
			set	{ SetValue((int)RefundRequestFieldIndex.RequestedByOrgRoleUserId, value); }
		}

		/// <summary> The ProcessedByOrgRoleUserId property of the Entity RefundRequest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRefundRequest"."ProcessedByOrgRoleUserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ProcessedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)RefundRequestFieldIndex.ProcessedByOrgRoleUserId, false); }
			set	{ SetValue((int)RefundRequestFieldIndex.ProcessedByOrgRoleUserId, value); }
		}

		/// <summary> The ProcessorNotes property of the Entity RefundRequest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRefundRequest"."ProcessorNotes"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ProcessorNotes
		{
			get { return (System.String)GetValue((int)RefundRequestFieldIndex.ProcessorNotes, true); }
			set	{ SetValue((int)RefundRequestFieldIndex.ProcessorNotes, value); }
		}

		/// <summary> The RequestedOn property of the Entity RefundRequest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRefundRequest"."RequestedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallDateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime RequestedOn
		{
			get { return (System.DateTime)GetValue((int)RefundRequestFieldIndex.RequestedOn, true); }
			set	{ SetValue((int)RefundRequestFieldIndex.RequestedOn, value); }
		}

		/// <summary> The ProcessedOn property of the Entity RefundRequest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRefundRequest"."ProcessedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallDateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ProcessedOn
		{
			get { return (Nullable<System.DateTime>)GetValue((int)RefundRequestFieldIndex.ProcessedOn, false); }
			set	{ SetValue((int)RefundRequestFieldIndex.ProcessedOn, value); }
		}

		/// <summary> The RequestResult property of the Entity RefundRequest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRefundRequest"."RequestResult"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> RequestResult
		{
			get { return (Nullable<System.Int32>)GetValue((int)RefundRequestFieldIndex.RequestResult, false); }
			set	{ SetValue((int)RefundRequestFieldIndex.RequestResult, value); }
		}

		/// <summary> The IsActive property of the Entity RefundRequest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRefundRequest"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)RefundRequestFieldIndex.IsActive, true); }
			set	{ SetValue((int)RefundRequestFieldIndex.IsActive, value); }
		}

		/// <summary> The RequestStatus property of the Entity RefundRequest<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRefundRequest"."RequestStatus"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 RequestStatus
		{
			get { return (System.Int64)GetValue((int)RefundRequestFieldIndex.RequestStatus, true); }
			set	{ SetValue((int)RefundRequestFieldIndex.RequestStatus, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventAppointmentCancellationLogEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventAppointmentCancellationLogEntity))]
		public virtual EntityCollection<EventAppointmentCancellationLogEntity> EventAppointmentCancellationLog
		{
			get
			{
				if(_eventAppointmentCancellationLog==null)
				{
					_eventAppointmentCancellationLog = new EntityCollection<EventAppointmentCancellationLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentCancellationLogEntityFactory)));
					_eventAppointmentCancellationLog.SetContainingEntityInfo(this, "RefundRequest");
				}
				return _eventAppointmentCancellationLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RefundRequestGiftCertificateEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RefundRequestGiftCertificateEntity))]
		public virtual EntityCollection<RefundRequestGiftCertificateEntity> RefundRequestGiftCertificate
		{
			get
			{
				if(_refundRequestGiftCertificate==null)
				{
					_refundRequestGiftCertificate = new EntityCollection<RefundRequestGiftCertificateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundRequestGiftCertificateEntityFactory)));
					_refundRequestGiftCertificate.SetContainingEntityInfo(this, "RefundRequest");
				}
				return _refundRequestGiftCertificate;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerRegistrationNotesEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerRegistrationNotesEntity))]
		public virtual EntityCollection<CustomerRegistrationNotesEntity> CustomerRegistrationNotesCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				if(_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog==null)
				{
					_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog = new EntityCollection<CustomerRegistrationNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerRegistrationNotesEntityFactory)));
					_customerRegistrationNotesCollectionViaEventAppointmentCancellationLog.IsReadOnly=true;
				}
				return _customerRegistrationNotesCollectionViaEventAppointmentCancellationLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				if(_eventCustomersCollectionViaEventAppointmentCancellationLog==null)
				{
					_eventCustomersCollectionViaEventAppointmentCancellationLog = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaEventAppointmentCancellationLog.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaEventAppointmentCancellationLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				if(_eventsCollectionViaEventAppointmentCancellationLog==null)
				{
					_eventsCollectionViaEventAppointmentCancellationLog = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventAppointmentCancellationLog.IsReadOnly=true;
				}
				return _eventsCollectionViaEventAppointmentCancellationLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GiftCertificateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GiftCertificateEntity))]
		public virtual EntityCollection<GiftCertificateEntity> GiftCertificateCollectionViaRefundRequestGiftCertificate
		{
			get
			{
				if(_giftCertificateCollectionViaRefundRequestGiftCertificate==null)
				{
					_giftCertificateCollectionViaRefundRequestGiftCertificate = new EntityCollection<GiftCertificateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GiftCertificateEntityFactory)));
					_giftCertificateCollectionViaRefundRequestGiftCertificate.IsReadOnly=true;
				}
				return _giftCertificateCollectionViaRefundRequestGiftCertificate;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				if(_lookupCollectionViaEventAppointmentCancellationLog==null)
				{
					_lookupCollectionViaEventAppointmentCancellationLog = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEventAppointmentCancellationLog.IsReadOnly=true;
				}
				return _lookupCollectionViaEventAppointmentCancellationLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventAppointmentCancellationLog==null)
				{
					_organizationRoleUserCollectionViaEventAppointmentCancellationLog = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventAppointmentCancellationLog.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventAppointmentCancellationLog;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RescheduleCancelDispositionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RescheduleCancelDispositionEntity))]
		public virtual EntityCollection<RescheduleCancelDispositionEntity> RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				if(_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog==null)
				{
					_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog = new EntityCollection<RescheduleCancelDispositionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RescheduleCancelDispositionEntityFactory)));
					_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog.IsReadOnly=true;
				}
				return _rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog;
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
							_lookup.UnsetRelatedEntity(this, "RefundRequest");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "RefundRequest");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrderEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrderEntity Order
		{
			get
			{
				return _order;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrder(value);
				}
				else
				{
					if(value==null)
					{
						if(_order != null)
						{
							_order.UnsetRelatedEntity(this, "RefundRequest");
						}
					}
					else
					{
						if(_order!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "RefundRequest");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser_
		{
			get
			{
				return _organizationRoleUser_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser_(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser_ != null)
						{
							_organizationRoleUser_.UnsetRelatedEntity(this, "RefundRequest_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "RefundRequest_");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "RefundRequest");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "RefundRequest");
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
			get { return (int)Falcon.Data.EntityType.RefundRequestEntity; }
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
