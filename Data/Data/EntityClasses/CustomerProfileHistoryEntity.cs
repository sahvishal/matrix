///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:52
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
	/// Entity class which represents the entity 'CustomerProfileHistory'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CustomerProfileHistoryEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<EventCustomersEntity> _eventCustomers;
		private EntityCollection<AfaffiliateCampaignEntity> _afaffiliateCampaignCollectionViaEventCustomers;
		private EntityCollection<CampaignEntity> _campaignCollectionViaEventCustomers;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaEventCustomers;
		private EntityCollection<CustomerRegistrationNotesEntity> _customerRegistrationNotesCollectionViaEventCustomers;
		private EntityCollection<EventAppointmentEntity> _eventAppointmentCollectionViaEventCustomers;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventCustomers;
		private EntityCollection<GcNotGivenReasonEntity> _gcNotGivenReasonCollectionViaEventCustomers;
		private EntityCollection<HospitalFacilityEntity> _hospitalFacilityCollectionViaEventCustomers;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventCustomers_;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventCustomers;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventCustomers_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventCustomers;
		private CustomerProfileEntity _customerProfile;
		private LookupEntity _lookup___;
		private LookupEntity _lookup_;
		private LookupEntity _lookup;
		private LookupEntity _lookup__;
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
			/// <summary>Member name CustomerProfile</summary>
			public static readonly string CustomerProfile = "CustomerProfile";
			/// <summary>Member name Lookup___</summary>
			public static readonly string Lookup___ = "Lookup___";
			/// <summary>Member name Lookup_</summary>
			public static readonly string Lookup_ = "Lookup_";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name Lookup__</summary>
			public static readonly string Lookup__ = "Lookup__";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name EventCustomers</summary>
			public static readonly string EventCustomers = "EventCustomers";
			/// <summary>Member name AfaffiliateCampaignCollectionViaEventCustomers</summary>
			public static readonly string AfaffiliateCampaignCollectionViaEventCustomers = "AfaffiliateCampaignCollectionViaEventCustomers";
			/// <summary>Member name CampaignCollectionViaEventCustomers</summary>
			public static readonly string CampaignCollectionViaEventCustomers = "CampaignCollectionViaEventCustomers";
			/// <summary>Member name CustomerProfileCollectionViaEventCustomers</summary>
			public static readonly string CustomerProfileCollectionViaEventCustomers = "CustomerProfileCollectionViaEventCustomers";
			/// <summary>Member name CustomerRegistrationNotesCollectionViaEventCustomers</summary>
			public static readonly string CustomerRegistrationNotesCollectionViaEventCustomers = "CustomerRegistrationNotesCollectionViaEventCustomers";
			/// <summary>Member name EventAppointmentCollectionViaEventCustomers</summary>
			public static readonly string EventAppointmentCollectionViaEventCustomers = "EventAppointmentCollectionViaEventCustomers";
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
		static CustomerProfileHistoryEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CustomerProfileHistoryEntity():base("CustomerProfileHistoryEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CustomerProfileHistoryEntity(IEntityFields2 fields):base("CustomerProfileHistoryEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CustomerProfileHistoryEntity</param>
		public CustomerProfileHistoryEntity(IValidator validator):base("CustomerProfileHistoryEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for CustomerProfileHistory which data should be fetched into this CustomerProfileHistory object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CustomerProfileHistoryEntity(System.Int64 id):base("CustomerProfileHistoryEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for CustomerProfileHistory which data should be fetched into this CustomerProfileHistory object</param>
		/// <param name="validator">The custom validator object for this CustomerProfileHistoryEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CustomerProfileHistoryEntity(System.Int64 id, IValidator validator):base("CustomerProfileHistoryEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CustomerProfileHistoryEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_eventCustomers = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomers", typeof(EntityCollection<EventCustomersEntity>));
				_afaffiliateCampaignCollectionViaEventCustomers = (EntityCollection<AfaffiliateCampaignEntity>)info.GetValue("_afaffiliateCampaignCollectionViaEventCustomers", typeof(EntityCollection<AfaffiliateCampaignEntity>));
				_campaignCollectionViaEventCustomers = (EntityCollection<CampaignEntity>)info.GetValue("_campaignCollectionViaEventCustomers", typeof(EntityCollection<CampaignEntity>));
				_customerProfileCollectionViaEventCustomers = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaEventCustomers", typeof(EntityCollection<CustomerProfileEntity>));
				_customerRegistrationNotesCollectionViaEventCustomers = (EntityCollection<CustomerRegistrationNotesEntity>)info.GetValue("_customerRegistrationNotesCollectionViaEventCustomers", typeof(EntityCollection<CustomerRegistrationNotesEntity>));
				_eventAppointmentCollectionViaEventCustomers = (EntityCollection<EventAppointmentEntity>)info.GetValue("_eventAppointmentCollectionViaEventCustomers", typeof(EntityCollection<EventAppointmentEntity>));
				_eventsCollectionViaEventCustomers = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventCustomers", typeof(EntityCollection<EventsEntity>));
				_gcNotGivenReasonCollectionViaEventCustomers = (EntityCollection<GcNotGivenReasonEntity>)info.GetValue("_gcNotGivenReasonCollectionViaEventCustomers", typeof(EntityCollection<GcNotGivenReasonEntity>));
				_hospitalFacilityCollectionViaEventCustomers = (EntityCollection<HospitalFacilityEntity>)info.GetValue("_hospitalFacilityCollectionViaEventCustomers", typeof(EntityCollection<HospitalFacilityEntity>));
				_lookupCollectionViaEventCustomers_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventCustomers_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEventCustomers = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventCustomers", typeof(EntityCollection<LookupEntity>));
				_organizationRoleUserCollectionViaEventCustomers_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventCustomers_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventCustomers = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventCustomers", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_customerProfile = (CustomerProfileEntity)info.GetValue("_customerProfile", typeof(CustomerProfileEntity));
				if(_customerProfile!=null)
				{
					_customerProfile.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup___ = (LookupEntity)info.GetValue("_lookup___", typeof(LookupEntity));
				if(_lookup___!=null)
				{
					_lookup___.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup_ = (LookupEntity)info.GetValue("_lookup_", typeof(LookupEntity));
				if(_lookup_!=null)
				{
					_lookup_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup__ = (LookupEntity)info.GetValue("_lookup__", typeof(LookupEntity));
				if(_lookup__!=null)
				{
					_lookup__.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((CustomerProfileHistoryFieldIndex)fieldIndex)
			{
				case CustomerProfileHistoryFieldIndex.CustomerId:
					DesetupSyncCustomerProfile(true, false);
					break;
				case CustomerProfileHistoryFieldIndex.CreatedBy:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case CustomerProfileHistoryFieldIndex.DoNotContactUpdateSource:
					DesetupSyncLookup(true, false);
					break;
				case CustomerProfileHistoryFieldIndex.PreferredContactType:
					DesetupSyncLookup___(true, false);
					break;
				case CustomerProfileHistoryFieldIndex.MemberUploadSourceId:
					DesetupSyncLookup__(true, false);
					break;
				case CustomerProfileHistoryFieldIndex.ProductTypeId:
					DesetupSyncLookup_(true, false);
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
				case "CustomerProfile":
					this.CustomerProfile = (CustomerProfileEntity)entity;
					break;
				case "Lookup___":
					this.Lookup___ = (LookupEntity)entity;
					break;
				case "Lookup_":
					this.Lookup_ = (LookupEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "Lookup__":
					this.Lookup__ = (LookupEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
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
				case "CustomerRegistrationNotesCollectionViaEventCustomers":
					this.CustomerRegistrationNotesCollectionViaEventCustomers.IsReadOnly = false;
					this.CustomerRegistrationNotesCollectionViaEventCustomers.Add((CustomerRegistrationNotesEntity)entity);
					this.CustomerRegistrationNotesCollectionViaEventCustomers.IsReadOnly = true;
					break;
				case "EventAppointmentCollectionViaEventCustomers":
					this.EventAppointmentCollectionViaEventCustomers.IsReadOnly = false;
					this.EventAppointmentCollectionViaEventCustomers.Add((EventAppointmentEntity)entity);
					this.EventAppointmentCollectionViaEventCustomers.IsReadOnly = true;
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
			return CustomerProfileHistoryEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "CustomerProfile":
					toReturn.Add(CustomerProfileHistoryEntity.Relations.CustomerProfileEntityUsingCustomerId);
					break;
				case "Lookup___":
					toReturn.Add(CustomerProfileHistoryEntity.Relations.LookupEntityUsingPreferredContactType);
					break;
				case "Lookup_":
					toReturn.Add(CustomerProfileHistoryEntity.Relations.LookupEntityUsingProductTypeId);
					break;
				case "Lookup":
					toReturn.Add(CustomerProfileHistoryEntity.Relations.LookupEntityUsingDoNotContactUpdateSource);
					break;
				case "Lookup__":
					toReturn.Add(CustomerProfileHistoryEntity.Relations.LookupEntityUsingMemberUploadSourceId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(CustomerProfileHistoryEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy);
					break;
				case "EventCustomers":
					toReturn.Add(CustomerProfileHistoryEntity.Relations.EventCustomersEntityUsingCustomerProfileHistoryId);
					break;
				case "AfaffiliateCampaignCollectionViaEventCustomers":
					toReturn.Add(CustomerProfileHistoryEntity.Relations.EventCustomersEntityUsingCustomerProfileHistoryId, "CustomerProfileHistoryEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.AfaffiliateCampaignEntityUsingAffiliateCampaignId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "CampaignCollectionViaEventCustomers":
					toReturn.Add(CustomerProfileHistoryEntity.Relations.EventCustomersEntityUsingCustomerProfileHistoryId, "CustomerProfileHistoryEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.CampaignEntityUsingCampaignId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaEventCustomers":
					toReturn.Add(CustomerProfileHistoryEntity.Relations.EventCustomersEntityUsingCustomerProfileHistoryId, "CustomerProfileHistoryEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.CustomerProfileEntityUsingCustomerId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "CustomerRegistrationNotesCollectionViaEventCustomers":
					toReturn.Add(CustomerProfileHistoryEntity.Relations.EventCustomersEntityUsingCustomerProfileHistoryId, "CustomerProfileHistoryEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.CustomerRegistrationNotesEntityUsingLeftWithoutScreeningNotesId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "EventAppointmentCollectionViaEventCustomers":
					toReturn.Add(CustomerProfileHistoryEntity.Relations.EventCustomersEntityUsingCustomerProfileHistoryId, "CustomerProfileHistoryEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.EventAppointmentEntityUsingAppointmentId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventCustomers":
					toReturn.Add(CustomerProfileHistoryEntity.Relations.EventCustomersEntityUsingCustomerProfileHistoryId, "CustomerProfileHistoryEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.EventsEntityUsingEventId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "GcNotGivenReasonCollectionViaEventCustomers":
					toReturn.Add(CustomerProfileHistoryEntity.Relations.EventCustomersEntityUsingCustomerProfileHistoryId, "CustomerProfileHistoryEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.GcNotGivenReasonEntityUsingGcNotGivenReasonId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "HospitalFacilityCollectionViaEventCustomers":
					toReturn.Add(CustomerProfileHistoryEntity.Relations.EventCustomersEntityUsingCustomerProfileHistoryId, "CustomerProfileHistoryEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.HospitalFacilityEntityUsingHospitalFacilityId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventCustomers_":
					toReturn.Add(CustomerProfileHistoryEntity.Relations.EventCustomersEntityUsingCustomerProfileHistoryId, "CustomerProfileHistoryEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.LookupEntityUsingPreferredContactType, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventCustomers":
					toReturn.Add(CustomerProfileHistoryEntity.Relations.EventCustomersEntityUsingCustomerProfileHistoryId, "CustomerProfileHistoryEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.LookupEntityUsingLeftWithoutScreeningReasonId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventCustomers_":
					toReturn.Add(CustomerProfileHistoryEntity.Relations.EventCustomersEntityUsingCustomerProfileHistoryId, "CustomerProfileHistoryEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.OrganizationRoleUserEntityUsingConfirmedBy, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventCustomers":
					toReturn.Add(CustomerProfileHistoryEntity.Relations.EventCustomersEntityUsingCustomerProfileHistoryId, "CustomerProfileHistoryEntity__", "EventCustomers_", JoinHint.None);
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
				case "CustomerProfile":
					SetupSyncCustomerProfile(relatedEntity);
					break;
				case "Lookup___":
					SetupSyncLookup___(relatedEntity);
					break;
				case "Lookup_":
					SetupSyncLookup_(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "Lookup__":
					SetupSyncLookup__(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
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
				case "CustomerProfile":
					DesetupSyncCustomerProfile(false, true);
					break;
				case "Lookup___":
					DesetupSyncLookup___(false, true);
					break;
				case "Lookup_":
					DesetupSyncLookup_(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "Lookup__":
					DesetupSyncLookup__(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
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
			if(_customerProfile!=null)
			{
				toReturn.Add(_customerProfile);
			}
			if(_lookup___!=null)
			{
				toReturn.Add(_lookup___);
			}
			if(_lookup_!=null)
			{
				toReturn.Add(_lookup_);
			}
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
			}
			if(_lookup__!=null)
			{
				toReturn.Add(_lookup__);
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
				info.AddValue("_eventCustomers", ((_eventCustomers!=null) && (_eventCustomers.Count>0) && !this.MarkedForDeletion)?_eventCustomers:null);
				info.AddValue("_afaffiliateCampaignCollectionViaEventCustomers", ((_afaffiliateCampaignCollectionViaEventCustomers!=null) && (_afaffiliateCampaignCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_afaffiliateCampaignCollectionViaEventCustomers:null);
				info.AddValue("_campaignCollectionViaEventCustomers", ((_campaignCollectionViaEventCustomers!=null) && (_campaignCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_campaignCollectionViaEventCustomers:null);
				info.AddValue("_customerProfileCollectionViaEventCustomers", ((_customerProfileCollectionViaEventCustomers!=null) && (_customerProfileCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaEventCustomers:null);
				info.AddValue("_customerRegistrationNotesCollectionViaEventCustomers", ((_customerRegistrationNotesCollectionViaEventCustomers!=null) && (_customerRegistrationNotesCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_customerRegistrationNotesCollectionViaEventCustomers:null);
				info.AddValue("_eventAppointmentCollectionViaEventCustomers", ((_eventAppointmentCollectionViaEventCustomers!=null) && (_eventAppointmentCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_eventAppointmentCollectionViaEventCustomers:null);
				info.AddValue("_eventsCollectionViaEventCustomers", ((_eventsCollectionViaEventCustomers!=null) && (_eventsCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventCustomers:null);
				info.AddValue("_gcNotGivenReasonCollectionViaEventCustomers", ((_gcNotGivenReasonCollectionViaEventCustomers!=null) && (_gcNotGivenReasonCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_gcNotGivenReasonCollectionViaEventCustomers:null);
				info.AddValue("_hospitalFacilityCollectionViaEventCustomers", ((_hospitalFacilityCollectionViaEventCustomers!=null) && (_hospitalFacilityCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_hospitalFacilityCollectionViaEventCustomers:null);
				info.AddValue("_lookupCollectionViaEventCustomers_", ((_lookupCollectionViaEventCustomers_!=null) && (_lookupCollectionViaEventCustomers_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventCustomers_:null);
				info.AddValue("_lookupCollectionViaEventCustomers", ((_lookupCollectionViaEventCustomers!=null) && (_lookupCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventCustomers:null);
				info.AddValue("_organizationRoleUserCollectionViaEventCustomers_", ((_organizationRoleUserCollectionViaEventCustomers_!=null) && (_organizationRoleUserCollectionViaEventCustomers_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventCustomers_:null);
				info.AddValue("_organizationRoleUserCollectionViaEventCustomers", ((_organizationRoleUserCollectionViaEventCustomers!=null) && (_organizationRoleUserCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventCustomers:null);
				info.AddValue("_customerProfile", (!this.MarkedForDeletion?_customerProfile:null));
				info.AddValue("_lookup___", (!this.MarkedForDeletion?_lookup___:null));
				info.AddValue("_lookup_", (!this.MarkedForDeletion?_lookup_:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_lookup__", (!this.MarkedForDeletion?_lookup__:null));
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
		public bool TestOriginalFieldValueForNull(CustomerProfileHistoryFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CustomerProfileHistoryFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CustomerProfileHistoryRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.CustomerProfileHistoryId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AfaffiliateCampaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfaffiliateCampaignCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AfaffiliateCampaignCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileHistoryFields.Id, null, ComparisonOperator.Equal, this.Id, "CustomerProfileHistoryEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Campaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CampaignCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileHistoryFields.Id, null, ComparisonOperator.Equal, this.Id, "CustomerProfileHistoryEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileHistoryFields.Id, null, ComparisonOperator.Equal, this.Id, "CustomerProfileHistoryEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerRegistrationNotes' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerRegistrationNotesCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerRegistrationNotesCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileHistoryFields.Id, null, ComparisonOperator.Equal, this.Id, "CustomerProfileHistoryEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventAppointment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventAppointmentCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventAppointmentCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileHistoryFields.Id, null, ComparisonOperator.Equal, this.Id, "CustomerProfileHistoryEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileHistoryFields.Id, null, ComparisonOperator.Equal, this.Id, "CustomerProfileHistoryEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GcNotGivenReason' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGcNotGivenReasonCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("GcNotGivenReasonCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileHistoryFields.Id, null, ComparisonOperator.Equal, this.Id, "CustomerProfileHistoryEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HospitalFacility' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHospitalFacilityCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HospitalFacilityCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileHistoryFields.Id, null, ComparisonOperator.Equal, this.Id, "CustomerProfileHistoryEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventCustomers_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventCustomers_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileHistoryFields.Id, null, ComparisonOperator.Equal, this.Id, "CustomerProfileHistoryEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileHistoryFields.Id, null, ComparisonOperator.Equal, this.Id, "CustomerProfileHistoryEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventCustomers_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventCustomers_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileHistoryFields.Id, null, ComparisonOperator.Equal, this.Id, "CustomerProfileHistoryEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileHistoryFields.Id, null, ComparisonOperator.Equal, this.Id, "CustomerProfileHistoryEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileFields.CustomerId, null, ComparisonOperator.Equal, this.CustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.PreferredContactType));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.ProductTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.DoNotContactUpdateSource));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.MemberUploadSourceId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.CreatedBy));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CustomerProfileHistoryEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileHistoryEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._eventCustomers);
			collectionsQueue.Enqueue(this._afaffiliateCampaignCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._campaignCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._customerRegistrationNotesCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._eventAppointmentCollectionViaEventCustomers);
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
			this._afaffiliateCampaignCollectionViaEventCustomers = (EntityCollection<AfaffiliateCampaignEntity>) collectionsQueue.Dequeue();
			this._campaignCollectionViaEventCustomers = (EntityCollection<CampaignEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaEventCustomers = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerRegistrationNotesCollectionViaEventCustomers = (EntityCollection<CustomerRegistrationNotesEntity>) collectionsQueue.Dequeue();
			this._eventAppointmentCollectionViaEventCustomers = (EntityCollection<EventAppointmentEntity>) collectionsQueue.Dequeue();
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
			if (this._customerRegistrationNotesCollectionViaEventCustomers != null)
			{
				return true;
			}
			if (this._eventAppointmentCollectionViaEventCustomers != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfaffiliateCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerRegistrationNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerRegistrationNotesEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventAppointmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentEntityFactory))) : null);
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
			toReturn.Add("CustomerProfile", _customerProfile);
			toReturn.Add("Lookup___", _lookup___);
			toReturn.Add("Lookup_", _lookup_);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("Lookup__", _lookup__);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("EventCustomers", _eventCustomers);
			toReturn.Add("AfaffiliateCampaignCollectionViaEventCustomers", _afaffiliateCampaignCollectionViaEventCustomers);
			toReturn.Add("CampaignCollectionViaEventCustomers", _campaignCollectionViaEventCustomers);
			toReturn.Add("CustomerProfileCollectionViaEventCustomers", _customerProfileCollectionViaEventCustomers);
			toReturn.Add("CustomerRegistrationNotesCollectionViaEventCustomers", _customerRegistrationNotesCollectionViaEventCustomers);
			toReturn.Add("EventAppointmentCollectionViaEventCustomers", _eventAppointmentCollectionViaEventCustomers);
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
			if(_customerRegistrationNotesCollectionViaEventCustomers!=null)
			{
				_customerRegistrationNotesCollectionViaEventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_eventAppointmentCollectionViaEventCustomers!=null)
			{
				_eventAppointmentCollectionViaEventCustomers.ActiveContext = base.ActiveContext;
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
			if(_customerProfile!=null)
			{
				_customerProfile.ActiveContext = base.ActiveContext;
			}
			if(_lookup___!=null)
			{
				_lookup___.ActiveContext = base.ActiveContext;
			}
			if(_lookup_!=null)
			{
				_lookup_.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_lookup__!=null)
			{
				_lookup__.ActiveContext = base.ActiveContext;
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
			_afaffiliateCampaignCollectionViaEventCustomers = null;
			_campaignCollectionViaEventCustomers = null;
			_customerProfileCollectionViaEventCustomers = null;
			_customerRegistrationNotesCollectionViaEventCustomers = null;
			_eventAppointmentCollectionViaEventCustomers = null;
			_eventsCollectionViaEventCustomers = null;
			_gcNotGivenReasonCollectionViaEventCustomers = null;
			_hospitalFacilityCollectionViaEventCustomers = null;
			_lookupCollectionViaEventCustomers_ = null;
			_lookupCollectionViaEventCustomers = null;
			_organizationRoleUserCollectionViaEventCustomers_ = null;
			_organizationRoleUserCollectionViaEventCustomers = null;
			_customerProfile = null;
			_lookup___ = null;
			_lookup_ = null;
			_lookup = null;
			_lookup__ = null;
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

			_fieldsCustomProperties.Add("Id", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FirstName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MiddleName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HomeAddress1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HomeAddress2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HomeCity", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HomeState", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HomeZipCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HomeCountry", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneOffice", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneCell", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneHome", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Email1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Email2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Picture", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Dob", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DefaultRoleId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneOfficeExtension", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Ssn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DisplayId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BillingAddress1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BillingAddress2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BillingCity", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BillingState", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BillingZipCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BillingCountry", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Height", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Weight", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Gender", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Race", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TrackingMarketingId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AddedByRoleId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Employer", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EmergencyContactName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EmergencyContactRelationship", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EmergencyContactPhoneNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DoNotContactReasonId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DoNotContactReasonNotesId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RequestNewsLetter", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EmployeeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InsuranceId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PreferredLanguage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BestTimeToCall", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Waist", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Hicn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EnableTexting", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MedicareAdvantageNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Tag", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MedicareAdvantagePlanName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsEligble", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LanguageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LabId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Copay", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Lpi", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Market", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Mrn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GroupName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsIncorrectPhoneNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsLanguageBarrier", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DoNotContactTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EnableVoiceMail", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AdditionalField1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AdditionalField2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AdditionalField3", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AdditionalField4", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ActivityId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DoNotContactUpdateDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DoNotContactUpdateSource", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsSubscribed", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IncorrectPhoneNumberMarkedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LanguageBarrierMarkedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PreferredContactType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Mbi", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AcesId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneHomeConsentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneHomeConsentUpdateDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneCellConsentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneCellConsentUpdateDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneOfficeConsentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneOfficeConsentUpdateDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BillingMemberId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BillingMemberPlan", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BillingMemberPlanYear", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EnableEmail", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EnableEmailUpdateDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MergedCustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EligibilityForYear", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsWarmTransfer", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("WarmTransferYear", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MemberUploadSourceId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ActivityTypeIsManual", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TargetedYear", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsTargeted", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProductTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AcesClientId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _customerProfile</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerProfile(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", CustomerProfileHistoryEntity.Relations.CustomerProfileEntityUsingCustomerId, true, signalRelatedEntity, "CustomerProfileHistory", resetFKFields, new int[] { (int)CustomerProfileHistoryFieldIndex.CustomerId } );		
			_customerProfile = null;
		}

		/// <summary> setups the sync logic for member _customerProfile</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerProfile(IEntity2 relatedEntity)
		{
			if(_customerProfile!=relatedEntity)
			{
				DesetupSyncCustomerProfile(true, true);
				_customerProfile = (CustomerProfileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", CustomerProfileHistoryEntity.Relations.CustomerProfileEntityUsingCustomerId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerProfilePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _lookup___</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup___(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup___, new PropertyChangedEventHandler( OnLookup___PropertyChanged ), "Lookup___", CustomerProfileHistoryEntity.Relations.LookupEntityUsingPreferredContactType, true, signalRelatedEntity, "CustomerProfileHistory___", resetFKFields, new int[] { (int)CustomerProfileHistoryFieldIndex.PreferredContactType } );		
			_lookup___ = null;
		}

		/// <summary> setups the sync logic for member _lookup___</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup___(IEntity2 relatedEntity)
		{
			if(_lookup___!=relatedEntity)
			{
				DesetupSyncLookup___(true, true);
				_lookup___ = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup___, new PropertyChangedEventHandler( OnLookup___PropertyChanged ), "Lookup___", CustomerProfileHistoryEntity.Relations.LookupEntityUsingPreferredContactType, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookup___PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _lookup_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", CustomerProfileHistoryEntity.Relations.LookupEntityUsingProductTypeId, true, signalRelatedEntity, "CustomerProfileHistory_", resetFKFields, new int[] { (int)CustomerProfileHistoryFieldIndex.ProductTypeId } );		
			_lookup_ = null;
		}

		/// <summary> setups the sync logic for member _lookup_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup_(IEntity2 relatedEntity)
		{
			if(_lookup_!=relatedEntity)
			{
				DesetupSyncLookup_(true, true);
				_lookup_ = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", CustomerProfileHistoryEntity.Relations.LookupEntityUsingProductTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookup_PropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CustomerProfileHistoryEntity.Relations.LookupEntityUsingDoNotContactUpdateSource, true, signalRelatedEntity, "CustomerProfileHistory", resetFKFields, new int[] { (int)CustomerProfileHistoryFieldIndex.DoNotContactUpdateSource } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CustomerProfileHistoryEntity.Relations.LookupEntityUsingDoNotContactUpdateSource, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _lookup__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup__, new PropertyChangedEventHandler( OnLookup__PropertyChanged ), "Lookup__", CustomerProfileHistoryEntity.Relations.LookupEntityUsingMemberUploadSourceId, true, signalRelatedEntity, "CustomerProfileHistory__", resetFKFields, new int[] { (int)CustomerProfileHistoryFieldIndex.MemberUploadSourceId } );		
			_lookup__ = null;
		}

		/// <summary> setups the sync logic for member _lookup__</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup__(IEntity2 relatedEntity)
		{
			if(_lookup__!=relatedEntity)
			{
				DesetupSyncLookup__(true, true);
				_lookup__ = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup__, new PropertyChangedEventHandler( OnLookup__PropertyChanged ), "Lookup__", CustomerProfileHistoryEntity.Relations.LookupEntityUsingMemberUploadSourceId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookup__PropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CustomerProfileHistoryEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, signalRelatedEntity, "CustomerProfileHistory", resetFKFields, new int[] { (int)CustomerProfileHistoryFieldIndex.CreatedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CustomerProfileHistoryEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this CustomerProfileHistoryEntity</param>
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
		public  static CustomerProfileHistoryRelations Relations
		{
			get	{ return new CustomerProfileHistoryRelations(); }
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
					(IEntityRelation)GetRelationsForField("EventCustomers")[0], (int)Falcon.Data.EntityType.CustomerProfileHistoryEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, null, null, "EventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfaffiliateCampaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfaffiliateCampaignCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerProfileHistoryEntity.Relations.EventCustomersEntityUsingCustomerProfileHistoryId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<AfaffiliateCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerProfileHistoryEntity, (int)Falcon.Data.EntityType.AfaffiliateCampaignEntity, 0, null, null, GetRelationsForField("AfaffiliateCampaignCollectionViaEventCustomers"), null, "AfaffiliateCampaignCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Campaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerProfileHistoryEntity.Relations.EventCustomersEntityUsingCustomerProfileHistoryId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerProfileHistoryEntity, (int)Falcon.Data.EntityType.CampaignEntity, 0, null, null, GetRelationsForField("CampaignCollectionViaEventCustomers"), null, "CampaignCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerProfileHistoryEntity.Relations.EventCustomersEntityUsingCustomerProfileHistoryId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerProfileHistoryEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaEventCustomers"), null, "CustomerProfileCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerRegistrationNotes' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerRegistrationNotesCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerProfileHistoryEntity.Relations.EventCustomersEntityUsingCustomerProfileHistoryId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<CustomerRegistrationNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerRegistrationNotesEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerProfileHistoryEntity, (int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, 0, null, null, GetRelationsForField("CustomerRegistrationNotesCollectionViaEventCustomers"), null, "CustomerRegistrationNotesCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventAppointment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventAppointmentCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerProfileHistoryEntity.Relations.EventCustomersEntityUsingCustomerProfileHistoryId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<EventAppointmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerProfileHistoryEntity, (int)Falcon.Data.EntityType.EventAppointmentEntity, 0, null, null, GetRelationsForField("EventAppointmentCollectionViaEventCustomers"), null, "EventAppointmentCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerProfileHistoryEntity.Relations.EventCustomersEntityUsingCustomerProfileHistoryId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerProfileHistoryEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventCustomers"), null, "EventsCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GcNotGivenReason' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGcNotGivenReasonCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerProfileHistoryEntity.Relations.EventCustomersEntityUsingCustomerProfileHistoryId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<GcNotGivenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GcNotGivenReasonEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerProfileHistoryEntity, (int)Falcon.Data.EntityType.GcNotGivenReasonEntity, 0, null, null, GetRelationsForField("GcNotGivenReasonCollectionViaEventCustomers"), null, "GcNotGivenReasonCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HospitalFacility' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHospitalFacilityCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerProfileHistoryEntity.Relations.EventCustomersEntityUsingCustomerProfileHistoryId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<HospitalFacilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalFacilityEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerProfileHistoryEntity, (int)Falcon.Data.EntityType.HospitalFacilityEntity, 0, null, null, GetRelationsForField("HospitalFacilityCollectionViaEventCustomers"), null, "HospitalFacilityCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventCustomers_
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerProfileHistoryEntity.Relations.EventCustomersEntityUsingCustomerProfileHistoryId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerProfileHistoryEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventCustomers_"), null, "LookupCollectionViaEventCustomers_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerProfileHistoryEntity.Relations.EventCustomersEntityUsingCustomerProfileHistoryId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerProfileHistoryEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventCustomers"), null, "LookupCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventCustomers_
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerProfileHistoryEntity.Relations.EventCustomersEntityUsingCustomerProfileHistoryId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerProfileHistoryEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventCustomers_"), null, "OrganizationRoleUserCollectionViaEventCustomers_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CustomerProfileHistoryEntity.Relations.EventCustomersEntityUsingCustomerProfileHistoryId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CustomerProfileHistoryEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventCustomers"), null, "OrganizationRoleUserCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfile
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerProfile")[0], (int)Falcon.Data.EntityType.CustomerProfileHistoryEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, null, null, "CustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup___
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup___")[0], (int)Falcon.Data.EntityType.CustomerProfileHistoryEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup_")[0], (int)Falcon.Data.EntityType.CustomerProfileHistoryEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.CustomerProfileHistoryEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup__
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup__")[0], (int)Falcon.Data.EntityType.CustomerProfileHistoryEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.CustomerProfileHistoryEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CustomerProfileHistoryEntity.CustomProperties;}
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
			get { return CustomerProfileHistoryEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)CustomerProfileHistoryFieldIndex.Id, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.Id, value); }
		}

		/// <summary> The CustomerId property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."CustomerID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CustomerId
		{
			get { return (System.Int64)GetValue((int)CustomerProfileHistoryFieldIndex.CustomerId, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.CustomerId, value); }
		}

		/// <summary> The FirstName property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."FirstName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String FirstName
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.FirstName, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.FirstName, value); }
		}

		/// <summary> The MiddleName property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."MiddleName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MiddleName
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.MiddleName, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.MiddleName, value); }
		}

		/// <summary> The LastName property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."LastName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String LastName
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.LastName, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.LastName, value); }
		}

		/// <summary> The HomeAddress1 property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."HomeAddress1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String HomeAddress1
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.HomeAddress1, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.HomeAddress1, value); }
		}

		/// <summary> The HomeAddress2 property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."HomeAddress2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String HomeAddress2
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.HomeAddress2, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.HomeAddress2, value); }
		}

		/// <summary> The HomeCity property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."HomeCity"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String HomeCity
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.HomeCity, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.HomeCity, value); }
		}

		/// <summary> The HomeState property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."HomeState"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String HomeState
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.HomeState, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.HomeState, value); }
		}

		/// <summary> The HomeZipCode property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."HomeZipCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String HomeZipCode
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.HomeZipCode, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.HomeZipCode, value); }
		}

		/// <summary> The HomeCountry property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."HomeCountry"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String HomeCountry
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.HomeCountry, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.HomeCountry, value); }
		}

		/// <summary> The PhoneOffice property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."PhoneOffice"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneOffice
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.PhoneOffice, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.PhoneOffice, value); }
		}

		/// <summary> The PhoneCell property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."PhoneCell"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneCell
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.PhoneCell, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.PhoneCell, value); }
		}

		/// <summary> The PhoneHome property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."PhoneHome"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneHome
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.PhoneHome, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.PhoneHome, value); }
		}

		/// <summary> The Email1 property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."EMail1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Email1
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.Email1, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.Email1, value); }
		}

		/// <summary> The Email2 property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."EMail2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Email2
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.Email2, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.Email2, value); }
		}

		/// <summary> The Picture property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."Picture"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Picture
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.Picture, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.Picture, value); }
		}

		/// <summary> The Dob property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."DOB"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallDateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> Dob
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CustomerProfileHistoryFieldIndex.Dob, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.Dob, value); }
		}

		/// <summary> The DefaultRoleId property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."DefaultRoleID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> DefaultRoleId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerProfileHistoryFieldIndex.DefaultRoleId, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.DefaultRoleId, value); }
		}

		/// <summary> The PhoneOfficeExtension property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."PhoneOfficeExtension"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneOfficeExtension
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.PhoneOfficeExtension, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.PhoneOfficeExtension, value); }
		}

		/// <summary> The Ssn property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."SSN"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Ssn
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.Ssn, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.Ssn, value); }
		}

		/// <summary> The DisplayId property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."DisplayID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> DisplayId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerProfileHistoryFieldIndex.DisplayId, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.DisplayId, value); }
		}

		/// <summary> The BillingAddress1 property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."BillingAddress1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BillingAddress1
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.BillingAddress1, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.BillingAddress1, value); }
		}

		/// <summary> The BillingAddress2 property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."BillingAddress2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BillingAddress2
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.BillingAddress2, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.BillingAddress2, value); }
		}

		/// <summary> The BillingCity property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."BillingCity"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BillingCity
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.BillingCity, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.BillingCity, value); }
		}

		/// <summary> The BillingState property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."BillingState"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BillingState
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.BillingState, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.BillingState, value); }
		}

		/// <summary> The BillingZipCode property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."BillingZipCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BillingZipCode
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.BillingZipCode, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.BillingZipCode, value); }
		}

		/// <summary> The BillingCountry property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."BillingCountry"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BillingCountry
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.BillingCountry, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.BillingCountry, value); }
		}

		/// <summary> The Height property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."Height"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 40<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Height
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.Height, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.Height, value); }
		}

		/// <summary> The Weight property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."Weight"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Double> Weight
		{
			get { return (Nullable<System.Double>)GetValue((int)CustomerProfileHistoryFieldIndex.Weight, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.Weight, value); }
		}

		/// <summary> The Gender property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."Gender"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 40<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Gender
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.Gender, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.Gender, value); }
		}

		/// <summary> The Race property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."Race"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Race
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.Race, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.Race, value); }
		}

		/// <summary> The TrackingMarketingId property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."TrackingMarketingID"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String TrackingMarketingId
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.TrackingMarketingId, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.TrackingMarketingId, value); }
		}

		/// <summary> The AddedByRoleId property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."AddedByRoleID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> AddedByRoleId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerProfileHistoryFieldIndex.AddedByRoleId, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.AddedByRoleId, value); }
		}

		/// <summary> The Employer property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."Employer"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Employer
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.Employer, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.Employer, value); }
		}

		/// <summary> The EmergencyContactName property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."EmergencyContactName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String EmergencyContactName
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.EmergencyContactName, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.EmergencyContactName, value); }
		}

		/// <summary> The EmergencyContactRelationship property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."EmergencyContactRelationship"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String EmergencyContactRelationship
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.EmergencyContactRelationship, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.EmergencyContactRelationship, value); }
		}

		/// <summary> The EmergencyContactPhoneNumber property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."EmergencyContactPhoneNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 20<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String EmergencyContactPhoneNumber
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.EmergencyContactPhoneNumber, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.EmergencyContactPhoneNumber, value); }
		}

		/// <summary> The DoNotContactReasonId property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."DoNotContactReasonId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> DoNotContactReasonId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerProfileHistoryFieldIndex.DoNotContactReasonId, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.DoNotContactReasonId, value); }
		}

		/// <summary> The DoNotContactReasonNotesId property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."DoNotContactReasonNotesId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> DoNotContactReasonNotesId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerProfileHistoryFieldIndex.DoNotContactReasonNotesId, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.DoNotContactReasonNotesId, value); }
		}

		/// <summary> The RequestNewsLetter property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."RequestNewsLetter"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean RequestNewsLetter
		{
			get { return (System.Boolean)GetValue((int)CustomerProfileHistoryFieldIndex.RequestNewsLetter, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.RequestNewsLetter, value); }
		}

		/// <summary> The EmployeeId property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."EmployeeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String EmployeeId
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.EmployeeId, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.EmployeeId, value); }
		}

		/// <summary> The InsuranceId property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."InsuranceId"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String InsuranceId
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.InsuranceId, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.InsuranceId, value); }
		}

		/// <summary> The PreferredLanguage property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."PreferredLanguage"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 250<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PreferredLanguage
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.PreferredLanguage, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.PreferredLanguage, value); }
		}

		/// <summary> The BestTimeToCall property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."BestTimeToCall"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BestTimeToCall
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerProfileHistoryFieldIndex.BestTimeToCall, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.BestTimeToCall, value); }
		}

		/// <summary> The Waist property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."Waist"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Waist
		{
			get { return (Nullable<System.Decimal>)GetValue((int)CustomerProfileHistoryFieldIndex.Waist, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.Waist, value); }
		}

		/// <summary> The Hicn property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."HICN"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Hicn
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.Hicn, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.Hicn, value); }
		}

		/// <summary> The EnableTexting property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."EnableTexting"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean EnableTexting
		{
			get { return (System.Boolean)GetValue((int)CustomerProfileHistoryFieldIndex.EnableTexting, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.EnableTexting, value); }
		}

		/// <summary> The MedicareAdvantageNumber property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."MedicareAdvantageNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MedicareAdvantageNumber
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.MedicareAdvantageNumber, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.MedicareAdvantageNumber, value); }
		}

		/// <summary> The Tag property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."Tag"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Tag
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.Tag, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.Tag, value); }
		}

		/// <summary> The MedicareAdvantagePlanName property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."MedicareAdvantagePlanName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MedicareAdvantagePlanName
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.MedicareAdvantagePlanName, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.MedicareAdvantagePlanName, value); }
		}

		/// <summary> The IsEligble property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."IsEligble"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsEligble
		{
			get { return (Nullable<System.Boolean>)GetValue((int)CustomerProfileHistoryFieldIndex.IsEligble, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.IsEligble, value); }
		}

		/// <summary> The LanguageId property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."LanguageId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> LanguageId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerProfileHistoryFieldIndex.LanguageId, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.LanguageId, value); }
		}

		/// <summary> The LabId property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."LabId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> LabId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerProfileHistoryFieldIndex.LabId, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.LabId, value); }
		}

		/// <summary> The Copay property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."Copay"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Copay
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.Copay, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.Copay, value); }
		}

		/// <summary> The Lpi property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."Lpi"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Lpi
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.Lpi, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.Lpi, value); }
		}

		/// <summary> The Market property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."Market"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Market
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.Market, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.Market, value); }
		}

		/// <summary> The Mrn property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."Mrn"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Mrn
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.Mrn, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.Mrn, value); }
		}

		/// <summary> The GroupName property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."GroupName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String GroupName
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.GroupName, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.GroupName, value); }
		}

		/// <summary> The IsIncorrectPhoneNumber property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."IsIncorrectPhoneNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsIncorrectPhoneNumber
		{
			get { return (System.Boolean)GetValue((int)CustomerProfileHistoryFieldIndex.IsIncorrectPhoneNumber, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.IsIncorrectPhoneNumber, value); }
		}

		/// <summary> The IsLanguageBarrier property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."IsLanguageBarrier"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsLanguageBarrier
		{
			get { return (System.Boolean)GetValue((int)CustomerProfileHistoryFieldIndex.IsLanguageBarrier, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.IsLanguageBarrier, value); }
		}

		/// <summary> The DoNotContactTypeId property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."DoNotContactTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> DoNotContactTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerProfileHistoryFieldIndex.DoNotContactTypeId, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.DoNotContactTypeId, value); }
		}

		/// <summary> The EnableVoiceMail property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."EnableVoiceMail"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean EnableVoiceMail
		{
			get { return (System.Boolean)GetValue((int)CustomerProfileHistoryFieldIndex.EnableVoiceMail, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.EnableVoiceMail, value); }
		}

		/// <summary> The AdditionalField1 property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."AdditionalField1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String AdditionalField1
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.AdditionalField1, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.AdditionalField1, value); }
		}

		/// <summary> The AdditionalField2 property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."AdditionalField2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String AdditionalField2
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.AdditionalField2, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.AdditionalField2, value); }
		}

		/// <summary> The AdditionalField3 property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."AdditionalField3"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String AdditionalField3
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.AdditionalField3, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.AdditionalField3, value); }
		}

		/// <summary> The AdditionalField4 property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."AdditionalField4"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String AdditionalField4
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.AdditionalField4, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.AdditionalField4, value); }
		}

		/// <summary> The ActivityId property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."ActivityId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ActivityId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerProfileHistoryFieldIndex.ActivityId, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.ActivityId, value); }
		}

		/// <summary> The DoNotContactUpdateDate property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."DoNotContactUpdateDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DoNotContactUpdateDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CustomerProfileHistoryFieldIndex.DoNotContactUpdateDate, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.DoNotContactUpdateDate, value); }
		}

		/// <summary> The DateCreated property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)CustomerProfileHistoryFieldIndex.DateCreated, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.DateCreated, value); }
		}

		/// <summary> The CreatedBy property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."CreatedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedBy
		{
			get { return (System.Int64)GetValue((int)CustomerProfileHistoryFieldIndex.CreatedBy, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.CreatedBy, value); }
		}

		/// <summary> The DoNotContactUpdateSource property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."DoNotContactUpdateSource"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> DoNotContactUpdateSource
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerProfileHistoryFieldIndex.DoNotContactUpdateSource, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.DoNotContactUpdateSource, value); }
		}

		/// <summary> The IsSubscribed property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."IsSubscribed"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsSubscribed
		{
			get { return (Nullable<System.Boolean>)GetValue((int)CustomerProfileHistoryFieldIndex.IsSubscribed, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.IsSubscribed, value); }
		}

		/// <summary> The IncorrectPhoneNumberMarkedDate property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."IncorrectPhoneNumberMarkedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> IncorrectPhoneNumberMarkedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CustomerProfileHistoryFieldIndex.IncorrectPhoneNumberMarkedDate, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.IncorrectPhoneNumberMarkedDate, value); }
		}

		/// <summary> The LanguageBarrierMarkedDate property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."LanguageBarrierMarkedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LanguageBarrierMarkedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CustomerProfileHistoryFieldIndex.LanguageBarrierMarkedDate, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.LanguageBarrierMarkedDate, value); }
		}

		/// <summary> The PreferredContactType property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."PreferredContactType"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> PreferredContactType
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerProfileHistoryFieldIndex.PreferredContactType, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.PreferredContactType, value); }
		}

		/// <summary> The Mbi property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."Mbi"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Mbi
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.Mbi, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.Mbi, value); }
		}

		/// <summary> The AcesId property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."AcesId"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 128<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String AcesId
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.AcesId, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.AcesId, value); }
		}

		/// <summary> The PhoneHomeConsentId property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."PhoneHomeConsentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 PhoneHomeConsentId
		{
			get { return (System.Int64)GetValue((int)CustomerProfileHistoryFieldIndex.PhoneHomeConsentId, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.PhoneHomeConsentId, value); }
		}

		/// <summary> The PhoneHomeConsentUpdateDate property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."PhoneHomeConsentUpdateDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> PhoneHomeConsentUpdateDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CustomerProfileHistoryFieldIndex.PhoneHomeConsentUpdateDate, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.PhoneHomeConsentUpdateDate, value); }
		}

		/// <summary> The PhoneCellConsentId property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."PhoneCellConsentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 PhoneCellConsentId
		{
			get { return (System.Int64)GetValue((int)CustomerProfileHistoryFieldIndex.PhoneCellConsentId, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.PhoneCellConsentId, value); }
		}

		/// <summary> The PhoneCellConsentUpdateDate property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."PhoneCellConsentUpdateDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> PhoneCellConsentUpdateDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CustomerProfileHistoryFieldIndex.PhoneCellConsentUpdateDate, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.PhoneCellConsentUpdateDate, value); }
		}

		/// <summary> The PhoneOfficeConsentId property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."PhoneOfficeConsentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 PhoneOfficeConsentId
		{
			get { return (System.Int64)GetValue((int)CustomerProfileHistoryFieldIndex.PhoneOfficeConsentId, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.PhoneOfficeConsentId, value); }
		}

		/// <summary> The PhoneOfficeConsentUpdateDate property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."PhoneOfficeConsentUpdateDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> PhoneOfficeConsentUpdateDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CustomerProfileHistoryFieldIndex.PhoneOfficeConsentUpdateDate, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.PhoneOfficeConsentUpdateDate, value); }
		}

		/// <summary> The BillingMemberId property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."BillingMemberId"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 128<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BillingMemberId
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.BillingMemberId, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.BillingMemberId, value); }
		}

		/// <summary> The BillingMemberPlan property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."BillingMemberPlan"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String BillingMemberPlan
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.BillingMemberPlan, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.BillingMemberPlan, value); }
		}

		/// <summary> The BillingMemberPlanYear property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."BillingMemberPlanYear"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> BillingMemberPlanYear
		{
			get { return (Nullable<System.Int32>)GetValue((int)CustomerProfileHistoryFieldIndex.BillingMemberPlanYear, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.BillingMemberPlanYear, value); }
		}

		/// <summary> The EnableEmail property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."EnableEmail"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean EnableEmail
		{
			get { return (System.Boolean)GetValue((int)CustomerProfileHistoryFieldIndex.EnableEmail, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.EnableEmail, value); }
		}

		/// <summary> The EnableEmailUpdateDate property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."EnableEmailUpdateDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> EnableEmailUpdateDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CustomerProfileHistoryFieldIndex.EnableEmailUpdateDate, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.EnableEmailUpdateDate, value); }
		}

		/// <summary> The MergedCustomerId property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."MergedCustomerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MergedCustomerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerProfileHistoryFieldIndex.MergedCustomerId, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.MergedCustomerId, value); }
		}

		/// <summary> The EligibilityForYear property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."EligibilityForYear"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> EligibilityForYear
		{
			get { return (Nullable<System.Int32>)GetValue((int)CustomerProfileHistoryFieldIndex.EligibilityForYear, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.EligibilityForYear, value); }
		}

		/// <summary> The IsWarmTransfer property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."IsWarmTransfer"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsWarmTransfer
		{
			get { return (Nullable<System.Boolean>)GetValue((int)CustomerProfileHistoryFieldIndex.IsWarmTransfer, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.IsWarmTransfer, value); }
		}

		/// <summary> The WarmTransferYear property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."WarmTransferYear"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> WarmTransferYear
		{
			get { return (Nullable<System.Int32>)GetValue((int)CustomerProfileHistoryFieldIndex.WarmTransferYear, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.WarmTransferYear, value); }
		}

		/// <summary> The MemberUploadSourceId property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."MemberUploadSourceId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MemberUploadSourceId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerProfileHistoryFieldIndex.MemberUploadSourceId, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.MemberUploadSourceId, value); }
		}

		/// <summary> The ActivityTypeIsManual property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."ActivityTypeIsManual"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean ActivityTypeIsManual
		{
			get { return (System.Boolean)GetValue((int)CustomerProfileHistoryFieldIndex.ActivityTypeIsManual, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.ActivityTypeIsManual, value); }
		}

		/// <summary> The TargetedYear property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."TargetedYear"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> TargetedYear
		{
			get { return (Nullable<System.Int32>)GetValue((int)CustomerProfileHistoryFieldIndex.TargetedYear, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.TargetedYear, value); }
		}

		/// <summary> The IsTargeted property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."IsTargeted"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsTargeted
		{
			get { return (Nullable<System.Boolean>)GetValue((int)CustomerProfileHistoryFieldIndex.IsTargeted, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.IsTargeted, value); }
		}

		/// <summary> The ProductTypeId property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."ProductTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ProductTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CustomerProfileHistoryFieldIndex.ProductTypeId, false); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.ProductTypeId, value); }
		}

		/// <summary> The AcesClientId property of the Entity CustomerProfileHistory<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCustomerProfileHistory"."AcesClientId"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 250<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String AcesClientId
		{
			get { return (System.String)GetValue((int)CustomerProfileHistoryFieldIndex.AcesClientId, true); }
			set	{ SetValue((int)CustomerProfileHistoryFieldIndex.AcesClientId, value); }
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
					_eventCustomers.SetContainingEntityInfo(this, "CustomerProfileHistory");
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

		/// <summary> Gets / sets related entity of type 'CustomerProfileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerProfileEntity CustomerProfile
		{
			get
			{
				return _customerProfile;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerProfile(value);
				}
				else
				{
					if(value==null)
					{
						if(_customerProfile != null)
						{
							_customerProfile.UnsetRelatedEntity(this, "CustomerProfileHistory");
						}
					}
					else
					{
						if(_customerProfile!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerProfileHistory");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup___
		{
			get
			{
				return _lookup___;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup___(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup___ != null)
						{
							_lookup___.UnsetRelatedEntity(this, "CustomerProfileHistory___");
						}
					}
					else
					{
						if(_lookup___!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerProfileHistory___");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup_
		{
			get
			{
				return _lookup_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup_(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup_ != null)
						{
							_lookup_.UnsetRelatedEntity(this, "CustomerProfileHistory_");
						}
					}
					else
					{
						if(_lookup_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerProfileHistory_");
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
							_lookup.UnsetRelatedEntity(this, "CustomerProfileHistory");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerProfileHistory");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup__
		{
			get
			{
				return _lookup__;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup__(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup__ != null)
						{
							_lookup__.UnsetRelatedEntity(this, "CustomerProfileHistory__");
						}
					}
					else
					{
						if(_lookup__!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerProfileHistory__");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "CustomerProfileHistory");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CustomerProfileHistory");
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
			get { return (int)Falcon.Data.EntityType.CustomerProfileHistoryEntity; }
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
