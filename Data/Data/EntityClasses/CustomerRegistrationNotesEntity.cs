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
	/// Entity class which represents the entity 'CustomerRegistrationNotes'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CustomerRegistrationNotesEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<EventAppointmentCancellationLogEntity> _eventAppointmentCancellationLog;
		private EntityCollection<EventCustomersEntity> _eventCustomers;
		private EntityCollection<AfaffiliateCampaignEntity> _afaffiliateCampaignCollectionViaEventCustomers;
		private EntityCollection<CampaignEntity> _campaignCollectionViaEventCustomers;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaEventCustomers;
		private EntityCollection<CustomerProfileHistoryEntity> _customerProfileHistoryCollectionViaEventCustomers;
		private EntityCollection<EventAppointmentEntity> _eventAppointmentCollectionViaEventCustomers;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaEventAppointmentCancellationLog;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventAppointmentCancellationLog;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventCustomers;
		private EntityCollection<GcNotGivenReasonEntity> _gcNotGivenReasonCollectionViaEventCustomers;
		private EntityCollection<HospitalFacilityEntity> _hospitalFacilityCollectionViaEventCustomers;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventAppointmentCancellationLog;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventCustomers;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventCustomers_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventCustomers;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventAppointmentCancellationLog;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventCustomers_;
		private EntityCollection<RefundRequestEntity> _refundRequestCollectionViaEventAppointmentCancellationLog;
		private EntityCollection<RescheduleCancelDispositionEntity> _rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog;
		private EventsEntity _events;
		private LookupEntity _lookup;
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
			/// <summary>Member name Events</summary>
			public static readonly string Events = "Events";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name EventAppointmentCancellationLog</summary>
			public static readonly string EventAppointmentCancellationLog = "EventAppointmentCancellationLog";
			/// <summary>Member name EventCustomers</summary>
			public static readonly string EventCustomers = "EventCustomers";
			/// <summary>Member name AfaffiliateCampaignCollectionViaEventCustomers</summary>
			public static readonly string AfaffiliateCampaignCollectionViaEventCustomers = "AfaffiliateCampaignCollectionViaEventCustomers";
			/// <summary>Member name CampaignCollectionViaEventCustomers</summary>
			public static readonly string CampaignCollectionViaEventCustomers = "CampaignCollectionViaEventCustomers";
			/// <summary>Member name CustomerProfileCollectionViaEventCustomers</summary>
			public static readonly string CustomerProfileCollectionViaEventCustomers = "CustomerProfileCollectionViaEventCustomers";
			/// <summary>Member name CustomerProfileHistoryCollectionViaEventCustomers</summary>
			public static readonly string CustomerProfileHistoryCollectionViaEventCustomers = "CustomerProfileHistoryCollectionViaEventCustomers";
			/// <summary>Member name EventAppointmentCollectionViaEventCustomers</summary>
			public static readonly string EventAppointmentCollectionViaEventCustomers = "EventAppointmentCollectionViaEventCustomers";
			/// <summary>Member name EventCustomersCollectionViaEventAppointmentCancellationLog</summary>
			public static readonly string EventCustomersCollectionViaEventAppointmentCancellationLog = "EventCustomersCollectionViaEventAppointmentCancellationLog";
			/// <summary>Member name EventsCollectionViaEventAppointmentCancellationLog</summary>
			public static readonly string EventsCollectionViaEventAppointmentCancellationLog = "EventsCollectionViaEventAppointmentCancellationLog";
			/// <summary>Member name EventsCollectionViaEventCustomers</summary>
			public static readonly string EventsCollectionViaEventCustomers = "EventsCollectionViaEventCustomers";
			/// <summary>Member name GcNotGivenReasonCollectionViaEventCustomers</summary>
			public static readonly string GcNotGivenReasonCollectionViaEventCustomers = "GcNotGivenReasonCollectionViaEventCustomers";
			/// <summary>Member name HospitalFacilityCollectionViaEventCustomers</summary>
			public static readonly string HospitalFacilityCollectionViaEventCustomers = "HospitalFacilityCollectionViaEventCustomers";
			/// <summary>Member name LookupCollectionViaEventAppointmentCancellationLog</summary>
			public static readonly string LookupCollectionViaEventAppointmentCancellationLog = "LookupCollectionViaEventAppointmentCancellationLog";
			/// <summary>Member name LookupCollectionViaEventCustomers</summary>
			public static readonly string LookupCollectionViaEventCustomers = "LookupCollectionViaEventCustomers";
			/// <summary>Member name LookupCollectionViaEventCustomers_</summary>
			public static readonly string LookupCollectionViaEventCustomers_ = "LookupCollectionViaEventCustomers_";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventCustomers</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventCustomers = "OrganizationRoleUserCollectionViaEventCustomers";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventAppointmentCancellationLog</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventAppointmentCancellationLog = "OrganizationRoleUserCollectionViaEventAppointmentCancellationLog";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventCustomers_</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventCustomers_ = "OrganizationRoleUserCollectionViaEventCustomers_";
			/// <summary>Member name RefundRequestCollectionViaEventAppointmentCancellationLog</summary>
			public static readonly string RefundRequestCollectionViaEventAppointmentCancellationLog = "RefundRequestCollectionViaEventAppointmentCancellationLog";
			/// <summary>Member name RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog</summary>
			public static readonly string RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog = "RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CustomerRegistrationNotesEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CustomerRegistrationNotesEntity():base("CustomerRegistrationNotesEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CustomerRegistrationNotesEntity(IEntityFields2 fields):base("CustomerRegistrationNotesEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CustomerRegistrationNotesEntity</param>
		public CustomerRegistrationNotesEntity(IValidator validator):base("CustomerRegistrationNotesEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="customerRegistrationNotesId">PK value for CustomerRegistrationNotes which data should be fetched into this CustomerRegistrationNotes object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CustomerRegistrationNotesEntity(System.Int64 customerRegistrationNotesId):base("CustomerRegistrationNotesEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CustomerRegistrationNotesId = customerRegistrationNotesId;
		}

		/// <summary> CTor</summary>
		/// <param name="customerRegistrationNotesId">PK value for CustomerRegistrationNotes which data should be fetched into this CustomerRegistrationNotes object</param>
		/// <param name="validator">The custom validator object for this CustomerRegistrationNotesEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CustomerRegistrationNotesEntity(System.Int64 customerRegistrationNotesId, IValidator validator):base("CustomerRegistrationNotesEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CustomerRegistrationNotesId = customerRegistrationNotesId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CustomerRegistrationNotesEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_eventAppointmentCancellationLog = (EntityCollection<EventAppointmentCancellationLogEntity>)info.GetValue("_eventAppointmentCancellationLog", typeof(EntityCollection<EventAppointmentCancellationLogEntity>));
				_eventCustomers = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomers", typeof(EntityCollection<EventCustomersEntity>));
				_afaffiliateCampaignCollectionViaEventCustomers = (EntityCollection<AfaffiliateCampaignEntity>)info.GetValue("_afaffiliateCampaignCollectionViaEventCustomers", typeof(EntityCollection<AfaffiliateCampaignEntity>));
				_campaignCollectionViaEventCustomers = (EntityCollection<CampaignEntity>)info.GetValue("_campaignCollectionViaEventCustomers", typeof(EntityCollection<CampaignEntity>));
				_customerProfileCollectionViaEventCustomers = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaEventCustomers", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileHistoryCollectionViaEventCustomers = (EntityCollection<CustomerProfileHistoryEntity>)info.GetValue("_customerProfileHistoryCollectionViaEventCustomers", typeof(EntityCollection<CustomerProfileHistoryEntity>));
				_eventAppointmentCollectionViaEventCustomers = (EntityCollection<EventAppointmentEntity>)info.GetValue("_eventAppointmentCollectionViaEventCustomers", typeof(EntityCollection<EventAppointmentEntity>));
				_eventCustomersCollectionViaEventAppointmentCancellationLog = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaEventAppointmentCancellationLog", typeof(EntityCollection<EventCustomersEntity>));
				_eventsCollectionViaEventAppointmentCancellationLog = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventAppointmentCancellationLog", typeof(EntityCollection<EventsEntity>));
				_eventsCollectionViaEventCustomers = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventCustomers", typeof(EntityCollection<EventsEntity>));
				_gcNotGivenReasonCollectionViaEventCustomers = (EntityCollection<GcNotGivenReasonEntity>)info.GetValue("_gcNotGivenReasonCollectionViaEventCustomers", typeof(EntityCollection<GcNotGivenReasonEntity>));
				_hospitalFacilityCollectionViaEventCustomers = (EntityCollection<HospitalFacilityEntity>)info.GetValue("_hospitalFacilityCollectionViaEventCustomers", typeof(EntityCollection<HospitalFacilityEntity>));
				_lookupCollectionViaEventAppointmentCancellationLog = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventAppointmentCancellationLog", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEventCustomers = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventCustomers", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEventCustomers_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventCustomers_", typeof(EntityCollection<LookupEntity>));
				_organizationRoleUserCollectionViaEventCustomers = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventCustomers", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventAppointmentCancellationLog = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventAppointmentCancellationLog", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventCustomers_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventCustomers_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_refundRequestCollectionViaEventAppointmentCancellationLog = (EntityCollection<RefundRequestEntity>)info.GetValue("_refundRequestCollectionViaEventAppointmentCancellationLog", typeof(EntityCollection<RefundRequestEntity>));
				_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog = (EntityCollection<RescheduleCancelDispositionEntity>)info.GetValue("_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog", typeof(EntityCollection<RescheduleCancelDispositionEntity>));
				_events = (EventsEntity)info.GetValue("_events", typeof(EventsEntity));
				if(_events!=null)
				{
					_events.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((CustomerRegistrationNotesFieldIndex)fieldIndex)
			{
				case CustomerRegistrationNotesFieldIndex.CreatedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case CustomerRegistrationNotesFieldIndex.EventId:
					DesetupSyncEvents(true, false);
					break;
				case CustomerRegistrationNotesFieldIndex.ReasonId:
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
				case "Events":
					this.Events = (EventsEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "EventAppointmentCancellationLog":
					this.EventAppointmentCancellationLog.Add((EventAppointmentCancellationLogEntity)entity);
					break;
				case "EventCustomers":
					this.EventCustomers.Add((EventCustomersEntity)entity);
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
				case "EventAppointmentCollectionViaEventCustomers":
					this.EventAppointmentCollectionViaEventCustomers.IsReadOnly = false;
					this.EventAppointmentCollectionViaEventCustomers.Add((EventAppointmentEntity)entity);
					this.EventAppointmentCollectionViaEventCustomers.IsReadOnly = true;
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
				case "LookupCollectionViaEventAppointmentCancellationLog":
					this.LookupCollectionViaEventAppointmentCancellationLog.IsReadOnly = false;
					this.LookupCollectionViaEventAppointmentCancellationLog.Add((LookupEntity)entity);
					this.LookupCollectionViaEventAppointmentCancellationLog.IsReadOnly = true;
					break;
				case "LookupCollectionViaEventCustomers":
					this.LookupCollectionViaEventCustomers.IsReadOnly = false;
					this.LookupCollectionViaEventCustomers.Add((LookupEntity)entity);
					this.LookupCollectionViaEventCustomers.IsReadOnly = true;
					break;
				case "LookupCollectionViaEventCustomers_":
					this.LookupCollectionViaEventCustomers_.IsReadOnly = false;
					this.LookupCollectionViaEventCustomers_.Add((LookupEntity)entity);
					this.LookupCollectionViaEventCustomers_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventCustomers":
					this.OrganizationRoleUserCollectionViaEventCustomers.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventCustomers.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventCustomers.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventAppointmentCancellationLog":
					this.OrganizationRoleUserCollectionViaEventAppointmentCancellationLog.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventAppointmentCancellationLog.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventAppointmentCancellationLog.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventCustomers_":
					this.OrganizationRoleUserCollectionViaEventCustomers_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventCustomers_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventCustomers_.IsReadOnly = true;
					break;
				case "RefundRequestCollectionViaEventAppointmentCancellationLog":
					this.RefundRequestCollectionViaEventAppointmentCancellationLog.IsReadOnly = false;
					this.RefundRequestCollectionViaEventAppointmentCancellationLog.Add((RefundRequestEntity)entity);
					this.RefundRequestCollectionViaEventAppointmentCancellationLog.IsReadOnly = true;
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
			return CustomerRegistrationNotesEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Events":
					toReturn.Add(CustomerRegistrationNotesEntity.Relations.EventsEntityUsingEventId);
					break;
				case "Lookup":
					toReturn.Add(CustomerRegistrationNotesEntity.Relations.LookupEntityUsingReasonId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(CustomerRegistrationNotesEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
					break;
				case "EventAppointmentCancellationLog":
					toReturn.Add(CustomerRegistrationNotesEntity.Relations.EventAppointmentCancellationLogEntityUsingNoteId);
					break;
				case "EventCustomers":
					toReturn.Add(CustomerRegistrationNotesEntity.Relations.EventCustomersEntityUsingLeftWithoutScreeningNotesId);
					break;
				case "AfaffiliateCampaignCollectionViaEventCustomers":
					toReturn.Add(CustomerRegistrationNotesEntity.Relations.EventCustomersEntityUsingLeftWithoutScreeningNotesId, "CustomerRegistrationNotesEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.AfaffiliateCampaignEntityUsingAffiliateCampaignId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "CampaignCollectionViaEventCustomers":
					toReturn.Add(CustomerRegistrationNotesEntity.Relations.EventCustomersEntityUsingLeftWithoutScreeningNotesId, "CustomerRegistrationNotesEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.CampaignEntityUsingCampaignId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaEventCustomers":
					toReturn.Add(CustomerRegistrationNotesEntity.Relations.EventCustomersEntityUsingLeftWithoutScreeningNotesId, "CustomerRegistrationNotesEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.CustomerProfileEntityUsingCustomerId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileHistoryCollectionViaEventCustomers":
					toReturn.Add(CustomerRegistrationNotesEntity.Relations.EventCustomersEntityUsingLeftWithoutScreeningNotesId, "CustomerRegistrationNotesEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.CustomerProfileHistoryEntityUsingCustomerProfileHistoryId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "EventAppointmentCollectionViaEventCustomers":
					toReturn.Add(CustomerRegistrationNotesEntity.Relations.EventCustomersEntityUsingLeftWithoutScreeningNotesId, "CustomerRegistrationNotesEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.EventAppointmentEntityUsingAppointmentId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaEventAppointmentCancellationLog":
					toReturn.Add(CustomerRegistrationNotesEntity.Relations.EventAppointmentCancellationLogEntityUsingNoteId, "CustomerRegistrationNotesEntity__", "EventAppointmentCancellationLog_", JoinHint.None);
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.EventCustomersEntityUsingEventCustomerId, "EventAppointmentCancellationLog_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventAppointmentCancellationLog":
					toReturn.Add(CustomerRegistrationNotesEntity.Relations.EventAppointmentCancellationLogEntityUsingNoteId, "CustomerRegistrationNotesEntity__", "EventAppointmentCancellationLog_", JoinHint.None);
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.EventsEntityUsingEventId, "EventAppointmentCancellationLog_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventCustomers":
					toReturn.Add(CustomerRegistrationNotesEntity.Relations.EventCustomersEntityUsingLeftWithoutScreeningNotesId, "CustomerRegistrationNotesEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.EventsEntityUsingEventId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "GcNotGivenReasonCollectionViaEventCustomers":
					toReturn.Add(CustomerRegistrationNotesEntity.Relations.EventCustomersEntityUsingLeftWithoutScreeningNotesId, "CustomerRegistrationNotesEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.GcNotGivenReasonEntityUsingGcNotGivenReasonId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "HospitalFacilityCollectionViaEventCustomers":
					toReturn.Add(CustomerRegistrationNotesEntity.Relations.EventCustomersEntityUsingLeftWithoutScreeningNotesId, "CustomerRegistrationNotesEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.HospitalFacilityEntityUsingHospitalFacilityId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventAppointmentCancellationLog":
					toReturn.Add(CustomerRegistrationNotesEntity.Relations.EventAppointmentCancellationLogEntityUsingNoteId, "CustomerRegistrationNotesEntity__", "EventAppointmentCancellationLog_", JoinHint.None);
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.LookupEntityUsingReasonId, "EventAppointmentCancellationLog_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventCustomers":
					toReturn.Add(CustomerRegistrationNotesEntity.Relations.EventCustomersEntityUsingLeftWithoutScreeningNotesId, "CustomerRegistrationNotesEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.LookupEntityUsingLeftWithoutScreeningReasonId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventCustomers_":
					toReturn.Add(CustomerRegistrationNotesEntity.Relations.EventCustomersEntityUsingLeftWithoutScreeningNotesId, "CustomerRegistrationNotesEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.LookupEntityUsingPreferredContactType, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventCustomers":
					toReturn.Add(CustomerRegistrationNotesEntity.Relations.EventCustomersEntityUsingLeftWithoutScreeningNotesId, "CustomerRegistrationNotesEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventAppointmentCancellationLog":
					toReturn.Add(CustomerRegistrationNotesEntity.Relations.EventAppointmentCancellationLogEntityUsingNoteId, "CustomerRegistrationNotesEntity__", "EventAppointmentCancellationLog_", JoinHint.None);
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "EventAppointmentCancellationLog_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventCustomers_":
					toReturn.Add(CustomerRegistrationNotesEntity.Relations.EventCustomersEntityUsingLeftWithoutScreeningNotesId, "CustomerRegistrationNotesEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.OrganizationRoleUserEntityUsingConfirmedBy, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "RefundRequestCollectionViaEventAppointmentCancellationLog":
					toReturn.Add(CustomerRegistrationNotesEntity.Relations.EventAppointmentCancellationLogEntityUsingNoteId, "CustomerRegistrationNotesEntity__", "EventAppointmentCancellationLog_", JoinHint.None);
					toReturn.Add(EventAppointmentCancellationLogEntity.Relations.RefundRequestEntityUsingRefundRequestId, "EventAppointmentCancellationLog_", string.Empty, JoinHint.None);
					break;
				case "RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog":
					toReturn.Add(CustomerRegistrationNotesEntity.Relations.EventAppointmentCancellationLogEntityUsingNoteId, "CustomerRegistrationNotesEntity__", "EventAppointmentCancellationLog_", JoinHint.None);
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
				case "Events":
					SetupSyncEvents(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "EventAppointmentCancellationLog":
					this.EventAppointmentCancellationLog.Add((EventAppointmentCancellationLogEntity)relatedEntity);
					break;
				case "EventCustomers":
					this.EventCustomers.Add((EventCustomersEntity)relatedEntity);
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
				case "Events":
					DesetupSyncEvents(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "EventAppointmentCancellationLog":
					base.PerformRelatedEntityRemoval(this.EventAppointmentCancellationLog, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomers":
					base.PerformRelatedEntityRemoval(this.EventCustomers, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_events!=null)
			{
				toReturn.Add(_events);
			}
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
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
			toReturn.Add(this.EventCustomers);

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
				info.AddValue("_eventCustomers", ((_eventCustomers!=null) && (_eventCustomers.Count>0) && !this.MarkedForDeletion)?_eventCustomers:null);
				info.AddValue("_afaffiliateCampaignCollectionViaEventCustomers", ((_afaffiliateCampaignCollectionViaEventCustomers!=null) && (_afaffiliateCampaignCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_afaffiliateCampaignCollectionViaEventCustomers:null);
				info.AddValue("_campaignCollectionViaEventCustomers", ((_campaignCollectionViaEventCustomers!=null) && (_campaignCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_campaignCollectionViaEventCustomers:null);
				info.AddValue("_customerProfileCollectionViaEventCustomers", ((_customerProfileCollectionViaEventCustomers!=null) && (_customerProfileCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaEventCustomers:null);
				info.AddValue("_customerProfileHistoryCollectionViaEventCustomers", ((_customerProfileHistoryCollectionViaEventCustomers!=null) && (_customerProfileHistoryCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_customerProfileHistoryCollectionViaEventCustomers:null);
				info.AddValue("_eventAppointmentCollectionViaEventCustomers", ((_eventAppointmentCollectionViaEventCustomers!=null) && (_eventAppointmentCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_eventAppointmentCollectionViaEventCustomers:null);
				info.AddValue("_eventCustomersCollectionViaEventAppointmentCancellationLog", ((_eventCustomersCollectionViaEventAppointmentCancellationLog!=null) && (_eventCustomersCollectionViaEventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaEventAppointmentCancellationLog:null);
				info.AddValue("_eventsCollectionViaEventAppointmentCancellationLog", ((_eventsCollectionViaEventAppointmentCancellationLog!=null) && (_eventsCollectionViaEventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventAppointmentCancellationLog:null);
				info.AddValue("_eventsCollectionViaEventCustomers", ((_eventsCollectionViaEventCustomers!=null) && (_eventsCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventCustomers:null);
				info.AddValue("_gcNotGivenReasonCollectionViaEventCustomers", ((_gcNotGivenReasonCollectionViaEventCustomers!=null) && (_gcNotGivenReasonCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_gcNotGivenReasonCollectionViaEventCustomers:null);
				info.AddValue("_hospitalFacilityCollectionViaEventCustomers", ((_hospitalFacilityCollectionViaEventCustomers!=null) && (_hospitalFacilityCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_hospitalFacilityCollectionViaEventCustomers:null);
				info.AddValue("_lookupCollectionViaEventAppointmentCancellationLog", ((_lookupCollectionViaEventAppointmentCancellationLog!=null) && (_lookupCollectionViaEventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventAppointmentCancellationLog:null);
				info.AddValue("_lookupCollectionViaEventCustomers", ((_lookupCollectionViaEventCustomers!=null) && (_lookupCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventCustomers:null);
				info.AddValue("_lookupCollectionViaEventCustomers_", ((_lookupCollectionViaEventCustomers_!=null) && (_lookupCollectionViaEventCustomers_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventCustomers_:null);
				info.AddValue("_organizationRoleUserCollectionViaEventCustomers", ((_organizationRoleUserCollectionViaEventCustomers!=null) && (_organizationRoleUserCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventCustomers:null);
				info.AddValue("_organizationRoleUserCollectionViaEventAppointmentCancellationLog", ((_organizationRoleUserCollectionViaEventAppointmentCancellationLog!=null) && (_organizationRoleUserCollectionViaEventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventAppointmentCancellationLog:null);
				info.AddValue("_organizationRoleUserCollectionViaEventCustomers_", ((_organizationRoleUserCollectionViaEventCustomers_!=null) && (_organizationRoleUserCollectionViaEventCustomers_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventCustomers_:null);
				info.AddValue("_refundRequestCollectionViaEventAppointmentCancellationLog", ((_refundRequestCollectionViaEventAppointmentCancellationLog!=null) && (_refundRequestCollectionViaEventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_refundRequestCollectionViaEventAppointmentCancellationLog:null);
				info.AddValue("_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog", ((_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog!=null) && (_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog.Count>0) && !this.MarkedForDeletion)?_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog:null);
				info.AddValue("_events", (!this.MarkedForDeletion?_events:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
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
		public bool TestOriginalFieldValueForNull(CustomerRegistrationNotesFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CustomerRegistrationNotesFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CustomerRegistrationNotesRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventAppointmentCancellationLog' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventAppointmentCancellationLogFields.NoteId, null, ComparisonOperator.Equal, this.CustomerRegistrationNotesId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.LeftWithoutScreeningNotesId, null, ComparisonOperator.Equal, this.CustomerRegistrationNotesId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AfaffiliateCampaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfaffiliateCampaignCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AfaffiliateCampaignCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerRegistrationNotesFields.CustomerRegistrationNotesId, null, ComparisonOperator.Equal, this.CustomerRegistrationNotesId, "CustomerRegistrationNotesEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Campaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CampaignCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerRegistrationNotesFields.CustomerRegistrationNotesId, null, ComparisonOperator.Equal, this.CustomerRegistrationNotesId, "CustomerRegistrationNotesEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerRegistrationNotesFields.CustomerRegistrationNotesId, null, ComparisonOperator.Equal, this.CustomerRegistrationNotesId, "CustomerRegistrationNotesEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfileHistory' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileHistoryCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileHistoryCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerRegistrationNotesFields.CustomerRegistrationNotesId, null, ComparisonOperator.Equal, this.CustomerRegistrationNotesId, "CustomerRegistrationNotesEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventAppointment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventAppointmentCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventAppointmentCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerRegistrationNotesFields.CustomerRegistrationNotesId, null, ComparisonOperator.Equal, this.CustomerRegistrationNotesId, "CustomerRegistrationNotesEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaEventAppointmentCancellationLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerRegistrationNotesFields.CustomerRegistrationNotesId, null, ComparisonOperator.Equal, this.CustomerRegistrationNotesId, "CustomerRegistrationNotesEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventAppointmentCancellationLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerRegistrationNotesFields.CustomerRegistrationNotesId, null, ComparisonOperator.Equal, this.CustomerRegistrationNotesId, "CustomerRegistrationNotesEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerRegistrationNotesFields.CustomerRegistrationNotesId, null, ComparisonOperator.Equal, this.CustomerRegistrationNotesId, "CustomerRegistrationNotesEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GcNotGivenReason' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGcNotGivenReasonCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("GcNotGivenReasonCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerRegistrationNotesFields.CustomerRegistrationNotesId, null, ComparisonOperator.Equal, this.CustomerRegistrationNotesId, "CustomerRegistrationNotesEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HospitalFacility' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHospitalFacilityCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HospitalFacilityCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerRegistrationNotesFields.CustomerRegistrationNotesId, null, ComparisonOperator.Equal, this.CustomerRegistrationNotesId, "CustomerRegistrationNotesEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventAppointmentCancellationLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerRegistrationNotesFields.CustomerRegistrationNotesId, null, ComparisonOperator.Equal, this.CustomerRegistrationNotesId, "CustomerRegistrationNotesEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerRegistrationNotesFields.CustomerRegistrationNotesId, null, ComparisonOperator.Equal, this.CustomerRegistrationNotesId, "CustomerRegistrationNotesEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventCustomers_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventCustomers_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerRegistrationNotesFields.CustomerRegistrationNotesId, null, ComparisonOperator.Equal, this.CustomerRegistrationNotesId, "CustomerRegistrationNotesEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerRegistrationNotesFields.CustomerRegistrationNotesId, null, ComparisonOperator.Equal, this.CustomerRegistrationNotesId, "CustomerRegistrationNotesEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventAppointmentCancellationLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerRegistrationNotesFields.CustomerRegistrationNotesId, null, ComparisonOperator.Equal, this.CustomerRegistrationNotesId, "CustomerRegistrationNotesEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventCustomers_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventCustomers_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerRegistrationNotesFields.CustomerRegistrationNotesId, null, ComparisonOperator.Equal, this.CustomerRegistrationNotesId, "CustomerRegistrationNotesEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'RefundRequest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRefundRequestCollectionViaEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("RefundRequestCollectionViaEventAppointmentCancellationLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerRegistrationNotesFields.CustomerRegistrationNotesId, null, ComparisonOperator.Equal, this.CustomerRegistrationNotesId, "CustomerRegistrationNotesEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'RescheduleCancelDisposition' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerRegistrationNotesFields.CustomerRegistrationNotesId, null, ComparisonOperator.Equal, this.CustomerRegistrationNotesId, "CustomerRegistrationNotesEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Events' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventsFields.EventId, null, ComparisonOperator.Equal, this.EventId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.ReasonId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.CreatedByOrgRoleUserId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CustomerRegistrationNotesEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CustomerRegistrationNotesEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._eventAppointmentCancellationLog);
			collectionsQueue.Enqueue(this._eventCustomers);
			collectionsQueue.Enqueue(this._afaffiliateCampaignCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._campaignCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._customerProfileHistoryCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._eventAppointmentCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaEventAppointmentCancellationLog);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventAppointmentCancellationLog);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._gcNotGivenReasonCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._hospitalFacilityCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._lookupCollectionViaEventAppointmentCancellationLog);
			collectionsQueue.Enqueue(this._lookupCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._lookupCollectionViaEventCustomers_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventAppointmentCancellationLog);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventCustomers_);
			collectionsQueue.Enqueue(this._refundRequestCollectionViaEventAppointmentCancellationLog);
			collectionsQueue.Enqueue(this._rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._eventAppointmentCancellationLog = (EntityCollection<EventAppointmentCancellationLogEntity>) collectionsQueue.Dequeue();
			this._eventCustomers = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._afaffiliateCampaignCollectionViaEventCustomers = (EntityCollection<AfaffiliateCampaignEntity>) collectionsQueue.Dequeue();
			this._campaignCollectionViaEventCustomers = (EntityCollection<CampaignEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaEventCustomers = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileHistoryCollectionViaEventCustomers = (EntityCollection<CustomerProfileHistoryEntity>) collectionsQueue.Dequeue();
			this._eventAppointmentCollectionViaEventCustomers = (EntityCollection<EventAppointmentEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaEventAppointmentCancellationLog = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventAppointmentCancellationLog = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventCustomers = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._gcNotGivenReasonCollectionViaEventCustomers = (EntityCollection<GcNotGivenReasonEntity>) collectionsQueue.Dequeue();
			this._hospitalFacilityCollectionViaEventCustomers = (EntityCollection<HospitalFacilityEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEventAppointmentCancellationLog = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEventCustomers = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEventCustomers_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventCustomers = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventAppointmentCancellationLog = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventCustomers_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._refundRequestCollectionViaEventAppointmentCancellationLog = (EntityCollection<RefundRequestEntity>) collectionsQueue.Dequeue();
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
			if (this._eventCustomers != null)
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
			if (this._eventAppointmentCollectionViaEventCustomers != null)
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
			if (this._lookupCollectionViaEventAppointmentCancellationLog != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEventCustomers != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEventCustomers_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventCustomers != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventAppointmentCancellationLog != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventCustomers_ != null)
			{
				return true;
			}
			if (this._refundRequestCollectionViaEventAppointmentCancellationLog != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfaffiliateCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileHistoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileHistoryEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventAppointmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GcNotGivenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GcNotGivenReasonEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HospitalFacilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalFacilityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RefundRequestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundRequestEntityFactory))) : null);
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
			toReturn.Add("Events", _events);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("EventAppointmentCancellationLog", _eventAppointmentCancellationLog);
			toReturn.Add("EventCustomers", _eventCustomers);
			toReturn.Add("AfaffiliateCampaignCollectionViaEventCustomers", _afaffiliateCampaignCollectionViaEventCustomers);
			toReturn.Add("CampaignCollectionViaEventCustomers", _campaignCollectionViaEventCustomers);
			toReturn.Add("CustomerProfileCollectionViaEventCustomers", _customerProfileCollectionViaEventCustomers);
			toReturn.Add("CustomerProfileHistoryCollectionViaEventCustomers", _customerProfileHistoryCollectionViaEventCustomers);
			toReturn.Add("EventAppointmentCollectionViaEventCustomers", _eventAppointmentCollectionViaEventCustomers);
			toReturn.Add("EventCustomersCollectionViaEventAppointmentCancellationLog", _eventCustomersCollectionViaEventAppointmentCancellationLog);
			toReturn.Add("EventsCollectionViaEventAppointmentCancellationLog", _eventsCollectionViaEventAppointmentCancellationLog);
			toReturn.Add("EventsCollectionViaEventCustomers", _eventsCollectionViaEventCustomers);
			toReturn.Add("GcNotGivenReasonCollectionViaEventCustomers", _gcNotGivenReasonCollectionViaEventCustomers);
			toReturn.Add("HospitalFacilityCollectionViaEventCustomers", _hospitalFacilityCollectionViaEventCustomers);
			toReturn.Add("LookupCollectionViaEventAppointmentCancellationLog", _lookupCollectionViaEventAppointmentCancellationLog);
			toReturn.Add("LookupCollectionViaEventCustomers", _lookupCollectionViaEventCustomers);
			toReturn.Add("LookupCollectionViaEventCustomers_", _lookupCollectionViaEventCustomers_);
			toReturn.Add("OrganizationRoleUserCollectionViaEventCustomers", _organizationRoleUserCollectionViaEventCustomers);
			toReturn.Add("OrganizationRoleUserCollectionViaEventAppointmentCancellationLog", _organizationRoleUserCollectionViaEventAppointmentCancellationLog);
			toReturn.Add("OrganizationRoleUserCollectionViaEventCustomers_", _organizationRoleUserCollectionViaEventCustomers_);
			toReturn.Add("RefundRequestCollectionViaEventAppointmentCancellationLog", _refundRequestCollectionViaEventAppointmentCancellationLog);
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
			if(_eventCustomers!=null)
			{
				_eventCustomers.ActiveContext = base.ActiveContext;
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
			if(_eventAppointmentCollectionViaEventCustomers!=null)
			{
				_eventAppointmentCollectionViaEventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaEventAppointmentCancellationLog!=null)
			{
				_eventCustomersCollectionViaEventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventAppointmentCancellationLog!=null)
			{
				_eventsCollectionViaEventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
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
			if(_lookupCollectionViaEventAppointmentCancellationLog!=null)
			{
				_lookupCollectionViaEventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEventCustomers!=null)
			{
				_lookupCollectionViaEventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEventCustomers_!=null)
			{
				_lookupCollectionViaEventCustomers_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventCustomers!=null)
			{
				_organizationRoleUserCollectionViaEventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventAppointmentCancellationLog!=null)
			{
				_organizationRoleUserCollectionViaEventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventCustomers_!=null)
			{
				_organizationRoleUserCollectionViaEventCustomers_.ActiveContext = base.ActiveContext;
			}
			if(_refundRequestCollectionViaEventAppointmentCancellationLog!=null)
			{
				_refundRequestCollectionViaEventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog!=null)
			{
				_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog.ActiveContext = base.ActiveContext;
			}
			if(_events!=null)
			{
				_events.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
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
			_eventCustomers = null;
			_afaffiliateCampaignCollectionViaEventCustomers = null;
			_campaignCollectionViaEventCustomers = null;
			_customerProfileCollectionViaEventCustomers = null;
			_customerProfileHistoryCollectionViaEventCustomers = null;
			_eventAppointmentCollectionViaEventCustomers = null;
			_eventCustomersCollectionViaEventAppointmentCancellationLog = null;
			_eventsCollectionViaEventAppointmentCancellationLog = null;
			_eventsCollectionViaEventCustomers = null;
			_gcNotGivenReasonCollectionViaEventCustomers = null;
			_hospitalFacilityCollectionViaEventCustomers = null;
			_lookupCollectionViaEventAppointmentCancellationLog = null;
			_lookupCollectionViaEventCustomers = null;
			_lookupCollectionViaEventCustomers_ = null;
			_organizationRoleUserCollectionViaEventCustomers = null;
			_organizationRoleUserCollectionViaEventAppointmentCancellationLog = null;
			_organizationRoleUserCollectionViaEventCustomers_ = null;
			_refundRequestCollectionViaEventAppointmentCancellationLog = null;
			_rescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog = null;
			_events = null;
			_lookup = null;
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

			_fieldsCustomProperties.Add("CustomerRegistrationNotesId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Notes", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NoteType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ReasonId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _events</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEvents(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", CustomerRegistrationNotesEntity.Relations.EventsEntityUsingEventId, true, signalRelatedEntity, "CustomerRegistrationNotes", resetFKFields, new int[] { (int)CustomerRegistrationNotesFieldIndex.EventId } );		
			_events = null;
		}

		/// <summary> setups the sync logic for member _events</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEvents(IEntity2 relatedEntity)
		{
			if(_events!=relatedEntity)
			{
				DesetupSyncEvents(true, true);
				_events = (EventsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", CustomerRegistrationNotesEntity.Relations.EventsEntityUsingEventId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEventsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _lookup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CustomerRegistrationNotesEntity.Relations.LookupEntityUsingReasonId, true, signalRelatedEntity, "CustomerRegistrationNotes", resetFKFields, new int[] { (int)CustomerRegistrationNotesFieldIndex.ReasonId } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CustomerRegistrationNotesEntity.Relations.LookupEntityUsingReasonId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _organizationRoleUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CustomerRegistrationNotesEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, signalRelatedEntity, "CustomerRegistrationNotes", resetFKFields, new int[] { (int)CustomerRegistrationNotesFieldIndex.CreatedByOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CustomerRegistrationNotesEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this CustomerRegistrationNotesEntity</param>
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
		public  static CustomerRegistrationNotesRelations Relations
		{
			get	{ return new CustomerRegistrationNotesRelations(); }
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
					(IEntityRelation)GetRelationsForField("EventAppointmentCancellationLog")[0], (int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, (int)Falcon.Data.EntityType.EventAppointmentCancellationLogEntity, 0, null, null, null, null, "EventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomers
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomers")[0], (int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, null, null, "EventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfaffiliateCampaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfaffiliateCampaignCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerRegistrationNotesEntity.Relations.EventCustomersEntityUsingLeftWithoutScreeningNotesId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<AfaffiliateCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, (int)Falcon.Data.EntityType.AfaffiliateCampaignEntity, 0, null, null, GetRelationsForField("AfaffiliateCampaignCollectionViaEventCustomers"), null, "AfaffiliateCampaignCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Campaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerRegistrationNotesEntity.Relations.EventCustomersEntityUsingLeftWithoutScreeningNotesId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, (int)Falcon.Data.EntityType.CampaignEntity, 0, null, null, GetRelationsForField("CampaignCollectionViaEventCustomers"), null, "CampaignCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerRegistrationNotesEntity.Relations.EventCustomersEntityUsingLeftWithoutScreeningNotesId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaEventCustomers"), null, "CustomerProfileCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfileHistory' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileHistoryCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerRegistrationNotesEntity.Relations.EventCustomersEntityUsingLeftWithoutScreeningNotesId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileHistoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileHistoryEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, (int)Falcon.Data.EntityType.CustomerProfileHistoryEntity, 0, null, null, GetRelationsForField("CustomerProfileHistoryCollectionViaEventCustomers"), null, "CustomerProfileHistoryCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventAppointment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventAppointmentCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerRegistrationNotesEntity.Relations.EventCustomersEntityUsingLeftWithoutScreeningNotesId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<EventAppointmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, (int)Falcon.Data.EntityType.EventAppointmentEntity, 0, null, null, GetRelationsForField("EventAppointmentCollectionViaEventCustomers"), null, "EventAppointmentCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerRegistrationNotesEntity.Relations.EventAppointmentCancellationLogEntityUsingNoteId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentCancellationLog_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaEventAppointmentCancellationLog"), null, "EventCustomersCollectionViaEventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerRegistrationNotesEntity.Relations.EventAppointmentCancellationLogEntityUsingNoteId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentCancellationLog_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventAppointmentCancellationLog"), null, "EventsCollectionViaEventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerRegistrationNotesEntity.Relations.EventCustomersEntityUsingLeftWithoutScreeningNotesId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventCustomers"), null, "EventsCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GcNotGivenReason' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGcNotGivenReasonCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerRegistrationNotesEntity.Relations.EventCustomersEntityUsingLeftWithoutScreeningNotesId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<GcNotGivenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GcNotGivenReasonEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, (int)Falcon.Data.EntityType.GcNotGivenReasonEntity, 0, null, null, GetRelationsForField("GcNotGivenReasonCollectionViaEventCustomers"), null, "GcNotGivenReasonCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HospitalFacility' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHospitalFacilityCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerRegistrationNotesEntity.Relations.EventCustomersEntityUsingLeftWithoutScreeningNotesId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<HospitalFacilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalFacilityEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, (int)Falcon.Data.EntityType.HospitalFacilityEntity, 0, null, null, GetRelationsForField("HospitalFacilityCollectionViaEventCustomers"), null, "HospitalFacilityCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerRegistrationNotesEntity.Relations.EventAppointmentCancellationLogEntityUsingNoteId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentCancellationLog_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventAppointmentCancellationLog"), null, "LookupCollectionViaEventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerRegistrationNotesEntity.Relations.EventCustomersEntityUsingLeftWithoutScreeningNotesId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventCustomers"), null, "LookupCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventCustomers_
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerRegistrationNotesEntity.Relations.EventCustomersEntityUsingLeftWithoutScreeningNotesId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventCustomers_"), null, "LookupCollectionViaEventCustomers_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerRegistrationNotesEntity.Relations.EventCustomersEntityUsingLeftWithoutScreeningNotesId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventCustomers"), null, "OrganizationRoleUserCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerRegistrationNotesEntity.Relations.EventAppointmentCancellationLogEntityUsingNoteId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentCancellationLog_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventAppointmentCancellationLog"), null, "OrganizationRoleUserCollectionViaEventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventCustomers_
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerRegistrationNotesEntity.Relations.EventCustomersEntityUsingLeftWithoutScreeningNotesId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventCustomers_"), null, "OrganizationRoleUserCollectionViaEventCustomers_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RefundRequest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRefundRequestCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerRegistrationNotesEntity.Relations.EventAppointmentCancellationLogEntityUsingNoteId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentCancellationLog_");
				return new PrefetchPathElement2(new EntityCollection<RefundRequestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundRequestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, (int)Falcon.Data.EntityType.RefundRequestEntity, 0, null, null, GetRelationsForField("RefundRequestCollectionViaEventAppointmentCancellationLog"), null, "RefundRequestCollectionViaEventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RescheduleCancelDisposition' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerRegistrationNotesEntity.Relations.EventAppointmentCancellationLogEntityUsingNoteId;
				intermediateRelation.SetAliases(string.Empty, "EventAppointmentCancellationLog_");
				return new PrefetchPathElement2(new EntityCollection<RescheduleCancelDispositionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RescheduleCancelDispositionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, (int)Falcon.Data.EntityType.RescheduleCancelDispositionEntity, 0, null, null, GetRelationsForField("RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog"), null, "RescheduleCancelDispositionCollectionViaEventAppointmentCancellationLog", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEvents
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Events")[0], (int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, null, null, "Events", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CustomerRegistrationNotesEntity.CustomProperties;}
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
			get { return CustomerRegistrationNotesEntity.FieldsCustomProperties;}
		}

		/// <summary> The CustomerRegistrationNotesId property of the Entity CustomerRegistrationNotes<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerRegistrationNotes"."CustomerRegistrationNotesID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 CustomerRegistrationNotesId
		{
			get { return (System.Int64)GetValue((int)CustomerRegistrationNotesFieldIndex.CustomerRegistrationNotesId, true); }
			set	{ SetValue((int)CustomerRegistrationNotesFieldIndex.CustomerRegistrationNotesId, value); }
		}

		/// <summary> The CustomerId property of the Entity CustomerRegistrationNotes<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerRegistrationNotes"."CustomerID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerId
		{
			get { return (System.Int64)GetValue((int)CustomerRegistrationNotesFieldIndex.CustomerId, true); }
			set	{ SetValue((int)CustomerRegistrationNotesFieldIndex.CustomerId, value); }
		}

		/// <summary> The Notes property of the Entity CustomerRegistrationNotes<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerRegistrationNotes"."Notes"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 5000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Notes
		{
			get { return (System.String)GetValue((int)CustomerRegistrationNotesFieldIndex.Notes, true); }
			set	{ SetValue((int)CustomerRegistrationNotesFieldIndex.Notes, value); }
		}

		/// <summary> The DateCreated property of the Entity CustomerRegistrationNotes<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerRegistrationNotes"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)CustomerRegistrationNotesFieldIndex.DateCreated, true); }
			set	{ SetValue((int)CustomerRegistrationNotesFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity CustomerRegistrationNotes<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerRegistrationNotes"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CustomerRegistrationNotesFieldIndex.DateModified, false); }
			set	{ SetValue((int)CustomerRegistrationNotesFieldIndex.DateModified, value); }
		}

		/// <summary> The IsActive property of the Entity CustomerRegistrationNotes<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerRegistrationNotes"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)CustomerRegistrationNotesFieldIndex.IsActive, true); }
			set	{ SetValue((int)CustomerRegistrationNotesFieldIndex.IsActive, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity CustomerRegistrationNotes<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerRegistrationNotes"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)CustomerRegistrationNotesFieldIndex.CreatedByOrgRoleUserId, true); }
			set	{ SetValue((int)CustomerRegistrationNotesFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The EventId property of the Entity CustomerRegistrationNotes<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerRegistrationNotes"."EventId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> EventId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerRegistrationNotesFieldIndex.EventId, false); }
			set	{ SetValue((int)CustomerRegistrationNotesFieldIndex.EventId, value); }
		}

		/// <summary> The NoteType property of the Entity CustomerRegistrationNotes<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerRegistrationNotes"."NoteType"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> NoteType
		{
			get { return (Nullable<System.Int32>)GetValue((int)CustomerRegistrationNotesFieldIndex.NoteType, false); }
			set	{ SetValue((int)CustomerRegistrationNotesFieldIndex.NoteType, value); }
		}

		/// <summary> The ReasonId property of the Entity CustomerRegistrationNotes<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerRegistrationNotes"."ReasonId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ReasonId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerRegistrationNotesFieldIndex.ReasonId, false); }
			set	{ SetValue((int)CustomerRegistrationNotesFieldIndex.ReasonId, value); }
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
					_eventAppointmentCancellationLog.SetContainingEntityInfo(this, "CustomerRegistrationNotes");
				}
				return _eventAppointmentCancellationLog;
			}
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
					_eventCustomers.SetContainingEntityInfo(this, "CustomerRegistrationNotes");
				}
				return _eventCustomers;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'EventAppointmentEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventAppointmentEntity))]
		public virtual EntityCollection<EventAppointmentEntity> EventAppointmentCollectionViaEventCustomers
		{
			get
			{
				if(_eventAppointmentCollectionViaEventCustomers==null)
				{
					_eventAppointmentCollectionViaEventCustomers = new EntityCollection<EventAppointmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentEntityFactory)));
					_eventAppointmentCollectionViaEventCustomers.IsReadOnly=true;
				}
				return _eventAppointmentCollectionViaEventCustomers;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'RefundRequestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RefundRequestEntity))]
		public virtual EntityCollection<RefundRequestEntity> RefundRequestCollectionViaEventAppointmentCancellationLog
		{
			get
			{
				if(_refundRequestCollectionViaEventAppointmentCancellationLog==null)
				{
					_refundRequestCollectionViaEventAppointmentCancellationLog = new EntityCollection<RefundRequestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RefundRequestEntityFactory)));
					_refundRequestCollectionViaEventAppointmentCancellationLog.IsReadOnly=true;
				}
				return _refundRequestCollectionViaEventAppointmentCancellationLog;
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

		/// <summary> Gets / sets related entity of type 'EventsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EventsEntity Events
		{
			get
			{
				return _events;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEvents(value);
				}
				else
				{
					if(value==null)
					{
						if(_events != null)
						{
							_events.UnsetRelatedEntity(this, "CustomerRegistrationNotes");
						}
					}
					else
					{
						if(_events!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerRegistrationNotes");
						}
					}
				}
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
							_lookup.UnsetRelatedEntity(this, "CustomerRegistrationNotes");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerRegistrationNotes");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "CustomerRegistrationNotes");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerRegistrationNotes");
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
			get { return (int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity; }
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
