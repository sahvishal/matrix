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
	/// Entity class which represents the entity 'EventAppointment'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class EventAppointmentEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<EventCustomersEntity> _eventCustomers;
		private EntityCollection<EventSlotAppointmentEntity> _eventSlotAppointment;
		private EntityCollection<AfaffiliateCampaignEntity> _afaffiliateCampaignCollectionViaEventCustomers;
		private EntityCollection<CampaignEntity> _campaignCollectionViaEventCustomers;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaEventCustomers;
		private EntityCollection<CustomerProfileHistoryEntity> _customerProfileHistoryCollectionViaEventCustomers;
		private EntityCollection<CustomerRegistrationNotesEntity> _customerRegistrationNotesCollectionViaEventCustomers;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventCustomers;
		private EntityCollection<GcNotGivenReasonEntity> _gcNotGivenReasonCollectionViaEventCustomers;
		private EntityCollection<HospitalFacilityEntity> _hospitalFacilityCollectionViaEventCustomers;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventCustomers_;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventCustomers;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventCustomers_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventCustomers;
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
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name EventCustomers</summary>
			public static readonly string EventCustomers = "EventCustomers";
			/// <summary>Member name EventSlotAppointment</summary>
			public static readonly string EventSlotAppointment = "EventSlotAppointment";
			/// <summary>Member name AfaffiliateCampaignCollectionViaEventCustomers</summary>
			public static readonly string AfaffiliateCampaignCollectionViaEventCustomers = "AfaffiliateCampaignCollectionViaEventCustomers";
			/// <summary>Member name CampaignCollectionViaEventCustomers</summary>
			public static readonly string CampaignCollectionViaEventCustomers = "CampaignCollectionViaEventCustomers";
			/// <summary>Member name CustomerProfileCollectionViaEventCustomers</summary>
			public static readonly string CustomerProfileCollectionViaEventCustomers = "CustomerProfileCollectionViaEventCustomers";
			/// <summary>Member name CustomerProfileHistoryCollectionViaEventCustomers</summary>
			public static readonly string CustomerProfileHistoryCollectionViaEventCustomers = "CustomerProfileHistoryCollectionViaEventCustomers";
			/// <summary>Member name CustomerRegistrationNotesCollectionViaEventCustomers</summary>
			public static readonly string CustomerRegistrationNotesCollectionViaEventCustomers = "CustomerRegistrationNotesCollectionViaEventCustomers";
			/// <summary>Member name EventsCollectionViaEventCustomers</summary>
			public static readonly string EventsCollectionViaEventCustomers = "EventsCollectionViaEventCustomers";
			/// <summary>Member name GcNotGivenReasonCollectionViaEventCustomers</summary>
			public static readonly string GcNotGivenReasonCollectionViaEventCustomers = "GcNotGivenReasonCollectionViaEventCustomers";
			/// <summary>Member name HospitalFacilityCollectionViaEventCustomers</summary>
			public static readonly string HospitalFacilityCollectionViaEventCustomers = "HospitalFacilityCollectionViaEventCustomers";
			/// <summary>Member name LookupCollectionViaEventCustomers_</summary>
			public static readonly string LookupCollectionViaEventCustomers_ = "LookupCollectionViaEventCustomers_";
			/// <summary>Member name LookupCollectionViaEventCustomers</summary>
			public static readonly string LookupCollectionViaEventCustomers = "LookupCollectionViaEventCustomers";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventCustomers_</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventCustomers_ = "OrganizationRoleUserCollectionViaEventCustomers_";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventCustomers</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventCustomers = "OrganizationRoleUserCollectionViaEventCustomers";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static EventAppointmentEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public EventAppointmentEntity():base("EventAppointmentEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public EventAppointmentEntity(IEntityFields2 fields):base("EventAppointmentEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this EventAppointmentEntity</param>
		public EventAppointmentEntity(IValidator validator):base("EventAppointmentEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="appointmentId">PK value for EventAppointment which data should be fetched into this EventAppointment object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EventAppointmentEntity(System.Int64 appointmentId):base("EventAppointmentEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.AppointmentId = appointmentId;
		}

		/// <summary> CTor</summary>
		/// <param name="appointmentId">PK value for EventAppointment which data should be fetched into this EventAppointment object</param>
		/// <param name="validator">The custom validator object for this EventAppointmentEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EventAppointmentEntity(System.Int64 appointmentId, IValidator validator):base("EventAppointmentEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.AppointmentId = appointmentId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected EventAppointmentEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_eventCustomers = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomers", typeof(EntityCollection<EventCustomersEntity>));
				_eventSlotAppointment = (EntityCollection<EventSlotAppointmentEntity>)info.GetValue("_eventSlotAppointment", typeof(EntityCollection<EventSlotAppointmentEntity>));
				_afaffiliateCampaignCollectionViaEventCustomers = (EntityCollection<AfaffiliateCampaignEntity>)info.GetValue("_afaffiliateCampaignCollectionViaEventCustomers", typeof(EntityCollection<AfaffiliateCampaignEntity>));
				_campaignCollectionViaEventCustomers = (EntityCollection<CampaignEntity>)info.GetValue("_campaignCollectionViaEventCustomers", typeof(EntityCollection<CampaignEntity>));
				_customerProfileCollectionViaEventCustomers = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaEventCustomers", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileHistoryCollectionViaEventCustomers = (EntityCollection<CustomerProfileHistoryEntity>)info.GetValue("_customerProfileHistoryCollectionViaEventCustomers", typeof(EntityCollection<CustomerProfileHistoryEntity>));
				_customerRegistrationNotesCollectionViaEventCustomers = (EntityCollection<CustomerRegistrationNotesEntity>)info.GetValue("_customerRegistrationNotesCollectionViaEventCustomers", typeof(EntityCollection<CustomerRegistrationNotesEntity>));
				_eventsCollectionViaEventCustomers = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventCustomers", typeof(EntityCollection<EventsEntity>));
				_gcNotGivenReasonCollectionViaEventCustomers = (EntityCollection<GcNotGivenReasonEntity>)info.GetValue("_gcNotGivenReasonCollectionViaEventCustomers", typeof(EntityCollection<GcNotGivenReasonEntity>));
				_hospitalFacilityCollectionViaEventCustomers = (EntityCollection<HospitalFacilityEntity>)info.GetValue("_hospitalFacilityCollectionViaEventCustomers", typeof(EntityCollection<HospitalFacilityEntity>));
				_lookupCollectionViaEventCustomers_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventCustomers_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEventCustomers = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventCustomers", typeof(EntityCollection<LookupEntity>));
				_organizationRoleUserCollectionViaEventCustomers_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventCustomers_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventCustomers = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventCustomers", typeof(EntityCollection<OrganizationRoleUserEntity>));
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
			switch((EventAppointmentFieldIndex)fieldIndex)
			{
				case EventAppointmentFieldIndex.ScheduledByOrgRoleUserId:
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
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "EventCustomers":
					this.EventCustomers.Add((EventCustomersEntity)entity);
					break;
				case "EventSlotAppointment":
					this.EventSlotAppointment.Add((EventSlotAppointmentEntity)entity);
					break;
				case "AfaffiliateCampaignCollectionViaEventCustomers":
					this.AfaffiliateCampaignCollectionViaEventCustomers.IsReadOnly = false;
					this.AfaffiliateCampaignCollectionViaEventCustomers.Add((AfaffiliateCampaignEntity)entity);
					this.AfaffiliateCampaignCollectionViaEventCustomers.IsReadOnly = true;
					break;
				case "CampaignCollectionViaEventCustomers":
					this.CampaignCollectionViaEventCustomers.IsReadOnly = false;
					this.CampaignCollectionViaEventCustomers.Add((CampaignEntity)entity);
					this.CampaignCollectionViaEventCustomers.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaEventCustomers":
					this.CustomerProfileCollectionViaEventCustomers.IsReadOnly = false;
					this.CustomerProfileCollectionViaEventCustomers.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaEventCustomers.IsReadOnly = true;
					break;
				case "CustomerProfileHistoryCollectionViaEventCustomers":
					this.CustomerProfileHistoryCollectionViaEventCustomers.IsReadOnly = false;
					this.CustomerProfileHistoryCollectionViaEventCustomers.Add((CustomerProfileHistoryEntity)entity);
					this.CustomerProfileHistoryCollectionViaEventCustomers.IsReadOnly = true;
					break;
				case "CustomerRegistrationNotesCollectionViaEventCustomers":
					this.CustomerRegistrationNotesCollectionViaEventCustomers.IsReadOnly = false;
					this.CustomerRegistrationNotesCollectionViaEventCustomers.Add((CustomerRegistrationNotesEntity)entity);
					this.CustomerRegistrationNotesCollectionViaEventCustomers.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventCustomers":
					this.EventsCollectionViaEventCustomers.IsReadOnly = false;
					this.EventsCollectionViaEventCustomers.Add((EventsEntity)entity);
					this.EventsCollectionViaEventCustomers.IsReadOnly = true;
					break;
				case "GcNotGivenReasonCollectionViaEventCustomers":
					this.GcNotGivenReasonCollectionViaEventCustomers.IsReadOnly = false;
					this.GcNotGivenReasonCollectionViaEventCustomers.Add((GcNotGivenReasonEntity)entity);
					this.GcNotGivenReasonCollectionViaEventCustomers.IsReadOnly = true;
					break;
				case "HospitalFacilityCollectionViaEventCustomers":
					this.HospitalFacilityCollectionViaEventCustomers.IsReadOnly = false;
					this.HospitalFacilityCollectionViaEventCustomers.Add((HospitalFacilityEntity)entity);
					this.HospitalFacilityCollectionViaEventCustomers.IsReadOnly = true;
					break;
				case "LookupCollectionViaEventCustomers_":
					this.LookupCollectionViaEventCustomers_.IsReadOnly = false;
					this.LookupCollectionViaEventCustomers_.Add((LookupEntity)entity);
					this.LookupCollectionViaEventCustomers_.IsReadOnly = true;
					break;
				case "LookupCollectionViaEventCustomers":
					this.LookupCollectionViaEventCustomers.IsReadOnly = false;
					this.LookupCollectionViaEventCustomers.Add((LookupEntity)entity);
					this.LookupCollectionViaEventCustomers.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventCustomers_":
					this.OrganizationRoleUserCollectionViaEventCustomers_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventCustomers_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventCustomers_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventCustomers":
					this.OrganizationRoleUserCollectionViaEventCustomers.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventCustomers.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventCustomers.IsReadOnly = true;
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
			return EventAppointmentEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "OrganizationRoleUser":
					toReturn.Add(EventAppointmentEntity.Relations.OrganizationRoleUserEntityUsingScheduledByOrgRoleUserId);
					break;
				case "EventCustomers":
					toReturn.Add(EventAppointmentEntity.Relations.EventCustomersEntityUsingAppointmentId);
					break;
				case "EventSlotAppointment":
					toReturn.Add(EventAppointmentEntity.Relations.EventSlotAppointmentEntityUsingAppointmentId);
					break;
				case "AfaffiliateCampaignCollectionViaEventCustomers":
					toReturn.Add(EventAppointmentEntity.Relations.EventCustomersEntityUsingAppointmentId, "EventAppointmentEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.AfaffiliateCampaignEntityUsingAffiliateCampaignId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "CampaignCollectionViaEventCustomers":
					toReturn.Add(EventAppointmentEntity.Relations.EventCustomersEntityUsingAppointmentId, "EventAppointmentEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.CampaignEntityUsingCampaignId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaEventCustomers":
					toReturn.Add(EventAppointmentEntity.Relations.EventCustomersEntityUsingAppointmentId, "EventAppointmentEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.CustomerProfileEntityUsingCustomerId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileHistoryCollectionViaEventCustomers":
					toReturn.Add(EventAppointmentEntity.Relations.EventCustomersEntityUsingAppointmentId, "EventAppointmentEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.CustomerProfileHistoryEntityUsingCustomerProfileHistoryId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "CustomerRegistrationNotesCollectionViaEventCustomers":
					toReturn.Add(EventAppointmentEntity.Relations.EventCustomersEntityUsingAppointmentId, "EventAppointmentEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.CustomerRegistrationNotesEntityUsingLeftWithoutScreeningNotesId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventCustomers":
					toReturn.Add(EventAppointmentEntity.Relations.EventCustomersEntityUsingAppointmentId, "EventAppointmentEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.EventsEntityUsingEventId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "GcNotGivenReasonCollectionViaEventCustomers":
					toReturn.Add(EventAppointmentEntity.Relations.EventCustomersEntityUsingAppointmentId, "EventAppointmentEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.GcNotGivenReasonEntityUsingGcNotGivenReasonId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "HospitalFacilityCollectionViaEventCustomers":
					toReturn.Add(EventAppointmentEntity.Relations.EventCustomersEntityUsingAppointmentId, "EventAppointmentEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.HospitalFacilityEntityUsingHospitalFacilityId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventCustomers_":
					toReturn.Add(EventAppointmentEntity.Relations.EventCustomersEntityUsingAppointmentId, "EventAppointmentEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.LookupEntityUsingPreferredContactType, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventCustomers":
					toReturn.Add(EventAppointmentEntity.Relations.EventCustomersEntityUsingAppointmentId, "EventAppointmentEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.LookupEntityUsingLeftWithoutScreeningReasonId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventCustomers_":
					toReturn.Add(EventAppointmentEntity.Relations.EventCustomersEntityUsingAppointmentId, "EventAppointmentEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.OrganizationRoleUserEntityUsingConfirmedBy, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventCustomers":
					toReturn.Add(EventAppointmentEntity.Relations.EventCustomersEntityUsingAppointmentId, "EventAppointmentEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "EventCustomers_", string.Empty, JoinHint.None);
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
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "EventCustomers":
					this.EventCustomers.Add((EventCustomersEntity)relatedEntity);
					break;
				case "EventSlotAppointment":
					this.EventSlotAppointment.Add((EventSlotAppointmentEntity)relatedEntity);
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
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "EventCustomers":
					base.PerformRelatedEntityRemoval(this.EventCustomers, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventSlotAppointment":
					base.PerformRelatedEntityRemoval(this.EventSlotAppointment, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.EventCustomers);
			toReturn.Add(this.EventSlotAppointment);

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
				info.AddValue("_eventCustomers", ((_eventCustomers!=null) && (_eventCustomers.Count>0) && !this.MarkedForDeletion)?_eventCustomers:null);
				info.AddValue("_eventSlotAppointment", ((_eventSlotAppointment!=null) && (_eventSlotAppointment.Count>0) && !this.MarkedForDeletion)?_eventSlotAppointment:null);
				info.AddValue("_afaffiliateCampaignCollectionViaEventCustomers", ((_afaffiliateCampaignCollectionViaEventCustomers!=null) && (_afaffiliateCampaignCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_afaffiliateCampaignCollectionViaEventCustomers:null);
				info.AddValue("_campaignCollectionViaEventCustomers", ((_campaignCollectionViaEventCustomers!=null) && (_campaignCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_campaignCollectionViaEventCustomers:null);
				info.AddValue("_customerProfileCollectionViaEventCustomers", ((_customerProfileCollectionViaEventCustomers!=null) && (_customerProfileCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaEventCustomers:null);
				info.AddValue("_customerProfileHistoryCollectionViaEventCustomers", ((_customerProfileHistoryCollectionViaEventCustomers!=null) && (_customerProfileHistoryCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_customerProfileHistoryCollectionViaEventCustomers:null);
				info.AddValue("_customerRegistrationNotesCollectionViaEventCustomers", ((_customerRegistrationNotesCollectionViaEventCustomers!=null) && (_customerRegistrationNotesCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_customerRegistrationNotesCollectionViaEventCustomers:null);
				info.AddValue("_eventsCollectionViaEventCustomers", ((_eventsCollectionViaEventCustomers!=null) && (_eventsCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventCustomers:null);
				info.AddValue("_gcNotGivenReasonCollectionViaEventCustomers", ((_gcNotGivenReasonCollectionViaEventCustomers!=null) && (_gcNotGivenReasonCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_gcNotGivenReasonCollectionViaEventCustomers:null);
				info.AddValue("_hospitalFacilityCollectionViaEventCustomers", ((_hospitalFacilityCollectionViaEventCustomers!=null) && (_hospitalFacilityCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_hospitalFacilityCollectionViaEventCustomers:null);
				info.AddValue("_lookupCollectionViaEventCustomers_", ((_lookupCollectionViaEventCustomers_!=null) && (_lookupCollectionViaEventCustomers_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventCustomers_:null);
				info.AddValue("_lookupCollectionViaEventCustomers", ((_lookupCollectionViaEventCustomers!=null) && (_lookupCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventCustomers:null);
				info.AddValue("_organizationRoleUserCollectionViaEventCustomers_", ((_organizationRoleUserCollectionViaEventCustomers_!=null) && (_organizationRoleUserCollectionViaEventCustomers_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventCustomers_:null);
				info.AddValue("_organizationRoleUserCollectionViaEventCustomers", ((_organizationRoleUserCollectionViaEventCustomers!=null) && (_organizationRoleUserCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventCustomers:null);
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
		public bool TestOriginalFieldValueForNull(EventAppointmentFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(EventAppointmentFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new EventAppointmentRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.AppointmentId, null, ComparisonOperator.Equal, this.AppointmentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventSlotAppointment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventSlotAppointment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventSlotAppointmentFields.AppointmentId, null, ComparisonOperator.Equal, this.AppointmentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AfaffiliateCampaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfaffiliateCampaignCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AfaffiliateCampaignCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventAppointmentFields.AppointmentId, null, ComparisonOperator.Equal, this.AppointmentId, "EventAppointmentEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Campaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CampaignCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventAppointmentFields.AppointmentId, null, ComparisonOperator.Equal, this.AppointmentId, "EventAppointmentEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventAppointmentFields.AppointmentId, null, ComparisonOperator.Equal, this.AppointmentId, "EventAppointmentEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfileHistory' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileHistoryCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileHistoryCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventAppointmentFields.AppointmentId, null, ComparisonOperator.Equal, this.AppointmentId, "EventAppointmentEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerRegistrationNotes' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerRegistrationNotesCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerRegistrationNotesCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventAppointmentFields.AppointmentId, null, ComparisonOperator.Equal, this.AppointmentId, "EventAppointmentEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventAppointmentFields.AppointmentId, null, ComparisonOperator.Equal, this.AppointmentId, "EventAppointmentEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GcNotGivenReason' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGcNotGivenReasonCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("GcNotGivenReasonCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventAppointmentFields.AppointmentId, null, ComparisonOperator.Equal, this.AppointmentId, "EventAppointmentEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HospitalFacility' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHospitalFacilityCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HospitalFacilityCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventAppointmentFields.AppointmentId, null, ComparisonOperator.Equal, this.AppointmentId, "EventAppointmentEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventCustomers_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventCustomers_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventAppointmentFields.AppointmentId, null, ComparisonOperator.Equal, this.AppointmentId, "EventAppointmentEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventAppointmentFields.AppointmentId, null, ComparisonOperator.Equal, this.AppointmentId, "EventAppointmentEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventCustomers_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventCustomers_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventAppointmentFields.AppointmentId, null, ComparisonOperator.Equal, this.AppointmentId, "EventAppointmentEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventAppointmentFields.AppointmentId, null, ComparisonOperator.Equal, this.AppointmentId, "EventAppointmentEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.ScheduledByOrgRoleUserId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.EventAppointmentEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._eventCustomers);
			collectionsQueue.Enqueue(this._eventSlotAppointment);
			collectionsQueue.Enqueue(this._afaffiliateCampaignCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._campaignCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._customerProfileHistoryCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._customerRegistrationNotesCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._gcNotGivenReasonCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._hospitalFacilityCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._lookupCollectionViaEventCustomers_);
			collectionsQueue.Enqueue(this._lookupCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventCustomers_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventCustomers);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._eventCustomers = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventSlotAppointment = (EntityCollection<EventSlotAppointmentEntity>) collectionsQueue.Dequeue();
			this._afaffiliateCampaignCollectionViaEventCustomers = (EntityCollection<AfaffiliateCampaignEntity>) collectionsQueue.Dequeue();
			this._campaignCollectionViaEventCustomers = (EntityCollection<CampaignEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaEventCustomers = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileHistoryCollectionViaEventCustomers = (EntityCollection<CustomerProfileHistoryEntity>) collectionsQueue.Dequeue();
			this._customerRegistrationNotesCollectionViaEventCustomers = (EntityCollection<CustomerRegistrationNotesEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventCustomers = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._gcNotGivenReasonCollectionViaEventCustomers = (EntityCollection<GcNotGivenReasonEntity>) collectionsQueue.Dequeue();
			this._hospitalFacilityCollectionViaEventCustomers = (EntityCollection<HospitalFacilityEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEventCustomers_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEventCustomers = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventCustomers_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventCustomers = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._eventCustomers != null)
			{
				return true;
			}
			if (this._eventSlotAppointment != null)
			{
				return true;
			}
			if (this._afaffiliateCampaignCollectionViaEventCustomers != null)
			{
				return true;
			}
			if (this._campaignCollectionViaEventCustomers != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaEventCustomers != null)
			{
				return true;
			}
			if (this._customerProfileHistoryCollectionViaEventCustomers != null)
			{
				return true;
			}
			if (this._customerRegistrationNotesCollectionViaEventCustomers != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventCustomers != null)
			{
				return true;
			}
			if (this._gcNotGivenReasonCollectionViaEventCustomers != null)
			{
				return true;
			}
			if (this._hospitalFacilityCollectionViaEventCustomers != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEventCustomers_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEventCustomers != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventCustomers_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventCustomers != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventSlotAppointmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventSlotAppointmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfaffiliateCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileHistoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileHistoryEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerRegistrationNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerRegistrationNotesEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GcNotGivenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GcNotGivenReasonEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HospitalFacilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalFacilityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
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
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("EventCustomers", _eventCustomers);
			toReturn.Add("EventSlotAppointment", _eventSlotAppointment);
			toReturn.Add("AfaffiliateCampaignCollectionViaEventCustomers", _afaffiliateCampaignCollectionViaEventCustomers);
			toReturn.Add("CampaignCollectionViaEventCustomers", _campaignCollectionViaEventCustomers);
			toReturn.Add("CustomerProfileCollectionViaEventCustomers", _customerProfileCollectionViaEventCustomers);
			toReturn.Add("CustomerProfileHistoryCollectionViaEventCustomers", _customerProfileHistoryCollectionViaEventCustomers);
			toReturn.Add("CustomerRegistrationNotesCollectionViaEventCustomers", _customerRegistrationNotesCollectionViaEventCustomers);
			toReturn.Add("EventsCollectionViaEventCustomers", _eventsCollectionViaEventCustomers);
			toReturn.Add("GcNotGivenReasonCollectionViaEventCustomers", _gcNotGivenReasonCollectionViaEventCustomers);
			toReturn.Add("HospitalFacilityCollectionViaEventCustomers", _hospitalFacilityCollectionViaEventCustomers);
			toReturn.Add("LookupCollectionViaEventCustomers_", _lookupCollectionViaEventCustomers_);
			toReturn.Add("LookupCollectionViaEventCustomers", _lookupCollectionViaEventCustomers);
			toReturn.Add("OrganizationRoleUserCollectionViaEventCustomers_", _organizationRoleUserCollectionViaEventCustomers_);
			toReturn.Add("OrganizationRoleUserCollectionViaEventCustomers", _organizationRoleUserCollectionViaEventCustomers);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_eventCustomers!=null)
			{
				_eventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_eventSlotAppointment!=null)
			{
				_eventSlotAppointment.ActiveContext = base.ActiveContext;
			}
			if(_afaffiliateCampaignCollectionViaEventCustomers!=null)
			{
				_afaffiliateCampaignCollectionViaEventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_campaignCollectionViaEventCustomers!=null)
			{
				_campaignCollectionViaEventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaEventCustomers!=null)
			{
				_customerProfileCollectionViaEventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileHistoryCollectionViaEventCustomers!=null)
			{
				_customerProfileHistoryCollectionViaEventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_customerRegistrationNotesCollectionViaEventCustomers!=null)
			{
				_customerRegistrationNotesCollectionViaEventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventCustomers!=null)
			{
				_eventsCollectionViaEventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_gcNotGivenReasonCollectionViaEventCustomers!=null)
			{
				_gcNotGivenReasonCollectionViaEventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_hospitalFacilityCollectionViaEventCustomers!=null)
			{
				_hospitalFacilityCollectionViaEventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEventCustomers_!=null)
			{
				_lookupCollectionViaEventCustomers_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEventCustomers!=null)
			{
				_lookupCollectionViaEventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventCustomers_!=null)
			{
				_organizationRoleUserCollectionViaEventCustomers_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventCustomers!=null)
			{
				_organizationRoleUserCollectionViaEventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_eventCustomers = null;
			_eventSlotAppointment = null;
			_afaffiliateCampaignCollectionViaEventCustomers = null;
			_campaignCollectionViaEventCustomers = null;
			_customerProfileCollectionViaEventCustomers = null;
			_customerProfileHistoryCollectionViaEventCustomers = null;
			_customerRegistrationNotesCollectionViaEventCustomers = null;
			_eventsCollectionViaEventCustomers = null;
			_gcNotGivenReasonCollectionViaEventCustomers = null;
			_hospitalFacilityCollectionViaEventCustomers = null;
			_lookupCollectionViaEventCustomers_ = null;
			_lookupCollectionViaEventCustomers = null;
			_organizationRoleUserCollectionViaEventCustomers_ = null;
			_organizationRoleUserCollectionViaEventCustomers = null;
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

			_fieldsCustomProperties.Add("AppointmentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("StartTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EndTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CheckinTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CheckoutTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ScheduledByOrgRoleUserId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organizationRoleUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", EventAppointmentEntity.Relations.OrganizationRoleUserEntityUsingScheduledByOrgRoleUserId, true, signalRelatedEntity, "EventAppointment", resetFKFields, new int[] { (int)EventAppointmentFieldIndex.ScheduledByOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", EventAppointmentEntity.Relations.OrganizationRoleUserEntityUsingScheduledByOrgRoleUserId, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this EventAppointmentEntity</param>
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
		public  static EventAppointmentRelations Relations
		{
			get	{ return new EventAppointmentRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomers
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomers")[0], (int)Falcon.Data.EntityType.EventAppointmentEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, null, null, "EventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventSlotAppointment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventSlotAppointment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventSlotAppointmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventSlotAppointmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventSlotAppointment")[0], (int)Falcon.Data.EntityType.EventAppointmentEntity, (int)Falcon.Data.EntityType.EventSlotAppointmentEntity, 0, null, null, null, null, "EventSlotAppointment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfaffiliateCampaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfaffiliateCampaignCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = EventAppointmentEntity.Relations.EventCustomersEntityUsingAppointmentId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<AfaffiliateCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventAppointmentEntity, (int)Falcon.Data.EntityType.AfaffiliateCampaignEntity, 0, null, null, GetRelationsForField("AfaffiliateCampaignCollectionViaEventCustomers"), null, "AfaffiliateCampaignCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Campaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = EventAppointmentEntity.Relations.EventCustomersEntityUsingAppointmentId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventAppointmentEntity, (int)Falcon.Data.EntityType.CampaignEntity, 0, null, null, GetRelationsForField("CampaignCollectionViaEventCustomers"), null, "CampaignCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = EventAppointmentEntity.Relations.EventCustomersEntityUsingAppointmentId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventAppointmentEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaEventCustomers"), null, "CustomerProfileCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfileHistory' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileHistoryCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = EventAppointmentEntity.Relations.EventCustomersEntityUsingAppointmentId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileHistoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileHistoryEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventAppointmentEntity, (int)Falcon.Data.EntityType.CustomerProfileHistoryEntity, 0, null, null, GetRelationsForField("CustomerProfileHistoryCollectionViaEventCustomers"), null, "CustomerProfileHistoryCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerRegistrationNotes' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerRegistrationNotesCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = EventAppointmentEntity.Relations.EventCustomersEntityUsingAppointmentId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<CustomerRegistrationNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerRegistrationNotesEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventAppointmentEntity, (int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, 0, null, null, GetRelationsForField("CustomerRegistrationNotesCollectionViaEventCustomers"), null, "CustomerRegistrationNotesCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = EventAppointmentEntity.Relations.EventCustomersEntityUsingAppointmentId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventAppointmentEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventCustomers"), null, "EventsCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GcNotGivenReason' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGcNotGivenReasonCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = EventAppointmentEntity.Relations.EventCustomersEntityUsingAppointmentId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<GcNotGivenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GcNotGivenReasonEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventAppointmentEntity, (int)Falcon.Data.EntityType.GcNotGivenReasonEntity, 0, null, null, GetRelationsForField("GcNotGivenReasonCollectionViaEventCustomers"), null, "GcNotGivenReasonCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HospitalFacility' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHospitalFacilityCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = EventAppointmentEntity.Relations.EventCustomersEntityUsingAppointmentId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<HospitalFacilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalFacilityEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventAppointmentEntity, (int)Falcon.Data.EntityType.HospitalFacilityEntity, 0, null, null, GetRelationsForField("HospitalFacilityCollectionViaEventCustomers"), null, "HospitalFacilityCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventCustomers_
		{
			get
			{
				IEntityRelation intermediateRelation = EventAppointmentEntity.Relations.EventCustomersEntityUsingAppointmentId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventAppointmentEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventCustomers_"), null, "LookupCollectionViaEventCustomers_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = EventAppointmentEntity.Relations.EventCustomersEntityUsingAppointmentId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventAppointmentEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventCustomers"), null, "LookupCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventCustomers_
		{
			get
			{
				IEntityRelation intermediateRelation = EventAppointmentEntity.Relations.EventCustomersEntityUsingAppointmentId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventAppointmentEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventCustomers_"), null, "OrganizationRoleUserCollectionViaEventCustomers_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = EventAppointmentEntity.Relations.EventCustomersEntityUsingAppointmentId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.EventAppointmentEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventCustomers"), null, "OrganizationRoleUserCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.EventAppointmentEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return EventAppointmentEntity.CustomProperties;}
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
			get { return EventAppointmentEntity.FieldsCustomProperties;}
		}

		/// <summary> The AppointmentId property of the Entity EventAppointment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventAppointment"."AppointmentID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 AppointmentId
		{
			get { return (System.Int64)GetValue((int)EventAppointmentFieldIndex.AppointmentId, true); }
			set	{ SetValue((int)EventAppointmentFieldIndex.AppointmentId, value); }
		}

		/// <summary> The EventId property of the Entity EventAppointment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventAppointment"."EventID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EventId
		{
			get { return (System.Int64)GetValue((int)EventAppointmentFieldIndex.EventId, true); }
			set	{ SetValue((int)EventAppointmentFieldIndex.EventId, value); }
		}

		/// <summary> The StartTime property of the Entity EventAppointment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventAppointment"."StartTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime StartTime
		{
			get { return (System.DateTime)GetValue((int)EventAppointmentFieldIndex.StartTime, true); }
			set	{ SetValue((int)EventAppointmentFieldIndex.StartTime, value); }
		}

		/// <summary> The EndTime property of the Entity EventAppointment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventAppointment"."EndTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime EndTime
		{
			get { return (System.DateTime)GetValue((int)EventAppointmentFieldIndex.EndTime, true); }
			set	{ SetValue((int)EventAppointmentFieldIndex.EndTime, value); }
		}

		/// <summary> The CheckinTime property of the Entity EventAppointment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventAppointment"."CheckinTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> CheckinTime
		{
			get { return (Nullable<System.DateTime>)GetValue((int)EventAppointmentFieldIndex.CheckinTime, false); }
			set	{ SetValue((int)EventAppointmentFieldIndex.CheckinTime, value); }
		}

		/// <summary> The CheckoutTime property of the Entity EventAppointment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventAppointment"."CheckoutTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> CheckoutTime
		{
			get { return (Nullable<System.DateTime>)GetValue((int)EventAppointmentFieldIndex.CheckoutTime, false); }
			set	{ SetValue((int)EventAppointmentFieldIndex.CheckoutTime, value); }
		}

		/// <summary> The DateCreated property of the Entity EventAppointment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventAppointment"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)EventAppointmentFieldIndex.DateCreated, true); }
			set	{ SetValue((int)EventAppointmentFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity EventAppointment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventAppointment"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)EventAppointmentFieldIndex.DateModified, false); }
			set	{ SetValue((int)EventAppointmentFieldIndex.DateModified, value); }
		}

		/// <summary> The ScheduledByOrgRoleUserId property of the Entity EventAppointment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblEventAppointment"."ScheduledByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ScheduledByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)EventAppointmentFieldIndex.ScheduledByOrgRoleUserId, false); }
			set	{ SetValue((int)EventAppointmentFieldIndex.ScheduledByOrgRoleUserId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomers
		{
			get
			{
				if(_eventCustomers==null)
				{
					_eventCustomers = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomers.SetContainingEntityInfo(this, "EventAppointment");
				}
				return _eventCustomers;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventSlotAppointmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventSlotAppointmentEntity))]
		public virtual EntityCollection<EventSlotAppointmentEntity> EventSlotAppointment
		{
			get
			{
				if(_eventSlotAppointment==null)
				{
					_eventSlotAppointment = new EntityCollection<EventSlotAppointmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventSlotAppointmentEntityFactory)));
					_eventSlotAppointment.SetContainingEntityInfo(this, "EventAppointment");
				}
				return _eventSlotAppointment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfaffiliateCampaignEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfaffiliateCampaignEntity))]
		public virtual EntityCollection<AfaffiliateCampaignEntity> AfaffiliateCampaignCollectionViaEventCustomers
		{
			get
			{
				if(_afaffiliateCampaignCollectionViaEventCustomers==null)
				{
					_afaffiliateCampaignCollectionViaEventCustomers = new EntityCollection<AfaffiliateCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignEntityFactory)));
					_afaffiliateCampaignCollectionViaEventCustomers.IsReadOnly=true;
				}
				return _afaffiliateCampaignCollectionViaEventCustomers;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CampaignEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CampaignEntity))]
		public virtual EntityCollection<CampaignEntity> CampaignCollectionViaEventCustomers
		{
			get
			{
				if(_campaignCollectionViaEventCustomers==null)
				{
					_campaignCollectionViaEventCustomers = new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory)));
					_campaignCollectionViaEventCustomers.IsReadOnly=true;
				}
				return _campaignCollectionViaEventCustomers;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaEventCustomers
		{
			get
			{
				if(_customerProfileCollectionViaEventCustomers==null)
				{
					_customerProfileCollectionViaEventCustomers = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaEventCustomers.IsReadOnly=true;
				}
				return _customerProfileCollectionViaEventCustomers;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileHistoryEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileHistoryEntity))]
		public virtual EntityCollection<CustomerProfileHistoryEntity> CustomerProfileHistoryCollectionViaEventCustomers
		{
			get
			{
				if(_customerProfileHistoryCollectionViaEventCustomers==null)
				{
					_customerProfileHistoryCollectionViaEventCustomers = new EntityCollection<CustomerProfileHistoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileHistoryEntityFactory)));
					_customerProfileHistoryCollectionViaEventCustomers.IsReadOnly=true;
				}
				return _customerProfileHistoryCollectionViaEventCustomers;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerRegistrationNotesEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerRegistrationNotesEntity))]
		public virtual EntityCollection<CustomerRegistrationNotesEntity> CustomerRegistrationNotesCollectionViaEventCustomers
		{
			get
			{
				if(_customerRegistrationNotesCollectionViaEventCustomers==null)
				{
					_customerRegistrationNotesCollectionViaEventCustomers = new EntityCollection<CustomerRegistrationNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerRegistrationNotesEntityFactory)));
					_customerRegistrationNotesCollectionViaEventCustomers.IsReadOnly=true;
				}
				return _customerRegistrationNotesCollectionViaEventCustomers;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventCustomers
		{
			get
			{
				if(_eventsCollectionViaEventCustomers==null)
				{
					_eventsCollectionViaEventCustomers = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventCustomers.IsReadOnly=true;
				}
				return _eventsCollectionViaEventCustomers;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GcNotGivenReasonEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GcNotGivenReasonEntity))]
		public virtual EntityCollection<GcNotGivenReasonEntity> GcNotGivenReasonCollectionViaEventCustomers
		{
			get
			{
				if(_gcNotGivenReasonCollectionViaEventCustomers==null)
				{
					_gcNotGivenReasonCollectionViaEventCustomers = new EntityCollection<GcNotGivenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GcNotGivenReasonEntityFactory)));
					_gcNotGivenReasonCollectionViaEventCustomers.IsReadOnly=true;
				}
				return _gcNotGivenReasonCollectionViaEventCustomers;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HospitalFacilityEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HospitalFacilityEntity))]
		public virtual EntityCollection<HospitalFacilityEntity> HospitalFacilityCollectionViaEventCustomers
		{
			get
			{
				if(_hospitalFacilityCollectionViaEventCustomers==null)
				{
					_hospitalFacilityCollectionViaEventCustomers = new EntityCollection<HospitalFacilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalFacilityEntityFactory)));
					_hospitalFacilityCollectionViaEventCustomers.IsReadOnly=true;
				}
				return _hospitalFacilityCollectionViaEventCustomers;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEventCustomers_
		{
			get
			{
				if(_lookupCollectionViaEventCustomers_==null)
				{
					_lookupCollectionViaEventCustomers_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEventCustomers_.IsReadOnly=true;
				}
				return _lookupCollectionViaEventCustomers_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEventCustomers
		{
			get
			{
				if(_lookupCollectionViaEventCustomers==null)
				{
					_lookupCollectionViaEventCustomers = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEventCustomers.IsReadOnly=true;
				}
				return _lookupCollectionViaEventCustomers;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventCustomers_
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventCustomers_==null)
				{
					_organizationRoleUserCollectionViaEventCustomers_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventCustomers_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventCustomers_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventCustomers
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventCustomers==null)
				{
					_organizationRoleUserCollectionViaEventCustomers = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventCustomers.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventCustomers;
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
							_organizationRoleUser.UnsetRelatedEntity(this, "EventAppointment");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "EventAppointment");
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
			get { return (int)Falcon.Data.EntityType.EventAppointmentEntity; }
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
