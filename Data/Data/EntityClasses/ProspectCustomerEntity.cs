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
	/// Entity class which represents the entity 'ProspectCustomer'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ProspectCustomerEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CallQueueCustomerEntity> _callQueueCustomer;
		private EntityCollection<ClickConversionEntity> _clickConversion;
		private EntityCollection<ProspectCustomerCallEntity> _prospectCustomerCall;
		private EntityCollection<ProspectCustomerNotificationEntity> _prospectCustomerNotification;
		private EntityCollection<TempCartEntity> _tempCart;
		private EntityCollection<AccountEntity> _accountCollectionViaCallQueueCustomer;
		private EntityCollection<ActivityTypeEntity> _activityTypeCollectionViaCallQueueCustomer;
		private EntityCollection<CallQueueEntity> _callQueueCollectionViaCallQueueCustomer;
		private EntityCollection<CallQueueCriteriaEntity> _callQueueCriteriaCollectionViaCallQueueCustomer;
		private EntityCollection<CallsEntity> _callsCollectionViaProspectCustomerCall;
		private EntityCollection<CampaignEntity> _campaignCollectionViaCallQueueCustomer;
		private EntityCollection<ChargeCardEntity> _chargeCardCollectionViaTempCart;
		private EntityCollection<ClickLogEntity> _clickLogCollectionViaClickConversion;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCallQueueCustomer;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaClickConversion;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaTempCart;
		private EntityCollection<EligibilityEntity> _eligibilityCollectionViaTempCart;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaCallQueueCustomer;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaClickConversion;
		private EntityCollection<EventsEntity> _eventsCollectionViaCallQueueCustomer;
		private EntityCollection<LanguageEntity> _languageCollectionViaCallQueueCustomer;
		private EntityCollection<LookupEntity> _lookupCollectionViaCallQueueCustomer;
		private EntityCollection<NotesDetailsEntity> _notesDetailsCollectionViaCallQueueCustomer;
		private EntityCollection<NotificationEntity> _notificationCollectionViaProspectCustomerNotification;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueCustomer;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueCustomer__;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueCustomer_;
		private AfaffiliateCampaignMarketingMaterialEntity _afaffiliateCampaignMarketingMaterial;
		private CustomerProfileEntity _customerProfile;
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
			/// <summary>Member name AfaffiliateCampaignMarketingMaterial</summary>
			public static readonly string AfaffiliateCampaignMarketingMaterial = "AfaffiliateCampaignMarketingMaterial";
			/// <summary>Member name CustomerProfile</summary>
			public static readonly string CustomerProfile = "CustomerProfile";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name CallQueueCustomer</summary>
			public static readonly string CallQueueCustomer = "CallQueueCustomer";
			/// <summary>Member name ClickConversion</summary>
			public static readonly string ClickConversion = "ClickConversion";
			/// <summary>Member name ProspectCustomerCall</summary>
			public static readonly string ProspectCustomerCall = "ProspectCustomerCall";
			/// <summary>Member name ProspectCustomerNotification</summary>
			public static readonly string ProspectCustomerNotification = "ProspectCustomerNotification";
			/// <summary>Member name TempCart</summary>
			public static readonly string TempCart = "TempCart";
			/// <summary>Member name AccountCollectionViaCallQueueCustomer</summary>
			public static readonly string AccountCollectionViaCallQueueCustomer = "AccountCollectionViaCallQueueCustomer";
			/// <summary>Member name ActivityTypeCollectionViaCallQueueCustomer</summary>
			public static readonly string ActivityTypeCollectionViaCallQueueCustomer = "ActivityTypeCollectionViaCallQueueCustomer";
			/// <summary>Member name CallQueueCollectionViaCallQueueCustomer</summary>
			public static readonly string CallQueueCollectionViaCallQueueCustomer = "CallQueueCollectionViaCallQueueCustomer";
			/// <summary>Member name CallQueueCriteriaCollectionViaCallQueueCustomer</summary>
			public static readonly string CallQueueCriteriaCollectionViaCallQueueCustomer = "CallQueueCriteriaCollectionViaCallQueueCustomer";
			/// <summary>Member name CallsCollectionViaProspectCustomerCall</summary>
			public static readonly string CallsCollectionViaProspectCustomerCall = "CallsCollectionViaProspectCustomerCall";
			/// <summary>Member name CampaignCollectionViaCallQueueCustomer</summary>
			public static readonly string CampaignCollectionViaCallQueueCustomer = "CampaignCollectionViaCallQueueCustomer";
			/// <summary>Member name ChargeCardCollectionViaTempCart</summary>
			public static readonly string ChargeCardCollectionViaTempCart = "ChargeCardCollectionViaTempCart";
			/// <summary>Member name ClickLogCollectionViaClickConversion</summary>
			public static readonly string ClickLogCollectionViaClickConversion = "ClickLogCollectionViaClickConversion";
			/// <summary>Member name CustomerProfileCollectionViaCallQueueCustomer</summary>
			public static readonly string CustomerProfileCollectionViaCallQueueCustomer = "CustomerProfileCollectionViaCallQueueCustomer";
			/// <summary>Member name CustomerProfileCollectionViaClickConversion</summary>
			public static readonly string CustomerProfileCollectionViaClickConversion = "CustomerProfileCollectionViaClickConversion";
			/// <summary>Member name CustomerProfileCollectionViaTempCart</summary>
			public static readonly string CustomerProfileCollectionViaTempCart = "CustomerProfileCollectionViaTempCart";
			/// <summary>Member name EligibilityCollectionViaTempCart</summary>
			public static readonly string EligibilityCollectionViaTempCart = "EligibilityCollectionViaTempCart";
			/// <summary>Member name EventCustomersCollectionViaCallQueueCustomer</summary>
			public static readonly string EventCustomersCollectionViaCallQueueCustomer = "EventCustomersCollectionViaCallQueueCustomer";
			/// <summary>Member name EventCustomersCollectionViaClickConversion</summary>
			public static readonly string EventCustomersCollectionViaClickConversion = "EventCustomersCollectionViaClickConversion";
			/// <summary>Member name EventsCollectionViaCallQueueCustomer</summary>
			public static readonly string EventsCollectionViaCallQueueCustomer = "EventsCollectionViaCallQueueCustomer";
			/// <summary>Member name LanguageCollectionViaCallQueueCustomer</summary>
			public static readonly string LanguageCollectionViaCallQueueCustomer = "LanguageCollectionViaCallQueueCustomer";
			/// <summary>Member name LookupCollectionViaCallQueueCustomer</summary>
			public static readonly string LookupCollectionViaCallQueueCustomer = "LookupCollectionViaCallQueueCustomer";
			/// <summary>Member name NotesDetailsCollectionViaCallQueueCustomer</summary>
			public static readonly string NotesDetailsCollectionViaCallQueueCustomer = "NotesDetailsCollectionViaCallQueueCustomer";
			/// <summary>Member name NotificationCollectionViaProspectCustomerNotification</summary>
			public static readonly string NotificationCollectionViaProspectCustomerNotification = "NotificationCollectionViaProspectCustomerNotification";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueCustomer</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueCustomer = "OrganizationRoleUserCollectionViaCallQueueCustomer";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueCustomer__</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueCustomer__ = "OrganizationRoleUserCollectionViaCallQueueCustomer__";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueCustomer_</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueCustomer_ = "OrganizationRoleUserCollectionViaCallQueueCustomer_";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ProspectCustomerEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ProspectCustomerEntity():base("ProspectCustomerEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ProspectCustomerEntity(IEntityFields2 fields):base("ProspectCustomerEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ProspectCustomerEntity</param>
		public ProspectCustomerEntity(IValidator validator):base("ProspectCustomerEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="prospectCustomerId">PK value for ProspectCustomer which data should be fetched into this ProspectCustomer object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ProspectCustomerEntity(System.Int64 prospectCustomerId):base("ProspectCustomerEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ProspectCustomerId = prospectCustomerId;
		}

		/// <summary> CTor</summary>
		/// <param name="prospectCustomerId">PK value for ProspectCustomer which data should be fetched into this ProspectCustomer object</param>
		/// <param name="validator">The custom validator object for this ProspectCustomerEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ProspectCustomerEntity(System.Int64 prospectCustomerId, IValidator validator):base("ProspectCustomerEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ProspectCustomerId = prospectCustomerId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ProspectCustomerEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_callQueueCustomer = (EntityCollection<CallQueueCustomerEntity>)info.GetValue("_callQueueCustomer", typeof(EntityCollection<CallQueueCustomerEntity>));
				_clickConversion = (EntityCollection<ClickConversionEntity>)info.GetValue("_clickConversion", typeof(EntityCollection<ClickConversionEntity>));
				_prospectCustomerCall = (EntityCollection<ProspectCustomerCallEntity>)info.GetValue("_prospectCustomerCall", typeof(EntityCollection<ProspectCustomerCallEntity>));
				_prospectCustomerNotification = (EntityCollection<ProspectCustomerNotificationEntity>)info.GetValue("_prospectCustomerNotification", typeof(EntityCollection<ProspectCustomerNotificationEntity>));
				_tempCart = (EntityCollection<TempCartEntity>)info.GetValue("_tempCart", typeof(EntityCollection<TempCartEntity>));
				_accountCollectionViaCallQueueCustomer = (EntityCollection<AccountEntity>)info.GetValue("_accountCollectionViaCallQueueCustomer", typeof(EntityCollection<AccountEntity>));
				_activityTypeCollectionViaCallQueueCustomer = (EntityCollection<ActivityTypeEntity>)info.GetValue("_activityTypeCollectionViaCallQueueCustomer", typeof(EntityCollection<ActivityTypeEntity>));
				_callQueueCollectionViaCallQueueCustomer = (EntityCollection<CallQueueEntity>)info.GetValue("_callQueueCollectionViaCallQueueCustomer", typeof(EntityCollection<CallQueueEntity>));
				_callQueueCriteriaCollectionViaCallQueueCustomer = (EntityCollection<CallQueueCriteriaEntity>)info.GetValue("_callQueueCriteriaCollectionViaCallQueueCustomer", typeof(EntityCollection<CallQueueCriteriaEntity>));
				_callsCollectionViaProspectCustomerCall = (EntityCollection<CallsEntity>)info.GetValue("_callsCollectionViaProspectCustomerCall", typeof(EntityCollection<CallsEntity>));
				_campaignCollectionViaCallQueueCustomer = (EntityCollection<CampaignEntity>)info.GetValue("_campaignCollectionViaCallQueueCustomer", typeof(EntityCollection<CampaignEntity>));
				_chargeCardCollectionViaTempCart = (EntityCollection<ChargeCardEntity>)info.GetValue("_chargeCardCollectionViaTempCart", typeof(EntityCollection<ChargeCardEntity>));
				_clickLogCollectionViaClickConversion = (EntityCollection<ClickLogEntity>)info.GetValue("_clickLogCollectionViaClickConversion", typeof(EntityCollection<ClickLogEntity>));
				_customerProfileCollectionViaCallQueueCustomer = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCallQueueCustomer", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaClickConversion = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaClickConversion", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaTempCart = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaTempCart", typeof(EntityCollection<CustomerProfileEntity>));
				_eligibilityCollectionViaTempCart = (EntityCollection<EligibilityEntity>)info.GetValue("_eligibilityCollectionViaTempCart", typeof(EntityCollection<EligibilityEntity>));
				_eventCustomersCollectionViaCallQueueCustomer = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaCallQueueCustomer", typeof(EntityCollection<EventCustomersEntity>));
				_eventCustomersCollectionViaClickConversion = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaClickConversion", typeof(EntityCollection<EventCustomersEntity>));
				_eventsCollectionViaCallQueueCustomer = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaCallQueueCustomer", typeof(EntityCollection<EventsEntity>));
				_languageCollectionViaCallQueueCustomer = (EntityCollection<LanguageEntity>)info.GetValue("_languageCollectionViaCallQueueCustomer", typeof(EntityCollection<LanguageEntity>));
				_lookupCollectionViaCallQueueCustomer = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCallQueueCustomer", typeof(EntityCollection<LookupEntity>));
				_notesDetailsCollectionViaCallQueueCustomer = (EntityCollection<NotesDetailsEntity>)info.GetValue("_notesDetailsCollectionViaCallQueueCustomer", typeof(EntityCollection<NotesDetailsEntity>));
				_notificationCollectionViaProspectCustomerNotification = (EntityCollection<NotificationEntity>)info.GetValue("_notificationCollectionViaProspectCustomerNotification", typeof(EntityCollection<NotificationEntity>));
				_organizationRoleUserCollectionViaCallQueueCustomer = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueCustomer", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallQueueCustomer__ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueCustomer__", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallQueueCustomer_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueCustomer_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_afaffiliateCampaignMarketingMaterial = (AfaffiliateCampaignMarketingMaterialEntity)info.GetValue("_afaffiliateCampaignMarketingMaterial", typeof(AfaffiliateCampaignMarketingMaterialEntity));
				if(_afaffiliateCampaignMarketingMaterial!=null)
				{
					_afaffiliateCampaignMarketingMaterial.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_customerProfile = (CustomerProfileEntity)info.GetValue("_customerProfile", typeof(CustomerProfileEntity));
				if(_customerProfile!=null)
				{
					_customerProfile.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ProspectCustomerFieldIndex)fieldIndex)
			{
				case ProspectCustomerFieldIndex.CustomerId:
					DesetupSyncCustomerProfile(true, false);
					break;
				case ProspectCustomerFieldIndex.Source:
					DesetupSyncLookup(true, false);
					break;
				case ProspectCustomerFieldIndex.AffiliateCampaignMarketingMaterialId:
					DesetupSyncAfaffiliateCampaignMarketingMaterial(true, false);
					break;
				case ProspectCustomerFieldIndex.ContactedBy:
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
				case "AfaffiliateCampaignMarketingMaterial":
					this.AfaffiliateCampaignMarketingMaterial = (AfaffiliateCampaignMarketingMaterialEntity)entity;
					break;
				case "CustomerProfile":
					this.CustomerProfile = (CustomerProfileEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "CallQueueCustomer":
					this.CallQueueCustomer.Add((CallQueueCustomerEntity)entity);
					break;
				case "ClickConversion":
					this.ClickConversion.Add((ClickConversionEntity)entity);
					break;
				case "ProspectCustomerCall":
					this.ProspectCustomerCall.Add((ProspectCustomerCallEntity)entity);
					break;
				case "ProspectCustomerNotification":
					this.ProspectCustomerNotification.Add((ProspectCustomerNotificationEntity)entity);
					break;
				case "TempCart":
					this.TempCart.Add((TempCartEntity)entity);
					break;
				case "AccountCollectionViaCallQueueCustomer":
					this.AccountCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.AccountCollectionViaCallQueueCustomer.Add((AccountEntity)entity);
					this.AccountCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "ActivityTypeCollectionViaCallQueueCustomer":
					this.ActivityTypeCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.ActivityTypeCollectionViaCallQueueCustomer.Add((ActivityTypeEntity)entity);
					this.ActivityTypeCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "CallQueueCollectionViaCallQueueCustomer":
					this.CallQueueCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.CallQueueCollectionViaCallQueueCustomer.Add((CallQueueEntity)entity);
					this.CallQueueCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "CallQueueCriteriaCollectionViaCallQueueCustomer":
					this.CallQueueCriteriaCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.CallQueueCriteriaCollectionViaCallQueueCustomer.Add((CallQueueCriteriaEntity)entity);
					this.CallQueueCriteriaCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "CallsCollectionViaProspectCustomerCall":
					this.CallsCollectionViaProspectCustomerCall.IsReadOnly = false;
					this.CallsCollectionViaProspectCustomerCall.Add((CallsEntity)entity);
					this.CallsCollectionViaProspectCustomerCall.IsReadOnly = true;
					break;
				case "CampaignCollectionViaCallQueueCustomer":
					this.CampaignCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.CampaignCollectionViaCallQueueCustomer.Add((CampaignEntity)entity);
					this.CampaignCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "ChargeCardCollectionViaTempCart":
					this.ChargeCardCollectionViaTempCart.IsReadOnly = false;
					this.ChargeCardCollectionViaTempCart.Add((ChargeCardEntity)entity);
					this.ChargeCardCollectionViaTempCart.IsReadOnly = true;
					break;
				case "ClickLogCollectionViaClickConversion":
					this.ClickLogCollectionViaClickConversion.IsReadOnly = false;
					this.ClickLogCollectionViaClickConversion.Add((ClickLogEntity)entity);
					this.ClickLogCollectionViaClickConversion.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCallQueueCustomer":
					this.CustomerProfileCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.CustomerProfileCollectionViaCallQueueCustomer.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaClickConversion":
					this.CustomerProfileCollectionViaClickConversion.IsReadOnly = false;
					this.CustomerProfileCollectionViaClickConversion.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaClickConversion.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaTempCart":
					this.CustomerProfileCollectionViaTempCart.IsReadOnly = false;
					this.CustomerProfileCollectionViaTempCart.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaTempCart.IsReadOnly = true;
					break;
				case "EligibilityCollectionViaTempCart":
					this.EligibilityCollectionViaTempCart.IsReadOnly = false;
					this.EligibilityCollectionViaTempCart.Add((EligibilityEntity)entity);
					this.EligibilityCollectionViaTempCart.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaCallQueueCustomer":
					this.EventCustomersCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.EventCustomersCollectionViaCallQueueCustomer.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaClickConversion":
					this.EventCustomersCollectionViaClickConversion.IsReadOnly = false;
					this.EventCustomersCollectionViaClickConversion.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaClickConversion.IsReadOnly = true;
					break;
				case "EventsCollectionViaCallQueueCustomer":
					this.EventsCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.EventsCollectionViaCallQueueCustomer.Add((EventsEntity)entity);
					this.EventsCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "LanguageCollectionViaCallQueueCustomer":
					this.LanguageCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.LanguageCollectionViaCallQueueCustomer.Add((LanguageEntity)entity);
					this.LanguageCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "LookupCollectionViaCallQueueCustomer":
					this.LookupCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.LookupCollectionViaCallQueueCustomer.Add((LookupEntity)entity);
					this.LookupCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "NotesDetailsCollectionViaCallQueueCustomer":
					this.NotesDetailsCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.NotesDetailsCollectionViaCallQueueCustomer.Add((NotesDetailsEntity)entity);
					this.NotesDetailsCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "NotificationCollectionViaProspectCustomerNotification":
					this.NotificationCollectionViaProspectCustomerNotification.IsReadOnly = false;
					this.NotificationCollectionViaProspectCustomerNotification.Add((NotificationEntity)entity);
					this.NotificationCollectionViaProspectCustomerNotification.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer":
					this.OrganizationRoleUserCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueCustomer.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer__":
					this.OrganizationRoleUserCollectionViaCallQueueCustomer__.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueCustomer__.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueCustomer__.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer_":
					this.OrganizationRoleUserCollectionViaCallQueueCustomer_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueCustomer_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueCustomer_.IsReadOnly = true;
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
			return ProspectCustomerEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "AfaffiliateCampaignMarketingMaterial":
					toReturn.Add(ProspectCustomerEntity.Relations.AfaffiliateCampaignMarketingMaterialEntityUsingAffiliateCampaignMarketingMaterialId);
					break;
				case "CustomerProfile":
					toReturn.Add(ProspectCustomerEntity.Relations.CustomerProfileEntityUsingCustomerId);
					break;
				case "Lookup":
					toReturn.Add(ProspectCustomerEntity.Relations.LookupEntityUsingSource);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(ProspectCustomerEntity.Relations.OrganizationRoleUserEntityUsingContactedBy);
					break;
				case "CallQueueCustomer":
					toReturn.Add(ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId);
					break;
				case "ClickConversion":
					toReturn.Add(ProspectCustomerEntity.Relations.ClickConversionEntityUsingProspectCustomerId);
					break;
				case "ProspectCustomerCall":
					toReturn.Add(ProspectCustomerEntity.Relations.ProspectCustomerCallEntityUsingProspectCustomerId);
					break;
				case "ProspectCustomerNotification":
					toReturn.Add(ProspectCustomerEntity.Relations.ProspectCustomerNotificationEntityUsingProspectCustomerId);
					break;
				case "TempCart":
					toReturn.Add(ProspectCustomerEntity.Relations.TempCartEntityUsingProspectCustomerId);
					break;
				case "AccountCollectionViaCallQueueCustomer":
					toReturn.Add(ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId, "ProspectCustomerEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.AccountEntityUsingHealthPlanId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "ActivityTypeCollectionViaCallQueueCustomer":
					toReturn.Add(ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId, "ProspectCustomerEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.ActivityTypeEntityUsingActivityId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCollectionViaCallQueueCustomer":
					toReturn.Add(ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId, "ProspectCustomerEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CallQueueEntityUsingCallQueueId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCriteriaCollectionViaCallQueueCustomer":
					toReturn.Add(ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId, "ProspectCustomerEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CallQueueCriteriaEntityUsingCallQueueCriteriaId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CallsCollectionViaProspectCustomerCall":
					toReturn.Add(ProspectCustomerEntity.Relations.ProspectCustomerCallEntityUsingProspectCustomerId, "ProspectCustomerEntity__", "ProspectCustomerCall_", JoinHint.None);
					toReturn.Add(ProspectCustomerCallEntity.Relations.CallsEntityUsingCallId, "ProspectCustomerCall_", string.Empty, JoinHint.None);
					break;
				case "CampaignCollectionViaCallQueueCustomer":
					toReturn.Add(ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId, "ProspectCustomerEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CampaignEntityUsingCampaignId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "ChargeCardCollectionViaTempCart":
					toReturn.Add(ProspectCustomerEntity.Relations.TempCartEntityUsingProspectCustomerId, "ProspectCustomerEntity__", "TempCart_", JoinHint.None);
					toReturn.Add(TempCartEntity.Relations.ChargeCardEntityUsingChargeCardId, "TempCart_", string.Empty, JoinHint.None);
					break;
				case "ClickLogCollectionViaClickConversion":
					toReturn.Add(ProspectCustomerEntity.Relations.ClickConversionEntityUsingProspectCustomerId, "ProspectCustomerEntity__", "ClickConversion_", JoinHint.None);
					toReturn.Add(ClickConversionEntity.Relations.ClickLogEntityUsingClickId, "ClickConversion_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCallQueueCustomer":
					toReturn.Add(ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId, "ProspectCustomerEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CustomerProfileEntityUsingCustomerId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaClickConversion":
					toReturn.Add(ProspectCustomerEntity.Relations.ClickConversionEntityUsingProspectCustomerId, "ProspectCustomerEntity__", "ClickConversion_", JoinHint.None);
					toReturn.Add(ClickConversionEntity.Relations.CustomerProfileEntityUsingCustomerId, "ClickConversion_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaTempCart":
					toReturn.Add(ProspectCustomerEntity.Relations.TempCartEntityUsingProspectCustomerId, "ProspectCustomerEntity__", "TempCart_", JoinHint.None);
					toReturn.Add(TempCartEntity.Relations.CustomerProfileEntityUsingCustomerId, "TempCart_", string.Empty, JoinHint.None);
					break;
				case "EligibilityCollectionViaTempCart":
					toReturn.Add(ProspectCustomerEntity.Relations.TempCartEntityUsingProspectCustomerId, "ProspectCustomerEntity__", "TempCart_", JoinHint.None);
					toReturn.Add(TempCartEntity.Relations.EligibilityEntityUsingEligibilityId, "TempCart_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaCallQueueCustomer":
					toReturn.Add(ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId, "ProspectCustomerEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.EventCustomersEntityUsingEventCustomerId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaClickConversion":
					toReturn.Add(ProspectCustomerEntity.Relations.ClickConversionEntityUsingProspectCustomerId, "ProspectCustomerEntity__", "ClickConversion_", JoinHint.None);
					toReturn.Add(ClickConversionEntity.Relations.EventCustomersEntityUsingEventCustomerId, "ClickConversion_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaCallQueueCustomer":
					toReturn.Add(ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId, "ProspectCustomerEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.EventsEntityUsingEventId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "LanguageCollectionViaCallQueueCustomer":
					toReturn.Add(ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId, "ProspectCustomerEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.LanguageEntityUsingLanguageId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCallQueueCustomer":
					toReturn.Add(ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId, "ProspectCustomerEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.LookupEntityUsingDoNotContactUpdateSource, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "NotesDetailsCollectionViaCallQueueCustomer":
					toReturn.Add(ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId, "ProspectCustomerEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.NotesDetailsEntityUsingNotesId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "NotificationCollectionViaProspectCustomerNotification":
					toReturn.Add(ProspectCustomerEntity.Relations.ProspectCustomerNotificationEntityUsingProspectCustomerId, "ProspectCustomerEntity__", "ProspectCustomerNotification_", JoinHint.None);
					toReturn.Add(ProspectCustomerNotificationEntity.Relations.NotificationEntityUsingNotificationId, "ProspectCustomerNotification_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer":
					toReturn.Add(ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId, "ProspectCustomerEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer__":
					toReturn.Add(ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId, "ProspectCustomerEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer_":
					toReturn.Add(ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId, "ProspectCustomerEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "CallQueueCustomer_", string.Empty, JoinHint.None);
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
				case "AfaffiliateCampaignMarketingMaterial":
					SetupSyncAfaffiliateCampaignMarketingMaterial(relatedEntity);
					break;
				case "CustomerProfile":
					SetupSyncCustomerProfile(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "CallQueueCustomer":
					this.CallQueueCustomer.Add((CallQueueCustomerEntity)relatedEntity);
					break;
				case "ClickConversion":
					this.ClickConversion.Add((ClickConversionEntity)relatedEntity);
					break;
				case "ProspectCustomerCall":
					this.ProspectCustomerCall.Add((ProspectCustomerCallEntity)relatedEntity);
					break;
				case "ProspectCustomerNotification":
					this.ProspectCustomerNotification.Add((ProspectCustomerNotificationEntity)relatedEntity);
					break;
				case "TempCart":
					this.TempCart.Add((TempCartEntity)relatedEntity);
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
				case "AfaffiliateCampaignMarketingMaterial":
					DesetupSyncAfaffiliateCampaignMarketingMaterial(false, true);
					break;
				case "CustomerProfile":
					DesetupSyncCustomerProfile(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "CallQueueCustomer":
					base.PerformRelatedEntityRemoval(this.CallQueueCustomer, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ClickConversion":
					base.PerformRelatedEntityRemoval(this.ClickConversion, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ProspectCustomerCall":
					base.PerformRelatedEntityRemoval(this.ProspectCustomerCall, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ProspectCustomerNotification":
					base.PerformRelatedEntityRemoval(this.ProspectCustomerNotification, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "TempCart":
					base.PerformRelatedEntityRemoval(this.TempCart, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_afaffiliateCampaignMarketingMaterial!=null)
			{
				toReturn.Add(_afaffiliateCampaignMarketingMaterial);
			}
			if(_customerProfile!=null)
			{
				toReturn.Add(_customerProfile);
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
			toReturn.Add(this.CallQueueCustomer);
			toReturn.Add(this.ClickConversion);
			toReturn.Add(this.ProspectCustomerCall);
			toReturn.Add(this.ProspectCustomerNotification);
			toReturn.Add(this.TempCart);

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
				info.AddValue("_callQueueCustomer", ((_callQueueCustomer!=null) && (_callQueueCustomer.Count>0) && !this.MarkedForDeletion)?_callQueueCustomer:null);
				info.AddValue("_clickConversion", ((_clickConversion!=null) && (_clickConversion.Count>0) && !this.MarkedForDeletion)?_clickConversion:null);
				info.AddValue("_prospectCustomerCall", ((_prospectCustomerCall!=null) && (_prospectCustomerCall.Count>0) && !this.MarkedForDeletion)?_prospectCustomerCall:null);
				info.AddValue("_prospectCustomerNotification", ((_prospectCustomerNotification!=null) && (_prospectCustomerNotification.Count>0) && !this.MarkedForDeletion)?_prospectCustomerNotification:null);
				info.AddValue("_tempCart", ((_tempCart!=null) && (_tempCart.Count>0) && !this.MarkedForDeletion)?_tempCart:null);
				info.AddValue("_accountCollectionViaCallQueueCustomer", ((_accountCollectionViaCallQueueCustomer!=null) && (_accountCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_accountCollectionViaCallQueueCustomer:null);
				info.AddValue("_activityTypeCollectionViaCallQueueCustomer", ((_activityTypeCollectionViaCallQueueCustomer!=null) && (_activityTypeCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_activityTypeCollectionViaCallQueueCustomer:null);
				info.AddValue("_callQueueCollectionViaCallQueueCustomer", ((_callQueueCollectionViaCallQueueCustomer!=null) && (_callQueueCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_callQueueCollectionViaCallQueueCustomer:null);
				info.AddValue("_callQueueCriteriaCollectionViaCallQueueCustomer", ((_callQueueCriteriaCollectionViaCallQueueCustomer!=null) && (_callQueueCriteriaCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_callQueueCriteriaCollectionViaCallQueueCustomer:null);
				info.AddValue("_callsCollectionViaProspectCustomerCall", ((_callsCollectionViaProspectCustomerCall!=null) && (_callsCollectionViaProspectCustomerCall.Count>0) && !this.MarkedForDeletion)?_callsCollectionViaProspectCustomerCall:null);
				info.AddValue("_campaignCollectionViaCallQueueCustomer", ((_campaignCollectionViaCallQueueCustomer!=null) && (_campaignCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_campaignCollectionViaCallQueueCustomer:null);
				info.AddValue("_chargeCardCollectionViaTempCart", ((_chargeCardCollectionViaTempCart!=null) && (_chargeCardCollectionViaTempCart.Count>0) && !this.MarkedForDeletion)?_chargeCardCollectionViaTempCart:null);
				info.AddValue("_clickLogCollectionViaClickConversion", ((_clickLogCollectionViaClickConversion!=null) && (_clickLogCollectionViaClickConversion.Count>0) && !this.MarkedForDeletion)?_clickLogCollectionViaClickConversion:null);
				info.AddValue("_customerProfileCollectionViaCallQueueCustomer", ((_customerProfileCollectionViaCallQueueCustomer!=null) && (_customerProfileCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCallQueueCustomer:null);
				info.AddValue("_customerProfileCollectionViaClickConversion", ((_customerProfileCollectionViaClickConversion!=null) && (_customerProfileCollectionViaClickConversion.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaClickConversion:null);
				info.AddValue("_customerProfileCollectionViaTempCart", ((_customerProfileCollectionViaTempCart!=null) && (_customerProfileCollectionViaTempCart.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaTempCart:null);
				info.AddValue("_eligibilityCollectionViaTempCart", ((_eligibilityCollectionViaTempCart!=null) && (_eligibilityCollectionViaTempCart.Count>0) && !this.MarkedForDeletion)?_eligibilityCollectionViaTempCart:null);
				info.AddValue("_eventCustomersCollectionViaCallQueueCustomer", ((_eventCustomersCollectionViaCallQueueCustomer!=null) && (_eventCustomersCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaCallQueueCustomer:null);
				info.AddValue("_eventCustomersCollectionViaClickConversion", ((_eventCustomersCollectionViaClickConversion!=null) && (_eventCustomersCollectionViaClickConversion.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaClickConversion:null);
				info.AddValue("_eventsCollectionViaCallQueueCustomer", ((_eventsCollectionViaCallQueueCustomer!=null) && (_eventsCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaCallQueueCustomer:null);
				info.AddValue("_languageCollectionViaCallQueueCustomer", ((_languageCollectionViaCallQueueCustomer!=null) && (_languageCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_languageCollectionViaCallQueueCustomer:null);
				info.AddValue("_lookupCollectionViaCallQueueCustomer", ((_lookupCollectionViaCallQueueCustomer!=null) && (_lookupCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCallQueueCustomer:null);
				info.AddValue("_notesDetailsCollectionViaCallQueueCustomer", ((_notesDetailsCollectionViaCallQueueCustomer!=null) && (_notesDetailsCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_notesDetailsCollectionViaCallQueueCustomer:null);
				info.AddValue("_notificationCollectionViaProspectCustomerNotification", ((_notificationCollectionViaProspectCustomerNotification!=null) && (_notificationCollectionViaProspectCustomerNotification.Count>0) && !this.MarkedForDeletion)?_notificationCollectionViaProspectCustomerNotification:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueCustomer", ((_organizationRoleUserCollectionViaCallQueueCustomer!=null) && (_organizationRoleUserCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueCustomer:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueCustomer__", ((_organizationRoleUserCollectionViaCallQueueCustomer__!=null) && (_organizationRoleUserCollectionViaCallQueueCustomer__.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueCustomer__:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueCustomer_", ((_organizationRoleUserCollectionViaCallQueueCustomer_!=null) && (_organizationRoleUserCollectionViaCallQueueCustomer_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueCustomer_:null);
				info.AddValue("_afaffiliateCampaignMarketingMaterial", (!this.MarkedForDeletion?_afaffiliateCampaignMarketingMaterial:null));
				info.AddValue("_customerProfile", (!this.MarkedForDeletion?_customerProfile:null));
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
		public bool TestOriginalFieldValueForNull(ProspectCustomerFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ProspectCustomerFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ProspectCustomerRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCustomerFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ClickConversion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoClickConversion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ClickConversionFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectCustomerCall' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectCustomerCall()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerCallFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectCustomerNotification' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectCustomerNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerNotificationFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TempCart' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTempCart()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TempCartFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AccountCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId, "ProspectCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ActivityType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActivityTypeCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ActivityTypeCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId, "ProspectCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId, "ProspectCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCriteria' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCriteriaCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCriteriaCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId, "ProspectCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Calls' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallsCollectionViaProspectCustomerCall()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallsCollectionViaProspectCustomerCall"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId, "ProspectCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Campaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CampaignCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId, "ProspectCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ChargeCard' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoChargeCardCollectionViaTempCart()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ChargeCardCollectionViaTempCart"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId, "ProspectCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ClickLog' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoClickLogCollectionViaClickConversion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ClickLogCollectionViaClickConversion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId, "ProspectCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId, "ProspectCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaClickConversion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaClickConversion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId, "ProspectCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaTempCart()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaTempCart"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId, "ProspectCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Eligibility' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEligibilityCollectionViaTempCart()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EligibilityCollectionViaTempCart"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId, "ProspectCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId, "ProspectCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaClickConversion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaClickConversion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId, "ProspectCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId, "ProspectCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Language' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLanguageCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LanguageCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId, "ProspectCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId, "ProspectCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'NotesDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotesDetailsCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("NotesDetailsCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId, "ProspectCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Notification' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotificationCollectionViaProspectCustomerNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("NotificationCollectionViaProspectCustomerNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId, "ProspectCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId, "ProspectCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueCustomer__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueCustomer__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId, "ProspectCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueCustomer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueCustomer_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId, "ProspectCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'AfaffiliateCampaignMarketingMaterial' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfaffiliateCampaignMarketingMaterial()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfaffiliateCampaignMarketingMaterialFields.AffiliateCampaignMarketingMaterialId, null, ComparisonOperator.Equal, this.AffiliateCampaignMarketingMaterialId));
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
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.Source));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.ContactedBy));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ProspectCustomerEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._callQueueCustomer);
			collectionsQueue.Enqueue(this._clickConversion);
			collectionsQueue.Enqueue(this._prospectCustomerCall);
			collectionsQueue.Enqueue(this._prospectCustomerNotification);
			collectionsQueue.Enqueue(this._tempCart);
			collectionsQueue.Enqueue(this._accountCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._activityTypeCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._callQueueCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._callQueueCriteriaCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._callsCollectionViaProspectCustomerCall);
			collectionsQueue.Enqueue(this._campaignCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._chargeCardCollectionViaTempCart);
			collectionsQueue.Enqueue(this._clickLogCollectionViaClickConversion);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaClickConversion);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaTempCart);
			collectionsQueue.Enqueue(this._eligibilityCollectionViaTempCart);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaClickConversion);
			collectionsQueue.Enqueue(this._eventsCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._languageCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._lookupCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._notesDetailsCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._notificationCollectionViaProspectCustomerNotification);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueCustomer__);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueCustomer_);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._callQueueCustomer = (EntityCollection<CallQueueCustomerEntity>) collectionsQueue.Dequeue();
			this._clickConversion = (EntityCollection<ClickConversionEntity>) collectionsQueue.Dequeue();
			this._prospectCustomerCall = (EntityCollection<ProspectCustomerCallEntity>) collectionsQueue.Dequeue();
			this._prospectCustomerNotification = (EntityCollection<ProspectCustomerNotificationEntity>) collectionsQueue.Dequeue();
			this._tempCart = (EntityCollection<TempCartEntity>) collectionsQueue.Dequeue();
			this._accountCollectionViaCallQueueCustomer = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._activityTypeCollectionViaCallQueueCustomer = (EntityCollection<ActivityTypeEntity>) collectionsQueue.Dequeue();
			this._callQueueCollectionViaCallQueueCustomer = (EntityCollection<CallQueueEntity>) collectionsQueue.Dequeue();
			this._callQueueCriteriaCollectionViaCallQueueCustomer = (EntityCollection<CallQueueCriteriaEntity>) collectionsQueue.Dequeue();
			this._callsCollectionViaProspectCustomerCall = (EntityCollection<CallsEntity>) collectionsQueue.Dequeue();
			this._campaignCollectionViaCallQueueCustomer = (EntityCollection<CampaignEntity>) collectionsQueue.Dequeue();
			this._chargeCardCollectionViaTempCart = (EntityCollection<ChargeCardEntity>) collectionsQueue.Dequeue();
			this._clickLogCollectionViaClickConversion = (EntityCollection<ClickLogEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCallQueueCustomer = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaClickConversion = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaTempCart = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._eligibilityCollectionViaTempCart = (EntityCollection<EligibilityEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaCallQueueCustomer = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaClickConversion = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaCallQueueCustomer = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._languageCollectionViaCallQueueCustomer = (EntityCollection<LanguageEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCallQueueCustomer = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._notesDetailsCollectionViaCallQueueCustomer = (EntityCollection<NotesDetailsEntity>) collectionsQueue.Dequeue();
			this._notificationCollectionViaProspectCustomerNotification = (EntityCollection<NotificationEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueCustomer = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueCustomer__ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueCustomer_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._callQueueCustomer != null)
			{
				return true;
			}
			if (this._clickConversion != null)
			{
				return true;
			}
			if (this._prospectCustomerCall != null)
			{
				return true;
			}
			if (this._prospectCustomerNotification != null)
			{
				return true;
			}
			if (this._tempCart != null)
			{
				return true;
			}
			if (this._accountCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._activityTypeCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._callQueueCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._callQueueCriteriaCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._callsCollectionViaProspectCustomerCall != null)
			{
				return true;
			}
			if (this._campaignCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._chargeCardCollectionViaTempCart != null)
			{
				return true;
			}
			if (this._clickLogCollectionViaClickConversion != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaClickConversion != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaTempCart != null)
			{
				return true;
			}
			if (this._eligibilityCollectionViaTempCart != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaClickConversion != null)
			{
				return true;
			}
			if (this._eventsCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._languageCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._notesDetailsCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._notificationCollectionViaProspectCustomerNotification != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueCustomer__ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueCustomer_ != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ClickConversionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClickConversionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectCustomerCallEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerCallEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectCustomerNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerNotificationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TempCartEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TempCartEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCriteriaEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ChargeCardEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChargeCardEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ClickLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClickLogEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EligibilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EligibilityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
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
			toReturn.Add("AfaffiliateCampaignMarketingMaterial", _afaffiliateCampaignMarketingMaterial);
			toReturn.Add("CustomerProfile", _customerProfile);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("CallQueueCustomer", _callQueueCustomer);
			toReturn.Add("ClickConversion", _clickConversion);
			toReturn.Add("ProspectCustomerCall", _prospectCustomerCall);
			toReturn.Add("ProspectCustomerNotification", _prospectCustomerNotification);
			toReturn.Add("TempCart", _tempCart);
			toReturn.Add("AccountCollectionViaCallQueueCustomer", _accountCollectionViaCallQueueCustomer);
			toReturn.Add("ActivityTypeCollectionViaCallQueueCustomer", _activityTypeCollectionViaCallQueueCustomer);
			toReturn.Add("CallQueueCollectionViaCallQueueCustomer", _callQueueCollectionViaCallQueueCustomer);
			toReturn.Add("CallQueueCriteriaCollectionViaCallQueueCustomer", _callQueueCriteriaCollectionViaCallQueueCustomer);
			toReturn.Add("CallsCollectionViaProspectCustomerCall", _callsCollectionViaProspectCustomerCall);
			toReturn.Add("CampaignCollectionViaCallQueueCustomer", _campaignCollectionViaCallQueueCustomer);
			toReturn.Add("ChargeCardCollectionViaTempCart", _chargeCardCollectionViaTempCart);
			toReturn.Add("ClickLogCollectionViaClickConversion", _clickLogCollectionViaClickConversion);
			toReturn.Add("CustomerProfileCollectionViaCallQueueCustomer", _customerProfileCollectionViaCallQueueCustomer);
			toReturn.Add("CustomerProfileCollectionViaClickConversion", _customerProfileCollectionViaClickConversion);
			toReturn.Add("CustomerProfileCollectionViaTempCart", _customerProfileCollectionViaTempCart);
			toReturn.Add("EligibilityCollectionViaTempCart", _eligibilityCollectionViaTempCart);
			toReturn.Add("EventCustomersCollectionViaCallQueueCustomer", _eventCustomersCollectionViaCallQueueCustomer);
			toReturn.Add("EventCustomersCollectionViaClickConversion", _eventCustomersCollectionViaClickConversion);
			toReturn.Add("EventsCollectionViaCallQueueCustomer", _eventsCollectionViaCallQueueCustomer);
			toReturn.Add("LanguageCollectionViaCallQueueCustomer", _languageCollectionViaCallQueueCustomer);
			toReturn.Add("LookupCollectionViaCallQueueCustomer", _lookupCollectionViaCallQueueCustomer);
			toReturn.Add("NotesDetailsCollectionViaCallQueueCustomer", _notesDetailsCollectionViaCallQueueCustomer);
			toReturn.Add("NotificationCollectionViaProspectCustomerNotification", _notificationCollectionViaProspectCustomerNotification);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueCustomer", _organizationRoleUserCollectionViaCallQueueCustomer);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueCustomer__", _organizationRoleUserCollectionViaCallQueueCustomer__);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueCustomer_", _organizationRoleUserCollectionViaCallQueueCustomer_);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_callQueueCustomer!=null)
			{
				_callQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_clickConversion!=null)
			{
				_clickConversion.ActiveContext = base.ActiveContext;
			}
			if(_prospectCustomerCall!=null)
			{
				_prospectCustomerCall.ActiveContext = base.ActiveContext;
			}
			if(_prospectCustomerNotification!=null)
			{
				_prospectCustomerNotification.ActiveContext = base.ActiveContext;
			}
			if(_tempCart!=null)
			{
				_tempCart.ActiveContext = base.ActiveContext;
			}
			if(_accountCollectionViaCallQueueCustomer!=null)
			{
				_accountCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_activityTypeCollectionViaCallQueueCustomer!=null)
			{
				_activityTypeCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCollectionViaCallQueueCustomer!=null)
			{
				_callQueueCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCriteriaCollectionViaCallQueueCustomer!=null)
			{
				_callQueueCriteriaCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_callsCollectionViaProspectCustomerCall!=null)
			{
				_callsCollectionViaProspectCustomerCall.ActiveContext = base.ActiveContext;
			}
			if(_campaignCollectionViaCallQueueCustomer!=null)
			{
				_campaignCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_chargeCardCollectionViaTempCart!=null)
			{
				_chargeCardCollectionViaTempCart.ActiveContext = base.ActiveContext;
			}
			if(_clickLogCollectionViaClickConversion!=null)
			{
				_clickLogCollectionViaClickConversion.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCallQueueCustomer!=null)
			{
				_customerProfileCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaClickConversion!=null)
			{
				_customerProfileCollectionViaClickConversion.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaTempCart!=null)
			{
				_customerProfileCollectionViaTempCart.ActiveContext = base.ActiveContext;
			}
			if(_eligibilityCollectionViaTempCart!=null)
			{
				_eligibilityCollectionViaTempCart.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaCallQueueCustomer!=null)
			{
				_eventCustomersCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaClickConversion!=null)
			{
				_eventCustomersCollectionViaClickConversion.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaCallQueueCustomer!=null)
			{
				_eventsCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_languageCollectionViaCallQueueCustomer!=null)
			{
				_languageCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCallQueueCustomer!=null)
			{
				_lookupCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_notesDetailsCollectionViaCallQueueCustomer!=null)
			{
				_notesDetailsCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_notificationCollectionViaProspectCustomerNotification!=null)
			{
				_notificationCollectionViaProspectCustomerNotification.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueCustomer!=null)
			{
				_organizationRoleUserCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueCustomer__!=null)
			{
				_organizationRoleUserCollectionViaCallQueueCustomer__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueCustomer_!=null)
			{
				_organizationRoleUserCollectionViaCallQueueCustomer_.ActiveContext = base.ActiveContext;
			}
			if(_afaffiliateCampaignMarketingMaterial!=null)
			{
				_afaffiliateCampaignMarketingMaterial.ActiveContext = base.ActiveContext;
			}
			if(_customerProfile!=null)
			{
				_customerProfile.ActiveContext = base.ActiveContext;
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

			_callQueueCustomer = null;
			_clickConversion = null;
			_prospectCustomerCall = null;
			_prospectCustomerNotification = null;
			_tempCart = null;
			_accountCollectionViaCallQueueCustomer = null;
			_activityTypeCollectionViaCallQueueCustomer = null;
			_callQueueCollectionViaCallQueueCustomer = null;
			_callQueueCriteriaCollectionViaCallQueueCustomer = null;
			_callsCollectionViaProspectCustomerCall = null;
			_campaignCollectionViaCallQueueCustomer = null;
			_chargeCardCollectionViaTempCart = null;
			_clickLogCollectionViaClickConversion = null;
			_customerProfileCollectionViaCallQueueCustomer = null;
			_customerProfileCollectionViaClickConversion = null;
			_customerProfileCollectionViaTempCart = null;
			_eligibilityCollectionViaTempCart = null;
			_eventCustomersCollectionViaCallQueueCustomer = null;
			_eventCustomersCollectionViaClickConversion = null;
			_eventsCollectionViaCallQueueCustomer = null;
			_languageCollectionViaCallQueueCustomer = null;
			_lookupCollectionViaCallQueueCustomer = null;
			_notesDetailsCollectionViaCallQueueCustomer = null;
			_notificationCollectionViaProspectCustomerNotification = null;
			_organizationRoleUserCollectionViaCallQueueCustomer = null;
			_organizationRoleUserCollectionViaCallQueueCustomer__ = null;
			_organizationRoleUserCollectionViaCallQueueCustomer_ = null;
			_afaffiliateCampaignMarketingMaterial = null;
			_customerProfile = null;
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

			_fieldsCustomProperties.Add("ProspectCustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FirstName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ZipCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallbackNo", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Address1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Address2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("City", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("State", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Dob", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Email", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Phone2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsConverted", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateConverted", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Source", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Tag", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AffiliateCampaignMarketingMaterialId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MarketingSource", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsQueuedForCallBack", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SourceCodeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IncomingPhoneLine", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProspectListId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Gender", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Status", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsContacted", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ContactedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ContactedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallBackRequestedOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallBackRequestedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TagUpdateDate", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _afaffiliateCampaignMarketingMaterial</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAfaffiliateCampaignMarketingMaterial(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _afaffiliateCampaignMarketingMaterial, new PropertyChangedEventHandler( OnAfaffiliateCampaignMarketingMaterialPropertyChanged ), "AfaffiliateCampaignMarketingMaterial", ProspectCustomerEntity.Relations.AfaffiliateCampaignMarketingMaterialEntityUsingAffiliateCampaignMarketingMaterialId, true, signalRelatedEntity, "ProspectCustomer", resetFKFields, new int[] { (int)ProspectCustomerFieldIndex.AffiliateCampaignMarketingMaterialId } );		
			_afaffiliateCampaignMarketingMaterial = null;
		}

		/// <summary> setups the sync logic for member _afaffiliateCampaignMarketingMaterial</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAfaffiliateCampaignMarketingMaterial(IEntity2 relatedEntity)
		{
			if(_afaffiliateCampaignMarketingMaterial!=relatedEntity)
			{
				DesetupSyncAfaffiliateCampaignMarketingMaterial(true, true);
				_afaffiliateCampaignMarketingMaterial = (AfaffiliateCampaignMarketingMaterialEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _afaffiliateCampaignMarketingMaterial, new PropertyChangedEventHandler( OnAfaffiliateCampaignMarketingMaterialPropertyChanged ), "AfaffiliateCampaignMarketingMaterial", ProspectCustomerEntity.Relations.AfaffiliateCampaignMarketingMaterialEntityUsingAffiliateCampaignMarketingMaterialId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAfaffiliateCampaignMarketingMaterialPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _customerProfile</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerProfile(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", ProspectCustomerEntity.Relations.CustomerProfileEntityUsingCustomerId, true, signalRelatedEntity, "ProspectCustomer", resetFKFields, new int[] { (int)ProspectCustomerFieldIndex.CustomerId } );		
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
				base.PerformSetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", ProspectCustomerEntity.Relations.CustomerProfileEntityUsingCustomerId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _lookup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", ProspectCustomerEntity.Relations.LookupEntityUsingSource, true, signalRelatedEntity, "ProspectCustomer", resetFKFields, new int[] { (int)ProspectCustomerFieldIndex.Source } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", ProspectCustomerEntity.Relations.LookupEntityUsingSource, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", ProspectCustomerEntity.Relations.OrganizationRoleUserEntityUsingContactedBy, true, signalRelatedEntity, "ProspectCustomer", resetFKFields, new int[] { (int)ProspectCustomerFieldIndex.ContactedBy } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", ProspectCustomerEntity.Relations.OrganizationRoleUserEntityUsingContactedBy, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this ProspectCustomerEntity</param>
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
		public  static ProspectCustomerRelations Relations
		{
			get	{ return new ProspectCustomerRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCustomer
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallQueueCustomer")[0], (int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.CallQueueCustomerEntity, 0, null, null, null, null, "CallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ClickConversion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathClickConversion
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ClickConversionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClickConversionEntityFactory))),
					(IEntityRelation)GetRelationsForField("ClickConversion")[0], (int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.ClickConversionEntity, 0, null, null, null, null, "ClickConversion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectCustomerCall' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectCustomerCall
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ProspectCustomerCallEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerCallEntityFactory))),
					(IEntityRelation)GetRelationsForField("ProspectCustomerCall")[0], (int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.ProspectCustomerCallEntity, 0, null, null, null, null, "ProspectCustomerCall", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("ProspectCustomerNotification")[0], (int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.ProspectCustomerNotificationEntity, 0, null, null, null, null, "ProspectCustomerNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TempCart' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTempCart
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TempCartEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TempCartEntityFactory))),
					(IEntityRelation)GetRelationsForField("TempCart")[0], (int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.TempCartEntity, 0, null, null, null, null, "TempCart", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, GetRelationsForField("AccountCollectionViaCallQueueCustomer"), null, "AccountCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActivityType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActivityTypeCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.ActivityTypeEntity, 0, null, null, GetRelationsForField("ActivityTypeCollectionViaCallQueueCustomer"), null, "ActivityTypeCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.CallQueueEntity, 0, null, null, GetRelationsForField("CallQueueCollectionViaCallQueueCustomer"), null, "CallQueueCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCriteria' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCriteriaCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCriteriaEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.CallQueueCriteriaEntity, 0, null, null, GetRelationsForField("CallQueueCriteriaCollectionViaCallQueueCustomer"), null, "CallQueueCriteriaCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Calls' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallsCollectionViaProspectCustomerCall
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectCustomerEntity.Relations.ProspectCustomerCallEntityUsingProspectCustomerId;
				intermediateRelation.SetAliases(string.Empty, "ProspectCustomerCall_");
				return new PrefetchPathElement2(new EntityCollection<CallsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.CallsEntity, 0, null, null, GetRelationsForField("CallsCollectionViaProspectCustomerCall"), null, "CallsCollectionViaProspectCustomerCall", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Campaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.CampaignEntity, 0, null, null, GetRelationsForField("CampaignCollectionViaCallQueueCustomer"), null, "CampaignCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ChargeCard' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathChargeCardCollectionViaTempCart
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectCustomerEntity.Relations.TempCartEntityUsingProspectCustomerId;
				intermediateRelation.SetAliases(string.Empty, "TempCart_");
				return new PrefetchPathElement2(new EntityCollection<ChargeCardEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChargeCardEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.ChargeCardEntity, 0, null, null, GetRelationsForField("ChargeCardCollectionViaTempCart"), null, "ChargeCardCollectionViaTempCart", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ClickLog' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathClickLogCollectionViaClickConversion
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectCustomerEntity.Relations.ClickConversionEntityUsingProspectCustomerId;
				intermediateRelation.SetAliases(string.Empty, "ClickConversion_");
				return new PrefetchPathElement2(new EntityCollection<ClickLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClickLogEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.ClickLogEntity, 0, null, null, GetRelationsForField("ClickLogCollectionViaClickConversion"), null, "ClickLogCollectionViaClickConversion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCallQueueCustomer"), null, "CustomerProfileCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaClickConversion
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectCustomerEntity.Relations.ClickConversionEntityUsingProspectCustomerId;
				intermediateRelation.SetAliases(string.Empty, "ClickConversion_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaClickConversion"), null, "CustomerProfileCollectionViaClickConversion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaTempCart
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectCustomerEntity.Relations.TempCartEntityUsingProspectCustomerId;
				intermediateRelation.SetAliases(string.Empty, "TempCart_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaTempCart"), null, "CustomerProfileCollectionViaTempCart", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Eligibility' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEligibilityCollectionViaTempCart
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectCustomerEntity.Relations.TempCartEntityUsingProspectCustomerId;
				intermediateRelation.SetAliases(string.Empty, "TempCart_");
				return new PrefetchPathElement2(new EntityCollection<EligibilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EligibilityEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.EligibilityEntity, 0, null, null, GetRelationsForField("EligibilityCollectionViaTempCart"), null, "EligibilityCollectionViaTempCart", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaCallQueueCustomer"), null, "EventCustomersCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaClickConversion
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectCustomerEntity.Relations.ClickConversionEntityUsingProspectCustomerId;
				intermediateRelation.SetAliases(string.Empty, "ClickConversion_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaClickConversion"), null, "EventCustomersCollectionViaClickConversion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaCallQueueCustomer"), null, "EventsCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Language' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLanguageCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.LanguageEntity, 0, null, null, GetRelationsForField("LanguageCollectionViaCallQueueCustomer"), null, "LanguageCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCallQueueCustomer"), null, "LookupCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotesDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotesDetailsCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.NotesDetailsEntity, 0, null, null, GetRelationsForField("NotesDetailsCollectionViaCallQueueCustomer"), null, "NotesDetailsCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Notification' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotificationCollectionViaProspectCustomerNotification
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectCustomerEntity.Relations.ProspectCustomerNotificationEntityUsingProspectCustomerId;
				intermediateRelation.SetAliases(string.Empty, "ProspectCustomerNotification_");
				return new PrefetchPathElement2(new EntityCollection<NotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.NotificationEntity, 0, null, null, GetRelationsForField("NotificationCollectionViaProspectCustomerNotification"), null, "NotificationCollectionViaProspectCustomerNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueCustomer"), null, "OrganizationRoleUserCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueCustomer__
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueCustomer__"), null, "OrganizationRoleUserCollectionViaCallQueueCustomer__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueCustomer_
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectCustomerEntity.Relations.CallQueueCustomerEntityUsingProspectCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueCustomer_"), null, "OrganizationRoleUserCollectionViaCallQueueCustomer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfaffiliateCampaignMarketingMaterial' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfaffiliateCampaignMarketingMaterial
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignMarketingMaterialEntityFactory))),
					(IEntityRelation)GetRelationsForField("AfaffiliateCampaignMarketingMaterial")[0], (int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.AfaffiliateCampaignMarketingMaterialEntity, 0, null, null, null, null, "AfaffiliateCampaignMarketingMaterial", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("CustomerProfile")[0], (int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, null, null, "CustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.ProspectCustomerEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ProspectCustomerEntity.CustomProperties;}
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
			get { return ProspectCustomerEntity.FieldsCustomProperties;}
		}

		/// <summary> The ProspectCustomerId property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."ProspectCustomerID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ProspectCustomerId
		{
			get { return (System.Int64)GetValue((int)ProspectCustomerFieldIndex.ProspectCustomerId, true); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.ProspectCustomerId, value); }
		}

		/// <summary> The FirstName property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."FirstName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String FirstName
		{
			get { return (System.String)GetValue((int)ProspectCustomerFieldIndex.FirstName, true); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.FirstName, value); }
		}

		/// <summary> The LastName property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."LastName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String LastName
		{
			get { return (System.String)GetValue((int)ProspectCustomerFieldIndex.LastName, true); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.LastName, value); }
		}

		/// <summary> The ZipCode property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."ZipCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ZipCode
		{
			get { return (System.String)GetValue((int)ProspectCustomerFieldIndex.ZipCode, true); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.ZipCode, value); }
		}

		/// <summary> The CallbackNo property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."CallbackNo"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CallbackNo
		{
			get { return (System.String)GetValue((int)ProspectCustomerFieldIndex.CallbackNo, true); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.CallbackNo, value); }
		}

		/// <summary> The CustomerId property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."CustomerID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CustomerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ProspectCustomerFieldIndex.CustomerId, false); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.CustomerId, value); }
		}

		/// <summary> The DateCreated property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)ProspectCustomerFieldIndex.DateCreated, true); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.DateCreated, value); }
		}

		/// <summary> The Address1 property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."Address1"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Address1
		{
			get { return (System.String)GetValue((int)ProspectCustomerFieldIndex.Address1, true); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.Address1, value); }
		}

		/// <summary> The Address2 property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."Address2"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Address2
		{
			get { return (System.String)GetValue((int)ProspectCustomerFieldIndex.Address2, true); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.Address2, value); }
		}

		/// <summary> The City property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."City"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String City
		{
			get { return (System.String)GetValue((int)ProspectCustomerFieldIndex.City, true); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.City, value); }
		}

		/// <summary> The State property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."State"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String State
		{
			get { return (System.String)GetValue((int)ProspectCustomerFieldIndex.State, true); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.State, value); }
		}

		/// <summary> The Dob property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."DOB"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> Dob
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ProspectCustomerFieldIndex.Dob, false); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.Dob, value); }
		}

		/// <summary> The Email property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."Email"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Email
		{
			get { return (System.String)GetValue((int)ProspectCustomerFieldIndex.Email, true); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.Email, value); }
		}

		/// <summary> The Phone2 property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."Phone2"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Phone2
		{
			get { return (System.String)GetValue((int)ProspectCustomerFieldIndex.Phone2, true); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.Phone2, value); }
		}

		/// <summary> The IsConverted property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."IsConverted"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsConverted
		{
			get { return (Nullable<System.Boolean>)GetValue((int)ProspectCustomerFieldIndex.IsConverted, false); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.IsConverted, value); }
		}

		/// <summary> The DateConverted property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."DateConverted"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateConverted
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ProspectCustomerFieldIndex.DateConverted, false); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.DateConverted, value); }
		}

		/// <summary> The Source property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."Source"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Source
		{
			get { return (System.Int64)GetValue((int)ProspectCustomerFieldIndex.Source, true); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.Source, value); }
		}

		/// <summary> The Tag property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."Tag"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Tag
		{
			get { return (System.String)GetValue((int)ProspectCustomerFieldIndex.Tag, true); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.Tag, value); }
		}

		/// <summary> The AffiliateCampaignMarketingMaterialId property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."AffiliateCampaignMarketingMaterialID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> AffiliateCampaignMarketingMaterialId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ProspectCustomerFieldIndex.AffiliateCampaignMarketingMaterialId, false); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.AffiliateCampaignMarketingMaterialId, value); }
		}

		/// <summary> The MarketingSource property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."MarketingSource"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MarketingSource
		{
			get { return (System.String)GetValue((int)ProspectCustomerFieldIndex.MarketingSource, true); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.MarketingSource, value); }
		}

		/// <summary> The IsQueuedForCallBack property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."IsQueuedForCallBack"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsQueuedForCallBack
		{
			get { return (System.Boolean)GetValue((int)ProspectCustomerFieldIndex.IsQueuedForCallBack, true); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.IsQueuedForCallBack, value); }
		}

		/// <summary> The SourceCodeId property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."SourceCodeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SourceCodeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ProspectCustomerFieldIndex.SourceCodeId, false); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.SourceCodeId, value); }
		}

		/// <summary> The IncomingPhoneLine property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."IncomingPhoneLine"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 20<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String IncomingPhoneLine
		{
			get { return (System.String)GetValue((int)ProspectCustomerFieldIndex.IncomingPhoneLine, true); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.IncomingPhoneLine, value); }
		}

		/// <summary> The ProspectListId property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."ProspectListID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ProspectListId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ProspectCustomerFieldIndex.ProspectListId, false); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.ProspectListId, value); }
		}

		/// <summary> The Gender property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."Gender"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 10<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Gender
		{
			get { return (System.String)GetValue((int)ProspectCustomerFieldIndex.Gender, true); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.Gender, value); }
		}

		/// <summary> The Status property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."Status"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Status
		{
			get { return (System.Int64)GetValue((int)ProspectCustomerFieldIndex.Status, true); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.Status, value); }
		}

		/// <summary> The IsContacted property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."IsContacted"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsContacted
		{
			get { return (System.Boolean)GetValue((int)ProspectCustomerFieldIndex.IsContacted, true); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.IsContacted, value); }
		}

		/// <summary> The ContactedDate property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."ContactedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ContactedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ProspectCustomerFieldIndex.ContactedDate, false); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.ContactedDate, value); }
		}

		/// <summary> The ContactedBy property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."ContactedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ContactedBy
		{
			get { return (Nullable<System.Int64>)GetValue((int)ProspectCustomerFieldIndex.ContactedBy, false); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.ContactedBy, value); }
		}

		/// <summary> The CallBackRequestedOn property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."CallBackRequestedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> CallBackRequestedOn
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ProspectCustomerFieldIndex.CallBackRequestedOn, false); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.CallBackRequestedOn, value); }
		}

		/// <summary> The CallBackRequestedDate property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."CallBackRequestedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> CallBackRequestedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ProspectCustomerFieldIndex.CallBackRequestedDate, false); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.CallBackRequestedDate, value); }
		}

		/// <summary> The TagUpdateDate property of the Entity ProspectCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspectCustomer"."TagUpdateDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> TagUpdateDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ProspectCustomerFieldIndex.TagUpdateDate, false); }
			set	{ SetValue((int)ProspectCustomerFieldIndex.TagUpdateDate, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueCustomerEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueCustomerEntity))]
		public virtual EntityCollection<CallQueueCustomerEntity> CallQueueCustomer
		{
			get
			{
				if(_callQueueCustomer==null)
				{
					_callQueueCustomer = new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory)));
					_callQueueCustomer.SetContainingEntityInfo(this, "ProspectCustomer");
				}
				return _callQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ClickConversionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ClickConversionEntity))]
		public virtual EntityCollection<ClickConversionEntity> ClickConversion
		{
			get
			{
				if(_clickConversion==null)
				{
					_clickConversion = new EntityCollection<ClickConversionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClickConversionEntityFactory)));
					_clickConversion.SetContainingEntityInfo(this, "ProspectCustomer");
				}
				return _clickConversion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectCustomerCallEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectCustomerCallEntity))]
		public virtual EntityCollection<ProspectCustomerCallEntity> ProspectCustomerCall
		{
			get
			{
				if(_prospectCustomerCall==null)
				{
					_prospectCustomerCall = new EntityCollection<ProspectCustomerCallEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerCallEntityFactory)));
					_prospectCustomerCall.SetContainingEntityInfo(this, "ProspectCustomer");
				}
				return _prospectCustomerCall;
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
					_prospectCustomerNotification.SetContainingEntityInfo(this, "ProspectCustomer");
				}
				return _prospectCustomerNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TempCartEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TempCartEntity))]
		public virtual EntityCollection<TempCartEntity> TempCart
		{
			get
			{
				if(_tempCart==null)
				{
					_tempCart = new EntityCollection<TempCartEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TempCartEntityFactory)));
					_tempCart.SetContainingEntityInfo(this, "ProspectCustomer");
				}
				return _tempCart;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountEntity))]
		public virtual EntityCollection<AccountEntity> AccountCollectionViaCallQueueCustomer
		{
			get
			{
				if(_accountCollectionViaCallQueueCustomer==null)
				{
					_accountCollectionViaCallQueueCustomer = new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory)));
					_accountCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _accountCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ActivityTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ActivityTypeEntity))]
		public virtual EntityCollection<ActivityTypeEntity> ActivityTypeCollectionViaCallQueueCustomer
		{
			get
			{
				if(_activityTypeCollectionViaCallQueueCustomer==null)
				{
					_activityTypeCollectionViaCallQueueCustomer = new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory)));
					_activityTypeCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _activityTypeCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueEntity))]
		public virtual EntityCollection<CallQueueEntity> CallQueueCollectionViaCallQueueCustomer
		{
			get
			{
				if(_callQueueCollectionViaCallQueueCustomer==null)
				{
					_callQueueCollectionViaCallQueueCustomer = new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory)));
					_callQueueCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _callQueueCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueCriteriaEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueCriteriaEntity))]
		public virtual EntityCollection<CallQueueCriteriaEntity> CallQueueCriteriaCollectionViaCallQueueCustomer
		{
			get
			{
				if(_callQueueCriteriaCollectionViaCallQueueCustomer==null)
				{
					_callQueueCriteriaCollectionViaCallQueueCustomer = new EntityCollection<CallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCriteriaEntityFactory)));
					_callQueueCriteriaCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _callQueueCriteriaCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallsEntity))]
		public virtual EntityCollection<CallsEntity> CallsCollectionViaProspectCustomerCall
		{
			get
			{
				if(_callsCollectionViaProspectCustomerCall==null)
				{
					_callsCollectionViaProspectCustomerCall = new EntityCollection<CallsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory)));
					_callsCollectionViaProspectCustomerCall.IsReadOnly=true;
				}
				return _callsCollectionViaProspectCustomerCall;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CampaignEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CampaignEntity))]
		public virtual EntityCollection<CampaignEntity> CampaignCollectionViaCallQueueCustomer
		{
			get
			{
				if(_campaignCollectionViaCallQueueCustomer==null)
				{
					_campaignCollectionViaCallQueueCustomer = new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory)));
					_campaignCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _campaignCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ChargeCardEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ChargeCardEntity))]
		public virtual EntityCollection<ChargeCardEntity> ChargeCardCollectionViaTempCart
		{
			get
			{
				if(_chargeCardCollectionViaTempCart==null)
				{
					_chargeCardCollectionViaTempCart = new EntityCollection<ChargeCardEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ChargeCardEntityFactory)));
					_chargeCardCollectionViaTempCart.IsReadOnly=true;
				}
				return _chargeCardCollectionViaTempCart;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ClickLogEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ClickLogEntity))]
		public virtual EntityCollection<ClickLogEntity> ClickLogCollectionViaClickConversion
		{
			get
			{
				if(_clickLogCollectionViaClickConversion==null)
				{
					_clickLogCollectionViaClickConversion = new EntityCollection<ClickLogEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClickLogEntityFactory)));
					_clickLogCollectionViaClickConversion.IsReadOnly=true;
				}
				return _clickLogCollectionViaClickConversion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCallQueueCustomer
		{
			get
			{
				if(_customerProfileCollectionViaCallQueueCustomer==null)
				{
					_customerProfileCollectionViaCallQueueCustomer = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaClickConversion
		{
			get
			{
				if(_customerProfileCollectionViaClickConversion==null)
				{
					_customerProfileCollectionViaClickConversion = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaClickConversion.IsReadOnly=true;
				}
				return _customerProfileCollectionViaClickConversion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaTempCart
		{
			get
			{
				if(_customerProfileCollectionViaTempCart==null)
				{
					_customerProfileCollectionViaTempCart = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaTempCart.IsReadOnly=true;
				}
				return _customerProfileCollectionViaTempCart;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EligibilityEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EligibilityEntity))]
		public virtual EntityCollection<EligibilityEntity> EligibilityCollectionViaTempCart
		{
			get
			{
				if(_eligibilityCollectionViaTempCart==null)
				{
					_eligibilityCollectionViaTempCart = new EntityCollection<EligibilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EligibilityEntityFactory)));
					_eligibilityCollectionViaTempCart.IsReadOnly=true;
				}
				return _eligibilityCollectionViaTempCart;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaCallQueueCustomer
		{
			get
			{
				if(_eventCustomersCollectionViaCallQueueCustomer==null)
				{
					_eventCustomersCollectionViaCallQueueCustomer = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaClickConversion
		{
			get
			{
				if(_eventCustomersCollectionViaClickConversion==null)
				{
					_eventCustomersCollectionViaClickConversion = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaClickConversion.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaClickConversion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaCallQueueCustomer
		{
			get
			{
				if(_eventsCollectionViaCallQueueCustomer==null)
				{
					_eventsCollectionViaCallQueueCustomer = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _eventsCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LanguageEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LanguageEntity))]
		public virtual EntityCollection<LanguageEntity> LanguageCollectionViaCallQueueCustomer
		{
			get
			{
				if(_languageCollectionViaCallQueueCustomer==null)
				{
					_languageCollectionViaCallQueueCustomer = new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory)));
					_languageCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _languageCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCallQueueCustomer
		{
			get
			{
				if(_lookupCollectionViaCallQueueCustomer==null)
				{
					_lookupCollectionViaCallQueueCustomer = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _lookupCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NotesDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NotesDetailsEntity))]
		public virtual EntityCollection<NotesDetailsEntity> NotesDetailsCollectionViaCallQueueCustomer
		{
			get
			{
				if(_notesDetailsCollectionViaCallQueueCustomer==null)
				{
					_notesDetailsCollectionViaCallQueueCustomer = new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory)));
					_notesDetailsCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _notesDetailsCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NotificationEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NotificationEntity))]
		public virtual EntityCollection<NotificationEntity> NotificationCollectionViaProspectCustomerNotification
		{
			get
			{
				if(_notificationCollectionViaProspectCustomerNotification==null)
				{
					_notificationCollectionViaProspectCustomerNotification = new EntityCollection<NotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotificationEntityFactory)));
					_notificationCollectionViaProspectCustomerNotification.IsReadOnly=true;
				}
				return _notificationCollectionViaProspectCustomerNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCallQueueCustomer
		{
			get
			{
				if(_organizationRoleUserCollectionViaCallQueueCustomer==null)
				{
					_organizationRoleUserCollectionViaCallQueueCustomer = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCallQueueCustomer__
		{
			get
			{
				if(_organizationRoleUserCollectionViaCallQueueCustomer__==null)
				{
					_organizationRoleUserCollectionViaCallQueueCustomer__ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCallQueueCustomer__.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCallQueueCustomer__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCallQueueCustomer_
		{
			get
			{
				if(_organizationRoleUserCollectionViaCallQueueCustomer_==null)
				{
					_organizationRoleUserCollectionViaCallQueueCustomer_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCallQueueCustomer_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCallQueueCustomer_;
			}
		}

		/// <summary> Gets / sets related entity of type 'AfaffiliateCampaignMarketingMaterialEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AfaffiliateCampaignMarketingMaterialEntity AfaffiliateCampaignMarketingMaterial
		{
			get
			{
				return _afaffiliateCampaignMarketingMaterial;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAfaffiliateCampaignMarketingMaterial(value);
				}
				else
				{
					if(value==null)
					{
						if(_afaffiliateCampaignMarketingMaterial != null)
						{
							_afaffiliateCampaignMarketingMaterial.UnsetRelatedEntity(this, "ProspectCustomer");
						}
					}
					else
					{
						if(_afaffiliateCampaignMarketingMaterial!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ProspectCustomer");
						}
					}
				}
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
							_customerProfile.UnsetRelatedEntity(this, "ProspectCustomer");
						}
					}
					else
					{
						if(_customerProfile!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ProspectCustomer");
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
							_lookup.UnsetRelatedEntity(this, "ProspectCustomer");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ProspectCustomer");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "ProspectCustomer");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "ProspectCustomer");
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
			get { return (int)Falcon.Data.EntityType.ProspectCustomerEntity; }
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
